// **********************************************
// Impostazioni IOS
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
public partial class ImpostazioniIOS : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  internal OTabView TAB_NUOVTABBVIEW;
  private const int PFL_APPLICATTIVE_ID1 = 0;
  private const int PFL_APPLICATTIVE_APPLICAZION1 = 1;
  private const int PFL_APPLICATTIVE_CERTIFICPUS1 = 2;
  private const int PFL_APPLICATTIVE_DATASCADENZ1 = 3;
  private const int PFL_APPLICATTIVE_NOTA1 = 4;
  private const int PFL_APPLICATTIVE_AMBIENTE1 = 5;
  private const int PFL_APPLICATTIVE_ATTIVA1 = 6;
  private const int PFL_APPLICATTIVE_TYPEOS1 = 7;
  private const int PFL_APPLICATTIVE_ERRORI1 = 8;

  private const int PPQRY_APPLICAZION1 = 0;

  private const int PPQRY_APPS1 = 1;


  internal IDPanel PAN_APPLICATTIVE;
  private const int PFL_APPLICDISATT_ID = 0;
  private const int PFL_APPLICDISATT_APPLICAZIONE = 1;
  private const int PFL_APPLICDISATT_CERTIFICPUSH = 2;
  private const int PFL_APPLICDISATT_DATASCADENZA = 3;
  private const int PFL_APPLICDISATT_NOTA = 4;
  private const int PFL_APPLICDISATT_AMBIENTE = 5;
  private const int PFL_APPLICDISATT_ATTIVA = 6;
  private const int PFL_APPLICDISATT_TYPEOS = 7;
  private const int PFL_APPLICDISATT_ERRORI = 8;

  private const int PPQRY_APPLICAZION5 = 0;

  private const int PPQRY_APPS = 1;


  internal IDPanel PAN_APPLICDISATT;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_APPLICAZION1(IMDB);
    Init_PQRY_APPLICAZION5(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_APPLICAZION1(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_APPLICAZION1, 9);
    IMDB.set_TblCode(IMDBDef1.PQRY_APPLICAZION1, "PQRY_APPLICAZION1");
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_CERT_DEV, "CERT_DEV");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_CERT_DEV,5,300,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_FLG_ATTIVA, "FLG_ATTIVA");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_FLG_ATTIVA,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_FLG_AMBIENTE, "FLG_AMBIENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_FLG_AMBIENTE,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_TYPE_OS, "TYPE_OS");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_TYPE_OS,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_ID_APP, "ID_APP");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_ID_APP,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_DAT_SCAD_CERT, "DAT_SCAD_CERT");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_DAT_SCAD_CERT,8,10,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_DES_ERR, "DES_ERR");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION1,IMDBDef1.PQSL_APPLICAZION1_DES_ERR,5,2000,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_APPLICAZION1, 0);
  }

  private static void Init_PQRY_APPLICAZION5(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_APPLICAZION5, 9);
    IMDB.set_TblCode(IMDBDef1.PQRY_APPLICAZION5, "PQRY_APPLICAZION5");
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_CERT_DEV, "CERT_DEV");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_CERT_DEV,5,300,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_FLG_ATTIVA, "FLG_ATTIVA");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_FLG_ATTIVA,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_FLG_AMBIENTE, "FLG_AMBIENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_FLG_AMBIENTE,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_TYPE_OS, "TYPE_OS");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_TYPE_OS,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_ID_APP, "ID_APP");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_ID_APP,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_DAT_SCAD_CERT, "DAT_SCAD_CERT");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_DAT_SCAD_CERT,8,10,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_DES_ERR, "DES_ERR");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION5,IMDBDef1.PQSL_APPLICAZION5_DES_ERR,5,2000,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_APPLICAZION5, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public ImpostazioniIOS(MyWebEntryPoint w, IMDBObj imdb)
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
  public ImpostazioniIOS()
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
    FormIdx = MyGlb.FRM_IMPOSTAZIIOS;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "393A90B8-8170-4FD6-AC84-2D15EF48AB4C";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 1016;
    DesignHeight = 664;
    set_Caption(new IDVariant("Impostazioni IOS"));
    //
    Frames = new AFrame[4];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 1016;
    Frames[1].Height = 604;
    Frames[1].Caption = "Nuova Tabbed View";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 604;
    TAB_NUOVTABBVIEW = new OTabView(this);
    Frames[1].Content = TAB_NUOVTABBVIEW;
    TAB_NUOVTABBVIEW.iGuid = "531E5E95-C6C7-4BFE-815C-2E2B09B8E8D1";
    TAB_NUOVTABBVIEW.SetItemCount(2);
    TAB_NUOVTABBVIEW.Placement = 1;
    TAB_NUOVTABBVIEW.FrIndex = 1;
    Frames[2] = new AFrame(2);
    Frames[2].Parent = this;
    Frames[2].InTabbed = true;
    Frames[2].Caption = "Applicazioni attive";
    Frames[2].Parent = this;
    PAN_APPLICATTIVE = new IDPanel(w, this, 2, "PAN_APPLICATTIVE");
    Frames[2].Content = PAN_APPLICATTIVE;
    PAN_APPLICATTIVE.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_APPLICATTIVE.VS = MainFrm.VisualStyleList;
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 1016-MyGlb.PAN_OFFS_X, 604-MyGlb.PAN_OFFS_Y- MyGlb.PAN_OFFS_PAGEY, 0, 0);
    PAN_APPLICATTIVE.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "5A222668-3377-4999-BA81-C307E5D75492");
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 952, 492, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_APPLICATTIVE.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 44);
    PAN_APPLICATTIVE.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_APPLICATTIVE.InitStatus = 2;
    PAN_APPLICATTIVE_Init();
    PAN_APPLICATTIVE_InitFields();
    PAN_APPLICATTIVE_InitQueries();
    TAB_NUOVTABBVIEW.SetItem(1, Frames[2], 0, "", "Applicazioni attive", "");
    Frames[3] = new AFrame(3);
    Frames[3].Parent = this;
    Frames[3].InTabbed = true;
    Frames[3].Caption = "Applicazioni disattivate";
    Frames[3].Parent = this;
    PAN_APPLICDISATT = new IDPanel(w, this, 3, "PAN_APPLICDISATT");
    Frames[3].Content = PAN_APPLICDISATT;
    PAN_APPLICDISATT.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_APPLICDISATT.VS = MainFrm.VisualStyleList;
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 1016-MyGlb.PAN_OFFS_X, 604-MyGlb.PAN_OFFS_Y- MyGlb.PAN_OFFS_PAGEY, 0, 0);
    PAN_APPLICDISATT.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "828DDE05-1C24-452A-865C-009919C84C38");
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 952, 492, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_APPLICDISATT.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 44);
    PAN_APPLICDISATT.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_APPLICDISATT.InitStatus = 2;
    PAN_APPLICDISATT_Init();
    PAN_APPLICDISATT_InitFields();
    PAN_APPLICDISATT_InitQueries();
    TAB_NUOVTABBVIEW.SetItem(2, Frames[3], 0, "", "Applicazioni disattivate", "");
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
    if (CmdIdx==MyGlb.CMD_INVIADISPNOT+BaseCmdLinIdx)
    {
      ApriInviaPushInterni();
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_INVIAAUTENTI+BaseCmdLinIdx)
    {
      ApriInviaPush();
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_CHECKCERTS+BaseCmdLinIdx)
    {
      CheckCerts();
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_CHECKFEEDBA1+BaseCmdLinIdx)
    {
      CheckFeedbackService1();
      goto fine;
    }
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
      PAN_APPLICATTIVE.UpdatePanel(MainFrm);
      PAN_APPLICDISATT.UpdatePanel(MainFrm);
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
    return (obj is ImpostazioniIOS);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(ImpostazioniIOS).FullName : typeof(ImpostazioniIOS).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Applicazioni attive Before Insert
  // Evento notificato dal pannello prima dell'inserimento
  // nel database dei dati relativi ad una nuova riga di
  // pannello.
  // Cancel - Input/Output
  // **********************************************************************
  private void PAN_APPLICATTIVE_BeforeInsert (IDVariant Cancel)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("D54AEAF0-E2C0-4EDC-B3DB-D58286427D80", "Applicazioni attive Before Insert", "", 0, "Impostazioni IOS")) return;
      MainFrm.DTTObj.AddParameter ("D54AEAF0-E2C0-4EDC-B3DB-D58286427D80", "3287E884-546D-43B4-9042-1E3C22379332", "Cancel", Cancel);
      // 
      // Applicazioni attive Before Insert Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddAssign ("EAD58F0E-8372-4A3B-BF5C-9B84F7A9E1FB", "Type OS Applicazione [Impostazioni IOS - Apps Push Settings] := iOS", "", IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_TYPE_OS, 0));
      MainFrm.DTTObj.AddToken ("EAD58F0E-8372-4A3B-BF5C-9B84F7A9E1FB", "8E64E9E9-98C7-4AE7-9BA4-B6034CE63C9C", 589824, "iOS", (new IDVariant("1")));
      IMDB.set_Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_TYPE_OS, 0, (new IDVariant("1")));
      MainFrm.DTTObj.AddAssignNewValue ("EAD58F0E-8372-4A3B-BF5C-9B84F7A9E1FB", "0E1C6C7E-2135-4ED9-BFD7-0AE5CEDD20E3", IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_TYPE_OS, 0));
      MainFrm.DTTObj.ExitProc("D54AEAF0-E2C0-4EDC-B3DB-D58286427D80", "Applicazioni attive Before Insert", "", 0, "Impostazioni IOS");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("D54AEAF0-E2C0-4EDC-B3DB-D58286427D80", "Applicazioni attive Before Insert", "", _e);
      MainFrm.ErrObj.ProcError ("ImpostazioniIOS", "ApplicazioniattiveBeforeInsert", _e);
      MainFrm.DTTObj.ExitProc("D54AEAF0-E2C0-4EDC-B3DB-D58286427D80", "Applicazioni attive Before Insert", "", 0, "Impostazioni IOS");
    }
  }

  // **********************************************************************
  // Applicazioni attive On Dynamic Properties
  // Consente l'aggiustamento delle proprietà visuali delle
  // singole celle del pannello.
  // **********************************************************************
  private void PAN_APPLICATTIVE_DynamicProperties ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("446D9D84-51A9-4100-8A1A-7C9E175B6129", "Applicazioni attive On Dynamic Properties", "", 1, "Impostazioni IOS")) return;
      // 
      // Applicazioni attive On Dynamic Properties Body
      // Corpo Procedura
      // 
      IDVariant D = new IDVariant(0,IDVariant.DATETIME);
      MainFrm.DTTObj.AddAssign ("C54F8DD3-1E41-430D-B2F8-53B43D1C8BDB", "d := Date Add (Day, -20, Data Scadenza Apps Push Settings Applicazione [Impostazioni IOS - Applicazioni attive])", "", D);
      MainFrm.DTTObj.AddToken ("C54F8DD3-1E41-430D-B2F8-53B43D1C8BDB", "132B6115-2447-11D5-911F-1A0113000000", 589824, "Day", (new IDVariant("d")));
      MainFrm.DTTObj.AddToken ("C54F8DD3-1E41-430D-B2F8-53B43D1C8BDB", "38D0FE01-8A4D-412E-8C55-F934708C97B5", 917504, "Data Scadenza Apps Push Settings", IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_DAT_SCAD_CERT, 0));
      D = IDL.DateAdd((new IDVariant("d")),(new IDVariant(-20)),IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_DAT_SCAD_CERT, 0));
      MainFrm.DTTObj.AddAssignNewValue ("C54F8DD3-1E41-430D-B2F8-53B43D1C8BDB", "6F01F654-7CE6-4DB6-B51E-17263B360FC5", D);
      MainFrm.DTTObj.AddIf ("68CABDAE-5323-464B-8F55-944ECF3CC7FC", "IF C! (Is Null (Data Scadenza Apps Push Settings Applicazione [Impostazioni IOS - Apps Push Settings]))", "");
      MainFrm.DTTObj.AddToken ("68CABDAE-5323-464B-8F55-944ECF3CC7FC", "38D0FE01-8A4D-412E-8C55-F934708C97B5", 917504, "Data Scadenza Apps Push Settings", IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_DAT_SCAD_CERT, 0));
      if (!(IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_DAT_SCAD_CERT, 0))))
      {
        MainFrm.DTTObj.EnterIf ("68CABDAE-5323-464B-8F55-944ECF3CC7FC", "IF C! (Is Null (Data Scadenza Apps Push Settings Applicazione [Impostazioni IOS - Apps Push Settings]))", "");
        MainFrm.DTTObj.AddIf ("3574D130-74F5-4703-A184-40F20AABE687", "IF Today () >= Data Scadenza Apps Push Settings Applicazione [Impostazioni IOS - Apps Push Settings]", "");
        MainFrm.DTTObj.AddToken ("3574D130-74F5-4703-A184-40F20AABE687", "38D0FE01-8A4D-412E-8C55-F934708C97B5", 917504, "Data Scadenza Apps Push Settings", IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_DAT_SCAD_CERT, 0));
        if (IDL.Today().compareTo(IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_DAT_SCAD_CERT, 0), true)>=0)
        {
          MainFrm.DTTObj.EnterIf ("3574D130-74F5-4703-A184-40F20AABE687", "IF Today () >= Data Scadenza Apps Push Settings Applicazione [Impostazioni IOS - Apps Push Settings]", "");
          MainFrm.DTTObj.AddSubProc ("CE6BCA2B-B550-48DD-B8A9-F5E1045CA79A", "Data Scadenza.Set Visual Style", "");
          MainFrm.DTTObj.AddParameter ("CE6BCA2B-B550-48DD-B8A9-F5E1045CA79A", "786E2EB7-DAB5-4435-BDB0-AA8AAA458EBD", "Stile", new IDVariant(MyGlb.VIS_SFONDOROSSO));
          PAN_APPLICATTIVE.set_VisualStyle(Glb.OBJ_FIELD,PFL_APPLICATTIVE_DATASCADENZ1,new IDVariant(MyGlb.VIS_SFONDOROSSO).intValue()); 
          MainFrm.DTTObj.AddSubProc ("F85A772E-81B3-42A2-B407-A8C74A0D0DD0", "Data Scadenza.Tooltip", "");
          MainFrm.DTTObj.AddParameter ("F85A772E-81B3-42A2-B407-A8C74A0D0DD0", "D12E2C62-0547-4485-B115-5230E0965C54", "Testo", (new IDVariant("Il certificato è scaduto")));
          PAN_APPLICATTIVE.set_ToolTip(Glb.OBJ_FIELD,PFL_APPLICATTIVE_DATASCADENZ1,(new IDVariant("Il certificato è scaduto")).stringValue()); 
        }
        else if (0==0) { // **** begin else-if block
        MainFrm.DTTObj.AddIf ("6C7B31E8-2CD9-422C-975D-6AD982961A60", "ELSE IF Nuova Formula", "");
        MainFrm.DTTObj.AddToken ("6C7B31E8-2CD9-422C-975D-6AD982961A60", "6F01F654-7CE6-4DB6-B51E-17263B360FC5", 1376256, "d", D);
        if (IDL.Today().compareTo(D, true)>0)
        {
          MainFrm.DTTObj.EnterIf ("6C7B31E8-2CD9-422C-975D-6AD982961A60", "ELSE IF Nuova Formula", "");
          MainFrm.DTTObj.AddSubProc ("5C224795-FA94-4D88-995A-2AFDC0C1DA82", "Data Scadenza.Set Visual Style", "");
          MainFrm.DTTObj.AddParameter ("5C224795-FA94-4D88-995A-2AFDC0C1DA82", "4CCBBC23-2AD6-43A7-B060-F0090E74E84E", "Stile", new IDVariant(MyGlb.VIS_INSCADENZA));
          PAN_APPLICATTIVE.set_VisualStyle(Glb.OBJ_FIELD,PFL_APPLICATTIVE_DATASCADENZ1,new IDVariant(MyGlb.VIS_INSCADENZA).intValue()); 
          MainFrm.DTTObj.AddSubProc ("C95BEA53-25F9-4687-BB1F-3AA7A8CCE7BA", "Data Scadenza.Tooltip", "");
          MainFrm.DTTObj.AddParameter ("C95BEA53-25F9-4687-BB1F-3AA7A8CCE7BA", "BCC1F6F1-B7F4-4D96-94B9-B789B6348CF0", "Testo", (new IDVariant("Il certificato sta per scadere")));
          PAN_APPLICATTIVE.set_ToolTip(Glb.OBJ_FIELD,PFL_APPLICATTIVE_DATASCADENZ1,(new IDVariant("Il certificato sta per scadere")).stringValue()); 
        }
        MainFrm.DTTObj.EndIfBlk ("6C7B31E8-2CD9-422C-975D-6AD982961A60");
        } // **** end else-if block
        MainFrm.DTTObj.EndIfBlk ("3574D130-74F5-4703-A184-40F20AABE687");
      }
      MainFrm.DTTObj.EndIfBlk ("68CABDAE-5323-464B-8F55-944ECF3CC7FC");
      MainFrm.DTTObj.AddIf ("FAB0C722-4E44-452E-AB7F-CA1912CD773D", "IF Attiva Applicazione [Impostazioni IOS - Apps Push Settings] = No", "");
      MainFrm.DTTObj.AddToken ("FAB0C722-4E44-452E-AB7F-CA1912CD773D", "CBE149FF-A135-4679-AB8D-E2615A1FE65B", 917504, "Attiva", IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_FLG_ATTIVA, 0));
      MainFrm.DTTObj.AddToken ("FAB0C722-4E44-452E-AB7F-CA1912CD773D", "7A05C78E-30B6-4DF1-92F5-40116ECDE716", 589824, "No", (new IDVariant("N")));
      if (IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_FLG_ATTIVA, 0).equals((new IDVariant("N")), true))
      {
        MainFrm.DTTObj.EnterIf ("FAB0C722-4E44-452E-AB7F-CA1912CD773D", "IF Attiva Applicazione [Impostazioni IOS - Apps Push Settings] = No", "");
        MainFrm.DTTObj.AddSubProc ("11894E90-7E3E-4131-A1CD-74F80184F192", "Attiva.Set Visual Style", "");
        MainFrm.DTTObj.AddParameter ("11894E90-7E3E-4131-A1CD-74F80184F192", "E0838126-06E0-448B-BD99-029B2E6D36B4", "Stile", new IDVariant(MyGlb.VIS_SFONDOROSSO));
        PAN_APPLICATTIVE.set_VisualStyle(Glb.OBJ_FIELD,PFL_APPLICATTIVE_ATTIVA1,new IDVariant(MyGlb.VIS_SFONDOROSSO).intValue()); 
      }
      MainFrm.DTTObj.EndIfBlk ("FAB0C722-4E44-452E-AB7F-CA1912CD773D");
      MainFrm.DTTObj.AddIf ("AEB63615-41DF-4E30-915D-E4F960484CDD", "IF Ambiente Applicazione [Impostazioni IOS - Apps Push Settings] = Sviluppo", "");
      MainFrm.DTTObj.AddToken ("AEB63615-41DF-4E30-915D-E4F960484CDD", "2D253E93-D4F0-45C6-9A7B-C7A416E7D756", 917504, "Ambiente", IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_FLG_AMBIENTE, 0));
      MainFrm.DTTObj.AddToken ("AEB63615-41DF-4E30-915D-E4F960484CDD", "87F2A810-482A-461D-B353-7699B5419A9C", 589824, "Sviluppo", (new IDVariant("S")));
      if (IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_FLG_AMBIENTE, 0).equals((new IDVariant("S")), true))
      {
        MainFrm.DTTObj.EnterIf ("AEB63615-41DF-4E30-915D-E4F960484CDD", "IF Ambiente Applicazione [Impostazioni IOS - Apps Push Settings] = Sviluppo", "");
        MainFrm.DTTObj.AddSubProc ("85F65AB6-CB1C-4348-8E7F-0044BD47A44E", "Ambiente.Set Visual Style", "");
        MainFrm.DTTObj.AddParameter ("85F65AB6-CB1C-4348-8E7F-0044BD47A44E", "769A1318-6A11-4BF7-9976-EBB34EE9370B", "Stile", new IDVariant(MyGlb.VIS_SFONDOGIALLO));
        PAN_APPLICATTIVE.set_VisualStyle(Glb.OBJ_FIELD,PFL_APPLICATTIVE_AMBIENTE1,new IDVariant(MyGlb.VIS_SFONDOGIALLO).intValue()); 
        MainFrm.DTTObj.AddSubProc ("293E6B68-7178-470D-9CDB-9EC7C0E3B258", "Ambiente.Tooltip", "");
        MainFrm.DTTObj.AddParameter ("293E6B68-7178-470D-9CDB-9EC7C0E3B258", "C82EF777-069D-4FB9-A573-0568BBCE2954", "Testo", (new IDVariant("Ambiente di sviluppo")));
        PAN_APPLICATTIVE.set_ToolTip(Glb.OBJ_FIELD,PFL_APPLICATTIVE_AMBIENTE1,(new IDVariant("Ambiente di sviluppo")).stringValue()); 
      }
      MainFrm.DTTObj.EndIfBlk ("AEB63615-41DF-4E30-915D-E4F960484CDD");
      MainFrm.DTTObj.ExitProc("446D9D84-51A9-4100-8A1A-7C9E175B6129", "Applicazioni attive On Dynamic Properties", "", 1, "Impostazioni IOS");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("446D9D84-51A9-4100-8A1A-7C9E175B6129", "Applicazioni attive On Dynamic Properties", "", _e);
      MainFrm.ErrObj.ProcError ("ImpostazioniIOS", "ApplicazioniattiveOnDynamicProperties", _e);
      MainFrm.DTTObj.ExitProc("446D9D84-51A9-4100-8A1A-7C9E175B6129", "Applicazioni attive On Dynamic Properties", "", 1, "Impostazioni IOS");
    }
  }

  // **********************************************************************
  // Apri Invia Push
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int ApriInviaPush ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("F4DA3C91-3FDC-4836-8C1A-988D1457AA9A", "Apri Invia Push", "", 3, "Impostazioni IOS")) return 0;
      // 
      // Apri Invia Push Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddIf ("91DD4904-6FD9-479D-985D-6E690E006D01", "IF Attiva Applicazione [Impostazioni IOS - Apps Push Settings] = No", "");
      MainFrm.DTTObj.AddToken ("91DD4904-6FD9-479D-985D-6E690E006D01", "CBE149FF-A135-4679-AB8D-E2615A1FE65B", 917504, "Attiva", IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_FLG_ATTIVA, 0));
      MainFrm.DTTObj.AddToken ("91DD4904-6FD9-479D-985D-6E690E006D01", "B416B676-F424-49A2-AEBE-45B728184B62", 589824, "No", (new IDVariant("N")));
      if (IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_FLG_ATTIVA, 0).equals((new IDVariant("N")), true))
      {
        MainFrm.DTTObj.EnterIf ("91DD4904-6FD9-479D-985D-6E690E006D01", "IF Attiva Applicazione [Impostazioni IOS - Apps Push Settings] = No", "");
        MainFrm.DTTObj.AddSubProc ("7316441D-F6F8-4A15-B1FF-9573343FFD95", "Notificatore.Message Box", "");
        MainFrm.DTTObj.AddParameter ("7316441D-F6F8-4A15-B1FF-9573343FFD95", "FB33919F-2427-4DA1-9208-5AE0BC269016", "Messaggio", (new IDVariant("Applicazione disattivata")));
        MainFrm.set_AlertMessage((new IDVariant("Applicazione disattivata"))); 
        MainFrm.DTTObj.ExitProc ("F4DA3C91-3FDC-4836-8C1A-988D1457AA9A", "Apri Invia Push", "Spiega quale elaborazione viene eseguita da questa procedura", 3, "Impostazioni IOS");
        return 0;
      }
      MainFrm.DTTObj.EndIfBlk ("91DD4904-6FD9-479D-985D-6E690E006D01");
      MainFrm.DTTObj.AddSubProc ("564AB4C2-72A8-4BC6-AC4D-0A775E39CD54", "Invio Notifiche A Utenti IOS.Start Form", "");
      ((InvioNotificheAUtentiIOS)MainFrm.GetForm(MyGlb.FRM_INVNOTAUTEIO,1,true,this)).StartForm(IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_ID, 0), (new IDVariant("")));
      MainFrm.DTTObj.ExitProc("F4DA3C91-3FDC-4836-8C1A-988D1457AA9A", "Apri Invia Push", "", 3, "Impostazioni IOS");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("F4DA3C91-3FDC-4836-8C1A-988D1457AA9A", "Apri Invia Push", "", _e);
      MainFrm.ErrObj.ProcError ("ImpostazioniIOS", "ApriInviaPush", _e);
      MainFrm.DTTObj.ExitProc("F4DA3C91-3FDC-4836-8C1A-988D1457AA9A", "Apri Invia Push", "", 3, "Impostazioni IOS");
      return -1;
    }
  }

  // **********************************************************************
  // Check Feedback Service 1
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int CheckFeedbackService1 ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;
    IDCachedRowSet C2;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("4E705705-8AB7-4607-9698-702A4020F1FA", "Check Feedback Service 1", "", 3, "Impostazioni IOS")) return 0;
      // 
      // Check Feedback Service 1 Body
      // Corpo Procedura
      // 
      IDVariant v_IMSGELABORAT = null;
      MainFrm.DTTObj.AddAssign ("0B828AE3-BFDD-4242-A4DD-AEC761AE1531", "i Msg Elaborato := C0", "", v_IMSGELABORAT);
      v_IMSGELABORAT = (new IDVariant(0));
      MainFrm.DTTObj.AddAssignNewValue ("0B828AE3-BFDD-4242-A4DD-AEC761AE1531", "C35EB529-10C1-4684-A362-311B18E6BE73", v_IMSGELABORAT);
      IDVariant v_BSANDBOX1 = new IDVariant(0,IDVariant.INTEGER);
      IDVariant v_VCERTIFICATO = new IDVariant(0,IDVariant.STRING);
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // 
      MainFrm.DTTObj.MaxLoopCycles = (new IDVariant(5000)).intValue();
      int DTT_C2 = 0;
      MainFrm.DTTObj.AddForEach ("1966CDB7-76AC-400D-B415-8B94A0D6863A", "FOR EACH Applicazioni ROW", "");
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.ID as VID, ");
      SQL.Append("  CASE WHEN A.FLG_AMBIENTE='S' OR (A.FLG_AMBIENTE IS NULL AND 'S' IS NULL) THEN -1 ELSE 0 END as VSANDBOX, ");
      SQL.Append("  " + IDL.CSql(MainFrm.GLBPATHCERTI, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + " + '\\' + A.CERT_DEV as VCERTIFICATO ");
      SQL.Append("from ");
      SQL.Append("  APPS_PUSH_SETTING A ");
      SQL.Append("where (A.FLG_ATTIVA = 'S') ");
      SQL.Append("and   (A.ID = " + IDL.CSql(IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_ID, 0), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      MainFrm.DTTObj.AddToken ("1966CDB7-76AC-400D-B415-8B94A0D6863A", "1966CDB7-76AC-400D-B415-8B94A0D6863A", 0, "SQL", SQL.ToString());
      C2 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      C2.setColUnbound(2,true);
      C2.setColUnbound(3,true);
      if (!C2.EOF()) C2.MoveNext();
      MainFrm.DTTObj.EndQuery ("1966CDB7-76AC-400D-B415-8B94A0D6863A");
      MainFrm.DTTObj.AddDBDataSource (C2, SQL);
      while (!C2.EOF())
      {
        DTT_C2 = DTT_C2 + 1;
        if (!MainFrm.DTTObj.CheckLoop("1966CDB7-76AC-400D-B415-8B94A0D6863A", DTT_C2)) break;
        C2.MoveNext();
      }
      C2.Close();
      MainFrm.DTTObj.EndForEach ("1966CDB7-76AC-400D-B415-8B94A0D6863A", "FOR EACH Applicazioni ROW", "", DTT_C2);
      MainFrm.DTTObj.ExitProc("4E705705-8AB7-4607-9698-702A4020F1FA", "Check Feedback Service 1", "", 3, "Impostazioni IOS");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("4E705705-8AB7-4607-9698-702A4020F1FA", "Check Feedback Service 1", "", _e);
      MainFrm.ErrObj.ProcError ("ImpostazioniIOS", "CheckFeedbackService1", _e);
      MainFrm.DTTObj.ExitProc("4E705705-8AB7-4607-9698-702A4020F1FA", "Check Feedback Service 1", "", 3, "Impostazioni IOS");
      return -1;
    }
  }

  // **********************************************************************
  // Apri Invia Push Interni
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int ApriInviaPushInterni ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("F11642F9-17E0-4734-8984-A0F4AF93F683", "Apri Invia Push Interni", "", 3, "Impostazioni IOS")) return 0;
      // 
      // Apri Invia Push Interni Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddIf ("9FB6108B-532D-41F4-A652-FF048F21523D", "IF Attiva Applicazione [Impostazioni IOS - Apps Push Settings] = No", "");
      MainFrm.DTTObj.AddToken ("9FB6108B-532D-41F4-A652-FF048F21523D", "CBE149FF-A135-4679-AB8D-E2615A1FE65B", 917504, "Attiva", IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_FLG_ATTIVA, 0));
      MainFrm.DTTObj.AddToken ("9FB6108B-532D-41F4-A652-FF048F21523D", "B416B676-F424-49A2-AEBE-45B728184B62", 589824, "No", (new IDVariant("N")));
      if (IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_FLG_ATTIVA, 0).equals((new IDVariant("N")), true))
      {
        MainFrm.DTTObj.EnterIf ("9FB6108B-532D-41F4-A652-FF048F21523D", "IF Attiva Applicazione [Impostazioni IOS - Apps Push Settings] = No", "");
        MainFrm.DTTObj.AddSubProc ("B2AFA9B8-AEAB-46D0-ABE9-F058A5305381", "Notificatore.Message Box", "");
        MainFrm.DTTObj.AddParameter ("B2AFA9B8-AEAB-46D0-ABE9-F058A5305381", "7F66B5E0-77EA-44E6-973B-D31120EC23D1", "Messaggio", (new IDVariant("Applicazione disattivata")));
        MainFrm.set_AlertMessage((new IDVariant("Applicazione disattivata"))); 
        MainFrm.DTTObj.ExitProc ("F11642F9-17E0-4734-8984-A0F4AF93F683", "Apri Invia Push Interni", "Spiega quale elaborazione viene eseguita da questa procedura", 3, "Impostazioni IOS");
        return 0;
      }
      MainFrm.DTTObj.EndIfBlk ("9FB6108B-532D-41F4-A652-FF048F21523D");
      MainFrm.DTTObj.AddSubProc ("C0657D55-4D39-415C-ACC8-0551C88D5E01", "Invio Notifiche A Dispoitivi Noti IOS.Start Form", "");
      ((InvioNotificheADispoitiviNotiIOS)MainFrm.GetForm(MyGlb.FRM_INVNOADINOIO,1,true,this)).StartForm(IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_ID, 0));
      MainFrm.DTTObj.ExitProc("F11642F9-17E0-4734-8984-A0F4AF93F683", "Apri Invia Push Interni", "", 3, "Impostazioni IOS");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("F11642F9-17E0-4734-8984-A0F4AF93F683", "Apri Invia Push Interni", "", _e);
      MainFrm.ErrObj.ProcError ("ImpostazioniIOS", "ApriInviaPushInterni", _e);
      MainFrm.DTTObj.ExitProc("F11642F9-17E0-4734-8984-A0F4AF93F683", "Apri Invia Push Interni", "", 3, "Impostazioni IOS");
      return -1;
    }
  }

  // **********************************************************************
  // Check Certs
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int CheckCerts ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;
    IDCachedRowSet C2;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("F18FBAB0-9F1B-45CD-8C8B-38D639EA4F4B", "Check Certs", "", 3, "Impostazioni IOS")) return 0;
      // 
      // Check Certs Body
      // Corpo Procedura
      // 
      int DTT_C2 = 0;
      MainFrm.DTTObj.AddForEach ("2EDD0335-B508-4ACF-919C-DB6502747561", "FOR EACH Apps Push Settings ROW", "");
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.ID as VID, ");
      SQL.Append("  A.CERT_DEV as VCERTIFICATO, ");
      SQL.Append("  A.DES_ERR as VERRORI, ");
      SQL.Append("  A.FLG_ATTIVA as VATTIVA, ");
      SQL.Append("  A.DAT_SCAD_CERT as VDATASCADENZ ");
      SQL.Append("from ");
      SQL.Append("  APPS_PUSH_SETTING A ");
      SQL.Append("where (NOT ((A.CERT_DEV IS NULL))) ");
      SQL.Append("and   (A.TYPE_OS = '1') ");
      SQL.Append("and   (A.FLG_ATTIVA = 'S') ");
      MainFrm.DTTObj.AddToken ("2EDD0335-B508-4ACF-919C-DB6502747561", "2EDD0335-B508-4ACF-919C-DB6502747561", 0, "SQL", SQL.ToString());
      C2 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!C2.EOF()) C2.MoveNext();
      MainFrm.DTTObj.EndQuery ("2EDD0335-B508-4ACF-919C-DB6502747561");
      MainFrm.DTTObj.AddDBDataSource (C2, SQL);
      while (!C2.EOF())
      {
        DTT_C2 = DTT_C2 + 1;
        if (!MainFrm.DTTObj.CheckLoop("2EDD0335-B508-4ACF-919C-DB6502747561", DTT_C2)) break;
        MainFrm.DTTObj.AddIf ("E4AAA27C-0C8A-42A2-81A9-C9807FFE9C30", "IF C! (File Exist (Glb Path Certificati Notificatore + \"\\\" + v Certificato Apps Push Settings))", "");
        MainFrm.DTTObj.AddToken ("E4AAA27C-0C8A-42A2-81A9-C9807FFE9C30", "86F8C8B1-246B-4C53-BF5A-347D22AD9996", 1376256, "Glb Path Certificati", MainFrm.GLBPATHCERTI);
        MainFrm.DTTObj.AddToken ("E4AAA27C-0C8A-42A2-81A9-C9807FFE9C30", "36ABB8C4-E63A-4A97-B861-5705F2AE3234", 1376256, "v Certificato", C2.Get("VCERTIFICATO"));
        if (!(MainFrm.FileExist(IDL.Add(IDL.Add(MainFrm.GLBPATHCERTI, (new IDVariant("\\"))), C2.Get("VCERTIFICATO")))))
        {
          MainFrm.DTTObj.EnterIf ("E4AAA27C-0C8A-42A2-81A9-C9807FFE9C30", "IF C! (File Exist (Glb Path Certificati Notificatore + \"\\\" + v Certificato Apps Push Settings))", "");
          MainFrm.DTTObj.AddAssign ("1E307AB6-F090-44F0-A8FB-7048BED4D4FB", "v Attiva Apps Push Settings := No", "", C2.Get("VATTIVA"));
          MainFrm.DTTObj.AddToken ("1E307AB6-F090-44F0-A8FB-7048BED4D4FB", "B416B676-F424-49A2-AEBE-45B728184B62", 589824, "No", (new IDVariant("N")));
          C2.Set("VATTIVA", (new IDVariant("N")));
          MainFrm.DTTObj.AddAssignNewValue ("1E307AB6-F090-44F0-A8FB-7048BED4D4FB", "2C3816F9-A0F9-4347-B494-FE4C40EE8C6A", C2.Get("VATTIVA"));
          MainFrm.DTTObj.AddSubProc ("4372E2CB-ADC9-4E51-BA7E-DB433F7ED50F", "Notificatore.Send Mail", "");
          MainFrm.SendMail((new IDVariant("File certificato non trovato")), IDL.Add(IDL.Add((new IDVariant("Il file ")), C2.Get("VCERTIFICATO")), (new IDVariant(" non è stato trovato"))));
        }
        else if (0==0)
        {
          MainFrm.DTTObj.EnterElse ("A16D580C-1180-4154-B432-0EAE7DCEC816", "ELSE", "", "E4AAA27C-0C8A-42A2-81A9-C9807FFE9C30");
          System.Security.Cryptography.X509Certificates.X509Certificate2 v_XC = null;
          MainFrm.DTTObj.AddAssign ("28235BB8-90D4-47A7-ABC6-41F2B38B3E8A", "xc := xc.New Instance (Glb Path Certificati Notificatore + \"\\\" + v Certificato Apps Push Settings)", "", v_XC);
          MainFrm.DTTObj.AddToken ("28235BB8-90D4-47A7-ABC6-41F2B38B3E8A", "86F8C8B1-246B-4C53-BF5A-347D22AD9996", 1376256, "Glb Path Certificati", MainFrm.GLBPATHCERTI);
          MainFrm.DTTObj.AddToken ("28235BB8-90D4-47A7-ABC6-41F2B38B3E8A", "36ABB8C4-E63A-4A97-B861-5705F2AE3234", 1376256, "v Certificato", C2.Get("VCERTIFICATO"));
          v_XC = new System.Security.Cryptography.X509Certificates.X509Certificate2(System.IO.File.ReadAllBytes(IDL.Add(IDL.Add(MainFrm.GLBPATHCERTI, (new IDVariant("\\"))), C2.Get("VCERTIFICATO")).stringValue()));
          MainFrm.DTTObj.AddAssignNewValue ("28235BB8-90D4-47A7-ABC6-41F2B38B3E8A", "642467E5-2FD9-4298-9C77-A4B74269112B", v_XC);
          IDVariant D = null;
          MainFrm.DTTObj.AddAssign ("BFBDDAD0-E8FD-47AE-8414-B69BF93889F2", "d := xc.Get Expiration Date String ()", "", D);
          D = (new IDVariant(Convert.ToDateTime(v_XC.GetExpirationDateString())));
          MainFrm.DTTObj.AddAssignNewValue ("BFBDDAD0-E8FD-47AE-8414-B69BF93889F2", "237F4F57-8911-487E-A37D-B524E23C8105", D);
          MainFrm.DTTObj.AddIf ("215C45B5-3138-4975-AD3C-CC3D9A5D7464", "IF d < Now ()", "");
          MainFrm.DTTObj.AddToken ("215C45B5-3138-4975-AD3C-CC3D9A5D7464", "237F4F57-8911-487E-A37D-B524E23C8105", 1376256, "d", D);
          if (D.compareTo(IDL.Now(), true)<0)
          {
            MainFrm.DTTObj.EnterIf ("215C45B5-3138-4975-AD3C-CC3D9A5D7464", "IF d < Now ()", "");
            MainFrm.DTTObj.AddAssign ("36549283-9C54-47A2-A7B8-F911B2AF5247", "v Attiva Apps Push Settings := No", "", C2.Get("VATTIVA"));
            MainFrm.DTTObj.AddToken ("36549283-9C54-47A2-A7B8-F911B2AF5247", "B416B676-F424-49A2-AEBE-45B728184B62", 589824, "No", (new IDVariant("N")));
            C2.Set("VATTIVA", (new IDVariant("N")));
            MainFrm.DTTObj.AddAssignNewValue ("36549283-9C54-47A2-A7B8-F911B2AF5247", "2C3816F9-A0F9-4347-B494-FE4C40EE8C6A", C2.Get("VATTIVA"));
            MainFrm.DTTObj.AddSubProc ("0F1AA70B-AFC9-4A40-B349-C0F338D8986D", "Notificatore.Send Mail", "");
            MainFrm.SendMail((new IDVariant("File certificato scaduto")), IDL.Add(IDL.Add((new IDVariant("Il file ")), C2.Get("VCERTIFICATO")), (new IDVariant(" è scaduto"))));
          }
          MainFrm.DTTObj.EndIfBlk ("215C45B5-3138-4975-AD3C-CC3D9A5D7464");
          MainFrm.DTTObj.AddAssign ("E167F5C4-B20B-48B8-8273-EABB973AFBE1", "v Data Scadenza Apps Push Settings := d", "", C2.Get("VDATASCADENZ"));
          MainFrm.DTTObj.AddToken ("E167F5C4-B20B-48B8-8273-EABB973AFBE1", "237F4F57-8911-487E-A37D-B524E23C8105", 1376256, "d", new IDVariant(D));
          C2.Set("VDATASCADENZ", new IDVariant(D));
          MainFrm.DTTObj.AddAssignNewValue ("E167F5C4-B20B-48B8-8273-EABB973AFBE1", "B6CA6BCB-1A7B-4BE5-B1AC-DFE39A71E9AC", C2.Get("VDATASCADENZ"));
          MainFrm.DTTObj.AddIf ("7994A73C-806B-4327-B4D4-0DAF618D5FD7", "IF Is Null (v Data Scadenza Apps Push Settings)", "");
          MainFrm.DTTObj.AddToken ("7994A73C-806B-4327-B4D4-0DAF618D5FD7", "B6CA6BCB-1A7B-4BE5-B1AC-DFE39A71E9AC", 1376256, "v Data Scadenza", C2.Get("VDATASCADENZ"));
          if (IDL.IsNull(C2.Get("VDATASCADENZ")))
          {
            MainFrm.DTTObj.EnterIf ("7994A73C-806B-4327-B4D4-0DAF618D5FD7", "IF Is Null (v Data Scadenza Apps Push Settings)", "");
            MainFrm.DTTObj.AddAssign ("40AFD416-045A-45C8-BDF3-CCD2E9E677DF", "v Attiva Apps Push Settings := No", "", C2.Get("VATTIVA"));
            MainFrm.DTTObj.AddToken ("40AFD416-045A-45C8-BDF3-CCD2E9E677DF", "B416B676-F424-49A2-AEBE-45B728184B62", 589824, "No", (new IDVariant("N")));
            C2.Set("VATTIVA", (new IDVariant("N")));
            MainFrm.DTTObj.AddAssignNewValue ("40AFD416-045A-45C8-BDF3-CCD2E9E677DF", "2C3816F9-A0F9-4347-B494-FE4C40EE8C6A", C2.Get("VATTIVA"));
            MainFrm.DTTObj.AddSubProc ("C700B49C-BBB5-42F8-9763-9E78F5D3BA4A", "Notificatore.Send Mail", "");
            MainFrm.SendMail((new IDVariant("data certificato null")), IDL.Add(IDL.Add((new IDVariant("Il file ")), C2.Get("VCERTIFICATO")), (new IDVariant(" ha una data certificato null"))));
          }
          MainFrm.DTTObj.EndIfBlk ("7994A73C-806B-4327-B4D4-0DAF618D5FD7");
        }
        MainFrm.DTTObj.EndIfBlk ("E4AAA27C-0C8A-42A2-81A9-C9807FFE9C30");
        C2.updateRow();
        C2.MoveNext();
      }
      MainFrm.NotificatoreDBObject.DBO().UpdateRS("APPS_PUSH_SETTING", C2);
      C2.Close();
      MainFrm.DTTObj.EndForEach ("2EDD0335-B508-4ACF-919C-DB6502747561", "FOR EACH Apps Push Settings ROW", "", DTT_C2);
      MainFrm.DTTObj.AddSubProc ("988236CE-BE10-4C0A-9050-08DA3E2188AE", "Applicazioni attive.Refresh Query", "");
      PAN_APPLICATTIVE.PanelCommand(Glb.PCM_REQUERY);
      MainFrm.DTTObj.ExitProc("F18FBAB0-9F1B-45CD-8C8B-38D639EA4F4B", "Check Certs", "", 3, "Impostazioni IOS");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("F18FBAB0-9F1B-45CD-8C8B-38D639EA4F4B", "Check Certs", "", _e);
      MainFrm.ErrObj.ProcError ("ImpostazioniIOS", "CheckCerts", _e);
      MainFrm.DTTObj.ExitProc("F18FBAB0-9F1B-45CD-8C8B-38D639EA4F4B", "Check Certs", "", 3, "Impostazioni IOS");
      return -1;
    }
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
  private void TAB_NUOVTABBVIEW_Click(IDVariant OldPage, IDVariant Cancel)
  {
  }

  private void PAN_APPLICATTIVE_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_APPLICATTIVE_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_APPLICATTIVE_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_FLG_ATTIVA, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_FLG_ATTIVA, 0, (new IDVariant("S")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_TYPE_OS, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_APPLICAZION1, IMDBDef1.PQSL_APPLICAZION1_TYPE_OS, 0, (new IDVariant("1")));
      }
    } catch ( Exception e) { }
  }

  private void PAN_APPLICDISATT_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_APPLICDISATT_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_APPLICDISATT_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_APPLICAZION5, IMDBDef1.PQSL_APPLICAZION5_FLG_ATTIVA, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_APPLICAZION5, IMDBDef1.PQSL_APPLICAZION5_FLG_ATTIVA, 0, (new IDVariant("S")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_APPLICAZION5, IMDBDef1.PQSL_APPLICAZION5_TYPE_OS, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_APPLICAZION5, IMDBDef1.PQSL_APPLICAZION5_TYPE_OS, 0, (new IDVariant("1")));
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_APPLICATTIVE_Init()
  {

    PAN_APPLICATTIVE.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_APPLICATTIVE.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_APPLICATTIVE.SetSize(MyGlb.OBJ_FIELD, 9);
    PAN_APPLICATTIVE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, "FFBF6662-D5BA-435E-AC14-942D1680131D");
    PAN_APPLICATTIVE.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, "ID");
    PAN_APPLICATTIVE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, "Identificativo univoco");
    PAN_APPLICATTIVE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_APPLICATTIVE.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_APPLICATTIVE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, "D9B69461-56A5-4AFF-9ADF-848745FF82F5");
    PAN_APPLICATTIVE.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, "Applicazione");
    PAN_APPLICATTIVE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, "Identificativo univoco");
    PAN_APPLICATTIVE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, MyGlb.VIS_FOREIKEYFIEL);
    PAN_APPLICATTIVE.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP, -1);
    PAN_APPLICATTIVE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, "2740C1DE-CFC9-4DEC-9D06-F0FD0F8690A3");
    PAN_APPLICATTIVE.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, "Certificato Push");
    PAN_APPLICATTIVE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, "");
    PAN_APPLICATTIVE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICATTIVE.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APPLICATTIVE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, "2CBC66DA-6EDE-4511-916F-9AC070C6B1CF");
    PAN_APPLICATTIVE.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, "Data Scadenza");
    PAN_APPLICATTIVE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, "Data di scadenza del certificato");
    PAN_APPLICATTIVE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICATTIVE.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APPLICATTIVE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, "41E1E4CA-8EAA-48B4-8E3D-34188D835818");
    PAN_APPLICATTIVE.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, "Nota");
    PAN_APPLICATTIVE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, "Nota");
    PAN_APPLICATTIVE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICATTIVE.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISDESCR, -1);
    PAN_APPLICATTIVE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, "F1FFEABF-AF98-4BA1-BFF0-CCE3ADA0ECC8");
    PAN_APPLICATTIVE.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, "Ambiente");
    PAN_APPLICATTIVE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, "");
    PAN_APPLICATTIVE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICATTIVE.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_APPLICATTIVE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, "EEDF9DCE-C1CB-4145-BC23-D8CCBB2273A6");
    PAN_APPLICATTIVE.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, "Attiva");
    PAN_APPLICATTIVE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, "");
    PAN_APPLICATTIVE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICATTIVE.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APPLICATTIVE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, "F777D57A-9206-40B7-9629-C1C2592B8693");
    PAN_APPLICATTIVE.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, "Type OS");
    PAN_APPLICATTIVE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, "");
    PAN_APPLICATTIVE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICATTIVE.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, 0 | MyGlb.FLD_ISOPT, -1);
    PAN_APPLICATTIVE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, "D4C4B941-8C25-44BA-83E4-A1A46A107FDA");
    PAN_APPLICATTIVE.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, "Errori");
    PAN_APPLICATTIVE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, "Errori valorizzati dal sistema");
    PAN_APPLICATTIVE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICATTIVE.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_APPLICATTIVE_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, MyGlb.PANEL_LIST, 0, 44, 48, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, MyGlb.PANEL_LIST, 20);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, MyGlb.PANEL_LIST, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, MyGlb.PANEL_LIST, "ID");
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, MyGlb.PANEL_FORM, 4, 4, 176, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, MyGlb.PANEL_FORM, 128);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, MyGlb.PANEL_FORM, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ID1, MyGlb.PANEL_FORM, "ID");
    PAN_APPLICATTIVE.SetFieldPage(PFL_APPLICATTIVE_ID1, -1, -1);
    PAN_APPLICATTIVE.SetFieldPanel(PFL_APPLICATTIVE_ID1, PPQRY_APPLICAZION1, "A.ID", "ID", 1, 9, 0, -1709);
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, MyGlb.PANEL_LIST, 48, 44, 148, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, MyGlb.PANEL_LIST, 48);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, MyGlb.PANEL_LIST, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, MyGlb.PANEL_LIST, "Applicazione");
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, MyGlb.PANEL_FORM, 4, 28, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, MyGlb.PANEL_FORM, 128);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, MyGlb.PANEL_FORM, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_APPLICAZION1, MyGlb.PANEL_FORM, "Applicazione");
    PAN_APPLICATTIVE.SetFieldPage(PFL_APPLICATTIVE_APPLICAZION1, -1, -1);
    PAN_APPLICATTIVE.SetFieldPanel(PFL_APPLICATTIVE_APPLICAZION1, PPQRY_APPLICAZION1, "A.ID_APP", "ID_APP", 1, 9, 0, -1709);
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, MyGlb.PANEL_LIST, 196, 44, 152, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, MyGlb.PANEL_LIST, 124);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, MyGlb.PANEL_LIST, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, MyGlb.PANEL_LIST, "Certificato Push");
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, MyGlb.PANEL_FORM, 4, 52, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, MyGlb.PANEL_FORM, 128);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, MyGlb.PANEL_FORM, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_CERTIFICPUS1, MyGlb.PANEL_FORM, "Certificato Push");
    PAN_APPLICATTIVE.SetFieldPage(PFL_APPLICATTIVE_CERTIFICPUS1, -1, -1);
    PAN_APPLICATTIVE.SetFieldPanel(PFL_APPLICATTIVE_CERTIFICPUS1, PPQRY_APPLICAZION1, "A.CERT_DEV", "CERT_DEV", 5, 300, 0, -1709);
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, MyGlb.PANEL_LIST, 348, 44, 144, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, MyGlb.PANEL_LIST, 80);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, MyGlb.PANEL_LIST, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, MyGlb.PANEL_LIST, "Data Scadenza");
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, MyGlb.PANEL_FORM, 4, 124, 248, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, MyGlb.PANEL_FORM, 128);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, MyGlb.PANEL_FORM, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_DATASCADENZ1, MyGlb.PANEL_FORM, "Data Scadenza");
    PAN_APPLICATTIVE.SetFieldPage(PFL_APPLICATTIVE_DATASCADENZ1, -1, -1);
    PAN_APPLICATTIVE.SetFieldPanel(PFL_APPLICATTIVE_DATASCADENZ1, PPQRY_APPLICAZION1, "A.DAT_SCAD_CERT", "DAT_SCAD_CERT", 8, 10, 0, -1709);
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, MyGlb.PANEL_LIST, 492, 44, 124, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, MyGlb.PANEL_LIST, 32);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, MyGlb.PANEL_LIST, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, MyGlb.PANEL_LIST, "Nota");
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, MyGlb.PANEL_FORM, 4, 76, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, MyGlb.PANEL_FORM, 128);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, MyGlb.PANEL_FORM, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_NOTA1, MyGlb.PANEL_FORM, "Nota");
    PAN_APPLICATTIVE.SetFieldPage(PFL_APPLICATTIVE_NOTA1, -1, -1);
    PAN_APPLICATTIVE.SetFieldPanel(PFL_APPLICATTIVE_NOTA1, PPQRY_APPLICAZION1, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -1709);
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, MyGlb.PANEL_LIST, 616, 44, 88, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, MyGlb.PANEL_LIST, 52);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, MyGlb.PANEL_LIST, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, MyGlb.PANEL_LIST, "Ambiente");
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, MyGlb.PANEL_FORM, 4, 100, 248, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, MyGlb.PANEL_FORM, 128);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, MyGlb.PANEL_FORM, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_AMBIENTE1, MyGlb.PANEL_FORM, "Ambiente");
    PAN_APPLICATTIVE.SetFieldPage(PFL_APPLICATTIVE_AMBIENTE1, -1, -1);
    PAN_APPLICATTIVE.SetFieldPanel(PFL_APPLICATTIVE_AMBIENTE1, PPQRY_APPLICAZION1, "A.FLG_AMBIENTE", "FLG_AMBIENTE", 5, 1, 0, -1709);
    PAN_APPLICATTIVE.SetValueListItem(PFL_APPLICATTIVE_AMBIENTE1, (new IDVariant("S")), "Sviluppo", "", "", -1);
    PAN_APPLICATTIVE.SetValueListItem(PFL_APPLICATTIVE_AMBIENTE1, (new IDVariant("P")), "Produzione", "", "", -1);
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, MyGlb.PANEL_LIST, 704, 44, 48, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, MyGlb.PANEL_LIST, 40);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, MyGlb.PANEL_LIST, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, MyGlb.PANEL_LIST, "Attiva");
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, MyGlb.PANEL_FORM, 356, 4, 176, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, MyGlb.PANEL_FORM, 128);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, MyGlb.PANEL_FORM, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ATTIVA1, MyGlb.PANEL_FORM, "Attiva");
    PAN_APPLICATTIVE.SetFieldPage(PFL_APPLICATTIVE_ATTIVA1, -1, -1);
    PAN_APPLICATTIVE.SetFieldPanel(PFL_APPLICATTIVE_ATTIVA1, PPQRY_APPLICAZION1, "A.FLG_ATTIVA", "FLG_ATTIVA", 5, 1, 0, -1709);
    PAN_APPLICATTIVE.SetValueListItem(PFL_APPLICATTIVE_ATTIVA1, (new IDVariant("S")), "Si", "", "", -1);
    PAN_APPLICATTIVE.SetValueListItem(PFL_APPLICATTIVE_ATTIVA1, (new IDVariant("N")), "No", "", "", -1);
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, MyGlb.PANEL_LIST, 0, 44, 52, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, MyGlb.PANEL_LIST, 52);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, MyGlb.PANEL_LIST, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, MyGlb.PANEL_LIST, "Type OS");
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, MyGlb.PANEL_FORM, 4, 172, 96, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, MyGlb.PANEL_FORM, 52);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, MyGlb.PANEL_FORM, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_TYPEOS1, MyGlb.PANEL_FORM, "Typ. O.");
    PAN_APPLICATTIVE.SetFieldPage(PFL_APPLICATTIVE_TYPEOS1, -1, -1);
    PAN_APPLICATTIVE.SetFieldPanel(PFL_APPLICATTIVE_TYPEOS1, PPQRY_APPLICAZION1, "A.TYPE_OS", "TYPE_OS", 5, 1, 0, -1709);
    PAN_APPLICATTIVE.SetValueListItem(PFL_APPLICATTIVE_TYPEOS1, (new IDVariant("1")), "iOS", "", "", -1);
    PAN_APPLICATTIVE.SetValueListItem(PFL_APPLICATTIVE_TYPEOS1, (new IDVariant("2")), "Android", "", "", -1);
    PAN_APPLICATTIVE.SetValueListItem(PFL_APPLICATTIVE_TYPEOS1, (new IDVariant("3")), "Windows Phone", "", "", -1);
    PAN_APPLICATTIVE.SetValueListItem(PFL_APPLICATTIVE_TYPEOS1, (new IDVariant("4")), "Blackberry", "", "", -1);
    PAN_APPLICATTIVE.SetValueListItem(PFL_APPLICATTIVE_TYPEOS1, (new IDVariant("5")), "Windows Store", "", "", -1);
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, MyGlb.PANEL_LIST, 752, 44, 200, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, MyGlb.PANEL_LIST, 36);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, MyGlb.PANEL_LIST, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, MyGlb.PANEL_LIST, "Errori");
    PAN_APPLICATTIVE.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, MyGlb.PANEL_FORM, 4, 148, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICATTIVE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, MyGlb.PANEL_FORM, 128);
    PAN_APPLICATTIVE.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, MyGlb.PANEL_FORM, 1);
    PAN_APPLICATTIVE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICATTIVE_ERRORI1, MyGlb.PANEL_FORM, "Errori");
    PAN_APPLICATTIVE.SetFieldPage(PFL_APPLICATTIVE_ERRORI1, -1, -1);
    PAN_APPLICATTIVE.SetFieldPanel(PFL_APPLICATTIVE_ERRORI1, PPQRY_APPLICAZION1, "A.DES_ERR", "DES_ERR", 5, 2000, 0, -1709);
  }

  private void PAN_APPLICATTIVE_InitQueries()
  {
    StringBuilder SQL;

    PAN_APPLICATTIVE.SetSize(MyGlb.OBJ_QUERY, 2);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPS, ");
    SQL.Append("  A.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS A ");
    SQL.Append("where (A.ID = ~~ID_APP~~) ");
    PAN_APPLICATTIVE.SetQuery(PPQRY_APPS1, 0, SQL, PFL_APPLICATTIVE_APPLICAZION1, "72794CF6-2F4B-4537-8424-5F2EBD171464");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPS, ");
    SQL.Append("  A.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS A ");
    PAN_APPLICATTIVE.SetQuery(PPQRY_APPS1, 1, SQL, PFL_APPLICATTIVE_APPLICAZION1, "");
    PAN_APPLICATTIVE.SetQueryDB(PPQRY_APPS1, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_APPLICATTIVE.SetIMDB(IMDB, "PQRY_APPLICAZION1", true);
    PAN_APPLICATTIVE.set_SetString(MyGlb.MASTER_ROWNAME, "Applicazione");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.CERT_DEV as CERT_DEV, ");
    SQL.Append("  A.DES_NOTA as DES_NOTA, ");
    SQL.Append("  A.FLG_ATTIVA as FLG_ATTIVA, ");
    SQL.Append("  A.FLG_AMBIENTE as FLG_AMBIENTE, ");
    SQL.Append("  A.TYPE_OS as TYPE_OS, ");
    SQL.Append("  A.ID_APP as ID_APP, ");
    SQL.Append("  A.DAT_SCAD_CERT as DAT_SCAD_CERT, ");
    SQL.Append("  A.DES_ERR as DES_ERR ");
    PAN_APPLICATTIVE.SetQuery(PPQRY_APPLICAZION1, 0, SQL, -1, "61190707-90B2-4FA2-B936-9116BB5E4DEE");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A ");
    PAN_APPLICATTIVE.SetQuery(PPQRY_APPLICAZION1, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.TYPE_OS = '1') ");
    SQL.Append("and   (A.FLG_ATTIVA = 'S') ");
    PAN_APPLICATTIVE.SetQuery(PPQRY_APPLICAZION1, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPLICATTIVE.SetQuery(PPQRY_APPLICAZION1, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPLICATTIVE.SetQuery(PPQRY_APPLICAZION1, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPLICATTIVE.SetQuery(PPQRY_APPLICAZION1, 5, SQL, -1, "");
    PAN_APPLICATTIVE.SetQueryDB(PPQRY_APPLICAZION1, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_APPLICATTIVE.SetMasterTable(0, "APPS_PUSH_SETTING");
    SQL = new StringBuilder("");
    PAN_APPLICATTIVE.SetQuery(0, -1, SQL, PFL_APPLICATTIVE_ID1, "");
  }

  private void PAN_APPLICDISATT_Init()
  {

    PAN_APPLICDISATT.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_APPLICDISATT.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_APPLICDISATT.SetSize(MyGlb.OBJ_FIELD, 9);
    PAN_APPLICDISATT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, "324F1ED5-ACA7-490E-ACFC-61583C73881B");
    PAN_APPLICDISATT.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, "ID");
    PAN_APPLICDISATT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, "Identificativo univoco");
    PAN_APPLICDISATT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_APPLICDISATT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_APPLICDISATT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, "91D2A8BB-DB90-4FD7-8EDB-34B81E1EAC3C");
    PAN_APPLICDISATT.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, "Applicazione");
    PAN_APPLICDISATT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, "Identificativo univoco");
    PAN_APPLICDISATT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, MyGlb.VIS_FOREIKEYFIEL);
    PAN_APPLICDISATT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP, -1);
    PAN_APPLICDISATT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, "B3724FFC-354B-40B1-BA84-BF6F22C1C3AD");
    PAN_APPLICDISATT.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, "Certificato Push");
    PAN_APPLICDISATT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, "");
    PAN_APPLICDISATT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICDISATT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APPLICDISATT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, "DA6F3BA1-D1AB-4696-A07B-1CE84ECA13D8");
    PAN_APPLICDISATT.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, "Data Scadenza");
    PAN_APPLICDISATT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, "Data di scadenza del certificato");
    PAN_APPLICDISATT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICDISATT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APPLICDISATT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, "7B7BB1BF-57B9-4FF6-8E0A-CF067E2C0764");
    PAN_APPLICDISATT.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, "Nota");
    PAN_APPLICDISATT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, "Nota");
    PAN_APPLICDISATT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICDISATT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISDESCR, -1);
    PAN_APPLICDISATT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, "86C32A10-38A0-439B-8A3F-9FC80B19FAEF");
    PAN_APPLICDISATT.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, "Ambiente");
    PAN_APPLICDISATT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, "");
    PAN_APPLICDISATT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICDISATT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_APPLICDISATT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, "C06C6749-C556-45FB-B447-9659D0DA559B");
    PAN_APPLICDISATT.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, "Attiva");
    PAN_APPLICDISATT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, "");
    PAN_APPLICDISATT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICDISATT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APPLICDISATT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, "36E1B4BC-2CEA-4C28-9C89-8D1DD999FF9C");
    PAN_APPLICDISATT.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, "Type OS");
    PAN_APPLICDISATT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, "");
    PAN_APPLICDISATT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICDISATT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, 0 | MyGlb.FLD_ISOPT, -1);
    PAN_APPLICDISATT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, "2FA47218-6D4B-48CF-BF11-E8BFF485231A");
    PAN_APPLICDISATT.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, "Errori");
    PAN_APPLICDISATT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, "Errori valorizzati dal sistema");
    PAN_APPLICDISATT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICDISATT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_APPLICDISATT_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, MyGlb.PANEL_LIST, 0, 44, 48, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, MyGlb.PANEL_LIST, 20);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, MyGlb.PANEL_LIST, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, MyGlb.PANEL_LIST, "ID");
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, MyGlb.PANEL_FORM, 4, 4, 176, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, MyGlb.PANEL_FORM, 128);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, MyGlb.PANEL_FORM, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ID, MyGlb.PANEL_FORM, "ID");
    PAN_APPLICDISATT.SetFieldPage(PFL_APPLICDISATT_ID, -1, -1);
    PAN_APPLICDISATT.SetFieldPanel(PFL_APPLICDISATT_ID, PPQRY_APPLICAZION5, "A.ID", "ID", 1, 9, 0, -1709);
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, MyGlb.PANEL_LIST, 48, 44, 148, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, MyGlb.PANEL_LIST, 48);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, MyGlb.PANEL_FORM, 4, 28, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, MyGlb.PANEL_FORM, 128);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, MyGlb.PANEL_FORM, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_APPLICDISATT.SetFieldPage(PFL_APPLICDISATT_APPLICAZIONE, -1, -1);
    PAN_APPLICDISATT.SetFieldPanel(PFL_APPLICDISATT_APPLICAZIONE, PPQRY_APPLICAZION5, "A.ID_APP", "ID_APP", 1, 9, 0, -1709);
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, MyGlb.PANEL_LIST, 196, 44, 152, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, MyGlb.PANEL_LIST, 124);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, MyGlb.PANEL_LIST, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, MyGlb.PANEL_LIST, "Certificato Push");
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, MyGlb.PANEL_FORM, 4, 52, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, MyGlb.PANEL_FORM, 128);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, MyGlb.PANEL_FORM, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_CERTIFICPUSH, MyGlb.PANEL_FORM, "Certificato Push");
    PAN_APPLICDISATT.SetFieldPage(PFL_APPLICDISATT_CERTIFICPUSH, -1, -1);
    PAN_APPLICDISATT.SetFieldPanel(PFL_APPLICDISATT_CERTIFICPUSH, PPQRY_APPLICAZION5, "A.CERT_DEV", "CERT_DEV", 5, 300, 0, -1709);
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, MyGlb.PANEL_LIST, 348, 44, 144, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, MyGlb.PANEL_LIST, 80);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, MyGlb.PANEL_LIST, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, MyGlb.PANEL_LIST, "Data Scadenza");
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, MyGlb.PANEL_FORM, 4, 124, 248, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, MyGlb.PANEL_FORM, 128);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, MyGlb.PANEL_FORM, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_DATASCADENZA, MyGlb.PANEL_FORM, "Data Scadenza");
    PAN_APPLICDISATT.SetFieldPage(PFL_APPLICDISATT_DATASCADENZA, -1, -1);
    PAN_APPLICDISATT.SetFieldPanel(PFL_APPLICDISATT_DATASCADENZA, PPQRY_APPLICAZION5, "A.DAT_SCAD_CERT", "DAT_SCAD_CERT", 8, 10, 0, -1709);
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, MyGlb.PANEL_LIST, 492, 44, 124, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, MyGlb.PANEL_LIST, 32);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, MyGlb.PANEL_LIST, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, MyGlb.PANEL_LIST, "Nota");
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, MyGlb.PANEL_FORM, 4, 76, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, MyGlb.PANEL_FORM, 128);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, MyGlb.PANEL_FORM, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_NOTA, MyGlb.PANEL_FORM, "Nota");
    PAN_APPLICDISATT.SetFieldPage(PFL_APPLICDISATT_NOTA, -1, -1);
    PAN_APPLICDISATT.SetFieldPanel(PFL_APPLICDISATT_NOTA, PPQRY_APPLICAZION5, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -1709);
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, MyGlb.PANEL_LIST, 616, 44, 88, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, MyGlb.PANEL_LIST, 52);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, MyGlb.PANEL_LIST, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, MyGlb.PANEL_LIST, "Ambiente");
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, MyGlb.PANEL_FORM, 4, 100, 248, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, MyGlb.PANEL_FORM, 128);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, MyGlb.PANEL_FORM, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_AMBIENTE, MyGlb.PANEL_FORM, "Ambiente");
    PAN_APPLICDISATT.SetFieldPage(PFL_APPLICDISATT_AMBIENTE, -1, -1);
    PAN_APPLICDISATT.SetFieldPanel(PFL_APPLICDISATT_AMBIENTE, PPQRY_APPLICAZION5, "A.FLG_AMBIENTE", "FLG_AMBIENTE", 5, 1, 0, -1709);
    PAN_APPLICDISATT.SetValueListItem(PFL_APPLICDISATT_AMBIENTE, (new IDVariant("S")), "Sviluppo", "", "", -1);
    PAN_APPLICDISATT.SetValueListItem(PFL_APPLICDISATT_AMBIENTE, (new IDVariant("P")), "Produzione", "", "", -1);
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, MyGlb.PANEL_LIST, 704, 44, 48, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, MyGlb.PANEL_LIST, 40);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, MyGlb.PANEL_LIST, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, MyGlb.PANEL_LIST, "Attiva");
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, MyGlb.PANEL_FORM, 356, 4, 176, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, MyGlb.PANEL_FORM, 128);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, MyGlb.PANEL_FORM, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ATTIVA, MyGlb.PANEL_FORM, "Attiva");
    PAN_APPLICDISATT.SetFieldPage(PFL_APPLICDISATT_ATTIVA, -1, -1);
    PAN_APPLICDISATT.SetFieldPanel(PFL_APPLICDISATT_ATTIVA, PPQRY_APPLICAZION5, "A.FLG_ATTIVA", "FLG_ATTIVA", 5, 1, 0, -1709);
    PAN_APPLICDISATT.SetValueListItem(PFL_APPLICDISATT_ATTIVA, (new IDVariant("S")), "Si", "", "", -1);
    PAN_APPLICDISATT.SetValueListItem(PFL_APPLICDISATT_ATTIVA, (new IDVariant("N")), "No", "", "", -1);
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, MyGlb.PANEL_LIST, 0, 44, 52, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, MyGlb.PANEL_LIST, 52);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, MyGlb.PANEL_LIST, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, MyGlb.PANEL_LIST, "Type OS");
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, MyGlb.PANEL_FORM, 4, 172, 96, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, MyGlb.PANEL_FORM, 52);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, MyGlb.PANEL_FORM, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_TYPEOS, MyGlb.PANEL_FORM, "Typ. O.");
    PAN_APPLICDISATT.SetFieldPage(PFL_APPLICDISATT_TYPEOS, -1, -1);
    PAN_APPLICDISATT.SetFieldPanel(PFL_APPLICDISATT_TYPEOS, PPQRY_APPLICAZION5, "A.TYPE_OS", "TYPE_OS", 5, 1, 0, -1709);
    PAN_APPLICDISATT.SetValueListItem(PFL_APPLICDISATT_TYPEOS, (new IDVariant("1")), "iOS", "", "", -1);
    PAN_APPLICDISATT.SetValueListItem(PFL_APPLICDISATT_TYPEOS, (new IDVariant("2")), "Android", "", "", -1);
    PAN_APPLICDISATT.SetValueListItem(PFL_APPLICDISATT_TYPEOS, (new IDVariant("3")), "Windows Phone", "", "", -1);
    PAN_APPLICDISATT.SetValueListItem(PFL_APPLICDISATT_TYPEOS, (new IDVariant("4")), "Blackberry", "", "", -1);
    PAN_APPLICDISATT.SetValueListItem(PFL_APPLICDISATT_TYPEOS, (new IDVariant("5")), "Windows Store", "", "", -1);
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, MyGlb.PANEL_LIST, 752, 44, 200, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, MyGlb.PANEL_LIST, 36);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, MyGlb.PANEL_LIST, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, MyGlb.PANEL_LIST, "Errori");
    PAN_APPLICDISATT.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, MyGlb.PANEL_FORM, 4, 148, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICDISATT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, MyGlb.PANEL_FORM, 128);
    PAN_APPLICDISATT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, MyGlb.PANEL_FORM, 1);
    PAN_APPLICDISATT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICDISATT_ERRORI, MyGlb.PANEL_FORM, "Errori");
    PAN_APPLICDISATT.SetFieldPage(PFL_APPLICDISATT_ERRORI, -1, -1);
    PAN_APPLICDISATT.SetFieldPanel(PFL_APPLICDISATT_ERRORI, PPQRY_APPLICAZION5, "A.DES_ERR", "DES_ERR", 5, 2000, 0, -1709);
  }

  private void PAN_APPLICDISATT_InitQueries()
  {
    StringBuilder SQL;

    PAN_APPLICDISATT.SetSize(MyGlb.OBJ_QUERY, 2);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS A ");
    SQL.Append("where (A.ID = ~~ID_APP~~) ");
    PAN_APPLICDISATT.SetQuery(PPQRY_APPS, 0, SQL, PFL_APPLICDISATT_APPLICAZIONE, "BDED5DA1-AE6A-44F3-917F-1F63E9A2B5EF");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS A ");
    PAN_APPLICDISATT.SetQuery(PPQRY_APPS, 1, SQL, PFL_APPLICDISATT_APPLICAZIONE, "");
    PAN_APPLICDISATT.SetQueryDB(PPQRY_APPS, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_APPLICDISATT.SetIMDB(IMDB, "PQRY_APPLICAZION5", true);
    PAN_APPLICDISATT.set_SetString(MyGlb.MASTER_ROWNAME, "Applicazione");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.CERT_DEV as CERT_DEV, ");
    SQL.Append("  A.DES_NOTA as DES_NOTA, ");
    SQL.Append("  A.FLG_ATTIVA as FLG_ATTIVA, ");
    SQL.Append("  A.FLG_AMBIENTE as FLG_AMBIENTE, ");
    SQL.Append("  A.TYPE_OS as TYPE_OS, ");
    SQL.Append("  A.ID_APP as ID_APP, ");
    SQL.Append("  A.DAT_SCAD_CERT as DAT_SCAD_CERT, ");
    SQL.Append("  A.DES_ERR as DES_ERR ");
    PAN_APPLICDISATT.SetQuery(PPQRY_APPLICAZION5, 0, SQL, -1, "83929FF4-0347-40C9-956E-2CE5114DD56F");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A ");
    PAN_APPLICDISATT.SetQuery(PPQRY_APPLICAZION5, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.TYPE_OS = '1') ");
    SQL.Append("and   (A.FLG_ATTIVA = 'N') ");
    PAN_APPLICDISATT.SetQuery(PPQRY_APPLICAZION5, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPLICDISATT.SetQuery(PPQRY_APPLICAZION5, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPLICDISATT.SetQuery(PPQRY_APPLICAZION5, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPLICDISATT.SetQuery(PPQRY_APPLICAZION5, 5, SQL, -1, "");
    PAN_APPLICDISATT.SetQueryDB(PPQRY_APPLICAZION5, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_APPLICDISATT.SetMasterTable(0, "APPS_PUSH_SETTING");
    SQL = new StringBuilder("");
    PAN_APPLICDISATT.SetQuery(0, -1, SQL, PFL_APPLICDISATT_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_APPLICATTIVE) PAN_APPLICATTIVE_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
    if (SrcObj == PAN_APPLICDISATT) PAN_APPLICDISATT_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_APPLICATTIVE) PAN_APPLICATTIVE_ValidateRow(Cancel);
    if (SrcObj == PAN_APPLICDISATT) PAN_APPLICDISATT_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
    if (SrcObj == PAN_APPLICATTIVE) PAN_APPLICATTIVE_DynamicProperties();
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_APPLICATTIVE) PAN_APPLICATTIVE_CellActivated(ColIndex, Cancel);
    if (SrcObj == PAN_APPLICDISATT) PAN_APPLICDISATT_CellActivated(ColIndex, Cancel);
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
    if (SrcObj == PAN_APPLICATTIVE) PAN_APPLICATTIVE_BeforeInsert(Cancel);
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
    if (SrcObj == TAB_NUOVTABBVIEW) TAB_NUOVTABBVIEW_Click(PreviousPage, Cancel);
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
