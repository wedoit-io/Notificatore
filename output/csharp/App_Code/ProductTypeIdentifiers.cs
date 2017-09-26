// **********************************************
// Product Type Identifiers
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
public partial class ProductTypeIdentifiers : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_PRODTYPEIDEN_IDENTIFIER = 0;
  private const int PFL_PRODTYPEIDEN_DESCRIPTION = 1;
  private const int PFL_PRODTYPEIDEN_FREEAPP = 2;
  private const int PFL_PRODTYPEIDEN_PAIDAPP = 3;
  private const int PFL_PRODTYPEIDEN_INAPPS = 4;
  private const int PFL_PRODTYPEIDEN_UPDATE = 5;

  private const int PPQRY_PRODTYPEIDEN = 0;


  internal IDPanel PAN_PRODTYPEIDEN;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_PRODTYPEIDEN(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_PRODTYPEIDEN(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_PRODTYPEIDEN, 6);
    IMDB.set_TblCode(IMDBDef1.PQRY_PRODTYPEIDEN, "PQRY_PRODTYPEIDEN");
    IMDB.set_FldCode(IMDBDef1.PQRY_PRODTYPEIDEN,IMDBDef1.PQSL_PRODTYPEIDEN_IDENTIFIER, "IDENTIFIER");
    IMDB.SetFldParams(IMDBDef1.PQRY_PRODTYPEIDEN,IMDBDef1.PQSL_PRODTYPEIDEN_IDENTIFIER,5,20,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_PRODTYPEIDEN,IMDBDef1.PQSL_PRODTYPEIDEN_DESCRIPTION, "DESCRIPTION");
    IMDB.SetFldParams(IMDBDef1.PQRY_PRODTYPEIDEN,IMDBDef1.PQSL_PRODTYPEIDEN_DESCRIPTION,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_PRODTYPEIDEN,IMDBDef1.PQSL_PRODTYPEIDEN_FREE_APPS, "FREE_APPS");
    IMDB.SetFldParams(IMDBDef1.PQRY_PRODTYPEIDEN,IMDBDef1.PQSL_PRODTYPEIDEN_FREE_APPS,1,2,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_PRODTYPEIDEN,IMDBDef1.PQSL_PRODTYPEIDEN_PAID_APPS, "PAID_APPS");
    IMDB.SetFldParams(IMDBDef1.PQRY_PRODTYPEIDEN,IMDBDef1.PQSL_PRODTYPEIDEN_PAID_APPS,1,2,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_PRODTYPEIDEN,IMDBDef1.PQSL_PRODTYPEIDEN_IN_APPS, "IN_APPS");
    IMDB.SetFldParams(IMDBDef1.PQRY_PRODTYPEIDEN,IMDBDef1.PQSL_PRODTYPEIDEN_IN_APPS,1,2,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_PRODTYPEIDEN,IMDBDef1.PQSL_PRODTYPEIDEN_UPDATE_APPS, "UPDATE_APPS");
    IMDB.SetFldParams(IMDBDef1.PQRY_PRODTYPEIDEN,IMDBDef1.PQSL_PRODTYPEIDEN_UPDATE_APPS,1,2,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_PRODTYPEIDEN, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public ProductTypeIdentifiers(MyWebEntryPoint w, IMDBObj imdb)
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
  public ProductTypeIdentifiers()
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
    FormIdx = MyGlb.FRM_PRODTYPEIDEN;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "0D1F2D76-CBEA-4765-BD5C-3A1BA7667228";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 612;
    DesignHeight = 60;
    set_Caption(new IDVariant("Product Type Identifiers"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 612;
    Frames[1].Height = 380;
    Frames[1].Caption = "Product Type Identifiers";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 380;
    PAN_PRODTYPEIDEN = new IDPanel(w, this, 1, "PAN_PRODTYPEIDEN");
    Frames[1].Content = PAN_PRODTYPEIDEN;
    PAN_PRODTYPEIDEN.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_PRODTYPEIDEN.VS = MainFrm.VisualStyleList;
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 612-MyGlb.PAN_OFFS_X, 380-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_PRODTYPEIDEN.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "F0CD38BA-6A40-4FA6-B820-F6BA3C35744B");
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 544, 316, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_PRODTYPEIDEN.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_PRODTYPEIDEN.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_PRODTYPEIDEN.InitStatus = 2;
    PAN_PRODTYPEIDEN_Init();
    PAN_PRODTYPEIDEN_InitFields();
    PAN_PRODTYPEIDEN_InitQueries();
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
      PAN_PRODTYPEIDEN.UpdatePanel(MainFrm);
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
    return (obj is ProductTypeIdentifiers);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(ProductTypeIdentifiers).FullName : typeof(ProductTypeIdentifiers).Name);
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
  private void PAN_PRODTYPEIDEN_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_PRODTYPEIDEN_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_PRODTYPEIDEN_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_PRODTYPEIDEN, IMDBDef1.PQSL_PRODTYPEIDEN_FREE_APPS, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_PRODTYPEIDEN, IMDBDef1.PQSL_PRODTYPEIDEN_FREE_APPS, 0, (new IDVariant(-1)));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_PRODTYPEIDEN, IMDBDef1.PQSL_PRODTYPEIDEN_PAID_APPS, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_PRODTYPEIDEN, IMDBDef1.PQSL_PRODTYPEIDEN_PAID_APPS, 0, (new IDVariant(-1)));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_PRODTYPEIDEN, IMDBDef1.PQSL_PRODTYPEIDEN_IN_APPS, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_PRODTYPEIDEN, IMDBDef1.PQSL_PRODTYPEIDEN_IN_APPS, 0, (new IDVariant(-1)));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_PRODTYPEIDEN, IMDBDef1.PQSL_PRODTYPEIDEN_UPDATE_APPS, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_PRODTYPEIDEN, IMDBDef1.PQSL_PRODTYPEIDEN_UPDATE_APPS, 0, (new IDVariant(-1)));
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_PRODTYPEIDEN_Init()
  {

    PAN_PRODTYPEIDEN.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_PRODTYPEIDEN.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_PRODTYPEIDEN.SetSize(MyGlb.OBJ_FIELD, 6);
    PAN_PRODTYPEIDEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, "8DB9C639-86DD-4CF9-9510-EDBFD737863C");
    PAN_PRODTYPEIDEN.set_Header(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, "Identifier");
    PAN_PRODTYPEIDEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, "Identifier");
    PAN_PRODTYPEIDEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_PRODTYPEIDEN.SetFlags(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISKEY, -1);
    PAN_PRODTYPEIDEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, "2650FFD2-E632-4205-99BC-4BD47A04229C");
    PAN_PRODTYPEIDEN.set_Header(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, "Description");
    PAN_PRODTYPEIDEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, "Description");
    PAN_PRODTYPEIDEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, MyGlb.VIS_NORMALFIELDS);
    PAN_PRODTYPEIDEN.SetFlags(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_PRODTYPEIDEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, "31C87E90-E503-4CE5-8B75-F18E5C540877");
    PAN_PRODTYPEIDEN.set_Header(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, "Free App");
    PAN_PRODTYPEIDEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, "Free App");
    PAN_PRODTYPEIDEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, MyGlb.VIS_CHECKSTYLE);
    PAN_PRODTYPEIDEN.SetFlags(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_PRODTYPEIDEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, "A34E5B56-40CC-47C3-AF2A-F969C8B1CB82");
    PAN_PRODTYPEIDEN.set_Header(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, "Paid App");
    PAN_PRODTYPEIDEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, "Paid App");
    PAN_PRODTYPEIDEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, MyGlb.VIS_CHECKSTYLE);
    PAN_PRODTYPEIDEN.SetFlags(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_PRODTYPEIDEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, "93FF0271-7DE5-4B61-AB70-38CC597E185E");
    PAN_PRODTYPEIDEN.set_Header(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, "In Apps");
    PAN_PRODTYPEIDEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, "In Apps");
    PAN_PRODTYPEIDEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, MyGlb.VIS_CHECKSTYLE);
    PAN_PRODTYPEIDEN.SetFlags(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_PRODTYPEIDEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, "7691B280-29AC-4CC5-9A34-5DB636E98079");
    PAN_PRODTYPEIDEN.set_Header(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, "Update");
    PAN_PRODTYPEIDEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, "Update");
    PAN_PRODTYPEIDEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, MyGlb.VIS_CHECKSTYLE);
    PAN_PRODTYPEIDEN.SetFlags(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_PRODTYPEIDEN_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, MyGlb.PANEL_LIST, 0, 32, 64, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, MyGlb.PANEL_LIST, 52);
    PAN_PRODTYPEIDEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, MyGlb.PANEL_LIST, 1);
    PAN_PRODTYPEIDEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, MyGlb.PANEL_LIST, "Identifier");
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, MyGlb.PANEL_FORM, 4, 4, 200, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, MyGlb.PANEL_FORM, 128);
    PAN_PRODTYPEIDEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, MyGlb.PANEL_FORM, 1);
    PAN_PRODTYPEIDEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_IDENTIFIER, MyGlb.PANEL_FORM, "Identifier");
    PAN_PRODTYPEIDEN.SetFieldPage(PFL_PRODTYPEIDEN_IDENTIFIER, -1, -1);
    PAN_PRODTYPEIDEN.SetFieldPanel(PFL_PRODTYPEIDEN_IDENTIFIER, PPQRY_PRODTYPEIDEN, "A.IDENTIFIER", "IDENTIFIER", 5, 20, 0, -1709);
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, MyGlb.PANEL_LIST, 64, 32, 204, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, MyGlb.PANEL_LIST, 160);
    PAN_PRODTYPEIDEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, MyGlb.PANEL_LIST, 1);
    PAN_PRODTYPEIDEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, MyGlb.PANEL_LIST, "Description");
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, MyGlb.PANEL_FORM, 4, 52, 528, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, MyGlb.PANEL_FORM, 128);
    PAN_PRODTYPEIDEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, MyGlb.PANEL_FORM, 1);
    PAN_PRODTYPEIDEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_DESCRIPTION, MyGlb.PANEL_FORM, "Description");
    PAN_PRODTYPEIDEN.SetFieldPage(PFL_PRODTYPEIDEN_DESCRIPTION, -1, -1);
    PAN_PRODTYPEIDEN.SetFieldPanel(PFL_PRODTYPEIDEN_DESCRIPTION, PPQRY_PRODTYPEIDEN, "A.DESCRIPTION", "DESCRIPTION", 5, 200, 0, -1709);
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, MyGlb.PANEL_LIST, 268, 32, 72, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, MyGlb.PANEL_LIST, 52);
    PAN_PRODTYPEIDEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, MyGlb.PANEL_LIST, 1);
    PAN_PRODTYPEIDEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, MyGlb.PANEL_LIST, "Free App");
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, MyGlb.PANEL_FORM, 4, 88, 96, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, MyGlb.PANEL_FORM, 52);
    PAN_PRODTYPEIDEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, MyGlb.PANEL_FORM, 1);
    PAN_PRODTYPEIDEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_FREEAPP, MyGlb.PANEL_FORM, "Fr. App");
    PAN_PRODTYPEIDEN.SetFieldPage(PFL_PRODTYPEIDEN_FREEAPP, -1, -1);
    PAN_PRODTYPEIDEN.SetFieldPanel(PFL_PRODTYPEIDEN_FREEAPP, PPQRY_PRODTYPEIDEN, "A.FREE_APPS", "FREE_APPS", 1, 2, 0, -1709);
    PAN_PRODTYPEIDEN.SetValueListItem(PFL_PRODTYPEIDEN_FREEAPP, (new IDVariant(-1)), "true", "Condizione vera", "", -1);
    PAN_PRODTYPEIDEN.SetValueListItem(PFL_PRODTYPEIDEN_FREEAPP, (new IDVariant(0)), "false", "Condizione falsa", "", -1);
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, MyGlb.PANEL_LIST, 340, 32, 72, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, MyGlb.PANEL_LIST, 52);
    PAN_PRODTYPEIDEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, MyGlb.PANEL_LIST, 1);
    PAN_PRODTYPEIDEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, MyGlb.PANEL_LIST, "Paid App");
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, MyGlb.PANEL_FORM, 4, 112, 96, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, MyGlb.PANEL_FORM, 52);
    PAN_PRODTYPEIDEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, MyGlb.PANEL_FORM, 1);
    PAN_PRODTYPEIDEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_PAIDAPP, MyGlb.PANEL_FORM, "Pd. App");
    PAN_PRODTYPEIDEN.SetFieldPage(PFL_PRODTYPEIDEN_PAIDAPP, -1, -1);
    PAN_PRODTYPEIDEN.SetFieldPanel(PFL_PRODTYPEIDEN_PAIDAPP, PPQRY_PRODTYPEIDEN, "A.PAID_APPS", "PAID_APPS", 1, 2, 0, -1709);
    PAN_PRODTYPEIDEN.SetValueListItem(PFL_PRODTYPEIDEN_PAIDAPP, (new IDVariant(-1)), "true", "Condizione vera", "", -1);
    PAN_PRODTYPEIDEN.SetValueListItem(PFL_PRODTYPEIDEN_PAIDAPP, (new IDVariant(0)), "false", "Condizione falsa", "", -1);
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, MyGlb.PANEL_LIST, 412, 32, 68, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, MyGlb.PANEL_LIST, 48);
    PAN_PRODTYPEIDEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, MyGlb.PANEL_LIST, 1);
    PAN_PRODTYPEIDEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, MyGlb.PANEL_LIST, "In Apps");
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, MyGlb.PANEL_FORM, 4, 136, 92, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, MyGlb.PANEL_FORM, 48);
    PAN_PRODTYPEIDEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, MyGlb.PANEL_FORM, 1);
    PAN_PRODTYPEIDEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_INAPPS, MyGlb.PANEL_FORM, "In App.");
    PAN_PRODTYPEIDEN.SetFieldPage(PFL_PRODTYPEIDEN_INAPPS, -1, -1);
    PAN_PRODTYPEIDEN.SetFieldPanel(PFL_PRODTYPEIDEN_INAPPS, PPQRY_PRODTYPEIDEN, "A.IN_APPS", "IN_APPS", 1, 2, 0, -1709);
    PAN_PRODTYPEIDEN.SetValueListItem(PFL_PRODTYPEIDEN_INAPPS, (new IDVariant(-1)), "true", "Condizione vera", "", -1);
    PAN_PRODTYPEIDEN.SetValueListItem(PFL_PRODTYPEIDEN_INAPPS, (new IDVariant(0)), "false", "Condizione falsa", "", -1);
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, MyGlb.PANEL_LIST, 480, 32, 64, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, MyGlb.PANEL_LIST, 44);
    PAN_PRODTYPEIDEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, MyGlb.PANEL_LIST, 1);
    PAN_PRODTYPEIDEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, MyGlb.PANEL_LIST, "Update");
    PAN_PRODTYPEIDEN.SetRect(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, MyGlb.PANEL_FORM, 4, 160, 88, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_PRODTYPEIDEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, MyGlb.PANEL_FORM, 44);
    PAN_PRODTYPEIDEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, MyGlb.PANEL_FORM, 1);
    PAN_PRODTYPEIDEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_PRODTYPEIDEN_UPDATE, MyGlb.PANEL_FORM, "Upd.");
    PAN_PRODTYPEIDEN.SetFieldPage(PFL_PRODTYPEIDEN_UPDATE, -1, -1);
    PAN_PRODTYPEIDEN.SetFieldPanel(PFL_PRODTYPEIDEN_UPDATE, PPQRY_PRODTYPEIDEN, "A.UPDATE_APPS", "UPDATE_APPS", 1, 2, 0, -1709);
    PAN_PRODTYPEIDEN.SetValueListItem(PFL_PRODTYPEIDEN_UPDATE, (new IDVariant(-1)), "true", "Condizione vera", "", -1);
    PAN_PRODTYPEIDEN.SetValueListItem(PFL_PRODTYPEIDEN_UPDATE, (new IDVariant(0)), "false", "Condizione falsa", "", -1);
  }

  private void PAN_PRODTYPEIDEN_InitQueries()
  {
    StringBuilder SQL;

    PAN_PRODTYPEIDEN.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_PRODTYPEIDEN.SetIMDB(IMDB, "PQRY_PRODTYPEIDEN", true);
    PAN_PRODTYPEIDEN.set_SetString(MyGlb.MASTER_ROWNAME, "Product Type Identifiers");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.IDENTIFIER as IDENTIFIER, ");
    SQL.Append("  A.DESCRIPTION as DESCRIPTION, ");
    SQL.Append("  A.FREE_APPS as FREE_APPS, ");
    SQL.Append("  A.PAID_APPS as PAID_APPS, ");
    SQL.Append("  A.IN_APPS as IN_APPS, ");
    SQL.Append("  A.UPDATE_APPS as UPDATE_APPS ");
    PAN_PRODTYPEIDEN.SetQuery(PPQRY_PRODTYPEIDEN, 0, SQL, -1, "15B0A47F-E558-43FB-94EC-90C003425721");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  APPLE_PROD_TYPES_IDENT A ");
    PAN_PRODTYPEIDEN.SetQuery(PPQRY_PRODTYPEIDEN, 1, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_PRODTYPEIDEN.SetQuery(PPQRY_PRODTYPEIDEN, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_PRODTYPEIDEN.SetQuery(PPQRY_PRODTYPEIDEN, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_PRODTYPEIDEN.SetQuery(PPQRY_PRODTYPEIDEN, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_PRODTYPEIDEN.SetQuery(PPQRY_PRODTYPEIDEN, 5, SQL, -1, "");
    PAN_PRODTYPEIDEN.SetQueryDB(PPQRY_PRODTYPEIDEN, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_PRODTYPEIDEN.SetMasterTable(0, "APPLE_PROD_TYPES_IDENT");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_PRODTYPEIDEN) PAN_PRODTYPEIDEN_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_PRODTYPEIDEN) PAN_PRODTYPEIDEN_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_PRODTYPEIDEN) PAN_PRODTYPEIDEN_CellActivated(ColIndex, Cancel);
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
