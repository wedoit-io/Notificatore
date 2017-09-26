// **********************************************
// Device ID Win Store
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
public partial class DeviceIDWinStore : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_DEVICETOKEN_ID = 0;
  private const int PFL_DEVICETOKEN_APPLICAZIONE = 1;
  private const int PFL_DEVICETOKEN_DEVTOKEN = 2;
  private const int PFL_DEVICETOKEN_DATAULTIACCE = 3;
  private const int PFL_DEVICETOKEN_DATA = 4;
  private const int PFL_DEVICETOKEN_ATTIVO = 5;
  private const int PFL_DEVICETOKEN_UTENTE = 6;
  private const int PFL_DEVICETOKEN_DISPOSITNOTO = 7;
  private const int PFL_DEVICETOKEN_RIMOSSO = 8;
  private const int PFL_DEVICETOKEN_DATAULTIINVI = 9;
  private const int PFL_DEVICETOKEN_NOTA = 10;
  private const int PFL_DEVICETOKEN_DATARIMOZION = 11;
  private const int PFL_DEVICETOKEN_REGURL = 12;
  private const int PFL_DEVICETOKEN_IDLINGUA = 13;

  private const int PPQRY_DEVICETOKEN4 = 0;

  private const int PPQRY_APPLICAZIONI = 1;
  private const int PPQRY_LINGUE = 2;


  internal IDPanel PAN_DEVICETOKEN;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_DEVICETOKEN4(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_DEVICETOKEN4(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DEVICETOKEN4, 14);
    IMDB.set_TblCode(IMDBDef1.PQRY_DEVICETOKEN4, "PQRY_DEVICETOKEN4");
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DEV_TOKEN, "DEV_TOKEN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DEV_TOKEN,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DATA_ULT_ACCESSO, "DATA_ULT_ACCESSO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DATA_ULT_ACCESSO,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DATA_CREAZIONE, "DATA_CREAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DATA_CREAZIONE,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_FLG_ATTIVO, "FLG_ATTIVO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_FLG_ATTIVO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_FLG_RIMOSSO, "FLG_RIMOSSO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_FLG_RIMOSSO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DAT_ULTIMO_INVIO, "DAT_ULTIMO_INVIO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DAT_ULTIMO_INVIO,8,19,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_ID_APPLICAZIONE, "ID_APPLICAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_ID_APPLICAZIONE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DATA_RIMOZ, "DATA_RIMOZ");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DATA_RIMOZ,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_REG_ID, "REG_ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_REG_ID,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DISNOTDEVTOK, "DISNOTDEVTOK");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_DISNOTDEVTOK,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_PRG_LINGUA, "PRG_LINGUA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN4,IMDBDef1.PQSL_DEVICETOKEN4_PRG_LINGUA,1,9,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_DEVICETOKEN4, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public DeviceIDWinStore(MyWebEntryPoint w, IMDBObj imdb)
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
  public DeviceIDWinStore()
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
    FormIdx = MyGlb.FRM_DEVIIDWINSTO;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "D1339D57-4550-4908-BFE9-5267F625B764";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 1124;
    DesignHeight = 680;
    set_Caption(new IDVariant("Device ID Win Store"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 1124;
    Frames[1].Height = 620;
    Frames[1].Caption = "Device Token";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 620;
    PAN_DEVICETOKEN = new IDPanel(w, this, 1, "PAN_DEVICETOKEN");
    Frames[1].Content = PAN_DEVICETOKEN;
    PAN_DEVICETOKEN.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_DEVICETOKEN.VS = MainFrm.VisualStyleList;
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 1124-MyGlb.PAN_OFFS_X, 620-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "AB559A69-CF30-472B-A113-C9E01E905550");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 1024, 484, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_DEVICETOKEN.InitStatus = 1;
    PAN_DEVICETOKEN_Init();
    PAN_DEVICETOKEN_InitFields();
    PAN_DEVICETOKEN_InitQueries();
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
    if (CmdIdx==MyGlb.CMD_INVIOMANUAL5+BaseCmdLinIdx)
    {
      InvioManuale();
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
      PAN_DEVICETOKEN.UpdatePanel(MainFrm);
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
    return (obj is DeviceIDWinStore);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(DeviceIDWinStore).FullName : typeof(DeviceIDWinStore).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Device Token On Dynamic Properties
  // Consente l'aggiustamento delle proprietà visuali delle
  // singole celle del pannello.
  // **********************************************************************
  private void PAN_DEVICETOKEN_DynamicProperties ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("B3AC7B1B-0973-4420-8CAB-97E518B8E174", "Device Token On Dynamic Properties", "", 1, "Device ID Win Store")) return;
      // 
      // Device Token On Dynamic Properties Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddIf ("B8CA2F21-74EA-45B9-A27C-7412927F0748", "IF Data Device Token [Device ID Win Store - Device Token].Text = Data Ultimo Accesso Device Token [Device ID Win Store - Device Token].Text", "");
      MainFrm.DTTObj.AddToken ("B8CA2F21-74EA-45B9-A27C-7412927F0748", "C09D3B9A-7712-47F5-BAEB-64342C8C348A", 2686976, "Data Device Token [Device ID Win Store - Device Token].Text", (new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATA))));
      MainFrm.DTTObj.AddToken ("B8CA2F21-74EA-45B9-A27C-7412927F0748", "AF6D152F-FEFB-4C61-BADD-1582CDE27A1E", 2686976, "Data Ultimo Accesso Device Token [Device ID Win Store - Device Token].Text", (new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATAULTIACCE))));
      if ((new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATA))).equals((new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATAULTIACCE))), true))
      {
        MainFrm.DTTObj.EnterIf ("B8CA2F21-74EA-45B9-A27C-7412927F0748", "IF Data Device Token [Device ID Win Store - Device Token].Text = Data Ultimo Accesso Device Token [Device ID Win Store - Device Token].Text", "");
        MainFrm.DTTObj.AddSubProc ("3BCCA958-12AB-4B65-B45A-72DD08924CDD", "Data Ultimo Accesso.Set Visual Style", "");
        MainFrm.DTTObj.AddParameter ("3BCCA958-12AB-4B65-B45A-72DD08924CDD", "AEFE2949-21AA-4B67-9B98-A4FD3DF0CCA8", "Stile", new IDVariant(MyGlb.VIS_SFONDOGIALLO));
        PAN_DEVICETOKEN.set_VisualStyle(Glb.OBJ_FIELD,PFL_DEVICETOKEN_DATAULTIACCE,new IDVariant(MyGlb.VIS_SFONDOGIALLO).intValue()); 
      }
      MainFrm.DTTObj.EndIfBlk ("B8CA2F21-74EA-45B9-A27C-7412927F0748");
      MainFrm.DTTObj.ExitProc("B3AC7B1B-0973-4420-8CAB-97E518B8E174", "Device Token On Dynamic Properties", "", 1, "Device ID Win Store");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("B3AC7B1B-0973-4420-8CAB-97E518B8E174", "Device Token On Dynamic Properties", "", _e);
      MainFrm.ErrObj.ProcError ("DeviceIDWinStore", "DeviceTokenOnDynamicProperties", _e);
      MainFrm.DTTObj.ExitProc("B3AC7B1B-0973-4420-8CAB-97E518B8E174", "Device Token On Dynamic Properties", "", 1, "Device ID Win Store");
    }
  }

  // **********************************************************************
  // Invio Manuale
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int InvioManuale ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("59896D67-519A-4D44-A189-C4108CD47454", "Invio Manuale", "", 3, "Device ID Win Store")) return 0;
      // 
      // Invio Manuale Body
      // Corpo Procedura
      // 
      IDVariant v_VWNSSEAPPUSE = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VWNPASEIDAPS = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VWNXMTEAPPUS = new IDVariant(0,IDVariant.STRING);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.WNS_SECRET as WNSSECAPPUSE, ");
      SQL.Append("  A.WNS_SID as WNPASEIDAPPS, ");
      SQL.Append("  A.WNS_XML as WNXMTEAPPUSE ");
      SQL.Append("from ");
      SQL.Append("  APPS_PUSH_SETTING A, ");
      SQL.Append("  APPS B ");
      SQL.Append("where B.ID = A.ID_APP ");
      SQL.Append("and   (A.TYPE_OS = '5') ");
      SQL.Append("and   (A.ID = " + IDL.CSql(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_ID_APPLICAZIONE, 0), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      MainFrm.DTTObj.AddQuery ("65499689-B645-4877-AE67-CC2448907610", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("65499689-B645-4877-AE67-CC2448907610");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        v_VWNSSEAPPUSE = QV.Get("WNSSECAPPUSE", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("65499689-B645-4877-AE67-CC2448907610", "03DCC66B-E29C-406B-BF58-A1E752147FBB", 1376256, "v Wns Secret Apps Push Settings", v_VWNSSEAPPUSE);
        v_VWNPASEIDAPS = QV.Get("WNPASEIDAPPS", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("65499689-B645-4877-AE67-CC2448907610", "C2719F55-C447-4A47-86B9-C146DCDCEA5D", 1376256, "v Wns Package Security Identifier Apps Push Settings", v_VWNPASEIDAPS);
        v_VWNXMTEAPPUS = QV.Get("WNXMTEAPPUSE", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("65499689-B645-4877-AE67-CC2448907610", "CA230DE3-52A5-4728-9DFB-55536B887A94", 1376256, "v Wns Xml Template Apps Push Settings", v_VWNXMTEAPPUS);
      }
      QV.Close();
      MainFrm.DTTObj.AddAssign ("507307C5-D65E-4963-8A54-68BDE95B45D3", "Regid Spedizione Nome Oggetto := Reg Url Device Token [Device ID Win Store - Device Token]", "", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_REG_ID, 0));
      MainFrm.DTTObj.AddToken ("507307C5-D65E-4963-8A54-68BDE95B45D3", "A6ECA0E8-BE4E-4517-B6B9-57E929F2D610", 917504, "Reg Url", IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_REG_ID, 0));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_REG_ID, 0, IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_REG_ID, 0));
      MainFrm.DTTObj.AddAssignNewValue ("507307C5-D65E-4963-8A54-68BDE95B45D3", "DABA2862-C97C-411C-9A73-136D6DAC6E2E", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_REG_ID, 0));
      MainFrm.DTTObj.AddAssign ("77847D22-1FBA-4491-956F-C0FD61C3A8B7", "ID Apps Push Settings Spedizione Nome Oggetto := Applicazione Device Token [Device ID Win Store - Device Token]", "", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_ID_APPLICAZIONE, 0));
      MainFrm.DTTObj.AddToken ("77847D22-1FBA-4491-956F-C0FD61C3A8B7", "C29C07DE-2D16-4E5F-9130-68427C8C62ED", 917504, "Applicazione", IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_ID_APPLICAZIONE, 0));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_ID_APPLICAZIONE, 0, IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_ID_APPLICAZIONE, 0));
      MainFrm.DTTObj.AddAssignNewValue ("77847D22-1FBA-4491-956F-C0FD61C3A8B7", "81C2F942-E36B-4881-AE4F-9B5F35E1520C", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_ID_APPLICAZIONE, 0));
      MainFrm.DTTObj.AddAssign ("A9EFE7E6-A983-4F6F-B6BE-D86A6C1972A0", "Device Token Spedizione Nome Oggetto := Dev Token Device Token [Device ID Win Store - Device Token]", "", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_DEV_TOKEN, 0));
      MainFrm.DTTObj.AddToken ("A9EFE7E6-A983-4F6F-B6BE-D86A6C1972A0", "732EEAA5-8D19-4489-B84A-870E2970F80A", 917504, "Dev Token Device Token", IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_DEV_TOKEN, 0));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_DEV_TOKEN, 0, IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_DEV_TOKEN, 0));
      MainFrm.DTTObj.AddAssignNewValue ("A9EFE7E6-A983-4F6F-B6BE-D86A6C1972A0", "22F1EE91-3F9C-4698-8067-59393FBF450A", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_DEV_TOKEN, 0));
      MainFrm.DTTObj.AddAssign ("50255605-434D-44A0-BAD8-6BA0D1FD26D7", "Wns Secret Apps Push Settings Nome Oggetto := v Wns Secret Apps Push Settings", "", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_WNS_SECRET, 0));
      MainFrm.DTTObj.AddToken ("50255605-434D-44A0-BAD8-6BA0D1FD26D7", "03DCC66B-E29C-406B-BF58-A1E752147FBB", 1376256, "v Wns Secret Apps Push Settings", new IDVariant(v_VWNSSEAPPUSE));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_WNS_SECRET, 0, new IDVariant(v_VWNSSEAPPUSE));
      MainFrm.DTTObj.AddAssignNewValue ("50255605-434D-44A0-BAD8-6BA0D1FD26D7", "9798DD27-FAD2-43D0-A60A-42E766C89A92", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_WNS_SECRET, 0));
      MainFrm.DTTObj.AddAssign ("CDF425B1-6BA9-4ADE-A1C8-AA8CEA4B95C1", "Wns Package Security Identifier Apps Push Settings Nome Oggetto := v Wns Package Security Identifier Apps Push Settings", "", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_WNS_SID, 0));
      MainFrm.DTTObj.AddToken ("CDF425B1-6BA9-4ADE-A1C8-AA8CEA4B95C1", "C2719F55-C447-4A47-86B9-C146DCDCEA5D", 1376256, "v Wns Package Security Identifier Apps Push Settings", new IDVariant(v_VWNPASEIDAPS));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_WNS_SID, 0, new IDVariant(v_VWNPASEIDAPS));
      MainFrm.DTTObj.AddAssignNewValue ("CDF425B1-6BA9-4ADE-A1C8-AA8CEA4B95C1", "C3F92F9A-3AC5-4126-B82E-D00E89EDC5C0", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_WNS_SID, 0));
      MainFrm.DTTObj.AddAssign ("0350128E-843F-415F-B06C-B75220B8D937", "Wns Xml Template Apps Push Settings Nome Oggetto := v Wns Xml Template Apps Push Settings", "", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_WNS_XML, 0));
      MainFrm.DTTObj.AddToken ("0350128E-843F-415F-B06C-B75220B8D937", "CA230DE3-52A5-4728-9DFB-55536B887A94", 1376256, "v Wns Xml Template Apps Push Settings", new IDVariant(v_VWNXMTEAPPUS));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_WNS_XML, 0, new IDVariant(v_VWNXMTEAPPUS));
      MainFrm.DTTObj.AddAssignNewValue ("0350128E-843F-415F-B06C-B75220B8D937", "0E8B77BA-4B08-4E18-A7A4-F2FEBD4BBC57", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_WNS_XML, 0));
      MainFrm.DTTObj.AddAssign ("03774A7B-2B98-40C6-A5C7-2E7A11F1C305", "Messaggio Spedizione Nome Oggetto := v Wns Xml Template Apps Push Settings", "", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_DES_MESSAGGIO, 0));
      MainFrm.DTTObj.AddToken ("03774A7B-2B98-40C6-A5C7-2E7A11F1C305", "CA230DE3-52A5-4728-9DFB-55536B887A94", 1376256, "v Wns Xml Template Apps Push Settings", new IDVariant(v_VWNXMTEAPPUS));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_DES_MESSAGGIO, 0, new IDVariant(v_VWNXMTEAPPUS));
      MainFrm.DTTObj.AddAssignNewValue ("03774A7B-2B98-40C6-A5C7-2E7A11F1C305", "35B1C52C-0A34-4197-BCDF-C0C6184AE530", IMDB.Value(IMDBDef1.TBL_PARAMETRI, IMDBDef1.FLD_PARAMETRI_DES_MESSAGGIO, 0));
      MainFrm.DTTObj.AddSubProc ("1419CE01-E3B9-4C00-81BB-54D8CDCA9B0C", "Invio WNS Manuale.Show", "");
      MainFrm.Show(MyGlb.FRM_INVIOWNSMANU, (new IDVariant(0)).intValue(), this); 
      MainFrm.DTTObj.ExitProc("59896D67-519A-4D44-A189-C4108CD47454", "Invio Manuale", "", 3, "Device ID Win Store");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("59896D67-519A-4D44-A189-C4108CD47454", "Invio Manuale", "", _e);
      MainFrm.ErrObj.ProcError ("DeviceIDWinStore", "InvioManuale", _e);
      MainFrm.DTTObj.ExitProc("59896D67-519A-4D44-A189-C4108CD47454", "Invio Manuale", "", 3, "Device ID Win Store");
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
  private void PAN_DEVICETOKEN_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_DEVICETOKEN_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_DEVICETOKEN_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_DATA_ULT_ACCESSO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_DATA_ULT_ACCESSO, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_DATA_CREAZIONE, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_DATA_CREAZIONE, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_FLG_ATTIVO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_FLG_ATTIVO, 0, (new IDVariant("S")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_FLG_RIMOSSO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN4, IMDBDef1.PQSL_DEVICETOKEN4_FLG_RIMOSSO, 0, (new IDVariant("N")));
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_DEVICETOKEN_Init()
  {

    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_FIELD, 14);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "D344DE69-C2F5-4037-B91A-CEE7CC69FFBB");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "ID");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "Identificativo univoco");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, 0 | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, "0FE0CCD0-7594-44B2-BF9C-DEEE847E79BB");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, "Applicazione");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, "Identificativo univoco");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.VIS_FOREIKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "55286278-A158-41B8-9894-2F0ADD53F3E1");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "Dev Token");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "AF6D152F-FEFB-4C61-BADD-1582CDE27A1E");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "Data Ultimo Accesso");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "C09D3B9A-7712-47F5-BAEB-64342C8C348A");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "Data");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "A66E2629-20C5-4E03-AAAC-B3CEF8D33993");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "Attivo");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "725BAFB7-BE79-4FE2-9160-DB44DD0AB35E");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "Utente");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, "F6289BE1-8F5D-4E87-96A1-458275E377F4");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, "Dispositivo Noto");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "3113CA44-4C37-4999-9307-E0A7339CBDAA");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "Rimosso");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "C3444255-2431-468E-8A2E-9825ACE9E816");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "Data Ultimo Invio");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "Data dell'invio dell'ultima notifica push");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "B75CE156-4DEB-4126-B22D-CBCF377DB269");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "Nota");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "Nota");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "53DEB151-4664-4790-BB37-35A90A59DE72");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "Data Rimozione");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, "976C96F8-570D-418D-93D7-2466344E3B74");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, "Reg Url");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, "RegID usato da android");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, "1E1391ED-5474-49D7-8D68-C1F9E0D48F8A");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, "Id Lingua");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.VIS_FOREIKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_DEVICETOKEN_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 0, 32, 68, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 20);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, "ID");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 4, 4, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, "ID");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_ID, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_ID, PPQRY_DEVICETOKEN4, "A.ID", "ID", 1, 9, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, 0, 32, 116, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, 84);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, 4, 28, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_APPLICAZIONE, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_APPLICAZIONE, PPQRY_DEVICETOKEN4, "A.ID_APPLICAZIONE", "ID_APPLICAZIONE", 1, 9, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 116, 32, 88, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, "Dev Token");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 4, 52, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, "Dev Token");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DEVTOKEN, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DEVTOKEN, PPQRY_DEVICETOKEN4, "A.DEV_TOKEN", "DEV_TOKEN", 5, 200, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 204, 32, 108, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, "Dt. Ult. Accesso");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 4, 76, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, "Dt. Ultimo Accesso");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATAULTIACCE, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATAULTIACCE, PPQRY_DEVICETOKEN4, "A.DATA_ULT_ACCESSO", "DATA_ULT_ACCESSO", 8, 61, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 312, 32, 104, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, "Data");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 4, 100, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, "Data");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATA, PPQRY_DEVICETOKEN4, "A.DATA_CREAZIONE", "DATA_CREAZIONE", 8, 61, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 416, 32, 48, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 40);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, "Attivo");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 4, 124, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, "Attivo");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_ATTIVO, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_ATTIVO, PPQRY_DEVICETOKEN4, "A.FLG_ATTIVO", "FLG_ATTIVO", 5, 1, 0, -1709);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_ATTIVO, (new IDVariant("S")), "Si", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_ATTIVO, (new IDVariant("N")), "No", "", "", -1);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 464, 32, 68, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 44);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, "Utente");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 4, 148, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, "Utente");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_UTENTE, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_UTENTE, PPQRY_DEVICETOKEN4, "A.DES_UTENTE", "DES_UTENTE", 5, 100, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, MyGlb.PANEL_LIST, 532, 32, 104, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, MyGlb.PANEL_LIST, 88);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, MyGlb.PANEL_LIST, "Dispositivo Noto");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, MyGlb.PANEL_FORM, 4, 316, 628, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, MyGlb.PANEL_FORM, "Dispositivo Noto");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DISPOSITNOTO, -1, -1);
    SQL = new StringBuilder();
    SQL.Append("( ");
  SQL.Append("select ");
  SQL.Append("  B.DES_MESSAGGIO ");
  SQL.Append("from ");
  SQL.Append("  DISPOSITIVI_NOTI B ");
  SQL.Append("where (B.DEV_TOKEN = A.DEV_TOKEN) ");
  SQL.Append(")");
    PAN_DEVICETOKEN.SetFieldUnbound(PFL_DEVICETOKEN_DISPOSITNOTO, true);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DISPOSITNOTO, PPQRY_DEVICETOKEN4, SQL.ToString(), "DISNOTDEVTOK", 9, 1000, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 636, 32, 44, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 48);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, "Rim.");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 4, 172, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, "Rimosso");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_RIMOSSO, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_RIMOSSO, PPQRY_DEVICETOKEN4, "A.FLG_RIMOSSO", "FLG_RIMOSSO", 5, 1, 0, -1709);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_RIMOSSO, (new IDVariant("N")), "No", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_RIMOSSO, (new IDVariant("S")), "Si", "", "", -1);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, 680, 32, 120, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, 92);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, "Data Ultimo Invio");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, 4, 196, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, "Data Ultimo Invio");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATAULTIINVI, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATAULTIINVI, PPQRY_DEVICETOKEN4, "A.DAT_ULTIMO_INVIO", "DAT_ULTIMO_INVIO", 8, 19, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 800, 32, 72, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 32);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, "Nota");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 4, 220, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, "Nota");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_NOTA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_NOTA, PPQRY_DEVICETOKEN4, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 872, 32, 96, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 84);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, "Dt. Rimozione");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 4, 244, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, "Data Rimozione");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATARIMOZION, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATARIMOZION, PPQRY_DEVICETOKEN4, "A.DATA_RIMOZ", "DATA_RIMOZ", 8, 61, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_LIST, 0, 512, 532, 76, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_LIST, 52);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_LIST, 4);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_LIST, "Reg Url");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_FORM, 4, 268, 628, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_FORM, "Reg Url");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_REGURL, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_REGURL, PPQRY_DEVICETOKEN4, "A.REG_ID", "REG_ID", 5, 200, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, 968, 32, 56, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, 52);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, "Id Ling.");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, 4, 340, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, "Id Lingua");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_IDLINGUA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_IDLINGUA, PPQRY_DEVICETOKEN4, "A.PRG_LINGUA", "PRG_LINGUA", 1, 9, 0, -1709);
  }

  private void PAN_DEVICETOKEN_InitQueries()
  {
    StringBuilder SQL;

    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_QUERY, 3);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.ID = ~~ID_APPLICAZIONE~~) ");
    SQL.Append("and   (A.TYPE_OS = '5') ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_APPLICAZIONI, 0, SQL, PFL_DEVICETOKEN_APPLICAZIONE, "F3C69B99-3057-4745-ADD6-57573D78E568");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.TYPE_OS = '5') ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_APPLICAZIONI, 1, SQL, PFL_DEVICETOKEN_APPLICAZIONE, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_APPLICAZIONI, MainFrm.NotificatoreDBObject.DB, 256);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.PRG_LINGUA as IDLINGUA, ");
    SQL.Append("  A.DES_LINGUA as DESCRILINGUA ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    SQL.Append("where (A.PRG_LINGUA = ~~PRG_LINGUA~~) ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LINGUE, 0, SQL, PFL_DEVICETOKEN_IDLINGUA, "798F17AA-92B7-4433-BF4B-C00239910BCF");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.PRG_LINGUA as IDLINGUA, ");
    SQL.Append("  A.DES_LINGUA as DESCRILINGUA ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LINGUE, 1, SQL, PFL_DEVICETOKEN_IDLINGUA, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_LINGUE, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DEVICETOKEN.SetIMDB(IMDB, "PQRY_DEVICETOKEN4", true);
    PAN_DEVICETOKEN.set_SetString(MyGlb.MASTER_ROWNAME, "Device Token");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.DEV_TOKEN as DEV_TOKEN, ");
    SQL.Append("  A.DATA_ULT_ACCESSO as DATA_ULT_ACCESSO, ");
    SQL.Append("  A.DATA_CREAZIONE as DATA_CREAZIONE, ");
    SQL.Append("  A.FLG_ATTIVO as FLG_ATTIVO, ");
    SQL.Append("  A.DES_UTENTE as DES_UTENTE, ");
    SQL.Append("  A.FLG_RIMOSSO as FLG_RIMOSSO, ");
    SQL.Append("  A.DAT_ULTIMO_INVIO as DAT_ULTIMO_INVIO, ");
    SQL.Append("  A.DES_NOTA as DES_NOTA, ");
    SQL.Append("  A.ID_APPLICAZIONE as ID_APPLICAZIONE, ");
    SQL.Append("  A.DATA_RIMOZ as DATA_RIMOZ, ");
    SQL.Append("  A.REG_ID as REG_ID, ");
    SQL.Append("  ( ");
    SQL.Append("select ");
    SQL.Append("  B.DES_MESSAGGIO ");
    SQL.Append("from ");
    SQL.Append("  DISPOSITIVI_NOTI B ");
    SQL.Append("where (B.DEV_TOKEN = A.DEV_TOKEN) ");
    SQL.Append(") as DISNOTDEVTOK, ");
    SQL.Append("  A.PRG_LINGUA as PRG_LINGUA ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN4, 0, SQL, -1, "1CE103DA-C9FB-42DA-ADE3-49431EB9F23B");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  DEV_TOKENS A ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN4, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.TYPE_OS = '5') ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN4, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN4, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN4, 4, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("order by ");
    SQL.Append("  A.DATA_ULT_ACCESSO desc ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN4, 5, SQL, -1, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_DEVICETOKEN4, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DEVICETOKEN.SetMasterTable(0, "DEV_TOKENS");
    PAN_DEVICETOKEN.AddToSortList(PFL_DEVICETOKEN_DATAULTIACCE, false);
    SQL = new StringBuilder("");
    PAN_DEVICETOKEN.SetQuery(0, -1, SQL, PFL_DEVICETOKEN_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_DEVICETOKEN) PAN_DEVICETOKEN_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_DEVICETOKEN) PAN_DEVICETOKEN_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
    if (SrcObj == PAN_DEVICETOKEN) PAN_DEVICETOKEN_DynamicProperties();
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_DEVICETOKEN) PAN_DEVICETOKEN_CellActivated(ColIndex, Cancel);
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
