// **********************************************
// Configurazione
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
public partial class Configurazione : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int GRP_IMPOSTAZIONI_GENERALE = 0;
  private const int GRP_IMPOSTAZIONI_APPLEIOS = 1;
  private const int GRP_IMPOSTAZIONI_ANDROID = 2;

  private const int PFL_IMPOSTAZIONI_ID = 0;
  private const int PFL_IMPOSTAZIONI_URLDIBASEAPP = 1;
  private const int PFL_IMPOSTAZIONI_INVIREPOESTR = 2;
  private const int PFL_IMPOSTAZIONI_WEBSERVIREFE = 3;
  private const int PFL_IMPOSTAZIONI_ATAUDEDAOG4S = 4;
  private const int PFL_IMPOSTAZIONI_GIDIREPELACM = 5;
  private const int PFL_IMPOSTAZIONI_BOTTINVINOTI = 6;
  private const int PFL_IMPOSTAZIONI_BOTRIPSPEINV = 7;
  private const int PFL_IMPOSTAZIONI_BOTTRIPUSPED = 8;
  private const int PFL_IMPOSTAZIONI_IMILLIDITVTL = 9;
  private const int PFL_IMPOSTAZIONI_PERCERNOTPUS = 10;
  private const int PFL_IMPOSTAZIONI_ATAUFEOG60MI = 11;
  private const int PFL_IMPOSTAZIONI_NUMADIMEPESP = 12;
  private const int PFL_IMPOSTAZIONI_BOTTCHECFEED = 13;
  private const int PFL_IMPOSTAZIONI_BOTELMAITORI = 14;
  private const int PFL_IMPOSTAZIONI_RESTARAPPLIC = 15;
  private const int PFL_IMPOSTAZIONI_RIFRLESPINSE = 16;
  private const int PFL_IMPOSTAZIONI_ELIDEFTOKRIM = 17;
  private const int PFL_IMPOSTAZIONI_MAXMESMEPESP = 18;

  private const int PPQRY_IMPOSTAZIONI = 0;


  internal IDPanel PAN_IMPOSTAZIONI;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_IMPOSTAZIONI(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_IMPOSTAZIONI(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_IMPOSTAZIONI, 13);
    IMDB.set_TblCode(IMDBDef1.PQRY_IMPOSTAZIONI, "PQRY_IMPOSTAZIONI");
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_FLG_REFRESH, "FLG_REFRESH");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_FLG_REFRESH,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_URL_APP, "URL_APP");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_URL_APP,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_PATH_CERTS, "PATH_CERTS");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_PATH_CERTS,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_ADMIN_MAIL, "ADMIN_MAIL");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_ADMIN_MAIL,5,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_WS_URL, "WS_URL");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_WS_URL,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_MAX_MESSAGGI, "MAX_MESSAGGI");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_MAX_MESSAGGI,1,5,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_FLG_CHECK, "FLG_CHECK");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_FLG_CHECK,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_NUM_TIMEOUT, "NUM_TIMEOUT");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_NUM_TIMEOUT,1,8,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_MAX_DAYS_RET, "MAX_DAYS_RET");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_MAX_DAYS_RET,1,5,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_FLG_DEL_REMOVED_TK, "FLG_DEL_REMOVED_TK");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_FLG_DEL_REMOVED_TK,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_MAX_MESSAGGI_C2DM, "MAX_MESSAGGI_C2DM");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_MAX_MESSAGGI_C2DM,1,5,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_FLG_DEBUG, "FLG_DEBUG");
    IMDB.SetFldParams(IMDBDef1.PQRY_IMPOSTAZIONI,IMDBDef1.PQSL_IMPOSTAZIONI_FLG_DEBUG,1,2,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_IMPOSTAZIONI, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public Configurazione(MyWebEntryPoint w, IMDBObj imdb)
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
  public Configurazione()
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
    FormIdx = MyGlb.FRM_CONFIGURAZIO;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "FB53D905-D5ED-4B9E-A156-953B72B9C172";
    ResModeW = 1;
    ResModeH = 1;
    iVisualFlags = -2049;
    DesignWidth = 788;
    DesignHeight = 630;
    set_Caption(new IDVariant("Configurazione"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 788;
    Frames[1].Height = 604;
    Frames[1].Caption = "Impostazioni";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 604;
    PAN_IMPOSTAZIONI = new IDPanel(w, this, 1, "PAN_IMPOSTAZIONI");
    Frames[1].Content = PAN_IMPOSTAZIONI;
    PAN_IMPOSTAZIONI.ShowRowSelector = false;
    PAN_IMPOSTAZIONI.ShowStatusbar = false;
    PAN_IMPOSTAZIONI.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_IMPOSTAZIONI.VS = MainFrm.VisualStyleList;
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 788-MyGlb.PAN_OFFS_X, 604-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "685A9980-B698-4845-943E-36293FBDE485");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 2324, 156, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_STARTFORM | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANINSERT | MyGlb.PAN_AUTOSAVE | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_IMPOSTAZIONI.InitStatus = 2;
    PAN_IMPOSTAZIONI_Init();
    PAN_IMPOSTAZIONI_InitFields();
    PAN_IMPOSTAZIONI_InitQueries();
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
      PAN_IMPOSTAZIONI.UpdatePanel(MainFrm);
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
    return (obj is Configurazione);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(Configurazione).FullName : typeof(Configurazione).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Impostazioni On Updating Row
  // Evento notificato dal pannello quando un utente modifica
  // i dati presenti nel pannello
  // Column - Input
  // Field Modified - Input
  // Field Was Modified - Input
  // Row Was Modified - Input
  // Inserting - Input
  // Cancel - Input/Output
  // **********************************************************************
  private void PAN_IMPOSTAZIONI_OnUpdatingRow(IDVariant Column, IDVariant FieldModified, IDVariant FieldWasModified, IDVariant RowWasModified, IDVariant Inserting, IDVariant Cancel)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Impostazioni On Updating Row Body
      // Corpo Procedura
      // 
      // if (IMDB.Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_FLG_REFRESH, 0).equals((new IDVariant("S")), true))
      // {
        // PAN_IMPOSTAZIONI.SetFlags (Glb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, ((new IDVariant(0)).booleanValue())? Glb.OBJ_VISIBLE : 0, Glb.OBJ_VISIBLE); 
        // PAN_IMPOSTAZIONI.SetFlags (Glb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, ((new IDVariant(0)).booleanValue())? Glb.OBJ_VISIBLE : 0, Glb.OBJ_VISIBLE); 
      // }
      // else
      // {
        // PAN_IMPOSTAZIONI.SetFlags (Glb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, ((new IDVariant(-1)).booleanValue())? Glb.OBJ_VISIBLE : 0, Glb.OBJ_VISIBLE); 
        // PAN_IMPOSTAZIONI.SetFlags (Glb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, ((new IDVariant(-1)).booleanValue())? Glb.OBJ_VISIBLE : 0, Glb.OBJ_VISIBLE); 
      // }
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Configurazione", "ImpostazioniOnUpdatingRow", _e);
    }
  }

  // **********************************************************************
  // Impostazioni On Dynamic Properties
  // Consente l'aggiustamento delle proprietà visuali delle
  // singole celle del pannello.
  // **********************************************************************
  private void PAN_IMPOSTAZIONI_DynamicProperties ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Impostazioni On Dynamic Properties Body
      // Corpo Procedura
      // 
      if (IMDB.Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_FLG_REFRESH, 0).equals((new IDVariant("S")), true))
      {
        PAN_IMPOSTAZIONI.SetFlags (Glb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, ((new IDVariant(0)).booleanValue())? Glb.OBJ_VISIBLE : 0, Glb.OBJ_VISIBLE); 
        PAN_IMPOSTAZIONI.SetFlags (Glb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, ((new IDVariant(0)).booleanValue())? Glb.OBJ_VISIBLE : 0, Glb.OBJ_VISIBLE); 
      }
      else
      {
        PAN_IMPOSTAZIONI.SetFlags (Glb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, ((new IDVariant(-1)).booleanValue())? Glb.OBJ_VISIBLE : 0, Glb.OBJ_VISIBLE); 
        PAN_IMPOSTAZIONI.SetFlags (Glb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, ((new IDVariant(-1)).booleanValue())? Glb.OBJ_VISIBLE : 0, Glb.OBJ_VISIBLE); 
      }
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Configurazione", "ImpostazioniOnDynamicProperties", _e);
    }
  }

  // **********************************************************************
  // Bottone Invia Notifiche
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int BottoneInviaNotifiche ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Bottone Invia Notifiche Body
      // Corpo Procedura
      // 
      MainFrm.SendAPNSPushNotification();
      MainFrm.SendGCMNotification((new IDVariant()));
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Configurazione", "BottoneInviaNotifiche", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Bottone Check feedback
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int BottoneCheckfeedback ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Bottone Check feedback Body
      // Corpo Procedura
      // 
      MainFrm.CheckFeedbackService();
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Configurazione", "BottoneCheckfeedback", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Ripulisci Spedizioni Inviate
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int RipulisciSpedizioniInviate ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Ripulisci Spedizioni Inviate Body
      // Corpo Procedura
      // 
      SQL = new StringBuilder();
      SQL.Append("delete from SPEDIZIONI ");
      SQL.Append("where (FLG_STATO = 'S') ");
      MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Configurazione", "RipulisciSpedizioniInviate", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Elimina Token Rimossi
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int EliminaTokenRimossi ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Elimina Token Rimossi Body
      // Corpo Procedura
      // 
      SQL = new StringBuilder();
      SQL.Append("delete from DEV_TOKENS ");
      SQL.Append("where (FLG_RIMOSSO = 'S') ");
      MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Configurazione", "EliminaTokenRimossi", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Ripulisci Spedizioni
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int RipulisciSpedizioni ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Ripulisci Spedizioni Body
      // Corpo Procedura
      // 
      SQL = new StringBuilder();
      SQL.Append("delete from SPEDIZIONI ");
      MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Configurazione", "RipulisciSpedizioni", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Restart Applicazione
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int RestartApplicazione ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Restart Applicazione Body
      // Corpo Procedura
      // 
      try
      {
          // *** This requires full trust so this will fail
          // *** in many scenarios
          System.Web.HttpRuntime.UnloadAppDomain();
       }
      catch
       {
          string ConfigPath = System.Web.HttpContext.Current.Request.PhysicalApplicationPath + "\\web.config";
          System.IO.File.SetLastWriteTimeUtc(ConfigPath, DateTime.UtcNow);
       }
       
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Configurazione", "RestartApplicazione", _e);
      return -1;
    }
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
  private void PAN_IMPOSTAZIONI_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
    if (ColIndex.intValue() == PFL_IMPOSTAZIONI_BOTTINVINOTI)
    {
      this.IdxPanelActived = this.PAN_IMPOSTAZIONI.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      BottoneInviaNotifiche();
      Cancel.set(IDVariant.TRUE);
    }
    if (ColIndex.intValue() == PFL_IMPOSTAZIONI_BOTRIPSPEINV)
    {
      this.IdxPanelActived = this.PAN_IMPOSTAZIONI.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      RipulisciSpedizioniInviate();
      Cancel.set(IDVariant.TRUE);
    }
    if (ColIndex.intValue() == PFL_IMPOSTAZIONI_BOTTRIPUSPED)
    {
      this.IdxPanelActived = this.PAN_IMPOSTAZIONI.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      RipulisciSpedizioni();
      Cancel.set(IDVariant.TRUE);
    }
    if (ColIndex.intValue() == PFL_IMPOSTAZIONI_BOTTCHECFEED)
    {
      this.IdxPanelActived = this.PAN_IMPOSTAZIONI.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      BottoneCheckfeedback();
      Cancel.set(IDVariant.TRUE);
    }
    if (ColIndex.intValue() == PFL_IMPOSTAZIONI_BOTELMAITORI)
    {
      this.IdxPanelActived = this.PAN_IMPOSTAZIONI.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      EliminaTokenRimossi();
      Cancel.set(IDVariant.TRUE);
    }
    if (ColIndex.intValue() == PFL_IMPOSTAZIONI_RESTARAPPLIC)
    {
      this.IdxPanelActived = this.PAN_IMPOSTAZIONI.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      RestartApplicazione();
      Cancel.set(IDVariant.TRUE);
    }
  }

  private void PAN_IMPOSTAZIONI_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
      PAN_IMPOSTAZIONI_OnUpdatingRow(ColIndex, CellModified, FldWasModified, RowWasModified, IsInsert, Cancel);
    }
    catch(Exception e) {}
  }

  private void PAN_IMPOSTAZIONI_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_FLG_REFRESH, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_FLG_REFRESH, 0, (new IDVariant("N")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_MAX_DAYS_RET, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_MAX_DAYS_RET, 0, (new IDVariant(4)));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_FLG_DEBUG, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_FLG_DEBUG, 0, (new IDVariant(0)));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_FLG_CHECK, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_FLG_CHECK, 0, (new IDVariant("N")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_MAX_MESSAGGI, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_MAX_MESSAGGI, 0, (new IDVariant(200)));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_NUM_TIMEOUT, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_NUM_TIMEOUT, 0, (new IDVariant(1)));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_FLG_DEL_REMOVED_TK, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_FLG_DEL_REMOVED_TK, 0, (new IDVariant("S")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_MAX_MESSAGGI_C2DM, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_IMPOSTAZIONI, IMDBDef1.PQSL_IMPOSTAZIONI_MAX_MESSAGGI_C2DM, 0, (new IDVariant(200)));
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_IMPOSTAZIONI_Init()
  {

    PAN_IMPOSTAZIONI.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_IMPOSTAZIONI.SetSize(MyGlb.OBJ_GROUP, 3);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_GENERALE, "797B8E46-E368-4B80-A3FE-F6A2B4119E54");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_GENERALE, "Generale");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_GENERALE, "");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_GENERALE, MyGlb.VIS_DEFAPANESTYL);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_GENERALE, MyGlb.PANEL_LIST, 0, -9999, 432, 16, 0, 0);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_GENERALE, MyGlb.PANEL_FORM, 8, 32, 648, 188, 0, 0);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_GENERALE, 0, 51);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_GENERALE, 1, 13);
    PAN_IMPOSTAZIONI.SetHeaderPos(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_GENERALE, 0, 4);
    PAN_IMPOSTAZIONI.SetHeaderPos(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_GENERALE, 1, 3);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_GENERALE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_APPLEIOS, "6D9CD0BF-061F-46C0-97B4-93CF15A60592");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_APPLEIOS, "Apple iOS");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_APPLEIOS, "");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_APPLEIOS, MyGlb.VIS_DEFAPANESTYL);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_APPLEIOS, MyGlb.PANEL_LIST, 0, -9999, 432, 16, 0, 0);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_APPLEIOS, MyGlb.PANEL_FORM, 8, 252, 652, 152, 0, 0);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_APPLEIOS, 0, 53);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_APPLEIOS, 1, 13);
    PAN_IMPOSTAZIONI.SetHeaderPos(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_APPLEIOS, 0, 4);
    PAN_IMPOSTAZIONI.SetHeaderPos(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_APPLEIOS, 1, 3);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_APPLEIOS, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_ANDROID, "BCCEBFA1-07FE-43F2-BD4F-3D64C3B0BA9E");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_ANDROID, "Android");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_ANDROID, "");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_ANDROID, MyGlb.VIS_DEFAPANESTYL);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_ANDROID, MyGlb.PANEL_LIST, 0, 0, 0, 0, 0, 0);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_ANDROID, MyGlb.PANEL_FORM, 0, 0, 0, 0, 0, 0);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_ANDROID, 0, 44);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_ANDROID, 1, 13);
    PAN_IMPOSTAZIONI.SetHeaderPos(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_ANDROID, 0, 4);
    PAN_IMPOSTAZIONI.SetHeaderPos(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_ANDROID, 1, 3);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_GROUP, GRP_IMPOSTAZIONI_ANDROID, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE, -1);
    PAN_IMPOSTAZIONI.SetSize(MyGlb.OBJ_FIELD, 19);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, "34E7468A-67A9-475C-999E-3EA95B3A9DEB");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, "ID");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, "Identificativo univoco");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, 0 | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, "9A70C051-BF49-488D-943E-4BBF6C0CABBF");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, "Url Di Base Applicativo");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, "");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, MyGlb.VIS_NORMALFIELDS);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, "6ECBC05F-AC85-4FC1-97E8-3752FA2009C7");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, "Invio Report Estrazioni");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, "Indirizzo di posta a cui inviare le estrazioni");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, MyGlb.VIS_NORMALFIELDS);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, "DEF66869-BF5B-4C34-B2FC-9781950BF0EB");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, "Web Service Reference");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, "");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, MyGlb.VIS_NORMALFIELDS);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, "4AAAC428-BAFB-4DE9-A5E9-AB559026C41C");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, "Attiva Autorefresh dei dati (ogni 4 sec.)");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, "");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, MyGlb.VIS_NORMALFIELDS);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISOPT, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, "07E7D7E4-5CDD-46A6-837E-6D5D386829B2");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, "Giorni di retention per la coda messaggi");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, "Per quanti giorni vuoi tenere la coda di spedfizioni ?");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, MyGlb.VIS_NORMALFIELDS);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, "69AC7547-B146-421E-BF23-E6B2CF08C60F");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, "Invio manuale notifiche in coda");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, MyGlb.VIS_COMMANBUTTO1);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_NOACTD | MyGlb.FLD_CANACTIVATE, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTRIPSPEINV, "9342A8EB-B81B-408F-9BBE-4B043A789CEC");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTRIPSPEINV, "Ripulisci spedizioni inviate");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTRIPSPEINV, MyGlb.VIS_COMMANBUTTO1);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTRIPSPEINV, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_NOACTD | MyGlb.FLD_CANACTIVATE, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTRIPUSPED, "FFFD2910-67AD-4D17-8C36-1F0C1F876FB4");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTRIPUSPED, "Ripulisci spedizioni (tutti i dati)");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTRIPUSPED, MyGlb.VIS_COMMANBUTTO1);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTRIPUSPED, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_NOACTD | MyGlb.FLD_CANACTIVATE, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, "D57025C1-17EC-4EAD-A0E6-B0F8C39B2B53");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, "Imposta il livello di Trace (vedi tabella log)");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, "");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, MyGlb.VIS_NORMALFIELDS);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, "F249801F-C070-44BA-B080-5F63BFEAB378");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, "Percorso Certificati notifiche push");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, "Percorso in cui sono messi i certificati");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, MyGlb.VIS_NORMALFIELDS);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, "F46B4801-EB36-49ED-95FE-BD90C01FDEB1");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, "Attiva Autocheck Feedback (ogni 60 min.)");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, "");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, MyGlb.VIS_NORMALFIELDS);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISOPT, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, "AFC3B42B-D7C9-4E70-A4FE-3266A9E3CB31");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, "Numero massimo di messaggi per spedizione");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, "Numero massimo di messaggi per spedizione singola");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, MyGlb.VIS_NORMALFIELDS);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, "1A3B0AF6-D6AF-423A-BD71-F7E29359D88D");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, "Check manuale Feedback");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, MyGlb.VIS_COMMANBUTTO1);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_NOACTD | MyGlb.FLD_CANACTIVATE, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTELMAITORI, "06997948-2F68-40FD-A2E3-E7257CFEB3D6");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTELMAITORI, "Elimina manualmente i token rimossi");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTELMAITORI, MyGlb.VIS_COMMANBUTTO1);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTELMAITORI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_NOACTD | MyGlb.FLD_CANACTIVATE, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RESTARAPPLIC, "AAABCC3B-ABA0-40DD-97D5-F7CA6ACAD74A");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RESTARAPPLIC, "Restart Applicazione");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RESTARAPPLIC, MyGlb.VIS_COMMANBUTTO1);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RESTARAPPLIC, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_NOACTD | MyGlb.FLD_CANACTIVATE, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, "9BCA7537-2962-4DC4-9274-400210B00948");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, "Ritardo fra le spedizioni (in sec.)");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, "Ritardo in secondi fra una spedizione e l'altra");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, MyGlb.VIS_NORMALFIELDS);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, "168DAB52-D64B-45B7-8C10-A9099CE8D4B3");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, "Elimina definitivamente Token Rimossi");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, "");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, MyGlb.VIS_NORMALFIELDS);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_IMPOSTAZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, "A03F54BE-4FA5-46F6-9246-B4ACFC4DBC90");
    PAN_IMPOSTAZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, "Max Messaggi Messaggi per spedizione");
    PAN_IMPOSTAZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, "");
    PAN_IMPOSTAZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, MyGlb.VIS_NORMALFIELDS);
    PAN_IMPOSTAZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, 0 | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_IMPOSTAZIONI_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, MyGlb.PANEL_LIST, 0, 36, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, MyGlb.PANEL_LIST, 20);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, MyGlb.PANEL_LIST, "ID");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, MyGlb.PANEL_FORM, 4, 4, 172, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, MyGlb.PANEL_FORM, 112);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ID, MyGlb.PANEL_FORM, "ID");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_ID, -1, -1);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_ID, PPQRY_IMPOSTAZIONI, "A.ID", "ID", 1, 9, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, MyGlb.PANEL_LIST, 0, 36, 432, 44, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, MyGlb.PANEL_LIST, 116);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, MyGlb.PANEL_LIST, 2);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, MyGlb.PANEL_LIST, "Url Di Base Applicativo");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, MyGlb.PANEL_FORM, 12, 36, 628, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, MyGlb.PANEL_FORM, 232);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_URLDIBASEAPP, MyGlb.PANEL_FORM, "Url Di Base Applicativo");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_URLDIBASEAPP, -1, GRP_IMPOSTAZIONI_GENERALE);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_URLDIBASEAPP, PPQRY_IMPOSTAZIONI, "A.URL_APP", "URL_APP", 5, 1000, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, MyGlb.PANEL_LIST, 0, 36, 432, 44, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, MyGlb.PANEL_LIST, 120);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, MyGlb.PANEL_LIST, 2);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, MyGlb.PANEL_LIST, "Invio Report Estrazioni");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, MyGlb.PANEL_FORM, 12, 60, 628, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, MyGlb.PANEL_FORM, 232);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_INVIREPOESTR, MyGlb.PANEL_FORM, "Invio Report Estrazioni");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_INVIREPOESTR, -1, GRP_IMPOSTAZIONI_GENERALE);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_INVIREPOESTR, PPQRY_IMPOSTAZIONI, "A.ADMIN_MAIL", "ADMIN_MAIL", 5, 500, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, MyGlb.PANEL_LIST, 0, 36, 432, 44, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, MyGlb.PANEL_LIST, 124);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, MyGlb.PANEL_LIST, 2);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, MyGlb.PANEL_LIST, "Web Service Reference");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, MyGlb.PANEL_FORM, 12, 84, 628, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, MyGlb.PANEL_FORM, 232);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_WEBSERVIREFE, MyGlb.PANEL_FORM, "Web Service Reference");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_WEBSERVIREFE, -1, GRP_IMPOSTAZIONI_GENERALE);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_WEBSERVIREFE, PPQRY_IMPOSTAZIONI, "A.WS_URL", "WS_URL", 5, 1000, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, MyGlb.PANEL_LIST, 40, 36, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, MyGlb.PANEL_LIST, 100);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, MyGlb.PANEL_LIST, "A. A. d. d. o. 4 s.");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, MyGlb.PANEL_FORM, 12, 120, 328, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, MyGlb.PANEL_FORM, 232);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUDEDAOG4S, MyGlb.PANEL_FORM, "Attiva Autorefresh dei dati (ogni 4 sec.)");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_ATAUDEDAOG4S, -1, GRP_IMPOSTAZIONI_GENERALE);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_ATAUDEDAOG4S, PPQRY_IMPOSTAZIONI, "A.FLG_REFRESH", "FLG_REFRESH", 5, 1, 0, -685);
    PAN_IMPOSTAZIONI.SetValueListItem(PFL_IMPOSTAZIONI_ATAUDEDAOG4S, (new IDVariant("N")), "No", "", "", -1);
    PAN_IMPOSTAZIONI.SetValueListItem(PFL_IMPOSTAZIONI_ATAUDEDAOG4S, (new IDVariant("S")), "Si", "", "", -1);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, MyGlb.PANEL_LIST, 0, 36, 88, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, MyGlb.PANEL_LIST, 88);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, MyGlb.PANEL_LIST, "G. d. r. p. l. c. m.");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, MyGlb.PANEL_FORM, 12, 152, 328, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, MyGlb.PANEL_FORM, 232);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_GIDIREPELACM, MyGlb.PANEL_FORM, "Giorni di retention per la coda messaggi");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_GIDIREPELACM, -1, GRP_IMPOSTAZIONI_GENERALE);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_GIDIREPELACM, PPQRY_IMPOSTAZIONI, "A.MAX_DAYS_RET", "MAX_DAYS_RET", 1, 5, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, MyGlb.PANEL_LIST, 376, 8, 120, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, MyGlb.PANEL_LIST, 0);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, MyGlb.PANEL_FORM, 460, 116, 192, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, MyGlb.PANEL_FORM, 0);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTINVINOTI, MyGlb.PANEL_FORM, 2);
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_BOTTINVINOTI, -1, GRP_IMPOSTAZIONI_GENERALE);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_BOTTINVINOTI, -1, "", "BOTTINVINOTI", 0, 0, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTRIPSPEINV, MyGlb.PANEL_LIST, 392, 24, 120, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTRIPSPEINV, MyGlb.PANEL_LIST, 0);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTRIPSPEINV, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTRIPSPEINV, MyGlb.PANEL_FORM, 460, 152, 192, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTRIPSPEINV, MyGlb.PANEL_FORM, 0);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTRIPSPEINV, MyGlb.PANEL_FORM, 2);
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_BOTRIPSPEINV, -1, GRP_IMPOSTAZIONI_GENERALE);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_BOTRIPSPEINV, -1, "", "BOTRIPSPEINV", 0, 0, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTRIPUSPED, MyGlb.PANEL_LIST, 400, 32, 120, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTRIPUSPED, MyGlb.PANEL_LIST, 0);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTRIPUSPED, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTRIPUSPED, MyGlb.PANEL_FORM, 460, 188, 192, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTRIPUSPED, MyGlb.PANEL_FORM, 0);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTRIPUSPED, MyGlb.PANEL_FORM, 2);
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_BOTTRIPUSPED, -1, GRP_IMPOSTAZIONI_GENERALE);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_BOTTRIPUSPED, -1, "", "BOTTRIPUSPED", 0, 0, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, MyGlb.PANEL_LIST, 0, 36, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, MyGlb.PANEL_LIST, 40);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, MyGlb.PANEL_LIST, "I. i. l. d. T. v. t. l.");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, MyGlb.PANEL_FORM, 12, 180, 328, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, MyGlb.PANEL_FORM, 232);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_IMILLIDITVTL, MyGlb.PANEL_FORM, "Imposta il livello di Trace (vedi tabella log)");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_IMILLIDITVTL, -1, GRP_IMPOSTAZIONI_GENERALE);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_IMILLIDITVTL, PPQRY_IMPOSTAZIONI, "A.FLG_DEBUG", "FLG_DEBUG", 1, 2, 0, -685);
    PAN_IMPOSTAZIONI.SetValueListItem(PFL_IMPOSTAZIONI_IMILLIDITVTL, (new IDVariant(0)), "Spento", "", "", -1);
    PAN_IMPOSTAZIONI.SetValueListItem(PFL_IMPOSTAZIONI_IMILLIDITVTL, (new IDVariant(1)), "Acceso", "", "", -1);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, MyGlb.PANEL_LIST, 0, 36, 432, 44, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, MyGlb.PANEL_LIST, 100);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, MyGlb.PANEL_LIST, 2);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, MyGlb.PANEL_LIST, "Percorso Certificati notifiche push");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, MyGlb.PANEL_FORM, 12, 256, 628, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, MyGlb.PANEL_FORM, 232);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_PERCERNOTPUS, MyGlb.PANEL_FORM, "Percorso Certificati notifiche push");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_PERCERNOTPUS, -1, GRP_IMPOSTAZIONI_APPLEIOS);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_PERCERNOTPUS, PPQRY_IMPOSTAZIONI, "A.PATH_CERTS", "PATH_CERTS", 5, 1000, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, MyGlb.PANEL_LIST, 0, 36, 140, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, MyGlb.PANEL_LIST, 140);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, MyGlb.PANEL_LIST, "Att. Aut. Feed. ogn. 60 min");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, MyGlb.PANEL_FORM, 12, 288, 328, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, MyGlb.PANEL_FORM, 232);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ATAUFEOG60MI, MyGlb.PANEL_FORM, "Attiva Autocheck Feedback (ogni 60 min.)");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_ATAUFEOG60MI, -1, GRP_IMPOSTAZIONI_APPLEIOS);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_ATAUFEOG60MI, PPQRY_IMPOSTAZIONI, "A.FLG_CHECK", "FLG_CHECK", 5, 1, 0, -685);
    PAN_IMPOSTAZIONI.SetValueListItem(PFL_IMPOSTAZIONI_ATAUFEOG60MI, (new IDVariant("N")), "No", "", "", -1);
    PAN_IMPOSTAZIONI.SetValueListItem(PFL_IMPOSTAZIONI_ATAUFEOG60MI, (new IDVariant("S")), "Si", "", "", -1);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, MyGlb.PANEL_LIST, 0, 36, 76, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, MyGlb.PANEL_LIST, 76);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, MyGlb.PANEL_LIST, "N. m. d. m. p. s.");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, MyGlb.PANEL_FORM, 12, 344, 328, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, MyGlb.PANEL_FORM, 232);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_NUMADIMEPESP, MyGlb.PANEL_FORM, "Numero massimo di messaggi per spedizione");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_NUMADIMEPESP, -1, GRP_IMPOSTAZIONI_APPLEIOS);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_NUMADIMEPESP, PPQRY_IMPOSTAZIONI, "A.MAX_MESSAGGI", "MAX_MESSAGGI", 1, 5, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, MyGlb.PANEL_LIST, 384, 16, 120, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, MyGlb.PANEL_LIST, 0);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, MyGlb.PANEL_FORM, 464, 284, 192, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, MyGlb.PANEL_FORM, 0);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTTCHECFEED, MyGlb.PANEL_FORM, 2);
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_BOTTCHECFEED, -1, GRP_IMPOSTAZIONI_APPLEIOS);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_BOTTCHECFEED, -1, "", "BOTTCHECFEED", 0, 0, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTELMAITORI, MyGlb.PANEL_LIST, 400, 32, 120, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTELMAITORI, MyGlb.PANEL_LIST, 0);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTELMAITORI, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTELMAITORI, MyGlb.PANEL_FORM, 464, 316, 192, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTELMAITORI, MyGlb.PANEL_FORM, 0);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_BOTELMAITORI, MyGlb.PANEL_FORM, 2);
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_BOTELMAITORI, -1, GRP_IMPOSTAZIONI_APPLEIOS);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_BOTELMAITORI, -1, "", "BOTELMAITORI", 0, 0, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RESTARAPPLIC, MyGlb.PANEL_LIST, 408, 40, 120, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RESTARAPPLIC, MyGlb.PANEL_LIST, 0);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RESTARAPPLIC, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RESTARAPPLIC, MyGlb.PANEL_FORM, 464, 372, 192, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RESTARAPPLIC, MyGlb.PANEL_FORM, 0);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RESTARAPPLIC, MyGlb.PANEL_FORM, 2);
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_RESTARAPPLIC, -1, GRP_IMPOSTAZIONI_APPLEIOS);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_RESTARAPPLIC, -1, "", "RESTARAPPLIC", 0, 0, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, MyGlb.PANEL_LIST, 0, 36, 100, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, MyGlb.PANEL_LIST, 100);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, MyGlb.PANEL_LIST, "Ritardo fra le spedizioni (in sec.)");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, MyGlb.PANEL_FORM, 12, 376, 328, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, MyGlb.PANEL_FORM, 232);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_RIFRLESPINSE, MyGlb.PANEL_FORM, "Ritardo fra le spedizioni (in sec.)");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_RIFRLESPINSE, -1, -1);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_RIFRLESPINSE, PPQRY_IMPOSTAZIONI, "A.NUM_TIMEOUT", "NUM_TIMEOUT", 1, 8, 0, -685);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, MyGlb.PANEL_LIST, 0, 36, 112, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, MyGlb.PANEL_LIST, 112);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, MyGlb.PANEL_LIST, "Elim. definitivamente Token Rimossi");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, MyGlb.PANEL_FORM, 12, 316, 328, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, MyGlb.PANEL_FORM, 232);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_ELIDEFTOKRIM, MyGlb.PANEL_FORM, "Elimina definitivamente Token Rimossi");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_ELIDEFTOKRIM, -1, -1);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_ELIDEFTOKRIM, PPQRY_IMPOSTAZIONI, "A.FLG_DEL_REMOVED_TK", "FLG_DEL_REMOVED_TK", 5, 1, 0, -685);
    PAN_IMPOSTAZIONI.SetValueListItem(PFL_IMPOSTAZIONI_ELIDEFTOKRIM, (new IDVariant("S")), "Si", "", "", -1);
    PAN_IMPOSTAZIONI.SetValueListItem(PFL_IMPOSTAZIONI_ELIDEFTOKRIM, (new IDVariant("N")), "No", "", "", -1);
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, MyGlb.PANEL_LIST, 0, 36, 108, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, MyGlb.PANEL_LIST, 108);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, MyGlb.PANEL_LIST, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, MyGlb.PANEL_LIST, "Max Mess. Messaggi per spedizione");
    PAN_IMPOSTAZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, MyGlb.PANEL_FORM, 16, 500, 316, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_IMPOSTAZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, MyGlb.PANEL_FORM, 248);
    PAN_IMPOSTAZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, MyGlb.PANEL_FORM, 1);
    PAN_IMPOSTAZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_IMPOSTAZIONI_MAXMESMEPESP, MyGlb.PANEL_FORM, "Max Messaggi Messaggi per spedizione");
    PAN_IMPOSTAZIONI.SetFieldPage(PFL_IMPOSTAZIONI_MAXMESMEPESP, -1, GRP_IMPOSTAZIONI_ANDROID);
    PAN_IMPOSTAZIONI.SetFieldPanel(PFL_IMPOSTAZIONI_MAXMESMEPESP, PPQRY_IMPOSTAZIONI, "A.MAX_MESSAGGI_C2DM", "MAX_MESSAGGI_C2DM", 1, 5, 0, -685);
  }

  private void PAN_IMPOSTAZIONI_InitQueries()
  {
    StringBuilder SQL;

    PAN_IMPOSTAZIONI.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_IMPOSTAZIONI.SetIMDB(IMDB, "PQRY_IMPOSTAZIONI", true);
    PAN_IMPOSTAZIONI.set_SetString(MyGlb.MASTER_ROWNAME, "Impostazione");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.FLG_REFRESH as FLG_REFRESH, ");
    SQL.Append("  A.URL_APP as URL_APP, ");
    SQL.Append("  A.PATH_CERTS as PATH_CERTS, ");
    SQL.Append("  A.ADMIN_MAIL as ADMIN_MAIL, ");
    SQL.Append("  A.WS_URL as WS_URL, ");
    SQL.Append("  A.MAX_MESSAGGI as MAX_MESSAGGI, ");
    SQL.Append("  A.FLG_CHECK as FLG_CHECK, ");
    SQL.Append("  A.NUM_TIMEOUT as NUM_TIMEOUT, ");
    SQL.Append("  A.MAX_DAYS_RET as MAX_DAYS_RET, ");
    SQL.Append("  A.FLG_DEL_REMOVED_TK as FLG_DEL_REMOVED_TK, ");
    SQL.Append("  A.MAX_MESSAGGI_C2DM as MAX_MESSAGGI_C2DM, ");
    SQL.Append("  A.FLG_DEBUG as FLG_DEBUG ");
    PAN_IMPOSTAZIONI.SetQuery(PPQRY_IMPOSTAZIONI, 0, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  IMPOSTAZIONI A ");
    PAN_IMPOSTAZIONI.SetQuery(PPQRY_IMPOSTAZIONI, 1, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_IMPOSTAZIONI.SetQuery(PPQRY_IMPOSTAZIONI, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_IMPOSTAZIONI.SetQuery(PPQRY_IMPOSTAZIONI, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_IMPOSTAZIONI.SetQuery(PPQRY_IMPOSTAZIONI, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_IMPOSTAZIONI.SetQuery(PPQRY_IMPOSTAZIONI, 5, SQL, -1, "");
    PAN_IMPOSTAZIONI.SetQueryDB(PPQRY_IMPOSTAZIONI, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_IMPOSTAZIONI.SetMasterTable(0, "IMPOSTAZIONI");
    SQL = new StringBuilder("");
    PAN_IMPOSTAZIONI.SetQuery(0, -1, SQL, PFL_IMPOSTAZIONI_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_IMPOSTAZIONI) PAN_IMPOSTAZIONI_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_IMPOSTAZIONI) PAN_IMPOSTAZIONI_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
    if (SrcObj == PAN_IMPOSTAZIONI) PAN_IMPOSTAZIONI_DynamicProperties();
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_IMPOSTAZIONI) PAN_IMPOSTAZIONI_CellActivated(ColIndex, Cancel);
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
