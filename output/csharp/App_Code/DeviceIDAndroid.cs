// **********************************************
// Device ID Android
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
public partial class DeviceIDAndroid : MyWebForm
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
  private const int PFL_DEVICETOKEN_LINGUA = 8;
  private const int PFL_DEVICETOKEN_RIMOSSO = 9;
  private const int PFL_DEVICETOKEN_DATAULTIINVI = 10;
  private const int PFL_DEVICETOKEN_DATARIMOZION = 11;
  private const int PFL_DEVICETOKEN_NOTA = 12;
  private const int PFL_DEVICETOKEN_CUSTOMTAG = 13;
  private const int PFL_DEVICETOKEN_REGID = 14;

  private const int PPQRY_DEVICETOKEN3 = 0;

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
    Init_PQRY_DEVICETOKEN3(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_DEVICETOKEN3(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DEVICETOKEN3, 15);
    IMDB.set_TblCode(IMDBDef1.PQRY_DEVICETOKEN3, "PQRY_DEVICETOKEN3");
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DEV_TOKEN, "DEV_TOKEN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DEV_TOKEN,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DATA_ULT_ACCESSO, "DATA_ULT_ACCESSO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DATA_ULT_ACCESSO,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DATA_CREAZIONE, "DATA_CREAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DATA_CREAZIONE,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_FLG_ATTIVO, "FLG_ATTIVO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_FLG_ATTIVO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_FLG_RIMOSSO, "FLG_RIMOSSO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_FLG_RIMOSSO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DAT_ULTIMO_INVIO, "DAT_ULTIMO_INVIO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DAT_ULTIMO_INVIO,8,19,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_ID_APPLICAZIONE, "ID_APPLICAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_ID_APPLICAZIONE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DATA_RIMOZ, "DATA_RIMOZ");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DATA_RIMOZ,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_REG_ID, "REG_ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_REG_ID,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_CUSTOM_TAG, "CUSTOM_TAG");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_CUSTOM_TAG,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DISNOTDEVTOK, "DISNOTDEVTOK");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_DISNOTDEVTOK,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_PRG_LINGUA, "PRG_LINGUA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN3,IMDBDef1.PQSL_DEVICETOKEN3_PRG_LINGUA,1,9,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_DEVICETOKEN3, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public DeviceIDAndroid(MyWebEntryPoint w, IMDBObj imdb)
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
  public DeviceIDAndroid()
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
    FormIdx = MyGlb.FRM_DEVICIDANDRO;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "DC9FCE05-49AF-4357-8C6E-3B2D5CFE3752";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 1124;
    DesignHeight = 646;
    set_Caption(new IDVariant("Device ID Android"));
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
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "75505970-740C-4D47-8736-4E99BF1E59BA");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 1040, 496, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
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
    if (CmdIdx==MyGlb.CMD_INVIOMANUAL4+BaseCmdLinIdx)
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
    return (obj is DeviceIDAndroid);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(DeviceIDAndroid).FullName : typeof(DeviceIDAndroid).Name);
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
      // 
      // Device Token On Dynamic Properties Body
      // Corpo Procedura
      // 
      if ((new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATA))).equals((new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATAULTIACCE))), true))
      {
        PAN_DEVICETOKEN.set_VisualStyle(Glb.OBJ_FIELD,PFL_DEVICETOKEN_DATAULTIACCE,new IDVariant(MyGlb.VIS_SFONDOGIALLO).intValue()); 
      }
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("DeviceIDAndroid", "DeviceTokenOnDynamicProperties", _e);
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
      // 
      // Invio Manuale Body
      // Corpo Procedura
      // 
      IDVariant v_VGOAPBRIDAPS = new IDVariant(0,IDVariant.STRING);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.GOOGLE_API_ID as GOAPBRIDAPPS ");
      SQL.Append("from ");
      SQL.Append("  APPS_PUSH_SETTING A, ");
      SQL.Append("  APPS B ");
      SQL.Append("where B.ID = A.ID_APP ");
      SQL.Append("and   (A.TYPE_OS = '2') ");
      SQL.Append("and   (A.ID = " + IDL.CSql(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN3, IMDBDef1.PQSL_DEVICETOKEN3_ID_APPLICAZIONE, 0), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      if (!QV.EOF())
      {
        v_VGOAPBRIDAPS = QV.Get("GOAPBRIDAPPS", IDVariant.STRING) ;
      }
      QV.Close();
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI1, IMDBDef1.FLD_PARAMETRI1_GOOGLE_API_ID, 0, new IDVariant(v_VGOAPBRIDAPS));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI1, IMDBDef1.FLD_PARAMETRI1_REG_ID, 0, IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN3, IMDBDef1.PQSL_DEVICETOKEN3_REG_ID, 0));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI1, IMDBDef1.FLD_PARAMETRI1_DEV_TOKEN, 0, IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN3, IMDBDef1.PQSL_DEVICETOKEN3_DEV_TOKEN, 0));
      IMDB.set_Value(IMDBDef1.TBL_PARAMETRI1, IMDBDef1.FLD_PARAMETRI1_ID_APPLICAZIONE, 0, IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN3, IMDBDef1.PQSL_DEVICETOKEN3_ID_APPLICAZIONE, 0));
      MainFrm.Show(MyGlb.FRM_INVIOGMCMANU, (new IDVariant(0)).intValue(), this); 
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("DeviceIDAndroid", "InvioManuale", _e);
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
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN3, IMDBDef1.PQSL_DEVICETOKEN3_DATA_ULT_ACCESSO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN3, IMDBDef1.PQSL_DEVICETOKEN3_DATA_ULT_ACCESSO, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN3, IMDBDef1.PQSL_DEVICETOKEN3_DATA_CREAZIONE, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN3, IMDBDef1.PQSL_DEVICETOKEN3_DATA_CREAZIONE, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN3, IMDBDef1.PQSL_DEVICETOKEN3_FLG_ATTIVO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN3, IMDBDef1.PQSL_DEVICETOKEN3_FLG_ATTIVO, 0, (new IDVariant("S")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN3, IMDBDef1.PQSL_DEVICETOKEN3_FLG_RIMOSSO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN3, IMDBDef1.PQSL_DEVICETOKEN3_FLG_RIMOSSO, 0, (new IDVariant("N")));
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
    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_FIELD, 15);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "72CAC0CA-F6C6-4236-95DF-77D565AB39FA");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "ID");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "Identificativo univoco");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, 0 | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, "27C2A86D-A591-47DF-84CA-F7B2751D624D");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, "Applicazione");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, "Identificativo univoco");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.VIS_FOREIKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "0F5C1AE9-40B0-43EF-8702-3753B32454CE");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "Dev Token");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "02865471-E1A4-4330-9811-7F58F717FC71");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "Data Ultimo Accesso");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "82B732EC-FD4B-40E5-83BF-AF697089B1B2");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "Data");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "015A9F64-AFC5-4E95-83F2-6764F382ACF0");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "Attivo");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "2D955AC6-1AEF-45F0-83EC-A6D6A238446C");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "Utente");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, "3E20D83D-0B32-4307-BF46-13755F34C541");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, "Dispositivo Noto");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, "8D991101-23C1-4B80-81CE-523414EF93F5");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, "Lingua");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, MyGlb.VIS_FOREIKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "0006A3E0-4DF3-487D-9249-59912E5F737F");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "Rimosso");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "0A992246-2483-4398-AEFB-2768A6B961F5");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "Data Ultimo Invio");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "Data dell'invio dell'ultima notifica push");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "9962CA90-DD02-47E1-A562-B926AEAE9231");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "Data Rimozione");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "BDE9764F-C26C-47CE-BC23-19C416341B26");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "Nota");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "Nota");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, "B2407A7A-368D-40EE-A00C-055EA360530D");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, "Custom TAG");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, "Custom TAG");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, "F24A0040-7C6C-4E0A-834E-F06376005C9C");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, "Regid");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, "RegID usato da android");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_DEVICETOKEN_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 0, 36, 68, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 20);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, "ID");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 4, 4, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, "ID");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_ID, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_ID, PPQRY_DEVICETOKEN3, "A.ID", "ID", 1, 9, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, 0, 36, 116, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, 84);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, 4, 28, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_APPLICAZIONE, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_APPLICAZIONE, PPQRY_DEVICETOKEN3, "A.ID_APPLICAZIONE", "ID_APPLICAZIONE", 1, 9, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 116, 36, 120, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, "Dev Token");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 4, 52, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, "Dev Token");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DEVTOKEN, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DEVTOKEN, PPQRY_DEVICETOKEN3, "A.DEV_TOKEN", "DEV_TOKEN", 5, 200, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 236, 36, 108, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, "Data Ultimo Accesso");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 4, 76, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, "Data Ultimo Accesso");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATAULTIACCE, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATAULTIACCE, PPQRY_DEVICETOKEN3, "A.DATA_ULT_ACCESSO", "DATA_ULT_ACCESSO", 8, 61, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 344, 36, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, "Data");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 4, 100, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, "Data");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATA, PPQRY_DEVICETOKEN3, "A.DATA_CREAZIONE", "DATA_CREAZIONE", 8, 61, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 448, 36, 48, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 40);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, "Attivo");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 4, 124, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, "Attivo");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_ATTIVO, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_ATTIVO, PPQRY_DEVICETOKEN3, "A.FLG_ATTIVO", "FLG_ATTIVO", 5, 1, 0, -685);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_ATTIVO, (new IDVariant("S")), "Si", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_ATTIVO, (new IDVariant("N")), "No", "", "", -1);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 496, 36, 88, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 44);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, "Utente");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 4, 148, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, "Utente");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_UTENTE, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_UTENTE, PPQRY_DEVICETOKEN3, "A.DES_UTENTE", "DES_UTENTE", 5, 100, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTO, MyGlb.PANEL_LIST, 584, 36, 128, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
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
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DISPOSITNOTO, PPQRY_DEVICETOKEN3, SQL.ToString(), "DISNOTDEVTOK", 9, 1000, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, MyGlb.PANEL_LIST, 712, 36, 68, 20, MyGlb.RESMODE_MOVE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, MyGlb.PANEL_LIST, 52);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, MyGlb.PANEL_LIST, "Lingua");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, MyGlb.PANEL_FORM, 4, 340, 280, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_LINGUA, MyGlb.PANEL_FORM, "Lingua");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_LINGUA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_LINGUA, PPQRY_DEVICETOKEN3, "A.PRG_LINGUA", "PRG_LINGUA", 1, 9, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 780, 36, 44, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 48);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, "Rim.");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 4, 172, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, "Rimosso");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_RIMOSSO, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_RIMOSSO, PPQRY_DEVICETOKEN3, "A.FLG_RIMOSSO", "FLG_RIMOSSO", 5, 1, 0, -685);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_RIMOSSO, (new IDVariant("N")), "No", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_RIMOSSO, (new IDVariant("S")), "Si", "", "", -1);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, 824, 36, 120, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, 92);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, "Data Ultimo Invio");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, 4, 196, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, "Data Ultimo Invio");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATAULTIINVI, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATAULTIINVI, PPQRY_DEVICETOKEN3, "A.DAT_ULTIMO_INVIO", "DAT_ULTIMO_INVIO", 8, 19, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 944, 36, 96, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 84);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, "Data Rimozione");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 4, 244, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, "Data Rimozione");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATARIMOZION, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATARIMOZION, PPQRY_DEVICETOKEN3, "A.DATA_RIMOZ", "DATA_RIMOZ", 8, 61, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 532, 508, 432, 20, MyGlb.RESMODE_MOVE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 68);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, "Nota");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 4, 220, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, "Nota");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_NOTA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_NOTA, PPQRY_DEVICETOKEN3, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_LIST, 532, 544, 432, 20, MyGlb.RESMODE_MOVE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_LIST, 68);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_LIST, "Custom TAG");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_FORM, 4, 292, 628, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_FORM, "Custom TAG");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_CUSTOMTAG, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_CUSTOMTAG, PPQRY_DEVICETOKEN3, "A.CUSTOM_TAG", "CUSTOM_TAG", 5, 200, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_LIST, 0, 512, 520, 52, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_LIST, 52);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_LIST, 3);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_LIST, "Regid");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_FORM, 4, 268, 628, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_FORM, "Regid");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_REGID, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_REGID, PPQRY_DEVICETOKEN3, "A.REG_ID", "REG_ID", 5, 200, 0, -685);
  }

  private void PAN_DEVICETOKEN_InitQueries()
  {
    StringBuilder SQL;

    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_QUERY, 3);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPLICAZIO, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.ID = ~~ID_APPLICAZIONE~~) ");
    SQL.Append("and   (A.TYPE_OS = '2') ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_APPLICAZIONI, 0, SQL, PFL_DEVICETOKEN_APPLICAZIONE, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPLICAZIO, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.TYPE_OS = '2') ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_APPLICAZIONI, 1, SQL, PFL_DEVICETOKEN_APPLICAZIONE, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_APPLICAZIONI, MainFrm.NotificatoreDBObject.DB, 2048);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.PRG_LINGUA as IDLINGUA, ");
    SQL.Append("  A.DES_LINGUA as DESCRILINGUA ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    SQL.Append("where (A.PRG_LINGUA = ~~PRG_LINGUA~~) ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LINGUE, 0, SQL, PFL_DEVICETOKEN_LINGUA, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.PRG_LINGUA as IDLINGUA, ");
    SQL.Append("  A.DES_LINGUA as DESCRILINGUA ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LINGUE, 1, SQL, PFL_DEVICETOKEN_LINGUA, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_LINGUE, MainFrm.NotificatoreDBObject.DB, 2048);
    PAN_DEVICETOKEN.SetIMDB(IMDB, "PQRY_DEVICETOKEN3", true);
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
    SQL.Append("  A.CUSTOM_TAG as CUSTOM_TAG, ");
    SQL.Append("  ( ");
    SQL.Append("select ");
    SQL.Append("  B.DES_MESSAGGIO ");
    SQL.Append("from ");
    SQL.Append("  DISPOSITIVI_NOTI B ");
    SQL.Append("where (B.DEV_TOKEN = A.DEV_TOKEN) ");
    SQL.Append(") as DISNOTDEVTOK, ");
    SQL.Append("  A.PRG_LINGUA as PRG_LINGUA ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN3, 0, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  DEV_TOKENS A ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN3, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.TYPE_OS = '2') ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN3, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN3, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN3, 4, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("order by ");
    SQL.Append("  A.DATA_ULT_ACCESSO desc ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN3, 5, SQL, -1, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_DEVICETOKEN3, MainFrm.NotificatoreDBObject.DB, 2048);
    PAN_DEVICETOKEN.SetMasterTable(0, "DEV_TOKENS");
    PAN_DEVICETOKEN.AddToSortList(PFL_DEVICETOKEN_DATAULTIACCE, false);
    SQL = new StringBuilder("select DEV_TOKENS_ID.NextVal from dual");
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
