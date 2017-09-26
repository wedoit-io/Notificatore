// **********************************************
// API Locator
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
public partial class APILocator : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_APILOCATOR1_ID1 = 0;
  private const int PFL_APILOCATOR1_APPLICAZIONE = 1;
  private const int PFL_APILOCATOR1_CHIAVE = 2;
  private const int PFL_APILOCATOR1_AUTHKEY = 3;
  private const int PFL_APILOCATOR1_NOTA1 = 4;
  private const int PFL_APILOCATOR1_PRODOTTO = 5;
  private const int PFL_APILOCATOR1_TITOLOSTATIS = 6;

  private const int PPQRY_APILOCATOR = 0;

  private const int PPQRY_PRODOTTI = 1;


  internal IDPanel PAN_APILOCATOR1;
  internal OTabView TAB_NUOVTABBVIEW;
  private const int PFL_APILOCATOR_ID2 = 0;
  private const int PFL_APILOCATOR_IDAPP1 = 1;
  private const int PFL_APILOCATOR_VERSIONE = 2;
  private const int PFL_APILOCATOR_NOTA2 = 3;
  private const int PFL_APILOCATOR_BLOCCA = 4;
  private const int PFL_APILOCATOR_AVVISOAGGTO = 5;
  private const int PFL_APILOCATOR_FORZAAGGTO = 6;
  private const int PFL_APILOCATOR_MESSADIBLOCC = 7;

  private const int PPQRY_DETTAGLIAPP = 0;


  internal IDPanel PAN_APILOCATOR;
  private const int PFL_DETTAGVERSIO_ID = 0;
  private const int PFL_DETTAGVERSIO_IDDETTAGLAPP = 1;
  private const int PFL_DETTAGVERSIO_APIURL = 2;
  private const int PFL_DETTAGVERSIO_NOTA = 3;
  private const int PFL_DETTAGVERSIO_ORDINAMENTO = 4;
  private const int PFL_DETTAGVERSIO_ATTIVA = 5;

  private const int PPQRY_DETTAGVERSIO = 0;


  internal IDPanel PAN_DETTAGVERSIO;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_APILOCATOR(IMDB);
    Init_PQRY_DETTAGLIAPP(IMDB);
    Init_PQRY_DETTAGVERSIO(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_APILOCATOR(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_APILOCATOR, 7);
    IMDB.set_TblCode(IMDBDef1.PQRY_APILOCATOR, "PQRY_APILOCATOR");
    IMDB.set_FldCode(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_NOME_APP, "NOME_APP");
    IMDB.SetFldParams(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_NOME_APP,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_APP_KEY, "APP_KEY");
    IMDB.SetFldParams(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_APP_KEY,5,300,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_AUTH_KEY, "AUTH_KEY");
    IMDB.SetFldParams(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_AUTH_KEY,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_NOME_APP_STAT, "NOME_APP_STAT");
    IMDB.SetFldParams(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_NOME_APP_STAT,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_ID_PRODOTTO, "ID_PRODOTTO");
    IMDB.SetFldParams(IMDBDef1.PQRY_APILOCATOR,IMDBDef1.PQSL_APILOCATOR_ID_PRODOTTO,1,9,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_APILOCATOR, 0);
  }

  private static void Init_PQRY_DETTAGLIAPP(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DETTAGLIAPP, 8);
    IMDB.set_TblCode(IMDBDef1.PQRY_DETTAGLIAPP, "PQRY_DETTAGLIAPP");
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_ID_APP, "ID_APP");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_ID_APP,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_DES_VERSIONE, "DES_VERSIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_DES_VERSIONE,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_FLG_BLOCCO, "FLG_BLOCCO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_FLG_BLOCCO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_DES_MSG, "DES_MSG");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_DES_MSG,5,2000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_FLG_SHOW_UPD, "FLG_SHOW_UPD");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_FLG_SHOW_UPD,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_FLG_FORCE_UPD, "FLG_FORCE_UPD");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGLIAPP,IMDBDef1.PQSL_DETTAGLIAPP_FLG_FORCE_UPD,5,1,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_DETTAGLIAPP, 0);
  }

  private static void Init_PQRY_DETTAGVERSIO(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DETTAGVERSIO, 6);
    IMDB.set_TblCode(IMDBDef1.PQRY_DETTAGVERSIO, "PQRY_DETTAGVERSIO");
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGVERSIO,IMDBDef1.PQSL_DETTAGVERSIO_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGVERSIO,IMDBDef1.PQSL_DETTAGVERSIO_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGVERSIO,IMDBDef1.PQSL_DETTAGVERSIO_ID_DETT_APP, "ID_DETT_APP");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGVERSIO,IMDBDef1.PQSL_DETTAGVERSIO_ID_DETT_APP,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGVERSIO,IMDBDef1.PQSL_DETTAGVERSIO_ORDINAMENTO, "ORDINAMENTO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGVERSIO,IMDBDef1.PQSL_DETTAGVERSIO_ORDINAMENTO,1,10,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGVERSIO,IMDBDef1.PQSL_DETTAGVERSIO_APP_URL, "APP_URL");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGVERSIO,IMDBDef1.PQSL_DETTAGVERSIO_APP_URL,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGVERSIO,IMDBDef1.PQSL_DETTAGVERSIO_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGVERSIO,IMDBDef1.PQSL_DETTAGVERSIO_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DETTAGVERSIO,IMDBDef1.PQSL_DETTAGVERSIO_FLG_ATTIVA, "FLG_ATTIVA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DETTAGVERSIO,IMDBDef1.PQSL_DETTAGVERSIO_FLG_ATTIVA,5,1,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_DETTAGVERSIO, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public APILocator(MyWebEntryPoint w, IMDBObj imdb)
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
  public APILocator()
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
    FormIdx = MyGlb.FRM_APILOCATOR;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "A00E2206-D1DE-4A15-B983-236563743B67";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 788;
    DesignHeight = 924;
    set_Caption(new IDVariant("API Locator"));
    //
    Frames = new AFrame[7];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 788;
    Frames[1].Height = 864;
    Frames[1].Vertical = true;
    Frames[1].FormFactor = 0.37037;
    Frames[2] = new AFrame(2);
    Frames[2].Parent = this;
    Frames[1].ChildFrame1 = Frames[2];
    Frames[2].Width = 788;
    Frames[2].Height = 320;
    Frames[2].Caption = "API Locator";
    Frames[2].Parent = this;
    Frames[2].FixedHeight = 320;
    PAN_APILOCATOR1 = new IDPanel(w, this, 2, "PAN_APILOCATOR1");
    Frames[2].Content = PAN_APILOCATOR1;
    PAN_APILOCATOR1.set_ShowGroups(true);
    PAN_APILOCATOR1.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_APILOCATOR1.VS = MainFrm.VisualStyleList;
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 788-MyGlb.PAN_OFFS_X, 320-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_APILOCATOR1.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "0A6BCDBB-B519-402E-BD8E-4403B53E14EC");
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 656, 256, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_APILOCATOR1.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_APILOCATOR1.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_APILOCATOR1.InitStatus = 2;
    PAN_APILOCATOR1_Init();
    PAN_APILOCATOR1_InitFields();
    PAN_APILOCATOR1_InitQueries();
    Frames[3] = new AFrame(3);
    Frames[3].Parent = this;
    Frames[1].ChildFrame2 = Frames[3];
    Frames[3].Width = 788;
    Frames[3].Height = 544;
    Frames[3].Vertical = true;
    Frames[3].FormFactor = 0.536765;
    Frames[4] = new AFrame(4);
    Frames[4].Parent = this;
    Frames[3].ChildFrame1 = Frames[4];
    Frames[4].Width = 788;
    Frames[4].Height = 292;
    Frames[4].Caption = "Nuova Tabbed View";
    Frames[4].Parent = this;
    Frames[4].FixedHeight = 292;
    TAB_NUOVTABBVIEW = new OTabView(this);
    Frames[4].Content = TAB_NUOVTABBVIEW;
    TAB_NUOVTABBVIEW.iGuid = "17766078-D97A-4875-8D72-F6B58C2B9ED7";
    TAB_NUOVTABBVIEW.SetItemCount(1);
    TAB_NUOVTABBVIEW.Placement = 1;
    TAB_NUOVTABBVIEW.FrIndex = 4;
    Frames[5] = new AFrame(5);
    Frames[5].Parent = this;
    Frames[5].InTabbed = true;
    Frames[5].Caption = "Api Locator";
    Frames[5].Parent = this;
    PAN_APILOCATOR = new IDPanel(w, this, 5, "PAN_APILOCATOR");
    Frames[5].Content = PAN_APILOCATOR;
    PAN_APILOCATOR.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_APILOCATOR.VS = MainFrm.VisualStyleList;
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 788-MyGlb.PAN_OFFS_X, 292-MyGlb.PAN_OFFS_Y- MyGlb.PAN_OFFS_PAGEY, 0, 0);
    PAN_APILOCATOR.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "373E0E65-365A-45BA-A24B-807DD649C2F6");
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 672, 200, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_APILOCATOR.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_APILOCATOR.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_APILOCATOR.InitStatus = 2;
    PAN_APILOCATOR_Init();
    PAN_APILOCATOR_InitFields();
    PAN_APILOCATOR_InitQueries();
    TAB_NUOVTABBVIEW.SetItem(1, Frames[5], 0, "", "Api Locator", "");
    Frames[6] = new AFrame(6);
    Frames[6].Parent = this;
    Frames[3].ChildFrame2 = Frames[6];
    Frames[6].Width = 788;
    Frames[6].Height = 252;
    Frames[6].Caption = "Dettagli Versione";
    Frames[6].Parent = this;
    Frames[6].FixedHeight = 252;
    PAN_DETTAGVERSIO = new IDPanel(w, this, 6, "PAN_DETTAGVERSIO");
    Frames[6].Content = PAN_DETTAGVERSIO;
    PAN_DETTAGVERSIO.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_DETTAGVERSIO.VS = MainFrm.VisualStyleList;
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 788-MyGlb.PAN_OFFS_X, 252-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_DETTAGVERSIO.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "50F256C7-C8F1-4C1F-9894-CD6B0816F00E");
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 656, 172, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_DETTAGVERSIO.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_DETTAGVERSIO.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_DETTAGVERSIO.InitStatus = 1;
    PAN_DETTAGVERSIO_Init();
    PAN_DETTAGVERSIO_InitFields();
    PAN_DETTAGVERSIO_InitQueries();
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
      PAN_APILOCATOR1.UpdatePanel(MainFrm);
      PAN_APILOCATOR.UpdatePanel(MainFrm);
      PAN_DETTAGVERSIO.UpdatePanel(MainFrm);
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
    return (obj is APILocator);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(APILocator).FullName : typeof(APILocator).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // API Locator Before Insert
  // Evento notificato dal pannello prima dell'inserimento
  // nel database dei dati relativi ad una nuova riga di
  // pannello.
  // Cancel - Input/Output
  // **********************************************************************
  private void PAN_APILOCATOR1_BeforeInsert (IDVariant Cancel)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("AD7E2FF4-67A0-4CD3-9924-A286AF70FB7F", "API Locator Before Insert", "", 0, "API Locator")) return;
      MainFrm.DTTObj.AddParameter ("AD7E2FF4-67A0-4CD3-9924-A286AF70FB7F", "5BA3D621-A024-45B5-BB40-D1A544C52054", "Cancel", Cancel);
      // 
      // API Locator Before Insert Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddIf ("C2DAB954-F69C-4189-A83A-072A6D240088", "IF Is Null (Chiave Apps API Locator [API Locator - API Locator])", "");
      MainFrm.DTTObj.AddToken ("C2DAB954-F69C-4189-A83A-072A6D240088", "EECFE8A5-7E59-4523-A3A6-B23E83AF0CF7", 917504, "Chiave Apps", IMDB.Value(IMDBDef1.PQRY_APILOCATOR, IMDBDef1.PQSL_APILOCATOR_APP_KEY, 0));
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_APILOCATOR, IMDBDef1.PQSL_APILOCATOR_APP_KEY, 0)))
      {
        MainFrm.DTTObj.EnterIf ("C2DAB954-F69C-4189-A83A-072A6D240088", "IF Is Null (Chiave Apps API Locator [API Locator - API Locator])", "");
        MainFrm.DTTObj.AddAssign ("0DE1A995-3132-456C-8445-FF313C60905E", "Auth Key Apps API Locator [API Locator - API Locator] := Upper (Doc ID To Guid (New Doc ID ()))", "", IMDB.Value(IMDBDef1.PQRY_APILOCATOR, IMDBDef1.PQSL_APILOCATOR_AUTH_KEY, 0));
        IMDB.set_Value(IMDBDef1.PQRY_APILOCATOR, IMDBDef1.PQSL_APILOCATOR_AUTH_KEY, 0, IDL.Upper(new IDVariant(com.progamma.GUID.DocID2GUID (com.progamma.doc.MDOInit.GetNewDocID().stringValue()))));
        MainFrm.DTTObj.AddAssignNewValue ("0DE1A995-3132-456C-8445-FF313C60905E", "3790AAC1-6E60-4810-8E35-9678702A6A06", IMDB.Value(IMDBDef1.PQRY_APILOCATOR, IMDBDef1.PQSL_APILOCATOR_AUTH_KEY, 0));
      }
      MainFrm.DTTObj.EndIfBlk ("C2DAB954-F69C-4189-A83A-072A6D240088");
      MainFrm.DTTObj.ExitProc("AD7E2FF4-67A0-4CD3-9924-A286AF70FB7F", "API Locator Before Insert", "", 0, "API Locator");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("AD7E2FF4-67A0-4CD3-9924-A286AF70FB7F", "API Locator Before Insert", "", _e);
      MainFrm.ErrObj.ProcError ("APILocator", "APILocatorBeforeInsert", _e);
      MainFrm.DTTObj.ExitProc("AD7E2FF4-67A0-4CD3-9924-A286AF70FB7F", "API Locator Before Insert", "", 0, "API Locator");
    }
  }

  // **********************************************************************
  // Api Locator Before Insert
  // Evento notificato dal pannello prima dell'inserimento
  // nel database dei dati relativi ad una nuova riga di
  // pannello.
  // Cancel - Input/Output
  // **********************************************************************
  private void PAN_APILOCATOR_BeforeInsert (IDVariant Cancel)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("776E4437-F0B1-41A6-AE06-DCE83C482DE3", "Api Locator Before Insert", "", 0, "API Locator")) return;
      MainFrm.DTTObj.AddParameter ("776E4437-F0B1-41A6-AE06-DCE83C482DE3", "75457361-E7E7-4B42-98F5-E5C4A1FDE237", "Cancel", Cancel);
      // 
      // Api Locator Before Insert Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddAssign ("09425D72-EE37-42AA-89D5-DA6DC10DF532", "ID App Dettagli App [API Locator - Api Locator] := ID Apps API Locator [API Locator - API Locator]", "", IMDB.Value(IMDBDef1.PQRY_DETTAGLIAPP, IMDBDef1.PQSL_DETTAGLIAPP_ID_APP, 0));
      MainFrm.DTTObj.AddToken ("09425D72-EE37-42AA-89D5-DA6DC10DF532", "1BDD5D87-DBFF-42F9-A5F7-B855C6D1D1DB", 917504, "ID Apps", IMDB.Value(IMDBDef1.PQRY_APILOCATOR, IMDBDef1.PQSL_APILOCATOR_ID, 0));
      IMDB.set_Value(IMDBDef1.PQRY_DETTAGLIAPP, IMDBDef1.PQSL_DETTAGLIAPP_ID_APP, 0, IMDB.Value(IMDBDef1.PQRY_APILOCATOR, IMDBDef1.PQSL_APILOCATOR_ID, 0));
      MainFrm.DTTObj.AddAssignNewValue ("09425D72-EE37-42AA-89D5-DA6DC10DF532", "1B3A6C79-FC55-48AA-AF1C-7541F7FB1C94", IMDB.Value(IMDBDef1.PQRY_DETTAGLIAPP, IMDBDef1.PQSL_DETTAGLIAPP_ID_APP, 0));
      MainFrm.DTTObj.ExitProc("776E4437-F0B1-41A6-AE06-DCE83C482DE3", "Api Locator Before Insert", "", 0, "API Locator");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("776E4437-F0B1-41A6-AE06-DCE83C482DE3", "Api Locator Before Insert", "", _e);
      MainFrm.ErrObj.ProcError ("APILocator", "ApiLocatorBeforeInsert", _e);
      MainFrm.DTTObj.ExitProc("776E4437-F0B1-41A6-AE06-DCE83C482DE3", "Api Locator Before Insert", "", 0, "API Locator");
    }
  }

  // **********************************************************************
  // Dettagli Versione Before Insert
  // Evento notificato dal pannello prima dell'inserimento
  // nel database dei dati relativi ad una nuova riga di
  // pannello.
  // Cancel - Input/Output
  // **********************************************************************
  private void PAN_DETTAGVERSIO_BeforeInsert (IDVariant Cancel)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("15D8CB4C-6CC9-4055-9AE2-DB431A4DF9E9", "Dettagli Versione Before Insert", "", 0, "API Locator")) return;
      MainFrm.DTTObj.AddParameter ("15D8CB4C-6CC9-4055-9AE2-DB431A4DF9E9", "E8692B18-7483-41E9-B0FD-75CFFAC246A6", "Cancel", Cancel);
      // 
      // Dettagli Versione Before Insert Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddAssign ("0DA7629C-4D76-4169-922C-F9AF2B982E4F", "ID Dettagli App Dettaglio Versione [API Locator - Dettagli Versione] := ID Dettagli App [API Locator - Api Locator]", "", IMDB.Value(IMDBDef1.PQRY_DETTAGVERSIO, IMDBDef1.PQSL_DETTAGVERSIO_ID_DETT_APP, 0));
      MainFrm.DTTObj.AddToken ("0DA7629C-4D76-4169-922C-F9AF2B982E4F", "5DBCDD0D-03DC-47EB-A89E-A191FEA12917", 917504, "ID Dettagli App", IMDB.Value(IMDBDef1.PQRY_DETTAGLIAPP, IMDBDef1.PQSL_DETTAGLIAPP_ID, 0));
      IMDB.set_Value(IMDBDef1.PQRY_DETTAGVERSIO, IMDBDef1.PQSL_DETTAGVERSIO_ID_DETT_APP, 0, IMDB.Value(IMDBDef1.PQRY_DETTAGLIAPP, IMDBDef1.PQSL_DETTAGLIAPP_ID, 0));
      MainFrm.DTTObj.AddAssignNewValue ("0DA7629C-4D76-4169-922C-F9AF2B982E4F", "75C99615-BD15-4281-8A33-7068B686B2D4", IMDB.Value(IMDBDef1.PQRY_DETTAGVERSIO, IMDBDef1.PQSL_DETTAGVERSIO_ID_DETT_APP, 0));
      MainFrm.DTTObj.ExitProc("15D8CB4C-6CC9-4055-9AE2-DB431A4DF9E9", "Dettagli Versione Before Insert", "", 0, "API Locator");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("15D8CB4C-6CC9-4055-9AE2-DB431A4DF9E9", "Dettagli Versione Before Insert", "", _e);
      MainFrm.ErrObj.ProcError ("APILocator", "DettagliVersioneBeforeInsert", _e);
      MainFrm.DTTObj.ExitProc("15D8CB4C-6CC9-4055-9AE2-DB431A4DF9E9", "Dettagli Versione Before Insert", "", 0, "API Locator");
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

      if (!MainFrm.DTTObj.EnterProc("F9839C48-4F23-4E03-B238-57293D9CBDA6", "Load", "", 0, "API Locator")) return;
      // 
      // Load Body
      // Corpo Procedura
      // 
      // PAN_APILOCATOR1.set_GroupingEnabled((new IDVariant(-1)).booleanValue());
      // PAN_APILOCATOR1.set_ShowGroups((new IDVariant(-1)).booleanValue());
      // PAN_APILOCATOR1.AddToGroupingList((new IDVariant(PFL_APILOCATOR1_PRODOTTO)).intValue(),(new IDVariant(-1)).booleanValue()); 
      // PAN_APILOCATOR1.PanelCommand(Glb.PCM_FIND);
      // PAN_APILOCATOR1.RefreshGrouping(true);
      // PAN_APILOCATOR1.RD3ExpandGroup((new IDVariant(0)).intValue(),(new IDVariant(-1)).booleanValue()); 
      // PAN_APILOCATOR1.set_ActualPosition(true, (new IDVariant(1)).intValue());
      MainFrm.DTTObj.ExitProc("F9839C48-4F23-4E03-B238-57293D9CBDA6", "Load", "", 0, "API Locator");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("F9839C48-4F23-4E03-B238-57293D9CBDA6", "Load", "", _e);
      MainFrm.ErrObj.ProcError ("APILocator", "Load", _e);
      MainFrm.DTTObj.ExitProc("F9839C48-4F23-4E03-B238-57293D9CBDA6", "Load", "", 0, "API Locator");
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
  private void PAN_APILOCATOR1_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_APILOCATOR1_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_APILOCATOR1_ValidateRow(IDVariant Cancel)
  {
    try
    {
    } catch ( Exception e) { }
  }

  private void TAB_NUOVTABBVIEW_Click(IDVariant OldPage, IDVariant Cancel)
  {
  }

  private void PAN_APILOCATOR_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_APILOCATOR_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_APILOCATOR_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DETTAGLIAPP, IMDBDef1.PQSL_DETTAGLIAPP_FLG_BLOCCO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DETTAGLIAPP, IMDBDef1.PQSL_DETTAGLIAPP_FLG_BLOCCO, 0, (new IDVariant("S")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DETTAGLIAPP, IMDBDef1.PQSL_DETTAGLIAPP_FLG_SHOW_UPD, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DETTAGLIAPP, IMDBDef1.PQSL_DETTAGLIAPP_FLG_SHOW_UPD, 0, (new IDVariant("N")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DETTAGLIAPP, IMDBDef1.PQSL_DETTAGLIAPP_FLG_FORCE_UPD, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DETTAGLIAPP, IMDBDef1.PQSL_DETTAGLIAPP_FLG_FORCE_UPD, 0, (new IDVariant("N")));
      }
    } catch ( Exception e) { }
  }

  private void PAN_DETTAGVERSIO_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_DETTAGVERSIO_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_DETTAGVERSIO_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DETTAGVERSIO, IMDBDef1.PQSL_DETTAGVERSIO_FLG_ATTIVA, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DETTAGVERSIO, IMDBDef1.PQSL_DETTAGVERSIO_FLG_ATTIVA, 0, (new IDVariant("S")));
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_APILOCATOR1_Init()
  {

    PAN_APILOCATOR1.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_APILOCATOR1.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_APILOCATOR1.SetSize(MyGlb.OBJ_FIELD, 7);
    PAN_APILOCATOR1.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, "6265185A-CD22-431D-8DF7-7192F903CA7C");
    PAN_APILOCATOR1.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, "ID");
    PAN_APILOCATOR1.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, "Identificativo univoco");
    PAN_APILOCATOR1.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_APILOCATOR1.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, 0 | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_APILOCATOR1.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, "25B2EE04-7F9E-4E79-9B2A-ADB5D2AF1AD0");
    PAN_APILOCATOR1.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, "Applicazione");
    PAN_APILOCATOR1.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, "");
    PAN_APILOCATOR1.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, MyGlb.VIS_NORMALFIELDS);
    PAN_APILOCATOR1.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISDESCR, -1);
    PAN_APILOCATOR1.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, "40CCC81A-1DAB-4CE5-BF6D-4E9153378D82");
    PAN_APILOCATOR1.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, "Chiave");
    PAN_APILOCATOR1.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, "Chiave dell'applicazione");
    PAN_APILOCATOR1.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, MyGlb.VIS_NORMALFIELDS);
    PAN_APILOCATOR1.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, 0 | MyGlb.FLD_ISOPT, -1);
    PAN_APILOCATOR1.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, "DC83DE15-A76B-4D33-9368-DF510DE0A310");
    PAN_APILOCATOR1.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, "Auth Key");
    PAN_APILOCATOR1.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, "Descrivi il contenuto del campo");
    PAN_APILOCATOR1.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, MyGlb.VIS_NORMALFIELDS);
    PAN_APILOCATOR1.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, 0 | MyGlb.FLD_ISOPT, -1);
    PAN_APILOCATOR1.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, "C4270DF7-A0AD-4107-8186-578AC098FD74");
    PAN_APILOCATOR1.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, "Nota");
    PAN_APILOCATOR1.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, "Nota");
    PAN_APILOCATOR1.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, MyGlb.VIS_NORMALFIELDS);
    PAN_APILOCATOR1.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APILOCATOR1.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, "F8767256-F191-4753-B488-5D71080965EC");
    PAN_APILOCATOR1.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, "Prodotto");
    PAN_APILOCATOR1.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, "Identificativo univoco");
    PAN_APILOCATOR1.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, MyGlb.VIS_FOREIKEYFIEL);
    PAN_APILOCATOR1.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP, -1);
    PAN_APILOCATOR1.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, "536713DE-FEB8-424E-9054-A50AD5C85523");
    PAN_APILOCATOR1.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, "Titolo Statistiche");
    PAN_APILOCATOR1.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, "");
    PAN_APILOCATOR1.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, MyGlb.VIS_NORMALFIELDS);
    PAN_APILOCATOR1.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISDESCR, -1);
  }

  private void PAN_APILOCATOR1_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, MyGlb.PANEL_LIST, 0, 32, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, MyGlb.PANEL_LIST, 20);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, MyGlb.PANEL_LIST, "ID");
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, MyGlb.PANEL_FORM, 4, 4, 128, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, MyGlb.PANEL_FORM, 80);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, MyGlb.PANEL_FORM, 1);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_ID1, MyGlb.PANEL_FORM, "ID");
    PAN_APILOCATOR1.SetFieldPage(PFL_APILOCATOR1_ID1, -1, -1);
    PAN_APILOCATOR1.SetFieldPanel(PFL_APILOCATOR1_ID1, PPQRY_APILOCATOR, "A.ID", "ID", 1, 9, 0, -1709);
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, MyGlb.PANEL_LIST, 0, 32, 384, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, MyGlb.PANEL_LIST, 96);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, MyGlb.PANEL_FORM, 4, 28, 480, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, MyGlb.PANEL_FORM, 80);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, MyGlb.PANEL_FORM, 1);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_APILOCATOR1.SetFieldPage(PFL_APILOCATOR1_APPLICAZIONE, -1, -1);
    PAN_APILOCATOR1.SetFieldPanel(PFL_APILOCATOR1_APPLICAZIONE, PPQRY_APILOCATOR, "A.NOME_APP", "NOME_APP", 5, 200, 0, -1709);
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, MyGlb.PANEL_LIST, 116, 32, 116, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, MyGlb.PANEL_LIST, 96);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, MyGlb.PANEL_LIST, "Chiave");
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, MyGlb.PANEL_FORM, 4, 100, 480, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, MyGlb.PANEL_FORM, 80);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, MyGlb.PANEL_FORM, 2);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_CHIAVE, MyGlb.PANEL_FORM, "Chiave");
    PAN_APILOCATOR1.SetFieldPage(PFL_APILOCATOR1_CHIAVE, -1, -1);
    PAN_APILOCATOR1.SetFieldPanel(PFL_APILOCATOR1_CHIAVE, PPQRY_APILOCATOR, "A.APP_KEY", "APP_KEY", 5, 300, 0, -1709);
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, MyGlb.PANEL_LIST, 116, 32, 152, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, MyGlb.PANEL_LIST, 96);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, MyGlb.PANEL_LIST, "Auth Key");
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, MyGlb.PANEL_FORM, 4, 124, 480, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, MyGlb.PANEL_FORM, 80);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, MyGlb.PANEL_FORM, 2);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_AUTHKEY, MyGlb.PANEL_FORM, "Auth Key");
    PAN_APILOCATOR1.SetFieldPage(PFL_APILOCATOR1_AUTHKEY, -1, -1);
    PAN_APILOCATOR1.SetFieldPanel(PFL_APILOCATOR1_AUTHKEY, PPQRY_APILOCATOR, "A.AUTH_KEY", "AUTH_KEY", 5, 1000, 0, -1709);
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, MyGlb.PANEL_LIST, 384, 32, 104, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, MyGlb.PANEL_LIST, 96);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, MyGlb.PANEL_LIST, "Nota");
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, MyGlb.PANEL_FORM, 4, 52, 480, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, MyGlb.PANEL_FORM, 80);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, MyGlb.PANEL_FORM, 1);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_NOTA1, MyGlb.PANEL_FORM, "Nota");
    PAN_APILOCATOR1.SetFieldPage(PFL_APILOCATOR1_NOTA1, -1, -1);
    PAN_APILOCATOR1.SetFieldPanel(PFL_APILOCATOR1_NOTA1, PPQRY_APILOCATOR, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -1709);
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, MyGlb.PANEL_LIST, 488, 32, 68, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, MyGlb.PANEL_LIST, 64);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, MyGlb.PANEL_LIST, "Prodotto");
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, MyGlb.PANEL_FORM, 4, 208, 124, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, MyGlb.PANEL_FORM, 64);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, MyGlb.PANEL_FORM, 1);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_PRODOTTO, MyGlb.PANEL_FORM, "Prodotto");
    PAN_APILOCATOR1.SetFieldPage(PFL_APILOCATOR1_PRODOTTO, -1, -1);
    PAN_APILOCATOR1.SetFieldPanel(PFL_APILOCATOR1_PRODOTTO, PPQRY_APILOCATOR, "A.ID_PRODOTTO", "ID_PRODOTTO", 1, 9, 0, -1709);
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, MyGlb.PANEL_LIST, 556, 32, 100, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, MyGlb.PANEL_LIST, 88);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, MyGlb.PANEL_LIST, "Tit. Statistiche");
    PAN_APILOCATOR1.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, MyGlb.PANEL_FORM, 4, 172, 596, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR1.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, MyGlb.PANEL_FORM, 88);
    PAN_APILOCATOR1.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, MyGlb.PANEL_FORM, 1);
    PAN_APILOCATOR1.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR1_TITOLOSTATIS, MyGlb.PANEL_FORM, "Tit. Statis.");
    PAN_APILOCATOR1.SetFieldPage(PFL_APILOCATOR1_TITOLOSTATIS, -1, -1);
    PAN_APILOCATOR1.SetFieldPanel(PFL_APILOCATOR1_TITOLOSTATIS, PPQRY_APILOCATOR, "A.NOME_APP_STAT", "NOME_APP_STAT", 5, 200, 0, -1709);
  }

  private void PAN_APILOCATOR1_InitQueries()
  {
    StringBuilder SQL;

    PAN_APILOCATOR1.SetSize(MyGlb.OBJ_QUERY, 2);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.NOME_APP as NOMEPRODOTTO ");
    SQL.Append("from ");
    SQL.Append("  PRODOTTI A ");
    SQL.Append("where (A.ID = ~~ID_PRODOTTO~~) ");
    PAN_APILOCATOR1.SetQuery(PPQRY_PRODOTTI, 0, SQL, PFL_APILOCATOR1_PRODOTTO, "06234CB2-F68E-4116-9C5E-CA9966817050");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.NOME_APP as NOMEPRODOTTO ");
    SQL.Append("from ");
    SQL.Append("  PRODOTTI A ");
    PAN_APILOCATOR1.SetQuery(PPQRY_PRODOTTI, 1, SQL, PFL_APILOCATOR1_PRODOTTO, "");
    PAN_APILOCATOR1.SetQueryDB(PPQRY_PRODOTTI, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_APILOCATOR1.SetIMDB(IMDB, "PQRY_APILOCATOR", true);
    PAN_APILOCATOR1.set_SetString(MyGlb.MASTER_ROWNAME, "API Locator");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.NOME_APP as NOME_APP, ");
    SQL.Append("  A.DES_NOTA as DES_NOTA, ");
    SQL.Append("  A.APP_KEY as APP_KEY, ");
    SQL.Append("  A.AUTH_KEY as AUTH_KEY, ");
    SQL.Append("  A.NOME_APP_STAT as NOME_APP_STAT, ");
    SQL.Append("  A.ID_PRODOTTO as ID_PRODOTTO ");
    PAN_APILOCATOR1.SetQuery(PPQRY_APILOCATOR, 0, SQL, -1, "A47B1803-4FED-44A9-BD50-0544D741BC31");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  APPS A ");
    PAN_APILOCATOR1.SetQuery(PPQRY_APILOCATOR, 1, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APILOCATOR1.SetQuery(PPQRY_APILOCATOR, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APILOCATOR1.SetQuery(PPQRY_APILOCATOR, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APILOCATOR1.SetQuery(PPQRY_APILOCATOR, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APILOCATOR1.SetQuery(PPQRY_APILOCATOR, 5, SQL, -1, "");
    PAN_APILOCATOR1.SetQueryDB(PPQRY_APILOCATOR, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_APILOCATOR1.SetMasterTable(0, "APPS");
    SQL = new StringBuilder("");
    PAN_APILOCATOR1.SetQuery(0, -1, SQL, PFL_APILOCATOR1_ID1, "");
  }

  private void PAN_APILOCATOR_Init()
  {

    PAN_APILOCATOR.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_APILOCATOR.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_APILOCATOR.SetSize(MyGlb.OBJ_FIELD, 8);
    PAN_APILOCATOR.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, "A58DE905-0006-4C36-B0E9-552D5D0F0D7D");
    PAN_APILOCATOR.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, "ID");
    PAN_APILOCATOR.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, "Identificativo univoco");
    PAN_APILOCATOR.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_APILOCATOR.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, 0 | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_APILOCATOR.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, "B9E546DA-936D-4505-8FEC-1A3D0C9A612B");
    PAN_APILOCATOR.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, "ID App");
    PAN_APILOCATOR.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, "Identificativo univoco");
    PAN_APILOCATOR.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, MyGlb.VIS_FOREIKEYFIEL);
    PAN_APILOCATOR.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, 0, -1);
    PAN_APILOCATOR.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, "4FB1AA5C-5E36-4CD1-8DA2-C84172E8F9E7");
    PAN_APILOCATOR.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, "Versione");
    PAN_APILOCATOR.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, "Versione");
    PAN_APILOCATOR.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, MyGlb.VIS_NORMALFIELDS);
    PAN_APILOCATOR.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISDESCR, -1);
    PAN_APILOCATOR.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, "56C46DCC-FF18-4203-9BED-182BFD4D244F");
    PAN_APILOCATOR.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, "Nota");
    PAN_APILOCATOR.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, "Nota");
    PAN_APILOCATOR.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, MyGlb.VIS_NORMALFIELDS);
    PAN_APILOCATOR.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_APILOCATOR.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, "D47A9C76-7225-4187-A210-72B0A1D57DBB");
    PAN_APILOCATOR.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, "Blocca");
    PAN_APILOCATOR.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, "");
    PAN_APILOCATOR.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, MyGlb.VIS_NORMALFIELDS);
    PAN_APILOCATOR.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APILOCATOR.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, "5A722C34-BBC3-4258-881D-E6FCEC7AE2BF");
    PAN_APILOCATOR.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, "Avviso Agg To");
    PAN_APILOCATOR.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, "");
    PAN_APILOCATOR.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, MyGlb.VIS_NORMALFIELDS);
    PAN_APILOCATOR.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APILOCATOR.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, "B3F59B95-1194-4610-9941-96AD155BA13E");
    PAN_APILOCATOR.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, "Forza Agg To");
    PAN_APILOCATOR.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, "");
    PAN_APILOCATOR.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, MyGlb.VIS_NORMALFIELDS);
    PAN_APILOCATOR.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APILOCATOR.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, "4C0B1129-5E43-4817-8196-D1B03B4298BD");
    PAN_APILOCATOR.set_Header(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, "Messaggio di blocco");
    PAN_APILOCATOR.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, "Messaggio");
    PAN_APILOCATOR.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, MyGlb.VIS_NORMALFIELDS);
    PAN_APILOCATOR.SetFlags(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_APILOCATOR_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, MyGlb.PANEL_LIST, 0, 32, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, MyGlb.PANEL_LIST, 20);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, MyGlb.PANEL_LIST, "ID");
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, MyGlb.PANEL_FORM, 4, 4, 112, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, MyGlb.PANEL_FORM, 64);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, MyGlb.PANEL_FORM, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_ID2, MyGlb.PANEL_FORM, "ID");
    PAN_APILOCATOR.SetFieldPage(PFL_APILOCATOR_ID2, -1, -1);
    PAN_APILOCATOR.SetFieldPanel(PFL_APILOCATOR_ID2, PPQRY_DETTAGLIAPP, "A.ID", "ID", 1, 9, 0, -1709);
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, MyGlb.PANEL_LIST, 40, 32, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, MyGlb.PANEL_LIST, 44);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, MyGlb.PANEL_LIST, "ID App");
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, MyGlb.PANEL_FORM, 4, 28, 112, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, MyGlb.PANEL_FORM, 64);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, MyGlb.PANEL_FORM, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_IDAPP1, MyGlb.PANEL_FORM, "ID App");
    PAN_APILOCATOR.SetFieldPage(PFL_APILOCATOR_IDAPP1, -1, -1);
    PAN_APILOCATOR.SetFieldPanel(PFL_APILOCATOR_IDAPP1, PPQRY_DETTAGLIAPP, "A.ID_APP", "ID_APP", 1, 9, 0, -1709);
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, MyGlb.PANEL_LIST, 0, 32, 76, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, MyGlb.PANEL_LIST, 120);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, MyGlb.PANEL_LIST, "Versione");
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, MyGlb.PANEL_FORM, 4, 52, 464, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, MyGlb.PANEL_FORM, 64);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, MyGlb.PANEL_FORM, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_VERSIONE, MyGlb.PANEL_FORM, "Versione");
    PAN_APILOCATOR.SetFieldPage(PFL_APILOCATOR_VERSIONE, -1, -1);
    PAN_APILOCATOR.SetFieldPanel(PFL_APILOCATOR_VERSIONE, PPQRY_DETTAGLIAPP, "A.DES_VERSIONE", "DES_VERSIONE", 5, 200, 0, -1709);
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, MyGlb.PANEL_LIST, 76, 32, 196, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, MyGlb.PANEL_LIST, 32);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, MyGlb.PANEL_LIST, "Nota");
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, MyGlb.PANEL_FORM, 4, 112, 544, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, MyGlb.PANEL_FORM, 32);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, MyGlb.PANEL_FORM, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_NOTA2, MyGlb.PANEL_FORM, "Nt.");
    PAN_APILOCATOR.SetFieldPage(PFL_APILOCATOR_NOTA2, -1, -1);
    PAN_APILOCATOR.SetFieldPanel(PFL_APILOCATOR_NOTA2, PPQRY_DETTAGLIAPP, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -1709);
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, MyGlb.PANEL_LIST, 272, 32, 40, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, MyGlb.PANEL_LIST, 40);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, MyGlb.PANEL_LIST, "Bloc.");
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, MyGlb.PANEL_FORM, 4, 184, 84, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, MyGlb.PANEL_FORM, 40);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, MyGlb.PANEL_FORM, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_BLOCCA, MyGlb.PANEL_FORM, "Bloc.");
    PAN_APILOCATOR.SetFieldPage(PFL_APILOCATOR_BLOCCA, -1, -1);
    PAN_APILOCATOR.SetFieldPanel(PFL_APILOCATOR_BLOCCA, PPQRY_DETTAGLIAPP, "A.FLG_BLOCCO", "FLG_BLOCCO", 5, 1, 0, -1709);
    PAN_APILOCATOR.SetValueListItem(PFL_APILOCATOR_BLOCCA, (new IDVariant("S")), "Si", "", "", -1);
    PAN_APILOCATOR.SetValueListItem(PFL_APILOCATOR_BLOCCA, (new IDVariant("N")), "No", "", "", -1);
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, MyGlb.PANEL_LIST, 312, 32, 44, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, MyGlb.PANEL_LIST, 80);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, MyGlb.PANEL_LIST, "A. A. T.");
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, MyGlb.PANEL_FORM, 4, 256, 124, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, MyGlb.PANEL_FORM, 80);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, MyGlb.PANEL_FORM, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_AVVISOAGGTO, MyGlb.PANEL_FORM, "Avv. Agg To");
    PAN_APILOCATOR.SetFieldPage(PFL_APILOCATOR_AVVISOAGGTO, -1, -1);
    PAN_APILOCATOR.SetFieldPanel(PFL_APILOCATOR_AVVISOAGGTO, PPQRY_DETTAGLIAPP, "A.FLG_SHOW_UPD", "FLG_SHOW_UPD", 5, 1, 0, -1709);
    PAN_APILOCATOR.SetValueListItem(PFL_APILOCATOR_AVVISOAGGTO, (new IDVariant("N")), "No", "", "", -1);
    PAN_APILOCATOR.SetValueListItem(PFL_APILOCATOR_AVVISOAGGTO, (new IDVariant("S")), "Si", "", "", -1);
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, MyGlb.PANEL_LIST, 356, 32, 48, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, MyGlb.PANEL_LIST, 72);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, MyGlb.PANEL_LIST, "F. A. T.");
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, MyGlb.PANEL_FORM, 4, 280, 116, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, MyGlb.PANEL_FORM, 72);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, MyGlb.PANEL_FORM, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_FORZAAGGTO, MyGlb.PANEL_FORM, "For. Agg To");
    PAN_APILOCATOR.SetFieldPage(PFL_APILOCATOR_FORZAAGGTO, -1, -1);
    PAN_APILOCATOR.SetFieldPanel(PFL_APILOCATOR_FORZAAGGTO, PPQRY_DETTAGLIAPP, "A.FLG_FORCE_UPD", "FLG_FORCE_UPD", 5, 1, 0, -1709);
    PAN_APILOCATOR.SetValueListItem(PFL_APILOCATOR_FORZAAGGTO, (new IDVariant("N")), "No", "", "", -1);
    PAN_APILOCATOR.SetValueListItem(PFL_APILOCATOR_FORZAAGGTO, (new IDVariant("S")), "Si", "", "", -1);
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, MyGlb.PANEL_LIST, 404, 32, 268, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, MyGlb.PANEL_LIST, 60);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, MyGlb.PANEL_LIST, 1);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, MyGlb.PANEL_LIST, "Messaggio di blocco");
    PAN_APILOCATOR.SetRect(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, MyGlb.PANEL_FORM, 4, 208, 496, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APILOCATOR.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, MyGlb.PANEL_FORM, 60);
    PAN_APILOCATOR.SetNumRow(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, MyGlb.PANEL_FORM, 2);
    PAN_APILOCATOR.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APILOCATOR_MESSADIBLOCC, MyGlb.PANEL_FORM, "Mess. di blocco");
    PAN_APILOCATOR.SetFieldPage(PFL_APILOCATOR_MESSADIBLOCC, -1, -1);
    PAN_APILOCATOR.SetFieldPanel(PFL_APILOCATOR_MESSADIBLOCC, PPQRY_DETTAGLIAPP, "A.DES_MSG", "DES_MSG", 5, 2000, 0, -1709);
  }

  private void PAN_APILOCATOR_InitQueries()
  {
    StringBuilder SQL;

    PAN_APILOCATOR.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_APILOCATOR.SetIMDB(IMDB, "PQRY_DETTAGLIAPP", true);
    PAN_APILOCATOR.set_SetString(MyGlb.MASTER_ROWNAME, "Dettagli App");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.ID_APP as ID_APP, ");
    SQL.Append("  A.DES_VERSIONE as DES_VERSIONE, ");
    SQL.Append("  A.DES_NOTA as DES_NOTA, ");
    SQL.Append("  A.FLG_BLOCCO as FLG_BLOCCO, ");
    SQL.Append("  A.DES_MSG as DES_MSG, ");
    SQL.Append("  A.FLG_SHOW_UPD as FLG_SHOW_UPD, ");
    SQL.Append("  A.FLG_FORCE_UPD as FLG_FORCE_UPD ");
    PAN_APILOCATOR.SetQuery(PPQRY_DETTAGLIAPP, 0, SQL, -1, "20173290-B97A-4DCA-B3F4-195335CC1551");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  APP_DETAILS A ");
    PAN_APILOCATOR.SetQuery(PPQRY_DETTAGLIAPP, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.ID_APP = ~~PQRY_APILOCATOR.ID~~) ");
    PAN_APILOCATOR.SetQuery(PPQRY_DETTAGLIAPP, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APILOCATOR.SetQuery(PPQRY_DETTAGLIAPP, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APILOCATOR.SetQuery(PPQRY_DETTAGLIAPP, 4, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("order by ");
    SQL.Append("  A.DES_VERSIONE desc ");
    PAN_APILOCATOR.SetQuery(PPQRY_DETTAGLIAPP, 5, SQL, -1, "");
    PAN_APILOCATOR.SetQueryDB(PPQRY_DETTAGLIAPP, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_APILOCATOR.SetMasterTable(0, "APP_DETAILS");
    PAN_APILOCATOR.AddToSortList(PFL_APILOCATOR_VERSIONE, false);
    SQL = new StringBuilder("");
    PAN_APILOCATOR.SetQuery(0, -1, SQL, PFL_APILOCATOR_ID2, "");
  }

  private void PAN_DETTAGVERSIO_Init()
  {

    PAN_DETTAGVERSIO.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_DETTAGVERSIO.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_DETTAGVERSIO.SetSize(MyGlb.OBJ_FIELD, 6);
    PAN_DETTAGVERSIO.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, "7506386B-573B-4884-AAAD-DFA734089D53");
    PAN_DETTAGVERSIO.set_Header(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, "ID");
    PAN_DETTAGVERSIO.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, "Identificativo univoco");
    PAN_DETTAGVERSIO.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_DETTAGVERSIO.SetFlags(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, 0 | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_DETTAGVERSIO.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, "041F1655-6E28-4C14-B7BD-11DE42781118");
    PAN_DETTAGVERSIO.set_Header(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, "ID Dettagli App");
    PAN_DETTAGVERSIO.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, "Identificativo univoco");
    PAN_DETTAGVERSIO.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, MyGlb.VIS_FOREIKEYFIEL);
    PAN_DETTAGVERSIO.SetFlags(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, 0, -1);
    PAN_DETTAGVERSIO.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, "3C7F12C8-C48C-4BFA-A7B5-EAFB058C2899");
    PAN_DETTAGVERSIO.set_Header(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, "Api Url");
    PAN_DETTAGVERSIO.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, "App url 1");
    PAN_DETTAGVERSIO.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, MyGlb.VIS_NORMALFIELDS);
    PAN_DETTAGVERSIO.SetFlags(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_DETTAGVERSIO.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, "891A5F95-BDFA-4F98-843F-F8F4DD792C4F");
    PAN_DETTAGVERSIO.set_Header(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, "Nota");
    PAN_DETTAGVERSIO.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, "Nota");
    PAN_DETTAGVERSIO.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, MyGlb.VIS_NORMALFIELDS);
    PAN_DETTAGVERSIO.SetFlags(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_DETTAGVERSIO.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, "47FC2CA2-190A-4011-8EAB-1F87CFB6B2D2");
    PAN_DETTAGVERSIO.set_Header(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, "Ordinamento");
    PAN_DETTAGVERSIO.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, "Ordinamento");
    PAN_DETTAGVERSIO.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, MyGlb.VIS_NORMALFIELDS);
    PAN_DETTAGVERSIO.SetFlags(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_DETTAGVERSIO.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, "3C39E155-A9C5-4DC7-8818-4A6A75EBCB3F");
    PAN_DETTAGVERSIO.set_Header(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, "Attiva");
    PAN_DETTAGVERSIO.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, "");
    PAN_DETTAGVERSIO.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, MyGlb.VIS_NORMALFIELDS);
    PAN_DETTAGVERSIO.SetFlags(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_DETTAGVERSIO_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, MyGlb.PANEL_LIST, 0, 32, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, MyGlb.PANEL_LIST, 20);
    PAN_DETTAGVERSIO.SetNumRow(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, MyGlb.PANEL_LIST, 1);
    PAN_DETTAGVERSIO.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, MyGlb.PANEL_LIST, "ID");
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, MyGlb.PANEL_FORM, 4, 4, 176, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, MyGlb.PANEL_FORM, 128);
    PAN_DETTAGVERSIO.SetNumRow(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, MyGlb.PANEL_FORM, 1);
    PAN_DETTAGVERSIO.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ID, MyGlb.PANEL_FORM, "ID");
    PAN_DETTAGVERSIO.SetFieldPage(PFL_DETTAGVERSIO_ID, -1, -1);
    PAN_DETTAGVERSIO.SetFieldPanel(PFL_DETTAGVERSIO_ID, PPQRY_DETTAGVERSIO, "A.ID", "ID", 1, 9, 0, -1709);
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, MyGlb.PANEL_LIST, 40, 32, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, MyGlb.PANEL_LIST, 84);
    PAN_DETTAGVERSIO.SetNumRow(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, MyGlb.PANEL_LIST, 1);
    PAN_DETTAGVERSIO.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, MyGlb.PANEL_LIST, "I. D. A.");
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, MyGlb.PANEL_FORM, 4, 28, 176, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, MyGlb.PANEL_FORM, 128);
    PAN_DETTAGVERSIO.SetNumRow(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, MyGlb.PANEL_FORM, 1);
    PAN_DETTAGVERSIO.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_IDDETTAGLAPP, MyGlb.PANEL_FORM, "ID Dettagli App");
    PAN_DETTAGVERSIO.SetFieldPage(PFL_DETTAGVERSIO_IDDETTAGLAPP, -1, -1);
    PAN_DETTAGVERSIO.SetFieldPanel(PFL_DETTAGVERSIO_IDDETTAGLAPP, PPQRY_DETTAGVERSIO, "A.ID_DETT_APP", "ID_DETT_APP", 1, 9, 0, -1709);
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, MyGlb.PANEL_LIST, 0, 32, 372, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, MyGlb.PANEL_LIST, 128);
    PAN_DETTAGVERSIO.SetNumRow(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, MyGlb.PANEL_LIST, 1);
    PAN_DETTAGVERSIO.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, MyGlb.PANEL_LIST, "Api Url");
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, MyGlb.PANEL_FORM, 4, 100, 528, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, MyGlb.PANEL_FORM, 128);
    PAN_DETTAGVERSIO.SetNumRow(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, MyGlb.PANEL_FORM, 1);
    PAN_DETTAGVERSIO.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_APIURL, MyGlb.PANEL_FORM, "Api Url");
    PAN_DETTAGVERSIO.SetFieldPage(PFL_DETTAGVERSIO_APIURL, -1, -1);
    PAN_DETTAGVERSIO.SetFieldPanel(PFL_DETTAGVERSIO_APIURL, PPQRY_DETTAGVERSIO, "A.APP_URL", "APP_URL", 5, 200, 0, -1709);
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, MyGlb.PANEL_LIST, 372, 32, 196, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, MyGlb.PANEL_LIST, 128);
    PAN_DETTAGVERSIO.SetNumRow(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, MyGlb.PANEL_LIST, 1);
    PAN_DETTAGVERSIO.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, MyGlb.PANEL_LIST, "Nota");
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, MyGlb.PANEL_FORM, 4, 124, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, MyGlb.PANEL_FORM, 128);
    PAN_DETTAGVERSIO.SetNumRow(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, MyGlb.PANEL_FORM, 1);
    PAN_DETTAGVERSIO.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_NOTA, MyGlb.PANEL_FORM, "Nota");
    PAN_DETTAGVERSIO.SetFieldPage(PFL_DETTAGVERSIO_NOTA, -1, -1);
    PAN_DETTAGVERSIO.SetFieldPanel(PFL_DETTAGVERSIO_NOTA, PPQRY_DETTAGVERSIO, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -1709);
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, MyGlb.PANEL_LIST, 568, 32, 44, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, MyGlb.PANEL_LIST, 72);
    PAN_DETTAGVERSIO.SetNumRow(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, MyGlb.PANEL_LIST, 1);
    PAN_DETTAGVERSIO.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, MyGlb.PANEL_LIST, "Ordin.");
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, MyGlb.PANEL_FORM, 4, 76, 176, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, MyGlb.PANEL_FORM, 128);
    PAN_DETTAGVERSIO.SetNumRow(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, MyGlb.PANEL_FORM, 1);
    PAN_DETTAGVERSIO.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ORDINAMENTO, MyGlb.PANEL_FORM, "Ordinamento");
    PAN_DETTAGVERSIO.SetFieldPage(PFL_DETTAGVERSIO_ORDINAMENTO, -1, -1);
    PAN_DETTAGVERSIO.SetFieldPanel(PFL_DETTAGVERSIO_ORDINAMENTO, PPQRY_DETTAGVERSIO, "A.ORDINAMENTO", "ORDINAMENTO", 1, 10, 0, -1709);
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, MyGlb.PANEL_LIST, 612, 32, 44, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, MyGlb.PANEL_LIST, 40);
    PAN_DETTAGVERSIO.SetNumRow(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, MyGlb.PANEL_LIST, 1);
    PAN_DETTAGVERSIO.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, MyGlb.PANEL_LIST, "Attiva");
    PAN_DETTAGVERSIO.SetRect(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, MyGlb.PANEL_FORM, 4, 148, 176, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DETTAGVERSIO.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, MyGlb.PANEL_FORM, 128);
    PAN_DETTAGVERSIO.SetNumRow(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, MyGlb.PANEL_FORM, 1);
    PAN_DETTAGVERSIO.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DETTAGVERSIO_ATTIVA, MyGlb.PANEL_FORM, "Attiva");
    PAN_DETTAGVERSIO.SetFieldPage(PFL_DETTAGVERSIO_ATTIVA, -1, -1);
    PAN_DETTAGVERSIO.SetFieldPanel(PFL_DETTAGVERSIO_ATTIVA, PPQRY_DETTAGVERSIO, "A.FLG_ATTIVA", "FLG_ATTIVA", 5, 1, 0, -1709);
    PAN_DETTAGVERSIO.SetValueListItem(PFL_DETTAGVERSIO_ATTIVA, (new IDVariant("S")), "Si", "", "", -1);
    PAN_DETTAGVERSIO.SetValueListItem(PFL_DETTAGVERSIO_ATTIVA, (new IDVariant("N")), "No", "", "", -1);
  }

  private void PAN_DETTAGVERSIO_InitQueries()
  {
    StringBuilder SQL;

    PAN_DETTAGVERSIO.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_DETTAGVERSIO.SetIMDB(IMDB, "PQRY_DETTAGVERSIO", true);
    PAN_DETTAGVERSIO.set_SetString(MyGlb.MASTER_ROWNAME, "Dettaglio Versione");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.ID_DETT_APP as ID_DETT_APP, ");
    SQL.Append("  A.ORDINAMENTO as ORDINAMENTO, ");
    SQL.Append("  A.APP_URL as APP_URL, ");
    SQL.Append("  A.DES_NOTA as DES_NOTA, ");
    SQL.Append("  A.FLG_ATTIVA as FLG_ATTIVA ");
    PAN_DETTAGVERSIO.SetQuery(PPQRY_DETTAGVERSIO, 0, SQL, -1, "766DB762-1613-4D7A-898E-E7EA614029CC");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  REL_DETAILS A ");
    PAN_DETTAGVERSIO.SetQuery(PPQRY_DETTAGVERSIO, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.ID_DETT_APP = ~~PQRY_DETTAGLIAPP.ID~~) ");
    PAN_DETTAGVERSIO.SetQuery(PPQRY_DETTAGVERSIO, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DETTAGVERSIO.SetQuery(PPQRY_DETTAGVERSIO, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DETTAGVERSIO.SetQuery(PPQRY_DETTAGVERSIO, 4, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("order by ");
    SQL.Append("  A.ORDINAMENTO ");
    PAN_DETTAGVERSIO.SetQuery(PPQRY_DETTAGVERSIO, 5, SQL, -1, "");
    PAN_DETTAGVERSIO.SetQueryDB(PPQRY_DETTAGVERSIO, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DETTAGVERSIO.SetMasterTable(0, "REL_DETAILS");
    PAN_DETTAGVERSIO.AddToSortList(PFL_DETTAGVERSIO_ORDINAMENTO, true);
    SQL = new StringBuilder("");
    PAN_DETTAGVERSIO.SetQuery(0, -1, SQL, PFL_DETTAGVERSIO_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_APILOCATOR1) PAN_APILOCATOR1_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
    if (SrcObj == PAN_APILOCATOR) PAN_APILOCATOR_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
    if (SrcObj == PAN_DETTAGVERSIO) PAN_DETTAGVERSIO_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_APILOCATOR1) PAN_APILOCATOR1_ValidateRow(Cancel);
    if (SrcObj == PAN_APILOCATOR) PAN_APILOCATOR_ValidateRow(Cancel);
    if (SrcObj == PAN_DETTAGVERSIO) PAN_DETTAGVERSIO_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_APILOCATOR1) PAN_APILOCATOR1_CellActivated(ColIndex, Cancel);
    if (SrcObj == PAN_APILOCATOR) PAN_APILOCATOR_CellActivated(ColIndex, Cancel);
    if (SrcObj == PAN_DETTAGVERSIO) PAN_DETTAGVERSIO_CellActivated(ColIndex, Cancel);
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
    if (SrcObj == PAN_APILOCATOR1) PAN_APILOCATOR1_BeforeInsert(Cancel);
    if (SrcObj == PAN_APILOCATOR) PAN_APILOCATOR_BeforeInsert(Cancel);
    if (SrcObj == PAN_DETTAGVERSIO) PAN_DETTAGVERSIO_BeforeInsert(Cancel);
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
