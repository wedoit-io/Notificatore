// **********************************************
// Sales Data
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
public partial class SalesData : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_SALESDATA_PROVIDER = 0;
  private const int PFL_SALESDATA_PROVIDCOUNTR = 1;
  private const int PFL_SALESDATA_BEGINDATE = 2;
  private const int PFL_SALESDATA_ENDDATE = 3;
  private const int PFL_SALESDATA_SKUNUMBER = 4;
  private const int PFL_SALESDATA_DEVELOPER = 5;
  private const int PFL_SALESDATA_TITLE = 6;
  private const int PFL_SALESDATA_VERSION = 7;
  private const int PFL_SALESDATA_PRODTYPEIDEN = 8;
  private const int PFL_SALESDATA_UNITS = 9;
  private const int PFL_SALESDATA_DEVELOPROCEE = 10;
  private const int PFL_SALESDATA_CUSTOMCURREN = 11;
  private const int PFL_SALESDATA_COUNTRYCODE = 12;
  private const int PFL_SALESDATA_CURRENPROCEE = 13;
  private const int PFL_SALESDATA_APPLEIDENTIF = 14;
  private const int PFL_SALESDATA_CUSTOMEPRICE = 15;
  private const int PFL_SALESDATA_PROMOCODE = 16;
  private const int PFL_SALESDATA_PARENTIDENTI = 17;
  private const int PFL_SALESDATA_SUBSFIELVALU = 18;
  private const int PFL_SALESDATA_PERIOD = 19;
  private const int PFL_SALESDATA_ID = 20;

  private const int PPQRY_SALESDATA1 = 0;

  private const int PPQRY_PRODTYPEIDEN = 1;
  private const int PPQRY_CURRENCIES1 = 2;
  private const int PPQRY_COUNTRYCODES = 3;
  private const int PPQRY_CURRENCIES = 4;
  private const int PPQRY_PROMOCODES = 5;


  internal IDPanel PAN_SALESDATA;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_SALESDATA1(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_SALESDATA1(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_SALESDATA1, 21);
    IMDB.set_TblCode(IMDBDef1.PQRY_SALESDATA1, "PQRY_SALESDATA1");
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_PROVIDER, "PROVIDER");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_PROVIDER,5,5,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_PROVIDER_COUNTRY, "PROVIDER_COUNTRY");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_PROVIDER_COUNTRY,5,2,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_SKU_NUMBER, "SKU_NUMBER");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_SKU_NUMBER,5,50,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_DEVELOPER, "DEVELOPER");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_DEVELOPER,5,2000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_TITLE, "TITLE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_TITLE,5,600,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_VERSION, "VERSION");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_VERSION,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_PROD_TYPE_IDENTIFIER, "PROD_TYPE_IDENTIFIER");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_PROD_TYPE_IDENTIFIER,5,20,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_UNITS, "UNITS");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_UNITS,3,18,2);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_DEV_PROCEED, "DEV_PROCEED");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_DEV_PROCEED,3,18,2);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_BEGIN_DATE, "BEGIN_DATE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_BEGIN_DATE,6,52,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_END_DATE, "END_DATE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_END_DATE,6,52,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_CUST_CURRENCY, "CUST_CURRENCY");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_CUST_CURRENCY,5,3,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_COUNTRY_CODE, "COUNTRY_CODE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_COUNTRY_CODE,5,3,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_CURRENCY_PROCEED, "CURRENCY_PROCEED");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_CURRENCY_PROCEED,5,3,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_APPLE_IDENTIFIER, "APPLE_IDENTIFIER");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_APPLE_IDENTIFIER,5,18,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_CUSTOMER_PRICE, "CUSTOMER_PRICE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_CUSTOMER_PRICE,3,18,2);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_CODE, "CODE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_CODE,5,10,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_PARENT_IDENTIFIER, "PARENT_IDENTIFIER");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_PARENT_IDENTIFIER,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_SUBSCRIPTION, "SUBSCRIPTION");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_SUBSCRIPTION,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_PERIOD, "PERIOD");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_PERIOD,5,30,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA1,IMDBDef1.PQSL_SALESDATA1_ID,1,9,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_SALESDATA1, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public SalesData(MyWebEntryPoint w, IMDBObj imdb)
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
  public SalesData()
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
    FormIdx = MyGlb.FRM_SALESDATA;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "67986D73-0FE0-4C11-BBB9-799604CAB11B";
    ResModeW = 1;
    ResModeH = 1;
    iVisualFlags = -2049;
    DesignWidth = 884;
    DesignHeight = 698;
    set_Caption(new IDVariant("Sales Data"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 884;
    Frames[1].Height = 672;
    Frames[1].Caption = "Sales Data";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 672;
    PAN_SALESDATA = new IDPanel(w, this, 1, "PAN_SALESDATA");
    Frames[1].Content = PAN_SALESDATA;
    PAN_SALESDATA.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_SALESDATA.VS = MainFrm.VisualStyleList;
    PAN_SALESDATA.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 884-MyGlb.PAN_OFFS_X, 672-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "680AB4C6-3CE2-4AF9-A7F9-31D3DB9FF4C6");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 1136, 436, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_SALESDATA.InitStatus = 1;
    PAN_SALESDATA_Init();
    PAN_SALESDATA_InitFields();
    PAN_SALESDATA_InitQueries();
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
      PAN_SALESDATA.UpdatePanel(MainFrm);
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
    return (obj is SalesData);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(SalesData).FullName : typeof(SalesData).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	


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
  private void PAN_SALESDATA_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_SALESDATA_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_SALESDATA_ValidateRow(IDVariant Cancel)
  {
    try
    {
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_SALESDATA_Init()
  {

    PAN_SALESDATA.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_SALESDATA.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_SALESDATA.SetSize(MyGlb.OBJ_FIELD, 21);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, "A208DB61-3871-45E5-A6AA-2C189224CA31");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, "Provider");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, "");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, "62461A1D-7DF7-4064-9C9C-B38F5C5A2BAC");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, "Provider Country");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, "The service provider country code will \ntypically be US");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, "C34109ED-3EDA-4447-B4C6-1A75AEA6F6B3");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, "Begin Date");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, "Begin Date");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, "CF39D44E-5F80-46ED-94CA-FCE88658FF94");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, "End Date");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, "End Date");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, "3CDC2C7F-4097-4156-AC36-B613309CE177");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, "Sku Number");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, "\nThis is a product identifier provided by  you when the app is set up ");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, "B50141FF-FB65-4AD6-BD85-CABF66E3A8F9");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, "Developer");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, "You provided this on initial setup\n");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, "C9221DC1-1040-411D-9E47-0AC63BDD9038");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, "Title");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, "\nYou provided this when setting up the app");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, "EEF69935-A560-477B-870A-2D6E8E04F2CC");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, "Version");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, "\nYou provided this when setting up the app");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, "BF741A81-8862-4627-A46B-565674FFC27A");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, "Product Type Identifiers");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, "Identifier");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, MyGlb.VIS_FOREIKEYFIEL);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, "6551D9D4-CA44-4F99-82B3-17138488DC29");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, "Units");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, "");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, "DE68D23F-DE92-423E-8B11-9E0CD6152E7E");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, "Developer Proceed");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, "");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, "DCF6A212-15C1-4D15-B979-64CB9E07345A");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, "Customer Currency");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, "Customer Currency");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, MyGlb.VIS_FOREIKEYFIEL);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, "50E79BBB-E196-45EC-B8CB-75BB0A679BAA");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, "Country Code");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, "Dashboard type identifier");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, MyGlb.VIS_FOREIKEYFIEL);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, "20AA302F-9EA2-4EBC-852D-074749CDC084");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, "Currency Proceed");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, "Dashboard type identifier");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, MyGlb.VIS_FOREIKEYFIEL);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, "6AE04CE3-26DD-4D71-9295-0D2E2F6575BD");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, "Apple Identifier");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, "Apple Identifier");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, "28591EED-0BA4-496A-8567-1AABC2D47B1E");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, "Customer Price");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, "Customer price");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, "7F706750-66C5-46D8-8010-257FF45E3A73");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, "Promo Code");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, "Dashboard type identifier");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, "8C37E4FF-48AF-4C30-A769-17FC73B56242");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, "Parent Identifier");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, "For In-App Purchases this will be populated with the SKU from the originating app");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, "B9AA2674-3594-49FE-B47A-48A4595FB065");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, "Subscription Field Value");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, "Subscription field value");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, "18B3916D-2570-45CE-A2FC-16C669F3FF6F");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, "Period");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, "");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, MyGlb.VIS_NORMALFIELDS);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SALESDATA.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, "57C7AC6D-6D0D-43D9-8A74-70DF076B4B0E");
    PAN_SALESDATA.set_Header(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, "ID");
    PAN_SALESDATA.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, "Identificativo univoco");
    PAN_SALESDATA.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_SALESDATA.SetFlags(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, 0 | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
  }

  private void PAN_SALESDATA_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, MyGlb.PANEL_LIST, 40, 36, 48, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, MyGlb.PANEL_LIST, 48);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, MyGlb.PANEL_LIST, "Provider");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, MyGlb.PANEL_FORM, 188, 4, 120, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, MyGlb.PANEL_FORM, 64);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDER, MyGlb.PANEL_FORM, "Provider");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_PROVIDER, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_PROVIDER, PPQRY_SALESDATA1, "A.PROVIDER", "PROVIDER", 5, 5, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, MyGlb.PANEL_LIST, 88, 36, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, MyGlb.PANEL_LIST, 92);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, MyGlb.PANEL_LIST, "Prov. Coun.");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, MyGlb.PANEL_FORM, 316, 4, 152, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, MyGlb.PANEL_FORM, 104);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROVIDCOUNTR, MyGlb.PANEL_FORM, "Provider Country");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_PROVIDCOUNTR, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_PROVIDCOUNTR, PPQRY_SALESDATA1, "A.PROVIDER_COUNTRY", "PROVIDER_COUNTRY", 5, 2, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, MyGlb.PANEL_LIST, 128, 36, 84, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, MyGlb.PANEL_LIST, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, MyGlb.PANEL_LIST, "Begin Date");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, MyGlb.PANEL_FORM, 4, 244, 276, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_BEGINDATE, MyGlb.PANEL_FORM, "Begin Date");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_BEGINDATE, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_BEGINDATE, PPQRY_SALESDATA1, "A.BEGIN_DATE", "BEGIN_DATE", 6, 52, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, MyGlb.PANEL_LIST, 212, 36, 84, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, MyGlb.PANEL_LIST, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, MyGlb.PANEL_LIST, "End Date");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, MyGlb.PANEL_FORM, 4, 268, 276, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_ENDDATE, MyGlb.PANEL_FORM, "End Date");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_ENDDATE, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_ENDDATE, PPQRY_SALESDATA1, "A.END_DATE", "END_DATE", 6, 52, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, MyGlb.PANEL_LIST, 296, 36, 92, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, MyGlb.PANEL_LIST, 68);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, MyGlb.PANEL_LIST, "Sku Number");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, MyGlb.PANEL_FORM, 4, 28, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_SKUNUMBER, MyGlb.PANEL_FORM, "Sku Number");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_SKUNUMBER, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_SKUNUMBER, PPQRY_SALESDATA1, "A.SKU_NUMBER", "SKU_NUMBER", 5, 50, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, MyGlb.PANEL_LIST, 4, 520, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, MyGlb.PANEL_LIST, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, MyGlb.PANEL_LIST, "Developer");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, MyGlb.PANEL_FORM, 4, 52, 528, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, MyGlb.PANEL_FORM, 2);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPER, MyGlb.PANEL_FORM, "Developer");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_DEVELOPER, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_DEVELOPER, PPQRY_SALESDATA1, "A.DEVELOPER", "DEVELOPER", 5, 2000, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, MyGlb.PANEL_LIST, 4, 472, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, MyGlb.PANEL_LIST, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, MyGlb.PANEL_LIST, "Title");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, MyGlb.PANEL_FORM, 4, 100, 528, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, MyGlb.PANEL_FORM, 2);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_TITLE, MyGlb.PANEL_FORM, "Title");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_TITLE, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_TITLE, PPQRY_SALESDATA1, "A.TITLE", "TITLE", 5, 600, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, MyGlb.PANEL_LIST, 4, 496, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, MyGlb.PANEL_LIST, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, MyGlb.PANEL_LIST, "Version");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, MyGlb.PANEL_FORM, 4, 148, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_VERSION, MyGlb.PANEL_FORM, "Version");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_VERSION, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_VERSION, PPQRY_SALESDATA1, "A.VERSION", "VERSION", 5, 100, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, MyGlb.PANEL_LIST, 388, 36, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, MyGlb.PANEL_LIST, 124);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, MyGlb.PANEL_LIST, "Product Type Identifiers");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, MyGlb.PANEL_FORM, 4, 172, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_PRODTYPEIDEN, MyGlb.PANEL_FORM, "Product Type Identifiers");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_PRODTYPEIDEN, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_PRODTYPEIDEN, PPQRY_SALESDATA1, "A.PROD_TYPE_IDENTIFIER", "PROD_TYPE_IDENTIFIER", 5, 20, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, MyGlb.PANEL_LIST, 492, 36, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, MyGlb.PANEL_LIST, 32);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, MyGlb.PANEL_LIST, "Units");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, MyGlb.PANEL_FORM, 4, 196, 280, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_UNITS, MyGlb.PANEL_FORM, "Units");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_UNITS, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_UNITS, PPQRY_SALESDATA1, "A.UNITS", "UNITS", 3, 18, 2, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, MyGlb.PANEL_LIST, 548, 36, 108, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, MyGlb.PANEL_LIST, 100);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, MyGlb.PANEL_LIST, "Developer Proceed");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, MyGlb.PANEL_FORM, 4, 220, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_DEVELOPROCEE, MyGlb.PANEL_FORM, "Developer Proceed");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_DEVELOPROCEE, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_DEVELOPROCEE, PPQRY_SALESDATA1, "A.DEV_PROCEED", "DEV_PROCEED", 3, 18, 2, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, MyGlb.PANEL_LIST, 656, 36, 60, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, MyGlb.PANEL_LIST, 104);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, MyGlb.PANEL_LIST, "Customer Currency");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, MyGlb.PANEL_FORM, 4, 292, 276, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMCURREN, MyGlb.PANEL_FORM, "Customer Currency");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_CUSTOMCURREN, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_CUSTOMCURREN, PPQRY_SALESDATA1, "A.CUST_CURRENCY", "CUST_CURRENCY", 5, 3, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, MyGlb.PANEL_LIST, 716, 36, 64, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, MyGlb.PANEL_LIST, 76);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, MyGlb.PANEL_LIST, "Country Code");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, MyGlb.PANEL_FORM, 4, 316, 276, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_COUNTRYCODE, MyGlb.PANEL_FORM, "Country Code");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_COUNTRYCODE, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_COUNTRYCODE, PPQRY_SALESDATA1, "A.COUNTRY_CODE", "COUNTRY_CODE", 5, 3, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, MyGlb.PANEL_LIST, 780, 36, 68, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, MyGlb.PANEL_LIST, 96);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, MyGlb.PANEL_LIST, "Currency Proceed");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, MyGlb.PANEL_FORM, 4, 340, 276, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_CURRENPROCEE, MyGlb.PANEL_FORM, "Currency Proceed");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_CURRENPROCEE, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_CURRENPROCEE, PPQRY_SALESDATA1, "A.CURRENCY_PROCEED", "CURRENCY_PROCEED", 5, 3, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, MyGlb.PANEL_LIST, 848, 36, 80, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, MyGlb.PANEL_LIST, 84);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, MyGlb.PANEL_LIST, "Apple Identifier");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, MyGlb.PANEL_FORM, 4, 364, 276, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_APPLEIDENTIF, MyGlb.PANEL_FORM, "Apple Identifier");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_APPLEIDENTIF, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_APPLEIDENTIF, PPQRY_SALESDATA1, "A.APPLE_IDENTIFIER", "APPLE_IDENTIFIER", 5, 18, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, MyGlb.PANEL_LIST, 928, 36, 72, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, MyGlb.PANEL_LIST, 80);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, MyGlb.PANEL_LIST, "Customer Price");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, MyGlb.PANEL_FORM, 4, 388, 276, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_CUSTOMEPRICE, MyGlb.PANEL_FORM, "Customer Price");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_CUSTOMEPRICE, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_CUSTOMEPRICE, PPQRY_SALESDATA1, "A.CUSTOMER_PRICE", "CUSTOMER_PRICE", 3, 18, 2, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, MyGlb.PANEL_LIST, 1000, 36, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, MyGlb.PANEL_LIST, 68);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, MyGlb.PANEL_LIST, "Promo Code");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, MyGlb.PANEL_FORM, 4, 412, 276, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_PROMOCODE, MyGlb.PANEL_FORM, "Promo Code");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_PROMOCODE, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_PROMOCODE, PPQRY_SALESDATA1, "A.CODE", "CODE", 5, 10, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, MyGlb.PANEL_LIST, 4, 544, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, MyGlb.PANEL_LIST, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, MyGlb.PANEL_LIST, "Parent Identifier");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, MyGlb.PANEL_FORM, 4, 436, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_PARENTIDENTI, MyGlb.PANEL_FORM, "Parent Identifier");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_PARENTIDENTI, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_PARENTIDENTI, PPQRY_SALESDATA1, "A.PARENT_IDENTIFIER", "PARENT_IDENTIFIER", 5, 100, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, MyGlb.PANEL_LIST, 4, 568, 528, 24, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, MyGlb.PANEL_LIST, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, MyGlb.PANEL_LIST, "Subscription Field Value");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, MyGlb.PANEL_FORM, 4, 460, 528, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, MyGlb.PANEL_FORM, 2);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_SUBSFIELVALU, MyGlb.PANEL_FORM, "Subscription Field Value");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_SUBSFIELVALU, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_SUBSFIELVALU, PPQRY_SALESDATA1, "A.SUBSCRIPTION", "SUBSCRIPTION", 5, 200, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, MyGlb.PANEL_LIST, 1040, 36, 136, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, MyGlb.PANEL_LIST, 40);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, MyGlb.PANEL_LIST, "Period");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, MyGlb.PANEL_FORM, 4, 496, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, MyGlb.PANEL_FORM, 128);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_PERIOD, MyGlb.PANEL_FORM, "Period");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_PERIOD, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_PERIOD, PPQRY_SALESDATA1, "A.PERIOD", "PERIOD", 5, 30, 0, -685);
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, MyGlb.PANEL_LIST, 0, 36, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, MyGlb.PANEL_LIST, 20);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, MyGlb.PANEL_LIST, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, MyGlb.PANEL_LIST, "ID");
    PAN_SALESDATA.SetRect(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, MyGlb.PANEL_FORM, 4, 520, 80, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SALESDATA.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, MyGlb.PANEL_FORM, 20);
    PAN_SALESDATA.SetNumRow(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, MyGlb.PANEL_FORM, 1);
    PAN_SALESDATA.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SALESDATA_ID, MyGlb.PANEL_FORM, "ID");
    PAN_SALESDATA.SetFieldPage(PFL_SALESDATA_ID, -1, -1);
    PAN_SALESDATA.SetFieldPanel(PFL_SALESDATA_ID, PPQRY_SALESDATA1, "A.ID", "ID", 1, 9, 0, -685);
  }

  private void PAN_SALESDATA_InitQueries()
  {
    StringBuilder SQL;

    PAN_SALESDATA.SetSize(MyGlb.OBJ_QUERY, 6);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.IDENTIFIER as IDEPROTYPIDE, ");
    SQL.Append("  A.DESCRIPTION as DESPROTYPIDE ");
    SQL.Append("from ");
    SQL.Append("  APPLE_PROD_TYPES_IDENT A ");
    SQL.Append("where (A.IDENTIFIER = ~~PROD_TYPE_IDENTIFIER~~) ");
    PAN_SALESDATA.SetQuery(PPQRY_PRODTYPEIDEN, 0, SQL, PFL_SALESDATA_PRODTYPEIDEN, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.IDENTIFIER as IDEPROTYPIDE, ");
    SQL.Append("  A.DESCRIPTION as DESPROTYPIDE ");
    SQL.Append("from ");
    SQL.Append("  APPLE_PROD_TYPES_IDENT A ");
    PAN_SALESDATA.SetQuery(PPQRY_PRODTYPEIDEN, 1, SQL, PFL_SALESDATA_PRODTYPEIDEN, "");
    PAN_SALESDATA.SetQueryDB(PPQRY_PRODTYPEIDEN, MainFrm.NotificatoreDBObject.DB, 2048);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.CODE as CODECURRENCY, ");
    SQL.Append("  A.DESCRIPTION as DESCRICURREN ");
    SQL.Append("from ");
    SQL.Append("  APPLE_CURRENCY_CODES A ");
    SQL.Append("where (A.CODE = ~~CUST_CURRENCY~~) ");
    SQL.Append("order by ");
    SQL.Append("  A.DESCRIPTION ");
    PAN_SALESDATA.SetQuery(PPQRY_CURRENCIES1, 0, SQL, PFL_SALESDATA_CUSTOMCURREN, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.CODE as CODECURRENCY, ");
    SQL.Append("  A.DESCRIPTION as DESCRICURREN ");
    SQL.Append("from ");
    SQL.Append("  APPLE_CURRENCY_CODES A ");
    SQL.Append("order by ");
    SQL.Append("  A.DESCRIPTION ");
    PAN_SALESDATA.SetQuery(PPQRY_CURRENCIES1, 1, SQL, PFL_SALESDATA_CUSTOMCURREN, "");
    PAN_SALESDATA.SetQueryDB(PPQRY_CURRENCIES1, MainFrm.NotificatoreDBObject.DB, 2048);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.CODE as CODECOUNCODE, ");
    SQL.Append("  A.DESCRIPTION as NAMECOUNCODE ");
    SQL.Append("from ");
    SQL.Append("  APPLE_COUNTRY_CODE A ");
    SQL.Append("where (A.CODE = ~~COUNTRY_CODE~~) ");
    SQL.Append("order by ");
    SQL.Append("  A.DESCRIPTION ");
    PAN_SALESDATA.SetQuery(PPQRY_COUNTRYCODES, 0, SQL, PFL_SALESDATA_COUNTRYCODE, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.CODE as CODECOUNCODE, ");
    SQL.Append("  A.DESCRIPTION as NAMECOUNCODE ");
    SQL.Append("from ");
    SQL.Append("  APPLE_COUNTRY_CODE A ");
    SQL.Append("order by ");
    SQL.Append("  A.DESCRIPTION ");
    PAN_SALESDATA.SetQuery(PPQRY_COUNTRYCODES, 1, SQL, PFL_SALESDATA_COUNTRYCODE, "");
    PAN_SALESDATA.SetQueryDB(PPQRY_COUNTRYCODES, MainFrm.NotificatoreDBObject.DB, 2048);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.CODE as CODECURRENCY, ");
    SQL.Append("  A.DESCRIPTION as DESCRICURREN ");
    SQL.Append("from ");
    SQL.Append("  APPLE_CURRENCY_CODES A ");
    SQL.Append("where (A.CODE = ~~CURRENCY_PROCEED~~) ");
    SQL.Append("order by ");
    SQL.Append("  A.DESCRIPTION ");
    PAN_SALESDATA.SetQuery(PPQRY_CURRENCIES, 0, SQL, PFL_SALESDATA_CURRENPROCEE, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.CODE as CODECURRENCY, ");
    SQL.Append("  A.DESCRIPTION as DESCRICURREN ");
    SQL.Append("from ");
    SQL.Append("  APPLE_CURRENCY_CODES A ");
    SQL.Append("order by ");
    SQL.Append("  A.DESCRIPTION ");
    PAN_SALESDATA.SetQuery(PPQRY_CURRENCIES, 1, SQL, PFL_SALESDATA_CURRENPROCEE, "");
    PAN_SALESDATA.SetQueryDB(PPQRY_CURRENCIES, MainFrm.NotificatoreDBObject.DB, 2048);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.CODE as CODEPROMCODE, ");
    SQL.Append("  A.DESCRIPTION as DESCPROMCODE ");
    SQL.Append("from ");
    SQL.Append("  APPLE_PROMO_CODE A ");
    SQL.Append("where (A.CODE = ~~CODE~~) ");
    SQL.Append("order by ");
    SQL.Append("  A.DESCRIPTION ");
    PAN_SALESDATA.SetQuery(PPQRY_PROMOCODES, 0, SQL, PFL_SALESDATA_PROMOCODE, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.CODE as CODEPROMCODE, ");
    SQL.Append("  A.DESCRIPTION as DESCPROMCODE ");
    SQL.Append("from ");
    SQL.Append("  APPLE_PROMO_CODE A ");
    SQL.Append("order by ");
    SQL.Append("  A.DESCRIPTION ");
    PAN_SALESDATA.SetQuery(PPQRY_PROMOCODES, 1, SQL, PFL_SALESDATA_PROMOCODE, "");
    PAN_SALESDATA.SetQueryDB(PPQRY_PROMOCODES, MainFrm.NotificatoreDBObject.DB, 2048);
    PAN_SALESDATA.SetIMDB(IMDB, "PQRY_SALESDATA1", true);
    PAN_SALESDATA.set_SetString(MyGlb.MASTER_ROWNAME, "Sales Data");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.PROVIDER as PROVIDER, ");
    SQL.Append("  A.PROVIDER_COUNTRY as PROVIDER_COUNTRY, ");
    SQL.Append("  A.SKU_NUMBER as SKU_NUMBER, ");
    SQL.Append("  A.DEVELOPER as DEVELOPER, ");
    SQL.Append("  A.TITLE as TITLE, ");
    SQL.Append("  A.VERSION as VERSION, ");
    SQL.Append("  A.PROD_TYPE_IDENTIFIER as PROD_TYPE_IDENTIFIER, ");
    SQL.Append("  A.UNITS as UNITS, ");
    SQL.Append("  A.DEV_PROCEED as DEV_PROCEED, ");
    SQL.Append("  A.BEGIN_DATE as BEGIN_DATE, ");
    SQL.Append("  A.END_DATE as END_DATE, ");
    SQL.Append("  A.CUST_CURRENCY as CUST_CURRENCY, ");
    SQL.Append("  A.COUNTRY_CODE as COUNTRY_CODE, ");
    SQL.Append("  A.CURRENCY_PROCEED as CURRENCY_PROCEED, ");
    SQL.Append("  A.APPLE_IDENTIFIER as APPLE_IDENTIFIER, ");
    SQL.Append("  A.CUSTOMER_PRICE as CUSTOMER_PRICE, ");
    SQL.Append("  A.CODE as CODE, ");
    SQL.Append("  A.PARENT_IDENTIFIER as PARENT_IDENTIFIER, ");
    SQL.Append("  A.SUBSCRIPTION as SUBSCRIPTION, ");
    SQL.Append("  A.PERIOD as PERIOD, ");
    SQL.Append("  A.ID as ID ");
    PAN_SALESDATA.SetQuery(PPQRY_SALESDATA1, 0, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  APPLE_SALES_DATA A ");
    PAN_SALESDATA.SetQuery(PPQRY_SALESDATA1, 1, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SALESDATA.SetQuery(PPQRY_SALESDATA1, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SALESDATA.SetQuery(PPQRY_SALESDATA1, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SALESDATA.SetQuery(PPQRY_SALESDATA1, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SALESDATA.SetQuery(PPQRY_SALESDATA1, 5, SQL, -1, "");
    PAN_SALESDATA.SetQueryDB(PPQRY_SALESDATA1, MainFrm.NotificatoreDBObject.DB, 2048);
    PAN_SALESDATA.SetMasterTable(0, "APPLE_SALES_DATA");
    SQL = new StringBuilder("select APPLE_SALES_DATA_ID.NextVal from dual");
    PAN_SALESDATA.SetQuery(0, -1, SQL, PFL_SALESDATA_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_SALESDATA) PAN_SALESDATA_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_SALESDATA) PAN_SALESDATA_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_SALESDATA) PAN_SALESDATA_CellActivated(ColIndex, Cancel);
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
