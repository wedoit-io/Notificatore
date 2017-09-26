// **********************************************
// Device Token IOS
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
public partial class DeviceTokenIOS : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PAG_DEVICETOKEN_PRINCIPALE = 0;
  private const int PAG_DEVICETOKEN_ALTRO = 1;

  private const int PFL_DEVICETOKEN_ID = 0;
  private const int PFL_DEVICETOKEN_APPLICAZIONE = 1;
  private const int PFL_DEVICETOKEN_DEVTOKEN = 2;
  private const int PFL_DEVICETOKEN_DATA = 3;
  private const int PFL_DEVICETOKEN_DATAULTIACCE = 4;
  private const int PFL_DEVICETOKEN_DISPOSITNOTI = 5;
  private const int PFL_DEVICETOKEN_UTENTE = 6;
  private const int PFL_DEVICETOKEN_ATTIVO = 7;
  private const int PFL_DEVICETOKEN_RIMOSSO = 8;
  private const int PFL_DEVICETOKEN_DATAULTIINVI = 9;
  private const int PFL_DEVICETOKEN_DATACUPERTIN = 10;
  private const int PFL_DEVICETOKEN_NOTA = 11;
  private const int PFL_DEVICETOKEN_CUSTOMTAG = 12;
  private const int PFL_DEVICETOKEN_DATARIMOZION = 13;
  private const int PFL_DEVICETOKEN_TYPEOS = 14;
  private const int PFL_DEVICETOKEN_IDLINGUA = 15;

  private const int PPQRY_DEVICETOKEN1 = 0;

  private const int PPQRY_APPLICAZIONI = 1;
  private const int PPQRY_LINGUE = 2;


  internal IDPanel PAN_DEVICETOKEN;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
    Init_PQRY_DEVICETOKEN1(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_PQRY_DEVICETOKEN1(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_DEVICETOKEN1, 16);
    IMDB.set_TblCode(IMDBDef1.PQRY_DEVICETOKEN1, "PQRY_DEVICETOKEN1");
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_ID, "ID");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_ID,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DEV_TOKEN, "DEV_TOKEN");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DEV_TOKEN,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DATA_ULT_ACCESSO, "DATA_ULT_ACCESSO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DATA_ULT_ACCESSO,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DATA_CREAZIONE, "DATA_CREAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DATA_CREAZIONE,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_FLG_ATTIVO, "FLG_ATTIVO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_FLG_ATTIVO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_FLG_RIMOSSO, "FLG_RIMOSSO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_FLG_RIMOSSO,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DAT_ULTIMO_INVIO, "DAT_ULTIMO_INVIO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DAT_ULTIMO_INVIO,8,19,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DES_NOTA, "DES_NOTA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DES_NOTA,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_ID_APPLICAZIONE, "ID_APPLICAZIONE");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_ID_APPLICAZIONE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DATA_RIMOZ, "DATA_RIMOZ");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DATA_RIMOZ,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_CUSTOM_TAG, "CUSTOM_TAG");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_CUSTOM_TAG,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_TYPE_OS, "TYPE_OS");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_TYPE_OS,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DATA_CUPERTINO, "DATA_CUPERTINO");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DATA_CUPERTINO,8,61,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DISNOTDEVTOK, "DISNOTDEVTOK");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_DISNOTDEVTOK,9,1000,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_PRG_LINGUA, "PRG_LINGUA");
    IMDB.SetFldParams(IMDBDef1.PQRY_DEVICETOKEN1,IMDBDef1.PQSL_DEVICETOKEN1_PRG_LINGUA,1,9,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_DEVICETOKEN1, 0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public DeviceTokenIOS(MyWebEntryPoint w, IMDBObj imdb)
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
  public DeviceTokenIOS()
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
    FormIdx = MyGlb.FRM_DEVICTOKEIOS;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "5E934776-4FB9-4054-BEC9-64BB055EB412";
    ResModeW = 3;
    ResModeH = 3;
    iVisualFlags = -2049;
    DesignWidth = 884;
    DesignHeight = 636;
    set_Caption(new IDVariant("Device Token IOS"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 884;
    Frames[1].Height = 576;
    Frames[1].Caption = "Device Token";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 576;
    PAN_DEVICETOKEN = new IDPanel(w, this, 1, "PAN_DEVICETOKEN");
    Frames[1].Content = PAN_DEVICETOKEN;
    PAN_DEVICETOKEN.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_DEVICETOKEN.VS = MainFrm.VisualStyleList;
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 884-MyGlb.PAN_OFFS_X, 576-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "CA8E9332-E979-4328-98CD-790E23C604CB");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 820, 480, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_HASLIST | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
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
    if (CmdIdx==MyGlb.CMD_INVIANOTIFIC+BaseCmdLinIdx)
    {
      Invianotifica();
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
    return (obj is DeviceTokenIOS);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(DeviceTokenIOS).FullName : typeof(DeviceTokenIOS).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Device Token On Dynamic Properties
  // Consente l'aggiustamento delle proprietà visuali delle
  // singole celle del pannello.
  // **********************************************************************
  private void PAN_DEVICETOKEN_DynamicProperties ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("808ACEDF-376E-40D4-89BE-DF4F31853A6C", "Device Token On Dynamic Properties", "", 1, "Device Token IOS")) return;
      // 
      // Device Token On Dynamic Properties Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddIf ("318D5F4C-DA31-4177-8F74-67CD0BC0A34E", "IF Data Principale [Device Token IOS - Device Token].Text = Data Ultimo Accesso Principale [Device Token IOS - Device Token].Text", "");
      MainFrm.DTTObj.AddToken ("318D5F4C-DA31-4177-8F74-67CD0BC0A34E", "E05D0107-7CF4-484C-AD72-8F15D495D4C4", 2686976, "Data Principale [Device Token IOS - Device Token].Text", (new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATA))));
      MainFrm.DTTObj.AddToken ("318D5F4C-DA31-4177-8F74-67CD0BC0A34E", "942A48CF-D7FC-421E-997E-BF67BA625156", 2686976, "Data Ultimo Accesso Principale [Device Token IOS - Device Token].Text", (new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATAULTIACCE))));
      if ((new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATA))).equals((new IDVariant(PAN_DEVICETOKEN.FieldText(PFL_DEVICETOKEN_DATAULTIACCE))), true))
      {
        MainFrm.DTTObj.EnterIf ("318D5F4C-DA31-4177-8F74-67CD0BC0A34E", "IF Data Principale [Device Token IOS - Device Token].Text = Data Ultimo Accesso Principale [Device Token IOS - Device Token].Text", "");
        MainFrm.DTTObj.AddSubProc ("6E3713FD-F5BE-4FB4-8F3C-10D2D4C23033", "Data Ultimo Accesso.Set Visual Style", "");
        MainFrm.DTTObj.AddParameter ("6E3713FD-F5BE-4FB4-8F3C-10D2D4C23033", "65F207C7-56FB-4BD5-9F82-9D4D696B7F04", "Stile", new IDVariant(MyGlb.VIS_SFONDOGIALLO));
        PAN_DEVICETOKEN.set_VisualStyle(Glb.OBJ_FIELD,PFL_DEVICETOKEN_DATAULTIACCE,new IDVariant(MyGlb.VIS_SFONDOGIALLO).intValue()); 
      }
      MainFrm.DTTObj.EndIfBlk ("318D5F4C-DA31-4177-8F74-67CD0BC0A34E");
      MainFrm.DTTObj.AddIf ("764E486B-8B77-41A0-A31B-6518E56E8508", "IF Rimosso Device Token [Device Token IOS - Device Token] = Si", "");
      MainFrm.DTTObj.AddToken ("764E486B-8B77-41A0-A31B-6518E56E8508", "5735B45E-5002-4DC6-8AC7-D021BBC71E7B", 917504, "Rimosso Device Token", IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_FLG_RIMOSSO, 0));
      MainFrm.DTTObj.AddToken ("764E486B-8B77-41A0-A31B-6518E56E8508", "9575A2DC-7881-4521-9D86-3444CB6D5E8A", 589824, "Si", (new IDVariant("S")));
      if (IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_FLG_RIMOSSO, 0).equals((new IDVariant("S")), true))
      {
        MainFrm.DTTObj.EnterIf ("764E486B-8B77-41A0-A31B-6518E56E8508", "IF Rimosso Device Token [Device Token IOS - Device Token] = Si", "");
        MainFrm.DTTObj.AddSubProc ("19D9DAFB-71F3-4B71-918F-571B93C409B0", "Rimosso.Set Visual Style", "");
        MainFrm.DTTObj.AddParameter ("19D9DAFB-71F3-4B71-918F-571B93C409B0", "328D2678-842D-4873-A336-03D20F3A8F74", "Stile", new IDVariant(MyGlb.VIS_SFONDOROSSO));
        PAN_DEVICETOKEN.set_VisualStyle(Glb.OBJ_FIELD,PFL_DEVICETOKEN_RIMOSSO,new IDVariant(MyGlb.VIS_SFONDOROSSO).intValue()); 
      }
      MainFrm.DTTObj.EndIfBlk ("764E486B-8B77-41A0-A31B-6518E56E8508");
      MainFrm.DTTObj.ExitProc("808ACEDF-376E-40D4-89BE-DF4F31853A6C", "Device Token On Dynamic Properties", "", 1, "Device Token IOS");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("808ACEDF-376E-40D4-89BE-DF4F31853A6C", "Device Token On Dynamic Properties", "", _e);
      MainFrm.ErrObj.ProcError ("DeviceTokenIOS", "DeviceTokenOnDynamicProperties", _e);
      MainFrm.DTTObj.ExitProc("808ACEDF-376E-40D4-89BE-DF4F31853A6C", "Device Token On Dynamic Properties", "", 1, "Device Token IOS");
    }
  }

  // **********************************************************************
  // Invia notifica
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int Invianotifica ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("E73122F4-5E94-488C-A1E0-0C6625D98D2A", "Invia notifica", "", 3, "Device Token IOS")) return 0;
      // 
      // Invia notifica Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddIf ("FEA92D60-39AC-49C7-BAA3-06D66A504F31", "IF not (Is Null (ID Device Token [Device Token IOS - Device Token]))", "");
      MainFrm.DTTObj.AddToken ("FEA92D60-39AC-49C7-BAA3-06D66A504F31", "B14FAEEC-A1E7-4DF3-8B10-005150F942EA", 917504, "ID Device Token", IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_ID, 0));
      if (!(IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_ID, 0))))
      {
        MainFrm.DTTObj.EnterIf ("FEA92D60-39AC-49C7-BAA3-06D66A504F31", "IF not (Is Null (ID Device Token [Device Token IOS - Device Token]))", "");
        MainFrm.DTTObj.AddSubProc ("08B69F14-40CA-4BEA-AAE6-ED134623BDD3", "Invio Notifiche A Utenti IOS.Start Form", "");
        ((InvioNotificheAUtentiIOS)MainFrm.GetForm(MyGlb.FRM_INVNOTAUTEIO,1,true,this)).StartForm(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_ID_APPLICAZIONE, 0), IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_DES_UTENTE, 0));
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("9518C987-9F7C-4700-8953-8F56058894F9", "ELSE", "", "FEA92D60-39AC-49C7-BAA3-06D66A504F31");
        MainFrm.DTTObj.AddSubProc ("389CFBAB-7ACD-40CD-A267-7B15EAB70515", "Notificatore.Message Box", "");
        MainFrm.DTTObj.AddParameter ("389CFBAB-7ACD-40CD-A267-7B15EAB70515", "879ADC1F-A148-4B26-8E46-1C90D1E03388", "Messaggio", (new IDVariant("Selezionare un utente")));
        MainFrm.set_AlertMessage((new IDVariant("Selezionare un utente"))); 
      }
      MainFrm.DTTObj.EndIfBlk ("FEA92D60-39AC-49C7-BAA3-06D66A504F31");
      MainFrm.DTTObj.ExitProc("E73122F4-5E94-488C-A1E0-0C6625D98D2A", "Invia notifica", "", 3, "Device Token IOS");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("E73122F4-5E94-488C-A1E0-0C6625D98D2A", "Invia notifica", "", _e);
      MainFrm.ErrObj.ProcError ("DeviceTokenIOS", "Invianotifica", _e);
      MainFrm.DTTObj.ExitProc("E73122F4-5E94-488C-A1E0-0C6625D98D2A", "Invia notifica", "", 3, "Device Token IOS");
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
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_DATA_CREAZIONE, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_DATA_CREAZIONE, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_DATA_ULT_ACCESSO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_DATA_ULT_ACCESSO, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_FLG_ATTIVO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_FLG_ATTIVO, 0, (new IDVariant("S")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_FLG_RIMOSSO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_FLG_RIMOSSO, 0, (new IDVariant("N")));
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_DATA_CUPERTINO, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_DATA_CUPERTINO, 0, IDL.Now());
      }
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_TYPE_OS, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_DEVICETOKEN1, IMDBDef1.PQSL_DEVICETOKEN1_TYPE_OS, 0, (new IDVariant("1")));
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_DEVICETOKEN_Init()
  {

    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_PAGE, 2);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_PAGE, PAG_DEVICETOKEN_PRINCIPALE, "9B99B895-73A5-4C95-A7D8-EA298D07CBF5");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_PAGE, PAG_DEVICETOKEN_PRINCIPALE, "Principale");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_PAGE, PAG_DEVICETOKEN_PRINCIPALE, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_PAGE, PAG_DEVICETOKEN_PRINCIPALE, MyGlb.VIS_DEFAPANESTYL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_PAGE, PAG_DEVICETOKEN_PRINCIPALE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_PAGE, PAG_DEVICETOKEN_ALTRO, "E7E1729C-B1F9-450C-9754-95CB57325A6A");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_PAGE, PAG_DEVICETOKEN_ALTRO, "Altro");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_PAGE, PAG_DEVICETOKEN_ALTRO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_PAGE, PAG_DEVICETOKEN_ALTRO, MyGlb.VIS_DEFAPANESTYL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_PAGE, PAG_DEVICETOKEN_ALTRO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE, -1);
    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_FIELD, 16);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "5926D1D6-A531-409E-8A57-99FA57CA021D");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "ID");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, "Identificativo univoco");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.VIS_PRIMAKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, 0 | MyGlb.FLD_ISOPT | MyGlb.FLD_ISKEY, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, "A885D04C-862C-4645-9877-A95E9D5573A4");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, "Applicazione");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, "Identificativo univoco");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.VIS_FOREIKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "179EF1B4-3220-440A-BA90-EA7CFE268E90");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "Dev Token");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "E05D0107-7CF4-484C-AD72-8F15D495D4C4");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "Data");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "942A48CF-D7FC-421E-997E-BF67BA625156");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "Data Ultimo Accesso");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, "3EDC4964-2568-4EB2-B814-B73E5F282346");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, "Dispositivi Noti");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "B60E4327-DF99-4145-8BD1-7CA2C339CCE8");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "Utente");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "46EC477C-9003-4583-8985-0A88AC89734E");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "Attivo");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "57AE2A07-3A71-41C8-B46C-51601837BF63");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "Rimosso");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "895A8D02-5EB4-4D9E-BE7B-1F7105DA2970");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "Data Ultimo Invio");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, "Data dell'invio dell'ultima notifica push");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, "73AAF211-1B4D-4D7E-9FBF-79A397E59038");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, "Data Cupertino");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "F828D92B-D868-4F22-BEEC-24277454A9F0");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "Nota");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, "Nota");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, "C07F3DCD-6570-4283-841C-A739187C0A0D");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, "Custom TAG");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, "Custom TAG");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "219C089B-A101-494D-9AEC-B923F7A0FCE2");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "Data Rimozione");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, "1E64BC04-AF9E-4502-99EC-67915574683D");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, "Type OS");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.VIS_NORMALFIELDS);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_DEVICETOKEN.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, "DDB4E789-D850-4A7E-B884-2EB0E5B2089B");
    PAN_DEVICETOKEN.set_Header(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, "Id Lingua");
    PAN_DEVICETOKEN.set_ToolTip(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, "");
    PAN_DEVICETOKEN.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.VIS_FOREIKEYFIEL);
    PAN_DEVICETOKEN.SetFlags(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_DEVICETOKEN_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 0, 32, 68, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 20);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_LIST, "ID");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 4, 4, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ID, MyGlb.PANEL_FORM, "ID");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_ID, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_ID, PPQRY_DEVICETOKEN1, "A.ID", "ID", 1, 9, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, 0, 32, 192, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, 136);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, 4, 28, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_APPLICAZIONE, -1, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_APPLICAZIONE, PPQRY_DEVICETOKEN1, "A.ID_APPLICAZIONE", "ID_APPLICAZIONE", 1, 9, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 192, 32, 124, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_LIST, "Dev Token");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 4, 52, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DEVTOKEN, MyGlb.PANEL_FORM, "Dev Token");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DEVTOKEN, PAG_DEVICETOKEN_PRINCIPALE, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DEVTOKEN, PPQRY_DEVICETOKEN1, "A.DEV_TOKEN", "DEV_TOKEN", 5, 200, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 316, 32, 112, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_LIST, "Data");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 4, 100, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATA, MyGlb.PANEL_FORM, "Data");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATA, PAG_DEVICETOKEN_PRINCIPALE, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATA, PPQRY_DEVICETOKEN1, "A.DATA_CREAZIONE", "DATA_CREAZIONE", 8, 61, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 428, 32, 116, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 128);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_LIST, "Dt. Ult. Accesso");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 4, 76, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIACCE, MyGlb.PANEL_FORM, "Dt. Ultimo Accesso");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATAULTIACCE, PAG_DEVICETOKEN_PRINCIPALE, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATAULTIACCE, PPQRY_DEVICETOKEN1, "A.DATA_ULT_ACCESSO", "DATA_ULT_ACCESSO", 8, 61, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, MyGlb.PANEL_LIST, 544, 32, 68, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, MyGlb.PANEL_LIST, 80);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, MyGlb.PANEL_LIST, "Disp. Nt.");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, MyGlb.PANEL_FORM, 4, 172, 628, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DISPOSITNOTI, MyGlb.PANEL_FORM, "Dispositivi Noti");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DISPOSITNOTI, PAG_DEVICETOKEN_PRINCIPALE, -1);
    SQL = new StringBuilder();
    SQL.Append("( ");
  SQL.Append("select ");
  SQL.Append("  B.DES_MESSAGGIO ");
  SQL.Append("from ");
  SQL.Append("  DISPOSITIVI_NOTI B ");
  SQL.Append("where (B.DEV_TOKEN = A.DEV_TOKEN) ");
  SQL.Append(")");
    PAN_DEVICETOKEN.SetFieldUnbound(PFL_DEVICETOKEN_DISPOSITNOTI, true);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DISPOSITNOTI, PPQRY_DEVICETOKEN1, SQL.ToString(), "DISNOTDEVTOK", 9, 1000, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 612, 32, 92, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 44);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_LIST, "Utente");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 4, 148, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_UTENTE, MyGlb.PANEL_FORM, "Utente");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_UTENTE, PAG_DEVICETOKEN_PRINCIPALE, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_UTENTE, PPQRY_DEVICETOKEN1, "A.DES_UTENTE", "DES_UTENTE", 5, 100, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 704, 32, 56, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 40);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_LIST, "Attivo");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 4, 124, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_ATTIVO, MyGlb.PANEL_FORM, "Attivo");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_ATTIVO, PAG_DEVICETOKEN_PRINCIPALE, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_ATTIVO, PPQRY_DEVICETOKEN1, "A.FLG_ATTIVO", "FLG_ATTIVO", 5, 1, 0, -1709);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_ATTIVO, (new IDVariant("S")), "Si", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_ATTIVO, (new IDVariant("N")), "No", "", "", -1);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 760, 32, 56, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 48);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_LIST, "Rim.");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 4, 172, 168, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_RIMOSSO, MyGlb.PANEL_FORM, "Rimosso");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_RIMOSSO, PAG_DEVICETOKEN_PRINCIPALE, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_RIMOSSO, PPQRY_DEVICETOKEN1, "A.FLG_RIMOSSO", "FLG_RIMOSSO", 5, 1, 0, -1709);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_RIMOSSO, (new IDVariant("N")), "No", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_RIMOSSO, (new IDVariant("S")), "Si", "", "", -1);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, 192, 32, 116, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, 92);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_LIST, "Data Ultimo Invio");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, 4, 196, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATAULTIINVI, MyGlb.PANEL_FORM, "Data Ultimo Invio");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATAULTIINVI, PAG_DEVICETOKEN_ALTRO, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATAULTIINVI, PPQRY_DEVICETOKEN1, "A.DAT_ULTIMO_INVIO", "DAT_ULTIMO_INVIO", 8, 19, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_LIST, 672, 32, 104, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_LIST, 84);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_LIST, "Data Cupertino");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_FORM, 4, 340, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATACUPERTIN, MyGlb.PANEL_FORM, "Data Cupertino");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATACUPERTIN, PAG_DEVICETOKEN_ALTRO, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATACUPERTIN, PPQRY_DEVICETOKEN1, "A.DATA_CUPERTINO", "DATA_CUPERTINO", 8, 61, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 308, 32, 204, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 32);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_LIST, "Nota");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 4, 220, 520, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_NOTA, MyGlb.PANEL_FORM, "Nota");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_NOTA, PAG_DEVICETOKEN_ALTRO, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_NOTA, PPQRY_DEVICETOKEN1, "A.DES_NOTA", "DES_NOTA", 5, 100, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_LIST, 512, 32, 132, 28, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_LIST, 68);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_LIST, "Custom TAG");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_FORM, 4, 292, 628, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_CUSTOMTAG, MyGlb.PANEL_FORM, "Custom TAG");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_CUSTOMTAG, PAG_DEVICETOKEN_ALTRO, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_CUSTOMTAG, PPQRY_DEVICETOKEN1, "A.CUSTOM_TAG", "CUSTOM_TAG", 5, 200, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 644, 32, 120, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 84);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_LIST, "Data Rimozione");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 4, 244, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_DATARIMOZION, MyGlb.PANEL_FORM, "Data Rimozione");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_DATARIMOZION, PAG_DEVICETOKEN_ALTRO, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_DATARIMOZION, PPQRY_DEVICETOKEN1, "A.DATA_RIMOZ", "DATA_RIMOZ", 8, 61, 0, -1709);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_LIST, 848, 32, 72, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_LIST, 52);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_LIST, "Type OS");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_FORM, 4, 316, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_TYPEOS, MyGlb.PANEL_FORM, "Type OS");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_TYPEOS, PAG_DEVICETOKEN_ALTRO, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_TYPEOS, PPQRY_DEVICETOKEN1, "A.TYPE_OS", "TYPE_OS", 5, 1, 0, -1709);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_TYPEOS, (new IDVariant("1")), "iOS", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_TYPEOS, (new IDVariant("2")), "Android", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_TYPEOS, (new IDVariant("3")), "Windows Phone", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_TYPEOS, (new IDVariant("4")), "Blackberry", "", "", -1);
    PAN_DEVICETOKEN.SetValueListItem(PFL_DEVICETOKEN_TYPEOS, (new IDVariant("5")), "Windows Store", "", "", -1);
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, 764, 32, 56, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, 52);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_LIST, "Id Ling.");
    PAN_DEVICETOKEN.SetRect(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, 4, 196, 252, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_DEVICETOKEN.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, 120);
    PAN_DEVICETOKEN.SetNumRow(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, 1);
    PAN_DEVICETOKEN.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_DEVICETOKEN_IDLINGUA, MyGlb.PANEL_FORM, "Id Lingua");
    PAN_DEVICETOKEN.SetFieldPage(PFL_DEVICETOKEN_IDLINGUA, PAG_DEVICETOKEN_ALTRO, -1);
    PAN_DEVICETOKEN.SetFieldPanel(PFL_DEVICETOKEN_IDLINGUA, PPQRY_DEVICETOKEN1, "A.PRG_LINGUA", "PRG_LINGUA", 1, 9, 0, -1709);
  }

  private void PAN_DEVICETOKEN_InitQueries()
  {
    StringBuilder SQL;

    PAN_DEVICETOKEN.SetSize(MyGlb.OBJ_QUERY, 3);
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
    PAN_DEVICETOKEN.SetQuery(PPQRY_APPLICAZIONI, 0, SQL, PFL_DEVICETOKEN_APPLICAZIONE, "97315832-EB41-4A19-A51B-BA1A83507866");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as IDAPPLICAZIO, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.TYPE_OS = '1') ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_APPLICAZIONI, 1, SQL, PFL_DEVICETOKEN_APPLICAZIONE, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_APPLICAZIONI, MainFrm.NotificatoreDBObject.DB, 256);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.PRG_LINGUA as IDLINGUA, ");
    SQL.Append("  A.DES_LINGUA as DESCRILINGUA ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    SQL.Append("where (A.PRG_LINGUA = ~~PRG_LINGUA~~) ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LINGUE, 0, SQL, PFL_DEVICETOKEN_IDLINGUA, "A1EC6927-A211-4955-9120-89A9015D11F8");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.PRG_LINGUA as IDLINGUA, ");
    SQL.Append("  A.DES_LINGUA as DESCRILINGUA ");
    SQL.Append("from ");
    SQL.Append("  LINGUE A ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_LINGUE, 1, SQL, PFL_DEVICETOKEN_IDLINGUA, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_LINGUE, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DEVICETOKEN.SetIMDB(IMDB, "PQRY_DEVICETOKEN1", true);
    PAN_DEVICETOKEN.set_SetString(MyGlb.MASTER_ROWNAME, "Device Token");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  A.DEV_TOKEN as DEV_TOKEN, ");
    SQL.Append("  A.DATA_ULT_ACCESSO as DATA_ULT_ACCESSO, ");
    SQL.Append("  A.DATA_CREAZIONE as DATA_CREAZIONE, ");
    SQL.Append("  A.FLG_ATTIVO as FLG_ATTIVO, ");
    SQL.Append("  A.DES_UTENTE as DES_UTENTE, ");
    SQL.Append("  A.FLG_RIMOSSO as FLG_RIMOSSO, ");
    SQL.Append("  A.DAT_ULTIMO_INVIO as DAT_ULTIMO_INVIO, ");
    SQL.Append("  A.DES_NOTA as DES_NOTA, ");
    SQL.Append("  A.ID_APPLICAZIONE as ID_APPLICAZIONE, ");
    SQL.Append("  A.DATA_RIMOZ as DATA_RIMOZ, ");
    SQL.Append("  A.CUSTOM_TAG as CUSTOM_TAG, ");
    SQL.Append("  A.TYPE_OS as TYPE_OS, ");
    SQL.Append("  A.DATA_CUPERTINO as DATA_CUPERTINO, ");
    SQL.Append("  ( ");
    SQL.Append("select ");
    SQL.Append("  B.DES_MESSAGGIO ");
    SQL.Append("from ");
    SQL.Append("  DISPOSITIVI_NOTI B ");
    SQL.Append("where (B.DEV_TOKEN = A.DEV_TOKEN) ");
    SQL.Append(") as DISNOTDEVTOK, ");
    SQL.Append("  A.PRG_LINGUA as PRG_LINGUA ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN1, 0, SQL, -1, "53F66555-FDCD-4758-A141-781DFCEEB020");
    SQL = new StringBuilder();
    SQL.Append("from ");
    SQL.Append("  DEV_TOKENS A ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN1, 1, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("where (A.TYPE_OS = '1') ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN1, 2, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN1, 3, SQL, -1, "");
    SQL = new StringBuilder();
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN1, 4, SQL, -1, "");
    SQL = new StringBuilder();
    SQL.Append("order by ");
    SQL.Append("  A.DATA_ULT_ACCESSO desc ");
    PAN_DEVICETOKEN.SetQuery(PPQRY_DEVICETOKEN1, 5, SQL, -1, "");
    PAN_DEVICETOKEN.SetQueryDB(PPQRY_DEVICETOKEN1, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_DEVICETOKEN.SetMasterTable(0, "DEV_TOKENS");
    PAN_DEVICETOKEN.AddToSortList(PFL_DEVICETOKEN_DATAULTIACCE, false);
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
    if (SrcObj == PAN_DEVICETOKEN) PAN_DEVICETOKEN_DynamicProperties();
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
