using System;
using System.Web;
using System.Collections.Generic;
using System.Text;
using System.IO;

using PushSharp;
using PushSharp.Android;
using PushSharp.Apple;
using PushSharp.Core;

using com.progamma;

/// <summary>
/// Summary description for PushSharpHelper
/// </summary>
public static class PushSharpHelper
{
    // Events

    //Currently it will raise only for android devices
    public static void DeviceSubscriptionChanged(object sender, string oldSubscriptionId, string newSubscriptionId, INotification notification)
    {
        
        MyWebEntryPoint mw = new MyWebEntryPoint(null);
        //mw.HandleRequest(null, null);
        PushAppEvents.ONDeviceSubscriptionChanged(mw, mw.getIMDB());
        mw.CloseAllDBConnections();
        
    }

    //this even raised when a notification is successfully sent
    public static void NotificationSent(object sender, INotification notification)
    {
        
        MyWebEntryPoint mw = new MyWebEntryPoint(null);
        //mw.HandleRequest(null, null);
        PushAppEvents.ONNotificationSent(mw, mw.getIMDB());
        mw.CloseAllDBConnections();
        
    }

    //this is raised when a notification is failed due to some reason
    public static void NotificationFailed(object sender, INotification notification, Exception notificationFailureException)
    {
       
        MyWebEntryPoint mw = new MyWebEntryPoint(null);
        //mw.HandleRequest(null, null);
        PushAppEvents.ONNotificationFailed(mw, mw.getIMDB());
        mw.CloseAllDBConnections();
      
    }

    //this is fired when there is exception is raised by the channel
    public static void ChannelException  (object sender, IPushChannel channel, Exception exception)
    {
         
        MyWebEntryPoint mw = new MyWebEntryPoint(null);
        //mw.HandleRequest(null, null);
        PushAppEvents.ONChannelException(mw, mw.getIMDB());
        mw.CloseAllDBConnections();
         
    }

    //this is fired when there is exception is raised by the service
    public static void ServiceException(object sender, Exception exception)
    {
        
        MyWebEntryPoint mw = new MyWebEntryPoint(null);
        //mw.HandleRequest(null, null);
        PushAppEvents.ONServiceException(mw, mw.getIMDB());
        mw.CloseAllDBConnections();
        
    }

    //this is raised when the particular device subscription is expired
    public static void DeviceSubscriptionExpired(object sender, string expiredDeviceSubscriptionId, DateTime timestamp, INotification notification)
    {
         
        MyWebEntryPoint mw = new MyWebEntryPoint(null);
        //mw.HandleRequest(null, null);
        PushAppEvents.ONDeviceSubscriptionExpired((new IDVariant(expiredDeviceSubscriptionId)), mw, mw.getIMDB());
        mw.CloseAllDBConnections();
       
    }

    //this is raised when the channel is destroyed
    public static void ChannelDestroyed(object sender)
    {
         
        MyWebEntryPoint mw = new MyWebEntryPoint(null);
        //mw.HandleRequest(null, null);
        PushAppEvents.ONChannelDestroyed(mw, mw.getIMDB());
        mw.CloseAllDBConnections();
         
    }

    //this is raised when the channel is created
    public static void ChannelCreated(object sender, IPushChannel pushChannel)
    {
      
        MyWebEntryPoint mw = new MyWebEntryPoint(null);
        //mw.HandleRequest(null, null);
        PushAppEvents.ONChannelCreated(mw, mw.getIMDB());
        mw.CloseAllDBConnections();
        
    }

}
