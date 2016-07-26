// **********************************************
// Push App Events
// Project : Mobile Manager
// **********************************************
using System;
using System.Text;
using System.Collections;
using com.progamma;
using com.progamma.ids;
using com.progamma.doc;

[Serializable]
public partial class PushAppEvents : IDObject
{
  private MyWebEntryPoint MainFrm;
  private IMDBObj IMDB;

  // Definition of Global Variables

	// **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
  }

  // IMDB DDL Procedures
  

	// **********************************************
  // Default constructor
  // **********************************************
  public PushAppEvents()
  {
  }
  
  // **********************************************
  // Initialize common framework object
  // **********************************************
  public PushAppEvents(Object w, Object imdb)
  {
    SetMainFrm(w, imdb);
  }

  public override void SetMainFrm(Object mainfrm, Object imdb)
  {
    MainFrm = (MyWebEntryPoint)mainfrm;
    IMDB = (IMDBObj)imdb;
    //
    //
    //
    base.SetMainFrm(mainfrm, imdb);
  }

  // **********************************************************************
  // ON Notification Succeeded
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Notification - Input
  // **********************************************************************
  public static int ONNotificationSucceeded (PushSharp.Apple.ApnsNotification Notification, MyWebEntryPoint MainFrm, IMDBObj IMDB)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // ON Notification Succeeded Body
      // Corpo Procedura
      // 
      MainFrm.WriteDebug(IDL.Add((new IDVariant("Inviata notifica a:")), (new IDVariant(Notification.DeviceToken))), (new IDVariant(2)), (new IDVariant("NotificationSucceded")));
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("PushAppEvents", "ONNotificationSucceeded", _e);
      return -1;
    }
  }

  // **********************************************************************
  // ON Notification Failed
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Notification - Input
  // **********************************************************************
  public static int ONNotificationFailed (PushSharp.Apple.ApnsNotification Notification, MyWebEntryPoint MainFrm, IMDBObj IMDB)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // ON Notification Failed Body
      // Corpo Procedura
      // 
      MainFrm.WriteDebug((new IDVariant("Errore in invio notifica")), (new IDVariant(1)), (new IDVariant("NotificationFailed")));
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("PushAppEvents", "ONNotificationFailed", _e);
      return -1;
    }
  }

}
