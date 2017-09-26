// **********************************************
// Spedizioni IOS
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
public partial class SpedizioniIOS : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_SPEDIZIONI_ID = 0;
  private const int PFL_SPEDIZIONI_APPLICAZIONE = 1;
  private const int PFL_SPEDIZIONI_DATAINSERIME = 2;
  private const int PFL_SPEDIZIONI_DATAELABORAZ = 3;
  private const int PFL_SPEDIZIONI_UTENTE = 4;
  private const int PFL_SPEDIZIONI_DISPOSITNOTI = 5;
  private const int PFL_SPEDIZIONI_DEVICETOKEN = 6;
  private const int PFL_SPEDIZIONI_MESSAGGIO = 7;
  private const int PFL_SPEDIZIONI_SOUND = 8;
  private const int PFL_SPEDIZIONI_BADGE = 9;
  private const int PFL_SPEDIZIONI_CUSTOMFIELD1 = 10;
  private const int PFL_SPEDIZIONI_CUSTOMFIELD2 = 11;
  private const int PFL_SPEDIZIONI_STATO = 12;

  private const int PPQRY_SPEDIZIONI1 = 0;

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
    Init_PQRY_SPEDIZIONI1(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_SPEDIZIONI1(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_SPEDIZIONI1, 13);
    IMDB.set_TblCode(IMDBDef1.PQRY_SPEDIZIONI1, "PQRY_SPEDIZIONI1");
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_DES_MESSAGGIO, "DES_MESSAGGIO");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_DES_MESSAGGIO,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_DEV_TOKEN, "DEV_TOKEN");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_DEV_TOKEN,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_FLG_STATO, "FLG_STATO");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_FLG_STATO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_ID_APPLICAZIONE, "ID_APPLICAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_ID_APPLICAZIONE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_DAT_CREAZ, "DAT_CREAZ");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_DAT_CREAZ,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_DAT_ELAB, "DAT_ELAB");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_DAT_ELAB,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_SOUND, "SOUND");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_SOUND,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_BADGE, "BADGE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_BADGE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_DES_UTENTE,5,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_DISPNOTISPED, "DISPNOTISPED");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_DISPNOTISPED,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_CUSTOM_FIELD1, "CUSTOM_FIELD1");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_CUSTOM_FIELD1,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_CUSTOM_FIELD2, "CUSTOM_FIELD2");
    IMDB.SetFldParams(IMDBDef1.PQRY_SPEDIZIONI1,IMDBDef1.PQSL_SPEDIZIONI1_CUSTOM_FIELD2,5,100,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_SPEDIZIONI1, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public SpedizioniIOS(MyWebEntryPoint w, IMDBObj imdb)
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
  public SpedizioniIOS()
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
    FormIdx = MyGlb.FRM_SPEDIZIONIOS;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "B5749086-B61D-4C19-B963-3A24EC0DA287";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 1168;
    DesignHeight = 680;
    set_Caption(new IDVariant("Spedizioni IOS"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 1168;
    Frames[1].Height = 620;
    Frames[1].Caption = "Spedizioni";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 620;
    PAN_SPEDIZIONI = new IDPanel(w, this, 1, "PAN_SPEDIZIONI");
    Frames[1].Content = PAN_SPEDIZIONI;
    PAN_SPEDIZIONI.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_SPEDIZIONI.VS = MainFrm.VisualStyleList;
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 1168-MyGlb.PAN_OFFS_X, 620-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "A2DC019C-A472-4C88-94C3-0E1436E2C130");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 1116, 536, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
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
    if (CmdIdx==MyGlb.CMD_ELIMININVIAT+BaseCmdLinIdx)
    {
      Eliminainviati();
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_RIMETINATTES+BaseCmdLinIdx)
    {
      RimettiInAttesa();
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
    return (obj is SpedizioniIOS);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(SpedizioniIOS).FullName : typeof(SpedizioniIOS).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Spedizioni On Dynamic Properties
  // Consente l'aggiustamento delle proprietà visuali delle
  // singole celle del pannello.
  // **********************************************************************
  private void PAN_SPEDIZIONI_DynamicProperties ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("5B6A4D28-BCAE-41B5-94E3-5DCAA71DE3B1", "Spedizioni On Dynamic Properties", "", 1, "Spedizioni IOS")) return;
      // 
      // Spedizioni On Dynamic Properties Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddIf ("28E3EE47-0606-498F-90F6-0991C93B2EAA", "IF Stato Spedizione [Spedizioni IOS - Spedizioni] = Attesa", "");
      MainFrm.DTTObj.AddToken ("28E3EE47-0606-498F-90F6-0991C93B2EAA", "D7DCF5CC-6836-4433-8BCB-FB1261F60DDC", 917504, "Stato Spedizione", IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI1, IMDBDef1.PQSL_SPEDIZIONI1_FLG_STATO, 0));
      MainFrm.DTTObj.AddToken ("28E3EE47-0606-498F-90F6-0991C93B2EAA", "D6046CA9-2D9C-4A5B-97B7-993C2399E958", 589824, "Attesa", (new IDVariant("W")));
      if (IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI1, IMDBDef1.PQSL_SPEDIZIONI1_FLG_STATO, 0).equals((new IDVariant("W")), true))
      {
        MainFrm.DTTObj.EnterIf ("28E3EE47-0606-498F-90F6-0991C93B2EAA", "IF Stato Spedizione [Spedizioni IOS - Spedizioni] = Attesa", "");
        MainFrm.DTTObj.AddSubProc ("C93BD58A-849C-4ED3-9C97-40E142B5EA1A", "Stato.Set Visual Style", "");
        MainFrm.DTTObj.AddParameter ("C93BD58A-849C-4ED3-9C97-40E142B5EA1A", "282AEF4C-909D-44A7-A28C-AC8A376ED0A0", "Stile", new IDVariant(MyGlb.VIS_SFONDOGIALLO));
        PAN_SPEDIZIONI.set_VisualStyle(Glb.OBJ_FIELD,PFL_SPEDIZIONI_STATO,new IDVariant(MyGlb.VIS_SFONDOGIALLO).intValue()); 
      }
      MainFrm.DTTObj.EndIfBlk ("28E3EE47-0606-498F-90F6-0991C93B2EAA");
      MainFrm.DTTObj.ExitProc("5B6A4D28-BCAE-41B5-94E3-5DCAA71DE3B1", "Spedizioni On Dynamic Properties", "", 1, "Spedizioni IOS");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("5B6A4D28-BCAE-41B5-94E3-5DCAA71DE3B1", "Spedizioni On Dynamic Properties", "", _e);
      MainFrm.ErrObj.ProcError ("SpedizioniIOS", "SpedizioniOnDynamicProperties", _e);
      MainFrm.DTTObj.ExitProc("5B6A4D28-BCAE-41B5-94E3-5DCAA71DE3B1", "Spedizioni On Dynamic Properties", "", 1, "Spedizioni IOS");
    }
  }

  // **********************************************************************
  // Elimina inviati
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int Eliminainviati ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("290F8151-CBEA-448B-AD3F-220FDF5CCE30", "Elimina inviati", "", 3, "Spedizioni IOS")) return 0;
      // 
      // Elimina inviati Body
      // Corpo Procedura
      // 
      SQL = new StringBuilder();
      SQL.Append("delete from SPEDIZIONI ");
      SQL.Append("where (TYPE_OS = '1') ");
      MainFrm.DTTObj.AddQuery ("55CAE879-1104-4DEC-8292-A05273AA2DDD", "Spedizioni (Notificatore DB): Delete", "", 256, SQL.ToString());
      MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
      MainFrm.DTTObj.EndQuery ("55CAE879-1104-4DEC-8292-A05273AA2DDD");
      MainFrm.DTTObj.AddParameter ("55CAE879-1104-4DEC-8292-A05273AA2DDD", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
      MainFrm.DTTObj.AddSubProc ("63D6475B-2D29-4BF4-84B1-CF2CAFD0D908", "Spedizioni.Refresh Query", "");
      PAN_SPEDIZIONI.PanelCommand(Glb.PCM_REQUERY);
      MainFrm.DTTObj.ExitProc("290F8151-CBEA-448B-AD3F-220FDF5CCE30", "Elimina inviati", "", 3, "Spedizioni IOS");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("290F8151-CBEA-448B-AD3F-220FDF5CCE30", "Elimina inviati", "", _e);
      MainFrm.ErrObj.ProcError ("SpedizioniIOS", "Eliminainviati", _e);
      MainFrm.DTTObj.ExitProc("290F8151-CBEA-448B-AD3F-220FDF5CCE30", "Elimina inviati", "", 3, "Spedizioni IOS");
      return -1;
    }
  }

  // **********************************************************************
  // Rimetti In Attesa
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int RimettiInAttesa ()
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

      if (!MainFrm.DTTObj.EnterProc("5D41FDDC-28A5-45E8-8A6C-8470262B5928", "Rimetti In Attesa", "", 3, "Spedizioni IOS")) return 0;
      // 
      // Rimetti In Attesa Body
      // Corpo Procedura
      // 
      IDVariant v_IRIGAATTIVA = null;
      MainFrm.DTTObj.AddAssign ("1C7DB3D7-251F-490F-AEC9-61AFC408C72A", "i Riga Attiva := C1", "", v_IRIGAATTIVA);
      v_IRIGAATTIVA = (new IDVariant(1));
      MainFrm.DTTObj.AddAssignNewValue ("1C7DB3D7-251F-490F-AEC9-61AFC408C72A", "15C634EE-1EA0-4D7F-BCA7-11F28D567287", v_IRIGAATTIVA);
      MainFrm.DTTObj.AddIf ("9A1D81EB-1D17-4376-9E58-56CA327F0D68", "IF Spedizioni [Spedizioni IOS].Show Multiple Selection", "");
      MainFrm.DTTObj.AddToken ("9A1D81EB-1D17-4376-9E58-56CA327F0D68", "A2DC019C-A472-4C88-94C3-0E1436E2C130", 2621440, "Spedizioni [Spedizioni IOS].Show Multiple Selection", PAN_SPEDIZIONI.ShowMultipleSel());
      if (PAN_SPEDIZIONI.ShowMultipleSel())
      {
        MainFrm.DTTObj.EnterIf ("9A1D81EB-1D17-4376-9E58-56CA327F0D68", "IF Spedizioni [Spedizioni IOS].Show Multiple Selection", "");
        int DTT_C3 = 0;
        MainFrm.DTTObj.AddForEach ("5A15CF7E-8AD4-4614-A2A5-B3B0AA6AAC40", "FOR EACH Spedizioni ROW", "");
        MainFrm.DTTObj.AddDBDataSource (PAN_SPEDIZIONI.MasterRS(), new StringBuilder(""));
        C3 = PAN_SPEDIZIONI.MasterRS();
        if (C3.size()>0) CurPos = C3.getRow(); else CurPos = 0;
        if (!C3.Bof()) PAN_SPEDIZIONI.GotoFirst();
        while (!PAN_SPEDIZIONI.RSEOF())
        {
          DTT_C3 = DTT_C3 + 1;
          if (!MainFrm.DTTObj.CheckLoop("5A15CF7E-8AD4-4614-A2A5-B3B0AA6AAC40", DTT_C3)) break;
          MainFrm.DTTObj.AddIf ("71207D1A-36E2-4E6E-B495-F41F27FCF895", "IF Spedizioni [Spedizioni IOS].Is Row Selected (i Riga Attiva)", "");
          MainFrm.DTTObj.AddToken ("71207D1A-36E2-4E6E-B495-F41F27FCF895", "A2DC019C-A472-4C88-94C3-0E1436E2C130", 2621440, "Spedizioni [Spedizioni IOS].Is Row Selected (i Riga Attiva)", PAN_SPEDIZIONI.IsRowSelected(v_IRIGAATTIVA.intValue()));
          MainFrm.DTTObj.AddToken ("71207D1A-36E2-4E6E-B495-F41F27FCF895", "15C634EE-1EA0-4D7F-BCA7-11F28D567287", 1376256, "i Riga Attiva", v_IRIGAATTIVA);
          if (PAN_SPEDIZIONI.IsRowSelected(v_IRIGAATTIVA.intValue()))
          {
            MainFrm.DTTObj.EnterIf ("71207D1A-36E2-4E6E-B495-F41F27FCF895", "IF Spedizioni [Spedizioni IOS].Is Row Selected (i Riga Attiva)", "");
            SQL = new StringBuilder();
            SQL.Append("update SPEDIZIONI set ");
            SQL.Append("  FLG_STATO = 'W' ");
            SQL.Append("where (ID = " + IDL.CSql(C3.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            SQL.Append("and   (FLG_STATO = 'S') ");
            MainFrm.DTTObj.AddQuery ("BF45CEB1-730D-4768-A36F-53BE5F190531", "Spedizioni (Notificatore DB): Update", "", 512, SQL.ToString());
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            MainFrm.DTTObj.EndQuery ("BF45CEB1-730D-4768-A36F-53BE5F190531");
            MainFrm.DTTObj.AddParameter ("BF45CEB1-730D-4768-A36F-53BE5F190531", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
          }
          MainFrm.DTTObj.EndIfBlk ("71207D1A-36E2-4E6E-B495-F41F27FCF895");
          MainFrm.DTTObj.AddAssign ("746EAFCD-10A7-4C03-BD71-99921174235D", "i Riga Attiva := i Riga Attiva + 1", "", v_IRIGAATTIVA);
          MainFrm.DTTObj.AddToken ("746EAFCD-10A7-4C03-BD71-99921174235D", "15C634EE-1EA0-4D7F-BCA7-11F28D567287", 1376256, "i Riga Attiva", v_IRIGAATTIVA);
          v_IRIGAATTIVA = IDL.Add(v_IRIGAATTIVA, (new IDVariant(1)));
          MainFrm.DTTObj.AddAssignNewValue ("746EAFCD-10A7-4C03-BD71-99921174235D", "15C634EE-1EA0-4D7F-BCA7-11F28D567287", v_IRIGAATTIVA);
          PAN_SPEDIZIONI.GotoNext();
        }
        if (CurPos>0) C3.absolute(CurPos);
        MainFrm.DTTObj.EndForEach ("5A15CF7E-8AD4-4614-A2A5-B3B0AA6AAC40", "FOR EACH Spedizioni ROW", "", DTT_C3);
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("99C9AAB0-07E0-4CDD-97EF-7AD08067B7F7", "ELSE", "", "9A1D81EB-1D17-4376-9E58-56CA327F0D68");
        MainFrm.DTTObj.AddIf ("AC281FCF-F00F-45E9-A223-D78106892CE7", "IF not (Is Null (ID Spedizione [Spedizioni IOS - Spedizioni]))", "");
        MainFrm.DTTObj.AddToken ("AC281FCF-F00F-45E9-A223-D78106892CE7", "E7439425-24A8-4927-A9C8-8925E2FBC0E4", 917504, "ID Spedizione", IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI1, IMDBDef1.PQSL_SPEDIZIONI1_ID, 0));
        if (!(IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI1, IMDBDef1.PQSL_SPEDIZIONI1_ID, 0))))
        {
          MainFrm.DTTObj.EnterIf ("AC281FCF-F00F-45E9-A223-D78106892CE7", "IF not (Is Null (ID Spedizione [Spedizioni IOS - Spedizioni]))", "");
          SQL = new StringBuilder();
          SQL.Append("update SPEDIZIONI set ");
          SQL.Append("  FLG_STATO = 'W' ");
          SQL.Append("where (ID = " + IDL.CSql(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI1, IMDBDef1.PQSL_SPEDIZIONI1_ID, 0), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
          SQL.Append("and   (FLG_STATO = 'S') ");
          MainFrm.DTTObj.AddQuery ("F36D72AE-E142-42D1-B481-9DE07A6ABA64", "Spedizioni (Notificatore DB): Update", "", 512, SQL.ToString());
          MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
          MainFrm.DTTObj.EndQuery ("F36D72AE-E142-42D1-B481-9DE07A6ABA64");
          MainFrm.DTTObj.AddParameter ("F36D72AE-E142-42D1-B481-9DE07A6ABA64", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
        }
        MainFrm.DTTObj.EndIfBlk ("AC281FCF-F00F-45E9-A223-D78106892CE7");
      }
      MainFrm.DTTObj.EndIfBlk ("9A1D81EB-1D17-4376-9E58-56CA327F0D68");
      MainFrm.DTTObj.AddSubProc ("3685C8DD-7D4E-42CB-A3C1-E7815A8668A4", "Spedizioni.Refresh Query", "");
      PAN_SPEDIZIONI.PanelCommand(Glb.PCM_REQUERY);
      MainFrm.DTTObj.ExitProc("5D41FDDC-28A5-45E8-8A6C-8470262B5928", "Rimetti In Attesa", "", 3, "Spedizioni IOS");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("5D41FDDC-28A5-45E8-8A6C-8470262B5928", "Rimetti In Attesa", "", _e);
      MainFrm.ErrObj.ProcError ("SpedizioniIOS", "RimettiInAttesa", _e);
      MainFrm.DTTObj.ExitProc("5D41FDDC-28A5-45E8-8A6C-8470262B5928", "Rimetti In Attesa", "", 3, "Spedizioni IOS");
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
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI1, IMDBDef1.PQSL_SPEDIZIONI1_DAT_CREAZ, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_SPEDIZIONI1, IMDBDef1.PQSL_SPEDIZIONI1_DAT_CREAZ, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_SPEDIZIONI1, IMDBDef1.PQSL_SPEDIZIONI1_FLG_STATO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_SPEDIZIONI1, IMDBDef1.PQSL_SPEDIZIONI1_FLG_STATO, 0, (new IDVariant("W")));
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
    PAN_SPEDIZIONI.SetSize(MyGlb.OBJ_FIELD, 13);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, "3B085267-7DA7-489C-B3C9-7685BD210D69");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, "ID");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, "Identificativo univoco");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, "8594C478-4654-4C9E-9235-3E3C14C22A79");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, "Applicazione");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, "Identificativo univoco");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.VIS_FOREIKEYFIEL);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, "9A97FD3E-7681-4994-9A21-5D8F11B6DD16");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, "Data Inserimento");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, "Data in cui è stato inserito il dato");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, "C9EA01B0-E95A-431A-9517-B0BB27DA6F42");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, "Data Elaborazione");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, "Data in cui è stato elaborato il record");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, "860C7ECD-A045-495A-AA61-FE59B1B7AD7C");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, "Utente");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, "59512EED-6C62-4551-B03D-A852587D8B90");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, "Dispositivi Noti");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, "08B8B00E-EB4E-4FB5-9C3E-5DC7B0295687");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, "Device Token");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, "Identificativo del dispositivo");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, "3F6873A3-EBC7-4586-AC30-2EF527858687");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, "Messaggio");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, "CB181070-7C43-4C03-9F19-0791756B5D66");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, "Sound");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, "768441BD-66FE-4FD8-B793-EA27AD8B5F48");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, "Badge");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, "6A958CDC-7860-4BEF-9427-0AC634A0B021");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, "Custom Field 1");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, "F6B35A4B-B2FD-4331-AEF1-F25021BAC736");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, "Custom Field 2");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_SPEDIZIONI.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, "9932B079-0540-4210-BD97-A36BCA48C156");
    PAN_SPEDIZIONI.set_Header(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, "Stato");
    PAN_SPEDIZIONI.set_ToolTip(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, "");
    PAN_SPEDIZIONI.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.VIS_NORMALFIELDS);
    PAN_SPEDIZIONI.SetFlags(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_SPEDIZIONI_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_LIST, 0, 32, 72, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_LIST, 20);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_LIST, "ID");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_FORM, 4, 4, 136, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_FORM, 88);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_ID, MyGlb.PANEL_FORM, "ID");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_ID, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_ID, PPQRY_SPEDIZIONI1, "A.ID", "ID", 1, 9, 0, -1709);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_LIST, 72, 32, 88, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_LIST, 84);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_FORM, 4, 100, 144, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_FORM, 84);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_APPLICAZIONE, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_APPLICAZIONE, PPQRY_SPEDIZIONI1, "A.ID_APPLICAZIONE", "ID_APPLICAZIONE", 1, 9, 0, -1709);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_LIST, 160, 32, 124, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_LIST, 92);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_LIST, "Data Inserimento");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_FORM, 4, 124, 412, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_FORM, 92);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAINSERIME, MyGlb.PANEL_FORM, "Dt. Inser.");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_DATAINSERIME, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_DATAINSERIME, PPQRY_SPEDIZIONI1, "A.DAT_CREAZ", "DAT_CREAZ", 8, 61, 0, -1709);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_LIST, 284, 32, 124, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_LIST, 96);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_LIST, "Data Elaborazione");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_FORM, 4, 148, 416, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_FORM, 96);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DATAELABORAZ, MyGlb.PANEL_FORM, "Dt. Elabor.");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_DATAELABORAZ, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_DATAELABORAZ, PPQRY_SPEDIZIONI1, "A.DAT_ELAB", "DAT_ELAB", 8, 61, 0, -1709);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_LIST, 408, 32, 84, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_LIST, 44);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_LIST, "Utente");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_FORM, 4, 232, 480, 44, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_FORM, 44);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_FORM, 2);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_UTENTE, MyGlb.PANEL_FORM, "Utente");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_UTENTE, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_UTENTE, PPQRY_SPEDIZIONI1, "A.DES_UTENTE", "DES_UTENTE", 5, 1000, 0, -1709);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_LIST, 492, 32, 100, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_LIST, 80);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_LIST, "Dispositivi Noti");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_FORM, 4, 280, 588, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_FORM, 80);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DISPOSITNOTI, MyGlb.PANEL_FORM, "Dispos. Noti");
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
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_DISPOSITNOTI, PPQRY_SPEDIZIONI1, SQL.ToString(), "DISPNOTISPED", 9, 1000, 0, -1709);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_LIST, 592, 32, 116, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_LIST, 72);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_LIST, "Device Token");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_FORM, 4, 52, 488, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_FORM, 88);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_DEVICETOKEN, MyGlb.PANEL_FORM, "Device Token");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_DEVICETOKEN, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_DEVICETOKEN, PPQRY_SPEDIZIONI1, "A.DEV_TOKEN", "DEV_TOKEN", 5, 1000, 0, -1709);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_LIST, 708, 32, 88, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_LIST, 60);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_LIST, "Messaggio");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_FORM, 4, 28, 488, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_FORM, 88);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_MESSAGGIO, MyGlb.PANEL_FORM, "Messaggio");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_MESSAGGIO, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_MESSAGGIO, PPQRY_SPEDIZIONI1, "A.DES_MESSAGGIO", "DES_MESSAGGIO", 9, 1000, 0, -1709);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_LIST, 796, 32, 48, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_LIST, 40);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_LIST, "Sound");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_FORM, 4, 172, 548, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_FORM, 40);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_SOUND, MyGlb.PANEL_FORM, "Soun.");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_SOUND, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_SOUND, PPQRY_SPEDIZIONI1, "A.SOUND", "SOUND", 5, 200, 0, -1709);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_LIST, 844, 32, 32, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_LIST, 40);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_LIST, "Bd.");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_FORM, 4, 208, 100, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_FORM, 40);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_BADGE, MyGlb.PANEL_FORM, "Bad.");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_BADGE, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_BADGE, PPQRY_SPEDIZIONI1, "A.BADGE", "BADGE", 1, 9, 0, -1709);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, MyGlb.PANEL_LIST, 876, 32, 80, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, MyGlb.PANEL_LIST, 80);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, MyGlb.PANEL_LIST, "Cust. Field 1");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, MyGlb.PANEL_FORM, 4, 304, 592, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, MyGlb.PANEL_FORM, 80);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD1, MyGlb.PANEL_FORM, "Cust. Field 1");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_CUSTOMFIELD1, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_CUSTOMFIELD1, PPQRY_SPEDIZIONI1, "A.CUSTOM_FIELD1", "CUSTOM_FIELD1", 5, 100, 0, -1709);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, MyGlb.PANEL_LIST, 956, 32, 80, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, MyGlb.PANEL_LIST, 80);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, MyGlb.PANEL_LIST, "Cust. Field 2");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, MyGlb.PANEL_FORM, 4, 328, 592, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, MyGlb.PANEL_FORM, 80);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_CUSTOMFIELD2, MyGlb.PANEL_FORM, "Cust. Field 2");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_CUSTOMFIELD2, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_CUSTOMFIELD2, PPQRY_SPEDIZIONI1, "A.CUSTOM_FIELD2", "CUSTOM_FIELD2", 5, 100, 0, -1709);
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_LIST, 1036, 32, 80, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_LIST, 32);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_LIST, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_LIST, "Stato");
    PAN_SPEDIZIONI.SetRect(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_FORM, 4, 76, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_SPEDIZIONI.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_FORM, 88);
    PAN_SPEDIZIONI.SetNumRow(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_FORM, 1);
    PAN_SPEDIZIONI.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_SPEDIZIONI_STATO, MyGlb.PANEL_FORM, "Stato");
    PAN_SPEDIZIONI.SetFieldPage(PFL_SPEDIZIONI_STATO, -1, -1);
    PAN_SPEDIZIONI.SetFieldPanel(PFL_SPEDIZIONI_STATO, PPQRY_SPEDIZIONI1, "A.FLG_STATO", "FLG_STATO", 5, 1, 0, -1709);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_STATO, (new IDVariant("W")), "Attesa", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_STATO, (new IDVariant("S")), "Inviato", "", "", -1);
    PAN_SPEDIZIONI.SetValueListItem(PFL_SPEDIZIONI_STATO, (new IDVariant("E")), "Errore", "", "", -1);
  }

  private void PAN_SPEDIZIONI_InitQueries()
  {
    StringBuilder SQL;

    PAN_SPEDIZIONI.SetSize(MyGlb.OBJ_QUERY, 2);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPLICAZIO, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.ID = ~~ID_APPLICAZIONE~~) ");
    SQL.Append("and   (A.TYPE_OS = '1') ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_APPLICAZIONI, 0, SQL, PFL_SPEDIZIONI_APPLICAZIONE, "93E60BCC-24C0-4C9D-9AE7-60AE3932D70F");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPLICAZIO, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.TYPE_OS = '1') ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_APPLICAZIONI, 1, SQL, PFL_SPEDIZIONI_APPLICAZIONE, "");
    PAN_SPEDIZIONI.SetQueryDB(PPQRY_APPLICAZIONI, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_SPEDIZIONI.SetIMDB(IMDB, "PQRY_SPEDIZIONI1", true);
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
    SQL.Append("  A.SOUND as SOUND, ");
    SQL.Append("  A.BADGE as BADGE, ");
    SQL.Append("  A.DES_UTENTE as DES_UTENTE, ");
    SQL.Append("  ( ");
    SQL.Append("select ");
    SQL.Append("  B.DES_MESSAGGIO ");
    SQL.Append("from ");
    SQL.Append("  DISPOSITIVI_NOTI B ");
    SQL.Append("where (B.DEV_TOKEN = A.DEV_TOKEN) ");
    SQL.Append(") as DISPNOTISPED, ");
    SQL.Append("  A.CUSTOM_FIELD1 as CUSTOM_FIELD1, ");
    SQL.Append("  A.CUSTOM_FIELD2 as CUSTOM_FIELD2 ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI1, 0, SQL, -1, "68B03566-BB93-4A3B-A413-8F979880139A");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  SPEDIZIONI A ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI1, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.TYPE_OS = '1') ");
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI1, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI1, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI1, 4, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_SPEDIZIONI.SetQuery(PPQRY_SPEDIZIONI1, 5, SQL, -1, "");
    PAN_SPEDIZIONI.SetQueryDB(PPQRY_SPEDIZIONI1, MainFrm.NotificatoreDBObject.DB, 256);
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
    if (SrcObj == PAN_SPEDIZIONI) PAN_SPEDIZIONI_DynamicProperties();
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
