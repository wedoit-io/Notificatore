// **********************************************
// Global functions and constants
// Instant WEB Application: www.progamma.com
// Project : Mobile Manager
// **********************************************
using System;
using com.progamma.ids;
using com.progamma;

// **********************************************
// **********************************************
public class IMDBDef1 : Object
{
  // IMDB Constants
  // Temporary recordset for grouping
  //
  public static int TMP_RECORDSET = 0;

  // Definition of table: Notifiche
  //
  public static int TBL_NOTIFICHE3 = 1;
  public static int FLD_NOTIFICHE3_SQUADRA = 0;
  public static int FLD_NOTIFICHE3_AMBIENNOTIFI = 1;
  public static int FLD_NOTIFICHE3_MESSAGNOTIFI = 2;
  public static int FLD_NOTIFICHE3_DES_UTENTE = 3;
  public static int FLD_NOTIFICHE3_IDAPPLINOTIF = 4;
  public static int FLD_NOTIFICHE3_SOUND = 5;
  public static int FLD_NOTIFICHE3_BADGE = 6;

  // Definition of table: Notifiche
  //
  public static int TBL_NOTIFICHE5 = 2;
  public static int FLD_NOTIFICHE5_SQUADRA = 0;
  public static int FLD_NOTIFICHE5_AMBIENNOTIFI = 1;
  public static int FLD_NOTIFICHE5_MESSAGNOTIFI = 2;
  public static int FLD_NOTIFICHE5_DES_UTENTE = 3;
  public static int FLD_NOTIFICHE5_IDAPPLINOTIF = 4;
  public static int FLD_NOTIFICHE5_SOUND = 5;
  public static int FLD_NOTIFICHE5_BADGE = 6;

  // Definition of table: Notifiche
  //
  public static int TBL_NOTIFICHE = 3;
  public static int FLD_NOTIFICHE_SQUADRA = 0;
  public static int FLD_NOTIFICHE_AMBIENNOTIFI = 1;
  public static int FLD_NOTIFICHE_MESSAGNOTIFI = 2;
  public static int FLD_NOTIFICHE_DES_UTENTE = 3;
  public static int FLD_NOTIFICHE_IDAPPLINOTIF = 4;
  public static int FLD_NOTIFICHE_SOUND = 5;
  public static int FLD_NOTIFICHE_BADGE = 6;

  // Definition of table: Parametri
  //
  public static int TBL_PARAMETRI1 = 4;
  public static int FLD_PARAMETRI1_GOOGLE_API_ID = 0;
  public static int FLD_PARAMETRI1_DES_MESSAGGIO = 1;
  public static int FLD_PARAMETRI1_REG_ID = 2;
  public static int FLD_PARAMETRI1_RISUNOMEOGGE = 3;
  public static int FLD_PARAMETRI1_DEV_TOKEN = 4;
  public static int FLD_PARAMETRI1_ID_APPLICAZIONE = 5;

  // Definition of table: Dati Temp
  //
  public static int TBL_DATITEMP = 5;
  public static int FLD_DATITEMP_JSORITNOMOGG = 0;

  // Definition of table: Dati Di Login
  //
  public static int TBL_DATIDILOGIN = 6;
  public static int FLD_DATIDILOGIN_EMAINUOVPANN = 0;
  public static int FLD_DATIDILOGIN_PINNUOVOPANN = 1;
  public static int FLD_DATIDILOGIN_NOMUTENUOPAN = 2;
  public static int FLD_DATIDILOGIN_COGUTENUOPAN = 3;
  public static int FLD_DATIDILOGIN_GENUTENUOPAN = 4;
  public static int FLD_DATIDILOGIN_EMAUTENUOPAN = 5;
  public static int FLD_DATIDILOGIN_PASUTENUOPAN = 6;
  public static int FLD_DATIDILOGIN_COMUTENUOPAN = 7;

  // Definition of table: Dati Di Login
  //
  public static int TBL_DATIDILOGIN3 = 7;
  public static int FLD_DATIDILOGIN3_EMAINUOVPANN = 0;
  public static int FLD_DATIDILOGIN3_PINNUOVOPANN = 1;

  // Definition of table: Parametri
  //
  public static int TBL_PARAMETRI2 = 8;
  public static int FLD_PARAMETRI2_DES_MESSAGGIO = 0;
  public static int FLD_PARAMETRI2_REG_ID = 1;
  public static int FLD_PARAMETRI2_RISUNOMEOGGE = 2;
  public static int FLD_PARAMETRI2_DEV_TOKEN = 3;
  public static int FLD_PARAMETRI2_ID_APPLICAZIONE = 4;

  // Definition of table: Parametri
  //
  public static int TBL_PARAMETRI = 9;
  public static int FLD_PARAMETRI_DES_MESSAGGIO = 0;
  public static int FLD_PARAMETRI_REG_ID = 1;
  public static int FLD_PARAMETRI_RISUNOMEOGGE = 2;
  public static int FLD_PARAMETRI_DEV_TOKEN = 3;
  public static int FLD_PARAMETRI_ID_APPLICAZIONE = 4;
  public static int FLD_PARAMETRI_WNS_SECRET = 5;
  public static int FLD_PARAMETRI_WNS_SID = 6;
  public static int FLD_PARAMETRI_WNS_XML = 7;
  public static int FLD_PARAMETRI_ACCTOCNOMOGG = 8;

  // Definition of table: Dati Sessione
  //
  public static int TBL_DATISESSIONE = 10;
  public static int FLD_DATISESSIONE_IDUTENTSESSI = 0;
  public static int FLD_DATISESSIONE_COMUUTENSESS = 1;
  public static int FLD_DATISESSIONE_COGNUTENSESS = 2;
  public static int FLD_DATISESSIONE_NOMEUTENSESS = 3;

  // Definition of table: Selettori Grafico
  //
  public static int TBL_SELETTGRAFIC = 11;
  public static int FLD_SELETTGRAFIC_ID_UTENTE = 0;
  public static int FLD_SELETTGRAFIC_ID_APP = 1;
  public static int FLD_SELETTGRAFIC_TIPOSELEGRAF = 2;
  public static int FLD_SELETTGRAFIC_DATADASELGRA = 3;
  public static int FLD_SELETTGRAFIC_DATAASELEGRA = 4;

  // Table to contain panel selected row: Impostazioni
  //
  public static int PQRY_IMPOSTAZIONI = 12;
  public static int PQSL_IMPOSTAZIONI_ID = 0;
  public static int PQSL_IMPOSTAZIONI_FLG_REFRESH = 1;
  public static int PQSL_IMPOSTAZIONI_URL_APP = 2;
  public static int PQSL_IMPOSTAZIONI_PATH_CERTS = 3;
  public static int PQSL_IMPOSTAZIONI_ADMIN_MAIL = 4;
  public static int PQSL_IMPOSTAZIONI_WS_URL = 5;
  public static int PQSL_IMPOSTAZIONI_MAX_MESSAGGI = 6;
  public static int PQSL_IMPOSTAZIONI_FLG_CHECK = 7;
  public static int PQSL_IMPOSTAZIONI_NUM_TIMEOUT = 8;
  public static int PQSL_IMPOSTAZIONI_MAX_DAYS_RET = 9;
  public static int PQSL_IMPOSTAZIONI_FLG_DEL_REMOVED_TK = 10;
  public static int PQSL_IMPOSTAZIONI_MAX_MESSAGGI_C2DM = 11;
  public static int PQSL_IMPOSTAZIONI_FLG_DEBUG = 12;

  // Table to contain panel selected row: Prodotti
  //
  public static int PQRY_PRODOTTI = 13;
  public static int PQSL_PRODOTTI_ID = 0;
  public static int PQSL_PRODOTTI_NOME_APP = 1;

  // Table to contain panel selected row: API Locator
  //
  public static int PQRY_APILOCATOR = 14;
  public static int PQSL_APILOCATOR_ID = 0;
  public static int PQSL_APILOCATOR_NOME_APP = 1;
  public static int PQSL_APILOCATOR_DES_NOTA = 2;
  public static int PQSL_APILOCATOR_APP_KEY = 3;
  public static int PQSL_APILOCATOR_AUTH_KEY = 4;
  public static int PQSL_APILOCATOR_NOME_APP_STAT = 5;
  public static int PQSL_APILOCATOR_ID_PRODOTTO = 6;

  // Table to contain panel selected row: Dettagli App
  //
  public static int PQRY_DETTAGLIAPP = 15;
  public static int PQSL_DETTAGLIAPP_ID = 0;
  public static int PQSL_DETTAGLIAPP_ID_APP = 1;
  public static int PQSL_DETTAGLIAPP_DES_VERSIONE = 2;
  public static int PQSL_DETTAGLIAPP_DES_NOTA = 3;
  public static int PQSL_DETTAGLIAPP_FLG_BLOCCO = 4;
  public static int PQSL_DETTAGLIAPP_DES_MSG = 5;

  // Table to contain panel selected row: Dettagli Versione
  //
  public static int PQRY_DETTAGVERSIO = 16;
  public static int PQSL_DETTAGVERSIO_ID = 0;
  public static int PQSL_DETTAGVERSIO_ID_DETT_APP = 1;
  public static int PQSL_DETTAGVERSIO_ORDINAMENTO = 2;
  public static int PQSL_DETTAGVERSIO_APP_URL = 3;
  public static int PQSL_DETTAGVERSIO_DES_NOTA = 4;
  public static int PQSL_DETTAGVERSIO_FLG_ATTIVA = 5;

  // Table to contain panel selected row: Applicazioni
  //
  public static int PQRY_APPLICAZION2 = 17;
  public static int PQSL_APPLICAZION2_ID = 0;
  public static int PQSL_APPLICAZION2_NOME_APP = 1;
  public static int PQSL_APPLICAZION2_DES_NOTA = 2;
  public static int PQSL_APPLICAZION2_APP_KEY = 3;
  public static int PQSL_APPLICAZION2_AUTH_KEY = 4;
  public static int PQSL_APPLICAZION2_NOME_APP_STAT = 5;
  public static int PQSL_APPLICAZION2_ID_PRODOTTO = 6;
  public static int PQSL_APPLICAZION2_PRG_LINGUA = 7;

  // Table to contain panel selected row: Messaggi
  //
  public static int PQRY_MESSAGGI = 18;
  public static int PQSL_MESSAGGI_ID = 0;
  public static int PQSL_MESSAGGI_FLG_LEV_DEBUG = 1;
  public static int PQSL_MESSAGGI_TESTO = 2;
  public static int PQSL_MESSAGGI_DATA_LOG = 3;

  // Table to contain panel selected row: Applicazioni
  //
  public static int PQRY_APPLICAZION1 = 19;
  public static int PQSL_APPLICAZION1_ID = 0;
  public static int PQSL_APPLICAZION1_CERT_DEV = 1;
  public static int PQSL_APPLICAZION1_DES_NOTA = 2;
  public static int PQSL_APPLICAZION1_FLG_ATTIVA = 3;
  public static int PQSL_APPLICAZION1_FLG_AMBIENTE = 4;
  public static int PQSL_APPLICAZION1_TYPE_OS = 5;
  public static int PQSL_APPLICAZION1_ID_APP = 6;
  public static int PQSL_APPLICAZION1_DAT_SCAD_CERT = 7;
  public static int PQSL_APPLICAZION1_DES_ERR = 8;

  // Table to contain panel selected row: Device Token
  //
  public static int PQRY_DEVICETOKEN1 = 20;
  public static int PQSL_DEVICETOKEN1_ID = 0;
  public static int PQSL_DEVICETOKEN1_DEV_TOKEN = 1;
  public static int PQSL_DEVICETOKEN1_DATA_ULT_ACCESSO = 2;
  public static int PQSL_DEVICETOKEN1_DATA_CREAZIONE = 3;
  public static int PQSL_DEVICETOKEN1_FLG_ATTIVO = 4;
  public static int PQSL_DEVICETOKEN1_DES_UTENTE = 5;
  public static int PQSL_DEVICETOKEN1_FLG_RIMOSSO = 6;
  public static int PQSL_DEVICETOKEN1_DAT_ULTIMO_INVIO = 7;
  public static int PQSL_DEVICETOKEN1_DES_NOTA = 8;
  public static int PQSL_DEVICETOKEN1_ID_APPLICAZIONE = 9;
  public static int PQSL_DEVICETOKEN1_DATA_RIMOZ = 10;
  public static int PQSL_DEVICETOKEN1_CUSTOM_TAG = 11;
  public static int PQSL_DEVICETOKEN1_TYPE_OS = 12;
  public static int PQSL_DEVICETOKEN1_DATA_CUPERTINO = 13;
  public static int PQSL_DEVICETOKEN1_DISNOTDEVTOK = 14;
  public static int PQSL_DEVICETOKEN1_PRG_LINGUA = 15;

  // Table to contain panel selected row: Notifiche
  //
  public static int PQRY_NOTIFICHE4 = 21;
  public static int PQRY_NOTIFICHE4_RS = 22;
  public static int PQSL_NOTIFICHE4_AMBIENNOTIFI = 0;
  public static int PQSL_NOTIFICHE4_MESSAGNOTIFI = 1;
  public static int PQSL_NOTIFICHE4_DES_UTENTE = 2;
  public static int PQSL_NOTIFICHE4_IDAPPLINOTIF = 3;
  public static int PQSL_NOTIFICHE4_SOUND = 4;
  public static int PQSL_NOTIFICHE4_BADGE = 5;

  // Table to contain panel selected row: Notifiche
  //
  public static int PQRY_NOTIFICHE2 = 23;
  public static int PQRY_NOTIFICHE2_RS = 24;
  public static int PQSL_NOTIFICHE2_AMBIENNOTIFI = 0;
  public static int PQSL_NOTIFICHE2_MESSAGNOTIFI = 1;
  public static int PQSL_NOTIFICHE2_DES_UTENTE = 2;
  public static int PQSL_NOTIFICHE2_IDAPPLINOTIF = 3;
  public static int PQSL_NOTIFICHE2_SOUND = 4;
  public static int PQSL_NOTIFICHE2_BADGE = 5;

  // Table to contain panel selected row: Spedizioni
  //
  public static int PQRY_SPEDIZIONI1 = 25;
  public static int PQSL_SPEDIZIONI1_ID = 0;
  public static int PQSL_SPEDIZIONI1_DES_MESSAGGIO = 1;
  public static int PQSL_SPEDIZIONI1_DEV_TOKEN = 2;
  public static int PQSL_SPEDIZIONI1_FLG_STATO = 3;
  public static int PQSL_SPEDIZIONI1_ID_APPLICAZIONE = 4;
  public static int PQSL_SPEDIZIONI1_DAT_CREAZ = 5;
  public static int PQSL_SPEDIZIONI1_DAT_ELAB = 6;
  public static int PQSL_SPEDIZIONI1_SOUND = 7;
  public static int PQSL_SPEDIZIONI1_BADGE = 8;
  public static int PQSL_SPEDIZIONI1_DES_UTENTE = 9;
  public static int PQSL_SPEDIZIONI1_DISPNOTISPED = 10;

  // Table to contain panel selected row: Applicazioni
  //
  public static int PQRY_APPLICAZION3 = 26;
  public static int PQSL_APPLICAZION3_ID = 0;
  public static int PQSL_APPLICAZION3_DES_NOTA = 1;
  public static int PQSL_APPLICAZION3_FLG_ATTIVA = 2;
  public static int PQSL_APPLICAZION3_TYPE_OS = 3;
  public static int PQSL_APPLICAZION3_GOOGLE_USERNAME = 4;
  public static int PQSL_APPLICAZION3_ID_APP = 5;
  public static int PQSL_APPLICAZION3_FLG_AMBIENTE = 6;
  public static int PQSL_APPLICAZION3_GOOGLE_API_ID = 7;
  public static int PQSL_APPLICAZION3_GOOGLE_PASSWORD = 8;

  // Table to contain panel selected row: Device Token
  //
  public static int PQRY_DEVICETOKEN3 = 27;
  public static int PQSL_DEVICETOKEN3_ID = 0;
  public static int PQSL_DEVICETOKEN3_DEV_TOKEN = 1;
  public static int PQSL_DEVICETOKEN3_DATA_ULT_ACCESSO = 2;
  public static int PQSL_DEVICETOKEN3_DATA_CREAZIONE = 3;
  public static int PQSL_DEVICETOKEN3_FLG_ATTIVO = 4;
  public static int PQSL_DEVICETOKEN3_DES_UTENTE = 5;
  public static int PQSL_DEVICETOKEN3_FLG_RIMOSSO = 6;
  public static int PQSL_DEVICETOKEN3_DAT_ULTIMO_INVIO = 7;
  public static int PQSL_DEVICETOKEN3_DES_NOTA = 8;
  public static int PQSL_DEVICETOKEN3_ID_APPLICAZIONE = 9;
  public static int PQSL_DEVICETOKEN3_DATA_RIMOZ = 10;
  public static int PQSL_DEVICETOKEN3_REG_ID = 11;
  public static int PQSL_DEVICETOKEN3_CUSTOM_TAG = 12;
  public static int PQSL_DEVICETOKEN3_DISNOTDEVTOK = 13;
  public static int PQSL_DEVICETOKEN3_PRG_LINGUA = 14;

  // Table to contain panel selected row: Notifiche
  //
  public static int PQRY_NOTIFICHE1 = 28;
  public static int PQRY_NOTIFICHE1_RS = 29;
  public static int PQSL_NOTIFICHE1_AMBIENNOTIFI = 0;
  public static int PQSL_NOTIFICHE1_MESSAGNOTIFI = 1;
  public static int PQSL_NOTIFICHE1_DES_UTENTE = 2;
  public static int PQSL_NOTIFICHE1_IDAPPLINOTIF = 3;
  public static int PQSL_NOTIFICHE1_SOUND = 4;
  public static int PQSL_NOTIFICHE1_BADGE = 5;

  // Table to contain panel selected row: Spedizioni
  //
  public static int PQRY_SPEDIZIONI3 = 30;
  public static int PQSL_SPEDIZIONI3_ID = 0;
  public static int PQSL_SPEDIZIONI3_DES_MESSAGGIO = 1;
  public static int PQSL_SPEDIZIONI3_DEV_TOKEN = 2;
  public static int PQSL_SPEDIZIONI3_FLG_STATO = 3;
  public static int PQSL_SPEDIZIONI3_ID_APPLICAZIONE = 4;
  public static int PQSL_SPEDIZIONI3_DAT_CREAZ = 5;
  public static int PQSL_SPEDIZIONI3_DAT_ELAB = 6;
  public static int PQSL_SPEDIZIONI3_SOUND = 7;
  public static int PQSL_SPEDIZIONI3_BADGE = 8;
  public static int PQSL_SPEDIZIONI3_DES_UTENTE = 9;
  public static int PQSL_SPEDIZIONI3_REG_ID = 10;
  public static int PQSL_SPEDIZIONI3_TYPE_OS = 11;
  public static int PQSL_SPEDIZIONI3_DISPNOTISPED = 12;
  public static int PQSL_SPEDIZIONI3_INFO = 13;
  public static int PQSL_SPEDIZIONI3_TENTATIVI = 14;
  public static int PQSL_SPEDIZIONI3_GUID_GRUPPO = 15;

  // Table to contain panel selected row: Nuova Tabella
  //
  public static int PQRY_NUOVATABELL2 = 31;
  public static int PQRY_NUOVATABELL2_RS = 32;
  public static int PQSL_NUOVATABELL2_GOOGLE_API_ID = 0;
  public static int PQSL_NUOVATABELL2_DES_MESSAGGIO = 1;
  public static int PQSL_NUOVATABELL2_REG_ID = 2;
  public static int PQSL_NUOVATABELL2_RISUNOMEOGGE = 3;

  // Table to contain panel selected row: Spedizioni
  //
  public static int PQRY_SPEDIZIONI = 33;
  public static int PQSL_SPEDIZIONI_ID = 0;
  public static int PQSL_SPEDIZIONI_ID_APPLICAZIONE = 1;
  public static int PQSL_SPEDIZIONI_DES_MESSAGGIO = 2;
  public static int PQSL_SPEDIZIONI_DEV_TOKEN = 3;
  public static int PQSL_SPEDIZIONI_FLG_STATO = 4;
  public static int PQSL_SPEDIZIONI_DAT_CREAZ = 5;
  public static int PQSL_SPEDIZIONI_DAT_ELAB = 6;
  public static int PQSL_SPEDIZIONI_DES_UTENTE = 7;
  public static int PQSL_SPEDIZIONI_SOUND = 8;
  public static int PQSL_SPEDIZIONI_BADGE = 9;
  public static int PQSL_SPEDIZIONI_REG_ID = 10;
  public static int PQSL_SPEDIZIONI_TYPE_OS = 11;
  public static int PQSL_SPEDIZIONI_INFO = 12;
  public static int PQSL_SPEDIZIONI_GUID_GRUPPO = 13;
  public static int PQSL_SPEDIZIONI_TENTATIVI = 14;

  // Table to contain panel selected row: Dati Temp
  //
  public static int PQRY_DATITEMP1 = 34;
  public static int PQRY_DATITEMP1_RS = 35;
  public static int PQSL_DATITEMP1_JSORITNOMOGG = 0;

  // Table to contain panel selected row: Device Token
  //
  public static int PQRY_DEVICETOKEN5 = 36;
  public static int PQSL_DEVICETOKEN5_ID = 0;
  public static int PQSL_DEVICETOKEN5_ID_APPLICAZIONE = 1;
  public static int PQSL_DEVICETOKEN5_DEV_TOKEN = 2;
  public static int PQSL_DEVICETOKEN5_FLG_ATTIVO = 3;
  public static int PQSL_DEVICETOKEN5_DES_UTENTE = 4;
  public static int PQSL_DEVICETOKEN5_FLG_RIMOSSO = 5;
  public static int PQSL_DEVICETOKEN5_DES_NOTA = 6;
  public static int PQSL_DEVICETOKEN5_DATA_RIMOZ = 7;
  public static int PQSL_DEVICETOKEN5_REG_ID = 8;

  // Table to contain panel selected row: Dati Di Login
  //
  public static int PQRY_DATIDILOGIN1 = 37;
  public static int PQRY_DATIDILOGIN1_RS = 38;
  public static int PQSL_DATIDILOGIN1_EMAINUOVPANN = 0;
  public static int PQSL_DATIDILOGIN1_PINNUOVOPANN = 1;
  public static int PQSL_DATIDILOGIN1_PASUTENUOPAN = 2;
  public static int PQSL_DATIDILOGIN1_COMUTENUOPAN = 3;

  // Table to contain panel selected row: Dati Di Login
  //
  public static int PQRY_DATIDILOGIN2 = 39;
  public static int PQRY_DATIDILOGIN2_RS = 40;
  public static int PQSL_DATIDILOGIN2_EMAINUOVPANN = 0;
  public static int PQSL_DATIDILOGIN2_PINNUOVOPANN = 1;

  // Table to contain panel selected row: Applicazioni
  //
  public static int PQRY_APPLICAZIONI = 41;
  public static int PQSL_APPLICAZIONI_ID = 0;
  public static int PQSL_APPLICAZIONI_DES_NOTA = 1;
  public static int PQSL_APPLICAZIONI_FLG_ATTIVA = 2;
  public static int PQSL_APPLICAZIONI_TYPE_OS = 3;
  public static int PQSL_APPLICAZIONI_ID_APP = 4;
  public static int PQSL_APPLICAZIONI_FLG_AMBIENTE = 5;
  public static int PQSL_APPLICAZIONI_WNS_XML = 6;

  // Table to contain panel selected row: Device Token
  //
  public static int PQRY_DEVICETOKEN2 = 42;
  public static int PQSL_DEVICETOKEN2_ID = 0;
  public static int PQSL_DEVICETOKEN2_DEV_TOKEN = 1;
  public static int PQSL_DEVICETOKEN2_DATA_ULT_ACCESSO = 2;
  public static int PQSL_DEVICETOKEN2_DATA_CREAZIONE = 3;
  public static int PQSL_DEVICETOKEN2_FLG_ATTIVO = 4;
  public static int PQSL_DEVICETOKEN2_DES_UTENTE = 5;
  public static int PQSL_DEVICETOKEN2_FLG_RIMOSSO = 6;
  public static int PQSL_DEVICETOKEN2_DAT_ULTIMO_INVIO = 7;
  public static int PQSL_DEVICETOKEN2_DES_NOTA = 8;
  public static int PQSL_DEVICETOKEN2_ID_APPLICAZIONE = 9;
  public static int PQSL_DEVICETOKEN2_DATA_RIMOZ = 10;
  public static int PQSL_DEVICETOKEN2_REG_ID = 11;
  public static int PQSL_DEVICETOKEN2_DISNOTDEVTOK = 12;
  public static int PQSL_DEVICETOKEN2_PRG_LINGUA = 13;

  // Table to contain panel selected row: Spedizioni
  //
  public static int PQRY_SPEDIZIONI2 = 43;
  public static int PQSL_SPEDIZIONI2_ID = 0;
  public static int PQSL_SPEDIZIONI2_DES_MESSAGGIO = 1;
  public static int PQSL_SPEDIZIONI2_DEV_TOKEN = 2;
  public static int PQSL_SPEDIZIONI2_FLG_STATO = 3;
  public static int PQSL_SPEDIZIONI2_ID_APPLICAZIONE = 4;
  public static int PQSL_SPEDIZIONI2_DAT_CREAZ = 5;
  public static int PQSL_SPEDIZIONI2_DAT_ELAB = 6;
  public static int PQSL_SPEDIZIONI2_BADGE = 7;
  public static int PQSL_SPEDIZIONI2_DES_UTENTE = 8;
  public static int PQSL_SPEDIZIONI2_REG_ID = 9;
  public static int PQSL_SPEDIZIONI2_TYPE_OS = 10;
  public static int PQSL_SPEDIZIONI2_DISPNOTISPED = 11;
  public static int PQSL_SPEDIZIONI2_INFO = 12;
  public static int PQSL_SPEDIZIONI2_TENTATIVI = 13;
  public static int PQSL_SPEDIZIONI2_GUID_GRUPPO = 14;

  // Table to contain panel selected row: Nuova Tabella
  //
  public static int PQRY_NUOVATABELL1 = 44;
  public static int PQRY_NUOVATABELL1_RS = 45;
  public static int PQSL_NUOVATABELL1_DES_MESSAGGIO = 0;
  public static int PQSL_NUOVATABELL1_REG_ID = 1;
  public static int PQSL_NUOVATABELL1_RISUNOMEOGGE = 2;

  // Table to contain panel selected row: Applicazioni
  //
  public static int PQRY_APPLICAZION4 = 46;
  public static int PQSL_APPLICAZION4_ID = 0;
  public static int PQSL_APPLICAZION4_DES_NOTA = 1;
  public static int PQSL_APPLICAZION4_FLG_ATTIVA = 2;
  public static int PQSL_APPLICAZION4_TYPE_OS = 3;
  public static int PQSL_APPLICAZION4_ID_APP = 4;
  public static int PQSL_APPLICAZION4_FLG_AMBIENTE = 5;
  public static int PQSL_APPLICAZION4_WNS_SECRET = 6;
  public static int PQSL_APPLICAZION4_WNS_SID = 7;
  public static int PQSL_APPLICAZION4_WNS_XML = 8;

  // Table to contain panel selected row: Device Token
  //
  public static int PQRY_DEVICETOKEN4 = 47;
  public static int PQSL_DEVICETOKEN4_ID = 0;
  public static int PQSL_DEVICETOKEN4_DEV_TOKEN = 1;
  public static int PQSL_DEVICETOKEN4_DATA_ULT_ACCESSO = 2;
  public static int PQSL_DEVICETOKEN4_DATA_CREAZIONE = 3;
  public static int PQSL_DEVICETOKEN4_FLG_ATTIVO = 4;
  public static int PQSL_DEVICETOKEN4_DES_UTENTE = 5;
  public static int PQSL_DEVICETOKEN4_FLG_RIMOSSO = 6;
  public static int PQSL_DEVICETOKEN4_DAT_ULTIMO_INVIO = 7;
  public static int PQSL_DEVICETOKEN4_DES_NOTA = 8;
  public static int PQSL_DEVICETOKEN4_ID_APPLICAZIONE = 9;
  public static int PQSL_DEVICETOKEN4_DATA_RIMOZ = 10;
  public static int PQSL_DEVICETOKEN4_REG_ID = 11;
  public static int PQSL_DEVICETOKEN4_DISNOTDEVTOK = 12;
  public static int PQSL_DEVICETOKEN4_PRG_LINGUA = 13;

  // Table to contain panel selected row: Spedizioni
  //
  public static int PQRY_SPEDIZIONI4 = 48;
  public static int PQSL_SPEDIZIONI4_ID = 0;
  public static int PQSL_SPEDIZIONI4_DES_MESSAGGIO = 1;
  public static int PQSL_SPEDIZIONI4_DEV_TOKEN = 2;
  public static int PQSL_SPEDIZIONI4_FLG_STATO = 3;
  public static int PQSL_SPEDIZIONI4_ID_APPLICAZIONE = 4;
  public static int PQSL_SPEDIZIONI4_DAT_CREAZ = 5;
  public static int PQSL_SPEDIZIONI4_DAT_ELAB = 6;
  public static int PQSL_SPEDIZIONI4_BADGE = 7;
  public static int PQSL_SPEDIZIONI4_DES_UTENTE = 8;
  public static int PQSL_SPEDIZIONI4_REG_ID = 9;
  public static int PQSL_SPEDIZIONI4_TYPE_OS = 10;
  public static int PQSL_SPEDIZIONI4_DISPNOTISPED = 11;
  public static int PQSL_SPEDIZIONI4_INFO = 12;
  public static int PQSL_SPEDIZIONI4_TENTATIVI = 13;
  public static int PQSL_SPEDIZIONI4_GUID_GRUPPO = 14;

  // Table to contain panel selected row: Nuova Tabella
  //
  public static int PQRY_NUOVATABELLA = 49;
  public static int PQRY_NUOVATABELLA_RS = 50;
  public static int PQSL_NUOVATABELLA_DES_MESSAGGIO = 0;
  public static int PQSL_NUOVATABELLA_REG_ID = 1;
  public static int PQSL_NUOVATABELLA_RISUNOMEOGGE = 2;
  public static int PQSL_NUOVATABELLA_WNS_SECRET = 3;
  public static int PQSL_NUOVATABELLA_WNS_SID = 4;
  public static int PQSL_NUOVATABELLA_WNS_XML = 5;
  public static int PQSL_NUOVATABELLA_ACCTOCNOMOGG = 6;

  // Table to contain panel selected row: Sales Data
  //
  public static int PQRY_SALESDATA1 = 51;
  public static int PQSL_SALESDATA1_PROVIDER = 0;
  public static int PQSL_SALESDATA1_PROVIDER_COUNTRY = 1;
  public static int PQSL_SALESDATA1_SKU_NUMBER = 2;
  public static int PQSL_SALESDATA1_DEVELOPER = 3;
  public static int PQSL_SALESDATA1_TITLE = 4;
  public static int PQSL_SALESDATA1_VERSION = 5;
  public static int PQSL_SALESDATA1_PROD_TYPE_IDENTIFIER = 6;
  public static int PQSL_SALESDATA1_UNITS = 7;
  public static int PQSL_SALESDATA1_DEV_PROCEED = 8;
  public static int PQSL_SALESDATA1_BEGIN_DATE = 9;
  public static int PQSL_SALESDATA1_END_DATE = 10;
  public static int PQSL_SALESDATA1_CUST_CURRENCY = 11;
  public static int PQSL_SALESDATA1_COUNTRY_CODE = 12;
  public static int PQSL_SALESDATA1_CURRENCY_PROCEED = 13;
  public static int PQSL_SALESDATA1_APPLE_IDENTIFIER = 14;
  public static int PQSL_SALESDATA1_CUSTOMER_PRICE = 15;
  public static int PQSL_SALESDATA1_CODE = 16;
  public static int PQSL_SALESDATA1_PARENT_IDENTIFIER = 17;
  public static int PQSL_SALESDATA1_SUBSCRIPTION = 18;
  public static int PQSL_SALESDATA1_PERIOD = 19;
  public static int PQSL_SALESDATA1_ID = 20;

  // Table to contain panel selected row: Currencies
  //
  public static int PQRY_CURRENCIES = 52;
  public static int PQSL_CURRENCIES_CODE = 0;
  public static int PQSL_CURRENCIES_DESCRIPTION = 1;

  // Table to contain panel selected row: Promo Codes
  //
  public static int PQRY_PROMOCODES = 53;
  public static int PQSL_PROMOCODES_CODE = 0;
  public static int PQSL_PROMOCODES_DESCRIPTION = 1;

  // Table to contain panel selected row: Country Codes
  //
  public static int PQRY_COUNTRYCODES = 54;
  public static int PQSL_COUNTRYCODES_CODE = 0;
  public static int PQSL_COUNTRYCODES_DESCRIPTION = 1;

  // Table to contain panel selected row: Product Type Identifiers
  //
  public static int PQRY_PRODTYPEIDEN = 55;
  public static int PQSL_PRODTYPEIDEN_IDENTIFIER = 0;
  public static int PQSL_PRODTYPEIDEN_DESCRIPTION = 1;
  public static int PQSL_PRODTYPEIDEN_FREE_APPS = 2;
  public static int PQSL_PRODTYPEIDEN_PAID_APPS = 3;
  public static int PQSL_PRODTYPEIDEN_IN_APPS = 4;
  public static int PQSL_PRODTYPEIDEN_UPDATE_APPS = 5;

  // Table to contain panel selected row: Fiscal Calendar
  //
  public static int PQRY_FISCALCALEND = 56;
  public static int PQSL_FISCALCALEND_CDN_YEAR = 0;
  public static int PQSL_FISCALCALEND_PERIOD = 1;
  public static int PQSL_FISCALCALEND_DESCRIPTION = 2;
  public static int PQSL_FISCALCALEND_BEGIN_DATE = 3;
  public static int PQSL_FISCALCALEND_END_DATE = 4;
  public static int PQSL_FISCALCALEND_ID = 5;

  // Table to contain panel selected row: Selettori Grafico
  //
  public static int PQRY_SELETTGRAFI1 = 57;
  public static int PQRY_SELETTGRAFI1_RS = 58;
  public static int PQSL_SELETTGRAFI1_ID_UTENTE = 0;
  public static int PQSL_SELETTGRAFI1_ID_APP = 1;
  public static int PQSL_SELETTGRAFI1_TIPOSELEGRAF = 2;
  public static int PQSL_SELETTGRAFI1_DATADASELGRA = 3;
  public static int PQSL_SELETTGRAFI1_DATAASELEGRA = 4;

  // Table to contain panel selected row: Stat Apple
  //
  public static int PQRY_STATAPPLE1 = 59;
  public static int PQSL_STATAPPLE1_DATARECORD = 0;
  public static int PQSL_STATAPPLE1_UNITSRECORD = 1;

  // Table to contain panel selected row: Stat Apple
  //
  public static int PQRY_STATAPPLE = 60;
  public static int PQSL_STATAPPLE_ANNSTAAPPREC = 0;
  public static int PQSL_STATAPPLE_MESSTAAPPREC = 1;
  public static int PQSL_STATAPPLE_GIOSTAAPPREC = 2;
  public static int PQSL_STATAPPLE_DATSTAAPPREC = 3;
  public static int PQSL_STATAPPLE_UNITSRECORD = 4;

  // Table to contain panel selected row: Sales Data
  //
  public static int PQRY_SALESDATA = 61;
  public static int PQSL_SALESDATA_DATEMANCRECO = 0;

  // Table to contain panel selected row: Dispositivi Noti IOS
  //
  public static int PQRY_DISPONOTIIOS = 62;
  public static int PQSL_DISPONOTIIOS_ID = 0;
  public static int PQSL_DISPONOTIIOS_DES_MESSAGGIO = 1;
  public static int PQSL_DISPONOTIIOS_DEV_TOKEN = 2;
  public static int PQSL_DISPONOTIIOS_TYPE_OS = 3;

  // Table to contain panel selected row: Lingue
  //
  public static int PQRY_LINGUE = 63;
  public static int PQSL_LINGUE_PRG_LINGUA = 0;
  public static int PQSL_LINGUE_DES_LINGUA = 1;
  public static int PQSL_LINGUE_CDA_LINGUA = 2;

  // Table to contain panel selected row: Device Token
  //
  public static int PQRY_DEVICETOKEN = 64;
  public static int PQSL_DEVICETOKEN_ID = 0;
  public static int PQSL_DEVICETOKEN_ID_APPLICAZIONE = 1;
  public static int PQSL_DEVICETOKEN_DEV_TOKEN = 2;
  public static int PQSL_DEVICETOKEN_DATA_ULT_ACCESSO = 3;
  public static int PQSL_DEVICETOKEN_DATA_CREAZIONE = 4;
  public static int PQSL_DEVICETOKEN_FLG_ATTIVO = 5;
  public static int PQSL_DEVICETOKEN_DES_UTENTE = 6;
  public static int PQSL_DEVICETOKEN_FLG_RIMOSSO = 7;
  public static int PQSL_DEVICETOKEN_DAT_ULTIMO_INVIO = 8;
  public static int PQSL_DEVICETOKEN_DES_NOTA = 9;
  public static int PQSL_DEVICETOKEN_DATA_RIMOZ = 10;
  public static int PQSL_DEVICETOKEN_REG_ID = 11;
  public static int PQSL_DEVICETOKEN_CUSTOM_TAG = 12;
  public static int PQSL_DEVICETOKEN_TYPE_OS = 13;
  public static int PQSL_DEVICETOKEN_DATA_CUPERTINO = 14;
  public static int PQSL_DEVICETOKEN_PRG_LINGUA = 15;

}
