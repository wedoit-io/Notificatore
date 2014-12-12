// **********************************************
// In Memory Database Initialization
// **********************************************
namespace NotificatoreWS
{
  
using com.progamma;
using com.progamma.ws;

using System;
using System.Collections;
using System.Text;
using System.IO;

// **********************************************
// In Memory Database Initialization
// **********************************************
public sealed class MyImdbInit : ImdbInit
{
  public static int IMDB_OFFSET = 0;

  // **********************************************
	// Costruttore
	// **********************************************
	public MyImdbInit(WebEntryPoint p) : base(p)
	{
    //
    IMDB.set_DBSize(1 + MyImdbInit.IMDB_OFFSET);
    //
    //
    //
    Notificatore.ImdbInit(IMDB);
    Lingue.ImdbInit(IMDB);
    //
    IMDB.set_TblNumField(IMDBDef1.TMP_RECORDSET, 0);
    IMDB.set_Version(0);
	  //
	  // Set all tables in a modified state
	  //
	  IMDB.ResetAllModified(-1);
	}

  // IMDB DDL Procedures

}

}
