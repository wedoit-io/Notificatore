// **********************************************
// Dispositivi Noti
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
public partial class DispositiviNoti : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_DISPOSITNOTI_ID = 0;
  private const int PFL_DISPOSITNOTI_NOME = 1;
  private const int PFL_DISPOSITNOTI_DEVICETOKEN = 2;
  private const int PFL_DISPOSITNOTI_TYPEOS = 3;

  private const int PPQRY_DISPONOTIIOS = 0;


  internal IDPanel PAN_DISPOSITNOTI;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_DISPONOTIIOS(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_DISPONOTIIOS(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DISPONOTIIOS, 4);
    IMDB.set_TblCode(IMDBDef1.PQRY_DISPONOTIIOS, "PQRY_DISPONOTIIOS");
    IMDB.set_FldCode(IMDBDef1.PQRY_DISPONOTIIOS,IMDBDef1.PQSL_DISPONOTIIOS_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DISPONOTIIOS,IMDBDef1.PQSL_DISPONOTIIOS_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DISPONOTIIOS,IMDBDef1.PQSL_DISPONOTIIOS_DES_MESSAGGIO, "DES_MESSAGGIO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DISPONOTIIOS,IMDBDef1.PQSL_DISPONOTIIOS_DES_MESSAGGIO,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DISPONOTIIOS,IMDBDef1.PQSL_DISPONOTIIOS_DEV_TOKEN, "DEV_TOKEN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DISPONOTIIOS,IMDBDef1.PQSL_DISPONOTIIOS_DEV_TOKEN,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DISPONOTIIOS,IMDBDef1.PQSL_DISPONOTIIOS_TYPE_OS, "TYPE_OS");
    IMDB.SetFldParams(IMDBDef1.PQRY_DISPONOTIIOS,IMDBDef1.PQSL_DISPONOTIIOS_TYPE_OS,5,1,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_DISPONOTIIOS, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public DispositiviNoti(MyWebEntryPoint w, IMDBObj imdb)
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
  public DispositiviNoti()
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
    FormIdx = MyGlb.FRM_DISPOSITNOTI;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "1FE50B1B-6210-41F5-A7B5-787950C3865D";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 752;
    DesignHeight = 532;
    set_Caption(new IDVariant("Dispositivi Noti"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 752;
    Frames[1].Height = 472;
    Frames[1].Caption = "Dispositivi Noti";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 472;
    PAN_DISPOSITNOTI = new IDPanel(w, this, 1, "PAN_DISPOSITNOTI");
    Frames[1].Content = PAN_DISPOSITNOTI;
    PAN_DISPOSITNOTI.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_DISPOSITNOTI.VS = MainFrm.VisualStyleList;
    PAN_DISPOSITNOTI.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 752-MyGlb.PAN_OFFS_X, 472-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_DISPOSITNOTI.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "D8BDC1B0-D282-425F-A277-A02DA4B8AB56");
    PAN_DISPOSITNOTI.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 708, 416, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_DISPOSITNOTI.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_DISPOSITNOTI.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_DISPOSITNOTI.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_DISPOSITNOTI.InitStatus = 2;
    PAN_DISPOSITNOTI_Init();
    PAN_DISPOSITNOTI_InitFields();
    PAN_DISPOSITNOTI_InitQueries();
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
      PAN_DISPOSITNOTI.UpdatePanel(MainFrm);
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
    return (obj is DispositiviNoti);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(DispositiviNoti).FullName : typeof(DispositiviNoti).Name);
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
  private void PAN_DISPOSITNOTI_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_DISPOSITNOTI_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_DISPOSITNOTI_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DISPONOTIIOS, IMDBDef1.PQSL_DISPONOTIIOS_TYPE_OS, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DISPONOTIIOS, IMDBDef1.PQSL_DISPONOTIIOS_TYPE_OS, 0, (new IDVariant("1")));
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_DISPOSITNOTI_Init()
  {

    PAN_DISPOSITNOTI.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_DISPOSITNOTI.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_DISPOSITNOTI.SetSize(MyGlb.OBJ_FIELD, 4);
    PAN_DISPOSITNOTI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, "F285C43E-8264-4636-96AB-3D7DEBCA1AFF");
    PAN_DISPOSITNOTI.set_Header(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, "ID");
    PAN_DISPOSITNOTI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, "Identificativo univoco");
    PAN_DISPOSITNOTI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_DISPOSITNOTI.SetFlags(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_DISPOSITNOTI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, "CFFFE1A8-F87C-4E11-8791-5C9186BC58D6");
    PAN_DISPOSITNOTI.set_Header(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, "Nome");
    PAN_DISPOSITNOTI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, "");
    PAN_DISPOSITNOTI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, MyGlb.VIS_NORMALFIELDS);
    PAN_DISPOSITNOTI.SetFlags(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DISPOSITNOTI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, "CD3170A3-E3B2-4536-BB1D-292BE76E9876");
    PAN_DISPOSITNOTI.set_Header(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, "Device Token");
    PAN_DISPOSITNOTI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, "Identificativo del dispositivo");
    PAN_DISPOSITNOTI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, MyGlb.VIS_NORMALFIELDS);
    PAN_DISPOSITNOTI.SetFlags(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_DISPOSITNOTI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, "EB309D97-4BC6-4268-A9B6-B51023DC90FC");
    PAN_DISPOSITNOTI.set_Header(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, "Type OS");
    PAN_DISPOSITNOTI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, "");
    PAN_DISPOSITNOTI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, MyGlb.VIS_NORMALFIELDS);
    PAN_DISPOSITNOTI.SetFlags(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_DISPOSITNOTI_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_DISPOSITNOTI.SetRect(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, MyGlb.PANEL_LIST, 0, 32, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DISPOSITNOTI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, MyGlb.PANEL_LIST, 20);
    PAN_DISPOSITNOTI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, MyGlb.PANEL_LIST, 1);
    PAN_DISPOSITNOTI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, MyGlb.PANEL_LIST, "ID");
    PAN_DISPOSITNOTI.SetRect(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, MyGlb.PANEL_FORM, 4, 4, 136, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DISPOSITNOTI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, MyGlb.PANEL_FORM, 88);
    PAN_DISPOSITNOTI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, MyGlb.PANEL_FORM, 1);
    PAN_DISPOSITNOTI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_ID, MyGlb.PANEL_FORM, "ID");
    PAN_DISPOSITNOTI.SetFieldPage(PFL_DISPOSITNOTI_ID, -1, -1);
    PAN_DISPOSITNOTI.SetFieldPanel(PFL_DISPOSITNOTI_ID, PPQRY_DISPONOTIIOS, "A.ID", "ID", 1, 9, 0, -1709);
    PAN_DISPOSITNOTI.SetRect(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, MyGlb.PANEL_LIST, 40, 32, 268, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DISPOSITNOTI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, MyGlb.PANEL_LIST, 104);
    PAN_DISPOSITNOTI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, MyGlb.PANEL_LIST, 1);
    PAN_DISPOSITNOTI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, MyGlb.PANEL_LIST, "Nome");
    PAN_DISPOSITNOTI.SetRect(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, MyGlb.PANEL_FORM, 56, 16, 488, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DISPOSITNOTI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, MyGlb.PANEL_FORM, 88);
    PAN_DISPOSITNOTI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, MyGlb.PANEL_FORM, 2);
    PAN_DISPOSITNOTI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_NOME, MyGlb.PANEL_FORM, "Nome");
    PAN_DISPOSITNOTI.SetFieldPage(PFL_DISPOSITNOTI_NOME, -1, -1);
    PAN_DISPOSITNOTI.SetFieldPanel(PFL_DISPOSITNOTI_NOME, PPQRY_DISPONOTIIOS, "A.DES_MESSAGGIO", "DES_MESSAGGIO", 9, 1000, 0, -1709);
    PAN_DISPOSITNOTI.SetRect(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, MyGlb.PANEL_LIST, 308, 32, 296, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DISPOSITNOTI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, MyGlb.PANEL_LIST, 104);
    PAN_DISPOSITNOTI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, MyGlb.PANEL_LIST, 1);
    PAN_DISPOSITNOTI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, MyGlb.PANEL_LIST, "Device Token");
    PAN_DISPOSITNOTI.SetRect(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, MyGlb.PANEL_FORM, 8, 92, 488, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DISPOSITNOTI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, MyGlb.PANEL_FORM, 88);
    PAN_DISPOSITNOTI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, MyGlb.PANEL_FORM, 2);
    PAN_DISPOSITNOTI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_DEVICETOKEN, MyGlb.PANEL_FORM, "Device Token");
    PAN_DISPOSITNOTI.SetFieldPage(PFL_DISPOSITNOTI_DEVICETOKEN, -1, -1);
    PAN_DISPOSITNOTI.SetFieldPanel(PFL_DISPOSITNOTI_DEVICETOKEN, PPQRY_DISPONOTIIOS, "A.DEV_TOKEN", "DEV_TOKEN", 5, 1000, 0, -1709);
    PAN_DISPOSITNOTI.SetRect(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, MyGlb.PANEL_LIST, 604, 32, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DISPOSITNOTI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, MyGlb.PANEL_LIST, 52);
    PAN_DISPOSITNOTI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, MyGlb.PANEL_LIST, 1);
    PAN_DISPOSITNOTI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, MyGlb.PANEL_LIST, "Type OS");
    PAN_DISPOSITNOTI.SetRect(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, MyGlb.PANEL_FORM, 4, 140, 96, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DISPOSITNOTI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, MyGlb.PANEL_FORM, 52);
    PAN_DISPOSITNOTI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, MyGlb.PANEL_FORM, 1);
    PAN_DISPOSITNOTI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DISPOSITNOTI_TYPEOS, MyGlb.PANEL_FORM, "Typ. O.");
    PAN_DISPOSITNOTI.SetFieldPage(PFL_DISPOSITNOTI_TYPEOS, -1, -1);
    PAN_DISPOSITNOTI.SetFieldPanel(PFL_DISPOSITNOTI_TYPEOS, PPQRY_DISPONOTIIOS, "A.TYPE_OS", "TYPE_OS", 5, 1, 0, -1709);
    PAN_DISPOSITNOTI.SetValueListItem(PFL_DISPOSITNOTI_TYPEOS, (new IDVariant("1")), "iOS", "", "", -1);
    PAN_DISPOSITNOTI.SetValueListItem(PFL_DISPOSITNOTI_TYPEOS, (new IDVariant("2")), "Android", "", "", -1);
    PAN_DISPOSITNOTI.SetValueListItem(PFL_DISPOSITNOTI_TYPEOS, (new IDVariant("3")), "Windows Phone", "", "", -1);
    PAN_DISPOSITNOTI.SetValueListItem(PFL_DISPOSITNOTI_TYPEOS, (new IDVariant("4")), "Blackberry", "", "", -1);
    PAN_DISPOSITNOTI.SetValueListItem(PFL_DISPOSITNOTI_TYPEOS, (new IDVariant("5")), "Windows Store", "", "", -1);
  }

  private void PAN_DISPOSITNOTI_InitQueries()
  {
    StringBuilder SQL;

    PAN_DISPOSITNOTI.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_DISPOSITNOTI.SetIMDB(IMDB, "PQRY_DISPONOTIIOS", true);
    PAN_DISPOSITNOTI.set_SetString(MyGlb.MASTER_ROWNAME, "Dispositivi Noti");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.DES_MESSAGGIO as DES_MESSAGGIO, ");
    SQL.Append("  A.DEV_TOKEN as DEV_TOKEN, ");
    SQL.Append("  A.TYPE_OS as TYPE_OS ");
    PAN_DISPOSITNOTI.SetQuery(PPQRY_DISPONOTIIOS, 0, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  DISPOSITIVI_NOTI A ");
    PAN_DISPOSITNOTI.SetQuery(PPQRY_DISPONOTIIOS, 1, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DISPOSITNOTI.SetQuery(PPQRY_DISPONOTIIOS, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DISPOSITNOTI.SetQuery(PPQRY_DISPONOTIIOS, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DISPOSITNOTI.SetQuery(PPQRY_DISPONOTIIOS, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DISPOSITNOTI.SetQuery(PPQRY_DISPONOTIIOS, 5, SQL, -1, "");
    PAN_DISPOSITNOTI.SetQueryDB(PPQRY_DISPONOTIIOS, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DISPOSITNOTI.SetMasterTable(0, "DISPOSITIVI_NOTI");
    SQL = new StringBuilder("");
    PAN_DISPOSITNOTI.SetQuery(0, -1, SQL, PFL_DISPOSITNOTI_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_DISPOSITNOTI) PAN_DISPOSITNOTI_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_DISPOSITNOTI) PAN_DISPOSITNOTI_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_DISPOSITNOTI) PAN_DISPOSITNOTI_CellActivated(ColIndex, Cancel);
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
