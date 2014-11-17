// **********************************************
// Invio WNS Manuale
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
public partial class InvioWNSManuale : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_PARAMETRI_RISULTATO = 0;
  private const int PFL_PARAMETRI_REGIDSPEDIZI = 1;
  private const int PFL_PARAMETRI_MESSAGSPEDIZ = 2;
  private const int PFL_PARAMETRI_ETICHETINVIA = 3;
  private const int PFL_PARAMETRI_ETICCREASPED = 4;
  private const int PFL_PARAMETRI_WNSSECRET = 5;
  private const int PFL_PARAMETRI_WNSSID = 6;
  private const int PFL_PARAMETRI_WNSXMLTEMPLA = 7;
  private const int PFL_PARAMETRI_ETICOTTIACCE = 8;
  private const int PFL_PARAMETRI_ACCESSTOCKEN = 9;

  private const int PPQRY_NUOVATABELLA = 0;


  internal IDPanel PAN_PARAMETRI;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    Init_TBL_PARAMETRI(IMDB);
    //
    //
    Init_PQRY_NUOVATABELLA(IMDB);
    Init_PQRY_NUOVATABELLA_RS(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_TBL_PARAMETRI(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.TBL_PARAMETRI, 9);
    IMDB.set_TblCode(IMDBDef1.TBL_PARAMETRI, "TBL_PARAMETRI");
    IMDB.set_FldCode(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_DES_MESSAGGIO, "DES_MESSAGGIO");
    IMDB.SetFldParams(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_DES_MESSAGGIO,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_REG_ID, "REG_ID");
    IMDB.SetFldParams(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_REG_ID,5,200,0);
    IMDB.set_FldCode(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_RISUNOMEOGGE, "RISUNOMEOGGE");
    IMDB.SetFldParams(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_RISUNOMEOGGE,9,5000,0);
    IMDB.set_FldCode(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_DEV_TOKEN, "DEV_TOKEN");
    IMDB.SetFldParams(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_DEV_TOKEN,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_ID_APPLICAZIONE, "ID_APPLICAZIONE");
    IMDB.SetFldParams(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_ID_APPLICAZIONE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_WNS_SECRET, "WNS_SECRET");
    IMDB.SetFldParams(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_WNS_SECRET,5,500,0);
    IMDB.set_FldCode(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_WNS_SID, "WNS_SID");
    IMDB.SetFldParams(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_WNS_SID,5,500,0);
    IMDB.set_FldCode(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_WNS_XML, "WNS_XML");
    IMDB.SetFldParams(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_WNS_XML,9,5000,0);
    IMDB.set_FldCode(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_ACCTOCNOMOGG, "ACCTOCNOMOGG");
    IMDB.SetFldParams(IMDBDef1.TBL_PARAMETRI,IMDBDef1.FLD_PARAMETRI_ACCTOCNOMOGG,9,5000,0);
    IMDB.TblAddNew(IMDBDef1.TBL_PARAMETRI, 0);
  }

  private static void Init_PQRY_NUOVATABELLA(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_NUOVATABELLA, 7);
    IMDB.set_TblCode(IMDBDef1.PQRY_NUOVATABELLA, "PQRY_NUOVATABELLA");
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_DES_MESSAGGIO, "DES_MESSAGGIO");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_DES_MESSAGGIO,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_REG_ID, "REG_ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_REG_ID,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_RISUNOMEOGGE, "RISUNOMEOGGE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_RISUNOMEOGGE,9,5000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_WNS_SECRET, "WNS_SECRET");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_WNS_SECRET,5,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_WNS_SID, "WNS_SID");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_WNS_SID,5,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_WNS_XML, "WNS_XML");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_WNS_XML,9,5000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_ACCTOCNOMOGG, "ACCTOCNOMOGG");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA,IMDBDef1.PQSL_NUOVATABELLA_ACCTOCNOMOGG,9,5000,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_NUOVATABELLA, 0);
  }

  private static void Init_PQRY_NUOVATABELLA_RS(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_NUOVATABELLA_RS, 7);
    IMDB.set_TblCode(IMDBDef1.PQRY_NUOVATABELLA_RS, "PQRY_NUOVATABELLA_RS");
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_DES_MESSAGGIO, "DES_MESSAGGIO");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_DES_MESSAGGIO,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_REG_ID, "REG_ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_REG_ID,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_RISUNOMEOGGE, "RISUNOMEOGGE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_RISUNOMEOGGE,9,5000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_WNS_SECRET, "WNS_SECRET");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_WNS_SECRET,5,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_WNS_SID, "WNS_SID");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_WNS_SID,5,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_WNS_XML, "WNS_XML");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_WNS_XML,9,5000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_ACCTOCNOMOGG, "ACCTOCNOMOGG");
    IMDB.SetFldParams(IMDBDef1.PQRY_NUOVATABELLA_RS,IMDBDef1.PQSL_NUOVATABELLA_ACCTOCNOMOGG,9,5000,0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public InvioWNSManuale(MyWebEntryPoint w, IMDBObj imdb)
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
  public InvioWNSManuale()
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
    FormIdx = MyGlb.FRM_INVIOWNSMANU;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "8C4BEA99-2556-4E78-BB51-CC97081C9297";
    ResModeW = 1;
    ResModeH = 1;
    iVisualFlags = -2049;
    DesignWidth = 592;
    DesignHeight = 542;
    set_Caption(new IDVariant("Invio WNS Manuale"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 592;
    Frames[1].Height = 516;
    Frames[1].FrHidden = true;
    Frames[1].Caption = "Parametri";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 516;
    PAN_PARAMETRI = new IDPanel(w, this, 1, "PAN_PARAMETRI");
    Frames[1].Content = PAN_PARAMETRI;
    PAN_PARAMETRI.Lockable = false;
    PAN_PARAMETRI.iLocked = false;
    PAN_PARAMETRI.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_PARAMETRI.VS = MainFrm.VisualStyleList;
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 592-MyGlb.PAN_OFFS_X, 516-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_PARAMETRI.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "8900A2F8-18E4-4271-8F74-7D5132D492AF");
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 2160, 112, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_PARAMETRI.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_PARAMETRI.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_STARTFORM | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_AUTOSAVE | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_PARAMETRI.InitStatus = 1;
    PAN_PARAMETRI_Init();
    PAN_PARAMETRI_InitFields();
    PAN_PARAMETRI_InitQueries();
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
      if (IMDB.TblModified(IMDBDef1.TBL_PARAMETRI, MyGlb.GlbRefModIdx) || JustLoaded)
      {
        INVIOWNSMANU_NUOVATABELLA();
      }
      PAN_PARAMETRI.UpdatePanel(MainFrm);
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
    return (obj is InvioWNSManuale);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(InvioWNSManuale).FullName : typeof(InvioWNSManuale).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Etichetta Invia
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int EtichettaInvia ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Etichetta Invia Body
      // Corpo Procedura
      // 
      IDVariant v_CODICERITORN = new IDVariant(0,IDVariant.INTEGER);
      IDVariant v_TESTORITORNO = new IDVariant(0,IDVariant.STRING);
      v_CODICERITORN = new IDVariant(WNSHelperInde.SendWinStorePushNotification(IMDB.Value(IMDBDef1.PQRY_NUOVATABELLA, IMDBDef1.PQSL_NUOVATABELLA_ACCTOCNOMOGG, 0).stringValue(), IMDB.Value(IMDBDef1.PQRY_NUOVATABELLA, IMDBDef1.PQSL_NUOVATABELLA_REG_ID, 0).stringValue(), IMDB.Value(IMDBDef1.PQRY_NUOVATABELLA, IMDBDef1.PQSL_NUOVATABELLA_DES_MESSAGGIO, 0).stringValue(), out v_TESTORITORNO));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_RISUNOMEOGGE, 0, new IDVariant(v_TESTORITORNO));
      PAN_PARAMETRI.PanelCommand(Glb.PCM_REQUERY);
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("InvioWNSManuale", "EtichettaInvia", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Etichetta Crea spedizione
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int EtichettaCreaspedizione ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Etichetta Crea spedizione Body
      // Corpo Procedura
      // 
      if (!(IDL.IsNull(IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_ID_APPLICAZIONE, 0))))
      {
        SQL = new StringBuilder();
        SQL.Append("insert into SPEDIZIONI ");
        SQL.Append("( ");
        SQL.Append("  ID_APPLICAZIONE, ");
        SQL.Append("  DEV_TOKEN, ");
        SQL.Append("  DES_MESSAGGIO, ");
        SQL.Append("  FLG_STATO, ");
        SQL.Append("  DAT_CREAZ, ");
        SQL.Append("  REG_ID, ");
        SQL.Append("  TYPE_OS ");
        SQL.Append(") ");
        SQL.Append("values ");
        SQL.Append("( ");
        SQL.Append("  " + IDL.CSql(IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_ID_APPLICAZIONE, 0), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  " + IDL.CSql(IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_DEV_TOKEN, 0), IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  " + IDL.CSql(IMDB.Value(IMDBDef1.PQRY_NUOVATABELLA, IMDBDef1.PQSL_NUOVATABELLA_DES_MESSAGGIO, 0), IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  'W', ");
        SQL.Append("  GETDATE(), ");
        SQL.Append("  " + IDL.CSql(IMDB.Value(IMDBDef1.PQRY_NUOVATABELLA, IMDBDef1.PQSL_NUOVATABELLA_REG_ID, 0), IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  '5' ");
        SQL.Append(") ");
        MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
      }
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("InvioWNSManuale", "EtichettaCreaspedizione", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Access Tocken
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int AccessTocken ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Access Tocken Body
      // Corpo Procedura
      // 
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_ACCTOCNOMOGG, 0, new IDVariant(WNSHelperInde.GetWinStoreAccessToken(IMDB.Value(IMDBDef1.PQRY_NUOVATABELLA, IMDBDef1.PQSL_NUOVATABELLA_WNS_SECRET, 0).stringValue(), IMDB.Value(IMDBDef1.PQRY_NUOVATABELLA, IMDBDef1.PQSL_NUOVATABELLA_WNS_SID, 0).stringValue())));
      PAN_PARAMETRI.PanelCommand(Glb.PCM_REQUERY);
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("InvioWNSManuale", "AccessTocken", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Nuova Tabella
  // Recupera i record da mostrare nel pannello
  // **********************************************************************
  private void INVIOWNSMANU_NUOVATABELLA()
  {
    IDVariant[] AggrBuff;
    int[] AggrRowCount;
    int AggrCount=0;
    bool AggrNewGroup = false;

    IMDB.TblTruncate(IMDBDef1.PQRY_NUOVATABELLA_RS);
    IMDB.TblMoveFirst(IMDBDef1.TBL_PARAMETRI, 0);
    Loop1: while (!IMDB.Eof(IMDBDef1.TBL_PARAMETRI, 0))
    {
      IMDB.TblAddNew(IMDBDef1.PQRY_NUOVATABELLA_RS, 0);
      IMDB.TblLinkRow(IMDBDef1.PQRY_NUOVATABELLA_RS, 0, IMDBDef1.TBL_PARAMETRI, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NUOVATABELLA_RS, 0, 0, IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_DES_MESSAGGIO, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NUOVATABELLA_RS, 1, 0, IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_REG_ID, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NUOVATABELLA_RS, 2, 0, IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_RISUNOMEOGGE, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NUOVATABELLA_RS, 3, 0, IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_WNS_SECRET, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NUOVATABELLA_RS, 4, 0, IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_WNS_SID, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NUOVATABELLA_RS, 5, 0, IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_WNS_XML, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NUOVATABELLA_RS, 6, 0, IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_ACCTOCNOMOGG, 0);
      IMDB.TblMoveNext(IMDBDef1.TBL_PARAMETRI, 0);
      if (IMDB.Eof(IMDBDef1.TBL_PARAMETRI, 0))
      {
        IMDB.TblMoveFirst(IMDBDef1.TBL_PARAMETRI, 0);
      }
      else
      {
        goto Loop1;
      }
      break;
    }
    IMDB.TblMoveFirst(IMDBDef1.PQRY_NUOVATABELLA_RS, 0);
  }



  // **********************************************
  // Event Stubs
  // **********************************************	
  // **********************************************************************
  // Load
  // Evento notificato alla videata al momento del caricamento
  // in memoria.
  // **********************************************************************
  private void IntFormLoad ()
  {
    // Stub
  }

  // **********************************************************************
  // Unload
  // Evento notificato dal form prima della chiusura dello
  // stesso
  // **********************************************************************
  public override void IntFormUnload (IDVariant Cancel, IDVariant Confirm)
  {
    // Stub
  }

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
  private void PAN_PARAMETRI_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
    if (ColIndex.intValue() == PFL_PARAMETRI_ETICHETINVIA)
    {
      this.IdxPanelActived = this.PAN_PARAMETRI.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      EtichettaInvia();
      Cancel.set(IDVariant.TRUE);
    }
    if (ColIndex.intValue() == PFL_PARAMETRI_ETICCREASPED)
    {
      this.IdxPanelActived = this.PAN_PARAMETRI.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      EtichettaCreaspedizione();
      Cancel.set(IDVariant.TRUE);
    }
    if (ColIndex.intValue() == PFL_PARAMETRI_ETICOTTIACCE)
    {
      this.IdxPanelActived = this.PAN_PARAMETRI.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      AccessTocken();
      Cancel.set(IDVariant.TRUE);
    }
  }

  private void PAN_PARAMETRI_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_PARAMETRI_ValidateRow(IDVariant Cancel)
  {
    try
    {
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_PARAMETRI_Init()
  {

    PAN_PARAMETRI.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_PARAMETRI.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_PARAMETRI.SetSize(MyGlb.OBJ_FIELD, 10);
    PAN_PARAMETRI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, "9B76F74F-F270-4C3A-8AA0-BA061BD4F406");
    PAN_PARAMETRI.set_Header(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, "Risultato");
    PAN_PARAMETRI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, "");
    PAN_PARAMETRI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, MyGlb.VIS_NORMALFIELDS);
    PAN_PARAMETRI.SetFlags(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_PARAMETRI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, "AB42EA4B-C5F8-49E2-B35C-B2FBE36EEA5B");
    PAN_PARAMETRI.set_Header(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, "Regid Spedizione");
    PAN_PARAMETRI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, "RegID usato da android");
    PAN_PARAMETRI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, MyGlb.VIS_NORMALFIELDS);
    PAN_PARAMETRI.SetFlags(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_PARAMETRI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, "90426E32-3442-41EE-B382-E936EB4F38E1");
    PAN_PARAMETRI.set_Header(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, "Messaggio Spedizione");
    PAN_PARAMETRI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, "");
    PAN_PARAMETRI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, MyGlb.VIS_NORMALFIELDS);
    PAN_PARAMETRI.SetFlags(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_PARAMETRI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICHETINVIA, "A249C6E8-F361-4CCB-92B5-C5B38911B2DC");
    PAN_PARAMETRI.set_Header(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICHETINVIA, "Invia");
    PAN_PARAMETRI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICHETINVIA, MyGlb.VIS_COMMANBUTTO1);
    PAN_PARAMETRI.SetFlags(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICHETINVIA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_CANACTIVATE, -1);
    PAN_PARAMETRI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICCREASPED, "79B43699-95D7-4EB8-94BA-9FFEE50AF7F5");
    PAN_PARAMETRI.set_Header(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICCREASPED, "Crea spedizione");
    PAN_PARAMETRI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICCREASPED, MyGlb.VIS_COMMANBUTTO1);
    PAN_PARAMETRI.SetFlags(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICCREASPED, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_CANACTIVATE, -1);
    PAN_PARAMETRI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, "46B39035-F986-4583-9B98-E8F54E8C4698");
    PAN_PARAMETRI.set_Header(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, "Wns Secret");
    PAN_PARAMETRI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, "");
    PAN_PARAMETRI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, MyGlb.VIS_NORMALFIELDS);
    PAN_PARAMETRI.SetFlags(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_PARAMETRI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, "3D5842F2-386E-48BB-BF4F-2161395DCE82");
    PAN_PARAMETRI.set_Header(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, "Wns Sid");
    PAN_PARAMETRI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, "");
    PAN_PARAMETRI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, MyGlb.VIS_NORMALFIELDS);
    PAN_PARAMETRI.SetFlags(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_PARAMETRI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, "D2CBDBB3-82F4-487B-BDFA-6CFDC833AAFF");
    PAN_PARAMETRI.set_Header(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, "Wns Xml Template");
    PAN_PARAMETRI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, "");
    PAN_PARAMETRI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, MyGlb.VIS_NORMALFIELDS);
    PAN_PARAMETRI.SetFlags(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_PARAMETRI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICOTTIACCE, "E6AB2475-7220-4317-9CEC-6CE9FD9DB136");
    PAN_PARAMETRI.set_Header(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICOTTIACCE, "Ottieni AccessTocken");
    PAN_PARAMETRI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICOTTIACCE, MyGlb.VIS_COMMANBUTTO1);
    PAN_PARAMETRI.SetFlags(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICOTTIACCE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_CANACTIVATE, -1);
    PAN_PARAMETRI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, "6B67B891-A5CF-4798-8569-1BEBB4C27296");
    PAN_PARAMETRI.set_Header(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, "Access Tocken");
    PAN_PARAMETRI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, "");
    PAN_PARAMETRI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, MyGlb.VIS_NORMALFIELDS);
    PAN_PARAMETRI.SetFlags(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_PARAMETRI_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, MyGlb.PANEL_LIST, 0, 36, 432, 44, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, MyGlb.PANEL_LIST, 52);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, MyGlb.PANEL_LIST, 2);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, MyGlb.PANEL_LIST, "Risultato");
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, MyGlb.PANEL_FORM, 8, 416, 560, 80, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, MyGlb.PANEL_FORM, 108);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, MyGlb.PANEL_FORM, 5);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_RISULTATO, MyGlb.PANEL_FORM, "Risultato");
    PAN_PARAMETRI.SetFieldPage(PFL_PARAMETRI_RISULTATO, -1, -1);
    PAN_PARAMETRI.SetFieldPanel(PFL_PARAMETRI_RISULTATO, PPQRY_NUOVATABELLA, "A.RISUNOMEOGGE", "RISUNOMEOGGE", 9, 5000, 0, -685);
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, MyGlb.PANEL_LIST, 4, 124, 528, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, MyGlb.PANEL_LIST, 128);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, MyGlb.PANEL_LIST, 2);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, MyGlb.PANEL_LIST, "Regid Spedizione");
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, MyGlb.PANEL_FORM, 8, 56, 560, 24, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, MyGlb.PANEL_FORM, 108);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, MyGlb.PANEL_FORM, 1);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_REGIDSPEDIZI, MyGlb.PANEL_FORM, "Regid Spedizione");
    PAN_PARAMETRI.SetFieldPage(PFL_PARAMETRI_REGIDSPEDIZI, -1, -1);
    PAN_PARAMETRI.SetFieldPanel(PFL_PARAMETRI_REGIDSPEDIZI, PPQRY_NUOVATABELLA, "A.REG_ID", "REG_ID", 5, 200, 0, -685);
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, MyGlb.PANEL_LIST, 4, 100, 528, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, MyGlb.PANEL_LIST, 128);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, MyGlb.PANEL_LIST, 2);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, MyGlb.PANEL_LIST, "Messaggio Spedizione");
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, MyGlb.PANEL_FORM, 8, 216, 560, 100, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, MyGlb.PANEL_FORM, 108);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, MyGlb.PANEL_FORM, 7);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_MESSAGSPEDIZ, MyGlb.PANEL_FORM, "Messaggio Spedizione");
    PAN_PARAMETRI.SetFieldPage(PFL_PARAMETRI_MESSAGSPEDIZ, -1, -1);
    PAN_PARAMETRI.SetFieldPanel(PFL_PARAMETRI_MESSAGSPEDIZ, PPQRY_NUOVATABELLA, "A.DES_MESSAGGIO", "DES_MESSAGGIO", 9, 1000, 0, -685);
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICHETINVIA, MyGlb.PANEL_LIST, 44, 344, 92, 24, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICHETINVIA, MyGlb.PANEL_LIST, 0);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICHETINVIA, MyGlb.PANEL_LIST, 1);
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICHETINVIA, MyGlb.PANEL_FORM, 476, 384, 92, 24, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICHETINVIA, MyGlb.PANEL_FORM, 0);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICHETINVIA, MyGlb.PANEL_FORM, 1);
    PAN_PARAMETRI.SetFieldPage(PFL_PARAMETRI_ETICHETINVIA, -1, -1);
    PAN_PARAMETRI.SetFieldPanel(PFL_PARAMETRI_ETICHETINVIA, -1, "", "ETICHETINVIA", 0, 0, 0, -685);
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICCREASPED, MyGlb.PANEL_LIST, 188, 276, 116, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICCREASPED, MyGlb.PANEL_LIST, 0);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICCREASPED, MyGlb.PANEL_LIST, 2);
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICCREASPED, MyGlb.PANEL_FORM, 448, 324, 116, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICCREASPED, MyGlb.PANEL_FORM, 0);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICCREASPED, MyGlb.PANEL_FORM, 2);
    PAN_PARAMETRI.SetFieldPage(PFL_PARAMETRI_ETICCREASPED, -1, -1);
    PAN_PARAMETRI.SetFieldPanel(PFL_PARAMETRI_ETICCREASPED, -1, "", "ETICCREASPED", 0, 0, 0, -685);
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, MyGlb.PANEL_LIST, 0, 36, 432, 44, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, MyGlb.PANEL_LIST, 160);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, MyGlb.PANEL_LIST, 2);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, MyGlb.PANEL_LIST, "Wns Secret");
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, MyGlb.PANEL_FORM, 8, 4, 560, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, MyGlb.PANEL_FORM, 108);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, MyGlb.PANEL_FORM, 1);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSECRET, MyGlb.PANEL_FORM, "Wns Secret");
    PAN_PARAMETRI.SetFieldPage(PFL_PARAMETRI_WNSSECRET, -1, -1);
    PAN_PARAMETRI.SetFieldPanel(PFL_PARAMETRI_WNSSECRET, PPQRY_NUOVATABELLA, "A.WNS_SECRET", "WNS_SECRET", 5, 500, 0, -685);
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, MyGlb.PANEL_LIST, 0, 36, 432, 44, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, MyGlb.PANEL_LIST, 256);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, MyGlb.PANEL_LIST, 2);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, MyGlb.PANEL_LIST, "Wns Sid");
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, MyGlb.PANEL_FORM, 8, 28, 560, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, MyGlb.PANEL_FORM, 108);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, MyGlb.PANEL_FORM, 1);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSSID, MyGlb.PANEL_FORM, "Wns Sid");
    PAN_PARAMETRI.SetFieldPage(PFL_PARAMETRI_WNSSID, -1, -1);
    PAN_PARAMETRI.SetFieldPanel(PFL_PARAMETRI_WNSSID, PPQRY_NUOVATABELLA, "A.WNS_SID", "WNS_SID", 5, 500, 0, -685);
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, MyGlb.PANEL_LIST, 0, 36, 432, 44, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, MyGlb.PANEL_LIST, 192);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, MyGlb.PANEL_LIST, 2);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, MyGlb.PANEL_LIST, "Wns Xml Template");
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, MyGlb.PANEL_FORM, 8, 84, 560, 124, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, MyGlb.PANEL_FORM, 108);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, MyGlb.PANEL_FORM, 9);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_WNSXMLTEMPLA, MyGlb.PANEL_FORM, "Wns Xml Template");
    PAN_PARAMETRI.SetFieldPage(PFL_PARAMETRI_WNSXMLTEMPLA, -1, -1);
    PAN_PARAMETRI.SetFieldPanel(PFL_PARAMETRI_WNSXMLTEMPLA, PPQRY_NUOVATABELLA, "A.WNS_XML", "WNS_XML", 9, 5000, 0, -685);
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICOTTIACCE, MyGlb.PANEL_LIST, 128, 328, 104, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICOTTIACCE, MyGlb.PANEL_LIST, 0);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICOTTIACCE, MyGlb.PANEL_LIST, 2);
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICOTTIACCE, MyGlb.PANEL_FORM, 120, 324, 136, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICOTTIACCE, MyGlb.PANEL_FORM, 0);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ETICOTTIACCE, MyGlb.PANEL_FORM, 2);
    PAN_PARAMETRI.SetFieldPage(PFL_PARAMETRI_ETICOTTIACCE, -1, -1);
    PAN_PARAMETRI.SetFieldPanel(PFL_PARAMETRI_ETICOTTIACCE, -1, "", "ETICOTTIACCE", 0, 0, 0, -685);
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, MyGlb.PANEL_LIST, 0, 36, 432, 44, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, MyGlb.PANEL_LIST, 80);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, MyGlb.PANEL_LIST, 2);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, MyGlb.PANEL_LIST, "Access Tocken");
    PAN_PARAMETRI.SetRect(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, MyGlb.PANEL_FORM, 8, 364, 444, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PARAMETRI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, MyGlb.PANEL_FORM, 108);
    PAN_PARAMETRI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, MyGlb.PANEL_FORM, 2);
    PAN_PARAMETRI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PARAMETRI_ACCESSTOCKEN, MyGlb.PANEL_FORM, "Access Tocken");
    PAN_PARAMETRI.SetFieldPage(PFL_PARAMETRI_ACCESSTOCKEN, -1, -1);
    PAN_PARAMETRI.SetFieldPanel(PFL_PARAMETRI_ACCESSTOCKEN, PPQRY_NUOVATABELLA, "A.ACCTOCNOMOGG", "ACCTOCNOMOGG", 9, 5000, 0, -685);
  }

  private void PAN_PARAMETRI_InitQueries()
  {
    StringBuilder SQL;

    PAN_PARAMETRI.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_PARAMETRI.SetIMDB(IMDB, "PQRY_NUOVATABELLA", true);
    PAN_PARAMETRI.set_SetString(MyGlb.MASTER_ROWNAME, "Nome Oggetto");
    PAN_PARAMETRI.SetQueryIMDB(PPQRY_NUOVATABELLA, IMDBDef1.PQRY_NUOVATABELLA_RS, IMDBDef1.TBL_PARAMETRI);
    JustLoaded = true;
    PAN_PARAMETRI.SetFieldPrimaryIndex(PFL_PARAMETRI_RISULTATO, IMDBDef1.FLD_PARAMETRI_RISUNOMEOGGE);
    PAN_PARAMETRI.SetFieldPrimaryIndex(PFL_PARAMETRI_REGIDSPEDIZI, IMDBDef1.FLD_PARAMETRI_REG_ID);
    PAN_PARAMETRI.SetFieldPrimaryIndex(PFL_PARAMETRI_MESSAGSPEDIZ, IMDBDef1.FLD_PARAMETRI_DES_MESSAGGIO);
    PAN_PARAMETRI.SetFieldPrimaryIndex(PFL_PARAMETRI_WNSSECRET, IMDBDef1.FLD_PARAMETRI_WNS_SECRET);
    PAN_PARAMETRI.SetFieldPrimaryIndex(PFL_PARAMETRI_WNSSID, IMDBDef1.FLD_PARAMETRI_WNS_SID);
    PAN_PARAMETRI.SetFieldPrimaryIndex(PFL_PARAMETRI_WNSXMLTEMPLA, IMDBDef1.FLD_PARAMETRI_WNS_XML);
    PAN_PARAMETRI.SetFieldPrimaryIndex(PFL_PARAMETRI_ACCESSTOCKEN, IMDBDef1.FLD_PARAMETRI_ACCTOCNOMOGG);
    PAN_PARAMETRI.SetMasterTable(0, "PARAMETRI");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_PARAMETRI) PAN_PARAMETRI_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_PARAMETRI) PAN_PARAMETRI_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_PARAMETRI) PAN_PARAMETRI_CellActivated(ColIndex, Cancel);
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
