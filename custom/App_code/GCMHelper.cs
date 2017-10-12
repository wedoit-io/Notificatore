using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Security;
using System.Reflection;

class GCMHelper
{
    /// <summary>
    /// Invio notifica con dati in json
    /// </summary>
    /// <param name="GoogleApiBrowserID">Key for browser apps generata dalla API console di google. Es: https://code.google.com/apis/console/#project:692207654898:access </param>
    /// <param name="jsonData">stringa json</param>
    /// <returns>json con esiti invii</returns>
    public static string SendNotification(string GoogleApiBrowserID, string jsonData)
    {
        try
        {
            //Preparing request
            HttpWebRequest tRequest = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
            tRequest.Method = "POST";
            tRequest.ContentType = "application/json";
            tRequest.Headers.Add(string.Format("Authorization:key={0}", GoogleApiBrowserID));
            byte[] byteArray = Encoding.UTF8.GetBytes(jsonData);
            tRequest.ContentLength = byteArray.Length;

            //-- Create Stream to Write Byte Array --// 
            Stream dataStream = tRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            //-- Post a Message --//
            WebResponse Response = tRequest.GetResponse();
            //HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;

            StreamReader Reader = new StreamReader(Response.GetResponseStream());
            string responseLine = Reader.ReadLine();
            //{"multicast_id":8887371922732547499,"success":1,"failure":0,"canonical_ids":0,"results":[{"message_id":"0:1344423811850493%67edbc55f9fd7ecd"}]}
            Reader.Close();

            return responseLine;
        }
        catch (Exception ex)
        {
            //Finisco qui in questi casi: http://developer.android.com/guide/google/gcm/gcm.html#response
            //Codice 400: errore nel formato json - Codice 401 Errore di autenticazione dell'account sender
            //Codice 5xx: errore GCM: riprovare invio in un secondo momento
            string jsonError = "{\"error\":";
            jsonError += "\"" + ex.Message + "\"}";
            return jsonError;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="GoogleApiBrowserID">Key for browser apps generata dalla API console di google. Es: https://code.google.com/apis/console/#project:692207654898:access </param>
    /// <param name="registrationIds">Chiavi di registrazione delle installazioni separate da ";"</param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static string SendNotification(string GoogleApiBrowserID, string registrationIds, string message)
    {
        //Preparing data
        String jsonData = ComposeJsonData(registrationIds, message);
        return SendNotification(GoogleApiBrowserID, jsonData);
    }

    public static string ComposeJsonData(string registrationIds, string message)
    {
        //Preparing data
        StringBuilder jsonData = new StringBuilder();
        jsonData.Append("{\"registration_ids\":[");
        String[] regIdsArray = registrationIds.Split(';');

        for (int i = 0; i < regIdsArray.Length; i++)
        {
            if (i > 0)
                jsonData.Append(string.Format(",\"{0}\"", regIdsArray[i]));
            else
                jsonData.Append(string.Format("\"{0}\"", regIdsArray[i]));
        }
        jsonData.Append("],\"data\":{\"message\":\"");
        message = message.Replace("\\", "\\\\");
        message = message.Replace("\"", "\\\"");
        jsonData.Append(message);
        jsonData.Append("\"}}");
        return jsonData.ToString();
    }
    
    
    public static int ParseResult(string inputRegIds, string rifRegId, string outputJson, out com.progamma.IDVariant infoInde)
    {
        //Errori su singoli invii: http://developer.android.com/guide/google/gcm/gcm.html#error_codes
        //Canonical id: http://developer.android.com/guide/google/gcm/adv.html#canonical : registration id multipli: rimpiazzare l'id di ritorno con l'id originario
        int returnCode = -1;
        string[] regIdsSpediti = inputRegIds.Split(',');

        int indexRefId = -1;
        for (int i = 0; i < regIdsSpediti.Length; i++)
        {
            if (regIdsSpediti[i].Equals(rifRegId))
                indexRefId = i;
        }

        if (indexRefId == -1)
        {
            //Elemento non trovato nel gruppo dei regId inviati     
        }

        //int indexRefId = regIdsSpediti.ToList().IndexOf(rifRegId);

        StringBuilder resultBuider = new StringBuilder();
       
				//E' necessario accedere alle librerie che sono sul framework 4.0 tramite reflection perchè su inde la compilazione viene fatta solo al frk 2.0. Sul server deve cmq esserci il frk 4
        Assembly WebExt = Assembly.LoadWithPartialName("System.Web.Extensions");
        Object serializer = WebExt.CreateInstance("System.Web.Script.Serialization.JavaScriptSerializer", true, BindingFlags.CreateInstance, null, null, null, null);

        MethodInfo method = serializer.GetType().GetMethod("DeserializeObject", new Type[] { typeof(String) });
        Dictionary<string, object> dict = (Dictionary<string, object>)method.Invoke(serializer, new Object[] { outputJson });

        foreach (string strKey in dict.Keys)
        {
            if (strKey.Equals("error"))
            {
                //Errore su tutto l'invio
                //TODO: prevedere un invio di tentativi
                returnCode = 200;
                resultBuider.Append(outputJson);
            }
            else if (strKey.Equals("results"))
            {
                if (dict[strKey] is Array)
                {
                    object[] results = (object[])(dict[strKey]);
                    int index = 0;
                    string messageId = string.Empty;
                    string error = string.Empty;
                    string canonicalId = string.Empty;

                    foreach (Dictionary<string, object> resultItem in results)
                    {
                        if (index == indexRefId)
                        {
                            foreach (string keyresult in resultItem.Keys)
                            {
                                if (keyresult.Equals("message_id"))
                                    messageId = resultItem[keyresult].ToString();
                                if (keyresult.Equals("error"))
                                    error = resultItem[keyresult].ToString();
                                if (keyresult.Equals("registration_id"))
                                    canonicalId = resultItem[keyresult].ToString();
                            }
                            if (!string.IsNullOrEmpty(error))
                            {
                                returnCode = getErrorCode(error);
                                resultBuider.Append(error);
                            }
                            else if (!string.IsNullOrEmpty(canonicalId))
                            {
                                returnCode = 10;
                                resultBuider.Append(canonicalId);
                            }
                            else if (!string.IsNullOrEmpty(messageId))
                            {
                                returnCode = 0;
                                resultBuider.Append(messageId);
                            }
                        }
                        index++;
                    }
                }
            }
        }
                
        infoInde = new com.progamma.IDVariant();
        infoInde.set(new com.progamma.IDVariant(resultBuider.ToString()));
        return returnCode;
    }

    private static int getErrorCode(string errorMessage)
    {
        //Riservati i codici da 100 a 199 per gli errori
        int ritorno = -1;
        switch (errorMessage)
        {
            case "MissingRegistration":
                ritorno = 101; //Check that the request contains a registration ID (either in the registration_id parameter in a plain text message, or in the registration_ids field in JSON).
                break;
            case "MismatchSenderId":
                ritorno = 102; //A registration ID is tied to a certain group of senders. When an application registers for GCM usage, it must specify which senders are allowed to send messages;
                break;
            case "InvalidRegistration":
                ritorno = 103; //Check the formatting of the registration ID that you pass to the server
                break;
            case "NotRegistered":
                ritorno = 104; //An existing registration ID may cease to be valid in a number of scenarios;
                break;
            case "MessageTooBig":
                ritorno = 105; //The total size of the payload data that is included in a message can't exceed 4096 bytes. Note that this includes both the size of the keys as well as the values.
                break;
            case "InvalidDataKey":
                ritorno = 106; //he payload data contains a key (such as from or any value prefixed by google.) that is used internally by GCM in the com.google.android.c2dm.intent.RECEIVE Intent and cannot be used
                break;
            case "InvalidTtl":
                ritorno = 107; //The value for the Time to Live field must be an integer representing a duration in seconds between 0 and 2,419,200 (4 weeks)
                break;
            default:
                ritorno = 199; //Error;
                break;
        }
        return ritorno;
    }

    /// <summary>
    /// Invio notifica con dati in post
    /// </summary>
    /// <param name="GoogleApiBrowserID">Key for browser apps generata dalla API console di google. Es: https://code.google.com/apis/console/#project:692207654898:access </param>
    /// <param name="deviceId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static string SendNotificationPlain(string GoogleApiBrowserID, string deviceId, string message, string customField1, string customField2)
    {
        String sResponseFromServer = string.Empty;
        try
        {
            WebRequest tRequest;
            tRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
            tRequest.Method = "POST";
            tRequest.ContentType = " application/x-www-form-urlencoded;charset=UTF-8";
            tRequest.Headers.Add(string.Format("Authorization:key={0}", GoogleApiBrowserID));

            //string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_ids=" + deviceId + "";
            //string postData = "data.message=" + message + "&registration_id=" + deviceId + "";
            string postData = String.Format(@"data.message={0}&registration_id={1}&data.custom-field-1={2}&data.custom-field-2={3}", System.Web.HttpUtility.UrlEncode(message), deviceId, System.Web.HttpUtility.UrlEncode(customField1), System.Web.HttpUtility.UrlEncode(customField2));
			

            //string postData = "{ 'registration_ids': [ '" + registrationId + "' ], 'data': {'message': '" + message + "'}}";

            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;

            Stream dataStream = tRequest.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();

            WebResponse tResponse = tRequest.GetResponse();

            dataStream = tResponse.GetResponseStream();

            StreamReader tReader = new StreamReader(dataStream);

            sResponseFromServer = tReader.ReadToEnd();

            tReader.Close();
            dataStream.Close();
            tResponse.Close();
        }
        catch (Exception ex)
        {
            //Finisco qui in questi casi: http://developer.android.com/guide/google/gcm/gcm.html#response
            //Codice 400: errore nel formato json - Codice 401 Errore di autenticazione dell'account sender
            //Codice 5xx: errore GCM: riprovare invio in un secondo momento
            return "GMCError=" + ex.Message;
        }
        return sResponseFromServer;
    }
    
    //com.progamma.IDVariant info) => su inde viene usato l'idvariant il parametro non va definito come di output
   public static int ParseResultPlain(string outputText, out com.progamma.IDVariant infoInde)
    {
        int returnCode = -1;
        string outInfo = outputText;
        if (outputText.ToLowerInvariant().StartsWith("gmcrror"))
        {
            //GMC server error
            returnCode = 200;
        }
        if (outputText.ToLowerInvariant().StartsWith("id"))
        {
            //id=0:1352894598679934%67edbc55f9fd7ecd
            returnCode = 0;
            outInfo = string.Empty;
        }
        if (outputText.ToLowerInvariant().StartsWith("error"))
        {
            //Error=InvalidRegistration
            int index = outputText.ToLowerInvariant().IndexOf("error=") + 6;
            string errorMessage = outputText.Substring(index, outputText.Length - index);
            returnCode = getErrorCode(errorMessage);
            outInfo = errorMessage;
        }
        if (outputText.ToLowerInvariant().Contains("registration_id"))
        {
            returnCode = 10;
            int index = outputText.ToLowerInvariant().IndexOf("registration_id=") + 16;
            outInfo = outputText.Substring(index, outputText.Length - index);
        }

        infoInde = new com.progamma.IDVariant();
        infoInde.set(new com.progamma.IDVariant(outInfo));
        //infoInde = outInfo;
        return returnCode;
    }
}

