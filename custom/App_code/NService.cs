using System;
using System.IO;
using System.Net;
using System.Text;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using JdSoft.Apple.Apns.Notifications;
using com.progamma;
using com.progamma.ids;


class NService
{

    static string devtkList;
    static string devtkError;

    public string devList;
    public string errList;

    //public string ErrorList = "";
    //public ArrayList devtkList = new ArrayList();

    public static void service_Error(object sender, Exception ex)
    {
       
        writeToLogFile(string.Format("Error: {0}", ex.Message));

        Console.WriteLine(string.Format("Error: {0}", ex.Message));

        //devtkList = devtkList + "|" + ex.Message;
    }
	
	public static void service_BadDeviceToken(object sender, BadDeviceTokenException ex)
	{
        writeToLogFile(string.Format("Bad Device Token: {0}", ex.Message));

		Console.WriteLine("Bad Device Token: {0}", ex.Message);
	}

    public static void service_Disconnected(object sender)
	{
        writeToLogFile("Disconnected...");
		Console.WriteLine("Disconnected...");
	}

    public static void service_Connected(object sender)
	{
   
		writeToLogFile("Connected...");
		Console.WriteLine("Connected...");
	}

    public static void service_Connecting(object sender)
	{
	    writeToLogFile("");
        writeToLogFile("Connecting...");
		Console.WriteLine("Connecting...");
	}

    public static void service_NotificationTooLong(object sender, NotificationLengthException ex)
	{
        writeToLogFile(string.Format("Notification Too Long: {0} - DeviceId: {1}", ex.Notification.ToString(), ex.Notification.DeviceToken));
        Console.WriteLine(string.Format("Notification Too Long: {0} - DeviceId: {1}", ex.Notification.ToString(), ex.Notification.DeviceToken));
	}

    public static void service_NotificationSuccess(object sender, Notification notification)
	{
        writeToLogFile(string.Format("Notification Success: {0} - DeviceId: {1}", notification.ToString(), notification.DeviceToken));
        Console.WriteLine(string.Format("Notification Success: {0} - DeviceId: {1}", notification.ToString(), notification.DeviceToken));
	}

    public static void service_NotificationFailed(object sender, Notification notification)
	{
        writeToLogFile(string.Format("Notification Failed: {0} - DeviceId: {1}", notification.ToString(), notification.DeviceToken));
        Console.WriteLine(string.Format("Notification Failed: {0} - DeviceId: {1}", notification.ToString(), notification.DeviceToken));
	}


    public static void writeToLogFile(string logMessage)
    {
        string strLogMessage = string.Empty;
        //string strLogFile = System.Configuration.ConfigurationManager.AppSettings["logFilePath"].ToString();
        //string strLogFile = @"c:\temp\Notificatore.log";
		string strLogFile = System.Web.HttpRuntime.AppDomainAppPath + @"temp\NotificationLOG.txt";
        StreamWriter swLog;

        strLogMessage = string.Format("{0}: {1}", DateTime.Now, logMessage);

        if (!File.Exists(strLogFile))
        {
            swLog = new StreamWriter(strLogFile);
        }
        else
        {
            swLog = File.AppendText(strLogFile);
        }

        swLog.WriteLine(strLogMessage);
        // swLog.WriteLine();

        swLog.Close();

    }

}

