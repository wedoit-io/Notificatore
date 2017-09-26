// **********************************************
// Device ID Win Phone
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
public partial class DeviceIDWinPhone : MyWebForm
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

  private const int PPQRY_DEVICETOKEN2 = 0;

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
    Init_PQRY_DEVICETOKEN2(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_DEVICETOKEN2(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DEVICETOKEN2, 14);
    IMDB.set_TblCode(IMDBDef1.PQRY_DEVICETOKEN2, "PQRY_DEVICETOKEN2");
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DEV_TOKEN, "DEV_TOKEN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DEV_TOKEN,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DATA_ULT_ACCESSO, "DATA_ULT_ACCESSO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DATA_ULT_ACCESSO,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DATA_CREAZIONE, "DATA_CREAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DATA_CREAZIONE,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_FLG_ATTIVO, "FLG_ATTIVO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_FLG_ATTIVO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_FLG_RIMOSSO, "FLG_RIMOSSO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_FLG_RIMOSSO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DAT_ULTIMO_INVIO, "DAT_ULTIMO_INVIO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DAT_ULTIMO_INVIO,8,19,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_ID_APPLICAZIONE, "ID_APPLICAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_ID_APPLICAZIONE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DATA_RIMOZ, "DATA_RIMOZ");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DATA_RIMOZ,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_REG_ID, "REG_ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_REG_ID,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DISNOTDEVTOK, "DISNOTDEVTOK");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_DISNOTDEVTOK,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_PRG_LINGUA, "PRG_LINGUA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN2,IMDBDef1.PQSL_DEVICETOKEN2_PRG_LINGUA,1,9,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_DEVICETOKEN2, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public DeviceIDWinPhone(MyWebEntryPoint w, IMDBObj imdb)
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
  public DeviceIDWinPhone()
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
    FormIdx = MyGlb.FRM_DEVIIDWINPHO;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "FBD5198D-05FC-458C-9EA0-AB115A7C7CEC";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 1124;
    DesignHeight = 680;
    set_Caption(new IDVariant("Device ID Win Phone"));
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
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "34EEF991-1B7B-4015-BD47-40FAD8ECD307");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 1036, 480, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
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
    if (CmdIdx==MyGlb.CMD_INVIOMANUALE+BaseCmdLinIdx)
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
    return (obj is DeviceIDWinPhone);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(DeviceIDWinPhone).FullName : typeof(DeviceIDWinPhone).Name);
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

      if (!MainFrm.DTTObj.EnterProc("65BCE5BB-9A19-49B6-BB1E-D6C571E2A6C6", "Device Token On Dynamic Properties", "", 1, "Device ID Win Phone")) return;
      // 
      // Device Token On Dynamic Properties Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddIf ("B7A54E74-88D8-43BF-A634-760750D8C896", "IF Data Device Token [Device ID Win Phone - Device Token].Text = Data Ultimo Accesso Device Token [Device ID Win Phone - Device Token].Text", "");
      MainFrm.DTTObj.AddToken ("B7A54E74-88D8-43BF-A634-760750D8C896", "352258D4-3A54-44BA-B912-528640ED6BB7", 2686976, "Data Device Token [Device ID Win Phone - Device Token].Text", (new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATA))));
      MainFrm.DTTObj.AddToken ("B7A54E74-88D8-43BF-A634-760750D8C896", "EC8276E1-9ADF-416A-81F5-3ADA33A843F3", 2686976, "Data Ultimo Accesso Device Token [Device ID Win Phone - Device Token].Text", (new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATAULTIACCE))));
      if ((new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATA))).equals((new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATAULTIACCE))), true))
      {
        MainFrm.DTTObj.EnterIf ("B7A54E74-88D8-43BF-A634-760750D8C896", "IF Data Device Token [Device ID Win Phone - Device Token].Text = Data Ultimo Accesso Device Token [Device ID Win Phone - Device Token].Text", "");
        MainFrm.DTTObj.AddSubProc ("EC98DA9F-EA4E-404C-AD5E-0F881FC156A4", "Data Ultimo Accesso.Set Visual Style", "");
        MainFrm.DTTObj.AddParameter ("EC98DA9F-EA4E-404C-AD5E-0F881FC156A4", "0A221725-0F72-4D2B-9D3D-AE65E02EA328", "Stile", new IDVariant(MyGlb.VIS_SFONDOGIALLO));
        PAN_DEVICETOKEN.set_VisualStyle(Glb.OBJ_FIELD,PFL_DEVICETOKEN_DATAULTIACCE,new IDVariant(MyGlb.VIS_SFONDOGIALLO).intValue()); 
      }
      MainFrm.DTTObj.EndIfBlk ("B7A54E74-88D8-43BF-A634-760750D8C896");
      MainFrm.DTTObj.ExitProc("65BCE5BB-9A19-49B6-BB1E-D6C571E2A6C6", "Device Token On Dynamic Properties", "", 1, "Device ID Win Phone");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("65BCE5BB-9A19-49B6-BB1E-D6C571E2A6C6", "Device Token On Dynamic Properties", "", _e);
      MainFrm.ErrObj.ProcError ("DeviceIDWinPhone", "DeviceTokenOnDynamicProperties", _e);
      MainFrm.DTTObj.ExitProc("65BCE5BB-9A19-49B6-BB1E-D6C571E2A6C6", "Device Token On Dynamic Properties", "", 1, "Device ID Win Phone");
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

      if (!MainFrm.DTTObj.EnterProc("1CAD79AC-F371-4044-BEF0-026FF03E9526", "Invio Manuale", "", 3, "Device ID Win Phone")) return 0;
      // 
      // Invio Manuale Body
      // Corpo Procedura
      // 
      IDVariant v_VWNXMTEAPPUS = new IDVariant(0,IDVariant.STRING);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.WNS_XML as WNXMTEAPPUSE ");
      SQL.Append("from ");
      SQL.Append("  APPS_PUSH_SETTING A, ");
      SQL.Append("  APPS B ");
      SQL.Append("where B.ID = A.ID_APP ");
      SQL.Append("and   (A.TYPE_OS = '3') ");
      SQL.Append("and   (A.ID = " + IDL.CSql(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN2, IMDBDef1.PQSL_DEVICETOKEN2_ID_APPLICAZIONE, 0), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      MainFrm.DTTObj.AddQuery ("82D0C670-04C0-44F9-AB59-E167F12BD67E", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("82D0C670-04C0-44F9-AB59-E167F12BD67E");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        v_VWNXMTEAPPUS = QV.Get("WNXMTEAPPUSE", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("82D0C670-04C0-44F9-AB59-E167F12BD67E", "543905E6-815A-4673-9219-DD9B87805186", 1376256, "v Wns Xml Template Apps Push Settings", v_VWNXMTEAPPUS);
      }
      QV.Close();
      MainFrm.DTTObj.AddAssign ("D47078B9-ABFC-485F-972E-B32456F9FB33", "Regid Spedizione Nome Oggetto := Reg Url Device Token [Device ID Win Phone - Device Token]", "", IMDB.Value(IMDBDef1.TBL_PARAMETRI2, IMDBDef1.FLD_PARAMETRI2_REG_ID, 0));
      MainFrm.DTTObj.AddToken ("D47078B9-ABFC-485F-972E-B32456F9FB33", "870252BD-1C8C-417C-AD16-B2D93F418CE6", 917504, "Reg Url", IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN2, IMDBDef1.PQSL_DEVICETOKEN2_REG_ID, 0));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI2, IMDBDef1.FLD_PARAMETRI2_REG_ID, 0, IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN2, IMDBDef1.PQSL_DEVICETOKEN2_REG_ID, 0));
      MainFrm.DTTObj.AddAssignNewValue ("D47078B9-ABFC-485F-972E-B32456F9FB33", "0D8574CE-62ED-4315-BE66-76816985C9EE", IMDB.Value(IMDBDef1.TBL_PARAMETRI2, IMDBDef1.FLD_PARAMETRI2_REG_ID, 0));
      MainFrm.DTTObj.AddAssign ("CCBDA166-0C7E-44C2-9F6B-D5BB9E740669", "Messaggio Spedizione Nome Oggetto := v Wns Xml Template Apps Push Settings", "", IMDB.Value(IMDBDef1.TBL_PARAMETRI2, IMDBDef1.FLD_PARAMETRI2_DES_MESSAGGIO, 0));
      MainFrm.DTTObj.AddToken ("CCBDA166-0C7E-44C2-9F6B-D5BB9E740669", "543905E6-815A-4673-9219-DD9B87805186", 1376256, "v Wns Xml Template Apps Push Settings", new IDVariant(v_VWNXMTEAPPUS));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI2, IMDBDef1.FLD_PARAMETRI2_DES_MESSAGGIO, 0, new IDVariant(v_VWNXMTEAPPUS));
      MainFrm.DTTObj.AddAssignNewValue ("CCBDA166-0C7E-44C2-9F6B-D5BB9E740669", "8ECB866B-A190-4EB2-B697-3BC9A8A633EF", IMDB.Value(IMDBDef1.TBL_PARAMETRI2, IMDBDef1.FLD_PARAMETRI2_DES_MESSAGGIO, 0));
      MainFrm.DTTObj.AddSubProc ("851E9975-0626-4010-B48D-4E37B652AA94", "Invio Winphone Manuale.Show", "");
      MainFrm.Show(MyGlb.FRM_INVIWINPMANU, (new IDVariant(0)).intValue(), this); 
      MainFrm.DTTObj.ExitProc("1CAD79AC-F371-4044-BEF0-026FF03E9526", "Invio Manuale", "", 3, "Device ID Win Phone");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("1CAD79AC-F371-4044-BEF0-026FF03E9526", "Invio Manuale", "", _e);
      MainFrm.ErrObj.ProcError ("DeviceIDWinPhone", "InvioManuale", _e);
      MainFrm.DTTObj.ExitProc("1CAD79AC-F371-4044-BEF0-026FF03E9526", "Invio Manuale", "", 3, "Device ID Win Phone");
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
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN2, IMDBDef1.PQSL_DEVICETOKEN2_DATA_ULT_ACCESSO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN2, IMDBDef1.PQSL_DEVICETOKEN2_DATA_ULT_ACCESSO, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN2, IMDBDef1.PQSL_DEVICETOKEN2_DATA_CREAZIONE, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN2, IMDBDef1.PQSL_DEVICETOKEN2_DATA_CREAZIONE, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN2, IMDBDef1.PQSL_DEVICETOKEN2_FLG_ATTIVO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN2, IMDBDef1.PQSL_DEVICETOKEN2_FLG_ATTIVO, 0, (new IDVariant("S")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN2, IMDBDef1.PQSL_DEVICETOKEN2_FLG_RIMOSSO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN2, IMDBDef1.PQSL_DEVICETOKEN2_FLG_RIMOSSO, 0, (new IDVariant("N")));
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
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "9D8BF9F5-21EA-452F-9C61-CAB460832948");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "ID");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "Identificativo univoco");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, 0 | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, "B671D265-CD69-41C7-B4CD-207BAF423F07");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, "Applicazione");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, "Identificativo univoco");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.VIS_FOREIKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "0C200F1B-83C6-4A7E-9A58-3250ACADE014");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "Dev Token");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "EC8276E1-9ADF-416A-81F5-3ADA33A843F3");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "Data Ultimo Accesso");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "352258D4-3A54-44BA-B912-528640ED6BB7");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "Data");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "64B0F186-B51D-478F-88E0-79C0D06CC33B");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "Attivo");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "7FBF8CA4-825E-4639-B504-879DFF5786C0");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "Utente");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, "3862AFA6-645D-4757-8D07-CC9EA9525A59");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, "Dispositivo Noto");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "4772B58D-4C2F-43E6-B878-4367DF86F9E1");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "Rimosso");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "747A4903-1C09-4A94-8080-44A7690A59F0");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "Data Ultimo Invio");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "Data dell'invio dell'ultima notifica push");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "71C36A90-02E1-443E-BB25-31F40E9377FF");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "Nota");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "Nota");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "90F31450-CEB4-4B38-A51F-08D592A48B54");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "Data Rimozione");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, "CF3DC807-EB9E-4CAD-BA20-FC062FE50FAB");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, "Reg Url");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, "RegID usato da android");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, "B1C4261E-BF8B-444B-B104-AE3ADE333D5C");
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
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_ID, PPQRY_DEVICETOKEN2, "A.ID", "ID", 1, 9, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, 0, 32, 116, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, 84);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, 4, 28, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_APPLICAZIONE, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_APPLICAZIONE, PPQRY_DEVICETOKEN2, "A.ID_APPLICAZIONE", "ID_APPLICAZIONE", 1, 9, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 116, 32, 88, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, "Dev Token");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 4, 52, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, "Dev Token");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DEVTOKEN, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DEVTOKEN, PPQRY_DEVICETOKEN2, "A.DEV_TOKEN", "DEV_TOKEN", 5, 200, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 204, 32, 108, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, "Dt. Ult. Accesso");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 4, 76, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, "Dt. Ultimo Accesso");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATAULTIACCE, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATAULTIACCE, PPQRY_DEVICETOKEN2, "A.DATA_ULT_ACCESSO", "DATA_ULT_ACCESSO", 8, 61, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 312, 32, 104, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, "Data");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 4, 100, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, "Data");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATA, PPQRY_DEVICETOKEN2, "A.DATA_CREAZIONE", "DATA_CREAZIONE", 8, 61, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 416, 32, 48, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 40);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, "Attivo");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 4, 124, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, "Attivo");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_ATTIVO, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_ATTIVO, PPQRY_DEVICETOKEN2, "A.FLG_ATTIVO", "FLG_ATTIVO", 5, 1, 0, -1709);
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
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_UTENTE, PPQRY_DEVICETOKEN2, "A.DES_UTENTE", "DES_UTENTE", 5, 100, 0, -1709);
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
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DISPOSITNOTO, PPQRY_DEVICETOKEN2, SQL.ToString(), "DISNOTDEVTOK", 9, 1000, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 636, 32, 44, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 48);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, "Rim.");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 4, 172, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, "Rimosso");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_RIMOSSO, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_RIMOSSO, PPQRY_DEVICETOKEN2, "A.FLG_RIMOSSO", "FLG_RIMOSSO", 5, 1, 0, -1709);
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
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATAULTIINVI, PPQRY_DEVICETOKEN2, "A.DAT_ULTIMO_INVIO", "DAT_ULTIMO_INVIO", 8, 19, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 800, 32, 72, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 32);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, "Nota");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 4, 220, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, "Nota");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_NOTA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_NOTA, PPQRY_DEVICETOKEN2, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 872, 32, 96, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 84);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, "Dt. Rimozione");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 4, 244, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, "Data Rimozione");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATARIMOZION, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATARIMOZION, PPQRY_DEVICETOKEN2, "A.DATA_RIMOZ", "DATA_RIMOZ", 8, 61, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_LIST, 0, 512, 532, 76, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_LIST, 52);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_LIST, 4);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_LIST, "Reg Url");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_FORM, 4, 268, 628, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGURL, MyGlb.PANEL_FORM, "Reg Url");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_REGURL, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_REGURL, PPQRY_DEVICETOKEN2, "A.REG_ID", "REG_ID", 5, 200, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, 968, 32, 68, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, 52);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, "Id Lingua");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, 4, 340, 244, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, "Id Lingua");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_IDLINGUA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_IDLINGUA, PPQRY_DEVICETOKEN2, "A.PRG_LINGUA", "PRG_LINGUA", 1, 9, 0, -1709);
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
    SQL.Append("and   (A.TYPE_OS = '3') ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_APPLICAZIONI, 0, SQL, PFL_DEVICETOKEN_APPLICAZIONE, "D37517B9-3CF2-4DCD-ABFC-D773EC58EEDE");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.TYPE_OS = '3') ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_APPLICAZIONI, 1, SQL, PFL_DEVICETOKEN_APPLICAZIONE, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_APPLICAZIONI, MainFrm.NotificatoreDBObject.DB, 256);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.PRG_LINGUA as IDLINGUA, ");
    SQL.Append("  A.DES_LINGUA as DESCRILINGUA ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    SQL.Append("where (A.PRG_LINGUA = ~~PRG_LINGUA~~) ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LINGUE, 0, SQL, PFL_DEVICETOKEN_IDLINGUA, "3BD7EB84-D0BB-4E79-B5B2-F2ADD7D89191");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.PRG_LINGUA as IDLINGUA, ");
    SQL.Append("  A.DES_LINGUA as DESCRILINGUA ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LINGUE, 1, SQL, PFL_DEVICETOKEN_IDLINGUA, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_LINGUE, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DEVICETOKEN.SetIMDB(IMDB, "PQRY_DEVICETOKEN2", true);
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
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN2, 0, SQL, -1, "0ACCB1C5-6349-43A8-98FA-DF301EEE008F");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  DEV_TOKENS A ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN2, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.TYPE_OS = '3') ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN2, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN2, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN2, 4, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("order by ");
    SQL.Append("  A.DATA_ULT_ACCESSO desc ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN2, 5, SQL, -1, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_DEVICETOKEN2, MainFrm.NotificatoreDBObject.DB, 256);
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
