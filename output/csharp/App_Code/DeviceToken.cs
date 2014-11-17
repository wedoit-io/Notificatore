// **********************************************
// Device Token
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
public partial class DeviceToken : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_DEVICETOKEN_ID = 0;
  private const int PFL_DEVICETOKEN_IDAPPSPUSSET = 1;
  private const int PFL_DEVICETOKEN_NOTAPPPUSSET = 2;
  private const int PFL_DEVICETOKEN_DEVTOKEN = 3;
  private const int PFL_DEVICETOKEN_DATAULTIACCE = 4;
  private const int PFL_DEVICETOKEN_DATA = 5;
  private const int PFL_DEVICETOKEN_ATTIVO = 6;
  private const int PFL_DEVICETOKEN_UTENTE = 7;
  private const int PFL_DEVICETOKEN_RIMOSSO = 8;
  private const int PFL_DEVICETOKEN_DATAULTIINVI = 9;
  private const int PFL_DEVICETOKEN_NOTA = 10;
  private const int PFL_DEVICETOKEN_DATARIMOZION = 11;
  private const int PFL_DEVICETOKEN_REGID = 12;
  private const int PFL_DEVICETOKEN_CUSTOMTAG = 13;
  private const int PFL_DEVICETOKEN_TYPEOS = 14;
  private const int PFL_DEVICETOKEN_DATACUPERTIN = 15;
  private const int PFL_DEVICETOKEN_IDLINGUA = 16;
  private const int PFL_DEVICETOKEN_DESCRILINGUA = 17;

  private const int PPQRY_DEVICETOKEN = 0;

  private const int PPQRY_LOOAPPPUSSET = 1;
  private const int PPQRY_LOOKUPLINGUA = 2;

  private const int PPQRY_APPSPUSHSETT = 3;
  private const int PPQRY_LINGUE = 4;


  internal IDPanel PAN_DEVICETOKEN;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_DEVICETOKEN(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_DEVICETOKEN(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DEVICETOKEN, 16);
    IMDB.set_TblCode(IMDBDef1.PQRY_DEVICETOKEN, "PQRY_DEVICETOKEN");
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_ID_APPLICAZIONE, "ID_APPLICAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_ID_APPLICAZIONE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DEV_TOKEN, "DEV_TOKEN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DEV_TOKEN,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DATA_ULT_ACCESSO, "DATA_ULT_ACCESSO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DATA_ULT_ACCESSO,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DATA_CREAZIONE, "DATA_CREAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DATA_CREAZIONE,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_FLG_ATTIVO, "FLG_ATTIVO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_FLG_ATTIVO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_FLG_RIMOSSO, "FLG_RIMOSSO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_FLG_RIMOSSO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DAT_ULTIMO_INVIO, "DAT_ULTIMO_INVIO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DAT_ULTIMO_INVIO,8,19,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DATA_RIMOZ, "DATA_RIMOZ");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DATA_RIMOZ,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_REG_ID, "REG_ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_REG_ID,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_CUSTOM_TAG, "CUSTOM_TAG");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_CUSTOM_TAG,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_TYPE_OS, "TYPE_OS");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_TYPE_OS,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DATA_CUPERTINO, "DATA_CUPERTINO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_DATA_CUPERTINO,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_PRG_LINGUA, "PRG_LINGUA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN,IMDBDef1.PQSL_DEVICETOKEN_PRG_LINGUA,1,9,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_DEVICETOKEN, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public DeviceToken(MyWebEntryPoint w, IMDBObj imdb)
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
  public DeviceToken()
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
    FormIdx = MyGlb.FRM_DEVICETOKEN;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "AA0CC099-65D8-4F6F-A7E3-5F186F27D8A0";
    ResModeW = 1;
    ResModeH = 1;
    iVisualFlags = -2049;
    DesignWidth = 588;
    DesignHeight = 550;
    set_Caption(new IDVariant("Device Token"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 588;
    Frames[1].Height = 524;
    Frames[1].Caption = "Device Token";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 524;
    PAN_DEVICETOKEN = new IDPanel(w, this, 1, "PAN_DEVICETOKEN");
    Frames[1].Content = PAN_DEVICETOKEN;
    PAN_DEVICETOKEN.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_DEVICETOKEN.VS = MainFrm.VisualStyleList;
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 588-MyGlb.PAN_OFFS_X, 524-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "7847523E-5975-4DA8-96CD-4CAD7E6E3BE2");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 512, 216, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
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
    return (obj is DeviceToken);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(DeviceToken).FullName : typeof(DeviceToken).Name);
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
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN, IMDBDef1.PQSL_DEVICETOKEN_DATA_ULT_ACCESSO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN, IMDBDef1.PQSL_DEVICETOKEN_DATA_ULT_ACCESSO, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN, IMDBDef1.PQSL_DEVICETOKEN_DATA_CREAZIONE, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN, IMDBDef1.PQSL_DEVICETOKEN_DATA_CREAZIONE, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN, IMDBDef1.PQSL_DEVICETOKEN_FLG_ATTIVO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN, IMDBDef1.PQSL_DEVICETOKEN_FLG_ATTIVO, 0, (new IDVariant("S")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN, IMDBDef1.PQSL_DEVICETOKEN_FLG_RIMOSSO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN, IMDBDef1.PQSL_DEVICETOKEN_FLG_RIMOSSO, 0, (new IDVariant("N")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN, IMDBDef1.PQSL_DEVICETOKEN_TYPE_OS, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN, IMDBDef1.PQSL_DEVICETOKEN_TYPE_OS, 0, (new IDVariant("1")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN, IMDBDef1.PQSL_DEVICETOKEN_DATA_CUPERTINO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN, IMDBDef1.PQSL_DEVICETOKEN_DATA_CUPERTINO, 0, IDL.Now());
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_DEVICETOKEN_Init()
  {

    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_FIELD, 18);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "31A525C2-3C20-4B23-BB1A-912689223A79");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "ID");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "Identificativo univoco");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, "649C7B42-8276-4E55-8CC5-39462162FAB0");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, "ID Apps Push Settings");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, "Identificativo univoco");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.VIS_FOREIKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, "24E0A257-3D45-43F3-8FE0-38C84CCE5A9C");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, "Nota Apps Push Settings");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, "Nota");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, MyGlb.VIS_LOOKUPFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISDESCR, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "DEE1F7D6-88CD-4CE8-B0B8-A3BF4B05967A");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "Dev Token");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "1D2A3D7D-5A51-4800-A2BE-08CBB098E21D");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "Data Ultimo Accesso");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "1D893588-C426-46D7-84D7-FC16CB742CEE");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "Data");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "0DA74A1B-4B93-4545-B00C-74FFEE6F1F8D");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "Attivo");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "DC45965F-1202-46B0-A321-24BDF52FEF3E");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "Utente");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "0F66EDFF-68A8-4646-B498-5BFB759AE3C4");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "Rimosso");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "69FA6D03-1E5C-4052-B020-2D3B697EE1B7");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "Data Ultimo Invio");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "Data dell'invio dell'ultima notifica push");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "0A09AA29-2360-4995-8A19-0FB560AC5968");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "Nota");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "Nota");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "72BE19CF-CF9A-4E63-BE06-2E21D0119768");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "Data Rimozione");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, "ACB49B18-A730-402A-BAE9-46E9080A2664");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, "Regid");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, "RegID usato da android");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, "71D7951E-F3D5-4014-A35B-6B4B1959A25C");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, "Custom TAG");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, "Custom TAG");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, "ED9D06F7-4970-49A2-99D0-C763D974064A");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, "Type OS");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, "146D44F7-19B1-423F-A64C-90085A1DA001");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, "Data Cupertino");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, "4BA86140-A08D-4D71-9FC2-D4A9A4C26C86");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, "Id Lingua");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.VIS_FOREIKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, "E4EF357B-186B-42DD-A973-B7CB891EC7BD");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, "Descrizione Lingua");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, MyGlb.VIS_LOOKUPFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISDESCR, -1);
  }

  private void PAN_DEVICETOKEN_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 0, 36, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 20);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, "ID");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 4, 4, 144, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, "ID");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_ID, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_ID, PPQRY_DEVICETOKEN, "A.ID", "ID", 1, 9, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_LIST, 40, 36, 40, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_LIST, 116);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_LIST, "I. A. P. Stt.");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_FORM, 156, 4, 176, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_FORM, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDAPPSPUSSET, MyGlb.PANEL_FORM, "ID Apps Push Settings");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_IDAPPSPUSSET, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_IDAPPSPUSSET, PPQRY_DEVICETOKEN, "A.ID_APPLICAZIONE", "ID_APPLICAZIONE", 1, 9, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, MyGlb.PANEL_LIST, 4, 224, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, MyGlb.PANEL_LIST, "Nota Apps Push Settings");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, MyGlb.PANEL_FORM, 4, 28, 496, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTAPPPUSSET, MyGlb.PANEL_FORM, "Nt. App. Psh. Stt.");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_NOTAPPPUSSET, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_NOTAPPPUSSET, PPQRY_LOOAPPPUSSET, "A.DES_NOTA", "NOAPPUSENOOG", 5, 100, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 4, 248, 528, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 2);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, "Dev Token");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 4, 52, 496, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 2);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, "Dev Token");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DEVTOKEN, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DEVTOKEN, PPQRY_DEVICETOKEN, "A.DEV_TOKEN", "DEV_TOKEN", 5, 200, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 4, 284, 448, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, "Data Ultimo Accesso");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 4, 76, 416, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, "Dt. Ultimo Accesso");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATAULTIACCE, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATAULTIACCE, PPQRY_DEVICETOKEN, "A.DATA_ULT_ACCESSO", "DATA_ULT_ACCESSO", 8, 61, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 4, 308, 448, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, "Data");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 4, 100, 416, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, "Data");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATA, PPQRY_DEVICETOKEN, "A.DATA_CREAZIONE", "DATA_CREAZIONE", 8, 61, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 80, 36, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 40);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, "Attivo");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 428, 100, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 56);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, "Attivo");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_ATTIVO, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_ATTIVO, PPQRY_DEVICETOKEN, "A.FLG_ATTIVO", "FLG_ATTIVO", 5, 1, 0, -685);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_ATTIVO, (new IDVariant("S")), "Si", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_ATTIVO, (new IDVariant("N")), "No", "", "", -1);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 4, 332, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, "Utente");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 4, 124, 496, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, "Utente");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_UTENTE, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_UTENTE, PPQRY_DEVICETOKEN, "A.DES_UTENTE", "DES_UTENTE", 5, 100, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 136, 36, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 48);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, "Rimosso");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 4, 148, 144, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, "Rimosso");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_RIMOSSO, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_RIMOSSO, PPQRY_DEVICETOKEN, "A.FLG_RIMOSSO", "FLG_RIMOSSO", 5, 1, 0, -685);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_RIMOSSO, (new IDVariant("N")), "No", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_RIMOSSO, (new IDVariant("S")), "Si", "", "", -1);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, 192, 36, 160, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, 92);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, "Data Ultimo Invio");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, 156, 148, 272, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, 104);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, "Data Ultimo Invio");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATAULTIINVI, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATAULTIINVI, PPQRY_DEVICETOKEN, "A.DAT_ULTIMO_INVIO", "DAT_ULTIMO_INVIO", 8, 19, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 4, 356, 528, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, "Nota");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 4, 172, 496, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, "Nota");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_NOTA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_NOTA, PPQRY_DEVICETOKEN, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 4, 380, 448, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, "Data Rimozione");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 4, 196, 416, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, "Data Rimozione");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATARIMOZION, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATARIMOZION, PPQRY_DEVICETOKEN, "A.DATA_RIMOZ", "DATA_RIMOZ", 8, 61, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_LIST, 4, 404, 528, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_LIST, 2);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_LIST, "Regid");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_FORM, 4, 220, 496, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_FORM, 2);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_REGID, MyGlb.PANEL_FORM, "Regid");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_REGID, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_REGID, PPQRY_DEVICETOKEN, "A.REG_ID", "REG_ID", 5, 200, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_LIST, 4, 440, 528, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_LIST, 2);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_LIST, "Custom TAG");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_FORM, 4, 244, 496, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_FORM, 2);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_FORM, "Custom TAG");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_CUSTOMTAG, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_CUSTOMTAG, PPQRY_DEVICETOKEN, "A.CUSTOM_TAG", "CUSTOM_TAG", 5, 200, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_LIST, 352, 36, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_LIST, 52);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_LIST, "Type OS");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_FORM, 4, 268, 208, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_FORM, "Type OS");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_TYPEOS, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_TYPEOS, PPQRY_DEVICETOKEN, "A.TYPE_OS", "TYPE_OS", 5, 1, 0, -685);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_TYPEOS, (new IDVariant("1")), "iOS", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_TYPEOS, (new IDVariant("2")), "Android", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_TYPEOS, (new IDVariant("3")), "Windows Phone", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_TYPEOS, (new IDVariant("4")), "Blackberry", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_TYPEOS, (new IDVariant("5")), "Windows Store", "", "", -1);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_LIST, 4, 476, 448, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_LIST, "Data Cupertino");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_FORM, 4, 292, 416, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_FORM, 96);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_FORM, "Data Cupertino");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATACUPERTIN, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATACUPERTIN, PPQRY_DEVICETOKEN, "A.DATA_CUPERTINO", "DATA_CUPERTINO", 8, 61, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, 456, 36, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, 52);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, "Id Lingua");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, 340, 4, 120, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, 64);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, "Id Lingua");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_IDLINGUA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_IDLINGUA, PPQRY_DEVICETOKEN, "A.PRG_LINGUA", "PRG_LINGUA", 1, 9, 0, -685);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, MyGlb.PANEL_LIST, 4, 500, 528, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_MOVE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, MyGlb.PANEL_LIST, 2);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, MyGlb.PANEL_LIST, "Descrizione Lingua");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, MyGlb.PANEL_FORM, 4, 316, 512, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, MyGlb.PANEL_FORM, 112);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, MyGlb.PANEL_FORM, 2);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DESCRILINGUA, MyGlb.PANEL_FORM, "Descrizione Lingua");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DESCRILINGUA, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DESCRILINGUA, PPQRY_LOOKUPLINGUA, "A.DES_LINGUA", "DESLINNOMOGG", 5, 150, 0, -685);
  }

  private void PAN_DEVICETOKEN_InitQueries()
  {
    StringBuilder SQL;

    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_QUERY, 5);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.DES_NOTA as NOAPPUSENOOG, ");
    SQL.Append("  A.ID as IDAPPUSENOOG ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A ");
    SQL.Append("where (A.ID = ~~ID_APPLICAZIONE~~) ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LOOAPPPUSSET, 0, SQL, -1, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_LOOAPPPUSSET, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DEVICETOKEN.SetMasterTable(PPQRY_LOOAPPPUSSET, "APPS_PUSH_SETTING");
    PAN_DEVICETOKEN.SetQueryLKE(PPQRY_LOOAPPPUSSET, PFL_DEVICETOKEN_IDAPPSPUSSET, "IDAPPUSENOOG");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.DES_NOTA as NOAPPUSENOOG, ");
    SQL.Append("  A.ID as IDAPPUSENOOG ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LOOAPPPUSSET, 1, SQL, -1, "");
    PAN_DEVICETOKEN.SetQueryHeaderColumn(PPQRY_LOOAPPPUSSET, "NOAPPUSENOOG", "Nota Apps Push Settings");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.DES_LINGUA as DESLINNOMOGG, ");
    SQL.Append("  A.PRG_LINGUA as IDLINGNOMOGG ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    SQL.Append("where (A.PRG_LINGUA = ~~PRG_LINGUA~~) ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LOOKUPLINGUA, 0, SQL, -1, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_LOOKUPLINGUA, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DEVICETOKEN.SetMasterTable(PPQRY_LOOKUPLINGUA, "LINGUE");
    PAN_DEVICETOKEN.SetQueryLKE(PPQRY_LOOKUPLINGUA, PFL_DEVICETOKEN_IDLINGUA, "IDLINGNOMOGG");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.DES_LINGUA as DESLINNOMOGG, ");
    SQL.Append("  A.PRG_LINGUA as IDLINGNOMOGG ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LOOKUPLINGUA, 1, SQL, -1, "");
    PAN_DEVICETOKEN.SetQueryHeaderColumn(PPQRY_LOOKUPLINGUA, "DESLINNOMOGG", "Descrizione Lingua");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPSPUSSET, ");
    SQL.Append("  A.DES_NOTA as NOTAPPPUSSET ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A ");
    SQL.Append("order by ");
    SQL.Append("  A.DES_NOTA ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_APPSPUSHSETT, 0, SQL, PFL_DEVICETOKEN_IDAPPSPUSSET, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_APPSPUSHSETT, MainFrm.NotificatoreDBObject.DB, 256);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.PRG_LINGUA as IDLINGUA, ");
    SQL.Append("  A.DES_LINGUA as DESCRILINGUA ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    SQL.Append("order by ");
    SQL.Append("  A.DES_LINGUA ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LINGUE, 0, SQL, PFL_DEVICETOKEN_IDLINGUA, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_LINGUE, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DEVICETOKEN.SetIMDB(IMDB, "PQRY_DEVICETOKEN", true);
    PAN_DEVICETOKEN.set_SetString(MyGlb.MASTER_ROWNAME, "Device Token");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.ID_APPLICAZIONE as ID_APPLICAZIONE, ");
    SQL.Append("  A.DEV_TOKEN as DEV_TOKEN, ");
    SQL.Append("  A.DATA_ULT_ACCESSO as DATA_ULT_ACCESSO, ");
    SQL.Append("  A.DATA_CREAZIONE as DATA_CREAZIONE, ");
    SQL.Append("  A.FLG_ATTIVO as FLG_ATTIVO, ");
    SQL.Append("  A.DES_UTENTE as DES_UTENTE, ");
    SQL.Append("  A.FLG_RIMOSSO as FLG_RIMOSSO, ");
    SQL.Append("  A.DAT_ULTIMO_INVIO as DAT_ULTIMO_INVIO, ");
    SQL.Append("  A.DES_NOTA as DES_NOTA, ");
    SQL.Append("  A.DATA_RIMOZ as DATA_RIMOZ, ");
    SQL.Append("  A.REG_ID as REG_ID, ");
    SQL.Append("  A.CUSTOM_TAG as CUSTOM_TAG, ");
    SQL.Append("  A.TYPE_OS as TYPE_OS, ");
    SQL.Append("  A.DATA_CUPERTINO as DATA_CUPERTINO, ");
    SQL.Append("  A.PRG_LINGUA as PRG_LINGUA ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN, 0, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  DEV_TOKENS A ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN, 1, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN, 5, SQL, -1, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_DEVICETOKEN, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DEVICETOKEN.SetMasterTable(0, "DEV_TOKENS");
    SQL = new StringBuilder("");
    PAN_DEVICETOKEN.SetQuery(0, -1, SQL, PFL_DEVICETOKEN_ID, "");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_DEVICETOKEN) PAN_DEVICETOKEN_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_DEVICETOKEN) PAN_DEVICETOKEN_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
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
