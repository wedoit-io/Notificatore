// **********************************************
// Invio Notifiche A Dispoitivi Noti IOS
// Project : Mobile Manager
// **********************************************
using System;
using System.Text;
using System.Collections;
using com.progamma.ids;
using com.progamma;
using com.progamma.idre;
using com.progamma.doc;

[Serializable]
public partial class InvioNotificheADispoitiviNotiIOS : MyWebForm
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

  private const int PPQRY_NOTIFICHE2 = 0;

  private const int PPQRY_APPLICAZIONI = 1;
  private const int PPQRY_DEVICETOKEN = 2;


  internal IDPanel PAN_NUOVOPANNELL;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    Init_TBL_NOTIFICHE5(IMDB);
    //
    //
    Init_PQRY_NOTIFICHE2(IMDB);
    Init_PQRY_NOTIFICHE2_RS(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_TBL_NOTIFICHE5(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.TBL_NOTIFICHE5, 7);
    IMDB.set_TblCode(IMDBDef1.TBL_NOTIFICHE5, "TBL_NOTIFICHE5");
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_SQUADRA, "SQUADRA");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_SQUADRA,5,200,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_AMBIENNOTIFI, "AMBIENNOTIFI");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_AMBIENNOTIFI,5,1,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_MESSAGNOTIFI, "MESSAGNOTIFI");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_MESSAGNOTIFI,9,500,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_IDAPPLINOTIF, "IDAPPLINOTIF");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_IDAPPLINOTIF,1,52,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_SOUND, "SOUND");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_SOUND,5,200,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_BADGE, "BADGE");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_BADGE,1,9,0);
    IMDB.TblAddNew(IMDBDef1.TBL_NOTIFICHE5, 0);
  }

  private static void Init_PQRY_NOTIFICHE2(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_NOTIFICHE2, 6);
    IMDB.set_TblCode(IMDBDef1.PQRY_NOTIFICHE2, "PQRY_NOTIFICHE2");
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI, "AMBIENNOTIFI");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_MESSAGNOTIFI, "MESSAGNOTIFI");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_MESSAGNOTIFI,9,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF, "IDAPPLINOTIF");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF,1,52,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_SOUND, "SOUND");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_SOUND,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_BADGE, "BADGE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_BADGE,1,9,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_NOTIFICHE2, 0);
  }

  private static void Init_PQRY_NOTIFICHE2_RS(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_NOTIFICHE2_RS, 6);
    IMDB.set_TblCode(IMDBDef1.PQRY_NOTIFICHE2_RS, "PQRY_NOTIFICHE2_RS");
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI, "AMBIENNOTIFI");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_MESSAGNOTIFI, "MESSAGNOTIFI");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_MESSAGNOTIFI,9,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF, "IDAPPLINOTIF");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF,1,52,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_SOUND, "SOUND");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_SOUND,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_BADGE, "BADGE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_BADGE,1,9,0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public InvioNotificheADispoitiviNotiIOS(MyWebEntryPoint w, IMDBObj imdb)
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
  public InvioNotificheADispoitiviNotiIOS()
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
    FormIdx = MyGlb.FRM_INVNOADINOIO;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "467E0147-90A6-4D1B-BF1F-FC18331D5DF0";
    ResModeW = 1;
    ResModeH = 1;
    iVisualFlags = -2139;
    DesignWidth = 476;
    DesignHeight = 334;
    set_Caption(new IDVariant("Invio Notifiche A Dispoitivi Noti IOS"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 476;
    Frames[1].Height = 308;
    Frames[1].FrHidden = true;
    Frames[1].Caption = "Nuovo Pannello";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 308;
    PAN_NUOVOPANNELL = new IDPanel(w, this, 1, "PAN_NUOVOPANNELL");
    Frames[1].Content = PAN_NUOVOPANNELL;
    PAN_NUOVOPANNELL.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_NUOVOPANNELL.VS = MainFrm.VisualStyleList;
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 476-MyGlb.PAN_OFFS_X, 308-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "74216C25-D5C7-4C49-8FC7-3C0E29B72341");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 1752, 336, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
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
      if (IMDB.TblModified(IMDBDef1.TBL_NOTIFICHE5, MyGlb.GlbRefModIdx) || JustLoaded)
      {
        INVNOADINOIO_NOTIFICHE2();
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
    return (obj is InvioNotificheADispoitiviNotiIOS);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(InvioNotificheADispoitiviNotiIOS).FullName : typeof(InvioNotificheADispoitiviNotiIOS).Name);
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
      // 
      // Lancia Invio Notifica Body
      // Corpo Procedura
      // 
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, 0)))
      {
        MainFrm.set_AlertMessage((new IDVariant("Scegli un utente"))); 
        return 0;
      }
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
      SQL.Append("and   (A.ID = " + IDL.CSql(IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF, 0), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      if (!QV.EOF())
      {
        v_VAUTHKEYAPPL = QV.Get("AUTHKEYAPPS", IDVariant.STRING) ;
        v_VCHIAVEAPPLI = QV.Get("CHIAVEAPPS", IDVariant.STRING) ;
      }
      QV.Close();
      IDVariant v_SUTENTE = new IDVariant(0,IDVariant.STRING);
      if (IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, 0).compareTo((new IDVariant("[Tutti gli utenti]")), true)!=0)
      {
        v_SUTENTE = IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, 0);
      }
      // 
      // Invio della notifica push
      // 
      NotificatoreWS.Notificatore N = null;
      N = (NotificatoreWS.Notificatore)new NotificatoreWS.Notificatore(); N.Url = (String)MainFrm.WebServicesUrl["NotificatoreWS"]; N.NameSpace = "http://www.progamma.com";
      N.Url = new IDVariant(MainFrm.GLBWSURL).stringValue();
      IDVariant S = null;
      S = N.SendNotification_ws(v_VAUTHKEYAPPL, v_VCHIAVEAPPLI, IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_MESSAGNOTIFI, 0), IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, 0), IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_SOUND, 0), IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_BADGE, 0));
      if (S.compareTo((new IDVariant("")), true)!=0)
      {
        MainFrm.set_AlertMessage(S); 
      }
      else
      {
        MainFrm.set_AlertMessage((new IDVariant("Invio messaggio in coda"))); 
      }
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("InvioNotificheADispoitiviNotiIOS", "LanciaInvioNotifica", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Start Form
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // ID Apps Push Settings - Input
  // **********************************************************************
  public int StartForm (IDVariant IDAppsPushSettings)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Start Form Body
      // Corpo Procedura
      // 
      IDVariant v_VAMBAPPPUSSE = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VIDAPPPUSSET = new IDVariant(0,IDVariant.INTEGER);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.FLG_AMBIENTE as AMBIENTE, ");
      SQL.Append("  A.ID as ID ");
      SQL.Append("from ");
      SQL.Append("  APPS_PUSH_SETTING A ");
      SQL.Append("where (A.ID = " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      if (!QV.EOF())
      {
        v_VAMBAPPPUSSE = QV.Get("AMBIENTE", IDVariant.STRING) ;
        v_VIDAPPPUSSET = QV.Get("ID", IDVariant.INTEGER) ;
      }
      QV.Close();
      IMDB.set_Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF, 0, new IDVariant(v_VIDAPPPUSSET));
      IMDB.set_Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI, 0, new IDVariant(v_VAMBAPPPUSSE));
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("InvioNotificheADispoitiviNotiIOS", "StartForm", _e);
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
      // 
      // Unload Body
      // Corpo Procedura
      // 
      UNLOAD_NOTIFIDELETE();
      PAN_NUOVOPANNELL.set_FieldText(PFL_NUOVOPANNELL_SOUND, (new IDVariant("default")).stringValue());
      PAN_NUOVOPANNELL.set_FieldText(PFL_NUOVOPANNELL_BADGE, (new IDVariant("0")).stringValue());
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("InvioNotificheADispoitiviNotiIOS", "Unload", _e);
    }
  }

  // **********************************************************************
  // Notifiche: Delete
  // Perchè stai eliminando questi dati?
  // **********************************************************************
  private void UNLOAD_NOTIFIDELETE()
  {
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_SQUADRA, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_AMBIENNOTIFI, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_MESSAGNOTIFI, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_DES_UTENTE, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_IDAPPLINOTIF, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_SOUND, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_BADGE, 0, new IDVariant());
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
      // 
      // Load Body
      // Corpo Procedura
      // 
      IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_BADGE, 0, (new IDVariant(0)));
      IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_SOUND, 0, (new IDVariant("default")));
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("InvioNotificheADispoitiviNotiIOS", "Load", _e);
    }
  }

  // **********************************************************************
  // Notifiche
  // Recupera i record da mostrare nel pannello
  // **********************************************************************
  private void INVNOADINOIO_NOTIFICHE2()
  {
    IDVariant[] AggrBuff;
    int[] AggrRowCount;
    int AggrCount=0;
    bool AggrNewGroup = false;

    IMDB.TblTruncate(IMDBDef1.PQRY_NOTIFICHE2_RS);
    IMDB.TblMoveFirst(IMDBDef1.TBL_NOTIFICHE5, 0);
    Loop1: while (!IMDB.Eof(IMDBDef1.TBL_NOTIFICHE5, 0))
    {
      IMDB.TblAddNew(IMDBDef1.PQRY_NOTIFICHE2_RS, 0);
      IMDB.TblLinkRow(IMDBDef1.PQRY_NOTIFICHE2_RS, 0, IMDBDef1.TBL_NOTIFICHE5, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 0, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_AMBIENNOTIFI, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 1, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_MESSAGNOTIFI, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 2, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_DES_UTENTE, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 3, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_IDAPPLINOTIF, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 4, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_SOUND, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 5, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_BADGE, 0);
      IMDB.TblMoveNext(IMDBDef1.TBL_NOTIFICHE5, 0);
      if (IMDB.Eof(IMDBDef1.TBL_NOTIFICHE5, 0))
      {
        IMDB.TblMoveFirst(IMDBDef1.TBL_NOTIFICHE5, 0);
      }
      else
      {
        goto Loop1;
      }
      break;
    }
    IMDB.TblMoveFirst(IMDBDef1.PQRY_NOTIFICHE2_RS, 0);
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
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI, 0, (new IDVariant("S")));
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
    PAN_NUOVOPANNELL.SetSize(MyGlb.OBJ_FIELD, 7);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, "D356D899-A5D7-4641-9BA4-504B7733B870");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, "Applicazione");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, "0AC3B8D1-3F4A-4845-942F-7C51D3168252");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, "Utente");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, "66BC0846-4CBD-43B0-AEBE-F2D2E0F17696");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, "Sound");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, "37980AD2-F800-4869-85F7-FE50A7AE9D1A");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, "Badge");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, "99050360-1147-49D3-A454-882D21ACD23E");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, "Messaggio");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, "Messaggio da inviare");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_VERTHDRFORM | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, "64F514C4-8D81-4E6A-B0B3-F025B851E49B");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, "Invia");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.VIS_COMMANBUTTO1);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_NOACTD | MyGlb.FLD_CANACTIVATE, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, "959A94B6-ECDC-4BD3-B042-D036B6C820E7");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, "Ambiente");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, 0 | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_NUOVOPANNELL_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_LIST, 0, 36, 268, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_LIST, 84);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_FORM, 12, 24, 432, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_FORM, 72);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_APPLICAZIONE, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_APPLICAZIONE, PPQRY_NOTIFICHE2, "A.IDAPPLINOTIF", "IDAPPLINOTIF", 1, 52, 0, -685);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_LIST, 0, 36, 508, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_LIST, 108);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_LIST, "Utente");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_FORM, 12, 48, 432, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_FORM, 72);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_FORM, "Utente");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_UTENTE, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_UTENTE, PPQRY_NOTIFICHE2, "A.DES_UTENTE", "DES_UTENTE", 5, 100, 0, -685);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_LIST, 0, 36, 504, 32, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_LIST, 92);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_LIST, 2);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_LIST, "Sound");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_FORM, 12, 72, 324, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_FORM, 72);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_FORM, "Sound");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_SOUND, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_SOUND, PPQRY_NOTIFICHE2, "A.SOUND", "SOUND", 5, 200, 0, -685);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_LIST, 0, 36, 92, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_LIST, 92);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_LIST, "Badge");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_FORM, 340, 72, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_FORM, 44);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_FORM, "Badge");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_BADGE, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_BADGE, PPQRY_NOTIFICHE2, "A.BADGE", "BADGE", 1, 9, 0, -685);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_LIST, 0, 36, 380, 32, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_LIST, 60);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_LIST, 2);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_LIST, "Messaggio");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_FORM, 12, 104, 432, 124, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_FORM, 20);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_FORM, 7);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_FORM, "Messaggio");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_MESSAGGIO, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_MESSAGGIO, PPQRY_NOTIFICHE2, "A.MESSAGNOTIFI", "MESSAGNOTIFI", 9, 500, 0, -685);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_LIST, 312, 204, 80, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_LIST, 0);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_LIST, 2);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_FORM, 356, 248, 88, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_FORM, 0);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_FORM, 2);
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_BOTTONEINVIA, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_BOTTONEINVIA, -1, "", "BOTTONEINVIA", 0, 0, 0, -685);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_LIST, 0, 36, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_LIST, 56);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_LIST, "Ambiente");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_FORM, 4, 272, 100, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_FORM, 56);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_FORM, "Ambiente");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_AMBIENTE, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_AMBIENTE, PPQRY_NOTIFICHE2, "A.AMBIENNOTIFI", "AMBIENNOTIFI", 5, 1, 0, -685);
    PAN_NUOVOPANNELL.SetValueListItem(PFL_NUOVOPANNELL_AMBIENTE, (new IDVariant("S")), "Sviluppo", "", "", -1);
    PAN_NUOVOPANNELL.SetValueListItem(PFL_NUOVOPANNELL_AMBIENTE, (new IDVariant("P")), "Produzione", "", "", -1);
  }

  private void PAN_NUOVOPANNELL_InitQueries()
  {
    StringBuilder SQL;

    PAN_NUOVOPANNELL.SetSize(MyGlb.OBJ_QUERY, 3);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.ID = ~~IDAPPLINOTIF~~) ");
    SQL.Append("and   (A.TYPE_OS = '1') ");
    PAN_NUOVOPANNELL.SetQuery(PPQRY_APPLICAZIONI, 0, SQL, PFL_NUOVOPANNELL_APPLICAZIONE, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
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
    SQL.Append("  B.DEV_TOKEN as DEVTOKDISNOT, ");
    SQL.Append("  B.DES_MESSAGGIO as NOMDISNODETO ");
    SQL.Append("from ");
    SQL.Append("  DISPOSITIVI_NOTI B ");
    SQL.Append("where (B.DES_MESSAGGIO = ~~DES_UTENTE~~) ");
    SQL.Append("and   (B.DEV_TOKEN IN ");
    SQL.Append("( ");
    SQL.Append("select distinct ");
    SQL.Append("  A.DEV_TOKEN ");
    SQL.Append("from ");
    SQL.Append("  DEV_TOKENS A ");
    SQL.Append("where (A.ID_APPLICAZIONE = ~~IDAPPLINOTIF~~) ");
    SQL.Append(")) ");
    PAN_NUOVOPANNELL.SetQuery(PPQRY_DEVICETOKEN, 0, SQL, PFL_NUOVOPANNELL_UTENTE, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  B.DEV_TOKEN as DEVTOKDISNOT, ");
    SQL.Append("  B.DES_MESSAGGIO as NOMDISNODETO ");
    SQL.Append("from ");
    SQL.Append("  DISPOSITIVI_NOTI B ");
    SQL.Append("where (B.DEV_TOKEN IN ");
    SQL.Append("( ");
    SQL.Append("select distinct ");
    SQL.Append("  A.DEV_TOKEN ");
    SQL.Append("from ");
    SQL.Append("  DEV_TOKENS A ");
    SQL.Append("where (A.ID_APPLICAZIONE = ~~IDAPPLINOTIF~~) ");
    SQL.Append(")) ");
    PAN_NUOVOPANNELL.SetQuery(PPQRY_DEVICETOKEN, 1, SQL, PFL_NUOVOPANNELL_UTENTE, "");
    PAN_NUOVOPANNELL.SetQueryDB(PPQRY_DEVICETOKEN, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_NUOVOPANNELL.SetIMDB(IMDB, "PQRY_NOTIFICHE2", true);
    PAN_NUOVOPANNELL.set_SetString(MyGlb.MASTER_ROWNAME, "Record");
    PAN_NUOVOPANNELL.SetQueryIMDB(PPQRY_NOTIFICHE2, IMDBDef1.PQRY_NOTIFICHE2_RS, IMDBDef1.TBL_NOTIFICHE5);
    JustLoaded = true;
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_APPLICAZIONE, IMDBDef1.FLD_NOTIFICHE5_IDAPPLINOTIF);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_UTENTE, IMDBDef1.FLD_NOTIFICHE5_DES_UTENTE);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_SOUND, IMDBDef1.FLD_NOTIFICHE5_SOUND);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_BADGE, IMDBDef1.FLD_NOTIFICHE5_BADGE);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_MESSAGGIO, IMDBDef1.FLD_NOTIFICHE5_MESSAGNOTIFI);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_AMBIENTE, IMDBDef1.FLD_NOTIFICHE5_AMBIENNOTIFI);
    PAN_NUOVOPANNELL.SetMasterTable(0, "NOTIFICHE5");
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
