// **********************************************
// Grafico Andamento
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
public partial class GraficoAndamento : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_SELETTORE_UTENTE = 0;
  private const int PFL_SELETTORE_APP = 1;
  private const int PFL_SELETTORE_TIPO = 2;
  private const int PFL_SELETTORE_RANGE = 3;
  private const int PFL_SELETTORE_DATAA = 4;

  private const int PPQRY_SELETTGRAFI1 = 0;

  private const int PPQRY_UTENTI = 1;
  private const int PPQRY_APPS = 2;


  internal IDPanel PAN_SELETTORE;
  internal OTabView TAB_NUOVTABBVIEW;
  internal AGraph GRH_GRAFTEMPORAL;
  private const int PFL_DATI_ANNO = 0;
  private const int PFL_DATI_MESE = 1;
  private const int PFL_DATI_GIORNO = 2;
  private const int PFL_DATI_DATA = 3;
  private const int PFL_DATI_UNITS = 4;

  private const int PPQRY_STATAPPLE = 0;


  internal IDPanel PAN_DATI;
  private const int PFL_DATENONCARIC_DATEMANCANTI = 0;

  private const int PPQRY_SALESDATA = 0;


  internal IDPanel PAN_DATENONCARIC;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_SELETTGRAFI1(IMDB);
    Init_PQRY_SELETTGRAFI1_RS(IMDB);
    Init_PQRY_STATAPPLE1(IMDB);
    Init_PQRY_STATAPPLE(IMDB);
    Init_PQRY_SALESDATA(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_SELETTGRAFI1(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_SELETTGRAFI1, 5);
    IMDB.set_TblCode(IMDBDef1.PQRY_SELETTGRAFI1, "PQRY_SELETTGRAFI1");
    IMDB.set_FldCode(IMDBDef1.PQRY_SELETTGRAFI1,IMDBDef1.PQSL_SELETTGRAFI1_ID_UTENTE, "ID_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SELETTGRAFI1,IMDBDef1.PQSL_SELETTGRAFI1_ID_UTENTE,1,6,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SELETTGRAFI1,IMDBDef1.PQSL_SELETTGRAFI1_ID_APP, "ID_APP");
    IMDB.SetFldParams(IMDBDef1.PQRY_SELETTGRAFI1,IMDBDef1.PQSL_SELETTGRAFI1_ID_APP,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SELETTGRAFI1,IMDBDef1.PQSL_SELETTGRAFI1_TIPOSELEGRAF, "TIPOSELEGRAF");
    IMDB.SetFldParams(IMDBDef1.PQRY_SELETTGRAFI1,IMDBDef1.PQSL_SELETTGRAFI1_TIPOSELEGRAF,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SELETTGRAFI1,IMDBDef1.PQSL_SELETTGRAFI1_DATADASELGRA, "DATADASELGRA");
    IMDB.SetFldParams(IMDBDef1.PQRY_SELETTGRAFI1,IMDBDef1.PQSL_SELETTGRAFI1_DATADASELGRA,6,52,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SELETTGRAFI1,IMDBDef1.PQSL_SELETTGRAFI1_DATAASELEGRA, "DATAASELEGRA");
    IMDB.SetFldParams(IMDBDef1.PQRY_SELETTGRAFI1,IMDBDef1.PQSL_SELETTGRAFI1_DATAASELEGRA,6,52,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_SELETTGRAFI1, 0);
  }

  private static void Init_PQRY_SELETTGRAFI1_RS(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_SELETTGRAFI1_RS, 5);
    IMDB.set_TblCode(IMDBDef1.PQRY_SELETTGRAFI1_RS, "PQRY_SELETTGRAFI1_RS");
    IMDB.set_FldCode(IMDBDef1.PQRY_SELETTGRAFI1_RS,IMDBDef1.PQSL_SELETTGRAFI1_ID_UTENTE, "ID_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SELETTGRAFI1_RS,IMDBDef1.PQSL_SELETTGRAFI1_ID_UTENTE,1,6,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SELETTGRAFI1_RS,IMDBDef1.PQSL_SELETTGRAFI1_ID_APP, "ID_APP");
    IMDB.SetFldParams(IMDBDef1.PQRY_SELETTGRAFI1_RS,IMDBDef1.PQSL_SELETTGRAFI1_ID_APP,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SELETTGRAFI1_RS,IMDBDef1.PQSL_SELETTGRAFI1_TIPOSELEGRAF, "TIPOSELEGRAF");
    IMDB.SetFldParams(IMDBDef1.PQRY_SELETTGRAFI1_RS,IMDBDef1.PQSL_SELETTGRAFI1_TIPOSELEGRAF,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SELETTGRAFI1_RS,IMDBDef1.PQSL_SELETTGRAFI1_DATADASELGRA, "DATADASELGRA");
    IMDB.SetFldParams(IMDBDef1.PQRY_SELETTGRAFI1_RS,IMDBDef1.PQSL_SELETTGRAFI1_DATADASELGRA,6,52,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SELETTGRAFI1_RS,IMDBDef1.PQSL_SELETTGRAFI1_DATAASELEGRA, "DATAASELEGRA");
    IMDB.SetFldParams(IMDBDef1.PQRY_SELETTGRAFI1_RS,IMDBDef1.PQSL_SELETTGRAFI1_DATAASELEGRA,6,52,0);
  }

  private static void Init_PQRY_STATAPPLE1(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_STATAPPLE1, 2);
    IMDB.set_TblCode(IMDBDef1.PQRY_STATAPPLE1, "PQRY_STATAPPLE1");
    IMDB.set_FldCode(IMDBDef1.PQRY_STATAPPLE1,IMDBDef1.PQSL_STATAPPLE1_DATARECORD, "DATARECORD");
    IMDB.SetFldParams(IMDBDef1.PQRY_STATAPPLE1,IMDBDef1.PQSL_STATAPPLE1_DATARECORD,6,52,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_STATAPPLE1,IMDBDef1.PQSL_STATAPPLE1_UNITSRECORD, "UNITSRECORD");
    IMDB.SetFldParams(IMDBDef1.PQRY_STATAPPLE1,IMDBDef1.PQSL_STATAPPLE1_UNITSRECORD,3,28,6);
    IMDB.TblAddNew(IMDBDef1.PQRY_STATAPPLE1, 0);
  }

  private static void Init_PQRY_STATAPPLE(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_STATAPPLE, 5);
    IMDB.set_TblCode(IMDBDef1.PQRY_STATAPPLE, "PQRY_STATAPPLE");
    IMDB.set_FldCode(IMDBDef1.PQRY_STATAPPLE,IMDBDef1.PQSL_STATAPPLE_ANNSTAAPPREC, "ANNSTAAPPREC");
    IMDB.SetFldParams(IMDBDef1.PQRY_STATAPPLE,IMDBDef1.PQSL_STATAPPLE_ANNSTAAPPREC,1,19,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_STATAPPLE,IMDBDef1.PQSL_STATAPPLE_MESSTAAPPREC, "MESSTAAPPREC");
    IMDB.SetFldParams(IMDBDef1.PQRY_STATAPPLE,IMDBDef1.PQSL_STATAPPLE_MESSTAAPPREC,1,19,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_STATAPPLE,IMDBDef1.PQSL_STATAPPLE_GIOSTAAPPREC, "GIOSTAAPPREC");
    IMDB.SetFldParams(IMDBDef1.PQRY_STATAPPLE,IMDBDef1.PQSL_STATAPPLE_GIOSTAAPPREC,1,19,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_STATAPPLE,IMDBDef1.PQSL_STATAPPLE_DATSTAAPPREC, "DATSTAAPPREC");
    IMDB.SetFldParams(IMDBDef1.PQRY_STATAPPLE,IMDBDef1.PQSL_STATAPPLE_DATSTAAPPREC,6,52,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_STATAPPLE,IMDBDef1.PQSL_STATAPPLE_UNITSRECORD, "UNITSRECORD");
    IMDB.SetFldParams(IMDBDef1.PQRY_STATAPPLE,IMDBDef1.PQSL_STATAPPLE_UNITSRECORD,3,28,6);
    IMDB.TblAddNew(IMDBDef1.PQRY_STATAPPLE, 0);
  }

  private static void Init_PQRY_SALESDATA(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_SALESDATA, 1);
    IMDB.set_TblCode(IMDBDef1.PQRY_SALESDATA, "PQRY_SALESDATA");
    IMDB.set_FldCode(IMDBDef1.PQRY_SALESDATA,IMDBDef1.PQSL_SALESDATA_DATEMANCRECO, "DATEMANCRECO");
    IMDB.SetFldParams(IMDBDef1.PQRY_SALESDATA,IMDBDef1.PQSL_SALESDATA_DATEMANCRECO,6,52,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_SALESDATA, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public GraficoAndamento(MyWebEntryPoint w, IMDBObj imdb)
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
  public GraficoAndamento()
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
    FormIdx = MyGlb.FRM_GRAFICANDAME;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "F7E0CEF3-B2BC-4D43-BAA6-363EA6E619C0";
    ResModeW = 1;
    ResModeH = 1;
    iVisualFlags = -2049;
    DesignWidth = 1112;
    DesignHeight = 680;
    set_Caption(new IDVariant("Grafico Andamento"));
    //
    Frames = new AFrame[7];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 1112;
    Frames[1].Height = 620;
    Frames[1].Vertical = true;
    Frames[1].FormFactor = 0.109677;
    Frames[2] = new AFrame(2);
    Frames[2].Parent = this;
    Frames[1].ChildFrame1 = Frames[2];
    Frames[2].Width = 1112;
    Frames[2].Height = 68;
    Frames[2].Caption = "Selettore";
    Frames[2].Parent = this;
    Frames[2].FixedHeight = 68;
    PAN_SELETTORE = new IDPanel(w, this, 2, "PAN_SELETTORE");
    Frames[2].Content = PAN_SELETTORE;
    PAN_SELETTORE.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_SELETTORE.VS = MainFrm.VisualStyleList;
    PAN_SELETTORE.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 1112-MyGlb.PAN_OFFS_X, 68-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_SELETTORE.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "F3B84D12-C363-4601-8BF7-43EEA10CE409");
    PAN_SELETTORE.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 916, 56, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_SELETTORE.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_SELETTORE.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_SELETTORE.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_STARTFORM | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.PAN_AUTOSAVE | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_SELETTORE.InitStatus = 1;
    PAN_SELETTORE_Init();
    PAN_SELETTORE_InitFields();
    PAN_SELETTORE_InitQueries();
    Frames[3] = new AFrame(3);
    Frames[3].Parent = this;
    Frames[1].ChildFrame2 = Frames[3];
    Frames[3].Width = 1112;
    Frames[3].Height = 552;
    Frames[3].Caption = "Nuova Tabbed View";
    Frames[3].Parent = this;
    Frames[3].FixedHeight = 552;
    TAB_NUOVTABBVIEW = new OTabView(this);
    Frames[3].Content = TAB_NUOVTABBVIEW;
    TAB_NUOVTABBVIEW.iGuid = "203F3853-76F3-4114-B005-AC552B3C1738";
    TAB_NUOVTABBVIEW.SetItemCount(3);
    TAB_NUOVTABBVIEW.Placement = 1;
    TAB_NUOVTABBVIEW.FrIndex = 3;
    Frames[4] = new AFrame(4);
    Frames[4].Parent = this;
    Frames[4].InTabbed = true;
    GRH_GRAFTEMPORAL = new AGraph(this);
    Frames[4].Caption = "Graf Temporale";
    Frames[4].Parent = this;
    Frames[4].Content = GRH_GRAFTEMPORAL;
    GRH_GRAFTEMPORAL.FrIndex = 4;
    GRH_GRAFTEMPORAL.Code = "GRH_GRAFTEMPORAL";
    GRH_GRAFTEMPORAL.GraphCode = "NUOVTABBVIEW_GRAFTEMPORAL";
    GRH_GRAFTEMPORAL.set_ChartType(9);
    GRH_GRAFTEMPORAL.set_Title("Sales Periodici");
    GRH_GRAFTEMPORAL.set_LabelAxisX("");
    GRH_GRAFTEMPORAL.set_LabelAxisY("");
    GRH_GRAFTEMPORAL.set_Legenda(1);
    GRH_GRAFTEMPORAL.set_Flags(40042753);
    GRH_GRAFTEMPORAL.Height = 486;
    GRH_GRAFTEMPORAL.Width = 1112;
    GRH_GRAFTEMPORAL.iGuid = "2A438898-A322-4772-B70C-48A911E1BCA2";
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.DATA as DATARECORD, ");
    SQL.Append("  SUM(A.UNITS) as UNITSRECORD ");
    SQL.Append("from ");
    SQL.Append("  V_STAT_APPLE A ");
    SQL.Append("where ((A.ID_UTENTE = ~~PQRY_SELETTGRAFI1.ID_UTENTE~~) OR (~~PQRY_SELETTGRAFI1.ID_UTENTE~~ IS NULL)) ");
    SQL.Append("and   ((A.ID_APP = ~~PQRY_SELETTGRAFI1.ID_APP~~) OR (~~PQRY_SELETTGRAFI1.ID_APP~~ IS NULL)) ");
    SQL.Append("and   ((~~PQRY_SELETTGRAFI1.TIPOSELEGRAF~~ = 'F' AND A.FREE_APP = -1) OR (~~PQRY_SELETTGRAFI1.TIPOSELEGRAF~~ = 'P' AND A.PAID_APP = -1) OR (~~PQRY_SELETTGRAFI1.TIPOSELEGRAF~~ = 'U' AND A.UPD_APP = -1) OR ((~~PQRY_SELETTGRAFI1.TIPOSELEGRAF~~ IS NULL))) ");
    SQL.Append("and   (~~PQRY_SELETTGRAFI1.DATADASELGRA~~ <= A.DATA OR (~~PQRY_SELETTGRAFI1.DATADASELGRA~~ IS NULL)) ");
    SQL.Append("and   (~~PQRY_SELETTGRAFI1.DATAASELEGRA~~ >= A.DATA OR (~~PQRY_SELETTGRAFI1.DATAASELEGRA~~ IS NULL)) ");
    SQL.Append("group by ");
    SQL.Append("  A.DATA ");
    GRH_GRAFTEMPORAL.SetQuery(SQL, MainFrm.NotificatoreDBObject.DB, MainFrm, "576EEBA1-76E8-4A70-A1AA-593D155A0DBA");
    GRH_GRAFTEMPORAL.SetIMDBTable(IMDBDef1.PQRY_STATAPPLE1);
    GRH_GRAFTEMPORAL.set_NumSeries(1);
    GRH_GRAFTEMPORAL.set_SerieLabel(1,"Units");
    TAB_NUOVTABBVIEW.SetItem(1, Frames[4], 0, "", "Graf Temporale", "Sales Periodici");
    Frames[5] = new AFrame(5);
    Frames[5].Parent = this;
    Frames[5].InTabbed = true;
    Frames[5].Caption = "Dati";
    Frames[5].Parent = this;
    PAN_DATI = new IDPanel(w, this, 5, "PAN_DATI");
    Frames[5].Content = PAN_DATI;
    PAN_DATI.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_DATI.VS = MainFrm.VisualStyleList;
    PAN_DATI.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 1112-MyGlb.PAN_OFFS_X, 552-MyGlb.PAN_OFFS_Y- MyGlb.PAN_OFFS_PAGEY, 0, 0);
    PAN_DATI.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "F50A18AE-4E1D-4684-AE17-B4021AD6F85B");
    PAN_DATI.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 572, 496, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_DATI.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_DATI.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_DATI.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANSELECT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_DATI.InitStatus = 1;
    PAN_DATI_Init();
    PAN_DATI_InitFields();
    PAN_DATI_InitQueries();
    TAB_NUOVTABBVIEW.SetItem(2, Frames[5], 0, "", "Dati", "");
    Frames[6] = new AFrame(6);
    Frames[6].Parent = this;
    Frames[6].InTabbed = true;
    Frames[6].Caption = "Date non caricate";
    Frames[6].Parent = this;
    PAN_DATENONCARIC = new IDPanel(w, this, 6, "PAN_DATENONCARIC");
    Frames[6].Content = PAN_DATENONCARIC;
    PAN_DATENONCARIC.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_DATENONCARIC.VS = MainFrm.VisualStyleList;
    PAN_DATENONCARIC.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 1112-MyGlb.PAN_OFFS_X, 552-MyGlb.PAN_OFFS_Y- MyGlb.PAN_OFFS_PAGEY, 0, 0);
    PAN_DATENONCARIC.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "B6FDCFB0-DE8F-461F-83E5-D03367ED3C24");
    PAN_DATENONCARIC.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 268, 476, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_DATENONCARIC.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_DATENONCARIC.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_DATENONCARIC.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANSELECT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_DATENONCARIC.InitStatus = 2;
    PAN_DATENONCARIC_Init();
    PAN_DATENONCARIC_InitFields();
    PAN_DATENONCARIC_InitQueries();
    TAB_NUOVTABBVIEW.SetItem(3, Frames[6], 0, "", "Date non caricate", "");
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
      if (IMDB.TblModified(IMDBDef1.TBL_SELETTGRAFIC, MyGlb.GlbRefModIdx) || JustLoaded)
      {
        GRAFICANDAME_SELETTGRAFI1();
      }
      PAN_SELETTORE.UpdatePanel(MainFrm);
      PAN_DATI.UpdatePanel(MainFrm);
      PAN_DATENONCARIC.UpdatePanel(MainFrm);
      GRH_GRAFTEMPORAL.UpdateGraph(MainFrm);
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
    return (obj is GraficoAndamento);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(GraficoAndamento).FullName : typeof(GraficoAndamento).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
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

      if (!MainFrm.DTTObj.EnterProc("4419AA2A-ECFD-4195-9553-C27E69C60EFA", "Load", "", 0, "Grafico Andamento")) return;
      // 
      // Load Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddSubProc ("B930A9F9-E049-473A-AE6B-99A867DD1E35", "Graf Temporale.Set Type", "");
      MainFrm.DTTObj.AddParameter ("B930A9F9-E049-473A-AE6B-99A867DD1E35", "D4D1886A-BBAF-4327-A40E-41F2EC1455A1", "Graph Type", (new IDVariant(2)));
      GRH_GRAFTEMPORAL.set_ChartType((new IDVariant(2)).intValue()); 
      MainFrm.DTTObj.AddSubProc ("5701B254-A9AF-4300-8347-11D3826ECB26", "Graf Temporale.Set Library", "");
      MainFrm.DTTObj.AddParameter ("5701B254-A9AF-4300-8347-11D3826ECB26", "5CCE4546-BA8B-4F84-B04E-9308F9F5DD9A", "Library", (new IDVariant(2)));
      GRH_GRAFTEMPORAL.setLibrary((new IDVariant(2)).intValue()); 
      MainFrm.DTTObj.ExitProc("4419AA2A-ECFD-4195-9553-C27E69C60EFA", "Load", "", 0, "Grafico Andamento");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("4419AA2A-ECFD-4195-9553-C27E69C60EFA", "Load", "", _e);
      MainFrm.ErrObj.ProcError ("GraficoAndamento", "Load", _e);
      MainFrm.DTTObj.ExitProc("4419AA2A-ECFD-4195-9553-C27E69C60EFA", "Load", "", 0, "Grafico Andamento");
    }
  }

  // **********************************************************************
  // Selettori Grafico
  // Recupera i record da mostrare nel pannello
  // **********************************************************************
  private void GRAFICANDAME_SELETTGRAFI1()
  {
    IDVariant[] AggrBuff;
    int[] AggrRowCount;
    int AggrCount=0;
    bool AggrNewGroup = false;

    IMDB.TblTruncate(IMDBDef1.PQRY_SELETTGRAFI1_RS);
    IMDB.TblMoveFirst(IMDBDef1.TBL_SELETTGRAFIC, 0);
    Loop1: while (!IMDB.Eof(IMDBDef1.TBL_SELETTGRAFIC, 0))
    {
      IMDB.TblAddNew(IMDBDef1.PQRY_SELETTGRAFI1_RS, 0);
      IMDB.TblLinkRow(IMDBDef1.PQRY_SELETTGRAFI1_RS, 0, IMDBDef1.TBL_SELETTGRAFIC, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_SELETTGRAFI1_RS, 0, 0, IMDBDef1.TBL_SELETTGRAFIC, IMDBDef1.FLD_SELETTGRAFIC_ID_UTENTE, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_SELETTGRAFI1_RS, 1, 0, IMDBDef1.TBL_SELETTGRAFIC, IMDBDef1.FLD_SELETTGRAFIC_ID_APP, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_SELETTGRAFI1_RS, 2, 0, IMDBDef1.TBL_SELETTGRAFIC, IMDBDef1.FLD_SELETTGRAFIC_TIPOSELEGRAF, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_SELETTGRAFI1_RS, 3, 0, IMDBDef1.TBL_SELETTGRAFIC, IMDBDef1.FLD_SELETTGRAFIC_DATADASELGRA, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_SELETTGRAFI1_RS, 4, 0, IMDBDef1.TBL_SELETTGRAFIC, IMDBDef1.FLD_SELETTGRAFIC_DATAASELEGRA, 0);
      IMDB.TblMoveNext(IMDBDef1.TBL_SELETTGRAFIC, 0);
      if (IMDB.Eof(IMDBDef1.TBL_SELETTGRAFIC, 0))
      {
        IMDB.TblMoveFirst(IMDBDef1.TBL_SELETTGRAFIC, 0);
      }
      else
      {
        goto Loop1;
      }
      break;
    }
    IMDB.TblMoveFirst(IMDBDef1.PQRY_SELETTGRAFI1_RS, 0);
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
  private void PAN_SELETTORE_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_SELETTORE_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_SELETTORE_ValidateRow(IDVariant Cancel)
  {
    try
    {
    } catch ( Exception e) { }
  }

  private void TAB_NUOVTABBVIEW_Click(IDVariant OldPage, IDVariant Cancel)
  {
  }

  private void PAN_DATI_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_DATI_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_DATI_ValidateRow(IDVariant Cancel)
  {
    try
    {
    } catch ( Exception e) { }
  }

  private void PAN_DATENONCARIC_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_DATENONCARIC_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_DATENONCARIC_ValidateRow(IDVariant Cancel)
  {
    try
    {
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_SELETTORE_Init()
  {

    PAN_SELETTORE.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_SELETTORE.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_SELETTORE.SetSize(MyGlb.OBJ_FIELD, 5);
    PAN_SELETTORE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, "97C10F6B-6202-4B84-85FA-74097F85473D");
    PAN_SELETTORE.set_Header(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, "Utente");
    PAN_SELETTORE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, "");
    PAN_SELETTORE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_SELETTORE.SetFlags(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_NOACTD | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISKEY, -1);
    PAN_SELETTORE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, "040961B5-16B7-47BE-BE34-9766672A36CF");
    PAN_SELETTORE.set_Header(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, "App");
    PAN_SELETTORE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, "Identificativo univoco");
    PAN_SELETTORE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_SELETTORE.SetFlags(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISKEY, -1);
    PAN_SELETTORE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, "0170B4D8-6725-4ECA-B864-FFA9EB40F388");
    PAN_SELETTORE.set_Header(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, "Tipo");
    PAN_SELETTORE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, "");
    PAN_SELETTORE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, MyGlb.VIS_NORMALFIELDS);
    PAN_SELETTORE.SetFlags(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISOPT, -1);
    PAN_SELETTORE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, "CDE813BB-5D53-4B31-B95A-4D09AFCDF252");
    PAN_SELETTORE.set_Header(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, "Range");
    PAN_SELETTORE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, "");
    PAN_SELETTORE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, MyGlb.VIS_NORMALFIELDS);
    PAN_SELETTORE.SetFlags(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISOPT, -1);
    PAN_SELETTORE.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, "D3E78BBC-E5C8-4D88-A4EC-631097922C97");
    PAN_SELETTORE.set_Header(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, "Data A");
    PAN_SELETTORE.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, "");
    PAN_SELETTORE.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, MyGlb.VIS_NORMALFIELDS);
    PAN_SELETTORE.SetFlags(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_NOHDRLIST | MyGlb.FLD_NOHDRFORM | MyGlb.FLD_INFORM | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_SELETTORE_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_SELETTORE.SetRect(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, MyGlb.PANEL_LIST, 0, 32, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SELETTORE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, MyGlb.PANEL_LIST, 56);
    PAN_SELETTORE.SetNumRow(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, MyGlb.PANEL_LIST, 1);
    PAN_SELETTORE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, MyGlb.PANEL_LIST, "Utente");
    PAN_SELETTORE.SetRect(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, MyGlb.PANEL_FORM, 4, 4, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SELETTORE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, MyGlb.PANEL_FORM, 56);
    PAN_SELETTORE.SetNumRow(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, MyGlb.PANEL_FORM, 1);
    PAN_SELETTORE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SELETTORE_UTENTE, MyGlb.PANEL_FORM, "Utente");
    PAN_SELETTORE.SetFieldPage(PFL_SELETTORE_UTENTE, -1, -1);
    PAN_SELETTORE.SetFieldPanel(PFL_SELETTORE_UTENTE, PPQRY_SELETTGRAFI1, "A.ID_UTENTE", "ID_UTENTE", 1, 6, 0, -1709);
    PAN_SELETTORE.SetRect(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, MyGlb.PANEL_LIST, 0, 32, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SELETTORE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, MyGlb.PANEL_LIST, 44);
    PAN_SELETTORE.SetNumRow(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, MyGlb.PANEL_LIST, 1);
    PAN_SELETTORE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, MyGlb.PANEL_LIST, "App");
    PAN_SELETTORE.SetRect(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, MyGlb.PANEL_FORM, 180, 4, 192, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SELETTORE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, MyGlb.PANEL_FORM, 44);
    PAN_SELETTORE.SetNumRow(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, MyGlb.PANEL_FORM, 1);
    PAN_SELETTORE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SELETTORE_APP, MyGlb.PANEL_FORM, "App");
    PAN_SELETTORE.SetFieldPage(PFL_SELETTORE_APP, -1, -1);
    PAN_SELETTORE.SetFieldPanel(PFL_SELETTORE_APP, PPQRY_SELETTGRAFI1, "A.ID_APP", "ID_APP", 1, 9, 0, -1709);
    PAN_SELETTORE.SetRect(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, MyGlb.PANEL_LIST, 0, 32, 268, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SELETTORE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, MyGlb.PANEL_LIST, 28);
    PAN_SELETTORE.SetNumRow(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, MyGlb.PANEL_LIST, 1);
    PAN_SELETTORE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, MyGlb.PANEL_LIST, "Tipo");
    PAN_SELETTORE.SetRect(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, MyGlb.PANEL_FORM, 380, 4, 148, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SELETTORE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, MyGlb.PANEL_FORM, 28);
    PAN_SELETTORE.SetNumRow(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, MyGlb.PANEL_FORM, 1);
    PAN_SELETTORE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SELETTORE_TIPO, MyGlb.PANEL_FORM, "Tp.");
    PAN_SELETTORE.SetFieldPage(PFL_SELETTORE_TIPO, -1, -1);
    PAN_SELETTORE.SetFieldPanel(PFL_SELETTORE_TIPO, PPQRY_SELETTGRAFI1, "A.TIPOSELEGRAF", "TIPOSELEGRAF", 5, 1, 0, -1709);
    PAN_SELETTORE.SetValueListItem(PFL_SELETTORE_TIPO, (new IDVariant("F")), "Free", "", "", -1);
    PAN_SELETTORE.SetValueListItem(PFL_SELETTORE_TIPO, (new IDVariant("P")), "Paid", "", "", -1);
    PAN_SELETTORE.SetValueListItem(PFL_SELETTORE_TIPO, (new IDVariant("U")), "Update", "", "", -1);
    PAN_SELETTORE.SetRect(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, MyGlb.PANEL_LIST, 0, 32, 268, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SELETTORE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, MyGlb.PANEL_LIST, 48);
    PAN_SELETTORE.SetNumRow(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, MyGlb.PANEL_LIST, 1);
    PAN_SELETTORE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, MyGlb.PANEL_LIST, "Range");
    PAN_SELETTORE.SetRect(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, MyGlb.PANEL_FORM, 540, 4, 152, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SELETTORE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, MyGlb.PANEL_FORM, 48);
    PAN_SELETTORE.SetNumRow(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, MyGlb.PANEL_FORM, 1);
    PAN_SELETTORE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SELETTORE_RANGE, MyGlb.PANEL_FORM, "Range");
    PAN_SELETTORE.SetFieldPage(PFL_SELETTORE_RANGE, -1, -1);
    PAN_SELETTORE.SetFieldPanel(PFL_SELETTORE_RANGE, PPQRY_SELETTGRAFI1, "A.DATADASELGRA", "DATADASELGRA", 6, 52, 0, -1709);
    PAN_SELETTORE.SetRect(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, MyGlb.PANEL_LIST, 0, 32, 268, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SELETTORE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, MyGlb.PANEL_LIST, 44);
    PAN_SELETTORE.SetNumRow(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, MyGlb.PANEL_LIST, 1);
    PAN_SELETTORE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, MyGlb.PANEL_LIST, "Data A");
    PAN_SELETTORE.SetRect(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, MyGlb.PANEL_FORM, 704, 4, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SELETTORE.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, MyGlb.PANEL_FORM, 44);
    PAN_SELETTORE.SetNumRow(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, MyGlb.PANEL_FORM, 1);
    PAN_SELETTORE.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SELETTORE_DATAA, MyGlb.PANEL_FORM, "Dt. A");
    PAN_SELETTORE.SetFieldPage(PFL_SELETTORE_DATAA, -1, -1);
    PAN_SELETTORE.SetFieldPanel(PFL_SELETTORE_DATAA, PPQRY_SELETTGRAFI1, "A.DATAASELEGRA", "DATAASELEGRA", 6, 52, 0, -1709);
  }

  private void PAN_SELETTORE_InitQueries()
  {
    StringBuilder SQL;

    PAN_SELETTORE.SetSize(MyGlb.OBJ_QUERY, 3);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDUTENTE, ");
    SQL.Append("  A.COGNOME as COGNOMUTENTE ");
    SQL.Append("from ");
    SQL.Append("  UTENTI A ");
    SQL.Append("where (A.ID = ~~ID_UTENTE~~) ");
    PAN_SELETTORE.SetQuery(PPQRY_UTENTI, 0, SQL, PFL_SELETTORE_UTENTE, "2387A4B9-B92B-4255-9ACD-5D192B1DE864");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDUTENTE, ");
    SQL.Append("  A.COGNOME as COGNOMUTENTE ");
    SQL.Append("from ");
    SQL.Append("  UTENTI A ");
    PAN_SELETTORE.SetQuery(PPQRY_UTENTI, 1, SQL, PFL_SELETTORE_UTENTE, "");
    PAN_SELETTORE.SetQueryDB(PPQRY_UTENTI, MainFrm.NotificatoreDBObject.DB, 256);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPP, ");
    SQL.Append("  A.NOME_APP as APPLICAZIAPP ");
    SQL.Append("from ");
    SQL.Append("  APPS A, ");
    SQL.Append("  APPS_UTENTI B ");
    SQL.Append("where A.ID = B.ID_APP ");
    SQL.Append("and   (A.ID = ~~ID_APP~~) ");
    SQL.Append("and   (~~ID_UTENTE~~ = B.ID_UTENTE) ");
    SQL.Append("and   ((~~ID_UTENTE~~ = B.ID_UTENTE) OR (~~ID_UTENTE~~ IS NULL)) ");
    SQL.Append("order by ");
    SQL.Append("  A.NOME_APP ");
    PAN_SELETTORE.SetQuery(PPQRY_APPS, 0, SQL, PFL_SELETTORE_APP, "ADC75E07-9F42-47A9-8D70-E0E287AB1986");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPP, ");
    SQL.Append("  A.NOME_APP as APPLICAZIAPP ");
    SQL.Append("from ");
    SQL.Append("  APPS A, ");
    SQL.Append("  APPS_UTENTI B ");
    SQL.Append("where A.ID = B.ID_APP ");
    SQL.Append("and   (~~ID_UTENTE~~ = B.ID_UTENTE) ");
    SQL.Append("and   ((~~ID_UTENTE~~ = B.ID_UTENTE) OR (~~ID_UTENTE~~ IS NULL)) ");
    SQL.Append("order by ");
    SQL.Append("  A.NOME_APP ");
    PAN_SELETTORE.SetQuery(PPQRY_APPS, 1, SQL, PFL_SELETTORE_APP, "");
    PAN_SELETTORE.SetQueryDB(PPQRY_APPS, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_SELETTORE.SetQueryHeaderColumn(PPQRY_APPS, "APPLICAZIAPP", "Applicazione App");
    PAN_SELETTORE.SetQueryVisibleColumn(PPQRY_APPS, "APPLICAZIAPP");
    PAN_SELETTORE.SetIMDB(IMDB, "PQRY_SELETTGRAFI1", true);
    PAN_SELETTORE.set_SetString(MyGlb.MASTER_ROWNAME, "Record");
    PAN_SELETTORE.SetQueryIMDB(PPQRY_SELETTGRAFI1, IMDBDef1.PQRY_SELETTGRAFI1_RS, IMDBDef1.TBL_SELETTGRAFIC);
    JustLoaded = true;
    PAN_SELETTORE.SetFieldPrimaryIndex(PFL_SELETTORE_UTENTE, IMDBDef1.FLD_SELETTGRAFIC_ID_UTENTE);
    PAN_SELETTORE.SetFieldPrimaryIndex(PFL_SELETTORE_APP, IMDBDef1.FLD_SELETTGRAFIC_ID_APP);
    PAN_SELETTORE.SetFieldPrimaryIndex(PFL_SELETTORE_TIPO, IMDBDef1.FLD_SELETTGRAFIC_TIPOSELEGRAF);
    PAN_SELETTORE.SetFieldPrimaryIndex(PFL_SELETTORE_RANGE, IMDBDef1.FLD_SELETTGRAFIC_DATADASELGRA);
    PAN_SELETTORE.SetFieldPrimaryIndex(PFL_SELETTORE_DATAA, IMDBDef1.FLD_SELETTGRAFIC_DATAASELEGRA);
    PAN_SELETTORE.SetMasterTable(0, "SELETTGRAFIC");
  }

  private void PAN_DATI_Init()
  {

    PAN_DATI.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_DATI.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_DATI.SetSize(MyGlb.OBJ_FIELD, 5);
    PAN_DATI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, "0C743EFE-DC26-4E82-BD91-2E2FB096047C");
    PAN_DATI.set_Header(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, "Anno");
    PAN_DATI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, "");
    PAN_DATI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, MyGlb.VIS_NORMALFIELDS);
    PAN_DATI.SetFlags(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DATI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DATI_MESE, "A6830FE5-F3A7-4593-8FE9-EA2E46D38BE6");
    PAN_DATI.set_Header(MyGlb.OBJ_FIELD, PFL_DATI_MESE, "Mese");
    PAN_DATI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DATI_MESE, "");
    PAN_DATI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DATI_MESE, MyGlb.VIS_NORMALFIELDS);
    PAN_DATI.SetFlags(MyGlb.OBJ_FIELD, PFL_DATI_MESE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DATI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, "84E4D7CC-E1E8-443A-8A84-BE134D42DAD6");
    PAN_DATI.set_Header(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, "Giorno");
    PAN_DATI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, "");
    PAN_DATI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, MyGlb.VIS_NORMALFIELDS);
    PAN_DATI.SetFlags(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DATI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DATI_DATA, "DF2EA16B-41F3-494F-AB28-B35C59DE6235");
    PAN_DATI.set_Header(MyGlb.OBJ_FIELD, PFL_DATI_DATA, "Data");
    PAN_DATI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DATI_DATA, "Begin Date");
    PAN_DATI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DATI_DATA, MyGlb.VIS_NORMALFIELDS);
    PAN_DATI.SetFlags(MyGlb.OBJ_FIELD, PFL_DATI_DATA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DATI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, "0DF91D85-5C1F-449A-838C-03CBF3D70B30");
    PAN_DATI.set_Header(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, "Units");
    PAN_DATI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, "");
    PAN_DATI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, MyGlb.VIS_NORMALFIELDS);
    PAN_DATI.SetFlags(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISAGGR | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_DATI_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_DATI.SetRect(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, MyGlb.PANEL_LIST, 0, 32, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, MyGlb.PANEL_LIST, 36);
    PAN_DATI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, MyGlb.PANEL_LIST, 1);
    PAN_DATI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, MyGlb.PANEL_LIST, "Anno");
    PAN_DATI.SetRect(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, MyGlb.PANEL_FORM, 4, 52, 144, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, MyGlb.PANEL_FORM, 36);
    PAN_DATI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, MyGlb.PANEL_FORM, 1);
    PAN_DATI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATI_ANNO, MyGlb.PANEL_FORM, "Anno");
    PAN_DATI.SetFieldPage(PFL_DATI_ANNO, -1, -1);
    PAN_DATI.SetFieldPanel(PFL_DATI_ANNO, PPQRY_STATAPPLE, "A.ANNO", "ANNSTAAPPREC", 1, 19, 0, -1709);
    PAN_DATI.SetRect(MyGlb.OBJ_FIELD, PFL_DATI_MESE, MyGlb.PANEL_LIST, 104, 32, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATI_MESE, MyGlb.PANEL_LIST, 36);
    PAN_DATI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATI_MESE, MyGlb.PANEL_LIST, 1);
    PAN_DATI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATI_MESE, MyGlb.PANEL_LIST, "Mese");
    PAN_DATI.SetRect(MyGlb.OBJ_FIELD, PFL_DATI_MESE, MyGlb.PANEL_FORM, 4, 76, 144, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATI_MESE, MyGlb.PANEL_FORM, 36);
    PAN_DATI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATI_MESE, MyGlb.PANEL_FORM, 1);
    PAN_DATI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATI_MESE, MyGlb.PANEL_FORM, "Ms.");
    PAN_DATI.SetFieldPage(PFL_DATI_MESE, -1, -1);
    PAN_DATI.SetFieldPanel(PFL_DATI_MESE, PPQRY_STATAPPLE, "A.MESE", "MESSTAAPPREC", 1, 19, 0, -1709);
    PAN_DATI.SetRect(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, MyGlb.PANEL_LIST, 208, 32, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, MyGlb.PANEL_LIST, 40);
    PAN_DATI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, MyGlb.PANEL_LIST, 1);
    PAN_DATI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, MyGlb.PANEL_LIST, "Giorno");
    PAN_DATI.SetRect(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, MyGlb.PANEL_FORM, 4, 100, 148, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, MyGlb.PANEL_FORM, 40);
    PAN_DATI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, MyGlb.PANEL_FORM, 1);
    PAN_DATI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATI_GIORNO, MyGlb.PANEL_FORM, "Gior.");
    PAN_DATI.SetFieldPage(PFL_DATI_GIORNO, -1, -1);
    PAN_DATI.SetFieldPanel(PFL_DATI_GIORNO, PPQRY_STATAPPLE, "A.GIORNO", "GIOSTAAPPREC", 1, 19, 0, -1709);
    PAN_DATI.SetRect(MyGlb.OBJ_FIELD, PFL_DATI_DATA, MyGlb.PANEL_LIST, 312, 32, 112, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATI_DATA, MyGlb.PANEL_LIST, 32);
    PAN_DATI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATI_DATA, MyGlb.PANEL_LIST, 1);
    PAN_DATI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATI_DATA, MyGlb.PANEL_LIST, "Data");
    PAN_DATI.SetRect(MyGlb.OBJ_FIELD, PFL_DATI_DATA, MyGlb.PANEL_FORM, 4, 4, 304, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATI_DATA, MyGlb.PANEL_FORM, 32);
    PAN_DATI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATI_DATA, MyGlb.PANEL_FORM, 1);
    PAN_DATI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATI_DATA, MyGlb.PANEL_FORM, "Dt.");
    PAN_DATI.SetFieldPage(PFL_DATI_DATA, -1, -1);
    PAN_DATI.SetFieldPanel(PFL_DATI_DATA, PPQRY_STATAPPLE, "A.DATA", "DATSTAAPPREC", 6, 52, 0, -1709);
    PAN_DATI.SetRect(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, MyGlb.PANEL_LIST, 424, 32, 148, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, MyGlb.PANEL_LIST, 88);
    PAN_DATI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, MyGlb.PANEL_LIST, 1);
    PAN_DATI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, MyGlb.PANEL_LIST, "Units");
    PAN_DATI.SetRect(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, MyGlb.PANEL_FORM, 4, 28, 240, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, MyGlb.PANEL_FORM, 88);
    PAN_DATI.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, MyGlb.PANEL_FORM, 1);
    PAN_DATI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATI_UNITS, MyGlb.PANEL_FORM, "Units");
    PAN_DATI.SetFieldPage(PFL_DATI_UNITS, -1, -1);
    PAN_DATI.SetFieldUnbound(PFL_DATI_UNITS, true);
    PAN_DATI.SetFieldPanel(PFL_DATI_UNITS, PPQRY_STATAPPLE, "SUM(A.UNITS)", "UNITSRECORD", 3, 28, 6, -1709);
  }

  private void PAN_DATI_InitQueries()
  {
    StringBuilder SQL;

    PAN_DATI.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_DATI.SetIMDB(IMDB, "PQRY_STATAPPLE", true);
    PAN_DATI.set_SetString(MyGlb.MASTER_ROWNAME, "Record");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ANNO as ANNSTAAPPREC, ");
    SQL.Append("  A.MESE as MESSTAAPPREC, ");
    SQL.Append("  A.GIORNO as GIOSTAAPPREC, ");
    SQL.Append("  A.DATA as DATSTAAPPREC, ");
    SQL.Append("  SUM(A.UNITS) as UNITSRECORD ");
    PAN_DATI.SetQuery(PPQRY_STATAPPLE, 0, SQL, -1, "48826B01-EB98-4E1A-9AF7-F244610492D8");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  V_STAT_APPLE A ");
    PAN_DATI.SetQuery(PPQRY_STATAPPLE, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where ((A.ID_UTENTE = ~~PQRY_SELETTGRAFI1.ID_UTENTE~~) OR (~~PQRY_SELETTGRAFI1.ID_UTENTE~~ IS NULL)) ");
    SQL.Append("and   ((A.ID_APP = ~~PQRY_SELETTGRAFI1.ID_APP~~) OR (~~PQRY_SELETTGRAFI1.ID_APP~~ IS NULL)) ");
    SQL.Append("and   ((~~PQRY_SELETTGRAFI1.TIPOSELEGRAF~~ = 'F' AND A.FREE_APP = -1) OR (~~PQRY_SELETTGRAFI1.TIPOSELEGRAF~~ = 'P' AND A.PAID_APP = -1) OR (~~PQRY_SELETTGRAFI1.TIPOSELEGRAF~~ = 'U' AND A.UPD_APP = -1) OR ((~~PQRY_SELETTGRAFI1.TIPOSELEGRAF~~ IS NULL))) ");
    SQL.Append("and   (~~PQRY_SELETTGRAFI1.DATADASELGRA~~ <= A.DATA OR (~~PQRY_SELETTGRAFI1.DATADASELGRA~~ IS NULL)) ");
    SQL.Append("and   (~~PQRY_SELETTGRAFI1.DATAASELEGRA~~ >= A.DATA OR (~~PQRY_SELETTGRAFI1.DATAASELEGRA~~ IS NULL)) ");
    PAN_DATI.SetQuery(PPQRY_STATAPPLE, 2, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("group by ");
    SQL.Append("  A.ANNO, ");
    SQL.Append("  A.MESE, ");
    SQL.Append("  A.GIORNO, ");
    SQL.Append("  A.DATA ");
    PAN_DATI.SetQuery(PPQRY_STATAPPLE, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DATI.SetQuery(PPQRY_STATAPPLE, 4, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("order by ");
    SQL.Append("  A.DATA desc ");
    PAN_DATI.SetQuery(PPQRY_STATAPPLE, 5, SQL, -1, "");
    PAN_DATI.SetQueryDB(PPQRY_STATAPPLE, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DATI.SetMasterTable(0, "V_STAT_APPLE");
    PAN_DATI.AddToSortList(PFL_DATI_DATA, false);
  }

  private void PAN_DATENONCARIC_Init()
  {

    PAN_DATENONCARIC.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_DATENONCARIC.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_DATENONCARIC.SetSize(MyGlb.OBJ_FIELD, 1);
    PAN_DATENONCARIC.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, "E1DE1E1C-DE8C-46E4-AB01-A169672022A1");
    PAN_DATENONCARIC.set_Header(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, "date mancanti");
    PAN_DATENONCARIC.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, "Begin Date");
    PAN_DATENONCARIC.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, MyGlb.VIS_NORMALFIELDS);
    PAN_DATENONCARIC.SetFlags(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_DATENONCARIC_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_DATENONCARIC.SetRect(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, MyGlb.PANEL_LIST, 0, 32, 268, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATENONCARIC.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, MyGlb.PANEL_LIST, 60);
    PAN_DATENONCARIC.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, MyGlb.PANEL_LIST, 1);
    PAN_DATENONCARIC.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, MyGlb.PANEL_LIST, "date mancanti");
    PAN_DATENONCARIC.SetRect(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, MyGlb.PANEL_FORM, 4, 4, 332, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATENONCARIC.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, MyGlb.PANEL_FORM, 60);
    PAN_DATENONCARIC.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, MyGlb.PANEL_FORM, 1);
    PAN_DATENONCARIC.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATENONCARIC_DATEMANCANTI, MyGlb.PANEL_FORM, "dt. mnc.");
    PAN_DATENONCARIC.SetFieldPage(PFL_DATENONCARIC_DATEMANCANTI, -1, -1);
    PAN_DATENONCARIC.SetFieldPanel(PFL_DATENONCARIC_DATEMANCANTI, PPQRY_SALESDATA, "A.BEGIN_DATE", "DATEMANCRECO", 6, 52, 0, -1709);
  }

  private void PAN_DATENONCARIC_InitQueries()
  {
    StringBuilder SQL;

    PAN_DATENONCARIC.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_DATENONCARIC.SetIMDB(IMDB, "PQRY_SALESDATA", true);
    PAN_DATENONCARIC.set_SetString(MyGlb.MASTER_ROWNAME, "Record");
    SQL = new StringBuilder();
    SQL.Append("select distinct ");
    SQL.Append("  A.BEGIN_DATE as DATEMANCRECO ");
    PAN_DATENONCARIC.SetQuery(PPQRY_SALESDATA, 0, SQL, -1, "1044AD02-542A-4D2A-BA6B-0636E4F66C45");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  APPLE_SALES_DATA A ");
    PAN_DATENONCARIC.SetQuery(PPQRY_SALESDATA, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (NOT (EXISTS(");
    SQL.Append("( ");
    SQL.Append("select ");
    SQL.Append("  B.ID ");
    SQL.Append("from ");
    SQL.Append("  APPLE_SALES_DATA B ");
    SQL.Append("where (B.BEGIN_DATE = A.BEGIN_DATE - 1) ");
    SQL.Append(")))) ");
    SQL.Append("and   (A.BEGIN_DATE >= '20110101') ");
    PAN_DATENONCARIC.SetQuery(PPQRY_SALESDATA, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DATENONCARIC.SetQuery(PPQRY_SALESDATA, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DATENONCARIC.SetQuery(PPQRY_SALESDATA, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DATENONCARIC.SetQuery(PPQRY_SALESDATA, 5, SQL, -1, "");
    PAN_DATENONCARIC.SetQueryDB(PPQRY_SALESDATA, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DATENONCARIC.SetMasterTable(0, "APPLE_SALES_DATA");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_SELETTORE) PAN_SELETTORE_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
    if (SrcObj == PAN_DATI) PAN_DATI_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
    if (SrcObj == PAN_DATENONCARIC) PAN_DATENONCARIC_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_SELETTORE) PAN_SELETTORE_ValidateRow(Cancel);
    if (SrcObj == PAN_DATI) PAN_DATI_ValidateRow(Cancel);
    if (SrcObj == PAN_DATENONCARIC) PAN_DATENONCARIC_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_SELETTORE) PAN_SELETTORE_CellActivated(ColIndex, Cancel);
    if (SrcObj == PAN_DATI) PAN_DATI_CellActivated(ColIndex, Cancel);
    if (SrcObj == PAN_DATENONCARIC) PAN_DATENONCARIC_CellActivated(ColIndex, Cancel);
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
