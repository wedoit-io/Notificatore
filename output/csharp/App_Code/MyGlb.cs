// **********************************************
// Global functions and constants
// Instant WEB Application: www.progamma.com
// Project : Mobile Manager
// **********************************************
using System;
using System.Reflection;
using com.progamma.ids;
using com.progamma;

// **********************************************
// **********************************************
public class MyGlb : Glb
{
  static int FRM_OFFSET = 0;
  
  // Command Constants Enumeration
  public static int FRM_CONFIGURAZIO = 1;
  public static int FRM_PRODOTTI = 2;
  public static int FRM_APILOCATOR = 3;
  public static int FRM_APPLICAZIONI = 4;
  public static int FRM_LOGS = 5;
  public static int FRM_IMPOSTAZIIOS = 6;
  public static int FRM_DEVICTOKEIOS = 7;
  public static int FRM_INVNOTAUTEIO = 8;
  public static int FRM_INVNOADINOIO = 9;
  public static int FRM_SPEDIZIONIOS = 10;
  public static int FRM_IMPOSTANDROI = 11;
  public static int FRM_DEVICIDANDRO = 12;
  public static int FRM_INVNOTAUTEAN = 13;
  public static int FRM_SPEDIZANDROI = 14;
  public static int FRM_INVIOGMCMANU = 15;
  public static int FRM_TESTSPEDIZIO = 16;
  public static int FRM_LOGINIPAD = 17;
  public static int FRM_LOGINIPHONE = 18;
  public static int FRM_IMPOSWINPHON = 19;
  public static int FRM_DEVIIDWINPHO = 20;
  public static int FRM_SPEDIWINPHON = 21;
  public static int FRM_INVIWINPMANU = 22;
  public static int FRM_IMPOSWINSTOR = 23;
  public static int FRM_DEVIIDWINSTO = 24;
  public static int FRM_SPEDIWINSTOR = 25;
  public static int FRM_INVIOWNSMANU = 26;
  public static int FRM_SALESDATA = 27;
  public static int FRM_CURRENCIES = 28;
  public static int FRM_PROMOCODES = 29;
  public static int FRM_COUNTRYCODES = 30;
  public static int FRM_PRODTYPEIDEN = 31;
  public static int FRM_FISCALCALEND = 32;
  public static int FRM_GRAFICANDAME = 33;
  public static int FRM_DISPOSITNOTI = 34;
  public static int FRM_LINGUE = 35;
  public static int FRM_DEVICETOKEN = 36;
  //
  public static int MAX_FORMS = 36;

  public static int CMDS_INVIOMANUAL2 = 1;
  public static int CMDS_NUOVOCOMMSE2 = 2;
  public static int CMDS_INVIOMANUAL3 = 3;
  public static int CMDS_NUOVOCOMMSET = 4;
  public static int CMDS_INVIOMANUAL1 = 5;
  public static int CMDS_NUOVOCOMMSE1 = 6;
  public static int CMDS_TOOLBARFORM = 7;
  public static int CMDS_TOOLBASPEDIZ = 8;
  public static int CMDS_TOOLBARFORM1 = 9;
  public static int CMDS_TOOLBARLOG = 10;
  public static int CMDS_DEBUG1 = 11;
  public static int CMDS_WINSTORE = 12;
  public static int CMDS_WINPHONE = 13;
  public static int CMDS_ANDROID = 14;
  public static int CMDS_IOS = 15;
  public static int CMDS_GENERALE = 16;
  //
  public static int MAX_COMMAND_SETS = 16;

  public static int CMD_CONFIGURAZIO = 1;
  public static int CMD_LOGS = 2;
  public static int CMD_LINGUE = 3;
  public static int CMD_SEP1 = 4;
  public static int CMD_APILOCATOR = 5;
  public static int CMD_PRODOTTI = 6;
  public static int CMD_APPLICAZIONI = 7;
  public static int CMD_DISPOSITNOTI = 8;
  public static int CMD_IMPOSTAZION2 = 9;
  public static int CMD_DEVICETOKENS = 10;
  public static int CMD_SPEDIZIONI1 = 11;
  public static int CMD_SALESDATA1 = 12;
  public static int CMD_CURRENCIES = 13;
  public static int CMD_PROMOCODES = 14;
  public static int CMD_COUNTRYCODES = 15;
  public static int CMD_PRODTYPEIDEN = 16;
  public static int CMD_FISCALCALEND = 17;
  public static int CMD_SEP2 = 18;
  public static int CMD_SALESDATA = 19;
  public static int CMD_GRAFICANDAME = 20;
  public static int CMD_IMPOSTAZION1 = 21;
  public static int CMD_DEVICEID1 = 22;
  public static int CMD_SPEDIZIONI2 = 23;
  public static int CMD_IMPOSTAZION3 = 24;
  public static int CMD_DEVICEID2 = 25;
  public static int CMD_SPEDIZIONI3 = 26;
  public static int CMD_IMPOSTAZIONI = 27;
  public static int CMD_DEVICEID = 28;
  public static int CMD_SPEDIZIONI = 29;
  public static int CMD_DEBUG = 30;
  public static int CMD_SVUOTALOG = 31;
  public static int CMD_SEP3 = 32;
  public static int CMD_LOGSPEDIZION = 33;
  public static int CMD_LOGFEEDBACK = 34;
  public static int CMD_SVUOLOGSFILE = 35;
  public static int CMD_INVIADISPNOT = 36;
  public static int CMD_INVIAAUTENTI = 37;
  public static int CMD_CHECKFEEDBA1 = 38;
  public static int CMD_CHECKCERTS = 39;
  public static int CMD_ELIMININVIAT = 40;
  public static int CMD_RIMETINATTES = 41;
  public static int CMD_INVIPUSHAUTE = 42;
  public static int CMD_INVIOMANUAL4 = 43;
  public static int CMD_INVIASUBITO1 = 44;
  public static int CMD_TESTSPEDIZI1 = 45;
  public static int CMD_INVIOMANUALE = 46;
  public static int CMD_INVIASUBITO = 47;
  public static int CMD_INVIOMANUAL5 = 48;
  public static int CMD_INVIASUBITO2 = 49;
  //
  public static int MAX_COMMANDS = 49;


  // Indicator Constants Enumeration
  public static int MAX_INDICATORS = 0;


  // Indicator Constants Enumeration
  public static int TIM_REFRESPOLLIN = 1;
  //
  public static int MAX_TIMERS = 1;


  // VIS ATTR Constants
  public const int VIS_DEFAPANESTYL = 1;
  public const int VIS_PRIMAKEYFIEL = 2;
  public const int VIS_FOREIKEYFIEL = 3;
  public const int VIS_BLOCKEFIELDS = 4;
  public const int VIS_LOOKUPFIELDS = 5;
  public const int VIS_LABELFIELD = 6;
  public const int VIS_HYPERLIFIELD = 7;
  public const int VIS_IMAGEFIELD = 8;
  public const int VIS_INTESTPICCOL = 9;
  public const int VIS_COMMANBUTTO1 = 10;
  public const int VIS_COMAIPHOGRAN = 11;
  public const int VIS_COMANDIPHONE = 12;
  public const int VIS_CHECKSTYLE = 13;
  public const int VIS_PASSWORSTYLE = 14;
  public const int VIS_RADIOSTYLE = 15;
  public const int VIS_NORMALFIELDS = 16;
  public const int VIS_VIDEATIPHONE = 17;
  public const int VIS_BORDORIZCLIC = 18;
  public const int VIS_ARTICOACQUIS = 19;
  public const int VIS_ARTICNONACQU = 20;
  public const int VIS_BORDNORMCLIC = 21;
  public const int VIS_INTESTIPHONE = 22;
  public const int VIS_RADIOIPHONE = 23;
  public const int VIS_HTML1 = 24;
  public const int VIS_HTMLORIZ = 25;
  public const int VIS_HTMLEDITSTYL = 26;
  public const int VIS_COORDINATA = 27;
  public const int VIS_HTML = 28;
  public const int VIS_HTMLSENZBORD = 29;
  public const int VIS_TRASPARENTE = 30;
  public const int VIS_SQUADRATTIVA = 31;
  public const int VIS_GIOCATCAMBIA = 32;
  public const int VIS_SFONDOGIALLO = 33;
  public const int VIS_SFONDOROSSO = 34;
  public const int VIS_SFONDOVERDE = 35;
  public const int VIS_INSCADENZA = 36;
  public const int VIS_DEFAREPOSTYL = 37;
  public const int VIS_COMMANBUTTON = 38;
  public const int VIS_HYPERLINK = 39;
  public const int VIS_RIQUADRO = 40;
  public const int VIS_RIQUADROBLU = 41;
  public const int VIS_NORMALREPORT = 42;
  public const int VIS_CAMPIIPHONE = 43;
  public const int VIS_SIMPLICITY = 44;
  public const int VIS_CASUAL = 45;
  public const int VIS_SEATTLE = 46;
  public const int VIS_DEFAMOBISTYL = 47;
  public const int VIS_PRIKEYFIEMOB = 48;
  public const int VIS_FORKEYFIEMOB = 49;
  public const int VIS_BLOCKFIELMOB = 50;
  public const int VIS_LOOKUFIELMOB = 51;
  public const int VIS_LABELFIELMOB = 52;
  public const int VIS_HYPERFIELMOB = 53;
  public const int VIS_IMAGEFIELMOB = 54;
  public const int VIS_COMMABUTTMOB = 55;
  public const int VIS_CHECKSTYLMOB = 56;
  public const int VIS_PASSWSTYLMOB = 57;
  public const int VIS_RADIOSTYLMOB = 58;
  public const int VIS_NORMAFIELMOB = 59;
  public const int VIS_HTMEDISTYMOB = 60;
  public const int MAX_VISATTR = 60;


  public static void ShiftFrmConst(int frmOfs, WebEntryPoint w)
  {
    if (MyGlb.FRM_OFFSET == 0)
    {
      MyGlb.FRM_OFFSET += frmOfs;
      //
      // Use reflection for shift
      String tn = (w.CompNameSpace != null ? w.CompNameSpace + "." : "");
      FieldInfo[] props = Assembly.GetExecutingAssembly().GetType(tn + "MyGlb").GetFields();
      for (int j = 0; j < props.Length; j++)
      {
        FieldInfo p = props[j];
        if (p.Name.StartsWith("FRM_"))
          p.SetValue(null, ((int)p.GetValue(null)) + MyGlb.FRM_OFFSET);
      }
    }
  }
}
