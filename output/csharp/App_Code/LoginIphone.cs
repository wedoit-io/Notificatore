// **********************************************
// Login Iphone
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
public partial class LoginIphone : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_LOGIN_EMAIL = 0;
  private const int PFL_LOGIN_PIN = 1;
  private const int PFL_LOGIN_BOTTONELOGIN = 2;
  private const int PFL_LOGIN_LOGO = 3;
  private const int PFL_LOGIN_ETICHESCRIVI = 4;

  private const int PPQRY_DATIDILOGIN2 = 0;


  internal IDPanel PAN_LOGIN;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    Init_TBL_DATIDILOGIN3(IMDB);
    //
    //
    Init_PQRY_DATIDILOGIN2(IMDB);
    Init_PQRY_DATIDILOGIN2_RS(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_TBL_DATIDILOGIN3(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.TBL_DATIDILOGIN3, 2);
    IMDB.set_TblCode(IMDBDef1.TBL_DATIDILOGIN3, "TBL_DATIDILOGIN3");
    IMDB.set_FldCode(IMDBDef1.TBL_DATIDILOGIN3,IMDBDef1.FLD_DATIDILOGIN3_EMAINUOVPANN, "EMAINUOVPANN");
    IMDB.SetFldParams(IMDBDef1.TBL_DATIDILOGIN3,IMDBDef1.FLD_DATIDILOGIN3_EMAINUOVPANN,5,255,0);
    IMDB.set_FldCode(IMDBDef1.TBL_DATIDILOGIN3,IMDBDef1.FLD_DATIDILOGIN3_PINNUOVOPANN, "PINNUOVOPANN");
    IMDB.SetFldParams(IMDBDef1.TBL_DATIDILOGIN3,IMDBDef1.FLD_DATIDILOGIN3_PINNUOVOPANN,5,255,0);
    IMDB.TblAddNew(IMDBDef1.TBL_DATIDILOGIN3, 0);
  }

  private static void Init_PQRY_DATIDILOGIN2(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DATIDILOGIN2, 2);
    IMDB.set_TblCode(IMDBDef1.PQRY_DATIDILOGIN2, "PQRY_DATIDILOGIN2");
    IMDB.set_FldCode(IMDBDef1.PQRY_DATIDILOGIN2,IMDBDef1.PQSL_DATIDILOGIN2_EMAINUOVPANN, "EMAINUOVPANN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATIDILOGIN2,IMDBDef1.PQSL_DATIDILOGIN2_EMAINUOVPANN,5,255,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DATIDILOGIN2,IMDBDef1.PQSL_DATIDILOGIN2_PINNUOVOPANN, "PINNUOVOPANN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATIDILOGIN2,IMDBDef1.PQSL_DATIDILOGIN2_PINNUOVOPANN,5,255,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_DATIDILOGIN2, 0);
  }

  private static void Init_PQRY_DATIDILOGIN2_RS(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DATIDILOGIN2_RS, 2);
    IMDB.set_TblCode(IMDBDef1.PQRY_DATIDILOGIN2_RS, "PQRY_DATIDILOGIN2_RS");
    IMDB.set_FldCode(IMDBDef1.PQRY_DATIDILOGIN2_RS,IMDBDef1.PQSL_DATIDILOGIN2_EMAINUOVPANN, "EMAINUOVPANN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATIDILOGIN2_RS,IMDBDef1.PQSL_DATIDILOGIN2_EMAINUOVPANN,5,255,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DATIDILOGIN2_RS,IMDBDef1.PQSL_DATIDILOGIN2_PINNUOVOPANN, "PINNUOVOPANN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DATIDILOGIN2_RS,IMDBDef1.PQSL_DATIDILOGIN2_PINNUOVOPANN,5,255,0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public LoginIphone(MyWebEntryPoint w, IMDBObj imdb)
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
  public LoginIphone()
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
    FormIdx = MyGlb.FRM_LOGINIPHONE;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "16A2632A-7A77-4DE1-9957-B8776E97FF7D";
    ResModeW = 1;
    ResModeH = 3;
    iVisualFlags = -2050;
    DesignWidth = 308;
    DesignHeight = 328;
    set_Caption(new IDVariant("Login Iphone"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 308;
    Frames[1].Height = 328;
    Frames[1].FrHidden = true;
    Frames[1].Caption = "Login";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 328;
    PAN_LOGIN = new IDPanel(w, this, 1, "PAN_LOGIN");
    Frames[1].Content = PAN_LOGIN;
    PAN_LOGIN.Lockable = false;
    PAN_LOGIN.iLocked = false;
    PAN_LOGIN.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_LOGIN.VS = MainFrm.VisualStyleList;
    PAN_LOGIN.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 308-MyGlb.PAN_OFFS_X, 328-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "197BBEBB-035F-4912-AA89-77ED20420B37");
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
      if (IMDB.TblModified(IMDBDef1.TBL_DATIDILOGIN3, MyGlb.GlbRefModIdx) || JustLoaded)
      {
        LOGINIPHONE_DATIDILOGIN2();
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
    return (obj is LoginIphone);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(LoginIphone).FullName : typeof(LoginIphone).Name);
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

      if (!MainFrm.DTTObj.EnterProc("FEF03126-2661-4658-8388-E223198A6597", "Bottone Login", "Esegue il login", 3, "Login Iphone")) return 0;
      // 
      // Bottone Login Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddIf ("3903ED4A-EB41-4BDE-BD6A-BF02B2F4D807", "IF Esegue Login (Email Nuovo Pannello, PIN Nuovo Pannello)", "");
      MainFrm.DTTObj.AddToken ("3903ED4A-EB41-4BDE-BD6A-BF02B2F4D807", "EC37344F-64F9-4AC0-AD32-61C138D5F9FD", 327680, "Email", IMDB.Value(IMDBDef1.TBL_DATIDILOGIN3, IMDBDef1.FLD_DATIDILOGIN3_EMAINUOVPANN, 0));
      MainFrm.DTTObj.AddToken ("3903ED4A-EB41-4BDE-BD6A-BF02B2F4D807", "1C2CB2D0-E651-487B-AA4B-72DBF329EBCA", 327680, "PIN", IMDB.Value(IMDBDef1.TBL_DATIDILOGIN3, IMDBDef1.FLD_DATIDILOGIN3_PINNUOVOPANN, 0));
      if (MainFrm.EsegueLogin(IMDB.Value(IMDBDef1.TBL_DATIDILOGIN3, IMDBDef1.FLD_DATIDILOGIN3_EMAINUOVPANN, 0), IMDB.Value(IMDBDef1.TBL_DATIDILOGIN3, IMDBDef1.FLD_DATIDILOGIN3_PINNUOVOPANN, 0)))
      {
        MainFrm.DTTObj.EnterIf ("3903ED4A-EB41-4BDE-BD6A-BF02B2F4D807", "IF Esegue Login (Email Nuovo Pannello, PIN Nuovo Pannello)", "");
        MainFrm.DTTObj.AddSubProc ("EA8D896D-64C6-44CA-99A6-E99112135404", "Login Iphone.Close", "");
        MainFrm.UnloadForm(FormIdx,(new IDVariant(0)).booleanValue()); 
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("5F3408A4-3057-416F-B24A-4D1EA405CB08", "ELSE", "", "3903ED4A-EB41-4BDE-BD6A-BF02B2F4D807");
        MainFrm.DTTObj.AddSubProc ("3A1A43BC-D941-4E79-83C5-9A4E3A979B61", "Notificatore.Message Box", "");
        MainFrm.DTTObj.AddParameter ("3A1A43BC-D941-4E79-83C5-9A4E3A979B61", "47B9C053-DD93-4025-9454-3AEFF386B352", "Messaggio", (new IDVariant("I dati inseriti non sono stati riconosciuti. Correggili e riprova.")));
        MainFrm.set_AlertMessage((new IDVariant("I dati inseriti non sono stati riconosciuti. Correggili e riprova."))); 
      }
      MainFrm.DTTObj.EndIfBlk ("3903ED4A-EB41-4BDE-BD6A-BF02B2F4D807");
      MainFrm.DTTObj.ExitProc("FEF03126-2661-4658-8388-E223198A6597", "Bottone Login", "Esegue il login", 3, "Login Iphone");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("FEF03126-2661-4658-8388-E223198A6597", "Bottone Login", "Esegue il login", _e);
      MainFrm.ErrObj.ProcError ("LoginIphone", "BottoneLogin", _e);
      MainFrm.DTTObj.ExitProc("FEF03126-2661-4658-8388-E223198A6597", "Bottone Login", "Esegue il login", 3, "Login Iphone");
      return -1;
    }
  }

  // **********************************************************************
  // Dati Di Login
  // Recupera i record da mostrare nel pannello
  // **********************************************************************
  private void LOGINIPHONE_DATIDILOGIN2()
  {
    IDVariant[] AggrBuff;
    int[] AggrRowCount;
    int AggrCount=0;
    bool AggrNewGroup = false;

    IMDB.TblTruncate(IMDBDef1.PQRY_DATIDILOGIN2_RS);
    IMDB.TblMoveFirst(IMDBDef1.TBL_DATIDILOGIN3, 0);
    Loop1: while (!IMDB.Eof(IMDBDef1.TBL_DATIDILOGIN3, 0))
    {
      IMDB.TblAddNew(IMDBDef1.PQRY_DATIDILOGIN2_RS, 0);
      IMDB.TblLinkRow(IMDBDef1.PQRY_DATIDILOGIN2_RS, 0, IMDBDef1.TBL_DATIDILOGIN3, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_DATIDILOGIN2_RS, 0, 0, IMDBDef1.TBL_DATIDILOGIN3, IMDBDef1.FLD_DATIDILOGIN3_EMAINUOVPANN, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_DATIDILOGIN2_RS, 1, 0, IMDBDef1.TBL_DATIDILOGIN3, IMDBDef1.FLD_DATIDILOGIN3_PINNUOVOPANN, 0);
      IMDB.TblMoveNext(IMDBDef1.TBL_DATIDILOGIN3, 0);
      if (IMDB.Eof(IMDBDef1.TBL_DATIDILOGIN3, 0))
      {
        IMDB.TblMoveFirst(IMDBDef1.TBL_DATIDILOGIN3, 0);
      }
      else
      {
        goto Loop1;
      }
      break;
    }
    IMDB.TblMoveFirst(IMDBDef1.PQRY_DATIDILOGIN2_RS, 0);
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
    PAN_LOGIN.SetSize(MyGlb.OBJ_FIELD, 5);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, "88EBD434-45B4-4FB6-B2BC-2121DC408E78");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, "Email");
    PAN_LOGIN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, "");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.VIS_VIDEATIPHONE);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, "23BEFCE6-C5AE-4088-A4B5-EBDB4402DBF3");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, "PIN");
    PAN_LOGIN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, "");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.VIS_VIDEATIPHONE);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, "815E3B24-8555-4E44-B42E-9BEE3CCAB307");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, "Login");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.VIS_COMAIPHOGRAN);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_NOACTD | MyGlb.FLD_CANACTIVATE, -1);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_LOGO, "CFC24FA6-96D2-4CDE-A115-21CCC04F1635");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_LOGO, "");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_LOGO, MyGlb.VIS_IMAGEFIELD);
    PAN_LOGIN.SetImage(MyGlb.OBJ_FIELD, PFL_LOGIN_LOGO, 0, "logoiphone.gif", false);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_LOGO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM, -1);
    PAN_LOGIN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, "67244045-2BE3-45F5-87B6-C8EE24642224");
    PAN_LOGIN.set_Header(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, "Scrivi l'indirizzo email e il PIN che hai usato al momento della registrazione. Se non sei registrato, accedi con il PC o l'iPad per farlo.");
    PAN_LOGIN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.VIS_INTESTPICCOL);
    PAN_LOGIN.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM, -1);
  }

  private void PAN_LOGIN_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_LIST, 84, 88, 144, 40, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_LIST, 32);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_LIST, 1);
    PAN_LOGIN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_LIST, "E.");
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_FORM, 12, 160, 272, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_FORM, 56);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_FORM, 1);
    PAN_LOGIN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGIN_EMAIL, MyGlb.PANEL_FORM, "Email");
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_EMAIL, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_EMAIL, PPQRY_DATIDILOGIN2, "A.EMAINUOVPANN", "EMAINUOVPANN", 5, 255, 0, -1709);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_LIST, 24, 132, 184, 48, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_LIST, 36);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_LIST, 2);
    PAN_LOGIN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_LIST, "PIN");
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_FORM, 12, 196, 272, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_FORM, 56);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_FORM, 1);
    PAN_LOGIN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGIN_PIN, MyGlb.PANEL_FORM, "PIN");
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_PIN, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_PIN, PPQRY_DATIDILOGIN2, "A.PINNUOVOPANN", "PINNUOVOPANN", 5, 255, 0, -1709);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.PANEL_LIST, 72, 176, 104, 36, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.PANEL_LIST, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.PANEL_LIST, 1);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.PANEL_FORM, 104, 248, 104, 36, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.PANEL_FORM, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_BOTTONELOGIN, MyGlb.PANEL_FORM, 1);
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_BOTTONELOGIN, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_BOTTONELOGIN, -1, "", "BOTTONELOGIN", 0, 0, 0, -1709);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_LOGO, MyGlb.PANEL_LIST, 56, 48, 47, 43, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_LOGO, MyGlb.PANEL_LIST, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_LOGO, MyGlb.PANEL_LIST, 2);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_LOGO, MyGlb.PANEL_FORM, 12, 4, 280, 96, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_LOGO, MyGlb.PANEL_FORM, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_LOGO, MyGlb.PANEL_FORM, 5);
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_LOGO, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_LOGO, -1, "", "LOGO", 0, 0, 0, -1709);
    PAN_LOGIN.set_ImageResizeMode(PFL_LOGIN_LOGO, 2);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.PANEL_LIST, 12, 88, 80, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.PANEL_LIST, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.PANEL_LIST, 1);
    PAN_LOGIN.SetRect(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.PANEL_FORM, 12, 100, 272, 48, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGIN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.PANEL_FORM, 0);
    PAN_LOGIN.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGIN_ETICHESCRIVI, MyGlb.PANEL_FORM, 2);
    PAN_LOGIN.SetFieldPage(PFL_LOGIN_ETICHESCRIVI, -1, -1);
    PAN_LOGIN.SetFieldPanel(PFL_LOGIN_ETICHESCRIVI, -1, "", "ETICHESCRIVI", 0, 0, 0, -1709);
    PAN_LOGIN.set_Alignment(PFL_LOGIN_ETICHESCRIVI, 2);
  }

  private void PAN_LOGIN_InitQueries()
  {
    StringBuilder SQL;

    PAN_LOGIN.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_LOGIN.SetIMDB(IMDB, "PQRY_DATIDILOGIN2", true);
    PAN_LOGIN.set_SetString(MyGlb.MASTER_ROWNAME, "Record");
    PAN_LOGIN.SetQueryIMDB(PPQRY_DATIDILOGIN2, IMDBDef1.PQRY_DATIDILOGIN2_RS, IMDBDef1.TBL_DATIDILOGIN3);
    JustLoaded = true;
    PAN_LOGIN.SetFieldPrimaryIndex(PFL_LOGIN_EMAIL, IMDBDef1.FLD_DATIDILOGIN3_EMAINUOVPANN);
    PAN_LOGIN.SetFieldPrimaryIndex(PFL_LOGIN_PIN, IMDBDef1.FLD_DATIDILOGIN3_PINNUOVOPANN);
    PAN_LOGIN.SetMasterTable(0, "DATIDILOGIN3");
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
