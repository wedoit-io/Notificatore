// **********************************************
// Web Entry Point (session handler)
// Instant WEB Application: www.progamma.com
// Project : Mobile Manager NET4
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

// **********************************************
// Classe base della servlet
// **********************************************
[Serializable]
public sealed class MyWebEntryPoint : WebEntryPoint
{
  public override WebEntryPoint CreateWEP() { return new MyWebEntryPoint(Parent()); }

  bool PreDesktopRendered = true;   // Pre-Inizializzazione: serve per bypassare il problema dell'F5 con videata di login (vedi NPQ 955)
  public MyWebEntryPoint MainFrm;

  //
  // Definition of Database Objects
  public NotificatoreDB NotificatoreDBObject;
  //
  // Definition of External Components
  //
  // Definition of Global Variables
  public IDVariant GLBATTIVAUTO = new IDVariant(0,IDVariant.STRING);
  public IDVariant GLBINDPOSREP = new IDVariant(0,IDVariant.STRING);
  public IDVariant GLBPATHCERTI = new IDVariant(0,IDVariant.STRING);
  public IDVariant GLBWSURL = new IDVariant(0,IDVariant.STRING);
  public IDVariant GLBMAXMESAPN = new IDVariant(0,IDVariant.INTEGER);
  public IDVariant GLBMAXMESC2D = new IDVariant(0,IDVariant.INTEGER);
  public IDVariant GLBATTCHEFEE = new IDVariant(0,IDVariant.STRING);
  public IDVariant GLBRITARSPED = new IDVariant(0,IDVariant.INTEGER);
  public IDVariant GLBRETENDAYS = new IDVariant(0,IDVariant.INTEGER);
  public IDVariant GLBELITOKRIM = new IDVariant(0,IDVariant.STRING);
  public IDVariant GLBCONTATORE = new IDVariant(0,IDVariant.INTEGER);
  public IDVariant GLBTRACE = new IDVariant(0,IDVariant.INTEGER);
  public IDVariant REFREINCORSO = new IDVariant(0,IDVariant.INTEGER);
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
    WelcomeURL = "";
    LogoffURL = "???";
    set_Image("");
    //
    try
    {
      iAccentColor = Convert.ToInt32("0081C2", 16);
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
    catch (Exception) { }
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
    RevNum = 6102;
    IDVer = "16.0.6700";
    AppVersion = "1.0.0.0";
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
    RTCObj.AppGuid = "5D17ACB6-0F41-4CB8-BE2D-0F961D66BA84";
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
    NotificatoreDBObject = new NotificatoreDB(this);
    SyncObject.SetSyncDB(NotificatoreDBObject);
    //
    GZipEnabled = 1; // unknown
    ResBuf = new StringBuilder(20 * 1024);
    RDStatus = MyGlb.RD_DISABLED;
    //
    set_Caption(new IDVariant("Notificatore"));
    InitPanelGlbFlags();
    IntSesNumber = (int)(Glb.Random.NextDouble() * 2147483647);
    UseRD = ParamsObj().UseRD;
    //
    // Initialize Visual Attributes
    //
    VisAttrObj v = null;
    //
    DTTObj.Init (5, 3, false, false, false, this);
    //
    VisualStyleList.set_Size(MyGlb.MAX_VISATTR);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_DEFAPANESTYL, v);
    v.iGuid = "2CBA05B6-623A-11D4-BDF0-301B4CC10101";
    v.set_Alignment(1, 1);
    v.set_Alignment(2, 3);
    v.set_Alignment(3, 1);
    v.set_ControlType(1);
    v.set_ClassName("");
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(0);
    v.set_HeaderOffset(0);
    v.set_Flags(786689);
    v.set_Color(1, 2105376);
    v.set_GradCol(1, -1);
    v.set_GradDir(1, 1);
    v.set_Opacity(1, 100);
    v.set_Color(2, 2105376);
    v.set_GradCol(2, -1);
    v.set_GradDir(2, 1);
    v.set_Opacity(2, 100);
    v.set_Color(3, 139296);
    v.set_GradCol(3, -1);
    v.set_GradDir(3, 1);
    v.set_Opacity(3, 100);
    v.set_Color(4, 16777215);
    v.set_GradCol(4, -1);
    v.set_GradDir(4, 1);
    v.set_Opacity(4, 100);
    v.set_Color(5, 16777215);
    v.set_GradCol(5, -1);
    v.set_GradDir(5, 1);
    v.set_Opacity(5, 100);
    v.set_Color(6, 16054778);
    v.set_GradCol(6, -1);
    v.set_GradDir(6, 1);
    v.set_Opacity(6, 100);
    v.set_Color(7, 16054778);
    v.set_GradCol(7, -1);
    v.set_GradDir(7, 3);
    v.set_Opacity(7, 100);
    v.set_Color(8, 14869218);
    v.set_GradCol(8, 14869218);
    v.set_GradDir(8, 3);
    v.set_Opacity(8, 100);
    v.set_Color(9, 16446446);
    v.set_GradCol(9, -1);
    v.set_GradDir(9, 1);
    v.set_Opacity(9, 100);
    v.set_Color(10, -1);
    v.set_GradCol(10, -1);
    v.set_GradDir(10, 1);
    v.set_Opacity(10, 100);
    v.set_Color(11, 13684944);
    v.set_GradCol(11, -1);
    v.set_GradDir(11, 1);
    v.set_Opacity(11, 100);
    v.set_Color(12, -1);
    v.set_GradCol(12, -1);
    v.set_GradDir(12, 1);
    v.set_Opacity(12, 100);
    v.set_Color(13, 2105376);
    v.set_GradCol(13, -1);
    v.set_GradDir(13, 1);
    v.set_Opacity(13, 100);
    v.set_Color(14, 14811106);
    v.set_GradCol(14, -1);
    v.set_GradDir(14, 1);
    v.set_Opacity(14, 100);
    v.set_Color(15, 15856627);
    v.set_GradCol(15, -1);
    v.set_GradDir(15, 1);
    v.set_Opacity(15, 100);
    v.set_Color(16, 15658477);
    v.set_GradCol(16, -1);
    v.set_GradDir(16, 1);
    v.set_Opacity(16, 100);
    v.set_Color(17, -1);
    v.set_GradCol(17, -1);
    v.set_GradDir(17, 1);
    v.set_Opacity(17, 100);
    v.set_Color(18, -1);
    v.set_GradCol(18, -1);
    v.set_GradDir(18, 1);
    v.set_Opacity(18, 100);
    v.set_Color(19, -1);
    v.set_GradCol(19, -1);
    v.set_GradDir(19, 1);
    v.set_Opacity(19, 100);
    v.set_Color(20, -1);
    v.set_GradCol(20, -1);
    v.set_GradDir(20, 1);
    v.set_Opacity(20, 100);
    v.set_Color(21, -1);
    v.set_GradCol(21, -1);
    v.set_GradDir(21, 1);
    v.set_Opacity(21, 100);
    v.set_Color(22, 16777215);
    v.set_GradCol(22, -1);
    v.set_GradDir(22, 1);
    v.set_Opacity(22, 100);
    v.set_Color(23, 16777215);
    v.set_GradCol(23, -1);
    v.set_GradDir(23, 1);
    v.set_Opacity(23, 100);
    v.set_BorderType(1, 9);
    v.set_BorderType(2, 9);
    v.set_BorderType(3, 4);
    v.set_BorderType(4, 1);
    v.set_BorderType(5, 2);
    v.set_BorderType(6, 4);
    v.set_Font(1, "Arial,,10");
    v.set_Font(2, "Arial,,10");
    v.set_Font(3, "Arial,B,9");
    v.set_Font(4, "Arial,,10");
    v.set_Font(5, "Arial,,10");
    v.set_Font(6, "Tahoma,,8");
    v.set_HorizontalScale(0);
    v.set_LetterSpacing(0);
    v.set_WordSpacing(0);
    v.set_CBorColor(1, 13684944);
    v.set_CBorWidth(1, 4);
    v.set_CBorType(1, 1);
    v.set_CBorPadding(1, 10);
    v.set_CBorColor(2, 13684944);
    v.set_CBorWidth(2, 4);
    v.set_CBorType(2, 2);
    v.set_CBorPadding(2, 10);
    v.set_CBorColor(3, 13684944);
    v.set_CBorWidth(3, 4);
    v.set_CBorType(3, 1);
    v.set_CBorPadding(3, 10);
    v.set_CBorColor(4, 13684944);
    v.set_CBorWidth(4, 4);
    v.set_CBorType(4, 2);
    v.set_CBorPadding(4, 10);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_PRIMAKEYFIEL, v);
    v.iGuid = "2CBA05B7-623A-11D4-BDF0-301B4CC10101";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(1835265);
    v.set_Color(1, 139);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_FOREIKEYFIEL, v);
    v.iGuid = "2CBA05B8-623A-11D4-BDF0-301B4CC10101";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_BLOCKEFIELDS, v);
    v.iGuid = "2CBA05BA-623A-11D4-BDF0-301B4CC10101";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(786433);
    v.set_Color(1, 8355711);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_LOOKUPFIELDS, v);
    v.iGuid = "2CBA05BB-623A-11D4-BDF0-301B4CC10101";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Color(4, 16446446);
    v.set_Color(5, 16446446);
    v.set_Color(9, 16051431);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_LABELFIELD, v);
    v.iGuid = "0AA3D5EF-9931-11D4-8EBD-6C2303000000";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(917761);
    v.set_Color(4, -1);
    v.set_Color(5, -1);
    v.set_Color(9, -1);
    v.set_Color(15, -1);
    v.set_Color(16, -1);
    v.set_Color(22, -1);
    v.set_Color(23, -1);
    v.set_BorderType(6, 1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_HYPERLIFIELD, v);
    v.iGuid = "D4423A16-E154-11D4-9021-88F920000000";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_LABELFIELD));
    v.set_Flags(4063489);
    v.set_Color(1, 16711680);
    v.set_Font(1, "Arial,U,10");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_IMAGEFIELD, v);
    v.iGuid = "0C892579-65CA-494B-B7D0-B06FD2CA39FC";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_LABELFIELD));
    v.set_Flags(1966337);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_INTESTPICCOL, v);
    v.iGuid = "0D1D06B1-15E5-462E-A70D-E482279E6941";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_LABELFIELD));
    v.set_Alignment(1, 4);
    v.set_Flags(4063233);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_COMMANBUTTO1, v);
    v.iGuid = "D47A9B39-CB14-11D5-93C0-6A9CBE000000";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Alignment(1, 3);
    v.set_ControlType(6);
    v.set_Flags(3539201);
    v.set_Color(4, -1);
    v.set_Color(5, -1);
    v.set_Color(9, -1);
    v.set_Color(14, -1);
    v.set_Color(15, -1);
    v.set_Color(16, -1);
    v.set_Color(22, -1);
    v.set_Color(23, -1);
    v.set_BorderType(1, 1);
    v.set_BorderType(6, 1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_COMAIPHOGRAN, v);
    v.iGuid = "EED58399-F463-4484-9F8B-0269A124CE00";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_COMMANBUTTO1));
    v.set_Flags(2490369);
    v.set_Color(1, 0);
    v.set_Color(2, 4473924);
    v.set_Color(3, 0);
    v.set_Color(8, 15790320);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Color(10, 10551295);
    v.set_Color(11, 12632256);
    v.set_Color(20, 0);
    v.set_Font(1, "Arial,B,12");
    v.set_Font(2, "Arial,,12");
    v.set_Font(3, "Arial,I,12");
    v.set_Font(4, "Arial,,12");
    v.set_Font(5, "Arial,,12");
    v.set_Font(6, "Arial,,12");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_COMANDIPHONE, v);
    v.iGuid = "603D5896-9031-4FA7-8B0C-7DA98FD4BE81";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_COMMANBUTTO1));
    v.set_Flags(2490369);
    v.set_Color(1, 0);
    v.set_Color(2, 4473924);
    v.set_Color(3, 0);
    v.set_Color(8, 15790320);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Color(10, 10551295);
    v.set_Color(11, 12632256);
    v.set_Color(20, 0);
    v.set_Font(2, "Arial,,12");
    v.set_Font(3, "Arial,I,12");
    v.set_Font(4, "Arial,,12");
    v.set_Font(5, "Arial,,12");
    v.set_Font(6, "Arial,,12");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_CHECKSTYLE, v);
    v.iGuid = "622C602E-9B5A-11D4-8ECE-323F96000000";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_ControlType(4);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_PASSWORSTYLE, v);
    v.iGuid = "D47A9B2C-CB14-11D5-93C0-6A9CBE000000";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(852225);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_RADIOSTYLE, v);
    v.iGuid = "DF846B65-D41A-444D-B05F-1378C91F7FC9";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_ControlType(5);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_NORMALFIELDS, v);
    v.iGuid = "2CBA05B9-623A-11D4-BDF0-301B4CC10101";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_VIDEATIPHONE, v);
    v.iGuid = "4D0E9773-B568-494B-BE2B-0FC35111EF74";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_NORMALFIELDS));
    v.set_Flags(786433);
    v.set_Color(1, 0);
    v.set_Color(2, 4473924);
    v.set_Color(3, 0);
    v.set_Color(8, 15790320);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Color(9, 16181214);
    v.set_Color(10, 10551295);
    v.set_Color(11, 12632256);
    v.set_Color(14, 16181214);
    v.set_Color(15, -1);
    v.set_Color(16, 16181471);
    v.set_Color(20, 0);
    v.set_Color(23, -1);
    v.set_Font(1, "Arial,,12");
    v.set_Font(2, "Arial,,12");
    v.set_Font(3, "Arial,I,12");
    v.set_Font(4, "Arial,,12");
    v.set_Font(5, "Arial,,12");
    v.set_Font(6, "Arial,,12");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_BORDORIZCLIC, v);
    v.iGuid = "CF8DC54F-9F69-4CED-801E-25B796881DDB";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_VIDEATIPHONE));
    v.set_Flags(2883585);
    v.set_BorderType(1, 2);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_ARTICOACQUIS, v);
    v.iGuid = "18C6F472-EDB6-4D81-95BD-B43E2B0F6D56";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_VIDEATIPHONE));
    v.set_Color(1, 28270);
    v.set_Color(4, 7526616);
    v.set_Color(5, 7526616);
    v.set_Color(9, 7526616);
    v.set_Color(10, -1);
    v.set_Color(15, 7526616);
    v.set_Color(16, 7526616);
    v.set_Color(18, 8838878);
    v.set_Color(20, 28270);
    v.set_Color(21, 28270);
    v.set_Color(22, 8838878);
    v.set_Color(23, 8838878);
    v.set_Font(1, "Arial,BS,14");
    v.set_Font(4, "Arial,BS,12");
    v.set_Font(5, "Arial,BS,12");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_ARTICNONACQU, v);
    v.iGuid = "A8A26A0F-84A8-403D-8AC9-3860749DD6E7";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_VIDEATIPHONE));
    v.set_Color(9, 16777215);
    v.set_Color(15, 16777215);
    v.set_Color(16, 16777215);
    v.set_Color(18, 16777215);
    v.set_Color(23, 16777215);
    v.set_Font(1, "Arial,B,14");
    v.set_Font(4, "Arial,B,12");
    v.set_Font(5, "Arial,B,12");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_BORDNORMCLIC, v);
    v.iGuid = "74DA3D30-F4F0-412B-B7AD-FA5E344704B2";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_VIDEATIPHONE));
    v.set_Flags(2883585);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_INTESTIPHONE, v);
    v.iGuid = "D5C3BC2F-CE55-43C2-8F37-A6D8D2827AF2";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_NORMALFIELDS));
    v.set_Alignment(1, 3);
    v.set_Flags(1835009);
    v.set_Color(1, 6316128);
    v.set_Color(2, 4473924);
    v.set_Color(3, 0);
    v.set_Color(4, -1);
    v.set_Color(8, 15790320);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Color(9, 16181214);
    v.set_Color(10, 10551295);
    v.set_Color(11, 12632256);
    v.set_Color(14, 16181214);
    v.set_Color(15, -1);
    v.set_Color(16, 16181471);
    v.set_Color(20, 0);
    v.set_Color(23, -1);
    v.set_BorderType(5, 4);
    v.set_BorderType(6, 9);
    v.set_Font(1, "Arial,B,12");
    v.set_Font(2, "Arial,,12");
    v.set_Font(3, "Arial,I,12");
    v.set_Font(4, "Arial,,12");
    v.set_Font(5, "Arial,,12");
    v.set_Font(6, "Arial,,12");
    v.set_CBorPadding(1, 32);
    v.set_CBorWidth(2, 1);
    v.set_CBorPadding(2, 32);
    v.set_CBorPadding(3, 32);
    v.set_CBorWidth(4, 1);
    v.set_CBorPadding(4, 32);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_RADIOIPHONE, v);
    v.iGuid = "6171182D-0154-4883-A520-379C11360428";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_NORMALFIELDS));
    v.set_ControlType(5);
    v.set_Flags(786433);
    v.set_Color(1, 0);
    v.set_Color(2, 4473924);
    v.set_Color(3, 0);
    v.set_Color(8, 15790320);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Color(9, 16181214);
    v.set_Color(10, 10551295);
    v.set_Color(11, 12632256);
    v.set_Color(14, 16181214);
    v.set_Color(15, -1);
    v.set_Color(16, 16181471);
    v.set_Color(20, 0);
    v.set_Color(23, -1);
    v.set_Font(1, "Arial,,12");
    v.set_Font(2, "Arial,,12");
    v.set_Font(3, "Arial,I,12");
    v.set_Font(4, "Arial,,12");
    v.set_Font(5, "Arial,,12");
    v.set_Font(6, "Arial,,12");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_HTML1, v);
    v.iGuid = "0F0AC50A-2248-47A9-8466-3FEE7FA7AA9B";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_NORMALFIELDS));
    v.set_Mask("=");
    v.set_Flags(786433);
    v.set_Color(1, 0);
    v.set_Color(2, 4473924);
    v.set_Color(3, 0);
    v.set_Color(8, 15790320);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Color(9, 16181214);
    v.set_Color(10, 10551295);
    v.set_Color(11, 12632256);
    v.set_Color(14, 16181214);
    v.set_Color(15, -1);
    v.set_Color(16, 16181471);
    v.set_Color(20, 0);
    v.set_Color(23, -1);
    v.set_Font(1, "Arial,,12");
    v.set_Font(2, "Arial,,12");
    v.set_Font(3, "Arial,I,12");
    v.set_Font(4, "Arial,,12");
    v.set_Font(5, "Arial,,12");
    v.set_Font(6, "Arial,,12");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_HTMLORIZ, v);
    v.iGuid = "288262C5-F787-4523-86CE-1B7B6011848E";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_HTML1));
    v.set_BorderType(1, 2);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_HTMLEDITSTYL, v);
    v.iGuid = "8A9099EE-0441-46D1-959A-474AB1390B7F";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_ControlType(7);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_COORDINATA, v);
    v.iGuid = "670F5A09-2E4D-4B2F-A635-9B7C6C662A5E";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Mask("#0.######");
    v.set_Color(9, 15322295);
    v.set_Color(16, 12632256);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_HTML, v);
    v.iGuid = "A5AE1408-9B44-4ADC-A3DE-12C089FB2D3A";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Mask("=");
    v.set_Flags(917761);
    v.set_Color(4, -1);
    v.set_Color(5, -1);
    v.set_Color(9, -1);
    v.set_Color(15, -1);
    v.set_Color(16, -1);
    v.set_Color(22, -1);
    v.set_Color(23, -1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_HTMLSENZBORD, v);
    v.iGuid = "A9651BD6-76EC-44B7-9071-A05EF047C5C6";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_HTML));
    v.set_Flags(1966337);
    v.set_BorderType(6, 1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_TRASPARENTE, v);
    v.iGuid = "C01E6AD9-7CCC-4EBF-8EE7-D29CCF8F76CF";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(786433);
    v.set_Opacity(4, 0);
    v.set_Opacity(5, 0);
    v.set_Opacity(6, 0);
    v.set_Color(9, 16777215);
    v.set_Opacity(9, 0);
    v.set_Color(15, 16777215);
    v.set_Opacity(15, 0);
    v.set_Color(16, 16777215);
    v.set_Opacity(16, 0);
    v.set_Opacity(22, 0);
    v.set_Opacity(23, 0);
    v.set_BorderType(1, 1);
    v.set_BorderType(6, 1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_SQUADRATTIVA, v);
    v.iGuid = "87A82AD0-87C7-4107-8D20-17ECF557E0EF";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(786433);
    v.set_Color(1, 32768);
    v.set_Color(20, 32768);
    v.set_Color(21, 32768);
    v.set_Font(1, "Arial,B,10");
    v.set_Font(4, "Arial,B,10");
    v.set_Font(5, "Arial,B,10");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_GIOCATCAMBIA, v);
    v.iGuid = "2E8AC3F2-C648-4BE4-A907-ADB0B7CA43A7";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(786433);
    v.set_Font(1, "Arial,B,10");
    v.set_Font(4, "Arial,B,10");
    v.set_Font(5, "Arial,B,10");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_SFONDOGIALLO, v);
    v.iGuid = "42C3159A-A6B9-44A4-8480-8E417D3A143B";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(786433);
    v.set_Color(4, 65535);
    v.set_Color(5, 65535);
    v.set_Color(9, 65535);
    v.set_Color(15, 65535);
    v.set_Color(16, 65535);
    v.set_Color(22, 65535);
    v.set_Color(23, 65535);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_SFONDOROSSO, v);
    v.iGuid = "C7078C78-DD92-49E5-93DF-324A96649CF2";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(786433);
    v.set_Color(1, 0);
    v.set_Color(4, 255);
    v.set_Color(5, 255);
    v.set_Color(6, 16777215);
    v.set_Color(7, 14085101);
    v.set_GradDir(7, 1);
    v.set_Color(8, 13166312);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Color(9, 255);
    v.set_Color(11, 12164479);
    v.set_Color(12, 16777215);
    v.set_Color(14, 16577775);
    v.set_Color(15, 255);
    v.set_Color(16, 255);
    v.set_Color(22, -1);
    v.set_Color(23, -1);
    v.set_CBorWidth(2, 1);
    v.set_CBorWidth(4, 1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_SFONDOVERDE, v);
    v.iGuid = "AAAB19F8-9F1E-4A87-BB32-E8762FCA833D";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(786433);
    v.set_Color(1, 0);
    v.set_Color(4, 65280);
    v.set_Color(5, 65280);
    v.set_Color(6, 16777215);
    v.set_Color(7, 14085101);
    v.set_GradDir(7, 1);
    v.set_Color(8, 13166312);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Color(9, 65280);
    v.set_Color(11, 12164479);
    v.set_Color(12, 16777215);
    v.set_Color(14, 16577775);
    v.set_Color(15, 8453888);
    v.set_Color(16, 65280);
    v.set_Color(22, -1);
    v.set_Color(23, -1);
    v.set_CBorWidth(2, 1);
    v.set_CBorWidth(4, 1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_INSCADENZA, v);
    v.iGuid = "7B91F98F-F33C-4CAA-8F97-84D2E3779327";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(786433);
    v.set_Color(1, 3947580);
    v.set_Color(4, 65535);
    v.set_Color(5, 65535);
    v.set_Color(6, 16777215);
    v.set_Color(7, 14085101);
    v.set_GradDir(7, 1);
    v.set_Color(8, 13166312);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Color(9, 65535);
    v.set_Color(10, 65535);
    v.set_Color(11, 12164479);
    v.set_Color(12, 16777215);
    v.set_Color(14, 16577775);
    v.set_Color(15, 65535);
    v.set_Color(16, 65535);
    v.set_Color(22, -1);
    v.set_Color(23, -1);
    v.set_CBorWidth(2, 1);
    v.set_CBorWidth(4, 1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_DEFAREPOSTYL, v);
    v.iGuid = "EFA25462-6C01-4AB0-A6CA-0A083C3ACE46";
    v.set_Alignment(1, 1);
    v.set_Alignment(2, 1);
    v.set_Alignment(3, 1);
    v.set_ControlType(1);
    v.set_ClassName("");
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(3);
    v.set_HeaderOffset(4);
    v.set_Flags(1);
    v.set_Color(1, 0);
    v.set_GradCol(1, -1);
    v.set_GradDir(1, 1);
    v.set_Opacity(1, 100);
    v.set_Color(2, 0);
    v.set_GradCol(2, -1);
    v.set_GradDir(2, 1);
    v.set_Opacity(2, 100);
    v.set_Color(3, 0);
    v.set_GradCol(3, -1);
    v.set_GradDir(3, 1);
    v.set_Opacity(3, 100);
    v.set_Color(4, -1);
    v.set_GradCol(4, -1);
    v.set_GradDir(4, 1);
    v.set_Opacity(4, 100);
    v.set_Color(5, -1);
    v.set_GradCol(5, -1);
    v.set_GradDir(5, 1);
    v.set_Opacity(5, 100);
    v.set_Color(6, -1);
    v.set_GradCol(6, -1);
    v.set_GradDir(6, 1);
    v.set_Opacity(6, 100);
    v.set_Color(7, -1);
    v.set_GradCol(7, -1);
    v.set_GradDir(7, 1);
    v.set_Opacity(7, 100);
    v.set_Color(8, -1);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Opacity(8, 100);
    v.set_Color(9, -1);
    v.set_GradCol(9, -1);
    v.set_GradDir(9, 1);
    v.set_Opacity(9, 100);
    v.set_Color(10, -1);
    v.set_GradCol(10, -1);
    v.set_GradDir(10, 1);
    v.set_Opacity(10, 100);
    v.set_Color(11, 8355711);
    v.set_GradCol(11, -1);
    v.set_GradDir(11, 1);
    v.set_Opacity(11, 100);
    v.set_Color(12, 12632256);
    v.set_GradCol(12, -1);
    v.set_GradDir(12, 1);
    v.set_Opacity(12, 100);
    v.set_Color(13, 0);
    v.set_GradCol(13, -1);
    v.set_GradDir(13, 1);
    v.set_Opacity(13, 100);
    v.set_Color(14, 12648384);
    v.set_GradCol(14, -1);
    v.set_GradDir(14, 1);
    v.set_Opacity(14, 100);
    v.set_Color(15, 12632256);
    v.set_GradCol(15, -1);
    v.set_GradDir(15, 1);
    v.set_Opacity(15, 100);
    v.set_Color(16, 14737632);
    v.set_GradCol(16, -1);
    v.set_GradDir(16, 1);
    v.set_Opacity(16, 100);
    v.set_Color(17, 14745599);
    v.set_GradCol(17, -1);
    v.set_GradDir(17, 1);
    v.set_Opacity(17, 100);
    v.set_Color(18, -1);
    v.set_GradCol(18, -1);
    v.set_GradDir(18, 1);
    v.set_Opacity(18, 100);
    v.set_Color(19, -1);
    v.set_GradCol(19, -1);
    v.set_GradDir(19, 1);
    v.set_Opacity(19, 100);
    v.set_Color(20, -1);
    v.set_GradCol(20, -1);
    v.set_GradDir(20, 1);
    v.set_Opacity(20, 100);
    v.set_Color(21, -1);
    v.set_GradCol(21, -1);
    v.set_GradDir(21, 1);
    v.set_Opacity(21, 100);
    v.set_Color(22, -1);
    v.set_GradCol(22, -1);
    v.set_GradDir(22, 1);
    v.set_Opacity(22, 100);
    v.set_Color(23, -1);
    v.set_GradCol(23, -1);
    v.set_GradDir(23, 1);
    v.set_Opacity(23, 100);
    v.set_BorderType(1, 1);
    v.set_BorderType(2, 4);
    v.set_BorderType(3, 4);
    v.set_BorderType(4, 4);
    v.set_BorderType(5, 7);
    v.set_BorderType(6, 4);
    v.set_Font(1, "Tahoma,,8");
    v.set_Font(2, "Tahoma,,8");
    v.set_Font(3, "Tahoma,,8");
    v.set_Font(4, "Tahoma,,8");
    v.set_Font(5, "Tahoma,,8");
    v.set_Font(6, "Tahoma,,8");
    v.set_HorizontalScale(0);
    v.set_LetterSpacing(0);
    v.set_WordSpacing(0);
    v.set_CBorColor(1, 13684944);
    v.set_CBorWidth(1, 1);
    v.set_CBorType(1, 1);
    v.set_CBorPadding(1, 1);
    v.set_CBorColor(2, 13684944);
    v.set_CBorWidth(2, 1);
    v.set_CBorType(2, 1);
    v.set_CBorPadding(2, 1);
    v.set_CBorColor(3, 13684944);
    v.set_CBorWidth(3, 1);
    v.set_CBorType(3, 1);
    v.set_CBorPadding(3, 1);
    v.set_CBorColor(4, 13684944);
    v.set_CBorWidth(4, 1);
    v.set_CBorType(4, 1);
    v.set_CBorPadding(4, 1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_COMMANBUTTON, v);
    v.iGuid = "35A1432C-83AD-4FC0-AC73-F1975EC5B17D";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAREPOSTYL));
    v.set_Alignment(1, 3);
    v.set_ControlType(6);
    v.set_Flags(2490625);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_HYPERLINK, v);
    v.iGuid = "79F9869B-2BD8-4446-9CFF-498C56A82BD3";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAREPOSTYL));
    v.set_Flags(2490625);
    v.set_Color(1, 16711680);
    v.set_Font(1, "Tahoma,U,8");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_RIQUADRO, v);
    v.iGuid = "51DC402F-4C20-48C5-B757-97466F63FA4C";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAREPOSTYL));
    v.set_Color(4, 16777215);
    v.set_Color(11, 12632256);
    v.set_BorderType(1, 4);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_RIQUADROBLU, v);
    v.iGuid = "DC72205E-315D-428B-9320-7FEB8A6B7D03";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_RIQUADRO));
    v.set_Color(4, 16774335);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_NORMALREPORT, v);
    v.iGuid = "3E15FB09-3B26-4622-A0F5-7FF082CCD8C8";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAREPOSTYL));
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_CAMPIIPHONE, v);
    v.iGuid = "2FE815B7-A7EF-422F-96DC-8EDD88EAB324";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAREPOSTYL));
    v.set_Flags(2097153);
    v.set_Font(1, "Arial,,12");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_SIMPLICITY, v);
    v.iGuid = "08FD91B7-5C04-4582-B0D5-2EB995A3A0B0";
    v.set_Alignment(1, 1);
    v.set_Alignment(2, 1);
    v.set_Alignment(3, 1);
    v.set_ControlType(1);
    v.set_ClassName("");
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(0);
    v.set_HeaderOffset(4);
    v.set_Flags(786433);
    v.set_Color(1, 3368448);
    v.set_GradCol(1, -1);
    v.set_GradDir(1, 1);
    v.set_Opacity(1, 100);
    v.set_Color(2, 3368448);
    v.set_GradCol(2, -1);
    v.set_GradDir(2, 1);
    v.set_Opacity(2, 100);
    v.set_Color(3, 3368448);
    v.set_GradCol(3, -1);
    v.set_GradDir(3, 1);
    v.set_Opacity(3, 100);
    v.set_Color(4, 16777215);
    v.set_GradCol(4, -1);
    v.set_GradDir(4, 1);
    v.set_Opacity(4, 100);
    v.set_Color(5, 16777215);
    v.set_GradCol(5, -1);
    v.set_GradDir(5, 1);
    v.set_Opacity(5, 100);
    v.set_Color(6, 16777215);
    v.set_GradCol(6, -1);
    v.set_GradDir(6, 1);
    v.set_Opacity(6, 100);
    v.set_Color(7, 14413275);
    v.set_GradCol(7, -1);
    v.set_GradDir(7, 1);
    v.set_Opacity(7, 100);
    v.set_Color(8, 14413275);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Opacity(8, 100);
    v.set_Color(9, 16577775);
    v.set_GradCol(9, -1);
    v.set_GradDir(9, 1);
    v.set_Opacity(9, 100);
    v.set_Color(10, 16706784);
    v.set_GradCol(10, -1);
    v.set_GradDir(10, 1);
    v.set_Opacity(10, 100);
    v.set_Color(11, 6736896);
    v.set_GradCol(11, -1);
    v.set_GradDir(11, 1);
    v.set_Opacity(11, 100);
    v.set_Color(12, -1);
    v.set_GradCol(12, -1);
    v.set_GradDir(12, 1);
    v.set_Opacity(12, 100);
    v.set_Color(13, 3368448);
    v.set_GradCol(13, -1);
    v.set_GradDir(13, 1);
    v.set_Opacity(13, 100);
    v.set_Color(14, 14220504);
    v.set_GradCol(14, -1);
    v.set_GradDir(14, 1);
    v.set_Opacity(14, 100);
    v.set_Color(15, 15660535);
    v.set_GradCol(15, -1);
    v.set_GradDir(15, 1);
    v.set_Opacity(15, 100);
    v.set_Color(16, 15265778);
    v.set_GradCol(16, -1);
    v.set_GradDir(16, 1);
    v.set_Opacity(16, 100);
    v.set_Color(17, -1);
    v.set_GradCol(17, -1);
    v.set_GradDir(17, 1);
    v.set_Opacity(17, 100);
    v.set_Color(18, -1);
    v.set_GradCol(18, -1);
    v.set_GradDir(18, 1);
    v.set_Opacity(18, 100);
    v.set_Color(19, -1);
    v.set_GradCol(19, -1);
    v.set_GradDir(19, 1);
    v.set_Opacity(19, 100);
    v.set_Color(20, -1);
    v.set_GradCol(20, -1);
    v.set_GradDir(20, 1);
    v.set_Opacity(20, 100);
    v.set_Color(21, -1);
    v.set_GradCol(21, -1);
    v.set_GradDir(21, 1);
    v.set_Opacity(21, 100);
    v.set_Color(22, -1);
    v.set_GradCol(22, -1);
    v.set_GradDir(22, 1);
    v.set_Opacity(22, 100);
    v.set_Color(23, -1);
    v.set_GradCol(23, -1);
    v.set_GradDir(23, 1);
    v.set_Opacity(23, 100);
    v.set_BorderType(1, 4);
    v.set_BorderType(2, 4);
    v.set_BorderType(3, 4);
    v.set_BorderType(4, 1);
    v.set_BorderType(5, 2);
    v.set_BorderType(6, 4);
    v.set_Font(1, "Tahoma,,8");
    v.set_Font(2, "Tahoma,,8");
    v.set_Font(3, "Tahoma,B,8");
    v.set_Font(4, "Tahoma,,8");
    v.set_Font(5, "Tahoma,,8");
    v.set_Font(6, "Tahoma,,8");
    v.set_HorizontalScale(0);
    v.set_LetterSpacing(0);
    v.set_WordSpacing(0);
    v.set_CBorColor(1, 13684944);
    v.set_CBorWidth(1, 1);
    v.set_CBorType(1, 1);
    v.set_CBorPadding(1, 1);
    v.set_CBorColor(2, 13684944);
    v.set_CBorWidth(2, 1);
    v.set_CBorType(2, 1);
    v.set_CBorPadding(2, 1);
    v.set_CBorColor(3, 13684944);
    v.set_CBorWidth(3, 1);
    v.set_CBorType(3, 1);
    v.set_CBorPadding(3, 1);
    v.set_CBorColor(4, 13684944);
    v.set_CBorWidth(4, 1);
    v.set_CBorType(4, 1);
    v.set_CBorPadding(4, 1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_CASUAL, v);
    v.iGuid = "4EF4E49D-B51C-4314-ABE0-10647F6866C4";
    v.set_Alignment(1, 1);
    v.set_Alignment(2, 1);
    v.set_Alignment(3, 1);
    v.set_ControlType(1);
    v.set_ClassName("");
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(0);
    v.set_HeaderOffset(4);
    v.set_Flags(786433);
    v.set_Color(1, 2105376);
    v.set_GradCol(1, -1);
    v.set_GradDir(1, 1);
    v.set_Opacity(1, 100);
    v.set_Color(2, 3952720);
    v.set_GradCol(2, -1);
    v.set_GradDir(2, 1);
    v.set_Opacity(2, 100);
    v.set_Color(3, 8998144);
    v.set_GradCol(3, -1);
    v.set_GradDir(3, 1);
    v.set_Opacity(3, 100);
    v.set_Color(4, 16777215);
    v.set_GradCol(4, -1);
    v.set_GradDir(4, 1);
    v.set_Opacity(4, 100);
    v.set_Color(5, 16777215);
    v.set_GradCol(5, -1);
    v.set_GradDir(5, 1);
    v.set_Opacity(5, 100);
    v.set_Color(6, 16777215);
    v.set_GradCol(6, -1);
    v.set_GradDir(6, 1);
    v.set_Opacity(6, 100);
    v.set_Color(7, 14085101);
    v.set_GradCol(7, -1);
    v.set_GradDir(7, 1);
    v.set_Opacity(7, 100);
    v.set_Color(8, 13166312);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Opacity(8, 100);
    v.set_Color(9, 16511466);
    v.set_GradCol(9, -1);
    v.set_GradDir(9, 1);
    v.set_Opacity(9, 100);
    v.set_Color(10, -1);
    v.set_GradCol(10, -1);
    v.set_GradDir(10, 1);
    v.set_Opacity(10, 100);
    v.set_Color(11, 12164479);
    v.set_GradCol(11, -1);
    v.set_GradDir(11, 1);
    v.set_Opacity(11, 100);
    v.set_Color(12, 16777215);
    v.set_GradCol(12, -1);
    v.set_GradDir(12, 1);
    v.set_Opacity(12, 100);
    v.set_Color(13, 8998144);
    v.set_GradCol(13, -1);
    v.set_GradDir(13, 1);
    v.set_Opacity(13, 100);
    v.set_Color(14, 13695974);
    v.set_GradCol(14, -1);
    v.set_GradDir(14, 1);
    v.set_Opacity(14, 100);
    v.set_Color(15, 15660535);
    v.set_GradCol(15, -1);
    v.set_GradDir(15, 1);
    v.set_Opacity(15, 100);
    v.set_Color(16, 14871535);
    v.set_GradCol(16, -1);
    v.set_GradDir(16, 1);
    v.set_Opacity(16, 100);
    v.set_Color(17, -1);
    v.set_GradCol(17, -1);
    v.set_GradDir(17, 1);
    v.set_Opacity(17, 100);
    v.set_Color(18, -1);
    v.set_GradCol(18, -1);
    v.set_GradDir(18, 1);
    v.set_Opacity(18, 100);
    v.set_Color(19, -1);
    v.set_GradCol(19, -1);
    v.set_GradDir(19, 1);
    v.set_Opacity(19, 100);
    v.set_Color(20, -1);
    v.set_GradCol(20, -1);
    v.set_GradDir(20, 1);
    v.set_Opacity(20, 100);
    v.set_Color(21, -1);
    v.set_GradCol(21, -1);
    v.set_GradDir(21, 1);
    v.set_Opacity(21, 100);
    v.set_Color(22, -1);
    v.set_GradCol(22, -1);
    v.set_GradDir(22, 1);
    v.set_Opacity(22, 100);
    v.set_Color(23, -1);
    v.set_GradCol(23, -1);
    v.set_GradDir(23, 1);
    v.set_Opacity(23, 100);
    v.set_BorderType(1, 4);
    v.set_BorderType(2, 4);
    v.set_BorderType(3, 4);
    v.set_BorderType(4, 1);
    v.set_BorderType(5, 2);
    v.set_BorderType(6, 4);
    v.set_Font(1, "Tahoma,,8");
    v.set_Font(2, "Tahoma,,8");
    v.set_Font(3, "Tahoma,B,8");
    v.set_Font(4, "Tahoma,,8");
    v.set_Font(5, "Tahoma,,8");
    v.set_Font(6, "Tahoma,,8");
    v.set_HorizontalScale(0);
    v.set_LetterSpacing(0);
    v.set_WordSpacing(0);
    v.set_CBorColor(1, 13684944);
    v.set_CBorWidth(1, 1);
    v.set_CBorType(1, 1);
    v.set_CBorPadding(1, 1);
    v.set_CBorColor(2, 13684944);
    v.set_CBorWidth(2, 1);
    v.set_CBorType(2, 1);
    v.set_CBorPadding(2, 1);
    v.set_CBorColor(3, 13684944);
    v.set_CBorWidth(3, 1);
    v.set_CBorType(3, 1);
    v.set_CBorPadding(3, 1);
    v.set_CBorColor(4, 13684944);
    v.set_CBorWidth(4, 1);
    v.set_CBorType(4, 1);
    v.set_CBorPadding(4, 1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_SEATTLE, v);
    v.iGuid = "DD74AA17-2B85-43FE-A1DC-6A7B7BF72AEE";
    v.set_Alignment(1, 1);
    v.set_Alignment(2, 1);
    v.set_Alignment(3, 1);
    v.set_ControlType(1);
    v.set_ClassName("");
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(0);
    v.set_HeaderOffset(4);
    v.set_Flags(786689);
    v.set_Color(1, 2105376);
    v.set_GradCol(1, -1);
    v.set_GradDir(1, 1);
    v.set_Opacity(1, 100);
    v.set_Color(2, 3952720);
    v.set_GradCol(2, -1);
    v.set_GradDir(2, 1);
    v.set_Opacity(2, 100);
    v.set_Color(3, 8998144);
    v.set_GradCol(3, -1);
    v.set_GradDir(3, 1);
    v.set_Opacity(3, 100);
    v.set_Color(4, 16777215);
    v.set_GradCol(4, -1);
    v.set_GradDir(4, 1);
    v.set_Opacity(4, 100);
    v.set_Color(5, 16777215);
    v.set_GradCol(5, -1);
    v.set_GradDir(5, 1);
    v.set_Opacity(5, 100);
    v.set_Color(6, 16054778);
    v.set_GradCol(6, -1);
    v.set_GradDir(6, 1);
    v.set_Opacity(6, 100);
    v.set_Color(7, 16382457);
    v.set_GradCol(7, 15658219);
    v.set_GradDir(7, 3);
    v.set_Opacity(7, 100);
    v.set_Color(8, 16777215);
    v.set_GradCol(8, 15658219);
    v.set_GradDir(8, 3);
    v.set_Opacity(8, 100);
    v.set_Color(9, 16446446);
    v.set_GradCol(9, -1);
    v.set_GradDir(9, 1);
    v.set_Opacity(9, 100);
    v.set_Color(10, -1);
    v.set_GradCol(10, -1);
    v.set_GradDir(10, 1);
    v.set_Opacity(10, 100);
    v.set_Color(11, 13547166);
    v.set_GradCol(11, -1);
    v.set_GradDir(11, 1);
    v.set_Opacity(11, 100);
    v.set_Color(12, -1);
    v.set_GradCol(12, -1);
    v.set_GradDir(12, 1);
    v.set_Opacity(12, 100);
    v.set_Color(13, 8998144);
    v.set_GradCol(13, -1);
    v.set_GradDir(13, 1);
    v.set_Opacity(13, 100);
    v.set_Color(14, 14811106);
    v.set_GradCol(14, -1);
    v.set_GradDir(14, 1);
    v.set_Opacity(14, 100);
    v.set_Color(15, 15856627);
    v.set_GradCol(15, -1);
    v.set_GradDir(15, 1);
    v.set_Opacity(15, 100);
    v.set_Color(16, 15658477);
    v.set_GradCol(16, -1);
    v.set_GradDir(16, 1);
    v.set_Opacity(16, 100);
    v.set_Color(17, -1);
    v.set_GradCol(17, -1);
    v.set_GradDir(17, 1);
    v.set_Opacity(17, 100);
    v.set_Color(18, -1);
    v.set_GradCol(18, -1);
    v.set_GradDir(18, 1);
    v.set_Opacity(18, 100);
    v.set_Color(19, -1);
    v.set_GradCol(19, -1);
    v.set_GradDir(19, 1);
    v.set_Opacity(19, 100);
    v.set_Color(20, -1);
    v.set_GradCol(20, -1);
    v.set_GradDir(20, 1);
    v.set_Opacity(20, 100);
    v.set_Color(21, -1);
    v.set_GradCol(21, -1);
    v.set_GradDir(21, 1);
    v.set_Opacity(21, 100);
    v.set_Color(22, 16777215);
    v.set_GradCol(22, -1);
    v.set_GradDir(22, 1);
    v.set_Opacity(22, 100);
    v.set_Color(23, 16777215);
    v.set_GradCol(23, -1);
    v.set_GradDir(23, 1);
    v.set_Opacity(23, 100);
    v.set_BorderType(1, 4);
    v.set_BorderType(2, 4);
    v.set_BorderType(3, 4);
    v.set_BorderType(4, 1);
    v.set_BorderType(5, 2);
    v.set_BorderType(6, 4);
    v.set_Font(1, "Tahoma,,8");
    v.set_Font(2, "Tahoma,,8");
    v.set_Font(3, "Tahoma,B,8");
    v.set_Font(4, "Tahoma,,8");
    v.set_Font(5, "Tahoma,,8");
    v.set_Font(6, "Tahoma,,8");
    v.set_HorizontalScale(0);
    v.set_LetterSpacing(0);
    v.set_WordSpacing(0);
    v.set_CBorColor(1, 13684944);
    v.set_CBorWidth(1, 1);
    v.set_CBorType(1, 1);
    v.set_CBorPadding(1, 1);
    v.set_CBorColor(2, 13684944);
    v.set_CBorWidth(2, 0);
    v.set_CBorType(2, 1);
    v.set_CBorPadding(2, 1);
    v.set_CBorColor(3, 13684944);
    v.set_CBorWidth(3, 1);
    v.set_CBorType(3, 1);
    v.set_CBorPadding(3, 1);
    v.set_CBorColor(4, 13684944);
    v.set_CBorWidth(4, 0);
    v.set_CBorType(4, 1);
    v.set_CBorPadding(4, 1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_ZEN, v);
    v.iGuid = "6F85177E-2EB3-4C60-861F-213F12F8D4F0";
    v.set_Alignment(1, 1);
    v.set_Alignment(2, 3);
    v.set_Alignment(3, 1);
    v.set_ControlType(1);
    v.set_ClassName("");
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(0);
    v.set_HeaderOffset(0);
    v.set_Flags(786689);
    v.set_Color(1, 2105376);
    v.set_GradCol(1, -1);
    v.set_GradDir(1, 1);
    v.set_Opacity(1, 100);
    v.set_Color(2, 2105376);
    v.set_GradCol(2, -1);
    v.set_GradDir(2, 1);
    v.set_Opacity(2, 100);
    v.set_Color(3, 139296);
    v.set_GradCol(3, -1);
    v.set_GradDir(3, 1);
    v.set_Opacity(3, 100);
    v.set_Color(4, 16777215);
    v.set_GradCol(4, -1);
    v.set_GradDir(4, 1);
    v.set_Opacity(4, 100);
    v.set_Color(5, 16777215);
    v.set_GradCol(5, -1);
    v.set_GradDir(5, 1);
    v.set_Opacity(5, 100);
    v.set_Color(6, 16054778);
    v.set_GradCol(6, -1);
    v.set_GradDir(6, 1);
    v.set_Opacity(6, 100);
    v.set_Color(7, 16054778);
    v.set_GradCol(7, -1);
    v.set_GradDir(7, 3);
    v.set_Opacity(7, 100);
    v.set_Color(8, 14869218);
    v.set_GradCol(8, 14869218);
    v.set_GradDir(8, 3);
    v.set_Opacity(8, 100);
    v.set_Color(9, 16446446);
    v.set_GradCol(9, -1);
    v.set_GradDir(9, 1);
    v.set_Opacity(9, 100);
    v.set_Color(10, -1);
    v.set_GradCol(10, -1);
    v.set_GradDir(10, 1);
    v.set_Opacity(10, 100);
    v.set_Color(11, 13684944);
    v.set_GradCol(11, -1);
    v.set_GradDir(11, 1);
    v.set_Opacity(11, 100);
    v.set_Color(12, -1);
    v.set_GradCol(12, -1);
    v.set_GradDir(12, 1);
    v.set_Opacity(12, 100);
    v.set_Color(13, 2105376);
    v.set_GradCol(13, -1);
    v.set_GradDir(13, 1);
    v.set_Opacity(13, 100);
    v.set_Color(14, 14811106);
    v.set_GradCol(14, -1);
    v.set_GradDir(14, 1);
    v.set_Opacity(14, 100);
    v.set_Color(15, 15856627);
    v.set_GradCol(15, -1);
    v.set_GradDir(15, 1);
    v.set_Opacity(15, 100);
    v.set_Color(16, 15658477);
    v.set_GradCol(16, -1);
    v.set_GradDir(16, 1);
    v.set_Opacity(16, 100);
    v.set_Color(17, -1);
    v.set_GradCol(17, -1);
    v.set_GradDir(17, 1);
    v.set_Opacity(17, 100);
    v.set_Color(18, -1);
    v.set_GradCol(18, -1);
    v.set_GradDir(18, 1);
    v.set_Opacity(18, 100);
    v.set_Color(19, -1);
    v.set_GradCol(19, -1);
    v.set_GradDir(19, 1);
    v.set_Opacity(19, 100);
    v.set_Color(20, -1);
    v.set_GradCol(20, -1);
    v.set_GradDir(20, 1);
    v.set_Opacity(20, 100);
    v.set_Color(21, -1);
    v.set_GradCol(21, -1);
    v.set_GradDir(21, 1);
    v.set_Opacity(21, 100);
    v.set_Color(22, 16777215);
    v.set_GradCol(22, -1);
    v.set_GradDir(22, 1);
    v.set_Opacity(22, 100);
    v.set_Color(23, 16777215);
    v.set_GradCol(23, -1);
    v.set_GradDir(23, 1);
    v.set_Opacity(23, 100);
    v.set_BorderType(1, 9);
    v.set_BorderType(2, 9);
    v.set_BorderType(3, 4);
    v.set_BorderType(4, 1);
    v.set_BorderType(5, 2);
    v.set_BorderType(6, 4);
    v.set_Font(1, "Arial,,10");
    v.set_Font(2, "Arial,,10");
    v.set_Font(3, "Arial,B,9");
    v.set_Font(4, "Arial,,10");
    v.set_Font(5, "Arial,,10");
    v.set_Font(6, "Tahoma,,8");
    v.set_HorizontalScale(0);
    v.set_LetterSpacing(0);
    v.set_WordSpacing(0);
    v.set_CBorColor(1, 13684944);
    v.set_CBorWidth(1, 4);
    v.set_CBorType(1, 1);
    v.set_CBorPadding(1, 10);
    v.set_CBorColor(2, 13684944);
    v.set_CBorWidth(2, 4);
    v.set_CBorType(2, 2);
    v.set_CBorPadding(2, 10);
    v.set_CBorColor(3, 13684944);
    v.set_CBorWidth(3, 4);
    v.set_CBorType(3, 1);
    v.set_CBorPadding(3, 10);
    v.set_CBorColor(4, 13684944);
    v.set_CBorWidth(4, 4);
    v.set_CBorType(4, 2);
    v.set_CBorPadding(4, 10);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_BOOTSTRAP, v);
    v.iGuid = "2B3455F0-983B-48AE-98B1-50ECD716A704";
    v.set_Alignment(1, 1);
    v.set_Alignment(2, 3);
    v.set_Alignment(3, 1);
    v.set_ControlType(1);
    v.set_ClassName("");
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(0);
    v.set_HeaderOffset(0);
    v.set_Flags(786689);
    v.set_Color(1, 2105376);
    v.set_GradCol(1, -1);
    v.set_GradDir(1, 1);
    v.set_Opacity(1, 100);
    v.set_Color(2, 2105376);
    v.set_GradCol(2, -1);
    v.set_GradDir(2, 1);
    v.set_Opacity(2, 100);
    v.set_Color(3, 139296);
    v.set_GradCol(3, -1);
    v.set_GradDir(3, 1);
    v.set_Opacity(3, 100);
    v.set_Color(4, -1);
    v.set_GradCol(4, -1);
    v.set_GradDir(4, 1);
    v.set_Opacity(4, 100);
    v.set_Color(5, -1);
    v.set_GradCol(5, -1);
    v.set_GradDir(5, 1);
    v.set_Opacity(5, 100);
    v.set_Color(6, 16054778);
    v.set_GradCol(6, -1);
    v.set_GradDir(6, 1);
    v.set_Opacity(6, 100);
    v.set_Color(7, -1);
    v.set_GradCol(7, -1);
    v.set_GradDir(7, 1);
    v.set_Opacity(7, 100);
    v.set_Color(8, 14869218);
    v.set_GradCol(8, 14869218);
    v.set_GradDir(8, 3);
    v.set_Opacity(8, 100);
    v.set_Color(9, 16446446);
    v.set_GradCol(9, -1);
    v.set_GradDir(9, 1);
    v.set_Opacity(9, 100);
    v.set_Color(10, -1);
    v.set_GradCol(10, -1);
    v.set_GradDir(10, 1);
    v.set_Opacity(10, 100);
    v.set_Color(11, 13684944);
    v.set_GradCol(11, -1);
    v.set_GradDir(11, 1);
    v.set_Opacity(11, 100);
    v.set_Color(12, -1);
    v.set_GradCol(12, -1);
    v.set_GradDir(12, 1);
    v.set_Opacity(12, 100);
    v.set_Color(13, 2105376);
    v.set_GradCol(13, -1);
    v.set_GradDir(13, 1);
    v.set_Opacity(13, 100);
    v.set_Color(14, 14811106);
    v.set_GradCol(14, -1);
    v.set_GradDir(14, 1);
    v.set_Opacity(14, 100);
    v.set_Color(15, -1);
    v.set_GradCol(15, -1);
    v.set_GradDir(15, 1);
    v.set_Opacity(15, 100);
    v.set_Color(16, 15658477);
    v.set_GradCol(16, -1);
    v.set_GradDir(16, 1);
    v.set_Opacity(16, 100);
    v.set_Color(17, -1);
    v.set_GradCol(17, -1);
    v.set_GradDir(17, 1);
    v.set_Opacity(17, 100);
    v.set_Color(18, -1);
    v.set_GradCol(18, -1);
    v.set_GradDir(18, 1);
    v.set_Opacity(18, 100);
    v.set_Color(19, -1);
    v.set_GradCol(19, -1);
    v.set_GradDir(19, 1);
    v.set_Opacity(19, 100);
    v.set_Color(20, -1);
    v.set_GradCol(20, -1);
    v.set_GradDir(20, 1);
    v.set_Opacity(20, 100);
    v.set_Color(21, -1);
    v.set_GradCol(21, -1);
    v.set_GradDir(21, 1);
    v.set_Opacity(21, 100);
    v.set_Color(22, 16777215);
    v.set_GradCol(22, -1);
    v.set_GradDir(22, 1);
    v.set_Opacity(22, 100);
    v.set_Color(23, 16777215);
    v.set_GradCol(23, -1);
    v.set_GradDir(23, 1);
    v.set_Opacity(23, 100);
    v.set_BorderType(1, 4);
    v.set_BorderType(2, 1);
    v.set_BorderType(3, 4);
    v.set_BorderType(4, 1);
    v.set_BorderType(5, 2);
    v.set_BorderType(6, 4);
    v.set_Font(1, "Arial,,10");
    v.set_Font(2, "Arial,,10");
    v.set_Font(3, "Arial,B,9");
    v.set_Font(4, "Arial,,10");
    v.set_Font(5, "Arial,,10");
    v.set_Font(6, "Tahoma,,8");
    v.set_HorizontalScale(0);
    v.set_LetterSpacing(0);
    v.set_WordSpacing(0);
    v.set_CBorColor(1, 13684944);
    v.set_CBorWidth(1, 4);
    v.set_CBorType(1, 1);
    v.set_CBorPadding(1, 10);
    v.set_CBorColor(2, 13684944);
    v.set_CBorWidth(2, 4);
    v.set_CBorType(2, 2);
    v.set_CBorPadding(2, 10);
    v.set_CBorColor(3, 13684944);
    v.set_CBorWidth(3, 4);
    v.set_CBorType(3, 1);
    v.set_CBorPadding(3, 10);
    v.set_CBorColor(4, 13684944);
    v.set_CBorWidth(4, 4);
    v.set_CBorType(4, 2);
    v.set_CBorPadding(4, 10);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_DEFAMOBISTYL, v);
    v.iGuid = "43A16029-32EA-4042-B82D-E48398C51D36";
    v.set_Alignment(1, 1);
    v.set_Alignment(2, 1);
    v.set_Alignment(3, 1);
    v.set_ControlType(1);
    v.set_ClassName("");
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(0);
    v.set_HeaderOffset(0);
    v.set_Flags(786689);
    v.set_Color(1, 0);
    v.set_GradCol(1, -1);
    v.set_GradDir(1, 1);
    v.set_Opacity(1, 100);
    v.set_Color(2, 8419441);
    v.set_GradCol(2, -1);
    v.set_GradDir(2, 1);
    v.set_Opacity(2, 100);
    v.set_Color(3, 7099980);
    v.set_GradCol(3, -1);
    v.set_GradDir(3, 1);
    v.set_Opacity(3, 100);
    v.set_Color(4, 16777215);
    v.set_GradCol(4, -1);
    v.set_GradDir(4, 1);
    v.set_Opacity(4, 100);
    v.set_Color(5, 16777215);
    v.set_GradCol(5, -1);
    v.set_GradDir(5, 1);
    v.set_Opacity(5, 100);
    v.set_Color(6, -1);
    v.set_GradCol(6, -1);
    v.set_GradDir(6, 1);
    v.set_Opacity(6, 100);
    v.set_Color(7, 16382457);
    v.set_GradCol(7, 12102567);
    v.set_GradDir(7, 3);
    v.set_Opacity(7, 100);
    v.set_Color(8, 16777215);
    v.set_GradCol(8, 15658219);
    v.set_GradDir(8, 3);
    v.set_Opacity(8, 100);
    v.set_Color(9, 15790320);
    v.set_GradCol(9, -1);
    v.set_GradDir(9, 1);
    v.set_Opacity(9, 100);
    v.set_Color(10, -1);
    v.set_GradCol(10, -1);
    v.set_GradDir(10, 1);
    v.set_Opacity(10, 100);
    v.set_Color(11, 13421772);
    v.set_GradCol(11, -1);
    v.set_GradDir(11, 1);
    v.set_Opacity(11, 100);
    v.set_Color(12, 16777215);
    v.set_GradCol(12, -1);
    v.set_GradDir(12, 1);
    v.set_Opacity(12, 100);
    v.set_Color(13, 7099980);
    v.set_GradCol(13, -1);
    v.set_GradDir(13, 1);
    v.set_Opacity(13, 100);
    v.set_Color(14, 14811106);
    v.set_GradCol(14, -1);
    v.set_GradDir(14, 1);
    v.set_Opacity(14, 100);
    v.set_Color(15, 16777215);
    v.set_GradCol(15, -1);
    v.set_GradDir(15, 1);
    v.set_Opacity(15, 100);
    v.set_Color(16, 15790320);
    v.set_GradCol(16, -1);
    v.set_GradDir(16, 1);
    v.set_Opacity(16, 100);
    v.set_Color(17, -1);
    v.set_GradCol(17, -1);
    v.set_GradDir(17, 1);
    v.set_Opacity(17, 100);
    v.set_Color(18, -1);
    v.set_GradCol(18, -1);
    v.set_GradDir(18, 1);
    v.set_Opacity(18, 100);
    v.set_Color(19, -1);
    v.set_GradCol(19, -1);
    v.set_GradDir(19, 1);
    v.set_Opacity(19, 100);
    v.set_Color(20, -1);
    v.set_GradCol(20, -1);
    v.set_GradDir(20, 1);
    v.set_Opacity(20, 100);
    v.set_Color(21, -1);
    v.set_GradCol(21, -1);
    v.set_GradDir(21, 1);
    v.set_Opacity(21, 100);
    v.set_Color(22, 16777215);
    v.set_GradCol(22, -1);
    v.set_GradDir(22, 1);
    v.set_Opacity(22, 100);
    v.set_Color(23, 16777215);
    v.set_GradCol(23, -1);
    v.set_GradDir(23, 1);
    v.set_Opacity(23, 100);
    v.set_BorderType(1, 9);
    v.set_BorderType(2, 9);
    v.set_BorderType(3, 4);
    v.set_BorderType(4, 9);
    v.set_BorderType(5, 4);
    v.set_BorderType(6, 9);
    v.set_Font(1, "Arial,,13");
    v.set_Font(2, "Arial,B,13");
    v.set_Font(3, "Arial,B,13");
    v.set_Font(4, "Arial,,13");
    v.set_Font(5, "Arial,,13");
    v.set_Font(6, "Tahoma,,8");
    v.set_HorizontalScale(0);
    v.set_LetterSpacing(0);
    v.set_WordSpacing(0);
    v.set_CBorColor(1, 13684944);
    v.set_CBorWidth(1, 1);
    v.set_CBorType(1, 1);
    v.set_CBorPadding(1, 32);
    v.set_CBorColor(2, 13684944);
    v.set_CBorWidth(2, 0);
    v.set_CBorType(2, 1);
    v.set_CBorPadding(2, 40);
    v.set_CBorColor(3, 13684944);
    v.set_CBorWidth(3, 1);
    v.set_CBorType(3, 1);
    v.set_CBorPadding(3, 32);
    v.set_CBorColor(4, 13684944);
    v.set_CBorWidth(4, 0);
    v.set_CBorType(4, 1);
    v.set_CBorPadding(4, 40);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_PRIKEYFIEMOB, v);
    v.iGuid = "BAE49E85-8C0D-4222-A404-83C5DB962F89";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAMOBISTYL));
    v.set_Flags(1835265);
    v.set_Color(1, 139);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_FORKEYFIEMOB, v);
    v.iGuid = "81F8B2FB-DA5E-4C79-95D1-D741C8BFD85B";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAMOBISTYL));
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_BLOCKFIELMOB, v);
    v.iGuid = "99ED52E9-6C42-4BF2-851D-7D2774698FF8";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAMOBISTYL));
    v.set_Flags(786433);
    v.set_Color(1, 8355711);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_LOOKUFIELMOB, v);
    v.iGuid = "F15E3F4D-1C3F-44B5-AB5C-6F28B23F2D90";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAMOBISTYL));
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_LABELFIELMOB, v);
    v.iGuid = "A8B47B02-5E37-4978-835F-4275B85F4327";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAMOBISTYL));
    v.set_Alignment(1, 3);
    v.set_Flags(1966337);
    v.set_Color(1, 7099980);
    v.set_Color(4, -1);
    v.set_Color(15, -1);
    v.set_Color(16, -1);
    v.set_Color(22, -1);
    v.set_Color(23, -1);
    v.set_BorderType(6, 1);
    v.set_Font(1, "Arial,,11");
    v.set_CBorPadding(2, 0);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_HYPERFIELMOB, v);
    v.iGuid = "B54E087A-BCEC-41AE-8ED5-91E87FD0990C";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_LABELFIELMOB));
    v.set_Flags(4063489);
    v.set_Color(1, 16711680);
    v.set_Font(1, "Arial,U,11");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_IMAGEFIELMOB, v);
    v.iGuid = "126D21F9-8F31-438E-A18E-C39BBC3AD0DF";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_LABELFIELMOB));
    v.set_Alignment(1, 1);
    v.set_Flags(2883841);
    v.set_Color(1, 0);
    v.set_Color(4, 16777215);
    v.set_Color(15, 16777215);
    v.set_Color(16, 15790320);
    v.set_Color(22, 16777215);
    v.set_Color(23, 16777215);
    v.set_BorderType(6, 9);
    v.set_Font(1, "Arial,,13");
    v.set_CBorPadding(2, 40);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_COMMABUTTMOB, v);
    v.iGuid = "959C76FD-D3BB-467D-BFD0-54045A9EAB32";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAMOBISTYL));
    v.set_Alignment(1, 3);
    v.set_ControlType(6);
    v.set_Flags(3539201);
    v.set_Color(1, 8869177);
    v.set_Color(14, -1);
    v.set_Color(15, -1);
    v.set_Color(16, -1);
    v.set_Color(22, -1);
    v.set_Color(23, -1);
    v.set_Font(1, "Arial,B,11");
    v.set_CBorWidth(1, 0);
    v.set_CBorWidth(3, 0);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_CHECKSTYLMOB, v);
    v.iGuid = "F3702BE0-4837-49AC-98C9-B3461F813EFE";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAMOBISTYL));
    v.set_ControlType(4);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_PASSWSTYLMOB, v);
    v.iGuid = "DDFFB40A-6D1D-457F-8098-2ACBBD2A7937";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAMOBISTYL));
    v.set_Flags(852225);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_RADIOSTYLMOB, v);
    v.iGuid = "01F3CF34-A192-4B9E-AEBA-B66EA69D5319";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAMOBISTYL));
    v.set_ControlType(5);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_NORMAFIELMOB, v);
    v.iGuid = "F5ED2E22-0A7B-49B1-821B-765AFEE9F2B6";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAMOBISTYL));
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_HTMEDISTYMOB, v);
    v.iGuid = "1C77869E-E35A-48C8-AAC7-DF0A1B06DB87";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAMOBISTYL));
    v.set_ControlType(7);
    HelpFile = "";
    SetVSInited(1);
    //
    // Listing cached images
    //
    // Initializing WebServices URLs
    WebServicesUrl["NotificatoreWS"] = "http://localhost:3998/NotificatoreWS/NotificatoreWS.asmx";
    WebServicesUrl["WIKIPEDIA"] = "http://dev.wikipedia-lab.org/WikipediaOntologyAPIv3/Service.asmx";
    //
    SetHelpFile(HelpFile);
    ErrObj = new ErrorHandler(this);
    //
    // RD3
    RD3EntryPoint = "Notificatore.aspx";
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
    for (int i = 0; i < TempFiles.Count; i++)
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
        PDFPrint p = (PDFPrint)PDFPrints[i];
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
    //
    // Creation of Global Variables
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
      NotificatoreDBObject.WebInit(this); if (CompOwner != null) iDB = CompOwner.GetDBByName("NotificatoreDB"); if (iDB == null && CompOwnerNT != null) iDB = CompOwnerNT.GetDBByName("NotificatoreDB"); if (iDB != null) NotificatoreDBObject.DB = iDB;
      RTCObj.AppGuid = "5D17ACB6-0F41-4CB8-BE2D-0F961D66BA84";
      RTCObj.PrjGuid = "69EAD523-711E-46FD-B1C6-C2208B480406";
      //
      // Chiamo il metodo base
      base.CreateCompRoles();
      //
      // Ho allineato tutti i componenti... ri-sincronizzo tutte le IMDB delle
      // variabili globali (ora tutte le strutture IMDB sono state mergiate tra loro)
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
    IDDocument d = MyMDOInit.CreateDocument(ClassName, this);
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
    if (d != null)
      d.SetMainFrm(this, IMDB);
    return d;
  }

  public override bool CreateDocument(IDCollection IDColl, String ClassName)
  {
    try
    {
      IDDocument d = MyMDOInit.CreateDocument(ClassName, this);
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
          AppName = AppPath + "/Notificatore.aspx";
          //
          RealPath = System.Web.HttpRuntime.AppDomainAppPath;
          if (RealPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
            RealPath = RealPath.Substring(0, RealPath.Length - 1);
          iTempPath = RealPath + Path.DirectorySeparatorChar + "temp";
          //
          try
          {
            // Se non ci sono le cartelle "temp" e "logs" le creo
            if (!Directory.Exists(TempPath()))
              Directory.CreateDirectory(TempPath());
            //
            String dirLogs = RealPath + Path.DirectorySeparatorChar + "logs";
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
          catch (Exception) { }
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
          catch (Exception) { }
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
          NotificatoreDBObject.WebInit(this);
          RTCObj.AppGuid = "5D17ACB6-0F41-4CB8-BE2D-0F961D66BA84";
          RTCObj.PrjGuid = "69EAD523-711E-46FD-B1C6-C2208B480406";
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
            else if (WebItem.Equals(MyGlb.ITEM_QUERY))
              IWQuery_UserEvent(WebEvent);
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
        WebForm f = (WebForm)i.Current;
        UnloadForm(f.FormIdx, false);
      }
      //
      if (DockedForm() != null)
        UnloadForm(DockedForm().FormIdx, false);
      //
      if (StackForm.Count > 0)
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
            RD3AddEvent("redirect", s);
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
    try
    {
      if (Out != null)
      {
        Out.Write(e.StackTrace); Out.Flush();
      }
      //
      Console.Error.WriteLine(e.Message + "\n" + e.StackTrace); Console.Error.Flush();
    }
    catch (Exception)
    { 
    }
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
    NotificatoreDBObject.CloseConnection();
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
    if (RDStatus != Glb.RD_DISABLED && ParamsObj().TruePopup)
    {
      if (IEVer >= 600 && ActiveForm() != null)
        onlyform = (ActiveForm().OpenAs != Glb.OPEN_MDI) || WidgetMode;
    }
    //
    // Need to redirect?
    //
    if ((!iParamsObj.UseRD3 || Request["WCI"] == "IWBlob") && RDStatus != MyGlb.RD_ACTIVE && RedirectTo().stringValue().Length > 0 && !RedirectNewWindow() && !DTTObj.TestRunning)
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
          FileInfo f = new FileInfo(Glb.ToAbsolutePath(this, RedirectTo().stringValue()));
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
      WriteStr("<html>\n");
      WriteStr("<head>\n");
      WriteStr("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1252\">\n");
      WriteStr("<title>\n");
      WriteStr("" + GetPageTitle() + "\n");
      WriteStr("</title>\n");
      WriteStr("<link rel=stylesheet type=\"text/css\" href=\"iw.css\">\n");
      WriteStr("</head>\n");
      WriteStr("<frameset>\n");
      WriteStr("<frame src=\"" + RedirectTo() + "\">\n");
      WriteStr("</frameset>\n");
      WriteStr("</html>\n");
      //
      // Se c'è RD3, lo spedisce e svuota lui... a meno che non sia uno scaricamento di BLOB
      // In questo caso occorre svuotarlo comunque!
      if (!iParamsObj.UseRD3 || Request["WCI"] == "IWBlob")
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
      if (iParamsObj.UseRD3 && DesktopRendered)
      {
        RenderDifferences3();
        return;
      }
      //
      if (iParamsObj.UseRD3 && !DesktopRendered)
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
    WriteStr(" ChangeRowDelay=" + (ParamsObj().UseFK ? ParamsObj().ChangeRowDelay : 0) + ";");
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
    if (AlertMessage() != null && AlertMessage().stringValue().Length > 0 && !DTTObj.TestRunning && !DTTObj.HelpGenerationActive)
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
    if (MenuIdx != "" && RDStatus != Glb.RD_ACTIVE)
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
    if (FK.Length > 0)
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
        //
        CmdObj.RenderToolbar();
        //
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
    if (MenuIdx != "" && RDStatus != Glb.RD_ACTIVE)
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
    WriteStr("\n");
    WriteStr("\n");
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
    WriteStr("\n");
    WriteStr("\n");
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
    WriteStr("<html>\n");
    WriteStr("<head>\n");
    WriteStr("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1252\">\n");
    WriteStr("<title>Validating HTML</title>\n");
    WriteStr("<link rel=stylesheet type=\"text/css\" href=\"iw.css\">\n");
    WriteStr("<script type=\"text/javascript\">\n");
    WriteStr("function done()\n");
    WriteStr("{\n");
    WriteStr("theform.submit();\n");
    WriteStr("setTimeout('n()', 400);\n");
    WriteStr("}\n");
    WriteStr("function n()\n");
    WriteStr("{\n");
    WriteStr("prog.innerText += '.';\n");
    WriteStr("setTimeout('n()', 400);\n");
    WriteStr("}\n");
    WriteStr("</script>\n");
    WriteStr("</head>\n");
    WriteStr("<body onload=\"done()\" style=\"background-color:white\">\n");
    WriteStr("<center>\n");
    WriteStr("<table style=\"margin-top:30px;border-top: 2 dotted #000080;border-bottom: 2 dotted #000080\" cellpadding=\"5\" cellspacing=\"5\">\n");
    WriteStr("<tr><td><img src=\"dttimg/idi.gif\"></td><td style=\"font-size:26pt;font-weight:bold;color:gray\">Validating HTML</td></tr>\n");
    WriteStr("<tr><td>&nbsp;</td><td id=prog style=\"font-size:26pt;font-weight:bold;color:gray\"></td></tr></table></center>\n");
    WriteStr("<form id=\"theform\" method=\"post\" enctype=\"multipart/form-data\" action=\"http://validator.w3.org/check\">\n");
    WriteStr("<input id=\"ss\" name=\"ss\" type=hidden value=\"1\"/>\n");
    WriteStr("<textarea style=\"display:none\" cols=\"10\" rows=\"10\" name=\"fragment\" id=\"fragment\">\n");
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
    WriteStr("</textarea>\n");
    WriteStr("</form>\n");
    WriteStr("</body>\n");
    WriteStr("</html>\n");
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
    if (FormIdx==MyGlb.FRM_CONFIGURAZIO) { newform = new Configurazione(); goto fine; }
    if (FormIdx==MyGlb.FRM_PRODOTTI) { newform = new Prodotti(); goto fine; }
    if (FormIdx==MyGlb.FRM_APILOCATOR) { newform = new APILocator(); goto fine; }
    if (FormIdx==MyGlb.FRM_APPLICAZIONI) { newform = new Applicazioni(); goto fine; }
    if (FormIdx==MyGlb.FRM_LOGS) { newform = new Logs(); goto fine; }
    if (FormIdx==MyGlb.FRM_IMPOSTAZIIOS) { newform = new ImpostazioniIOS(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVICTOKEIOS) { newform = new DeviceTokenIOS(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVNOTAUTEIO) { newform = new InvioNotificheAUtentiIOS(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVNOADINOIO) { newform = new InvioNotificheADispoitiviNotiIOS(); goto fine; }
    if (FormIdx==MyGlb.FRM_SPEDIZIONIOS) { newform = new SpedizioniIOS(); goto fine; }
    if (FormIdx==MyGlb.FRM_IMPOSTANDROI) { newform = new ImpostazioniAndroid(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVICIDANDRO) { newform = new DeviceIDAndroid(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVNOTAUTEAN) { newform = new InvioNotificheAUtentiAndroid(); goto fine; }
    if (FormIdx==MyGlb.FRM_SPEDIZANDROI) { newform = new SpedizioniAndroid(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVIOGMCMANU) { newform = new InvioGMCManuale(); goto fine; }
    if (FormIdx==MyGlb.FRM_TESTSPEDIZIO) { newform = new TestSpedizione(); goto fine; }
    if (FormIdx==MyGlb.FRM_IMPOSWINPHON) { newform = new ImpostazioniWinPhone(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVIIDWINPHO) { newform = new DeviceIDWinPhone(); goto fine; }
    if (FormIdx==MyGlb.FRM_SPEDIWINPHON) { newform = new SpedizioniWinPhone(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVIWINPMANU) { newform = new InvioWinphoneManuale(); goto fine; }
    if (FormIdx==MyGlb.FRM_IMPOSWINSTOR) { newform = new ImpostazioniWinStore(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVIIDWINSTO) { newform = new DeviceIDWinStore(); goto fine; }
    if (FormIdx==MyGlb.FRM_SPEDIWINSTOR) { newform = new SpedizioniWinStore(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVIOWNSMANU) { newform = new InvioWNSManuale(); goto fine; }
    if (FormIdx==MyGlb.FRM_DISPOSITNOTI) { newform = new DispositiviNoti(); goto fine; }
    if (FormIdx==MyGlb.FRM_LINGUE) { newform = new Lingue(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVICETOKEN) { newform = new DeviceToken(); goto fine; }
    if (FormIdx==MyGlb.FRM_SALESDATA) { newform = new SalesData(); goto fine; }
    if (FormIdx==MyGlb.FRM_CURRENCIES) { newform = new Currencies(); goto fine; }
    if (FormIdx==MyGlb.FRM_PROMOCODES) { newform = new PromoCodes(); goto fine; }
    if (FormIdx==MyGlb.FRM_COUNTRYCODES) { newform = new CountryCodes(); goto fine; }
    if (FormIdx==MyGlb.FRM_PRODTYPEIDEN) { newform = new ProductTypeIdentifiers(); goto fine; }
    if (FormIdx==MyGlb.FRM_FISCALCALEND) { newform = new FiscalCalendar(); goto fine; }
    if (FormIdx==MyGlb.FRM_LOGINIPAD) { newform = new LoginIpad(); goto fine; }
    if (FormIdx==MyGlb.FRM_LOGINIPHONE) { newform = new LoginIphone(); goto fine; }
    if (FormIdx==MyGlb.FRM_GRAFICANDAME) { newform = new GraficoAndamento(); goto fine; }
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
        if (RDClosePopup && !RDPopupClosedForcibly && FormIdx == ClosingForm)
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
    if (FormIdx==MyGlb.FRM_CONFIGURAZIO) { newform = new Configurazione(); goto fine; }
    if (FormIdx==MyGlb.FRM_PRODOTTI) { newform = new Prodotti(); goto fine; }
    if (FormIdx==MyGlb.FRM_APILOCATOR) { newform = new APILocator(); goto fine; }
    if (FormIdx==MyGlb.FRM_APPLICAZIONI) { newform = new Applicazioni(); goto fine; }
    if (FormIdx==MyGlb.FRM_LOGS) { newform = new Logs(); goto fine; }
    if (FormIdx==MyGlb.FRM_IMPOSTAZIIOS) { newform = new ImpostazioniIOS(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVICTOKEIOS) { newform = new DeviceTokenIOS(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVNOTAUTEIO) { newform = new InvioNotificheAUtentiIOS(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVNOADINOIO) { newform = new InvioNotificheADispoitiviNotiIOS(); goto fine; }
    if (FormIdx==MyGlb.FRM_SPEDIZIONIOS) { newform = new SpedizioniIOS(); goto fine; }
    if (FormIdx==MyGlb.FRM_IMPOSTANDROI) { newform = new ImpostazioniAndroid(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVICIDANDRO) { newform = new DeviceIDAndroid(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVNOTAUTEAN) { newform = new InvioNotificheAUtentiAndroid(); goto fine; }
    if (FormIdx==MyGlb.FRM_SPEDIZANDROI) { newform = new SpedizioniAndroid(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVIOGMCMANU) { newform = new InvioGMCManuale(); goto fine; }
    if (FormIdx==MyGlb.FRM_TESTSPEDIZIO) { newform = new TestSpedizione(); goto fine; }
    if (FormIdx==MyGlb.FRM_IMPOSWINPHON) { newform = new ImpostazioniWinPhone(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVIIDWINPHO) { newform = new DeviceIDWinPhone(); goto fine; }
    if (FormIdx==MyGlb.FRM_SPEDIWINPHON) { newform = new SpedizioniWinPhone(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVIWINPMANU) { newform = new InvioWinphoneManuale(); goto fine; }
    if (FormIdx==MyGlb.FRM_IMPOSWINSTOR) { newform = new ImpostazioniWinStore(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVIIDWINSTO) { newform = new DeviceIDWinStore(); goto fine; }
    if (FormIdx==MyGlb.FRM_SPEDIWINSTOR) { newform = new SpedizioniWinStore(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVIOWNSMANU) { newform = new InvioWNSManuale(); goto fine; }
    if (FormIdx==MyGlb.FRM_DISPOSITNOTI) { newform = new DispositiviNoti(); goto fine; }
    if (FormIdx==MyGlb.FRM_LINGUE) { newform = new Lingue(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVICETOKEN) { newform = new DeviceToken(); goto fine; }
    if (FormIdx==MyGlb.FRM_SALESDATA) { newform = new SalesData(); goto fine; }
    if (FormIdx==MyGlb.FRM_CURRENCIES) { newform = new Currencies(); goto fine; }
    if (FormIdx==MyGlb.FRM_PROMOCODES) { newform = new PromoCodes(); goto fine; }
    if (FormIdx==MyGlb.FRM_COUNTRYCODES) { newform = new CountryCodes(); goto fine; }
    if (FormIdx==MyGlb.FRM_PRODTYPEIDEN) { newform = new ProductTypeIdentifiers(); goto fine; }
    if (FormIdx==MyGlb.FRM_FISCALCALEND) { newform = new FiscalCalendar(); goto fine; }
    if (FormIdx==MyGlb.FRM_LOGINIPAD) { newform = new LoginIpad(); goto fine; }
    if (FormIdx==MyGlb.FRM_LOGINIPHONE) { newform = new LoginIphone(); goto fine; }
    if (FormIdx==MyGlb.FRM_GRAFICANDAME) { newform = new GraficoAndamento(); goto fine; }
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
    catch (Exception e)
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
    if (DB == NotificatoreDBObject.DB) NotificatoreDBObject.OpenConnection("", "", "");
  }


  // **********************************************
  // Command Activation Handler
  // **********************************************
  public override void CmdClickCB(int CmdIdx)
  {
    DispatchToComp("CmdClickCB", new Object[] { CmdIdx });
    if (CmdIdx==MyGlb.CMD_CONFIGURAZIO+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_CONFIGURAZIO, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_LOGS+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_LOGS, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_LINGUE+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_LINGUE, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_APILOCATOR+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_APILOCATOR, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_PRODOTTI+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_PRODOTTI, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_APPLICAZIONI+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_APPLICAZIONI, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_DISPOSITNOTI+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_DISPOSITNOTI, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_IMPOSTAZION2+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_IMPOSTAZIIOS, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_DEVICETOKENS+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_DEVICTOKEIOS, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_SPEDIZIONI1+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_SPEDIZIONIOS, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_CURRENCIES+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_CURRENCIES, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_PROMOCODES+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_PROMOCODES, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_COUNTRYCODES+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_COUNTRYCODES, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_PRODTYPEIDEN+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_PRODTYPEIDEN, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_FISCALCALEND+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_FISCALCALEND, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_SALESDATA+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_SALESDATA, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_GRAFICANDAME+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_GRAFICANDAME, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_IMPOSTAZION1+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_IMPOSTANDROI, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_DEVICEID1+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_DEVICIDANDRO, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_SPEDIZIONI2+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_SPEDIZANDROI, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_IMPOSTAZION3+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_IMPOSWINPHON, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_DEVICEID2+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_DEVIIDWINPHO, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_SPEDIZIONI3+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_SPEDIWINPHON, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_IMPOSTAZIONI+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_IMPOSWINSTOR, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_DEVICEID+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_DEVIIDWINSTO, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_SPEDIZIONI+BaseCmdLinIdx)
    {
      MainFrm.Show(MyGlb.FRM_SPEDIWINSTOR, 0, this);
      goto fine;
    }
    if (CmdIdx==MyGlb.CMD_DEBUG+BaseCmdLinIdx)
    {
      goto fine;
    }
    fine: ;
  }


  // **********************************************
  // Timer Activation Handler
  // **********************************************
  public override void TimerTickCB(int TimerIdx)
  {
    DispatchToComp("TimerTickCB", new Object[] { TimerIdx });
      if (TimerIdx == MyGlb.TIM_REFRESPOLLIN + BaseTimerIdx) {  RefreshPolling(); goto fine; }
      fine: ;
  }


  // **********************************************
  // Get HTML for logoff Button
  // **********************************************
  public override String LogoffButton()
  {
    String HF = "";
    String DTT = "";
    String TEL = "";
    String s = "";
    String bkImg = (String.Compare(ParamsObj().Theme, "zen", true) == 0 ? "" : " background-image:url(images/btn_bk.gif);");

    if (ActiveHelpFile().Length > 0)
      HF = "<a onclick=\"return OpenDoc('" + ActiveHelpFile() + "','Help','" + s + "');\" href=\"\" id=help><img alt=\"Open Help File\" src=\"images/help.gif\" style=\"border:none;" + bkImg + "\"></a>&nbsp;";
    //
    if (DTTObj.Level > 0 && !DTTObj.TraceEnabled)
      DTT = "<a onclick=\"return OpenDoc('" + UrlForEnc(MyGlb.ITEM_DTT, "") + "','Debug','');\" href=\"\"><img alt=\"Open Debug Window\" src=\"images/bug.gif\" style=\"border:none;" + bkImg + "\"></a>&nbsp;";
    //
    if (DTTObj.HelpEnabled && DTTObj.CanSendHelpMail(false))
      TEL = "<a href=\"" + UrlFor(MyGlb.ITEM_APP, "") + "&amp;CMD=DTTHELP\"><img alt=\"Request help\" src=\"images/dtthelp.gif\" style=\"border:none;" + bkImg + "\"></a>&nbsp;";
    //
    if (LogoffURL.Length > 0)
      return HF + TEL + DTT + "<a id=\"LOGOFF\" href=\"" + UrlForEnc(MyGlb.ITEM_LOGOFF, "") + "\"><img alt=\"" + RTCObj.GetConst("38ABB688-409C-43A8-BA9F-1ECACD08D957", "Chiude l'applicazione", true) + "\" src=\"images/closex.gif\" style=\"border:none;" + bkImg + "\"></a>";
    else
      return HF + TEL + DTT;
  }

  public String DebugButton()
  {
    if (DTTObj.Level > 0 && !DTTObj.TraceEnabled)
    {
      String bkImg = (String.Compare(ParamsObj().Theme, "zen", true) == 0 ? "" : " background-image:url(images/btn_bk.gif);");
      //
      if (IsBootstrap())
        return "<a href=\"" + UrlForEnc(MyGlb.ITEM_DTT, "") + "\" target=Debug><i class='fa fa-bug'></i></a>";
      else
        return "<a href=\"" + UrlForEnc(MyGlb.ITEM_DTT, "") + "\" target=Debug><img alt=\"Open Debug Window\" src=\"images/bug.gif\" style=\"border:none;" + bkImg + "\"></a>";
    }
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
    WriteStr("<!DOCTYPE html PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">\n");
    WriteStr("<html>\n");
    WriteStr("<head>\n");
    WriteStr("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=UTF-8\">\n");
    WriteStr("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=EmulateIE7\">\n");
    WriteStr("<link rel=stylesheet type=\"text/css\" href=\"dtt.css\">\n");
    WriteStr("<title>Login Page</title>\n");
    WriteStr("<script language=\"javascript\" type=\"text/javascript\">\n");
    WriteStr("function PlayTest() { try { window.parent.frames('Control').NextRequest(); } catch(e) {}; }\n");
    WriteStr("</script>\n");
    WriteStr("<style type=\"text/css\">\n");
    WriteStr("\n");
    WriteStr("body {\n");
    WriteStr("font-family: Helvetica, Arial, sans-serif;\n");
    WriteStr("font-size: 10pt;\n");
    WriteStr("background-color: #F0F0F0;\n");
    WriteStr("margin: 0;\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr(".loginbox {\n");
    WriteStr("position: absolute;\n");
    WriteStr("left: 50%;\n");
    WriteStr("top: 50%;\n");
    WriteStr("width: 340px;\n");
    WriteStr("margin-top: -200px;\n");
    WriteStr("margin-left: -170px;\n");
    WriteStr("background-color: #FFF;\n");
    WriteStr("border-radius: 3px;\n");
    WriteStr("-ms-border-radius: 3px;\n");
    WriteStr("-webkit-box-shadow: 0 2px 4px 0 #CCC;\n");
    WriteStr("-moz-box-shadow: 0 2px 4px 0 #CCC;\n");
    WriteStr("box-shadow: 0 2px 4px 0 #CCC;\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr("h1 {\n");
    WriteStr("font-weight: normal;\n");
    WriteStr("margin: 20px 20px;\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr(".bugBtn {\n");
    WriteStr("position: absolute;\n");
    WriteStr("right: 0;\n");
    WriteStr("top: 0;\n");
    WriteStr("padding: 5px;\n");
    WriteStr("margin: 5px;\n");
    WriteStr("}\n");
    WriteStr(".bugBtn:hover {\n");
    WriteStr("opacity: 0.7;\n");
    WriteStr("filter: alpha( opacity = 70 );\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr("form {\n");
    WriteStr("width: 100%;\n");
    WriteStr("margin: 10px 0;\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr(".button {\n");
    WriteStr("height: 30px;\n");
    WriteStr("line-height: 30px;\n");
    WriteStr("padding: 0;\n");
    WriteStr("overflow: visible;\n");
    WriteStr("vertical-align: middle;\n");
    WriteStr("border-radius: 3px;\n");
    WriteStr("-ms-border-radius: 3px;\n");
    WriteStr("font-size: 10pt;\n");
    WriteStr("font-weight: normal;\n");
    WriteStr("text-transform: uppercase;\n");
    WriteStr("border: none;\n");
    WriteStr("background-color: #8A9399;\n");
    WriteStr("color: #FFF;\n");
    WriteStr("cursor: pointer;\n");
    WriteStr("-webkit-box-shadow: 0 1px 0 0 #666;\n");
    WriteStr("-moz-box-shadow: 0 1px 0 0 #666;\n");
    WriteStr("box-shadow: 0 1px 0 0 #666;\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr(".button:hover {\n");
    WriteStr("background-color: #242D33;\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr("form .button {\n");
    WriteStr("margin-top: 10px;\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr("form input {\n");
    WriteStr("width: 300px !important;\n");
    WriteStr("height: 30px;\n");
    WriteStr("margin: 0 20px;\n");
    WriteStr("margin-bottom: 10px;\n");
    WriteStr("font-size: 10pt;\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr("p {\n");
    WriteStr("font-size: 10pt;\n");
    WriteStr("margin: 0 20px;\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr("label {\n");
    WriteStr("font-size: 10pt;\n");
    WriteStr("line-height: 24px;\n");
    WriteStr("margin: 0 20px;\n");
    WriteStr("display: block;\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr("</style>\n");
    WriteStr("<style id=\"style-1-cropbar-clipper\">\n");
    WriteStr("\n");
    WriteStr(".en-markup-crop-options {\n");
    WriteStr("top: 18px !important;\n");
    WriteStr("left: 50% !important;\n");
    WriteStr("margin-left: -100px !important;\n");
    WriteStr("width: 200px !important;\n");
    WriteStr("border: 2px rgba(255,255,255,.38) solid !important;\n");
    WriteStr("border-radius: 4px !important;\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr(".en-markup-crop-options div div:first-of-type {\n");
    WriteStr("margin-left: 0px !important;\n");
    WriteStr("}\n");
    WriteStr("\n");
    WriteStr("</style>\n");
    WriteStr("</head>\n");
    WriteStr("\n");
    WriteStr("<body onload=\"PlayTest()\">\n");
    WriteStr("\n");
    WriteStr("<div class=\"loginbox\">\n");
    WriteStr("\n");
    WriteStr("   <div class=\"bugBtn\">" + DebugButton() + "</div>\n");
    WriteStr("\n");
    WriteStr("<form method=\"post\" autocomplete=\"off\" name=\"frm\" action=\"Notificatore.aspx\">\n");
    WriteStr("<input type=\"hidden\" name=\"WCI\" value=\"IWLogin\">\n");
    WriteStr("<input type=\"hidden\" name=\"WCE\" value=\"Form1\">\n");
    WriteStr("<input type=\"hidden\" name=\"WCU\">\n");
    WriteStr("      <h1>" + Glb.HTMLEncode(Caption(), true, true) + "</h1>\n");
    WriteStr("<label for=\"USERNAME\">Username</label>\n");
    WriteStr("      <input id=\"USERNAME\" name=\"UserName\" tabindex=\"1\" size=\"20\" value=\"" + Glb.HTMLEncode(RolObj.glbUser) + "\">\n");
    WriteStr("<label for=\"PASSWORD\">Password</label>\n");
    WriteStr("<input id=\"PASSWORD\" type=\"password\" name=\"PassWord\" tabindex=\"2\" size=\"20\">\n");
    WriteStr("<input id=\"LOGIN\" class=\"button\" border=\"0\" name=\"I1\" width=\"83\" height=\"28\" type=\"submit\" value=\"LOGIN\">\n");
    WriteStr("     <p>" + MainFrm.RTCObj.GetConst("4D691B94-E528-4AEC-B319-0F18A9049DB3", "Introduci il tuo Username e&nbsp;Password per accedere al sistema</a>", false) + "</p>\n");
    WriteStr("<!--  <p>Salva le mie credenziali</p><input type=\"checkbox\" name=\"checkbox\" value=\"ON\" /> -->\n");
    WriteStr("\n");
    WriteStr("<script>\n");
    WriteStr("\n");
    WriteStr("\n");
    WriteStr("if (document.frm.UserName.value.length==0)\n");
    WriteStr("document.frm.UserName.focus();\n");
    WriteStr("else\n");
    WriteStr("document.frm.PassWord.focus();\n");
    WriteStr("</script>\n");
    WriteStr("</form>\n");
    WriteStr("\n");
    WriteStr("<p align=\"center\"><img border=\"0\" src=\"images/pow2.gif\" width=\"300\" height=\"60\"></p>\n");
    WriteStr("\n");
    WriteStr("<div id=\"reqdiv\" class=HelpReqDiv style=\"display:none\"></div>\n");
    WriteStr("<div id=\"reqVdiv\" class=HelpReqDiv style=\"display:none\"></div>\n");
    WriteStr("<div id=\"itemdiv\" class=HelpItemDiv style=\"display:none\"></div>\n");
    WriteStr("<img id=\"helpcurs\" class=HelpCurs src=\"dttimg/helpcurs.gif\" style=\"display:none\">\n");
    WriteStr("</div>\n");
    WriteStr("</body>\n");
    WriteStr("</html>\n");
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
        if (dt != LastDockType)
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
            //
            CmdObj.RenderToolbar();
            //
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
            Out.Write(", " + (WidgetMode ? "'browser'" : "null") + ", " + MyGlb.JSEncode(RedirectFeatures()));
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
          WebForm f = (WebForm)i.Current;
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
    WriteStr("<table border=0 style=\"width:100%\" cellspacing=0 cellpadding=0 id=ApplHeader>\n");
    WriteStr("<tr><td style=\"width:100%\">\n");
    WriteStr("" + MenuButton() + "&nbsp;" + Glb.HTMLEncode(Caption(), true, true) + "</td>\n");
    WriteStr("<td style=\"white-space:nowrap\"><span id=cmdspan class=cmdform>cmd: <input class=cmdinput type=text accesskey=\"c\" maxlength=6 name=cmd id=cmdcode size=6></span></td>\n");
    WriteStr("<td style=\"white-space:nowrap\">" + LogoffButton() + "</td>\n");
    WriteStr("</tr></table>\n");
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
      //
      CmdObj.RenderMenu();
      //
      //
      // Rendering window list
      //
      RenderFormList();
      //
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
      //
      IndObj.Render();
      //
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
        WriteStr("<iframe id=welcome src=\"" + WelcomeURL + "\" width=\"100%\" height=\"520px\" frameborder=\"0\"></iframe>\n");
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
  // Get DB by name
  // **********************************************
  public override IDBObject GetDBObjByName(String Name)
  {
    // Scateno l'evento... se vogliono mi cambiano il nome
    // dandomi il vero nome e preparando il DB come vogliono
    IDVariant TrueName = new IDVariant(Name);
    OnGetDBByName(TrueName);
    Name = TrueName.stringValue();
    //
    if (Name.Equals("NotificatoreDB")) return NotificatoreDBObject;
    //
    if (CompOwner != null)
      return CompOwner.GetDBObjByName(Name);
    else
      return null;
  }

  public override void OnOpenPopup(ACommand SrcObj, IDVariant Direction, IDVariant Cancel)
  {
    DispatchToComp("OnOpenPopup", new Object[] { SrcObj, Direction, Cancel });
  }

  public override void OnCmdSetCommand(ACommand SrcObj, IDVariant CmdIdx, IDVariant ChildIdx, IDVariant Cancel)
  {
    DispatchToComp("OnCmdSetCommand", new Object[] { SrcObj, CmdIdx, ChildIdx, Cancel });
  }

  public override void OnCmdSetChangeExpand(ACommand SrcObj, IDVariant Expand, IDVariant Cancel)
  {
    DispatchToComp("OnCmdSetChangeExpand", new Object[] { SrcObj, Expand, Cancel });
  }

  public override void OnCmdSetGeneralDrag(ACommand SrcObj, IDVariant DragInfo, IDVariant CmdIdx, IDVariant ChildIdx)
  {
    DispatchToComp("OnCmdSetGeneralDrag", new Object[] { SrcObj, DragInfo, CmdIdx, ChildIdx });
  }

  public override void OnCmdSetGeneralDrop(ACommand SrcObj, IDVariant DragInfo, IDVariant CmdIdx, IDVariant ChildIdx)
  {
    DispatchToComp("OnCmdSetGeneralDrop", new Object[] { SrcObj, DragInfo, CmdIdx, ChildIdx });
  }

  // **********************************************
  // Update Controls against IMDB variations
  // **********************************************
  public override void UpdateControls()
  {
    DispatchToComp("UpdateControls", new Object[] { });
  }


  // **********************************************
  // Procedure Definition
  // **********************************************
  // **********************************************************************
  // Get Base Url
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public IDVariant GetBaseUrl ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("F3D740E6-4FC8-4B85-90C9-5131D7DAAAFA", "Get Base Url", "", 2, "MainFrm")) return new IDVariant();
      // 
      // Get Base Url Body
      // Corpo Procedura
      // 
      IDVariant v_SURL = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VURLDIBAAPIM = new IDVariant(0,IDVariant.STRING);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.URL_APP as URLDIBASAPIM ");
      SQL.Append("from ");
      SQL.Append("  IMPOSTAZIONI A ");
      MainFrm.DTTObj.AddQuery ("B057CE5E-9EF9-48EE-B912-96F357A1A22E", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("B057CE5E-9EF9-48EE-B912-96F357A1A22E");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        v_VURLDIBAAPIM = QV.Get("URLDIBASAPIM", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("B057CE5E-9EF9-48EE-B912-96F357A1A22E", "631BE0EB-4BCE-4301-AEF3-185D2B346E16", 1376256, "v Url Di Base Applicativo Impostazione", v_VURLDIBAAPIM);
      }
      QV.Close();
      MainFrm.DTTObj.AddIf ("AAF10B1A-1B58-4FB6-B666-B213264E9B66", "IF v Url Di Base Applicativo Impostazione <> \"\" or ! (Is Null (v Url Di Base Applicativo Impostazione))", "");
      MainFrm.DTTObj.AddToken ("AAF10B1A-1B58-4FB6-B666-B213264E9B66", "631BE0EB-4BCE-4301-AEF3-185D2B346E16", 1376256, "v Url Di Base Applicativo Impostazione", v_VURLDIBAAPIM);
      if (v_VURLDIBAAPIM.compareTo((new IDVariant("")), true)!=0 || !(IDL.IsNull(v_VURLDIBAAPIM)))
      {
        MainFrm.DTTObj.EnterIf ("AAF10B1A-1B58-4FB6-B666-B213264E9B66", "IF v Url Di Base Applicativo Impostazione <> \"\" or ! (Is Null (v Url Di Base Applicativo Impostazione))", "");
        MainFrm.DTTObj.AddAssign ("043D8E23-F915-4FFB-AAF6-0BDAF3AA09CD", "s URL := v Url Di Base Applicativo Impostazione", "", v_SURL);
        MainFrm.DTTObj.AddToken ("043D8E23-F915-4FFB-AAF6-0BDAF3AA09CD", "631BE0EB-4BCE-4301-AEF3-185D2B346E16", 1376256, "v Url Di Base Applicativo Impostazione", new IDVariant(v_VURLDIBAAPIM));
        v_SURL = new IDVariant(v_VURLDIBAAPIM);
        MainFrm.DTTObj.AddAssignNewValue ("043D8E23-F915-4FFB-AAF6-0BDAF3AA09CD", "DCEB4B96-CB40-44A8-AAA0-9F9170287CD8", v_SURL);
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("0CC0DE80-87E4-49A5-9F46-7C83AA0120EB", "ELSE", "", "AAF10B1A-1B58-4FB6-B666-B213264E9B66");
        // 
        // Creo Ulr Base Name
        // 
        {
          IDVariant v_SHTTP = null;
          MainFrm.DTTObj.AddAssign ("080F5237-D033-4F7D-AB97-AD0A23533783", "s HTTP := C\"http://\"", "", v_SHTTP);
          v_SHTTP = (new IDVariant("http://"));
          MainFrm.DTTObj.AddAssignNewValue ("080F5237-D033-4F7D-AB97-AD0A23533783", "F2A8E1F5-5041-4E07-98A3-8E521DFBA2A8", v_SHTTP);
          IDVariant v_SAPPENDPORT = new IDVariant(0,IDVariant.STRING);
          MainFrm.DTTObj.AddIf ("FC060C70-B3CB-44CC-BD7E-5D6AE68EBB77", "IF Server Port () = 1", "");
          if (new IDVariant(MainFrm.Request["SERVER_PORT"]!="" ? MainFrm.Request["SERVER_PORT"] : MainFrm.Request["SERVER_PORT"]).equals((new IDVariant(1)), true))
          {
            MainFrm.DTTObj.EnterIf ("FC060C70-B3CB-44CC-BD7E-5D6AE68EBB77", "IF Server Port () = 1", "");
            MainFrm.DTTObj.AddAssign ("144F4AAA-7FED-404E-B038-A12FB00AF428", "s HTTP := C\"https://\"", "", v_SHTTP);
            v_SHTTP = (new IDVariant("https://"));
            MainFrm.DTTObj.AddAssignNewValue ("144F4AAA-7FED-404E-B038-A12FB00AF428", "F2A8E1F5-5041-4E07-98A3-8E521DFBA2A8", v_SHTTP);
          }
          MainFrm.DTTObj.EndIfBlk ("FC060C70-B3CB-44CC-BD7E-5D6AE68EBB77");
          MainFrm.DTTObj.AddIf ("864CB081-A7BF-4D51-9F06-E1B9B0316E54", "IF Server Port () != 80", "");
          if (new IDVariant(MainFrm.Request["SERVER_PORT"]!="" ? MainFrm.Request["SERVER_PORT"] : MainFrm.Request["SERVER_PORT"]).compareTo((new IDVariant(80)), true)!=0)
          {
            MainFrm.DTTObj.EnterIf ("864CB081-A7BF-4D51-9F06-E1B9B0316E54", "IF Server Port () != 80", "");
            MainFrm.DTTObj.AddAssign ("9026B9F5-AE60-457B-9066-DEBF60B3A23A", "s Append Port := C\":\" + To String (To Integer (Server Port ()))", "", v_SAPPENDPORT);
            v_SAPPENDPORT = IDL.Add((new IDVariant(":")), IDL.ToString(IDL.ToInteger(new IDVariant(MainFrm.Request["SERVER_PORT"]!="" ? MainFrm.Request["SERVER_PORT"] : MainFrm.Request["SERVER_PORT"]))));
            MainFrm.DTTObj.AddAssignNewValue ("9026B9F5-AE60-457B-9066-DEBF60B3A23A", "46EACC41-05F7-4D53-A470-ED913CA5F03A", v_SAPPENDPORT);
          }
          MainFrm.DTTObj.EndIfBlk ("864CB081-A7BF-4D51-9F06-E1B9B0316E54");
          MainFrm.DTTObj.AddAssign ("79FEB89D-4CCD-4CF6-82B9-53D2AFDB2920", "s URL := Trim (s HTTP + Server Name () + s Append Port)", "", v_SURL);
          MainFrm.DTTObj.AddToken ("79FEB89D-4CCD-4CF6-82B9-53D2AFDB2920", "F2A8E1F5-5041-4E07-98A3-8E521DFBA2A8", 1376256, "s HTTP", v_SHTTP);
          MainFrm.DTTObj.AddToken ("79FEB89D-4CCD-4CF6-82B9-53D2AFDB2920", "46EACC41-05F7-4D53-A470-ED913CA5F03A", 1376256, "s Append Port", v_SAPPENDPORT);
          v_SURL = IDL.Trim(IDL.Add(IDL.Add(v_SHTTP, new IDVariant(MainFrm.Request["SERVER_NAME"]!="" ? MainFrm.Request["SERVER_NAME"] : MainFrm.Request["SERVER_NAME"])), v_SAPPENDPORT), true, true);
          MainFrm.DTTObj.AddAssignNewValue ("79FEB89D-4CCD-4CF6-82B9-53D2AFDB2920", "DCEB4B96-CB40-44A8-AAA0-9F9170287CD8", v_SURL);
        }
        IDVariant S = null;
        MainFrm.DTTObj.AddAssign ("340155BE-DA81-4C81-B0FD-0F9B79A59104", "s := Path ()", "", S);
        S = (new IDVariant(MainFrm.RealPath));
        MainFrm.DTTObj.AddAssignNewValue ("340155BE-DA81-4C81-B0FD-0F9B79A59104", "5173C6A2-B6D3-4CB0-A7E6-A396C410F660", S);
      }
      MainFrm.DTTObj.EndIfBlk ("AAF10B1A-1B58-4FB6-B666-B213264E9B66");
      MainFrm.DTTObj.AddReturn ("29BA0B7F-B04A-462B-892D-4FE310D98D17", "RETURN s URL", "", v_SURL);
      MainFrm.DTTObj.ExitProc ("F3D740E6-4FC8-4B85-90C9-5131D7DAAAFA", "Get Base Url", "Spiega quale elaborazione viene eseguita da questa procedura", 2, "MainFrm");
      return v_SURL;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("F3D740E6-4FC8-4B85-90C9-5131D7DAAAFA", "Get Base Url", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "GetBaseUrl", _e);
      MainFrm.DTTObj.ExitProc("F3D740E6-4FC8-4B85-90C9-5131D7DAAAFA", "Get Base Url", "", 2, "MainFrm");
      return new IDVariant();
    }
  }

  // **********************************************************************
  // Check Login
  // Check login
  // 
  // Utente - Input
  // Password - Input
  // **********************************************************************
  public bool CheckLogin (IDVariant Utente, IDVariant Password)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("DE1A1868-F0FC-4638-BE6E-580468C4625C", "Check Login", "Check login\n", 2, "MainFrm")) return false;
      MainFrm.DTTObj.AddParameter ("DE1A1868-F0FC-4638-BE6E-580468C4625C", "CD739512-21E2-4D98-A25F-CDD351E90263", "Utente", Utente);
      MainFrm.DTTObj.AddParameter ("DE1A1868-F0FC-4638-BE6E-580468C4625C", "F65D97AA-AF97-43B3-8EB5-220BAC926764", "Password", Password);
      // 
      // Check Login Body
      // Corpo Procedura
      // 
      IDVariant v_BRETVALUE = new IDVariant(0,IDVariant.INTEGER);
      MainFrm.DTTObj.AddIf ("81F63169-87F4-42EF-9A6B-838F836CC721", "IF Utente = \"admin\" and Password = \"cesena\"", "");
      MainFrm.DTTObj.AddToken ("81F63169-87F4-42EF-9A6B-838F836CC721", "CD739512-21E2-4D98-A25F-CDD351E90263", 1376256, "Utente", Utente);
      MainFrm.DTTObj.AddToken ("81F63169-87F4-42EF-9A6B-838F836CC721", "F65D97AA-AF97-43B3-8EB5-220BAC926764", 1376256, "Password", Password);
      if (Utente.equals((new IDVariant("admin")), true) && Password.equals((new IDVariant("cesena")), true))
      {
        MainFrm.DTTObj.EnterIf ("81F63169-87F4-42EF-9A6B-838F836CC721", "IF Utente = \"admin\" and Password = \"cesena\"", "");
        MainFrm.DTTObj.AddAssign ("B2B3DBBB-919D-4985-8734-4CFAA758015E", "b Ret Value := true", "", v_BRETVALUE);
        MainFrm.DTTObj.AddToken ("B2B3DBBB-919D-4985-8734-4CFAA758015E", "78B75DA3-DBDF-11D4-900E-726096000000", 589824, "true", (new IDVariant(-1)));
        v_BRETVALUE = (new IDVariant(-1));
        MainFrm.DTTObj.AddAssignNewValue ("B2B3DBBB-919D-4985-8734-4CFAA758015E", "25112C21-6B37-4399-9319-5D33C8F185DB", v_BRETVALUE);
      }
      MainFrm.DTTObj.EndIfBlk ("81F63169-87F4-42EF-9A6B-838F836CC721");
      MainFrm.DTTObj.AddReturn ("F7685E25-5A1B-4092-A696-7654B547BEA3", "RETURN b Ret Value", "", v_BRETVALUE.booleanValue());
      MainFrm.DTTObj.ExitProc ("DE1A1868-F0FC-4638-BE6E-580468C4625C", "Check Login", "Check login\n", 2, "MainFrm");
      return v_BRETVALUE.booleanValue();
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("DE1A1868-F0FC-4638-BE6E-580468C4625C", "Check Login", "Check login\n", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "CheckLogin", _e);
      MainFrm.DTTObj.ExitProc("DE1A1868-F0FC-4638-BE6E-580468C4625C", "Check Login", "Check login\n", 2, "MainFrm");
      return false;
    }
  }

  // **********************************************************************
  // File Exist
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Nome File - Input
  // **********************************************************************
  public bool FileExist (IDVariant NomeFile)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("5589464E-EB1C-4B05-B66E-5FFE5314886C", "File Exist", "", 2, "MainFrm")) return false;
      MainFrm.DTTObj.AddParameter ("5589464E-EB1C-4B05-B66E-5FFE5314886C", "01F01C52-6366-473B-84C4-FBFE7AE26A4D", "Nome File", NomeFile);
      // 
      // File Exist Body
      // Corpo Procedura
      // 
      IDVariant I = null;
      MainFrm.DTTObj.AddAssign ("D37C0340-87C1-4A84-9D9C-81ADE8EA4282", "i := Free File ()", "", I);
      I = MainFrm.VBFile.FreeFile();
      MainFrm.DTTObj.AddAssignNewValue ("D37C0340-87C1-4A84-9D9C-81ADE8EA4282", "75ACD668-8922-453D-BF84-F256BBE7E2E3", I);
      IDVariant v_BRETVALUE = new IDVariant(0,IDVariant.INTEGER);
      try
      {
        MainFrm.DTTObj.AddSubProc ("BEC4DD0D-9998-46BD-AC01-8EA5F8EB2ED1", "Notificatore.Open File For Input", "");
        MainFrm.DTTObj.AddParameter ("BEC4DD0D-9998-46BD-AC01-8EA5F8EB2ED1", "41EAC2AB-E0F8-4936-8CC9-FC1FA0FEB13D", "Percorso", NomeFile);
        MainFrm.DTTObj.AddParameter ("BEC4DD0D-9998-46BD-AC01-8EA5F8EB2ED1", "A0097D60-9A7A-4059-A1EF-E249B42C1E63", "Numero File", I);
        MainFrm.VBFile.OpenForInput(NomeFile, I); 
        MainFrm.DTTObj.AddAssign ("404ABD91-3140-421D-9886-1566488E6872", "b Ret Value := true", "", v_BRETVALUE);
        MainFrm.DTTObj.AddToken ("404ABD91-3140-421D-9886-1566488E6872", "78B75DA3-DBDF-11D4-900E-726096000000", 589824, "true", (new IDVariant(-1)));
        v_BRETVALUE = (new IDVariant(-1));
        MainFrm.DTTObj.AddAssignNewValue ("404ABD91-3140-421D-9886-1566488E6872", "46EE1F6E-5892-4DCC-B11C-8B04DD93E4B9", v_BRETVALUE);
        MainFrm.DTTObj.AddSubProc ("A0F7585B-1E58-4114-ADF0-B0142A7389DE", "Notificatore.Close File", "");
        MainFrm.DTTObj.AddParameter ("A0F7585B-1E58-4114-ADF0-B0142A7389DE", "98FFDB16-8C99-4824-B56C-64605D4D4C4E", "Numero File", I);
        MainFrm.VBFile.Close(I); 
      }
      catch (Exception e3)
      {
        MainFrm.DTTObj.AddException("2C4A2997-6500-4D8D-A2CB-7DD11BF086C8", "CATCH", "", e3, true);
        MainFrm.DTTObj.AddAssign ("282C6B20-E886-4698-A0D0-D4C66FE4D90E", "b Ret Value := false", "", v_BRETVALUE);
        MainFrm.DTTObj.AddToken ("282C6B20-E886-4698-A0D0-D4C66FE4D90E", "78B75DA4-DBDF-11D4-900E-726096000000", 589824, "false", (new IDVariant(0)));
        v_BRETVALUE = (new IDVariant(0));
        MainFrm.DTTObj.AddAssignNewValue ("282C6B20-E886-4698-A0D0-D4C66FE4D90E", "46EE1F6E-5892-4DCC-B11C-8B04DD93E4B9", v_BRETVALUE);
      }
      MainFrm.DTTObj.AddReturn ("1E63ED27-BB14-4484-9EED-4731DDE0CCC9", "RETURN b Ret Value", "", v_BRETVALUE.booleanValue());
      MainFrm.DTTObj.ExitProc ("5589464E-EB1C-4B05-B66E-5FFE5314886C", "File Exist", "Spiega quale elaborazione viene eseguita da questa procedura", 2, "MainFrm");
      return v_BRETVALUE.booleanValue();
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("5589464E-EB1C-4B05-B66E-5FFE5314886C", "File Exist", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "FileExist", _e);
      MainFrm.DTTObj.ExitProc("5589464E-EB1C-4B05-B66E-5FFE5314886C", "File Exist", "", 2, "MainFrm");
      return false;
    }
  }

  // **********************************************************************
  // Initialize
  // Evento notificato dall'applicazione quando viene inizializzata
  // **********************************************************************
  public void InitApp ()
  {
    DispatchToComp("InitApp", new Object[] {});
    //
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("56D23B81-02CF-4BBF-8261-0CFD7932C974", "Initialize", "", 0, "MainFrm")) return;
      // 
      // Initialize Body
      // Corpo Procedura
      // 
      // MainFrm.set_Widget(new IDVariant(MainFrm.BrowserInfo()).equals((new IDVariant(5)), true) || new IDVariant(MainFrm.BrowserInfo()).equals((new IDVariant(6)), true));
      MainFrm.DTTObj.AddAssign ("82E7AB9F-7D0D-4934-8E84-E19798E62344", "Notificatore.Main Caption := C\"Il Notificatore\"", "", MainFrm.Caption());
      MainFrm.set_Caption((new IDVariant("Il Notificatore")));
      MainFrm.DTTObj.AddAssignNewValue ("82E7AB9F-7D0D-4934-8E84-E19798E62344", "5D17ACB6-0F41-4CB8-BE2D-0F961D66BA84", MainFrm.Caption());
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // Se sn = "" sono in condizioni normali (utente collegato
      // ,
      // se no si tratta di una server session
      // 
      MainFrm.DTTObj.MaxLoopCycles = (new IDVariant(5000)).intValue();
      MainFrm.DTTObj.MaxRecToDump = (new IDVariant(50)).intValue();
      MainFrm.DTTObj.LoggedLoops = (new IDVariant(50)).intValue();
      // MainFrm.set_UserRole((new IDVariant(1)));
      MainFrm.DTTObj.Add(new IDVariant(MainFrm.SessionName).stringValue(), (new IDVariant(999)).intValue(), (new IDVariant(2)).intValue()); 
      MainFrm.DTTObj.AddIf ("467C7019-365C-4308-AE2D-095A113B3C2E", "IF Session Name () != \"\"", "");
      if (new IDVariant(MainFrm.SessionName).compareTo((new IDVariant("")), true)!=0)
      {
        MainFrm.DTTObj.EnterIf ("467C7019-365C-4308-AE2D-095A113B3C2E", "IF Session Name () != \"\"", "");
        MainFrm.DTTObj.AddAssign ("E965A1FB-92EC-4371-964E-8F3903E78059", "Refresh In Corso Notificatore := false", "", REFREINCORSO);
        MainFrm.DTTObj.AddToken ("E965A1FB-92EC-4371-964E-8F3903E78059", "78B75DA4-DBDF-11D4-900E-726096000000", 589824, "false", (new IDVariant(0)));
        REFREINCORSO = (new IDVariant(0));
        MainFrm.DTTObj.AddAssignNewValue ("E965A1FB-92EC-4371-964E-8F3903E78059", "C1847AC8-46E8-42AA-A957-B731D0EED721", REFREINCORSO);
        MainFrm.DTTObj.AddAssign ("500B4C92-6215-47CE-B904-248F6A7664E1", "Notificatore.User Role := Amministratore", "", MainFrm.UserRole());
        MainFrm.DTTObj.AddToken ("500B4C92-6215-47CE-B904-248F6A7664E1", "85A3408B-A8F4-11D4-8F26-0860F2000000", 589824, "Amministratore", (new IDVariant(1)));
        MainFrm.set_UserRole((new IDVariant(1)));
        MainFrm.DTTObj.AddAssignNewValue ("500B4C92-6215-47CE-B904-248F6A7664E1", "5D17ACB6-0F41-4CB8-BE2D-0F961D66BA84", MainFrm.UserRole());
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("17FBEA46-D364-4CDD-AEE5-4B6BCC936B19", "ELSE", "", "467C7019-365C-4308-AE2D-095A113B3C2E");
        // 
        // Login con iPad iPhone
        // 
        {
          IDVariant I = new IDVariant(0,IDVariant.INTEGER);
          // 
          // Nel caso di login ipad o iphone scommentare questo
          // blocco
          // 
          // EsegueLogin(MainFrm.GetSetting((new IDVariant("icalcio")),(new IDVariant("email"))), MainFrm.GetSetting((new IDVariant("icalcio")),(new IDVariant("password"))));
        }
        // 
        // Login con modalità tradizionale
        // 
        {
          IDVariant v_SUTENTE = null;
          MainFrm.DTTObj.AddAssign ("1755E0E1-1821-4801-9EA5-7E8967FAC42F", "s Utente := Get Setting (\"icalcio\", \"username\")", "", v_SUTENTE);
          v_SUTENTE = MainFrm.GetSetting((new IDVariant("icalcio")),(new IDVariant("username")));
          MainFrm.DTTObj.AddAssignNewValue ("1755E0E1-1821-4801-9EA5-7E8967FAC42F", "079705AB-57F6-402F-908C-AC7CE27A1300", v_SUTENTE);
          IDVariant v_SPASSWORD = null;
          MainFrm.DTTObj.AddAssign ("E72F4642-24C1-418B-B244-2CC9145EE86D", "s Password := Get Setting (\"icalcio\", \"password\")", "", v_SPASSWORD);
          v_SPASSWORD = MainFrm.GetSetting((new IDVariant("icalcio")),(new IDVariant("password")));
          MainFrm.DTTObj.AddAssignNewValue ("E72F4642-24C1-418B-B244-2CC9145EE86D", "4E2A1A16-9B18-479E-AFFE-1DE2075AED0C", v_SPASSWORD);
          MainFrm.DTTObj.AddIf ("E6C0C21B-50B5-4B0B-B2D2-28C80EC73C8B", "IF Check Login (s Utente, s Password)", "");
          MainFrm.DTTObj.AddToken ("E6C0C21B-50B5-4B0B-B2D2-28C80EC73C8B", "079705AB-57F6-402F-908C-AC7CE27A1300", 1376256, "s Utente", v_SUTENTE);
          MainFrm.DTTObj.AddToken ("E6C0C21B-50B5-4B0B-B2D2-28C80EC73C8B", "4E2A1A16-9B18-479E-AFFE-1DE2075AED0C", 1376256, "s Password", v_SPASSWORD);
          if (CheckLogin(v_SUTENTE, v_SPASSWORD))
          {
            MainFrm.DTTObj.EnterIf ("E6C0C21B-50B5-4B0B-B2D2-28C80EC73C8B", "IF Check Login (s Utente, s Password)", "");
            MainFrm.DTTObj.AddAssign ("09C46BCB-69CC-4CBB-8A8B-375D7A94FD5D", "Notificatore.User Role := Amministratore", "", MainFrm.UserRole());
            MainFrm.DTTObj.AddToken ("09C46BCB-69CC-4CBB-8A8B-375D7A94FD5D", "85A3408B-A8F4-11D4-8F26-0860F2000000", 589824, "Amministratore", (new IDVariant(1)));
            MainFrm.set_UserRole((new IDVariant(1)));
            MainFrm.DTTObj.AddAssignNewValue ("09C46BCB-69CC-4CBB-8A8B-375D7A94FD5D", "5D17ACB6-0F41-4CB8-BE2D-0F961D66BA84", MainFrm.UserRole());
          }
          MainFrm.DTTObj.EndIfBlk ("E6C0C21B-50B5-4B0B-B2D2-28C80EC73C8B");
        }
        // 
        // Query string da iCalcio
        // 
        {
          MainFrm.DTTObj.AddSubProc ("0ECB6480-23E6-4071-8AD9-FC99A9D253FF", "Notificatore.Parse URL", "");
          ParseURL(MainFrm.GetUrlParam());
        }
      }
      MainFrm.DTTObj.EndIfBlk ("467C7019-365C-4308-AE2D-095A113B3C2E");
      MainFrm.DTTObj.ExitProc("56D23B81-02CF-4BBF-8261-0CFD7932C974", "Initialize", "", 0, "MainFrm");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("56D23B81-02CF-4BBF-8261-0CFD7932C974", "Initialize", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "Initialize", _e);
      MainFrm.DTTObj.ExitProc("56D23B81-02CF-4BBF-8261-0CFD7932C974", "Initialize", "", 0, "MainFrm");
    }
  }

  // **********************************************************************
  // On Login Event
  // Evento notificato dall'applicazione quando l'utente
  // effettua il login
  // Data Valid - Input/Output
  // User Name - Input/Output
  // Password - Input/Output
  // **********************************************************************
  public void Login (IDVariant UserName, IDVariant Password, IDVariant DataValid)
  {
    DispatchToComp("Login", new Object[] {UserName, Password, DataValid});
    //
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("FBF33652-BC43-4EC1-864F-C4450B884427", "On Login Event", "", 0, "MainFrm")) return;
      MainFrm.DTTObj.AddParameter ("FBF33652-BC43-4EC1-864F-C4450B884427", "B704A838-3A44-489F-82F5-C7104BC3D77F", "Data Valid", DataValid);
      MainFrm.DTTObj.AddParameter ("FBF33652-BC43-4EC1-864F-C4450B884427", "FEB4EC39-4AD7-43FE-A850-304864E73971", "User Name", UserName);
      MainFrm.DTTObj.AddParameter ("FBF33652-BC43-4EC1-864F-C4450B884427", "55D40BB9-4754-4579-8805-F6F32DCEA7F0", "Password", Password);
      // 
      // On Login Event Body
      // Procedure Body
      // 
      MainFrm.DTTObj.AddIf ("7A47B3A7-E483-4D72-BBD9-A21D6AC6333F", "IF Session Name () != \"\"", "");
      if (new IDVariant(MainFrm.SessionName).compareTo((new IDVariant("")), true)!=0)
      {
        MainFrm.DTTObj.EnterIf ("7A47B3A7-E483-4D72-BBD9-A21D6AC6333F", "IF Session Name () != \"\"", "");
        MainFrm.DTTObj.AddAssign ("4E185F2B-7A53-47A6-B500-468206F25E09", "Data Valid := true", "", DataValid);
        MainFrm.DTTObj.AddToken ("4E185F2B-7A53-47A6-B500-468206F25E09", "78B75DA3-DBDF-11D4-900E-726096000000", 589824, "true", (new IDVariant(-1)));
        DataValid.set((new IDVariant(-1)));
        MainFrm.DTTObj.AddAssignNewValue ("4E185F2B-7A53-47A6-B500-468206F25E09", "B704A838-3A44-489F-82F5-C7104BC3D77F", DataValid);
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("A44EFF74-EFF0-46E5-BC8B-E7B141E17D05", "ELSE", "", "7A47B3A7-E483-4D72-BBD9-A21D6AC6333F");
        // 
        // Nel caso di login ipad o iphone commentare questo blocco
        // 
        MainFrm.DTTObj.AddIf ("341DBF89-B856-476A-B3A8-FAFE2FCDECF6", "IF Check Login (User Name, Password)", "Nel caso di login ipad o iphone commentare questo blocco");
        MainFrm.DTTObj.AddToken ("341DBF89-B856-476A-B3A8-FAFE2FCDECF6", "FEB4EC39-4AD7-43FE-A850-304864E73971", 1376256, "User Name", UserName);
        MainFrm.DTTObj.AddToken ("341DBF89-B856-476A-B3A8-FAFE2FCDECF6", "55D40BB9-4754-4579-8805-F6F32DCEA7F0", 1376256, "Password", Password);
        if (CheckLogin(UserName, Password))
        {
          MainFrm.DTTObj.EnterIf ("341DBF89-B856-476A-B3A8-FAFE2FCDECF6", "IF Check Login (User Name, Password)", "Nel caso di login ipad o iphone commentare questo blocco");
          MainFrm.DTTObj.AddAssign ("F6A2AFE8-AB87-45E8-8F98-86484A540A10", "Notificatore.User Role := Amministratore", "", MainFrm.UserRole());
          MainFrm.DTTObj.AddToken ("F6A2AFE8-AB87-45E8-8F98-86484A540A10", "85A3408B-A8F4-11D4-8F26-0860F2000000", 589824, "Amministratore", (new IDVariant(1)));
          MainFrm.set_UserRole((new IDVariant(1)));
          MainFrm.DTTObj.AddAssignNewValue ("F6A2AFE8-AB87-45E8-8F98-86484A540A10", "5D17ACB6-0F41-4CB8-BE2D-0F961D66BA84", MainFrm.UserRole());
          MainFrm.DTTObj.AddAssign ("C779C303-0183-4178-994F-BA9065E83D55", "Data Valid := true", "", DataValid);
          MainFrm.DTTObj.AddToken ("C779C303-0183-4178-994F-BA9065E83D55", "78B75DA3-DBDF-11D4-900E-726096000000", 589824, "true", (new IDVariant(-1)));
          DataValid.set((new IDVariant(-1)));
          MainFrm.DTTObj.AddAssignNewValue ("C779C303-0183-4178-994F-BA9065E83D55", "B704A838-3A44-489F-82F5-C7104BC3D77F", DataValid);
          // 
          // Se l'utente ha deciso di salvare le credenziali, dopo
          // essere entrato le salvo nel cookie
          // 
          MainFrm.DTTObj.AddIf ("CAEF746D-ACEE-4C5F-8916-CBEF73A34C7A", "IF Upper (Get Setting (Form, \"checkbox\")) = \"ON\"", "Se l'utente ha deciso di salvare le credenziali, dopo essere entrato le salvo nel cookie");
          MainFrm.DTTObj.AddToken ("CAEF746D-ACEE-4C5F-8916-CBEF73A34C7A", "F061868A-8E22-4435-9198-27ED76A3285E", 589824, "Form", (new IDVariant("FORM")));
          if (IDL.Upper(MainFrm.GetSetting((new IDVariant("FORM")),(new IDVariant("checkbox")))).equals((new IDVariant("ON")), true))
          {
            MainFrm.DTTObj.EnterIf ("CAEF746D-ACEE-4C5F-8916-CBEF73A34C7A", "IF Upper (Get Setting (Form, \"checkbox\")) = \"ON\"", "Se l'utente ha deciso di salvare le credenziali, dopo essere entrato le salvo nel cookie");
            MainFrm.DTTObj.AddSubProc ("0FEC0C49-AD0F-4B6A-9E5E-8CAB1D00CF57", "Notificatore.Save Setting", "");
            MainFrm.DTTObj.AddParameter ("0FEC0C49-AD0F-4B6A-9E5E-8CAB1D00CF57", "ADF77D88-6BA2-4001-A38E-DEBF96CFD3C3", "Sezione", (new IDVariant("icalcio")));
            MainFrm.DTTObj.AddParameter ("0FEC0C49-AD0F-4B6A-9E5E-8CAB1D00CF57", "41A7433C-346B-4439-B3BD-C3673AFA99B4", "Chiave", (new IDVariant("username")));
            MainFrm.DTTObj.AddParameter ("0FEC0C49-AD0F-4B6A-9E5E-8CAB1D00CF57", "47AFDA46-AB14-48AB-AB5C-76E5779BDF9A", "Valore", UserName);
            MainFrm.SaveSetting((new IDVariant("icalcio")),(new IDVariant("username")),UserName); 
            MainFrm.DTTObj.AddSubProc ("D41EDA51-83E8-4653-8E8B-C8128CBD7B5D", "Notificatore.Save Setting", "");
            MainFrm.DTTObj.AddParameter ("D41EDA51-83E8-4653-8E8B-C8128CBD7B5D", "E016866B-341C-4D6D-893F-606FBF91788D", "Sezione", (new IDVariant("icalcio")));
            MainFrm.DTTObj.AddParameter ("D41EDA51-83E8-4653-8E8B-C8128CBD7B5D", "7FE03ACA-53FE-4B8D-AA32-341955008DBC", "Chiave", (new IDVariant("password")));
            MainFrm.DTTObj.AddParameter ("D41EDA51-83E8-4653-8E8B-C8128CBD7B5D", "D90630E9-F563-4B44-9AEA-EF9E9A00477D", "Valore", Password);
            MainFrm.SaveSetting((new IDVariant("icalcio")),(new IDVariant("password")),Password); 
          }
          MainFrm.DTTObj.EndIfBlk ("CAEF746D-ACEE-4C5F-8916-CBEF73A34C7A");
        }
        MainFrm.DTTObj.EndIfBlk ("341DBF89-B856-476A-B3A8-FAFE2FCDECF6");
      }
      MainFrm.DTTObj.EndIfBlk ("7A47B3A7-E483-4D72-BBD9-A21D6AC6333F");
      MainFrm.DTTObj.ExitProc("FBF33652-BC43-4EC1-864F-C4450B884427", "On Login Event", "", 0, "MainFrm");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("FBF33652-BC43-4EC1-864F-C4450B884427", "On Login Event", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "OnLoginEvent", _e);
      MainFrm.DTTObj.ExitProc("FBF33652-BC43-4EC1-864F-C4450B884427", "On Login Event", "", 0, "MainFrm");
    }
  }

  // **********************************************************************
  // After Login
  // Evento notificato dall'applicazione dopo che è stato
  // effettuato l'accesso al sistema
  // **********************************************************************
  public void AfterLogin()
  {
    DispatchToComp("AfterLogin", new Object[] {});
    //
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("43027C3D-305D-4AD3-9BD6-6501A4EE2697", "After Login", "", 0, "MainFrm")) return;
      // 
      // After Login Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddAssign ("4F8EF082-49CD-4E45-B6F3-B5EF53D2B80A", "Generale.Expanded := true", "", MainFrm.CmdObj.CmdSetExpanded(MyGlb.CMDS_GENERALE+BaseCmdSetIdx));
      MainFrm.DTTObj.AddToken ("4F8EF082-49CD-4E45-B6F3-B5EF53D2B80A", "78B75DA3-DBDF-11D4-900E-726096000000", 589824, "true", (new IDVariant(-1)).booleanValue());
      MainFrm.CmdObj.set_CmdSetExpanded(MyGlb.CMDS_GENERALE+BaseCmdSetIdx, (new IDVariant(-1)).booleanValue());
      MainFrm.DTTObj.AddAssignNewValue ("4F8EF082-49CD-4E45-B6F3-B5EF53D2B80A", "8FB85B23-3AE1-4C43-A67F-99176AF09C8A", MainFrm.CmdObj.CmdSetExpanded(MyGlb.CMDS_GENERALE+BaseCmdSetIdx));
      MainFrm.DTTObj.AddAssign ("E23B2EF4-4425-4888-9F98-AAF77FFEADE5", "iOS.Expanded := true", "", MainFrm.CmdObj.CmdSetExpanded(MyGlb.CMDS_IOS+BaseCmdSetIdx));
      MainFrm.DTTObj.AddToken ("E23B2EF4-4425-4888-9F98-AAF77FFEADE5", "78B75DA3-DBDF-11D4-900E-726096000000", 589824, "true", (new IDVariant(-1)).booleanValue());
      MainFrm.CmdObj.set_CmdSetExpanded(MyGlb.CMDS_IOS+BaseCmdSetIdx, (new IDVariant(-1)).booleanValue());
      MainFrm.DTTObj.AddAssignNewValue ("E23B2EF4-4425-4888-9F98-AAF77FFEADE5", "91590DDD-D3B0-4DC0-AFD7-3B6D53CA3201", MainFrm.CmdObj.CmdSetExpanded(MyGlb.CMDS_IOS+BaseCmdSetIdx));
      MainFrm.DTTObj.AddAssign ("DF03FDD0-1E53-4A29-9A24-F6C28AF8E78A", "Android.Expanded := true", "", MainFrm.CmdObj.CmdSetExpanded(MyGlb.CMDS_ANDROID+BaseCmdSetIdx));
      MainFrm.DTTObj.AddToken ("DF03FDD0-1E53-4A29-9A24-F6C28AF8E78A", "78B75DA3-DBDF-11D4-900E-726096000000", 589824, "true", (new IDVariant(-1)).booleanValue());
      MainFrm.CmdObj.set_CmdSetExpanded(MyGlb.CMDS_ANDROID+BaseCmdSetIdx, (new IDVariant(-1)).booleanValue());
      MainFrm.DTTObj.AddAssignNewValue ("DF03FDD0-1E53-4A29-9A24-F6C28AF8E78A", "D3561A37-8DE6-4368-81BD-F0148F894BA9", MainFrm.CmdObj.CmdSetExpanded(MyGlb.CMDS_ANDROID+BaseCmdSetIdx));
      MainFrm.DTTObj.AddAssign ("1869E407-A899-42D2-B997-A2D6258C4CF9", "Win Phone.Expanded := true", "", MainFrm.CmdObj.CmdSetExpanded(MyGlb.CMDS_WINPHONE+BaseCmdSetIdx));
      MainFrm.DTTObj.AddToken ("1869E407-A899-42D2-B997-A2D6258C4CF9", "78B75DA3-DBDF-11D4-900E-726096000000", 589824, "true", (new IDVariant(-1)).booleanValue());
      MainFrm.CmdObj.set_CmdSetExpanded(MyGlb.CMDS_WINPHONE+BaseCmdSetIdx, (new IDVariant(-1)).booleanValue());
      MainFrm.DTTObj.AddAssignNewValue ("1869E407-A899-42D2-B997-A2D6258C4CF9", "22396A4F-70CE-42B4-A233-DCEA9BD2760E", MainFrm.CmdObj.CmdSetExpanded(MyGlb.CMDS_WINPHONE+BaseCmdSetIdx));
      MainFrm.DTTObj.AddAssign ("9EB7115C-0AF0-416A-A567-CBE05B8E85A2", "Win Store.Expanded := true", "", MainFrm.CmdObj.CmdSetExpanded(MyGlb.CMDS_WINSTORE+BaseCmdSetIdx));
      MainFrm.DTTObj.AddToken ("9EB7115C-0AF0-416A-A567-CBE05B8E85A2", "78B75DA3-DBDF-11D4-900E-726096000000", 589824, "true", (new IDVariant(-1)).booleanValue());
      MainFrm.CmdObj.set_CmdSetExpanded(MyGlb.CMDS_WINSTORE+BaseCmdSetIdx, (new IDVariant(-1)).booleanValue());
      MainFrm.DTTObj.AddAssignNewValue ("9EB7115C-0AF0-416A-A567-CBE05B8E85A2", "ACFE000F-BF0A-47A5-BF18-2AAE6782F714", MainFrm.CmdObj.CmdSetExpanded(MyGlb.CMDS_WINSTORE+BaseCmdSetIdx));
      MainFrm.DTTObj.AddSubProc ("B7B66A66-03A8-4C94-A9AE-38C50EFC5C89", "Notificatore.Valorizza Variabili Globali", "");
      ValorizzaVariabiliGlobali();
      // 
      // Percorsi per la nuova versione dei file
      // Nel caso di login ipad o iphone scommentare questo
      // blocco
      // 
      // if (MainFrm.UserRole().equals((new IDVariant(5)), true))
      // {
        // if (new IDVariant(MainFrm.BrowserInfo()).equals((new IDVariant(5)), true))
        // {
          // MainFrm.Show(MyGlb.FRM_LOGINIPHONE, (new IDVariant(0)).intValue(), this); 
        // }
        // else
        // {
          // MainFrm.Show(MyGlb.FRM_LOGINIPAD, (new IDVariant(0)).intValue(), this); 
        // }
      // }
      // if (new IDVariant(MainFrm.BrowserInfo()).equals((new IDVariant(5)), true))
      // {
        // MainFrm.set_Widget((new IDVariant(-1)).booleanValue());
        // MainFrm.CmdObj.set_SuppressMenu((new IDVariant(-1)).booleanValue());
      // }
      MainFrm.DTTObj.ExitProc("43027C3D-305D-4AD3-9BD6-6501A4EE2697", "After Login", "", 0, "MainFrm");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("43027C3D-305D-4AD3-9BD6-6501A4EE2697", "After Login", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "AfterLogin", _e);
      MainFrm.DTTObj.ExitProc("43027C3D-305D-4AD3-9BD6-6501A4EE2697", "After Login", "", 0, "MainFrm");
    }
  }

  // **********************************************************************
  // On Logoff
  // Evento notificato dall'applicazione quando l'utente
  // clicca sul pulsante di logoff dell'applicazione
  // Skip: E' un parametro booleano di output che consente di disabilitare il meccanismo di risposta standard all'evento di Logoff descritta nelle note successive - Input/Output
  // Cancel - Input/Output
  // **********************************************************************
  public void OnLogoff(IDVariant Skip, IDVariant Cancel)
  {
    DispatchToComp("OnLogoff", new Object[] {Skip, Cancel});
    //
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("3F9AEA63-9F4D-4111-B5A6-C371C86B8EB9", "On Logoff", "", 0, "MainFrm")) return;
      MainFrm.DTTObj.AddParameter ("3F9AEA63-9F4D-4111-B5A6-C371C86B8EB9", "0D57979F-5931-44E3-85E5-C63B216D4CD0", "Skip", Skip);
      MainFrm.DTTObj.AddParameter ("3F9AEA63-9F4D-4111-B5A6-C371C86B8EB9", "22871D1F-C700-4ECA-A757-D6BD5602AAD4", "Cancel", Cancel);
      // 
      // On Logoff Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddSubProc ("23D24D8F-9C88-4746-ACDD-7F5178E6881C", "Notificatore.Save Setting", "");
      MainFrm.DTTObj.AddParameter ("23D24D8F-9C88-4746-ACDD-7F5178E6881C", "F15ED620-FE09-4935-9468-778F2C8BC22C", "Sezione", (new IDVariant("icalcio")));
      MainFrm.DTTObj.AddParameter ("23D24D8F-9C88-4746-ACDD-7F5178E6881C", "DB1D2460-AA3B-4F07-B6C7-EBFB81E2A5F8", "Chiave", (new IDVariant("username")));
      MainFrm.DTTObj.AddParameter ("23D24D8F-9C88-4746-ACDD-7F5178E6881C", "11907B67-96FC-4F39-9672-72B874C95AA1", "Valore", (new IDVariant("")));
      MainFrm.SaveSetting((new IDVariant("icalcio")),(new IDVariant("username")),(new IDVariant(""))); 
      MainFrm.DTTObj.AddSubProc ("01564596-1035-4E1D-A6E5-0A01B2D0FEB4", "Notificatore.Save Setting", "");
      MainFrm.DTTObj.AddParameter ("01564596-1035-4E1D-A6E5-0A01B2D0FEB4", "C878112E-0291-45E6-AF87-CFECDEDF8923", "Sezione", (new IDVariant("icalcio")));
      MainFrm.DTTObj.AddParameter ("01564596-1035-4E1D-A6E5-0A01B2D0FEB4", "9ADEF13D-9295-4D40-B4AE-283035CAEE43", "Chiave", (new IDVariant("password")));
      MainFrm.DTTObj.AddParameter ("01564596-1035-4E1D-A6E5-0A01B2D0FEB4", "E4958EE0-1FB1-410C-BACE-714850DB1183", "Valore", (new IDVariant("")));
      MainFrm.SaveSetting((new IDVariant("icalcio")),(new IDVariant("password")),(new IDVariant(""))); 
      MainFrm.DTTObj.ExitProc("3F9AEA63-9F4D-4111-B5A6-C371C86B8EB9", "On Logoff", "", 0, "MainFrm");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("3F9AEA63-9F4D-4111-B5A6-C371C86B8EB9", "On Logoff", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "OnLogoff", _e);
      MainFrm.DTTObj.ExitProc("3F9AEA63-9F4D-4111-B5A6-C371C86B8EB9", "On Logoff", "", 0, "MainFrm");
    }
  }

  // **********************************************************************
  // On Command
  // Evento notificato dall'applicazione quando viene passato
  // un comando via URL
  // Command - Input
  // **********************************************************************
  public override void OnCommand(IDVariant Command)
  {
    DispatchToComp("OnCommand", new Object[] {Command});
    //
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("906A3D24-807E-4154-8422-07B416BFEC41", "On Command", "", 0, "MainFrm")) return;
      MainFrm.DTTObj.AddParameter ("906A3D24-807E-4154-8422-07B416BFEC41", "1F8E37F0-85BC-422D-8BAB-E99652E0EB64", "Command", Command);
      // 
      // On Command Body
      // Corpo Procedura
      // 
      MainFrm.DTTObj.AddSubProc ("37C920A0-82FC-4C4D-9176-AD3D8E67F16C", "Notificatore.Parse URL", "");
      ParseURL(Command);
      MainFrm.DTTObj.ExitProc("906A3D24-807E-4154-8422-07B416BFEC41", "On Command", "", 0, "MainFrm");
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("906A3D24-807E-4154-8422-07B416BFEC41", "On Command", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "OnCommand", _e);
      MainFrm.DTTObj.ExitProc("906A3D24-807E-4154-8422-07B416BFEC41", "On Command", "", 0, "MainFrm");
    }
  }

  // **********************************************************************
  // Get Path Certificati
  // Ritorna il percorso dei certificati con la barra alla
  // fine
  // **********************************************************************
  public IDVariant GetPathCertificati ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("6AD71CCD-BF52-4DF0-9035-FF90A9F99299", "Get Path Certificati", "Ritorna il percorso dei certificati con la barra alla fine", 2, "MainFrm")) return new IDVariant();
      // 
      // Get Path Certificati Body
      // Corpo Procedura
      // 
      IDVariant v_RETVALUE = new IDVariant(0,IDVariant.STRING);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.PATH_CERTS as PERCCERTIMPO ");
      SQL.Append("from ");
      SQL.Append("  IMPOSTAZIONI A ");
      MainFrm.DTTObj.AddQuery ("EFEAF95E-7494-492C-8C34-9F7B707DAD61", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("EFEAF95E-7494-492C-8C34-9F7B707DAD61");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        v_RETVALUE = QV.Get("PERCCERTIMPO", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("EFEAF95E-7494-492C-8C34-9F7B707DAD61", "EB05F049-94D6-4EC6-9DCE-8AB2A58F37CA", 1376256, "RetValue", v_RETVALUE);
      }
      QV.Close();
      MainFrm.DTTObj.AddAssign ("F91F9B29-5E3B-477B-B173-0A45C6F5E570", "RetValue := Trim (RetValue)", "", v_RETVALUE);
      MainFrm.DTTObj.AddToken ("F91F9B29-5E3B-477B-B173-0A45C6F5E570", "EB05F049-94D6-4EC6-9DCE-8AB2A58F37CA", 1376256, "RetValue", v_RETVALUE);
      v_RETVALUE = IDL.Trim(v_RETVALUE, true, true);
      MainFrm.DTTObj.AddAssignNewValue ("F91F9B29-5E3B-477B-B173-0A45C6F5E570", "EB05F049-94D6-4EC6-9DCE-8AB2A58F37CA", v_RETVALUE);
      MainFrm.DTTObj.AddIf ("8653DEC0-1D2D-4042-9C90-FC73804E458C", "IF Right (RetValue, 1) != \"\\\"", "");
      MainFrm.DTTObj.AddToken ("8653DEC0-1D2D-4042-9C90-FC73804E458C", "EB05F049-94D6-4EC6-9DCE-8AB2A58F37CA", 1376256, "RetValue", v_RETVALUE);
      if (IDL.Right(v_RETVALUE, (new IDVariant(1))).compareTo((new IDVariant("\\")), true)!=0)
      {
        MainFrm.DTTObj.EnterIf ("8653DEC0-1D2D-4042-9C90-FC73804E458C", "IF Right (RetValue, 1) != \"\\\"", "");
        MainFrm.DTTObj.AddAssign ("7E13F8EC-5106-4879-8FC7-2779F2EAEECB", "RetValue := RetValue + \"\\\"", "", v_RETVALUE);
        MainFrm.DTTObj.AddToken ("7E13F8EC-5106-4879-8FC7-2779F2EAEECB", "EB05F049-94D6-4EC6-9DCE-8AB2A58F37CA", 1376256, "RetValue", v_RETVALUE);
        v_RETVALUE = IDL.Add(v_RETVALUE, (new IDVariant("\\")));
        MainFrm.DTTObj.AddAssignNewValue ("7E13F8EC-5106-4879-8FC7-2779F2EAEECB", "EB05F049-94D6-4EC6-9DCE-8AB2A58F37CA", v_RETVALUE);
      }
      MainFrm.DTTObj.EndIfBlk ("8653DEC0-1D2D-4042-9C90-FC73804E458C");
      MainFrm.DTTObj.AddReturn ("E767BAE2-5B52-4806-A1C3-C9E6D09A0221", "RETURN RetValue", "", v_RETVALUE);
      MainFrm.DTTObj.ExitProc ("6AD71CCD-BF52-4DF0-9035-FF90A9F99299", "Get Path Certificati", "Ritorna il percorso dei certificati con la barra alla fine", 2, "MainFrm");
      return v_RETVALUE;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("6AD71CCD-BF52-4DF0-9035-FF90A9F99299", "Get Path Certificati", "Ritorna il percorso dei certificati con la barra alla fine", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "GetPathCertificati", _e);
      MainFrm.DTTObj.ExitProc("6AD71CCD-BF52-4DF0-9035-FF90A9F99299", "Get Path Certificati", "Ritorna il percorso dei certificati con la barra alla fine", 2, "MainFrm");
      return new IDVariant();
    }
  }

  // **********************************************************************
  // Refresh Polling
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int RefreshPolling ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("20990343-4D5D-4784-BA78-793E2A196383", "Refresh Polling", "", 3, "MainFrm")) return 0;
      // 
      // Refresh Polling Body
      // Corpo Procedura
      // 
      IDVariant v_IORARIO = null;
      MainFrm.DTTObj.AddAssign ("587E7AD5-9D9C-406F-9B0C-587F47A97C31", "i Orario := Hour (Time ())", "", v_IORARIO);
      v_IORARIO = IDL.Hour(IDL.Time());
      MainFrm.DTTObj.AddAssignNewValue ("587E7AD5-9D9C-406F-9B0C-587F47A97C31", "25C7EB42-E5D1-4422-A522-60C264D6AB25", v_IORARIO);
      IDVariant v_IMINUTI = null;
      MainFrm.DTTObj.AddAssign ("6C205492-7482-4AEB-A5CC-40C2313A0D45", "i Minuti := Minute (Time ())", "", v_IMINUTI);
      v_IMINUTI = IDL.Minute(IDL.Time());
      MainFrm.DTTObj.AddAssignNewValue ("6C205492-7482-4AEB-A5CC-40C2313A0D45", "0DCCB891-C32D-4D5D-9B9D-24E48E7DE472", v_IMINUTI);
      MainFrm.DTTObj.AddSubProc ("90A29C6C-8D12-4626-A526-A8A5E7D4EF0A", "Notificatore.Valorizza Variabili Globali", "");
      ValorizzaVariabiliGlobali();
      MainFrm.DTTObj.AddSubProc ("45B6AA36-47C4-43B6-89AD-F4BFF0A29D29", "Notificatore.Write Debug", "");
      WriteDebug((new IDVariant("Server session attiva")), (new IDVariant(2)), (new IDVariant("Start Server session cycle")));
      // 
      // Controllo se è uin corso un'altra operazione
      // 
      MainFrm.DTTObj.AddIf ("44AAB29C-453A-46A1-B50F-F3E53ADE929A", "IF Refresh In Corso Notificatore = false", "Controllo se è uin corso un'altra operazione");
      MainFrm.DTTObj.AddToken ("44AAB29C-453A-46A1-B50F-F3E53ADE929A", "C1847AC8-46E8-42AA-A957-B731D0EED721", 1376256, "Refresh In Corso", REFREINCORSO);
      MainFrm.DTTObj.AddToken ("44AAB29C-453A-46A1-B50F-F3E53ADE929A", "78B75DA4-DBDF-11D4-900E-726096000000", 589824, "false", (new IDVariant(0)));
      if (REFREINCORSO.equals((new IDVariant(0)), true))
      {
        MainFrm.DTTObj.EnterIf ("44AAB29C-453A-46A1-B50F-F3E53ADE929A", "IF Refresh In Corso Notificatore = false", "Controllo se è uin corso un'altra operazione");
        // 
        // Se posso, segnalo che inizio a fare cose..
        // 
        MainFrm.DTTObj.AddAssign ("107467F0-D8D5-4C10-A82E-6C0053D7D471", "Refresh In Corso Notificatore := true", "Se posso, segnalo che inizio a fare cose..", REFREINCORSO);
        MainFrm.DTTObj.AddToken ("107467F0-D8D5-4C10-A82E-6C0053D7D471", "78B75DA3-DBDF-11D4-900E-726096000000", 589824, "true", (new IDVariant(-1)));
        REFREINCORSO = (new IDVariant(-1));
        MainFrm.DTTObj.AddAssignNewValue ("107467F0-D8D5-4C10-A82E-6C0053D7D471", "C1847AC8-46E8-42AA-A957-B731D0EED721", REFREINCORSO);
        MainFrm.DTTObj.AddAssign ("37B65115-651E-45C1-AD72-EFA24109BC8A", "GLB Contatore Notificatore := C0", "", GLBCONTATORE);
        GLBCONTATORE = (new IDVariant(0));
        MainFrm.DTTObj.AddAssignNewValue ("37B65115-651E-45C1-AD72-EFA24109BC8A", "B17E8FE0-7514-4CA4-A531-C7F39159839E", GLBCONTATORE);
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("3F465756-949F-4A2C-9807-BA8436D49D54", "ELSE", "", "44AAB29C-453A-46A1-B50F-F3E53ADE929A");
        MainFrm.DTTObj.AddAssign ("CD712E0A-2B93-4EB9-A0FA-4F2445FFFFBA", "GLB Contatore Notificatore := GLB Contatore Notificatore + 1", "", GLBCONTATORE);
        MainFrm.DTTObj.AddToken ("CD712E0A-2B93-4EB9-A0FA-4F2445FFFFBA", "B17E8FE0-7514-4CA4-A531-C7F39159839E", 1376256, "GLB Contatore", GLBCONTATORE);
        GLBCONTATORE = IDL.Add(GLBCONTATORE, (new IDVariant(1)));
        MainFrm.DTTObj.AddAssignNewValue ("CD712E0A-2B93-4EB9-A0FA-4F2445FFFFBA", "B17E8FE0-7514-4CA4-A531-C7F39159839E", GLBCONTATORE);
        MainFrm.DTTObj.AddIf ("72230250-44E1-4E01-B657-E2029693D3C6", "IF GLB Contatore Notificatore = 50", "");
        MainFrm.DTTObj.AddToken ("72230250-44E1-4E01-B657-E2029693D3C6", "B17E8FE0-7514-4CA4-A531-C7F39159839E", 1376256, "GLB Contatore", GLBCONTATORE);
        if (GLBCONTATORE.equals((new IDVariant(50)), true))
        {
          MainFrm.DTTObj.EnterIf ("72230250-44E1-4E01-B657-E2029693D3C6", "IF GLB Contatore Notificatore = 50", "");
          MainFrm.DTTObj.AddSubProc ("2836C1C4-7338-457A-A25B-6789B8759CB4", "Notificatore.Write Debug", "");
          WriteDebug((new IDVariant("Limite massimo iterazioni refresh. Azzero")), (new IDVariant(2)), (new IDVariant("Main server session")));
          MainFrm.DTTObj.AddAssign ("7F82BBF5-2DF9-4CBD-A09E-FF47E497FE31", "Refresh In Corso Notificatore := false", "", REFREINCORSO);
          MainFrm.DTTObj.AddToken ("7F82BBF5-2DF9-4CBD-A09E-FF47E497FE31", "78B75DA4-DBDF-11D4-900E-726096000000", 589824, "false", (new IDVariant(0)));
          REFREINCORSO = (new IDVariant(0));
          MainFrm.DTTObj.AddAssignNewValue ("7F82BBF5-2DF9-4CBD-A09E-FF47E497FE31", "C1847AC8-46E8-42AA-A957-B731D0EED721", REFREINCORSO);
        }
        MainFrm.DTTObj.EndIfBlk ("72230250-44E1-4E01-B657-E2029693D3C6");
        // 
        // altrimenti esco. Il notificatore è già impegnato
        // 
        MainFrm.DTTObj.ExitProc ("20990343-4D5D-4784-BA78-793E2A196383", "Refresh Polling", "Spiega quale elaborazione viene eseguita da questa procedura", 3, "MainFrm");
        return 0;
      }
      MainFrm.DTTObj.EndIfBlk ("44AAB29C-453A-46A1-B50F-F3E53ADE929A");
      try
      {
        // 
        // Se autorefresh è a SI eseguo l'invio delle notifiche
        // push per iOS
        // 
        MainFrm.DTTObj.AddIf ("94A00670-34B4-4E61-B4C4-00156436011A", "IF Glb Attiva Autorefresh Notificatore = Si", "Se autorefresh è a SI eseguo l'invio delle notifiche push per iOS");
        MainFrm.DTTObj.AddToken ("94A00670-34B4-4E61-B4C4-00156436011A", "A54D5C2F-B976-4120-ABDA-1766DFB98FE7", 1376256, "Glb Attiva Autorefresh", GLBATTIVAUTO);
        MainFrm.DTTObj.AddToken ("94A00670-34B4-4E61-B4C4-00156436011A", "607309F9-0C4D-4257-B6D9-D73344CC3ACA", 589824, "Si", (new IDVariant("S")));
        if (GLBATTIVAUTO.equals((new IDVariant("S")), true))
        {
          MainFrm.DTTObj.EnterIf ("94A00670-34B4-4E61-B4C4-00156436011A", "IF Glb Attiva Autorefresh Notificatore = Si", "Se autorefresh è a SI eseguo l'invio delle notifiche push per iOS");
          MainFrm.DTTObj.AddSubProc ("580D03D7-7A50-4ECE-9129-CBBDD491F85C", "Notificatore.Send APNS Push Notification", "");
          SendAPNSPushNotification();
          MainFrm.DTTObj.AddSubProc ("A19B5401-4AEC-450D-AC13-732602B276C8", "Notificatore.Send GCMNotification", "");
          SendGCMNotification((new IDVariant()));
          MainFrm.DTTObj.AddSubProc ("7B6171F4-8A01-4DC1-A3E6-D0C48C7502C8", "Notificatore.Send Win Store Notification", "");
          SendWinStoreNotification((new IDVariant()));
          MainFrm.DTTObj.AddSubProc ("9FCB96DE-FE7E-496C-916F-E868174163ED", "Notificatore.Send Win Phone Notification", "");
          SendWinPhoneNotification((new IDVariant()));
        }
        MainFrm.DTTObj.EndIfBlk ("94A00670-34B4-4E61-B4C4-00156436011A");
        // 
        // Se il check del feedback è a SI eseguo il controllo
        // del feedback IOS
        // 
        MainFrm.DTTObj.AddIf ("D3BB5F2B-A692-4D5F-989F-9ED07CB47651", "IF Glb Attiva Check Feedback Notificatore = Si", "Se il check del feedback è a SI eseguo il controllo del feedback IOS");
        MainFrm.DTTObj.AddToken ("D3BB5F2B-A692-4D5F-989F-9ED07CB47651", "B6800BA2-86F4-4DEA-A865-AED44D7EAFF1", 1376256, "Glb Attiva Check Feedback", GLBATTCHEFEE);
        MainFrm.DTTObj.AddToken ("D3BB5F2B-A692-4D5F-989F-9ED07CB47651", "607309F9-0C4D-4257-B6D9-D73344CC3ACA", 589824, "Si", (new IDVariant("S")));
        if (GLBATTCHEFEE.equals((new IDVariant("S")), true))
        {
          MainFrm.DTTObj.EnterIf ("D3BB5F2B-A692-4D5F-989F-9ED07CB47651", "IF Glb Attiva Check Feedback Notificatore = Si", "Se il check del feedback è a SI eseguo il controllo del feedback IOS");
          // 
          // ogni mezz'ora faccio la verifica del feedback
          // 
          MainFrm.DTTObj.AddIf ("A96D0F51-1DD5-4DA5-8229-ACE5C4690763", "IF i Minuti = 0 or i Minuti = 30", "ogni mezz'ora faccio la verifica del feedback");
          MainFrm.DTTObj.AddToken ("A96D0F51-1DD5-4DA5-8229-ACE5C4690763", "0DCCB891-C32D-4D5D-9B9D-24E48E7DE472", 1376256, "i Minuti", v_IMINUTI);
          if (v_IMINUTI.equals((new IDVariant(0)), true) || v_IMINUTI.equals((new IDVariant(30)), true))
          {
            MainFrm.DTTObj.EnterIf ("A96D0F51-1DD5-4DA5-8229-ACE5C4690763", "IF i Minuti = 0 or i Minuti = 30", "ogni mezz'ora faccio la verifica del feedback");
            // 
            // Se devo eliminare i token rimossi
            // 
            MainFrm.DTTObj.AddIf ("1B8DB69B-F2A4-4F64-851A-A2F43C88F7C3", "IF Glb Elimina Token Rimossi Notificatore = Si", "Se devo eliminare i token rimossi");
            MainFrm.DTTObj.AddToken ("1B8DB69B-F2A4-4F64-851A-A2F43C88F7C3", "889B6380-880A-44F3-B70C-C94305FD268E", 1376256, "Glb Elimina Token Rimossi", GLBELITOKRIM);
            MainFrm.DTTObj.AddToken ("1B8DB69B-F2A4-4F64-851A-A2F43C88F7C3", "D06F89A8-AF0E-4C8D-AD09-59A9DE4A5984", 589824, "Si", (new IDVariant("S")));
            if (GLBELITOKRIM.equals((new IDVariant("S")), true))
            {
              MainFrm.DTTObj.EnterIf ("1B8DB69B-F2A4-4F64-851A-A2F43C88F7C3", "IF Glb Elimina Token Rimossi Notificatore = Si", "Se devo eliminare i token rimossi");
              SQL = new StringBuilder();
              SQL.Append("delete from DEV_TOKENS ");
              SQL.Append("where (FLG_RIMOSSO = 'S') ");
              MainFrm.DTTObj.AddQuery ("94A23369-F8BD-4FCB-A167-C64551EAD3A0", "Device Token (Notificatore DB): Delete", "", 256, SQL.ToString());
              MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
              MainFrm.DTTObj.EndQuery ("94A23369-F8BD-4FCB-A167-C64551EAD3A0");
              MainFrm.DTTObj.AddParameter ("94A23369-F8BD-4FCB-A167-C64551EAD3A0", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
            }
            MainFrm.DTTObj.EndIfBlk ("1B8DB69B-F2A4-4F64-851A-A2F43C88F7C3");
          }
          MainFrm.DTTObj.EndIfBlk ("A96D0F51-1DD5-4DA5-8229-ACE5C4690763");
        }
        MainFrm.DTTObj.EndIfBlk ("D3BB5F2B-A692-4D5F-989F-9ED07CB47651");
        // 
        // Ogni ora controllo se è il caso di ripulire le code
        // vecchie
        // 
        MainFrm.DTTObj.AddIf ("ABF5655F-57F7-4E66-B4A3-CF9374191B23", "IF i Minuti = 0", "Ogni ora controllo se è il caso di ripulire le code vecchie");
        MainFrm.DTTObj.AddToken ("ABF5655F-57F7-4E66-B4A3-CF9374191B23", "0DCCB891-C32D-4D5D-9B9D-24E48E7DE472", 1376256, "i Minuti", v_IMINUTI);
        if (v_IMINUTI.equals((new IDVariant(0)), true))
        {
          MainFrm.DTTObj.EnterIf ("ABF5655F-57F7-4E66-B4A3-CF9374191B23", "IF i Minuti = 0", "Ogni ora controllo se è il caso di ripulire le code vecchie");
          IDVariant v_VDATAULTIMAE = new IDVariant(0,IDVariant.DATETIME);
          SQL = new StringBuilder();
          SQL.Append("select ");
          SQL.Append("  MAX(A.DAT_ELAB) as MAXDATELASPE ");
          SQL.Append("from ");
          SQL.Append("  SPEDIZIONI A ");
          SQL.Append("where (A.FLG_STATO = 'S') ");
          MainFrm.DTTObj.AddQuery ("8237FCCD-E6B2-4668-9A3E-625A756D264C", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
          QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
          if (!QV.EOF()) QV.MoveNext();
          MainFrm.DTTObj.EndQuery ("8237FCCD-E6B2-4668-9A3E-625A756D264C");
          MainFrm.DTTObj.AddDBDataSource (QV, SQL);
          if (!QV.EOF())
          {
            v_VDATAULTIMAE = QV.Get("MAXDATELASPE", IDVariant.DATETIME) ;
            MainFrm.DTTObj.AddToken ("8237FCCD-E6B2-4668-9A3E-625A756D264C", "6335CF51-8D07-4680-A9CC-48707159CF84", 1376256, "vDataUltimaElaborazione", v_VDATAULTIMAE);
          }
          QV.Close();
          IDVariant v_DDATALIMITE = null;
          MainFrm.DTTObj.AddAssign ("46988311-B64B-4B97-9493-48A6F1B9E7AF", "d Data Limite := Date Add (Day, - (Glb Retention Days Notificatore), vDataUltimaElaborazione)", "", v_DDATALIMITE);
          MainFrm.DTTObj.AddToken ("46988311-B64B-4B97-9493-48A6F1B9E7AF", "132B6115-2447-11D5-911F-1A0113000000", 589824, "Day", (new IDVariant("d")));
          MainFrm.DTTObj.AddToken ("46988311-B64B-4B97-9493-48A6F1B9E7AF", "23BA9F1D-CC70-433F-BAD9-C579ED246894", 1376256, "Glb Retention Days", GLBRETENDAYS);
          MainFrm.DTTObj.AddToken ("46988311-B64B-4B97-9493-48A6F1B9E7AF", "6335CF51-8D07-4680-A9CC-48707159CF84", 1376256, "vDataUltimaElaborazione", v_VDATAULTIMAE);
          v_DDATALIMITE = IDL.DateAdd((new IDVariant("d")),IDL.Neg(GLBRETENDAYS),v_VDATAULTIMAE);
          MainFrm.DTTObj.AddAssignNewValue ("46988311-B64B-4B97-9493-48A6F1B9E7AF", "DCCC63CA-8D96-4A96-8A3C-61AA43D91CDF", v_DDATALIMITE);
          SQL = new StringBuilder();
          SQL.Append("delete from SPEDIZIONI ");
          SQL.Append("where (DAT_ELAB <= " + IDL.CSql(v_DDATALIMITE, IDL.FMT_DAT2, MainFrm.NotificatoreDBObject.DBO()) + ") ");
          SQL.Append("and   (FLG_STATO = 'S') ");
          MainFrm.DTTObj.AddQuery ("8E15764A-CF5B-4D08-9571-4C8DFEA8F7C2", "Spedizioni (Notificatore DB): Delete", "", 256, SQL.ToString());
          MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
          MainFrm.DTTObj.EndQuery ("8E15764A-CF5B-4D08-9571-4C8DFEA8F7C2");
          MainFrm.DTTObj.AddParameter ("8E15764A-CF5B-4D08-9571-4C8DFEA8F7C2", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
        }
        MainFrm.DTTObj.EndIfBlk ("ABF5655F-57F7-4E66-B4A3-CF9374191B23");
      }
      catch (Exception e12)
      {
        MainFrm.DTTObj.AddException("54CB29F3-2776-45FB-A707-401332991231", "CATCH", "", e12, true);
        MainFrm.DTTObj.AddAssign ("2F54B7E8-81C4-45D3-A320-5236D9CBC725", "Refresh In Corso Notificatore := false", "", REFREINCORSO);
        MainFrm.DTTObj.AddToken ("2F54B7E8-81C4-45D3-A320-5236D9CBC725", "78B75DA4-DBDF-11D4-900E-726096000000", 589824, "false", (new IDVariant(0)));
        REFREINCORSO = (new IDVariant(0));
        MainFrm.DTTObj.AddAssignNewValue ("2F54B7E8-81C4-45D3-A320-5236D9CBC725", "C1847AC8-46E8-42AA-A957-B731D0EED721", REFREINCORSO);
        MainFrm.DTTObj.AddSubProc ("032287E4-9A6D-46FF-A1A4-809A3BCE2D8D", "Notificatore.Write Debug", "");
        WriteDebug(IDL.Add(new IDVariant(e12.Message), (new IDVariant(" : "))), (new IDVariant(1)), (new IDVariant("Main server session")));
      }
      MainFrm.DTTObj.AddAssign ("87FB3D49-5306-4E94-B8D3-C4847790D281", "Refresh In Corso Notificatore := false", "", REFREINCORSO);
      MainFrm.DTTObj.AddToken ("87FB3D49-5306-4E94-B8D3-C4847790D281", "78B75DA4-DBDF-11D4-900E-726096000000", 589824, "false", (new IDVariant(0)));
      REFREINCORSO = (new IDVariant(0));
      MainFrm.DTTObj.AddAssignNewValue ("87FB3D49-5306-4E94-B8D3-C4847790D281", "C1847AC8-46E8-42AA-A957-B731D0EED721", REFREINCORSO);
      MainFrm.DTTObj.ExitProc("20990343-4D5D-4784-BA78-793E2A196383", "Refresh Polling", "", 3, "MainFrm");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("20990343-4D5D-4784-BA78-793E2A196383", "Refresh Polling", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "RefreshPolling", _e);
      MainFrm.DTTObj.ExitProc("20990343-4D5D-4784-BA78-793E2A196383", "Refresh Polling", "", 3, "MainFrm");
      return -1;
    }
  }

  // **********************************************************************
  // Valorizza Variabili Globali
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int ValorizzaVariabiliGlobali ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("AAB5A6F3-2044-4894-9283-71663DFCDDCA", "Valorizza Variabili Globali", "", 3, "MainFrm")) return 0;
      // 
      // Valorizza Variabili Globali Body
      // Corpo Procedura
      // 
      // 
      // Percorsi per la nuova versione dei file
      // 
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  REPLACE(LTRIM(RTRIM(ISNULL(A.ADMIN_MAIL, 's.teodorani@apexnet.it'))), ' ', '') as RTNVIREISTAI, ");
      SQL.Append("  A.PATH_CERTS as PERCCERTIMPO, ");
      SQL.Append("  A.WS_URL as WEBSERREFIMP, ");
      SQL.Append("  A.MAX_MESSAGGI as MAXMESAPNIMP, ");
      SQL.Append("  A.FLG_REFRESH as ATTIAUTOIMPO, ");
      SQL.Append("  A.FLG_CHECK as ATTAUTFEEIMP, ");
      SQL.Append("  A.NUM_TIMEOUT as TIMESPEDIMPO, ");
      SQL.Append("  A.MAX_DAYS_RET as GIORRETEIMPO, ");
      SQL.Append("  A.FLG_DEL_REMOVED_TK as ELITOKRIMIMP, ");
      SQL.Append("  A.MAX_MESSAGGI_C2DM as MAXMESC2DIMP, ");
      SQL.Append("  A.FLG_DEBUG as TRACEIMPOSTA ");
      SQL.Append("from ");
      SQL.Append("  IMPOSTAZIONI A ");
      MainFrm.DTTObj.AddQuery ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741", "Notificatore DB (Notificatore DB): Select into variables", "Percorsi per la nuova versione dei file", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        GLBINDPOSREP = QV.Get("RTNVIREISTAI", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741", "69550C83-B1E3-458C-91D8-D5B3ABFCEF55", 1376256, "Glb Indirizzo Posta Report", GLBINDPOSREP);
        GLBPATHCERTI = QV.Get("PERCCERTIMPO", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741", "86F8C8B1-246B-4C53-BF5A-347D22AD9996", 1376256, "Glb Path Certificati", GLBPATHCERTI);
        GLBWSURL = QV.Get("WEBSERREFIMP", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741", "10ADFF3C-9D96-4180-92DE-D5CA73B4ADA5", 1376256, "Glb WS Url", GLBWSURL);
        GLBMAXMESAPN = QV.Get("MAXMESAPNIMP", IDVariant.INTEGER) ;
        MainFrm.DTTObj.AddToken ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741", "267CDC8C-DD64-4D24-B4F2-C4391A5C80B9", 1376256, "Glb Max Messaggi APNS", GLBMAXMESAPN);
        GLBATTIVAUTO = QV.Get("ATTIAUTOIMPO", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741", "A54D5C2F-B976-4120-ABDA-1766DFB98FE7", 1376256, "Glb Attiva Autorefresh", GLBATTIVAUTO);
        GLBATTCHEFEE = QV.Get("ATTAUTFEEIMP", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741", "B6800BA2-86F4-4DEA-A865-AED44D7EAFF1", 1376256, "Glb Attiva Check Feedback", GLBATTCHEFEE);
        GLBRITARSPED = QV.Get("TIMESPEDIMPO", IDVariant.INTEGER) ;
        MainFrm.DTTObj.AddToken ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741", "8A74DC0D-A1A1-44D8-A361-FF2AB610A0C2", 1376256, "Glb Ritardo Spedizione", GLBRITARSPED);
        GLBRETENDAYS = QV.Get("GIORRETEIMPO", IDVariant.INTEGER) ;
        MainFrm.DTTObj.AddToken ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741", "23BA9F1D-CC70-433F-BAD9-C579ED246894", 1376256, "Glb Retention Days", GLBRETENDAYS);
        GLBELITOKRIM = QV.Get("ELITOKRIMIMP", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741", "889B6380-880A-44F3-B70C-C94305FD268E", 1376256, "Glb Elimina Token Rimossi", GLBELITOKRIM);
        GLBMAXMESC2D = QV.Get("MAXMESC2DIMP", IDVariant.INTEGER) ;
        MainFrm.DTTObj.AddToken ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741", "6C3C97CC-47BF-405C-BBA3-A78D7A0C270D", 1376256, "Glb Max Messaggi C2DN", GLBMAXMESC2D);
        GLBTRACE = QV.Get("TRACEIMPOSTA", IDVariant.INTEGER) ;
        MainFrm.DTTObj.AddToken ("6D8EE228-F84F-4E77-96C0-1D8DA74EE741", "23CDB7CC-52F2-4CF7-91E5-68CB05883E0B", 1376256, "GLB Trace", GLBTRACE);
      }
      QV.Close();
      MainFrm.DTTObj.ExitProc("AAB5A6F3-2044-4894-9283-71663DFCDDCA", "Valorizza Variabili Globali", "", 3, "MainFrm");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("AAB5A6F3-2044-4894-9283-71663DFCDDCA", "Valorizza Variabili Globali", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "ValorizzaVariabiliGlobali", _e);
      MainFrm.DTTObj.ExitProc("AAB5A6F3-2044-4894-9283-71663DFCDDCA", "Valorizza Variabili Globali", "", 3, "MainFrm");
      return -1;
    }
  }

  // **********************************************************************
  // Send APNS Push Notification
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int SendAPNSPushNotification ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;
    IDCachedRowSet C2;
    IDCachedRowSet C7;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("66652DB6-BC00-4C70-80AE-991D5487CAE6", "Send APNS Push Notification", "", 3, "MainFrm")) return 0;
      // 
      // Send APNS Push Notification Body
      // Corpo Procedura
      // 
      IDVariant v_IMSGELABORAT = null;
      MainFrm.DTTObj.AddAssign ("0A38967F-3689-4055-87F6-EA8AD980EEB0", "i Msg Elaborato := C0", "", v_IMSGELABORAT);
      v_IMSGELABORAT = (new IDVariant(0));
      MainFrm.DTTObj.AddAssignNewValue ("0A38967F-3689-4055-87F6-EA8AD980EEB0", "D73CACFB-78B1-48F1-9CC7-3760DE78DA61", v_IMSGELABORAT);
      MainFrm.DTTObj.AddSubProc ("401D6652-7432-43E3-98A9-BE2D6E27D482", "Notificatore.Write Debug", "");
      WriteDebug((new IDVariant("INFO: Inizio invio notifiche iOS")), (new IDVariant(2)), (new IDVariant("Main server session - IOS")));
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // Ciclo per ogni applicazione che ha messaggi in coda
      // 
      int DTT_C2 = 0;
      MainFrm.DTTObj.AddForEach ("D2D1E08D-1356-45D0-A167-63F255E42967", "FOR EACH Spedizioni ROW", "Sono in una fascia oraria in cui non devo fare il refresh. Azzero la variabile\nCiclo per ogni applicazione che ha messaggi in coda");
      SQL = new StringBuilder();
      SQL.Append("select distinct ");
      SQL.Append("  A.ID_APPLICAZIONE as MIDAPPLICAZI ");
      SQL.Append("from ");
      SQL.Append("  SPEDIZIONI A, ");
      SQL.Append("  APPS_PUSH_SETTING B ");
      SQL.Append("where B.ID = A.ID_APPLICAZIONE ");
      SQL.Append("and   (A.FLG_STATO = 'W') ");
      SQL.Append("and   (A.TYPE_OS = '1') ");
      SQL.Append("and   (B.FLG_ATTIVA = 'S') ");
      MainFrm.DTTObj.AddToken ("D2D1E08D-1356-45D0-A167-63F255E42967", "D2D1E08D-1356-45D0-A167-63F255E42967", 0, "SQL", SQL.ToString());
      C2 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!C2.EOF()) C2.MoveNext();
      MainFrm.DTTObj.EndQuery ("D2D1E08D-1356-45D0-A167-63F255E42967");
      MainFrm.DTTObj.AddDBDataSource (C2, SQL);
      while (!C2.EOF())
      {
        DTT_C2 = DTT_C2 + 1;
        if (!MainFrm.DTTObj.CheckLoop("D2D1E08D-1356-45D0-A167-63F255E42967", DTT_C2)) break;
        IDVariant v_BSANDBOX = new IDVariant(0,IDVariant.INTEGER);
        IDVariant v_VCERTIFICATO = new IDVariant(0,IDVariant.STRING);
        IDVariant v_TROVATAAPP = new IDVariant(0,IDVariant.INTEGER);
        IDVariant v_VIDAPPPUSSET = new IDVariant(0,IDVariant.INTEGER);
        // 
        // Prelevo i dati dell'applicazione
        // 
        SQL = new StringBuilder();
        SQL.Append("select ");
        SQL.Append("  CASE WHEN A.FLG_AMBIENTE='S' OR (A.FLG_AMBIENTE IS NULL AND 'S' IS NULL) THEN 0 ELSE -1 END as IFEQAMAPSSFT, ");
        SQL.Append("  " + IDL.CSql(GLBPATHCERTI, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + " + '\\' + A.CERT_DEV as GLPACENCPAPS, ");
        SQL.Append("  A.ID as IDAPPSPUSSET ");
        SQL.Append("from ");
        SQL.Append("  APPS_PUSH_SETTING A ");
        SQL.Append("where (A.ID = " + IDL.CSql(C2.Get("MIDAPPLICAZI"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        SQL.Append("and   (A.FLG_ATTIVA = 'S') ");
        SQL.Append("and   (A.TYPE_OS = '1') ");
        MainFrm.DTTObj.AddQuery ("1902DD77-6908-4826-9B8D-7167ADBC2583", "Notificatore DB (Notificatore DB): Select into variables", "Prelevo i dati dell'applicazione", 1280, SQL.ToString());
        QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!QV.EOF()) QV.MoveNext();
        MainFrm.DTTObj.EndQuery ("1902DD77-6908-4826-9B8D-7167ADBC2583");
        MainFrm.DTTObj.AddDBDataSource (QV, SQL);
        v_TROVATAAPP = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
        if (!QV.EOF())
        {
          v_BSANDBOX = QV.Get("IFEQAMAPSSFT", IDVariant.INTEGER) ;
          MainFrm.DTTObj.AddToken ("1902DD77-6908-4826-9B8D-7167ADBC2583", "CF261AED-918D-43A7-BAD8-BA80BD796679", 1376256, "bSandbox", v_BSANDBOX);
          v_VCERTIFICATO = QV.Get("GLPACENCPAPS", IDVariant.STRING) ;
          MainFrm.DTTObj.AddToken ("1902DD77-6908-4826-9B8D-7167ADBC2583", "EFF1BC42-1225-4E99-AFF6-716974CDF543", 1376256, "vCertificato", v_VCERTIFICATO);
          v_VIDAPPPUSSET = QV.Get("IDAPPSPUSSET", IDVariant.INTEGER) ;
          MainFrm.DTTObj.AddToken ("1902DD77-6908-4826-9B8D-7167ADBC2583", "24B7EC1F-F2DE-45BC-860D-F704EF1DAB88", 1376256, "v ID Apps Push Settings", v_VIDAPPPUSSET);
        }
        QV.Close();
        // 
        // Se trovo ma configurazione (ovvio)
        // 
        MainFrm.DTTObj.AddIf ("722AC4FC-2408-498D-A552-061F7564D5B7", "IF Trovata APP", "Se trovo ma configurazione (ovvio)");
        MainFrm.DTTObj.AddToken ("722AC4FC-2408-498D-A552-061F7564D5B7", "D2C5A9CE-DB7C-4644-91DB-79D85137ABD8", 1376256, "Trovata APP", v_TROVATAAPP.booleanValue());
        if (v_TROVATAAPP.booleanValue())
        {
          MainFrm.DTTObj.EnterIf ("722AC4FC-2408-498D-A552-061F7564D5B7", "IF Trovata APP", "Se trovo ma configurazione (ovvio)");
          System.Security.Cryptography.X509Certificates.X509Certificate2 v_XC = null;
          MainFrm.DTTObj.AddAssign ("5D7C0298-4E4F-4648-9A4A-A4B0157E8178", "xc := xc.New Instance (vCertificato)", "", v_XC);
          MainFrm.DTTObj.AddToken ("5D7C0298-4E4F-4648-9A4A-A4B0157E8178", "EFF1BC42-1225-4E99-AFF6-716974CDF543", 1376256, "vCertificato", v_VCERTIFICATO);
          v_XC = new System.Security.Cryptography.X509Certificates.X509Certificate2(System.IO.File.ReadAllBytes(v_VCERTIFICATO.stringValue()));
          MainFrm.DTTObj.AddAssignNewValue ("5D7C0298-4E4F-4648-9A4A-A4B0157E8178", "8AC4C006-B5B8-417C-8826-1A51FD44D489", v_XC);
          IDVariant D = new IDVariant(0,IDVariant.DATETIME);
          MainFrm.DTTObj.AddAssign ("F11A64D6-E5C2-4E7A-8906-605A9ABFAE50", "d := xc.Get Expiration Date String ()", "", D);
          D = (new IDVariant(Convert.ToDateTime(v_XC.GetExpirationDateString())));
          MainFrm.DTTObj.AddAssignNewValue ("F11A64D6-E5C2-4E7A-8906-605A9ABFAE50", "CD1F2226-BA19-42B7-83B2-9A5071880B01", D);
          MainFrm.DTTObj.AddIf ("6A975967-4166-465D-AB2A-DA2839DB60D0", "IF d < Now ()", "");
          MainFrm.DTTObj.AddToken ("6A975967-4166-465D-AB2A-DA2839DB60D0", "CD1F2226-BA19-42B7-83B2-9A5071880B01", 1376256, "d", D);
          if (D.compareTo(IDL.Now(), true)<0)
          {
            MainFrm.DTTObj.EnterIf ("6A975967-4166-465D-AB2A-DA2839DB60D0", "IF d < Now ()", "");
            MainFrm.DTTObj.AddSubProc ("A9FDDCEA-B2F0-4866-966B-2FCEEA301387", "Notificatore.Write Debug", "");
            WriteDebug(IDL.FormatMessage((new IDVariant("Certificato app|1 non valido")), IDL.ToString(v_VIDAPPPUSSET)), (new IDVariant(2)), (new IDVariant("Main server session - IOS")));
            SQL = new StringBuilder();
            SQL.Append("update APPS_PUSH_SETTING set ");
            SQL.Append("  FLG_ATTIVA = 'N', ");
            SQL.Append("  DES_ERR = 'Disattivata dal sistema:CertExp:' + CONVERT (varchar(8000), " + IDL.CSql(D, IDL.FMT_DAT2, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            SQL.Append("where (ID = " + IDL.CSql(v_VIDAPPPUSSET, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            MainFrm.DTTObj.AddQuery ("3C1DEF52-322F-4416-9DDA-1F79DDABA4D8", "Apps Push Settings (Notificatore DB): Update", "", 512, SQL.ToString());
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            MainFrm.DTTObj.EndQuery ("3C1DEF52-322F-4416-9DDA-1F79DDABA4D8");
            MainFrm.DTTObj.AddParameter ("3C1DEF52-322F-4416-9DDA-1F79DDABA4D8", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
            MainFrm.DTTObj.ExitProc ("66652DB6-BC00-4C70-80AE-991D5487CAE6", "Send APNS Push Notification", "Spiega quale elaborazione viene eseguita da questa procedura", 3, "MainFrm");
            return 0;
          }
          MainFrm.DTTObj.EndIfBlk ("6A975967-4166-465D-AB2A-DA2839DB60D0");
          PushSharp.Apple.ApnsConfiguration v_AC = null;
          MainFrm.DTTObj.AddAssign ("6426937C-E985-4332-9386-80AF09A75120", "ac := ac.new Instance (bSandbox, xc)", "", v_AC);
          MainFrm.DTTObj.AddToken ("6426937C-E985-4332-9386-80AF09A75120", "CF261AED-918D-43A7-BAD8-BA80BD796679", 1376256, "bSandbox", v_BSANDBOX.booleanValue());
          if (v_XC != null) MainFrm.DTTObj.AddToken ("6426937C-E985-4332-9386-80AF09A75120", "8AC4C006-B5B8-417C-8826-1A51FD44D489", 1376256, "xc", v_XC);
          v_AC = new PushSharp.Apple.ApnsConfiguration(v_BSANDBOX.booleanValue() ? PushSharp.Apple.ApnsConfiguration.ApnsServerEnvironment.Production : PushSharp.Apple.ApnsConfiguration.ApnsServerEnvironment.Sandbox, v_XC);
          MainFrm.DTTObj.AddAssignNewValue ("6426937C-E985-4332-9386-80AF09A75120", "D38B4624-1E89-445E-A76A-5E6D68C209C7", v_AC);
          PushSharp.Apple.ApnsServiceBroker v_PB = null;
          MainFrm.DTTObj.AddAssign ("4F6BAF7F-AA6D-49C6-B42D-010101FF9B1F", "pb := pb.new Instance (ac)", "", v_PB);
          if (v_AC != null) MainFrm.DTTObj.AddToken ("4F6BAF7F-AA6D-49C6-B42D-010101FF9B1F", "D38B4624-1E89-445E-A76A-5E6D68C209C7", 1376256, "ac", v_AC);
          v_PB = new PushSharp.Apple.ApnsServiceBroker(v_AC);
          MainFrm.DTTObj.AddAssignNewValue ("4F6BAF7F-AA6D-49C6-B42D-010101FF9B1F", "EE4857B7-0B84-46C2-9E63-98D544E0E509", v_PB);
          MainFrm.DTTObj.AddSubProc ("7A298C90-7CBA-45D5-9D62-F446341480A7", "pb.Connect events", "");
          v_PB.OnNotificationSucceeded += PushSharpHelper.NotificationSucceeded;
          v_PB.OnNotificationFailed += PushSharpHelper.NotificationFailed;
          MainFrm.DTTObj.AddSubProc ("47F1EC48-8522-4AC5-BD45-B9F5AA21BCFA", "pb.Start", "");
          v_PB.Start();
          IDVariant v_SPAYLOAD = null;
          MainFrm.DTTObj.AddAssign ("D1887436-9053-471E-8F90-DED3BFE48E5D", "s Payload := Notification Payload", "", v_SPAYLOAD);
          MainFrm.DTTObj.AddToken ("D1887436-9053-471E-8F90-DED3BFE48E5D", "AAFD617A-EE1A-43C2-9635-3B57E954A66D", 589824, "Notification Payload", (new IDVariant("{\n    \"aps\" : {\n        \"alert\" : \"|1\",\n        \"badge\" : |2,\n        \"sound\" : \"|3\"\n    },\n    \"custom-field-1\" : \"|4\",\n    \"custom-field-2\" : \"|5\"\n}")));
          v_SPAYLOAD = (new IDVariant("{\n    \"aps\" : {\n        \"alert\" : \"|1\",\n        \"badge\" : |2,\n        \"sound\" : \"|3\"\n    },\n    \"custom-field-1\" : \"|4\",\n    \"custom-field-2\" : \"|5\"\n}"));
          MainFrm.DTTObj.AddAssignNewValue ("D1887436-9053-471E-8F90-DED3BFE48E5D", "52B0AACA-8120-482C-925F-A31FC4E14D43", v_SPAYLOAD);
          try
          {
            // 
            // Sono nella fascia oraria prevista per il refresh dei
            // dati...
            // 
            int DTT_C7 = 0;
            MainFrm.DTTObj.AddForEach ("D297482F-E581-4FEE-8269-C35E759D0F5C", "FOR EACH Spedizioni ROW", "Sono nella fascia oraria prevista per il refresh dei dati...");
            SQL = new StringBuilder();
            SQL.Append("select ");
            SQL.Append("  A.ID as IDSPEDIZIONE, ");
            SQL.Append("  REPLACE(A.DEV_TOKEN, ' ', '') as RDEVICETOKEN, ");
            SQL.Append("  A.ID_APPLICAZIONE as RIDAPPLICAZI, ");
            SQL.Append("  A.DES_MESSAGGIO as RMESSAGGIO, ");
            SQL.Append("  A.DES_UTENTE as RUTENTE, ");
            SQL.Append("  A.SOUND as SOUNDSPEDIZI, ");
            SQL.Append("  ISNULL(A.BADGE, 0) as BADGESPEDIZI, ");
            SQL.Append("  A.CUSTOM_FIELD1 as CUSTFIEL1SPE, ");
            SQL.Append("  A.CUSTOM_FIELD2 as CUSTFIEL2SPE ");
            SQL.Append("from ");
            SQL.Append("  SPEDIZIONI A ");
            SQL.Append("where (A.ID_APPLICAZIONE = " + IDL.CSql(C2.Get("MIDAPPLICAZI"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            SQL.Append("and   (A.FLG_STATO = 'W') ");
            SQL.Append("and   (LEN(A.DEV_TOKEN) = 64) ");
            MainFrm.DTTObj.AddToken ("D297482F-E581-4FEE-8269-C35E759D0F5C", "D297482F-E581-4FEE-8269-C35E759D0F5C", 0, "SQL", SQL.ToString());
            C7 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
            C7.setColUnbound(2,true);
            C7.setColUnbound(7,true);
            if (!C7.EOF()) C7.MoveNext();
            MainFrm.DTTObj.EndQuery ("D297482F-E581-4FEE-8269-C35E759D0F5C");
            MainFrm.DTTObj.AddDBDataSource (C7, SQL);
            while (!C7.EOF())
            {
              DTT_C7 = DTT_C7 + 1;
              if (!MainFrm.DTTObj.CheckLoop("D297482F-E581-4FEE-8269-C35E759D0F5C", DTT_C7)) break;
              IDVariant v_SALERTMESSAG = new IDVariant(0,IDVariant.STRING);
              IDVariant v_SBADGE = null;
              MainFrm.DTTObj.AddAssign ("F7B8D948-352E-40B6-B418-FDE55BDE3BB8", "s Badge := C0", "", v_SBADGE);
              v_SBADGE = (new IDVariant(0));
              MainFrm.DTTObj.AddAssignNewValue ("F7B8D948-352E-40B6-B418-FDE55BDE3BB8", "4A2A8498-A760-4EBB-9B58-FBECCC80033F", v_SBADGE);
              IDVariant v_SSOUND = new IDVariant(0,IDVariant.STRING);
              IDVariant v_SCUSTOMFI1 = new IDVariant(0,IDVariant.STRING);
              IDVariant v_SCUSTOMFIELD = new IDVariant(0,IDVariant.STRING);
              MainFrm.DTTObj.AddAssign ("5C01C474-0C3B-4EDF-8185-91FC87D6D236", "i Msg Elaborato := i Msg Elaborato + 1", "", v_IMSGELABORAT);
              MainFrm.DTTObj.AddToken ("5C01C474-0C3B-4EDF-8185-91FC87D6D236", "D73CACFB-78B1-48F1-9CC7-3760DE78DA61", 1376256, "i Msg Elaborato", v_IMSGELABORAT);
              v_IMSGELABORAT = IDL.Add(v_IMSGELABORAT, (new IDVariant(1)));
              MainFrm.DTTObj.AddAssignNewValue ("5C01C474-0C3B-4EDF-8185-91FC87D6D236", "D73CACFB-78B1-48F1-9CC7-3760DE78DA61", v_IMSGELABORAT);
              // 
              // Se ho raggiunto il numero massimo di elaborazioni da
              // effettuare
              // 
              MainFrm.DTTObj.AddIf ("AB0A27B9-EBA6-4848-AFB9-2B133A685A18", "IF i Msg Elaborato > Glb Max Messaggi APNS Notificatore", "Se ho raggiunto il numero massimo di elaborazioni da effettuare");
              MainFrm.DTTObj.AddToken ("AB0A27B9-EBA6-4848-AFB9-2B133A685A18", "D73CACFB-78B1-48F1-9CC7-3760DE78DA61", 1376256, "i Msg Elaborato", v_IMSGELABORAT);
              MainFrm.DTTObj.AddToken ("AB0A27B9-EBA6-4848-AFB9-2B133A685A18", "267CDC8C-DD64-4D24-B4F2-C4391A5C80B9", 1376256, "Glb Max Messaggi APNS", GLBMAXMESAPN);
              if (v_IMSGELABORAT.compareTo(GLBMAXMESAPN, true)>0)
              {
                MainFrm.DTTObj.EnterIf ("AB0A27B9-EBA6-4848-AFB9-2B133A685A18", "IF i Msg Elaborato > Glb Max Messaggi APNS Notificatore", "Se ho raggiunto il numero massimo di elaborazioni da effettuare");
                MainFrm.DTTObj.AddAssign ("A4C6662B-E683-48A2-847E-9D5AF8BE6654", "i Msg Elaborato := C0", "", v_IMSGELABORAT);
                v_IMSGELABORAT = (new IDVariant(0));
                MainFrm.DTTObj.AddAssignNewValue ("A4C6662B-E683-48A2-847E-9D5AF8BE6654", "D73CACFB-78B1-48F1-9CC7-3760DE78DA61", v_IMSGELABORAT);
                IDVariant v_SMSG = null;
                MainFrm.DTTObj.AddAssign ("9252C312-6ECA-4161-8876-823D9E287ECD", "s Msg := Format Message (\"Ne ho spediti |1. L'ultimo è il |2\", To String (Glb Max Messaggi APNS Notificatore), To String (ID Spedizione), ??, ??, ??)", "", v_SMSG);
                MainFrm.DTTObj.AddToken ("9252C312-6ECA-4161-8876-823D9E287ECD", "267CDC8C-DD64-4D24-B4F2-C4391A5C80B9", 1376256, "Glb Max Messaggi APNS", GLBMAXMESAPN);
                MainFrm.DTTObj.AddToken ("9252C312-6ECA-4161-8876-823D9E287ECD", "45599313-695D-40F4-9E6A-FA2522F3C137", 1376256, "ID Spedizione", C7.Get("IDSPEDIZIONE"));
                v_SMSG = IDL.FormatMessage((new IDVariant("Ne ho spediti |1. L'ultimo è il |2")), IDL.ToString(GLBMAXMESAPN), IDL.ToString(C7.Get("IDSPEDIZIONE")));
                MainFrm.DTTObj.AddAssignNewValue ("9252C312-6ECA-4161-8876-823D9E287ECD", "372439F6-81BD-41F8-8E3B-CD072AEB3091", v_SMSG);
                MainFrm.DTTObj.AddSubProc ("80BEF13E-F46C-49D6-97F7-64430BC4A9EF", "Notificatore.Write Debug", "");
                WriteDebug(v_SMSG, (new IDVariant(2)), (new IDVariant("Main server session - IOS")));
                MainFrm.DTTObj.AddBreak ("16688AC7-245A-4A6B-80FC-DFD917268EB5", "BREAK", "");
                break;
              }
              MainFrm.DTTObj.EndIfBlk ("AB0A27B9-EBA6-4848-AFB9-2B133A685A18");
              PushSharp.Apple.ApnsNotification v_APN = null;
              MainFrm.DTTObj.AddAssign ("45D8EFF3-289F-471A-B5E6-02D8282852EB", "apn := new ()", "", v_APN);
              v_APN = (PushSharp.Apple.ApnsNotification)new PushSharp.Apple.ApnsNotification();
              MainFrm.DTTObj.AddAssignNewValue ("45D8EFF3-289F-471A-B5E6-02D8282852EB", "D049AA85-283D-4C9F-8198-64190DAFCB89", v_APN);
              MainFrm.DTTObj.AddAssign ("46547E07-055B-4D6E-B836-9235482D68A6", "apn.Device Token := r Device Token Spedizione", "", v_APN.DeviceToken);
              MainFrm.DTTObj.AddToken ("46547E07-055B-4D6E-B836-9235482D68A6", "D00392E4-7186-4821-8506-41CA9E776D75", 1376256, "r Device Token", new IDVariant(C7.Get("RDEVICETOKEN")));
              v_APN.DeviceToken = new IDVariant(C7.Get("RDEVICETOKEN")).stringValue();
              MainFrm.DTTObj.AddAssignNewValue ("46547E07-055B-4D6E-B836-9235482D68A6", "D049AA85-283D-4C9F-8198-64190DAFCB89", v_APN.DeviceToken);
              // 
              // Se c'è il messaggio lo metto nel payload
              // 
              MainFrm.DTTObj.AddIf ("34E3ACF8-B606-4C50-A3A9-004CAC50BE9B", "IF not (Is Null (r Messaggio Spedizione)) and r Messaggio Spedizione != \"\"", "Se c'è il messaggio lo metto nel payload");
              MainFrm.DTTObj.AddToken ("34E3ACF8-B606-4C50-A3A9-004CAC50BE9B", "AEAD0175-DD3D-4691-8B91-8C831B00B014", 1376256, "r Messaggio", C7.Get("RMESSAGGIO"));
              if (!(IDL.IsNull(C7.Get("RMESSAGGIO"))) && C7.Get("RMESSAGGIO").compareTo((new IDVariant("")), true)!=0)
              {
                MainFrm.DTTObj.EnterIf ("34E3ACF8-B606-4C50-A3A9-004CAC50BE9B", "IF not (Is Null (r Messaggio Spedizione)) and r Messaggio Spedizione != \"\"", "Se c'è il messaggio lo metto nel payload");
                MainFrm.DTTObj.AddAssign ("B39F3DAE-E844-4D62-89AE-1A8981FFA2DF", "s Alert Message := Json Stringfy (r Messaggio Spedizione)", "", v_SALERTMESSAG);
                MainFrm.DTTObj.AddToken ("B39F3DAE-E844-4D62-89AE-1A8981FFA2DF", "AEAD0175-DD3D-4691-8B91-8C831B00B014", 1376256, "r Messaggio", C7.Get("RMESSAGGIO"));
                v_SALERTMESSAG = JsonStringfy(C7.Get("RMESSAGGIO"));
                MainFrm.DTTObj.AddAssignNewValue ("B39F3DAE-E844-4D62-89AE-1A8981FFA2DF", "8291B78E-2624-4A7C-9AD2-82AD7AEB6458", v_SALERTMESSAG);
              }
              MainFrm.DTTObj.EndIfBlk ("34E3ACF8-B606-4C50-A3A9-004CAC50BE9B");
              // 
              // Se c'è il suono lo metto nel payload
              // 
              MainFrm.DTTObj.AddIf ("E3B2595B-CE71-4B01-B974-F3B3F298C6F9", "IF not (Is Null (Sound Spedizione)) and Sound Spedizione != \"\"", "Se c'è il suono lo metto nel payload");
              MainFrm.DTTObj.AddToken ("E3B2595B-CE71-4B01-B974-F3B3F298C6F9", "6CA2B1A6-C034-40ED-B18E-D9191B09CA72", 1376256, "Sound Spedizione", C7.Get("SOUNDSPEDIZI"));
              if (!(IDL.IsNull(C7.Get("SOUNDSPEDIZI"))) && C7.Get("SOUNDSPEDIZI").compareTo((new IDVariant("")), true)!=0)
              {
                MainFrm.DTTObj.EnterIf ("E3B2595B-CE71-4B01-B974-F3B3F298C6F9", "IF not (Is Null (Sound Spedizione)) and Sound Spedizione != \"\"", "Se c'è il suono lo metto nel payload");
                MainFrm.DTTObj.AddAssign ("3852C9B1-6B82-4215-87F7-FC4B64A22B58", "s Sound := Sound Spedizione", "", v_SSOUND);
                MainFrm.DTTObj.AddToken ("3852C9B1-6B82-4215-87F7-FC4B64A22B58", "6CA2B1A6-C034-40ED-B18E-D9191B09CA72", 1376256, "Sound Spedizione", new IDVariant(C7.Get("SOUNDSPEDIZI")));
                v_SSOUND = new IDVariant(C7.Get("SOUNDSPEDIZI"));
                MainFrm.DTTObj.AddAssignNewValue ("3852C9B1-6B82-4215-87F7-FC4B64A22B58", "CBA1D745-03AE-4B4A-BF1E-383B95B192A2", v_SSOUND);
              }
              MainFrm.DTTObj.EndIfBlk ("E3B2595B-CE71-4B01-B974-F3B3F298C6F9");
              // 
              // Se c'è il badge lo metto nel payload
              // 
              MainFrm.DTTObj.AddIf ("72958E98-7171-4EB6-B8EB-8F481F1BBAC3", "IF Badge Spedizione >= 0", "Se c'è il badge lo metto nel payload");
              MainFrm.DTTObj.AddToken ("72958E98-7171-4EB6-B8EB-8F481F1BBAC3", "41EB974A-A309-4EA6-9235-A9A652EBC828", 1376256, "Badge Spedizione", C7.Get("BADGESPEDIZI"));
              if (C7.Get("BADGESPEDIZI").compareTo((new IDVariant(0)), true)>=0)
              {
                MainFrm.DTTObj.EnterIf ("72958E98-7171-4EB6-B8EB-8F481F1BBAC3", "IF Badge Spedizione >= 0", "Se c'è il badge lo metto nel payload");
                MainFrm.DTTObj.AddAssign ("D4DB6BCA-B359-4E5A-874E-33A775F17419", "s Badge := Badge Spedizione", "", v_SBADGE);
                MainFrm.DTTObj.AddToken ("D4DB6BCA-B359-4E5A-874E-33A775F17419", "41EB974A-A309-4EA6-9235-A9A652EBC828", 1376256, "Badge Spedizione", new IDVariant(C7.Get("BADGESPEDIZI")));
                v_SBADGE = new IDVariant(C7.Get("BADGESPEDIZI"));
                MainFrm.DTTObj.AddAssignNewValue ("D4DB6BCA-B359-4E5A-874E-33A775F17419", "4A2A8498-A760-4EBB-9B58-FBECCC80033F", v_SBADGE);
              }
              MainFrm.DTTObj.EndIfBlk ("72958E98-7171-4EB6-B8EB-8F481F1BBAC3");
              // 
              // Controllo se il Custom field 1 è valorizzato
              // 
              MainFrm.DTTObj.AddIf ("61C8A546-7CE9-40F2-965C-4D56902BDD56", "IF not (Is Null (Custom Field 1 Spedizione)) and Custom Field 1 Spedizione != \"\"", "Controllo se il Custom field 1 è valorizzato");
              MainFrm.DTTObj.AddToken ("61C8A546-7CE9-40F2-965C-4D56902BDD56", "0423617E-5F37-4A02-BB2F-8160616CCA82", 1376256, "Custom Field 1 Spedizione", C7.Get("CUSTFIEL1SPE"));
              if (!(IDL.IsNull(C7.Get("CUSTFIEL1SPE"))) && C7.Get("CUSTFIEL1SPE").compareTo((new IDVariant("")), true)!=0)
              {
                MainFrm.DTTObj.EnterIf ("61C8A546-7CE9-40F2-965C-4D56902BDD56", "IF not (Is Null (Custom Field 1 Spedizione)) and Custom Field 1 Spedizione != \"\"", "Controllo se il Custom field 1 è valorizzato");
                MainFrm.DTTObj.AddAssign ("9032ED5E-0E0A-46C6-B4AF-A66886FA5871", "s Custom Field1 := Custom Field 1 Spedizione", "", v_SCUSTOMFI1);
                MainFrm.DTTObj.AddToken ("9032ED5E-0E0A-46C6-B4AF-A66886FA5871", "0423617E-5F37-4A02-BB2F-8160616CCA82", 1376256, "Custom Field 1 Spedizione", new IDVariant(C7.Get("CUSTFIEL1SPE")));
                v_SCUSTOMFI1 = new IDVariant(C7.Get("CUSTFIEL1SPE"));
                MainFrm.DTTObj.AddAssignNewValue ("9032ED5E-0E0A-46C6-B4AF-A66886FA5871", "366B87CF-2310-4BB2-8C4B-7C8BCF7E2405", v_SCUSTOMFI1);
              }
              MainFrm.DTTObj.EndIfBlk ("61C8A546-7CE9-40F2-965C-4D56902BDD56");
              // 
              // Controllo se il Custom field 2 è valorizzato
              // 
              MainFrm.DTTObj.AddIf ("6DB72A30-054E-46F1-A4B5-E87321EB1E05", "IF not (Is Null (Custom Field 2 Spedizione)) and Custom Field 2 Spedizione != \"\"", "Controllo se il Custom field 2 è valorizzato");
              MainFrm.DTTObj.AddToken ("6DB72A30-054E-46F1-A4B5-E87321EB1E05", "BAD31227-F19E-492A-84E7-519C76351CC4", 1376256, "Custom Field 2 Spedizione", C7.Get("CUSTFIEL2SPE"));
              if (!(IDL.IsNull(C7.Get("CUSTFIEL2SPE"))) && C7.Get("CUSTFIEL2SPE").compareTo((new IDVariant("")), true)!=0)
              {
                MainFrm.DTTObj.EnterIf ("6DB72A30-054E-46F1-A4B5-E87321EB1E05", "IF not (Is Null (Custom Field 2 Spedizione)) and Custom Field 2 Spedizione != \"\"", "Controllo se il Custom field 2 è valorizzato");
                MainFrm.DTTObj.AddAssign ("3A769420-D02B-4E61-A5D7-E83ABEC8522F", "s Custom Field2 := Custom Field 2 Spedizione", "", v_SCUSTOMFIELD);
                MainFrm.DTTObj.AddToken ("3A769420-D02B-4E61-A5D7-E83ABEC8522F", "BAD31227-F19E-492A-84E7-519C76351CC4", 1376256, "Custom Field 2 Spedizione", new IDVariant(C7.Get("CUSTFIEL2SPE")));
                v_SCUSTOMFIELD = new IDVariant(C7.Get("CUSTFIEL2SPE"));
                MainFrm.DTTObj.AddAssignNewValue ("3A769420-D02B-4E61-A5D7-E83ABEC8522F", "81AC4679-1010-42B7-9803-C31FE725820A", v_SCUSTOMFIELD);
              }
              MainFrm.DTTObj.EndIfBlk ("6DB72A30-054E-46F1-A4B5-E87321EB1E05");
              MainFrm.DTTObj.AddAssign ("37345A34-89C5-4C0A-B36D-1327BA0684BD", "s Payload := Format Message (Notification Payload, s Alert Message, s Badge, s Sound, Custom Field 1 Spedizione, Custom Field 2 Spedizione)", "", v_SPAYLOAD);
              MainFrm.DTTObj.AddToken ("37345A34-89C5-4C0A-B36D-1327BA0684BD", "AAFD617A-EE1A-43C2-9635-3B57E954A66D", 589824, "Notification Payload", (new IDVariant("{\n    \"aps\" : {\n        \"alert\" : \"|1\",\n        \"badge\" : |2,\n        \"sound\" : \"|3\"\n    },\n    \"custom-field-1\" : \"|4\",\n    \"custom-field-2\" : \"|5\"\n}")));
              MainFrm.DTTObj.AddToken ("37345A34-89C5-4C0A-B36D-1327BA0684BD", "8291B78E-2624-4A7C-9AD2-82AD7AEB6458", 1376256, "s Alert Message", v_SALERTMESSAG);
              MainFrm.DTTObj.AddToken ("37345A34-89C5-4C0A-B36D-1327BA0684BD", "4A2A8498-A760-4EBB-9B58-FBECCC80033F", 1376256, "s Badge", v_SBADGE);
              MainFrm.DTTObj.AddToken ("37345A34-89C5-4C0A-B36D-1327BA0684BD", "CBA1D745-03AE-4B4A-BF1E-383B95B192A2", 1376256, "s Sound", v_SSOUND);
              MainFrm.DTTObj.AddToken ("37345A34-89C5-4C0A-B36D-1327BA0684BD", "0423617E-5F37-4A02-BB2F-8160616CCA82", 1376256, "Custom Field 1 Spedizione", C7.Get("CUSTFIEL1SPE"));
              MainFrm.DTTObj.AddToken ("37345A34-89C5-4C0A-B36D-1327BA0684BD", "BAD31227-F19E-492A-84E7-519C76351CC4", 1376256, "Custom Field 2 Spedizione", C7.Get("CUSTFIEL2SPE"));
              v_SPAYLOAD = IDL.FormatMessage((new IDVariant("{\n    \"aps\" : {\n        \"alert\" : \"|1\",\n        \"badge\" : |2,\n        \"sound\" : \"|3\"\n    },\n    \"custom-field-1\" : \"|4\",\n    \"custom-field-2\" : \"|5\"\n}")), v_SALERTMESSAG, v_SBADGE, v_SSOUND, C7.Get("CUSTFIEL1SPE"), C7.Get("CUSTFIEL2SPE"));
              MainFrm.DTTObj.AddAssignNewValue ("37345A34-89C5-4C0A-B36D-1327BA0684BD", "52B0AACA-8120-482C-925F-A31FC4E14D43", v_SPAYLOAD);
              MainFrm.DTTObj.AddSubProc ("CD94D0CF-7AE9-4D65-B209-6D2A7C56DC2C", "apn.Payload", "");
              MainFrm.DTTObj.AddParameter ("CD94D0CF-7AE9-4D65-B209-6D2A7C56DC2C", "AA6F8970-DD80-4B65-B8E3-78D95CB72BC6", "Payload", v_SPAYLOAD);
              v_APN.Payload = Newtonsoft.Json.Linq.JObject.Parse(v_SPAYLOAD.stringValue()); 
              MainFrm.DTTObj.AddSubProc ("159522E1-6ED6-4EA4-BA0A-287DAD718C57", "pb.QueueNotification", "");
              MainFrm.DTTObj.AddParameter ("159522E1-6ED6-4EA4-BA0A-287DAD718C57", "8F0BF090-BD5C-47CB-B4C3-21F4166466AF", "Apple notification", v_APN);
              v_PB.QueueNotification(v_APN); 
              // 
              // Metto il messaggio in coda
              // 
              // 
              SQL = new StringBuilder();
              SQL.Append("update SPEDIZIONI set ");
              SQL.Append("  FLG_STATO = 'S', ");
              SQL.Append("  DAT_ELAB = GETDATE() ");
              SQL.Append("where (ID = " + IDL.CSql(C7.Get("IDSPEDIZIONE"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
              MainFrm.DTTObj.AddQuery ("496C5F58-6744-49D7-B8A9-C70B57546878", "Spedizioni (Notificatore DB): Update", "Metto il messaggio in coda\n", 512, SQL.ToString());
              MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
              MainFrm.DTTObj.EndQuery ("496C5F58-6744-49D7-B8A9-C70B57546878");
              MainFrm.DTTObj.AddParameter ("496C5F58-6744-49D7-B8A9-C70B57546878", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
              SQL = new StringBuilder();
              SQL.Append("update DEV_TOKENS set ");
              SQL.Append("  DAT_ULTIMO_INVIO = GETDATE() ");
              SQL.Append("where (DEV_TOKEN = " + IDL.CSql(C7.Get("RDEVICETOKEN"), IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
              SQL.Append("and   (ID_APPLICAZIONE = " + IDL.CSql(v_VIDAPPPUSSET, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
              MainFrm.DTTObj.AddQuery ("D3EABC9E-0F44-4F12-9D07-F22EA1EB7375", "Device Token (Notificatore DB): Update", "", 512, SQL.ToString());
              MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
              MainFrm.DTTObj.EndQuery ("D3EABC9E-0F44-4F12-9D07-F22EA1EB7375");
              MainFrm.DTTObj.AddParameter ("D3EABC9E-0F44-4F12-9D07-F22EA1EB7375", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
              C7.MoveNext();
            }
            C7.Close();
            MainFrm.DTTObj.EndForEach ("D297482F-E581-4FEE-8269-C35E759D0F5C", "FOR EACH Spedizioni ROW", "Sono nella fascia oraria prevista per il refresh dei dati...", DTT_C7);
            MainFrm.DTTObj.AddSubProc ("55E951D4-CFDB-4E70-A746-6CEC3BE1B590", "pb.Stop", "");
            v_PB.Stop(false);
            // 
            // Il close verifica che tutti i messaggi siano correttamente
            // in coda
            // 
            // 
            // IDL.Sleep((new IDVariant(10)).intValue()*1000); 
          }
          catch (Exception e15)
          {
            MainFrm.DTTObj.AddException("465101E2-65BA-4CF5-B558-27D68B17B45A", "CATCH", "", e15, true);
            IDVariant v_SMESSAGERROR = null;
            MainFrm.DTTObj.AddAssign ("685EF382-9751-4FB5-9E58-DC4E8170D70D", "s Messaggio Errore := Format Message (\"Disattivata dal sistema: |1, payload: |2\", Error Message (), s Payload, ??, ??, ??)", "", v_SMESSAGERROR);
            MainFrm.DTTObj.AddToken ("685EF382-9751-4FB5-9E58-DC4E8170D70D", "52B0AACA-8120-482C-925F-A31FC4E14D43", 1376256, "s Payload", v_SPAYLOAD);
            v_SMESSAGERROR = IDL.FormatMessage((new IDVariant("Disattivata dal sistema: |1, payload: |2")), new IDVariant(e15.Message), v_SPAYLOAD);
            MainFrm.DTTObj.AddAssignNewValue ("685EF382-9751-4FB5-9E58-DC4E8170D70D", "D0AAEFC4-6FE2-4078-805D-D73E9BE73706", v_SMESSAGERROR);
            MainFrm.DTTObj.AddSubProc ("361D49E9-2E64-4854-A690-7F4D4BD9BDB0", "Notificatore.Send Mail", "");
            SendMail(IDL.FormatMessage((new IDVariant("Applicazione |1 disattivata")), IDL.ToString(v_VIDAPPPUSSET)), IDL.Add(IDL.Add(new IDVariant(e15.Message), (new IDVariant("\\"))), v_SPAYLOAD));
            MainFrm.DTTObj.AddSubProc ("3A767254-A318-48B8-96CE-9AB089CBB95A", "Notificatore.Write Debug", "");
            WriteDebug(IDL.FormatMessage((new IDVariant("Trovato errore. Disattivo l'applicazione IDAppspushSetting:|1, |2")), IDL.ToString(v_VIDAPPPUSSET), v_SMESSAGERROR), (new IDVariant(1)), (new IDVariant("Main server session - IOS")));
            SQL = new StringBuilder();
            SQL.Append("update APPS_PUSH_SETTING set ");
            SQL.Append("  FLG_ATTIVA = 'N', ");
            SQL.Append("  DES_ERR = " + IDL.CSql(v_SMESSAGERROR, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + " ");
            SQL.Append("where (ID = " + IDL.CSql(v_VIDAPPPUSSET, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            MainFrm.DTTObj.AddQuery ("56995953-19CF-49E3-ACF6-EFD77090DDCE", "Apps Push Settings (Notificatore DB): Update", "", 512, SQL.ToString());
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            MainFrm.DTTObj.EndQuery ("56995953-19CF-49E3-ACF6-EFD77090DDCE");
            MainFrm.DTTObj.AddParameter ("56995953-19CF-49E3-ACF6-EFD77090DDCE", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
            // if ()
            // {
              // 
              // Il close verifica che tutti i messaggi siano correttamente
              // in coda
              // 
              // IDL.Sleep((new IDVariant(1)).intValue()*1000); 
              // IDL.Sleep((new IDVariant(1)).intValue()*1000); 
            // }
            // throw new Exception(((new IDVariant(550590))).stringValue() + " - " + IDL.Add(new IDVariant(e15.Message), new IDVariant(e15.Message.StackTrace)));
            MainFrm.DTTObj.AddError ("825EBE42-530C-402A-9F6C-80DDF1EAEAA6", "THROW Error Message ()", "");
            throw new Exception(((new IDVariant(550590))).stringValue() + " - " + new IDVariant(e15.Message));
          }
        }
        MainFrm.DTTObj.EndIfBlk ("722AC4FC-2408-498D-A552-061F7564D5B7");
        MainFrm.DTTObj.AddSubProc ("30CC849D-DC76-46C7-A065-F87A1C724D51", "Notificatore.Sleep", "");
        MainFrm.DTTObj.AddParameter ("30CC849D-DC76-46C7-A065-F87A1C724D51", "29970574-35E2-4855-BA71-96412020B725", "Numero Secondi", GLBRITARSPED);
        IDL.Sleep(GLBRITARSPED.intValue()*1000); 
        C2.MoveNext();
      }
      C2.Close();
      MainFrm.DTTObj.EndForEach ("D2D1E08D-1356-45D0-A167-63F255E42967", "FOR EACH Spedizioni ROW", "Sono in una fascia oraria in cui non devo fare il refresh. Azzero la variabile\nCiclo per ogni applicazione che ha messaggi in coda", DTT_C2);
      MainFrm.DTTObj.ExitProc("66652DB6-BC00-4C70-80AE-991D5487CAE6", "Send APNS Push Notification", "", 3, "MainFrm");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("66652DB6-BC00-4C70-80AE-991D5487CAE6", "Send APNS Push Notification", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "SendAPNSPushNotification", _e);
      MainFrm.DTTObj.ExitProc("66652DB6-BC00-4C70-80AE-991D5487CAE6", "Send APNS Push Notification", "", 3, "MainFrm");
      return -1;
    }
  }

  // **********************************************************************
  // Save Device Token
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Token - Input
  // Utente - Input
  // ID Apps Push Settings - Input
  // Reg ID - Input
  // Type OS - Input
  // Custom TAG - Input
  // Codice Lingua - Input
  // **********************************************************************
  public int SaveDeviceToken (IDVariant Token, IDVariant Utente, IDVariant IDAppsPushSettings, IDVariant RegID, IDVariant TypeOS, IDVariant CustomTAG, IDVariant CodiceLingua)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("14E0D576-F9A7-419C-B2D1-579D68B6A1E4", "Save Device Token", "", 3, "MainFrm")) return 0;
      MainFrm.DTTObj.AddParameter ("14E0D576-F9A7-419C-B2D1-579D68B6A1E4", "B8E686EC-9037-4392-9507-CEDD815C41FF", "Token", Token);
      MainFrm.DTTObj.AddParameter ("14E0D576-F9A7-419C-B2D1-579D68B6A1E4", "FD04AD85-E138-4E5C-8255-BB2CDBD2C94A", "Utente", Utente);
      MainFrm.DTTObj.AddParameter ("14E0D576-F9A7-419C-B2D1-579D68B6A1E4", "C6005E5C-456E-4CEC-AFA4-791027965834", "ID Apps Push Settings", IDAppsPushSettings);
      MainFrm.DTTObj.AddParameter ("14E0D576-F9A7-419C-B2D1-579D68B6A1E4", "6DB20EB3-04F0-463B-B66B-4AA4C40D5145", "Reg ID", RegID);
      MainFrm.DTTObj.AddParameter ("14E0D576-F9A7-419C-B2D1-579D68B6A1E4", "06898A7B-C23D-4AE7-A69D-547D7708D3D2", "Type OS", TypeOS);
      MainFrm.DTTObj.AddParameter ("14E0D576-F9A7-419C-B2D1-579D68B6A1E4", "96200CC8-4855-4351-9EE2-995AC77D7C08", "Custom TAG", CustomTAG);
      MainFrm.DTTObj.AddParameter ("14E0D576-F9A7-419C-B2D1-579D68B6A1E4", "D443E94C-7B1C-4646-9F41-50F2F2BF49EF", "Codice Lingua", CodiceLingua);
      // 
      // Save Device Token Body
      // Corpo Procedura
      // 
      IDVariant v_IDLINGUA = null;
      MainFrm.DTTObj.AddAssign ("53582D9F-6993-4484-8FDF-10AF45F15B05", "Id Lingua := null", "", v_IDLINGUA);
      v_IDLINGUA = (new IDVariant());
      MainFrm.DTTObj.AddAssignNewValue ("53582D9F-6993-4484-8FDF-10AF45F15B05", "9B0CA6A2-BE3A-41E0-93DB-6E29C7CFDFA6", v_IDLINGUA);
      // 
      // Se mi passi un null o empty string, vuol dire che sei
      // utente Guest.
      // In questo caso sul db devo mettere null
      // 
      MainFrm.DTTObj.AddIf ("DB981974-277C-41E4-AF3A-61FB739B9726", "IF Is Null (Utente) or Trim (Utente) = \"\"", "Se mi passi un null o empty string, vuol dire che sei utente Guest.\nIn questo caso sul db devo mettere null");
      MainFrm.DTTObj.AddToken ("DB981974-277C-41E4-AF3A-61FB739B9726", "FD04AD85-E138-4E5C-8255-BB2CDBD2C94A", 1376256, "Utente", Utente);
      if (IDL.IsNull(Utente) || IDL.Trim(Utente, true, true).equals((new IDVariant("")), true))
      {
        MainFrm.DTTObj.EnterIf ("DB981974-277C-41E4-AF3A-61FB739B9726", "IF Is Null (Utente) or Trim (Utente) = \"\"", "Se mi passi un null o empty string, vuol dire che sei utente Guest.\nIn questo caso sul db devo mettere null");
        MainFrm.DTTObj.AddAssign ("E58FAA74-81BA-4F50-998A-F9AEEB1B9E4F", "Utente := C\"\"", "", Utente);
        Utente = (new IDVariant());
        MainFrm.DTTObj.AddAssignNewValue ("E58FAA74-81BA-4F50-998A-F9AEEB1B9E4F", "FD04AD85-E138-4E5C-8255-BB2CDBD2C94A", Utente);
      }
      MainFrm.DTTObj.EndIfBlk ("DB981974-277C-41E4-AF3A-61FB739B9726");
      // 
      // Se mi passi un null o empty string, vuol dire che sei
      // utente Guest.
      // In questo caso sul db devo mettere null
      // 
      MainFrm.DTTObj.AddIf ("5137A96F-F72C-4205-BBFB-F9B8A0073DE9", "IF Is Null (Codice Lingua) or Trim (Codice Lingua) = \"\"", "Se mi passi un null o empty string, vuol dire che sei utente Guest.\nIn questo caso sul db devo mettere null");
      MainFrm.DTTObj.AddToken ("5137A96F-F72C-4205-BBFB-F9B8A0073DE9", "D443E94C-7B1C-4646-9F41-50F2F2BF49EF", 1376256, "Codice Lingua", CodiceLingua);
      if (IDL.IsNull(CodiceLingua) || IDL.Trim(CodiceLingua, true, true).equals((new IDVariant("")), true))
      {
        MainFrm.DTTObj.EnterIf ("5137A96F-F72C-4205-BBFB-F9B8A0073DE9", "IF Is Null (Codice Lingua) or Trim (Codice Lingua) = \"\"", "Se mi passi un null o empty string, vuol dire che sei utente Guest.\nIn questo caso sul db devo mettere null");
        MainFrm.DTTObj.AddAssign ("A67530B1-FD95-41FC-941A-CB5B50C827E0", "Id Lingua := null", "", v_IDLINGUA);
        v_IDLINGUA = (new IDVariant());
        MainFrm.DTTObj.AddAssignNewValue ("A67530B1-FD95-41FC-941A-CB5B50C827E0", "9B0CA6A2-BE3A-41E0-93DB-6E29C7CFDFA6", v_IDLINGUA);
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("EEFDB4CD-17F1-4409-9798-740133661664", "ELSE", "", "5137A96F-F72C-4205-BBFB-F9B8A0073DE9");
        MainFrm.DTTObj.AddSubProc ("DDC8D03F-19C6-4093-A79F-128544D4ACE9", "Notificatore DB.Identifica Lingua", "");
        ReturnStatus = MainFrm.NotificatoreDBObject.IdentificaLingua(CodiceLingua, v_IDLINGUA);
        if (ReturnStatus != 0) throw new Exception(MainFrm.NotificatoreDBObject.ErrorMessage());
      }
      MainFrm.DTTObj.EndIfBlk ("5137A96F-F72C-4205-BBFB-F9B8A0073DE9");
      // 
      // Se il regid e' null o empty string, devo mettere null
      // sul db
      // 
      MainFrm.DTTObj.AddIf ("23D657DA-AFA3-49DE-80E4-A372AED18F29", "IF Is Null (Reg ID) or Reg ID = \"\"", "Se il regid e' null o empty string, devo mettere null sul db");
      MainFrm.DTTObj.AddToken ("23D657DA-AFA3-49DE-80E4-A372AED18F29", "6DB20EB3-04F0-463B-B66B-4AA4C40D5145", 1376256, "Reg ID", RegID);
      if (IDL.IsNull(RegID) || RegID.equals((new IDVariant("")), true))
      {
        MainFrm.DTTObj.EnterIf ("23D657DA-AFA3-49DE-80E4-A372AED18F29", "IF Is Null (Reg ID) or Reg ID = \"\"", "Se il regid e' null o empty string, devo mettere null sul db");
        MainFrm.DTTObj.AddAssign ("8360EB88-D10B-4CC2-9653-0F98CE9E6588", "Reg ID := C\"\"", "", RegID);
        RegID = (new IDVariant());
        MainFrm.DTTObj.AddAssignNewValue ("8360EB88-D10B-4CC2-9653-0F98CE9E6588", "6DB20EB3-04F0-463B-B66B-4AA4C40D5145", RegID);
      }
      MainFrm.DTTObj.EndIfBlk ("23D657DA-AFA3-49DE-80E4-A372AED18F29");
      // 
      // Se il custom tag e' null o empty string, sul db devo
      // mettere null
      // 
      MainFrm.DTTObj.AddIf ("E535D050-7BEF-4695-85E0-805935066018", "IF Is Null (Custom TAG) or Custom TAG = \"\"", "Se il custom tag e' null o empty string, sul db devo mettere null");
      MainFrm.DTTObj.AddToken ("E535D050-7BEF-4695-85E0-805935066018", "96200CC8-4855-4351-9EE2-995AC77D7C08", 1376256, "Custom TAG", CustomTAG);
      if (IDL.IsNull(CustomTAG) || CustomTAG.equals((new IDVariant("")), true))
      {
        MainFrm.DTTObj.EnterIf ("E535D050-7BEF-4695-85E0-805935066018", "IF Is Null (Custom TAG) or Custom TAG = \"\"", "Se il custom tag e' null o empty string, sul db devo mettere null");
        MainFrm.DTTObj.AddAssign ("613A56EC-7050-4801-B3EC-947E913B3E30", "Custom TAG := C\"\"", "", CustomTAG);
        CustomTAG = (new IDVariant());
        MainFrm.DTTObj.AddAssignNewValue ("613A56EC-7050-4801-B3EC-947E913B3E30", "96200CC8-4855-4351-9EE2-995AC77D7C08", CustomTAG);
      }
      MainFrm.DTTObj.EndIfBlk ("E535D050-7BEF-4695-85E0-805935066018");
      // 
      // Tolgo evntuali spazi dal token
      // 
      IDVariant v_STOKEN = null;
      MainFrm.DTTObj.AddAssign ("E09B0A96-5D9A-4B79-AD2A-73E532C3DD70", "s Token := Trim (Replace (Token, \" \", \"\"))", "Tolgo evntuali spazi dal token", v_STOKEN);
      MainFrm.DTTObj.AddToken ("E09B0A96-5D9A-4B79-AD2A-73E532C3DD70", "B8E686EC-9037-4392-9507-CEDD815C41FF", 1376256, "Token", Token);
      v_STOKEN = IDL.Trim(IDL.Replace(Token, (new IDVariant(" ")), (new IDVariant(""))), true, true);
      MainFrm.DTTObj.AddAssignNewValue ("E09B0A96-5D9A-4B79-AD2A-73E532C3DD70", "80F206F9-C4EC-4E57-A52A-3239223EA5D7", v_STOKEN);
      IDVariant v_VIDDEVICTOKE = new IDVariant(0,IDVariant.INTEGER);
      IDVariant v_TROVATOTOKEN = new IDVariant(0,IDVariant.INTEGER);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.ID as IDDEVICTOKEN ");
      SQL.Append("from ");
      SQL.Append("  DEV_TOKENS A ");
      SQL.Append("where (A.DEV_TOKEN = " + IDL.CSql(v_STOKEN, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      SQL.Append("and   (A.ID_APPLICAZIONE = " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      SQL.Append("and   (A.FLG_ATTIVO = 'S') ");
      MainFrm.DTTObj.AddQuery ("7EE070D5-4C90-4D3E-9FB3-0423C07CC5C6", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("7EE070D5-4C90-4D3E-9FB3-0423C07CC5C6");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      v_TROVATOTOKEN = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
      if (!QV.EOF())
      {
        v_VIDDEVICTOKE = QV.Get("IDDEVICTOKEN", IDVariant.INTEGER) ;
        MainFrm.DTTObj.AddToken ("7EE070D5-4C90-4D3E-9FB3-0423C07CC5C6", "27983098-4FB5-4E30-985F-D79626E05057", 1376256, "v ID Device Token", v_VIDDEVICTOKE);
      }
      QV.Close();
      MainFrm.DTTObj.AddIf ("095E563D-6FDF-481E-BA0C-AC805BB62120", "IF C! (TrovatoToken)", "");
      MainFrm.DTTObj.AddToken ("095E563D-6FDF-481E-BA0C-AC805BB62120", "308304E8-5D5F-4996-ABB7-4855A08B96BE", 1376256, "TrovatoToken", v_TROVATOTOKEN.booleanValue());
      if (!(v_TROVATOTOKEN.booleanValue()))
      {
        MainFrm.DTTObj.EnterIf ("095E563D-6FDF-481E-BA0C-AC805BB62120", "IF C! (TrovatoToken)", "");
        IDVariant v_DDATACUPERTI = new IDVariant(0,IDVariant.DATETIME);
        MainFrm.DTTObj.AddAssign ("47EACC88-EFD5-4586-B1BA-1083A473190F", "d Data Cupertino := Date Add (Day, 9, Now ())", "", v_DDATACUPERTI);
        MainFrm.DTTObj.AddToken ("47EACC88-EFD5-4586-B1BA-1083A473190F", "132B6115-2447-11D5-911F-1A0113000000", 589824, "Day", (new IDVariant("d")));
        v_DDATACUPERTI = IDL.DateAdd((new IDVariant("d")),(new IDVariant(9)),IDL.Now());
        MainFrm.DTTObj.AddAssignNewValue ("47EACC88-EFD5-4586-B1BA-1083A473190F", "B73DF876-BCAE-4FA7-A782-BE8E4D768854", v_DDATACUPERTI);
        MainFrm.DTTObj.AddSwitch ("650840A7-CFCF-4346-9CB9-785DD3746024", "SWITCH (Type OS)", "");
        MainFrm.DTTObj.AddToken ("650840A7-CFCF-4346-9CB9-785DD3746024", "06898A7B-C23D-4AE7-A69D-547D7708D3D2", 1376256, "Type OS", TypeOS);
        switch (1) // Allows the use of BREAK inside ifs
        {
          default:
          if (TypeOS.equals((new IDVariant("1"))))	
          {
            MainFrm.DTTObj.EnterSwitch ("D26A9779-AD53-4BDD-B7A4-2A20AE67A9D6", "CASE iOS:", "");
            MainFrm.DTTObj.AddToken ("D26A9779-AD53-4BDD-B7A4-2A20AE67A9D6", "8E64E9E9-98C7-4AE7-9BA4-B6034CE63C9C", 589824, "iOS", (new IDVariant("1")));
            MainFrm.DTTObj.AddIf ("23BCB8BE-3763-4A02-BD98-2EB93E334D6D", "IF Length (s Token) != 64", "");
            MainFrm.DTTObj.AddToken ("23BCB8BE-3763-4A02-BD98-2EB93E334D6D", "80F206F9-C4EC-4E57-A52A-3239223EA5D7", 1376256, "s Token", v_STOKEN);
            if (IDL.Length(v_STOKEN).compareTo((new IDVariant(64)), true)!=0)
            {
              MainFrm.DTTObj.EnterIf ("23BCB8BE-3763-4A02-BD98-2EB93E334D6D", "IF Length (s Token) != 64", "");
              MainFrm.DTTObj.AddSubProc ("0A34FCB2-D325-48D5-866E-DDEE029D96E8", "Notificatore.Write Debug", "");
              WriteDebug((new IDVariant("ERRORE: Il token arrivato dal dispositivo non è 64 bytes")), (new IDVariant(1)), (new IDVariant("WS: Save Token")));
            }
            else if (0==0)
            {
              MainFrm.DTTObj.EnterElse ("E2F6F4A4-8B86-4A71-A52D-2944BB20E04E", "ELSE", "", "23BCB8BE-3763-4A02-BD98-2EB93E334D6D");
              // 
              // Inserisco un nuovo device token
              // 
              SQL = new StringBuilder();
              SQL.Append("insert into DEV_TOKENS ");
              SQL.Append("( ");
              SQL.Append("  DEV_TOKEN, ");
              SQL.Append("  ID_APPLICAZIONE, ");
              SQL.Append("  DES_UTENTE, ");
              SQL.Append("  REG_ID, ");
              SQL.Append("  CUSTOM_TAG, ");
              SQL.Append("  TYPE_OS, ");
              SQL.Append("  PRG_LINGUA, ");
              SQL.Append("  DATA_CUPERTINO ");
              SQL.Append(") ");
              SQL.Append("values ");
              SQL.Append("( ");
              SQL.Append("  " + IDL.CSql(v_STOKEN, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  " + IDL.CSql(Utente, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  " + IDL.CSql(RegID, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  " + IDL.CSql(CustomTAG, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  CASE WHEN " + IDL.CSql(TypeOS, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + "='' OR (" + IDL.CSql(TypeOS, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + " IS NULL AND '' IS NULL) THEN '1' ELSE " + IDL.CSql(TypeOS, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + " END, ");
              SQL.Append("  " + IDL.CSql(v_IDLINGUA, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  " + IDL.CSql(v_DDATACUPERTI, IDL.FMT_DAT2, MainFrm.NotificatoreDBObject.DBO()) + " ");
              SQL.Append(") ");
              MainFrm.DTTObj.AddQuery ("8EB46A9B-F814-4D59-B58C-1D93ABC09C9E", "Device Token (Notificatore DB): Insert into", "Inserisco un nuovo device token", 768, SQL.ToString());
              MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
              MainFrm.DTTObj.EndQuery ("8EB46A9B-F814-4D59-B58C-1D93ABC09C9E");
            }
            MainFrm.DTTObj.EndIfBlk ("23BCB8BE-3763-4A02-BD98-2EB93E334D6D");
          }
          else if (TypeOS.equals((new IDVariant("2"))))	
          {
            MainFrm.DTTObj.EnterSwitch ("6AFF32EB-D356-449C-ACE4-072133BE2E7E", "CASE Android:", "");
            MainFrm.DTTObj.AddToken ("6AFF32EB-D356-449C-ACE4-072133BE2E7E", "E9D1BD92-BCC3-4AA1-8A5C-CA0C6347ECDD", 589824, "Android", (new IDVariant("2")));
            // 
            // Inserisco un nuovo device token
            // 
            SQL = new StringBuilder();
            SQL.Append("insert into DEV_TOKENS ");
            SQL.Append("( ");
            SQL.Append("  DEV_TOKEN, ");
            SQL.Append("  ID_APPLICAZIONE, ");
            SQL.Append("  DES_UTENTE, ");
            SQL.Append("  REG_ID, ");
            SQL.Append("  CUSTOM_TAG, ");
            SQL.Append("  TYPE_OS, ");
            SQL.Append("  PRG_LINGUA, ");
            SQL.Append("  DATA_CUPERTINO ");
            SQL.Append(") ");
            SQL.Append("values ");
            SQL.Append("( ");
            SQL.Append("  " + IDL.CSql(v_STOKEN, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(Utente, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(RegID, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(CustomTAG, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  CASE WHEN " + IDL.CSql(TypeOS, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + "='' OR (" + IDL.CSql(TypeOS, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + " IS NULL AND '' IS NULL) THEN '1' ELSE " + IDL.CSql(TypeOS, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + " END, ");
            SQL.Append("  " + IDL.CSql(v_IDLINGUA, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(v_DDATACUPERTI, IDL.FMT_DAT2, MainFrm.NotificatoreDBObject.DBO()) + " ");
            SQL.Append(") ");
            MainFrm.DTTObj.AddQuery ("601E9E76-E5D8-4648-8EA4-9F182D549FD9", "Device Token (Notificatore DB): Insert into", "Inserisco un nuovo device token", 768, SQL.ToString());
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            MainFrm.DTTObj.EndQuery ("601E9E76-E5D8-4648-8EA4-9F182D549FD9");
          }
          else if (TypeOS.equals((new IDVariant("5"))))	
          {
            MainFrm.DTTObj.EnterSwitch ("CE3218CA-FAD1-4995-9A62-87636F6BBB80", "CASE Windows Store:", "");
            MainFrm.DTTObj.AddToken ("CE3218CA-FAD1-4995-9A62-87636F6BBB80", "A7370DFC-A1F6-441C-A770-C4B9D3C303F6", 589824, "Windows Store", (new IDVariant("5")));
            // 
            // Inserisco un nuovo device token
            // 
            SQL = new StringBuilder();
            SQL.Append("insert into DEV_TOKENS ");
            SQL.Append("( ");
            SQL.Append("  DEV_TOKEN, ");
            SQL.Append("  ID_APPLICAZIONE, ");
            SQL.Append("  DES_UTENTE, ");
            SQL.Append("  REG_ID, ");
            SQL.Append("  CUSTOM_TAG, ");
            SQL.Append("  TYPE_OS, ");
            SQL.Append("  PRG_LINGUA, ");
            SQL.Append("  DATA_CUPERTINO ");
            SQL.Append(") ");
            SQL.Append("values ");
            SQL.Append("( ");
            SQL.Append("  " + IDL.CSql(v_STOKEN, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(Utente, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(RegID, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(CustomTAG, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  '5', ");
            SQL.Append("  " + IDL.CSql(v_IDLINGUA, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(v_DDATACUPERTI, IDL.FMT_DAT2, MainFrm.NotificatoreDBObject.DBO()) + " ");
            SQL.Append(") ");
            MainFrm.DTTObj.AddQuery ("E40B2682-BE26-4DC4-A139-842FD4737FF2", "Device Token (Notificatore DB): Insert into", "Inserisco un nuovo device token", 768, SQL.ToString());
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            MainFrm.DTTObj.EndQuery ("E40B2682-BE26-4DC4-A139-842FD4737FF2");
          }
          else if (TypeOS.equals((new IDVariant("3"))))	
          {
            MainFrm.DTTObj.EnterSwitch ("4FB877CC-6849-4285-A4CB-29FCCCFE4F48", "CASE Windows Phone:", "");
            MainFrm.DTTObj.AddToken ("4FB877CC-6849-4285-A4CB-29FCCCFE4F48", "057F8A8B-F4F8-44F1-BC23-172B53A54683", 589824, "Windows Phone", (new IDVariant("3")));
            // 
            // Inserisco un nuovo device token
            // 
            SQL = new StringBuilder();
            SQL.Append("insert into DEV_TOKENS ");
            SQL.Append("( ");
            SQL.Append("  DEV_TOKEN, ");
            SQL.Append("  ID_APPLICAZIONE, ");
            SQL.Append("  DES_UTENTE, ");
            SQL.Append("  REG_ID, ");
            SQL.Append("  CUSTOM_TAG, ");
            SQL.Append("  TYPE_OS, ");
            SQL.Append("  PRG_LINGUA, ");
            SQL.Append("  DATA_CUPERTINO ");
            SQL.Append(") ");
            SQL.Append("values ");
            SQL.Append("( ");
            SQL.Append("  " + IDL.CSql(v_STOKEN, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(Utente, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(RegID, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(CustomTAG, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  '3', ");
            SQL.Append("  " + IDL.CSql(v_IDLINGUA, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(v_DDATACUPERTI, IDL.FMT_DAT2, MainFrm.NotificatoreDBObject.DBO()) + " ");
            SQL.Append(") ");
            MainFrm.DTTObj.AddQuery ("9969269C-A202-4543-8570-4D2AC277AD12", "Device Token (Notificatore DB): Insert into", "Inserisco un nuovo device token", 768, SQL.ToString());
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            MainFrm.DTTObj.EndQuery ("9969269C-A202-4543-8570-4D2AC277AD12");
          }
          break;
        }
        MainFrm.DTTObj.EndSwitchBlk ("650840A7-CFCF-4346-9CB9-785DD3746024");
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("8A05B482-1399-4597-93FF-F5C1CF9423FC", "ELSE", "", "095E563D-6FDF-481E-BA0C-AC805BB62120");
        // 
        // Aggiorna il device token
        // 
        SQL = new StringBuilder();
        SQL.Append("update DEV_TOKENS set ");
        SQL.Append("  DATA_ULT_ACCESSO = GETDATE(), ");
        SQL.Append("  DES_UTENTE = " + IDL.CSql(Utente, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  REG_ID = " + IDL.CSql(RegID, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  CUSTOM_TAG = " + IDL.CSql(CustomTAG, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  FLG_RIMOSSO = 'N', ");
        SQL.Append("  PRG_LINGUA = " + IDL.CSql(v_IDLINGUA, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " ");
        SQL.Append("where (ID = " + IDL.CSql(v_VIDDEVICTOKE, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        SQL.Append("and   (ID_APPLICAZIONE = " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        MainFrm.DTTObj.AddQuery ("D84D9907-A976-430F-9E1F-65436974B588", "Device Token (Notificatore DB): Update", "Aggiorna il device token", 512, SQL.ToString());
        MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
        MainFrm.DTTObj.EndQuery ("D84D9907-A976-430F-9E1F-65436974B588");
        MainFrm.DTTObj.AddParameter ("D84D9907-A976-430F-9E1F-65436974B588", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
      }
      MainFrm.DTTObj.EndIfBlk ("095E563D-6FDF-481E-BA0C-AC805BB62120");
      MainFrm.DTTObj.ExitProc("14E0D576-F9A7-419C-B2D1-579D68B6A1E4", "Save Device Token", "", 3, "MainFrm");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("14E0D576-F9A7-419C-B2D1-579D68B6A1E4", "Save Device Token", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "SaveDeviceToken", _e);
      MainFrm.DTTObj.ExitProc("14E0D576-F9A7-419C-B2D1-579D68B6A1E4", "Save Device Token", "", 3, "MainFrm");
      return -1;
    }
  }

  // **********************************************************************
  // Send Mail
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Oggetto:  - Input
  // Testo:  - Input
  // **********************************************************************
  public int SendMail (IDVariant Oggetto, IDVariant Testo)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("1739E296-7689-41B7-A17E-6ABE0873C6FF", "Send Mail", "", 3, "MainFrm")) return 0;
      MainFrm.DTTObj.AddParameter ("1739E296-7689-41B7-A17E-6ABE0873C6FF", "D3D9AE08-CCDB-45CB-A958-524839F22150", "Oggetto", Oggetto);
      MainFrm.DTTObj.AddParameter ("1739E296-7689-41B7-A17E-6ABE0873C6FF", "7DA28D92-E9F8-40F9-9047-45BC059F748F", "Testo", Testo);
      // 
      // Send Mail Body
      // Corpo Procedura
      // 
      IDVariant v_VMITTENTE = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VINDIRIZZO = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VRELAY = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VUTENTE = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VPASSWORD = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VPORTA = new IDVariant(0,IDVariant.INTEGER);
      IDVariant v_VDESTINATARI = new IDVariant(0,IDVariant.STRING);
      IDVariant v_VATTIVASSL = new IDVariant(0,IDVariant.STRING);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.DES_MITTENTE as MITTENIMPOST, ");
      SQL.Append("  A.DES_INDIRIZZO as INDIRIIMPOST, ");
      SQL.Append("  A.DES_SERVER_OUT as POSTINUSCIMP, ");
      SQL.Append("  A.DES_LOGIN as UTENTEIMPOST, ");
      SQL.Append("  A.DES_PASSWORD as PASSWOIMPOST, ");
      SQL.Append("  A.CDN_PORTA_OUT as PORPOSUSCIMP, ");
      SQL.Append("  A.FLG_SSL as ATTIVSSLIMPO, ");
      SQL.Append("  A.DES_INDIRIZZO_SUPP as EMAISUPPIMPO ");
      SQL.Append("from ");
      SQL.Append("  IMPOSTAZIONI A ");
      MainFrm.DTTObj.AddQuery ("08536D58-C5BD-47B9-ACE5-CB289854C0CA", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("08536D58-C5BD-47B9-ACE5-CB289854C0CA");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        v_VMITTENTE = QV.Get("MITTENIMPOST", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("08536D58-C5BD-47B9-ACE5-CB289854C0CA", "5CF42ABC-AFC7-4394-9895-E85C3069D40C", 1376256, "vMittente", v_VMITTENTE);
        v_VINDIRIZZO = QV.Get("INDIRIIMPOST", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("08536D58-C5BD-47B9-ACE5-CB289854C0CA", "B674BD68-B91D-4472-8AD4-421178ABC503", 1376256, "vIndirizzo", v_VINDIRIZZO);
        v_VRELAY = QV.Get("POSTINUSCIMP", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("08536D58-C5BD-47B9-ACE5-CB289854C0CA", "74EE42B3-A626-4104-A571-13FDF6E9EC77", 1376256, "vRelay", v_VRELAY);
        v_VUTENTE = QV.Get("UTENTEIMPOST", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("08536D58-C5BD-47B9-ACE5-CB289854C0CA", "61992C40-B19D-466A-B71D-B246CD0980F4", 1376256, "vUtente", v_VUTENTE);
        v_VPASSWORD = QV.Get("PASSWOIMPOST", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("08536D58-C5BD-47B9-ACE5-CB289854C0CA", "258CE89A-D864-4BD9-8B24-C999A0AC9EC7", 1376256, "vPassword", v_VPASSWORD);
        v_VPORTA = QV.Get("PORPOSUSCIMP", IDVariant.INTEGER) ;
        MainFrm.DTTObj.AddToken ("08536D58-C5BD-47B9-ACE5-CB289854C0CA", "B9E40D9E-18C7-4E3B-A4CA-3012C3264B37", 1376256, "vPorta", v_VPORTA);
        v_VATTIVASSL = QV.Get("ATTIVSSLIMPO", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("08536D58-C5BD-47B9-ACE5-CB289854C0CA", "BF728C56-0482-4F83-8FD9-AE1CAF61AEB0", 1376256, "vAttivaSSL", v_VATTIVASSL);
        v_VDESTINATARI = QV.Get("EMAISUPPIMPO", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("08536D58-C5BD-47B9-ACE5-CB289854C0CA", "F97CDB3D-5529-43BE-B6B7-8EE6F278E6DB", 1376256, "vDestinatario", v_VDESTINATARI);
      }
      QV.Close();
      ApexIDMailer M = null;
      MainFrm.DTTObj.AddAssign ("66C47E51-75D7-4016-8770-C25AC1666FDC", "m := new ()", "", M);
      M = (ApexIDMailer)new ApexIDMailer();
      MainFrm.DTTObj.AddAssignNewValue ("66C47E51-75D7-4016-8770-C25AC1666FDC", "1355B5AF-7135-42EB-B53E-51BF7BABDF31", M);
      MainFrm.DTTObj.AddAssign ("C55C1562-785E-45C8-84D3-1E08EC559FAB", "m.From Name := vMittente", "", M.FromName);
      MainFrm.DTTObj.AddToken ("C55C1562-785E-45C8-84D3-1E08EC559FAB", "5CF42ABC-AFC7-4394-9895-E85C3069D40C", 1376256, "vMittente", new IDVariant(v_VMITTENTE));
      M.FromName = new IDVariant(v_VMITTENTE).stringValue();
      MainFrm.DTTObj.AddAssignNewValue ("C55C1562-785E-45C8-84D3-1E08EC559FAB", "1355B5AF-7135-42EB-B53E-51BF7BABDF31", M.FromName);
      MainFrm.DTTObj.AddAssign ("D2A8AD28-2A23-4B80-9317-921D221FF603", "m.From Address := vIndirizzo", "", M.FromAddress);
      MainFrm.DTTObj.AddToken ("D2A8AD28-2A23-4B80-9317-921D221FF603", "B674BD68-B91D-4472-8AD4-421178ABC503", 1376256, "vIndirizzo", new IDVariant(v_VINDIRIZZO));
      M.FromAddress = new IDVariant(v_VINDIRIZZO).stringValue();
      MainFrm.DTTObj.AddAssignNewValue ("D2A8AD28-2A23-4B80-9317-921D221FF603", "1355B5AF-7135-42EB-B53E-51BF7BABDF31", M.FromAddress);
      // 
      // Spezzo la stringa
      // 
      com.progamma.StringTokenizer v_ST = null;
      MainFrm.DTTObj.AddAssign ("46957DBE-1B0C-474D-95F8-F626207E7CE4", "st := new ()", "Spezzo la stringa", v_ST);
      v_ST = (com.progamma.StringTokenizer)new com.progamma.StringTokenizer();
      MainFrm.DTTObj.AddAssignNewValue ("46957DBE-1B0C-474D-95F8-F626207E7CE4", "9D09AAC8-B533-4F46-97EB-CDC2C1973D79", v_ST);
      MainFrm.DTTObj.AddSubProc ("FBC772D4-6EE9-4057-B073-AA3AA02F2570", "st.Set String", "");
      MainFrm.DTTObj.AddParameter ("FBC772D4-6EE9-4057-B073-AA3AA02F2570", "125CB83A-08A1-4BA5-B35E-ECCFE33ECB50", "Stringa Da Suddividere", GLBINDPOSREP);
      MainFrm.DTTObj.AddParameter ("FBC772D4-6EE9-4057-B073-AA3AA02F2570", "81EEA48F-AE0D-4706-AFC9-6E2DA4374DE4", "Delimitatore", (new IDVariant(",")));
      v_ST.setString(GLBINDPOSREP,(new IDVariant(","))); 
      MainFrm.DTTObj.AddSubProc ("F126E956-5B29-4B88-BBF0-64A00800136D", "m.Add TO: address", "");
      MainFrm.DTTObj.AddParameter ("F126E956-5B29-4B88-BBF0-64A00800136D", "A5A46C42-833E-4B1C-9B3B-31AA8970F14D", "Address", v_VDESTINATARI);
      M.AddToAddress(v_VDESTINATARI.stringValue()); 
      MainFrm.DTTObj.AddAssign ("716C9C2C-06D5-4578-B0DA-CC5FF589D574", "m.Subject := C\"Notificatore: \" + Oggetto", "", M.Subject);
      MainFrm.DTTObj.AddToken ("716C9C2C-06D5-4578-B0DA-CC5FF589D574", "D3D9AE08-CCDB-45CB-A958-524839F22150", 1376256, "Oggetto", Oggetto);
      M.Subject = IDL.Add((new IDVariant("Notificatore: ")), Oggetto).stringValue();
      MainFrm.DTTObj.AddAssignNewValue ("716C9C2C-06D5-4578-B0DA-CC5FF589D574", "1355B5AF-7135-42EB-B53E-51BF7BABDF31", M.Subject);
      MainFrm.DTTObj.AddAssign ("575F3A6B-5F3C-466C-A05B-537C38732BEE", "m.Body := Testo", "", M.Body);
      MainFrm.DTTObj.AddToken ("575F3A6B-5F3C-466C-A05B-537C38732BEE", "7DA28D92-E9F8-40F9-9047-45BC059F748F", 1376256, "Testo", new IDVariant(Testo));
      M.Body = new IDVariant(Testo).stringValue();
      MainFrm.DTTObj.AddAssignNewValue ("575F3A6B-5F3C-466C-A05B-537C38732BEE", "1355B5AF-7135-42EB-B53E-51BF7BABDF31", M.Body);
      MainFrm.DTTObj.AddSubProc ("359C2DC7-8EF9-41E5-8042-F11440FD601F", "m.Add RELAY Server", "");
      MainFrm.DTTObj.AddParameter ("359C2DC7-8EF9-41E5-8042-F11440FD601F", "74B4A761-6379-4960-B461-6FE67C7F246C", "Server Name", v_VRELAY);
      MainFrm.DTTObj.AddParameter ("359C2DC7-8EF9-41E5-8042-F11440FD601F", "AE1293FC-B0D7-4F88-BEE1-B5B723E41F73", "Port", v_VPORTA);
      MainFrm.DTTObj.AddParameter ("359C2DC7-8EF9-41E5-8042-F11440FD601F", "333E81C1-7A15-4A6D-96CB-4D7B8F51C3E5", "Local Host", (new IDVariant("")));
      MainFrm.DTTObj.AddParameter ("359C2DC7-8EF9-41E5-8042-F11440FD601F", "A6D1F508-563B-494F-8EFE-C3B1B8BC6362", "User Name", v_VUTENTE);
      MainFrm.DTTObj.AddParameter ("359C2DC7-8EF9-41E5-8042-F11440FD601F", "6544E18C-1575-4404-B28B-EA42C8CC3154", "Password", v_VPASSWORD);
      M.SetRelayServer(v_VRELAY.stringValue(), v_VPORTA.intValue(), v_VUTENTE.stringValue(), v_VPASSWORD.stringValue()); 
      MainFrm.DTTObj.AddIf ("825484BA-C772-4030-B995-E3FFB660D384", "IF vAttivaSSL = Si", "");
      MainFrm.DTTObj.AddToken ("825484BA-C772-4030-B995-E3FFB660D384", "BF728C56-0482-4F83-8FD9-AE1CAF61AEB0", 1376256, "vAttivaSSL", v_VATTIVASSL);
      MainFrm.DTTObj.AddToken ("825484BA-C772-4030-B995-E3FFB660D384", "B22AFA52-3B31-4800-811A-5AD64C2ACCAA", 589824, "Si", (new IDVariant("S")));
      if (v_VATTIVASSL.equals((new IDVariant("S")), true))
      {
        MainFrm.DTTObj.EnterIf ("825484BA-C772-4030-B995-E3FFB660D384", "IF vAttivaSSL = Si", "");
        MainFrm.DTTObj.AddSubProc ("26A83544-4976-4798-9E04-CE6112F623BC", "m.Enable SSL", "");
        MainFrm.DTTObj.AddParameter ("26A83544-4976-4798-9E04-CE6112F623BC", "F68C341E-55FB-444A-8551-C4CE4120DA4F", "Enabled", (new IDVariant(-1)).booleanValue());
        M.EnableSSL = (new IDVariant(-1)).booleanValue(); 
      }
      MainFrm.DTTObj.EndIfBlk ("825484BA-C772-4030-B995-E3FFB660D384");
      MainFrm.DTTObj.AddSubProc ("6625CE28-46BF-41F6-A79E-13C8C3CF159E", "m.Send Mail", "");
      M.SendMail();
      MainFrm.DTTObj.ExitProc("1739E296-7689-41B7-A17E-6ABE0873C6FF", "Send Mail", "", 3, "MainFrm");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("1739E296-7689-41B7-A17E-6ABE0873C6FF", "Send Mail", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "SendMail", _e);
      MainFrm.DTTObj.ExitProc("1739E296-7689-41B7-A17E-6ABE0873C6FF", "Send Mail", "", 3, "MainFrm");
      return -1;
    }
  }

  // **********************************************************************
  // Parse URL
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Command - Input
  // **********************************************************************
  public int ParseURL (IDVariant Command)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("5517F4A9-2E35-4F48-80C7-BED2CFB0C9C9", "Parse URL", "", 3, "MainFrm")) return 0;
      MainFrm.DTTObj.AddParameter ("5517F4A9-2E35-4F48-80C7-BED2CFB0C9C9", "C2E9C885-7396-4AA0-BCE9-0C4F93EAA7E6", "Command", Command);
      // 
      // Parse URL Body
      // Corpo Procedura
      // 
      IDVariant v_JSONOK = null;
      MainFrm.DTTObj.AddAssign ("97B7E173-647F-4D84-8450-E3E0EF870C09", "Json OK := C\"[{\"result\":\"OK\"}]\"", "", v_JSONOK);
      v_JSONOK = (new IDVariant("[{\"result\":\"OK\"}]"));
      MainFrm.DTTObj.AddAssignNewValue ("97B7E173-647F-4D84-8450-E3E0EF870C09", "EF31C578-1651-47C6-AA8D-187DB19A0879", v_JSONOK);
      IDVariant v_JSONKO = null;
      MainFrm.DTTObj.AddAssign ("97A63EFD-57BF-4F31-B6B8-2A605CD2AD3D", "Json KO := C\"[{\"result\":\"KO\"}]\"", "", v_JSONKO);
      v_JSONKO = (new IDVariant("[{\"result\":\"KO\"}]"));
      MainFrm.DTTObj.AddAssignNewValue ("97A63EFD-57BF-4F31-B6B8-2A605CD2AD3D", "10C1C58B-A474-4143-88BD-95B7CE46637B", v_JSONKO);
      IDVariant v_OK = null;
      MainFrm.DTTObj.AddAssign ("587C33E6-A10C-4688-B299-64340A6B1EAC", "OK := false", "", v_OK);
      MainFrm.DTTObj.AddToken ("587C33E6-A10C-4688-B299-64340A6B1EAC", "78B75DA4-DBDF-11D4-900E-726096000000", 589824, "false", (new IDVariant(0)));
      v_OK = (new IDVariant(0));
      MainFrm.DTTObj.AddAssignNewValue ("587C33E6-A10C-4688-B299-64340A6B1EAC", "CC9A938B-431C-4777-AA10-D7409FA32B18", v_OK);
      MainFrm.DTTObj.Add(Command.stringValue(), (new IDVariant(999)).intValue(), (new IDVariant(2)).intValue()); 
      MainFrm.DTTObj.AddSwitch ("5AA5B11D-5299-496B-8F1C-3A0E20C95D13", "SWITCH (Command)", "");
      MainFrm.DTTObj.AddToken ("5AA5B11D-5299-496B-8F1C-3A0E20C95D13", "C2E9C885-7396-4AA0-BCE9-0C4F93EAA7E6", 1376256, "Command", Command);
      switch (1) // Allows the use of BREAK inside ifs
      {
        default:
        if (Command.equals((new IDVariant("initapp"))))	
        {
          MainFrm.DTTObj.EnterSwitch ("6CF102CE-86D6-49D7-B376-C0A5FE465AA7", "CASE C\"initapp\":", "");
          IDVariant v_VKEY = null;
          MainFrm.DTTObj.AddAssign ("5BF78B58-426D-4E30-9F14-0233287B7AFE", "v Key := Get URL Param (\"appkey\")", "", v_VKEY);
          v_VKEY = MainFrm.GetUrlParam((new IDVariant("appkey")));
          MainFrm.DTTObj.AddAssignNewValue ("5BF78B58-426D-4E30-9F14-0233287B7AFE", "443BA776-42C2-4E54-813A-8F9BD136594F", v_VKEY);
          IDVariant v_VDEVTOKEN = null;
          MainFrm.DTTObj.AddAssign ("53CE73AB-BE66-49C0-B62E-102249ED6A1E", "v Dev Token := Get URL Param (\"devtoken\")", "", v_VDEVTOKEN);
          v_VDEVTOKEN = MainFrm.GetUrlParam((new IDVariant("devtoken")));
          MainFrm.DTTObj.AddAssignNewValue ("53CE73AB-BE66-49C0-B62E-102249ED6A1E", "89B49CF9-34F9-4B92-BF20-ECD7EF8633DF", v_VDEVTOKEN);
          IDVariant v_VUSER = null;
          MainFrm.DTTObj.AddAssign ("BB545048-5EEC-46B5-9792-F3CC9E87C39B", "v User := Get URL Param (\"user\")", "", v_VUSER);
          v_VUSER = MainFrm.GetUrlParam((new IDVariant("user")));
          MainFrm.DTTObj.AddAssignNewValue ("BB545048-5EEC-46B5-9792-F3CC9E87C39B", "E38CB02A-E23B-410C-80F2-7EFE4EA4AE88", v_VUSER);
          IDVariant v_VREGID = null;
          MainFrm.DTTObj.AddAssign ("B6BB12AB-4827-4521-A590-CB2D6D34715B", "v Reg ID := Get URL Param (\"regid\")", "", v_VREGID);
          v_VREGID = MainFrm.GetUrlParam((new IDVariant("regid")));
          MainFrm.DTTObj.AddAssignNewValue ("B6BB12AB-4827-4521-A590-CB2D6D34715B", "40B07C7B-EDDE-44BA-BBFA-87AE18D1BD59", v_VREGID);
          IDVariant v_VOS = null;
          MainFrm.DTTObj.AddAssign ("E004EB0C-AEB9-4BE8-9448-6A0CC6EE57FA", "v OS := Get URL Param (\"os\")", "", v_VOS);
          v_VOS = MainFrm.GetUrlParam((new IDVariant("os")));
          MainFrm.DTTObj.AddAssignNewValue ("E004EB0C-AEB9-4BE8-9448-6A0CC6EE57FA", "AB2214DF-B143-48E7-8E2C-3DCC2B4A48E0", v_VOS);
          IDVariant v_VCUSTOM = null;
          MainFrm.DTTObj.AddAssign ("B14706DE-2894-4D73-B048-45103EB288C9", "v Custom := Get URL Param (\"custom\")", "", v_VCUSTOM);
          v_VCUSTOM = MainFrm.GetUrlParam((new IDVariant("custom")));
          MainFrm.DTTObj.AddAssignNewValue ("B14706DE-2894-4D73-B048-45103EB288C9", "6AC80181-2D71-4E2E-965C-EB8296789B32", v_VCUSTOM);
          IDVariant v_VLANGUAGE = null;
          MainFrm.DTTObj.AddAssign ("982195B7-B043-41B9-A3CF-00DB4A78946B", "v Language := Notificatore.Get URL Param (\"lang\")", "", v_VLANGUAGE);
          MainFrm.DTTObj.AddToken ("982195B7-B043-41B9-A3CF-00DB4A78946B", "5D17ACB6-0F41-4CB8-BE2D-0F961D66BA84", 2097152, "Notificatore.Get URL Param (\"lang\")", MainFrm.GetUrlParam((new IDVariant("lang"))));
          v_VLANGUAGE = MainFrm.GetUrlParam((new IDVariant("lang")));
          MainFrm.DTTObj.AddAssignNewValue ("982195B7-B043-41B9-A3CF-00DB4A78946B", "756AE3EE-F216-41B7-B111-322856D831CF", v_VLANGUAGE);
          MainFrm.DTTObj.AddIf ("36D645D1-C802-476B-ABF5-D061B28FE991", "IF v OS = \"\"", "");
          MainFrm.DTTObj.AddToken ("36D645D1-C802-476B-ABF5-D061B28FE991", "AB2214DF-B143-48E7-8E2C-3DCC2B4A48E0", 1376256, "v OS", v_VOS);
          if (v_VOS.equals((new IDVariant("")), true))
          {
            MainFrm.DTTObj.EnterIf ("36D645D1-C802-476B-ABF5-D061B28FE991", "IF v OS = \"\"", "");
            MainFrm.DTTObj.AddAssign ("05F762A8-F6B8-482F-89EB-41FBB1B13EDE", "v OS := iOS", "", v_VOS);
            MainFrm.DTTObj.AddToken ("05F762A8-F6B8-482F-89EB-41FBB1B13EDE", "8E64E9E9-98C7-4AE7-9BA4-B6034CE63C9C", 589824, "iOS", (new IDVariant("1")));
            v_VOS = (new IDVariant("1"));
            MainFrm.DTTObj.AddAssignNewValue ("05F762A8-F6B8-482F-89EB-41FBB1B13EDE", "AB2214DF-B143-48E7-8E2C-3DCC2B4A48E0", v_VOS);
          }
          MainFrm.DTTObj.EndIfBlk ("36D645D1-C802-476B-ABF5-D061B28FE991");
          MainFrm.DTTObj.AddIf ("7830EAC8-C90A-456A-BA62-B118BF179992", "IF v Key <> \"\" and v Dev Token <> \"\"", "");
          MainFrm.DTTObj.AddToken ("7830EAC8-C90A-456A-BA62-B118BF179992", "443BA776-42C2-4E54-813A-8F9BD136594F", 1376256, "v Key", v_VKEY);
          MainFrm.DTTObj.AddToken ("7830EAC8-C90A-456A-BA62-B118BF179992", "89B49CF9-34F9-4B92-BF20-ECD7EF8633DF", 1376256, "v Dev Token", v_VDEVTOKEN);
          if (v_VKEY.compareTo((new IDVariant("")), true)!=0 && v_VDEVTOKEN.compareTo((new IDVariant("")), true)!=0)
          {
            MainFrm.DTTObj.EnterIf ("7830EAC8-C90A-456A-BA62-B118BF179992", "IF v Key <> \"\" and v Dev Token <> \"\"", "");
            IDVariant v_IAPPPUSSETID = new IDVariant(0,IDVariant.INTEGER);
            IDVariant v_TROVOAPPLICA = new IDVariant(0,IDVariant.INTEGER);
            SQL = new StringBuilder();
            SQL.Append("select ");
            SQL.Append("  A.ID as IDAPPS ");
            SQL.Append("from ");
            SQL.Append("  APPS A ");
            SQL.Append("where (A.APP_KEY = " + IDL.CSql(v_VKEY, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            MainFrm.DTTObj.AddQuery ("190B8BE9-70BA-47D6-A7C0-E6EB8DF450B9", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
            QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
            if (!QV.EOF()) QV.MoveNext();
            MainFrm.DTTObj.EndQuery ("190B8BE9-70BA-47D6-A7C0-E6EB8DF450B9");
            MainFrm.DTTObj.AddDBDataSource (QV, SQL);
            v_TROVOAPPLICA = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
            if (!QV.EOF())
            {
              v_IAPPPUSSETID = QV.Get("IDAPPS", IDVariant.INTEGER) ;
              MainFrm.DTTObj.AddToken ("190B8BE9-70BA-47D6-A7C0-E6EB8DF450B9", "68694F5A-A6EC-438E-B96D-F015A4E906CA", 1376256, "i Apps Push Settings ID", v_IAPPPUSSETID);
            }
            QV.Close();
            MainFrm.DTTObj.AddSubProc ("0DB8449D-8C22-4490-BFCD-4495ACC22D28", "Notificatore.Write Debug", "");
            WriteDebug(new IDVariant (SQL.ToString()), (new IDVariant(2)), (new IDVariant("HTTP Request: Parse URL")));
            // 
            // iOS: http://notificatore.apexnet.it/Notificatore.aspx
            // CMD=initapp&appkey=PIPPO&devtoken=1231231232123
            // Android: http://notificatore.apexnet.it/Notificatore
            // aspx?CMD=initapp&appkey=PIPPO&devtoken=1231231232123
            // 
            MainFrm.DTTObj.AddIf ("73A9F5F8-15AD-43F7-B1AB-36C4A8813782", "IF Trovo Applicazione1", "iOS: http://notificatore.apexnet.it/Notificatore.aspx?CMD=initapp&appkey=PIPPO&devtoken=1231231232123\nAndroid: http://notificatore.apexnet.it/Notificatore.aspx?CMD=initapp&appkey=PIPPO&devtoken=1231231232123");
            MainFrm.DTTObj.AddToken ("73A9F5F8-15AD-43F7-B1AB-36C4A8813782", "AF799A16-D9A3-4DE5-A453-56F53AF07C0E", 1376256, "Trovo Applicazione1", v_TROVOAPPLICA.booleanValue());
            if (v_TROVOAPPLICA.booleanValue())
            {
              MainFrm.DTTObj.EnterIf ("73A9F5F8-15AD-43F7-B1AB-36C4A8813782", "IF Trovo Applicazione1", "iOS: http://notificatore.apexnet.it/Notificatore.aspx?CMD=initapp&appkey=PIPPO&devtoken=1231231232123\nAndroid: http://notificatore.apexnet.it/Notificatore.aspx?CMD=initapp&appkey=PIPPO&devtoken=1231231232123");
              IDVariant v_VIDAPPPUSSET = new IDVariant(0,IDVariant.INTEGER);
              IDVariant v_TROVATA = new IDVariant(0,IDVariant.INTEGER);
              SQL = new StringBuilder();
              SQL.Append("select ");
              SQL.Append("  A.ID as ID ");
              SQL.Append("from ");
              SQL.Append("  APPS_PUSH_SETTING A ");
              SQL.Append("where (A.ID_APP = " + IDL.CSql(v_IAPPPUSSETID, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
              SQL.Append("and   (A.TYPE_OS = " + IDL.CSql(v_VOS, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
              MainFrm.DTTObj.AddQuery ("78FCF815-2931-401E-BE09-3DA6B900BBB2", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
              QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
              if (!QV.EOF()) QV.MoveNext();
              MainFrm.DTTObj.EndQuery ("78FCF815-2931-401E-BE09-3DA6B900BBB2");
              MainFrm.DTTObj.AddDBDataSource (QV, SQL);
              v_TROVATA = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
              if (!QV.EOF())
              {
                v_VIDAPPPUSSET = QV.Get("ID", IDVariant.INTEGER) ;
                MainFrm.DTTObj.AddToken ("78FCF815-2931-401E-BE09-3DA6B900BBB2", "6CC6A6C6-538F-4964-BAE1-D298F55C3910", 1376256, "v ID Apps Push Settings", v_VIDAPPPUSSET);
              }
              QV.Close();
              MainFrm.DTTObj.AddSubProc ("45AEBBB0-4D2A-4F9C-A062-73EA1C891CE9", "Notificatore.Write Debug", "");
              WriteDebug(new IDVariant (SQL.ToString()), (new IDVariant(2)), (new IDVariant("HTTP Request: Parse URL")));
              MainFrm.DTTObj.AddIf ("F5221E0F-EA31-42E2-AF07-0C073B5BB7D0", "IF trovata", "");
              MainFrm.DTTObj.AddToken ("F5221E0F-EA31-42E2-AF07-0C073B5BB7D0", "EE14C5D4-7086-4354-AD2D-2D8CEE05356D", 1376256, "trovata", v_TROVATA.booleanValue());
              if (v_TROVATA.booleanValue())
              {
                MainFrm.DTTObj.EnterIf ("F5221E0F-EA31-42E2-AF07-0C073B5BB7D0", "IF trovata", "");
                MainFrm.DTTObj.AddSubProc ("F120F4E7-FD59-45BE-95A7-21C4969AFABE", "Notificatore.Save Device Token", "");
                SaveDeviceToken(v_VDEVTOKEN, v_VUSER, v_VIDAPPPUSSET, v_VREGID, v_VOS, v_VCUSTOM, v_VLANGUAGE);
                MainFrm.DTTObj.AddAssign ("D69B4C32-5656-45D7-A4FD-DECCD9793691", "OK := true", "", v_OK);
                MainFrm.DTTObj.AddToken ("D69B4C32-5656-45D7-A4FD-DECCD9793691", "78B75DA3-DBDF-11D4-900E-726096000000", 589824, "true", (new IDVariant(-1)));
                v_OK = (new IDVariant(-1));
                MainFrm.DTTObj.AddAssignNewValue ("D69B4C32-5656-45D7-A4FD-DECCD9793691", "CC9A938B-431C-4777-AA10-D7409FA32B18", v_OK);
              }
              MainFrm.DTTObj.EndIfBlk ("F5221E0F-EA31-42E2-AF07-0C073B5BB7D0");
            }
            MainFrm.DTTObj.EndIfBlk ("73A9F5F8-15AD-43F7-B1AB-36C4A8813782");
          }
          MainFrm.DTTObj.EndIfBlk ("7830EAC8-C90A-456A-BA62-B118BF179992");
          MainFrm.DTTObj.AddIf ("187273D7-5D9A-4B29-91EF-F9D1C8F9AE82", "IF OK", "");
          MainFrm.DTTObj.AddToken ("187273D7-5D9A-4B29-91EF-F9D1C8F9AE82", "CC9A938B-431C-4777-AA10-D7409FA32B18", 1376256, "OK", v_OK.booleanValue());
          if (v_OK.booleanValue())
          {
            MainFrm.DTTObj.EnterIf ("187273D7-5D9A-4B29-91EF-F9D1C8F9AE82", "IF OK", "");
            MainFrm.DTTObj.AddSubProc ("79F4F8DA-A6CD-4DD2-B822-77BC7C2B7AF7", "Notificatore.Send To Browser", "");
            MainFrm.DTTObj.AddParameter ("79F4F8DA-A6CD-4DD2-B822-77BC7C2B7AF7", "9E14B4E2-C9CC-4C2A-9817-44958613A46F", "Contenuto", v_JSONOK);
            MainFrm.SendHtml(v_JSONOK.stringValue()); 
          }
          else if (0==0)
          {
            MainFrm.DTTObj.EnterElse ("6BE13686-6325-44F1-97EF-D31118EBE72C", "ELSE", "", "187273D7-5D9A-4B29-91EF-F9D1C8F9AE82");
            MainFrm.DTTObj.AddSubProc ("9ECFB445-FDA2-407F-8096-7AA240B19463", "Notificatore.Send To Browser", "");
            MainFrm.DTTObj.AddParameter ("9ECFB445-FDA2-407F-8096-7AA240B19463", "86F68A7D-E911-43C5-8A4B-9348425F0362", "Contenuto", v_JSONKO);
            MainFrm.SendHtml(v_JSONKO.stringValue()); 
          }
          MainFrm.DTTObj.EndIfBlk ("187273D7-5D9A-4B29-91EF-F9D1C8F9AE82");
        }
        break;
      }
      MainFrm.DTTObj.EndSwitchBlk ("5AA5B11D-5299-496B-8F1C-3A0E20C95D13");
      MainFrm.DTTObj.ExitProc("5517F4A9-2E35-4F48-80C7-BED2CFB0C9C9", "Parse URL", "", 3, "MainFrm");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("5517F4A9-2E35-4F48-80C7-BED2CFB0C9C9", "Parse URL", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "ParseURL", _e);
      MainFrm.DTTObj.ExitProc("5517F4A9-2E35-4F48-80C7-BED2CFB0C9C9", "Parse URL", "", 3, "MainFrm");
      return -1;
    }
  }

  // **********************************************************************
  // Write Debug
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Messaggio:  - Input
  // Livello - Input
  // Tipo:  - Input
  // **********************************************************************
  public int WriteDebug (IDVariant Messaggio, IDVariant Livello, IDVariant Tipo)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("42422BDE-5EFD-43C0-A5C1-98E12ED7A296", "Write Debug", "", 3, "MainFrm")) return 0;
      MainFrm.DTTObj.AddParameter ("42422BDE-5EFD-43C0-A5C1-98E12ED7A296", "A912E274-62C3-46BE-9784-C557EBE2EAB7", "Messaggio", Messaggio);
      MainFrm.DTTObj.AddParameter ("42422BDE-5EFD-43C0-A5C1-98E12ED7A296", "B0B88961-58F3-4661-80F2-866D82AFC8DE", "Livello", Livello);
      MainFrm.DTTObj.AddParameter ("42422BDE-5EFD-43C0-A5C1-98E12ED7A296", "068EE28E-EAAA-43CE-9AED-55341D24703F", "Tipo", Tipo);
      // 
      // Write Debug Body
      // Corpo Procedura
      // 
      IDVariant v_VTRACEIMPOST = new IDVariant(0,IDVariant.INTEGER);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.FLG_DEBUG as TRACEIMPOSTA ");
      SQL.Append("from ");
      SQL.Append("  IMPOSTAZIONI A ");
      MainFrm.DTTObj.AddQuery ("93AC4928-9A79-402E-8500-BFFC572AD354", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("93AC4928-9A79-402E-8500-BFFC572AD354");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        v_VTRACEIMPOST = QV.Get("TRACEIMPOSTA", IDVariant.INTEGER) ;
        MainFrm.DTTObj.AddToken ("93AC4928-9A79-402E-8500-BFFC572AD354", "D9D140CF-AB51-41A9-92D9-95731041AA89", 1376256, "v Trace Impostazione", v_VTRACEIMPOST);
      }
      QV.Close();
      MainFrm.DTTObj.AddIf ("939DA05E-AA53-4C82-BC1F-A51E74E20845", "IF v Trace Impostazione >= Livello", "");
      MainFrm.DTTObj.AddToken ("939DA05E-AA53-4C82-BC1F-A51E74E20845", "D9D140CF-AB51-41A9-92D9-95731041AA89", 1376256, "v Trace Impostazione", v_VTRACEIMPOST);
      MainFrm.DTTObj.AddToken ("939DA05E-AA53-4C82-BC1F-A51E74E20845", "B0B88961-58F3-4661-80F2-866D82AFC8DE", 1376256, "Livello", Livello);
      if (v_VTRACEIMPOST.compareTo(Livello, true)>=0)
      {
        MainFrm.DTTObj.EnterIf ("939DA05E-AA53-4C82-BC1F-A51E74E20845", "IF v Trace Impostazione >= Livello", "");
        MainFrm.DTTObj.AddSubProc ("2BB23ADB-16CF-41C2-944B-A1B540785EF5", "Notificatore DB.Write Message Log", "");
        ReturnStatus = MainFrm.NotificatoreDBObject.WriteMessageLog(Messaggio, Livello, Tipo);
        if (ReturnStatus != 0) throw new Exception(MainFrm.NotificatoreDBObject.ErrorMessage());
      }
      MainFrm.DTTObj.EndIfBlk ("939DA05E-AA53-4C82-BC1F-A51E74E20845");
      MainFrm.DTTObj.ExitProc("42422BDE-5EFD-43C0-A5C1-98E12ED7A296", "Write Debug", "", 3, "MainFrm");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("42422BDE-5EFD-43C0-A5C1-98E12ED7A296", "Write Debug", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "WriteDebug", _e);
      MainFrm.DTTObj.ExitProc("42422BDE-5EFD-43C0-A5C1-98E12ED7A296", "Write Debug", "", 3, "MainFrm");
      return -1;
    }
  }

  // **********************************************************************
  // Get App Name
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // IDApps Push Setting - Input
  // **********************************************************************
  public IDVariant GetAppName (IDVariant IDAppsPushSetting)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("701D9F58-90F6-416B-9B37-08B655549117", "Get App Name", "", 2, "MainFrm")) return new IDVariant();
      MainFrm.DTTObj.AddParameter ("701D9F58-90F6-416B-9B37-08B655549117", "02143B93-6D7F-4FDE-B05C-35A6CEC4BEE7", "IDApps Push Setting", IDAppsPushSetting);
      // 
      // Get App Name Body
      // Corpo Procedura
      // 
      IDVariant v_VAPPLICAZAPP = new IDVariant(0,IDVariant.STRING);
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  B.NOME_APP as APPLICAZIAPP ");
      SQL.Append("from ");
      SQL.Append("  APPS_PUSH_SETTING A, ");
      SQL.Append("  APPS B ");
      SQL.Append("where B.ID = A.ID_APP ");
      SQL.Append("and   (A.ID = " + IDL.CSql(IDAppsPushSetting, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      MainFrm.DTTObj.AddQuery ("11A174A6-05DE-4263-9AC0-D6E90304D9F4", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("11A174A6-05DE-4263-9AC0-D6E90304D9F4");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        v_VAPPLICAZAPP = QV.Get("APPLICAZIAPP", IDVariant.STRING) ;
        MainFrm.DTTObj.AddToken ("11A174A6-05DE-4263-9AC0-D6E90304D9F4", "401F3B09-1D23-4266-820B-9D4AB0C8DFA4", 1376256, "v Applicazione App", v_VAPPLICAZAPP);
      }
      QV.Close();
      MainFrm.DTTObj.AddReturn ("9AFED3A0-131E-4082-8836-39E666BE7806", "RETURN v Applicazione App", "", v_VAPPLICAZAPP);
      MainFrm.DTTObj.ExitProc ("701D9F58-90F6-416B-9B37-08B655549117", "Get App Name", "Spiega quale elaborazione viene eseguita da questa procedura", 2, "MainFrm");
      return v_VAPPLICAZAPP;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("701D9F58-90F6-416B-9B37-08B655549117", "Get App Name", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "GetAppName", _e);
      MainFrm.DTTObj.ExitProc("701D9F58-90F6-416B-9B37-08B655549117", "Get App Name", "", 2, "MainFrm");
      return new IDVariant();
    }
  }

  // **********************************************************************
  // Call GMC Helper Send Notification
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Google Api Browser ID Apps Push Settings - Input
  // Regid Spedizione: RegID usato da android - Input
  // Messaggio Spedizione - Input
  // Custom Field1: Campo custom da passare - Input
  // Custom Field 2: Campo custom da passare - Input
  // **********************************************************************
  public IDVariant CallGMCHelperSendNotification (IDVariant GoogleApiBrowserIDAppsPushSettings, IDVariant RegidSpedizione, IDVariant MessaggioSpedizione, IDVariant CustomField1, IDVariant CustomField2)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("A50B9C2B-3091-41A8-9F7F-600ABFA6DB41", "Call GMC Helper Send Notification", "", 2, "MainFrm")) return new IDVariant();
      MainFrm.DTTObj.AddParameter ("A50B9C2B-3091-41A8-9F7F-600ABFA6DB41", "86F23F96-DEC6-4951-A99E-C246A92B87EE", "Google Api Browser ID Apps Push Settings", GoogleApiBrowserIDAppsPushSettings);
      MainFrm.DTTObj.AddParameter ("A50B9C2B-3091-41A8-9F7F-600ABFA6DB41", "002BE74A-8A1B-4704-8C02-BB030FAA68E6", "Regid Spedizione", RegidSpedizione);
      MainFrm.DTTObj.AddParameter ("A50B9C2B-3091-41A8-9F7F-600ABFA6DB41", "8A29D9FB-542D-47D0-9AE4-F4167B388BB1", "Messaggio Spedizione", MessaggioSpedizione);
      MainFrm.DTTObj.AddParameter ("A50B9C2B-3091-41A8-9F7F-600ABFA6DB41", "60ACEA04-380E-4AC2-ABA9-615E6DB7A98B", "Custom Field1", CustomField1);
      MainFrm.DTTObj.AddParameter ("A50B9C2B-3091-41A8-9F7F-600ABFA6DB41", "E5FA63F9-5EDD-4E8B-AB35-5F99C2907036", "Custom Field 2", CustomField2);
      // 
      // Call GMC Helper Send Notification Body
      // Corpo Procedura
      // 
      IDVariant v_SRET1 = null;
      MainFrm.DTTObj.AddAssign ("A5CEFEDB-0494-486A-A976-2BC5C90B5164", "s Ret1 := Gcm Helper.SendNotificationPlain (Google Api Browser ID Apps Push Settings, Regid Spedizione, Messaggio Spedizione, Custom Field1, Custom Field 2)", "", v_SRET1);
      MainFrm.DTTObj.AddToken ("A5CEFEDB-0494-486A-A976-2BC5C90B5164", "86F23F96-DEC6-4951-A99E-C246A92B87EE", 1376256, "Google Api Browser ID Apps Push Settings", GoogleApiBrowserIDAppsPushSettings);
      MainFrm.DTTObj.AddToken ("A5CEFEDB-0494-486A-A976-2BC5C90B5164", "002BE74A-8A1B-4704-8C02-BB030FAA68E6", 1376256, "Regid Spedizione", RegidSpedizione);
      MainFrm.DTTObj.AddToken ("A5CEFEDB-0494-486A-A976-2BC5C90B5164", "8A29D9FB-542D-47D0-9AE4-F4167B388BB1", 1376256, "Messaggio Spedizione", MessaggioSpedizione);
      MainFrm.DTTObj.AddToken ("A5CEFEDB-0494-486A-A976-2BC5C90B5164", "60ACEA04-380E-4AC2-ABA9-615E6DB7A98B", 1376256, "Custom Field1", CustomField1);
      MainFrm.DTTObj.AddToken ("A5CEFEDB-0494-486A-A976-2BC5C90B5164", "E5FA63F9-5EDD-4E8B-AB35-5F99C2907036", 1376256, "Custom Field 2", CustomField2);
      v_SRET1 = new IDVariant(GCMHelper.SendNotificationPlain(GoogleApiBrowserIDAppsPushSettings.stringValue(), RegidSpedizione.stringValue(),MessaggioSpedizione.stringValue(),CustomField1.stringValue(),CustomField2.stringValue()));
      MainFrm.DTTObj.AddAssignNewValue ("A5CEFEDB-0494-486A-A976-2BC5C90B5164", "390773D5-98D1-4381-8749-E068877E52A6", v_SRET1);
      MainFrm.DTTObj.AddReturn ("45020A38-24A6-485E-9822-E8DFE79463FC", "RETURN s Ret1", "", v_SRET1);
      MainFrm.DTTObj.ExitProc ("A50B9C2B-3091-41A8-9F7F-600ABFA6DB41", "Call GMC Helper Send Notification", "Spiega quale elaborazione viene eseguita da questa procedura", 2, "MainFrm");
      return v_SRET1;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("A50B9C2B-3091-41A8-9F7F-600ABFA6DB41", "Call GMC Helper Send Notification", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "CallGMCHelperSendNotification", _e);
      MainFrm.DTTObj.ExitProc("A50B9C2B-3091-41A8-9F7F-600ABFA6DB41", "Call GMC Helper Send Notification", "", 2, "MainFrm");
      return new IDVariant();
    }
  }

  // **********************************************************************
  // Send GCMNotification
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // ID Spedizione: Identificativo univoco - Input
  // **********************************************************************
  public int SendGCMNotification (IDVariant IDSpedizione)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;
    IDCachedRowSet C2;
    IDCachedRowSet C4;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("73C4D77E-8D22-4B54-940F-AA1FB8DB1511", "Send GCMNotification", "", 3, "MainFrm")) return 0;
      MainFrm.DTTObj.AddParameter ("73C4D77E-8D22-4B54-940F-AA1FB8DB1511", "B7820F4A-65E7-41C1-A6B4-5244285DAF5E", "ID Spedizione", IDSpedizione);
      // 
      // Send GCMNotification Body
      // Corpo Procedura
      // 
      IDVariant v_IMSGELABORAT = null;
      MainFrm.DTTObj.AddAssign ("3F7B3DB9-DE42-40B7-9518-2F330D17245D", "i Msg Elaborato := C0", "", v_IMSGELABORAT);
      v_IMSGELABORAT = (new IDVariant(0));
      MainFrm.DTTObj.AddAssignNewValue ("3F7B3DB9-DE42-40B7-9518-2F330D17245D", "9B93712B-9362-4F82-9753-E536C8D97820", v_IMSGELABORAT);
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // Ciclo per ogni applicazione che ha messaggi in coda
      // 
      int DTT_C2 = 0;
      MainFrm.DTTObj.AddForEach ("B617557B-D962-4200-8155-6B154091708F", "FOR EACH Spedizioni ROW", "Sono in una fascia oraria in cui non devo fare il refresh. Azzero la variabile\nCiclo per ogni applicazione che ha messaggi in coda");
      SQL = new StringBuilder();
      SQL.Append("select distinct ");
      SQL.Append("  A.ID_APPLICAZIONE as MIDAPPLICAZI ");
      SQL.Append("from ");
      SQL.Append("  SPEDIZIONI A, ");
      SQL.Append("  APPS_PUSH_SETTING B ");
      SQL.Append("where B.ID = A.ID_APPLICAZIONE ");
      SQL.Append("and   (A.FLG_STATO = 'W') ");
      SQL.Append("and   (A.TYPE_OS = '2') ");
      SQL.Append("and   (A.ID = " + IDL.CSql(IDSpedizione, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " OR (" + IDL.CSql(IDSpedizione, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " IS NULL)) ");
      SQL.Append("and   (B.FLG_ATTIVA = 'S') ");
      MainFrm.DTTObj.AddToken ("B617557B-D962-4200-8155-6B154091708F", "B617557B-D962-4200-8155-6B154091708F", 0, "SQL", SQL.ToString());
      C2 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!C2.EOF()) C2.MoveNext();
      MainFrm.DTTObj.EndQuery ("B617557B-D962-4200-8155-6B154091708F");
      MainFrm.DTTObj.AddDBDataSource (C2, SQL);
      while (!C2.EOF())
      {
        DTT_C2 = DTT_C2 + 1;
        if (!MainFrm.DTTObj.CheckLoop("B617557B-D962-4200-8155-6B154091708F", DTT_C2)) break;
        // 
        // 
        // 
        // 
        IDVariant v_TROVATAAPP = new IDVariant(0,IDVariant.INTEGER);
        IDVariant v_VGOAPBRIDAPS = new IDVariant(0,IDVariant.STRING);
        // 
        // Prelevo i dati dell'applicazione
        // 
        SQL = new StringBuilder();
        SQL.Append("select ");
        SQL.Append("  A.GOOGLE_API_ID as GOAPBRIDAPPS ");
        SQL.Append("from ");
        SQL.Append("  APPS_PUSH_SETTING A ");
        SQL.Append("where (A.ID = " + IDL.CSql(C2.Get("MIDAPPLICAZI"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        SQL.Append("and   (A.FLG_ATTIVA = 'S') ");
        SQL.Append("and   (A.TYPE_OS = '2') ");
        MainFrm.DTTObj.AddQuery ("1A8FCE74-8305-425E-BC43-E151DBF6D396", "Notificatore DB (Notificatore DB): Select into variables", "Prelevo i dati dell'applicazione", 1280, SQL.ToString());
        QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!QV.EOF()) QV.MoveNext();
        MainFrm.DTTObj.EndQuery ("1A8FCE74-8305-425E-BC43-E151DBF6D396");
        MainFrm.DTTObj.AddDBDataSource (QV, SQL);
        v_TROVATAAPP = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
        if (!QV.EOF())
        {
          v_VGOAPBRIDAPS = QV.Get("GOAPBRIDAPPS", IDVariant.STRING) ;
          MainFrm.DTTObj.AddToken ("1A8FCE74-8305-425E-BC43-E151DBF6D396", "3AD54D33-3DAE-4C4A-9320-9DA0875836A2", 1376256, "v Google Api Browser ID Apps Push Settings", v_VGOAPBRIDAPS);
        }
        QV.Close();
        // 
        // Se trovo ma configurazione (ovvio)
        // 
        MainFrm.DTTObj.AddIf ("26A84CA1-7DBC-405F-A577-82273F81BA4D", "IF Trovata APP and v Google Api Browser ID Apps Push Settings != \"\"", "Se trovo ma configurazione (ovvio)");
        MainFrm.DTTObj.AddToken ("26A84CA1-7DBC-405F-A577-82273F81BA4D", "FD73FC27-3C8A-42E7-ACBD-A23A198D81BA", 1376256, "Trovata APP", v_TROVATAAPP.booleanValue());
        MainFrm.DTTObj.AddToken ("26A84CA1-7DBC-405F-A577-82273F81BA4D", "3AD54D33-3DAE-4C4A-9320-9DA0875836A2", 1376256, "v Google Api Browser ID Apps Push Settings", v_VGOAPBRIDAPS);
        if (v_TROVATAAPP.booleanValue() && v_VGOAPBRIDAPS.compareTo((new IDVariant("")), true)!=0)
        {
          MainFrm.DTTObj.EnterIf ("26A84CA1-7DBC-405F-A577-82273F81BA4D", "IF Trovata APP and v Google Api Browser ID Apps Push Settings != \"\"", "Se trovo ma configurazione (ovvio)");
          // 
          // Raggruppa le spedizione con lo stesso messaggio
          // Sono nella fascia oraria prevista per il refresh dei
          // dati...
          // 
          int DTT_C4 = 0;
          MainFrm.DTTObj.AddForEach ("707F1E72-FB12-4B80-9707-7EE2736E37E3", "FOR EACH Spedizioni ROW", "Raggruppa le spedizione con lo stesso messaggio\nSono nella fascia oraria prevista per il refresh dei dati...");
          SQL = new StringBuilder();
          SQL.Append("select ");
          SQL.Append("  A.ID as ID, ");
          SQL.Append("  REPLACE(A.REG_ID, ' ', '') as RREGID, ");
          SQL.Append("  A.ID_APPLICAZIONE as RIDAPPLICAZI, ");
          SQL.Append("  A.DES_MESSAGGIO as RMESSAGGIO, ");
          SQL.Append("  A.CUSTOM_FIELD1 as CUSTFIEL1SPE, ");
          SQL.Append("  A.CUSTOM_FIELD2 as CUSTFIEL2SPE ");
          SQL.Append("from ");
          SQL.Append("  SPEDIZIONI A ");
          SQL.Append("where (A.ID_APPLICAZIONE = " + IDL.CSql(C2.Get("MIDAPPLICAZI"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
          SQL.Append("and   (A.FLG_STATO = 'W') ");
          SQL.Append("and   ((A.DAT_ELAB IS NULL) OR CONVERT (float, GETDATE() - A.DAT_ELAB) > 0.100) ");
          MainFrm.DTTObj.AddToken ("707F1E72-FB12-4B80-9707-7EE2736E37E3", "707F1E72-FB12-4B80-9707-7EE2736E37E3", 0, "SQL", SQL.ToString());
          C4 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
          C4.setColUnbound(2,true);
          if (!C4.EOF()) C4.MoveNext();
          MainFrm.DTTObj.EndQuery ("707F1E72-FB12-4B80-9707-7EE2736E37E3");
          MainFrm.DTTObj.AddDBDataSource (C4, SQL);
          while (!C4.EOF())
          {
            DTT_C4 = DTT_C4 + 1;
            if (!MainFrm.DTTObj.CheckLoop("707F1E72-FB12-4B80-9707-7EE2736E37E3", DTT_C4)) break;
            MainFrm.DTTObj.AddAssign ("6F4D48F9-CB89-4CD9-9EBA-F407A9AF6F75", "i Msg Elaborato := i Msg Elaborato + 1", "", v_IMSGELABORAT);
            MainFrm.DTTObj.AddToken ("6F4D48F9-CB89-4CD9-9EBA-F407A9AF6F75", "9B93712B-9362-4F82-9753-E536C8D97820", 1376256, "i Msg Elaborato", v_IMSGELABORAT);
            v_IMSGELABORAT = IDL.Add(v_IMSGELABORAT, (new IDVariant(1)));
            MainFrm.DTTObj.AddAssignNewValue ("6F4D48F9-CB89-4CD9-9EBA-F407A9AF6F75", "9B93712B-9362-4F82-9753-E536C8D97820", v_IMSGELABORAT);
            // 
            // Se ho raggiunto il numero massimo di elaborazioni da
            // effettuare
            // 
            MainFrm.DTTObj.AddIf ("5BA00A96-1FC1-44DE-92AC-9F9927B7BB94", "IF i Msg Elaborato > Glb Max Messaggi C2DN Notificatore", "Se ho raggiunto il numero massimo di elaborazioni da effettuare");
            MainFrm.DTTObj.AddToken ("5BA00A96-1FC1-44DE-92AC-9F9927B7BB94", "9B93712B-9362-4F82-9753-E536C8D97820", 1376256, "i Msg Elaborato", v_IMSGELABORAT);
            MainFrm.DTTObj.AddToken ("5BA00A96-1FC1-44DE-92AC-9F9927B7BB94", "6C3C97CC-47BF-405C-BBA3-A78D7A0C270D", 1376256, "Glb Max Messaggi C2DN", GLBMAXMESC2D);
            if (v_IMSGELABORAT.compareTo(GLBMAXMESC2D, true)>0)
            {
              MainFrm.DTTObj.EnterIf ("5BA00A96-1FC1-44DE-92AC-9F9927B7BB94", "IF i Msg Elaborato > Glb Max Messaggi C2DN Notificatore", "Se ho raggiunto il numero massimo di elaborazioni da effettuare");
              MainFrm.DTTObj.AddAssign ("7D8F41EB-A559-4744-AA8B-31974BE6BEB3", "i Msg Elaborato := C0", "", v_IMSGELABORAT);
              v_IMSGELABORAT = (new IDVariant(0));
              MainFrm.DTTObj.AddAssignNewValue ("7D8F41EB-A559-4744-AA8B-31974BE6BEB3", "9B93712B-9362-4F82-9753-E536C8D97820", v_IMSGELABORAT);
              IDVariant v_SMSG = null;
              MainFrm.DTTObj.AddAssign ("0CC5DFFA-DFBB-4B31-9AEA-978C9354DE38", "s Msg := Format Message (\"C2DM: Ne ho spediti |1. L'ultimo è il |2\", To String (Glb Max Messaggi C2DN Notificatore), To String (ID Spedizione), ??, ??, ??)", "", v_SMSG);
              MainFrm.DTTObj.AddToken ("0CC5DFFA-DFBB-4B31-9AEA-978C9354DE38", "6C3C97CC-47BF-405C-BBA3-A78D7A0C270D", 1376256, "Glb Max Messaggi C2DN", GLBMAXMESC2D);
              MainFrm.DTTObj.AddToken ("0CC5DFFA-DFBB-4B31-9AEA-978C9354DE38", "5E5267C8-642E-4AEA-8F90-197FB78404C7", 1376256, "ID Spedizione", C4.Get("ID"));
              v_SMSG = IDL.FormatMessage((new IDVariant("C2DM: Ne ho spediti |1. L'ultimo è il |2")), IDL.ToString(GLBMAXMESC2D), IDL.ToString(C4.Get("ID")));
              MainFrm.DTTObj.AddAssignNewValue ("0CC5DFFA-DFBB-4B31-9AEA-978C9354DE38", "5381D6F0-1FCB-44BE-9998-F38AC6674BB1", v_SMSG);
              MainFrm.DTTObj.AddSubProc ("B5672091-B574-455C-BF91-CAFD02D54434", "Notificatore.Write Debug", "");
              WriteDebug(v_SMSG, (new IDVariant(2)), (new IDVariant("Server session CGM")));
              MainFrm.DTTObj.AddBreak ("850E89FD-57C3-4E89-86AE-1880A9BEE5F9", "BREAK", "");
              break;
            }
            MainFrm.DTTObj.EndIfBlk ("5BA00A96-1FC1-44DE-92AC-9F9927B7BB94");
            IDVariant v_SRETJSON = null;
            MainFrm.DTTObj.AddAssign ("E2ED5860-4718-42E5-BAD5-7E64DFB92BFF", "s Ret Json := Gcm Helper.SendNotificationPlain (v Google Api Browser ID Apps Push Settings, r Reg ID Spedizione, r Messaggio Spedizione, Custom Field 1 Spedizione, Custom Field 2 Spedizione)", "", v_SRETJSON);
            MainFrm.DTTObj.AddToken ("E2ED5860-4718-42E5-BAD5-7E64DFB92BFF", "3AD54D33-3DAE-4C4A-9320-9DA0875836A2", 1376256, "v Google Api Browser ID Apps Push Settings", v_VGOAPBRIDAPS);
            MainFrm.DTTObj.AddToken ("E2ED5860-4718-42E5-BAD5-7E64DFB92BFF", "93C47A83-0AD7-4301-82A6-B113E6A60FCC", 1376256, "r Reg ID", C4.Get("RREGID"));
            MainFrm.DTTObj.AddToken ("E2ED5860-4718-42E5-BAD5-7E64DFB92BFF", "DB588A49-E1BD-4F24-868B-2BD88CD9F877", 1376256, "r Messaggio", C4.Get("RMESSAGGIO"));
            MainFrm.DTTObj.AddToken ("E2ED5860-4718-42E5-BAD5-7E64DFB92BFF", "854F2C8C-32BF-43FF-B91D-FCAC4D78E461", 1376256, "Custom Field 1 Spedizione", C4.Get("CUSTFIEL1SPE"));
            MainFrm.DTTObj.AddToken ("E2ED5860-4718-42E5-BAD5-7E64DFB92BFF", "4327264B-21B8-4830-BE77-90E13AD0C001", 1376256, "Custom Field 2 Spedizione", C4.Get("CUSTFIEL2SPE"));
            v_SRETJSON = new IDVariant(GCMHelper.SendNotificationPlain(v_VGOAPBRIDAPS.stringValue(), C4.Get("RREGID").stringValue(),C4.Get("RMESSAGGIO").stringValue(),C4.Get("CUSTFIEL1SPE").stringValue(),C4.Get("CUSTFIEL2SPE").stringValue()));
            MainFrm.DTTObj.AddAssignNewValue ("E2ED5860-4718-42E5-BAD5-7E64DFB92BFF", "2CE0EAE8-3E46-4841-923E-9192C91EF0BB", v_SRETJSON);
            MainFrm.DTTObj.AddSubProc ("4354F5F9-78FA-4164-B0E6-DBD5C4D2AC36", "Notificatore.Elabora Risultato GCM Notification", "");
            ElaboraRisultatoGCMNotification(C4.Get("RREGID"), v_SRETJSON, C4.Get("ID"));
            C4.MoveNext();
          }
          C4.Close();
          MainFrm.DTTObj.EndForEach ("707F1E72-FB12-4B80-9707-7EE2736E37E3", "FOR EACH Spedizioni ROW", "Raggruppa le spedizione con lo stesso messaggio\nSono nella fascia oraria prevista per il refresh dei dati...", DTT_C4);
        }
        MainFrm.DTTObj.EndIfBlk ("26A84CA1-7DBC-405F-A577-82273F81BA4D");
        MainFrm.DTTObj.AddSubProc ("B7C456FB-5CFE-4E12-9616-828A8DBE8F9A", "Notificatore.Sleep", "");
        MainFrm.DTTObj.AddParameter ("B7C456FB-5CFE-4E12-9616-828A8DBE8F9A", "75EC2A20-3783-41E9-AD72-6A8B0BBB80AD", "Numero Secondi", (new IDVariant(1)));
        IDL.Sleep((new IDVariant(1)).intValue()*1000); 
        C2.MoveNext();
      }
      C2.Close();
      MainFrm.DTTObj.EndForEach ("B617557B-D962-4200-8155-6B154091708F", "FOR EACH Spedizioni ROW", "Sono in una fascia oraria in cui non devo fare il refresh. Azzero la variabile\nCiclo per ogni applicazione che ha messaggi in coda", DTT_C2);
      MainFrm.DTTObj.ExitProc("73C4D77E-8D22-4B54-940F-AA1FB8DB1511", "Send GCMNotification", "", 3, "MainFrm");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("73C4D77E-8D22-4B54-940F-AA1FB8DB1511", "Send GCMNotification", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "SendGCMNotification", _e);
      MainFrm.DTTObj.ExitProc("73C4D77E-8D22-4B54-940F-AA1FB8DB1511", "Send GCMNotification", "", 3, "MainFrm");
      return -1;
    }
  }

  // **********************************************************************
  // Elabora Risultato GCM Notification
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Regid Spedizione: RegID usato da android - Input
  // Json Ritorno - Input
  // ID Spedizione: Identificativo univoco - Input
  // **********************************************************************
  public int ElaboraRisultatoGCMNotification (IDVariant RegidSpedizione, IDVariant JsonRitorno, IDVariant IDSpedizione)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("1ED6AFE7-798D-4E39-A84B-06E0E9EE4E02", "Elabora Risultato GCM Notification", "", 3, "MainFrm")) return 0;
      MainFrm.DTTObj.AddParameter ("1ED6AFE7-798D-4E39-A84B-06E0E9EE4E02", "83D3EAD8-AE3A-47A9-9684-E7DAC4B00D38", "Regid Spedizione", RegidSpedizione);
      MainFrm.DTTObj.AddParameter ("1ED6AFE7-798D-4E39-A84B-06E0E9EE4E02", "B8C8BD69-D5ED-41D2-9249-95CCCED8B2C2", "Json Ritorno", JsonRitorno);
      MainFrm.DTTObj.AddParameter ("1ED6AFE7-798D-4E39-A84B-06E0E9EE4E02", "97678A97-68D5-479C-A07E-95212514BBE5", "ID Spedizione", IDSpedizione);
      // 
      // Elabora Risultato GCM Notification Body
      // Corpo Procedura
      // 
      IDVariant v_INFO = new IDVariant(0,IDVariant.STRING);
      IDVariant v_STATOSPEDIZI = new IDVariant(0,IDVariant.STRING);
      IDVariant v_NUMETENTSPED = new IDVariant(0,IDVariant.INTEGER);
      IDVariant v_MAXNUMERTENT = null;
      MainFrm.DTTObj.AddAssign ("825086FC-E67C-49F8-960A-7F0EE8AD622F", "Max Numero Tentativi := n 3", "", v_MAXNUMERTENT);
      MainFrm.DTTObj.AddToken ("825086FC-E67C-49F8-960A-7F0EE8AD622F", "A59B4CFA-46C3-47DA-A33C-78BF5AFA2264", 589824, "n 3", (new IDVariant(3)));
      v_MAXNUMERTENT = (new IDVariant(3));
      MainFrm.DTTObj.AddAssignNewValue ("825086FC-E67C-49F8-960A-7F0EE8AD622F", "6CDA6F50-C06C-4174-BAC4-A14184814247", v_MAXNUMERTENT);
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // Ciclo per ogni applicazione che ha messaggi in coda
      // 
      // 
      IDVariant v_INFOESITO = new IDVariant(0,IDVariant.STRING);
      IDVariant v_RESULTCODE = null;
      MainFrm.DTTObj.AddAssign ("12DC89A0-4345-4298-82B0-702F8A80B4C1", "result Code := Gcm Helper.ParseResultPlain (Json Ritorno, info Esito)", "", v_RESULTCODE);
      MainFrm.DTTObj.AddToken ("12DC89A0-4345-4298-82B0-702F8A80B4C1", "B8C8BD69-D5ED-41D2-9249-95CCCED8B2C2", 1376256, "Json Ritorno", JsonRitorno);
      MainFrm.DTTObj.AddToken ("12DC89A0-4345-4298-82B0-702F8A80B4C1", "E4AF275F-F265-43BB-B18D-A79D6757E7E3", 1376256, "info Esito", v_INFOESITO);
      v_RESULTCODE = new IDVariant(GCMHelper.ParseResultPlain(JsonRitorno.stringValue(),out v_INFOESITO));
      MainFrm.DTTObj.AddAssignNewValue ("12DC89A0-4345-4298-82B0-702F8A80B4C1", "EFE1C233-D283-4EF7-8AE4-FFC9163BCA1F", v_RESULTCODE);
      MainFrm.DTTObj.AddIf ("DEBF319A-DDC6-422E-B24D-A084A2E6EF80", "IF result Code >= n 0", "");
      MainFrm.DTTObj.AddToken ("DEBF319A-DDC6-422E-B24D-A084A2E6EF80", "EFE1C233-D283-4EF7-8AE4-FFC9163BCA1F", 1376256, "result Code", v_RESULTCODE);
      MainFrm.DTTObj.AddToken ("DEBF319A-DDC6-422E-B24D-A084A2E6EF80", "6A2DB12F-5472-454C-B7E6-5971E73AAA3E", 589824, "n 0", (new IDVariant(0)));
      if (v_RESULTCODE.compareTo((new IDVariant(0)), true)>=0)
      {
        MainFrm.DTTObj.EnterIf ("DEBF319A-DDC6-422E-B24D-A084A2E6EF80", "IF result Code >= n 0", "");
        SQL = new StringBuilder();
        SQL.Append("select ");
        SQL.Append("  A.TENTATIVI as NUMETENTSPED ");
        SQL.Append("from ");
        SQL.Append("  SPEDIZIONI A ");
        SQL.Append("where (A.ID = " + IDL.CSql(IDSpedizione, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        MainFrm.DTTObj.AddQuery ("E5E6DAB7-D248-4562-80D0-E1F2D0C77FBD", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
        QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!QV.EOF()) QV.MoveNext();
        MainFrm.DTTObj.EndQuery ("E5E6DAB7-D248-4562-80D0-E1F2D0C77FBD");
        MainFrm.DTTObj.AddDBDataSource (QV, SQL);
        if (!QV.EOF())
        {
          v_NUMETENTSPED = QV.Get("NUMETENTSPED", IDVariant.INTEGER) ;
          MainFrm.DTTObj.AddToken ("E5E6DAB7-D248-4562-80D0-E1F2D0C77FBD", "59DFF79F-36AD-4079-A3EC-ECAC19EEE9AB", 1376256, "Numero Tentativi Spedizione", v_NUMETENTSPED);
        }
        QV.Close();
        MainFrm.DTTObj.AddAssign ("355D7232-2AA1-470D-A9E0-FDC83BA6711D", "Stato Spedizione := Inviato", "", v_STATOSPEDIZI);
        MainFrm.DTTObj.AddToken ("355D7232-2AA1-470D-A9E0-FDC83BA6711D", "CA1DB931-7761-4DCC-8589-F8CF47B2F827", 589824, "Inviato", (new IDVariant("S")));
        v_STATOSPEDIZI = (new IDVariant("S"));
        MainFrm.DTTObj.AddAssignNewValue ("355D7232-2AA1-470D-A9E0-FDC83BA6711D", "0137CA71-ED81-4A31-96DC-CA03A93790DE", v_STATOSPEDIZI);
        IDVariant v_INFOSPEDIZIO = null;
        MainFrm.DTTObj.AddAssign ("F8A5DF49-DB03-4A16-BBD3-2DEDABA59B1D", "Info Spedizione := info Esito", "", v_INFOSPEDIZIO);
        MainFrm.DTTObj.AddToken ("F8A5DF49-DB03-4A16-BBD3-2DEDABA59B1D", "E4AF275F-F265-43BB-B18D-A79D6757E7E3", 1376256, "info Esito", new IDVariant(v_INFOESITO));
        v_INFOSPEDIZIO = new IDVariant(v_INFOESITO);
        MainFrm.DTTObj.AddAssignNewValue ("F8A5DF49-DB03-4A16-BBD3-2DEDABA59B1D", "7494AD4E-146D-44B0-A7BD-10FA554FED6E", v_INFOSPEDIZIO);
        // 
        // Invio effettuato con successo
        // 
        MainFrm.DTTObj.AddIf ("98FC925E-4A75-4E0E-9775-D5D236BC1837", "IF result Code = Invio OK", "Invio effettuato con successo");
        MainFrm.DTTObj.AddToken ("98FC925E-4A75-4E0E-9775-D5D236BC1837", "EFE1C233-D283-4EF7-8AE4-FFC9163BCA1F", 1376256, "result Code", v_RESULTCODE);
        MainFrm.DTTObj.AddToken ("98FC925E-4A75-4E0E-9775-D5D236BC1837", "026F1366-575C-43ED-B86B-549EA967C2D7", 589824, "Invio OK", (new IDVariant(0)));
        if (v_RESULTCODE.equals((new IDVariant(0)), true))
        {
          MainFrm.DTTObj.EnterIf ("98FC925E-4A75-4E0E-9775-D5D236BC1837", "IF result Code = Invio OK", "Invio effettuato con successo");
          MainFrm.DTTObj.AddAssign ("217A35EE-AD64-446F-BBF0-8B07920EBB3E", "Info Spedizione := C\"\"", "", v_INFOSPEDIZIO);
          v_INFOSPEDIZIO = (new IDVariant(""));
          MainFrm.DTTObj.AddAssignNewValue ("217A35EE-AD64-446F-BBF0-8B07920EBB3E", "7494AD4E-146D-44B0-A7BD-10FA554FED6E", v_INFOSPEDIZIO);
        }
        // 
        // In questi casi il device non è più attivo
        // 
        else if (0==0) { // **** begin else-if block
        MainFrm.DTTObj.AddIf ("24F445F9-3598-4BB4-912E-B140288B0FFB", "ELSE IF result Code = MissingRegistration or result Code = MismatchSenderId or result Code = InvalidRegistration or result Code = NotRegistered", "In questi casi il device non è più attivo");
        MainFrm.DTTObj.AddToken ("24F445F9-3598-4BB4-912E-B140288B0FFB", "EFE1C233-D283-4EF7-8AE4-FFC9163BCA1F", 1376256, "result Code", v_RESULTCODE);
        MainFrm.DTTObj.AddToken ("24F445F9-3598-4BB4-912E-B140288B0FFB", "7506B9EC-7958-4E82-91EF-7C9C981A8065", 589824, "MissingRegistration", (new IDVariant(101)));
        MainFrm.DTTObj.AddToken ("24F445F9-3598-4BB4-912E-B140288B0FFB", "96B6A16B-9C6B-4559-A760-F619092A6AD9", 589824, "MismatchSenderId", (new IDVariant(102)));
        MainFrm.DTTObj.AddToken ("24F445F9-3598-4BB4-912E-B140288B0FFB", "83A1CA6B-3AA8-4951-8F26-848F8B67A350", 589824, "InvalidRegistration", (new IDVariant(103)));
        MainFrm.DTTObj.AddToken ("24F445F9-3598-4BB4-912E-B140288B0FFB", "9D70E919-1F4B-4E82-8255-2E3DDC930D2B", 589824, "NotRegistered", (new IDVariant(104)));
        if (v_RESULTCODE.equals((new IDVariant(101)), true) || v_RESULTCODE.equals((new IDVariant(102)), true) || v_RESULTCODE.equals((new IDVariant(103)), true) || v_RESULTCODE.equals((new IDVariant(104)), true))
        {
          MainFrm.DTTObj.EnterIf ("24F445F9-3598-4BB4-912E-B140288B0FFB", "ELSE IF result Code = MissingRegistration or result Code = MismatchSenderId or result Code = InvalidRegistration or result Code = NotRegistered", "In questi casi il device non è più attivo");
          // 
          // In questi casi posso disabilitare il device token
          // 
          MainFrm.DTTObj.AddAssign ("54E7B32B-A7C0-4FA5-9918-5FC80CAE0466", "Stato Spedizione := Errore", "In questi casi posso disabilitare il device token", v_STATOSPEDIZI);
          MainFrm.DTTObj.AddToken ("54E7B32B-A7C0-4FA5-9918-5FC80CAE0466", "5E6E842B-5377-4A9D-88FA-5B1F058AB8FA", 589824, "Errore", (new IDVariant("E")));
          v_STATOSPEDIZI = (new IDVariant("E"));
          MainFrm.DTTObj.AddAssignNewValue ("54E7B32B-A7C0-4FA5-9918-5FC80CAE0466", "0137CA71-ED81-4A31-96DC-CA03A93790DE", v_STATOSPEDIZI);
          SQL = new StringBuilder();
          SQL.Append("update DEV_TOKENS set ");
          SQL.Append("  FLG_RIMOSSO = 'S', ");
          SQL.Append("  FLG_ATTIVO = 'N', ");
          SQL.Append("  DATA_RIMOZ = GETDATE() ");
          SQL.Append("where (REG_ID = " + IDL.CSql(RegidSpedizione, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
          MainFrm.DTTObj.AddQuery ("958A2972-98A3-4E9D-81EC-F5B2E29B0723", "Device Token (Notificatore DB): Update", "", 512, SQL.ToString());
          MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
          MainFrm.DTTObj.EndQuery ("958A2972-98A3-4E9D-81EC-F5B2E29B0723");
          MainFrm.DTTObj.AddParameter ("958A2972-98A3-4E9D-81EC-F5B2E29B0723", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
        }
        // 
        // Nel caso di errori bloccanti non faccio altri tentativi
        // di invio
        // 
        else if (0==0) { // **** begin else-if block
        MainFrm.DTTObj.AddIf ("B2B2A7DF-6153-4BD4-802A-BCE3EF155094", "ELSE IF result Code = MessageTooBig or result Code = InvalidDataKey or result Code = Generic error", "Nel caso di errori bloccanti non faccio altri tentativi di invio");
        MainFrm.DTTObj.AddToken ("B2B2A7DF-6153-4BD4-802A-BCE3EF155094", "EFE1C233-D283-4EF7-8AE4-FFC9163BCA1F", 1376256, "result Code", v_RESULTCODE);
        MainFrm.DTTObj.AddToken ("B2B2A7DF-6153-4BD4-802A-BCE3EF155094", "E97E5FD4-D278-40DB-BD19-376A4C3B9290", 589824, "MessageTooBig", (new IDVariant(105)));
        MainFrm.DTTObj.AddToken ("B2B2A7DF-6153-4BD4-802A-BCE3EF155094", "23F84E56-91D0-4E7F-8A7F-09502FC6D902", 589824, "InvalidDataKey", (new IDVariant(106)));
        MainFrm.DTTObj.AddToken ("B2B2A7DF-6153-4BD4-802A-BCE3EF155094", "A3D01651-3B20-402D-9C31-C068446FA58C", 589824, "Generic error", (new IDVariant(199)));
        if (v_RESULTCODE.equals((new IDVariant(105)), true) || v_RESULTCODE.equals((new IDVariant(106)), true) || v_RESULTCODE.equals((new IDVariant(199)), true))
        {
          MainFrm.DTTObj.EnterIf ("B2B2A7DF-6153-4BD4-802A-BCE3EF155094", "ELSE IF result Code = MessageTooBig or result Code = InvalidDataKey or result Code = Generic error", "Nel caso di errori bloccanti non faccio altri tentativi di invio");
          MainFrm.DTTObj.AddAssign ("6D8A765C-901A-4608-8735-0E543FFFBEF1", "Stato Spedizione := Errore", "", v_STATOSPEDIZI);
          MainFrm.DTTObj.AddToken ("6D8A765C-901A-4608-8735-0E543FFFBEF1", "5E6E842B-5377-4A9D-88FA-5B1F058AB8FA", 589824, "Errore", (new IDVariant("E")));
          v_STATOSPEDIZI = (new IDVariant("E"));
          MainFrm.DTTObj.AddAssignNewValue ("6D8A765C-901A-4608-8735-0E543FFFBEF1", "0137CA71-ED81-4A31-96DC-CA03A93790DE", v_STATOSPEDIZI);
        }
        // 
        // In questo caso GMC comunica un regId che va rimpiazzato
        // con quello presente nella base dati. InfoEsito contiene
        // il nuovo regId
        // 
        else if (0==0) { // **** begin else-if block
        MainFrm.DTTObj.AddIf ("175AD29C-F3CA-4D51-8B0E-A6F850887538", "ELSE IF result Code = Canonical Id", "In questo caso GMC comunica un regId che va rimpiazzato con quello presente nella base dati. InfoEsito contiene il nuovo regId");
        MainFrm.DTTObj.AddToken ("175AD29C-F3CA-4D51-8B0E-A6F850887538", "EFE1C233-D283-4EF7-8AE4-FFC9163BCA1F", 1376256, "result Code", v_RESULTCODE);
        MainFrm.DTTObj.AddToken ("175AD29C-F3CA-4D51-8B0E-A6F850887538", "24312857-5468-4C6B-B35A-C7B263FF0201", 589824, "Canonical Id", (new IDVariant(10)));
        if (v_RESULTCODE.equals((new IDVariant(10)), true))
        {
          MainFrm.DTTObj.EnterIf ("175AD29C-F3CA-4D51-8B0E-A6F850887538", "ELSE IF result Code = Canonical Id", "In questo caso GMC comunica un regId che va rimpiazzato con quello presente nella base dati. InfoEsito contiene il nuovo regId");
          // 
          // In questo caso GMC comunica un regId che va rimpiazzato
          // con quello presente nella base
          // 
          MainFrm.DTTObj.AddAssign ("85CC3F9D-7858-4286-AAA3-4CC57507006A", "Info Spedizione := Json Ritorno", "In questo caso GMC comunica un regId che va rimpiazzato con quello presente nella base", v_INFOSPEDIZIO);
          MainFrm.DTTObj.AddToken ("85CC3F9D-7858-4286-AAA3-4CC57507006A", "B8C8BD69-D5ED-41D2-9249-95CCCED8B2C2", 1376256, "Json Ritorno", new IDVariant(JsonRitorno));
          v_INFOSPEDIZIO = new IDVariant(JsonRitorno);
          MainFrm.DTTObj.AddAssignNewValue ("85CC3F9D-7858-4286-AAA3-4CC57507006A", "7494AD4E-146D-44B0-A7BD-10FA554FED6E", v_INFOSPEDIZIO);
          // 
          // Verifico che non ci siano altri regId uguali al canonical
          // fornito
          // 
          IDVariant v_VCOUNT = new IDVariant(0,IDVariant.INTEGER);
          SQL = new StringBuilder();
          SQL.Append("select ");
          SQL.Append("  COUNT(*) as COUNT1 ");
          SQL.Append("from ");
          SQL.Append("  DEV_TOKENS A ");
          SQL.Append("where (A.REG_ID = " + IDL.CSql(v_INFOESITO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
          MainFrm.DTTObj.AddQuery ("993C6396-DD30-4CCA-9439-32809F79BB31", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
          QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
          if (!QV.EOF()) QV.MoveNext();
          MainFrm.DTTObj.EndQuery ("993C6396-DD30-4CCA-9439-32809F79BB31");
          MainFrm.DTTObj.AddDBDataSource (QV, SQL);
          if (!QV.EOF())
          {
            v_VCOUNT = QV.Get("COUNT1", IDVariant.INTEGER) ;
            MainFrm.DTTObj.AddToken ("993C6396-DD30-4CCA-9439-32809F79BB31", "0D2EC826-CE95-4B38-A7FC-C4249ADC83F0", 1376256, "v Count", v_VCOUNT);
          }
          QV.Close();
          MainFrm.DTTObj.AddIf ("8654A417-CC56-4B6C-B67D-6FCE8689FF87", "IF v Count = n 0", "");
          MainFrm.DTTObj.AddToken ("8654A417-CC56-4B6C-B67D-6FCE8689FF87", "0D2EC826-CE95-4B38-A7FC-C4249ADC83F0", 1376256, "v Count", v_VCOUNT);
          MainFrm.DTTObj.AddToken ("8654A417-CC56-4B6C-B67D-6FCE8689FF87", "6A2DB12F-5472-454C-B7E6-5971E73AAA3E", 589824, "n 0", (new IDVariant(0)));
          if (v_VCOUNT.equals((new IDVariant(0)), true))
          {
            MainFrm.DTTObj.EnterIf ("8654A417-CC56-4B6C-B67D-6FCE8689FF87", "IF v Count = n 0", "");
            // 
            // Non esiste un'altra riga con quel regId, aggiorno la
            // riga vecchia con il nuovo canonical id
            // 
            SQL = new StringBuilder();
            SQL.Append("update DEV_TOKENS set ");
            SQL.Append("  REG_ID = " + IDL.CSql(v_INFOESITO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + " ");
            SQL.Append("where (REG_ID = " + IDL.CSql(RegidSpedizione, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            MainFrm.DTTObj.AddQuery ("BD51A423-FE0C-43F1-A1F7-3039DA84CD4B", "Device Token (Notificatore DB): Update", "Non esiste un'altra riga con quel regId, aggiorno la riga vecchia con il nuovo canonical id", 512, SQL.ToString());
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            MainFrm.DTTObj.EndQuery ("BD51A423-FE0C-43F1-A1F7-3039DA84CD4B");
            MainFrm.DTTObj.AddParameter ("BD51A423-FE0C-43F1-A1F7-3039DA84CD4B", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
          }
          else if (0==0)
          {
            MainFrm.DTTObj.EnterElse ("0F210D5E-4AC9-4DD2-850B-FB54FA88F1DC", "ELSE", "", "8654A417-CC56-4B6C-B67D-6FCE8689FF87");
            // 
            // C'è già un'altra riga con lo stesso regId, quindi posso
            // cancellare quella corrente per evitare invii doppi
            // 
            SQL = new StringBuilder();
            SQL.Append("update DEV_TOKENS set ");
            SQL.Append("  FLG_RIMOSSO = 'S', ");
            SQL.Append("  FLG_ATTIVO = 'N', ");
            SQL.Append("  DATA_RIMOZ = GETDATE() ");
            SQL.Append("where (REG_ID = " + IDL.CSql(RegidSpedizione, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            MainFrm.DTTObj.AddQuery ("2272E84D-2EE5-4949-B962-06853AB71505", "Device Token (Notificatore DB): Update", "C'è già un'altra riga con lo stesso regId, quindi posso cancellare quella corrente per evitare invii doppi", 512, SQL.ToString());
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            MainFrm.DTTObj.EndQuery ("2272E84D-2EE5-4949-B962-06853AB71505");
            MainFrm.DTTObj.AddParameter ("2272E84D-2EE5-4949-B962-06853AB71505", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
          }
          MainFrm.DTTObj.EndIfBlk ("8654A417-CC56-4B6C-B67D-6FCE8689FF87");
        }
        // 
        // In questi casi posso ritentare l'invio del messaggio
        // in un momento successivo
        // 
        else if (0==0) { // **** begin else-if block
        MainFrm.DTTObj.AddIf ("61E01C78-1104-480C-84BE-2DE952D5CC5E", "ELSE IF result Code = GMC Server error", "In questi casi posso ritentare l'invio del messaggio in un momento successivo");
        MainFrm.DTTObj.AddToken ("61E01C78-1104-480C-84BE-2DE952D5CC5E", "EFE1C233-D283-4EF7-8AE4-FFC9163BCA1F", 1376256, "result Code", v_RESULTCODE);
        MainFrm.DTTObj.AddToken ("61E01C78-1104-480C-84BE-2DE952D5CC5E", "B909714E-7141-4F1E-BCA2-CAFD64FC9147", 589824, "GMC Server error", (new IDVariant(200)));
        if (v_RESULTCODE.equals((new IDVariant(200)), true))
        {
          MainFrm.DTTObj.EnterIf ("61E01C78-1104-480C-84BE-2DE952D5CC5E", "ELSE IF result Code = GMC Server error", "In questi casi posso ritentare l'invio del messaggio in un momento successivo");
          // 
          // In questi casi posso ritentare l'invio del messaggio
          // in un momento successivo
          // 
          MainFrm.DTTObj.AddAssign ("78C5E8C0-AF7F-4860-A5A0-F030779821D5", "Stato Spedizione := Attesa", "In questi casi posso ritentare l'invio del messaggio in un momento successivo", v_STATOSPEDIZI);
          MainFrm.DTTObj.AddToken ("78C5E8C0-AF7F-4860-A5A0-F030779821D5", "D6046CA9-2D9C-4A5B-97B7-993C2399E958", 589824, "Attesa", (new IDVariant("W")));
          v_STATOSPEDIZI = (new IDVariant("W"));
          MainFrm.DTTObj.AddAssignNewValue ("78C5E8C0-AF7F-4860-A5A0-F030779821D5", "0137CA71-ED81-4A31-96DC-CA03A93790DE", v_STATOSPEDIZI);
          MainFrm.DTTObj.AddAssign ("04412110-CB08-4BE5-B08C-FFE93F9FC3A5", "Numero Tentativi Spedizione := Numero Tentativi Spedizione + n 1", "", v_NUMETENTSPED);
          MainFrm.DTTObj.AddToken ("04412110-CB08-4BE5-B08C-FFE93F9FC3A5", "59DFF79F-36AD-4079-A3EC-ECAC19EEE9AB", 1376256, "Numero Tentativi Spedizione", v_NUMETENTSPED);
          MainFrm.DTTObj.AddToken ("04412110-CB08-4BE5-B08C-FFE93F9FC3A5", "259692C8-9CC4-43D4-8159-184C0B3BA071", 589824, "n 1", (new IDVariant(1)));
          v_NUMETENTSPED = IDL.Add(v_NUMETENTSPED, (new IDVariant(1)));
          MainFrm.DTTObj.AddAssignNewValue ("04412110-CB08-4BE5-B08C-FFE93F9FC3A5", "59DFF79F-36AD-4079-A3EC-ECAC19EEE9AB", v_NUMETENTSPED);
          MainFrm.DTTObj.AddIf ("EE7762C8-5996-4587-BA93-947721552416", "IF Numero Tentativi Spedizione >= Max Numero Tentativi", "");
          MainFrm.DTTObj.AddToken ("EE7762C8-5996-4587-BA93-947721552416", "59DFF79F-36AD-4079-A3EC-ECAC19EEE9AB", 1376256, "Numero Tentativi Spedizione", v_NUMETENTSPED);
          MainFrm.DTTObj.AddToken ("EE7762C8-5996-4587-BA93-947721552416", "6CDA6F50-C06C-4174-BAC4-A14184814247", 1376256, "Max Numero Tentativi", v_MAXNUMERTENT);
          if (v_NUMETENTSPED.compareTo(v_MAXNUMERTENT, true)>=0)
          {
            MainFrm.DTTObj.EnterIf ("EE7762C8-5996-4587-BA93-947721552416", "IF Numero Tentativi Spedizione >= Max Numero Tentativi", "");
            MainFrm.DTTObj.AddAssign ("8D1B5F84-E445-4C63-92C4-719B1929738D", "Stato Spedizione := Errore", "", v_STATOSPEDIZI);
            MainFrm.DTTObj.AddToken ("8D1B5F84-E445-4C63-92C4-719B1929738D", "5E6E842B-5377-4A9D-88FA-5B1F058AB8FA", 589824, "Errore", (new IDVariant("E")));
            v_STATOSPEDIZI = (new IDVariant("E"));
            MainFrm.DTTObj.AddAssignNewValue ("8D1B5F84-E445-4C63-92C4-719B1929738D", "0137CA71-ED81-4A31-96DC-CA03A93790DE", v_STATOSPEDIZI);
          }
          MainFrm.DTTObj.EndIfBlk ("EE7762C8-5996-4587-BA93-947721552416");
        }
        MainFrm.DTTObj.EndIfBlk ("61E01C78-1104-480C-84BE-2DE952D5CC5E");
        } // **** end else-if block
        MainFrm.DTTObj.EndIfBlk ("175AD29C-F3CA-4D51-8B0E-A6F850887538");
        } // **** end else-if block
        MainFrm.DTTObj.EndIfBlk ("B2B2A7DF-6153-4BD4-802A-BCE3EF155094");
        } // **** end else-if block
        MainFrm.DTTObj.EndIfBlk ("24F445F9-3598-4BB4-912E-B140288B0FFB");
        } // **** end else-if block
        MainFrm.DTTObj.EndIfBlk ("98FC925E-4A75-4E0E-9775-D5D236BC1837");
        MainFrm.DTTObj.AddSubProc ("257EB012-5521-4D47-A32A-893CEBB72B02", "Notificatore.Write Debug", "");
        WriteDebug((new IDVariant("ERROR: CGM Problemi. Messaggio non in coda: spedizione id |1 codice errore |2 info |3")), (new IDVariant(1)), (new IDVariant("Server session CGM")));
        SQL = new StringBuilder();
        SQL.Append("update SPEDIZIONI set ");
        SQL.Append("  INFO = " + IDL.CSql(v_INFOSPEDIZIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  FLG_STATO = " + IDL.CSql(v_STATOSPEDIZI, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  DAT_ELAB = GETDATE(), ");
        SQL.Append("  TENTATIVI = " + IDL.CSql(v_NUMETENTSPED, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " ");
        SQL.Append("where (ID = " + IDL.CSql(IDSpedizione, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        MainFrm.DTTObj.AddQuery ("65E0539A-7170-4BF5-8290-0D902AF468A9", "Spedizioni (Notificatore DB): Update", "", 512, SQL.ToString());
        MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
        MainFrm.DTTObj.EndQuery ("65E0539A-7170-4BF5-8290-0D902AF468A9");
        MainFrm.DTTObj.AddParameter ("65E0539A-7170-4BF5-8290-0D902AF468A9", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("DF022DC7-C032-4239-9B82-836A482A14BD", "ELSE", "", "DEBF319A-DDC6-422E-B24D-A084A2E6EF80");
        SQL = new StringBuilder();
        SQL.Append("update SPEDIZIONI set ");
        SQL.Append("  FLG_STATO = 'E', ");
        SQL.Append("  INFO = " + IDL.CSql(JsonRitorno, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  DAT_ELAB = GETDATE(), ");
        SQL.Append("  TENTATIVI = " + IDL.CSql(v_NUMETENTSPED, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " ");
        SQL.Append("where (ID = " + IDL.CSql(IDSpedizione, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        MainFrm.DTTObj.AddQuery ("6BEFAD81-9FAC-4CCC-9909-105A8D098773", "Spedizioni (Notificatore DB): Update", "", 512, SQL.ToString());
        MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
        MainFrm.DTTObj.EndQuery ("6BEFAD81-9FAC-4CCC-9909-105A8D098773");
        MainFrm.DTTObj.AddParameter ("6BEFAD81-9FAC-4CCC-9909-105A8D098773", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
      }
      MainFrm.DTTObj.EndIfBlk ("DEBF319A-DDC6-422E-B24D-A084A2E6EF80");
      MainFrm.DTTObj.ExitProc("1ED6AFE7-798D-4E39-A84B-06E0E9EE4E02", "Elabora Risultato GCM Notification", "", 3, "MainFrm");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("1ED6AFE7-798D-4E39-A84B-06E0E9EE4E02", "Elabora Risultato GCM Notification", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "ElaboraRisultatoGCMNotification", _e);
      MainFrm.DTTObj.ExitProc("1ED6AFE7-798D-4E39-A84B-06E0E9EE4E02", "Elabora Risultato GCM Notification", "", 3, "MainFrm");
      return -1;
    }
  }

  // **********************************************************************
  // Send Win Store Notification
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // ID Spedizione: Identificativo univoco - Input
  // **********************************************************************
  public int SendWinStoreNotification (IDVariant IDSpedizione)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;
    IDCachedRowSet C2;
    IDCachedRowSet C4;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("0C04D02D-C4B9-48EB-82F8-132493485C80", "Send Win Store Notification", "", 3, "MainFrm")) return 0;
      MainFrm.DTTObj.AddParameter ("0C04D02D-C4B9-48EB-82F8-132493485C80", "A5BE652E-E855-4268-98CF-7A65C349A4B2", "ID Spedizione", IDSpedizione);
      // 
      // Send Win Store Notification Body
      // Corpo Procedura
      // 
      IDVariant v_MAXNUMERTENT = null;
      MainFrm.DTTObj.AddAssign ("F1DFBB44-52AC-42C1-A220-BD6011ECF69A", "Max Numero Tentativi := n 3", "", v_MAXNUMERTENT);
      MainFrm.DTTObj.AddToken ("F1DFBB44-52AC-42C1-A220-BD6011ECF69A", "A59B4CFA-46C3-47DA-A33C-78BF5AFA2264", 589824, "n 3", (new IDVariant(3)));
      v_MAXNUMERTENT = (new IDVariant(3));
      MainFrm.DTTObj.AddAssignNewValue ("F1DFBB44-52AC-42C1-A220-BD6011ECF69A", "E134B5FD-039A-4A80-8981-A0326B40A791", v_MAXNUMERTENT);
      IDVariant v_IMSGELABORAT = null;
      MainFrm.DTTObj.AddAssign ("B7772B5A-FD42-4BE6-B29B-041E65F83893", "i Msg Elaborato := C0", "", v_IMSGELABORAT);
      v_IMSGELABORAT = (new IDVariant(0));
      MainFrm.DTTObj.AddAssignNewValue ("B7772B5A-FD42-4BE6-B29B-041E65F83893", "5F14EB65-5E6E-4E9C-8BE7-9722F14AA0FD", v_IMSGELABORAT);
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // Ciclo per ogni applicazione che ha messaggi in coda
      // 
      int DTT_C2 = 0;
      MainFrm.DTTObj.AddForEach ("3036A6A3-7527-473A-A41A-75EE734B19D3", "FOR EACH Spedizioni ROW", "Sono in una fascia oraria in cui non devo fare il refresh. Azzero la variabile\nCiclo per ogni applicazione che ha messaggi in coda");
      SQL = new StringBuilder();
      SQL.Append("select distinct ");
      SQL.Append("  A.ID_APPLICAZIONE as MIDAPPLICAZI, ");
      SQL.Append("  A.TENTATIVI as NUMETENTSPED ");
      SQL.Append("from ");
      SQL.Append("  SPEDIZIONI A, ");
      SQL.Append("  APPS_PUSH_SETTING B ");
      SQL.Append("where B.ID = A.ID_APPLICAZIONE ");
      SQL.Append("and   (A.FLG_STATO = 'W') ");
      SQL.Append("and   (A.TYPE_OS = '5') ");
      SQL.Append("and   (A.ID = " + IDL.CSql(IDSpedizione, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " OR (" + IDL.CSql(IDSpedizione, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " IS NULL)) ");
      SQL.Append("and   (B.FLG_ATTIVA = 'S') ");
      MainFrm.DTTObj.AddToken ("3036A6A3-7527-473A-A41A-75EE734B19D3", "3036A6A3-7527-473A-A41A-75EE734B19D3", 0, "SQL", SQL.ToString());
      C2 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!C2.EOF()) C2.MoveNext();
      MainFrm.DTTObj.EndQuery ("3036A6A3-7527-473A-A41A-75EE734B19D3");
      MainFrm.DTTObj.AddDBDataSource (C2, SQL);
      while (!C2.EOF())
      {
        DTT_C2 = DTT_C2 + 1;
        if (!MainFrm.DTTObj.CheckLoop("3036A6A3-7527-473A-A41A-75EE734B19D3", DTT_C2)) break;
        // 
        // 
        // 
        // 
        IDVariant v_TROVATAAPP = new IDVariant(0,IDVariant.INTEGER);
        IDVariant v_VWNSSEAPPUSE = new IDVariant(0,IDVariant.STRING);
        IDVariant v_VWNPASEIDAPS = new IDVariant(0,IDVariant.STRING);
        IDVariant v_VWNXMTEAPPUS = new IDVariant(0,IDVariant.STRING);
        // 
        // Prelevo i dati dell'applicazione
        // 
        SQL = new StringBuilder();
        SQL.Append("select ");
        SQL.Append("  A.WNS_SECRET as WNSSECAPPUSE, ");
        SQL.Append("  A.WNS_SID as WNPASEIDAPPS, ");
        SQL.Append("  A.WNS_XML as WNXMTEAPPUSE ");
        SQL.Append("from ");
        SQL.Append("  APPS_PUSH_SETTING A ");
        SQL.Append("where (A.ID = " + IDL.CSql(C2.Get("MIDAPPLICAZI"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        SQL.Append("and   (A.FLG_ATTIVA = 'S') ");
        SQL.Append("and   (A.TYPE_OS = '5') ");
        MainFrm.DTTObj.AddQuery ("13390799-1EED-4604-8125-A85C74D7DD04", "Notificatore DB (Notificatore DB): Select into variables", "Prelevo i dati dell'applicazione", 1280, SQL.ToString());
        QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!QV.EOF()) QV.MoveNext();
        MainFrm.DTTObj.EndQuery ("13390799-1EED-4604-8125-A85C74D7DD04");
        MainFrm.DTTObj.AddDBDataSource (QV, SQL);
        v_TROVATAAPP = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
        if (!QV.EOF())
        {
          v_VWNSSEAPPUSE = QV.Get("WNSSECAPPUSE", IDVariant.STRING) ;
          MainFrm.DTTObj.AddToken ("13390799-1EED-4604-8125-A85C74D7DD04", "6B90BC96-278E-426B-8944-6C1C42C9B26A", 1376256, "v Wns Secret Apps Push Settings", v_VWNSSEAPPUSE);
          v_VWNPASEIDAPS = QV.Get("WNPASEIDAPPS", IDVariant.STRING) ;
          MainFrm.DTTObj.AddToken ("13390799-1EED-4604-8125-A85C74D7DD04", "CF9165D2-C7F7-45E4-B935-F4B48E3EAE03", 1376256, "v Wns Package Security Identifier Apps Push Settings", v_VWNPASEIDAPS);
          v_VWNXMTEAPPUS = QV.Get("WNXMTEAPPUSE", IDVariant.STRING) ;
          MainFrm.DTTObj.AddToken ("13390799-1EED-4604-8125-A85C74D7DD04", "63A975CF-5023-4391-BC1F-8F3CAD7CF65F", 1376256, "v Wns Xml Template Apps Push Settings", v_VWNXMTEAPPUS);
        }
        QV.Close();
        // 
        // Se trovo ma configurazione (ovvio)
        // 
        MainFrm.DTTObj.AddIf ("CA5C7E0A-BD1F-4032-A7D4-EED2518AB480", "IF Trovata APP and Null Value (v Wns Secret Apps Push Settings, \"\") != \"\"", "Se trovo ma configurazione (ovvio)");
        MainFrm.DTTObj.AddToken ("CA5C7E0A-BD1F-4032-A7D4-EED2518AB480", "1E9533EB-5E10-4C83-B2B4-62FA2F112D8E", 1376256, "Trovata APP", v_TROVATAAPP.booleanValue());
        MainFrm.DTTObj.AddToken ("CA5C7E0A-BD1F-4032-A7D4-EED2518AB480", "6B90BC96-278E-426B-8944-6C1C42C9B26A", 1376256, "v Wns Secret Apps Push Settings", v_VWNSSEAPPUSE);
        if (v_TROVATAAPP.booleanValue() && IDL.NullValue(v_VWNSSEAPPUSE,(new IDVariant(""))).compareTo((new IDVariant("")), true)!=0)
        {
          MainFrm.DTTObj.EnterIf ("CA5C7E0A-BD1F-4032-A7D4-EED2518AB480", "IF Trovata APP and Null Value (v Wns Secret Apps Push Settings, \"\") != \"\"", "Se trovo ma configurazione (ovvio)");
          IDVariant v_ACCESSTOKEN = null;
          MainFrm.DTTObj.AddAssign ("4E7EAC73-AE0A-4D8E-95D5-68F4E3D22D8D", "access Token := Wnshelperinde.GetWinStoreAccessToken (v Wns Secret Apps Push Settings, v Wns Package Security Identifier Apps Push Settings)", "", v_ACCESSTOKEN);
          MainFrm.DTTObj.AddToken ("4E7EAC73-AE0A-4D8E-95D5-68F4E3D22D8D", "6B90BC96-278E-426B-8944-6C1C42C9B26A", 1376256, "v Wns Secret Apps Push Settings", v_VWNSSEAPPUSE);
          MainFrm.DTTObj.AddToken ("4E7EAC73-AE0A-4D8E-95D5-68F4E3D22D8D", "CF9165D2-C7F7-45E4-B935-F4B48E3EAE03", 1376256, "v Wns Package Security Identifier Apps Push Settings", v_VWNPASEIDAPS);
          v_ACCESSTOKEN = new IDVariant(WNSHelperInde.GetWinStoreAccessToken(v_VWNSSEAPPUSE.stringValue(), v_VWNPASEIDAPS.stringValue()));
          MainFrm.DTTObj.AddAssignNewValue ("4E7EAC73-AE0A-4D8E-95D5-68F4E3D22D8D", "9F44D6A8-6587-45C8-A1CE-D44252E2F6CC", v_ACCESSTOKEN);
          // 
          // Raggruppa le spedizione con lo stesso messaggio
          // Sono nella fascia oraria prevista per il refresh dei
          // dati...
          // 
          int DTT_C4 = 0;
          MainFrm.DTTObj.AddForEach ("C537D303-DD8E-4DBB-8BB6-9362CCA0C7A4", "FOR EACH Spedizioni ROW", "Raggruppa le spedizione con lo stesso messaggio\nSono nella fascia oraria prevista per il refresh dei dati...");
          SQL = new StringBuilder();
          SQL.Append("select ");
          SQL.Append("  A.ID as ID, ");
          SQL.Append("  REPLACE(A.REG_ID, ' ', '') as RREGID, ");
          SQL.Append("  A.ID_APPLICAZIONE as RIDAPPLICAZI, ");
          SQL.Append("  A.DES_MESSAGGIO as RMESSAGGIO ");
          SQL.Append("from ");
          SQL.Append("  SPEDIZIONI A ");
          SQL.Append("where (A.ID_APPLICAZIONE = " + IDL.CSql(C2.Get("MIDAPPLICAZI"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
          SQL.Append("and   (A.FLG_STATO = 'W') ");
          SQL.Append("and   ((A.DAT_ELAB IS NULL) OR CONVERT (float, GETDATE() - A.DAT_ELAB) > 0.100) ");
          MainFrm.DTTObj.AddToken ("C537D303-DD8E-4DBB-8BB6-9362CCA0C7A4", "C537D303-DD8E-4DBB-8BB6-9362CCA0C7A4", 0, "SQL", SQL.ToString());
          C4 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
          C4.setColUnbound(2,true);
          if (!C4.EOF()) C4.MoveNext();
          MainFrm.DTTObj.EndQuery ("C537D303-DD8E-4DBB-8BB6-9362CCA0C7A4");
          MainFrm.DTTObj.AddDBDataSource (C4, SQL);
          while (!C4.EOF())
          {
            DTT_C4 = DTT_C4 + 1;
            if (!MainFrm.DTTObj.CheckLoop("C537D303-DD8E-4DBB-8BB6-9362CCA0C7A4", DTT_C4)) break;
            // 
            // Se c'è stato un errore nella generazione dell'access
            // tocken mi fermo
            // 
            MainFrm.DTTObj.AddIf ("C51EFEB9-96A9-42E6-AEDD-3E89A78C4E83", "IF access Token == \"\"", "Se c'è stato un errore nella generazione dell'access tocken mi fermo");
            MainFrm.DTTObj.AddToken ("C51EFEB9-96A9-42E6-AEDD-3E89A78C4E83", "9F44D6A8-6587-45C8-A1CE-D44252E2F6CC", 1376256, "access Token", v_ACCESSTOKEN);
            if (v_ACCESSTOKEN.equals((new IDVariant("")), true))
            {
              MainFrm.DTTObj.EnterIf ("C51EFEB9-96A9-42E6-AEDD-3E89A78C4E83", "IF access Token == \"\"", "Se c'è stato un errore nella generazione dell'access tocken mi fermo");
              MainFrm.DTTObj.AddBreak ("B310C74D-017B-4A8A-B864-A048B283F3F1", "BREAK", "");
              break;
            }
            MainFrm.DTTObj.EndIfBlk ("C51EFEB9-96A9-42E6-AEDD-3E89A78C4E83");
            MainFrm.DTTObj.AddAssign ("D88D2280-3DF5-4E26-897F-11E83163016A", "i Msg Elaborato := i Msg Elaborato + 1", "", v_IMSGELABORAT);
            MainFrm.DTTObj.AddToken ("D88D2280-3DF5-4E26-897F-11E83163016A", "5F14EB65-5E6E-4E9C-8BE7-9722F14AA0FD", 1376256, "i Msg Elaborato", v_IMSGELABORAT);
            v_IMSGELABORAT = IDL.Add(v_IMSGELABORAT, (new IDVariant(1)));
            MainFrm.DTTObj.AddAssignNewValue ("D88D2280-3DF5-4E26-897F-11E83163016A", "5F14EB65-5E6E-4E9C-8BE7-9722F14AA0FD", v_IMSGELABORAT);
            // 
            // Se ho raggiunto il numero massimo di elaborazioni da
            // effettuare
            // 
            MainFrm.DTTObj.AddIf ("D41ADDB0-8767-4B45-9D0B-81155BDD3179", "IF i Msg Elaborato > Glb Max Messaggi C2DN Notificatore", "Se ho raggiunto il numero massimo di elaborazioni da effettuare");
            MainFrm.DTTObj.AddToken ("D41ADDB0-8767-4B45-9D0B-81155BDD3179", "5F14EB65-5E6E-4E9C-8BE7-9722F14AA0FD", 1376256, "i Msg Elaborato", v_IMSGELABORAT);
            MainFrm.DTTObj.AddToken ("D41ADDB0-8767-4B45-9D0B-81155BDD3179", "6C3C97CC-47BF-405C-BBA3-A78D7A0C270D", 1376256, "Glb Max Messaggi C2DN", GLBMAXMESC2D);
            if (v_IMSGELABORAT.compareTo(GLBMAXMESC2D, true)>0)
            {
              MainFrm.DTTObj.EnterIf ("D41ADDB0-8767-4B45-9D0B-81155BDD3179", "IF i Msg Elaborato > Glb Max Messaggi C2DN Notificatore", "Se ho raggiunto il numero massimo di elaborazioni da effettuare");
              MainFrm.DTTObj.AddAssign ("F846050F-2EE0-4AD1-A964-6C2282488363", "i Msg Elaborato := C0", "", v_IMSGELABORAT);
              v_IMSGELABORAT = (new IDVariant(0));
              MainFrm.DTTObj.AddAssignNewValue ("F846050F-2EE0-4AD1-A964-6C2282488363", "5F14EB65-5E6E-4E9C-8BE7-9722F14AA0FD", v_IMSGELABORAT);
              IDVariant v_SMSG = null;
              MainFrm.DTTObj.AddAssign ("CACB778D-9ACC-4CF9-B0BA-D08EF3A4EADC", "s Msg := Format Message (\"WinStore: Ne ho spediti |1. L'ultimo è il |2\", To String (Glb Max Messaggi C2DN Notificatore), To String (ID Spedizione), ??, ??, ??)", "", v_SMSG);
              MainFrm.DTTObj.AddToken ("CACB778D-9ACC-4CF9-B0BA-D08EF3A4EADC", "6C3C97CC-47BF-405C-BBA3-A78D7A0C270D", 1376256, "Glb Max Messaggi C2DN", GLBMAXMESC2D);
              MainFrm.DTTObj.AddToken ("CACB778D-9ACC-4CF9-B0BA-D08EF3A4EADC", "3AD476C8-9371-490B-BC6F-D5C512C4736D", 1376256, "ID Spedizione", C4.Get("ID"));
              v_SMSG = IDL.FormatMessage((new IDVariant("WinStore: Ne ho spediti |1. L'ultimo è il |2")), IDL.ToString(GLBMAXMESC2D), IDL.ToString(C4.Get("ID")));
              MainFrm.DTTObj.AddAssignNewValue ("CACB778D-9ACC-4CF9-B0BA-D08EF3A4EADC", "295D71A3-1C57-40EA-B12B-B2BD98588CFC", v_SMSG);
              MainFrm.DTTObj.AddSubProc ("AEEF7314-8EDE-4E3F-B82F-8BC08E092CA0", "Notificatore.Write Debug", "");
              WriteDebug(v_SMSG, (new IDVariant(2)), (new IDVariant("Server session Win Store")));
              MainFrm.DTTObj.AddBreak ("FAB897DC-A368-4306-B08E-212A964AB251", "BREAK", "");
              break;
            }
            MainFrm.DTTObj.EndIfBlk ("D41ADDB0-8767-4B45-9D0B-81155BDD3179");
            IDVariant v_ESITOINVIO = new IDVariant(0,IDVariant.STRING);
            IDVariant v_SRET = null;
            MainFrm.DTTObj.AddAssign ("9C71C454-293C-402F-B411-3BDD9303B0FF", "s Ret := Wnshelperinde.SendWinStorePushNotification (access Token, r Reg ID Spedizione, r Messaggio Spedizione, esito Invio)", "", v_SRET);
            MainFrm.DTTObj.AddToken ("9C71C454-293C-402F-B411-3BDD9303B0FF", "9F44D6A8-6587-45C8-A1CE-D44252E2F6CC", 1376256, "access Token", v_ACCESSTOKEN);
            MainFrm.DTTObj.AddToken ("9C71C454-293C-402F-B411-3BDD9303B0FF", "553E2B9C-8566-41EC-9626-9BA1A27F409B", 1376256, "r Reg ID", C4.Get("RREGID"));
            MainFrm.DTTObj.AddToken ("9C71C454-293C-402F-B411-3BDD9303B0FF", "C98F5059-27DD-4E22-BB18-93330F59DD0C", 1376256, "r Messaggio", C4.Get("RMESSAGGIO"));
            MainFrm.DTTObj.AddToken ("9C71C454-293C-402F-B411-3BDD9303B0FF", "A084FF74-7F9B-4B5A-AB34-4EE5E3B6A3B3", 1376256, "esito Invio", v_ESITOINVIO);
            v_SRET = new IDVariant(WNSHelperInde.SendWinStorePushNotification(v_ACCESSTOKEN.stringValue(), C4.Get("RREGID").stringValue(), C4.Get("RMESSAGGIO").stringValue(), out v_ESITOINVIO));
            MainFrm.DTTObj.AddAssignNewValue ("9C71C454-293C-402F-B411-3BDD9303B0FF", "6056D01C-57B4-4E17-8ECC-07A7CF7E8013", v_SRET);
            // 
            // Controllo del risultato
            // 
            MainFrm.DTTObj.AddIf ("6FA58D24-F285-467F-80A1-36E6B8C45F69", "IF s Ret == OK", "Controllo del risultato");
            MainFrm.DTTObj.AddToken ("6FA58D24-F285-467F-80A1-36E6B8C45F69", "6056D01C-57B4-4E17-8ECC-07A7CF7E8013", 1376256, "s Ret", v_SRET);
            MainFrm.DTTObj.AddToken ("6FA58D24-F285-467F-80A1-36E6B8C45F69", "517E2F21-A24A-492E-ACAB-2F0BD03841E0", 589824, "OK", (new IDVariant(-1)));
            if (v_SRET.equals((new IDVariant(-1)), true))
            {
              MainFrm.DTTObj.EnterIf ("6FA58D24-F285-467F-80A1-36E6B8C45F69", "IF s Ret == OK", "Controllo del risultato");
              SQL = new StringBuilder();
              SQL.Append("update SPEDIZIONI set ");
              SQL.Append("  DAT_ELAB = GETDATE(), ");
              SQL.Append("  INFO = " + IDL.CSql(v_ESITOINVIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  FLG_STATO = 'S' ");
              SQL.Append("where (ID = " + IDL.CSql(C4.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
              MainFrm.DTTObj.AddQuery ("8940877D-1EC7-48AE-BA21-20ECB231B7EC", "Spedizioni (Notificatore DB): Update", "", 512, SQL.ToString());
              MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
              MainFrm.DTTObj.EndQuery ("8940877D-1EC7-48AE-BA21-20ECB231B7EC");
              MainFrm.DTTObj.AddParameter ("8940877D-1EC7-48AE-BA21-20ECB231B7EC", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
            }
            else if (0==0)
            {
              MainFrm.DTTObj.EnterElse ("CA6D4063-5CEF-43E3-8B25-8260EAFC08C4", "ELSE", "", "6FA58D24-F285-467F-80A1-36E6B8C45F69");
              MainFrm.DTTObj.AddIf ("AA4DE616-4D3A-467F-81D8-10569AFF5874", "IF s Ret = Token expired", "");
              MainFrm.DTTObj.AddToken ("AA4DE616-4D3A-467F-81D8-10569AFF5874", "6056D01C-57B4-4E17-8ECC-07A7CF7E8013", 1376256, "s Ret", v_SRET);
              MainFrm.DTTObj.AddToken ("AA4DE616-4D3A-467F-81D8-10569AFF5874", "4009CB1B-FA57-48D5-8F3B-0602EC0AB92C", 589824, "Token expired", (new IDVariant(100)));
              if (v_SRET.equals((new IDVariant(100)), true))
              {
                MainFrm.DTTObj.EnterIf ("AA4DE616-4D3A-467F-81D8-10569AFF5874", "IF s Ret = Token expired", "");
                MainFrm.DTTObj.AddAssign ("2BAEB1E4-D15A-41FD-8B98-FB7F12DD7B43", "access Token := Wnshelperinde.GetWinStoreAccessToken (v Wns Secret Apps Push Settings, v Wns Package Security Identifier Apps Push Settings)", "", v_ACCESSTOKEN);
                MainFrm.DTTObj.AddToken ("2BAEB1E4-D15A-41FD-8B98-FB7F12DD7B43", "6B90BC96-278E-426B-8944-6C1C42C9B26A", 1376256, "v Wns Secret Apps Push Settings", v_VWNSSEAPPUSE);
                MainFrm.DTTObj.AddToken ("2BAEB1E4-D15A-41FD-8B98-FB7F12DD7B43", "CF9165D2-C7F7-45E4-B935-F4B48E3EAE03", 1376256, "v Wns Package Security Identifier Apps Push Settings", v_VWNPASEIDAPS);
                v_ACCESSTOKEN = new IDVariant(WNSHelperInde.GetWinStoreAccessToken(v_VWNSSEAPPUSE.stringValue(), v_VWNPASEIDAPS.stringValue()));
                MainFrm.DTTObj.AddAssignNewValue ("2BAEB1E4-D15A-41FD-8B98-FB7F12DD7B43", "9F44D6A8-6587-45C8-A1CE-D44252E2F6CC", v_ACCESSTOKEN);
              }
              MainFrm.DTTObj.EndIfBlk ("AA4DE616-4D3A-467F-81D8-10569AFF5874");
              MainFrm.DTTObj.AddIf ("6E244FBB-EF22-4772-862A-53B9EC7B87FD", "IF s Ret == WebException or s Ret == Generic Exception", "");
              MainFrm.DTTObj.AddToken ("6E244FBB-EF22-4772-862A-53B9EC7B87FD", "6056D01C-57B4-4E17-8ECC-07A7CF7E8013", 1376256, "s Ret", v_SRET);
              MainFrm.DTTObj.AddToken ("6E244FBB-EF22-4772-862A-53B9EC7B87FD", "C3E2C789-4243-4A57-9DDD-D379A58C8F54", 589824, "WebException", (new IDVariant(101)));
              MainFrm.DTTObj.AddToken ("6E244FBB-EF22-4772-862A-53B9EC7B87FD", "D5CEAF84-8398-44F6-A229-92F0CED7F04C", 589824, "Generic Exception", (new IDVariant(199)));
              if (v_SRET.equals((new IDVariant(101)), true) || v_SRET.equals((new IDVariant(199)), true))
              {
                MainFrm.DTTObj.EnterIf ("6E244FBB-EF22-4772-862A-53B9EC7B87FD", "IF s Ret == WebException or s Ret == Generic Exception", "");
                IDVariant v_TENTATIVTEMP = null;
                MainFrm.DTTObj.AddAssign ("0E1D2047-8AEF-4430-BE66-156F65C8D15A", "tentativi Temp := n 1", "", v_TENTATIVTEMP);
                MainFrm.DTTObj.AddToken ("0E1D2047-8AEF-4430-BE66-156F65C8D15A", "259692C8-9CC4-43D4-8159-184C0B3BA071", 589824, "n 1", (new IDVariant(1)));
                v_TENTATIVTEMP = (new IDVariant(1));
                MainFrm.DTTObj.AddAssignNewValue ("0E1D2047-8AEF-4430-BE66-156F65C8D15A", "B289C7DA-AC2E-4F68-BCBC-FE35C2EF1EDB", v_TENTATIVTEMP);
                MainFrm.DTTObj.AddIf ("98B9469E-C665-489A-9B36-60385B84D3E2", "IF not (Is Null (Numero Tentativi Spedizione))", "");
                MainFrm.DTTObj.AddToken ("98B9469E-C665-489A-9B36-60385B84D3E2", "C2D872FA-7DE6-4E95-B4CF-9A88E835C3C6", 1376256, "Numero Tentativi Spedizione", C2.Get("NUMETENTSPED"));
                if (!(IDL.IsNull(C2.Get("NUMETENTSPED"))))
                {
                  MainFrm.DTTObj.EnterIf ("98B9469E-C665-489A-9B36-60385B84D3E2", "IF not (Is Null (Numero Tentativi Spedizione))", "");
                  MainFrm.DTTObj.AddAssign ("9BBA83ED-91D6-4C44-9FDA-244C19488C1F", "tentativi Temp := Numero Tentativi Spedizione + n 1", "", v_TENTATIVTEMP);
                  MainFrm.DTTObj.AddToken ("9BBA83ED-91D6-4C44-9FDA-244C19488C1F", "C2D872FA-7DE6-4E95-B4CF-9A88E835C3C6", 1376256, "Numero Tentativi Spedizione", C2.Get("NUMETENTSPED"));
                  MainFrm.DTTObj.AddToken ("9BBA83ED-91D6-4C44-9FDA-244C19488C1F", "259692C8-9CC4-43D4-8159-184C0B3BA071", 589824, "n 1", (new IDVariant(1)));
                  v_TENTATIVTEMP = IDL.Add(C2.Get("NUMETENTSPED"), (new IDVariant(1)));
                  MainFrm.DTTObj.AddAssignNewValue ("9BBA83ED-91D6-4C44-9FDA-244C19488C1F", "B289C7DA-AC2E-4F68-BCBC-FE35C2EF1EDB", v_TENTATIVTEMP);
                }
                MainFrm.DTTObj.EndIfBlk ("98B9469E-C665-489A-9B36-60385B84D3E2");
                MainFrm.DTTObj.AddIf ("975A5EC9-D47E-4888-B6F6-5D796E27B66A", "IF tentativi Temp <= Max Numero Tentativi", "");
                MainFrm.DTTObj.AddToken ("975A5EC9-D47E-4888-B6F6-5D796E27B66A", "B289C7DA-AC2E-4F68-BCBC-FE35C2EF1EDB", 1376256, "tentativi Temp", v_TENTATIVTEMP);
                MainFrm.DTTObj.AddToken ("975A5EC9-D47E-4888-B6F6-5D796E27B66A", "E134B5FD-039A-4A80-8981-A0326B40A791", 1376256, "Max Numero Tentativi", v_MAXNUMERTENT);
                if (v_TENTATIVTEMP.compareTo(v_MAXNUMERTENT, true)<=0)
                {
                  MainFrm.DTTObj.EnterIf ("975A5EC9-D47E-4888-B6F6-5D796E27B66A", "IF tentativi Temp <= Max Numero Tentativi", "");
                  SQL = new StringBuilder();
                  SQL.Append("update SPEDIZIONI set ");
                  SQL.Append("  INFO = " + IDL.CSql(v_ESITOINVIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
                  SQL.Append("  FLG_STATO = 'W', ");
                  SQL.Append("  TENTATIVI = " + IDL.CSql(v_TENTATIVTEMP, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " ");
                  SQL.Append("where (ID = " + IDL.CSql(C4.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
                  MainFrm.DTTObj.AddQuery ("666EAACF-1EBC-4AEF-B5ED-EE8371B869AC", "Spedizioni (Notificatore DB): Update", "", 512, SQL.ToString());
                  MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
                  MainFrm.DTTObj.EndQuery ("666EAACF-1EBC-4AEF-B5ED-EE8371B869AC");
                  MainFrm.DTTObj.AddParameter ("666EAACF-1EBC-4AEF-B5ED-EE8371B869AC", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
                }
                else if (0==0)
                {
                  MainFrm.DTTObj.EnterElse ("F16C065F-1F4B-4F68-82E9-FA7B0255CD04", "ELSE", "", "975A5EC9-D47E-4888-B6F6-5D796E27B66A");
                  SQL = new StringBuilder();
                  SQL.Append("update SPEDIZIONI set ");
                  SQL.Append("  DAT_ELAB = GETDATE(), ");
                  SQL.Append("  INFO = " + IDL.CSql(v_ESITOINVIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
                  SQL.Append("  FLG_STATO = 'E' ");
                  SQL.Append("where (ID = " + IDL.CSql(C4.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
                  MainFrm.DTTObj.AddQuery ("24DDA8AF-5431-4107-89CF-FD2432E507F7", "Spedizioni (Notificatore DB): Update", "", 512, SQL.ToString());
                  MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
                  MainFrm.DTTObj.EndQuery ("24DDA8AF-5431-4107-89CF-FD2432E507F7");
                  MainFrm.DTTObj.AddParameter ("24DDA8AF-5431-4107-89CF-FD2432E507F7", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
                }
                MainFrm.DTTObj.EndIfBlk ("975A5EC9-D47E-4888-B6F6-5D796E27B66A");
              }
              MainFrm.DTTObj.EndIfBlk ("6E244FBB-EF22-4772-862A-53B9EC7B87FD");
            }
            MainFrm.DTTObj.EndIfBlk ("6FA58D24-F285-467F-80A1-36E6B8C45F69");
            C4.MoveNext();
          }
          C4.Close();
          MainFrm.DTTObj.EndForEach ("C537D303-DD8E-4DBB-8BB6-9362CCA0C7A4", "FOR EACH Spedizioni ROW", "Raggruppa le spedizione con lo stesso messaggio\nSono nella fascia oraria prevista per il refresh dei dati...", DTT_C4);
        }
        MainFrm.DTTObj.EndIfBlk ("CA5C7E0A-BD1F-4032-A7D4-EED2518AB480");
        MainFrm.DTTObj.AddSubProc ("8FEF173A-07FE-4740-8C76-6B5868CDD5BC", "Notificatore.Sleep", "");
        MainFrm.DTTObj.AddParameter ("8FEF173A-07FE-4740-8C76-6B5868CDD5BC", "A6C4F106-94D2-471C-B73B-D92DA0BD0E0F", "Numero Secondi", (new IDVariant(1)));
        IDL.Sleep((new IDVariant(1)).intValue()*1000); 
        C2.MoveNext();
      }
      C2.Close();
      MainFrm.DTTObj.EndForEach ("3036A6A3-7527-473A-A41A-75EE734B19D3", "FOR EACH Spedizioni ROW", "Sono in una fascia oraria in cui non devo fare il refresh. Azzero la variabile\nCiclo per ogni applicazione che ha messaggi in coda", DTT_C2);
      MainFrm.DTTObj.ExitProc("0C04D02D-C4B9-48EB-82F8-132493485C80", "Send Win Store Notification", "", 3, "MainFrm");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("0C04D02D-C4B9-48EB-82F8-132493485C80", "Send Win Store Notification", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "SendWinStoreNotification", _e);
      MainFrm.DTTObj.ExitProc("0C04D02D-C4B9-48EB-82F8-132493485C80", "Send Win Store Notification", "", 3, "MainFrm");
      return -1;
    }
  }

  // **********************************************************************
  // Send Win Phone Notification
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // ID Spedizione: Identificativo univoco - Input
  // **********************************************************************
  public int SendWinPhoneNotification (IDVariant IDSpedizione)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;
    IDCachedRowSet C2;
    IDCachedRowSet C4;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("A279D336-588B-409D-A70C-0A87110E2774", "Send Win Phone Notification", "", 3, "MainFrm")) return 0;
      MainFrm.DTTObj.AddParameter ("A279D336-588B-409D-A70C-0A87110E2774", "89CB45E9-E74A-49BD-B1B6-BD76A5929474", "ID Spedizione", IDSpedizione);
      // 
      // Send Win Phone Notification Body
      // Corpo Procedura
      // 
      IDVariant v_MAXNUMERTENT = null;
      MainFrm.DTTObj.AddAssign ("EBBF509D-9A67-4767-8668-4FDEB193DE03", "Max Numero Tentativi := n 3", "", v_MAXNUMERTENT);
      MainFrm.DTTObj.AddToken ("EBBF509D-9A67-4767-8668-4FDEB193DE03", "A59B4CFA-46C3-47DA-A33C-78BF5AFA2264", 589824, "n 3", (new IDVariant(3)));
      v_MAXNUMERTENT = (new IDVariant(3));
      MainFrm.DTTObj.AddAssignNewValue ("EBBF509D-9A67-4767-8668-4FDEB193DE03", "E949F31E-547E-4A08-B9E6-33CEE650CD6C", v_MAXNUMERTENT);
      IDVariant v_IMSGELABORAT = null;
      MainFrm.DTTObj.AddAssign ("FCFD900D-1898-4642-BFB9-A9CEDDD48C14", "i Msg Elaborato := C0", "", v_IMSGELABORAT);
      v_IMSGELABORAT = (new IDVariant(0));
      MainFrm.DTTObj.AddAssignNewValue ("FCFD900D-1898-4642-BFB9-A9CEDDD48C14", "EFC596B5-7F49-4FFE-A9BC-83484951F5B1", v_IMSGELABORAT);
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // Ciclo per ogni applicazione che ha messaggi in coda
      // 
      int DTT_C2 = 0;
      MainFrm.DTTObj.AddForEach ("8D3E89E0-AC60-4AB8-A62F-F806B2656DE5", "FOR EACH Spedizioni ROW", "Sono in una fascia oraria in cui non devo fare il refresh. Azzero la variabile\nCiclo per ogni applicazione che ha messaggi in coda");
      SQL = new StringBuilder();
      SQL.Append("select distinct ");
      SQL.Append("  A.ID_APPLICAZIONE as MIDAPPLICAZI, ");
      SQL.Append("  A.TENTATIVI as NUMETENTSPED ");
      SQL.Append("from ");
      SQL.Append("  SPEDIZIONI A, ");
      SQL.Append("  APPS_PUSH_SETTING B ");
      SQL.Append("where B.ID = A.ID_APPLICAZIONE ");
      SQL.Append("and   (A.FLG_STATO = 'W') ");
      SQL.Append("and   (A.TYPE_OS = '3') ");
      SQL.Append("and   (A.ID = " + IDL.CSql(IDSpedizione, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " OR (" + IDL.CSql(IDSpedizione, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " IS NULL)) ");
      SQL.Append("and   (B.FLG_ATTIVA = 'S') ");
      MainFrm.DTTObj.AddToken ("8D3E89E0-AC60-4AB8-A62F-F806B2656DE5", "8D3E89E0-AC60-4AB8-A62F-F806B2656DE5", 0, "SQL", SQL.ToString());
      C2 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!C2.EOF()) C2.MoveNext();
      MainFrm.DTTObj.EndQuery ("8D3E89E0-AC60-4AB8-A62F-F806B2656DE5");
      MainFrm.DTTObj.AddDBDataSource (C2, SQL);
      while (!C2.EOF())
      {
        DTT_C2 = DTT_C2 + 1;
        if (!MainFrm.DTTObj.CheckLoop("8D3E89E0-AC60-4AB8-A62F-F806B2656DE5", DTT_C2)) break;
        // 
        // 
        // 
        // 
        IDVariant v_TROVATAAPP = new IDVariant(0,IDVariant.INTEGER);
        IDVariant v_VWNXMTEAPPUS = new IDVariant(0,IDVariant.STRING);
        // 
        // Prelevo i dati dell'applicazione
        // 
        SQL = new StringBuilder();
        SQL.Append("select ");
        SQL.Append("  A.WNS_XML as WNXMTEAPPUSE ");
        SQL.Append("from ");
        SQL.Append("  APPS_PUSH_SETTING A ");
        SQL.Append("where (A.ID = " + IDL.CSql(C2.Get("MIDAPPLICAZI"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        SQL.Append("and   (A.FLG_ATTIVA = 'S') ");
        SQL.Append("and   (A.TYPE_OS = '3') ");
        MainFrm.DTTObj.AddQuery ("6A6855B2-F542-4473-B475-436802E9A9A3", "Notificatore DB (Notificatore DB): Select into variables", "Prelevo i dati dell'applicazione", 1280, SQL.ToString());
        QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!QV.EOF()) QV.MoveNext();
        MainFrm.DTTObj.EndQuery ("6A6855B2-F542-4473-B475-436802E9A9A3");
        MainFrm.DTTObj.AddDBDataSource (QV, SQL);
        v_TROVATAAPP = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
        if (!QV.EOF())
        {
          v_VWNXMTEAPPUS = QV.Get("WNXMTEAPPUSE", IDVariant.STRING) ;
          MainFrm.DTTObj.AddToken ("6A6855B2-F542-4473-B475-436802E9A9A3", "7F7BBB99-4B62-4520-97EB-3425F931973C", 1376256, "v Wns Xml Template Apps Push Settings", v_VWNXMTEAPPUS);
        }
        QV.Close();
        // 
        // Se trovo ma configurazione (ovvio)
        // 
        MainFrm.DTTObj.AddIf ("2E4B1BA2-4004-48CF-86E5-1AD90BD228E3", "IF Trovata APP", "Se trovo ma configurazione (ovvio)");
        MainFrm.DTTObj.AddToken ("2E4B1BA2-4004-48CF-86E5-1AD90BD228E3", "3A950D1E-DC08-4AB7-B15B-9F1B98204FE5", 1376256, "Trovata APP", v_TROVATAAPP.booleanValue());
        if (v_TROVATAAPP.booleanValue())
        {
          MainFrm.DTTObj.EnterIf ("2E4B1BA2-4004-48CF-86E5-1AD90BD228E3", "IF Trovata APP", "Se trovo ma configurazione (ovvio)");
          // 
          // Raggruppa le spedizione con lo stesso messaggio
          // Sono nella fascia oraria prevista per il refresh dei
          // dati...
          // 
          int DTT_C4 = 0;
          MainFrm.DTTObj.AddForEach ("8820021B-AC2E-417E-87E4-4488C4AC7681", "FOR EACH Spedizioni ROW", "Raggruppa le spedizione con lo stesso messaggio\nSono nella fascia oraria prevista per il refresh dei dati...");
          SQL = new StringBuilder();
          SQL.Append("select ");
          SQL.Append("  A.ID as ID, ");
          SQL.Append("  REPLACE(A.REG_ID, ' ', '') as RREGID, ");
          SQL.Append("  A.ID_APPLICAZIONE as RIDAPPLICAZI, ");
          SQL.Append("  A.DES_MESSAGGIO as RMESSAGGIO ");
          SQL.Append("from ");
          SQL.Append("  SPEDIZIONI A ");
          SQL.Append("where (A.ID_APPLICAZIONE = " + IDL.CSql(C2.Get("MIDAPPLICAZI"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
          SQL.Append("and   (A.FLG_STATO = 'W') ");
          SQL.Append("and   ((A.DAT_ELAB IS NULL) OR CONVERT (float, GETDATE() - A.DAT_ELAB) > 0.100) ");
          MainFrm.DTTObj.AddToken ("8820021B-AC2E-417E-87E4-4488C4AC7681", "8820021B-AC2E-417E-87E4-4488C4AC7681", 0, "SQL", SQL.ToString());
          C4 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
          C4.setColUnbound(2,true);
          if (!C4.EOF()) C4.MoveNext();
          MainFrm.DTTObj.EndQuery ("8820021B-AC2E-417E-87E4-4488C4AC7681");
          MainFrm.DTTObj.AddDBDataSource (C4, SQL);
          while (!C4.EOF())
          {
            DTT_C4 = DTT_C4 + 1;
            if (!MainFrm.DTTObj.CheckLoop("8820021B-AC2E-417E-87E4-4488C4AC7681", DTT_C4)) break;
            // 
            // Se c'è stato un errore nella generazione dell'access
            // tocken mi fermo
            // 
            MainFrm.DTTObj.AddAssign ("518048F9-637A-43CC-AB28-F99E1A988DB7", "i Msg Elaborato := i Msg Elaborato + 1", "Se c'è stato un errore nella generazione dell'access tocken mi fermo", v_IMSGELABORAT);
            MainFrm.DTTObj.AddToken ("518048F9-637A-43CC-AB28-F99E1A988DB7", "EFC596B5-7F49-4FFE-A9BC-83484951F5B1", 1376256, "i Msg Elaborato", v_IMSGELABORAT);
            v_IMSGELABORAT = IDL.Add(v_IMSGELABORAT, (new IDVariant(1)));
            MainFrm.DTTObj.AddAssignNewValue ("518048F9-637A-43CC-AB28-F99E1A988DB7", "EFC596B5-7F49-4FFE-A9BC-83484951F5B1", v_IMSGELABORAT);
            // 
            // Se ho raggiunto il numero massimo di elaborazioni da
            // effettuare
            // 
            MainFrm.DTTObj.AddIf ("5ED2F40C-16F9-419B-8C4C-5E8907044425", "IF i Msg Elaborato > Glb Max Messaggi C2DN Notificatore", "Se ho raggiunto il numero massimo di elaborazioni da effettuare");
            MainFrm.DTTObj.AddToken ("5ED2F40C-16F9-419B-8C4C-5E8907044425", "EFC596B5-7F49-4FFE-A9BC-83484951F5B1", 1376256, "i Msg Elaborato", v_IMSGELABORAT);
            MainFrm.DTTObj.AddToken ("5ED2F40C-16F9-419B-8C4C-5E8907044425", "6C3C97CC-47BF-405C-BBA3-A78D7A0C270D", 1376256, "Glb Max Messaggi C2DN", GLBMAXMESC2D);
            if (v_IMSGELABORAT.compareTo(GLBMAXMESC2D, true)>0)
            {
              MainFrm.DTTObj.EnterIf ("5ED2F40C-16F9-419B-8C4C-5E8907044425", "IF i Msg Elaborato > Glb Max Messaggi C2DN Notificatore", "Se ho raggiunto il numero massimo di elaborazioni da effettuare");
              MainFrm.DTTObj.AddAssign ("E50B6A4B-C686-4E64-9C7B-3E65BB01EE2F", "i Msg Elaborato := C0", "", v_IMSGELABORAT);
              v_IMSGELABORAT = (new IDVariant(0));
              MainFrm.DTTObj.AddAssignNewValue ("E50B6A4B-C686-4E64-9C7B-3E65BB01EE2F", "EFC596B5-7F49-4FFE-A9BC-83484951F5B1", v_IMSGELABORAT);
              IDVariant v_SMSG = null;
              MainFrm.DTTObj.AddAssign ("FA443E33-C945-4404-AB8E-5A4AA55E48FE", "s Msg := Format Message (\"WinPhone: Ne ho spediti |1. L'ultimo è il |2\", To String (Glb Max Messaggi C2DN Notificatore), To String (ID Spedizione), ??, ??, ??)", "", v_SMSG);
              MainFrm.DTTObj.AddToken ("FA443E33-C945-4404-AB8E-5A4AA55E48FE", "6C3C97CC-47BF-405C-BBA3-A78D7A0C270D", 1376256, "Glb Max Messaggi C2DN", GLBMAXMESC2D);
              MainFrm.DTTObj.AddToken ("FA443E33-C945-4404-AB8E-5A4AA55E48FE", "74E9EFA7-CBB0-436A-87FE-4C296B7342A0", 1376256, "ID Spedizione", C4.Get("ID"));
              v_SMSG = IDL.FormatMessage((new IDVariant("WinPhone: Ne ho spediti |1. L'ultimo è il |2")), IDL.ToString(GLBMAXMESC2D), IDL.ToString(C4.Get("ID")));
              MainFrm.DTTObj.AddAssignNewValue ("FA443E33-C945-4404-AB8E-5A4AA55E48FE", "73BD346A-884A-41DE-A3E2-39BF2742DB2C", v_SMSG);
              MainFrm.DTTObj.AddSubProc ("6912C978-CCE5-4E09-A466-D3FE8299837F", "Notificatore.Write Debug", "");
              WriteDebug(v_SMSG, (new IDVariant(2)), (new IDVariant("Server session Win Phone")));
              MainFrm.DTTObj.AddBreak ("10493F98-7B81-4E72-AB9B-B02618621763", "BREAK", "");
              break;
            }
            MainFrm.DTTObj.EndIfBlk ("5ED2F40C-16F9-419B-8C4C-5E8907044425");
            IDVariant v_ESITOINVIO = new IDVariant(0,IDVariant.STRING);
            IDVariant v_SRET = null;
            MainFrm.DTTObj.AddAssign ("729C2AFF-60AC-4AB4-A794-6B101EA1D29D", "s Ret := Wnshelperinde.SendWinPhonePushNotification (r Reg ID Spedizione, r Messaggio Spedizione, esito Invio)", "", v_SRET);
            MainFrm.DTTObj.AddToken ("729C2AFF-60AC-4AB4-A794-6B101EA1D29D", "B1DDBAAA-7455-4BE5-A1C3-00B986BE37DF", 1376256, "r Reg ID", C4.Get("RREGID"));
            MainFrm.DTTObj.AddToken ("729C2AFF-60AC-4AB4-A794-6B101EA1D29D", "0E07224A-DE7F-4F72-8237-1A372266E95C", 1376256, "r Messaggio", C4.Get("RMESSAGGIO"));
            MainFrm.DTTObj.AddToken ("729C2AFF-60AC-4AB4-A794-6B101EA1D29D", "255034BC-C292-43C5-9404-4A179ECBA694", 1376256, "esito Invio", v_ESITOINVIO);
            v_SRET = new IDVariant(WNSHelperInde.SendWinPhonePushNotification(C4.Get("RREGID").stringValue(), C4.Get("RMESSAGGIO").stringValue(), out v_ESITOINVIO));
            MainFrm.DTTObj.AddAssignNewValue ("729C2AFF-60AC-4AB4-A794-6B101EA1D29D", "2AA8AD81-C1A3-4CE8-B46D-50B3D88EE4AE", v_SRET);
            // 
            // Controllo del risultato
            // 
            MainFrm.DTTObj.AddIf ("1E82F039-7E5C-4CA6-86FA-8D446E4C877F", "IF s Ret == OK", "Controllo del risultato");
            MainFrm.DTTObj.AddToken ("1E82F039-7E5C-4CA6-86FA-8D446E4C877F", "2AA8AD81-C1A3-4CE8-B46D-50B3D88EE4AE", 1376256, "s Ret", v_SRET);
            MainFrm.DTTObj.AddToken ("1E82F039-7E5C-4CA6-86FA-8D446E4C877F", "842D718B-55AF-4B17-8AB0-E7BD7541174B", 589824, "OK", (new IDVariant(-1)));
            if (v_SRET.equals((new IDVariant(-1)), true))
            {
              MainFrm.DTTObj.EnterIf ("1E82F039-7E5C-4CA6-86FA-8D446E4C877F", "IF s Ret == OK", "Controllo del risultato");
              SQL = new StringBuilder();
              SQL.Append("update SPEDIZIONI set ");
              SQL.Append("  DAT_ELAB = GETDATE(), ");
              SQL.Append("  INFO = " + IDL.CSql(v_ESITOINVIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  FLG_STATO = 'S' ");
              SQL.Append("where (ID = " + IDL.CSql(C4.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
              MainFrm.DTTObj.AddQuery ("2CA15B06-07B7-431C-AC77-222A2C71A9E1", "Spedizioni (Notificatore DB): Update", "", 512, SQL.ToString());
              MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
              MainFrm.DTTObj.EndQuery ("2CA15B06-07B7-431C-AC77-222A2C71A9E1");
              MainFrm.DTTObj.AddParameter ("2CA15B06-07B7-431C-AC77-222A2C71A9E1", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
            }
            else if (0==0)
            {
              MainFrm.DTTObj.EnterElse ("8FF668CF-6F89-4C1A-AD36-39E70DAD903E", "ELSE", "", "1E82F039-7E5C-4CA6-86FA-8D446E4C877F");
              MainFrm.DTTObj.AddIf ("41049C21-A359-4C42-9BB2-26B04FB5C870", "IF s Ret == Generic Exception", "");
              MainFrm.DTTObj.AddToken ("41049C21-A359-4C42-9BB2-26B04FB5C870", "2AA8AD81-C1A3-4CE8-B46D-50B3D88EE4AE", 1376256, "s Ret", v_SRET);
              MainFrm.DTTObj.AddToken ("41049C21-A359-4C42-9BB2-26B04FB5C870", "BB52A97D-598D-4DA5-AB5C-93164B8D2640", 589824, "Generic Exception", (new IDVariant(199)));
              if (v_SRET.equals((new IDVariant(199)), true))
              {
                MainFrm.DTTObj.EnterIf ("41049C21-A359-4C42-9BB2-26B04FB5C870", "IF s Ret == Generic Exception", "");
                IDVariant v_TENTATIVTEMP = null;
                MainFrm.DTTObj.AddAssign ("64C54226-03C7-4336-B204-FF7E1D7FF012", "tentativi Temp := n 1", "", v_TENTATIVTEMP);
                MainFrm.DTTObj.AddToken ("64C54226-03C7-4336-B204-FF7E1D7FF012", "259692C8-9CC4-43D4-8159-184C0B3BA071", 589824, "n 1", (new IDVariant(1)));
                v_TENTATIVTEMP = (new IDVariant(1));
                MainFrm.DTTObj.AddAssignNewValue ("64C54226-03C7-4336-B204-FF7E1D7FF012", "416D96B6-6277-4E2A-B63B-EDB5EA3B4495", v_TENTATIVTEMP);
                MainFrm.DTTObj.AddIf ("47A8A772-8E85-4AD9-A070-1F78BF86B45D", "IF not (Is Null (Numero Tentativi Spedizione))", "");
                MainFrm.DTTObj.AddToken ("47A8A772-8E85-4AD9-A070-1F78BF86B45D", "99910140-6B95-4C46-BD7B-35354EE28D1E", 1376256, "Numero Tentativi Spedizione", C2.Get("NUMETENTSPED"));
                if (!(IDL.IsNull(C2.Get("NUMETENTSPED"))))
                {
                  MainFrm.DTTObj.EnterIf ("47A8A772-8E85-4AD9-A070-1F78BF86B45D", "IF not (Is Null (Numero Tentativi Spedizione))", "");
                  MainFrm.DTTObj.AddAssign ("02FD4FB6-E27D-4685-BFB5-2E680B238128", "tentativi Temp := Numero Tentativi Spedizione + n 1", "", v_TENTATIVTEMP);
                  MainFrm.DTTObj.AddToken ("02FD4FB6-E27D-4685-BFB5-2E680B238128", "99910140-6B95-4C46-BD7B-35354EE28D1E", 1376256, "Numero Tentativi Spedizione", C2.Get("NUMETENTSPED"));
                  MainFrm.DTTObj.AddToken ("02FD4FB6-E27D-4685-BFB5-2E680B238128", "259692C8-9CC4-43D4-8159-184C0B3BA071", 589824, "n 1", (new IDVariant(1)));
                  v_TENTATIVTEMP = IDL.Add(C2.Get("NUMETENTSPED"), (new IDVariant(1)));
                  MainFrm.DTTObj.AddAssignNewValue ("02FD4FB6-E27D-4685-BFB5-2E680B238128", "416D96B6-6277-4E2A-B63B-EDB5EA3B4495", v_TENTATIVTEMP);
                }
                MainFrm.DTTObj.EndIfBlk ("47A8A772-8E85-4AD9-A070-1F78BF86B45D");
                MainFrm.DTTObj.AddIf ("D86C56F4-316D-4409-803C-CE3F8DCDEDDF", "IF tentativi Temp <= Max Numero Tentativi", "");
                MainFrm.DTTObj.AddToken ("D86C56F4-316D-4409-803C-CE3F8DCDEDDF", "416D96B6-6277-4E2A-B63B-EDB5EA3B4495", 1376256, "tentativi Temp", v_TENTATIVTEMP);
                MainFrm.DTTObj.AddToken ("D86C56F4-316D-4409-803C-CE3F8DCDEDDF", "E949F31E-547E-4A08-B9E6-33CEE650CD6C", 1376256, "Max Numero Tentativi", v_MAXNUMERTENT);
                if (v_TENTATIVTEMP.compareTo(v_MAXNUMERTENT, true)<=0)
                {
                  MainFrm.DTTObj.EnterIf ("D86C56F4-316D-4409-803C-CE3F8DCDEDDF", "IF tentativi Temp <= Max Numero Tentativi", "");
                  SQL = new StringBuilder();
                  SQL.Append("update SPEDIZIONI set ");
                  SQL.Append("  INFO = " + IDL.CSql(v_ESITOINVIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
                  SQL.Append("  FLG_STATO = 'W', ");
                  SQL.Append("  TENTATIVI = " + IDL.CSql(v_TENTATIVTEMP, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " ");
                  SQL.Append("where (ID = " + IDL.CSql(C4.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
                  MainFrm.DTTObj.AddQuery ("3BAE598B-612D-444C-BD81-CF5C48617641", "Spedizioni (Notificatore DB): Update", "", 512, SQL.ToString());
                  MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
                  MainFrm.DTTObj.EndQuery ("3BAE598B-612D-444C-BD81-CF5C48617641");
                  MainFrm.DTTObj.AddParameter ("3BAE598B-612D-444C-BD81-CF5C48617641", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
                }
                else if (0==0)
                {
                  MainFrm.DTTObj.EnterElse ("CEA8951B-2444-4075-8F0A-2A16C01257A4", "ELSE", "", "D86C56F4-316D-4409-803C-CE3F8DCDEDDF");
                  SQL = new StringBuilder();
                  SQL.Append("update SPEDIZIONI set ");
                  SQL.Append("  DAT_ELAB = GETDATE(), ");
                  SQL.Append("  INFO = " + IDL.CSql(v_ESITOINVIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
                  SQL.Append("  FLG_STATO = 'E' ");
                  SQL.Append("where (ID = " + IDL.CSql(C4.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
                  MainFrm.DTTObj.AddQuery ("C6FC3D2E-E9FD-40E5-A210-AD3E9AC34F1B", "Spedizioni (Notificatore DB): Update", "", 512, SQL.ToString());
                  MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
                  MainFrm.DTTObj.EndQuery ("C6FC3D2E-E9FD-40E5-A210-AD3E9AC34F1B");
                  MainFrm.DTTObj.AddParameter ("C6FC3D2E-E9FD-40E5-A210-AD3E9AC34F1B", "", "Records affected", MainFrm.NotificatoreDBObject.DBO().RecordsAffected());
                }
                MainFrm.DTTObj.EndIfBlk ("D86C56F4-316D-4409-803C-CE3F8DCDEDDF");
              }
              MainFrm.DTTObj.EndIfBlk ("41049C21-A359-4C42-9BB2-26B04FB5C870");
            }
            MainFrm.DTTObj.EndIfBlk ("1E82F039-7E5C-4CA6-86FA-8D446E4C877F");
            C4.MoveNext();
          }
          C4.Close();
          MainFrm.DTTObj.EndForEach ("8820021B-AC2E-417E-87E4-4488C4AC7681", "FOR EACH Spedizioni ROW", "Raggruppa le spedizione con lo stesso messaggio\nSono nella fascia oraria prevista per il refresh dei dati...", DTT_C4);
        }
        MainFrm.DTTObj.EndIfBlk ("2E4B1BA2-4004-48CF-86E5-1AD90BD228E3");
        MainFrm.DTTObj.AddSubProc ("84ED0779-4552-4F90-A31C-F26F5414731C", "Notificatore.Sleep", "");
        MainFrm.DTTObj.AddParameter ("84ED0779-4552-4F90-A31C-F26F5414731C", "785DF525-C9EE-4CE5-BA34-C33EDE9E21A3", "Numero Secondi", (new IDVariant(1)));
        IDL.Sleep((new IDVariant(1)).intValue()*1000); 
        C2.MoveNext();
      }
      C2.Close();
      MainFrm.DTTObj.EndForEach ("8D3E89E0-AC60-4AB8-A62F-F806B2656DE5", "FOR EACH Spedizioni ROW", "Sono in una fascia oraria in cui non devo fare il refresh. Azzero la variabile\nCiclo per ogni applicazione che ha messaggi in coda", DTT_C2);
      MainFrm.DTTObj.ExitProc("A279D336-588B-409D-A70C-0A87110E2774", "Send Win Phone Notification", "", 3, "MainFrm");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("A279D336-588B-409D-A70C-0A87110E2774", "Send Win Phone Notification", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "SendWinPhoneNotification", _e);
      MainFrm.DTTObj.ExitProc("A279D336-588B-409D-A70C-0A87110E2774", "Send Win Phone Notification", "", 3, "MainFrm");
      return -1;
    }
  }

  // **********************************************************************
  // Nuova Procedura
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int NuovaProcedura ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("13E78139-1F94-4DAF-977E-CA12E2C6D5B3", "Nuova Procedura", "", 3, "MainFrm")) return 0;
      // 
      // Nuova Procedura Body
      // Corpo Procedura
      // 
      IDVariant v_SPAYLOAD = null;
      MainFrm.DTTObj.AddAssign ("01A22DD9-D47D-4571-B92A-E0AF4B5AF65C", "s Payload := Notification Payload", "", v_SPAYLOAD);
      MainFrm.DTTObj.AddToken ("01A22DD9-D47D-4571-B92A-E0AF4B5AF65C", "AAFD617A-EE1A-43C2-9635-3B57E954A66D", 589824, "Notification Payload", (new IDVariant("{\n    \"aps\" : {\n        \"alert\" : \"|1\",\n        \"badge\" : |2,\n        \"sound\" : \"|3\"\n    },\n    \"custom-field-1\" : \"|4\",\n    \"custom-field-2\" : \"|5\"\n}")));
      v_SPAYLOAD = (new IDVariant("{\n    \"aps\" : {\n        \"alert\" : \"|1\",\n        \"badge\" : |2,\n        \"sound\" : \"|3\"\n    },\n    \"custom-field-1\" : \"|4\",\n    \"custom-field-2\" : \"|5\"\n}"));
      MainFrm.DTTObj.AddAssignNewValue ("01A22DD9-D47D-4571-B92A-E0AF4B5AF65C", "0B913621-12ED-408C-9D36-555631BD2C19", v_SPAYLOAD);
      System.Security.Cryptography.X509Certificates.X509Certificate2 v_XC = null;
      MainFrm.DTTObj.AddAssign ("F6E1A82D-AD0C-43A1-98F4-93B8C804B69F", "xc := xc.New Instance (\"c:\\CertsApex\\iGamma.p12\")", "", v_XC);
      v_XC = new System.Security.Cryptography.X509Certificates.X509Certificate2(System.IO.File.ReadAllBytes((new IDVariant("c:\\CertsApex\\iGamma.p12")).stringValue()));
      MainFrm.DTTObj.AddAssignNewValue ("F6E1A82D-AD0C-43A1-98F4-93B8C804B69F", "EFA1CF83-E03C-41A2-8F88-1823F3206A89", v_XC);
      PushSharp.Apple.ApnsConfiguration v_AC = null;
      MainFrm.DTTObj.AddAssign ("6DF13079-E0F0-477E-B4EE-C1ADEDBBBDBB", "ac := ac.new Instance (Production, xc)", "", v_AC);
      MainFrm.DTTObj.AddToken ("6DF13079-E0F0-477E-B4EE-C1ADEDBBBDBB", "282C6F43-D185-4BAE-9BFB-172ADDDCF9A1", 589824, "Production", (new IDVariant(1)).booleanValue());
      if (v_XC != null) MainFrm.DTTObj.AddToken ("6DF13079-E0F0-477E-B4EE-C1ADEDBBBDBB", "EFA1CF83-E03C-41A2-8F88-1823F3206A89", 1376256, "xc", v_XC);
      v_AC = new PushSharp.Apple.ApnsConfiguration((new IDVariant(1)).booleanValue() ? PushSharp.Apple.ApnsConfiguration.ApnsServerEnvironment.Production : PushSharp.Apple.ApnsConfiguration.ApnsServerEnvironment.Sandbox, v_XC);
      MainFrm.DTTObj.AddAssignNewValue ("6DF13079-E0F0-477E-B4EE-C1ADEDBBBDBB", "24BC377F-680D-4FA4-BA6D-91A66F1E7C44", v_AC);
      PushSharp.Apple.ApnsServiceBroker v_PB = null;
      MainFrm.DTTObj.AddAssign ("64873B54-DA3F-4480-A31D-919A93A9DAC0", "pb := pb.new Instance (ac)", "", v_PB);
      if (v_AC != null) MainFrm.DTTObj.AddToken ("64873B54-DA3F-4480-A31D-919A93A9DAC0", "24BC377F-680D-4FA4-BA6D-91A66F1E7C44", 1376256, "ac", v_AC);
      v_PB = new PushSharp.Apple.ApnsServiceBroker(v_AC);
      MainFrm.DTTObj.AddAssignNewValue ("64873B54-DA3F-4480-A31D-919A93A9DAC0", "418F95AE-B0FE-495D-A9E0-B59EDF722B05", v_PB);
      MainFrm.DTTObj.AddSubProc ("55F810B7-856A-41B5-A6C1-4DFF0FB52EE2", "pb.Connect events", "");
      v_PB.OnNotificationSucceeded += PushSharpHelper.NotificationSucceeded;
      v_PB.OnNotificationFailed += PushSharpHelper.NotificationFailed;
      MainFrm.DTTObj.AddSubProc ("8F2294B4-CE8B-46F0-A0CA-4506AD27E715", "pb.Start", "");
      v_PB.Start();
      // 
      // inizio for
      // 
      PushSharp.Apple.ApnsNotification v_APN = null;
      MainFrm.DTTObj.AddAssign ("5A63F135-5859-451C-9DC4-4E153CF4ED23", "apn := new ()", "", v_APN);
      v_APN = (PushSharp.Apple.ApnsNotification)new PushSharp.Apple.ApnsNotification();
      MainFrm.DTTObj.AddAssignNewValue ("5A63F135-5859-451C-9DC4-4E153CF4ED23", "AA4953E3-2702-4A88-998F-DE1EC37DEAD1", v_APN);
      MainFrm.DTTObj.AddAssign ("5CA4AD2B-539D-4F93-A32F-CDEE0B5DE481", "apn.Device Token := C\"eda973193dd8a008bd2070bec978b87173c294dea81d1cf289ec69f21cd427fa\"", "", v_APN.DeviceToken);
      v_APN.DeviceToken = (new IDVariant("eda973193dd8a008bd2070bec978b87173c294dea81d1cf289ec69f21cd427fa")).stringValue();
      MainFrm.DTTObj.AddAssignNewValue ("5CA4AD2B-539D-4F93-A32F-CDEE0B5DE481", "AA4953E3-2702-4A88-998F-DE1EC37DEAD1", v_APN.DeviceToken);
      MainFrm.DTTObj.AddAssign ("32AEBC69-A8B3-4D7C-B944-5CC324F6043D", "s Payload := Format Message (s Payload, \"alert\", \"badge\", \"\", \"cf1\", \"cf2\")", "", v_SPAYLOAD);
      MainFrm.DTTObj.AddToken ("32AEBC69-A8B3-4D7C-B944-5CC324F6043D", "0B913621-12ED-408C-9D36-555631BD2C19", 1376256, "s Payload", v_SPAYLOAD);
      v_SPAYLOAD = IDL.FormatMessage(v_SPAYLOAD, (new IDVariant("alert")), (new IDVariant("badge")), (new IDVariant("")), (new IDVariant("cf1")), (new IDVariant("cf2")));
      MainFrm.DTTObj.AddAssignNewValue ("32AEBC69-A8B3-4D7C-B944-5CC324F6043D", "0B913621-12ED-408C-9D36-555631BD2C19", v_SPAYLOAD);
      MainFrm.DTTObj.AddSubProc ("EE926981-F72D-4843-86AB-8CA4B1C9685C", "apn.Payload", "");
      MainFrm.DTTObj.AddParameter ("EE926981-F72D-4843-86AB-8CA4B1C9685C", "84FE4685-2829-474F-85F6-C943872B334B", "Payload", v_SPAYLOAD);
      v_APN.Payload = Newtonsoft.Json.Linq.JObject.Parse(v_SPAYLOAD.stringValue()); 
      MainFrm.DTTObj.AddSubProc ("0E95BDCE-CFC5-4750-8A11-CE8BE052EA15", "pb.QueueNotification", "");
      MainFrm.DTTObj.AddParameter ("0E95BDCE-CFC5-4750-8A11-CE8BE052EA15", "911AF700-8931-4E4D-9E66-AD0F2F1B038C", "Apple notification", v_APN);
      v_PB.QueueNotification(v_APN); 
      // 
      // fine for
      // 
      MainFrm.DTTObj.AddSubProc ("908AEBE4-7E37-4244-8E7B-29DC57E7D642", "pb.Stop", "fine for");
      v_PB.Stop(false);
      MainFrm.DTTObj.ExitProc("13E78139-1F94-4DAF-977E-CA12E2C6D5B3", "Nuova Procedura", "", 3, "MainFrm");
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("13E78139-1F94-4DAF-977E-CA12E2C6D5B3", "Nuova Procedura", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "NuovaProcedura", _e);
      MainFrm.DTTObj.ExitProc("13E78139-1F94-4DAF-977E-CA12E2C6D5B3", "Nuova Procedura", "", 3, "MainFrm");
      return -1;
    }
  }

  // **********************************************************************
  // Json Stringfy
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Data:  - Input
  // **********************************************************************
  public IDVariant JsonStringfy (IDVariant Data)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("E71D0711-23F6-408E-9FEF-F128B7B3F638", "Json Stringfy", "", 2, "MainFrm")) return new IDVariant();
      MainFrm.DTTObj.AddParameter ("E71D0711-23F6-408E-9FEF-F128B7B3F638", "C0A923D1-7B0C-4BB5-95A9-E5C981D3B95E", "Data", Data);
      // 
      // Json Stringfy Body
      // Corpo Procedura
      // 
      IDVariant v_SRETVAL = null;
      MainFrm.DTTObj.AddAssign ("E61ACF92-11C2-44F7-9F1D-711EF5683D2D", "s Ret Val := Data", "", v_SRETVAL);
      MainFrm.DTTObj.AddToken ("E61ACF92-11C2-44F7-9F1D-711EF5683D2D", "C0A923D1-7B0C-4BB5-95A9-E5C981D3B95E", 1376256, "Data", new IDVariant(Data));
      v_SRETVAL = new IDVariant(Data);
      MainFrm.DTTObj.AddAssignNewValue ("E61ACF92-11C2-44F7-9F1D-711EF5683D2D", "B8A17EA1-D350-4955-A866-AC8874F1047B", v_SRETVAL);
      MainFrm.DTTObj.AddAssign ("C17D5844-0C16-4007-B1E3-1ADDFED439BD", "s Ret Val := Replace (s Ret Val, \"\"\", \"\\\"\")", "", v_SRETVAL);
      MainFrm.DTTObj.AddToken ("C17D5844-0C16-4007-B1E3-1ADDFED439BD", "B8A17EA1-D350-4955-A866-AC8874F1047B", 1376256, "s Ret Val", v_SRETVAL);
      v_SRETVAL = IDL.Replace(v_SRETVAL, (new IDVariant("\"")), (new IDVariant("\\\"")));
      MainFrm.DTTObj.AddAssignNewValue ("C17D5844-0C16-4007-B1E3-1ADDFED439BD", "B8A17EA1-D350-4955-A866-AC8874F1047B", v_SRETVAL);
      MainFrm.DTTObj.AddReturn ("10351492-DB8B-4E38-8CD5-75DA5354CE9A", "RETURN s Ret Val", "", v_SRETVAL);
      MainFrm.DTTObj.ExitProc ("E71D0711-23F6-408E-9FEF-F128B7B3F638", "Json Stringfy", "Spiega quale elaborazione viene eseguita da questa procedura", 2, "MainFrm");
      return v_SRETVAL;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("E71D0711-23F6-408E-9FEF-F128B7B3F638", "Json Stringfy", "", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "JsonStringfy", _e);
      MainFrm.DTTObj.ExitProc("E71D0711-23F6-408E-9FEF-F128B7B3F638", "Json Stringfy", "", 2, "MainFrm");
      return new IDVariant();
    }
  }

  // **********************************************************************
  // Esegue Login
  // Esegue il login
  // e Mail - Input
  // Password - Input
  // **********************************************************************
  public bool EsegueLogin (IDVariant eMail, IDVariant Password)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;

      if (!MainFrm.DTTObj.EnterProc("DA6EA772-5919-4E8F-8C1F-9C1118427D96", "Esegue Login", "Esegue il login", 2, "MainFrm")) return false;
      MainFrm.DTTObj.AddParameter ("DA6EA772-5919-4E8F-8C1F-9C1118427D96", "00ADAAD5-B3A3-4172-8F85-0A78EFD16225", "e Mail", eMail);
      MainFrm.DTTObj.AddParameter ("DA6EA772-5919-4E8F-8C1F-9C1118427D96", "1CD434DD-AED1-4BCB-9650-54237D24254A", "Password", Password);
      // 
      // Esegue Login Body
      // Corpo Procedura
      // 
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.ID as IDUTENTE, ");
      SQL.Append("  A.COGNOME as COGNOMUTENTE, ");
      SQL.Append("  A.NOME as NOMEUTENTE ");
      SQL.Append("from ");
      SQL.Append("  UTENTI A ");
      SQL.Append("where (A.EMAIL = " + IDL.CSql(eMail, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      SQL.Append("and   (A.DES_PASSWORD = " + IDL.CSql(Password, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
      MainFrm.DTTObj.AddQuery ("16E88805-D1FD-44F6-A59C-4F6C95A3B681", "Notificatore DB (Notificatore DB): Select into variables", "", 1280, SQL.ToString());
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      MainFrm.DTTObj.EndQuery ("16E88805-D1FD-44F6-A59C-4F6C95A3B681");
      MainFrm.DTTObj.AddDBDataSource (QV, SQL);
      if (!QV.EOF())
      {
        IMDB.set_Value(IMDBDef1.TBL_DATISESSIONE, IMDBDef1.FLD_DATISESSIONE_IDUTENTSESSI, 0, QV.Get("IDUTENTE", IDVariant.INTEGER));
        MainFrm.DTTObj.AddToken ("16E88805-D1FD-44F6-A59C-4F6C95A3B681", "13569EA0-7EC0-45F3-B470-1F781D2A5C05", 1376256, "ID Utente Sessione", IMDB.Value(IMDBDef1.TBL_DATISESSIONE, IMDBDef1.FLD_DATISESSIONE_IDUTENTSESSI, 0));
        IMDB.set_Value(IMDBDef1.TBL_DATISESSIONE, IMDBDef1.FLD_DATISESSIONE_COGNUTENSESS, 0, QV.Get("COGNOMUTENTE", IDVariant.STRING));
        MainFrm.DTTObj.AddToken ("16E88805-D1FD-44F6-A59C-4F6C95A3B681", "34B84E82-5381-4E0D-8598-79E07A86A8F2", 1376256, "Cognome Utente Sessione", IMDB.Value(IMDBDef1.TBL_DATISESSIONE, IMDBDef1.FLD_DATISESSIONE_COGNUTENSESS, 0));
        IMDB.set_Value(IMDBDef1.TBL_DATISESSIONE, IMDBDef1.FLD_DATISESSIONE_NOMEUTENSESS, 0, QV.Get("NOMEUTENTE", IDVariant.STRING));
        MainFrm.DTTObj.AddToken ("16E88805-D1FD-44F6-A59C-4F6C95A3B681", "1D9C8DE2-A9D4-4788-9FC4-028DA3A25ADB", 1376256, "Nome Utente Sessione", IMDB.Value(IMDBDef1.TBL_DATISESSIONE, IMDBDef1.FLD_DATISESSIONE_NOMEUTENSESS, 0));
      }
      QV.Close();
      // 
      // Se ho eseguito il login salvo i dati e torno vero
      // 
      MainFrm.DTTObj.AddIf ("A280B841-B12C-4AFC-8104-755D454DF3C7", "IF ID Utente Sessione > 0", "Se ho eseguito il login salvo i dati e torno vero");
      MainFrm.DTTObj.AddToken ("A280B841-B12C-4AFC-8104-755D454DF3C7", "13569EA0-7EC0-45F3-B470-1F781D2A5C05", 327680, "ID Utente", IMDB.Value(IMDBDef1.TBL_DATISESSIONE, IMDBDef1.FLD_DATISESSIONE_IDUTENTSESSI, 0));
      if (IMDB.Value(IMDBDef1.TBL_DATISESSIONE, IMDBDef1.FLD_DATISESSIONE_IDUTENTSESSI, 0).compareTo((new IDVariant(0)), true)>0)
      {
        MainFrm.DTTObj.EnterIf ("A280B841-B12C-4AFC-8104-755D454DF3C7", "IF ID Utente Sessione > 0", "Se ho eseguito il login salvo i dati e torno vero");
        MainFrm.DTTObj.AddSubProc ("070EED45-E916-481A-A4F9-42203B21939B", "Notificatore.Save Setting", "");
        MainFrm.DTTObj.AddParameter ("070EED45-E916-481A-A4F9-42203B21939B", "C7C84337-E338-4D37-829B-4D6B150DFF27", "Sezione", (new IDVariant("icalcio")));
        MainFrm.DTTObj.AddParameter ("070EED45-E916-481A-A4F9-42203B21939B", "9ABE797C-B742-4350-8860-CA5F8A07BC2C", "Chiave", (new IDVariant("email")));
        MainFrm.DTTObj.AddParameter ("070EED45-E916-481A-A4F9-42203B21939B", "DA3608A7-5859-44FA-BB81-1A9CF8B2C8CF", "Valore", eMail);
        MainFrm.SaveSetting((new IDVariant("icalcio")),(new IDVariant("email")),eMail); 
        MainFrm.DTTObj.AddSubProc ("EB43B7CC-C5DA-476D-BAAC-83E58D7F1D79", "Notificatore.Save Setting", "");
        MainFrm.DTTObj.AddParameter ("EB43B7CC-C5DA-476D-BAAC-83E58D7F1D79", "5A2DCBA1-2561-44DF-BA5F-3C6120D5B849", "Sezione", (new IDVariant("icalcio")));
        MainFrm.DTTObj.AddParameter ("EB43B7CC-C5DA-476D-BAAC-83E58D7F1D79", "2ED27467-20A8-4159-A837-648FD34B67AD", "Chiave", (new IDVariant("password")));
        MainFrm.DTTObj.AddParameter ("EB43B7CC-C5DA-476D-BAAC-83E58D7F1D79", "D01D7BF5-4484-4686-899B-CF262F68B59E", "Valore", Password);
        MainFrm.SaveSetting((new IDVariant("icalcio")),(new IDVariant("password")),Password); 
        MainFrm.DTTObj.AddAssign ("673A40F3-6EB6-4EF8-BFA3-A0CDA44AFDD2", "Notificatore.User Role := Utente normale", "", MainFrm.UserRole());
        MainFrm.DTTObj.AddToken ("673A40F3-6EB6-4EF8-BFA3-A0CDA44AFDD2", "85A340A5-A8F4-11D4-8F26-0860F2000000", 589824, "Utente normale", (new IDVariant(3)));
        MainFrm.set_UserRole((new IDVariant(3)));
        MainFrm.DTTObj.AddAssignNewValue ("673A40F3-6EB6-4EF8-BFA3-A0CDA44AFDD2", "5D17ACB6-0F41-4CB8-BE2D-0F961D66BA84", MainFrm.UserRole());
        MainFrm.DTTObj.AddReturn ("925B5E7D-EA83-4E84-A2E3-D781CDDF4759", "RETURN true", "", (new IDVariant(-1)).booleanValue());
        MainFrm.DTTObj.ExitProc ("DA6EA772-5919-4E8F-8C1F-9C1118427D96", "Esegue Login", "Esegue il login", 2, "MainFrm");
        return (new IDVariant(-1)).booleanValue();
      }
      else if (0==0)
      {
        MainFrm.DTTObj.EnterElse ("45FED8DF-D72E-4D01-B4B8-8A1C0C8D9796", "ELSE", "", "A280B841-B12C-4AFC-8104-755D454DF3C7");
        MainFrm.DTTObj.AddAssign ("8C1B72B6-708D-4289-B1C5-1274CFE7ECB5", "Notificatore.User Role := Anonimo", "", MainFrm.UserRole());
        MainFrm.DTTObj.AddToken ("8C1B72B6-708D-4289-B1C5-1274CFE7ECB5", "85A340B7-A8F4-11D4-8F26-0860F2000000", 589824, "Anonimo", (new IDVariant(5)));
        MainFrm.set_UserRole((new IDVariant(5)));
        MainFrm.DTTObj.AddAssignNewValue ("8C1B72B6-708D-4289-B1C5-1274CFE7ECB5", "5D17ACB6-0F41-4CB8-BE2D-0F961D66BA84", MainFrm.UserRole());
        MainFrm.DTTObj.AddReturn ("2F7BDEBB-2AD1-4BF9-BD2D-47472DAA191C", "RETURN false", "", (new IDVariant(0)).booleanValue());
        MainFrm.DTTObj.ExitProc ("DA6EA772-5919-4E8F-8C1F-9C1118427D96", "Esegue Login", "Esegue il login", 2, "MainFrm");
        return (new IDVariant(0)).booleanValue();
      }
      MainFrm.DTTObj.EndIfBlk ("A280B841-B12C-4AFC-8104-755D454DF3C7");
      return false;
    }
    catch (Exception _e)
    {
      MainFrm.DTTObj.AddException("DA6EA772-5919-4E8F-8C1F-9C1118427D96", "Esegue Login", "Esegue il login", _e);
      MainFrm.ErrObj.ProcError ("Notificatore", "EsegueLogin", _e);
      MainFrm.DTTObj.ExitProc("DA6EA772-5919-4E8F-8C1F-9C1118427D96", "Esegue Login", "Esegue il login", 2, "MainFrm");
      return false;
    }
  }



  // **********************************************
  // Event Stubs
  // **********************************************
  // **********************************************************************
  // Terminate
  // Evento notificato dall'applicazione subito prima della
  // chiusura della sessione utente
  // **********************************************************************
  public void TerminateApp ()
  {
    DispatchToComp("TerminateApp", new Object[] {});
    //
    // Stub
  }

  // **********************************************************************
  // On Resize
  // Evento notificato dall'applicazione quando cambiano
  // le dimensioni del browser
  // **********************************************************************
  public void OnResize()
  {
    DispatchToComp("OnResize", new Object[] {});
    //
    // Stub
  }

  // **********************************************************************
  // On Table Substitution
  // Evento notificato dall'applicazione quando viene eseguita
  // una query e nella from list di questa è contenuta una
  // tabella su cui è stato attivato il flag "Sostituzione
  // tabella"
  // **********************************************************************
  public void OnTableSubstitution(IDVariant PreviousTableCode, IDVariant Join, IDVariant TableCode, IDVariant Reason)
  {
    DispatchToComp("OnTableSubstitution", new Object[] {PreviousTableCode, Join, TableCode, Reason});
    //
    // Stub
  }

  // **********************************************************************
  // Service Started
  // Evento notificato dall'applicazione quando il servizio
  // viene avviato
  // **********************************************************************
  private void NTStartService(IDVariant Success)
  {
    DispatchToComp("NTStartService", new Object[] {Success});
    //
    // Stub
  }

  // **********************************************************************
  // Service Stopped
  // Evento notificato dall'applicazione quando il servizio
  // viene fermato
  // **********************************************************************
  private void NTStopService()
  {
    DispatchToComp("NTStopService", new Object[] {});
    //
    // Stub
  }

  // **********************************************************************
  // Service Paused
  // Evento notificato dall'applicazione quando il servizio
  // viene messo in pausa
  // **********************************************************************
  private void NTPauseService(IDVariant Success)
  {
    DispatchToComp("NTPauseService", new Object[] {Success});
    //
    // Stub
  }

  // **********************************************************************
  // Service Continued
  // Evento notificato dall'applicazione quando il servizio
  // viene ri-avviato
  // **********************************************************************
  private void NTContinueService(IDVariant Success)
  {
    DispatchToComp("NTContinueService", new Object[] {Success});
    //
    // Stub
  }



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
    AddCaseInsensitive(CachedFiles, "images/logoiphone.gif");
    AddCaseInsensitive(CachedFiles, "images/sfuma.gif");
    AddCaseInsensitive(CachedFiles, "images/logoipad.gif");
    AddCaseInsensitive(CachedFiles, "images/delip.gif");
  }

  // ************************************************************
  // Elenca i file utilizzati dall'applicazione offline
  // ************************************************************
  public override void GetFontsList(ArrayList Fonts)
  {
    base.GetFontsList(Fonts);
    //
  }
}
