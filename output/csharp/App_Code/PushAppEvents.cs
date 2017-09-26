// **********************************************
// Push App Events
// Project : Mobile Manager NET4
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

      if (!MainFrm.DTTObj.EnterProc("F585A312-8602-4C73-AEFD-2FB3FF4E6403", "ON Notification Succeeded", "", 3, "Push App Events")) return 0;
      MainFrm.DTTObj.AddParameter ("F585A312-8602-4C73-AEFD-2FB3FF4E6403", "491AB646-932D-4AED-A7BF-BD0804FA5018", "Notification", Notification);
      // 
      // ON Notification Succeeded Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddSubProc ("C0C2CC95-75F5-4813-A0BC-301395608892", "Notificatore.Write Debug", "");
      MainFrm.WriteDebug(IDL.Add((new IDVariant("Inviata notifica a:")), (new IDVariant(Notification.DeviceToken))), (new IDVariant(2)), (new IDVariant("NotificationSucceded")));
      MainFrm.DTTObj.ExitProc("F585A312-8602-4C73-AEFD-2FB3FF4E6403", "ON Notification Succeeded", "", 3, "Push App Events");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("F585A312-8602-4C73-AEFD-2FB3FF4E6403", "ON Notification Succeeded", "", _e);
      MainFrm.ErrObj.ProcError ("PushAppEvents", "ONNotificationSucceeded", _e);
      MainFrm.DTTObj.ExitProc("F585A312-8602-4C73-AEFD-2FB3FF4E6403", "ON Notification Succeeded", "", 3, "Push App Events");
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

      if (!MainFrm.DTTObj.EnterProc("9FD0DFAE-BAE7-4FBB-9115-78A0199E0115", "ON Notification Failed", "", 3, "Push App Events")) return 0;
      MainFrm.DTTObj.AddParameter ("9FD0DFAE-BAE7-4FBB-9115-78A0199E0115", "B5FF8F4F-BDD1-4EC2-9044-8E3BBF52AC93", "Notification", Notification);
      // 
      // ON Notification Failed Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddSubProc ("2B99E1FE-16AD-429A-8ECA-F2EC0B3C4FCC", "Notificatore.Write Debug", "");
      MainFrm.WriteDebug((new IDVariant("Errore in invio notifica")), (new IDVariant(1)), (new IDVariant("NotificationFailed")));
      MainFrm.DTTObj.ExitProc("9FD0DFAE-BAE7-4FBB-9115-78A0199E0115", "ON Notification Failed", "", 3, "Push App Events");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("9FD0DFAE-BAE7-4FBB-9115-78A0199E0115", "ON Notification Failed", "", _e);
      MainFrm.ErrObj.ProcError ("PushAppEvents", "ONNotificationFailed", _e);
      MainFrm.DTTObj.ExitProc("9FD0DFAE-BAE7-4FBB-9115-78A0199E0115", "ON Notification Failed", "", 3, "Push App Events");
      return -1;
    }
  }

}
