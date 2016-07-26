// **********************************************
// Connect to a database
// Instant WEB Application: www.progamma.com
// Build on: 26/07/2016 11.08.06
// Project : Mobile Manager
// **********************************************
namespace NotificatoreWS
{

using com.progamma;
using com.progamma.svc;

using System;
using System.Text;
using System.IO;
using System.Collections;

// **********************************************
// Command Handler
// **********************************************
public sealed class NotificatoreDB : IDBObject
{
  public IDConnection DB = new IDConnection();
  public int TransCount = 0;
  public int vErrorNumber = 0;
  public String vErrorMessage;
  public String vOffendingCommand;

  public String vDefaultUserId;
  public String vDefaultPassword;
  public String vDefaultConnStr;
  public String DBName;
  public int DBType;
  public int MaxRows;

  private com.progamma.ws.WebEntryPoint MainFrm;

  public String DefaultUserId()       { return vDefaultUserId; }
  public String DefaultPassword()     { return vDefaultPassword; }
  public String DefaultConnStr()      { return vDefaultConnStr; }
  public int DBaseType()              { return DBType; }
  public byte SchemaAlreadyAdjusted() { return 0; }
  public String OffendingCommand()    { return vOffendingCommand; }
  public String ErrorMessage()        { return vErrorMessage; }
  public int ErrorNumber()            { return vErrorNumber; }

  public void set_DefaultUserId(String s)         { vDefaultUserId = s; }
  public void set_DefaultPassword(String s)       { vDefaultPassword = s; }
  public void set_DefaultConnStr(String s)        { vDefaultConnStr = s; }
  public void set_DBaseType(int t)                { DBType = t; }
  public void set_SchemaAlreadyAdjusted(byte sc)  {}
  public void set_OffendingCommand(String s)      { vOffendingCommand = s; }
  public void set_ErrorMessage(String s)          { vErrorMessage = s; }
  public void set_ErrorNumber(int t)              { vErrorNumber = t; }

  public IDConnection GetDB()                 { return DB; }
  public void DBAdjustSchema(bool flForceNew) {}

  // **********************************************
  // Costruttore
  // **********************************************
  public NotificatoreDB(com.progamma.ws.WebEntryPoint p)
  {
    MainFrm=p;
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
    return DB;
  }


  // **********************************************************************
  // Open a new connection
  // **********************************************************************
  public int OpenConnection(String UserID, String Password, String ConnStr)
  {
    try
    {
      ClearErrors();
      if (UserID.Length == 0)
      {
        Password = vDefaultPassword;
        UserID = vDefaultUserId;
      }
      if (ConnStr.Length == 0)
        ConnStr = vDefaultConnStr;
      //
      DB.Open(ConnStr, UserID, Password, DBType);
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
    if (DB.IsOpen())
    {
      try
      {
        if (TransCount > 0)
        {
          RollbackTrans();
        }
        DB.Close(force);
      }
      catch (Exception)
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
    vErrorNumber = 0;
    vErrorMessage = "";
    vOffendingCommand = "";
  }


  // **********************************************************************
  // Set error status
  // **********************************************************************
  public int SetError(String SQL, Exception s)
  {
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
    return vErrorNumber;
  }


  // **********************************************************************
  // Transaction functions
  // **********************************************************************
  public void BeginTrans()
  {
    TransCount = TransCount + 1;
    DBO().BeginTrans();
  }

  public void CommitTrans()
  {
    TransCount = TransCount - 1;
    DBO().CommitTrans();
  }

  public void RollbackTrans()
  {
    TransCount = TransCount - 1;
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


}

}
