// **********************************************
// Invio Notifiche A Utenti IOS
// Project : Mobile Manager NET4
// **********************************************
using System;
using System.Text;
using System.Collections;
using com.progamma.ids;
using com.progamma;
using com.progamma.idre;
using com.progamma.doc;

[Serializable]
public partial class InvioNotificheAUtentiIOS : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_NUOVOPANNELL_APPLICAZIONE = 0;
  private const int PFL_NUOVOPANNELL_UTENTE = 1;
  private const int PFL_NUOVOPANNELL_SOUND = 2;
  private const int PFL_NUOVOPANNELL_BADGE = 3;
  private const int PFL_NUOVOPANNELL_MESSAGGIO = 4;
  private const int PFL_NUOVOPANNELL_BOTTONEINVIA = 5;
  private const int PFL_NUOVOPANNELL_AMBIENTE = 6;
  private const int PFL_NUOVOPANNELL_CUSTOMFIELD1 = 7;
  private const int PFL_NUOVOPANNELL_CUSTOMFIELD2 = 8;

  private const int PPQRY_NOTIFICHE4 = 0;

  private const int PPQRY_APPLICAZIONI = 1;
  private const int PPQRY_DEVICETOKEN = 2;


  internal IDPanel PAN_NUOVOPANNELL;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    Init_TBL_NOTIFICHE3(IMDB);
    //
    //
    Init_PQRY_NOTIFICHE4(IMDB);
    Init_PQRY_NOTIFICHE4_RS(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_TBL_NOTIFICHE3(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.TBL_NOTIFICHE3, 9);
    IMDB.set_TblCode(IMDBDef1.TBL_NOTIFICHE3, "TBL_NOTIFICHE3");
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_SQUADRA, "SQUADRA");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_SQUADRA,5,200,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_AMBIENNOTIFI, "AMBIENNOTIFI");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_AMBIENNOTIFI,5,1,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_MESSAGNOTIFI, "MESSAGNOTIFI");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_MESSAGNOTIFI,9,500,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_IDAPPLINOTIF, "IDAPPLINOTIF");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_IDAPPLINOTIF,1,52,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_SOUND, "SOUND");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_SOUND,5,200,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_BADGE, "BADGE");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_BADGE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_CUSTFIEL1NOT, "CUSTFIEL1NOT");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_CUSTFIEL1NOT,5,50,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_CUSTFIEL2NOT, "CUSTFIEL2NOT");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE3,IMDBDef1.FLD_NOTIFICHE3_CUSTFIEL2NOT,5,50,0);
    IMDB.TblAddNew(IMDBDef1.TBL_NOTIFICHE3, 0);
  }

  private static void Init_PQRY_NOTIFICHE4(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_NOTIFICHE4, 8);
    IMDB.set_TblCode(IMDBDef1.PQRY_NOTIFICHE4, "PQRY_NOTIFICHE4");
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_AMBIENNOTIFI, "AMBIENNOTIFI");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_AMBIENNOTIFI,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_MESSAGNOTIFI, "MESSAGNOTIFI");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_MESSAGNOTIFI,9,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_IDAPPLINOTIF, "IDAPPLINOTIF");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_IDAPPLINOTIF,1,52,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_SOUND, "SOUND");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_SOUND,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_BADGE, "BADGE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_BADGE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_CUSTFIEL1NOT, "CUSTFIEL1NOT");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_CUSTFIEL1NOT,5,50,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_CUSTFIEL2NOT, "CUSTFIEL2NOT");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4,IMDBDef1.PQSL_NOTIFICHE4_CUSTFIEL2NOT,5,50,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_NOTIFICHE4, 0);
  }

  private static void Init_PQRY_NOTIFICHE4_RS(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_NOTIFICHE4_RS, 8);
    IMDB.set_TblCode(IMDBDef1.PQRY_NOTIFICHE4_RS, "PQRY_NOTIFICHE4_RS");
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_AMBIENNOTIFI, "AMBIENNOTIFI");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_AMBIENNOTIFI,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_MESSAGNOTIFI, "MESSAGNOTIFI");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_MESSAGNOTIFI,9,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_IDAPPLINOTIF, "IDAPPLINOTIF");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_IDAPPLINOTIF,1,52,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_SOUND, "SOUND");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_SOUND,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_BADGE, "BADGE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_BADGE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_CUSTFIEL1NOT, "CUSTFIEL1NOT");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_CUSTFIEL1NOT,5,50,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_CUSTFIEL2NOT, "CUSTFIEL2NOT");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE4_RS,IMDBDef1.PQSL_NOTIFICHE4_CUSTFIEL2NOT,5,50,0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public InvioNotificheAUtentiIOS(MyWebEntryPoint w, IMDBObj imdb)
    : base()
  {
    //
    SetMainFrm(w, imdb);
  }

	// **********************************************
	// Funzione chiamata su form multipla
	// durante l'inizializzazione
	// **********************************************
	public override void SetMainFrm(WebEntryPoint w, IMDBObj i)
	{
		// Sono una form multipla, duplico IMDB
		IMDB = new IMDBObj();
		IMDB.set_DBSize(w.IwImdb.IMDB.DBSize());
		ImdbInit(IMDB);
		IMDB.SetMaster(w.IwImdb.IMDB);
		base.SetMainFrm(w,i);
	}
  public override void SetSubMainFrm(WebEntryPoint w, IMDBObj i)
	{
		// Sono una form multipla, duplico IMDB
    IMDB = new IMDBObj();
    IMDB.set_DBSize(w.IwImdb.IMDB.DBSize());
    ImdbInit(IMDB);
    IMDB.SetMaster(w.IwImdb.IMDB);
    base.SetSubMainFrm(w, i);
  }

  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public InvioNotificheAUtentiIOS()
    : base()
  {
  }

  // **********************************************
  // Form Loaded
  // **********************************************
  public override void Init(WebEntryPoint w, bool flMulti, bool flSubForm)
  {
    StringBuilder SQL;
    int i;
    ATreeItem Item;

    MainFrm = (MyWebEntryPoint)w;
    base.Init(w, flMulti, flSubForm);
    //
    FormIdx = MyGlb.FRM_INVNOTAUTEIO;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "EFC0C266-DEE6-41B3-90AC-A1A734AE1842";
    ResModeW = 1;
    ResModeH = 1;
    iVisualFlags = -2139;
    DesignWidth = 520;
    DesignHeight = 468;
    set_Caption(new IDVariant("Invio Notifiche A Utenti IOS"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 520;
    Frames[1].Height = 408;
    Frames[1].FrHidden = true;
    Frames[1].Caption = "Nuovo Pannello";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 408;
    PAN_NUOVOPANNELL = new IDPanel(w, this, 1, "PAN_NUOVOPANNELL");
    Frames[1].Content = PAN_NUOVOPANNELL;
    PAN_NUOVOPANNELL.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_NUOVOPANNELL.VS = MainFrm.VisualStyleList;
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 520-MyGlb.PAN_OFFS_X, 408-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "68C3118D-B832-4E4B-AF7C-3F31E9C9DAAD");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 2368, 336, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_STARTFORM | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.PAN_AUTOSAVE | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_NUOVOPANNELL.InitStatus = 3;
    PAN_NUOVOPANNELL_Init();
    PAN_NUOVOPANNELL_InitFields();
    PAN_NUOVOPANNELL_InitQueries();
    HelpFile = "";
    //
    // Modifico alcune impostazioni per smartphone, potranno
    // essere ulteriormente modificate nell'evento di Load
    if (MainFrm.IsSmartPhone())
    {
    	DockType = 0;
    	Docked = false;
    	ResModeW = Glb.FRESMODE_STRETCH;
    	ResModeH = Glb.FRESMODE_STRETCH;
    }
    //
    for (i = 1; i < Frames.Length; i++)
    {
      if (Frames[i].Content is IDPanel)
      {
        Frames[i].Content.MainFrm = w;
        Frames[i].Content.Parent = this;
        ((IDPanel)Frames[i].Content).CalcLayout();
        ((IDPanel)Frames[i].Content).SetDOIMDB(IMDB);
      }
      if (Frames[i].Content is OBook)
        Frames[i].Content.MainFrm = w;
      //
      if (Frames[i].Content != null)
        Frames[i].Content.Collapsable = w.ParamsObj().UseCollapsableFrames;
      //
      if (Frames[i].Content != null && Frames[i].HasCaptionToolbar==-1)
        Frames[i].HasCaptionToolbar = MainFrm.CmdObj.HasCaptionToolbar(FormIdx, Frames[i].Index, Frames[i].Content.Code);
    }
    //
    // Init sub-frames
    for (i = 1; i < Frames.Length; i++)
    {
      if (Frames[i].Content is IDPanel)
        for (int j = 0; j < ((IDPanel)Frames[i].Content).UFields(); j++)
          ((IDPanel)Frames[i].Content).bFields(j).UpdateSubFrame();
    }
    //
    for (i = 1; i < Frames.Length; i++)
    {
      if (Frames[i].Content is OTabView)
        ((OTabView)Frames[i].Content).SelectTab(1, true);
    }
    OrgWidth = Frames[1].Width + GetPadding(false);
    OrgHeight = Frames[1].Height + GetPadding(true);
    //
    // Resetto il fuoco perchè le tabbed view lo possono modificare
    FocusPriority = 0;
    ActiveElement = "";
    //
    MainFrm.RolObj.ApplyRoles(FormIdx, this);
    //
    MainFrm.TimerObj.ActivateTimers(FormIdx, true);
    IntFormLoad();
    //
    // Solo le form non modali devono essere ridimensionate
    if (!flSubForm && (!MainFrm.ParamsObj().TruePopup || OpenAs == Glb.OPEN_MDI))
      Resize(w.ScreenW(), w.ScreenH());
    //
    JustLoaded = true;
    UpdateControls();
  }


  // **********************************************
  // Command Activation Handler
  // **********************************************
  public override void CmdClickCB(int CmdIdx)
  {
    fine: ;
  }


  // **********************************************
  // Timer Activation Handler
  // **********************************************
  public override void TimerTickCB(int TimerIdx)
  {
      fine: ;
  }


  // **********************************************
  // Update Controls against IMDB variations
  // **********************************************
  public override void UpdateControls()
  {
    try
    {
      if (IMDB.TblModified(IMDBDef1.TBL_NOTIFICHE3, MyGlb.GlbRefModIdx) || JustLoaded)
      {
        INVNOTAUTEIO_NOTIFICHE4();
      }
      PAN_NUOVOPANNELL.UpdatePanel(MainFrm);
      //
    }
    catch (Exception e)
    {
      Console.Error.WriteLine(e.Message + "\n" + e.StackTrace); Console.Error.Flush();
    }
    JustLoaded = false;
    DOSetCaption();
		base.UpdateControls();
  }


  // **********************************************
  // One of my modal form has been closed
  // **********************************************
  public override void EndModal(int CallerIdx, bool flRis)
  {
    IDVariant Cancel = new IDVariant();
    IntEndModal(new IDVariant(CallerIdx), new IDVariant(flRis), Cancel);
    if (Cancel.isTrue())
    {
      if (MainFrm != null)
        MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, RTCGuid, 26, "Form.EndModal", "Form " + Caption() + " canceled further processing after EndModal event");
      return;
    }
    //
  }


  // **********************************************
  // Enumerate books
  // **********************************************
  public override CIDREObj SearchBook(String Code)
  {
    //
    return null;
  }

  // **************************************************
  // Torna TRUE se l'oggetto passato è una mia istanza
  // **************************************************
  public static bool IsMyInstance(Object obj)
  {
    return (obj is InvioNotificheAUtentiIOS);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(InvioNotificheAUtentiIOS).FullName : typeof(InvioNotificheAUtentiIOS).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Lancia Invio Notifica
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int LanciaInvioNotifica ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("F49DAEDF-3097-4C5C-975C-E858A23D921A", "Lancia Invio Notifica", "", 3, "Invio Notifiche A Utenti IOS")) return 0;
      // 
      // Lancia Invio Notifica Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddSubProc ("788181B9-4D31-4ED4-8F61-FEFE5F433946", "Nuovo Pannello.Update Data", "");
      PAN_NUOVOPANNELL.PanelCommand(Glb.PCM_UPDATE);
      // 
      // Ho inserito un testo?
      // 
      IDVariant v_VAUTHKEYAPPL = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VCHIAVEAPPLI = new IDVariant(0,IDVariant.STRING);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  B.AUTH_KEY as AUTHKEYAPPS, ");
      SQL.Append("  B.APP_KEY as CHIAVEAPPS ");
      SQL.Append("from ");
      SQL.Append("  APPS_PUSH_SETTING A, ");
      SQL.Append("  APPS B ");
      SQL.Append("where B.ID = A.ID_APP ");
      SQL.Append("and   (A.ID = " + IDL.CSql(IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_IDAPPLINOTIF, 0), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      MainFrm.DTTObj.AddQuery ("5C1FB5E1-DF78-4DB1-B444-64588A6F2381", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("5C1FB5E1-DF78-4DB1-B444-64588A6F2381");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        v_VAUTHKEYAPPL = QV.Get("AUTHKEYAPPS", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("5C1FB5E1-DF78-4DB1-B444-64588A6F2381", "7C8D1B7C-9201-4939-AB0E-04DCE930226F", 1376256, "V Auth Key Applicazione", v_VAUTHKEYAPPL);
        v_VCHIAVEAPPLI = QV.Get("CHIAVEAPPS", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("5C1FB5E1-DF78-4DB1-B444-64588A6F2381", "653A7985-1EBC-4FD5-AF34-B1DEEBE45538", 1376256, "v Chiave Applicazione", v_VCHIAVEAPPLI);
      }
      QV.Close();
      IDVariant v_SUTENTE = new IDVariant(0,IDVariant.STRING);
      MainFrm.DTTObj.AddIf ("3FCDAB71-AF3E-48F5-BAF7-B8013A2033B4", "IF Utente Record [Invio Notifiche A Utenti IOS - Nuovo Pannello] != \"[Tutti gli utenti]\"", "");
      MainFrm.DTTObj.AddToken ("3FCDAB71-AF3E-48F5-BAF7-B8013A2033B4", "38E75D8C-206E-4FE3-ABB9-D251F87D8B9C", 917504, "Utente", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_DES_UTENTE, 0));
      if (IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_DES_UTENTE, 0).compareTo((new IDVariant("[Tutti gli utenti]")), true)!=0)
      {
        MainFrm.DTTObj.EnterIf ("3FCDAB71-AF3E-48F5-BAF7-B8013A2033B4", "IF Utente Record [Invio Notifiche A Utenti IOS - Nuovo Pannello] != \"[Tutti gli utenti]\"", "");
        MainFrm.DTTObj.AddAssign ("F560A93A-D98F-4D44-9AE7-F03C3D004B51", "s Utente := Utente Record [Invio Notifiche A Utenti IOS - Nuovo Pannello]", "", v_SUTENTE);
        MainFrm.DTTObj.AddToken ("F560A93A-D98F-4D44-9AE7-F03C3D004B51", "38E75D8C-206E-4FE3-ABB9-D251F87D8B9C", 917504, "Utente", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_DES_UTENTE, 0));
        v_SUTENTE = IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_DES_UTENTE, 0);
        MainFrm.DTTObj.AddAssignNewValue ("F560A93A-D98F-4D44-9AE7-F03C3D004B51", "19C3047A-C476-4157-AAAF-CE9243865087", v_SUTENTE);
      }
      MainFrm.DTTObj.EndIfBlk ("3FCDAB71-AF3E-48F5-BAF7-B8013A2033B4");
      // 
      // Invio della notifica push
      // 
      NotificatoreWS.Notificatore N = null;
      MainFrm.DTTObj.AddAssign ("F916C25C-6FEA-4931-BEFB-5B293D5CE9CE", "n := new ()", "Invio della notifica push", N);
      N = (NotificatoreWS.Notificatore)new NotificatoreWS.Notificatore(); N.Url = (String)MainFrm.WebServicesUrl["NotificatoreWS"]; N.NameSpace = "http://www.progamma.com";
      MainFrm.DTTObj.AddAssignNewValue ("F916C25C-6FEA-4931-BEFB-5B293D5CE9CE", "CC3CAD79-DC30-4774-8CD8-DD517DF5B64E", N);
      MainFrm.DTTObj.AddAssign ("8AC9E30E-C5CF-4128-8BFC-EFD623CEA0F0", "n.Url := Glb WS Url Notificatore", "", N.Url);
      MainFrm.DTTObj.AddToken ("8AC9E30E-C5CF-4128-8BFC-EFD623CEA0F0", "10ADFF3C-9D96-4180-92DE-D5CA73B4ADA5", 1376256, "Glb WS Url", new IDVariant(MainFrm.GLBWSURL));
      N.Url = new IDVariant(MainFrm.GLBWSURL).stringValue();
      MainFrm.DTTObj.AddAssignNewValue ("8AC9E30E-C5CF-4128-8BFC-EFD623CEA0F0", "CC3CAD79-DC30-4774-8CD8-DD517DF5B64E", N.Url);
      IDVariant S = null;
      MainFrm.DTTObj.AddAssign ("F0A42FB9-B905-4E0D-881E-F45C7B604CBA", "s := n.Send Notification (V Auth Key Applicazione, v Chiave Applicazione, Messaggio Notifica Record [Invio Notifiche A Utenti IOS - Nuovo Pannello], s Utente, Sound Record [Invio Notifiche A Utenti IOS - Nuovo Pannello], Badge Record [Invio", "", S);
      MainFrm.DTTObj.AddToken ("F0A42FB9-B905-4E0D-881E-F45C7B604CBA", "7C8D1B7C-9201-4939-AB0E-04DCE930226F", 1376256, "V Auth Key Applicazione", v_VAUTHKEYAPPL);
      MainFrm.DTTObj.AddToken ("F0A42FB9-B905-4E0D-881E-F45C7B604CBA", "653A7985-1EBC-4FD5-AF34-B1DEEBE45538", 1376256, "v Chiave Applicazione", v_VCHIAVEAPPLI);
      MainFrm.DTTObj.AddToken ("F0A42FB9-B905-4E0D-881E-F45C7B604CBA", "98C1F891-8CF1-41EF-9999-5A4F6227CE92", 917504, "Messaggio Notifica", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_MESSAGNOTIFI, 0));
      MainFrm.DTTObj.AddToken ("F0A42FB9-B905-4E0D-881E-F45C7B604CBA", "19C3047A-C476-4157-AAAF-CE9243865087", 1376256, "s Utente", v_SUTENTE);
      MainFrm.DTTObj.AddToken ("F0A42FB9-B905-4E0D-881E-F45C7B604CBA", "988A4879-5B25-4281-9419-C21FE8D8F4B5", 917504, "Sound", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_SOUND, 0));
      MainFrm.DTTObj.AddToken ("F0A42FB9-B905-4E0D-881E-F45C7B604CBA", "4FEF4633-0FAB-47B2-842A-25FA9038B7DC", 917504, "Badge", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_BADGE, 0));
      S = N.SendNotification_ws(v_VAUTHKEYAPPL, v_VCHIAVEAPPLI, IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_MESSAGNOTIFI, 0), v_SUTENTE, IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_SOUND, 0), IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_BADGE, 0));
      MainFrm.DTTObj.AddAssignNewValue ("F0A42FB9-B905-4E0D-881E-F45C7B604CBA", "BC347EB8-AE96-4A52-BFB9-397EC5326DDD", S);
      MainFrm.DTTObj.AddIf ("5954ECD3-A0AF-40E6-B334-91DEE8D03C0F", "IF s != \"\"", "");
      MainFrm.DTTObj.AddToken ("5954ECD3-A0AF-40E6-B334-91DEE8D03C0F", "BC347EB8-AE96-4A52-BFB9-397EC5326DDD", 1376256, "s", S);
      if (S.compareTo((new IDVariant("")), true)!=0)
      {
        MainFrm.DTTObj.EnterIf ("5954ECD3-A0AF-40E6-B334-91DEE8D03C0F", "IF s != \"\"", "");
        MainFrm.DTTObj.AddSubProc ("FF359E44-34A7-4ACB-987B-DFA1842AC43A", "Notificatore.Message Box", "");
        MainFrm.DTTObj.AddParameter ("FF359E44-34A7-4ACB-987B-DFA1842AC43A", "4C154B9E-8ADB-40E8-A659-2BC0AB2A5116", "Messaggio", S);
        MainFrm.set_AlertMessage(S); 
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("FA31E2DF-9132-4B61-91DC-0BA51D86C5ED", "ELSE", "", "5954ECD3-A0AF-40E6-B334-91DEE8D03C0F");
        MainFrm.DTTObj.AddSubProc ("70CA015F-5269-4BB4-B498-2A3EEE49850A", "Notificatore.Message Box", "");
        MainFrm.DTTObj.AddParameter ("70CA015F-5269-4BB4-B498-2A3EEE49850A", "D646BECB-28FC-470F-BE56-A0EC924E6092", "Messaggio", (new IDVariant("Invio messaggio in coda")));
        MainFrm.set_AlertMessage((new IDVariant("Invio messaggio in coda"))); 
      }
      MainFrm.DTTObj.EndIfBlk ("5954ECD3-A0AF-40E6-B334-91DEE8D03C0F");
      MainFrm.DTTObj.ExitProc("F49DAEDF-3097-4C5C-975C-E858A23D921A", "Lancia Invio Notifica", "", 3, "Invio Notifiche A Utenti IOS");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("F49DAEDF-3097-4C5C-975C-E858A23D921A", "Lancia Invio Notifica", "", _e);
      MainFrm.ErrObj.ProcError ("InvioNotificheAUtentiIOS", "LanciaInvioNotifica", _e);
      MainFrm.DTTObj.ExitProc("F49DAEDF-3097-4C5C-975C-E858A23D921A", "Lancia Invio Notifica", "", 3, "Invio Notifiche A Utenti IOS");
      return -1;
    }
  }

  // **********************************************************************
  // Start Form
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // ID Apps Push Settings - Input
  // Utente:  - Input
  // **********************************************************************
  public int StartForm (IDVariant IDAppsPushSettings, IDVariant Utente)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("5992DB65-3CBC-47BB-9B81-357AE06AC7BA", "Start Form", "", 3, "Invio Notifiche A Utenti IOS")) return 0;
      MainFrm.DTTObj.AddParameter ("5992DB65-3CBC-47BB-9B81-357AE06AC7BA", "7715621F-73E3-4D2B-856B-CB11C392F98D", "ID Apps Push Settings", IDAppsPushSettings);
      MainFrm.DTTObj.AddParameter ("5992DB65-3CBC-47BB-9B81-357AE06AC7BA", "BBFE3947-DCEF-4B8F-A3B8-ECC7F53E2327", "Utente", Utente);
      // 
      // Start Form Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddIf ("B105EFA9-6AA9-43FC-AC87-4E45A2FD6D19", "IF Null Value (Utente, \"\") != \"\"", "");
      MainFrm.DTTObj.AddToken ("B105EFA9-6AA9-43FC-AC87-4E45A2FD6D19", "BBFE3947-DCEF-4B8F-A3B8-ECC7F53E2327", 1376256, "Utente", Utente);
      if (IDL.NullValue(Utente,(new IDVariant(""))).compareTo((new IDVariant("")), true)!=0)
      {
        MainFrm.DTTObj.EnterIf ("B105EFA9-6AA9-43FC-AC87-4E45A2FD6D19", "IF Null Value (Utente, \"\") != \"\"", "");
        MainFrm.DTTObj.AddAssign ("E5BEB079-CDC8-4F87-9630-B1EE23C6FC30", "Utente Device Token Notifica := Utente", "", IMDB.Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_DES_UTENTE, 0));
        MainFrm.DTTObj.AddToken ("E5BEB079-CDC8-4F87-9630-B1EE23C6FC30", "BBFE3947-DCEF-4B8F-A3B8-ECC7F53E2327", 1376256, "Utente", new IDVariant(Utente));
        IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_DES_UTENTE, 0, new IDVariant(Utente));
        MainFrm.DTTObj.AddAssignNewValue ("E5BEB079-CDC8-4F87-9630-B1EE23C6FC30", "6478C56A-0556-4E9B-91E3-89A80CFEC444", IMDB.Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_DES_UTENTE, 0));
      }
      MainFrm.DTTObj.EndIfBlk ("B105EFA9-6AA9-43FC-AC87-4E45A2FD6D19");
      IDVariant v_VAMBAPPPUSSE = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VIDAPPPUSSET = new IDVariant(0,IDVariant.INTEGER);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.FLG_AMBIENTE as AMBIENTE, ");
      SQL.Append("  A.ID as ID ");
      SQL.Append("from ");
      SQL.Append("  APPS_PUSH_SETTING A ");
      SQL.Append("where (A.ID = " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      MainFrm.DTTObj.AddQuery ("B76E3D06-084A-4F24-8DDB-678D51B98EED", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("B76E3D06-084A-4F24-8DDB-678D51B98EED");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        v_VAMBAPPPUSSE = QV.Get("AMBIENTE", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("B76E3D06-084A-4F24-8DDB-678D51B98EED", "B19F1BA7-1FD5-416D-B4E2-6DA3D272BF49", 1376256, "v Ambiente Apps Push Settings", v_VAMBAPPPUSSE);
        v_VIDAPPPUSSET = QV.Get("ID", IDVariant.INTEGER) ;
        MainFrm.DTTObj.AddToken ("B76E3D06-084A-4F24-8DDB-678D51B98EED", "477D0B02-6973-455D-8056-BC166529385A", 1376256, "v ID Apps Push Settings", v_VIDAPPPUSSET);
      }
      QV.Close();
      MainFrm.DTTObj.AddAssign ("6AFDEA37-C436-403C-8C6E-D3B0BFFD942F", "Applicazione Record [Invio Notifiche A Utenti IOS - Nuovo Pannello] := v ID Apps Push Settings", "", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_IDAPPLINOTIF, 0));
      MainFrm.DTTObj.AddToken ("6AFDEA37-C436-403C-8C6E-D3B0BFFD942F", "477D0B02-6973-455D-8056-BC166529385A", 1376256, "v ID Apps Push Settings", new IDVariant(v_VIDAPPPUSSET));
      IMDB.set_Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_IDAPPLINOTIF, 0, new IDVariant(v_VIDAPPPUSSET));
      MainFrm.DTTObj.AddAssignNewValue ("6AFDEA37-C436-403C-8C6E-D3B0BFFD942F", "3A264A7E-340D-4AED-B0A7-D0750AA0EFE8", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_IDAPPLINOTIF, 0));
      MainFrm.DTTObj.AddAssign ("35E6061A-2ED7-44D8-9CDD-8DF822DB4745", "Ambiente Notifica Record [Invio Notifiche A Utenti IOS - Nuovo Pannello] := v Ambiente Apps Push Settings", "", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_AMBIENNOTIFI, 0));
      MainFrm.DTTObj.AddToken ("35E6061A-2ED7-44D8-9CDD-8DF822DB4745", "B19F1BA7-1FD5-416D-B4E2-6DA3D272BF49", 1376256, "v Ambiente Apps Push Settings", new IDVariant(v_VAMBAPPPUSSE));
      IMDB.set_Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_AMBIENNOTIFI, 0, new IDVariant(v_VAMBAPPPUSSE));
      MainFrm.DTTObj.AddAssignNewValue ("35E6061A-2ED7-44D8-9CDD-8DF822DB4745", "00564FB9-0343-433B-8564-264602123D4B", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_AMBIENNOTIFI, 0));
      MainFrm.DTTObj.ExitProc("5992DB65-3CBC-47BB-9B81-357AE06AC7BA", "Start Form", "", 3, "Invio Notifiche A Utenti IOS");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("5992DB65-3CBC-47BB-9B81-357AE06AC7BA", "Start Form", "", _e);
      MainFrm.ErrObj.ProcError ("InvioNotificheAUtentiIOS", "StartForm", _e);
      MainFrm.DTTObj.ExitProc("5992DB65-3CBC-47BB-9B81-357AE06AC7BA", "Start Form", "", 3, "Invio Notifiche A Utenti IOS");
      return -1;
    }
  }

  // **********************************************************************
  // Unload
  // Evento notificato dal form prima della chiusura dello
  // stesso
  // Cancel - Input/Output
  // Confirm - Input
  // **********************************************************************
  public override void IntFormUnload (IDVariant Cancel, IDVariant Confirm)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("C4327AEF-28D4-46BE-A8D4-18597109551F", "Unload", "", 0, "Invio Notifiche A Utenti IOS")) return;
      MainFrm.DTTObj.AddParameter ("C4327AEF-28D4-46BE-A8D4-18597109551F", "F2AE655B-E92B-4499-B66D-27D95A52D9EF", "Cancel", Cancel);
      MainFrm.DTTObj.AddParameter ("C4327AEF-28D4-46BE-A8D4-18597109551F", "67D67A4F-CF6B-462B-9994-C8EC08F0CD88", "Confirm", Confirm);
      // 
      // Unload Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddQuery ("A978B5D8-CECA-495C-9D80-5E64AC738515", "Notifiche: Delete", "", 256, "");
      UNLOAD_NOTIFIDELETE();
      MainFrm.DTTObj.EndQuery ("A978B5D8-CECA-495C-9D80-5E64AC738515");
      MainFrm.DTTObj.AddAssign ("34631A4D-E0EF-423D-A9EE-65FFB73B7356", "Sound Nuovo Pannello [Invio Notifiche A Utenti IOS - Nuovo Pannello].Text := C\"default\"", "", PAN_NUOVOPANNELL.FieldText(PFL_NUOVOPANNELL_SOUND));
      PAN_NUOVOPANNELL.set_FieldText(PFL_NUOVOPANNELL_SOUND, (new IDVariant("default")).stringValue());
      MainFrm.DTTObj.AddAssignNewValue ("34631A4D-E0EF-423D-A9EE-65FFB73B7356", "7F848997-9DC9-4CA8-A569-B86CC7C811B1", PAN_NUOVOPANNELL.FieldText(PFL_NUOVOPANNELL_SOUND));
      MainFrm.DTTObj.AddAssign ("13098BA5-E342-45A2-883B-D457E9A84ED1", "Badge Nuovo Pannello [Invio Notifiche A Utenti IOS - Nuovo Pannello].Text := C\"0\"", "", PAN_NUOVOPANNELL.FieldText(PFL_NUOVOPANNELL_BADGE));
      PAN_NUOVOPANNELL.set_FieldText(PFL_NUOVOPANNELL_BADGE, (new IDVariant("0")).stringValue());
      MainFrm.DTTObj.AddAssignNewValue ("13098BA5-E342-45A2-883B-D457E9A84ED1", "0B0E80BD-D592-4832-AADB-C103EB640EF9", PAN_NUOVOPANNELL.FieldText(PFL_NUOVOPANNELL_BADGE));
      MainFrm.DTTObj.ExitProc("C4327AEF-28D4-46BE-A8D4-18597109551F", "Unload", "", 0, "Invio Notifiche A Utenti IOS");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("C4327AEF-28D4-46BE-A8D4-18597109551F", "Unload", "", _e);
      MainFrm.ErrObj.ProcError ("InvioNotificheAUtentiIOS", "Unload", _e);
      MainFrm.DTTObj.ExitProc("C4327AEF-28D4-46BE-A8D4-18597109551F", "Unload", "", 0, "Invio Notifiche A Utenti IOS");
    }
  }

  // **********************************************************************
  // Notifiche: Delete
  // Perchè stai eliminando questi dati?
  // **********************************************************************
  private void UNLOAD_NOTIFIDELETE()
  {
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_SQUADRA, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_AMBIENNOTIFI, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_MESSAGNOTIFI, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_DES_UTENTE, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_IDAPPLINOTIF, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_SOUND, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_BADGE, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_CUSTFIEL1NOT, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_CUSTFIEL2NOT, 0, new IDVariant());
  }

  // **********************************************************************
  // Load
  // Evento notificato alla videata al momento del caricamento
  // in memoria.
  // **********************************************************************
  private void IntFormLoad ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("E4E6F344-7538-4891-8782-3818069096B2", "Load", "", 0, "Invio Notifiche A Utenti IOS")) return;
      // 
      // Load Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddAssign ("4AB624C6-FF7A-48A2-BB5B-413767AB4E78", "Badge Spedizione Notifica := C0", "", IMDB.Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_BADGE, 0));
      IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_BADGE, 0, (new IDVariant(0)));
      MainFrm.DTTObj.AddAssignNewValue ("4AB624C6-FF7A-48A2-BB5B-413767AB4E78", "73CB552B-4F7E-46F8-9684-8F7E74FC0F43", IMDB.Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_BADGE, 0));
      MainFrm.DTTObj.AddAssign ("D097D45A-23EC-4684-BFAF-375306565256", "Sound Spedizione Notifica := C\"default\"", "", IMDB.Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_SOUND, 0));
      IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_SOUND, 0, (new IDVariant("default")));
      MainFrm.DTTObj.AddAssignNewValue ("D097D45A-23EC-4684-BFAF-375306565256", "4301E5B5-3D6C-47B5-A3C3-2677820BC601", IMDB.Value(IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_SOUND, 0));
      MainFrm.DTTObj.ExitProc("E4E6F344-7538-4891-8782-3818069096B2", "Load", "", 0, "Invio Notifiche A Utenti IOS");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("E4E6F344-7538-4891-8782-3818069096B2", "Load", "", _e);
      MainFrm.ErrObj.ProcError ("InvioNotificheAUtentiIOS", "Load", _e);
      MainFrm.DTTObj.ExitProc("E4E6F344-7538-4891-8782-3818069096B2", "Load", "", 0, "Invio Notifiche A Utenti IOS");
    }
  }

  // **********************************************************************
  // Notifiche
  // Recupera i record da mostrare nel pannello
  // **********************************************************************
  private void INVNOTAUTEIO_NOTIFICHE4()
  {
    IDVariant[] AggrBuff;
    int[] AggrRowCount;
    int AggrCount=0;
    bool AggrNewGroup = false;

    IMDB.TblTruncate(IMDBDef1.PQRY_NOTIFICHE4_RS);
    IMDB.TblMoveFirst(IMDBDef1.TBL_NOTIFICHE3, 0);
    Loop1: while (!IMDB.Eof(IMDBDef1.TBL_NOTIFICHE3, 0))
    {
      IMDB.TblAddNew(IMDBDef1.PQRY_NOTIFICHE4_RS, 0);
      IMDB.TblLinkRow(IMDBDef1.PQRY_NOTIFICHE4_RS, 0, IMDBDef1.TBL_NOTIFICHE3, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE4_RS, 0, 0, IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_AMBIENNOTIFI, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE4_RS, 1, 0, IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_MESSAGNOTIFI, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE4_RS, 2, 0, IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_DES_UTENTE, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE4_RS, 3, 0, IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_IDAPPLINOTIF, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE4_RS, 4, 0, IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_SOUND, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE4_RS, 5, 0, IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_BADGE, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE4_RS, 6, 0, IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_CUSTFIEL1NOT, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE4_RS, 7, 0, IMDBDef1.TBL_NOTIFICHE3, IMDBDef1.FLD_NOTIFICHE3_CUSTFIEL2NOT, 0);
      IMDB.TblMoveNext(IMDBDef1.TBL_NOTIFICHE3, 0);
      if (IMDB.Eof(IMDBDef1.TBL_NOTIFICHE3, 0))
      {
        IMDB.TblMoveFirst(IMDBDef1.TBL_NOTIFICHE3, 0);
      }
      else
      {
        goto Loop1;
      }
      break;
    }
    IMDB.TblMoveFirst(IMDBDef1.PQRY_NOTIFICHE4_RS, 0);
  }



  // **********************************************
  // Event Stubs
  // **********************************************	
  // **********************************************************************
  // Activate
  // Evento notificato alla videata quando essa viene attivata
  // cioè quando viene portata in primo piano
  // **********************************************************************
  public override void Form_Activate()
  {
    // Stub
  }

  // **********************************************************************
  // Deactivate
  // Evento notificato alla videata quando essa viene messa
  // in secondo piano
  // **********************************************************************
  public override void Form_Deactivate(IDVariant Cancel)
  {
    // Stub
  }

  // **********************************************************************
  // End Modal
  // Evento notificato dall'oggetto form in applicazioni
  // Web quando viene chiusa una finestra modale
  // **********************************************************************
  private void IntEndModal(IDVariant LookupForm,IDVariant Result,IDVariant Cancel)
  {
    // Stub
  }

  // **********************************************************************
  // On Change Document
  // Evento notificato al form quando viene cambiato il
  // documento collegato
  // **********************************************************************
  public override void OnChangeDocument(com.progamma.doc.IDDocument OldDocument)
  {
    // Stub
  }



  // **********************************************
  // Frame Events
  // **********************************************
  private void PAN_NUOVOPANNELL_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
    if (ColIndex.intValue() == PFL_NUOVOPANNELL_BOTTONEINVIA)
    {
      this.IdxPanelActived = this.PAN_NUOVOPANNELL.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      LanciaInvioNotifica();
      Cancel.set(IDVariant.TRUE);
    }
  }

  private void PAN_NUOVOPANNELL_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_NUOVOPANNELL_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_AMBIENNOTIFI, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_NOTIFICHE4, IMDBDef1.PQSL_NOTIFICHE4_AMBIENNOTIFI, 0, (new IDVariant("S")));
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_NUOVOPANNELL_Init()
  {

    PAN_NUOVOPANNELL.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_NUOVOPANNELL.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_NUOVOPANNELL.SetSize(MyGlb.OBJ_FIELD, 9);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, "3672BD02-8B7C-40EB-8992-4D3A0AE44894");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, "Applicazione");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, "D5F56AD1-5BB8-47F1-834F-2A6DCD98C4E7");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, "Utente");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, "7F848997-9DC9-4CA8-A569-B86CC7C811B1");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, "Sound");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, "0B0E80BD-D592-4832-AADB-C103EB640EF9");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, "Badge");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, "6902F9CD-835B-4354-A0C1-D316E7BB6A79");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, "Messaggio");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, "Messaggio da inviare");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_VERTHDRFORM | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, "EDFD2F28-248A-40A6-B731-B67A0DA4A11D");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, "Invia");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.VIS_COMMANBUTTO1);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_NOACTD | MyGlb.FLD_CANACTIVATE, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, "146F72EB-2CFC-4E29-94AF-BFCD1CB711C1");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, "Ambiente");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, 0 | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, "CD1BE086-8005-4424-92E0-ECD83166C0DF");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, "Custom Field 1");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, "A413A7DD-7481-4D14-AE1E-18975D20D424");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, "Custom Field 2");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_NUOVOPANNELL_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_LIST, 0, 32, 268, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_LIST, 84);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_FORM, 12, 24, 476, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_FORM, 104);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_APPLICAZIONE, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_APPLICAZIONE, PPQRY_NOTIFICHE4, "A.IDAPPLINOTIF", "IDAPPLINOTIF", 1, 52, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_LIST, 0, 32, 508, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_LIST, 108);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_LIST, "Utente");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_FORM, 12, 56, 476, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_FORM, 104);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_FORM, "Utente");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_UTENTE, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_UTENTE, PPQRY_NOTIFICHE4, "A.DES_UTENTE", "DES_UTENTE", 5, 100, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_LIST, 0, 32, 504, 32, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_LIST, 92);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_LIST, "Sound");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_FORM, 12, 88, 356, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_FORM, 104);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_FORM, "Sound");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_SOUND, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_SOUND, PPQRY_NOTIFICHE4, "A.SOUND", "SOUND", 5, 200, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_LIST, 0, 32, 92, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_LIST, 92);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_LIST, "Badge");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_FORM, 364, 88, 124, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_FORM, 64);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_FORM, "Badge");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_BADGE, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_BADGE, PPQRY_NOTIFICHE4, "A.BADGE", "BADGE", 1, 9, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_LIST, 0, 32, 380, 32, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_LIST, 60);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_LIST, "Messaggio");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_FORM, 12, 192, 476, 136, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_FORM, 20);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_FORM, 6);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_FORM, "Messaggio");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_MESSAGGIO, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_MESSAGGIO, PPQRY_NOTIFICHE4, "A.MESSAGNOTIFI", "MESSAGNOTIFI", 9, 500, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_LIST, 312, 204, 80, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_LIST, 0);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_LIST, 2);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_FORM, 372, 344, 116, 36, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_FORM, 0);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_FORM, 2);
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_BOTTONEINVIA, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_BOTTONEINVIA, -1, "", "BOTTONEINVIA", 0, 0, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_LIST, 0, 32, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_LIST, 56);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_LIST, "Ambien.");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_FORM, 4, 272, 100, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_FORM, 56);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_FORM, "Ambien.");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_AMBIENTE, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_AMBIENTE, PPQRY_NOTIFICHE4, "A.AMBIENNOTIFI", "AMBIENNOTIFI", 5, 1, 0, -1709);
    PAN_NUOVOPANNELL.SetValueListItem(PFL_NUOVOPANNELL_AMBIENTE, (new IDVariant("S")), "Sviluppo", "", "", -1);
    PAN_NUOVOPANNELL.SetValueListItem(PFL_NUOVOPANNELL_AMBIENTE, (new IDVariant("P")), "Produzione", "", "", -1);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_LIST, 0, 36, 308, 32, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_LIST, 96);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_LIST, "Custom Field 1");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_FORM, 12, 120, 476, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_FORM, 104);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_FORM, "Custom Field 1");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_CUSTOMFIELD1, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_CUSTOMFIELD1, PPQRY_NOTIFICHE4, "A.CUSTFIEL1NOT", "CUSTFIEL1NOT", 5, 50, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_LIST, 0, 36, 308, 32, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_LIST, 96);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_LIST, "Custom Field 2");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_FORM, 12, 152, 476, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_FORM, 104);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_FORM, "Custom Field 2");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_CUSTOMFIELD2, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_CUSTOMFIELD2, PPQRY_NOTIFICHE4, "A.CUSTFIEL2NOT", "CUSTFIEL2NOT", 5, 50, 0, -1709);
  }

  private void PAN_NUOVOPANNELL_InitQueries()
  {
    StringBuilder SQL;

    PAN_NUOVOPANNELL.SetSize(MyGlb.OBJ_QUERY, 3);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPLICAZIO, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.ID = ~~IDAPPLINOTIF~~) ");
    SQL.Append("and   (A.TYPE_OS = '1') ");
    PAN_NUOVOPANNELL.SetQuery(PPQRY_APPLICAZIONI, 0, SQL, PFL_NUOVOPANNELL_APPLICAZIONE, "EF7307C1-04E5-4D9E-8C2E-D3E63DE5535B");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPLICAZIO, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.TYPE_OS = '1') ");
    PAN_NUOVOPANNELL.SetQuery(PPQRY_APPLICAZIONI, 1, SQL, PFL_NUOVOPANNELL_APPLICAZIONE, "");
    PAN_NUOVOPANNELL.SetQueryDB(PPQRY_APPLICAZIONI, MainFrm.NotificatoreDBObject.DB, 256);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  CONVERT (varchar(8000), '[Tutti gli utenti]') as TUTTIGLIUTEN ");
    SQL.Append("UNION ALL ");
    SQL.Append("select distinct ");
    SQL.Append("  ISNULL(A.DES_UTENTE, '') ");
    SQL.Append("from ");
    SQL.Append("  DEV_TOKENS A ");
    SQL.Append("where (A.ID_APPLICAZIONE = ~~IDAPPLINOTIF~~) ");
    SQL.Append("and   (A.TYPE_OS = '1') ");
    SQL.Append("and   (NOT ((A.DES_UTENTE IS NULL))) ");
    PAN_NUOVOPANNELL.SetQuery(PPQRY_DEVICETOKEN, 0, SQL, PFL_NUOVOPANNELL_UTENTE, "CC28FC41-88E5-4E1D-BFA1-224887286144");
    PAN_NUOVOPANNELL.SetQueryDB(PPQRY_DEVICETOKEN, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_NUOVOPANNELL.SetIMDB(IMDB, "PQRY_NOTIFICHE4", true);
    PAN_NUOVOPANNELL.set_SetString(MyGlb.MASTER_ROWNAME, "Record");
    PAN_NUOVOPANNELL.SetQueryIMDB(PPQRY_NOTIFICHE4, IMDBDef1.PQRY_NOTIFICHE4_RS, IMDBDef1.TBL_NOTIFICHE3);
    JustLoaded = true;
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_APPLICAZIONE, IMDBDef1.FLD_NOTIFICHE3_IDAPPLINOTIF);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_UTENTE, IMDBDef1.FLD_NOTIFICHE3_DES_UTENTE);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_SOUND, IMDBDef1.FLD_NOTIFICHE3_SOUND);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_BADGE, IMDBDef1.FLD_NOTIFICHE3_BADGE);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_MESSAGGIO, IMDBDef1.FLD_NOTIFICHE3_MESSAGNOTIFI);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_AMBIENTE, IMDBDef1.FLD_NOTIFICHE3_AMBIENNOTIFI);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_CUSTOMFIELD1, IMDBDef1.FLD_NOTIFICHE3_CUSTFIEL1NOT);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_CUSTOMFIELD2, IMDBDef1.FLD_NOTIFICHE3_CUSTFIEL2NOT);
    PAN_NUOVOPANNELL.SetMasterTable(0, "NOTIFICHE3");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_NUOVOPANNELL) PAN_NUOVOPANNELL_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_NUOVOPANNELL) PAN_NUOVOPANNELL_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_NUOVOPANNELL) PAN_NUOVOPANNELL_CellActivated(ColIndex, Cancel);
  }

  public override void OnChangePage(IDPanel SrcObj, IDVariant NewPage, IDVariant Cancel)
  {
  }

  public override void OnChangeLayout(IDPanel SrcObj, IDVariant NewLayout, IDVariant Cancel)
  {
  }

  public override void OnChangeRow(IDPanel SrcObj)
  {
  }

  public override void OnSelectingRow(IDPanel SrcObj)
  {
  }

  public override void OnSorting(IDPanel SrcObj, IDVariant FldIdx, IDVariant Cancel)
  {
  }

  public override void OnChangeSelection(IDPanel SrcObj, IDVariant NewVal, IDVariant Final, IDVariant Cancel)
  {
  }

  public override void OnChangeLocking(IDPanel SrcObj, IDVariant NewLocking, IDVariant Cancel)
  {
  }

  public override void OnChangeStatus(IDPanel SrcObj, IDVariant OldStatus)
  {
  }

  public override void OnPanelCommand(IDPanel SrcObj, IDVariant Command, IDVariant Cancel, IDVariant UserOp)
  {
  }

  public override void BeforeFind(IDPanel SrcObj, IDVariant Cancel)
  {
  }

  public override void BeforeInsert(IDPanel SrcObj, IDVariant Cancel)
  {
  }

  public override void BeforeUpdate(IDPanel SrcObj, IDVariant Cancel)
  {
  }

  public override void BeforeBlobUpdate(IDPanel SrcObj, IDVariant Cancel, IDVariant Column, IDVariant Size, IDVariant Extension, IDVariant FilePath)
  {
  }

  public override void BeforeDelete(IDPanel SrcObj, IDVariant Cancel)
  {
  }

  public override void AfterInsert(IDPanel SrcObj)
  {
  }

  public override void AfterUpdate(IDPanel SrcObj)
  {
  }

  public override void AfterBlobUpdate(IDPanel SrcObj, IDVariant Column, IDVariant Size, IDVariant Extension)
  {
  }

  public override void AfterDelete(IDPanel SrcObj)
  {
  }

  public override void AfterFind(IDPanel SrcObj, IDVariant CmdFind)
  {
  }

  public override void BeforeCommit(IDPanel SrcObj, IDVariant Cancel)
  {
  }

  public override void AfterCommit(IDPanel SrcObj, IDVariant RowUpdated, IDVariant RowError)
  {
  }

  public override void OnDBError(IDPanel SrcObj, IDVariant Cancel, IDVariant Skip, IDVariant ErrNum, IDVariant ErrMsg, IDVariant NativeErrNum, IDVariant PanOp, IDDocument Doc)
  {
  }

  public override void OnDownloadBlob(IDPanel SrcObj, IDVariant Cancel, IDVariant Column, IDVariant Size, IDVariant Extension, IDVariant Inline, IDVariant Filename, IDVariant MimeType)
  {
  }

  public override void OnPrint(IDPanel SrcObj, IDVariant Cancel, IDVariant Dest, IDVariant SetWC)
  {
  }

  public override void TabClick(OTabView SrcObj, IDVariant PreviousPage, IDVariant Cancel)
  {
  }

  public override void NodeClick(ATree SrcObj, ATreeNode Node)
  {
  }

  public override void OnTreeDropNode(ATree SrcObj, IDVariant SourceHash, IDVariant SourceTreeIndex, IDVariant DestinationHash, IDVariant ShiftKey, IDVariant AltKey, IDVariant ControlKey)
  {
  }

  public override void OnTreeExpandNode(ATree SrcObj, IDVariant HashKey, IDVariant Cancel)
  {
  }

  public override void OnTreeActivateNode(ATree SrcObj, IDVariant HashKey, IDVariant Cancel)
  {
  }

  public override void OnTreeChangeSelNode(ATree SrcObj, IDVariant HashKey, IDVariant Selected, IDVariant Cancel, IDVariant Final)
  {
  }

  public override void OnTreeDropDoc(ATree SrcObj, IDDocument SourceDoc, IDDocument DestDoc, IDVariant ShiftKey, IDVariant AltKey, IDVariant ControlKey, IDVariant Cancel)
  {
  }

  public override void OnTreeExpandDoc(ATree SrcObj, IDDocument Doc, IDVariant Cancel)
  {
  }

  public override void OnTreeActivateDoc(ATree SrcObj, IDDocument Doc, IDVariant Cancel)
  {
  }

  public override void OnTreeChangeSelDoc(ATree SrcObj, IDDocument Doc, IDVariant Selected, IDVariant Cancel, IDVariant Final)
  {
  }

  public override void OnFormattingSection(OBook SrcObj, int SectionID)
  {
  }

  public override void OnAfterFormattingSection(OBook SrcObj, int SectionID)
  {
  }

  public override void OnFormattingPage(OBook SrcObj, int PageID)
  {
  }

  public override void OnChangingSpan(OBook SrcObj, int SpanIdx, IDVariant OldVal, IDVariant NewVal, IDVariant Cancel)
  {
  }

  public override void OnBoxDrop(OBook SrcObj, IDVariant SrcBoxIdx, IDVariant DstBoxIdx)
  {
  }

  public override void OnBoxTransform(OBook SrcObj, IDVariant BoxIdx, IDVariant NewX, IDVariant NewY, IDVariant NewW, IDVariant NewH, IDVariant Cancel)
  {
  }

  public override void OnConnecting(OBook SrcObj, IDConnection DBConn)
  {
  }

  public override void Activated(OBook SrcObj, int ObjID, String BoxName)
  {
  }

  public override void OnIMDBUpdate(OBook SrcObj, int ReportIdx)
  {
  }

  public override void OnPreview(OBook SrcObj)
  {
  }

  public override void OnOpenPopup(ACommand SrcObj, IDVariant Direction, IDVariant Cancel)
  {
  }

  public override void OnCmdSetCommand(ACommand SrcObj, IDVariant CmdIdx, IDVariant ChildIdx, IDVariant Cancel)
  {
  }
  
  public override void OnCmdSetGeneralDrag(ACommand SrcObj, IDVariant DragInfo, IDVariant CmdIdx, IDVariant ChildIdx)
  {
  }
  
  public override void OnCmdSetGeneralDrop(ACommand SrcObj, IDVariant DragInfo, IDVariant CmdIdx, IDVariant ChildIdx)
  {
  }

  public override void OnChangeCollapse(WebFrame SrcObj, IDVariant Collapse, IDVariant Cancel)
  {
  }

  public override void OnGraphClick(WebFrame SrcObj, IDVariant NumSerie, IDVariant NumPoint)
  {
  }

  public override void OnGraphOptions(WebFrame SrcObj, IDVariant Options)
  {
  }
  
  public override void OnRenderToolbar(WebFrame SrcObj, IDVariant CmdIdx, IDVariant Visible)
  {
  }

  public override void OnBookCommand(OBook SrcObj, IDVariant Command, IDVariant Cancel, IDVariant UserOp)
  {
  }

  public override void OnCmdSetChangeExpand(ACommand SrcObj, IDVariant Expand, IDVariant Cancel)
  {
  }

  public override void OnTreeChangeExpandNode(ATree SrcObj, IDVariant HashKey, IDVariant Expanded, IDVariant Cancel)
  {
  }

  public override void OnTreeChangeExpandDoc(ATree SrcObj, IDDocument Doc, IDVariant Expanded, IDVariant Cancel)
  {
  }
  
	public override void OnMouseClick(IDPanel SrcObj, IDVariant btn, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant c, IDVariant r, IDVariant cancel)
  {
  }

	public override void OnMouseDoubleClick(IDPanel SrcObj, IDVariant btn, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant c, IDVariant r, IDVariant cancel)
  {
  }
  
	public override void OnMouseClick(OBook SrcObj, IDVariant btn, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant boxid, IDVariant cancel)
  {
  }

	public override void OnMouseDoubleClick(OBook SrcObj, IDVariant btn, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant boxid, IDVariant cancel)
  {
  }
  
	public override void OnMouseClick(ATree SrcObj, IDVariant btn, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant nodehash, IDDocument doc, IDVariant cancel)
	{
	}

	public override void OnMouseDoubleClick(ATree SrcObj, IDVariant btn, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant nodehash, IDDocument doc, IDVariant cancel)
	{
	}
	
	public override void OnMouseClick(AGraph SrcObj, IDVariant btn, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant numserie, IDVariant recordselected, IDVariant cancel)
	{
	}

	public override void OnMouseDoubleClick(AGraph SrcObj, IDVariant btn, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant numserie, IDVariant recordselected, IDVariant cancel)
	{
	}
	
	public override void OnMouseClick(OTabView SrcObj, IDVariant btn, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant tabid, IDVariant cancel)
	{
	}

	public override void OnMouseDoubleClick(OTabView SrcObj, IDVariant btn, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant tabid, IDVariant cancel)
	{
	}
	
	public override void OnReorderColum(IDPanel SrcObj, IDVariant sourcefield, IDVariant targetfield)
  {
  }
  
  public override void OnResizeColum(IDPanel SrcObj, IDVariant sourcefield, IDVariant oldwidth)
  {
  }
  
	public override void OnGenericDrag(IDPanel SrcObj, IDVariant draginfo,  IDVariant button, IDVariant colidx)
	{
	}

	public override void OnGenericDrop(IDPanel SrcObj, IDVariant draginfo, IDVariant cancel, IDVariant button, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant colidx, IDVariant rownum, IDDocument doc)
	{
	}
	
	public override void OnGenericDrag(ATree SrcObj, IDVariant draginfo,  IDVariant button, IDVariant hashkey)
	{
	}

	public override void OnGenericDrop(ATree SrcObj, IDVariant draginfo, IDVariant cancel, IDVariant button, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant hashkey, IDDocument doc)
	{
	}	
	
	public override void OnGenericDrag(OBook SrcObj, IDVariant draginfo,  IDVariant button, IDVariant boxid)
	{
	}

	public override void OnGenericDrop(OBook SrcObj, IDVariant draginfo, IDVariant cancel, IDVariant button, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant boxid)
	{
	}

  public override void OnGenericDrag(OTabView SrcObj, IDVariant draginfo, IDVariant button, IDVariant pageindex)
  {
  }

  public override void OnGenericDrop(OTabView SrcObj, IDVariant draginfo, IDVariant cancel, IDVariant button, IDVariant x, IDVariant y, IDVariant xb, IDVariant yb, IDVariant pageindex)
  {
  }

  public override void OnExpandingGroup(IDPanel SrcObj, IDVariant expanded, IDVariant userOperation)
  {
  }

  public override void OnChangeGroupCollapse(IDPanel SrcObj, IDVariant GrpIndex)
  {
  }

  public override void OnShowMultipleSelection(IDPanel SrcObj, IDVariant NewValue, IDVariant Cancel, IDVariant UserOperation)
  {
  }
  
  public override void OnChangeTextSelection(IDPanel SrcObj, IDVariant Field, IDVariant OldSelectionStart, IDVariant OldSelectionEnd)
  {
  }
  
  public override void OnFocus(IDPanel SrcObj, IDVariant Field, IDVariant GotFocus)
  {
  }

  public override void OnFrameKeyPress(WebFrame SrcObj, IDVariant KeySet, IDVariant KeyCode, IDVariant Skip)
  {
  }

  public override void OnGetLKE(IDPanel SrcObj, IDCachedRowSet RS, IDVariant ntry, IDVariant nullv, IDVariant bskip, IDVariant bcancel, IDVariant fldindex)
  {
  }
  
}
