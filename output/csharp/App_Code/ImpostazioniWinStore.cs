// **********************************************
// Impostazioni Win Store
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
public partial class ImpostazioniWinStore : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int GRP_APPSPUSHSETT_WNSACCOUNT = 0;

  private const int PFL_APPSPUSHSETT_ID = 0;
  private const int PFL_APPSPUSHSETT_APPLICAZIONE = 1;
  private const int PFL_APPSPUSHSETT_WNSSECRET = 2;
  private const int PFL_APPSPUSHSETT_WNSPACSECIDE = 3;
  private const int PFL_APPSPUSHSETT_ATTIVA = 4;
  private const int PFL_APPSPUSHSETT_AMBIENTE = 5;
  private const int PFL_APPSPUSHSETT_NOTA = 6;
  private const int PFL_APPSPUSHSETT_WNSXMLTEMPLA = 7;
  private const int PFL_APPSPUSHSETT_TYPEOS = 8;

  private const int PPQRY_APPLICAZION4 = 0;

  private const int PPQRY_APPS = 1;


  internal IDPanel PAN_APPSPUSHSETT;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_APPLICAZION4(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_APPLICAZION4(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_APPLICAZION4, 9);
    IMDB.set_TblCode(IMDBDef1.PQRY_APPLICAZION4, "PQRY_APPLICAZION4");
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_FLG_ATTIVA, "FLG_ATTIVA");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_FLG_ATTIVA,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_TYPE_OS, "TYPE_OS");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_TYPE_OS,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_ID_APP, "ID_APP");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_ID_APP,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_FLG_AMBIENTE, "FLG_AMBIENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_FLG_AMBIENTE,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_WNS_SECRET, "WNS_SECRET");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_WNS_SECRET,5,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_WNS_SID, "WNS_SID");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_WNS_SID,5,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_WNS_XML, "WNS_XML");
    IMDB.SetFldParams(IMDBDef1.PQRY_APPLICAZION4,IMDBDef1.PQSL_APPLICAZION4_WNS_XML,9,5000,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_APPLICAZION4, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public ImpostazioniWinStore(MyWebEntryPoint w, IMDBObj imdb)
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
  public ImpostazioniWinStore()
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
    FormIdx = MyGlb.FRM_IMPOSWINSTOR;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "57D09067-5529-4AA4-B7A1-0E7FE3360A14";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 1028;
    DesignHeight = 742;
    set_Caption(new IDVariant("Impostazioni Win Store"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 1028;
    Frames[1].Height = 716;
    Frames[1].Caption = "Apps Push Settings";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 716;
    PAN_APPSPUSHSETT = new IDPanel(w, this, 1, "PAN_APPSPUSHSETT");
    Frames[1].Content = PAN_APPSPUSHSETT;
    PAN_APPSPUSHSETT.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_APPSPUSHSETT.VS = MainFrm.VisualStyleList;
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 1028-MyGlb.PAN_OFFS_X, 716-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_APPSPUSHSETT.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "29520513-D0D3-4639-B639-80863E5B776A");
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 984, 408, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_APPSPUSHSETT.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 44);
    PAN_APPSPUSHSETT.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_HASFORM | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_APPSPUSHSETT.InitStatus = 2;
    PAN_APPSPUSHSETT_Init();
    PAN_APPSPUSHSETT_InitFields();
    PAN_APPSPUSHSETT_InitQueries();
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
      PAN_APPSPUSHSETT.UpdatePanel(MainFrm);
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
    return (obj is ImpostazioniWinStore);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(ImpostazioniWinStore).FullName : typeof(ImpostazioniWinStore).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Apps Push Settings Before Insert
  // Evento notificato dal pannello prima dell'inserimento
  // nel database dei dati relativi ad una nuova riga di
  // pannello.
  // Cancel - Input/Output
  // **********************************************************************
  private void PAN_APPSPUSHSETT_BeforeInsert (IDVariant Cancel)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Apps Push Settings Before Insert Body
      // Corpo Procedura
      // 
      IMDB.set_Value(IMDBDef1.PQRY_APPLICAZION4, IMDBDef1.PQSL_APPLICAZION4_TYPE_OS, 0, (new IDVariant("5")));
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("ImpostazioniWinStore", "AppsPushSettingsBeforeInsert", _e);
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
  private void PAN_APPSPUSHSETT_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
  }

  private void PAN_APPSPUSHSETT_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_APPSPUSHSETT_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_APPLICAZION4, IMDBDef1.PQSL_APPLICAZION4_FLG_ATTIVA, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_APPLICAZION4, IMDBDef1.PQSL_APPLICAZION4_FLG_ATTIVA, 0, (new IDVariant("S")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_APPLICAZION4, IMDBDef1.PQSL_APPLICAZION4_TYPE_OS, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_APPLICAZION4, IMDBDef1.PQSL_APPLICAZION4_TYPE_OS, 0, (new IDVariant("1")));
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_APPSPUSHSETT_Init()
  {

    PAN_APPSPUSHSETT.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_APPSPUSHSETT.SetSize(MyGlb.OBJ_GROUP, 1);
    PAN_APPSPUSHSETT.SetRTCGuid(MyGlb.OBJ_GROUP, GRP_APPSPUSHSETT_WNSACCOUNT, "7FB08041-D954-4C39-A489-68EA2DCFCCA4");
    PAN_APPSPUSHSETT.set_Header(MyGlb.OBJ_GROUP, GRP_APPSPUSHSETT_WNSACCOUNT, "Wns account");
    PAN_APPSPUSHSETT.set_ToolTip(MyGlb.OBJ_GROUP, GRP_APPSPUSHSETT_WNSACCOUNT, "");
    PAN_APPSPUSHSETT.set_VisualStyle(MyGlb.OBJ_GROUP, GRP_APPSPUSHSETT_WNSACCOUNT, MyGlb.VIS_DEFAPANESTYL);
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_GROUP, GRP_APPSPUSHSETT_WNSACCOUNT, MyGlb.PANEL_LIST, 216, -9999, 492, 21, 0, 0);
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_GROUP, GRP_APPSPUSHSETT_WNSACCOUNT, MyGlb.PANEL_FORM, 0, 140, 548, 100, 0, 0);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_GROUP, GRP_APPSPUSHSETT_WNSACCOUNT, 0, 72);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_GROUP, GRP_APPSPUSHSETT_WNSACCOUNT, 1, 13);
    PAN_APPSPUSHSETT.SetHeaderPos(MyGlb.OBJ_GROUP, GRP_APPSPUSHSETT_WNSACCOUNT, 0, 4);
    PAN_APPSPUSHSETT.SetHeaderPos(MyGlb.OBJ_GROUP, GRP_APPSPUSHSETT_WNSACCOUNT, 1, 3);
    PAN_APPSPUSHSETT.SetFlags(MyGlb.OBJ_GROUP, GRP_APPSPUSHSETT_WNSACCOUNT, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE, -1);
    PAN_APPSPUSHSETT.SetSize(MyGlb.OBJ_FIELD, 9);
    PAN_APPSPUSHSETT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, "61AE5146-EAA5-4101-BAC9-1EC34B7D7785");
    PAN_APPSPUSHSETT.set_Header(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, "ID");
    PAN_APPSPUSHSETT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, "Identificativo univoco");
    PAN_APPSPUSHSETT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_APPSPUSHSETT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_APPSPUSHSETT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, "17AFB9B5-1E31-4B97-A53D-DAC253A387DE");
    PAN_APPSPUSHSETT.set_Header(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, "Applicazione");
    PAN_APPSPUSHSETT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, "Identificativo univoco");
    PAN_APPSPUSHSETT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, MyGlb.VIS_FOREIKEYFIEL);
    PAN_APPSPUSHSETT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP, -1);
    PAN_APPSPUSHSETT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, "A4E732C8-2D89-4DBD-8B0D-6C6E0335E187");
    PAN_APPSPUSHSETT.set_Header(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, "Wns Secret");
    PAN_APPSPUSHSETT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, "");
    PAN_APPSPUSHSETT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, MyGlb.VIS_NORMALFIELDS);
    PAN_APPSPUSHSETT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APPSPUSHSETT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, "FE3D8689-3477-4AA5-867F-BA371FCEAE93");
    PAN_APPSPUSHSETT.set_Header(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, "Wns Package Security Identifier");
    PAN_APPSPUSHSETT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, "");
    PAN_APPSPUSHSETT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, MyGlb.VIS_NORMALFIELDS);
    PAN_APPSPUSHSETT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APPSPUSHSETT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, "5E81C305-13C6-4CE7-B87B-16B2EB9AD5D5");
    PAN_APPSPUSHSETT.set_Header(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, "Attiva");
    PAN_APPSPUSHSETT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, "");
    PAN_APPSPUSHSETT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, MyGlb.VIS_NORMALFIELDS);
    PAN_APPSPUSHSETT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_APPSPUSHSETT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, "B8009008-DCE2-4C11-82AE-36E91E1CC453");
    PAN_APPSPUSHSETT.set_Header(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, "Ambiente");
    PAN_APPSPUSHSETT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, "");
    PAN_APPSPUSHSETT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_APPSPUSHSETT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_APPSPUSHSETT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, "2C9A843F-55DC-41A4-B2DB-12D13F954CF3");
    PAN_APPSPUSHSETT.set_Header(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, "Nota");
    PAN_APPSPUSHSETT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, "Nota");
    PAN_APPSPUSHSETT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, MyGlb.VIS_NORMALFIELDS);
    PAN_APPSPUSHSETT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISDESCR, -1);
    PAN_APPSPUSHSETT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, "9B2C25E9-911C-4557-8305-4E39A1734F74");
    PAN_APPSPUSHSETT.set_Header(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, "Wns Xml Template");
    PAN_APPSPUSHSETT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, "");
    PAN_APPSPUSHSETT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, MyGlb.VIS_NORMALFIELDS);
    PAN_APPSPUSHSETT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_VERTHDRLIST | MyGlb.FLD_ISOPT, -1);
    PAN_APPSPUSHSETT.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, "312A675E-244C-44BC-B2A0-D8826C21C97E");
    PAN_APPSPUSHSETT.set_Header(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, "Type OS");
    PAN_APPSPUSHSETT.set_ToolTip(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, "");
    PAN_APPSPUSHSETT.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, MyGlb.VIS_NORMALFIELDS);
    PAN_APPSPUSHSETT.SetFlags(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, 0 | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_APPSPUSHSETT_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, MyGlb.PANEL_LIST, 0, 48, 48, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, MyGlb.PANEL_LIST, 20);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, MyGlb.PANEL_LIST, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, MyGlb.PANEL_LIST, "ID");
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, MyGlb.PANEL_FORM, 8, 8, 152, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, MyGlb.PANEL_FORM, 104);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, MyGlb.PANEL_FORM, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ID, MyGlb.PANEL_FORM, "ID");
    PAN_APPSPUSHSETT.SetFieldPage(PFL_APPSPUSHSETT_ID, -1, -1);
    PAN_APPSPUSHSETT.SetFieldPanel(PFL_APPSPUSHSETT_ID, PPQRY_APPLICAZION4, "A.ID", "ID", 1, 9, 0, -685);
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, MyGlb.PANEL_LIST, 48, 48, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, MyGlb.PANEL_LIST, 48);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, MyGlb.PANEL_FORM, 8, 32, 504, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, MyGlb.PANEL_FORM, 104);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, MyGlb.PANEL_FORM, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_APPSPUSHSETT.SetFieldPage(PFL_APPSPUSHSETT_APPLICAZIONE, -1, -1);
    PAN_APPSPUSHSETT.SetFieldPanel(PFL_APPSPUSHSETT_APPLICAZIONE, PPQRY_APPLICAZION4, "A.ID_APP", "ID_APP", 1, 9, 0, -685);
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, MyGlb.PANEL_LIST, 216, 48, 248, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, MyGlb.PANEL_LIST, 64);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, MyGlb.PANEL_LIST, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, MyGlb.PANEL_LIST, "Wns Secret");
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, MyGlb.PANEL_FORM, 4, 144, 540, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, MyGlb.PANEL_FORM, 104);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, MyGlb.PANEL_FORM, 2);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSSECRET, MyGlb.PANEL_FORM, "Wns Secret");
    PAN_APPSPUSHSETT.SetFieldPage(PFL_APPSPUSHSETT_WNSSECRET, -1, GRP_APPSPUSHSETT_WNSACCOUNT);
    PAN_APPSPUSHSETT.SetFieldPanel(PFL_APPSPUSHSETT_WNSSECRET, PPQRY_APPLICAZION4, "A.WNS_SECRET", "WNS_SECRET", 5, 500, 0, -685);
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, MyGlb.PANEL_LIST, 464, 48, 244, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, MyGlb.PANEL_LIST, 164);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, MyGlb.PANEL_LIST, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, MyGlb.PANEL_LIST, "Wns Package Security Identifier");
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, MyGlb.PANEL_FORM, 4, 192, 540, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, MyGlb.PANEL_FORM, 104);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, MyGlb.PANEL_FORM, 2);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSPACSECIDE, MyGlb.PANEL_FORM, "Wns Package Security Identifier");
    PAN_APPSPUSHSETT.SetFieldPage(PFL_APPSPUSHSETT_WNSPACSECIDE, -1, GRP_APPSPUSHSETT_WNSACCOUNT);
    PAN_APPSPUSHSETT.SetFieldPanel(PFL_APPSPUSHSETT_WNSPACSECIDE, PPQRY_APPLICAZION4, "A.WNS_SID", "WNS_SID", 5, 500, 0, -685);
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, MyGlb.PANEL_LIST, 708, 48, 52, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, MyGlb.PANEL_LIST, 40);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, MyGlb.PANEL_LIST, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, MyGlb.PANEL_LIST, "Attiva");
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, MyGlb.PANEL_FORM, 336, 8, 176, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, MyGlb.PANEL_FORM, 128);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, MyGlb.PANEL_FORM, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_ATTIVA, MyGlb.PANEL_FORM, "Attiva");
    PAN_APPSPUSHSETT.SetFieldPage(PFL_APPSPUSHSETT_ATTIVA, -1, -1);
    PAN_APPSPUSHSETT.SetFieldPanel(PFL_APPSPUSHSETT_ATTIVA, PPQRY_APPLICAZION4, "A.FLG_ATTIVA", "FLG_ATTIVA", 5, 1, 0, -685);
    PAN_APPSPUSHSETT.SetValueListItem(PFL_APPSPUSHSETT_ATTIVA, (new IDVariant("S")), "Si", "", "", -1);
    PAN_APPSPUSHSETT.SetValueListItem(PFL_APPSPUSHSETT_ATTIVA, (new IDVariant("N")), "No", "", "", -1);
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, MyGlb.PANEL_LIST, 760, 48, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, MyGlb.PANEL_LIST, 56);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, MyGlb.PANEL_LIST, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, MyGlb.PANEL_LIST, "Ambiente");
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, MyGlb.PANEL_FORM, 8, 64, 216, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, MyGlb.PANEL_FORM, 104);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, MyGlb.PANEL_FORM, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_AMBIENTE, MyGlb.PANEL_FORM, "Ambiente");
    PAN_APPSPUSHSETT.SetFieldPage(PFL_APPSPUSHSETT_AMBIENTE, -1, -1);
    PAN_APPSPUSHSETT.SetFieldPanel(PFL_APPSPUSHSETT_AMBIENTE, PPQRY_APPLICAZION4, "A.FLG_AMBIENTE", "FLG_AMBIENTE", 5, 1, 0, -685);
    PAN_APPSPUSHSETT.SetValueListItem(PFL_APPSPUSHSETT_AMBIENTE, (new IDVariant("S")), "Sviluppo", "", "", -1);
    PAN_APPSPUSHSETT.SetValueListItem(PFL_APPSPUSHSETT_AMBIENTE, (new IDVariant("P")), "Produzione", "", "", -1);
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, MyGlb.PANEL_LIST, 816, 48, 168, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, MyGlb.PANEL_LIST, 60);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, MyGlb.PANEL_LIST, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, MyGlb.PANEL_LIST, "Nota");
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, MyGlb.PANEL_FORM, 8, 104, 536, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, MyGlb.PANEL_FORM, 104);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, MyGlb.PANEL_FORM, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_NOTA, MyGlb.PANEL_FORM, "Nota");
    PAN_APPSPUSHSETT.SetFieldPage(PFL_APPSPUSHSETT_NOTA, -1, -1);
    PAN_APPSPUSHSETT.SetFieldPanel(PFL_APPSPUSHSETT_NOTA, PPQRY_APPLICAZION4, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -685);
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, MyGlb.PANEL_LIST, 0, 416, 432, 236, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_MOVE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, MyGlb.PANEL_LIST, 20);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, MyGlb.PANEL_LIST, 15);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, MyGlb.PANEL_LIST, "Wns Xml Template");
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, MyGlb.PANEL_FORM, 4, 244, 540, 232, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, MyGlb.PANEL_FORM, 104);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, MyGlb.PANEL_FORM, 17);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_WNSXMLTEMPLA, MyGlb.PANEL_FORM, "Wns Xml Template");
    PAN_APPSPUSHSETT.SetFieldPage(PFL_APPSPUSHSETT_WNSXMLTEMPLA, -1, -1);
    PAN_APPSPUSHSETT.SetFieldPanel(PFL_APPSPUSHSETT_WNSXMLTEMPLA, PPQRY_APPLICAZION4, "A.WNS_XML", "WNS_XML", 9, 5000, 0, -685);
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, MyGlb.PANEL_LIST, 0, 48, 52, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, MyGlb.PANEL_LIST, 52);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, MyGlb.PANEL_LIST, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, MyGlb.PANEL_LIST, "Type OS");
    PAN_APPSPUSHSETT.SetRect(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, MyGlb.PANEL_FORM, 4, 148, 96, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_APPSPUSHSETT.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, MyGlb.PANEL_FORM, 52);
    PAN_APPSPUSHSETT.SetNumRow(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, MyGlb.PANEL_FORM, 1);
    PAN_APPSPUSHSETT.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_APPSPUSHSETT_TYPEOS, MyGlb.PANEL_FORM, "Type OS");
    PAN_APPSPUSHSETT.SetFieldPage(PFL_APPSPUSHSETT_TYPEOS, -1, -1);
    PAN_APPSPUSHSETT.SetFieldPanel(PFL_APPSPUSHSETT_TYPEOS, PPQRY_APPLICAZION4, "A.TYPE_OS", "TYPE_OS", 5, 1, 0, -685);
    PAN_APPSPUSHSETT.SetValueListItem(PFL_APPSPUSHSETT_TYPEOS, (new IDVariant("1")), "iOS", "", "", -1);
    PAN_APPSPUSHSETT.SetValueListItem(PFL_APPSPUSHSETT_TYPEOS, (new IDVariant("2")), "Android", "", "", -1);
    PAN_APPSPUSHSETT.SetValueListItem(PFL_APPSPUSHSETT_TYPEOS, (new IDVariant("3")), "Windows Phone", "", "", -1);
    PAN_APPSPUSHSETT.SetValueListItem(PFL_APPSPUSHSETT_TYPEOS, (new IDVariant("4")), "Blackberry", "", "", -1);
    PAN_APPSPUSHSETT.SetValueListItem(PFL_APPSPUSHSETT_TYPEOS, (new IDVariant("5")), "Windows Store", "", "", -1);
  }

  private void PAN_APPSPUSHSETT_InitQueries()
  {
    StringBuilder SQL;

    PAN_APPSPUSHSETT.SetSize(MyGlb.OBJ_QUERY, 2);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS A ");
    SQL.Append("where (A.ID = ~~ID_APP~~) ");
    PAN_APPSPUSHSETT.SetQuery(PPQRY_APPS, 0, SQL, PFL_APPSPUSHSETT_APPLICAZIONE, "");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS A ");
    PAN_APPSPUSHSETT.SetQuery(PPQRY_APPS, 1, SQL, PFL_APPSPUSHSETT_APPLICAZIONE, "");
    PAN_APPSPUSHSETT.SetQueryDB(PPQRY_APPS, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_APPSPUSHSETT.SetIMDB(IMDB, "PQRY_APPLICAZION4", true);
    PAN_APPSPUSHSETT.set_SetString(MyGlb.MASTER_ROWNAME, "Applicazione");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.DES_NOTA as DES_NOTA, ");
    SQL.Append("  A.FLG_ATTIVA as FLG_ATTIVA, ");
    SQL.Append("  A.TYPE_OS as TYPE_OS, ");
    SQL.Append("  A.ID_APP as ID_APP, ");
    SQL.Append("  A.FLG_AMBIENTE as FLG_AMBIENTE, ");
    SQL.Append("  A.WNS_SECRET as WNS_SECRET, ");
    SQL.Append("  A.WNS_SID as WNS_SID, ");
    SQL.Append("  A.WNS_XML as WNS_XML ");
    PAN_APPSPUSHSETT.SetQuery(PPQRY_APPLICAZION4, 0, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A ");
    PAN_APPSPUSHSETT.SetQuery(PPQRY_APPLICAZION4, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.TYPE_OS = '5') ");
    PAN_APPSPUSHSETT.SetQuery(PPQRY_APPLICAZION4, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPSPUSHSETT.SetQuery(PPQRY_APPLICAZION4, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPSPUSHSETT.SetQuery(PPQRY_APPLICAZION4, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_APPSPUSHSETT.SetQuery(PPQRY_APPLICAZION4, 5, SQL, -1, "");
    PAN_APPSPUSHSETT.SetQueryDB(PPQRY_APPLICAZION4, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_APPSPUSHSETT.SetMasterTable(0, "APPS_PUSH_SETTING");
    SQL = new StringBuilder("");
    PAN_APPSPUSHSETT.SetQuery(0, -1, SQL, PFL_APPSPUSHSETT_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_APPSPUSHSETT) PAN_APPSPUSHSETT_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_APPSPUSHSETT) PAN_APPSPUSHSETT_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_APPSPUSHSETT) PAN_APPSPUSHSETT_CellActivated(ColIndex, Cancel);
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
    if (SrcObj == PAN_APPSPUSHSETT) PAN_APPSPUSHSETT_BeforeInsert(Cancel);
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
