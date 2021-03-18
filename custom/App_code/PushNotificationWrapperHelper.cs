using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.IO;

using com.progamma;

using PushNotificationWrapper;

/// <summary>
/// Summary description for PushNotificationWrapperHelper
/// </summary>
public static class PushNotificationWrapperHelper
{
    // Events

    //this even raised when a notification is successfully sent
    public static void NotificationSucceeded(INotification notification)
    {
        
        MyWebEntryPoint mw = new MyWebEntryPoint(null);
		IosNotification iosNotif = (IosNotification)notification;
        PushNotificationWrapperEvents.ONNotificationSucceeded(iosNotif, mw, mw.getIMDB());
        mw.CloseAllDBConnections();
        
    }

    // //this is raised when a notification is failed due to some reason
    public static void NotificationFailed(INotification notification, String error)
    {
       
        MyWebEntryPoint mw = new MyWebEntryPoint(null);
		com.progamma.IDVariant ErrorMessage = new com.progamma.IDVariant();
        ErrorMessage.set(new com.progamma.IDVariant(error));
		
		IosNotification IosNotif = (IosNotification)notification;
		
        PushNotificationWrapperEvents.ONNotificationFailed(IosNotif, ErrorMessage, mw, mw.getIMDB());
		
        mw.CloseAllDBConnections();
    }

}
