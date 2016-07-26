// **********************************************
// Connect to a database
// Instant WEB Application: www.progamma.com
// Project : Mobile Manager
// **********************************************
using System;
using System.Text;
using System.Collections;
using System.Data.Common;
using com.progamma.ids;
using com.progamma;

// **********************************************
// Command Handler
// **********************************************
[Serializable]
public partial class NotificatoreDB : IDBObject
{
  public IDConnection DB = new IDConnection();
  public int vErrorNumber = 0;
  public String vErrorMessage;
  public String vOffendingCommand;

  public String vDefaultUserId;
  public String vDefaultPassword;
  public String vDefaultConnStr;
  public String DBName;
  public int DBType;
  public int MaxRows;

  private MyWebEntryPoint MainFrm;

  private const int ChunkSize = 32768;

  private static byte iSchemaAlreadyAdjusted = 0;

  // Create private definition of other databases for web applications

  public void WebInit(MyWebEntryPoint w)
  {
    MainFrm = w;
  }



  public String DefaultUserId()
  {
    if (DB.Parent != this)
      return DB.Parent.DefaultUserId();
    //
    return vDefaultUserId;
  }
  public String DefaultPassword()
  {
    if (DB.Parent != this)
      return DB.Parent.DefaultPassword();
    //
    return vDefaultPassword;
  }
  public String DefaultConnStr()
  {
    if (DB.Parent != this)
      return DB.Parent.DefaultConnStr();
    //
    return vDefaultConnStr;
  }
  public int DBaseType()
  {
    if (DB.Parent != this)
      return DB.Parent.DBaseType();
    //
    return DBType;
  }
  public byte SchemaAlreadyAdjusted()
  {
    if (DB.Parent != this)
      return DB.Parent.SchemaAlreadyAdjusted();
    //
    return iSchemaAlreadyAdjusted;
  }
  public String OffendingCommand()
  {
    if (DB.Parent != this)
      return DB.Parent.OffendingCommand();
    //
    return vOffendingCommand;
  }
  public String ErrorMessage()
  {
    if (DB.Parent != this)
      return DB.Parent.ErrorMessage();
    //
    return vErrorMessage;
  }
  public int ErrorNumber()
  {
    if (DB.Parent != this)
      return DB.Parent.ErrorNumber();
    //
    return vErrorNumber;
  }
  public IDConnection GetDB()
  {
    return DB;
  }
  public void DBAdjustSchema(bool flForceNew)
  {
    if (DB.Parent != this)
    {
      DB.Parent.DBAdjustSchema(flForceNew);
      return;
    }
    //
    AdjustSchema(flForceNew);
  }

  public void set_DefaultUserId(String s)
  {
    if (DB.Parent != this)
      DB.Parent.set_DefaultUserId(s);
    //
    vDefaultUserId = s;
  }
  public void set_DefaultPassword(String s)
  {
    if (DB.Parent != this)
      DB.Parent.set_DefaultPassword(s);
    //
    vDefaultPassword = s;
  }
  public void set_DefaultConnStr(String s)
  {
    if (DB.Parent != this)
      DB.Parent.set_DefaultConnStr(s);
    //
    vDefaultConnStr = s;
    //
    // Quando cambia la stringa di connessione devo rimettere a posto lo schema
    set_SchemaAlreadyAdjusted(0);
    //
    // ... ed eventualmente la ZZ_SYNC
    if (MainFrm.SyncObject.DB == this)
      MainFrm.SyncObject.TablesAlreadyChecked = false;
  }
  public void set_DBaseType(int t)
  {
    if (DB.Parent != this)
      DB.Parent.set_DBaseType(t);
    //
    DBType = t;
  }
  public void set_SchemaAlreadyAdjusted(byte sc)
  {
    if (DB.Parent != this)
      DB.Parent.set_SchemaAlreadyAdjusted(sc);
    //
    iSchemaAlreadyAdjusted = sc;
  }
  public void set_OffendingCommand(String s)
  {
    if (DB.Parent != this)
      DB.Parent.set_OffendingCommand(s);
    //
    vOffendingCommand = s;
  }
  public void set_ErrorMessage(String s)
  {
    if (DB.Parent != this)
      DB.Parent.set_ErrorMessage(s);
    //
    vErrorMessage = s;
  }
  public void set_ErrorNumber(int t)
  {
    if (DB.Parent != this)
      DB.Parent.set_ErrorNumber(t);
    //
    vErrorNumber = t;
  }
  // **********************************************
  // Costruttore
  // **********************************************
  public NotificatoreDB(MyWebEntryPoint p)
  {
    MainFrm = p;
    DB.Parent = this;
    vDefaultUserId = "sa";
    vDefaultPassword = "apice";
    vDefaultConnStr = "Data Source=CORK;Initial Catalog=NOTIFICATORE;Persist Security Info=False";
    DBType = 256;
    DB.Unicode = true;
    DBName = "NotificatoreDB";
  }


  // **********************************************************************
  // Make the connection open
  // **********************************************************************
  public IDConnection DBO()
  {
    if (!DB.IsOpen())
      OpenConnection("", "", "");
    //
    return DB;
  }


  // **********************************************************************
  // Open a new connection
  // **********************************************************************
  public int OpenConnection(String UserID, String Password, String ConnStr)
  {
    if (DB.Parent != this)
      return DB.Parent.OpenConnection(UserID, Password, ConnStr);
    //
    try
    {
      ClearErrors();
      if (UserID.Length == 0)
      {
        Password = DefaultPassword();
        UserID = DefaultUserId();
      }
      if (ConnStr.Length == 0)
        ConnStr = DefaultConnStr();
      //
      if (ConnStr.IndexOf("$DB") > 0)
        ConnStr = ConnStr.Replace("$DB", MainFrm.RealPath + "/DB");
      //
      MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 160, DBName + ".OpenConnection", DBName + ": Open Connection");
      MainFrm.DTTObj.AddParameter("", "", "Connection String", new IDVariant(ConnStr));
      MainFrm.DTTObj.AddParameter("", "", "User ID", new IDVariant(UserID));
      MainFrm.DTTObj.AddParameter("", "", "Password", new IDVariant(Password));
      //
      DB.Open(ConnStr, UserID, Password, DBType);
      //
      if (DB.getConnection() != null && DB.IntConDrvDetails!=null)
        MainFrm.DTTObj.AddParameter("", "", "Driver", new IDVariant(DB.IntConDrvDetails + " (" + DB.getConnection().GetType().Assembly + ")"));
      //
      // Prima di ridare la connessione, controllo che lo schema sia a posto
      // ma solo la prima volta
      if (SchemaAlreadyAdjusted()==0)
      {
        set_SchemaAlreadyAdjusted(1);
        DBAdjustSchema(false);
        set_SchemaAlreadyAdjusted(2);
      }
      //
      // Attendo inizializzazione da altra sessione
      while (SchemaAlreadyAdjusted() != 2)
        System.Threading.Thread.Sleep(50);
      //
      return 0;
    }
    catch (Exception s)
    {
      return SetError("OPEN", s);
    }
  }

  // **********************************************************************
  // Make the connection close
  // **********************************************************************
  public void CloseConnection()
  {
    CloseConnection(false);
  }

  public void CloseConnection(bool force)
  {
    if (DB.Parent != this)
    {
      DB.Parent.CloseConnection(force);
      return;
    }
    //
    if (DB.IsOpen())
    {
      try
      {
        if (DB.TransCount > 0)
        {
          MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_WARN, "", 171, DBName + ".CloseConnection", DBName + ": closing while in transaction");
          RollbackTrans();
        }
        DB.Close(force);
      }
      catch (DbException s)
      {
        // Salto...
      }
    }
  }

  // **********************************************************************
  // Clear error status
  // **********************************************************************
  public void ClearErrors()
  {
    if (DB.Parent != this)
      DB.Parent.ClearErrors();
    //
    vErrorNumber = 0;
    vErrorMessage = "";
    vOffendingCommand = "";
  }


  // **********************************************************************
  // Set error status
  // **********************************************************************
  public int SetError(String SQL, Exception s)
  {
    if (DB.Parent != this)
      return DB.Parent.SetError(SQL, s);
    //
    vErrorNumber = -1;
    vErrorMessage = s.Message;
    vOffendingCommand = SQL;
    //
    if (vErrorNumber != -1) // Quando troveremo il modo di ritornare l'errore vero del DB
    {
      switch (DBType)
      {
        case Glb.DBT_SQLSRV6:
        case Glb.DBT_SQLSRV7:
        case Glb.DBT_SQLSRV2K:
          if (vErrorNumber > 50000)
            vErrorNumber = vErrorNumber - 50000;
          break;

        case Glb.DBT_ORACLE7:
        case Glb.DBT_ORACLE8:
          if (vErrorNumber < -20000)
            vErrorNumber = -vErrorNumber - 20000;
          break;
      }
    }
    //
    MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_ERROR, "", 161, DBName, DBName + ": " + s.Message);
    MainFrm.DTTObj.AddParameter("", "", "Offending Command", new IDVariant(vOffendingCommand));
    return vErrorNumber;
  }


  // **********************************************************************
  // Transaction functions
  // **********************************************************************
  public void BeginTrans()
  {
    if (DB.TransCount != 0)
      MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_WARN, "", 162, DBName + ".BeginTrans", DBName + ": nested transaction detected (" + DB.TransCount + ")");
    DBO().BeginTrans();
  }

  public void CommitTrans()
  {
    if (DB.TransCount < 1)
      MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_WARN, "", 163, DBName + ".CommitTrans", DBName + ": Commit without Begin Transaction");
    DBO().CommitTrans();
  }

  public void RollbackTrans()
  {
    if (DB.TransCount < 1)
      MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_WARN, "", 164, DBName + ".RollbackTrans", DBName + ": Rollback without Begin Transaction");
    DBO().RollbackTrans();
  }


  // **********************************************
  // Procedure Definition
  // **********************************************

  // **********************************************************************
  // Write Message Log
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Messaggio: Scrivi un commento per questo parametro o premi backspace per eliminare questo commento - Input
  // Livello:  - Input
  // Tipo:  - Input
  // **********************************************************************
  public int WriteMessageLog (IDVariant Messaggio, IDVariant Livello, IDVariant Tipo)
  {
    ArrayList SPPar  = new ArrayList();
    ArrayList ParNames = new ArrayList();
    ArrayList OutPar = new ArrayList();

    SPPar.Add(Messaggio);
    ParNames.Add("p_MESSAGGIO");
    OutPar.Add(IDVariant.STRING);
    SPPar.Add(Livello);
    ParNames.Add("p_LIVELLO");
    OutPar.Add(IDVariant.INTEGER);
    SPPar.Add(Tipo);
    ParNames.Add("p_TIPO");
    OutPar.Add(IDVariant.STRING);
    ClearErrors();
    try
    {
      DBO().CallSP("WRITE_MSG_LOG",SPPar,ParNames,OutPar);
      return 0;
    }
    catch(Exception s)
    {
      return SetError("WriteMessageLog",s);
    }
  }

  // **********************************************************************
  // Recupera Token
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // ID Apps Push Settings - Input
  // **********************************************************************
  public int RecuperaToken (IDVariant IDAppsPushSettings)
  {
    ArrayList SPPar  = new ArrayList();
    ArrayList ParNames = new ArrayList();
    ArrayList OutPar = new ArrayList();

    SPPar.Add(IDAppsPushSettings);
    ParNames.Add("p_IDAPPSPUSSET");
    OutPar.Add(IDVariant.INTEGER);
    ClearErrors();
    try
    {
      DBO().CallSP("RECUPERA_TOKEN",SPPar,ParNames,OutPar);
      return 0;
    }
    catch(Exception s)
    {
      return SetError("RecuperaToken",s);
    }
  }

  // **********************************************************************
  // Identifica Lingua
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // Codice Lingua1 - Input
  // Id Lingua - Input/Output
  // **********************************************************************
  public int IdentificaLingua (IDVariant CodiceLingua1, IDVariant IdLingua)
  {
    ArrayList SPPar  = new ArrayList();
    ArrayList ParNames = new ArrayList();
    ArrayList OutPar = new ArrayList();

    SPPar.Add(CodiceLingua1);
    ParNames.Add("p_CODICELINGUA");
    OutPar.Add(IDVariant.STRING);
    SPPar.Add(IdLingua);
    ParNames.Add("p_IDLINGUA");
    OutPar.Add(-IDVariant.INTEGER);
    ClearErrors();
    try
    {
      DBO().CallSP("SP_GET_LANGUAGE",SPPar,ParNames,OutPar);
      return 0;
    }
    catch(Exception s)
    {
      return SetError("IdentificaLingua",s);
    }
  }

  // **********************************************************************
  // Clean IOS Dev Token
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int CleanIOSDevToken ()
  {
    ArrayList SPPar  = new ArrayList();
    ArrayList ParNames = new ArrayList();
    ArrayList OutPar = new ArrayList();

    ClearErrors();
    try
    {
      DBO().CallSP("CLEAN_IOS_DEV_TOKEN",SPPar,ParNames,OutPar);
      return 0;
    }
    catch(Exception s)
    {
      return SetError("CleanIOSDevToken",s);
    }
  }

  // **********************************************************************
  // Import Sales Data
  // Spiega quale elaborazione viene eseguita da questa
  // procedura
  // **********************************************************************
  public int ImportSalesData ()
  {
    ArrayList SPPar  = new ArrayList();
    ArrayList ParNames = new ArrayList();
    ArrayList OutPar = new ArrayList();

    ClearErrors();
    try
    {
      DBO().CallSP("IMP_SALES_DATA",SPPar,ParNames,OutPar);
      return 0;
    }
    catch(Exception s)
    {
      return SetError("ImportSalesData",s);
    }
  }


  // **********************************************
  // SQLite schema adjustment
  // **********************************************
  public bool AdjustSchema(bool flForceNew)
  {
    // Se non è SQLite non posso aggiustare lo schema
    if (Glb.ClassDB(DBType) != Glb.DBC_SQLITE)
      return false;
    //
    // Evito problemi con i limiti e le sostituzioni
    DB.MaxRows = 0;
    DB.ClearSubstitutions();
    //
    try
    {
      MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 160, DBName + ".AdjustSchema", DBName + ": Adjust Schema");
      //
      // Disabilito FK Support / scrivo nelle tabelle di sistema
      DBO().Execute("PRAGMA foreign_keys = 0");
      //
      // Lavoro in transazione
      BeginTrans();
      //
      ArrayList Tabelle = new ArrayList();
      ArrayList Indici = new ArrayList();
      ArrayList Viste = new ArrayList();
      //
      if (flForceNew)
      {
        // Distruggo tutto
        DBO().DropUselessObjects(MainFrm, Tabelle, "table");
        DBO().DropUselessObjects(MainFrm, Indici, "index");
        DBO().DropUselessObjects(MainFrm, Viste, "view");
        //
        // ... ed eventualmente la ZZ_SYNC
        if (MainFrm.SyncObject.DB != null && MainFrm.SyncObject.DB.GetDB() == GetDB())
        {
          String sql = "DROP TABLE ZZ_SYNC";
          MainFrm.DTTObj.AddQuery(DBName + ".AdjustSchema", "Dropping table ZZ_SYNC", DBName + ".AdjustSchema", DTTEngine.STMT_QRY_UPDATE, sql);
          try
          {
            DBO().Execute(sql);
            MainFrm.SyncObject.TablesAlreadyChecked = false;
          }
          catch (Exception) { }
          MainFrm.DTTObj.EndQuery(DBName + ".AdjustSchema");
        }
      }
      //
      //
      // Distruggo oggetti ormai inutili, se effettivamente lo
      // schema doveva essere gestito automaticamente
      if (Tabelle.Count>0)
      {
        DBO().DropUselessObjects(MainFrm, Tabelle, "table");
        DBO().DropUselessObjects(MainFrm, Indici, "index");
        DBO().DropUselessObjects(MainFrm, Viste, "view");
      }
      //
      CommitTrans();
      //
      // Riabilito supporto a FK
      DBO().Execute("PRAGMA foreign_keys = 1");
      //
      MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_INFO, "", 160, DBName + ".AdjustSchema", DBName + ": Finished to adjust schema");
      //
      return true;
    }
    catch (Exception e)
    {
      // In caso di errore torno indietro e riabilito FK
      try
      {
        RollbackTrans();
        DBO().Execute("PRAGMA foreign_keys = 1");
      }
      catch (Exception) {}
      //
      vErrorMessage = e.Message;
      vOffendingCommand = "AdjustSchema";
      MainFrm.DTTObj.AddMsg(DTTEngine.DTTMSG_ERROR, "", 160, DBName + ".AdjustSchema", "Error occurred while adjusting schema: " + vErrorMessage);
      MainFrm.DTTObj.AddParameter("", "", "Stack Trace", e.StackTrace);
      return false;
    }
  }

}
