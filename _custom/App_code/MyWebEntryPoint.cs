// **********************************************
// Web Entry Point (session handler)
// Instant WEB Application: www.progamma.com
// Project : _ICD_PROJECT
// **********************************************
using System;
using System.Text;
using System.Collections;
using System.IO;
using System.Web;
using System.IO.Compression;
using Microsoft.Win32;
using com.progamma.ids;
using com.progamma;
using com.progamma.doc;
using CIDREObj = com.progamma.idre.CIDREObj;
using IDREGlb = com.progamma.idre.IDREGlb;

// ----------------------------------------------------------------------------
// Uniche personalizzazione del MyWebEntryPoint per far funzionare le notifiche

using PushSharp;
using PushSharp.Apple;
using PushSharp.Android;
using PushSharp.Core;

// Fine Personazzazioni
// --------------------

// **********************************************
// Classe base della servlet
// **********************************************
// _ICD_COMP_START
[Serializable]
public sealed class MyWebEntryPoint : WebEntryPoint
{
  public override WebEntryPoint CreateWEP() { return new MyWebEntryPoint(Parent()); }

  bool PreDesktopRendered = true;   // Pre-Inizializzazione: serve per bypassare il problema dell'F5 con videata di login (vedi NPQ 955)
  public MyWebEntryPoint MainFrm;

  //
  // Definition of Database Objects
  // _ICD_MAIN_DBOBJECTS
  //
  // Definition of External Components
  // _ICD_COMP_DEF
  //
  // Definition of Global Variables
  // _ICD_VAR_GLOBAL
  //  


  // **********************************************
  // Setting Global panel flags
  // **********************************************
  public void InitPanelGlbFlags()
  {
    GlbPanelFlags = MyGlb.PAN_USERETURN | MyGlb.PAN_CANSORT;
    if (MyParamsObj().PanelsUseTab.Equals("YES")) GlbPanelFlags = GlbPanelFlags | MyGlb.PAN_USETAB;
    if (MyParamsObj().PanelsSortAlways.Equals("YES")) GlbPanelFlags = GlbPanelFlags | MyGlb.PAN_SORTALWAYS;
    if (MyParamsObj().PanelNewInsertMode.Equals("YES")) GlbPanelFlags = GlbPanelFlags | MyGlb.PAN_NEWINSMODE;
    if (MyParamsObj().PanelFreezeWhenHidden.Equals("YES")) GlbPanelFlags = GlbPanelFlags | Glb.PAN_FREEWHENHID;
    //
    WelcomeURL = "_ICD_WELCOME_URL";
    LogoffURL = "_ICD_LOGOFF_URL";
    set_Image("_ICD_APPICON");
    //
    try
    {
      iAccentColor = Convert.ToInt32("_ICD_ACCENT_COLOR", 16);
      // Inverto la parte rossa e blu
      iAccentColor = ((iAccentColor & 0xFF0000) >> 16) + (iAccentColor & 0x00FF00) + ((iAccentColor & 0x0000FF) << 16);
    }
    catch (Exception)
    {
    }
  }


  // **********************************************
  // Logging a Message
  // **********************************************
  public override void log(String Message)
  {
    if (CompOwner == null)
    {
      HttpContext ctx = (HttpContext.Current != null ? HttpContext.Current : Parent());
      ((IDHttpHandler)ctx.CurrentHandler).log(Message);
      Console.Error.WriteLine(Message);
    }
    else
      CompOwner.log(Message);
  }


  // ************************************************
  // Determina il MimeType a partire dall'estensione
  // ************************************************
  public override String GetMimeType(String ext)
  {
    try
    {
      RegistryKey rk = Registry.ClassesRoot.OpenSubKey("." + ext.ToLower());
      Object mt = (rk == null ? null : rk.GetValue("Content Type"));
      if (mt != null)
        return (String)mt;
      //
      RegistryKey AllCntTypes = Registry.ClassesRoot.OpenSubKey("MIME\\Database\\Content Type");
      foreach (String cnttyp in AllCntTypes.GetSubKeyNames())
      {
        RegistryKey cnttypKey = Registry.ClassesRoot.OpenSubKey("MIME\\Database\\Content Type\\" + cnttyp);
        Object exttyp = cnttypKey.GetValue("Extension");
        if (exttyp != null && (String)exttyp == ext)
          return cnttyp;
      }
    }
    catch (Exception) {}
    //
    // Non ho trovato... provo con la mia mappa
    return GetMimeFromExtension(ext);
  }


  // **********************************************
  // La sessione sta per essere attivata dopo la deserializzazione!
  // **********************************************
  public void SetParent(HttpContext p)
  {
    set_Parent(p);
    IMDB.Reset();
  }


  // **********************************************
  // Una nuova sessione è iniziata!
  // **********************************************
  public MyWebEntryPoint(HttpContext p)
    : base()
  {
    MainFrm = this;
    //
    RevNum = _ICD_REVNUM;
    IDVer = "_ICD_IDVER";
    // _ICD_SHAREDINSTANCE
    iParamsObj = new MyParams();
    //
    // Se non sono un componente
    if (GetType().FullName.IndexOf('.') == -1)
    {
      // Se ci sono componenti in fase di inizializzazione non posso proseguire
      if (cmpInited == 1)
      {
        // I componenti stanno per essere inizializzati, aspetto che sia tutto finito
        DateTime dt = DateTime.Now;
        while (cmpInited != 2)
        {
          System.Threading.Thread.Sleep(50);
          //
          // Non aspetto all'infinito... se entro 5 secondi non finisce... forse è morto... ci provo io
          // e lascio entrare gli altri
          TimeSpan ts = (DateTime.Now - dt);
          if (ts.TotalSeconds > 5)
            cmpInited = 2;
        }
      }
      else if (cmpInited == 0)    // Se non sono ancora stati inizializzati i componenti, ci penso io
        cmpInited = 1;
    }
    //
    set_Parent(p);
    CmdObj = new MyCmdHandler(this);
    IndObj = new MyIndHandler(this);
    TimerObj = new MyTimerHandler(this);
    IwImdb = new MyImdbInit(this);
    RTCObj = new RTCEngine(this);
    RTCObj.AppGuid = "_ICD_APP_GUID";
    VoiceObj = new VoiceHandler(this);
    IMDB = IwImdb.IMDB;
    //
    // Creo le ScreenZone
    if (UseZones())
    {
      ScreenZone sz = new ScreenZone(this, 0, Glb.FORMDOCK_LEFT, Glb.TABOR_LEFT);
      screenZones.Add(sz);
      sz = new ScreenZone(this, 1, Glb.FORMDOCK_RIGHT, Glb.TABOR_RIGHT);
      screenZones.Add(sz);
      sz = new ScreenZone(this, 2, Glb.FORMDOCK_TOP, Glb.TABOR_TOP);
      screenZones.Add(sz);
      sz = new ScreenZone(this, 3, Glb.FORMDOCK_BOTTOM, Glb.TABOR_BOTTOM);
      screenZones.Add(sz);
    }
    //
    // Creation of Database Objects
    // _ICD_MAIN_DBOBJECTSINT
    //
    GZipEnabled = 1; // unknown
    ResBuf = new StringBuilder(20 * 1024);
    RDStatus = MyGlb.RD_DISABLED;
    //
    set_Caption(new IDVariant("_ICD_MAINCAPTION"));
    InitPanelGlbFlags();
    IntSesNumber = (int)(Glb.Random.NextDouble() * 2147483647);
    UseRD = ParamsObj().UseRD;
    //
    // Initialize Visual Attributes
    //
    VisAttrObj v = null;
    //
    // _ICD_DTT_INIT
    //
    // _ICD_VIS_INIT
    //
    // Listing cached images
    // _ICD_WEB_IMGCACHE
    //
    // Initializing WebServices URLs
    // _ICD_WS_INIT
    //
    SetHelpFile(HelpFile);
    ErrObj = new ErrorHandler(this);
    //
    // RD3
    RD3EntryPoint = "#_ICD_WEB_LOGINURL";
    //
    if (!ParamsObj().Theme.Equals("seattle"))
      set_SideMenuWidth(163);
  }


  // **********************************************
  // La sessione è stata distrutta
  // **********************************************
  ~MyWebEntryPoint()
  {
    if (!AlreadyDestroyed)
      _WebEntryPoint();
  }

  public override void _WebEntryPoint()
  {
    try
    {
      // Comunico che sono già stato distrutto
      AlreadyDestroyed = true;
      //
      TerminateApp();
      //
      // Chiamo il distruttore della mia classe base
      base._WebEntryPoint();
    }
    catch (Exception) { }
    finally
    {
      try
      {
        EndRequest();
      }
      catch (Exception) { }
    }
    //
    // Deleting Temp Files & PDF Files
    for (int i=0; i<TempFiles.Count; i++)
    {
      try
      {
        String s = (String)TempFiles[i];
        if (File.Exists(s))
          File.Delete(s);
      }
      catch (Exception)
      {
      }
    }
    for (int i = 0; i < PDFPrints.Count; i++)
    {
      try
      {
        PDFPrint p =(PDFPrint)PDFPrints[i]; 
        if (p.AutoDelete)
        {
          if (File.Exists(RealPath + "/" + p.PDFFile))
            File.Delete(RealPath + "/" + p.PDFFile);
        }
      }
      catch (Exception)
      {
      }
    }
  }


  // **********************************************
  // Componenti
  // **********************************************
  public override void ShiftFrmConst(int frmOfs) { MyGlb.ShiftFrmConst(frmOfs, this); }
  public override int IMDBOffset() { return MyImdbInit.IMDB_OFFSET; }
  public override void CreateComponents() 
  {
    // Creating components
    // _ICD_COMP_INIT
    //
    // Creation of Global Variables
    // _ICD_VAR_GLOBALCR
  }

  // **********************************************
  // Crea i ruoli del componente
  // **********************************************
  public override void CreateCompRoles()
  {
    // Se non l'ho ancora fatto, creo il ruolo
    if (RolObj == null)
    {
      IDConnection iDB = null;
      //
      RolObj = new MyRoles(this);
      //
      // _ICD_WEB_INITDB COPY
      //
      // Chiamo il metodo base
      base.CreateCompRoles();
      //
      // Ho allineato tutti i componenti... ri-sincronizzo tutte le IMDB delle
      // variabili globali (ora tutte le strutture IMDB sono state mergiate tra loro)
      // _ICD_VAR_GLOBALCR SYNC
      //
      // Passo ai miei figli
      foreach (WebEntryPoint cmp in CompList)
        cmp.CreateCompRoles();
    }
  }

  // **********************************************
  // Crea un'istanza di una classe DO a partire dal nome
  // e lo inserisce nella collection
  // **********************************************
  public override IDDocument CreateDocument(String ClassName)
  {
    IDDocument d = MyMDOInit.CreateDocument(ClassName);
    if (d == null)
    {
      // Io non ci sono riuscito... se ho dei componenti provo con loro
      foreach (WebEntryPoint cmp in CompList)
      {
        // Se questo componente ci riesce, ho finito
        d = cmp.CreateDocument(ClassName);
        if (d != null)
          break;
      }
    }
    if (d!=null)
      d.SetMainFrm(this, IMDB);
    return d;
  }

  public override bool CreateDocument(IDCollection IDColl, String ClassName)
  {
    try
    {
      IDDocument d = MyMDOInit.CreateDocument(ClassName);
      if (d == null)
      {
        // Io non ci sono riuscito... se ho dei componenti provo con loro
        foreach (WebEntryPoint cmp in CompList)
        {
          // Se questo componente ci riesce, ho finito
          if (cmp.CreateDocument(IDColl, ClassName))
            return true;
        }
        //
        // Nessun componente ne sa nulla... esco
        return false;
      }
      //
      d.SetMainFrm(MainFrm, IMDB);
      d.Init();
      d.set_Inserted(true);
      IDColl.Add(d);
      IDColl.MoveLast();
      d.OnInserting();
      if (d.Parent() != null)
        d.Parent().ReconnectChildren(9999);
      //
      // OK
      return true;
    }
    catch (Exception)
    {
      return false;
    }
  }

  // **********************************************
  // Crea un documento dall'assembly giusto
  // **********************************************
  public override IDDocument GetFromDNA(IDVariant DNA, bool FromCache, int NumLevel, bool SkipLoad) 
  {
    return IDDocument.GetFromDNA(DNA, FromCache, NumLevel, this, IMDB, SkipLoad);
  }
  

  // **********************************************
  // Gestisce una nuova richiesta
  // **********************************************
  public override void HandleRequest(HttpRequest req, HttpResponse resp)
  {
    lock (this)
    {
      TextWriter OldOutStream = null;
      TextWriter OldErrStream = null;
      //
      try
      {
        base.HandleRequest(req, resp);
        //
        if (req != null)
        {
          // Se la richiesta arriva dal frame RD, forzo l'ASCII encoding
          if (req["WCI"] == MyGlb.ITEM_RD)
            req.ContentEncoding = ASCIIEncoding.Default;
        }
        //
        String WebItem = null, WebEvent = null, UrlData = null;
        //
        // Prelevo il path base
        if (RealPath.Length == 0)
        {
          AppPath = System.Web.HttpRuntime.AppDomainAppVirtualPath;
          if (AppPath.EndsWith("/"))
            AppPath = AppPath.Substring(0, AppPath.Length - 1);
          //
          AppName = AppPath + "/VB_ICD_APP_TITLE.aspx";
          //
          RealPath = System.Web.HttpRuntime.AppDomainAppPath;
          if (RealPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
            RealPath = RealPath.Substring(0, RealPath.Length - 1);
          //
          try
          {
            // Se non ci sono le cartelle "temp" e "logs" le creo
            String dirTemp = RealPath + Path.DirectorySeparatorChar.ToString() + "temp";
            if (!Directory.Exists(dirTemp))
              Directory.CreateDirectory(dirTemp);
            //
            String dirLogs = RealPath + Path.DirectorySeparatorChar.ToString() + "logs";
            if (DTTObj.Level > 0 && !Directory.Exists(dirLogs))
              Directory.CreateDirectory(dirLogs);
          }
          catch (Exception) { }
          //
          RTCObj.LoadRTCConst();
          //
          // Ora che RTC è inizializzato, inizializzo anche l'error handler
          ErrObj.Init();
          //
          // Ora che RTC è inizializzato e conosco il path, inizializzo anche il voice handler
          VoiceObj.Init();
        }
        //
        // Se il debug è attivo (e non c'è il trace attivo), ridirigo gli Stream di Out ed Error su files
        if (DTTObj.Level > 0 && !DTTObj.TraceEnabled)
        {
          try
          {
            TextWriter tw = CreateLogFile("Output");
            if (tw != null)
            {
              OldOutStream = Console.Out;
              Console.SetOut(tw);
            }
          }
          catch (Exception) {}
          //
          try
          {
            TextWriter tw = CreateLogFile("Error");
            if (tw != null)
            {
              OldErrStream = Console.Error;
              Console.SetError(tw);
            }
          }
          catch (Exception) {}
        }
        //
        Request = req;
        Response = resp;
        //
        DTTObj.AddRequest(this);
        //
        if (Request != null)
        {
          // Estraggo i parametri dall'URL
          ExtractUrlParams(Request);
          bool flCmd = true;
          if (ActiveForm() != null && ActiveForm().UploadingPanel != null)
            flCmd = false;
          if (UrlParams.Count == 0 && flCmd)
            ExtractUrlParams2(Request.Form["cmd"]);  // Provo con CMD (form-rd)
          if (UrlParams.Count == 0 && flCmd)
            ExtractUrlParams2(Request["ss"]);   // Provo con CMD proveniente da RD
        }
        else if (IsServerSession())
          ExtractUrlParams2(SessionQueryString);
        //
        if (RolObj == null)
        {
          RolObj = new MyRoles(this);
          //
          // _ICD_WEB_INITDB
        }
        //
        // Aggiorno i componenti
        BeginCompRequest();
        //
        // Inizio richiesta (analisi UserAgent)
        BeginRequest();
        //
        // Verifico se non è una richiesta a WebAPI
        WebApiObject.IsWebApiRequest = (WebApiObject.CheckUri().Length != 0);
        //
        // Solo se non è un item di test... il test chiama l'IWApp al momento di partire e
        // la init verrà fatta in quel momento
        if ((req != null && (req["WCI"] == null || !req["WCI"].Equals(MyGlb.ITEM_TEST))) || IsServerSession())
          RolObj.InitRoles(); // Scatena la InitApp!
        //
        if (MyParamsObj().ResponseBufferSize > 8)
        {
//          Response.setBufferSize(MyParamsObj().ResponseBufferSize * 1024);
        }
        //
        if (Request != null)
        {
          WebItem = req["WCI"];
          WebEvent = req["WCE"];
          UrlData = req["WCU"];
        }
        if (WebItem == null)
          WebItem = "";
        if (WebEvent == null)
          WebEvent = "";
        if (UrlData == null)
          UrlData = "";
        //
        SetUrlData(UrlData);
        //
        if (Request != null)
        {
          if (!WebItem.Equals(MyGlb.ITEM_BLOB) && !WebItem.Equals(MyGlb.ITEM_STREAM))
          {
            Response.BufferOutput = true;
            //
            // Uso UTF8 solo se sono in RD3 (in RD2 devo usare Latin1 per il frame RD)
            bool useUTF8 = false;
            if (ParamsObj().UseRD3)
              useUTF8 = true;
            //
            // Anche per la sincronizzazione rispondo sempre in UTF-8
            if (WebItem.Equals(MyGlb.ITEM_SYNC))
              useUTF8 = true;
            //
            OpenResponse(false);
            Out = new StreamWriter(OutStr, useUTF8 ? Encoding.UTF8 : Encoding.Default);
            Response.ContentType = "text/html";
          }
          else
            OpenResponse(true); // No compressione per i blob
        }
        //
        // Ri-aggiorno i componenti... potrebbe essere cambiato qualcosa (es: nati ruoli, creato stream Out)...
        BeginCompRequest();
        //
        // Se c'è il comando URL, chiamo l'evento
        //
        IDVariant cmd = GetUrlParam();
        if (cmd.stringValue().Length > 0)
        {
          DTTObj.SetRequestName("Command " + cmd.ToString(), "Query String Command Detected", DTTRequest.PRI_DATA);
          //
          bool ro = RolObj.CheckRole();
          bool cr = false;
          if (ro)
            cr = CmdObj.ExecCmdCode(cmd.stringValue()); // Solo se utente già loggato!
          if (!ro || !cr)
          {
            // Lancio evento, non era gestita da un comando
            DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 152, "MainFrm.BeginRequest", "Fire OnCommand(" + cmd.ToString() + ") event");
            OnCommand(cmd);
            if (!ro && RolObj.CheckRole())
            {
              MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 114, "OnCommand", "Bypass login (Session Role set while handling a command)");
              // No login will occur, need to activate app manually
              //
              FireAfterLogin();
            }
            //
            // Se è il CMD che indica il ritorno online di una app OWA
            if (RolObj.CheckRole() && cmd.stringValue().Equals("OWABackOnline"))
            {
              WebItem = Glb.ITEM_RD3;
              WebEvent = "OWABackOnline";
            }
          }
          //
          if (cmd.stringValue().Equals("?IDVER"))
            DumpVersions(true);
          if (cmd.stringValue().Equals("?DEBUG"))
            OpenDebugWindow();
          if (cmd.stringValue().Equals("?DTTOK"))
          {
            DTTObj.DTTStarted = true;
            set_AlertMessage(new IDVariant("DTT Started"));
          }
          if (cmd.stringValue().Equals("?DTTKO"))
          {
            DTTObj.DTTStarted = false;
            set_AlertMessage(new IDVariant("DTT Stopped"));
          }
          //
          // a CMD is arrived, disable Session Number checking
          IntSesNumber = 0;
        }
        //
        // Dopo NPQ 940 (migliorato LOGIN1.HTM passando WCI, WCE e WCU in POST) c'è un problema
        // se premo F5... se mi arriva IWLOGIN ed ho già un ruolo attivo, annullo l'item
        if (WebItem.Equals(MyGlb.ITEM_LOGIN) && RolObj.CheckRole())
        {
          WebItem = "";
          WebEvent = "";
          UrlData = "";
          //
          // Se c'è l'RD3 meglio resettare il tutto
          if (ParamsObj().UseRD3)
            RD3Reset();
        }
        //
        if (!IsServerSession())
        {
          // Selezione del WEBITEM tramite stringa
          //
          try
          {
            if (WebItem.Equals(MyGlb.ITEM_APP))
              IWApp_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_LOGIN))
              IWLogin_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_LOGOFF))
              IWLogoff_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_MENU))
              IWMenu_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_SBIND))
              IWSbInd_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_FORM))
              IWForm_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_FORMLIST))
              IWFormList_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_BLOB))
              IWBlob_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_UPLOAD))
              IWUpload_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_FILES))
              IWFiles_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_TREE_EXP))
              IWTreeExp_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_TREE_CLICK))
              IWTreeClick_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_TREE_DROP))
              IWTreeDrop_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_GRAPH_CLICK))
              IWGraphClick_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_DTT))
              IWDTT_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_TEST))
              IWTest_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_HELP))
              IWHelp_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_FRAMES))
              IWFrames_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_RD))
              IWRD_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_W3C))
              IW3C_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_RD3))
              IWRD3_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_SYNC))
              IWSync_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_STREAM))
              IWStream_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_OWA))
              IWOwa_UserEvent(WebEvent);
            else if (WebItem.Equals(MyGlb.ITEM_OAUTH))
              IWOAuth_UserEvent(WebEvent);
            else if (!WebApiObject.HandleRequest())
            {
              if (UseRD)
              {
                if (!DTTObj.TestEnabled && !iParamsObj.UseRD3)
                  IWFrames_UserEvent(WebEvent);
                else
                  IWApp_UserEvent(WebEvent);
              }
              else
                IWApp_UserEvent(WebEvent);
            }
          }
          catch (Exception ex)
          {
            MainFrm.DTTObj.AddException("", "MainFrm", "Exception while handling event WCI=" + WebItem + " WCE=" + WebEvent + " URL=" + UrlData, ex);
            MainFrm.ErrObj.ProcError("MainFrm", "WCI=" + WebItem + " WCE=" + WebEvent + " URL=" + UrlData, ex);
            RenderPage();
          }
        }
      }
      catch (Exception e)
      {
        FatalErrorResponse(e);
      }
      finally
      {
        try
        {
          EndRequest();
        }
        catch (Exception e1)
        {
          Console.Error.WriteLine(e1.Message + "\n" + e1.StackTrace); Console.Error.Flush();
        }
        //
        try
        {
          if (Out != null)
            Out.Close();
          //
          if (OutStr != null)
            OutStr.Close();
        }
        catch (Exception e)
        {
          Console.Error.WriteLine(e.Message + "\n" + e.StackTrace); Console.Error.Flush();
        }
        //
        Request = null;
        Response = null;
        OutStr = null;
        Out = null;
        //
        // Chiudo i files di log se li ho aperti
        if (OldOutStream != null)
        {
          Console.Out.Close();
          Console.SetOut(OldOutStream);
        }
        if (OldErrStream != null)
        {
          Console.Error.Close();
          Console.SetError(OldErrStream);
        }
        //
        // Componenti
        EndCompRequest();
      }
    }
  }

  public override void FireAfterLogin()
  {
    RolObj.ApplyRoles(0, null);
    DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 20, "MainFrm", "Fire AfterLogin event");
    AfterLogin();
    TimerObj.ActivateTimers(0, true);
  }

  // **********************************************
  // Check for user login
  // **********************************************
  public override void IWLogin_UserEvent(String EventName)
  {
    // Siccome posso arrivare qui dall'RD3 se l'utente preme F5, devo
    // mostrare nuovamente il desktop
    RD3Reset();
    //
    // Check for user data...
    IDVariant Valid, sUser, sPass;
    //
    sUser = new IDVariant(Glb.HTMLDecode(Request["UserName"]));
    sPass = new IDVariant(Glb.HTMLDecode(Request["PassWord"]));
    Valid = new IDVariant(true);
    RolObj.glbUser = new IDVariant(sUser);
    //
    DTTObj.SetRequestName("Login", "Login procedure", DTTRequest.PRI_ITEM);
    DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 150, "MainFrm.Login", "Fire OnLogin event");
    DTTObj.AddTestItem("USERNAME", DTTEngine.TST_APPLOGUP, sUser.stringValue(), "");
    if (sUser.stringValue().Length == 0)
      DTTObj.AddHelpItem(0, 0, 0, 0, "Lascia vuoto il campo UserName");
    else
      DTTObj.AddHelpItem(0, 0, 0, 0, "Scrivi " + sUser.stringValue() + " nel campo UserName");
    DTTObj.AddTestItem("PASSWORD", DTTEngine.TST_APPLOGUP, sPass.stringValue(), "");
    if (sPass.stringValue().Length == 0)
      DTTObj.AddHelpItem(0, 0, 0, 0, "Lascia vuoto il campo Password");
    else
      DTTObj.AddHelpItem(0, 0, 0, 0, "Scrivi " + sPass.stringValue() + " nel campo Password");
    DTTObj.AddTestItem("LOGIN", DTTEngine.TST_APPLOGIN, "", "");
    DTTObj.AddHelpItem(0, 0, 0, 0, "Clicca sul bottone LOGIN");
    MainFrm.Login(sUser, sPass, Valid);
    //
    if (RolObj.CheckRole())
      FireAfterLogin();
    else
      DTTObj.AddMsg(DTTEngine.DTTMSG_WARN, "", 8, "MainFrm.Login", "Login failed (User Role not set)");
    //
    RenderPage();
  }


  // **********************************************
  // Premuto pulsante logoff
  // **********************************************
  public override void IWLogoff_UserEvent(String EventName)
  {
    String s = "";
    //
    DTTObj.SetRequestName("Logoff", "Logoff button pressed", DTTRequest.PRI_CMD);
    DTTObj.AddTestItem("", DTTEngine.TST_LOGOFF, "Logoff", "");
    DTTObj.AddHelpItem(0, 0, 0, 0, "Clicca sul bottone LOGOFF");    
    //
    // Lancio Evento
    IDVariant skip = new IDVariant();
    IDVariant cancel = new IDVariant();
    DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 197, "MainFrm.OnLogoff", "Logoff button pressed: firing OnLogoff Event");      
    OnLogoff(skip, cancel);
    if (cancel.isTrue())
    {
      DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 197, "MainFrm.OnLogoff", "Logoff was canceled by OnLogoff Event");
      if (RDStatus == MyGlb.RD_ACTIVE)
        RenderDifferences();
      return;
    }
    if (skip.isFalse())
    {
      // Tento di chiudere tutte le form
      ArrayList c = new ArrayList(StackForm);
      IEnumerator i = c.GetEnumerator();
      //    
      while (i.MoveNext())
      {
        WebForm f = (WebForm) i.Current;
        UnloadForm(f.FormIdx, false);
      }
      //
      if (DockedForm()!=null)
        UnloadForm(DockedForm().FormIdx, false);
      //
      if (StackForm.Count>0)
        cancel = IDVariant.TRUE;
    }
    if (cancel.isTrue())
    {
      DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 197, "MainFrm.Logoff", "Logoff was canceled because not all forms can be closed");
      if (RDStatus == MyGlb.RD_ACTIVE)
        RenderDifferences();
      return;
    }
    //
    if (DTTObj.TestRunning || DTTObj.RecordRunning)
    {
      Out.Write("<html>");
      Out.Write("<head>");
      Out.Write("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1252\">");
      Out.Write("<script language=\"javascript\" type=\"text/javascript\">");
      if (DTTObj.RecordRunning)
        Out.Write("top.window.close();");
      else
        Out.Write("window.parent.frames('Control').NextStep();");
      Out.Write("</script>");
      Out.Write("</head>");
      Out.Write("</html>");
      //
      // Mettiamo sempre e solo un messaggio (se no ci saranno delle differenze!)
      //if (DTTObj.RecordRunning)
      //  DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 23, "MainFrm.Logoff", "Record termination");
      //else
      DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 23, "MainFrm.Logoff", "Test termination");
    }
    else
    {
      if (LogoffURL.Length > 0 && !LogoffURL.Equals("???"))
        s = LogoffURL;
      else
      {
        if (UseRD)
        {
          if (ParamsObj().UseRD3)
            s = AppName;
          else if (DTTObj.TestEnabled)
            s = UrlFor(MyGlb.ITEM_APP, "");
          else
            s = UrlFor(MyGlb.ITEM_FRAMES, "");
        }
        else
          s = UrlFor(MyGlb.ITEM_APP, "");
      }
      //
      DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 23, "MainFrm.Logoff", "Redirect to " + s);
      if (RDStatus == MyGlb.RD_ACTIVE)
      {
        RDExitURL = s;
        RenderDifferences();
      }
      else
      {
        try
        {
          if (ParamsObj().UseRD3)
            RD3AddEvent("redirect",s);
          else
            Response.Redirect(s, false);
        }
        catch (Exception e)
        {
          Console.Error.WriteLine(e.Message + "\n" + e.StackTrace); Console.Error.Flush();
        }
      }
    }
    //
    HttpContext.Current.Session.Abandon();
  }


  // **********************************************
  // Fatal Error (a component or framework error)
  // **********************************************
  public override void FatalErrorResponse(Exception e)
  {
    base.FatalErrorResponse(e);
    //
    if (Out != null)
    {
      Out.Write(e.StackTrace); Out.Flush();
    }
    //
    Console.Error.WriteLine(e.Message + "\n" + e.StackTrace); Console.Error.Flush();
  }


  // **********************************************
  // Before end, close database connections
  // **********************************************
  public override void EndRequest()
  {
    CloseAllDBConnections();
    //
    base.EndRequest();
  }


  // **********************************************
  // Close database connections
  // **********************************************
  public override void CloseAllDBConnections()
  {
    //
    // _ICD_WEB_CLOSEDB
    //
  }


  // **********************************************
  // Opens the right output stream
  // **********************************************
  public override void OpenResponse(bool flNoCompr)
  {
    try
    {
      if (!flNoCompr && MyParamsObj().CompressResponse.Equals("YES"))
      {
        String encodings = Request.Headers["Accept-Encoding"];
        if (encodings != null && encodings.IndexOf("gzip") != -1)
        {
          // GZIP
          if (encodings.IndexOf("x-gzip") != -1)
            Response.AddHeader("Content-Encoding", "x-gzip");
          else
            Response.AddHeader("Content-Encoding", "gzip");
          OutStr = new GZipStream(Response.OutputStream, CompressionMode.Compress);
        }
        else
        {
/*
          if (encodings != null && encodings.IndexOf("compress") != -1)
          {
            // ZIP
            if (encodings.IndexOf("x-compress") != -1)
              Response.AddHeader("Content-Encoding", "x-compress");
            else
              Response.AddHeader("Content-Encoding", "compress");
            //
            ZipOutputStream z = new ZipOutputStream(Response.OutputStream);
            z.putNextEntry(new ZipEntry("dummy name"));
            OutStr = z;
          }
          else
*/
          {
            // No compression
            OutStr = Response.OutputStream;
          }
        }
        Response.AddHeader("Vary", "Accept-Encoding");
      }
      else
      {
        // Compression is disabled
        OutStr = Response.OutputStream;
      }
    }
    catch (Exception)
    {

    }
  }


  // **********************************************
  // Render current page
  // **********************************************
  public override void RenderPage()
  {
    // Se è attivo l'RD4, vado di ShowDestop... non ho altro da aggiungere
    if (ParamsObj().UseRD4)
    {
      ShowDesktop();
      return;
    }
    //
    // In RD3 avviato, RD2 avviato o RD0 se non è già stato programmato un messaggio all'utente vedo se è previsto un riavvio dell'applicazione
    if (((UseRD && iParamsObj.UseRD3 && DesktopRendered) || (UseRD && !iParamsObj.UseRD3 && RDStatus == Glb.RD_ACTIVE) || !UseRD) && AlertMessage().stringValue().Length == 0)
      CheckRestartWarning();
    //
    // Se il debug è attivo (non TRACE), vedo se occorre mostrare errori all'utente
    if (DTTObj.Level > 0 && !DTTObj.TraceEnabled && !ErrObj.IsError())
      DTTObj.ShowReqErrors();
    //
    // Popup menu
    int PopupMenu_CmdSetIdx = 0;
    int PopupMenu_FormIdx = 0;
    //
    if (DisableRender)
    {
      DisableRender = false;
      return;
    }
    //
    bool onlyform = WidgetMode;
    //
    String s = Request["WCU"];
    int p = (s == null) ? -1 : s.IndexOf("TT");
    if (p > -1)
    {
      p = p + 2;
      int f = p;
      while (f < s.Length && Char.IsDigit(s[f]))
        f++;
      try
      {
        TreeScrollTop = Int32.Parse(s.Substring(p, f - p));
      }
      catch (Exception e)
      {
        TreeScrollTop = 0;
      }
    }
    //
    set_ClickCounter(ClickCounter() + 1);
    RefreshNextClick = false;
    //
    SetUrlData("");
    //
    // True Popup
    if (RDStatus!=Glb.RD_DISABLED && ParamsObj().TruePopup)
    {
      if (IEVer >= 600 && ActiveForm() != null)
        onlyform = (ActiveForm().OpenAs != Glb.OPEN_MDI) || WidgetMode;
    }
    //
    // Need to redirect?
    //
    if ((!iParamsObj.UseRD3 || Request["WCI"]=="IWBlob") && RDStatus != MyGlb.RD_ACTIVE && RedirectTo().stringValue().Length > 0 && !RedirectNewWindow() && !DTTObj.TestRunning)
    {
      DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 6, "MainFrm.RenderPage", "Redirecting to " + RedirectTo().ToString());
      //
      // Se sono in RD3 (e la richiesta è di tipo IWBlob: vedi sopra)
      // e se devo gestire i file in streaming ...
      if (iParamsObj.UseRD3 && DeleteAfterDownload)
      {
        // Questo è l'unico caso in RD3 nel quale serve inviare dell'HTML
        // in quanto il download di un blob apre già una nuova finestra e non si aspetta dell'XML
        // Codice replicato dall'RD3RenderDifferences
        try
        {
          // Se il file è locale all'applicazione
          FileInfo f = new FileInfo(RealPath + Path.DirectorySeparatorChar + RedirectTo().stringValue());
          if (f.Exists)
          {
            set_RedirectTo(new IDVariant(UrlFor(Glb.ITEM_STREAM)));
            FileToSend = f.FullName;
          }
        }
        catch (Exception)
        {
        }
      }
      //
      // _ICD_HTML_INCLUDE REPORT.HTM
      //
      // Se c'è RD3, lo spedisce e svuota lui... a meno che non sia uno scaricamento di BLOB
      // In questo caso occorre svuotarlo comunque!
      if (!iParamsObj.UseRD3 || Request["WCI"]=="IWBlob")
        set_RedirectTo(new IDVariant());
      //
      //RefreshNextClick = True;
      return;
    }
    //
    // Updating IMDB
    //
    TimerObj.Tick(this);
    UpdateIMDBState();
    //
    if (!RolObj.CheckRole())
    {
      // Show login screen
      //
      ShowLogin();
      return;
    }
    //
    ResBuf.Length = 0;
    //
    // Gestione del Trace
    DTTTrace();
    //
    // Gestione rendering differenziale
    if (UseRD)
    {
      if (RDStatus == MyGlb.RD_ACTIVE)
      {
        RenderDifferences(onlyform);
        return;
      }
      //
      if (iParamsObj.UseRD3 && !PreDesktopRendered)
      {
        PreDesktopRendered = true;
        //
        WriteStr("<html><head>");
        WriteStr("<script>window.location.href = window.location.href;</script>");
        WriteStr("</head></html>");
        return;
      }
      //
      if(iParamsObj.UseRD3 && DesktopRendered)
      {
        RenderDifferences3();
        return;
      }
      //
      if(iParamsObj.UseRD3 && !DesktopRendered)
      {
        ShowDesktop();
        DesktopRendered = true;
        return;
      }
    }
    //
    if (ParamsObj().HtmlConstraints == MyGlb.WEBVALID_STRICT)
      WriteStr("<!DOCTYPE html PUBLIC \"-//W3C//DTD HTML 4.01//EN\" \"http://www.w3.org/TR/html4/strict.dtd\">");
    WriteStr("<html>");
    WriteStr("<head>");
    WriteStr("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">");
    WriteStr("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=EmulateIE7\">");
    if (ParamsObj().IWCacheControl.Equals("CACHE") || UseRD)
    {
      WriteStr("<meta http-equiv=\"Pragma\" content=\"no-cache\">");
      WriteStr("<meta http-equiv=\"Expires\" content=\"-1\">");
    }
    if (!UseRD)
    {
      if (RefreshInterval().intValue() > -1)
        WriteStr("<meta http-equiv=\"refresh\" content=\"" + RefreshInterval().intValue() + ";url=" + UrlFor(MyGlb.ITEM_APP, "") + "\">");
    }
    WriteStr("<title>");
    WriteStr(GetPageTitle());
    WriteStr("</title>");
    WriteStr("<link rel=stylesheet type=\"text/css\" href=\"iw.css\">");
    if (DTTObj.HelpGenerationActive)
      WriteStr("<link rel=stylesheet type=\"text/css\" href=\"dtt.css\">");
    WriteStr("<link rel=stylesheet type=\"text/css\" href=\"custom.css\">");
    //
    // client mask?
    if (ParamsObj().UseClientMask)
      WriteStr("<script type=\"text/javascript\" src=\"maskedinp.js\"></script>");
    WriteStr("<script type=\"text/javascript\" src=\"ijlib.js\"></script>");
    WriteStr("<script type=\"text/javascript\" src=\"dragdrop.js\"></script>");
    WriteStr("<script type=\"text/javascript\" src=\"custom.js\"></script>");
    //
    // Form JScript events
    //
    WriteStr("<script type=\"text/javascript\">");
    WriteStr("function InitBody() { ");
    if (!ParamsObj().UseFK)
      WriteStr("UseFK=false;");
    else
    {
      WriteStr("HLColorED=\"" + Glb.GetWebColor(VisualStyleList.Color(1, Glb.VISCLR_EDITING)) + "\";");
      if (VisualStyleList.GradCol(1, Glb.VISCLR_EDITING) != -1)
        WriteStr("HLColorEDFlt=\"" + Glb.GetWebGradient(VisualStyleList.Color(1, Glb.VISCLR_EDITING), VisualStyleList.GradCol(1, Glb.VISCLR_EDITING), VisualStyleList.GradDir(1, Glb.VISCLR_EDITING)) + "\";");
      else
        WriteStr("HLColorEDFlt=\"" + Glb.GetWebOpacity(VisualStyleList.Opacity(1, Glb.VISCLR_EDITING)) + "\";");
    }
    if (!ParamsObj().UseDoubleClick)
      WriteStr("UseDBLCLK=false;");
    if (ParamsObj().HtmlConstraints == MyGlb.WEBVALID_STRICT)
      WriteStr("StrictHTML=true;");
    if (ParamsObj().UseClientMask)
    {
      WriteStr("glbDecSep='" + (ParamsObj().UseDecimalDot ? '.' : ',') + "';");
      WriteStr("glbThoSep='" + (ParamsObj().UseDecimalDot ? ',' : '.') + "';");
    }
    WriteStr(" ResizeTables();");
    WriteStr(" ChangeRowDelay=" + (ParamsObj().UseFK?ParamsObj().ChangeRowDelay:0) + ";");
    if (ActiveForm() != null)
    {
      WriteStr("try {");
      if (ActiveForm().ScrollTop >= 0)
        WriteStr(" document.body.scrollTop = " + ActiveForm().ScrollTop + "; ");
      if (ActiveForm().ActiveElement.Length > 0)
        WriteStr(" if (document.all(\"" + ActiveForm().ActiveElement + "\")!=null) document.all(\"" + ActiveForm().ActiveElement + "\").focus(); ");
      WriteStr("} catch (e) {}");
    }
    if (TreeScrollTop > 0)
    {
      WriteStr("try {");
      WriteStr("document.getElementById(\"TREE\").scrollTop = " + TreeScrollTop + ";");
      WriteStr("} catch (e) {}");
    }
    if (RedirectNewWindow() && !DTTObj.TestRunning)
    {
      set_RedirectTo(IDL.Replace(RedirectTo(), new IDVariant("\\"), new IDVariant("/")));
      if (RedirectFeatures().stringValue().ToLower().IndexOf("modal") > -1)
        WriteStr("window.showModalDialog(" + MyGlb.JSEncode2(RedirectTo()));
      else
        WriteStr("window.open(" + MyGlb.JSEncode2(RedirectTo()));
      if (RedirectFeatures().stringValue().Length > 0)
        WriteStr(", null, " + MyGlb.JSEncode(RedirectFeatures()));
      WriteStr("); ");
    }
    if (AlertMessage()!=null && AlertMessage().stringValue().Length > 0 && !DTTObj.TestRunning && !DTTObj.HelpGenerationActive)
      WriteStr("alert(" + MyGlb.JSEncode2(AlertMessage()) + "); ");
    //
    // Stampo senza RD?
    RenderPDFPrints();
    //
    WriteStr(" } </script>");
    //
    WriteStr("</head>");
    WriteStr("<body");
    if (WidgetMode)
      WriteStr(" style=\"overflow:hidden\"");
    else if (ParamsObj().HtmlConstraints != MyGlb.WEBVALID_NONE)
      WriteStr(" style=\"overflow:visible\"");
    //
    String js = "InitBody();";
    //
    // Se il test è in esecuzione chiamo il prossimo step
    if (DTTObj.TestRunning || DTTObj.HelpGenerationActive)
      js = js + "try{window.parent.frames('Control').NextStep();}catch(e){}";
    //
    if (UseRD)
    {
      if (RDStatus != MyGlb.RD_DISABLED)
      {
        js = js + " ChangeTarget();";
        // Solo ora carico l'altro frame che farà poi il change target
        js = js + " GetFrame(window.parent.frames,'RD').location.href='" + UrlFor(MyGlb.ITEM_RD, "") + "';";
      }
      if (UseRD && ParamsObj().TruePopup)
      {
        if (IEVer >= 600 && ActiveForm() != null)
        {
          WebForm af = ActiveForm();
          if (af.OpenAs != Glb.OPEN_MDI)
            js = js + " rp(" + af.FormLeft + ", " + af.FormTop + ", " + af.FormWidth + ", " + af.FormHeight + ");";
        }
      }
    }
    //
    // Se è stato richiesto il menu contestuale, lo mostro
    if (MenuIdx!="" && RDStatus!=Glb.RD_ACTIVE)
    {
      // Recupero la direzione corrente
      int Dir = 0;
      if (MenuIdx.IndexOf("|") != -1)
      {
        Dir = Int32.Parse(MenuIdx.Substring(MenuIdx.IndexOf("|") + 1));
        MenuIdx = MenuIdx.Substring(0, MenuIdx.IndexOf("|"));
      }
      else
        Dir = 1; // Default: Bottom
      //
      // Recupero il CmdSet ed il FormIdx
      String ObjIDs;
      int FormIdx;
      PopupMenu_CmdSetIdx = Int32.Parse(MenuIdx.Substring(0, MenuIdx.IndexOf(":")));
      MenuIdx = MenuIdx.Substring(MenuIdx.IndexOf(":") + 1);
      ObjIDs = MenuIdx.Substring(0, MenuIdx.IndexOf(":"));
      MenuIdx = MenuIdx.Substring(MenuIdx.IndexOf(":") + 1);
      PopupMenu_FormIdx = Int32.Parse(MenuIdx);
      if (PopupMenu_FormIdx == -1)
      {
        if (ActiveForm() != null)
          PopupMenu_FormIdx = ActiveForm().FormIdx;
        else
          PopupMenu_FormIdx = 0;
      }
      //
      // Scrivo il comando che posizionerà il popup menu
      js = js + "popupshow_NoRD('" + ObjIDs + "|" + Dir + "');";
    }
    //
    // FK per custom commands...
    // NPQ 428: tasti FK anche con RD non attivo
    String FK = WebFrame.GetCCFK();
    if (FK.Length>0)
      js += "if (!StdFKInit) " + FK;
    //
    if (js != "")
      WriteStr(" onload=\"" + js + "\"");
    //
    set_RedirectNewWindow(false);
    set_RedirectTo(new IDVariant());
    set_RedirectFeatures(new IDVariant());
    set_AlertMessage(new IDVariant(""));
    WriteStr(">");
    //
    if (onlyform)
    {
      WriteStr("<table id=ExtTable cellspacing=\"0\" cellpadding=\"0\">"); // Primary Frame Definition
      WriteStr("<tr><td id=ActiveForm valign=\"top\">"); // Page Definition
      RenderActiveForm(true);
      WriteStr("</td></tr></table>");
    }
    else
    {
      WriteStr("<div id=hdr>");
      RenderHeader();
      WriteStr("</div><table id=ExtTable cellspacing=0 cellpadding=0>"); // Primary Frame Definition
      WriteStr("<tr>");
      //
      // Menu Bar
      WriteStr("<td id=MenuTable style=\"width:1px;vertical-align:top\">"); // Menu Frame Definition
      RenderMenuBar();
      //
      WriteStr("</td><td id=RightTables><table id=RightTable cellspacing=\"0\" cellpadding=\"0\"><tr><td id=StatusBarTable>");
      RenderStatusBar();
      WriteStr("</td></tr><tr><td id=ToolBarTable>");
      //
      if (CmdObj.IsToolbarPresent())
      {
        WriteStr("<table id=ToolBar><tr>"); // Tool Bar Definition
        //
        // _ICD_HTML_INCLUDE TB1.HTM
        //
        CmdObj.RenderToolbar();
        //
        // _ICD_HTML_INCLUDE TB2.HTM
        //
        WriteStr("</tr></table>");
      }
      WriteStr("</td></tr><tr>");
      //
      IntSesNumber = (int)(Glb.Random.NextDouble() * 2147483647); // New internal session number
      //
      WriteStr("<td id=PageTable>"); // Page Definition
      RenderPageTable();
      WriteStr("</td></tr>");
      //
      // Closing primary table
      WriteStr("</table></td></tr></table>");
    }
    //
    if ((ShowCalendar || RDStatus == Glb.RD_FRAMES) && (ParamsObj().HtmlConstraints != MyGlb.WEBVALID_STRICT || (UseRD && RDStatus != Glb.RD_DISABLED)))
    {
      // Creating popup calendar
      WriteStr("<script type=\"text/javascript\" src=\"calpopup.js\"></script>");
      WriteStr("<script event=onclick() for=document>");
      WriteStr("document.all.calpopup.style.display=\"none\";</script>");
      WriteStr("<iframe id=calpopup style=\"display:none;z-index:100;width:157px;height:162px;position:absolute\"");
      WriteStr("marginwidth=0 marginheight=0 src=\"calpopup.htm\" frameborder=0 noresize scrolling=no></iframe>");
      ShowCalendar = false;
    }
    //
    if (RDStatus == Glb.RD_FRAMES && UseRD)
      WriteStr("<iframe id=delaydlg style=\"display:none;z-index:100;position:absolute;filter:progid:DXImageTransform.Microsoft.Shadow(color=gray,direction=135,strength=3)\" marginwidth=5 marginheight=5 src=\"delaydlg.htm\" frameborder=0 noresize scrolling=no progrbar='" + ProgrBarFileName() + "'></iframe>");
    //    
    // Se è attivo l'Help generation aggiungo 2 iframes per le label di help
    if (DTTObj.HelpGeneration)
    {
      WriteStr("<div id=\"reqdiv\" class=HelpReqDiv style=\"display:none\"></div>");
      WriteStr("<div id=\"reqVdiv\" class=HelpReqDiv style=\"display:none\"></div>");
      WriteStr("<div id=\"itemdiv\" class=HelpItemDiv style=\"display:none\"></div>");
      WriteStr("<img id=\"helpcurs\" class=HelpCurs src=\"dttimg/helpcurs.gif\" style=\"display:none\">");
    }
    //
    // Se c'era da mostrare un menu popup, lo faccio
    if (MenuIdx!="" && RDStatus!=Glb.RD_ACTIVE)
    {
      CmdObj.RenderPopupMenu(PopupMenu_CmdSetIdx, PopupMenu_FormIdx);
      MenuIdx = "";
    }
    //
    // Inserisco l'oggetto per la stampa PDF
    WriteStr("<div id=\"dpdf\"></div>");
    RenderTrayletCommand(); // Renderizza l'IFRAME per chiamare la traylet!
    //
    WriteStr("</body>");
    //
    if ((ParamsObj().IWCacheControl.Equals("CACHE") || UseRD) && ParamsObj().HtmlConstraints != MyGlb.WEBVALID_STRICT)
    {
      WriteStr("<head>");
      WriteStr("<meta http-equiv=\"Pragma\" content=\"no-cache\">");
      WriteStr("<meta http-equiv=\"Expires\" content=\"-1\">");
      WriteStr("</head>");
    }
    WriteStr("</html>");
    SetUrlData(""); // Disabilito URL per evitare problemi al debugger
    //
    if (UseRD)
    {
      if (RDStatus != MyGlb.RD_DISABLED)
        ResetRD();
    }
  }


  // **********************************************
  // Esegue render docked e active form
  // **********************************************
  public override void RenderPageTable()
  {
    //
    // _ICD_HTML_INCLUDE PAGE1.HTM
    //
    WriteStr("<table class=wh100 cellspacing=\"0\" cellpadding=\"0\"><tr>");
    LastDockType = (DockedForm() != null) ? DockedForm().DockType : 0;
    if (LastDockType == 0 || LastDockType == Glb.FORMDOCK_LEFT || LastDockType == Glb.FORMDOCK_TOP)
    {
      WriteStr("<td id=dockform style=\"height:10px\">");
      RenderDockedForm();
    }
    else
    {
      WriteStr("<td id=ActiveForm>");
      RenderActiveForm();
    }
    //
    WriteStr("</td>");
    if (LastDockType == Glb.FORMDOCK_TOP || LastDockType == Glb.FORMDOCK_BOTTOM)
      WriteStr("</tr><tr>");
    //
    if (LastDockType == 0 || LastDockType == Glb.FORMDOCK_LEFT || LastDockType == Glb.FORMDOCK_TOP)
    {
      WriteStr("<td id=ActiveForm>");
      RenderActiveForm();
    }
    else
    {
      WriteStr("<td id=dockform style=\"height:10px\">");
      RenderDockedForm();
    }
    WriteStr("</td></tr></table>");
    //
    // _ICD_HTML_INCLUDE PAGE2.HTM
    //
  }


  // **********************************************
  // Status bar clicking events
  // **********************************************
  public override void IWSbInd_UserEvent(String EventName)
  {
    if (RefreshNextClick && !ParamsObj().UseRD3)
    {
      RenderPage();
      return;
    }
    //
    DispatchToComp("IWSbInd_UserEvent", new Object[] { EventName });
    //
    if (RolObj.CheckRole())
    {
      //
      // _ICD_WEB_SBEVN
      //
      // Cerco l'indicatore corrispondente
      AIndicator ind = null;
      for (int i = 1; i < IndObj.Indicators.Length; i++)
      {
        if (IndObj.Indicators[i] == null)
          continue;
        //
        if (IndObj.Indicators[i].Code.Equals(EventName))
        {
          ind = IndObj.Indicators[i];
          break;
        }
      }
      if (ind != null)
      {
        DTTObj.SetRequestName("Indicator " + ind.Code + " click", "Indicator " + ind.Code + " click", DTTRequest.PRI_CMD);
        DTTObj.AddTestItem(ind.iGuid, DTTEngine.TST_INDIC, "Indicator " + ind.Code + " action", "");
        DTTObj.AddHelpItem(0, 0, 0, 0, "Premi l'indicatore " + ind.Code);
      }
    }
    else
      DTTObj.AddMsg(DTTEngine.DTTMSG_WARN, "", 19, "MainFrm.StatusBarHandler", "Unhandled Status Bar command: undefined session role");
    //
    if (!ParamsObj().UseRD3)
      RenderPage();
  }

  // **********************************************
  // W3C Validation
  // **********************************************
  public override void IW3C_UserEvent(String EventName)
  {
    // Salvo il vecchio stato
    int oldrd = RDStatus;
    bool oldhlp = DTTObj.HelpGenerationActive;
    //
    // Disabilito l'RD
    RDStatus = Glb.RD_DISABLED;
    //
    // Direct Output (vedi WriteStr)
    DTTObj.HelpGenerationActive = false;
    //
    // _ICD_HTML_INCLUDE VALIDATE1.HTM
    //
    // Buffered Output (vedi WriteStr)
    DTTObj.HelpGenerationActive = true;
    //
    // Renderizzo la pagina encodandola
    ResBuf.Length = 0;
    RenderPage();
    Out.Write(Glb.HTMLEncode(ResBuf.ToString()));
    ResBuf.Length = 0;
    //
    // Direct Output (vedi WriteStr)
    DTTObj.HelpGenerationActive = false;
    //
    // _ICD_HTML_INCLUDE VALIDATE2.HTM
    //
    // Ripristino il tutto
    RDStatus = oldrd;
    DTTObj.HelpGenerationActive = oldhlp;
  }

  // **********************************************
  // Gestione delle FORMS
  // **********************************************
  public override void Show(int FormIdx, int flModal)
  {
    Show(FormIdx, flModal, null);
  }
  public override void Show(int FormIdx, int OpenAs, Object ParentObj)
  {
    int Owner = 0;
    IDVariant Cancel = new IDVariant();
    //
    // Se non è RD3 allora la form deve essere parte dell'MDI
    if (OpenAs == Glb.OPEN_POPUP && RDLevel() < 3)
    {
      OpenAs = Glb.OPEN_MDI;
    }
    //
    // Check if docked form is open
    if (DockedForm() != null && DockedForm().FormIdx == FormIdx)
    {
      DockedForm().set_Visible(true);
      DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 14, "MainFrm.Show", "Form " + DockedForm().Caption() + " already open and docked");
      return;
    }
    //
    // Check is form is already open
    WebForm f = GetFormByIndex(FormIdx);
    if (f != null)
    {
      DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 14, "MainFrm.Show", "Form " + f.Caption() + " already open: bringing to front");
      f.set_Visible(true);
      //
      // In RD2 non è mai docked perchè è stato controllato prima, in RD3 può invece essere docked: in quel caso saltiamo la BringToFront e 
      // scriviamo il messaggio che avremmo scritto in RD2
      if (f.Docked)
      {
        DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 14, "MainFrm.Show", "Form " + f.Caption() + " already open and docked");
        //
        if (UseZones() && ScreenZone(f.DockType) != null)
        {
          ScreenZone(f.DockType).set_SelectedForm(f.FormIdx);
        }
      }
      else
        BringToFront(FormIdx);
      return;
    }
    //
    RDForm = true; // Dovrò ridisegnare l'intera form!
    WebForm OldForm = ActiveForm();
    //
    // Se non è MDI o sono su mobile (dove memorizzo l'owner anche se è MDI)
    WebForm parentF = null;
    if (OpenAs != Glb.OPEN_MDI || IsMobile())
    {
      // Se la videata è MDI non tengo conto dell'ActiveForm
      parentF = (OpenAs != Glb.OPEN_MDI ? ActiveForm() : null);
      if (ParentObj != null && ParentObj is WebForm)
        parentF = (WebForm)ParentObj;
      //
      // Se da una DOCKED apro una MDI, non le attacco tra loro
      // Ma se è SmartPhone devo comunque attaccarle perché su smartphone c'è una sola videata aperta
      if (parentF != null && parentF.Docked && OpenAs == Glb.OPEN_MDI && !IsSmartPhone())
        parentF = null;
      //
      if (parentF != null)
      {
        Owner = parentF.FormIdx;
        //
        if (OpenAs != Glb.OPEN_MDI)
        {
          // Dato che la nuova form è modale, controllo se la form corrente vuole deattivarsi
          // Se non vuole... non apro la nuova form
          parentF.Form_Deactivate(Cancel);
          parentF.SubForm_Deactivate(Cancel);
          if (Cancel.isTrue())
          {
            DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 12, "MainFrm.Show", "The new form has not been shown, because the parent form " + parentF.Caption() + " refuses to deactivate (cancel := true)");
            return;
          }
        }
      }
      else if (OpenAs != Glb.OPEN_MDI)
        Owner = 32767; // Altrimenti non viene riconosciuta come form modale
    }
    //
    WebForm newform = null;
    // _ICD_WEB_SHOWFORMS
  fine:
    if (newform != null)
      set_ActiveForm(newform);
    //
    ActiveForm().ActivedTick = ClickCounter() + 1;
    StackForm.Insert(0, ActiveForm());
    ActiveForm().Owner = Owner;
    //
    // Inizializzo il testo del back-button
    if (parentF != null && parentF.OpenAs == Glb.OPEN_MDI && OpenAs == Glb.OPEN_MDI && !ActiveForm().Docked)
      ActiveForm().set_BackButTxt(parentF.Caption().stringValue());
    //
    if (ParamsObj().TruePopup && UseRD)
    {
      if (OpenAs != 0 && IEVer >= 600)
      {
        // Se avevo già programmato la chiusura della stessa form, la annullo... la vecchia
        // form verrà sostituita da questa. Altrimenti programmo l'apertura.
        // Sempre che la modale non sia stata chiusa in malomodo... in quel caso... devo
        // aprirne una nuova!
        if (RDClosePopup && !RDPopupClosedForcibly && FormIdx==ClosingForm)
          RDClosePopup = false;
        else
          RDOpenPopup = true;
      }
      //
      // Se c'era già una chiusura in corso di una popup e la nuova form
      // che è stata aperta non è una popup, aspetto a chiudere la modale
      if (RDClosePopup)
        RDDelayPopup = true;
    }
    //
    ActiveForm().OpenAs = OpenAs;
    //
    WebForm oldActiveForm = ActiveForm();
    ActiveForm().Init(this, false, false);
    //
    // Se il programmatore non ha già definito il testo del back button da sè:
    // su smartphone mostro il back-button anche nel caso di modali con closeonselection 
    // (per poterle chiudere senza selezione) solo se la videata non mostra la sua caption 
    // ma quella del pannello (se lo fa i bottoni X e V sono già presenti nella toolbar della videata)
    if (ActiveForm() != null && ActiveForm().BackButTxt().Length == 0 && parentF != null && OpenAs == Glb.OPEN_MODAL && IsSmartPhone() && ActiveForm().CloseOnSelection && ActiveForm().VisualFlag(Glb.FORMVISPROP_HASCAPTION) == 0)
      ActiveForm().set_BackButTxt(parentF.Caption().stringValue());
    //
    // Se è cambiata la form attiva può essere successo che è stata chiusa la videata appena aperta...
    if (oldActiveForm != ActiveForm())
    {
      // Se la vecchia form, quella appena aperta, è ancora nello stack form... devo proseguire
      bool flIsStillOpen = false;
      IEnumerator i = StackForm.GetEnumerator();
      while (i.MoveNext())
      {
        if ((WebForm)i.Current == oldActiveForm)
        {
          flIsStillOpen = true;
          break;
        }
      }
      //
      // Se è stata chiusa... non devo proseguire!
      if (!flIsStillOpen)
        return;
    }
    //
    // Proseguo... informo l'RD3 che deve aprire questa form
    RD3Event ev = RD3AddEvent("open", "frm:" + FormIdx);
    if (OpenAs != 0)
      ev.SetAttribute("openas", OpenAs.ToString());
    //
    // Se è cambiata l'ActiveForm, allora potrebbe essere successo che nell'evento di OnLoad:
    // 1) è stata aperta o attivata un'altra form
    // 2) la form è stata resa invisibile
    // 3) la form è stata chiusa
    // In questo caso attivo la vecchia form, se non ce ne è nessuna attiva
    if (oldActiveForm != ActiveForm())
    {
      // Se è uno dei casi 2 o 3 e non c'erano altre form già aperte, ActiveForm diventa NULL
      // In questo caso ripristino la form attiva
      if (ActiveForm() == null)
        set_ActiveForm(OldForm);
      //
      // Informo l'RD3 che occorre attivare questa form
      if (ActiveForm() != null)
        RD3AddEvent("activateform", "frm:" + ActiveForm().FormIdx);
      return;
    }
    //
    // Docked Forms
    if (ActiveForm().Docked)
    {
      if (!ParamsObj().UseRD3)
      {
        RDDockForm = true;
        if (DockedForm() != null) // Sostituzione Docked Form
        {
          UnloadForm(DockedForm().FormIdx, false);
          set_DockedForm(null); // Forzo Chiusura
        }
        StackForm.Remove(ActiveForm());
        set_DockedForm(ActiveForm());
        set_ActiveForm(OldForm);
        //
        f = DockedForm();
        f.Form_Activate(); // Fire activate event
        f.SubForm_Activate();
        //
        // Ridimensiono il client size!
        if (f.DockType == Glb.FORMDOCK_LEFT || f.DockType == Glb.FORMDOCK_RIGHT)
          ResizeClient(ScreenW() - f.OrgWidth + f.GetPadding(false) + 1, ScreenH(), false);
        else
          ResizeClient(ScreenW(), ScreenH() - f.OrgHeight + f.GetPadding(true) + 1, false);
        return;
      }
      else
      {
        // Gestione Form Docked RD3
        // Devo sostituire un'eventuale DockedForm sullo stesso lato
        if (!UseZones())
        {
          foreach (WebForm frm in StackForm)
          {
            if (frm.Docked && frm.DockType == ActiveForm().DockType && frm.FormIdx != ActiveForm().FormIdx)
            {
              UnloadForm(frm.FormIdx, false);
              break;
            }
          }
        }
        //
        WebForm dkf = ActiveForm();
        set_ActiveForm(OldForm);
        //
        if (UseZones() && ScreenZone(dkf.DockType) != null)
          ScreenZone(dkf.DockType).set_SelectedForm(dkf.FormIdx);
        else
        {
          dkf.Form_Activate(); // Fire activate event
          dkf.SubForm_Activate();
        }
        //
        return;
      }
    }
    
    //
    // Se è modale ho già chiesto
    if (OldForm != null && OpenAs == 0)
    {
      OldForm.Form_Deactivate(Cancel);
      OldForm.SubForm_Deactivate(Cancel);
    }
    //
    if (Cancel.isFalse())
    {
      SetHelpFile(ActiveForm().HelpFile);
      f = ActiveForm();
      f.Form_Activate(); // Fire activate event
      f.SubForm_Activate();
    }
    else
    {
      DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 12, "MainFrm.Show", "The form " + ActiveForm().Caption() + " has been shown, but the form " + OldForm.Caption() + " refuses to deactivate (cancel := true)");
      set_ActiveForm(OldForm);
      //
      RD3AddEvent("activateform", "frm:" + ActiveForm().FormIdx);
    }
  }

  // **********************************************
  // Crea una nuova istanza di form a partire dall'indice
  // **********************************************
  public override WebForm CreateFormByIndex(int FormIdx)
  {
    WebForm newform = null;
    // _ICD_WEB_SHOWFORMS
  fine:
    if (newform != null)
    {
      newform.MainFrm = this;
      return newform;
    }
    //
    // Se non ci sono riuscito, provo con i miei componenti
    foreach (WebEntryPoint cmp in CompList)
    {
      newform = cmp.CreateFormByIndex(FormIdx);
      if (newform != null)
        return newform;
    }
    //
    return null;
  }

  // **********************************************
  // Gestione delle FORMS / (by name)
  // **********************************************
  public override bool Show(String FormName, int OpenAs)
  {
    return Show(FormName, OpenAs, null);
  }
  public override bool Show(String FormName, int OpenAs, Object parentObj)
  {
    bool ris = false;
    //
    try
    {
      WebForm newform = (WebForm)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(FormName, true);
      newform.Init(this, false, false);
      Show(newform.FormIdx, OpenAs, parentObj);
    }
    catch(Exception e)
    {
      ;
    }
    return ris;
  }


  // **********************************************************************
  // Open database connection as needed
  // **********************************************************************
  public override void OpenConnection(IDConnection DB)
  {
    if (DB == null || DB.IsOpen())
      return; // Not a connection or not closed
    //
    // _ICD_WEB_OPENDB
  }


  // **********************************************
  // Command Activation Handler
  // **********************************************
  public override void CmdClickCB(int CmdIdx)
  {
    DispatchToComp("CmdClickCB", new Object[] { CmdIdx });
    // _ICD_CMD_CLICK
  }


  // **********************************************
  // Timer Activation Handler
  // **********************************************
  public override void TimerTickCB(int TimerIdx)
  {
    DispatchToComp("TimerTickCB", new Object[] { TimerIdx });
    // _ICD_TIM_TICK
  }


  // **********************************************
  // Get HTML for logoff Button
  // **********************************************
  public override String LogoffButton()
  {
    String HF = "";
    String DTT = "";
    String TEL = "";
    String s = "_ICD_HELPFEATURES";

    if (ActiveHelpFile().Length > 0)
      HF = "<a onclick=\"return OpenDoc('" + ActiveHelpFile() + "','Help','" + s + "');\" href=\"\" id=help><img alt=\"Open Help File\" src=\"images/help.gif\" style=\"border:none; background-image:url(images/btn_bk.gif);\"></a>&nbsp;";
    //
    if (DTTObj.Level > 0 && !DTTObj.TraceEnabled)
      DTT = "<a onclick=\"return OpenDoc('" + UrlForEnc(MyGlb.ITEM_DTT, "") + "','Debug','');\" href=\"\"><img alt=\"Open Debug Window\" src=\"images/bug.gif\" style=\"border:none; background-image:url(images/btn_bk.gif);\"></a>&nbsp;";
    //
    if (DTTObj.HelpEnabled && DTTObj.CanSendHelpMail(false))
      TEL = "<a href=\"" + UrlFor(MyGlb.ITEM_APP, "") + "&amp;CMD=DTTHELP\"><img alt=\"Request help\" src=\"images/dtthelp.gif\" style=\"border:none; background-image:url(images/btn_bk.gif);\"></a>&nbsp;";
    //
    if (LogoffURL.Length > 0)
      return HF + TEL + DTT + "<a id=\"LOGOFF\" href=\"" + UrlForEnc(MyGlb.ITEM_LOGOFF, "") + "\"><img alt=\"" + RTCObj.GetConst("38ABB688-409C-43A8-BA9F-1ECACD08D957", "Chiude l'applicazione", true) + "\" src=\"images/closex.gif\" style=\"border:none; background-image:url(images/btn_bk.gif);\"></a>";
    else
      return HF + TEL + DTT;
  }

  public String DebugButton()
  {
    if (DTTObj.Level > 0 && !DTTObj.TraceEnabled)
      return "<a href=\"" + UrlForEnc(MyGlb.ITEM_DTT, "") + "\" target=Debug><img alt=\"Open Debug Window\" src=\"images/bug.gif\" style=\"border:none; background-image:url(images/btn_bk.gif);\"></a>";
    //
    return "";
  }

  // **********************************************
  // Show login page
  // **********************************************
  public override void ShowLogin()
  {
    // Per il problema dell'F5 dovrò rispondere con una paginetta di pre-desktop
    PreDesktopRendered = false;
    //
    // _ICD_HTML_INCLUDE LOGIN1.HTM
    //
  }


  // **********************************************
  // Imposta una url data
  // **********************************************
  public override void SetUrlData(String UD)
  {
    URLData = "";
    if (ParamsObj().IWCacheControl.Equals("URL"))
      URLData = ((double)(Glb.Random.NextDouble() * 2147483647)).ToString();
    //    
    URLData = URLData + UD;
  }

  // **********************************************
  // Esegue il rendering differenziale...
  // **********************************************
  public override void RenderDifferences(bool onlyform)
  {
    String ObjToFocus = "";
    if (ActiveForm() != null)
      ObjToFocus = ActiveForm().ActiveElement;
    //
    // Cappello iniziale
    Out.Write("<html>");
    Out.Write("<head>");
    Out.Write("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1252\">");
    //
    // La disabilitazione della cache del frame RD NON può essere effettuata mentre
    // apro una popup, altrimenti IE impazzisce e ne apre tantissime.
    if (!RDOpenPopup)
    {
      Out.Write("<meta http-equiv=\"Expires\" content=\"-1\">");
      Out.Write("<meta http-equiv=\"Pragma\" content=\"no-cache\">");
    }
    //
    Out.Write("<script language=\"javascript\" src=\"ijlib.js\"></script>");
    Out.Write("<script language=\"javascript\" src=\"dragdrop.js\"></script>");
    Out.Write("<script language=\"javascript\" src=\"custom.js\"></script>");
    Out.Write("<script language=\"javascript\" type=\"text/javascript\">");
    Out.Write("function ApplyRender() { ");
    //
    // Invio nuovamente i dati aggiornati (potrebbero essere cambiati a run-time!)
    if (ParamsObj().UseClientMask)
      Out.Write("  SetDD('" + (UseDecimalDot() ? '.' : ',') + "','" + (UseDecimalDot() ? ',' : '.') + "');");
    //
    if (!RDOpenPopup && !RDClosePopup)
    {
      if (!onlyform)
      {
        int dt = (DockedForm() != null) ? DockedForm().DockType : 0;
        if (dt!=LastDockType)
        {
          // Devo fare il render dell'intera DOCK+FORM area
          ResBuf.Length = 0;
          RenderPageTable();
          SendRenderCmd("PageTable");
          RDForm = false;
          RDDockForm = false;
        }
        //
        if (RDHeader)
        {
          // Devo fare il rendering dell'intera header bar
          ResBuf.Length = 0;
          RenderHeader();
          SendRenderCmd("hdr");
        }
        //
        if (CmdObj.RDAll)
        {
          // Devo fare il rendering dell'intera menù bar
          ResBuf.Length = 0;
          RenderMenuBar();
          SendRenderCmd("MenuTable");
        }
        else
        {
          // Analizzo interno del menù
          CmdObj.RenderMenuDifference();
        }
      }
      //
      if (RDForm || (ActiveForm() != null && ActiveForm().RDUpload))
      {
        // Devo fare il rendering dell'intera active form
        // Resetto i tasti funzione che qui possono essere diversi...
        Out.Write(WebFrame.GetCCFK());
        ResBuf.Length = 0;
        RenderActiveForm();
        SendRenderCmd("ActiveForm");
        ResBuf.Length = 0;
        RenderFormListInternal();
        SendRenderCmd("FormList");
      }
      else
      {
        if (ActiveForm() != null)
        {
          if (ActiveForm().RDCaption && !CmdObj.SuppressMenu())
          {
            ResBuf.Length = 0;
            RenderFormListInternal();
            SendRenderCmd("FormList");
          }
          ActiveForm().RenderDifference();
        }
      }
      //
      if (!onlyform)
      {
        if (RDDockForm)
        {
          // Devo fare il rendering dell'intera active form
          ResBuf.Length = 0;
          RenderDockedForm();
          SendRenderCmd("DockForm");
        }
        else
        {
          if (DockedForm() != null)
            DockedForm().RenderDifference();
        }
        //
        if (RDSB || RDForm)
        {
          ResBuf.Length = 0;
          RenderStatusBar();
          SendRenderCmd("StatusBarTable");
        }
        //
        if (CmdObj.IsTBRD())
        {
          ResBuf.Length = 0;
          if (CmdObj.IsToolbarPresent())
          {
            WriteStr("<table id=ToolBar><tr>"); // Tool Bar Definition            
            //
            // _ICD_HTML_INCLUDE TB1.HTM
            //
            CmdObj.RenderToolbar();
            //
            // _ICD_HTML_INCLUDE SB2.HTM
            //
            WriteStr("</tr></table>");
          }
          SendRenderCmd("ToolBarTable");
        }
      }
    }
    else
    {
      if (RDOpenPopup && RDForm && ActiveForm() != null)
      {
        WebForm fo = GetForm(ActiveForm().Owner, 0, false);
        if (fo != null)
        {
          fo.RenderDifference();
          fo.ResetRD();
          Out.Write(" ApplyRD2();");
        }
      }
    }
    //
    // Cappello finale
    if (!RDOpenPopup && !RDClosePopup)
    {
      Out.Write(" window.setTimeout(\"ChangeTarget();\",10);");
      Out.Write(" ep('" + (ResTotal / 1024) + "-" + ResCount + (GZipEnabled == 0 ? " NOZIP" : "") + "');");
      Out.Write(" window.setTimeout(\"SetFocus('" + ObjToFocus + "')\",20);");
      if (!RedirectTo().stringValue().Equals("") && !DTTObj.TestRunning)
      {
        set_RedirectTo(IDL.Replace(RedirectTo(), new IDVariant("\\"), new IDVariant("/")));
        if (RedirectNewWindow())
        {
          bool ismodal = false;
          //
          if (RedirectFeatures().stringValue().ToLower().IndexOf("modal") != -1)
          {
            Out.Write("window.showModalDialog(" + MyGlb.JSEncode2(RedirectTo()));
            ismodal = true;
          }
          else
          {
            Out.Write("window.setTimeout(\"window.open(" + MyGlb.JSEncode2(RedirectTo(), "\\\""));
          }
          if (!RedirectFeatures().stringValue().Equals(""))
            Out.Write(", "+ (WidgetMode?"'browser'":"null")+ ", " + MyGlb.JSEncode(RedirectFeatures()));
          //
          if (ismodal)
            Out.Write("); ");
          else
            Out.Write(");\",200); ");
        }
        else
          Out.Write(" GetFrame(window.parent.frames,'Main').location.href=" + MyGlb.JSEncode2(RedirectTo()) + "; ");
        //
        // Gestita Redirect
        set_RedirectNewWindow(false);
        set_RedirectTo(new IDVariant(""));
        set_RedirectFeatures(new IDVariant(""));
      }
      //
      RenderPDFPrints();
    }
    //
    // Menu popup su PField
    if (!MenuIdx.Equals(""))
    {
      // Recupero la direzione corrente
      IDVariant Dir = null;
      if (MenuIdx.IndexOf("|") != -1)
      {
        Dir = new IDVariant(Int32.Parse(MenuIdx.Substring(MenuIdx.IndexOf("|") + 1)));
        MenuIdx = MenuIdx.Substring(0, MenuIdx.IndexOf("|"));
      }
      else
        Dir = new IDVariant(1); // Default: Bottom
      //
      // Recupero il CmdSet ed il FormIdx
      int CmdSetIdx;
      String ObjIDs;
      int FormIdx;
      CmdSetIdx = Int32.Parse(MenuIdx.Substring(0, MenuIdx.IndexOf(":")));
      MenuIdx = MenuIdx.Substring(MenuIdx.IndexOf(":") + 1);
      ObjIDs = MenuIdx.Substring(0, MenuIdx.IndexOf(":"));
      MenuIdx = MenuIdx.Substring(MenuIdx.IndexOf(":") + 1);
      FormIdx = Int32.Parse(MenuIdx);
      if (FormIdx == -1)
      {
        if (ActiveForm() != null)
          FormIdx = ActiveForm().FormIdx;
        else
          FormIdx = 0;
      }
      //
      // Mostro il menu
      ResBuf.Length = 0;
      CmdObj.RenderPopupMenu(CmdSetIdx, FormIdx);
      SendRenderCmd(ObjIDs + "|" + Dir.intValue(), "popup");
      MenuIdx = "";
    }
    //
    if (AlertMessage() != null && !AlertMessage().stringValue().Equals("") && !DTTObj.TestRunning && !DTTObj.HelpGenerationActive)
      Out.Write(" msg(" + MyGlb.JSEncode2(AlertMessage()) + "," + AlertType() + "); ");
    //
    if (RDOpenPopup && !RDDelayPopup)
    {
      Rect r = ActiveForm().Frames[1].GetTotalSize();
      int w = r.Width;
      int h = r.Height;
      String rectstr;
      //
      h = h + MyGlb.PAN_OFFS_PAGEY + MyGlb.PAN_OFFS_Y + 4 + 40; // Messages
      w = w + 8;
      if (w < 300)
        w = 300;
      if (h < 200)
        h = 200;
      //
      rectstr = "";
      if (ActiveForm().FormLeft != -1)
        rectstr = rectstr + "dialogLeft:" + ActiveForm().FormLeft + "px;";
      if (ActiveForm().FormTop != -1)
        rectstr = rectstr + "dialogTop:" + ActiveForm().FormTop + "px;";
      if (ActiveForm().FormWidth != -1)
        w = ActiveForm().FormWidth;
      if (ActiveForm().FormHeight != -1)
        h = ActiveForm().FormHeight;
      rectstr = rectstr + "dialogHeight:" + h + "px;";
      rectstr = rectstr + "dialogWidth:" + w + "px;";
      //
      Out.Write(" GetFrame(window.parent.frames,'Main').ModIdx=" + ActiveForm().FormIdx + ";");
      Out.Write(" window.showModalDialog(\"" + UrlFor(MyGlb.ITEM_FRAMES, "") + "\",window,\"" + rectstr + "help:no;status:no;resizable:yes;\");");
      Out.Write(" GetFrame(window.parent.frames,'Main').EnableClick=3;");
      Out.Write(" pb('WCI=IWRD&WCE=" + ActiveForm().FormIdx + "');");
      Out.Write(" window.defaultStatus=\"\";");
    }
    else
    {
      if (ScreenW() == 0 || ScreenH() == 0)
      {
        // Se c'è una form aperta che si vuole ridimensionare faccio una richiesta
        bool ric = false;
        //
        if (DockedForm() != null && (DockedForm().ResModeH != Glb.FRESMODE_NONE || DockedForm().ResModeW != Glb.FRESMODE_NONE))
          ric = true;
        //
        IEnumerator i = StackForm.GetEnumerator();
        //    
        while (!ric && i.MoveNext())
        {
          WebForm f = (WebForm) i.Current;
          if (f.ResModeH != Glb.FRESMODE_NONE || f.ResModeW != Glb.FRESMODE_NONE)
            ric = true;
        }
        //
        if (ric)
          Out.Write(" window.setTimeout(\"pb('');\",10);");
      }
    }
    //
    if (RDClosePopup)
      Out.Write(" window.parent.close();");
    //
    if (!RDExitURL.Equals("") && RolObj.CheckRole())
    {
      Out.Write(" window.parent.location.href=" + MyGlb.JSEncode2(new IDVariant(RDExitURL)) + "; ");
      RDExitURL = "";
    }
    //
    if (RefreshInterval().intValue() > -1)
      Out.Write(" SetRefresh(" + (1000 * RefreshInterval().dblValue()) + "); ");
    //
    if (ActiveForm() != null && ActiveForm().ScrollTop >= 0)
      Out.Write(" sct(" + ActiveForm().ScrollTop + "); ");
    //
    Out.Write(" } </script></head><body onload=\"NextRD();\">");
    //
    // Form
    Out.Write("<form id=theform method=post action=\"" + UrlFor(MyGlb.ITEM_RD, "") + "\">");
    Out.Write("<input type=hidden id=ss name=ss>");
    Out.Write("<input type=hidden id=ace name=ace>");
    Out.Write("<input type=hidden id=pd name=pd>");
    Out.Write("<input type=hidden id=cmd name=cmd>");
    Out.Write("<input type=hidden id=keys name=keys>");
    RenderTrayletCommand(); // Renderizza l'IFRAME per chiamare la traylet!
    //
    // Vedi commenti sopra
    if (RDOpenPopup)
      Out.Write("</form></body></html>");
    else
      Out.Write("</form></body><head><meta http-equiv=\"Pragma\" content=\"no-cache\"><meta http-equiv=\"Expires\" content=\"-1\"></head></html>");
    //
    if (!RDOpenPopup && !RDClosePopup)
      ResetRD();
    if (RDDelayPopup)
      RDDelayPopup = false;
    else
      RDOpenPopup = false;
    RDClosePopup = false;
    if (AlertType() == 0)
    {
      ConfStack.Clear();
      set_AlertMessage(new IDVariant(""));
    }
  }

  // **********************************************
  // Esegue il rendering dell'header
  // **********************************************
  public void RenderHeader()
  {
    //
    // _ICD_HTML_INCLUDE HEADER.HTM
    //
  }


  // **********************************************
  // Esegue il rendering della menu bar intera
  // **********************************************
  public void RenderMenuBar()
  {
    if (CmdObj.IsMenuPresent())
    {
      WriteStr("<table class=w100 id=Menu cellspacing=0 cellpadding=0>");
      //
      // _ICD_HTML_INCLUDE MENU1.HTM
      //
      CmdObj.RenderMenu();
      //
      // _ICD_HTML_INCLUDE MENU2.HTM
      //
      // Rendering window list
      // _ICD_HTML_INCLUDE FORMLIST1.HTM
      //
      RenderFormList();
      //
      // _ICD_HTML_INCLUDE FORMLIST2.HTM
      //
      WriteStr("</table>");
    }
  }

  // **********************************************
  // Esegue il rendering della menu bar intera
  // **********************************************
  public void RenderStatusBar()
  {
    bool Messages = false;
    //
    if (ActiveForm() != null)
      Messages = ActiveForm().HasMessages();
    if (IndObj.IsStatusBarPresent())
    {
      WriteStr("<div id=StatusBar>"); // Status Bar Definition
      //
      // _ICD_HTML_INCLUDE SB1.HTM
      //
      IndObj.Render();
      //
      // _ICD_HTML_INCLUDE SB2.HTM
      //
      WriteStr("</div>");
    }
    if (ActiveForm() != null)
      ActiveForm().RenderMessages();
  }

  // **********************************************
  // Esegue il rendering dell'intera form!
  // **********************************************
  public void RenderActiveForm() { RenderActiveForm(false); }
  public void RenderActiveForm(bool flmsg)
  {
    if (ErrObj.IsError())
    {
      ErrObj.Render();
      //RefreshNextClick = True
    }
    else
    {
      if (ActiveForm() != null)
      {
        ActiveForm().ActivedTick = ClickCounter();
        ActiveForm().Render(flmsg);
      }
      else
      {
        // _ICD_HTML_INCLUDE WELCOME.HTM
      }
    }
  }

  // **********************************************
  // Get parameters
  // **********************************************
  public MyParams MyParamsObj()
  {
    return (MyParams)iParamsObj;
  }

  // **********************************************
  // Get DB by code
  // **********************************************
  public override IDConnection GetDBByName(String Name)
  {
    // Scateno l'evento... se vogliono mi cambiano il nome
    // dandomi il vero nome e preparando il DB come vogliono
    IDVariant TrueName = new IDVariant(Name);
    OnGetDBByName(TrueName);
    Name = TrueName.stringValue();
    //
    // _ICD_DB_GETBYNAME
    //
    if (CompOwner != null)
      return CompOwner.GetDBByName(Name);
    else
      return null;
  }

  public override void OnOpenPopup(ACommand SrcObj, IDVariant Direction, IDVariant Cancel)
  {
    DispatchToComp("OnOpenPopup", new Object[] { SrcObj, Direction, Cancel });
    // _ICD_CMD_DISP OnOpenPopup(Direction, Cancel)
  }

  public override void OnCmdSetCommand(ACommand SrcObj, IDVariant CmdIdx, IDVariant ChildIdx, IDVariant Cancel)
  {
    DispatchToComp("OnCmdSetCommand", new Object[] { SrcObj, CmdIdx, ChildIdx, Cancel });
    // _ICD_CMD_DISP OnCmdSetCommand(CmdIdx, ChildIdx, Cancel)
  }

  public override void OnCmdSetChangeExpand(ACommand SrcObj, IDVariant Expand, IDVariant Cancel)
  {
    DispatchToComp("OnCmdSetChangeExpand", new Object[] { SrcObj, Expand, Cancel });
    // _ICD_CMD_DISP OnCmdSetChangeExpand(Expand, Cancel)
  }
  
  public override void OnCmdSetGeneralDrag(ACommand SrcObj, IDVariant DragInfo, IDVariant CmdIdx, IDVariant ChildIdx)
  {
    DispatchToComp("OnCmdSetGeneralDrag", new Object[] { SrcObj, DragInfo, CmdIdx, ChildIdx });
    // _ICD_CMD_DISP OnCmdSetGeneralDrag(DragInfo, CmdIdx, ChildIdx)
  }
  
  public override void OnCmdSetGeneralDrop(ACommand SrcObj, IDVariant DragInfo, IDVariant CmdIdx, IDVariant ChildIdx)
  {
    DispatchToComp("OnCmdSetGeneralDrop", new Object[] { SrcObj, DragInfo, CmdIdx, ChildIdx });
    // _ICD_CMD_DISP OnCmdSetGeneralDrop(DragInfo, CmdIdx, ChildIdx)
  }

  // **********************************************
  // Update Controls against IMDB variations
  // **********************************************
  public override void UpdateControls()
  {
    DispatchToComp("UpdateControls", new Object[] { });
    // _ICD_CMD_UPDATE
  }


  // **********************************************
  // Procedure Definition
  // **********************************************
  // _ICD_PROC


  // **********************************************
  // Event Stubs
  // **********************************************
  // _ICD_EVENT_STUB


  // **********************************************
  // Show Desktop page
  // **********************************************
  public override void ShowDesktop()
  {
    if (RD3CompressFiles)
    {
      RenderAllImages(true);
    }
    else
    {
      // No compressione. Invio il file Desktop.htm
      StreamFile(RealPath + "/Desktop.htm");
    }
  }
  
  // **************************************************************
  // Gestisco l'arrivo di un comando RD3 interno all'XML
  // **************************************************************
  public override bool HandleCommand(XMLNode node)
  {
    // Leggo il nome del comando 
    String cmdvalue = node.GetAttribute("obn");
    // 
    // Inserisco il comando, e tutti gli eventuali attributi presenti, nella mappa dei parametri
    ExtractUrlParams2("CMD=" + cmdvalue);
    cmdvalue = GetUrlParam().stringValue();
    //
    // Replico la gestione del comando della MyWebEntryPoint (riga 327)
    DTTObj.SetRequestName("Command " + cmdvalue, "Query String Command Detected", DTTRequest.PRI_DATA);
    //
    bool ro = RolObj.CheckRole();
    bool cr = false;
    if (ro)
      cr = CmdObj.ExecCmdCode(cmdvalue); // Solo se utente già loggato! (se arrivo qui dovrei essere sicuro, questo controllo non dovrebbe servire)
    if (!ro || !cr)
    {
      // Lancio evento, non era gestita da un comando
      DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 152, "MainFrm.BeginRequest", "Fire OnCommand(" + cmdvalue + ") event");
      OnCommand(new IDVariant(cmdvalue));
    }
    //
    if (cmdvalue.Equals("?IDVER"))
      DumpVersions(true);
    if (cmdvalue.Equals("?DEBUG"))
      OpenDebugWindow();
    if (cmdvalue.Equals("?DTTOK"))
    {
      DTTObj.DTTStarted = true;
      set_AlertMessage(new IDVariant("DTT Started"));
    }
    if (cmdvalue.Equals("?DTTKO"))
    {
      DTTObj.DTTStarted = false;
      set_AlertMessage(new IDVariant("DTT Stopped"));
    }
    //
    return true;
  }

  // **********************************************
  // Determina la lingua usata dall'applicazione
  // **********************************************
  public override String GetAppLanguage()
  {
    if (RTCObj.Enabled && RolObj.glbLanguage != ".")
      return RolObj.glbLanguage;
    else
      return MyParamsObj().LANGUAGE;
  }

  // **********************************************
  // Determina l'url dell'applicazione
  // **********************************************
  public override String GetAppUrl(bool defDoc, bool defPort)
  {
    // Solo l'applicazione sa rispondere correttamente
    if (CompOwner != null)
      return CompOwner.GetAppUrl(defDoc);
    //
    if (Request == null)
      return "";
    //
    String url = Request.Url.Scheme + "://";
    url += Request["SERVER_NAME"];
    if (Request.Url.Port > 0)
    {
      if (defPort && ((Request.Url.Scheme == "http" && Request.Url.Port != 80) || (Request.Url.Scheme == "https" && Request.Url.Port != 443)))
        url += ":" + Request.Url.Port;
    }
    url += Request.ApplicationPath;
    if (!url.EndsWith("/"))
      url += "/";
    //
    // Se si vuole il documento lo aggiungo
    if (defDoc)
      url += RD3EntryPoint;
    //
    return url;
  }

  // ************************************************************
  // Creo il file di manifest
  // ************************************************************
  public override void AddCustomToManifest(ArrayList CachedFiles) 
  {
    base.AddCustomToManifest(CachedFiles);
    //
    // _ICD_WEB_MANIFEST
  }

  // ************************************************************
  // Elenca i file utilizzati dall'applicazione offline
  // ************************************************************
  public override void GetFontsList(ArrayList Fonts)
  {
    base.GetFontsList(Fonts);
    //
    // _ICD_WEB_FONTLIST
  }
}
// _ICD_COMP_END
