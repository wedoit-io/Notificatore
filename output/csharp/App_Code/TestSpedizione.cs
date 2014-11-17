// **********************************************
// Test Spedizione
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
public partial class TestSpedizione : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_SPEDIZIONI_ID1 = 0;
  private const int PFL_SPEDIZIONI_IDAPPSPUSSE1 = 1;
  private const int PFL_SPEDIZIONI_STATO = 2;
  private const int PFL_SPEDIZIONI_BADGE = 3;
  private const int PFL_SPEDIZIONI_NUMEROTENTAT = 4;
  private const int PFL_SPEDIZIONI_DATAINSERIME = 5;
  private const int PFL_SPEDIZIONI_DATAELABORAZ = 6;
  private const int PFL_SPEDIZIONI_TYPEOS = 7;
  private const int PFL_SPEDIZIONI_UTENTE1 = 8;
  private const int PFL_SPEDIZIONI_SOUND = 9;
  private const int PFL_SPEDIZIONI_DEVICETOKEN = 10;
  private const int PFL_SPEDIZIONI_GUIDGRUPINVI = 11;
  private const int PFL_SPEDIZIONI_GOOGLEAPI = 12;
  private const int PFL_SPEDIZIONI_REGID1 = 13;
  private const int PFL_SPEDIZIONI_MESSAGGIO = 14;
  private const int PFL_SPEDIZIONI_INFO = 15;
  private const int PFL_SPEDIZIONI_ETICHETINVIA = 16;

  private const int PPQRY_SPEDIZIONI = 0;

  private const int PPQRY_LOOAPPPUSSE1 = 1;

  private const int PPQRY_APPSPUSHSETT = 2;


  internal IDPanel PAN_SPEDIZIONI;
  private const int PFL_DATITEMP_JSONRITORNO = 0;
  private const int PFL_DATITEMP_ETICELABRISU = 1;

  private const int PPQRY_DATITEMP1 = 0;


  internal IDPanel PAN_DATITEMP;
  private const int PFL_DEVICETOKEN_ID = 0;
  private const int PFL_DEVICETOKEN_DEVTOKEN = 1;
  private const int PFL_DEVICETOKEN_UTENTE = 2;
  private const int PFL_DEVICETOKEN_ATTIVO = 3;
  private const int PFL_DEVICETOKEN_RIMOSSO = 4;
  private const int PFL_DEVICETOKEN_DATARIMOZION = 5;
  private const int PFL_DEVICETOKEN_NOTA = 6;
  private const int PFL_DEVICETOKEN_REGID = 7;
  private const int PFL_DEVICETOKEN_IDAPPSPUSSET = 8;

  private const int PPQRY_DEVICETOKEN5 = 0;

  private const int PPQRY_LOOAPPPUSSET = 1;


  internal IDPanel PAN_DEVICETOKEN;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    Init_TBL_DATITEMP(IMDB);
    //
    //
    Init_PQRY_SPEDIZIONI(IMDB);
    Init_PQRY_DATITEMP1(IMDB);
    Init_PQRY_DATITEMP1_RS(IMDB);
    Init_PQRY_DEVICETOKEN5(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_TBL_DATITEMP(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.TBL_DATITEMP, 1);
    IMDB.set_TblCode(IMDBDef1.TBL_DATITEMP, "TBL_DATITEMP");
    IMDB.set_FldCode(IMDBDef1.TBL_DATITEMP,IMDBDef1.FLD_DATITEMP_JSORITNOMOGG, "JSORITNOMOGG");
    IMDB.SetFldParams(IMDBDef1.TBL_DATITEMP,IMDBDef1.FLD_DATITEMP_JSORITNOMOGG,9,5000,0);
    IMDB.TblAddNew(IMDBDef1.TBL_DATITEMP, 0);
  }

  private static void Init_PQRY_SPEDIZIONI(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_SPEDIZIONI, 15);
    IMDB.set_TblCode(IMDBDef1.PQRY_SPEDIZIONI, "PQRY_SPEDIZIONI");
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_ID_APPLICAZIONE, "ID_APPLICAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_ID_APPLICAZIONE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_DES_MESSAGGIO, "DES_MESSAGGIO");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_DES_MESSAGGIO,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_DEV_TOKEN, "DEV_TOKEN");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_DEV_TOKEN,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_FLG_STATO, "FLG_STATO");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_FLG_STATO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_DAT_CREAZ, "DAT_CREAZ");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_DAT_CREAZ,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_DAT_ELAB, "DAT_ELAB");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_DAT_ELAB,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_DES_UTENTE,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_SOUND, "SOUND");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_SOUND,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_BADGE, "BADGE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_BADGE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_REG_ID, "REG_ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_REG_ID,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_TYPE_OS, "TYPE_OS");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_TYPE_OS,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_INFO, "INFO");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_INFO,5,2000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_GUID_GRUPPO, "GUID_GRUPPO");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_GUID_GRUPPO,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_TENTATIVI, "TENTATIVI");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI,IMDBDef1.PQSL_SPEDIZIONI_TENTATIVI,1,3,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_SPEDIZIONI, 0);
  }

  private static void Init_PQRY_DATITEMP1(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DATITEMP1, 1);
    IMDB.set_TblCode(IMDBDef1.PQRY_DATITEMP1, "PQRY_DATITEMP1");
    IMDB.set_FldCode(IMDBDef1.PQRY_DATITEMP1,IMDBDef1.PQSL_DATITEMP1_JSORITNOMOGG, "JSORITNOMOGG");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATITEMP1,IMDBDef1.PQSL_DATITEMP1_JSORITNOMOGG,9,5000,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_DATITEMP1, 0);
  }

  private static void Init_PQRY_DATITEMP1_RS(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DATITEMP1_RS, 1);
    IMDB.set_TblCode(IMDBDef1.PQRY_DATITEMP1_RS, "PQRY_DATITEMP1_RS");
    IMDB.set_FldCode(IMDBDef1.PQRY_DATITEMP1_RS,IMDBDef1.PQSL_DATITEMP1_JSORITNOMOGG, "JSORITNOMOGG");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATITEMP1_RS,IMDBDef1.PQSL_DATITEMP1_JSORITNOMOGG,9,5000,0);
  }

  private static void Init_PQRY_DEVICETOKEN5(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DEVICETOKEN5, 9);
    IMDB.set_TblCode(IMDBDef1.PQRY_DEVICETOKEN5, "PQRY_DEVICETOKEN5");
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_ID_APPLICAZIONE, "ID_APPLICAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_ID_APPLICAZIONE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_DEV_TOKEN, "DEV_TOKEN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_DEV_TOKEN,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_FLG_ATTIVO, "FLG_ATTIVO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_FLG_ATTIVO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_FLG_RIMOSSO, "FLG_RIMOSSO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_FLG_RIMOSSO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_DATA_RIMOZ, "DATA_RIMOZ");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_DATA_RIMOZ,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_REG_ID, "REG_ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN5,IMDBDef1.PQSL_DEVICETOKEN5_REG_ID,5,200,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_DEVICETOKEN5, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public TestSpedizione(MyWebEntryPoint w, IMDBObj imdb)
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
  public TestSpedizione()
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
    FormIdx = MyGlb.FRM_TESTSPEDIZIO;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "2564B3FF-3146-4038-8C2D-CADB72E7C2AF";
    ResModeW = 1;
    ResModeH = 1;
    iVisualFlags = -2049;
    DesignWidth = 900;
    DesignHeight = 718;
    set_Caption(new IDVariant("Test Spedizione"));
    //
    Frames = new AFrame[6];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 900;
    Frames[1].Height = 692;
    Frames[1].Vertical = true;
    Frames[1].FormFactor = 0.531792;
    Frames[2] = new AFrame(2);
    Frames[2].Parent = this;
    Frames[1].ChildFrame1 = Frames[2];
    Frames[2].Width = 900;
    Frames[2].Height = 368;
    Frames[2].Caption = "Spedizioni";
    Frames[2].Parent = this;
    Frames[2].FixedHeight = 368;
    PAN_SPEDIZIONI = new IDPanel(w, this, 2, "PAN_SPEDIZIONI");
    Frames[2].Content = PAN_SPEDIZIONI;
    PAN_SPEDIZIONI.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_SPEDIZIONI.VS = MainFrm.VisualStyleList;
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 900-MyGlb.PAN_OFFS_X, 368-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "0BBA17D0-46EE-4A95-A2E7-D708E32A260F");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 972, 236, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_STARTFORM | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_SPEDIZIONI.InitStatus = 1;
    PAN_SPEDIZIONI_Init();
    PAN_SPEDIZIONI_InitFields();
    PAN_SPEDIZIONI_InitQueries();
    Frames[3] = new AFrame(3);
    Frames[3].Parent = this;
    Frames[1].ChildFrame2 = Frames[3];
    Frames[3].Width = 900;
    Frames[3].Height = 324;
    Frames[3].Vertical = true;
    Frames[3].FormFactor = 0.333333;
    Frames[4] = new AFrame(4);
    Frames[4].Parent = this;
    Frames[3].ChildFrame1 = Frames[4];
    Frames[4].Width = 900;
    Frames[4].Height = 108;
    Frames[4].FrHidden = true;
    Frames[4].Caption = "Dati Temp";
    Frames[4].Parent = this;
    Frames[4].FixedHeight = 108;
    PAN_DATITEMP = new IDPanel(w, this, 4, "PAN_DATITEMP");
    Frames[4].Content = PAN_DATITEMP;
    PAN_DATITEMP.Lockable = false;
    PAN_DATITEMP.iLocked = false;
    PAN_DATITEMP.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_DATITEMP.VS = MainFrm.VisualStyleList;
    PAN_DATITEMP.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 900-MyGlb.PAN_OFFS_X, 108-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_DATITEMP.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "DDB30901-A4BA-4348-8B8B-63EB00494307");
    PAN_DATITEMP.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 0, 156, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_DATITEMP.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_DATITEMP.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_DATITEMP.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_STARTFORM | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_AUTOSAVE | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_DATITEMP.InitStatus = 1;
    PAN_DATITEMP_Init();
    PAN_DATITEMP_InitFields();
    PAN_DATITEMP_InitQueries();
    Frames[5] = new AFrame(5);
    Frames[5].Parent = this;
    Frames[3].ChildFrame2 = Frames[5];
    Frames[5].Width = 900;
    Frames[5].Height = 216;
    Frames[5].Caption = "Device Token";
    Frames[5].Parent = this;
    Frames[5].FixedHeight = 216;
    PAN_DEVICETOKEN = new IDPanel(w, this, 5, "PAN_DEVICETOKEN");
    Frames[5].Content = PAN_DEVICETOKEN;
    PAN_DEVICETOKEN.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_DEVICETOKEN.VS = MainFrm.VisualStyleList;
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 900-MyGlb.PAN_OFFS_X, 216-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "50B4584E-A5B9-48D4-A122-1E5DB7B3A45E");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 556, 104, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_STARTFORM | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
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
      if (IMDB.TblModified(IMDBDef1.TBL_DATITEMP, MyGlb.GlbRefModIdx) || JustLoaded)
      {
        TESTSPEDIZIO_DATITEMP1();
      }
      PAN_SPEDIZIONI.UpdatePanel(MainFrm);
      PAN_DATITEMP.UpdatePanel(MainFrm);
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
    return (obj is TestSpedizione);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(TestSpedizione).FullName : typeof(TestSpedizione).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Etichetta Invia
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int EtichettaInvia ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Etichetta Invia Body
      // Corpo Procedura
      // 
      IDVariant v_SJSONRITORNO = null;
      v_SJSONRITORNO = MainFrm.CallGMCHelperSendNotification((new IDVariant(PAN_SPEDIZIONI.FieldText(PFL_SPEDIZIONI_GOOGLEAPI))), IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI, IMDBDef1.PQSL_SPEDIZIONI_REG_ID, 0), IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI, IMDBDef1.PQSL_SPEDIZIONI_DES_MESSAGGIO, 0));
      IMDB.set_Value(IMDBDef1.PQRY_DATITEMP1, IMDBDef1.PQSL_DATITEMP1_JSORITNOMOGG, 0, new IDVariant(v_SJSONRITORNO));
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("TestSpedizione", "EtichettaInvia", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Etichetta Elabora Risultato
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int EtichettaElaboraRisultato ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Etichetta Elabora Risultato Body
      // Corpo Procedura
      // 
      MainFrm.ElaboraRisultatoGCMNotification(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI, IMDBDef1.PQSL_SPEDIZIONI_REG_ID, 0), IMDB.Value(IMDBDef1.TBL_DATITEMP, IMDBDef1.FLD_DATITEMP_JSORITNOMOGG, 0), IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI, IMDBDef1.PQSL_SPEDIZIONI_ID, 0));
      PAN_SPEDIZIONI.PanelCommand(Glb.PCM_REQUERY);
      PAN_DEVICETOKEN.PanelCommand(Glb.PCM_REQUERY);
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("TestSpedizione", "EtichettaElaboraRisultato", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Dati Temp
  // Recupera i record da mostrare nel pannello
  // **********************************************************************
  private void TESTSPEDIZIO_DATITEMP1()
  {
    IDVariant[] AggrBuff;
    int[] AggrRowCount;
    int AggrCount=0;
    bool AggrNewGroup = false;

    IMDB.TblTruncate(IMDBDef1.PQRY_DATITEMP1_RS);
    IMDB.TblMoveFirst(IMDBDef1.TBL_DATITEMP, 0);
    Loop1: while (!IMDB.Eof(IMDBDef1.TBL_DATITEMP, 0))
    {
      IMDB.TblAddNew(IMDBDef1.PQRY_DATITEMP1_RS, 0);
      IMDB.TblLinkRow(IMDBDef1.PQRY_DATITEMP1_RS, 0, IMDBDef1.TBL_DATITEMP, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_DATITEMP1_RS, 0, 0, IMDBDef1.TBL_DATITEMP, IMDBDef1.FLD_DATITEMP_JSORITNOMOGG, 0);
      IMDB.TblMoveNext(IMDBDef1.TBL_DATITEMP, 0);
      if (IMDB.Eof(IMDBDef1.TBL_DATITEMP, 0))
      {
        IMDB.TblMoveFirst(IMDBDef1.TBL_DATITEMP, 0);
      }
      else
      {
        goto Loop1;
      }
      break;
    }
    IMDB.TblMoveFirst(IMDBDef1.PQRY_DATITEMP1_RS, 0);
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
  private void PAN_SPEDIZIONI_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
    if (ColIndex.intValue() == PFL_SPEDIZIONI_ETICHETINVIA)
    {
      this.IdxPanelActived = this.PAN_SPEDIZIONI.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      EtichettaInvia();
      Cancel.set(IDVariant.TRUE);
    }
  }

  private void PAN_SPEDIZIONI_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_SPEDIZIONI_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI, IMDBDef1.PQSL_SPEDIZIONI_FLG_STATO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_SPEDIZIONI, IMDBDef1.PQSL_SPEDIZIONI_FLG_STATO, 0, (new IDVariant("W")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI, IMDBDef1.PQSL_SPEDIZIONI_DAT_CREAZ, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_SPEDIZIONI, IMDBDef1.PQSL_SPEDIZIONI_DAT_CREAZ, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI, IMDBDef1.PQSL_SPEDIZIONI_TYPE_OS, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_SPEDIZIONI, IMDBDef1.PQSL_SPEDIZIONI_TYPE_OS, 0, (new IDVariant("1")));
      }
    } catch ( Exception e) { }
  }

  private void PAN_DATITEMP_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
    if (ColIndex.intValue() == PFL_DATITEMP_ETICELABRISU)
    {
      this.IdxPanelActived = this.PAN_DATITEMP.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      EtichettaElaboraRisultato();
      Cancel.set(IDVariant.TRUE);
    }
  }

  private void PAN_DATITEMP_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_DATITEMP_ValidateRow(IDVariant Cancel)
  {
    try
    {
    } catch ( Exception e) { }
  }

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
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN5, IMDBDef1.PQSL_DEVICETOKEN5_FLG_ATTIVO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN5, IMDBDef1.PQSL_DEVICETOKEN5_FLG_ATTIVO, 0, (new IDVariant("S")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN5, IMDBDef1.PQSL_DEVICETOKEN5_FLG_RIMOSSO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN5, IMDBDef1.PQSL_DEVICETOKEN5_FLG_RIMOSSO, 0, (new IDVariant("N")));
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_SPEDIZIONI_Init()
  {

    PAN_SPEDIZIONI.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_SPEDIZIONI.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_SPEDIZIONI.SetSize(MyGlb.OBJ_FIELD, 17);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, "A6265DEC-7515-4233-AC2B-7A739CE5E935");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, "ID");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, "Identificativo univoco");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, "AF579E21-7420-4BDF-8C5C-B7E155DB3EEE");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, "ID Apps Push Settings");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, "Identificativo univoco");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, MyGlb.VIS_FOREIKEYFIEL);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, "03CB4EFF-AD69-4D27-BDAB-56C79FCB4D56");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, "Stato");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, "29158615-513F-413E-96AA-7985069DB1B3");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, "Badge");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, "CA4B2BDC-EC1C-4175-9AAF-CC2CF824E9D5");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, "Numero Tentativi");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, "A9D7ABE4-F990-4B05-A200-0A7DC13C7E02");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, "Data Inserimento");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, "Data in cui è stato inserito il dato");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, "BF55DFD8-0D4C-47ED-86BE-8D1F3EE18727");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, "Data Elaborazione");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, "Data in cui è stato elaborato il record");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, "D3011399-1A8C-4471-9582-A242495FB3E1");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, "Type OS");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, "4CE43519-191B-418E-8DA4-2E56CFE34682");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, "Utente");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, "1875A414-97FF-4FAA-A356-1A3F8F6C7371");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, "Sound");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, "CA408EC2-7D88-4DF8-8D34-7381A446133E");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, "Device Token");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, "Identificativo del dispositivo");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, "0BEE0987-87C2-4644-86E2-CA72140B80C6");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, "Guid Gruppo Invio");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, "EC03F4A2-C542-4DF9-B2D9-823E8ABBC048");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, "Google Api");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, MyGlb.VIS_LOOKUPFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, "841A9E80-6F88-40E0-9232-0ECABE23F2EC");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, "Regid");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, "RegID usato da android");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, "72E6244A-5331-4274-9507-64DD1FFC3936");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, "Messaggio");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, "81AD967D-2A3D-4687-8AB5-D4253A90C30E");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, "Info");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ETICHETINVIA, "EF5C71E6-4BD5-4002-B16E-0D82A00E3AE2");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ETICHETINVIA, "Invia");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ETICHETINVIA, MyGlb.VIS_COMMANBUTTO1);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ETICHETINVIA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_CANACTIVATE, -1);
  }

  private void PAN_SPEDIZIONI_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, MyGlb.PANEL_LIST, 0, 36, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, MyGlb.PANEL_LIST, 20);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, MyGlb.PANEL_LIST, "ID");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, MyGlb.PANEL_FORM, 4, 4, 156, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, MyGlb.PANEL_FORM, 108);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID1, MyGlb.PANEL_FORM, "ID");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_ID1, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_ID1, PPQRY_SPEDIZIONI, "A.ID", "ID", 1, 9, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, MyGlb.PANEL_LIST, 40, 36, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, MyGlb.PANEL_LIST, 116);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, MyGlb.PANEL_LIST, "I. A. P. Stt.");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, MyGlb.PANEL_FORM, 188, 4, 176, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, MyGlb.PANEL_FORM, 128);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_IDAPPSPUSSE1, MyGlb.PANEL_FORM, "ID Apps Push Settings");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_IDAPPSPUSSE1, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_IDAPPSPUSSE1, PPQRY_SPEDIZIONI, "A.ID_APPLICAZIONE", "ID_APPLICAZIONE", 1, 9, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_LIST, 80, 36, 64, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_LIST, 36);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_LIST, "Stato");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_FORM, 372, 4, 160, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_FORM, 88);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_FORM, "Stato");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_STATO, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_STATO, PPQRY_SPEDIZIONI, "A.FLG_STATO", "FLG_STATO", 5, 1, 0, -685);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_STATO, (new IDVariant("W")), "Attesa", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_STATO, (new IDVariant("S")), "Inviato", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_STATO, (new IDVariant("E")), "Errore", "", "", -1);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_LIST, 144, 36, 48, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_LIST, 40);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_LIST, "Badge");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_FORM, 540, 4, 108, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_FORM, 60);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_FORM, "Badge");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_BADGE, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_BADGE, PPQRY_SPEDIZIONI, "A.BADGE", "BADGE", 1, 9, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_LIST, 424, 36, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_LIST, 92);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_LIST, "Num. Tent.");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_FORM, 656, 4, 152, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_FORM, 104);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_FORM, "Numero Tentativi");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_NUMEROTENTAT, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_NUMEROTENTAT, PPQRY_SPEDIZIONI, "A.TENTATIVI", "TENTATIVI", 1, 3, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_LIST, 4, 316, 448, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_LIST, 128);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_LIST, "Data Inserimento");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_FORM, 4, 32, 228, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_FORM, 108);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_FORM, "Data Inserimento");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_DATAINSERIME, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_DATAINSERIME, PPQRY_SPEDIZIONI, "A.DAT_CREAZ", "DAT_CREAZ", 8, 61, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_LIST, 4, 340, 448, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_LIST, 128);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_LIST, "Data Elaborazione");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_FORM, 256, 32, 248, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_FORM, 128);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_FORM, "Data Elaborazione");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_DATAELABORAZ, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_DATAELABORAZ, PPQRY_SPEDIZIONI, "A.DAT_ELAB", "DAT_ELAB", 8, 61, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_LIST, 192, 36, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_LIST, 52);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_LIST, "Type OS");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_FORM, 540, 36, 240, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_FORM, 128);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_FORM, "Type OS");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_TYPEOS, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_TYPEOS, PPQRY_SPEDIZIONI, "A.TYPE_OS", "TYPE_OS", 5, 1, 0, -685);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_TYPEOS, (new IDVariant("1")), "iOS", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_TYPEOS, (new IDVariant("2")), "Android", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_TYPEOS, (new IDVariant("3")), "Windows Phone", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_TYPEOS, (new IDVariant("4")), "Blackberry", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_TYPEOS, (new IDVariant("5")), "Windows Store", "", "", -1);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, MyGlb.PANEL_LIST, 4, 364, 528, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, MyGlb.PANEL_LIST, 128);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, MyGlb.PANEL_LIST, 2);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, MyGlb.PANEL_LIST, "Utente");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, MyGlb.PANEL_FORM, 4, 60, 324, 24, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, MyGlb.PANEL_FORM, 108);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE1, MyGlb.PANEL_FORM, "Utente");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_UTENTE1, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_UTENTE1, PPQRY_SPEDIZIONI, "A.DES_UTENTE", "DES_UTENTE", 5, 1000, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_LIST, 4, 388, 528, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_LIST, 128);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_LIST, 2);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_LIST, "Sound");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_FORM, 340, 64, 284, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_FORM, 60);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_FORM, "Sound");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_SOUND, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_SOUND, PPQRY_SPEDIZIONI, "A.SOUND", "SOUND", 5, 200, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_LIST, 4, 292, 528, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_LIST, 128);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_LIST, 2);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_LIST, "Device Token");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_FORM, 4, 96, 324, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_FORM, 108);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_FORM, "Device Token");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_DEVICETOKEN, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_DEVICETOKEN, PPQRY_SPEDIZIONI, "A.DEV_TOKEN", "DEV_TOKEN", 5, 1000, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_LIST, 296, 36, 128, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_LIST, 96);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_LIST, "Guid Gruppo Invio");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_FORM, 8, 128, 324, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_FORM, 108);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_FORM, "Guid Gruppo Invio");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_GUIDGRUPINVI, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_GUIDGRUPINVI, PPQRY_SPEDIZIONI, "A.GUID_GRUPPO", "GUID_GRUPPO", 5, 200, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, MyGlb.PANEL_LIST, 0, 36, 508, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, MyGlb.PANEL_LIST, 212);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, MyGlb.PANEL_LIST, "Google Api");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, MyGlb.PANEL_FORM, 336, 128, 472, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, MyGlb.PANEL_FORM, 140);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GOOGLEAPI, MyGlb.PANEL_FORM, "Google Api");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_GOOGLEAPI, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_GOOGLEAPI, PPQRY_LOOAPPPUSSE1, "A.GOOGLE_API_ID", "GOAPBRIAPSNO", 5, 100, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, MyGlb.PANEL_LIST, 4, 412, 528, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, MyGlb.PANEL_LIST, 128);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, MyGlb.PANEL_LIST, 2);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, MyGlb.PANEL_LIST, "Regid");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, MyGlb.PANEL_FORM, 4, 160, 804, 56, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, MyGlb.PANEL_FORM, 108);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, MyGlb.PANEL_FORM, 3);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGID1, MyGlb.PANEL_FORM, "Regid");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_REGID1, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_REGID1, PPQRY_SPEDIZIONI, "A.REG_ID", "REG_ID", 5, 200, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_LIST, 4, 268, 528, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_LIST, 128);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_LIST, 2);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_LIST, "Messaggio");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_FORM, 4, 224, 804, 56, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_FORM, 108);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_FORM, 3);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_FORM, "Messaggio");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_MESSAGGIO, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_MESSAGGIO, PPQRY_SPEDIZIONI, "A.DES_MESSAGGIO", "DES_MESSAGGIO", 9, 1000, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_LIST, 4, 436, 528, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_LIST, 128);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_LIST, 2);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_LIST, "Info");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_FORM, 4, 288, 700, 24, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_FORM, 108);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_FORM, "Info");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_INFO, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_INFO, PPQRY_SPEDIZIONI, "A.INFO", "INFO", 5, 2000, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ETICHETINVIA, MyGlb.PANEL_LIST, 32, 408, 88, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ETICHETINVIA, MyGlb.PANEL_LIST, 0);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ETICHETINVIA, MyGlb.PANEL_LIST, 2);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ETICHETINVIA, MyGlb.PANEL_FORM, 716, 288, 108, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ETICHETINVIA, MyGlb.PANEL_FORM, 0);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ETICHETINVIA, MyGlb.PANEL_FORM, 2);
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_ETICHETINVIA, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_ETICHETINVIA, -1, "", "ETICHETINVIA", 0, 0, 0, -685);
  }

  private void PAN_SPEDIZIONI_InitQueries()
  {
    StringBuilder SQL;

    PAN_SPEDIZIONI.SetSize(MyGlb.OBJ_QUERY, 3);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPUSENOOG, ");
    SQL.Append("  A.GOOGLE_API_ID as GOAPBRIAPSNO ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A ");
    SQL.Append("where (A.ID = ~~ID_APPLICAZIONE~~) ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_LOOAPPPUSSE1, 0, SQL, -1, "");
    PAN_SPEDIZIONI.SetQueryDB(PPQRY_LOOAPPPUSSE1, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_SPEDIZIONI.SetMasterTable(PPQRY_LOOAPPPUSSE1, "APPS_PUSH_SETTING");
    PAN_SPEDIZIONI.SetQueryLKE(PPQRY_LOOAPPPUSSE1, PFL_SPEDIZIONI_IDAPPSPUSSE1, "IDAPPUSENOOG");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPUSENOOG, ");
    SQL.Append("  A.GOOGLE_API_ID as GOAPBRIAPSNO ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_LOOAPPPUSSE1, 1, SQL, -1, "");
    PAN_SPEDIZIONI.SetQueryHeaderColumn(PPQRY_LOOAPPPUSSE1, "GOAPBRIAPSNO", "Google Api Browser ID Apps Push Settings");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPSPUSSET, ");
    SQL.Append("  B.NOME_APP as APPAPPAPPUSE ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_APPSPUSHSETT, 0, SQL, PFL_SPEDIZIONI_IDAPPSPUSSE1, "");
    PAN_SPEDIZIONI.SetQueryDB(PPQRY_APPSPUSHSETT, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_SPEDIZIONI.SetIMDB(IMDB, "PQRY_SPEDIZIONI", true);
    PAN_SPEDIZIONI.set_SetString(MyGlb.MASTER_ROWNAME, "Spedizione");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.ID_APPLICAZIONE as ID_APPLICAZIONE, ");
    SQL.Append("  A.DES_MESSAGGIO as DES_MESSAGGIO, ");
    SQL.Append("  A.DEV_TOKEN as DEV_TOKEN, ");
    SQL.Append("  A.FLG_STATO as FLG_STATO, ");
    SQL.Append("  A.DAT_CREAZ as DAT_CREAZ, ");
    SQL.Append("  A.DAT_ELAB as DAT_ELAB, ");
    SQL.Append("  A.DES_UTENTE as DES_UTENTE, ");
    SQL.Append("  A.SOUND as SOUND, ");
    SQL.Append("  A.BADGE as BADGE, ");
    SQL.Append("  A.REG_ID as REG_ID, ");
    SQL.Append("  A.TYPE_OS as TYPE_OS, ");
    SQL.Append("  A.INFO as INFO, ");
    SQL.Append("  A.GUID_GRUPPO as GUID_GRUPPO, ");
    SQL.Append("  A.TENTATIVI as TENTATIVI ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI, 0, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  SPEDIZIONI A ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.TYPE_OS = '2') ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI, 5, SQL, -1, "");
    PAN_SPEDIZIONI.SetQueryDB(PPQRY_SPEDIZIONI, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_SPEDIZIONI.SetMasterTable(0, "SPEDIZIONI");
    SQL = new StringBuilder("");
    PAN_SPEDIZIONI.SetQuery(0, -1, SQL, PFL_SPEDIZIONI_ID1, "");
  }

  private void PAN_DATITEMP_Init()
  {

    PAN_DATITEMP.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_DATITEMP.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_DATITEMP.SetSize(MyGlb.OBJ_FIELD, 2);
    PAN_DATITEMP.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, "556808C2-6710-4EBB-97C8-C7ACD1C6F9DA");
    PAN_DATITEMP.set_Header(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, "Json Ritorno");
    PAN_DATITEMP.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, "");
    PAN_DATITEMP.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, MyGlb.VIS_NORMALFIELDS);
    PAN_DATITEMP.SetFlags(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DATITEMP.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DATITEMP_ETICELABRISU, "043B0EA6-351F-4C98-9372-D00B9DA01AF5");
    PAN_DATITEMP.set_Header(MyGlb.OBJ_FIELD, PFL_DATITEMP_ETICELABRISU, "Elabora Risultato");
    PAN_DATITEMP.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DATITEMP_ETICELABRISU, MyGlb.VIS_COMMANBUTTO1);
    PAN_DATITEMP.SetFlags(MyGlb.OBJ_FIELD, PFL_DATITEMP_ETICELABRISU, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_CANACTIVATE, -1);
  }

  private void PAN_DATITEMP_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_DATITEMP.SetRect(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, MyGlb.PANEL_LIST, 4, 164, 480, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DATITEMP.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, MyGlb.PANEL_LIST, 80);
    PAN_DATITEMP.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, MyGlb.PANEL_LIST, 2);
    PAN_DATITEMP.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, MyGlb.PANEL_LIST, "Json Ritorno");
    PAN_DATITEMP.SetRect(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, MyGlb.PANEL_FORM, 4, 4, 700, 88, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATITEMP.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, MyGlb.PANEL_FORM, 108);
    PAN_DATITEMP.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, MyGlb.PANEL_FORM, 6);
    PAN_DATITEMP.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DATITEMP_JSONRITORNO, MyGlb.PANEL_FORM, "Json Ritorno");
    PAN_DATITEMP.SetFieldPage(PFL_DATITEMP_JSONRITORNO, -1, -1);
    PAN_DATITEMP.SetFieldPanel(PFL_DATITEMP_JSONRITORNO, PPQRY_DATITEMP1, "A.JSORITNOMOGG", "JSORITNOMOGG", 9, 5000, 0, -685);
    PAN_DATITEMP.SetRect(MyGlb.OBJ_FIELD, PFL_DATITEMP_ETICELABRISU, MyGlb.PANEL_LIST, 136, 408, 88, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATITEMP.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATITEMP_ETICELABRISU, MyGlb.PANEL_LIST, 0);
    PAN_DATITEMP.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATITEMP_ETICELABRISU, MyGlb.PANEL_LIST, 2);
    PAN_DATITEMP.SetRect(MyGlb.OBJ_FIELD, PFL_DATITEMP_ETICELABRISU, MyGlb.PANEL_FORM, 720, 4, 108, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DATITEMP.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DATITEMP_ETICELABRISU, MyGlb.PANEL_FORM, 0);
    PAN_DATITEMP.SetNumRow(MyGlb.OBJ_FIELD, PFL_DATITEMP_ETICELABRISU, MyGlb.PANEL_FORM, 2);
    PAN_DATITEMP.SetFieldPage(PFL_DATITEMP_ETICELABRISU, -1, -1);
    PAN_DATITEMP.SetFieldPanel(PFL_DATITEMP_ETICELABRISU, -1, "", "ETICELABRISU", 0, 0, 0, -685);
  }

  private void PAN_DATITEMP_InitQueries()
  {
    StringBuilder SQL;

    PAN_DATITEMP.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_DATITEMP.SetIMDB(IMDB, "PQRY_DATITEMP1", true);
    PAN_DATITEMP.set_SetString(MyGlb.MASTER_ROWNAME, "Nome Oggetto");
    PAN_DATITEMP.SetQueryIMDB(PPQRY_DATITEMP1, IMDBDef1.PQRY_DATITEMP1_RS, IMDBDef1.TBL_DATITEMP);
    JustLoaded = true;
    PAN_DATITEMP.SetFieldPrimaryIndex(PFL_DATITEMP_JSONRITORNO, IMDBDef1.FLD_DATITEMP_JSORITNOMOGG);
    PAN_DATITEMP.SetMasterTable(0, "DATITEMP");
  }

  private void PAN_DEVICETOKEN_Init()
  {

    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_FIELD, 9);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "5D82149C-14FD-472D-BF05-98488CB5CEE4");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "ID");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "Identificativo univoco");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "0647BD32-9F39-4C76-B5A7-6DBA489948C5");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "Dev Token");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "5911B988-7737-4AB9-BE9D-F91789EC711A");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "Utente");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "3F69C097-6016-4B25-8CCD-27E318B9D719");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "Attivo");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "0CBBB545-8C16-42C8-955D-4698051E3E3C");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "Rimosso");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "2B7017C2-B520-4E4A-8BFB-12AC24A6A935");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "Data Rimozione");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "FA52209F-0C5F-4FE9-B3EC-57FCCEF9C225");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "Nota");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "Nota");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, "61D866D4-B1CF-4F16-BB78-08E1133A3BC3");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, "Regid");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, "RegID usato da android");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, "F6A729A4-B60C-4B29-983B-5EC198FB5281");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, "ID Apps Push Settings");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, "Identificativo univoco");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.VIS_FOREIKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, 0, -1);
  }

  private void PAN_DEVICETOKEN_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 0, 36, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 20);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, "ID");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 4, 4, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 56);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, "ID");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_ID, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_ID, PPQRY_DEVICETOKEN5, "A.ID", "ID", 1, 9, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 40, 36, 396, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, "Dev Token");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 120, 4, 368, 24, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, "Dev Token");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DEVTOKEN, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DEVTOKEN, PPQRY_DEVICETOKEN5, "A.DEV_TOKEN", "DEV_TOKEN", 5, 200, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 4, 280, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, "Utente");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 492, 4, 288, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 52);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, "Utente");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_UTENTE, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_UTENTE, PPQRY_DEVICETOKEN5, "A.DES_UTENTE", "DES_UTENTE", 5, 100, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 476, 36, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 40);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, "Attivo");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 4, 32, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 56);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, "Attivo");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_ATTIVO, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_ATTIVO, PPQRY_DEVICETOKEN5, "A.FLG_ATTIVO", "FLG_ATTIVO", 5, 1, 0, -685);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_ATTIVO, (new IDVariant("S")), "Si", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_ATTIVO, (new IDVariant("N")), "No", "", "", -1);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 532, 36, 64, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 48);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, "Rimosso");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 116, 32, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 56);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, "Rimosso");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_RIMOSSO, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_RIMOSSO, PPQRY_DEVICETOKEN5, "A.FLG_RIMOSSO", "FLG_RIMOSSO", 5, 1, 0, -685);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_RIMOSSO, (new IDVariant("N")), "No", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_RIMOSSO, (new IDVariant("S")), "Si", "", "", -1);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 4, 328, 448, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, "Data Rimozione");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 228, 32, 260, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, "Data Rimozione");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATARIMOZION, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATARIMOZION, PPQRY_DEVICETOKEN5, "A.DATA_RIMOZ", "DATA_RIMOZ", 8, 61, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 4, 304, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, "Nota");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 4, 60, 776, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 56);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, "Nota");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_NOTA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_NOTA, PPQRY_DEVICETOKEN5, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_LIST, 4, 352, 528, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_LIST, 2);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_LIST, "Regid");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_FORM, 4, 92, 776, 48, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_FORM, 56);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_FORM, 3);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_FORM, "Regid");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_REGID, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_REGID, PPQRY_DEVICETOKEN5, "A.REG_ID", "REG_ID", 5, 200, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_LIST, 0, 36, 116, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_LIST, 116);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_LIST, "ID Apps Push Settings");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_FORM, 4, 316, 176, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_FORM, 116);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_FORM, "ID Apps Push Settings");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_IDAPPSPUSSET, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_IDAPPSPUSSET, PPQRY_DEVICETOKEN5, "A.ID_APPLICAZIONE", "ID_APPLICAZIONE", 1, 9, 0, -685);
  }

  private void PAN_DEVICETOKEN_InitQueries()
  {
    StringBuilder SQL;

    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_QUERY, 2);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPUSENOOG ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A ");
    SQL.Append("where (A.ID = ~~ID_APPLICAZIONE~~) ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LOOAPPPUSSET, 0, SQL, -1, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_LOOAPPPUSSET, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DEVICETOKEN.SetMasterTable(PPQRY_LOOAPPPUSSET, "APPS_PUSH_SETTING");
    PAN_DEVICETOKEN.SetIMDB(IMDB, "PQRY_DEVICETOKEN5", true);
    PAN_DEVICETOKEN.set_SetString(MyGlb.MASTER_ROWNAME, "Device Token");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.ID_APPLICAZIONE as ID_APPLICAZIONE, ");
    SQL.Append("  A.DEV_TOKEN as DEV_TOKEN, ");
    SQL.Append("  A.FLG_ATTIVO as FLG_ATTIVO, ");
    SQL.Append("  A.DES_UTENTE as DES_UTENTE, ");
    SQL.Append("  A.FLG_RIMOSSO as FLG_RIMOSSO, ");
    SQL.Append("  A.DES_NOTA as DES_NOTA, ");
    SQL.Append("  A.DATA_RIMOZ as DATA_RIMOZ, ");
    SQL.Append("  A.REG_ID as REG_ID ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN5, 0, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  DEV_TOKENS A ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN5, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.ID_APPLICAZIONE = ~~PQRY_SPEDIZIONI.ID_APPLICAZIONE~~) ");
    SQL.Append("and   (A.REG_ID = ~~PQRY_SPEDIZIONI.REG_ID~~) ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN5, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN5, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN5, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN5, 5, SQL, -1, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_DEVICETOKEN5, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DEVICETOKEN.SetMasterTable(0, "DEV_TOKENS");
    SQL = new StringBuilder("");
    PAN_DEVICETOKEN.SetQuery(0, -1, SQL, PFL_DEVICETOKEN_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_SPEDIZIONI) PAN_SPEDIZIONI_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
    if (SrcObj == PAN_DATITEMP) PAN_DATITEMP_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
    if (SrcObj == PAN_DEVICETOKEN) PAN_DEVICETOKEN_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_SPEDIZIONI) PAN_SPEDIZIONI_ValidateRow(Cancel);
    if (SrcObj == PAN_DATITEMP) PAN_DATITEMP_ValidateRow(Cancel);
    if (SrcObj == PAN_DEVICETOKEN) PAN_DEVICETOKEN_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_SPEDIZIONI) PAN_SPEDIZIONI_CellActivated(ColIndex, Cancel);
    if (SrcObj == PAN_DATITEMP) PAN_DATITEMP_CellActivated(ColIndex, Cancel);
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
