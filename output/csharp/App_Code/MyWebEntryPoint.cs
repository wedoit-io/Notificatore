// **********************************************
// Web Entry Point (session handler)
// Instant WEB Application: www.progamma.com
// Project : Mobile Manager
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
    RevNum = 5477;
    IDVer = "13.5.5800";
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
    DTTObj.Init (0, 0, false, false, false, this);
    //
    VisualStyleList.set_Size(MyGlb.MAX_VISATTR);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_DEFAPANESTYL, v);
    v.iGuid = "2CBA05B6-623A-11D4-BDF0-301B4CC10101";
    v.set_Alignment(1, 1);
    v.set_Alignment(2, 1);
    v.set_Alignment(3, 1);
    v.set_ControlType(1);
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(0);
    v.set_HeaderOffset(4);
    v.set_Flags(786721);
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
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_PRIMAKEYFIEL, v);
    v.iGuid = "2CBA05B7-623A-11D4-BDF0-301B4CC10101";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
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
    v.set_Flags(786465);
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
    v.set_Flags(917793);
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
    v.set_Flags(4063521);
    v.set_Color(1, 16711680);
    v.set_Font(1, "Tahoma,U,8");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_IMAGEFIELD, v);
    v.iGuid = "0C892579-65CA-494B-B7D0-B06FD2CA39FC";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_LABELFIELD));
    v.set_Flags(1966369);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_INTESTPICCOL, v);
    v.iGuid = "0D1D06B1-15E5-462E-A70D-E482279E6941";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_LABELFIELD));
    v.set_Alignment(1, 4);
    v.set_Flags(4063265);
    v.set_Font(1, "Arial,,8");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_COMMANBUTTO1, v);
    v.iGuid = "D47A9B39-CB14-11D5-93C0-6A9CBE000000";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Alignment(1, 3);
    v.set_ControlType(6);
    v.set_Flags(3539233);
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
    v.set_Flags(2490401);
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
    v.set_Flags(2490401);
    v.set_Color(1, 0);
    v.set_Color(2, 4473924);
    v.set_Color(3, 0);
    v.set_Color(8, 15790320);
    v.set_GradCol(8, -1);
    v.set_GradDir(8, 1);
    v.set_Color(10, 10551295);
    v.set_Color(11, 12632256);
    v.set_Color(20, 0);
    v.set_Font(1, "Arial,,10");
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
    v.set_Flags(852257);
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
    v.set_Flags(786465);
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
    v.set_Flags(2883617);
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
    v.set_Flags(2883617);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_INTESTIPHONE, v);
    v.iGuid = "D5C3BC2F-CE55-43C2-8F37-A6D8D2827AF2";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_NORMALFIELDS));
    v.set_Alignment(1, 3);
    v.set_Flags(1835041);
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
    v.set_BorderType(1, 9);
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
    v.set_Flags(786465);
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
    v.set_Flags(786465);
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
    v.set_Flags(917793);
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
    v.set_Flags(1966369);
    v.set_BorderType(6, 1);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_TRASPARENTE, v);
    v.iGuid = "C01E6AD9-7CCC-4EBF-8EE7-D29CCF8F76CF";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(786465);
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
    v.set_Flags(786465);
    v.set_Color(1, 32768);
    v.set_Color(20, 32768);
    v.set_Color(21, 32768);
    v.set_Font(1, "Tahoma,B,8");
    v.set_Font(4, "Tahoma,B,8");
    v.set_Font(5, "Tahoma,B,8");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_GIOCATCAMBIA, v);
    v.iGuid = "2E8AC3F2-C648-4BE4-A907-ADB0B7CA43A7";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(786465);
    v.set_Font(1, "Tahoma,B,8");
    v.set_Font(4, "Tahoma,B,8");
    v.set_Font(5, "Tahoma,B,8");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_SFONDOGIALLO, v);
    v.iGuid = "42C3159A-A6B9-44A4-8480-8E417D3A143B";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAPANESTYL));
    v.set_Flags(786465);
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
    v.set_Flags(786465);
    v.set_Color(1, 0);
    v.set_Color(4, 255);
    v.set_Color(5, 255);
    v.set_Color(6, 16777215);
    v.set_Color(7, 14085101);
    v.set_GradCol(7, -1);
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
    v.set_Flags(786465);
    v.set_Color(1, 0);
    v.set_Color(4, 65280);
    v.set_Color(5, 65280);
    v.set_Color(6, 16777215);
    v.set_Color(7, 14085101);
    v.set_GradCol(7, -1);
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
    v.set_Flags(786465);
    v.set_Color(1, 3947580);
    v.set_Color(4, 65535);
    v.set_Color(5, 65535);
    v.set_Color(6, 16777215);
    v.set_Color(7, 14085101);
    v.set_GradCol(7, -1);
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
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(3);
    v.set_HeaderOffset(4);
    v.set_Flags(33);
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
    v.set_Flags(2490657);
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_HYPERLINK, v);
    v.iGuid = "79F9869B-2BD8-4446-9CFF-498C56A82BD3";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_DEFAREPOSTYL));
    v.set_Flags(2490657);
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
    v.set_Flags(2097185);
    v.set_Font(1, "Arial,,12");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_SIMPLICITY, v);
    v.iGuid = "08FD91B7-5C04-4582-B0D5-2EB995A3A0B0";
    v.set_Alignment(1, 1);
    v.set_Alignment(2, 1);
    v.set_Alignment(3, 1);
    v.set_ControlType(1);
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(0);
    v.set_HeaderOffset(4);
    v.set_Flags(786465);
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
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(0);
    v.set_HeaderOffset(4);
    v.set_Flags(786465);
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
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(0);
    v.set_HeaderOffset(4);
    v.set_Flags(786721);
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
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_DEFAMOBISTYL, v);
    v.iGuid = "43A16029-32EA-4042-B82D-E48398C51D36";
    v.set_Alignment(1, 1);
    v.set_Alignment(2, 1);
    v.set_Alignment(3, 1);
    v.set_ControlType(1);
    v.set_Mask("");
    v.set_Cursor("");
    v.set_RowOffset(0);
    v.set_HeaderOffset(0);
    v.set_Flags(786721);
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
    v.set_Flags(1835297);
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
    v.set_Flags(786465);
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
    v.set_Flags(1966369);
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
    v.set_Flags(4063521);
    v.set_Color(1, 16711680);
    v.set_Font(1, "Arial,U,11");
    //
    v = new VisAttrObj();
    VisualStyleList.set_VisualAttribute(MyGlb.VIS_IMAGEFIELMOB, v);
    v.iGuid = "126D21F9-8F31-438E-A18E-C39BBC3AD0DF";
    v.set_Derived(VisualStyleList.VisualAttribute(MyGlb.VIS_LABELFIELMOB));
    v.set_Alignment(1, 1);
    v.set_Flags(2883873);
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
    v.set_Flags(3539233);
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
    v.set_Flags(852257);
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
          AppName = AppPath + "/Notificatore.aspx";
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
    //
    NotificatoreDBObject.CloseConnection();
    //
    //
    base.EndRequest();
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
    if (FormIdx==MyGlb.FRM_LOGINIPAD) { newform = new LoginIpad(); goto fine; }
    if (FormIdx==MyGlb.FRM_LOGINIPHONE) { newform = new LoginIphone(); goto fine; }
    if (FormIdx==MyGlb.FRM_IMPOSWINPHON) { newform = new ImpostazioniWinPhone(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVIIDWINPHO) { newform = new DeviceIDWinPhone(); goto fine; }
    if (FormIdx==MyGlb.FRM_SPEDIWINPHON) { newform = new SpedizioniWinPhone(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVIWINPMANU) { newform = new InvioWinphoneManuale(); goto fine; }
    if (FormIdx==MyGlb.FRM_IMPOSWINSTOR) { newform = new ImpostazioniWinStore(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVIIDWINSTO) { newform = new DeviceIDWinStore(); goto fine; }
    if (FormIdx==MyGlb.FRM_SPEDIWINSTOR) { newform = new SpedizioniWinStore(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVIOWNSMANU) { newform = new InvioWNSManuale(); goto fine; }
    if (FormIdx==MyGlb.FRM_SALESDATA) { newform = new SalesData(); goto fine; }
    if (FormIdx==MyGlb.FRM_CURRENCIES) { newform = new Currencies(); goto fine; }
    if (FormIdx==MyGlb.FRM_PROMOCODES) { newform = new PromoCodes(); goto fine; }
    if (FormIdx==MyGlb.FRM_COUNTRYCODES) { newform = new CountryCodes(); goto fine; }
    if (FormIdx==MyGlb.FRM_PRODTYPEIDEN) { newform = new ProductTypeIdentifiers(); goto fine; }
    if (FormIdx==MyGlb.FRM_FISCALCALEND) { newform = new FiscalCalendar(); goto fine; }
    if (FormIdx==MyGlb.FRM_GRAFICANDAME) { newform = new GraficoAndamento(); goto fine; }
    if (FormIdx==MyGlb.FRM_DISPOSITNOTI) { newform = new DispositiviNoti(); goto fine; }
    if (FormIdx==MyGlb.FRM_LINGUE) { newform = new Lingue(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVICETOKEN) { newform = new DeviceToken(); goto fine; }
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
    if (FormIdx==MyGlb.FRM_LOGINIPAD) { newform = new LoginIpad(); goto fine; }
    if (FormIdx==MyGlb.FRM_LOGINIPHONE) { newform = new LoginIphone(); goto fine; }
    if (FormIdx==MyGlb.FRM_IMPOSWINPHON) { newform = new ImpostazioniWinPhone(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVIIDWINPHO) { newform = new DeviceIDWinPhone(); goto fine; }
    if (FormIdx==MyGlb.FRM_SPEDIWINPHON) { newform = new SpedizioniWinPhone(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVIWINPMANU) { newform = new InvioWinphoneManuale(); goto fine; }
    if (FormIdx==MyGlb.FRM_IMPOSWINSTOR) { newform = new ImpostazioniWinStore(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVIIDWINSTO) { newform = new DeviceIDWinStore(); goto fine; }
    if (FormIdx==MyGlb.FRM_SPEDIWINSTOR) { newform = new SpedizioniWinStore(); goto fine; }
    if (FormIdx==MyGlb.FRM_INVIOWNSMANU) { newform = new InvioWNSManuale(); goto fine; }
    if (FormIdx==MyGlb.FRM_SALESDATA) { newform = new SalesData(); goto fine; }
    if (FormIdx==MyGlb.FRM_CURRENCIES) { newform = new Currencies(); goto fine; }
    if (FormIdx==MyGlb.FRM_PROMOCODES) { newform = new PromoCodes(); goto fine; }
    if (FormIdx==MyGlb.FRM_COUNTRYCODES) { newform = new CountryCodes(); goto fine; }
    if (FormIdx==MyGlb.FRM_PRODTYPEIDEN) { newform = new ProductTypeIdentifiers(); goto fine; }
    if (FormIdx==MyGlb.FRM_FISCALCALEND) { newform = new FiscalCalendar(); goto fine; }
    if (FormIdx==MyGlb.FRM_GRAFICANDAME) { newform = new GraficoAndamento(); goto fine; }
    if (FormIdx==MyGlb.FRM_DISPOSITNOTI) { newform = new DispositiviNoti(); goto fine; }
    if (FormIdx==MyGlb.FRM_LINGUE) { newform = new Lingue(); goto fine; }
    if (FormIdx==MyGlb.FRM_DEVICETOKEN) { newform = new DeviceToken(); goto fine; }
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
    WriteStr("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">\n");
    WriteStr("<html>\n");
    WriteStr("<head>\n");
    WriteStr("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\">\n");
    WriteStr("<link rel=stylesheet type=\"text/css\" href=\"dtt.css\">\n");
    WriteStr("<title>Login Page</title>\n");
    WriteStr("<script language=\"javascript\" type=\"text/javascript\">\n");
    WriteStr("function PlayTest() { try { window.parent.frames('Control').NextRequest(); } catch(e) {}; }\n");
    WriteStr("</script>\n");
    WriteStr("</head>\n");
    WriteStr("\n");
    WriteStr("<body style=\"margin:0\" onload=\"PlayTest()\">\n");
    WriteStr("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse: collapse\" bordercolor=\"#111111\" width=\"100%\" height=\"100%\">\n");
    WriteStr("<tr>\n");
    WriteStr("<td  colspan=3 style=\"background-color:#FFFFFF\">&nbsp;</td>\n");
    WriteStr("</tr>\n");
    WriteStr("<tr>\n");
    WriteStr("<td style=\"background-color:#FFFFFF\">&nbsp;</td>\n");
    WriteStr("<td width=\"790\" background=\"images/splash.jpg\" height=\"557\" valign=\"top\">&nbsp;\n");
    WriteStr("   <div style=\"position:relative;top:-10px;left:750px\">" + DebugButton() + "</div>\n");
    WriteStr("<p align=\"center\">\n");
    WriteStr("<img border=\"0\" src=\"images/pow2.gif\" width=\"590\" height=\"46\"><p align=\"center\">\n");
    WriteStr("&nbsp;<p align=\"center\">\n");
    WriteStr("&nbsp;<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" style=\"border-collapse: collapse\" bordercolor=\"#111111\" width=\"100%\" height=\"20\">\n");
    WriteStr("<tr>\n");
    WriteStr("<td width=\"33%\" height=\"20\">&nbsp;</td>\n");
    WriteStr("<td width=\"67%\" height=\"20\"><b><font face=\"Trebuchet MS\" size=\"4\">\n");
    WriteStr("<form method=\"post\" autocomplete=\"off\" name=\"frm\" action=\"Notificatore.aspx\">\n");
    WriteStr("<input type=hidden name=WCI value=IWLogin>\n");
    WriteStr("<input type=hidden name=WCE value=Form1>\n");
    WriteStr("<input type=hidden name=WCU>\n");
    WriteStr("       <font color=\"#BCBC77\">" + Glb.HTMLEncode(Caption(), true, true) + "</font>\n");
    WriteStr("</b><p>&nbsp;</p>\n");
    WriteStr("<p><font color=\"#104E79\" face=\"Trebuchet MS\" size=\"2\">Username&nbsp;&nbsp;\n");
    WriteStr("       <input id=\"USERNAME\" name=\"UserName\" tabindex=\"1\" size=\"20\" style=\"border: 1px solid #BCBC77;color:#104E79;font-family:Trebuchet MS;width:150px;height:20px\" value=\"" + Glb.HTMLEncode(RolObj.glbUser) + "\"\n");
    WriteStr("<br><br>Password&nbsp;&nbsp;&nbsp;\n");
    WriteStr("<input id=\"PASSWORD\" type=\"password\" name=\"PassWord\" tabindex=\"2\" size=\"20\" style=\"border:1px solid #BCBC77;color:#104E79;width:150px;height:20px\" >\n");
    WriteStr("<br><font face=\"Trebuchet MS\" size=\"1\"><font color=\"#104E79\">Connessione automatica ad ogni visita </font><input type=\"checkbox\" name=\"checkbox\" value=\"ON\" /></p>\n");
    WriteStr("<p><input id=\"LOGIN\" border=\"0\" src=\"images/login.gif\" name=\"I1\" width=\"83\" height=\"28\" type=\"image\"></p>\n");
    WriteStr("\n");
    WriteStr("<!--\n");
    WriteStr("<font color=\"#104E79\"><a href=\"./forgotpassword.aspx\"</font>\n");
    WriteStr("<font color=\"#BCBC77\">Ho dimenticato la password</font>\n");
    WriteStr("\n");
    WriteStr("<b>\n");
    WriteStr("<p><font face=\"Trebuchet MS\" size=\"2\"><b>\n");
    WriteStr("</a></b></font></p> -->\n");
    WriteStr("\n");
    WriteStr("     	<p style=\"padding-right:40px\"><b><font color=\"#C04040\" face=\"Trebuchet MS\" size=\"2\">" + Glb.HTMLEncode(LoginMessage, true, true) + "</font></b></p>\n");
    WriteStr("<SCRIPT>\n");
    WriteStr("if (document.frm.UserName.value.length==0)\n");
    WriteStr("					document.frm.UserName.focus();\n");
    WriteStr("else\n");
    WriteStr("					document.frm.PassWord.focus();\n");
    WriteStr("</SCRIPT>\n");
    WriteStr("</form></td>\n");
    WriteStr("</tr>\n");
    WriteStr("</table>\n");
    WriteStr("</td>\n");
    WriteStr("<td style=\"background-color:#FFFFFF\">&nbsp;</td>\n");
    WriteStr("</tr>\n");
    WriteStr("<tr>\n");
    WriteStr("<td style=\"background-color:#FFFFFF\" colspan=3>&nbsp;</td>\n");
    WriteStr("</tr>\n");
    WriteStr("</table>\n");
    WriteStr("<div id=\"reqdiv\" class=HelpReqDiv style=\"display:none\"></div>\n");
    WriteStr("<div id=\"reqVdiv\" class=HelpReqDiv style=\"display:none\"></div>\n");
    WriteStr("<div id=\"itemdiv\" class=HelpItemDiv style=\"display:none\"></div>\n");
    WriteStr("<img id=\"helpcurs\" class=HelpCurs src=\"dttimg/helpcurs.gif\" style=\"display:none\">\n");
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
    if (Name.Equals("NotificatoreDB")) return NotificatoreDBObject.DB;
    //
    if (CompOwner != null)
      return CompOwner.GetDBByName(Name);
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
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      if (!QV.EOF())
      {
        v_VURLDIBAAPIM = QV.Get("URLDIBASAPIM", IDVariant.STRING) ;
      }
      QV.Close();
      if (v_VURLDIBAAPIM.compareTo((new IDVariant("")), true)!=0 || !(IDL.IsNull(v_VURLDIBAAPIM)))
      {
        v_SURL = new IDVariant(v_VURLDIBAAPIM);
      }
      else
      {
        // 
        // Creo Ulr Base Name
        // 
        {
          IDVariant v_SHTTP = null;
          v_SHTTP = (new IDVariant("http://"));
          IDVariant v_SAPPENDPORT = new IDVariant(0,IDVariant.STRING);
          if (new IDVariant(MainFrm.Request["SERVER_PORT"]!="" ? MainFrm.Request["SERVER_PORT"] : MainFrm.Request["SERVER_PORT"]).equals((new IDVariant(1)), true))
          {
            v_SHTTP = (new IDVariant("https://"));
          }
          if (new IDVariant(MainFrm.Request["SERVER_PORT"]!="" ? MainFrm.Request["SERVER_PORT"] : MainFrm.Request["SERVER_PORT"]).compareTo((new IDVariant(80)), true)!=0)
          {
            v_SAPPENDPORT = IDL.Add((new IDVariant(":")), IDL.ToString(IDL.ToInteger(new IDVariant(MainFrm.Request["SERVER_PORT"]!="" ? MainFrm.Request["SERVER_PORT"] : MainFrm.Request["SERVER_PORT"]))));
          }
          v_SURL = IDL.Trim(IDL.Add(IDL.Add(v_SHTTP, new IDVariant(MainFrm.Request["SERVER_NAME"]!="" ? MainFrm.Request["SERVER_NAME"] : MainFrm.Request["SERVER_NAME"])), v_SAPPENDPORT), true, true);
        }
        IDVariant S = null;
        S = (new IDVariant(MainFrm.RealPath));
      }
      return v_SURL;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "GetBaseUrl", _e);
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
      // 
      // Check Login Body
      // Corpo Procedura
      // 
      IDVariant v_BRETVALUE = new IDVariant(0,IDVariant.INTEGER);
      if (Utente.equals((new IDVariant("icalcio")), true) && Password.equals((new IDVariant("cesena")), true))
      {
        v_BRETVALUE = (new IDVariant(-1));
      }
      return v_BRETVALUE.booleanValue();
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "CheckLogin", _e);
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
      // 
      // File Exist Body
      // Corpo Procedura
      // 
      IDVariant I = null;
      I = MainFrm.VBFile.FreeFile();
      IDVariant v_BRETVALUE = new IDVariant(0,IDVariant.INTEGER);
      try
      {
        MainFrm.VBFile.OpenForInput(NomeFile, I); 
        v_BRETVALUE = (new IDVariant(-1));
        MainFrm.VBFile.Close(I); 
      }
      catch (Exception e3)
      {
        v_BRETVALUE = (new IDVariant(0));
      }
      return v_BRETVALUE.booleanValue();
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "FileExist", _e);
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
      // 
      // Initialize Body
      // Corpo Procedura
      // 
      // MainFrm.set_Widget(new IDVariant(MainFrm.BrowserInfo()).equals((new IDVariant(5)), true) || new IDVariant(MainFrm.BrowserInfo()).equals((new IDVariant(6)), true));
      MainFrm.set_Caption((new IDVariant("Il Notificatore")));
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
      if (new IDVariant(MainFrm.SessionName).compareTo((new IDVariant("")), true)!=0)
      {
        REFREINCORSO = (new IDVariant(0));
        MainFrm.set_UserRole((new IDVariant(1)));
      }
      else
      {
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
          v_SUTENTE = MainFrm.GetSetting((new IDVariant("icalcio")),(new IDVariant("username")));
          IDVariant v_SPASSWORD = null;
          v_SPASSWORD = MainFrm.GetSetting((new IDVariant("icalcio")),(new IDVariant("password")));
          if (CheckLogin(v_SUTENTE, v_SPASSWORD))
          {
            MainFrm.set_UserRole((new IDVariant(1)));
          }
        }
        // 
        // Query string da iCalcio
        // 
        {
          ParseURL(MainFrm.GetUrlParam());
        }
      }
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "Initialize", _e);
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
      // 
      // On Login Event Body
      // Procedure Body
      // 
      if (new IDVariant(MainFrm.SessionName).compareTo((new IDVariant("")), true)!=0)
      {
        DataValid.set((new IDVariant(-1)));
      }
      else
      {
        // 
        // Nel caso di login ipad o iphone commentare questo blocco
        // 
        if (CheckLogin(UserName, Password))
        {
          MainFrm.set_UserRole((new IDVariant(1)));
          DataValid.set((new IDVariant(-1)));
          // 
          // Se l'utente ha deciso di salvare le credenziali, dopo
          // essere entrato le salvo nel cookie
          // 
          if (IDL.Upper(MainFrm.GetSetting((new IDVariant("FORM")),(new IDVariant("checkbox")))).equals((new IDVariant("ON")), true))
          {
            MainFrm.SaveSetting((new IDVariant("icalcio")),(new IDVariant("username")),UserName); 
            MainFrm.SaveSetting((new IDVariant("icalcio")),(new IDVariant("password")),Password); 
          }
        }
      }
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "OnLoginEvent", _e);
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
      // 
      // After Login Body
      // Corpo Procedura
      // 
      MainFrm.CmdObj.set_CmdSetExpanded(MyGlb.CMDS_GENERALE+BaseCmdSetIdx, (new IDVariant(-1)).booleanValue());
      MainFrm.CmdObj.set_CmdSetExpanded(MyGlb.CMDS_IOS+BaseCmdSetIdx, (new IDVariant(-1)).booleanValue());
      MainFrm.CmdObj.set_CmdSetExpanded(MyGlb.CMDS_ANDROID+BaseCmdSetIdx, (new IDVariant(-1)).booleanValue());
      MainFrm.CmdObj.set_CmdSetExpanded(MyGlb.CMDS_WINPHONE+BaseCmdSetIdx, (new IDVariant(-1)).booleanValue());
      MainFrm.CmdObj.set_CmdSetExpanded(MyGlb.CMDS_WINSTORE+BaseCmdSetIdx, (new IDVariant(-1)).booleanValue());
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
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "AfterLogin", _e);
    }
  }

  // **********************************************************************
  // On Logoff
  // Evento notificato dall'applicazione quando l'utente
  // clicca sul pulsante di logoff dell'applicazione
  // Skip - Input/Output
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
      // 
      // On Logoff Body
      // Corpo Procedura
      // 
      MainFrm.SaveSetting((new IDVariant("icalcio")),(new IDVariant("username")),(new IDVariant(""))); 
      MainFrm.SaveSetting((new IDVariant("icalcio")),(new IDVariant("password")),(new IDVariant(""))); 
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "OnLogoff", _e);
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
      // 
      // On Command Body
      // Corpo Procedura
      // 
      ParseURL(Command);
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "OnCommand", _e);
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
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      if (!QV.EOF())
      {
        v_RETVALUE = QV.Get("PERCCERTIMPO", IDVariant.STRING) ;
      }
      QV.Close();
      v_RETVALUE = IDL.Trim(v_RETVALUE, true, true);
      if (IDL.Right(v_RETVALUE, (new IDVariant(1))).compareTo((new IDVariant("\\")), true)!=0)
      {
        v_RETVALUE = IDL.Add(v_RETVALUE, (new IDVariant("\\")));
      }
      return v_RETVALUE;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "GetPathCertificati", _e);
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
      // 
      // Refresh Polling Body
      // Corpo Procedura
      // 
      IDVariant v_IORARIO = null;
      v_IORARIO = IDL.Hour(IDL.Time());
      IDVariant v_IMINUTI = null;
      v_IMINUTI = IDL.Minute(IDL.Time());
      ValorizzaVariabiliGlobali();
      // 
      // Controllo se è uin corso un'altra operazione
      // 
      if (REFREINCORSO.equals((new IDVariant(0)), true))
      {
        // 
        // Se posso, segnalo che inizio a fare cose..
        // 
        REFREINCORSO = (new IDVariant(-1));
        GLBCONTATORE = (new IDVariant(0));
      }
      else
      {
        GLBCONTATORE = IDL.Add(GLBCONTATORE, (new IDVariant(1)));
        if (GLBCONTATORE.equals((new IDVariant(50)), true))
        {
          WriteDebug((new IDVariant("Limite massimo iterazioni refresh. Azzero")));
          REFREINCORSO = (new IDVariant(0));
        }
        // 
        // altrimenti esco. Il notificatore è già impegnato
        // 
        return 0;
      }
      try
      {
        // 
        // Se autorefresh è a SI eseguo l'invio delle notifiche
        // push per iOS
        // 
        if (GLBATTIVAUTO.equals((new IDVariant("S")), true))
        {
          SendAPNSPushNotification();
          SendGCMNotification((new IDVariant()));
          SendWinStoreNotification((new IDVariant()));
          SendWinPhoneNotification((new IDVariant()));
        }
        // 
        // Se il check del feedback è a SI eseguo il controllo
        // del feedback IOS
        // 
        if (GLBATTCHEFEE.equals((new IDVariant("S")), true))
        {
          // 
          // ogni mezz'ora faccio la verifica del feedback
          // 
          if (v_IMINUTI.equals((new IDVariant(0)), true) || v_IMINUTI.equals((new IDVariant(30)), true))
          {
            CheckFeedbackService();
            // 
            // Se devo eliminare i token rimossi
            // 
            if (GLBELITOKRIM.equals((new IDVariant("S")), true))
            {
              SQL = new StringBuilder();
              SQL.Append("delete from DEV_TOKENS ");
              SQL.Append("where (FLG_RIMOSSO = 'S') ");
              MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            }
          }
        }
        // 
        // Ogni ora controllo se è il caso di ripulire le code
        // vecchie
        // 
        if (v_IMINUTI.equals((new IDVariant(0)), true))
        {
          IDVariant v_VDATAULTIMAE = new IDVariant(0,IDVariant.DATETIME);
          SQL = new StringBuilder();
          SQL.Append("select ");
          SQL.Append("  MAX(A.DAT_ELAB) as MAXDATELASPE ");
          SQL.Append("from ");
          SQL.Append("  SPEDIZIONI A ");
          SQL.Append("where (A.FLG_STATO = 'S') ");
          QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
          if (!QV.EOF()) QV.MoveNext();
          if (!QV.EOF())
          {
            v_VDATAULTIMAE = QV.Get("MAXDATELASPE", IDVariant.DATETIME) ;
          }
          QV.Close();
          IDVariant v_DDATALIMITE = null;
          v_DDATALIMITE = IDL.DateAdd((new IDVariant("d")),IDL.Neg(GLBRETENDAYS),v_VDATAULTIMAE);
          SQL = new StringBuilder();
          SQL.Append("delete from SPEDIZIONI ");
          SQL.Append("where (DAT_ELAB <= " + IDL.CSql(v_DDATALIMITE, IDL.FMT_DAT3, MainFrm.NotificatoreDBObject.DBO()) + ") ");
          SQL.Append("and   (FLG_STATO = 'S') ");
          MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
        }
      }
      catch (Exception e12)
      {
        REFREINCORSO = (new IDVariant(0));
        // WriteDebug(IDL.Add(IDL.Add(new IDVariant(e12.Message), (new IDVariant(" : "))), new IDVariant(e12.Message.StackTrace)));
        WriteDebug(IDL.Add(new IDVariant(e12.Message), (new IDVariant(" : "))));
      }
      REFREINCORSO = (new IDVariant(0));
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "RefreshPolling", _e);
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
      // 
      // Valorizza Variabili Globali Body
      // Corpo Procedura
      // 
      // 
      // Percorsi per la nuova versione dei file
      // 
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  REPLACE(LTRIM(RTRIM(NVL(A.ADMIN_MAIL, 's.teodorani@apexnet.it'))), ' ', '') as RTNVIREISTAI, ");
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
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      if (!QV.EOF())
      {
        GLBINDPOSREP = QV.Get("RTNVIREISTAI", IDVariant.STRING) ;
        GLBPATHCERTI = QV.Get("PERCCERTIMPO", IDVariant.STRING) ;
        GLBWSURL = QV.Get("WEBSERREFIMP", IDVariant.STRING) ;
        GLBMAXMESAPN = QV.Get("MAXMESAPNIMP", IDVariant.INTEGER) ;
        GLBATTIVAUTO = QV.Get("ATTIAUTOIMPO", IDVariant.STRING) ;
        GLBATTCHEFEE = QV.Get("ATTAUTFEEIMP", IDVariant.STRING) ;
        GLBRITARSPED = QV.Get("TIMESPEDIMPO", IDVariant.INTEGER) ;
        GLBRETENDAYS = QV.Get("GIORRETEIMPO", IDVariant.INTEGER) ;
        GLBELITOKRIM = QV.Get("ELITOKRIMIMP", IDVariant.STRING) ;
        GLBMAXMESC2D = QV.Get("MAXMESC2DIMP", IDVariant.INTEGER) ;
        GLBTRACE = QV.Get("TRACEIMPOSTA", IDVariant.INTEGER) ;
      }
      QV.Close();
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "ValorizzaVariabiliGlobali", _e);
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
      // 
      // Send APNS Push Notification Body
      // Corpo Procedura
      // 
      IDVariant v_IMSGELABORAT = null;
      v_IMSGELABORAT = (new IDVariant(0));
      WriteDebug((new IDVariant("INFO: Inizio invio notifiche iOS")));
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // Ciclo per ogni applicazione che ha messaggi in coda
      // 
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
      C2 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!C2.EOF()) C2.MoveNext();
      while (!C2.EOF())
      {
        IDVariant v_BSANDBOX = new IDVariant(0,IDVariant.INTEGER);
        IDVariant v_VCERTIFICATO = new IDVariant(0,IDVariant.STRING);
        IDVariant v_TROVATAAPP = new IDVariant(0,IDVariant.INTEGER);
        IDVariant v_VIDAPPPUSSET = new IDVariant(0,IDVariant.INTEGER);
        // 
        // Prelevo i dati dell'applicazione
        // 
        SQL = new StringBuilder();
        SQL.Append("select ");
        SQL.Append("  DECODE(A.FLG_AMBIENTE, 'S', -1, 0) as IFEQAMAPSSTF, ");
        SQL.Append("  " + IDL.CSql(GLBPATHCERTI, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + " || '\\' || A.CERT_DEV as GLPACENCPAPS, ");
        SQL.Append("  A.ID as IDAPPSPUSSET ");
        SQL.Append("from ");
        SQL.Append("  APPS_PUSH_SETTING A ");
        SQL.Append("where (A.ID = " + IDL.CSql(C2.Get("MIDAPPLICAZI"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        SQL.Append("and   (A.FLG_ATTIVA = 'S') ");
        SQL.Append("and   (A.TYPE_OS = '1') ");
        QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!QV.EOF()) QV.MoveNext();
        v_TROVATAAPP = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
        if (!QV.EOF())
        {
          v_BSANDBOX = QV.Get("IFEQAMAPSSTF", IDVariant.INTEGER) ;
          v_VCERTIFICATO = QV.Get("GLPACENCPAPS", IDVariant.STRING) ;
          v_VIDAPPPUSSET = QV.Get("IDAPPSPUSSET", IDVariant.INTEGER) ;
        }
        QV.Close();
        // 
        // Se trovo ma configurazione (ovvio)
        // 
        if (v_TROVATAAPP.booleanValue())
        {
          System.Security.Cryptography.X509Certificates.X509Certificate2 v_XC = null;
          v_XC = new System.Security.Cryptography.X509Certificates.X509Certificate2(System.IO.File.ReadAllBytes(v_VCERTIFICATO.stringValue()));
          IDVariant D = new IDVariant(0,IDVariant.DATETIME);
          D = (new IDVariant(Convert.ToDateTime(v_XC.GetExpirationDateString())));
          if (D.compareTo(IDL.Now(), true)<0)
          {
            WriteDebug(IDL.FormatMessage((new IDVariant("Certificato app|1 non valido")), IDL.ToString(v_VIDAPPPUSSET)));
            SQL = new StringBuilder();
            SQL.Append("update APPS_PUSH_SETTING set ");
            SQL.Append("  FLG_ATTIVA = 'N', ");
            SQL.Append("  DES_ERR = 'Disattivata dal sistema:CertExp:' || TO_CHAR ( " + IDL.CSql(D, IDL.FMT_DAT3, MainFrm.NotificatoreDBObject.DBO()) + " ) ");
            SQL.Append("where (ID = " + IDL.CSql(v_VIDAPPPUSSET, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            return 0;
          }
          // 
          // 
          // 
          // 
          JdSoft.Apple.Apns.Notifications.NotificationService v_NS = null;
          try
          {
            v_NS = new JdSoft.Apple.Apns.Notifications.NotificationService(v_BSANDBOX.booleanValue(), v_VCERTIFICATO.stringValue(), (new IDVariant("")).stringValue(),1);
            v_NS.Error += new JdSoft.Apple.Apns.Notifications.NotificationService.OnError(NService.service_Error);
            v_NS.NotificationTooLong += new JdSoft.Apple.Apns.Notifications.NotificationService.OnNotificationTooLong(NService.service_NotificationTooLong);
            v_NS.BadDeviceToken += new JdSoft.Apple.Apns.Notifications.NotificationService.OnBadDeviceToken(NService.service_BadDeviceToken);
            v_NS.NotificationFailed += new JdSoft.Apple.Apns.Notifications.NotificationService.OnNotificationFailed(NService.service_NotificationFailed);
            v_NS.NotificationSuccess += new JdSoft.Apple.Apns.Notifications.NotificationService.OnNotificationSuccess(NService.service_NotificationSuccess);
            v_NS.Connecting += new JdSoft.Apple.Apns.Notifications.NotificationService.OnConnecting(NService.service_Connecting);
            v_NS.Connected += new JdSoft.Apple.Apns.Notifications.NotificationService.OnConnected(NService.service_Connected);
            v_NS.Disconnected += new JdSoft.Apple.Apns.Notifications.NotificationService.OnDisconnected(NService.service_Disconnected);
            v_NS.SendRetries = (new IDVariant(10)).intValue();
            v_NS.ReconnectDelay = (new IDVariant(5000)).intValue();
            // 
            // Sono nella fascia oraria prevista per il refresh dei
            // dati...
            // 
            SQL = new StringBuilder();
            SQL.Append("select ");
            SQL.Append("  A.ID as IDSPEDIZIONE, ");
            SQL.Append("  REPLACE(A.DEV_TOKEN, ' ', '') as RDEVICETOKEN, ");
            SQL.Append("  A.ID_APPLICAZIONE as RIDAPPLICAZI, ");
            SQL.Append("  A.DES_MESSAGGIO as RMESSAGGIO, ");
            SQL.Append("  A.DES_UTENTE as RUTENTE, ");
            SQL.Append("  A.SOUND as SOUNDSPEDIZI, ");
            SQL.Append("  NVL(A.BADGE, 0) as BADGESPEDIZI ");
            SQL.Append("from ");
            SQL.Append("  SPEDIZIONI A ");
            SQL.Append("where (A.ID_APPLICAZIONE = " + IDL.CSql(C2.Get("MIDAPPLICAZI"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            SQL.Append("and   (A.FLG_STATO = 'W') ");
            SQL.Append("and   (LENGTH(A.DEV_TOKEN) = 64) ");
            C7 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
            C7.setColUnbound(2,true);
            C7.setColUnbound(7,true);
            if (!C7.EOF()) C7.MoveNext();
            while (!C7.EOF())
            {
              v_IMSGELABORAT = IDL.Add(v_IMSGELABORAT, (new IDVariant(1)));
              // 
              // Se ho raggiunto il numero massimo di elaborazioni da
              // effettuare
              // 
              if (v_IMSGELABORAT.compareTo(GLBMAXMESAPN, true)>0)
              {
                v_IMSGELABORAT = (new IDVariant(0));
                IDVariant v_SMSG = null;
                v_SMSG = IDL.FormatMessage((new IDVariant("Ne ho spediti |1. L'ultimo è il |2")), IDL.ToString(GLBMAXMESAPN), IDL.ToString(C7.Get("IDSPEDIZIONE")));
                WriteDebug(v_SMSG);
                break;
              }
              JdSoft.Apple.Apns.Notifications.Notification N = null;
              N = new JdSoft.Apple.Apns.Notifications.Notification(C7.Get("RDEVICETOKEN").stringValue());
              // 
              // Se c'è il messaggio lo metto nel payload
              // 
              if (!(IDL.IsNull(C7.Get("RMESSAGGIO"))) && C7.Get("RMESSAGGIO").compareTo((new IDVariant("")), true)!=0)
              {
                N.Payload.Alert.Body = new IDVariant(C7.Get("RMESSAGGIO")).stringValue();
              }
              // 
              // Se c'è il suono lo metto nel payload
              // 
              if (!(IDL.IsNull(C7.Get("SOUNDSPEDIZI"))) && C7.Get("SOUNDSPEDIZI").compareTo((new IDVariant("")), true)!=0)
              {
                N.Payload.Sound = new IDVariant(C7.Get("SOUNDSPEDIZI")).stringValue();
              }
              // 
              // Se c'è il badge lo metto nel payload
              // 
              if (C7.Get("BADGESPEDIZI").compareTo((new IDVariant(0)), true)>=0)
              {
                N.Payload.Badge = new IDVariant(C7.Get("BADGESPEDIZI")).intValue();
              }
              // 
              // Metto il messaggio in coda
              // 
              if (!(v_NS.QueueNotification(N)))
              {
                WriteDebug((new IDVariant("ERROR: Ci sono stati dei problemi. il messaggio non è in coda")));
              }
              else
              {
                SQL = new StringBuilder();
                SQL.Append("update SPEDIZIONI set ");
                SQL.Append("  FLG_STATO = 'S', ");
                SQL.Append("  DAT_ELAB = SYSDATE ");
                SQL.Append("where (ID = " + IDL.CSql(C7.Get("IDSPEDIZIONE"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
                MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
                SQL = new StringBuilder();
                SQL.Append("update DEV_TOKENS set ");
                SQL.Append("  DAT_ULTIMO_INVIO = SYSDATE ");
                SQL.Append("where (DEV_TOKEN = " + IDL.CSql(C7.Get("RDEVICETOKEN"), IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
                SQL.Append("and   (ID_APPLICAZIONE = " + IDL.CSql(v_VIDAPPPUSSET, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
                MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
              }
              C7.MoveNext();
            }
            C7.Close();
            // 
            // Il close verifica che tutti i messaggi siano correttamente
            // in coda
            // 
            IDL.Sleep((new IDVariant(1)).intValue()*1000); 
            v_NS.Close();
            IDL.Sleep((new IDVariant(1)).intValue()*1000); 
            // 
            // Il dispose chiude la connessione
            // 
            v_NS.Dispose();
          }
          catch (Exception e15)
          {
            WriteDebug(IDL.FormatMessage((new IDVariant("Trovato errore. Disattivo l'applicazione IDAppspushSetting:|1")), IDL.ToString(v_VIDAPPPUSSET)));
            SQL = new StringBuilder();
            SQL.Append("update APPS_PUSH_SETTING set ");
            SQL.Append("  FLG_ATTIVA = 'N', ");
            SQL.Append("  DES_ERR = 'Disattivata dal sistema' ");
            SQL.Append("where (ID = " + IDL.CSql(v_VIDAPPPUSSET, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            if (v_NS != null)
            {
              // 
              // Il close verifica che tutti i messaggi siano correttamente
              // in coda
              // 
              IDL.Sleep((new IDVariant(1)).intValue()*1000); 
              v_NS.Close();
              IDL.Sleep((new IDVariant(1)).intValue()*1000); 
              // 
              // Il dispose chiude la connessione
              // 
              v_NS.Dispose();
            }
            // throw new Exception(((new IDVariant(550590))).stringValue() + " - " + IDL.Add(new IDVariant(e15.Message), new IDVariant(e15.Message.StackTrace)));
            throw new Exception(((new IDVariant(550590))).stringValue() + " - " + new IDVariant(e15.Message));
          }
        }
        IDL.Sleep(GLBRITARSPED.intValue()*1000); 
        C2.MoveNext();
      }
      C2.Close();
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "SendAPNSPushNotification", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Check Feedback Service
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int CheckFeedbackService ()
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;
    IDCachedRowSet C2;

    try
    {
      TransCount = 0;
      // 
      // Check Feedback Service Body
      // Corpo Procedura
      // 
      IDVariant v_IMSGELABORAT = null;
      v_IMSGELABORAT = (new IDVariant(0));
      IDVariant v_BSANDBOX1 = new IDVariant(0,IDVariant.INTEGER);
      IDVariant v_VCERTIFICATO = new IDVariant(0,IDVariant.STRING);
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // 
      SQL = new StringBuilder();
      SQL.Append("select ");
      SQL.Append("  A.ID as VID, ");
      SQL.Append("  DECODE(A.FLG_AMBIENTE, 'S', -1, 0) as VSANDBOX, ");
      SQL.Append("  " + IDL.CSql(GLBPATHCERTI, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + " || '\\' || A.CERT_DEV as VCERTIFICATO ");
      SQL.Append("from ");
      SQL.Append("  APPS_PUSH_SETTING A ");
      SQL.Append("where (A.FLG_ATTIVA = 'S') ");
      SQL.Append("and   (A.TYPE_OS = '1') ");
      C2 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      C2.setColUnbound(2,true);
      C2.setColUnbound(3,true);
      if (!C2.EOF()) C2.MoveNext();
      while (!C2.EOF())
      {
        CheckAppleFeedbackService(C2.Get("VID"), C2.Get("VSANDBOX"), C2.Get("VCERTIFICATO"));
        C2.MoveNext();
      }
      C2.Close();
      // IDL.Sleep((new IDVariant(5000)).intValue()*1000); 
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "CheckFeedbackService", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Check Apple Feedback Service
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // ID Apps Push Settings:  - Input
  // Sandbox:  - Input
  // Certificato:  - Input
  // **********************************************************************
  public int CheckAppleFeedbackService (IDVariant IDAppsPushSettings, IDVariant Sandbox, IDVariant Certificato)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Check Apple Feedback Service Body
      // Corpo Procedura
      // 
      System.Security.Cryptography.X509Certificates.X509Certificate2 v_XC = null;
      v_XC = new System.Security.Cryptography.X509Certificates.X509Certificate2(System.IO.File.ReadAllBytes(Certificato.stringValue()));
      IDVariant D = new IDVariant(0,IDVariant.DATETIME);
      D = (new IDVariant(Convert.ToDateTime(v_XC.GetExpirationDateString())));
      if (D.compareTo(IDL.Now(), true)<0)
      {
        WriteDebug(IDL.FormatMessage((new IDVariant("Il certificato di |1 è scaduto. Disattivo l'app e non chiamo il feedback")), GetAppName(IDAppsPushSettings)));
        SQL = new StringBuilder();
        SQL.Append("update APPS_PUSH_SETTING set ");
        SQL.Append("  FLG_ATTIVA = 'N' ");
        SQL.Append("where (ID = " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
        return 0;
      }
      FService v_FB = null;
      v_FB = (FService)new FService();
      IDVariant v_STK3 = new IDVariant(0,IDVariant.STRING);
      v_FB.vConnectAttempts = (new IDVariant(10)).intValue();
      v_FB.vReconnectDelay = (new IDVariant(200)).intValue();
      v_FB.GetFeedback(Sandbox.booleanValue(), Certificato.stringValue(), ""); 
      // 
      // Contiene la lista dei devtoken da rimuovere
      // 
      IDVariant v_SDEVTKLIST = null;
      v_SDEVTKLIST = (new IDVariant(v_FB.devList));
      // 
      // Contiene un elenco di errori sconosciuti
      // 
      IDVariant v_SDEVERROLIST = null;
      v_SDEVERROLIST = (new IDVariant(v_FB.errList));
      // 
      // Chiamo il servizio di feedback e ciclo sull'elenco
      // di tokent rimossi
      // --------------------------------------------------
      // ------------------
      // 
      com.progamma.StringTokenizer v_ST1 = null;
      v_ST1 = (com.progamma.StringTokenizer)new com.progamma.StringTokenizer();
      v_ST1.setString(v_SDEVTKLIST,(new IDVariant("|"))); 
      while (v_ST1.hasNext())
      {
        IDVariant v_STK = null;
        v_STK = IDL.Upper(IDL.Trim(v_ST1.next(), true, true));
        if (v_STK.compareTo((new IDVariant("")), true)!=0)
        {
          SQL = new StringBuilder();
          SQL.Append("update DEV_TOKENS set ");
          SQL.Append("  FLG_RIMOSSO = 'S', ");
          SQL.Append("  DES_NOTA = 'Applicazione disinstallata', ");
          SQL.Append("  DATA_RIMOZ = SYSDATE ");
          SQL.Append("where (UPPER(DEV_TOKEN) = UPPER(" + IDL.CSql(v_STK, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ")) ");
          SQL.Append("and   (ID_APPLICAZIONE = " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
          MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
        }
      }
      // 
      // Ora ciclo su un elenco di token che ritornano errori
      // per motivi ignoti
      // --------------------------------------------------
      // ----------------
      // 
      com.progamma.StringTokenizer v_ST2 = null;
      v_ST2 = (com.progamma.StringTokenizer)new com.progamma.StringTokenizer();
      v_ST2.setString(v_SDEVERROLIST,(new IDVariant("|"))); 
      while (v_ST2.hasNext())
      {
        IDVariant v_STK2 = null;
        v_STK2 = IDL.Upper(IDL.Trim(v_ST2.next(), true, true));
        if (v_STK2.compareTo((new IDVariant("")), true)!=0)
        {
          IDVariant v_VAPPLICAZION = new IDVariant(0,IDVariant.STRING);
          SQL = new StringBuilder();
          SQL.Append("select ");
          SQL.Append("  B.NOME_APP as APPLICAZAPPS ");
          SQL.Append("from ");
          SQL.Append("  APPS_PUSH_SETTING A, ");
          SQL.Append("  APPS B ");
          SQL.Append("where B.ID = A.ID_APP ");
          SQL.Append("and   (A.ID = " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
          QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
          if (!QV.EOF()) QV.MoveNext();
          if (!QV.EOF())
          {
            v_VAPPLICAZION = QV.Get("APPLICAZAPPS", IDVariant.STRING) ;
          }
          QV.Close();
          IDVariant v_SMSG = null;
          v_SMSG = IDL.FormatMessage((new IDVariant("Feedback error: |1, AppName: |2, AppID: |3")), v_STK2, v_VAPPLICAZION, IDL.ToString(IDAppsPushSettings));
          WriteDebug(v_SMSG);
        }
      }
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "CheckAppleFeedbackService", _e);
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
      // 
      // Save Device Token Body
      // Corpo Procedura
      // 
      IDVariant v_IDLINGUA = null;
      v_IDLINGUA = (new IDVariant());
      // 
      // Se mi passi un null o empty string, vuol dire che sei
      // utente Guest.
      // In questo caso sul db devo mettere null
      // 
      if (IDL.IsNull(Utente) || IDL.Trim(Utente, true, true).equals((new IDVariant("")), true))
      {
        Utente = (new IDVariant());
      }
      // 
      // Se mi passi un null o empty string, vuol dire che sei
      // utente Guest.
      // In questo caso sul db devo mettere null
      // 
      if (IDL.IsNull(CodiceLingua) || IDL.Trim(CodiceLingua, true, true).equals((new IDVariant("")), true))
      {
        v_IDLINGUA = (new IDVariant());
      }
      else
      {
        ReturnStatus = MainFrm.NotificatoreDBObject.IdentificaLingua(CodiceLingua, v_IDLINGUA);
        if (ReturnStatus != 0) throw new Exception(MainFrm.NotificatoreDBObject.ErrorMessage());
      }
      // 
      // Se il regid e' null o empty string, devo mettere null
      // sul db
      // 
      if (IDL.IsNull(RegID) || RegID.equals((new IDVariant("")), true))
      {
        RegID = (new IDVariant());
      }
      // 
      // Se il custom tag e' null o empty string, sul db devo
      // mettere null
      // 
      if (IDL.IsNull(CustomTAG) || CustomTAG.equals((new IDVariant("")), true))
      {
        CustomTAG = (new IDVariant());
      }
      // 
      // Tolgo evntuali spazi dal token
      // 
      IDVariant v_STOKEN = null;
      v_STOKEN = IDL.Trim(IDL.Replace(Token, (new IDVariant(" ")), (new IDVariant(""))), true, true);
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
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      v_TROVATOTOKEN = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
      if (!QV.EOF())
      {
        v_VIDDEVICTOKE = QV.Get("IDDEVICTOKEN", IDVariant.INTEGER) ;
      }
      QV.Close();
      if (!(v_TROVATOTOKEN.booleanValue()))
      {
        IDVariant v_DDATACUPERTI = new IDVariant(0,IDVariant.DATETIME);
        v_DDATACUPERTI = IDL.DateAdd((new IDVariant("d")),(new IDVariant(9)),IDL.Now());
        switch (1) // Allows the use of BREAK inside ifs
        {
          default:
          if (TypeOS.equals((new IDVariant("1"))))	
          {
            if (IDL.Length(v_STOKEN).compareTo((new IDVariant(64)), true)!=0)
            {
              WriteDebug((new IDVariant("ERRORE: Il token arrivato dal dispositivo non è 64 bytes")));
            }
            else
            {
              // 
              // Inserisco un nuovo device token
              // 
              SQL = new StringBuilder();
              SQL.Append("insert into DEV_TOKENS ");
              SQL.Append("( ");
              SQL.Append("  ID, ");
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
              SQL.Append("  DEV_TOKENS_ID.NextVal, ");
              SQL.Append("  " + IDL.CSql(v_STOKEN, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  " + IDL.CSql(Utente, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  " + IDL.CSql(RegID, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  " + IDL.CSql(CustomTAG, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  DECODE(" + IDL.CSql(TypeOS, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", '', '1', " + IDL.CSql(TypeOS, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + "), ");
              SQL.Append("  " + IDL.CSql(v_IDLINGUA, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  " + IDL.CSql(v_DDATACUPERTI, IDL.FMT_DAT3, MainFrm.NotificatoreDBObject.DBO()) + " ");
              SQL.Append(") ");
              MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            }
          }
          else if (TypeOS.equals((new IDVariant("2"))))	
          {
            // 
            // Inserisco un nuovo device token
            // 
            SQL = new StringBuilder();
            SQL.Append("insert into DEV_TOKENS ");
            SQL.Append("( ");
            SQL.Append("  ID, ");
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
            SQL.Append("  DEV_TOKENS_ID.NextVal, ");
            SQL.Append("  " + IDL.CSql(v_STOKEN, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(Utente, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(RegID, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(CustomTAG, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  DECODE(" + IDL.CSql(TypeOS, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", '', '1', " + IDL.CSql(TypeOS, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + "), ");
            SQL.Append("  " + IDL.CSql(v_IDLINGUA, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(v_DDATACUPERTI, IDL.FMT_DAT3, MainFrm.NotificatoreDBObject.DBO()) + " ");
            SQL.Append(") ");
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
          }
          else if (TypeOS.equals((new IDVariant("5"))))	
          {
            // 
            // Inserisco un nuovo device token
            // 
            SQL = new StringBuilder();
            SQL.Append("insert into DEV_TOKENS ");
            SQL.Append("( ");
            SQL.Append("  ID, ");
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
            SQL.Append("  DEV_TOKENS_ID.NextVal, ");
            SQL.Append("  " + IDL.CSql(v_STOKEN, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(Utente, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(RegID, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(CustomTAG, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  '5', ");
            SQL.Append("  " + IDL.CSql(v_IDLINGUA, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(v_DDATACUPERTI, IDL.FMT_DAT3, MainFrm.NotificatoreDBObject.DBO()) + " ");
            SQL.Append(") ");
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
          }
          else if (TypeOS.equals((new IDVariant("3"))))	
          {
            // 
            // Inserisco un nuovo device token
            // 
            SQL = new StringBuilder();
            SQL.Append("insert into DEV_TOKENS ");
            SQL.Append("( ");
            SQL.Append("  ID, ");
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
            SQL.Append("  DEV_TOKENS_ID.NextVal, ");
            SQL.Append("  " + IDL.CSql(v_STOKEN, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(Utente, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(RegID, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(CustomTAG, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  '3', ");
            SQL.Append("  " + IDL.CSql(v_IDLINGUA, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(v_DDATACUPERTI, IDL.FMT_DAT3, MainFrm.NotificatoreDBObject.DBO()) + " ");
            SQL.Append(") ");
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
          }
          break;
        }
      }
      else
      {
        // 
        // Aggiorna il device token
        // 
        SQL = new StringBuilder();
        SQL.Append("update DEV_TOKENS set ");
        SQL.Append("  DATA_ULT_ACCESSO = SYSDATE, ");
        SQL.Append("  DES_UTENTE = " + IDL.CSql(Utente, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  REG_ID = " + IDL.CSql(RegID, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  CUSTOM_TAG = " + IDL.CSql(CustomTAG, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  FLG_RIMOSSO = 'N', ");
        SQL.Append("  PRG_LINGUA = " + IDL.CSql(v_IDLINGUA, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " ");
        SQL.Append("where (ID = " + IDL.CSql(v_VIDDEVICTOKE, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        SQL.Append("and   (ID_APPLICAZIONE = " + IDL.CSql(IDAppsPushSettings, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
      }
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "SaveDeviceToken", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Send Mail Report
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Testo - Input
  // **********************************************************************
  public int SendMailReport (IDVariant Testo)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Send Mail Report Body
      // Corpo Procedura
      // 
      IDMailer M = null;
      M = (IDMailer)new IDMailer();
      M.FromName = (new IDVariant("icalcio")).stringValue();
      M.FromAddress = (new IDVariant("cim@apex-net.it")).stringValue();
      // 
      // Spezzo la stringa
      // 
      com.progamma.StringTokenizer v_ST = null;
      v_ST = (com.progamma.StringTokenizer)new com.progamma.StringTokenizer();
      v_ST.setString(GLBINDPOSREP,(new IDVariant(","))); 
      while (v_ST.hasNext())
      {
        IDVariant v_SDESTINATARI = null;
        v_SDESTINATARI = v_ST.next();
        M.AddToAddress(v_SDESTINATARI.stringValue()); 
      }
      M.Subject = (new IDVariant("icalcio report")).stringValue();
      M.Body = new IDVariant(Testo).stringValue();
      M.SetRelayServer((new IDVariant("pop.apex-net.it")).stringValue(), (new IDVariant(25)).intValue(), (new IDVariant("cim@apex-net.it")).stringValue(), (new IDVariant("nomoreapex-net")).stringValue(),(new IDVariant(0)).booleanValue()); 
      M.SendMail();
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "SendMailReport", _e);
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
      // 
      // Parse URL Body
      // Corpo Procedura
      // 
      IDVariant v_JSONOK = null;
      v_JSONOK = (new IDVariant("[{\"result\":\"OK\"}]"));
      IDVariant v_JSONKO = null;
      v_JSONKO = (new IDVariant("[{\"result\":\"KO\"}]"));
      IDVariant v_OK = null;
      v_OK = (new IDVariant(0));
      MainFrm.DTTObj.Add(Command.stringValue(), (new IDVariant(999)).intValue(), (new IDVariant(2)).intValue()); 
      switch (1) // Allows the use of BREAK inside ifs
      {
        default:
        if (Command.equals((new IDVariant("initapp"))))	
        {
          IDVariant v_VKEY = null;
          v_VKEY = MainFrm.GetUrlParam((new IDVariant("appkey")));
          IDVariant v_VDEVTOKEN = null;
          v_VDEVTOKEN = MainFrm.GetUrlParam((new IDVariant("devtoken")));
          IDVariant v_VUSER = null;
          v_VUSER = MainFrm.GetUrlParam((new IDVariant("user")));
          IDVariant v_VREGID = null;
          v_VREGID = MainFrm.GetUrlParam((new IDVariant("regid")));
          IDVariant v_VOS = null;
          v_VOS = MainFrm.GetUrlParam((new IDVariant("os")));
          IDVariant v_VCUSTOM = null;
          v_VCUSTOM = MainFrm.GetUrlParam((new IDVariant("custom")));
          IDVariant v_VLANGUAGE = null;
          v_VLANGUAGE = MainFrm.GetUrlParam((new IDVariant("lang")));
          if (v_VOS.equals((new IDVariant("")), true))
          {
            v_VOS = (new IDVariant("1"));
          }
          if (v_VKEY.compareTo((new IDVariant("")), true)!=0 && v_VDEVTOKEN.compareTo((new IDVariant("")), true)!=0)
          {
            IDVariant v_IAPPPUSSETID = new IDVariant(0,IDVariant.INTEGER);
            IDVariant v_TROVOAPPLICA = new IDVariant(0,IDVariant.INTEGER);
            SQL = new StringBuilder();
            SQL.Append("select ");
            SQL.Append("  A.ID as IDAPPS ");
            SQL.Append("from ");
            SQL.Append("  APPS A ");
            SQL.Append("where (A.APP_KEY = " + IDL.CSql(v_VKEY, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
            if (!QV.EOF()) QV.MoveNext();
            v_TROVOAPPLICA = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
            if (!QV.EOF())
            {
              v_IAPPPUSSETID = QV.Get("IDAPPS", IDVariant.INTEGER) ;
            }
            QV.Close();
            WriteDebug(new IDVariant (SQL.ToString()));
            // 
            // iOS: http://notificatore.apexnet.it/Notificatore.aspx
            // CMD=initapp&appkey=PIPPO&devtoken=1231231232123
            // Android: http://notificatore.apexnet.it/Notificatore
            // aspx?CMD=initapp&appkey=PIPPO&devtoken=1231231232123
            // 
            if (v_TROVOAPPLICA.booleanValue())
            {
              IDVariant v_VIDAPPPUSSET = new IDVariant(0,IDVariant.INTEGER);
              IDVariant v_TROVATA = new IDVariant(0,IDVariant.INTEGER);
              SQL = new StringBuilder();
              SQL.Append("select ");
              SQL.Append("  A.ID as ID ");
              SQL.Append("from ");
              SQL.Append("  APPS_PUSH_SETTING A ");
              SQL.Append("where (A.ID_APP = " + IDL.CSql(v_IAPPPUSSETID, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
              SQL.Append("and   (A.TYPE_OS = " + IDL.CSql(v_VOS, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
              QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
              if (!QV.EOF()) QV.MoveNext();
              v_TROVATA = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
              if (!QV.EOF())
              {
                v_VIDAPPPUSSET = QV.Get("ID", IDVariant.INTEGER) ;
              }
              QV.Close();
              WriteDebug(new IDVariant (SQL.ToString()));
              if (v_TROVATA.booleanValue())
              {
                SaveDeviceToken(v_VDEVTOKEN, v_VUSER, v_VIDAPPPUSSET, v_VREGID, v_VOS, v_VCUSTOM, v_VLANGUAGE);
                v_OK = (new IDVariant(-1));
              }
            }
          }
          if (v_OK.booleanValue())
          {
            MainFrm.SendHtml(v_JSONOK.stringValue()); 
          }
          else
          {
            MainFrm.SendHtml(v_JSONKO.stringValue()); 
          }
        }
        break;
      }
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "ParseURL", _e);
      return -1;
    }
  }

  // **********************************************************************
  // Write Debug
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Messaggio - Input
  // **********************************************************************
  public int WriteDebug (IDVariant Messaggio)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
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
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      if (!QV.EOF())
      {
        v_VTRACEIMPOST = QV.Get("TRACEIMPOSTA", IDVariant.INTEGER) ;
      }
      QV.Close();
      if (v_VTRACEIMPOST.equals((new IDVariant(1)), true))
      {
        ReturnStatus = MainFrm.NotificatoreDBObject.WriteMessageLog(Messaggio);
        if (ReturnStatus != 0) throw new Exception(MainFrm.NotificatoreDBObject.ErrorMessage());
      }
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "WriteDebug", _e);
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
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      if (!QV.EOF())
      {
        v_VAPPLICAZAPP = QV.Get("APPLICAZIAPP", IDVariant.STRING) ;
      }
      QV.Close();
      return v_VAPPLICAZAPP;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "GetAppName", _e);
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
  // **********************************************************************
  public IDVariant CallGMCHelperSendNotification (IDVariant GoogleApiBrowserIDAppsPushSettings, IDVariant RegidSpedizione, IDVariant MessaggioSpedizione)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;

    try
    {
      TransCount = 0;
      // 
      // Call GMC Helper Send Notification Body
      // Corpo Procedura
      // 
      IDVariant v_SRET1 = null;
      v_SRET1 = new IDVariant(GCMHelper.SendNotificationPlain(GoogleApiBrowserIDAppsPushSettings.stringValue(), RegidSpedizione.stringValue(),MessaggioSpedizione.stringValue()));
      return v_SRET1;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "CallGMCHelperSendNotification", _e);
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
      // 
      // Send GCMNotification Body
      // Corpo Procedura
      // 
      IDVariant v_IMSGELABORAT = null;
      v_IMSGELABORAT = (new IDVariant(0));
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // Ciclo per ogni applicazione che ha messaggi in coda
      // 
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
      C2 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!C2.EOF()) C2.MoveNext();
      while (!C2.EOF())
      {
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
        QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!QV.EOF()) QV.MoveNext();
        v_TROVATAAPP = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
        if (!QV.EOF())
        {
          v_VGOAPBRIDAPS = QV.Get("GOAPBRIDAPPS", IDVariant.STRING) ;
        }
        QV.Close();
        // 
        // Se trovo ma configurazione (ovvio)
        // 
        if (v_TROVATAAPP.booleanValue() && v_VGOAPBRIDAPS.compareTo((new IDVariant("")), true)!=0)
        {
          // 
          // Raggruppa le spedizione con lo stesso messaggio
          // Sono nella fascia oraria prevista per il refresh dei
          // dati...
          // 
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
          SQL.Append("and   ((A.DAT_ELAB IS NULL) OR SYSDATE - A.DAT_ELAB > 0.100) ");
          C4 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
          C4.setColUnbound(2,true);
          if (!C4.EOF()) C4.MoveNext();
          while (!C4.EOF())
          {
            v_IMSGELABORAT = IDL.Add(v_IMSGELABORAT, (new IDVariant(1)));
            // 
            // Se ho raggiunto il numero massimo di elaborazioni da
            // effettuare
            // 
            if (v_IMSGELABORAT.compareTo(GLBMAXMESC2D, true)>0)
            {
              v_IMSGELABORAT = (new IDVariant(0));
              IDVariant v_SMSG = null;
              v_SMSG = IDL.FormatMessage((new IDVariant("C2DM: Ne ho spediti |1. L'ultimo è il |2")), IDL.ToString(GLBMAXMESC2D), IDL.ToString(C4.Get("ID")));
              WriteDebug(v_SMSG);
              break;
            }
            IDVariant v_SRETJSON = null;
            v_SRETJSON = new IDVariant(GCMHelper.SendNotificationPlain(v_VGOAPBRIDAPS.stringValue(), C4.Get("RREGID").stringValue(),C4.Get("RMESSAGGIO").stringValue()));
            ElaboraRisultatoGCMNotification(C4.Get("RREGID"), v_SRETJSON, C4.Get("ID"));
            C4.MoveNext();
          }
          C4.Close();
        }
        IDL.Sleep((new IDVariant(1)).intValue()*1000); 
        C2.MoveNext();
      }
      C2.Close();
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "SendGCMNotification", _e);
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
      // 
      // Elabora Risultato GCM Notification Body
      // Corpo Procedura
      // 
      IDVariant v_INFO = new IDVariant(0,IDVariant.STRING);
      IDVariant v_STATOSPEDIZI = new IDVariant(0,IDVariant.STRING);
      IDVariant v_NUMETENTSPED = new IDVariant(0,IDVariant.INTEGER);
      IDVariant v_MAXNUMERTENT = null;
      v_MAXNUMERTENT = (new IDVariant(3));
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // Ciclo per ogni applicazione che ha messaggi in coda
      // 
      // 
      IDVariant v_INFOESITO = new IDVariant(0,IDVariant.STRING);
      IDVariant v_RESULTCODE = null;
      v_RESULTCODE = new IDVariant(GCMHelper.ParseResultPlain(JsonRitorno.stringValue(),out v_INFOESITO));
      if (v_RESULTCODE.compareTo((new IDVariant(0)), true)>=0)
      {
        SQL = new StringBuilder();
        SQL.Append("select ");
        SQL.Append("  A.TENTATIVI as NUMETENTSPED ");
        SQL.Append("from ");
        SQL.Append("  SPEDIZIONI A ");
        SQL.Append("where (A.ID = " + IDL.CSql(IDSpedizione, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!QV.EOF()) QV.MoveNext();
        if (!QV.EOF())
        {
          v_NUMETENTSPED = QV.Get("NUMETENTSPED", IDVariant.INTEGER) ;
        }
        QV.Close();
        v_STATOSPEDIZI = (new IDVariant("S"));
        IDVariant v_INFOSPEDIZIO = null;
        v_INFOSPEDIZIO = new IDVariant(v_INFOESITO);
        // 
        // Invio effettuato con successo
        // 
        if (v_RESULTCODE.equals((new IDVariant(0)), true))
        {
          v_INFOSPEDIZIO = (new IDVariant(""));
        }
        // 
        // In questi casi il device non è più attivo
        // 
        else if (v_RESULTCODE.equals((new IDVariant(101)), true) || v_RESULTCODE.equals((new IDVariant(102)), true) || v_RESULTCODE.equals((new IDVariant(103)), true) || v_RESULTCODE.equals((new IDVariant(104)), true))
        {
          // 
          // In questi casi posso disabilitare il device token
          // 
          v_STATOSPEDIZI = (new IDVariant("E"));
          SQL = new StringBuilder();
          SQL.Append("update DEV_TOKENS set ");
          SQL.Append("  FLG_RIMOSSO = 'S', ");
          SQL.Append("  FLG_ATTIVO = 'N', ");
          SQL.Append("  DATA_RIMOZ = SYSDATE ");
          SQL.Append("where (REG_ID = " + IDL.CSql(RegidSpedizione, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
          MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
        }
        // 
        // Nel caso di errori bloccanti non faccio altri tentativi
        // di invio
        // 
        else if (v_RESULTCODE.equals((new IDVariant(105)), true) || v_RESULTCODE.equals((new IDVariant(106)), true) || v_RESULTCODE.equals((new IDVariant(199)), true))
        {
          v_STATOSPEDIZI = (new IDVariant("E"));
        }
        // 
        // In questo caso GMC comunica un regId che va rimpiazzato
        // con quello presente nella base dati. InfoEsito contiene
        // il nuovo regId
        // 
        else if (v_RESULTCODE.equals((new IDVariant(10)), true))
        {
          // 
          // In questo caso GMC comunica un regId che va rimpiazzato
          // con quello presente nella base
          // 
          v_INFOSPEDIZIO = new IDVariant(JsonRitorno);
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
          QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
          if (!QV.EOF()) QV.MoveNext();
          if (!QV.EOF())
          {
            v_VCOUNT = QV.Get("COUNT1", IDVariant.INTEGER) ;
          }
          QV.Close();
          if (v_VCOUNT.equals((new IDVariant(0)), true))
          {
            // 
            // Non esiste un'altra riga con quel regId, aggiorno la
            // riga vecchia con il nuovo canonical id
            // 
            SQL = new StringBuilder();
            SQL.Append("update DEV_TOKENS set ");
            SQL.Append("  REG_ID = " + IDL.CSql(v_INFOESITO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + " ");
            SQL.Append("where (REG_ID = " + IDL.CSql(RegidSpedizione, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
          }
          else
          {
            // 
            // C'è già un'altra riga con lo stesso regId, quindi posso
            // cancellare quella corrente per evitare invii doppi
            // 
            SQL = new StringBuilder();
            SQL.Append("update DEV_TOKENS set ");
            SQL.Append("  FLG_RIMOSSO = 'S', ");
            SQL.Append("  FLG_ATTIVO = 'N', ");
            SQL.Append("  DATA_RIMOZ = SYSDATE ");
            SQL.Append("where (REG_ID = " + IDL.CSql(RegidSpedizione, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ") ");
            MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
          }
        }
        // 
        // In questi casi posso ritentare l'invio del messaggio
        // in un momento successivo
        // 
        else if (v_RESULTCODE.equals((new IDVariant(200)), true))
        {
          // 
          // In questi casi posso ritentare l'invio del messaggio
          // in un momento successivo
          // 
          v_STATOSPEDIZI = (new IDVariant("W"));
          v_NUMETENTSPED = IDL.Add(v_NUMETENTSPED, (new IDVariant(1)));
          if (v_NUMETENTSPED.compareTo(v_MAXNUMERTENT, true)>=0)
          {
            v_STATOSPEDIZI = (new IDVariant("E"));
          }
        }
        // WriteDebug(IDL.FormatMessage((new IDVariant("ERROR: Problemi. Messaggio non in coda: spedizione id |1 codice errore |2 info |3")), IDL.ToString(), IDL.ToString(), v_INFO));
        SQL = new StringBuilder();
        SQL.Append("update SPEDIZIONI set ");
        SQL.Append("  INFO = " + IDL.CSql(v_INFOSPEDIZIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  FLG_STATO = " + IDL.CSql(v_STATOSPEDIZI, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  DAT_ELAB = SYSDATE, ");
        SQL.Append("  TENTATIVI = " + IDL.CSql(v_NUMETENTSPED, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " ");
        SQL.Append("where (ID = " + IDL.CSql(IDSpedizione, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
      }
      else
      {
        SQL = new StringBuilder();
        SQL.Append("update SPEDIZIONI set ");
        SQL.Append("  FLG_STATO = 'E', ");
        SQL.Append("  INFO = " + IDL.CSql(JsonRitorno, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
        SQL.Append("  DAT_ELAB = SYSDATE, ");
        SQL.Append("  TENTATIVI = " + IDL.CSql(v_NUMETENTSPED, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " ");
        SQL.Append("where (ID = " + IDL.CSql(IDSpedizione, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
        MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
      }
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "ElaboraRisultatoGCMNotification", _e);
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
      // 
      // Send Win Store Notification Body
      // Corpo Procedura
      // 
      IDVariant v_MAXNUMERTENT = null;
      v_MAXNUMERTENT = (new IDVariant(3));
      IDVariant v_IMSGELABORAT = null;
      v_IMSGELABORAT = (new IDVariant(0));
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // Ciclo per ogni applicazione che ha messaggi in coda
      // 
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
      C2 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!C2.EOF()) C2.MoveNext();
      while (!C2.EOF())
      {
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
        QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!QV.EOF()) QV.MoveNext();
        v_TROVATAAPP = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
        if (!QV.EOF())
        {
          v_VWNSSEAPPUSE = QV.Get("WNSSECAPPUSE", IDVariant.STRING) ;
          v_VWNPASEIDAPS = QV.Get("WNPASEIDAPPS", IDVariant.STRING) ;
          v_VWNXMTEAPPUS = QV.Get("WNXMTEAPPUSE", IDVariant.STRING) ;
        }
        QV.Close();
        // 
        // Se trovo ma configurazione (ovvio)
        // 
        if (v_TROVATAAPP.booleanValue() && IDL.NullValue(v_VWNSSEAPPUSE,(new IDVariant(""))).compareTo((new IDVariant("")), true)!=0)
        {
          IDVariant v_ACCESSTOKEN = null;
          v_ACCESSTOKEN = new IDVariant(WNSHelperInde.GetWinStoreAccessToken(v_VWNSSEAPPUSE.stringValue(), v_VWNPASEIDAPS.stringValue()));
          // 
          // Raggruppa le spedizione con lo stesso messaggio
          // Sono nella fascia oraria prevista per il refresh dei
          // dati...
          // 
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
          SQL.Append("and   ((A.DAT_ELAB IS NULL) OR SYSDATE - A.DAT_ELAB > 0.100) ");
          C4 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
          C4.setColUnbound(2,true);
          if (!C4.EOF()) C4.MoveNext();
          while (!C4.EOF())
          {
            // 
            // Se c'è stato un errore nella generazione dell'access
            // tocken mi fermo
            // 
            if (v_ACCESSTOKEN.equals((new IDVariant("")), true))
            {
              break;
            }
            v_IMSGELABORAT = IDL.Add(v_IMSGELABORAT, (new IDVariant(1)));
            // 
            // Se ho raggiunto il numero massimo di elaborazioni da
            // effettuare
            // 
            if (v_IMSGELABORAT.compareTo(GLBMAXMESC2D, true)>0)
            {
              v_IMSGELABORAT = (new IDVariant(0));
              IDVariant v_SMSG = null;
              v_SMSG = IDL.FormatMessage((new IDVariant("WinStore: Ne ho spediti |1. L'ultimo è il |2")), IDL.ToString(GLBMAXMESC2D), IDL.ToString(C4.Get("ID")));
              WriteDebug(v_SMSG);
              break;
            }
            IDVariant v_ESITOINVIO = new IDVariant(0,IDVariant.STRING);
            IDVariant v_SRET = null;
            v_SRET = new IDVariant(WNSHelperInde.SendWinStorePushNotification(v_ACCESSTOKEN.stringValue(), C4.Get("RREGID").stringValue(), C4.Get("RMESSAGGIO").stringValue(), out v_ESITOINVIO));
            // 
            // Controllo del risultato
            // 
            if (v_SRET.equals((new IDVariant(-1)), true))
            {
              SQL = new StringBuilder();
              SQL.Append("update SPEDIZIONI set ");
              SQL.Append("  DAT_ELAB = SYSDATE, ");
              SQL.Append("  INFO = " + IDL.CSql(v_ESITOINVIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  FLG_STATO = 'S' ");
              SQL.Append("where (ID = " + IDL.CSql(C4.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
              MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            }
            else
            {
              if (v_SRET.equals((new IDVariant(100)), true))
              {
                v_ACCESSTOKEN = new IDVariant(WNSHelperInde.GetWinStoreAccessToken(v_VWNSSEAPPUSE.stringValue(), v_VWNPASEIDAPS.stringValue()));
              }
              if (v_SRET.equals((new IDVariant(101)), true) || v_SRET.equals((new IDVariant(199)), true))
              {
                IDVariant v_TENTATIVTEMP = null;
                v_TENTATIVTEMP = (new IDVariant(1));
                if (!(IDL.IsNull(C2.Get("NUMETENTSPED"))))
                {
                  v_TENTATIVTEMP = IDL.Add(C2.Get("NUMETENTSPED"), (new IDVariant(1)));
                }
                if (v_TENTATIVTEMP.compareTo(v_MAXNUMERTENT, true)<=0)
                {
                  SQL = new StringBuilder();
                  SQL.Append("update SPEDIZIONI set ");
                  SQL.Append("  INFO = " + IDL.CSql(v_ESITOINVIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
                  SQL.Append("  FLG_STATO = 'W', ");
                  SQL.Append("  TENTATIVI = " + IDL.CSql(v_TENTATIVTEMP, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " ");
                  SQL.Append("where (ID = " + IDL.CSql(C4.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
                  MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
                }
                else
                {
                  SQL = new StringBuilder();
                  SQL.Append("update SPEDIZIONI set ");
                  SQL.Append("  DAT_ELAB = SYSDATE, ");
                  SQL.Append("  INFO = " + IDL.CSql(v_ESITOINVIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
                  SQL.Append("  FLG_STATO = 'E' ");
                  SQL.Append("where (ID = " + IDL.CSql(C4.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
                  MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
                }
              }
            }
            C4.MoveNext();
          }
          C4.Close();
        }
        IDL.Sleep((new IDVariant(1)).intValue()*1000); 
        C2.MoveNext();
      }
      C2.Close();
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "SendWinStoreNotification", _e);
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
      // 
      // Send Win Phone Notification Body
      // Corpo Procedura
      // 
      IDVariant v_MAXNUMERTENT = null;
      v_MAXNUMERTENT = (new IDVariant(3));
      IDVariant v_IMSGELABORAT = null;
      v_IMSGELABORAT = (new IDVariant(0));
      // 
      // Sono in una fascia oraria in cui non devo fare il refresh
      //  Azzero la variabile
      // Ciclo per ogni applicazione che ha messaggi in coda
      // 
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
      C2 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!C2.EOF()) C2.MoveNext();
      while (!C2.EOF())
      {
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
        QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!QV.EOF()) QV.MoveNext();
        v_TROVATAAPP = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
        if (!QV.EOF())
        {
          v_VWNXMTEAPPUS = QV.Get("WNXMTEAPPUSE", IDVariant.STRING) ;
        }
        QV.Close();
        // 
        // Se trovo ma configurazione (ovvio)
        // 
        if (v_TROVATAAPP.booleanValue())
        {
          // 
          // Raggruppa le spedizione con lo stesso messaggio
          // Sono nella fascia oraria prevista per il refresh dei
          // dati...
          // 
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
          SQL.Append("and   ((A.DAT_ELAB IS NULL) OR SYSDATE - A.DAT_ELAB > 0.100) ");
          C4 = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
          C4.setColUnbound(2,true);
          if (!C4.EOF()) C4.MoveNext();
          while (!C4.EOF())
          {
            // 
            // Se c'è stato un errore nella generazione dell'access
            // tocken mi fermo
            // 
            v_IMSGELABORAT = IDL.Add(v_IMSGELABORAT, (new IDVariant(1)));
            // 
            // Se ho raggiunto il numero massimo di elaborazioni da
            // effettuare
            // 
            if (v_IMSGELABORAT.compareTo(GLBMAXMESC2D, true)>0)
            {
              v_IMSGELABORAT = (new IDVariant(0));
              IDVariant v_SMSG = null;
              v_SMSG = IDL.FormatMessage((new IDVariant("WinPhone: Ne ho spediti |1. L'ultimo è il |2")), IDL.ToString(GLBMAXMESC2D), IDL.ToString(C4.Get("ID")));
              WriteDebug(v_SMSG);
              break;
            }
            IDVariant v_ESITOINVIO = new IDVariant(0,IDVariant.STRING);
            IDVariant v_SRET = null;
            v_SRET = new IDVariant(WNSHelperInde.SendWinPhonePushNotification(C4.Get("RREGID").stringValue(), C4.Get("RMESSAGGIO").stringValue(), out v_ESITOINVIO));
            // 
            // Controllo del risultato
            // 
            if (v_SRET.equals((new IDVariant(-1)), true))
            {
              SQL = new StringBuilder();
              SQL.Append("update SPEDIZIONI set ");
              SQL.Append("  DAT_ELAB = SYSDATE, ");
              SQL.Append("  INFO = " + IDL.CSql(v_ESITOINVIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  FLG_STATO = 'S' ");
              SQL.Append("where (ID = " + IDL.CSql(C4.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
              MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
            }
            else
            {
              if (v_SRET.equals((new IDVariant(199)), true))
              {
                IDVariant v_TENTATIVTEMP = null;
                v_TENTATIVTEMP = (new IDVariant(1));
                if (!(IDL.IsNull(C2.Get("NUMETENTSPED"))))
                {
                  v_TENTATIVTEMP = IDL.Add(C2.Get("NUMETENTSPED"), (new IDVariant(1)));
                }
                if (v_TENTATIVTEMP.compareTo(v_MAXNUMERTENT, true)<=0)
                {
                  SQL = new StringBuilder();
                  SQL.Append("update SPEDIZIONI set ");
                  SQL.Append("  INFO = " + IDL.CSql(v_ESITOINVIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
                  SQL.Append("  FLG_STATO = 'W', ");
                  SQL.Append("  TENTATIVI = " + IDL.CSql(v_TENTATIVTEMP, IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + " ");
                  SQL.Append("where (ID = " + IDL.CSql(C4.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
                  MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
                }
                else
                {
                  SQL = new StringBuilder();
                  SQL.Append("update SPEDIZIONI set ");
                  SQL.Append("  DAT_ELAB = SYSDATE, ");
                  SQL.Append("  INFO = " + IDL.CSql(v_ESITOINVIO, IDL.FMT_CHAR, MainFrm.NotificatoreDBObject.DBO()) + ", ");
                  SQL.Append("  FLG_STATO = 'E' ");
                  SQL.Append("where (ID = " + IDL.CSql(C4.Get("ID"), IDL.FMT_NUM, MainFrm.NotificatoreDBObject.DBO()) + ") ");
                  MainFrm.NotificatoreDBObject.DBO().Execute(SQL);
                }
              }
            }
            C4.MoveNext();
          }
          C4.Close();
        }
        IDL.Sleep((new IDVariant(1)).intValue()*1000); 
        C2.MoveNext();
      }
      C2.Close();
      return 0;
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "SendWinPhoneNotification", _e);
      return -1;
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
      QV = MainFrm.NotificatoreDBObject.DBO().OpenRS(SQL);
      if (!QV.EOF()) QV.MoveNext();
      if (!QV.EOF())
      {
        IMDB.set_Value(IMDBDef1.TBL_DATISESSIONE, IMDBDef1.FLD_DATISESSIONE_IDUTENTSESSI, 0, QV.Get("IDUTENTE", IDVariant.INTEGER));
        IMDB.set_Value(IMDBDef1.TBL_DATISESSIONE, IMDBDef1.FLD_DATISESSIONE_COGNUTENSESS, 0, QV.Get("COGNOMUTENTE", IDVariant.STRING));
        IMDB.set_Value(IMDBDef1.TBL_DATISESSIONE, IMDBDef1.FLD_DATISESSIONE_NOMEUTENSESS, 0, QV.Get("NOMEUTENTE", IDVariant.STRING));
      }
      QV.Close();
      // 
      // Se ho eseguito il login salvo i dati e torno vero
      // 
      if (IMDB.Value(IMDBDef1.TBL_DATISESSIONE, IMDBDef1.FLD_DATISESSIONE_IDUTENTSESSI, 0).compareTo((new IDVariant(0)), true)>0)
      {
        MainFrm.SaveSetting((new IDVariant("icalcio")),(new IDVariant("email")),eMail); 
        MainFrm.SaveSetting((new IDVariant("icalcio")),(new IDVariant("password")),Password); 
        MainFrm.set_UserRole((new IDVariant(3)));
        return (new IDVariant(-1)).booleanValue();
      }
      else
      {
        MainFrm.set_UserRole((new IDVariant(5)));
        return (new IDVariant(0)).booleanValue();
      }
    }
    catch (Exception _e)
    {
      MainFrm.ErrObj.ProcError ("Notificatore", "EsegueLogin", _e);
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
