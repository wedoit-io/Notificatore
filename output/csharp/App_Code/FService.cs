using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using JdSoft.Apple.Apns.Feedback;

public class FService {

    static string devtkList;
    static string devtkError;
	static string devtkBadDeviceTK;

    public string devList = "";
    public string errList = "";
	public string badDeviceTK = "";

    public int vConnectAttempts = 0;
    public int vReconnectDelay = 0;
    

    //public string ErrorList = "";
    //public ArrayList devtkList = new ArrayList();
    
    public  void GetFeedback(bool sandbox, string p12File, string p12FilePassword)
    {

        devList = "";
        errList = "";
		devtkList = "";
        devtkError = "";

		writeToLogFile(string.Format("Start Get feedback: {0}", p12File));
		
		//Actual Code starts below:
		//--------------------------------
		FeedbackService service = new FeedbackService(sandbox, p12File, p12FilePassword);
		
		//Wireup the events
		service.Error += new FeedbackService.OnError(service_Error);
		service.Feedback += new FeedbackService.OnFeedback(service_Feedback);
	    //service.OnBadDeviceToken += new FeedbackService.OnBadDeviceToken(service_BadDeviceToken);

        if (vConnectAttempts > 0) {
          service.ConnectAttempts = vConnectAttempts;
        }

        if (vReconnectDelay > 0)
        {
            service.ReconnectDelay = vReconnectDelay;
        }
          

		//Run it.  This actually connects and receives the feedback
		// the Feedback event will fire for each feedback object
		// received from the server
		service.Run();

    	// .OnBadDeviceToken(service_BadDeviceToken);

		//Clean up
		service.Dispose();
        
        devList = devtkList;
        errList = devtkError;
		badDeviceTK = devtkBadDeviceTK;
		

    }

	static void service_Feedback(object sender, Feedback feedback)
	{
		//Console.WriteLine(string.Format("Feedback - Timestamp: {0} - DeviceId: {1}", feedback.Timestamp, feedback.DeviceToken));
        devtkList = devtkList + "|" + feedback.DeviceToken;
		writeToLogFile(string.Format("   Feedback - Timestamp: {0} - DeviceId: {1}", feedback.Timestamp, feedback.DeviceToken));
       
	}

	static void service_Error(object sender, Exception ex)
	{
		//Console.WriteLine(string.Format("Error: {0}", ex.Message));
        devtkError = devtkError + "|" + ex.Message + "," + ex.InnerException.Message;
		writeToLogFile(string.Format("   Error: {0} - InnerMessage: {1}", ex.Message, ex.InnerException.Message));
       
	}

	/*
	static void service_BadDeviceToken(object sender, Feedback feedback)
	{

        badDeviceTK = badDeviceTK + "|" + feedback.DeviceToken;
		writeToLogFile(string.Format("Bad Device Token - Timestamp: {0} - DeviceId: {1}", feedback.Timestamp, feedback.DeviceToken));

	}
    */
	
    public static void writeToLogFile(string logMessage)
    {
        string strLogMessage = string.Empty;
        //string strLogFile = System.Configuration.ConfigurationManager.AppSettings["logFilePath"].ToString();
        //string strLogFile = @"c:\temp\Feedback.log";
		string strLogFile = System.Web.HttpRuntime.AppDomainAppPath + @"temp\FeedbackLOG.txt";
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
        //swLog.WriteLine();

        swLog.Close();
    }

}
