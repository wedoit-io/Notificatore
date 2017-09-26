// **********************************************
// Invio Notifiche A Dispoitivi Noti IOS
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
public partial class InvioNotificheADispoitiviNotiIOS : MyWebForm
{
  internal MyWebEntryPoint MainFrm;

  // Frame constant definitions
  private const int PFL_NUOVOPANNELL_APPLICAZIONE = 0;
  private const int PFL_NUOVOPANNELL_UTENTE = 1;
  private const int PFL_NUOVOPANNELL_SOUND = 2;
  private const int PFL_NUOVOPANNELL_BADGE = 3;
  private const int PFL_NUOVOPANNELL_CUSTOMFIELD1 = 4;
  private const int PFL_NUOVOPANNELL_CUSTOMFIELD2 = 5;
  private const int PFL_NUOVOPANNELL_MESSAGGIO = 6;
  private const int PFL_NUOVOPANNELL_BOTTONEINVIA = 7;
  private const int PFL_NUOVOPANNELL_AMBIENTE = 8;

  private const int PPQRY_NOTIFICHE2 = 0;

  private const int PPQRY_APPLICAZIONI = 1;
  private const int PPQRY_DEVICETOKEN = 2;


  internal IDPanel PAN_NUOVOPANNELL;

  // Definition of Global Variables

  
  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    Init_TBL_NOTIFICHE5(IMDB);
    //
    //
    Init_PQRY_NOTIFICHE2(IMDB);
    Init_PQRY_NOTIFICHE2_RS(IMDB);
  }

  // IMDB DDL Procedures
  private static void Init_TBL_NOTIFICHE5(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.TBL_NOTIFICHE5, 9);
    IMDB.set_TblCode(IMDBDef1.TBL_NOTIFICHE5, "TBL_NOTIFICHE5");
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_SQUADRA, "SQUADRA");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_SQUADRA,5,200,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_AMBIENNOTIFI, "AMBIENNOTIFI");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_AMBIENNOTIFI,5,1,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_MESSAGNOTIFI, "MESSAGNOTIFI");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_MESSAGNOTIFI,9,500,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_IDAPPLINOTIF, "IDAPPLINOTIF");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_IDAPPLINOTIF,1,52,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_SOUND, "SOUND");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_SOUND,5,200,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_BADGE, "BADGE");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_BADGE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_CUSTOM_FIELD1, "CUSTOM_FIELD1");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_CUSTOM_FIELD1,5,100,0);
    IMDB.set_FldCode(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_CUSTOM_FIELD2, "CUSTOM_FIELD2");
    IMDB.SetFldParams(IMDBDef1.TBL_NOTIFICHE5,IMDBDef1.FLD_NOTIFICHE5_CUSTOM_FIELD2,5,100,0);
    IMDB.TblAddNew(IMDBDef1.TBL_NOTIFICHE5, 0);
  }

  private static void Init_PQRY_NOTIFICHE2(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_NOTIFICHE2, 8);
    IMDB.set_TblCode(IMDBDef1.PQRY_NOTIFICHE2, "PQRY_NOTIFICHE2");
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI, "AMBIENNOTIFI");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_MESSAGNOTIFI, "MESSAGNOTIFI");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_MESSAGNOTIFI,9,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF, "IDAPPLINOTIF");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF,1,52,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_SOUND, "SOUND");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_SOUND,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_BADGE, "BADGE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_BADGE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_CUSTOM_FIELD1, "CUSTOM_FIELD1");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_CUSTOM_FIELD1,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_CUSTOM_FIELD2, "CUSTOM_FIELD2");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2,IMDBDef1.PQSL_NOTIFICHE2_CUSTOM_FIELD2,5,100,0);
    IMDB.TblAddNew(IMDBDef1.PQRY_NOTIFICHE2, 0);
  }

  private static void Init_PQRY_NOTIFICHE2_RS(IMDBObj IMDB)
  {
    IMDB.set_TblNumField(IMDBDef1.PQRY_NOTIFICHE2_RS, 8);
    IMDB.set_TblCode(IMDBDef1.PQRY_NOTIFICHE2_RS, "PQRY_NOTIFICHE2_RS");
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI, "AMBIENNOTIFI");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI,5,1,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_MESSAGNOTIFI, "MESSAGNOTIFI");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_MESSAGNOTIFI,9,500,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, "DES_UTENTE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF, "IDAPPLINOTIF");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF,1,52,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_SOUND, "SOUND");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_SOUND,5,200,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_BADGE, "BADGE");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_BADGE,1,9,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_CUSTOM_FIELD1, "CUSTOM_FIELD1");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_CUSTOM_FIELD1,5,100,0);
    IMDB.set_FldCode(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_CUSTOM_FIELD2, "CUSTOM_FIELD2");
    IMDB.SetFldParams(IMDBDef1.PQRY_NOTIFICHE2_RS,IMDBDef1.PQSL_NOTIFICHE2_CUSTOM_FIELD2,5,100,0);
  }



  // **********************************************
  // Costruttore per form multiple
  // **********************************************
  public InvioNotificheADispoitiviNotiIOS(MyWebEntryPoint w, IMDBObj imdb)
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
  public InvioNotificheADispoitiviNotiIOS()
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
    FormIdx = MyGlb.FRM_INVNOADINOIO;
    //
    if (flMulti)
      MainFrm.AddMultipleForm(this, flSubForm);
    //
    //
    RTCGuid = "467E0147-90A6-4D1B-BF1F-FC18331D5DF0";
    ResModeW = 1;
    ResModeH = 1;
    iVisualFlags = -2139;
    DesignWidth = 504;
    DesignHeight = 464;
    set_Caption(new IDVariant("Invio Notifiche A Dispoitivi Noti IOS"));
    //
    Frames = new AFrame[2];
    Frames[1] = new AFrame(1);
    Frames[1].Parent = this;
    Frames[1].Width = 504;
    Frames[1].Height = 404;
    Frames[1].FrHidden = true;
    Frames[1].Caption = "Nuovo Pannello";
    Frames[1].Parent = this;
    Frames[1].FixedHeight = 404;
    PAN_NUOVOPANNELL = new IDPanel(w, this, 1, "PAN_NUOVOPANNELL");
    Frames[1].Content = PAN_NUOVOPANNELL;
    PAN_NUOVOPANNELL.set_VisualFlag(Glb.PANVISPROP_HILITEROW,true);
    PAN_NUOVOPANNELL.VS = MainFrm.VisualStyleList;
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_RECT, 0, 0, 0, 0, 504-MyGlb.PAN_OFFS_X, 404-MyGlb.PAN_OFFS_Y, 0, 0);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_PANEL, 0, "74216C25-D5C7-4C49-8FC7-3C0E29B72341");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_PANEL, 0, 0, 0, 0, 2768, 336, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_STRETCH);
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_PANEL, 0, MyGlb.VIS_DEFAPANESTYL);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_PANEL, 0, 0, 32);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_PANEL, 0, MainFrm.GlbPanelFlags | MyGlb.PAN_SCROLLREC | MyGlb.PAN_HASFORM | MyGlb.PAN_STARTFORM | MyGlb.PAN_CANDELETE | MyGlb.PAN_CANUPDATE | MyGlb.PAN_CANSELECT | MyGlb.PAN_CANINSERT | MyGlb.PAN_AUTOSAVE | MyGlb.OBJ_VISIBLE | MyGlb.OBJ_ENABLED, -1);
    PAN_NUOVOPANNELL.InitStatus = 3;
    PAN_NUOVOPANNELL_Init();
    PAN_NUOVOPANNELL_InitFields();
    PAN_NUOVOPANNELL_InitQueries();
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
      if (IMDB.TblModified(IMDBDef1.TBL_NOTIFICHE5, MyGlb.GlbRefModIdx) || JustLoaded)
      {
        INVNOADINOIO_NOTIFICHE2();
      }
      PAN_NUOVOPANNELL.UpdatePanel(MainFrm);
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
    return (obj is InvioNotificheADispoitiviNotiIOS);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(InvioNotificheADispoitiviNotiIOS).FullName : typeof(InvioNotificheADispoitiviNotiIOS).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************	
  // **********************************************************************
  // Lancia Invio Notifica
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  private int LanciaInvioNotifica ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("73095CE8-CADE-4956-95A0-A4356BC3E954", "Lancia Invio Notifica", "", 3, "Invio Notifiche A Dispoitivi Noti IOS")) return 0;
      // 
      // Lancia Invio Notifica Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddSubProc ("77E1A6A9-4DC8-42E3-8042-050C88A0AD0A", "Nuovo Pannello.Update Data", "");
      PAN_NUOVOPANNELL.PanelCommand(Glb.PCM_UPDATE);
      MainFrm.DTTObj.AddIf ("F99D28C2-2B24-4415-8EE5-8C4356C06BFF", "IF Is Null (Utente Record [Invio Notifiche A Dispoitivi Noti IOS - Nuovo Pannello])", "");
      MainFrm.DTTObj.AddToken ("F99D28C2-2B24-4415-8EE5-8C4356C06BFF", "0AD49410-3DAE-4FAF-9407-F377A19E4494", 917504, "Utente", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, 0));
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, 0)))
      {
        MainFrm.DTTObj.EnterIf ("F99D28C2-2B24-4415-8EE5-8C4356C06BFF", "IF Is Null (Utente Record [Invio Notifiche A Dispoitivi Noti IOS - Nuovo Pannello])", "");
        MainFrm.DTTObj.AddSubProc ("985FC1AC-5383-4AA4-B247-DF9D2D6D27E2", "Notificatore.Message Box", "");
        MainFrm.DTTObj.AddParameter ("985FC1AC-5383-4AA4-B247-DF9D2D6D27E2", "F72A9AA9-7454-44AF-BC07-5BCDD9C7CB40", "Messaggio", (new IDVariant("Scegli un utente")));
        MainFrm.set_AlertMessage((new IDVariant("Scegli un utente"))); 
        MainFrm.DTTObj.ExitProc ("73095CE8-CADE-4956-95A0-A4356BC3E954", "Lancia Invio Notifica", "Spiega quale elaborazione viene eseguita da questa procedura", 3, "Invio Notifiche A Dispoitivi Noti IOS");
        return 0;
      }
      MainFrm.DTTObj.EndIfBlk ("F99D28C2-2B24-4415-8EE5-8C4356C06BFF");
      // 
      // Ho inserito un testo?
      // 
      IDVariant v_VAUTHKEYAPPL = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VCHIAVEAPPLI = new IDVariant(0,IDVariant.STRING);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  B.AUTH_KEY as AUTHKEYAPPS, ");
      SQL.Append("  B.APP_KEY as CHIAVEAPPS ");
      SQL.Append("from ");
      SQL.Append("  APPS_PUSH_SETTING A, ");
      SQL.Append("  APPS B ");
      SQL.Append("where B.ID = A.ID_APP ");
      SQL.Append("and   (A.ID = " + IDL.CSql(IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF, 0), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      MainFrm.DTTObj.AddQuery ("8634997D-4C45-42E2-AB91-718E433A337C", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("8634997D-4C45-42E2-AB91-718E433A337C");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        v_VAUTHKEYAPPL = QV.Get("AUTHKEYAPPS", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("8634997D-4C45-42E2-AB91-718E433A337C", "E900FC69-FD76-463B-9E1C-90AE3DA8D00C", 1376256, "V Auth Key Applicazione", v_VAUTHKEYAPPL);
        v_VCHIAVEAPPLI = QV.Get("CHIAVEAPPS", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("8634997D-4C45-42E2-AB91-718E433A337C", "4D84C940-BB99-4924-8A62-A3DD2118D990", 1376256, "v Chiave Applicazione", v_VCHIAVEAPPLI);
      }
      QV.Close();
      IDVariant v_SUTENTE = new IDVariant(0,IDVariant.STRING);
      MainFrm.DTTObj.AddIf ("4FBA4EEB-CCCE-4B21-90E6-209D46A6EED6", "IF Utente Record [Invio Notifiche A Dispoitivi Noti IOS - Nuovo Pannello] != \"[Tutti gli utenti]\"", "");
      MainFrm.DTTObj.AddToken ("4FBA4EEB-CCCE-4B21-90E6-209D46A6EED6", "0AD49410-3DAE-4FAF-9407-F377A19E4494", 917504, "Utente", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, 0));
      if (IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, 0).compareTo((new IDVariant("[Tutti gli utenti]")), true)!=0)
      {
        MainFrm.DTTObj.EnterIf ("4FBA4EEB-CCCE-4B21-90E6-209D46A6EED6", "IF Utente Record [Invio Notifiche A Dispoitivi Noti IOS - Nuovo Pannello] != \"[Tutti gli utenti]\"", "");
        MainFrm.DTTObj.AddAssign ("4048C8FB-024D-4AA7-A785-4BEC8C91A29C", "s Utente := Utente Record [Invio Notifiche A Dispoitivi Noti IOS - Nuovo Pannello]", "", v_SUTENTE);
        MainFrm.DTTObj.AddToken ("4048C8FB-024D-4AA7-A785-4BEC8C91A29C", "0AD49410-3DAE-4FAF-9407-F377A19E4494", 917504, "Utente", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, 0));
        v_SUTENTE = IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, 0);
        MainFrm.DTTObj.AddAssignNewValue ("4048C8FB-024D-4AA7-A785-4BEC8C91A29C", "48FA01B4-D4D1-45AC-A8FB-A9B999ACE487", v_SUTENTE);
      }
      MainFrm.DTTObj.EndIfBlk ("4FBA4EEB-CCCE-4B21-90E6-209D46A6EED6");
      // 
      // Invio della notifica push
      // 
      NotificatoreWS.Notificatore N = null;
      MainFrm.DTTObj.AddAssign ("B401F355-D89D-4B7A-9C5F-1C42839A41AA", "n := new ()", "Invio della notifica push", N);
      N = (NotificatoreWS.Notificatore)new NotificatoreWS.Notificatore(); N.Url = (String)MainFrm.WebServicesUrl["NotificatoreWS"]; N.NameSpace = "http://www.progamma.com";
      MainFrm.DTTObj.AddAssignNewValue ("B401F355-D89D-4B7A-9C5F-1C42839A41AA", "B7CD05DB-A583-47EE-8E3C-9DE4B4529E09", N);
      MainFrm.DTTObj.AddAssign ("FDD6B100-90A4-4B0A-807C-DE3B65317C33", "n.Url := Glb WS Url Notificatore", "", N.Url);
      MainFrm.DTTObj.AddToken ("FDD6B100-90A4-4B0A-807C-DE3B65317C33", "10ADFF3C-9D96-4180-92DE-D5CA73B4ADA5", 1376256, "Glb WS Url", new IDVariant(MainFrm.GLBWSURL));
      N.Url = new IDVariant(MainFrm.GLBWSURL).stringValue();
      MainFrm.DTTObj.AddAssignNewValue ("FDD6B100-90A4-4B0A-807C-DE3B65317C33", "B7CD05DB-A583-47EE-8E3C-9DE4B4529E09", N.Url);
      IDVariant S = null;
      MainFrm.DTTObj.AddAssign ("F46EC56F-DB15-460B-94D7-FDD3D2A98840", "s := n.Send Notification (V Auth Key Applicazione, v Chiave Applicazione, Messaggio Notifica Record [Invio Notifiche A Dispoitivi Noti IOS - Nuovo Pannello], Utente Record [Invio Notifiche A Dispoitivi Noti IOS - Nuovo Pannello], Sound Reco", "", S);
      MainFrm.DTTObj.AddToken ("F46EC56F-DB15-460B-94D7-FDD3D2A98840", "E900FC69-FD76-463B-9E1C-90AE3DA8D00C", 1376256, "V Auth Key Applicazione", v_VAUTHKEYAPPL);
      MainFrm.DTTObj.AddToken ("F46EC56F-DB15-460B-94D7-FDD3D2A98840", "4D84C940-BB99-4924-8A62-A3DD2118D990", 1376256, "v Chiave Applicazione", v_VCHIAVEAPPLI);
      MainFrm.DTTObj.AddToken ("F46EC56F-DB15-460B-94D7-FDD3D2A98840", "4BF8523F-C9E7-4395-92F4-1D026882EC2D", 917504, "Messaggio Notifica", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_MESSAGNOTIFI, 0));
      MainFrm.DTTObj.AddToken ("F46EC56F-DB15-460B-94D7-FDD3D2A98840", "0AD49410-3DAE-4FAF-9407-F377A19E4494", 917504, "Utente", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, 0));
      MainFrm.DTTObj.AddToken ("F46EC56F-DB15-460B-94D7-FDD3D2A98840", "D82742FC-78CD-4E60-99DD-474BF42C6A29", 917504, "Sound", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_SOUND, 0));
      MainFrm.DTTObj.AddToken ("F46EC56F-DB15-460B-94D7-FDD3D2A98840", "7761AFEC-B2E6-4466-BBFF-C47F80612903", 917504, "Badge", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_BADGE, 0));
      S = N.SendNotification_ws(v_VAUTHKEYAPPL, v_VCHIAVEAPPLI, IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_MESSAGNOTIFI, 0), IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_DES_UTENTE, 0), IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_SOUND, 0), IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_BADGE, 0));
      MainFrm.DTTObj.AddAssignNewValue ("F46EC56F-DB15-460B-94D7-FDD3D2A98840", "24E7A487-F5FF-46C5-BA7A-D2850849848C", S);
      MainFrm.DTTObj.AddIf ("60CDDE0D-EEB7-41E0-A7BB-A65BFF3FF743", "IF s != \"\"", "");
      MainFrm.DTTObj.AddToken ("60CDDE0D-EEB7-41E0-A7BB-A65BFF3FF743", "24E7A487-F5FF-46C5-BA7A-D2850849848C", 1376256, "s", S);
      if (S.compareTo((new IDVariant("")), true)!=0)
      {
        MainFrm.DTTObj.EnterIf ("60CDDE0D-EEB7-41E0-A7BB-A65BFF3FF743", "IF s != \"\"", "");
        MainFrm.DTTObj.AddSubProc ("C7F97A23-43D9-49C7-998F-AB36A7889CE0", "Notificatore.Message Box", "");
        MainFrm.DTTObj.AddParameter ("C7F97A23-43D9-49C7-998F-AB36A7889CE0", "5433794B-FB0E-4673-85DF-D24465526142", "Messaggio", S);
        MainFrm.set_AlertMessage(S); 
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("01CCEB82-8EDA-428F-A4DD-FD4D81E2C233", "ELSE", "", "60CDDE0D-EEB7-41E0-A7BB-A65BFF3FF743");
        MainFrm.DTTObj.AddSubProc ("785B6DE4-A772-463D-860D-E8588B84A7E4", "Notificatore.Message Box", "");
        MainFrm.DTTObj.AddParameter ("785B6DE4-A772-463D-860D-E8588B84A7E4", "1883C4B7-F9A5-47E6-9439-0BDB510810FB", "Messaggio", (new IDVariant("Invio messaggio in coda")));
        MainFrm.set_AlertMessage((new IDVariant("Invio messaggio in coda"))); 
      }
      MainFrm.DTTObj.EndIfBlk ("60CDDE0D-EEB7-41E0-A7BB-A65BFF3FF743");
      MainFrm.DTTObj.ExitProc("73095CE8-CADE-4956-95A0-A4356BC3E954", "Lancia Invio Notifica", "", 3, "Invio Notifiche A Dispoitivi Noti IOS");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("73095CE8-CADE-4956-95A0-A4356BC3E954", "Lancia Invio Notifica", "", _e);
      MainFrm.ErrObj.ProcError ("InvioNotificheADispoitiviNotiIOS", "LanciaInvioNotifica", _e);
      MainFrm.DTTObj.ExitProc("73095CE8-CADE-4956-95A0-A4356BC3E954", "Lancia Invio Notifica", "", 3, "Invio Notifiche A Dispoitivi Noti IOS");
      return -1;
    }
  }

  // **********************************************************************
  // Start Form
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // ID Apps Push Settings - Input
  // **********************************************************************
  public int StartForm (IDVariant IDAppsPushSettings)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("F634F90A-AA44-44F4-8BBB-A16CD586585E", "Start Form", "", 3, "Invio Notifiche A Dispoitivi Noti IOS")) return 0;
      MainFrm.DTTObj.AddParameter ("F634F90A-AA44-44F4-8BBB-A16CD586585E", "E0B5B19E-8615-434F-A87B-80CFBC03FF20", "ID Apps Push Settings", IDAppsPushSettings);
      // 
      // Start Form Body
      // Corpo Procedura
      // 
      IDVariant v_VAMBAPPPUSSE = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VIDAPPPUSSET = new IDVariant(0,IDVariant.INTEGER);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.FLG_AMBIENTE as AMBIENTE, ");
      SQL.Append("  A.ID as ID ");
      SQL.Append("from ");
      SQL.Append("  APPS_PUSH_SETTING A ");
      SQL.Append("where (A.ID = " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      MainFrm.DTTObj.AddQuery ("10DEB566-A98C-4444-BF48-2C5A9735E69D", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("10DEB566-A98C-4444-BF48-2C5A9735E69D");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        v_VAMBAPPPUSSE = QV.Get("AMBIENTE", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("10DEB566-A98C-4444-BF48-2C5A9735E69D", "321AF1CD-6D94-4FE3-8EE8-1FA2AA31AED7", 1376256, "v Ambiente Apps Push Settings", v_VAMBAPPPUSSE);
        v_VIDAPPPUSSET = QV.Get("ID", IDVariant.INTEGER) ;
        MainFrm.DTTObj.AddToken ("10DEB566-A98C-4444-BF48-2C5A9735E69D", "9B5C3F7E-750C-4F6B-828D-4500EB3EA3AC", 1376256, "v ID Apps Push Settings", v_VIDAPPPUSSET);
      }
      QV.Close();
      MainFrm.DTTObj.AddAssign ("D592C1D6-E39C-495F-9909-F481114D8819", "Applicazione Record [Invio Notifiche A Dispoitivi Noti IOS - Nuovo Pannello] := v ID Apps Push Settings", "", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF, 0));
      MainFrm.DTTObj.AddToken ("D592C1D6-E39C-495F-9909-F481114D8819", "9B5C3F7E-750C-4F6B-828D-4500EB3EA3AC", 1376256, "v ID Apps Push Settings", new IDVariant(v_VIDAPPPUSSET));
      IMDB.set_Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF, 0, new IDVariant(v_VIDAPPPUSSET));
      MainFrm.DTTObj.AddAssignNewValue ("D592C1D6-E39C-495F-9909-F481114D8819", "D471205F-F7ED-453F-AE51-BCE393E3D099", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_IDAPPLINOTIF, 0));
      MainFrm.DTTObj.AddAssign ("39E73491-D934-4CE5-9757-48F22EDE2631", "Ambiente Notifica Record [Invio Notifiche A Dispoitivi Noti IOS - Nuovo Pannello] := v Ambiente Apps Push Settings", "", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI, 0));
      MainFrm.DTTObj.AddToken ("39E73491-D934-4CE5-9757-48F22EDE2631", "321AF1CD-6D94-4FE3-8EE8-1FA2AA31AED7", 1376256, "v Ambiente Apps Push Settings", new IDVariant(v_VAMBAPPPUSSE));
      IMDB.set_Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI, 0, new IDVariant(v_VAMBAPPPUSSE));
      MainFrm.DTTObj.AddAssignNewValue ("39E73491-D934-4CE5-9757-48F22EDE2631", "E405EEBD-FE90-45F4-8FB4-EF5AEF4B7D9A", IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI, 0));
      MainFrm.DTTObj.ExitProc("F634F90A-AA44-44F4-8BBB-A16CD586585E", "Start Form", "", 3, "Invio Notifiche A Dispoitivi Noti IOS");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("F634F90A-AA44-44F4-8BBB-A16CD586585E", "Start Form", "", _e);
      MainFrm.ErrObj.ProcError ("InvioNotificheADispoitiviNotiIOS", "StartForm", _e);
      MainFrm.DTTObj.ExitProc("F634F90A-AA44-44F4-8BBB-A16CD586585E", "Start Form", "", 3, "Invio Notifiche A Dispoitivi Noti IOS");
      return -1;
    }
  }

  // **********************************************************************
  // Unload
  // Evento notificato dal form prima della chiusura dello
  // stesso
  // Cancel - Input/Output
  // Confirm - Input
  // **********************************************************************
  public override void IntFormUnload (IDVariant Cancel, IDVariant Confirm)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("8A0A5B16-456D-4610-B17A-48A0425520E9", "Unload", "", 0, "Invio Notifiche A Dispoitivi Noti IOS")) return;
      MainFrm.DTTObj.AddParameter ("8A0A5B16-456D-4610-B17A-48A0425520E9", "026943BA-3201-4EA6-A721-155D9A6158F9", "Cancel", Cancel);
      MainFrm.DTTObj.AddParameter ("8A0A5B16-456D-4610-B17A-48A0425520E9", "E68C0035-1DF7-4600-9069-DAFD4299650B", "Confirm", Confirm);
      // 
      // Unload Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddQuery ("6CD160CB-47AA-47C9-9F44-058A7B40BDEE", "Notifiche: Delete", "", 256, "");
      UNLOAD_NOTIFIDELETE();
      MainFrm.DTTObj.EndQuery ("6CD160CB-47AA-47C9-9F44-058A7B40BDEE");
      MainFrm.DTTObj.AddAssign ("7D95D7AF-6072-41A1-8A40-7AA24053BEEB", "Sound Nuovo Pannello [Invio Notifiche A Dispoitivi Noti IOS - Nuovo Pannello].Text := C\"default\"", "", PAN_NUOVOPANNELL.FieldText(PFL_NUOVOPANNELL_SOUND));
      PAN_NUOVOPANNELL.set_FieldText(PFL_NUOVOPANNELL_SOUND, (new IDVariant("default")).stringValue());
      MainFrm.DTTObj.AddAssignNewValue ("7D95D7AF-6072-41A1-8A40-7AA24053BEEB", "66BC0846-4CBD-43B0-AEBE-F2D2E0F17696", PAN_NUOVOPANNELL.FieldText(PFL_NUOVOPANNELL_SOUND));
      MainFrm.DTTObj.AddAssign ("0B8B2AAE-1171-4B5E-9267-D48472692245", "Badge Nuovo Pannello [Invio Notifiche A Dispoitivi Noti IOS - Nuovo Pannello].Text := C\"0\"", "", PAN_NUOVOPANNELL.FieldText(PFL_NUOVOPANNELL_BADGE));
      PAN_NUOVOPANNELL.set_FieldText(PFL_NUOVOPANNELL_BADGE, (new IDVariant("0")).stringValue());
      MainFrm.DTTObj.AddAssignNewValue ("0B8B2AAE-1171-4B5E-9267-D48472692245", "37980AD2-F800-4869-85F7-FE50A7AE9D1A", PAN_NUOVOPANNELL.FieldText(PFL_NUOVOPANNELL_BADGE));
      MainFrm.DTTObj.ExitProc("8A0A5B16-456D-4610-B17A-48A0425520E9", "Unload", "", 0, "Invio Notifiche A Dispoitivi Noti IOS");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("8A0A5B16-456D-4610-B17A-48A0425520E9", "Unload", "", _e);
      MainFrm.ErrObj.ProcError ("InvioNotificheADispoitiviNotiIOS", "Unload", _e);
      MainFrm.DTTObj.ExitProc("8A0A5B16-456D-4610-B17A-48A0425520E9", "Unload", "", 0, "Invio Notifiche A Dispoitivi Noti IOS");
    }
  }

  // **********************************************************************
  // Notifiche: Delete
  // Perchè stai eliminando questi dati?
  // **********************************************************************
  private void UNLOAD_NOTIFIDELETE()
  {
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_SQUADRA, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_AMBIENNOTIFI, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_MESSAGNOTIFI, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_DES_UTENTE, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_IDAPPLINOTIF, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_SOUND, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_BADGE, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_CUSTOM_FIELD1, 0, new IDVariant());
    IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_CUSTOM_FIELD2, 0, new IDVariant());
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

      if (!MainFrm.DTTObj.EnterProc("4F32CF63-37A5-45A9-BE0A-84B3ED11CFCD", "Load", "", 0, "Invio Notifiche A Dispoitivi Noti IOS")) return;
      // 
      // Load Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddAssign ("D8312EEB-C6FA-4C24-BC94-BE7756D18B51", "Badge Spedizione Notifica := C0", "", IMDB.Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_BADGE, 0));
      IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_BADGE, 0, (new IDVariant(0)));
      MainFrm.DTTObj.AddAssignNewValue ("D8312EEB-C6FA-4C24-BC94-BE7756D18B51", "37E5ABF8-B4D0-4075-9738-4E72B8E40201", IMDB.Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_BADGE, 0));
      MainFrm.DTTObj.AddAssign ("4C369F63-135E-4304-9961-A9B50B0C717E", "Sound Spedizione Notifica := C\"default\"", "", IMDB.Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_SOUND, 0));
      IMDB.set_Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_SOUND, 0, (new IDVariant("default")));
      MainFrm.DTTObj.AddAssignNewValue ("4C369F63-135E-4304-9961-A9B50B0C717E", "7C7E8421-D9CC-496A-8773-7B9968152F01", IMDB.Value(IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_SOUND, 0));
      MainFrm.DTTObj.ExitProc("4F32CF63-37A5-45A9-BE0A-84B3ED11CFCD", "Load", "", 0, "Invio Notifiche A Dispoitivi Noti IOS");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("4F32CF63-37A5-45A9-BE0A-84B3ED11CFCD", "Load", "", _e);
      MainFrm.ErrObj.ProcError ("InvioNotificheADispoitiviNotiIOS", "Load", _e);
      MainFrm.DTTObj.ExitProc("4F32CF63-37A5-45A9-BE0A-84B3ED11CFCD", "Load", "", 0, "Invio Notifiche A Dispoitivi Noti IOS");
    }
  }

  // **********************************************************************
  // Notifiche
  // Recupera i record da mostrare nel pannello
  // **********************************************************************
  private void INVNOADINOIO_NOTIFICHE2()
  {
    IDVariant[] AggrBuff;
    int[] AggrRowCount;
    int AggrCount=0;
    bool AggrNewGroup = false;

    IMDB.TblTruncate(IMDBDef1.PQRY_NOTIFICHE2_RS);
    IMDB.TblMoveFirst(IMDBDef1.TBL_NOTIFICHE5, 0);
    Loop1: while (!IMDB.Eof(IMDBDef1.TBL_NOTIFICHE5, 0))
    {
      IMDB.TblAddNew(IMDBDef1.PQRY_NOTIFICHE2_RS, 0);
      IMDB.TblLinkRow(IMDBDef1.PQRY_NOTIFICHE2_RS, 0, IMDBDef1.TBL_NOTIFICHE5, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 0, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_AMBIENNOTIFI, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 1, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_MESSAGNOTIFI, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 2, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_DES_UTENTE, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 3, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_IDAPPLINOTIF, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 4, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_SOUND, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 5, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_BADGE, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 6, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_CUSTOM_FIELD1, 0);
      IMDB.TblLinkField(IMDBDef1.PQRY_NOTIFICHE2_RS, 7, 0, IMDBDef1.TBL_NOTIFICHE5, IMDBDef1.FLD_NOTIFICHE5_CUSTOM_FIELD2, 0);
      IMDB.TblMoveNext(IMDBDef1.TBL_NOTIFICHE5, 0);
      if (IMDB.Eof(IMDBDef1.TBL_NOTIFICHE5, 0))
      {
        IMDB.TblMoveFirst(IMDBDef1.TBL_NOTIFICHE5, 0);
      }
      else
      {
        goto Loop1;
      }
      break;
    }
    IMDB.TblMoveFirst(IMDBDef1.PQRY_NOTIFICHE2_RS, 0);
  }



  // **********************************************
  // Event Stubs
  // **********************************************	
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
  private void PAN_NUOVOPANNELL_CellActivated(IDVariant ColIndex, IDVariant Cancel)
  {
    int i = 0;
    if (ColIndex.intValue() == PFL_NUOVOPANNELL_BOTTONEINVIA)
    {
      this.IdxPanelActived = this.PAN_NUOVOPANNELL.FrIndex;
      this.IdxFieldActived = ColIndex.intValue();
      LanciaInvioNotifica();
      Cancel.set(IDVariant.TRUE);
    }
  }

  private void PAN_NUOVOPANNELL_ValidateCell(IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    try
    {
    }
    catch(Exception e) {}
  }

  private void PAN_NUOVOPANNELL_ValidateRow(IDVariant Cancel)
  {
    try
    {
      if (IDL.IsNull(IMDB.Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI, 0)))
      {
        IMDB.set_Value(IMDBDef1.PQRY_NOTIFICHE2, IMDBDef1.PQSL_NOTIFICHE2_AMBIENNOTIFI, 0, (new IDVariant("S")));
      }
    } catch ( Exception e) { }
  }



  // **********************************************
  // Panel (long) initialization
  // **********************************************
  private void PAN_NUOVOPANNELL_Init()
  {

    PAN_NUOVOPANNELL.SetSize(MyGlb.OBJ_PAGE, 0);
    PAN_NUOVOPANNELL.SetSize(MyGlb.OBJ_GROUP, 0);
    PAN_NUOVOPANNELL.SetSize(MyGlb.OBJ_FIELD, 9);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, "D356D899-A5D7-4641-9BA4-504B7733B870");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, "Applicazione");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, 0 | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, "0AC3B8D1-3F4A-4845-942F-7C51D3168252");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, "Utente");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_AUTOLOOKUP | MyGlb.FLD_ACTIVE | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, "66BC0846-4CBD-43B0-AEBE-F2D2E0F17696");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, "Sound");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, "37980AD2-F800-4869-85F7-FE50A7AE9D1A");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, "Badge");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, "5C8C8607-7726-4130-BE6D-7A8AAB7D398E");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, "Custom field 1");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, "8BDBB009-A0E8-4F64-BC58-2ACBC416758C");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, "Custom Field 2");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, "99050360-1147-49D3-A454-882D21ACD23E");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, "Messaggio");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, "Messaggio da inviare");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_LISTLIST | MyGlb.FLD_INLIST | MyGlb.FLD_INFORM | MyGlb.FLD_VERTHDRFORM | MyGlb.FLD_ISOPT, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, "64F514C4-8D81-4E6A-B0B3-F025B851E49B");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, "Invia");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.VIS_COMMANBUTTO1);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, 0 | MyGlb.OBJ_ENABLED | MyGlb.OBJ_VISIBLE | MyGlb.FLD_INFORM | MyGlb.FLD_NOACTD | MyGlb.FLD_CANACTIVATE, -1);
    PAN_NUOVOPANNELL.SetRTCGuid(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, "959A94B6-ECDC-4BD3-B042-D036B6C820E7");
    PAN_NUOVOPANNELL.set_Header(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, "Ambiente");
    PAN_NUOVOPANNELL.set_ToolTip(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, "");
    PAN_NUOVOPANNELL.set_VisualStyle(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.VIS_NORMALFIELDS);
    PAN_NUOVOPANNELL.SetFlags(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, 0 | MyGlb.FLD_ISOPT, -1);
  }

  private void PAN_NUOVOPANNELL_InitFields()
  {

    StringBuilder SQL = new StringBuilder();
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_LIST, 0, 32, 268, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_LIST, 84);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_LIST, "Applicazione");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_FORM, 12, 24, 460, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_FORM, 96);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_APPLICAZIONE, MyGlb.PANEL_FORM, "Applicazione");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_APPLICAZIONE, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_APPLICAZIONE, PPQRY_NOTIFICHE2, "A.IDAPPLINOTIF", "IDAPPLINOTIF", 1, 52, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_LIST, 0, 32, 508, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_LIST, 108);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_LIST, "Utente");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_FORM, 12, 56, 460, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_FORM, 96);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_UTENTE, MyGlb.PANEL_FORM, "Utente");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_UTENTE, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_UTENTE, PPQRY_NOTIFICHE2, "A.DES_UTENTE", "DES_UTENTE", 5, 100, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_LIST, 0, 32, 504, 32, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_LIST, 92);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_LIST, "Sound");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_FORM, 12, 88, 352, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_FORM, 96);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_SOUND, MyGlb.PANEL_FORM, "Sound");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_SOUND, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_SOUND, PPQRY_NOTIFICHE2, "A.SOUND", "SOUND", 5, 200, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_LIST, 0, 32, 92, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_LIST, 92);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_LIST, "Badge");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_FORM, 368, 88, 104, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_FORM, 44);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BADGE, MyGlb.PANEL_FORM, "Badge");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_BADGE, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_BADGE, PPQRY_NOTIFICHE2, "A.BADGE", "BADGE", 1, 9, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_LIST, 0, 32, 508, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_LIST, 132);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_LIST, "Custom field 1");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_FORM, 12, 120, 460, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_FORM, 96);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD1, MyGlb.PANEL_FORM, "Custom field 1");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_CUSTOMFIELD1, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_CUSTOMFIELD1, PPQRY_NOTIFICHE2, "A.CUSTOM_FIELD1", "CUSTOM_FIELD1", 5, 100, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_LIST, 0, 32, 508, 20, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_LIST, 132);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_LIST, "Custom Field 2");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_FORM, 12, 152, 460, 28, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_FORM, 96);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_CUSTOMFIELD2, MyGlb.PANEL_FORM, "Custom Field 2");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_CUSTOMFIELD2, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_CUSTOMFIELD2, PPQRY_NOTIFICHE2, "A.CUSTOM_FIELD2", "CUSTOM_FIELD2", 5, 100, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_LIST, 0, 32, 380, 32, MyGlb.RESMODE_STRETCH, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_LIST, 60);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_LIST, "Messaggio");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_FORM, 12, 184, 460, 132, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_FORM, 20);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_FORM, 6);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_MESSAGGIO, MyGlb.PANEL_FORM, "Messaggio");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_MESSAGGIO, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_MESSAGGIO, PPQRY_NOTIFICHE2, "A.MESSAGNOTIFI", "MESSAGNOTIFI", 9, 500, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_LIST, 312, 204, 80, 32, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_LIST, 0);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_LIST, 2);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_FORM, 364, 328, 108, 36, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_FORM, 0);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_BOTTONEINVIA, MyGlb.PANEL_FORM, 2);
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_BOTTONEINVIA, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_BOTTONEINVIA, -1, "", "BOTTONEINVIA", 0, 0, 0, -1709);
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_LIST, 0, 32, 56, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_LIST, 56);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_LIST, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_LIST, "Ambien.");
    PAN_NUOVOPANNELL.SetRect(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_FORM, 4, 272, 100, 20, MyGlb.RESMODE_NONE, MyGlb.RESMODE_NONE);
    PAN_NUOVOPANNELL.SetHeaderSize(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_FORM, 56);
    PAN_NUOVOPANNELL.SetNumRow(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_FORM, 1);
    PAN_NUOVOPANNELL.SetAbbrHeader(MyGlb.OBJ_FIELD, PFL_NUOVOPANNELL_AMBIENTE, MyGlb.PANEL_FORM, "Ambien.");
    PAN_NUOVOPANNELL.SetFieldPage(PFL_NUOVOPANNELL_AMBIENTE, -1, -1);
    PAN_NUOVOPANNELL.SetFieldPanel(PFL_NUOVOPANNELL_AMBIENTE, PPQRY_NOTIFICHE2, "A.AMBIENNOTIFI", "AMBIENNOTIFI", 5, 1, 0, -1709);
    PAN_NUOVOPANNELL.SetValueListItem(PFL_NUOVOPANNELL_AMBIENTE, (new IDVariant("S")), "Sviluppo", "", "", -1);
    PAN_NUOVOPANNELL.SetValueListItem(PFL_NUOVOPANNELL_AMBIENTE, (new IDVariant("P")), "Produzione", "", "", -1);
  }

  private void PAN_NUOVOPANNELL_InitQueries()
  {
    StringBuilder SQL;

    PAN_NUOVOPANNELL.SetSize(MyGlb.OBJ_QUERY, 3);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.ID = ~~IDAPPLINOTIF~~) ");
    SQL.Append("and   (A.TYPE_OS = '1') ");
    PAN_NUOVOPANNELL.SetQuery(PPQRY_APPLICAZIONI, 0, SQL, PFL_NUOVOPANNELL_APPLICAZIONE, "057024E4-3BD4-4007-BAA5-E2572FC09954");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  A.ID as ID, ");
    SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
    SQL.Append("from ");
    SQL.Append("  APPS_PUSH_SETTING A, ");
    SQL.Append("  APPS B ");
    SQL.Append("where B.ID = A.ID_APP ");
    SQL.Append("and   (A.TYPE_OS = '1') ");
    PAN_NUOVOPANNELL.SetQuery(PPQRY_APPLICAZIONI, 1, SQL, PFL_NUOVOPANNELL_APPLICAZIONE, "");
    PAN_NUOVOPANNELL.SetQueryDB(PPQRY_APPLICAZIONI, MainFrm.NotificatoreDBObject.DB, 256);
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  B.DEV_TOKEN as DEVTOKDISNOT, ");
    SQL.Append("  B.DES_MESSAGGIO as NOMDISNODETO ");
    SQL.Append("from ");
    SQL.Append("  DISPOSITIVI_NOTI B ");
    SQL.Append("where (B.DES_MESSAGGIO = ~~DES_UTENTE~~) ");
    SQL.Append("and   (B.DEV_TOKEN IN ");
    SQL.Append("( ");
    SQL.Append("select distinct ");
    SQL.Append("  A.DEV_TOKEN ");
    SQL.Append("from ");
    SQL.Append("  DEV_TOKENS A ");
    SQL.Append("where (A.ID_APPLICAZIONE = ~~IDAPPLINOTIF~~) ");
    SQL.Append(")) ");
    PAN_NUOVOPANNELL.SetQuery(PPQRY_DEVICETOKEN, 0, SQL, PFL_NUOVOPANNELL_UTENTE, "CE590C4D-2B77-4B07-88D6-D3211FD7F1DE");
    SQL = new StringBuilder();
    SQL.Append("select ");
    SQL.Append("  B.DEV_TOKEN as DEVTOKDISNOT, ");
    SQL.Append("  B.DES_MESSAGGIO as NOMDISNODETO ");
    SQL.Append("from ");
    SQL.Append("  DISPOSITIVI_NOTI B ");
    SQL.Append("where (B.DEV_TOKEN IN ");
    SQL.Append("( ");
    SQL.Append("select distinct ");
    SQL.Append("  A.DEV_TOKEN ");
    SQL.Append("from ");
    SQL.Append("  DEV_TOKENS A ");
    SQL.Append("where (A.ID_APPLICAZIONE = ~~IDAPPLINOTIF~~) ");
    SQL.Append(")) ");
    PAN_NUOVOPANNELL.SetQuery(PPQRY_DEVICETOKEN, 1, SQL, PFL_NUOVOPANNELL_UTENTE, "");
    PAN_NUOVOPANNELL.SetQueryDB(PPQRY_DEVICETOKEN, MainFrm.NotificatoreDBObject.DB, 256);
    PAN_NUOVOPANNELL.SetIMDB(IMDB, "PQRY_NOTIFICHE2", true);
    PAN_NUOVOPANNELL.set_SetString(MyGlb.MASTER_ROWNAME, "Record");
    PAN_NUOVOPANNELL.SetQueryIMDB(PPQRY_NOTIFICHE2, IMDBDef1.PQRY_NOTIFICHE2_RS, IMDBDef1.TBL_NOTIFICHE5);
    JustLoaded = true;
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_APPLICAZIONE, IMDBDef1.FLD_NOTIFICHE5_IDAPPLINOTIF);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_UTENTE, IMDBDef1.FLD_NOTIFICHE5_DES_UTENTE);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_SOUND, IMDBDef1.FLD_NOTIFICHE5_SOUND);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_BADGE, IMDBDef1.FLD_NOTIFICHE5_BADGE);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_CUSTOMFIELD1, IMDBDef1.FLD_NOTIFICHE5_CUSTOM_FIELD1);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_CUSTOMFIELD2, IMDBDef1.FLD_NOTIFICHE5_CUSTOM_FIELD2);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_MESSAGGIO, IMDBDef1.FLD_NOTIFICHE5_MESSAGNOTIFI);
    PAN_NUOVOPANNELL.SetFieldPrimaryIndex(PFL_NUOVOPANNELL_AMBIENTE, IMDBDef1.FLD_NOTIFICHE5_AMBIENNOTIFI);
    PAN_NUOVOPANNELL.SetMasterTable(0, "NOTIFICHE5");
  }



  // **********************************************
  // Panel events dispatching
  // **********************************************
  public override void ValidateCell(IDPanel SrcObj, IDVariant ColIndex, IDVariant CellModified, IDVariant Cancel, IDVariant FldWasModified, IDVariant RowWasModified, IDVariant IsInsert)
  {
    if (SrcObj == PAN_NUOVOPANNELL) PAN_NUOVOPANNELL_ValidateCell(ColIndex, CellModified , Cancel, FldWasModified, RowWasModified, IsInsert);
  }

  public override void ValidateRow(IDPanel SrcObj, IDVariant Cancel)
  {
    if (SrcObj == PAN_NUOVOPANNELL) PAN_NUOVOPANNELL_ValidateRow(Cancel);
  }

  public override void DynamicProperties(IDPanel SrcObj)
  {
  }

  public override void CellActivated(IDPanel SrcObj, IDVariant ColIndex, IDVariant Cancel)
  {
    if (SrcObj == PAN_NUOVOPANNELL) PAN_NUOVOPANNELL_CellActivated(ColIndex, Cancel);
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
