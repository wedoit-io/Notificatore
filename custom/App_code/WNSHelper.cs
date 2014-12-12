using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Web;


class WNSHelperInde
{
    #region Windows Store


    /// <summary>
    /// Permette l'invio di un messaggio Toast attraverso WNS
    /// </summary>
    /// <param name="accessToken">Access tocken ottenuto dalla chiamata a GetWinStoreAccessToken </param>
    /// <param name="uri">Url ottenuto dalla registrazione del dispositivo</param>
    /// <param name="xml">Xml del messaggio da spedire</param>
    /// <param name="infoInde">Messaggio di ritorno esito operazione</param>
    /// <returns>Codice numerico esito operazione</returns>
    public static int SendWinStorePushNotification(string accessToken, string uri, string xml, out com.progamma.IDVariant infoInde)
    {
        int returnCode = -1;
        string resultText = string.Empty;
        try
        {
             byte[] contentInBytes = Encoding.UTF8.GetBytes(xml);

            HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";

            // X-WNS-Type: wns/toast | wns/badge | wns/tile | wns/raw
            string notificationType = "wns/toast";
            if (xml.Trim().ToLower().StartsWith("<tile"))
            {
                notificationType = "wns/tile";
            }
            else if (xml.Trim().ToLower().StartsWith("<badge"))
            {
                notificationType = "wns/badge";
            }
            

            request.Headers.Add("X-WNS-Type", notificationType);
            request.ContentType = "text/xml";
            request.Headers.Add("Authorization", String.Format("Bearer {0}", accessToken));

            using (Stream requestStream = request.GetRequestStream())
                requestStream.Write(contentInBytes, 0, contentInBytes.Length);

            using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
            {
                string error = webResponse.Headers["X-WNS-Error-Description"];
                resultText = webResponse.StatusCode.ToString() + " | " + webResponse.Headers["X-WNS-NotificationStatus"];
                if (!string.IsNullOrEmpty(error))
                    resultText += " | " + error;
            }
        }
        catch (WebException webException)
        {
            string exceptionDetails = webException.Response.Headers["WWW-Authenticate"];
            if (exceptionDetails != null && exceptionDetails.Contains("Token expired"))
            {
                //Tocken expired, rinnovare il tocken e riprovare invio
                returnCode = 100;
                resultText = "EXCEPTION: Token expired";
            }
            else
            {
                //Errore chiamata
                returnCode = 101;
                // Log the response
                resultText = "EXCEPTION: " + webException.Message;
            }
        }
        catch (Exception ex)
        {
            //Errore generico
            returnCode = 199;
            resultText = "EXCEPTION: " + ex.Message;
        }

        //infoInde = resultText;
        infoInde = new com.progamma.IDVariant();
        infoInde.set(new com.progamma.IDVariant(resultText));
        return returnCode;
    }

    /// <summary>
    /// Invio di una notifica push WNS per le applicazioni Windows Store
    /// http://msdn.microsoft.com/en-us/library/windows/apps/xaml/Hh868252(v=win.10).aspx
    /// </summary>
    /// <param name="secret">Client secret fornito dallo store a seguito della creazione di una app abilitata alle notifiche</param>
    /// <param name="sid">Package Security Identifier (SID) fornito dallo store a seguito della creazione di una app abilitata alle notifiche</param>
    /// <param name="uri">Url ottenuto dalla registrazione del dispositivo</param>
    /// <param name="xml"></param>
    /// <param name="notificationType">The X-WNS-Type header specifies whether this is a tile, toast, badge, or raw notification. X-WNS-Type: wns/toast | wns/badge | wns/tile | wns/raw</param>
    /// <param name="contentType">The Content-Type is set depending on the value of the X-WNS-Type http://msdn.microsoft.com/en-us/library/windows/apps/xaml/hh868221.aspx </param>
    /// <returns>Codici di ritorno: http://msdn.microsoft.com/it-it/library/windows/apps/hh465435.aspx</returns>
    public static string SendWinStorePushNotification(string secret, string sid, string uri, string xml, string notificationType, string contentType)
    {
        try
        {
            // You should cache this access token.
            string accessToken = GetWinStoreAccessToken(secret, sid);

            byte[] contentInBytes = Encoding.UTF8.GetBytes(xml);

            HttpWebRequest request = HttpWebRequest.Create(uri) as HttpWebRequest;
            request.Method = "POST";
            request.Headers.Add("X-WNS-Type", notificationType);
            request.ContentType = contentType;
            request.Headers.Add("Authorization", String.Format("Bearer {0}", accessToken));

            using (Stream requestStream = request.GetRequestStream())
                requestStream.Write(contentInBytes, 0, contentInBytes.Length);

            using (HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse())
                return webResponse.StatusCode.ToString();

        }
        catch (WebException webException)
        {
            string exceptionDetails = webException.Response.Headers["WWW-Authenticate"];
            if (exceptionDetails.Contains("Token expired"))
            {
                GetWinStoreAccessToken(secret, sid);

                // We suggest that you implement a maximum retry policy.
                return SendWinStorePushNotification(uri, xml, secret, sid, notificationType, contentType);
            }
            else
            {
                // Log the response
                return "EXCEPTION: " + webException.Message;
            }
        }
        catch (Exception ex)
        {
            return "EXCEPTION: " + ex.Message;
        }
    }

    
    public static string GetWinStoreAccessToken(string secret, string sid)
    {
        string accesstocket = string.Empty;
        string urlEncodedSecret = HttpUtility.UrlEncode(secret);
        string urlEncodedSid = HttpUtility.UrlEncode(sid);

        string body = String.Format("grant_type=client_credentials&client_id={0}&client_secret={1}&scope=notify.windows.com",
                                 urlEncodedSid,
                                 urlEncodedSecret);

        string responseJson;
        using (WebClient client = new WebClient())
        {
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            responseJson = client.UploadString("https://login.live.com/accesstoken.srf", body);
        }

        //E' necessario accedere alle librerie che sono sul framework 4.0 tramite reflection perchè su inde la compilazione viene fatta solo al frk 2.0. Sul server deve cmq esserci il frk 4
        Assembly WebExt = Assembly.LoadWithPartialName("System.Web.Extensions");
        Object serializer = WebExt.CreateInstance("System.Web.Script.Serialization.JavaScriptSerializer", true, BindingFlags.CreateInstance, null, null, null, null);

        MethodInfo method = serializer.GetType().GetMethod("DeserializeObject", new Type[] { typeof(String) });
        Dictionary<string, object> dict = (Dictionary<string, object>)method.Invoke(serializer, new Object[] { responseJson });

        foreach (string strKey in dict.Keys)
        {
            if (strKey.Equals("access_token"))
            {
                //Errore su tutto l'invio
                //TODO: prevedere un invio di tentativi
                accesstocket = dict[strKey].ToString();
            }
        }

        return accesstocket;
    }



    

    #endregion

        #region Windows Phone

    public static int SendWinPhonePushNotification(string subscriptionUri, string xml, out com.progamma.IDVariant infoInde)
    {
        int returnCode = -1;
        string resultText = string.Empty;

        string notificationType = "toast";
        if (xml.Trim().ToLower().Contains("<wp:tile>"))
        {
            notificationType = "token";
        }
        try
        {
            resultText = SendWinPhonePushNotification(subscriptionUri, xml, notificationType);
        }
        catch (Exception ex)
        {
            //Errore generico
            returnCode = 199;
            resultText = "EXCEPTION: " + ex.Message;
        }
        //infoInde = resultText;
        infoInde = new com.progamma.IDVariant();
        infoInde.set(new com.progamma.IDVariant(resultText));
        return returnCode;
    }

    //TODO: gestire i casi di errore: http://msdn.microsoft.com/en-us/library/hh202940(v=vs.92).aspx
    public static string SendWinPhonePushNotification(string subscriptionUri, string xml, string notificationType)
    {
        //http://msdn.microsoft.com/en-us/library/hh202967(v=vs.92).aspx

            // Get the URI that the Microsoft Push Notification Service returns to the push client when creating a notification channel.
            // Normally, a web service would listen for URIs coming from the web client and maintain a list of URIs to send
            // notifications out to.

            HttpWebRequest sendNotificationRequest = (HttpWebRequest)WebRequest.Create(subscriptionUri);

            // Create an HTTPWebRequest that posts the toast notification to the Microsoft Push Notification Service.
            // HTTP POST is the only method allowed to send the notification.
            sendNotificationRequest.Method = "POST";

            // The optional custom header X-MessageID uniquely identifies a notification message. 
            // If it is present, the same value is returned in the notification response. It must be a string that contains a UUID.
            // sendNotificationRequest.Headers.Add("X-MessageID", "<UUID>");

            // Set the notification payload to send.
            byte[] notificationMessage = Encoding.Default.GetBytes(xml);

            // Set the web request content length.
            sendNotificationRequest.ContentLength = notificationMessage.Length;
            sendNotificationRequest.ContentType = "text/xml";
            sendNotificationRequest.Headers.Add("X-WindowsPhone-Target", notificationType);
            if (notificationType == "token")
                sendNotificationRequest.Headers.Add("X-NotificationClass", "1");
            else
                sendNotificationRequest.Headers.Add("X-NotificationClass", "2");


            using (System.IO.Stream requestStream = sendNotificationRequest.GetRequestStream())
            {
                requestStream.Write(notificationMessage, 0, notificationMessage.Length);
            }

            // Send the notification and get the response.
            HttpWebResponse response = (HttpWebResponse)sendNotificationRequest.GetResponse();
            string notificationStatus = response.Headers["X-NotificationStatus"];
            string notificationChannelStatus = response.Headers["X-SubscriptionStatus"];
            string deviceConnectionStatus = response.Headers["X-DeviceConnectionStatus"];

            // Display the response from the Microsoft Push Notification Service.  
            // Normally, error handling code would be here. In the real world, because data connections are not always available,
            // notifications may need to be throttled back if the device cannot be reached.
            return notificationStatus + " | " + deviceConnectionStatus + " | " + notificationChannelStatus;

    }

    //TODO: gestire i casi di errore: http://msdn.microsoft.com/en-us/library/hh202940(v=vs.92).aspx
    public static string SendWinPhonePushNotificationToast(string subscriptionUri, string titleText, string descriptionText, string parameters)
    {
        //http://msdn.microsoft.com/en-us/library/hh202967(v=vs.92).aspx
        try
        {
            // Get the URI that the Microsoft Push Notification Service returns to the push client when creating a notification channel.
            // Normally, a web service would listen for URIs coming from the web client and maintain a list of URIs to send
            // notifications out to.

            HttpWebRequest sendNotificationRequest = (HttpWebRequest)WebRequest.Create(subscriptionUri);

            // Create an HTTPWebRequest that posts the toast notification to the Microsoft Push Notification Service.
            // HTTP POST is the only method allowed to send the notification.
            sendNotificationRequest.Method = "POST";

            // The optional custom header X-MessageID uniquely identifies a notification message. 
            // If it is present, the same value is returned in the notification response. It must be a string that contains a UUID.
            // sendNotificationRequest.Headers.Add("X-MessageID", "<UUID>");

            // Create the toast message.
            string toastMessage = "<?xml version=\"1.0\" encoding=\"utf-8\"?>" +
            "<wp:Notification xmlns:wp=\"WPNotification\">" +
               "<wp:Toast>" +
                    "<wp:Text1>" + titleText + "</wp:Text1>" +
                    "<wp:Text2>" + descriptionText + "</wp:Text2>" +
                    "<wp:Param>" + parameters + "</wp:Param>" +
               "</wp:Toast> " +
            "</wp:Notification>";

            return SendWinPhonePushNotification(subscriptionUri, toastMessage, "toast");
        }
        catch (Exception ex)
        {
            return "Exception caught sending update: " + ex.ToString();
        }
    }

    #endregion

}

