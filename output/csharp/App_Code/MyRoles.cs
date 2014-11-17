// **********************************************
// Roles Handler
// Instant WEB Application: www.progamma.com
// Project : Mobile Manager
// **********************************************
using System;
using com.progamma.ids;
using com.progamma;

// **********************************************
// Roles Handler
// **********************************************
[Serializable]
public sealed class MyRoles : Roles
{
  // **********************************************
  // Costruttore
  // **********************************************
  public MyRoles(WebEntryPoint p)
    : base(p)
  {
    //
    ARole rf;
    //
    iRoles = new ARole[5];
    rf = new ARole();
    iRoles[1] = rf;
    rf.Code = (new IDVariant(1));
    rf.SetItemCount(0);
    rf = new ARole();
    iRoles[2] = rf;
    rf.Parent = iRoles[1];
    rf.Code = (new IDVariant(2));
    rf.SetItemCount(0);
    rf = new ARole();
    iRoles[3] = rf;
    rf.Parent = iRoles[2];
    rf.Code = (new IDVariant(3));
    rf.SetItemCount(0);
    rf = new ARole();
    iRoles[4] = rf;
    rf.Parent = iRoles[3];
    rf.Code = (new IDVariant(5));
    rf.SetItemCount(0);
    //
  }


  // **********************************************
  // Scatena la INITAPP
  // **********************************************
  public override void InitRoles()
  {
    if (AlreadyInit)
      return;
    //
    AlreadyInit = true;
    //
    // Prima lancio initialize
    if (MainFrm.Request != null)
      glbUser = new IDVariant(MainFrm.Request.ServerVariables["AUTH_USER"]);
    MainFrm.DTTObj.SetRequestName("Init Session", "Init Session", DTTRequest.PRI_ITEM);
    MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 113, "Roles.Init", "Fire InitApp Event");
    ((MyWebEntryPoint)MainFrm).InitApp();
    MainFrm.RTCObj.ConfigureMain();
    //
    // Vado avanti con la configurazione dei ruoli
    ARole[] OldRoles = iRoles;
    MainFrm.RTCObj.ConfigureRoles();
    //
    // Se il puntatore non è cambiato l'RTC non ha configurato i ruoli dinamici
    if (OldRoles == iRoles)
      MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 112, "Roles.Init", "Static roles used");
    else
      MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 112, "Roles.Init", "Dynamic roles used");
    //
    if (glbRole.Type != IDVariant.NULL)
    {
      MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 114, "Roles.Init", "Bypass login (DefaultRole set while initializing application)");
      //
      // No login will occur, need to activate app manually
      MainFrm.FireAfterLogin();
    }
  }
}
