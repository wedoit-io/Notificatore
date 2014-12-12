using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Net;
using System.Web;
using System.IO;

class C2DMService
{
		private const string GoogleMessageUrl = "http://android.clients.google.com/c2dm/send";
    // Post data parameters
    private const string RegistrationIdParam = "registration_id";
    private const string CollapseKeyParam = "collapse_key";
    private const string DataPayloadParam = "data.message";
    private const string DelayWhileIdleParam = "delay_while_idle";
    
    public static string GetGoogleAuthToken(string pEMail, string pPassword)
    {
        string googleAuthToken = string.Empty;
        string authUrl = "https://www.google.com/accounts/ClientLogin";
        NameValueCollection data = new NameValueCollection();

        data.Add("Email", pEMail);
        data.Add("Passwd", pPassword);
        data.Add("accountType", "GOOGLE_OR_HOSTED");
        data.Add("service", "ac2dm");
        data.Add("source", "ApexnetPushServer");

        WebClient wc = new WebClient();

        try
        {
            string authStr = Encoding.ASCII.GetString(wc.UploadValues(authUrl, data));

            //Only care about the Auth= part at the end
            if (authStr.Contains("Auth="))
                googleAuthToken = authStr.Substring(authStr.IndexOf("Auth=") + 5);
            else
                googleAuthToken = "Missing Auth Token";
        }
        catch (WebException ex)
        {
            string result = "Unknown Error";
            try { result = (new System.IO.StreamReader(ex.Response.GetResponseStream())).ReadToEnd(); }
            catch { }

            googleAuthToken = result;
        }
        return googleAuthToken;
    }

 public static int SendMessage(string googleLoginAuthorizationToken, string registrationId, string messageText, out com.progamma.IDVariant info)
    {
        int ritorno = -1;
        string infoRitorno = string.Empty;
        info = new com.progamma.IDVariant();
        
        StringBuilder sb = new StringBuilder();
        string collapseKey = Guid.NewGuid().ToString("n");

        ServicePointManager.ServerCertificateValidationCallback += delegate(
                                            object sender,
                                            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                            System.Security.Cryptography.X509Certificates.X509Chain chain,
                                            System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };


        HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(GoogleMessageUrl);
        webReq.Method = "POST";
        webReq.KeepAlive = false;

        NameValueCollection postFieldNameValue = new NameValueCollection();
        postFieldNameValue.Add(RegistrationIdParam, registrationId);
        postFieldNameValue.Add(CollapseKeyParam, collapseKey);
        postFieldNameValue.Add(DelayWhileIdleParam, "0");
        postFieldNameValue.Add(DataPayloadParam, messageText);

        string postData = GetPostStringFrom(postFieldNameValue);
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);

        webReq.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
        webReq.ContentLength = byteArray.Length;

        webReq.Headers.Add(HttpRequestHeader.Authorization, "GoogleLogin auth=" + googleLoginAuthorizationToken);

        Stream dataStream = webReq.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();

        try
        {
            HttpWebResponse webResp = webReq.GetResponse() as HttpWebResponse;

            #region checking response

            if (webResp != null)
            {
                ritorno = 0;

                //Check for an updated auth token and store it here if necessary
                string updateClientAuth = webResp.GetResponseHeader("Update-Client-Auth");
                if (!string.IsNullOrEmpty(updateClientAuth))
                    ritorno = 100; //Errore legato alla necessità di creare un nuovo tocken di autorizzazione

                //Get the response body
                string responseBody = "Error=";
                try { responseBody = (new StreamReader(webResp.GetResponseStream())).ReadToEnd(); }
                catch { }

                //Handle the type of error
                if (responseBody.StartsWith("Error="))
                {
                    string wrErr = responseBody.Substring(responseBody.IndexOf("Error=") + 6);
                    switch (wrErr.ToLower().Trim())
                    {
                        case "quotaexceeded":
                            infoRitorno = "Error: " + "Quota Exceeded";
                            ritorno = 101; //QuotaExceeded;
                            break;
                        case "devicequotaexceeded":
                            infoRitorno = "Error: " + "Device Quota Exceeded";
                            ritorno = 102; //DeviceQuotaExceeded;
                            break;
                        case "invalidregistration":
                            infoRitorno = "Error: " + "Invalid Registration";
                            ritorno = 103; //InvalidRegistration;
                            break;
                        case "notregistered":
                            infoRitorno = "Error: " + "Not Registered";
                            ritorno = 104; //NotRegistered;
                            break;
                        case "messagetoobig":
                            infoRitorno = "Error: " + "Message Too Big";
                            ritorno = 105; //MessageTooBig;
                            break;
                        case "missingcollapsekey":
                            infoRitorno = "Error: " + "Missing CollapseKey";
                            ritorno = 106; //MissingCollapseKey;
                            break;
                        default:
                            infoRitorno = "Error: " + "Generic Error";
                            ritorno = 107; //Error;
                            break;
                    }
                }
                else
                {
                    //Get the message ID
                    if (responseBody.StartsWith("id="))
                        infoRitorno = "Message: " + responseBody.Trim();
                }
            }

            #endregion
        }
        catch (WebException webEx)
        {
            #region checking error

            HttpWebResponse webResp = webEx.Response as HttpWebResponse;

            if (webResp != null)
            {
                if (webResp.StatusCode == HttpStatusCode.Unauthorized)
                {
                    //401 bad auth token
                    ritorno = 108;
                    infoRitorno = "Error: " + "InvalidAuthToken";
                }
                else if (webResp.StatusCode == HttpStatusCode.ServiceUnavailable)
                {
                    //First try grabbing the retry-after header and parsing it.
                    TimeSpan retryAfter = new TimeSpan(0, 0, 120);

                    string wrRetryAfter = webResp.GetResponseHeader("Retry-After");

                    if (!string.IsNullOrEmpty(wrRetryAfter))
                    {
                        DateTime wrRetryAfterDate = DateTime.UtcNow;

                        if (DateTime.TryParse(wrRetryAfter, out wrRetryAfterDate))
                            retryAfter = wrRetryAfterDate - DateTime.UtcNow;
                        else
                        {
                            int wrRetryAfterSeconds = 120;
                            if (int.TryParse(wrRetryAfter, out wrRetryAfterSeconds))
                                retryAfter = new TimeSpan(0, 0, wrRetryAfterSeconds);
                        }
                    }

                    //503 exponential backoff, get retry-after header
                    ritorno = 109;
                    infoRitorno = "ServiceUnavailable";
                }
            }

            #endregion
        }
				info = new com.progamma.IDVariant();
        info.set(new com.progamma.IDVariant(infoRitorno));
        return ritorno;
    }

 		private static string GetPostStringFrom(NameValueCollection nameValuePair)
    {
        StringBuilder postString = new StringBuilder();
        for (int i = 0; i < nameValuePair.Count; i++)
        {
            postString.Append(nameValuePair.GetKey(i));
            postString.Append("=");
            postString.Append(Uri.EscapeDataString(nameValuePair[i]));
            if (i + 1 != nameValuePair.Count)
            {
                postString.Append("&");
            }
        }
        return postString.ToString();
    }

    public static string SendMessage(string pAuthString, string registrationId, string data)
    {

        ServicePointManager.ServerCertificateValidationCallback += delegate(
                                            object sender,
                                            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                                            System.Security.Cryptography.X509Certificates.X509Chain chain,
                                            System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        };

        string collapseKey = Guid.NewGuid().ToString("n");

        string url = "https://android.apis.google.com/c2dm/send";
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.Headers.Add("Authorization", "GoogleLogin auth=" + pAuthString
    );


        string px = "registration_id=" + registrationId + "&collapse_key=" + collapseKey + "&data.message=" + data;
        string encoded = px;

        ASCIIEncoding encoding = new ASCIIEncoding();
        byte[] buffer = encoding.GetBytes(encoded);

        System.IO.Stream newStream = request.GetRequestStream();
        newStream.Write(buffer, 0, buffer.Length);
        newStream.Close();


        System.Net.HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        if (response.StatusCode == HttpStatusCode.OK)
        {
            System.IO.Stream resStream = response.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(resStream);
            //    Console.Write(sr.ReadToEnd());
            sr.Close();
            resStream.Close();
        }
        //Console.WriteLine();
        //Console.ReadLine();

        return "";
    }

}
