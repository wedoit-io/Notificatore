// **********************************************
// Applicazioni
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
public partial class Applicazioni : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_APPLICAZIONI_ID = 0;
  private const int PFL_APPLICAZIONI_APPLICAZIONE = 1;
  private const int PFL_APPLICAZIONI_CHIAVE = 2;
  private const int PFL_APPLICAZIONI_AUTHKEY = 3;
  private const int PFL_APPLICAZIONI_NOTA = 4;
  private const int PFL_APPLICAZIONI_PRODOTTO = 5;
  private const int PFL_APPLICAZIONI_TITOLOSTATIS = 6;
  private const int PFL_APPLICAZIONI_LINGUA = 7;

  private const int PPQRY_APPLICAZION2 = 0;

  private const int PPQRY_PRODOTTI = 1;
  private const int PPQRY_LINGUE = 2;


  internal IDPanel PAN_APPLICAZIONI;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_APPLICAZION2(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_APPLICAZION2(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_APPLICAZION2, 8);
    IMDB.set_TblCode(IMDBDef1.PQRY_APPLICAZION2, "PQRY_APPLICAZION2");
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_NOME_APP, "NOME_APP");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_NOME_APP,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_APP_KEY, "APP_KEY");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_APP_KEY,5,300,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_AUTH_KEY, "AUTH_KEY");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_AUTH_KEY,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_NOME_APP_STAT, "NOME_APP_STAT");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_NOME_APP_STAT,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_ID_PRODOTTO, "ID_PRODOTTO");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_ID_PRODOTTO,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_PRG_LINGUA, "PRG_LINGUA");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION2,IMDBDef1.PQSL_APPLICAZION2_PRG_LINGUA,1,9,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_APPLICAZION2, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public Applicazioni(MyWebEntryPoint w, IMDBObj imdb)
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
  public Applicazioni()
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
    FormIdx = MyGlb.FRM_APPLICAZIONI;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "E5FF8C62-E567-4787-A569-E6C526D2E483";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 772;
    DesignHeight = 342;
    set_Caption(new IDVariant("Applicazioni"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 772;
    Frames[1].Height = 316;
    Frames[1].Caption = "Applicazioni";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 316;
    PAN_APPLICAZIONI = new IDPanel(w, this, 1, "PAN_APPLICAZIONI");
    Frames[1].Content = PAN_APPLICAZIONI;
    PAN_APPLICAZIONI.set_ShowGroups(true);
    PAN_APPLICAZIONI.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_APPLICAZIONI.VS = MainFrm.VisualStyleList;
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 772-MyGlb.PAN_OFFS_X, 316-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_APPLICAZIONI.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "CBEAA1EA-F1FC-49C4-BD6C-0B1C30704DBD");
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 720, 256, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_APPLICAZIONI.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_APPLICAZIONI.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_APPLICAZIONI.InitStatus = 1;
    PAN_APPLICAZIONI_Init();
    PAN_APPLICAZIONI_InitFields();
    PAN_APPLICAZIONI_InitQueries();
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
      PAN_APPLICAZIONI.UpdatePanel(MainFrm);
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
    return (obj is Applicazioni);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(Applicazioni).FullName : typeof(Applicazioni).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Applicazioni Before Insert
  // Evento notificato dal pannello prima dell'inserimento
  // nel database dei dati relativi ad una nuova riga di
  // pannello.
  // Cancel - Input/Output
  // **********************************************************************
  private void PAN_APPLICAZIONI_BeforeInsert (IDVariant Cancel)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Applicazioni Before Insert Body
      // Corpo Procedura
      // 
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_APPLICAZION2, IMDBDef1.PQSL_APPLICAZION2_APP_KEY, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_APPLICAZION2, IMDBDef1.PQSL_APPLICAZION2_AUTH_KEY, 0, IDL.Upper(new IDVariant(com.progamma.GUID.DocID2GUID (com.progamma.doc.MDOInit.GetNewDocID().stringValue()))));
      }
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Applicazioni", "ApplicazioniBeforeInsert", _e);
    }
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
      // PAN_APPLICAZIONI.set_GroupingEnabled((new IDVariant(-1)).booleanValue());
      // PAN_APPLICAZIONI.set_ShowGroups((new IDVariant(-1)).booleanValue());
      // PAN_APPLICAZIONI.AddToGroupingList((new IDVariant(PFL_APPLICAZIONI_PRODOTTO)).intValue(),(new IDVariant(-1)).booleanValue()); 
      // PAN_APPLICAZIONI.PanelCommand(Glb.PCM_FIND);
      // PAN_APPLICAZIONI.RefreshGrouping(true);
      // PAN_APPLICAZIONI.RD3ExpandGroup((new IDVariant(0)).intValue(),(new IDVariant(-1)).booleanValue()); 
      // PAN_APPLICAZIONI.set_ActualPosition(true, (new IDVariant(1)).intValue());
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Applicazioni", "Load", _e);
    }
  }



  // **********************************************
  // Event Stubs
  // **********************************************	
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
  private void PAN_APPLICAZIONI_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_APPLICAZIONI_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_APPLICAZIONI_ValidateRow(IDVariant Cancel)
  {
    try
    {
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_APPLICAZIONI_Init()
  {

    PAN_APPLICAZIONI.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_APPLICAZIONI.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_APPLICAZIONI.SetSize(MyGlb.OBJ_FIELD, 8);
    PAN_APPLICAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, "CEDABAE4-6451-4AB3-912E-2867ECC58031");
    PAN_APPLICAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, "ID");
    PAN_APPLICAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, "Identificativo univoco");
    PAN_APPLICAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_APPLICAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_APPLICAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, "860F7B4E-EEE4-4C4A-BD04-5D71FB0684A6");
    PAN_APPLICAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, "Applicazione");
    PAN_APPLICAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, "");
    PAN_APPLICAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISDESCR, -1);
    PAN_APPLICAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, "486562CE-CEFD-4679-867F-24A39AD42147");
    PAN_APPLICAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, "Chiave");
    PAN_APPLICAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, "Chiave dell'applicazione");
    PAN_APPLICAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APPLICAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, "B4AB5B9A-A463-48C2-A8D6-4E9EF4F17937");
    PAN_APPLICAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, "Auth Key");
    PAN_APPLICAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, "Descrivi il contenuto del campo");
    PAN_APPLICAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APPLICAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, "68941FED-3EC1-4A21-A2EF-B9AD672BF69D");
    PAN_APPLICAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, "Nota");
    PAN_APPLICAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, "Nota");
    PAN_APPLICAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APPLICAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, "1A92E27A-036C-4E45-9B94-91F45FDF16E6");
    PAN_APPLICAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, "Prodotto");
    PAN_APPLICAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, "Identificativo univoco");
    PAN_APPLICAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, MyGlb.VIS_FOREIKEYFIEL);
    PAN_APPLICAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP, -1);
    PAN_APPLICAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, "49EA3344-2B3C-4AC1-A516-5DF6D275C05B");
    PAN_APPLICAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, "Titolo Statistiche");
    PAN_APPLICAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, "");
    PAN_APPLICAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, MyGlb.VIS_NORMALFIELDS);
    PAN_APPLICAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISDESCR, -1);
    PAN_APPLICAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, "F104D77F-4095-4C0C-A15B-716C626005FC");
    PAN_APPLICAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, "Lingua");
    PAN_APPLICAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, "");
    PAN_APPLICAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, MyGlb.VIS_FOREIKEYFIEL);
    PAN_APPLICAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_APPLICAZIONI_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, MyGlb.PANEL_LIST, 0, 36, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, MyGlb.PANEL_LIST, 20);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, MyGlb.PANEL_LIST, 1);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, MyGlb.PANEL_LIST, "ID");
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, MyGlb.PANEL_FORM, 4, 4, 128, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, MyGlb.PANEL_FORM, 80);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, MyGlb.PANEL_FORM, 1);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_ID, MyGlb.PANEL_FORM, "ID");
    PAN_APPLICAZIONI.SetFieldPage(PFL_APPLICAZIONI_ID, -1, -1);
    PAN_APPLICAZIONI.SetFieldPanel(PFL_APPLICAZIONI_ID, PPQRY_APPLICAZION2, "A.ID", "ID", 1, 9, 0, -685);
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, MyGlb.PANEL_LIST, 40, 36, 116, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, MyGlb.PANEL_LIST, 96);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, MyGlb.PANEL_FORM, 4, 28, 480, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, MyGlb.PANEL_FORM, 80);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, MyGlb.PANEL_FORM, 2);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_APPLICAZIONI.SetFieldPage(PFL_APPLICAZIONI_APPLICAZIONE, -1, -1);
    PAN_APPLICAZIONI.SetFieldPanel(PFL_APPLICAZIONI_APPLICAZIONE, PPQRY_APPLICAZION2, "A.NOME_APP", "NOME_APP", 5, 200, 0, -685);
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, MyGlb.PANEL_LIST, 156, 36, 84, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, MyGlb.PANEL_LIST, 96);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, MyGlb.PANEL_LIST, 1);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, MyGlb.PANEL_LIST, "Chiave");
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, MyGlb.PANEL_FORM, 4, 100, 480, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, MyGlb.PANEL_FORM, 80);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, MyGlb.PANEL_FORM, 2);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_CHIAVE, MyGlb.PANEL_FORM, "Chiave");
    PAN_APPLICAZIONI.SetFieldPage(PFL_APPLICAZIONI_CHIAVE, -1, -1);
    PAN_APPLICAZIONI.SetFieldPanel(PFL_APPLICAZIONI_CHIAVE, PPQRY_APPLICAZION2, "A.APP_KEY", "APP_KEY", 5, 300, 0, -685);
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, MyGlb.PANEL_LIST, 240, 36, 152, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, MyGlb.PANEL_LIST, 96);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, MyGlb.PANEL_LIST, 1);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, MyGlb.PANEL_LIST, "Auth Key");
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, MyGlb.PANEL_FORM, 4, 124, 480, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, MyGlb.PANEL_FORM, 80);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, MyGlb.PANEL_FORM, 2);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_AUTHKEY, MyGlb.PANEL_FORM, "Auth Key");
    PAN_APPLICAZIONI.SetFieldPage(PFL_APPLICAZIONI_AUTHKEY, -1, -1);
    PAN_APPLICAZIONI.SetFieldPanel(PFL_APPLICAZIONI_AUTHKEY, PPQRY_APPLICAZION2, "A.AUTH_KEY", "AUTH_KEY", 5, 1000, 0, -685);
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, MyGlb.PANEL_LIST, 392, 36, 104, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, MyGlb.PANEL_LIST, 96);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, MyGlb.PANEL_LIST, 1);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, MyGlb.PANEL_LIST, "Nota");
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, MyGlb.PANEL_FORM, 4, 52, 480, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, MyGlb.PANEL_FORM, 80);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, MyGlb.PANEL_FORM, 1);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_NOTA, MyGlb.PANEL_FORM, "Nota");
    PAN_APPLICAZIONI.SetFieldPage(PFL_APPLICAZIONI_NOTA, -1, -1);
    PAN_APPLICAZIONI.SetFieldPanel(PFL_APPLICAZIONI_NOTA, PPQRY_APPLICAZION2, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -685);
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, MyGlb.PANEL_LIST, 496, 36, 68, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, MyGlb.PANEL_LIST, 64);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, MyGlb.PANEL_LIST, 1);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, MyGlb.PANEL_LIST, "Prodotto");
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, MyGlb.PANEL_FORM, 4, 208, 124, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, MyGlb.PANEL_FORM, 64);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, MyGlb.PANEL_FORM, 1);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_PRODOTTO, MyGlb.PANEL_FORM, "Prodotto");
    PAN_APPLICAZIONI.SetFieldPage(PFL_APPLICAZIONI_PRODOTTO, -1, -1);
    PAN_APPLICAZIONI.SetFieldPanel(PFL_APPLICAZIONI_PRODOTTO, PPQRY_APPLICAZION2, "A.ID_PRODOTTO", "ID_PRODOTTO", 1, 9, 0, -685);
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, MyGlb.PANEL_LIST, 564, 36, 100, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, MyGlb.PANEL_LIST, 88);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, MyGlb.PANEL_LIST, 1);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, MyGlb.PANEL_LIST, "Titolo Statistiche");
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, MyGlb.PANEL_FORM, 4, 172, 596, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, MyGlb.PANEL_FORM, 88);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, MyGlb.PANEL_FORM, 2);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_TITOLOSTATIS, MyGlb.PANEL_FORM, "Titolo Statistiche");
    PAN_APPLICAZIONI.SetFieldPage(PFL_APPLICAZIONI_TITOLOSTATIS, -1, -1);
    PAN_APPLICAZIONI.SetFieldPanel(PFL_APPLICAZIONI_TITOLOSTATIS, PPQRY_APPLICAZION2, "A.NOME_APP_STAT", "NOME_APP_STAT", 5, 200, 0, -685);
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, MyGlb.PANEL_LIST, 664, 36, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, MyGlb.PANEL_LIST, 52);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, MyGlb.PANEL_LIST, 1);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, MyGlb.PANEL_LIST, "Lingua");
    PAN_APPLICAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, MyGlb.PANEL_FORM, 4, 232, 112, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPLICAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, MyGlb.PANEL_FORM, 52);
    PAN_APPLICAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, MyGlb.PANEL_FORM, 1);
    PAN_APPLICAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPLICAZIONI_LINGUA, MyGlb.PANEL_FORM, "Lingua");
    PAN_APPLICAZIONI.SetFieldPage(PFL_APPLICAZIONI_LINGUA, -1, -1);
    PAN_APPLICAZIONI.SetFieldPanel(PFL_APPLICAZIONI_LINGUA, PPQRY_APPLICAZION2, "A.PRG_LINGUA", "PRG_LINGUA", 1, 9, 0, -685);
  }

  private void PAN_APPLICAZIONI_InitQueries()
  {
    StringBuilder SQL;

    PAN_APPLICAZIONI.SetSize(MyGlb.OBJ_QUERY, 3);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDPRODOTTO, ");
    SQL.Append("  A.NOME_APP as NOMEPRODOTTO ");
    SQL.Append("from ");
    SQL.Append("  PRODOTTI A ");
    SQL.Append("where (A.ID = ~~ID_PRODOTTO~~) ");
    PAN_APPLICAZIONI.SetQuery(PPQRY_PRODOTTI, 0, SQL, PFL_APPLICAZIONI_PRODOTTO, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDPRODOTTO, ");
    SQL.Append("  A.NOME_APP as NOMEPRODOTTO ");
    SQL.Append("from ");
    SQL.Append("  PRODOTTI A ");
    PAN_APPLICAZIONI.SetQuery(PPQRY_PRODOTTI, 1, SQL, PFL_APPLICAZIONI_PRODOTTO, "");
    PAN_APPLICAZIONI.SetQueryDB(PPQRY_PRODOTTI, MainFrm.NotificatoreDBObject.DB, 2048);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.PRG_LINGUA as IDLINGUA, ");
    SQL.Append("  A.DES_LINGUA as DESCRILINGUA ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    SQL.Append("where (A.PRG_LINGUA = ~~PRG_LINGUA~~) ");
    PAN_APPLICAZIONI.SetQuery(PPQRY_LINGUE, 0, SQL, PFL_APPLICAZIONI_LINGUA, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.PRG_LINGUA as IDLINGUA, ");
    SQL.Append("  A.DES_LINGUA as DESCRILINGUA ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    PAN_APPLICAZIONI.SetQuery(PPQRY_LINGUE, 1, SQL, PFL_APPLICAZIONI_LINGUA, "");
    PAN_APPLICAZIONI.SetQueryDB(PPQRY_LINGUE, MainFrm.NotificatoreDBObject.DB, 2048);
    PAN_APPLICAZIONI.SetIMDB(IMDB, "PQRY_APPLICAZION2", true);
    PAN_APPLICAZIONI.set_SetString(MyGlb.MASTER_ROWNAME, "Applicazione");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.NOME_APP as NOME_APP, ");
    SQL.Append("  A.DES_NOTA as DES_NOTA, ");
    SQL.Append("  A.APP_KEY as APP_KEY, ");
    SQL.Append("  A.AUTH_KEY as AUTH_KEY, ");
    SQL.Append("  A.NOME_APP_STAT as NOME_APP_STAT, ");
    SQL.Append("  A.ID_PRODOTTO as ID_PRODOTTO, ");
    SQL.Append("  A.PRG_LINGUA as PRG_LINGUA ");
    PAN_APPLICAZIONI.SetQuery(PPQRY_APPLICAZION2, 0, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  APPS A ");
    PAN_APPLICAZIONI.SetQuery(PPQRY_APPLICAZION2, 1, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPLICAZIONI.SetQuery(PPQRY_APPLICAZION2, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPLICAZIONI.SetQuery(PPQRY_APPLICAZION2, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPLICAZIONI.SetQuery(PPQRY_APPLICAZION2, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPLICAZIONI.SetQuery(PPQRY_APPLICAZION2, 5, SQL, -1, "");
    PAN_APPLICAZIONI.SetQueryDB(PPQRY_APPLICAZION2, MainFrm.NotificatoreDBObject.DB, 2048);
    PAN_APPLICAZIONI.SetMasterTable(0, "APPS");
    SQL = new StringBuilder("select APPS_ID.NextVal from dual");
    PAN_APPLICAZIONI.SetQuery(0, -1, SQL, PFL_APPLICAZIONI_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_APPLICAZIONI) PAN_APPLICAZIONI_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_APPLICAZIONI) PAN_APPLICAZIONI_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_APPLICAZIONI) PAN_APPLICAZIONI_CellActivated(ColIndex, Cancel);
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
    if (SrcObj == PAN_APPLICAZIONI) PAN_APPLICAZIONI_BeforeInsert(Cancel);
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
