// **********************************************
// Logs
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
public partial class Logs : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_LOGS_ID = 0;
  private const int PFL_LOGS_DATA = 1;
  private const int PFL_LOGS_TESTO = 2;
  private const int PFL_LOGS_LIVELLO = 3;
  private const int PFL_LOGS_TIPO = 4;

  private const int PPQRY_MESSAGGI = 0;


  internal IDPanel PAN_LOGS;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_MESSAGGI(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_MESSAGGI(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_MESSAGGI, 5);
    IMDB.set_TblCode(IMDBDef1.PQRY_MESSAGGI, "PQRY_MESSAGGI");
    IMDB.set_FldCode(IMDBDef1.PQRY_MESSAGGI,IMDBDef1.PQSL_MESSAGGI_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_MESSAGGI,IMDBDef1.PQSL_MESSAGGI_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_MESSAGGI,IMDBDef1.PQSL_MESSAGGI_FLG_LEV_DEBUG, "FLG_LEV_DEBUG");
    IMDB.SetFldParams(IMDBDef1.PQRY_MESSAGGI,IMDBDef1.PQSL_MESSAGGI_FLG_LEV_DEBUG,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_MESSAGGI,IMDBDef1.PQSL_MESSAGGI_TESTO, "TESTO");
    IMDB.SetFldParams(IMDBDef1.PQRY_MESSAGGI,IMDBDef1.PQSL_MESSAGGI_TESTO,9,10000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_MESSAGGI,IMDBDef1.PQSL_MESSAGGI_DATA_LOG, "DATA_LOG");
    IMDB.SetFldParams(IMDBDef1.PQRY_MESSAGGI,IMDBDef1.PQSL_MESSAGGI_DATA_LOG,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_MESSAGGI,IMDBDef1.PQSL_MESSAGGI_TIPO, "TIPO");
    IMDB.SetFldParams(IMDBDef1.PQRY_MESSAGGI,IMDBDef1.PQSL_MESSAGGI_TIPO,5,100,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_MESSAGGI, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public Logs(MyWebEntryPoint w, IMDBObj imdb)
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
  public Logs()
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
    FormIdx = MyGlb.FRM_LOGS;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "D98112EE-4901-4C82-8178-99BE1D295734";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 908;
    DesignHeight = 488;
    set_Caption(new IDVariant("Logs"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 908;
    Frames[1].Height = 428;
    Frames[1].Caption = "Logs";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 428;
    PAN_LOGS = new IDPanel(w, this, 1, "PAN_LOGS");
    Frames[1].Content = PAN_LOGS;
    PAN_LOGS.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_LOGS.VS = MainFrm.VisualStyleList;
    PAN_LOGS.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 908-MyGlb.PAN_OFFS_X, 428-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_LOGS.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "4D2C5D1F-C3D6-45BF-9471-45DAF85A88BA");
    PAN_LOGS.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 840, 372, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_LOGS.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_LOGS.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_LOGS.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANSELECT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_LOGS.InitStatus = 2;
    PAN_LOGS_Init();
    PAN_LOGS_InitFields();
    PAN_LOGS_InitQueries();
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
    if (CmdIdx==MyGlb.CMD_SVUOTALOG+BaseCmdLinIdx)
    {
      Svuotalog();
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_LOGSPEDIZION+BaseCmdLinIdx)
    {
      EtichettaAprilogspedizioni();
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_LOGFEEDBACK+BaseCmdLinIdx)
    {
      EtichettaAprilogfeedback();
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_SVUOLOGSFILE+BaseCmdLinIdx)
    {
      EliminaLOGFilesystem();
      goto fine;
    }
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
      PAN_LOGS.UpdatePanel(MainFrm);
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
    return (obj is Logs);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(Logs).FullName : typeof(Logs).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Svuota log
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int Svuotalog ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Svuota log Body
      // Corpo Procedura
      // 
      SQL = new StringBuilder();
      SQL.Append("delete from LOGS ");
      MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
      PAN_LOGS.PanelCommand(Glb.PCM_REQUERY);
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Logs", "Svuotalog", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Etichetta Apri log spedizioni
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int EtichettaAprilogspedizioni ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Etichetta Apri log spedizioni Body
      // Corpo Procedura
      // 
      MainFrm.set_RedirectTo((new IDVariant("temp\\NotificationLOG.txt")));
      MainFrm.set_RedirectNewWindow((new IDVariant(-1)).booleanValue());
      MainFrm.set_RedirectFeatures((new IDVariant(""))); 
      PAN_LOGS.PanelCommand(Glb.PCM_REQUERY);
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Logs", "EtichettaAprilogspedizioni", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Etichetta Apri log feedback
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int EtichettaAprilogfeedback ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Etichetta Apri log feedback Body
      // Corpo Procedura
      // 
      MainFrm.set_RedirectTo((new IDVariant("temp\\FeedbackLOG.txt")));
      MainFrm.set_RedirectNewWindow((new IDVariant(-1)).booleanValue());
      MainFrm.set_RedirectFeatures((new IDVariant(""))); 
      PAN_LOGS.PanelCommand(Glb.PCM_REQUERY);
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Logs", "EtichettaAprilogfeedback", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Elimina LOG Filesystem
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int EliminaLOGFilesystem ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Elimina LOG Filesystem Body
      // Corpo Procedura
      // 
      VBFiles.Kill(IDL.Add(IDL.Add((new IDVariant(MainFrm.RealPath)), (new IDVariant("\\temp\\"))), (new IDVariant("NotificationLOG.txt")))); 
      VBFiles.Kill(IDL.Add(IDL.Add((new IDVariant(MainFrm.RealPath)), (new IDVariant("\\temp\\"))), (new IDVariant("FeedbackLOG.txt")))); 
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Logs", "EliminaLOGFilesystem", _e);
      return -1;
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
      PAN_LOGS.SetFlags (Glb.OBJ_PANEL, 0, ((new IDVariant(0)).booleanValue())? Glb.PAN_CANSORT : 0, Glb.PAN_CANSORT); 
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Logs", "Load", _e);
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
  private void PAN_LOGS_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_LOGS_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_LOGS_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_MESSAGGI, IMDBDef1.PQSL_MESSAGGI_DATA_LOG, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_MESSAGGI, IMDBDef1.PQSL_MESSAGGI_DATA_LOG, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_MESSAGGI, IMDBDef1.PQSL_MESSAGGI_FLG_LEV_DEBUG, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_MESSAGGI, IMDBDef1.PQSL_MESSAGGI_FLG_LEV_DEBUG, 0, (new IDVariant(0)));
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_LOGS_Init()
  {

    PAN_LOGS.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_LOGS.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_LOGS.SetSize(MyGlb.OBJ_FIELD, 5);
    PAN_LOGS.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGS_ID, "74979646-7123-4418-86BF-FA94DA0EF5A8");
    PAN_LOGS.set_Header(MyGlb.OBJ_FIELD, PFL_LOGS_ID, "ID");
    PAN_LOGS.set_ToolTip(MyGlb.OBJ_FIELD, PFL_LOGS_ID, "Identificativo univoco");
    PAN_LOGS.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGS_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_LOGS.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGS_ID, 0 | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_LOGS.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, "C946960B-850E-438F-A630-ABDA9401053F");
    PAN_LOGS.set_Header(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, "Data");
    PAN_LOGS.set_ToolTip(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, "Data di inserimento del record");
    PAN_LOGS.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, MyGlb.VIS_NORMALFIELDS);
    PAN_LOGS.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_LOGS.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, "FE5119C3-49CB-44EC-8619-664D1CBB0F72");
    PAN_LOGS.set_Header(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, "Testo");
    PAN_LOGS.set_ToolTip(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, "Nome Squadra");
    PAN_LOGS.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, MyGlb.VIS_NORMALFIELDS);
    PAN_LOGS.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISDESCR, -1);
    PAN_LOGS.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, "452535F0-DDFF-4DF6-903A-DCDE3065EC4B");
    PAN_LOGS.set_Header(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, "Livello");
    PAN_LOGS.set_ToolTip(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, "");
    PAN_LOGS.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, MyGlb.VIS_NORMALFIELDS);
    PAN_LOGS.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_LOGS.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, "7F8A8E23-4079-41A1-AE0D-93483934BC64");
    PAN_LOGS.set_Header(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, "Tipo");
    PAN_LOGS.set_ToolTip(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, "Tipo messaggio");
    PAN_LOGS.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, MyGlb.VIS_NORMALFIELDS);
    PAN_LOGS.SetFlags(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISDESCR, -1);
  }

  private void PAN_LOGS_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_LOGS.SetRect(MyGlb.OBJ_FIELD, PFL_LOGS_ID, MyGlb.PANEL_LIST, 232, 32, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGS.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGS_ID, MyGlb.PANEL_LIST, 20);
    PAN_LOGS.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGS_ID, MyGlb.PANEL_LIST, 1);
    PAN_LOGS.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGS_ID, MyGlb.PANEL_LIST, "ID");
    PAN_LOGS.SetRect(MyGlb.OBJ_FIELD, PFL_LOGS_ID, MyGlb.PANEL_FORM, 4, 4, 96, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGS.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGS_ID, MyGlb.PANEL_FORM, 48);
    PAN_LOGS.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGS_ID, MyGlb.PANEL_FORM, 1);
    PAN_LOGS.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGS_ID, MyGlb.PANEL_FORM, "ID");
    PAN_LOGS.SetFieldPage(PFL_LOGS_ID, -1, -1);
    PAN_LOGS.SetFieldPanel(PFL_LOGS_ID, PPQRY_MESSAGGI, "A.ID", "ID", 1, 9, 0, -1709);
    PAN_LOGS.SetRect(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, MyGlb.PANEL_LIST, 0, 32, 104, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGS.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, MyGlb.PANEL_LIST, 64);
    PAN_LOGS.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, MyGlb.PANEL_LIST, 1);
    PAN_LOGS.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, MyGlb.PANEL_LIST, "Data");
    PAN_LOGS.SetRect(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, MyGlb.PANEL_FORM, 4, 52, 368, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGS.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, MyGlb.PANEL_FORM, 48);
    PAN_LOGS.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, MyGlb.PANEL_FORM, 1);
    PAN_LOGS.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGS_DATA, MyGlb.PANEL_FORM, "Data");
    PAN_LOGS.SetFieldPage(PFL_LOGS_DATA, -1, -1);
    PAN_LOGS.SetFieldPanel(PFL_LOGS_DATA, PPQRY_MESSAGGI, "A.DATA_LOG", "DATA_LOG", 8, 61, 0, -1709);
    PAN_LOGS.SetRect(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, MyGlb.PANEL_LIST, 104, 32, 496, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_LOGS.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, MyGlb.PANEL_LIST, 64);
    PAN_LOGS.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, MyGlb.PANEL_LIST, 1);
    PAN_LOGS.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, MyGlb.PANEL_LIST, "Testo");
    PAN_LOGS.SetRect(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, MyGlb.PANEL_FORM, 4, 28, 448, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGS.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, MyGlb.PANEL_FORM, 48);
    PAN_LOGS.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, MyGlb.PANEL_FORM, 2);
    PAN_LOGS.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGS_TESTO, MyGlb.PANEL_FORM, "Testo");
    PAN_LOGS.SetFieldPage(PFL_LOGS_TESTO, -1, -1);
    PAN_LOGS.SetFieldPanel(PFL_LOGS_TESTO, PPQRY_MESSAGGI, "A.TESTO", "TESTO", 9, 10000, 0, -1709);
    PAN_LOGS.SetRect(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, MyGlb.PANEL_LIST, 600, 32, 120, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGS.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, MyGlb.PANEL_LIST, 40);
    PAN_LOGS.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, MyGlb.PANEL_LIST, 1);
    PAN_LOGS.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, MyGlb.PANEL_LIST, "Livello");
    PAN_LOGS.SetRect(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, MyGlb.PANEL_FORM, 4, 76, 100, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGS.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, MyGlb.PANEL_FORM, 40);
    PAN_LOGS.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, MyGlb.PANEL_FORM, 1);
    PAN_LOGS.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGS_LIVELLO, MyGlb.PANEL_FORM, "Liv.");
    PAN_LOGS.SetFieldPage(PFL_LOGS_LIVELLO, -1, -1);
    PAN_LOGS.SetFieldPanel(PFL_LOGS_LIVELLO, PPQRY_MESSAGGI, "A.FLG_LEV_DEBUG", "FLG_LEV_DEBUG", 1, 9, 0, -1709);
    PAN_LOGS.SetValueListItem(PFL_LOGS_LIVELLO, (new IDVariant(0)), "Spento", "", "", -1);
    PAN_LOGS.SetValueListItem(PFL_LOGS_LIVELLO, (new IDVariant(1)), "Livello 1 - Errori", "", "", -1);
    PAN_LOGS.SetValueListItem(PFL_LOGS_LIVELLO, (new IDVariant(2)), "Livello 2 - Trace", "", "", -1);
    PAN_LOGS.SetRect(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, MyGlb.PANEL_LIST, 720, 32, 120, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_LOGS.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, MyGlb.PANEL_LIST, 12);
    PAN_LOGS.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, MyGlb.PANEL_LIST, 1);
    PAN_LOGS.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, MyGlb.PANEL_LIST, "Tipo");
    PAN_LOGS.SetRect(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, MyGlb.PANEL_FORM, 4, 100, 540, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_LOGS.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, MyGlb.PANEL_FORM, 28);
    PAN_LOGS.SetNumRow(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, MyGlb.PANEL_FORM, 1);
    PAN_LOGS.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_LOGS_TIPO, MyGlb.PANEL_FORM, "Tp.");
    PAN_LOGS.SetFieldPage(PFL_LOGS_TIPO, -1, -1);
    PAN_LOGS.SetFieldPanel(PFL_LOGS_TIPO, PPQRY_MESSAGGI, "A.TIPO", "TIPO", 5, 100, 0, -1709);
  }

  private void PAN_LOGS_InitQueries()
  {
    StringBuilder SQL;

    PAN_LOGS.SetSize(MyGlb.OBJ_QUERY, 1);
    PAN_LOGS.SetIMDB(IMDB, "PQRY_MESSAGGI", true);
    PAN_LOGS.set_SetString(MyGlb.MASTER_ROWNAME, "Messaggio");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.FLG_LEV_DEBUG as FLG_LEV_DEBUG, ");
    SQL.Append("  A.TESTO as TESTO, ");
    SQL.Append("  A.DATA_LOG as DATA_LOG, ");
    SQL.Append("  A.TIPO as TIPO ");
    PAN_LOGS.SetQuery(PPQRY_MESSAGGI, 0, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  LOGS A ");
    PAN_LOGS.SetQuery(PPQRY_MESSAGGI, 1, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_LOGS.SetQuery(PPQRY_MESSAGGI, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_LOGS.SetQuery(PPQRY_MESSAGGI, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_LOGS.SetQuery(PPQRY_MESSAGGI, 4, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("order by ");
    SQL.Append("  A.DATA_LOG desc ");
    PAN_LOGS.SetQuery(PPQRY_MESSAGGI, 5, SQL, -1, "");
    PAN_LOGS.SetQueryDB(PPQRY_MESSAGGI, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_LOGS.SetMasterTable(0, "LOGS");
    PAN_LOGS.AddToSortList(PFL_LOGS_DATA, false);
    SQL = new StringBuilder("");
    PAN_LOGS.SetQuery(0, -1, SQL, PFL_LOGS_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_LOGS) PAN_LOGS_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_LOGS) PAN_LOGS_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_LOGS) PAN_LOGS_CellActivated(ColIndex, Cancel);
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
