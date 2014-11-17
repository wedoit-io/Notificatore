// **********************************************
// In Memory Database Initialization
// Project : Mobile Manager
// **********************************************
using System;
using System.Reflection;
using com.progamma;
using com.progamma.ids;

// **********************************************
// In Memory Database Initialization
// **********************************************
[Serializable]
public sealed class MyImdbInit : ImdbInit
{
  public static int IMDB_OFFSET = 0;

  // **********************************************
  // Costruttore
  // **********************************************
  public MyImdbInit(WebEntryPoint p)
    : base(p)
  {
    //
    IMDB.set_DBSize(65 + MyImdbInit.IMDB_OFFSET);
    //
    Init_TBL_DATISESSIONE();
    Init_TBL_SELETTGRAFIC();
    //
    //
    Configurazione.ImdbInit(IMDB);
    Prodotti.ImdbInit(IMDB);
    APILocator.ImdbInit(IMDB);
    Applicazioni.ImdbInit(IMDB);
    Logs.ImdbInit(IMDB);
    ImpostazioniIOS.ImdbInit(IMDB);
    DeviceTokenIOS.ImdbInit(IMDB);
    InvioNotificheAUtentiIOS.ImdbInit(IMDB);
    InvioNotificheADispoitiviNotiIOS.ImdbInit(IMDB);
    SpedizioniIOS.ImdbInit(IMDB);
    ImpostazioniAndroid.ImdbInit(IMDB);
    DeviceIDAndroid.ImdbInit(IMDB);
    InvioNotificheAUtentiAndroid.ImdbInit(IMDB);
    SpedizioniAndroid.ImdbInit(IMDB);
    InvioGMCManuale.ImdbInit(IMDB);
    TestSpedizione.ImdbInit(IMDB);
    LoginIpad.ImdbInit(IMDB);
    LoginIphone.ImdbInit(IMDB);
    ImpostazioniWinPhone.ImdbInit(IMDB);
    DeviceIDWinPhone.ImdbInit(IMDB);
    SpedizioniWinPhone.ImdbInit(IMDB);
    InvioWinphoneManuale.ImdbInit(IMDB);
    ImpostazioniWinStore.ImdbInit(IMDB);
    DeviceIDWinStore.ImdbInit(IMDB);
    SpedizioniWinStore.ImdbInit(IMDB);
    InvioWNSManuale.ImdbInit(IMDB);
    SalesData.ImdbInit(IMDB);
    Currencies.ImdbInit(IMDB);
    PromoCodes.ImdbInit(IMDB);
    CountryCodes.ImdbInit(IMDB);
    ProductTypeIdentifiers.ImdbInit(IMDB);
    FiscalCalendar.ImdbInit(IMDB);
    GraficoAndamento.ImdbInit(IMDB);
    DispositiviNoti.ImdbInit(IMDB);
    Lingue.ImdbInit(IMDB);
    DeviceToken.ImdbInit(IMDB);
    //
    IMDB.set_TblNumField(IMDBDef1.TMP_RECORDSET, 21);
    IMDB.set_Version(-1122311783);
    //
    // Set all tables in a modified state
    //
    IMDB.ResetAllModified(-1);
  }

  // ********************************************************
  // Appende tutte le mie tabelle nell'IMDB di ownobj
  // ********************************************************
  public override void AppendTo(Object Dst)
  {
    IMDBObj dstIMDB = null;
    if (Dst is com.progamma.ids.ImdbInit)
      dstIMDB = ((com.progamma.ids.ImdbInit)Dst).IMDB;
    if (Dst is com.progamma.svc.ImdbInit)
      dstIMDB = ((com.progamma.svc.ImdbInit)Dst).IMDB;
    if (Dst is com.progamma.ws.ImdbInit)
      dstIMDB = ((com.progamma.ws.ImdbInit)Dst).IMDB;
    //
    // Per cominciare appendo tutte le tabelle contenute in iobj dentro alle mie tabelle
    int ownSize = dstIMDB.DBSize();
    //
    dstIMDB.AppendTables(IMDB, MyImdbInit.IMDB_OFFSET);
    //
    // Se non l'ho ancora fatto shifto tutte le costanti contenute in IMDBDefXX
    if (MyImdbInit.IMDB_OFFSET == 0)
    {
      MyImdbInit.IMDB_OFFSET = ownSize;
      //
      String tn = (MainFrm.CompNameSpace != null ? MainFrm.CompNameSpace + "." : "");
      for (int i = 1; i < 1000; i++)
      {
        Type T = Assembly.GetExecutingAssembly().GetType(tn + "IMDBDef" + i);
        if (T == null)
          break;
        //
        FieldInfo[] props = T.GetFields();
        for (int j = 0; j < props.Length; j++)
        {
          FieldInfo p = props[j];
          if (p.Name.StartsWith("PQRY_") || p.Name.StartsWith("QRY_") || p.Name.StartsWith("TBL_") || p.Name.Equals("TMP_RECORDSET"))
            p.SetValue(null, ((int)p.GetValue(null)) + MyImdbInit.IMDB_OFFSET);
        }
      }
    }
    //
    // Ora uso quello
    IMDB = dstIMDB;
  }
  
  // IMDB DDL Procedures
  private void Init_TBL_DATISESSIONE()
  {
    IMDB.set_TblNumField(IMDBDef1.TBL_DATISESSIONE, 4);
    IMDB.set_TblCode(IMDBDef1.TBL_DATISESSIONE, "TBL_DATISESSIONE");
    IMDB.set_FldCode(IMDBDef1.TBL_DATISESSIONE,IMDBDef1.FLD_DATISESSIONE_IDUTENTSESSI, "IDUTENTSESSI");
    IMDB.SetFldParams(IMDBDef1.TBL_DATISESSIONE,IMDBDef1.FLD_DATISESSIONE_IDUTENTSESSI,1,6,0);
    IMDB.set_FldCode(IMDBDef1.TBL_DATISESSIONE,IMDBDef1.FLD_DATISESSIONE_COMUUTENSESS, "COMUUTENSESS");
    IMDB.SetFldParams(IMDBDef1.TBL_DATISESSIONE,IMDBDef1.FLD_DATISESSIONE_COMUUTENSESS,1,6,0);
    IMDB.set_FldCode(IMDBDef1.TBL_DATISESSIONE,IMDBDef1.FLD_DATISESSIONE_COGNUTENSESS, "COGNUTENSESS");
    IMDB.SetFldParams(IMDBDef1.TBL_DATISESSIONE,IMDBDef1.FLD_DATISESSIONE_COGNUTENSESS,5,50,0);
    IMDB.set_FldCode(IMDBDef1.TBL_DATISESSIONE,IMDBDef1.FLD_DATISESSIONE_NOMEUTENSESS, "NOMEUTENSESS");
    IMDB.SetFldParams(IMDBDef1.TBL_DATISESSIONE,IMDBDef1.FLD_DATISESSIONE_NOMEUTENSESS,5,50,0);
    IMDB.TblAddNew(IMDBDef1.TBL_DATISESSIONE, 0);
  }

  private void Init_TBL_SELETTGRAFIC()
  {
    IMDB.set_TblNumField(IMDBDef1.TBL_SELETTGRAFIC, 5);
    IMDB.set_TblCode(IMDBDef1.TBL_SELETTGRAFIC, "TBL_SELETTGRAFIC");
    IMDB.set_FldCode(IMDBDef1.TBL_SELETTGRAFIC,IMDBDef1.FLD_SELETTGRAFIC_ID_UTENTE, "ID_UTENTE");
    IMDB.SetFldParams(IMDBDef1.TBL_SELETTGRAFIC,IMDBDef1.FLD_SELETTGRAFIC_ID_UTENTE,1,6,0);
    IMDB.set_FldCode(IMDBDef1.TBL_SELETTGRAFIC,IMDBDef1.FLD_SELETTGRAFIC_ID_APP, "ID_APP");
    IMDB.SetFldParams(IMDBDef1.TBL_SELETTGRAFIC,IMDBDef1.FLD_SELETTGRAFIC_ID_APP,1,9,0);
    IMDB.set_FldCode(IMDBDef1.TBL_SELETTGRAFIC,IMDBDef1.FLD_SELETTGRAFIC_TIPOSELEGRAF, "TIPOSELEGRAF");
    IMDB.SetFldParams(IMDBDef1.TBL_SELETTGRAFIC,IMDBDef1.FLD_SELETTGRAFIC_TIPOSELEGRAF,5,1,0);
    IMDB.set_FldCode(IMDBDef1.TBL_SELETTGRAFIC,IMDBDef1.FLD_SELETTGRAFIC_DATADASELGRA, "DATADASELGRA");
    IMDB.SetFldParams(IMDBDef1.TBL_SELETTGRAFIC,IMDBDef1.FLD_SELETTGRAFIC_DATADASELGRA,6,52,0);
    IMDB.set_FldCode(IMDBDef1.TBL_SELETTGRAFIC,IMDBDef1.FLD_SELETTGRAFIC_DATAASELEGRA, "DATAASELEGRA");
    IMDB.SetFldParams(IMDBDef1.TBL_SELETTGRAFIC,IMDBDef1.FLD_SELETTGRAFIC_DATAASELEGRA,6,52,0);
    IMDB.TblAddNew(IMDBDef1.TBL_SELETTGRAFIC, 0);
  }

}
