// **********************************************
// Spedizioni Win Phone
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
public partial class SpedizioniWinPhone : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_SPEDIZIONI_ID = 0;
  private const int PFL_SPEDIZIONI_APPLICAZIONE = 1;
  private const int PFL_SPEDIZIONI_DATAINSERIME = 2;
  private const int PFL_SPEDIZIONI_DATAELABORAZ = 3;
  private const int PFL_SPEDIZIONI_UTENTE = 4;
  private const int PFL_SPEDIZIONI_DISPOSITNOTI = 5;
  private const int PFL_SPEDIZIONI_GUIDGRUPINVI = 6;
  private const int PFL_SPEDIZIONI_DEVICETOKEN = 7;
  private const int PFL_SPEDIZIONI_MESSAGGIO = 8;
  private const int PFL_SPEDIZIONI_BADGE = 9;
  private const int PFL_SPEDIZIONI_STATO = 10;
  private const int PFL_SPEDIZIONI_NUMEROTENTAT = 11;
  private const int PFL_SPEDIZIONI_INFO = 12;
  private const int PFL_SPEDIZIONI_REGURL = 13;
  private const int PFL_SPEDIZIONI_TYPEOS = 14;

  private const int PPQRY_SPEDIZIONI2 = 0;

  private const int PPQRY_APPLICAZIONI = 1;


  internal IDPanel PAN_SPEDIZIONI;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_SPEDIZIONI2(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_SPEDIZIONI2(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_SPEDIZIONI2, 15);
    IMDB.set_TblCode(IMDBDef1.PQRY_SPEDIZIONI2, "PQRY_SPEDIZIONI2");
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_DES_MESSAGGIO, "DES_MESSAGGIO");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_DES_MESSAGGIO,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_DEV_TOKEN, "DEV_TOKEN");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_DEV_TOKEN,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_FLG_STATO, "FLG_STATO");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_FLG_STATO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_ID_APPLICAZIONE, "ID_APPLICAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_ID_APPLICAZIONE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_DAT_CREAZ, "DAT_CREAZ");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_DAT_CREAZ,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_DAT_ELAB, "DAT_ELAB");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_DAT_ELAB,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_BADGE, "BADGE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_BADGE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_DES_UTENTE,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_REG_ID, "REG_ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_REG_ID,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_TYPE_OS, "TYPE_OS");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_TYPE_OS,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_DISPNOTISPED, "DISPNOTISPED");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_DISPNOTISPED,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_INFO, "INFO");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_INFO,5,2000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_TENTATIVI, "TENTATIVI");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_TENTATIVI,1,3,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_GUID_GRUPPO, "GUID_GRUPPO");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI2,IMDBDef1.PQSL_SPEDIZIONI2_GUID_GRUPPO,5,200,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_SPEDIZIONI2, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public SpedizioniWinPhone(MyWebEntryPoint w, IMDBObj imdb)
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
  public SpedizioniWinPhone()
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
    FormIdx = MyGlb.FRM_SPEDIWINPHON;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "79ACBACC-36C6-4AB9-B525-B2EA19701FF0";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 996;
    DesignHeight = 802;
    set_Caption(new IDVariant("Spedizioni Win Phone"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 996;
    Frames[1].Height = 776;
    Frames[1].Caption = "Spedizioni";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 776;
    PAN_SPEDIZIONI = new IDPanel(w, this, 1, "PAN_SPEDIZIONI");
    Frames[1].Content = PAN_SPEDIZIONI;
    PAN_SPEDIZIONI.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_SPEDIZIONI.VS = MainFrm.VisualStyleList;
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 996-MyGlb.PAN_OFFS_X, 776-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "5887BFA5-BF7C-4B6C-AA55-FEC1367CDEF6");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 944, 500, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_SPEDIZIONI.InitStatus = 1;
    PAN_SPEDIZIONI_Init();
    PAN_SPEDIZIONI_InitFields();
    PAN_SPEDIZIONI_InitQueries();
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
    if (CmdIdx==MyGlb.CMD_INVIASUBITO+BaseCmdLinIdx)
    {
      Inviasubito();
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
      PAN_SPEDIZIONI.UpdatePanel(MainFrm);
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
    return (obj is SpedizioniWinPhone);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(SpedizioniWinPhone).FullName : typeof(SpedizioniWinPhone).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Invia subito
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int Inviasubito ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;
    int CurPos=0;
    IDCachedRowSet C3;

    try
    {
      TransCount = 0;
      // 
      // Invia subito Body
      // Corpo Procedura
      // 
      // IDVariant v_IRIGAATTIVA = null;
      // v_IRIGAATTIVA = (new IDVariant(1));
      // if (PAN_SPEDIZIONI.ShowMultipleSel())
      // {
        // C3 = PAN_SPEDIZIONI.MasterRS();
        // if (C3.size()>0) CurPos = C3.getRow(); else CurPos = 0;
        // if (!C3.Bof()) PAN_SPEDIZIONI.GotoFirst();
        // while (!PAN_SPEDIZIONI.RSEOF())
        // {
          // if (PAN_SPEDIZIONI.IsRowSelected(v_IRIGAATTIVA.intValue()))
          // {
            // MainFrm.SendGCMNotification(C3.Get("ID"));
          // }
          // v_IRIGAATTIVA = IDL.Add(v_IRIGAATTIVA, (new IDVariant(1)));
        //   PAN_SPEDIZIONI.GotoNext();
        // }
        // if (CurPos>0) C3.absolute(CurPos);
      // }
      // else
      // {
        // if (!(IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI2, IMDBDef1.PQSL_SPEDIZIONI2_ID, 0))))
        // {
          // MainFrm.SendGCMNotification(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI2, IMDBDef1.PQSL_SPEDIZIONI2_ID, 0));
        // }
      // }
      // PAN_SPEDIZIONI.PanelCommand(Glb.PCM_REQUERY);
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("SpedizioniWinPhone", "Inviasubito", _e);
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
  private void PAN_SPEDIZIONI_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
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
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI2, IMDBDef1.PQSL_SPEDIZIONI2_DAT_CREAZ, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_SPEDIZIONI2, IMDBDef1.PQSL_SPEDIZIONI2_DAT_CREAZ, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI2, IMDBDef1.PQSL_SPEDIZIONI2_FLG_STATO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_SPEDIZIONI2, IMDBDef1.PQSL_SPEDIZIONI2_FLG_STATO, 0, (new IDVariant("W")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI2, IMDBDef1.PQSL_SPEDIZIONI2_TYPE_OS, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_SPEDIZIONI2, IMDBDef1.PQSL_SPEDIZIONI2_TYPE_OS, 0, (new IDVariant("1")));
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
    PAN_SPEDIZIONI.SetSize(MyGlb.OBJ_FIELD, 15);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, "C6C22CF1-D597-45FB-A89D-E12F8B9D72D3");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, "ID");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, "Identificativo univoco");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, "614727AD-2112-4778-BD04-E7520D47185A");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, "Applicazione");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, "Identificativo univoco");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.VIS_FOREIKEYFIEL);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, "02ECE557-C753-42E9-8790-84421F2E77AB");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, "Data Inserimento");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, "Data in cui è stato inserito il dato");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, "5623A4E7-DD35-4EB5-99D7-0A425CB70887");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, "Data Elaborazione");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, "Data in cui è stato elaborato il record");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, "780E73D7-B804-4FB6-BE9B-C6870674AC8E");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, "Utente");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, "30CC6291-ED93-47C5-B789-39BBE6FADE63");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, "Dispositivi Noti");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, "09EBE12A-8AD7-4CC2-8B52-74E7FEAA53AB");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, "Guid Gruppo Invio");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, "A538FAED-E677-49FD-941F-BBCBBB027053");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, "Device Token");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, "Identificativo del dispositivo");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, "E039984F-A390-45CE-B493-CB85476FC94C");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, "Messaggio");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_VERTHDRLIST | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, "0D996344-8C6E-44E2-AB19-D7D3BA8F6533");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, "Badge");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, "B8F39D3D-CF90-4A76-9578-8E176F1F22AF");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, "Stato");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, "6AD99AF5-CFD5-4B53-857D-F61DCBC177F6");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, "Numero Tentativi");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, "A64D8F87-F99C-406C-9016-84CFDC5B9511");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, "Info");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_VERTHDRLIST | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, "1E01CBB1-43DC-4110-8954-EE604183BD73");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, "Reg url");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, "RegID usato da android");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_VERTHDRLIST | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, "F6F2B474-2030-4F25-AC93-250E670F01BB");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, "Type OS");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, 0 | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_SPEDIZIONI_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_LIST, 0, 36, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_LIST, 20);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_LIST, "ID");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_FORM, 4, 4, 136, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_FORM, 88);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_FORM, "ID");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_ID, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_ID, PPQRY_SPEDIZIONI2, "A.ID", "ID", 1, 9, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_LIST, 56, 36, 88, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_LIST, 84);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_FORM, 4, 100, 144, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_FORM, 84);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_APPLICAZIONE, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_APPLICAZIONE, PPQRY_SPEDIZIONI2, "A.ID_APPLICAZIONE", "ID_APPLICAZIONE", 1, 9, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_LIST, 144, 36, 108, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_LIST, 92);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_LIST, "Data Inserimento");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_FORM, 4, 124, 412, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_FORM, 92);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_FORM, "Data Inserimento");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_DATAINSERIME, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_DATAINSERIME, PPQRY_SPEDIZIONI2, "A.DAT_CREAZ", "DAT_CREAZ", 8, 61, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_LIST, 252, 36, 108, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_LIST, 96);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_LIST, "Data Elaborazione");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_FORM, 4, 148, 416, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_FORM, 96);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_FORM, "Data Elaborazione");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_DATAELABORAZ, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_DATAELABORAZ, PPQRY_SPEDIZIONI2, "A.DAT_ELAB", "DAT_ELAB", 8, 61, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_LIST, 536, 36, 144, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_LIST, 44);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_LIST, "Utente");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_FORM, 4, 232, 480, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_FORM, 44);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_FORM, 2);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_FORM, "Utente");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_UTENTE, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_UTENTE, PPQRY_SPEDIZIONI2, "A.DES_UTENTE", "DES_UTENTE", 5, 1000, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_LIST, 360, 36, 176, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_LIST, 80);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_LIST, "Dispositivi Noti");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_FORM, 4, 340, 588, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_FORM, 80);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_FORM, "Dispositivi Noti");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_DISPOSITNOTI, -1, -1);
    SQL = new StringBuilder();
    SQL.Append("( ");
  SQL.Append("select ");
  SQL.Append("  B.DES_MESSAGGIO ");
  SQL.Append("from ");
  SQL.Append("  DISPOSITIVI_NOTI B ");
  SQL.Append("where (B.DEV_TOKEN = A.DEV_TOKEN) ");
  SQL.Append(")");
    PAN_SPEDIZIONI.SetFieldUnbound(PFL_SPEDIZIONI_DISPOSITNOTI, true);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_DISPOSITNOTI, PPQRY_SPEDIZIONI2, SQL.ToString(), "DISPNOTISPED", 9, 1000, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_LIST, 680, 36, 120, 20, MyGlb.RESMODE_MOVE, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_LIST, 96);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_LIST, "Guid Gruppo Invio");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_FORM, 4, 436, 236, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_FORM, 96);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_GUIDGRUPINVI, MyGlb.PANEL_FORM, "Guid Gruppo Invio");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_GUIDGRUPINVI, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_GUIDGRUPINVI, PPQRY_SPEDIZIONI2, "A.GUID_GRUPPO", "GUID_GRUPPO", 5, 200, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_LIST, 440, 512, 504, 20, MyGlb.RESMODE_MOVE, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_LIST, 72);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_LIST, "Device Token");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_FORM, 4, 52, 488, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_FORM, 88);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_FORM, "Device Token");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_DEVICETOKEN, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_DEVICETOKEN, PPQRY_SPEDIZIONI2, "A.DEV_TOKEN", "DEV_TOKEN", 5, 1000, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_LIST, 0, 512, 420, 192, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_LIST, 20);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_LIST, 12);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_LIST, "Messaggio");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_FORM, 4, 28, 488, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_FORM, 88);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_FORM, "Messaggio");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_MESSAGGIO, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_MESSAGGIO, PPQRY_SPEDIZIONI2, "A.DES_MESSAGGIO", "DES_MESSAGGIO", 9, 1000, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_LIST, 800, 36, 32, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_LIST, 40);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_LIST, "Bad.");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_FORM, 4, 208, 100, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_FORM, 40);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_FORM, "Badge");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_BADGE, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_BADGE, PPQRY_SPEDIZIONI2, "A.BADGE", "BADGE", 1, 9, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_LIST, 832, 36, 80, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_LIST, 32);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_LIST, "Stato");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_FORM, 4, 76, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_FORM, 88);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_FORM, "Stato");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_STATO, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_STATO, PPQRY_SPEDIZIONI2, "A.FLG_STATO", "FLG_STATO", 5, 1, 0, -685);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_STATO, (new IDVariant("W")), "Attesa", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_STATO, (new IDVariant("S")), "Inviato", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_STATO, (new IDVariant("E")), "Errore", "", "", -1);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_LIST, 912, 36, 32, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_LIST, 92);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_LIST, "Num. Tent.");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_FORM, 4, 412, 136, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_FORM, 92);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_NUMEROTENTAT, MyGlb.PANEL_FORM, "Numero Tentativi");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_NUMEROTENTAT, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_NUMEROTENTAT, PPQRY_SPEDIZIONI2, "A.TENTATIVI", "TENTATIVI", 1, 3, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_LIST, 440, 624, 500, 80, MyGlb.RESMODE_MOVE, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_LIST, 20);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_LIST, 3);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_LIST, "Info");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_FORM, 4, 364, 464, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_FORM, 28);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_FORM, 2);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_INFO, MyGlb.PANEL_FORM, "Info");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_INFO, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_INFO, PPQRY_SPEDIZIONI2, "A.INFO", "INFO", 5, 2000, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, MyGlb.PANEL_LIST, 440, 544, 504, 72, MyGlb.RESMODE_MOVE, MyGlb.RESMODE_MOVE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, MyGlb.PANEL_LIST, 20);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, MyGlb.PANEL_LIST, 3);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, MyGlb.PANEL_LIST, "Reg url");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, MyGlb.PANEL_FORM, 4, 280, 544, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, MyGlb.PANEL_FORM, 36);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, MyGlb.PANEL_FORM, 2);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_REGURL, MyGlb.PANEL_FORM, "Reg url");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_REGURL, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_REGURL, PPQRY_SPEDIZIONI2, "A.REG_ID", "REG_ID", 5, 200, 0, -685);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_LIST, 1028, 36, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_LIST, 52);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_LIST, "Type OS");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_FORM, 4, 316, 96, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_FORM, 52);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_TYPEOS, MyGlb.PANEL_FORM, "Type OS");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_TYPEOS, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_TYPEOS, PPQRY_SPEDIZIONI2, "A.TYPE_OS", "TYPE_OS", 5, 1, 0, -685);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_TYPEOS, (new IDVariant("1")), "iOS", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_TYPEOS, (new IDVariant("2")), "Android", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_TYPEOS, (new IDVariant("3")), "Windows Phone", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_TYPEOS, (new IDVariant("4")), "Blackberry", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_TYPEOS, (new IDVariant("5")), "Windows Store", "", "", -1);
  }

  private void PAN_SPEDIZIONI_InitQueries()
  {
    StringBuilder SQL;

    PAN_SPEDIZIONI.SetSize(MyGlb.OBJ_QUERY, 2);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.ID = ~~ID_APPLICAZIONE~~) ");
    SQL.Append("and   (A.TYPE_OS = '3') ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_APPLICAZIONI, 0, SQL, PFL_SPEDIZIONI_APPLICAZIONE, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.TYPE_OS = '3') ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_APPLICAZIONI, 1, SQL, PFL_SPEDIZIONI_APPLICAZIONE, "");
    PAN_SPEDIZIONI.SetQueryDB(PPQRY_APPLICAZIONI, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_SPEDIZIONI.SetIMDB(IMDB, "PQRY_SPEDIZIONI2", true);
    PAN_SPEDIZIONI.set_SetString(MyGlb.MASTER_ROWNAME, "Spedizione");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.DES_MESSAGGIO as DES_MESSAGGIO, ");
    SQL.Append("  A.DEV_TOKEN as DEV_TOKEN, ");
    SQL.Append("  A.FLG_STATO as FLG_STATO, ");
    SQL.Append("  A.ID_APPLICAZIONE as ID_APPLICAZIONE, ");
    SQL.Append("  A.DAT_CREAZ as DAT_CREAZ, ");
    SQL.Append("  A.DAT_ELAB as DAT_ELAB, ");
    SQL.Append("  A.BADGE as BADGE, ");
    SQL.Append("  A.DES_UTENTE as DES_UTENTE, ");
    SQL.Append("  A.REG_ID as REG_ID, ");
    SQL.Append("  A.TYPE_OS as TYPE_OS, ");
    SQL.Append("  ( ");
    SQL.Append("select ");
    SQL.Append("  B.DES_MESSAGGIO ");
    SQL.Append("from ");
    SQL.Append("  DISPOSITIVI_NOTI B ");
    SQL.Append("where (B.DEV_TOKEN = A.DEV_TOKEN) ");
    SQL.Append(") as DISPNOTISPED, ");
    SQL.Append("  A.INFO as INFO, ");
    SQL.Append("  A.TENTATIVI as TENTATIVI, ");
    SQL.Append("  A.GUID_GRUPPO as GUID_GRUPPO ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI2, 0, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  SPEDIZIONI A ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI2, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.TYPE_OS = '3') ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI2, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI2, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI2, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI2, 5, SQL, -1, "");
    PAN_SPEDIZIONI.SetQueryDB(PPQRY_SPEDIZIONI2, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_SPEDIZIONI.SetMasterTable(0, "SPEDIZIONI");
    SQL = new StringBuilder("");
    PAN_SPEDIZIONI.SetQuery(0, -1, SQL, PFL_SPEDIZIONI_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_SPEDIZIONI) PAN_SPEDIZIONI_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_SPEDIZIONI) PAN_SPEDIZIONI_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_SPEDIZIONI) PAN_SPEDIZIONI_CellActivated(ColIndex, Cancel);
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
