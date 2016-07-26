// **********************************************
// Login Ipad
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
public partial class LoginIpad : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_LOGIN_EMAIL = 0;
  private const int PFL_LOGIN_PIN = 1;
  private const int PFL_LOGIN_BOTTONELOGIN = 2;
  private const int PFL_LOGIN_BENVEINISPES = 3;
  private const int PFL_LOGIN_ETICHESCRIVI = 4;
  private const int PFL_LOGIN_BENVEINISPE1 = 5;
  private const int PFL_LOGIN_IDCOMUNE = 6;
  private const int PFL_LOGIN_ETICILSISPIU = 7;
  private const int PFL_LOGIN_PASSWOUTENTE = 8;

  private const int PPQRY_DATIDILOGIN1 = 0;


  internal IDPanel PAN_LOGIN;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    Init_TBL_DATIDILOGIN(IMDB);
    //
    //
    Init_PQRY_DATIDILOGIN1(IMDB);
    Init_PQRY_DATIDILOGIN1_RS(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_TBL_DATIDILOGIN(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.TBL_DATIDILOGIN, 8);
    IMDB.set_TblCode(IMDBDef1.TBL_DATIDILOGIN, "TBL_DATIDILOGIN");
    IMDB.set_FldCode(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_EMAINUOVPANN, "EMAINUOVPANN");
    IMDB.SetFldParams(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_EMAINUOVPANN,5,255,0);
    IMDB.set_FldCode(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_PINNUOVOPANN, "PINNUOVOPANN");
    IMDB.SetFldParams(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_PINNUOVOPANN,5,255,0);
    IMDB.set_FldCode(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_NOMUTENUOPAN, "NOMUTENUOPAN");
    IMDB.SetFldParams(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_NOMUTENUOPAN,5,50,0);
    IMDB.set_FldCode(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_COGUTENUOPAN, "COGUTENUOPAN");
    IMDB.SetFldParams(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_COGUTENUOPAN,5,50,0);
    IMDB.set_FldCode(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_GENUTENUOPAN, "GENUTENUOPAN");
    IMDB.SetFldParams(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_GENUTENUOPAN,5,1,0);
    IMDB.set_FldCode(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_EMAUTENUOPAN, "EMAUTENUOPAN");
    IMDB.SetFldParams(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_EMAUTENUOPAN,5,100,0);
    IMDB.set_FldCode(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_PASUTENUOPAN, "PASUTENUOPAN");
    IMDB.SetFldParams(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_PASUTENUOPAN,5,10,0);
    IMDB.set_FldCode(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_COMUTENUOPAN, "COMUTENUOPAN");
    IMDB.SetFldParams(IMDBDef1.TBL_DATIDILOGIN,IMDBDef1.FLD_DATIDILOGIN_COMUTENUOPAN,1,6,0);
    IMDB.TblAddNew(IMDBDef1.TBL_DATIDILOGIN, 0);
  }

  private static void Init_PQRY_DATIDILOGIN1(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DATIDILOGIN1, 4);
    IMDB.set_TblCode(IMDBDef1.PQRY_DATIDILOGIN1, "PQRY_DATIDILOGIN1");
    IMDB.set_FldCode(IMDBDef1.PQRY_DATIDILOGIN1,IMDBDef1.PQSL_DATIDILOGIN1_EMAINUOVPANN, "EMAINUOVPANN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATIDILOGIN1,IMDBDef1.PQSL_DATIDILOGIN1_EMAINUOVPANN,5,255,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DATIDILOGIN1,IMDBDef1.PQSL_DATIDILOGIN1_PINNUOVOPANN, "PINNUOVOPANN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATIDILOGIN1,IMDBDef1.PQSL_DATIDILOGIN1_PINNUOVOPANN,5,255,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DATIDILOGIN1,IMDBDef1.PQSL_DATIDILOGIN1_PASUTENUOPAN, "PASUTENUOPAN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATIDILOGIN1,IMDBDef1.PQSL_DATIDILOGIN1_PASUTENUOPAN,5,10,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DATIDILOGIN1,IMDBDef1.PQSL_DATIDILOGIN1_COMUTENUOPAN, "COMUTENUOPAN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATIDILOGIN1,IMDBDef1.PQSL_DATIDILOGIN1_COMUTENUOPAN,1,6,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_DATIDILOGIN1, 0);
  }

  private static void Init_PQRY_DATIDILOGIN1_RS(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DATIDILOGIN1_RS, 4);
    IMDB.set_TblCode(IMDBDef1.PQRY_DATIDILOGIN1_RS, "PQRY_DATIDILOGIN1_RS");
    IMDB.set_FldCode(IMDBDef1.PQRY_DATIDILOGIN1_RS,IMDBDef1.PQSL_DATIDILOGIN1_EMAINUOVPANN, "EMAINUOVPANN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATIDILOGIN1_RS,IMDBDef1.PQSL_DATIDILOGIN1_EMAINUOVPANN,5,255,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DATIDILOGIN1_RS,IMDBDef1.PQSL_DATIDILOGIN1_PINNUOVOPANN, "PINNUOVOPANN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATIDILOGIN1_RS,IMDBDef1.PQSL_DATIDILOGIN1_PINNUOVOPANN,5,255,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DATIDILOGIN1_RS,IMDBDef1.PQSL_DATIDILOGIN1_PASUTENUOPAN, "PASUTENUOPAN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATIDILOGIN1_RS,IMDBDef1.PQSL_DATIDILOGIN1_PASUTENUOPAN,5,10,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DATIDILOGIN1_RS,IMDBDef1.PQSL_DATIDILOGIN1_COMUTENUOPAN, "COMUTENUOPAN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATIDILOGIN1_RS,IMDBDef1.PQSL_DATIDILOGIN1_COMUTENUOPAN,1,6,0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public LoginIpad(MyWebEntryPoint w, IMDBObj imdb)
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
  public LoginIpad()
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
    FormIdx = MyGlb.FRM_LOGINIPAD;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "CCDC006F-BDE9-4A6B-BF0C-1783660D36AA";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2050;
    DesignWidth = 720;
    DesignHeight = 564;
    set_Caption(new IDVariant("Login Ipad"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 720;
    Frames[1].Height = 564;
    Frames[1].FrHidden = true;
    Frames[1].Caption = "Login";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 564;
    PAN_LOGIN = new IDPanel(w, this, 1, "PAN_LOGIN");
    Frames[1].Content = PAN_LOGIN;
    PAN_LOGIN.Lockable = false;
    PAN_LOGIN.iLocked = false;
    PAN_LOGIN.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_LOGIN.VS = MainFrm.VisualStyleList;
    PAN_LOGIN.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 720-MyGlb.PAN_OFFS_X, 564-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "EBEC1CCC-3D1B-4667-8818-3C054A590913");
    PAN_LOGIN.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 0, 276, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_VIDEATIPHONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_STARTFORM | MyGlb.PAN_CANUPDATE | MyGlb.PAN_AUTOSAVE | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_LOGIN.InitStatus = 1;
    PAN_LOGIN_Init();
    PAN_LOGIN_InitFields();
    PAN_LOGIN_InitQueries();
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
      if (IMDB.TblModified(IMDBDef1.TBL_DATIDILOGIN, MyGlb.GlbRefModIdx) || JustLoaded)
      {
        LOGINIPAD_DATIDILOGIN1();
      }
      PAN_LOGIN.UpdatePanel(MainFrm);
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
    return (obj is LoginIpad);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(LoginIpad).FullName : typeof(LoginIpad).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Bottone Login
  // Esegue il login
  // **********************************************************************
  public int BottoneLogin ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Bottone Login Body
      // Corpo Procedura
      // 
      if (MainFrm.EsegueLogin(IMDB.Value(IMDBDef1.TBL_DATIDILOGIN, IMDBDef1.FLD_DATIDILOGIN_EMAINUOVPANN, 0), IMDB.Value(IMDBDef1.TBL_DATIDILOGIN, IMDBDef1.FLD_DATIDILOGIN_PINNUOVOPANN, 0)))
      {
        MainFrm.UnloadForm(FormIdx,(new IDVariant(0)).booleanValue()); 
      }
      else
      {
        MainFrm.set_AlertMessage((new IDVariant("I dati inseriti non sono stati riconosciuti. Correggili e riprova."))); 
      }
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("LoginIpad", "BottoneLogin", _e);
      return -1;
    }
  }

  // **********************************************************************
  // On Resize
  // Evento notificato al form quando viene ridimensionato
  // NewWidth - Input/Output
  // NewHeight - Input/Output
  // Cancel - Input/Output
  // **********************************************************************
  public override void OnResize(IDVariant NewWidth,IDVariant NewHeight,IDVariant Cancel)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // On Resize Body
      // Corpo Procedura
      // 
      // 
      // allineamento logo
      // 
      PAN_LOGIN.set_ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, IDPanel.RT_LEFT, Glb.PANEL_FORM, IDL.Div((IDL.Sub(NewWidth, (new IDVariant(PAN_LOGIN.ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, IDPanel.RT_WIDTH, Glb.PANEL_FORM))))), (new IDVariant(2))).intValue());
      // 
      // oggetti allineati alla sinistra del logo
      // 
      PAN_LOGIN.set_ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, IDPanel.RT_LEFT, Glb.PANEL_FORM, IDL.Div((IDL.Sub(NewWidth, (new IDVariant(PAN_LOGIN.ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, IDPanel.RT_WIDTH, Glb.PANEL_FORM))))), (new IDVariant(2))).intValue());
      PAN_LOGIN.set_ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, IDPanel.RT_LEFT, Glb.PANEL_FORM, (new IDVariant(PAN_LOGIN.ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, IDPanel.RT_LEFT, Glb.PANEL_FORM))).intValue());
      PAN_LOGIN.set_ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_EMAIL, IDPanel.RT_LEFT, Glb.PANEL_FORM, (new IDVariant(PAN_LOGIN.ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, IDPanel.RT_LEFT, Glb.PANEL_FORM))).intValue());
      PAN_LOGIN.set_ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_PIN, IDPanel.RT_LEFT, Glb.PANEL_FORM, (new IDVariant(PAN_LOGIN.ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, IDPanel.RT_LEFT, Glb.PANEL_FORM))).intValue());
      PAN_LOGIN.set_ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BENVEINISPE1, IDPanel.RT_LEFT, Glb.PANEL_FORM, (new IDVariant(PAN_LOGIN.ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, IDPanel.RT_LEFT, Glb.PANEL_FORM))).intValue());
      // 
      // oggetti allineati alla destra interna della colonna
      // di sinistra
      // 
      PAN_LOGIN.set_ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, IDPanel.RT_LEFT, Glb.PANEL_FORM, IDL.Sub(IDL.Add((new IDVariant(PAN_LOGIN.ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, IDPanel.RT_LEFT, Glb.PANEL_FORM))), (new IDVariant(PAN_LOGIN.ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_EMAIL, IDPanel.RT_WIDTH, Glb.PANEL_FORM)))), (new IDVariant(PAN_LOGIN.ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, IDPanel.RT_WIDTH, Glb.PANEL_FORM)))).intValue());
      // 
      // oggetti allineati alla destra del logo
      // 
      PAN_LOGIN.set_ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_ETICILSISPIU, IDPanel.RT_LEFT, Glb.PANEL_FORM, IDL.Sub(IDL.Add((new IDVariant(PAN_LOGIN.ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, IDPanel.RT_LEFT, Glb.PANEL_FORM))), (new IDVariant(PAN_LOGIN.ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, IDPanel.RT_WIDTH, Glb.PANEL_FORM)))), (new IDVariant(PAN_LOGIN.ObjRect(Glb.OBJ_FIELD, PFL_LOGIN_ETICILSISPIU, IDPanel.RT_WIDTH, Glb.PANEL_FORM)))).intValue());
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("LoginIpad", "OnResize", _e);
    }
  }

  // **********************************************************************
  // Dati Di Login
  // Recupera i record da mostrare nel pannello
  // **********************************************************************
  private void LOGINIPAD_DATIDILOGIN1()
  {
    IDVariant[] AggrBuff;
    int[] AggrRowCount;
    int AggrCount=0;
    bool AggrNewGroup = false;

    IMDB.TblTruncate(IMDBDef1.PQRY_DATIDILOGIN1_RS);
    IMDB.TblMoveFirst(IMDBDef1.TBL_DATIDILOGIN, 0);
    Loop1: while (!IMDB.Eof(IMDBDef1.TBL_DATIDILOGIN, 0))
    {
      IMDB.TblAddNew(IMDBDef1.PQRY_DATIDILOGIN1_RS, 0);
      IMDB.TblLinkRow(IMDBDef1.PQRY_DATIDILOGIN1_RS, 0, IMDBDef1.TBL_DATIDILOGIN, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_DATIDILOGIN1_RS, 0, 0, IMDBDef1.TBL_DATIDILOGIN, IMDBDef1.FLD_DATIDILOGIN_EMAINUOVPANN, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_DATIDILOGIN1_RS, 1, 0, IMDBDef1.TBL_DATIDILOGIN, IMDBDef1.FLD_DATIDILOGIN_PINNUOVOPANN, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_DATIDILOGIN1_RS, 2, 0, IMDBDef1.TBL_DATIDILOGIN, IMDBDef1.FLD_DATIDILOGIN_PASUTENUOPAN, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_DATIDILOGIN1_RS, 3, 0, IMDBDef1.TBL_DATIDILOGIN, IMDBDef1.FLD_DATIDILOGIN_COMUTENUOPAN, 0);
      IMDB.TblMoveNext(IMDBDef1.TBL_DATIDILOGIN, 0);
      if (IMDB.Eof(IMDBDef1.TBL_DATIDILOGIN, 0))
      {
        IMDB.TblMoveFirst(IMDBDef1.TBL_DATIDILOGIN, 0);
      }
      else
      {
        goto Loop1;
      }
      break;
    }
    IMDB.TblMoveFirst(IMDBDef1.PQRY_DATIDILOGIN1_RS, 0);
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
  private void PAN_LOGIN_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
    if (ColIndex.intValue() == PFL_LOGIN_BOTTONELOGIN)
    {
      this.IdxPanelActived = this.PAN_LOGIN.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      BottoneLogin();
      Cancel.set(IDVariant.TRUE);
    }
  }

  private void PAN_LOGIN_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_LOGIN_ValidateRow(IDVariant Cancel)
  {
    try
    {
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_LOGIN_Init()
  {

    PAN_LOGIN.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_LOGIN.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_LOGIN.SetSize(MyGlb.OBJ_FIELD, 9);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, "E923C6E7-E1D4-4EDB-970D-79B2739B4C62");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, "Email");
    PAN_LOGIN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, "");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.VIS_VIDEATIPHONE);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, "B5E0A895-66EE-4486-A243-62B78EC7FB8C");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, "PIN");
    PAN_LOGIN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, "");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.VIS_VIDEATIPHONE);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, "098984F4-A573-42B9-A4A2-3F74A4B947A8");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, "Login");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.VIS_COMANDIPHONE);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_NOACTD | MyGlb.FLD_CANACTIVATE, -1);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, "038D9BEC-6D40-4290-9888-789DB86A76B3");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, "");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, MyGlb.VIS_IMAGEFIELD);
    PAN_LOGIN.SetImage(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, 0, "logoipad.gif", false);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM, -1);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, "5257B874-1CE1-42B0-935C-A1E6B68A892B");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, "Scrivi l'indirizzo email e il PIN che hai usato al momento della registrazione.");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.VIS_INTESTPICCOL);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM, -1);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPE1, "E6900092-BD12-4419-AF3A-B20CE118F0F3");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPE1, "Sei già registrato?");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPE1, MyGlb.VIS_INTESTIPHONE);
    PAN_LOGIN.SetImage(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPE1, 0, "sfuma.gif", false);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPE1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM, -1);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, "FE5B7953-2DE0-4FE7-B6C7-7BF12D58E893");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, "ID Comune");
    PAN_LOGIN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, "");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, MyGlb.VIS_VIDEATIPHONE);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, 0 | MyGlb.FLD_NOACTD | MyGlb.FLD_ISOPT, -1);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICILSISPIU, "BE0AAA3B-743B-425A-A3EA-59A4B9FA4562");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICILSISPIU, "Il sistema più semplice per la tua lista della spesa. Anche al supermercato!");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICILSISPIU, MyGlb.VIS_LABELFIELD);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICILSISPIU, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM, -1);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, "303EBD47-986E-4B75-A279-F2FFF9EDD91E");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, "Password Utente");
    PAN_LOGIN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, "");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, MyGlb.VIS_VIDEATIPHONE);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, 0, -1);
  }

  private void PAN_LOGIN_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_LIST, 84, 88, 144, 40, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_LIST, 32);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_LIST, 1);
    PAN_LOGIN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_LIST, "E.");
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_FORM, 216, 292, 316, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_FORM, 56);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_FORM, 1);
    PAN_LOGIN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_FORM, "Email");
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_EMAIL, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_EMAIL, PPQRY_DATIDILOGIN1, "A.EMAINUOVPANN", "EMAINUOVPANN", 5, 255, 0, -1709);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_LIST, 24, 132, 184, 48, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_LIST, 36);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_LIST, 2);
    PAN_LOGIN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_LIST, "PIN");
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_FORM, 216, 328, 316, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_FORM, 56);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_FORM, 1);
    PAN_LOGIN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_FORM, "PIN");
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_PIN, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_PIN, PPQRY_DATIDILOGIN1, "A.PINNUOVOPANN", "PINNUOVOPANN", 5, 255, 0, -1709);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.PANEL_LIST, 72, 176, 104, 36, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.PANEL_LIST, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.PANEL_LIST, 2);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.PANEL_FORM, 296, 384, 152, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.PANEL_FORM, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.PANEL_FORM, 2);
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_BOTTONELOGIN, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_BOTTONELOGIN, -1, "", "BOTTONELOGIN", 0, 0, 0, -1709);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, MyGlb.PANEL_LIST, 104, 28, 140, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, MyGlb.PANEL_LIST, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, MyGlb.PANEL_LIST, 2);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, MyGlb.PANEL_FORM, 27, 8, 665, 180, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, MyGlb.PANEL_FORM, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPES, MyGlb.PANEL_FORM, 10);
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_BENVEINISPES, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_BENVEINISPES, -1, "", "BENVEINISPES", 0, 0, 0, -1709);
    PAN_LOGIN.set_ImageResizeMode(PFL_LOGIN_BENVEINISPES, 2);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.PANEL_LIST, 12, 88, 80, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.PANEL_LIST, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.PANEL_LIST, 1);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.PANEL_FORM, 216, 248, 316, 36, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.PANEL_FORM, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.PANEL_FORM, 1);
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_ETICHESCRIVI, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_ETICHESCRIVI, -1, "", "ETICHESCRIVI", 0, 0, 0, -1709);
    PAN_LOGIN.set_Alignment(PFL_LOGIN_ETICHESCRIVI, 2);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPE1, MyGlb.PANEL_LIST, 104, 28, 140, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPE1, MyGlb.PANEL_LIST, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPE1, MyGlb.PANEL_LIST, 1);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPE1, MyGlb.PANEL_FORM, 216, 200, 316, 40, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPE1, MyGlb.PANEL_FORM, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_BENVEINISPE1, MyGlb.PANEL_FORM, 1);
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_BENVEINISPE1, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_BENVEINISPE1, -1, "", "BENVEINISPE1", 0, 0, 0, -1709);
    PAN_LOGIN.set_ImageResizeMode(PFL_LOGIN_BENVEINISPE1, 3);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, MyGlb.PANEL_LIST, 0, 32, 116, 24, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, MyGlb.PANEL_LIST, 116);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, MyGlb.PANEL_LIST, 1);
    PAN_LOGIN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, MyGlb.PANEL_LIST, "ID Comune");
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, MyGlb.PANEL_FORM, 332, 392, 272, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, MyGlb.PANEL_FORM, 80);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, MyGlb.PANEL_FORM, 1);
    PAN_LOGIN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGIN_IDCOMUNE, MyGlb.PANEL_FORM, "ID Com.");
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_IDCOMUNE, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_IDCOMUNE, PPQRY_DATIDILOGIN1, "A.COMUTENUOPAN", "COMUTENUOPAN", 1, 6, 0, -1709);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICILSISPIU, MyGlb.PANEL_LIST, 12, 100, 524, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICILSISPIU, MyGlb.PANEL_LIST, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICILSISPIU, MyGlb.PANEL_LIST, 2);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICILSISPIU, MyGlb.PANEL_FORM, 308, 160, 380, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICILSISPIU, MyGlb.PANEL_FORM, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICILSISPIU, MyGlb.PANEL_FORM, 1);
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_ETICILSISPIU, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_ETICILSISPIU, -1, "", "ETICILSISPIU", 0, 0, 0, -1709);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, MyGlb.PANEL_LIST, 0, 32, 84, 24, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, MyGlb.PANEL_LIST, 84);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, MyGlb.PANEL_LIST, 1);
    PAN_LOGIN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, MyGlb.PANEL_LIST, "Pass. Utn.");
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, MyGlb.PANEL_FORM, 4, 544, 168, 24, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, MyGlb.PANEL_FORM, 84);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, MyGlb.PANEL_FORM, 1);
    PAN_LOGIN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGIN_PASSWOUTENTE, MyGlb.PANEL_FORM, "Pass. Utn.");
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_PASSWOUTENTE, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_PASSWOUTENTE, PPQRY_DATIDILOGIN1, "A.PASUTENUOPAN", "PASUTENUOPAN", 5, 10, 0, -1709);
  }

  private void PAN_LOGIN_InitQueries()
  {
    StringBuilder SQL;

    PAN_LOGIN.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_LOGIN.SetIMDB(IMDB, "PQRY_DATIDILOGIN1", true);
    PAN_LOGIN.set_SetString(MyGlb.MASTER_ROWNAME, "Record");
    PAN_LOGIN.SetQueryIMDB(PPQRY_DATIDILOGIN1, IMDBDef1.PQRY_DATIDILOGIN1_RS, IMDBDef1.TBL_DATIDILOGIN);
    JustLoaded = true;
    PAN_LOGIN.SetFieldPrimaryIndex(PFL_LOGIN_EMAIL, IMDBDef1.FLD_DATIDILOGIN_EMAINUOVPANN);
    PAN_LOGIN.SetFieldPrimaryIndex(PFL_LOGIN_PIN, IMDBDef1.FLD_DATIDILOGIN_PINNUOVOPANN);
    PAN_LOGIN.SetFieldPrimaryIndex(PFL_LOGIN_IDCOMUNE, IMDBDef1.FLD_DATIDILOGIN_COMUTENUOPAN);
    PAN_LOGIN.SetFieldPrimaryIndex(PFL_LOGIN_PASSWOUTENTE, IMDBDef1.FLD_DATIDILOGIN_PASUTENUOPAN);
    PAN_LOGIN.SetMasterTable(0, "DATIDILOGIN");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_LOGIN) PAN_LOGIN_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_LOGIN) PAN_LOGIN_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_LOGIN) PAN_LOGIN_CellActivated(ColIndex, Cancel);
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
