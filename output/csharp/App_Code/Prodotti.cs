// **********************************************
// Prodotti
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
public partial class Prodotti : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_PRODOTTI_ID = 0;
  private const int PFL_PRODOTTI_NOME = 1;

  private const int PPQRY_PRODOTTI = 0;


  internal IDPanel PAN_PRODOTTI;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_PRODOTTI(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_PRODOTTI(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_PRODOTTI, 2);
    IMDB.set_TblCode(IMDBDef1.PQRY_PRODOTTI, "PQRY_PRODOTTI");
    IMDB.set_FldCode(IMDBDef1.PQRY_PRODOTTI,IMDBDef1.PQSL_PRODOTTI_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_PRODOTTI,IMDBDef1.PQSL_PRODOTTI_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_PRODOTTI,IMDBDef1.PQSL_PRODOTTI_NOME_APP, "NOME_APP");
    IMDB.SetFldParams(IMDBDef1.PQRY_PRODOTTI,IMDBDef1.PQSL_PRODOTTI_NOME_APP,5,200,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_PRODOTTI, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public Prodotti(MyWebEntryPoint w, IMDBObj imdb)
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
  public Prodotti()
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
    FormIdx = MyGlb.FRM_PRODOTTI;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "7887F555-5B59-4ED4-9865-773B45194F54";
    ResModeW = 1;
    ResModeH = 1;
    iVisualFlags = -2049;
    DesignWidth = 700;
    DesignHeight = 532;
    set_Caption(new IDVariant("Prodotti"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 700;
    Frames[1].Height = 472;
    Frames[1].Caption = "Prodotti";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 472;
    PAN_PRODOTTI = new IDPanel(w, this, 1, "PAN_PRODOTTI");
    Frames[1].Content = PAN_PRODOTTI;
    PAN_PRODOTTI.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_PRODOTTI.VS = MainFrm.VisualStyleList;
    PAN_PRODOTTI.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 700-MyGlb.PAN_OFFS_X, 472-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_PRODOTTI.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "CA0C05AE-E84C-42E8-8A08-1A9CFCD39A43");
    PAN_PRODOTTI.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 324, 396, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_PRODOTTI.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_PRODOTTI.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_PRODOTTI.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_PRODOTTI.InitStatus = 2;
    PAN_PRODOTTI_Init();
    PAN_PRODOTTI_InitFields();
    PAN_PRODOTTI_InitQueries();
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
      PAN_PRODOTTI.UpdatePanel(MainFrm);
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
    return (obj is Prodotti);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(Prodotti).FullName : typeof(Prodotti).Name);
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
  private void PAN_PRODOTTI_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_PRODOTTI_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_PRODOTTI_ValidateRow(IDVariant Cancel)
  {
    try
    {
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_PRODOTTI_Init()
  {

    PAN_PRODOTTI.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_PRODOTTI.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_PRODOTTI.SetSize(MyGlb.OBJ_FIELD, 2);
    PAN_PRODOTTI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, "641898C1-5781-4460-8A0F-3714B0A3F225");
    PAN_PRODOTTI.set_Header(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, "ID");
    PAN_PRODOTTI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, "Identificativo univoco");
    PAN_PRODOTTI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_PRODOTTI.SetFlags(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_PRODOTTI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, "D6E34BE0-3A8B-4B56-942A-C5EA3C1D45AF");
    PAN_PRODOTTI.set_Header(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, "Nome");
    PAN_PRODOTTI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, "Nome del prodotto");
    PAN_PRODOTTI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, MyGlb.VIS_NORMALFIELDS);
    PAN_PRODOTTI.SetFlags(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISDESCR, -1);
  }

  private void PAN_PRODOTTI_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_PRODOTTI.SetRect(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, MyGlb.PANEL_LIST, 0, 32, 40, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODOTTI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, MyGlb.PANEL_LIST, 20);
    PAN_PRODOTTI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, MyGlb.PANEL_LIST, 1);
    PAN_PRODOTTI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, MyGlb.PANEL_LIST, "ID");
    PAN_PRODOTTI.SetRect(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, MyGlb.PANEL_FORM, 4, 4, 96, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODOTTI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, MyGlb.PANEL_FORM, 48);
    PAN_PRODOTTI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, MyGlb.PANEL_FORM, 1);
    PAN_PRODOTTI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODOTTI_ID, MyGlb.PANEL_FORM, "ID");
    PAN_PRODOTTI.SetFieldPage(PFL_PRODOTTI_ID, -1, -1);
    PAN_PRODOTTI.SetFieldPanel(PFL_PRODOTTI_ID, PPQRY_PRODOTTI, "A.ID", "ID", 1, 9, 0, -1709);
    PAN_PRODOTTI.SetRect(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, MyGlb.PANEL_LIST, 40, 32, 284, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_PRODOTTI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, MyGlb.PANEL_LIST, 36);
    PAN_PRODOTTI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, MyGlb.PANEL_LIST, 1);
    PAN_PRODOTTI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, MyGlb.PANEL_LIST, "Nome");
    PAN_PRODOTTI.SetRect(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, MyGlb.PANEL_FORM, 4, 28, 448, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODOTTI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, MyGlb.PANEL_FORM, 48);
    PAN_PRODOTTI.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, MyGlb.PANEL_FORM, 1);
    PAN_PRODOTTI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODOTTI_NOME, MyGlb.PANEL_FORM, "Nome");
    PAN_PRODOTTI.SetFieldPage(PFL_PRODOTTI_NOME, -1, -1);
    PAN_PRODOTTI.SetFieldPanel(PFL_PRODOTTI_NOME, PPQRY_PRODOTTI, "A.NOME_APP", "NOME_APP", 5, 200, 0, -1709);
  }

  private void PAN_PRODOTTI_InitQueries()
  {
    StringBuilder SQL;

    PAN_PRODOTTI.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_PRODOTTI.SetIMDB(IMDB, "PQRY_PRODOTTI", true);
    PAN_PRODOTTI.set_SetString(MyGlb.MASTER_ROWNAME, "Prodotto");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.NOME_APP as NOME_APP ");
    PAN_PRODOTTI.SetQuery(PPQRY_PRODOTTI, 0, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  PRODOTTI A ");
    PAN_PRODOTTI.SetQuery(PPQRY_PRODOTTI, 1, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_PRODOTTI.SetQuery(PPQRY_PRODOTTI, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_PRODOTTI.SetQuery(PPQRY_PRODOTTI, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_PRODOTTI.SetQuery(PPQRY_PRODOTTI, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_PRODOTTI.SetQuery(PPQRY_PRODOTTI, 5, SQL, -1, "");
    PAN_PRODOTTI.SetQueryDB(PPQRY_PRODOTTI, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_PRODOTTI.SetMasterTable(0, "PRODOTTI");
    SQL = new StringBuilder("");
    PAN_PRODOTTI.SetQuery(0, -1, SQL, PFL_PRODOTTI_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_PRODOTTI) PAN_PRODOTTI_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_PRODOTTI) PAN_PRODOTTI_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_PRODOTTI) PAN_PRODOTTI_CellActivated(ColIndex, Cancel);
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
