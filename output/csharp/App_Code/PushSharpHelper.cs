using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.IO;

using PushSharp;
using PushSharp.Google;
using PushSharp.Apple;
using PushSharp.Core;

using com.progamma;

/// <summary>
/// Summary description for PushSharpHelper
/// </summary>
public static class PushSharpHelper
{
    // Events
   


    //this even raised when a notification is successfully sent
    public static void NotificationSucceeded(PushSharp.Apple.ApnsNotification Notification)
    {
        
        MyWebEntryPoint mw = new MyWebEntryPoint(null);
        //mw.HandleRequest(null, null);
        PushAppEvents.ONNotificationSucceeded(Notification, mw, mw.getIMDB());
        mw.CloseAllDBConnections();
        
    }

    //this is raised when a notification is failed due to some reason
    public static void NotificationFailed(PushSharp.Apple.ApnsNotification Notification, Exception exception)
    {
       
        MyWebEntryPoint mw = new MyWebEntryPoint(null);
        //mw.HandleRequest(null, null);
        PushAppEvents.ONNotificationFailed(Notification, mw, mw.getIMDB());
        mw.CloseAllDBConnections();
      
    }

}
