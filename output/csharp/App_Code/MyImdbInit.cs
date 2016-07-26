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
  public static int IMDB_BASEIDX = 0;

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
    ImpostazioniWinPhone.ImdbInit(IMDB);
    DeviceIDWinPhone.ImdbInit(IMDB);
    SpedizioniWinPhone.ImdbInit(IMDB);
    InvioWinphoneManuale.ImdbInit(IMDB);
    ImpostazioniWinStore.ImdbInit(IMDB);
    DeviceIDWinStore.ImdbInit(IMDB);
    SpedizioniWinStore.ImdbInit(IMDB);
    InvioWNSManuale.ImdbInit(IMDB);
    DispositiviNoti.ImdbInit(IMDB);
    Lingue.ImdbInit(IMDB);
    DeviceToken.ImdbInit(IMDB);
    PushAppEvents.ImdbInit(IMDB);
    SalesData.ImdbInit(IMDB);
    Currencies.ImdbInit(IMDB);
    PromoCodes.ImdbInit(IMDB);
    CountryCodes.ImdbInit(IMDB);
    ProductTypeIdentifiers.ImdbInit(IMDB);
    FiscalCalendar.ImdbInit(IMDB);
    LoginIpad.ImdbInit(IMDB);
    LoginIphone.ImdbInit(IMDB);
    GraficoAndamento.ImdbInit(IMDB);
    //
    IMDB.set_TblNumField(IMDBDef1.TMP_RECORDSET, 21);
    IMDB.set_Version(1468573217);
    //
    // Set all tables in a modified state
    //
    IMDB.ResetAllModified(-1);
  }

  // ********************************************************
  // Appende tutte le mie tabelle nell'IMDB di ownobj
  // ********************************************************
  public override int GetBaseIndex()
  {
    return MyImdbInit.IMDB_BASEIDX;
  }
  public override void SetBaseIndex(int newIndex)
  {
    MyImdbInit.IMDB_BASEIDX = newIndex;
  }
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
    // Se non l'ho ancora fatto shifto tutte le costanti contenute in IMDBDefXX
    if (MyImdbInit.IMDB_OFFSET == 0)
    {
      // Per cominciare estraggo un po' di dati utili
      int baseidx = 0;
      if (Dst is com.progamma.ids.ImdbInit)
        baseidx = ((com.progamma.ids.ImdbInit)Dst).GetBaseIndex();
      if (Dst is com.progamma.svc.ImdbInit)
        baseidx = ((com.progamma.svc.ImdbInit)Dst).GetBaseIndex();
      if (Dst is com.progamma.ws.ImdbInit)
        baseidx = ((com.progamma.ws.ImdbInit)Dst).GetBaseIndex();
      int mySize = IMDB.DBSize();
      int ownSize = dstIMDB.DBSize();
      //
      // Non ho mai caricato prima questo componente ma l'IMDB che riceverà le mie tabelle IMDB
      // ha un baseidx diverso da 0 (questo può succedere se vengono caricati componenti dinamici
      // e vengono caricati in ordine diverso. Es: sessione 1 carica Comp1, sessione 2 carica Comp2
      // in questo caso la sessione 2 non ha mai caricato Comp1 ma se dovesse farlo deve esserci spazio
      // per le sue tabelle IMDB nello stesso posto in cui erano prima!)
      // Quindi se il componente base ha delle zone che non possono essere occupate (causa componenti
      // già caricati in altre sessioni) sposto le mie tabelle IMDB in avanti di quell'offset così la
      // AppendTables funziona correttamente
      if (baseidx != 0)
      {
        IMDB.MoveTables(baseidx);
        //
        // Appendo tutte le mie tabelle dentro al DST (le mie tabelle iniziano da baseidx, le ho spostate sopra)
        dstIMDB.AppendTables(IMDB, baseidx);
        //
        // Questo è l'indice della mia prima tabella IMDB in DST
        MyImdbInit.IMDB_OFFSET = baseidx;
      }
      else
      {
        // Appendo tutte le mie tabelle dentro al DST (le mie tabelle sono all'inizio)
        dstIMDB.AppendTables(IMDB, 0);
        //
        // Ora questo è l'indice della mia prima tabella IMDB in DST
        MyImdbInit.IMDB_OFFSET = ownSize;
      }
      //
      // Sposto tutte le mie costanti dell'offset appena calcolato
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
      //
      // Aggiorno l'indice di "riempimento" del DST. Se verrà caricato un nuovo componente 
      // le sue tabelle IMDB dovranno finire dopo la mia ultima tabella IMDB
      if (Dst is com.progamma.ids.ImdbInit)
        ((com.progamma.ids.ImdbInit)Dst).SetBaseIndex(dstIMDB.DBSize());
      if (Dst is com.progamma.svc.ImdbInit)
        ((com.progamma.svc.ImdbInit)Dst).SetBaseIndex(dstIMDB.DBSize());
      if (Dst is com.progamma.ws.ImdbInit)
        ((com.progamma.ws.ImdbInit)Dst).SetBaseIndex(dstIMDB.DBSize());
    }
    else
    {
      // Il componente è già stato caricato in precedenza... mergio semplicemente le tabelle
      // (le mie tabelle iniziano dalla posizione in cui le ho spostate l'ultima volta che questo
      // componente è stato caricato)
      dstIMDB.AppendTables(IMDB, MyImdbInit.IMDB_OFFSET);
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
