// **********************************************
// Notificatore
// Build on: 17/11/2014 16.28.33
// Project : Mobile Manager
// **********************************************
namespace NotificatoreWS
{

using com.progamma;
using com.progamma.doc;
using com.progamma.ws;
using Glb = com.progamma.ids.Glb;

using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Reflection;

[WebService(Namespace = "http://www.progamma.com")]
public sealed class Notificatore : WebEntryPoint
{
  public Notificatore MainFrm;

  // Compilation Predefined Constants
  public String DefaultURL = "";
  public String ConvertNullToValue = "YES";
  public String UseDecimalDot = "NO";
  public String NativeBlob = "NO";
  public bool UseRD4 = false;
  public bool UseDynVS = true;

  //
  // Definition of Global Variables
  //
  // Definition of Database Objects
  public NotificatoreDB NotificatoreDBObject;
  //
  // Definition of External Components

  public Notificatore() 
  {
    MainFrm = this;
    //
    RevNum = 5471;
    IDVer = "13.5.5800";
    IDVariant.ConvertNullToValue = ConvertNullToValue.Equals("YES");
    IDVariant.InitDefaultMasks("dd/mm/yyyy", "hh:nn");
    set_UseDecimalDot(this.UseDecimalDot.Equals("YES"));
    UseNativeBlob = NativeBlob.Equals("YES");
    //
    DTTObj.Init (0, 0, false, false, false, this);
    DTTObj.DTTStarted = false;
    //
    // Initializing WebServices URLs
    WebServicesUrl["WIKIPEDIA"] = "http://dev.wikipedia-lab.org/WikipediaOntologyAPIv3/Service.asmx";
    //
    //
    // Creation of Database Objects
    NotificatoreDBObject = new NotificatoreDB(this);
    //
    // Creating components
    //
    IwImdb = new MyImdbInit(this);
    IMDB = IwImdb.IMDB;
    //
    // Init components
    InitComponents();
  }

  // **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    // IMDB Init
    //
    //
  }
  
  // IMDB DDL Procedures
 
  // **********************************************
  // Crea un nuovo documento dato il nome della classe
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
    if (d != null)
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
  // Get DB by code
  // **********************************************
  public override IDConnection GetDBByName(String Name)
  {
    if (Name.Equals("NotificatoreDB")) return NotificatoreDBObject.DB;
    //
    return null;
  }

  // **********************************************
  // Chiude tutte le connessioni ai DB aperte per questa sessione
  // **********************************************
  public override void CloseDBConnections()
  {
    NotificatoreDBObject.CloseConnection();
  }
  
  // **********************************************
  // Metodi standard del WebService
  // **********************************************
  [WebMethod(Description = "Executes the given method on a IDDocument object")]
  [SoapRpcMethod()]
  public Object ID_DOExecute(String DOXML, String MethodName, String ClassName, Object[] Params, Boolean RetDoc, ref String RetDocXML)
  {
    return ID_DOExecuteINT(DOXML, MethodName, ClassName, Params, RetDoc, ref RetDocXML);
  }

  [WebMethod(Description = "Receive a file from a client application")]
  [SoapRpcMethod()]
  public String ID_ReceiveFile(byte[] FileData, String Extension)
  {
    return ID_ReceiveFileINT(FileData, Extension);
  }

  [WebMethod(Description = "Sends a file to a client application")]
  [SoapRpcMethod()]
  public byte[] ID_SendFile(String FileName)
  {
    return ID_SendFileINT(FileName);
  }

  // **********************************************************************
  // Send Notification
  // Invia una notifica push
  // Auth Key: Stringa di autenticazione - Input
  // Application Key: Chiave dell'applicazione - Input
  // Message: Messaggio da inviare (Passare empty string per non caricare il payload) - Input
  // User Name: Deve essere empty string se si vuole mandare la notifica a tutti - Input
  // Sound: Nome del suono che deve essere eseguito (Passare empty string per non caricare il payload,
  //   default per eseguire il suono di default) - Input
  // Badge: Numero del badge (Passare 0 per azzerare il badge, >0 per visualizzare il valore, -1 per non passare nel payload) - Input
  // **********************************************************************
  [WebMethod(Description="Invia una notifica push")]
  [SoapRpcMethod()]
  public String SendNotification (String pAuthKey, String pApplicationKey, String pMessage, String pUserName, String pSound, int pBadge)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;
    NotificatoreDB NotificatoreDBObject = ((Notificatore)MainFrm).NotificatoreDBObject;
    IDVariant AuthKey = new IDVariant(pAuthKey);
    IDVariant ApplicationKey = new IDVariant(pApplicationKey);
    IDVariant Message = new IDVariant(pMessage);
    IDVariant UserName = new IDVariant(pUserName);
    IDVariant Sound = new IDVariant(pSound);
    IDVariant Badge = new IDVariant(pBadge);
    IDCachedRowSet C7;
    IDCachedRowSet C12;

    try
    {
      TransCount = 0;
      // 
      // Send Notification Body
      // Corpo Procedura
      // 
      IDVariant v_SRETVALUE = new IDVariant(0,IDVariant.STRING);
      IDVariant v_BERROR = new IDVariant(0,IDVariant.INTEGER);
      IDVariant v_IAPPLICATIID = new IDVariant(0,IDVariant.INTEGER);
      IDVariant v_VIDAPPS = new IDVariant(0,IDVariant.INTEGER);
      // 
      // Posso mandare le notifiche con il WS solo se il campo
      // AppKey non è vuoto
      // 
      if (AuthKey.equals((new IDVariant("")), true))
      {
        v_SRETVALUE = (new IDVariant("Auth string non valorizzata"));
        v_BERROR = (new IDVariant(-1));
      }
      else
      {
        IDVariant v_TROVATOAPP = new IDVariant(0,IDVariant.INTEGER);
        // 
        // Se l'AppKey è nel db, allora posso usare il WS
        // 
        SQL = new StringBuilder();
        SQL.Append("select ");
        SQL.Append("  A.ID as IDAPPS ");
        SQL.Append("from ");
        SQL.Append("  APPS A ");
        SQL.Append("where (A.APP_KEY = " + IDL.CSql(ApplicationKey, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + ") ");
        SQL.Append("and   (A.AUTH_KEY = " + IDL.CSql(AuthKey, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + ") ");
        QV = NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!QV.EOF()) QV.MoveNext();
        v_TROVATOAPP = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
        if (!QV.EOF())
        {
          v_VIDAPPS = QV.Get("IDAPPS", IDVariant.INTEGER) ;
        }
        QV.Close();
        // 
        // Se l'AppKey non è nel DB, esco con errore
        // 
        if (!(v_TROVATOAPP.booleanValue()))
        {
          v_SRETVALUE = (new IDVariant("Auth Key non valida"));
          v_BERROR = (new IDVariant(-1));
        }
      }
      // 
      // Se AppKey è empty string ed è cosi' anche nel DB, mi
      // blocco
      // 
      if (ApplicationKey.equals((new IDVariant("")), true) && v_BERROR.equals((new IDVariant(0)), true))
      {
        v_SRETVALUE = (new IDVariant("L'application Key deve essere valorizzato"));
        v_BERROR = (new IDVariant(-1));
      }
      else
      {
        // 
        // ... in tutti gli altri casi posso procedere
        // 
        // 
        // Estraggo l'ID dell'AppKey che sto trattando
        // 
        SQL = new StringBuilder();
        SQL.Append("select ");
        SQL.Append("  A.ID as VID, ");
        SQL.Append("  A.TYPE_OS as TYPOSAPPPUSE, ");
        SQL.Append("  A.WNS_XML as WNXMTEAPPUSE ");
        SQL.Append("from ");
        SQL.Append("  APPS_PUSH_SETTING A ");
        SQL.Append("where (A.ID_APP = " + IDL.CSql(v_VIDAPPS, IDL.FMT_NUM, NotificatoreDBObject.DBO()) + ") ");
        SQL.Append("and   (A.FLG_ATTIVA = 'S') ");
        C7 = NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!C7.EOF()) C7.MoveNext();
        while (!C7.EOF())
        {
          IDVariant v_MESSADASPEDI = null;
          v_MESSADASPEDI = new IDVariant(Message);
          if (C7.Get("TYPOSAPPPUSE").equals((new IDVariant("5")), true))
          {
            // 
            // Encode special characters
            // Scrivi un commento per questo blocco o premi backspace
            // per eliminare questo commento
            // 
            {
              v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("&")), (new IDVariant("&amp;")));
              v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("<")), (new IDVariant("&lt;")));
              v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant(">")), (new IDVariant("&gt;")));
              v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("'")), (new IDVariant("&apos;")));
              v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("\"")), (new IDVariant("&quot;")));
            }
            v_MESSADASPEDI = IDL.Replace(C7.Get("WNXMTEAPPUSE"), (new IDVariant("{MESSAGE_PLACEHOLDER}")), v_MESSADASPEDI);
          }
          if (C7.Get("TYPOSAPPPUSE").equals((new IDVariant("3")), true))
          {
            // 
            // Encode special characters
            // Scrivi un commento per questo blocco o premi backspace
            // per eliminare questo commento
            // 
            {
              v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("&")), (new IDVariant("&amp;")));
              v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("<")), (new IDVariant("&lt;")));
              v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant(">")), (new IDVariant("&gt;")));
              v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("'")), (new IDVariant("&apos;")));
              v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("\"")), (new IDVariant("&quot;")));
            }
            v_MESSADASPEDI = IDL.Replace(C7.Get("WNXMTEAPPUSE"), (new IDVariant("{MESSAGE_PLACEHOLDER}")), v_MESSADASPEDI);
          }
          // ReturnStatus = NotificatoreDBObject.WriteMessageLog(new IDVariant (SQL.ToString()));
          // if (ReturnStatus != 0) throw new Exception(NotificatoreDBObject.ErrorMessage());
          IDVariant v_SGUID = null;
          v_SGUID = new IDVariant(com.progamma.GUID.DocID2GUID (com.progamma.doc.MDOInit.GetNewDocID().stringValue()));
          // 
          // Per l'AppKey in esame, cerco il token dell'utente a
          // cui devo mandare la notifica seguendo questa regola
          // 
          // 1. Estraggo il token dello username che ho passato
          //  oppure
          // 2. Estraggo il token del token che passo al posto dello
          // username, oppure
          // 3. Estraggo tutti i token dell'AppKey in esame, se
          // lo username Empty String
          // 
          SQL = new StringBuilder();
          SQL.Append("select ");
          SQL.Append("  A.DEV_TOKEN as DEVTOKDEVTOK, ");
          SQL.Append("  A.REG_ID as REGIDEVITOKE, ");
          SQL.Append("  A.TYPE_OS as TYPEOSDEVTOK, ");
          SQL.Append("  A.DES_UTENTE as UTENDEVITOKE ");
          SQL.Append("from ");
          SQL.Append("  DEV_TOKENS A ");
          SQL.Append("where (A.ID_APPLICAZIONE = " + IDL.CSql(C7.Get("VID"), IDL.FMT_NUM, NotificatoreDBObject.DBO()) + ") ");
          SQL.Append("and   (A.FLG_ATTIVO = 'S') ");
          SQL.Append("and   (A.FLG_RIMOSSO = 'N') ");
          SQL.Append("and   (A.DES_UTENTE = " + IDL.CSql(UserName, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " OR A.DEV_TOKEN = " + IDL.CSql(UserName, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " OR " + IDL.CSql(UserName, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " = '') ");
          C12 = NotificatoreDBObject.DBO().OpenRS(SQL);
          if (!C12.EOF()) C12.MoveNext();
          while (!C12.EOF())
          {
            // ReturnStatus = NotificatoreDBObject.WriteMessageLog(new IDVariant (SQL.ToString()));
            // if (ReturnStatus != 0) throw new Exception(NotificatoreDBObject.ErrorMessage());
            // 
            // Metto il messaggio in coda per il token in esame
            // 
            SQL = new StringBuilder();
            SQL.Append("insert into SPEDIZIONI ");
            SQL.Append("( ");
            SQL.Append("  DEV_TOKEN, ");
            SQL.Append("  REG_ID, ");
            SQL.Append("  DES_MESSAGGIO, ");
            SQL.Append("  DES_UTENTE, ");
            SQL.Append("  ID_APPLICAZIONE, ");
            SQL.Append("  SOUND, ");
            SQL.Append("  BADGE, ");
            SQL.Append("  TYPE_OS, ");
            SQL.Append("  GUID_GRUPPO ");
            SQL.Append(") ");
            SQL.Append("values ");
            SQL.Append("( ");
            SQL.Append("  " + IDL.CSql(C12.Get("DEVTOKDEVTOK"), IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(C12.Get("REGIDEVITOKE"), IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  CASE WHEN " + IDL.CSql(v_MESSADASPEDI, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + "='' OR (" + IDL.CSql(v_MESSADASPEDI, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " IS NULL AND '' IS NULL) THEN convert(varchar,NULL) ELSE " + IDL.CSql(v_MESSADASPEDI, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " END, ");
            SQL.Append("  CASE WHEN " + IDL.CSql(UserName, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + "='' OR (" + IDL.CSql(UserName, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " IS NULL AND '' IS NULL) THEN " + IDL.CSql(C12.Get("UTENDEVITOKE"), IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " ELSE " + IDL.CSql(UserName, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " END, ");
            SQL.Append("  " + IDL.CSql(C7.Get("VID"), IDL.FMT_NUM, NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  CASE WHEN " + IDL.CSql(Sound, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + "='' OR (" + IDL.CSql(Sound, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " IS NULL AND '' IS NULL) THEN convert(varchar,NULL) ELSE " + IDL.CSql(Sound, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " END, ");
            SQL.Append("  CASE WHEN " + IDL.CSql(Badge, IDL.FMT_NUM, NotificatoreDBObject.DBO()) + "='' OR (" + IDL.CSql(Badge, IDL.FMT_NUM, NotificatoreDBObject.DBO()) + " IS NULL AND '' IS NULL) THEN NULL ELSE " + IDL.CSql(Badge, IDL.FMT_NUM, NotificatoreDBObject.DBO()) + " END, ");
            SQL.Append("  " + IDL.CSql(C12.Get("TYPEOSDEVTOK"), IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + ", ");
            SQL.Append("  " + IDL.CSql(v_SGUID, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " ");
            SQL.Append(") ");
            NotificatoreDBObject.DBO().Execute(SQL);
            C12.MoveNext();
          }
          C12.Close();
          C7.MoveNext();
        }
        C7.Close();
      }
      // 
      // Non ci sono errori
      // 
      MainFrm.CloseDBConnections();
      return (v_SRETVALUE).stringValue();
    }
    catch (Exception _e)
    {
      MainFrm.CloseDBConnections();
      throw new Exception("SendNotification - "+_e.Message,_e);
    }
  }

  // **********************************************************************
  // Send Notification With Lang
  // Invia una notifica push
  // Auth Key: Stringa di autenticazione - Input
  // Application Key: Chiave dell'applicazione - Input
  // Message: Messaggio json
  //   {"messages":[{"lang":"it", "message":"ciao"},{"lang":"en", "message":"hello"}]} - Input
  // User Name: Deve essere empty string se si vuole mandare la notifica a tutti - Input
  // Sound: Nome del suono che deve essere eseguito (Passare empty string per non caricare il payload,
  //   default per eseguire il suono di default) - Input
  // Badge: Numero del badge (Passare 0 per azzerare il badge, >0 per visualizzare il valore, -1 per non passare nel payload) - Input
  // **********************************************************************
  [WebMethod(Description="Invia una notifica push")]
  [SoapRpcMethod()]
  public String SendNotificationWithLang (String pAuthKey, String pApplicationKey, String pMessage, String pUserName, String pSound, int pBadge)
  {
    StringBuilder SQL = new StringBuilder();
    int TransCount   = 0;
    int ReturnStatus = 0;
    IDCachedRowSet QV;
    NotificatoreDB NotificatoreDBObject = ((Notificatore)MainFrm).NotificatoreDBObject;
    IDVariant AuthKey = new IDVariant(pAuthKey);
    IDVariant ApplicationKey = new IDVariant(pApplicationKey);
    IDVariant Message = new IDVariant(pMessage);
    IDVariant UserName = new IDVariant(pUserName);
    IDVariant Sound = new IDVariant(pSound);
    IDVariant Badge = new IDVariant(pBadge);
    IDCachedRowSet C12;
    IDCachedRowSet C13;

    try
    {
      TransCount = 0;
      // 
      // Send Notification With Lang Body
      // Corpo Procedura
      // 
      IDVariant v_SRETVALUE = new IDVariant(0,IDVariant.STRING);
      IDVariant v_BERROR = new IDVariant(0,IDVariant.INTEGER);
      IDVariant v_VIDAPPS = new IDVariant(0,IDVariant.INTEGER);
      IDVariant v_IDLINGUA = new IDVariant(0,IDVariant.INTEGER);
      IDVariant v_IDLINGDEFAPP = new IDVariant(0,IDVariant.INTEGER);
      // 
      // Posso mandare le notifiche con il WS solo se il campo
      // AppKey non è vuoto
      // 
      if (AuthKey.equals((new IDVariant("")), true))
      {
        v_SRETVALUE = (new IDVariant("Auth string non valorizzata"));
        v_BERROR = (new IDVariant(-1));
      }
      else
      {
        IDVariant v_TROVATOAPP = new IDVariant(0,IDVariant.INTEGER);
        // 
        // Se l'AppKey è nel db, allora posso usare il WS
        // 
        SQL = new StringBuilder();
        SQL.Append("select ");
        SQL.Append("  A.ID as ID, ");
        SQL.Append("  A.PRG_LINGUA as IDLINGDEFAPP ");
        SQL.Append("from ");
        SQL.Append("  APPS A ");
        SQL.Append("where (A.APP_KEY = " + IDL.CSql(ApplicationKey, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + ") ");
        SQL.Append("and   (A.AUTH_KEY = " + IDL.CSql(AuthKey, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + ") ");
        QV = NotificatoreDBObject.DBO().OpenRS(SQL);
        if (!QV.EOF()) QV.MoveNext();
        v_TROVATOAPP = (QV.RecordCount()!=0 ? IDVariant.TRUE : IDVariant.FALSE);
        if (!QV.EOF())
        {
          v_VIDAPPS = QV.Get("ID", IDVariant.INTEGER) ;
          v_IDLINGDEFAPP = QV.Get("IDLINGDEFAPP", IDVariant.INTEGER) ;
        }
        QV.Close();
        // 
        // Se l'AppKey non è nel DB, esco con errore
        // 
        if (!(v_TROVATOAPP.booleanValue()))
        {
          v_SRETVALUE = (new IDVariant("Auth Key non valida"));
          v_BERROR = (new IDVariant(-1));
        }
      }
      // 
      // Se AppKey è empty string ed è cosi' anche nel DB, mi
      // blocco
      // 
      if (ApplicationKey.equals((new IDVariant("")), true) && v_BERROR.equals((new IDVariant(0)), true))
      {
        v_SRETVALUE = (new IDVariant("L'application Key deve essere valorizzato"));
        v_BERROR = (new IDVariant(-1));
      }
      else
      {
        // 
        // ... in tutti gli altri casi posso procedere
        // 
        com.progamma.doc.IDCollection v_MESSAINLINGU1 = new com.progamma.doc.IDCollection();
        v_MESSAINLINGU1 = (com.progamma.doc.IDCollection)new com.progamma.doc.IDCollection();
        IDVariant v_MESSLINGDEFA = new IDVariant(0,IDVariant.STRING);
        XMLDoc v_XMLDOC = null;
        v_XMLDOC = (XMLDoc)new XMLDoc();
        try
        {
          v_XMLDOC.LoadFromString(Message.stringValue(), (new IDVariant(1)).intValue()); 
          XMLNode v_NODOROOT = null;
          v_NODOROOT = v_XMLDOC.GetNextNode();
          // 
          // Estraggo i dati dal json e popolo la collection con
          // le lingue
          // 
          // 
          while (v_NODOROOT.HasNextNode())
          {
            XMLNode v_NODOMESSAGGI = null;
            v_NODOMESSAGGI = v_NODOROOT.GetNextNode();
            IDVariant v_SLANG = null;
            v_SLANG = new IDVariant(v_NODOMESSAGGI.GetAttribute((new IDVariant("lang")).stringValue()));
            IDVariant v_SMESSAGE = null;
            v_SMESSAGE = new IDVariant(v_NODOMESSAGGI.GetAttribute((new IDVariant("message")).stringValue()));
            ReturnStatus = NotificatoreDBObject.IdentificaLingua(v_SLANG, v_IDLINGUA);
            if (ReturnStatus != 0) throw new Exception(NotificatoreDBObject.ErrorMessage());
            if (!(IDL.IsNull(v_IDLINGUA)))
            {
              // 
              // Metto da una parte il messaggio nella lingua di default
              //  così è più comodo quando devo ciclare nella collection
              // 
              if (v_IDLINGUA.equals(v_IDLINGDEFAPP, true))
              {
                v_MESSLINGDEFA = new IDVariant(v_SMESSAGE);
              }
              else
              {
                NotificatoreWS.Lingue v_MESSAINLINGU = null;
                v_MESSAINLINGU = (Lingue)new NotificatoreWS.Lingue(MainFrm,IMDB);
                v_MESSAINLINGU.setlang(new IDVariant(v_IDLINGUA));
                v_MESSAINLINGU.setmessage(new IDVariant(v_SMESSAGE));
                v_MESSAINLINGU1.Add(v_MESSAINLINGU); 
              }
            }
          }
          // 
          // Estraggo l'ID dell'AppKey che sto trattando
          // 
          SQL = new StringBuilder();
          SQL.Append("select ");
          SQL.Append("  A.ID as VID, ");
          SQL.Append("  A.TYPE_OS as TYPOSAPPPUSE, ");
          SQL.Append("  A.WNS_XML as WNXMTEAPPUSE ");
          SQL.Append("from ");
          SQL.Append("  APPS_PUSH_SETTING A ");
          SQL.Append("where (A.ID_APP = " + IDL.CSql(v_VIDAPPS, IDL.FMT_NUM, NotificatoreDBObject.DBO()) + ") ");
          SQL.Append("and   (A.FLG_ATTIVA = 'S') ");
          C12 = NotificatoreDBObject.DBO().OpenRS(SQL);
          if (!C12.EOF()) C12.MoveNext();
          while (!C12.EOF())
          {
            // 
            // Definisco il gruppo di invio
            // 
            IDVariant v_SGUID = null;
            v_SGUID = new IDVariant(com.progamma.GUID.DocID2GUID (com.progamma.doc.MDOInit.GetNewDocID().stringValue()));
            // 
            // Per l'AppKey in esame, cerco il token dell'utente a
            // cui devo mandare la notifica seguendo questa regola
            // 
            // 1. Estraggo il token dello username che ho passato
            //  oppure
            // 2. Estraggo il token del token che passo al posto dello
            // username, oppure
            // 3. Estraggo tutti i token dell'AppKey in esame, se
            // lo username Empty String
            // 
            SQL = new StringBuilder();
            SQL.Append("select ");
            SQL.Append("  A.DEV_TOKEN as DEVTOKDEVTOK, ");
            SQL.Append("  A.REG_ID as REGIDEVITOKE, ");
            SQL.Append("  A.TYPE_OS as TYPEOSDEVTOK, ");
            SQL.Append("  A.DES_UTENTE as UTENDEVITOKE, ");
            SQL.Append("  A.PRG_LINGUA as IDLINGDEVTOK ");
            SQL.Append("from ");
            SQL.Append("  DEV_TOKENS A ");
            SQL.Append("where (A.ID_APPLICAZIONE = " + IDL.CSql(C12.Get("VID"), IDL.FMT_NUM, NotificatoreDBObject.DBO()) + ") ");
            SQL.Append("and   (A.FLG_ATTIVO = 'S') ");
            SQL.Append("and   (A.FLG_RIMOSSO = 'N') ");
            SQL.Append("and   (A.DES_UTENTE = " + IDL.CSql(UserName, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " OR A.DEV_TOKEN = " + IDL.CSql(UserName, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " OR " + IDL.CSql(UserName, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " = '') ");
            C13 = NotificatoreDBObject.DBO().OpenRS(SQL);
            if (!C13.EOF()) C13.MoveNext();
            while (!C13.EOF())
            {
              IDVariant v_MESSADASPEDI = null;
              v_MESSADASPEDI = (new IDVariant());
              // ReturnStatus = NotificatoreDBObject.WriteMessageLog(new IDVariant (SQL.ToString()));
              // if (ReturnStatus != 0) throw new Exception(NotificatoreDBObject.ErrorMessage());
              if (C13.Get("IDLINGDEVTOK").equals(v_IDLINGDEFAPP, true) || new IDVariant(v_MESSAINLINGU1.Count()).equals((new IDVariant(0)), true) || IDL.IsNull(C13.Get("IDLINGDEVTOK")))
              {
                v_MESSADASPEDI = new IDVariant(v_MESSLINGDEFA);
              }
              else
              {
                IDVariant I = new IDVariant(0,IDVariant.INTEGER);
                for (; I.compareTo(new IDVariant(v_MESSAINLINGU1.Count()), true)<0; I = IDL.Add(I, (new IDVariant(1))))
                {
                  if (I.equals((new IDVariant(0)), true))
                  {
                    v_MESSAINLINGU1.MoveFirst();
                  }
                  else
                  {
                    v_MESSAINLINGU1.MoveNext();
                  }
                  NotificatoreWS.Lingue L = null;
                  L = (Lingue)v_MESSAINLINGU1.GetAt();
                  if (L.getlang().equals(C13.Get("IDLINGDEVTOK"), true))
                  {
                    v_MESSADASPEDI = L.getmessage();
                    break;
                  }
                }
              }
              if (IDL.IsNull(v_MESSADASPEDI))
              {
                v_MESSADASPEDI = new IDVariant(v_MESSLINGDEFA);
              }
              if (C12.Get("TYPOSAPPPUSE").equals((new IDVariant("5")), true))
              {
                // 
                // Encode special characters
                // Scrivi un commento per questo blocco o premi backspace
                // per eliminare questo commento
                // 
                {
                  v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("&")), (new IDVariant("&amp;")));
                  v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("<")), (new IDVariant("&lt;")));
                  v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant(">")), (new IDVariant("&gt;")));
                  v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("'")), (new IDVariant("&apos;")));
                  v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("\"")), (new IDVariant("&quot;")));
                }
                v_MESSADASPEDI = IDL.Replace(C12.Get("WNXMTEAPPUSE"), (new IDVariant("{MESSAGE_PLACEHOLDER}")), v_MESSADASPEDI);
              }
              if (C12.Get("TYPOSAPPPUSE").equals((new IDVariant("3")), true))
              {
                // 
                // Encode special characters
                // Scrivi un commento per questo blocco o premi backspace
                // per eliminare questo commento
                // 
                {
                  v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("&")), (new IDVariant("&amp;")));
                  v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("<")), (new IDVariant("&lt;")));
                  v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant(">")), (new IDVariant("&gt;")));
                  v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("'")), (new IDVariant("&apos;")));
                  v_MESSADASPEDI = IDL.Replace(v_MESSADASPEDI, (new IDVariant("\"")), (new IDVariant("&quot;")));
                }
                v_MESSADASPEDI = IDL.Replace(C12.Get("WNXMTEAPPUSE"), (new IDVariant("{MESSAGE_PLACEHOLDER}")), v_MESSADASPEDI);
              }
              // ReturnStatus = NotificatoreDBObject.WriteMessageLog(new IDVariant (SQL.ToString()));
              // if (ReturnStatus != 0) throw new Exception(NotificatoreDBObject.ErrorMessage());
              // 
              // Metto il messaggio in coda per il token in esame
              // 
              SQL = new StringBuilder();
              SQL.Append("insert into SPEDIZIONI ");
              SQL.Append("( ");
              SQL.Append("  DEV_TOKEN, ");
              SQL.Append("  REG_ID, ");
              SQL.Append("  DES_MESSAGGIO, ");
              SQL.Append("  DES_UTENTE, ");
              SQL.Append("  ID_APPLICAZIONE, ");
              SQL.Append("  SOUND, ");
              SQL.Append("  BADGE, ");
              SQL.Append("  TYPE_OS, ");
              SQL.Append("  GUID_GRUPPO ");
              SQL.Append(") ");
              SQL.Append("values ");
              SQL.Append("( ");
              SQL.Append("  " + IDL.CSql(C13.Get("DEVTOKDEVTOK"), IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  " + IDL.CSql(C13.Get("REGIDEVITOKE"), IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  CASE WHEN " + IDL.CSql(v_MESSADASPEDI, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + "='' OR (" + IDL.CSql(v_MESSADASPEDI, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " IS NULL AND '' IS NULL) THEN convert(varchar,NULL) ELSE " + IDL.CSql(v_MESSADASPEDI, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " END, ");
              SQL.Append("  CASE WHEN " + IDL.CSql(UserName, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + "='' OR (" + IDL.CSql(UserName, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " IS NULL AND '' IS NULL) THEN " + IDL.CSql(C13.Get("UTENDEVITOKE"), IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " ELSE " + IDL.CSql(UserName, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " END, ");
              SQL.Append("  " + IDL.CSql(C12.Get("VID"), IDL.FMT_NUM, NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  CASE WHEN " + IDL.CSql(Sound, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + "='' OR (" + IDL.CSql(Sound, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " IS NULL AND '' IS NULL) THEN convert(varchar,NULL) ELSE " + IDL.CSql(Sound, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " END, ");
              SQL.Append("  CASE WHEN " + IDL.CSql(Badge, IDL.FMT_NUM, NotificatoreDBObject.DBO()) + "='' OR (" + IDL.CSql(Badge, IDL.FMT_NUM, NotificatoreDBObject.DBO()) + " IS NULL AND '' IS NULL) THEN NULL ELSE " + IDL.CSql(Badge, IDL.FMT_NUM, NotificatoreDBObject.DBO()) + " END, ");
              SQL.Append("  " + IDL.CSql(C13.Get("TYPEOSDEVTOK"), IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + ", ");
              SQL.Append("  " + IDL.CSql(v_SGUID, IDL.FMT_CHAR, NotificatoreDBObject.DBO()) + " ");
              SQL.Append(") ");
              NotificatoreDBObject.DBO().Execute(SQL);
              C13.MoveNext();
            }
            C13.Close();
            C12.MoveNext();
          }
          C12.Close();
        }
        catch (Exception e26)
        {
          v_SRETVALUE = (new IDVariant("Errore imprevisto. Controllare il json"));
        }
      }
      // 
      // Non ci sono errori
      // 
      MainFrm.CloseDBConnections();
      return (v_SRETVALUE).stringValue();
    }
    catch (Exception _e)
    {
      MainFrm.CloseDBConnections();
      throw new Exception("SendNotificationWithLang - "+_e.Message,_e);
    }
  }

}

}
