// **********************************************
// Lingue
// Build on: 17/11/2014 16.28.33
// Project : Mobile Manager
// **********************************************
namespace NotificatoreWS
{

using com.progamma;
using com.progamma.ws;
using com.progamma.doc;
using Glb = com.progamma.ids.Glb;

using System;
using System.Collections;
using System.Text;
using System.IO;

public class Lingue : com.progamma.doc.IDDocument
{
  private WebEntryPoint MainFrm;
  private IMDBObj IMDB;
  private static String ClassName = null;
  private static Object LockClass=new Object();

  // Property constant definitions
  public const int LINGUE_lang = 1;
  public const int LINGUE_message = 2;
  public const int MAX_VARS = 2;
  public const int BASE_VARS = 0;
  public const int BASE_COLLS = 0;

  // Definition of Global Variables
  public IDVariant getlang() { return GetPropDirect(LINGUE_lang); }
  public void setlang(IDVariant NewValue) { ChangePropDirect(LINGUE_lang,NewValue,false); }
  public IDVariant getmessage() { return GetPropDirect(LINGUE_message); }
  public void setmessage(IDVariant NewValue) { ChangePropDirect(LINGUE_message,NewValue,false); }

	// **********************************************
  // Inizializzatore tabelle IMDB di form
  // **********************************************
  public static void ImdbInit(IMDBObj IMDB)
  {
    //
    //
  }

  // IMDB DDL Procedures
  

  // **********************************************
  // Initialize common framework object
  // **********************************************
  public Lingue()
  {
  }

  // **********************************************
  // Initialize common framework object
  // **********************************************
  public Lingue(WebEntryPoint w, IMDBObj imdb)
  {
    SetMainFrm(w, imdb);
  }

  // **********************************************
  // Initialize common framework object
  // **********************************************
  public override void SetMainFrm(Object mainfrm, Object imdb)
  {
    if (MainFrm==null)
  	{
    	MainFrm = (WebEntryPoint)mainfrm;
    	IMDB = (IMDBObj)imdb;
	    //
    	if (aVars==null)
    	{
	    	aVars = new IDVariant[MAX_VARS+BASE_VARS];
		    MyMDOInit.Initialize(this);
	    }
	    //
	    //
	    DOMDObj MD = GetMD();
	    for (int i = 1; i <= MD.GetNumColl(); i++)
	    {
	      IDCollection c = GetCollByIndex(i);
	      c.set_MainFrm(mainfrm);
	      c.set_imdb(imdb);
	    }
		  //
	    //
	    base.SetMainFrm(mainfrm,imdb);
	  }
  }

  public override Object GetMainFrm()
  {
    return MainFrm;
  }

/*
  public override IDDocHelper GetDocHelper()
  {
    if (MainFrm != null)
      return MainFrm.DocHelper;
    else
      return null;
  }
*/

  public override Object GetIMDB()
  {
    return IMDB;
  }

/*
  public override void RefreshUI()
  {
    if (MainFrm != null)
      MainFrm.RefreshUI = true;
  }

  public override ArrayList GetLookupCache()
  {
    if (MainFrm != null)
      return MainFrm.LookupCache;
    else
      return null;
  }

  public override Hashtable GetSchemaCache()
  {
    if (MainFrm != null)
      return MainFrm.SchemaCache;
    else
      return null;
  }
*/

  // **********************************************
  // Get Database Connection (if not Meta Data Connected)
  // **********************************************
  public override IDConnection GetDBObj(bool Open)
  {
    try
    {
    }
    catch (Exception)
    {
    }
    return base.GetDBObj(Open);
  }

  // **********************************************
  // Get Meta Data
  // **********************************************
  private static DOMDObj MDOLingue;
  public static DOMDObj GetDOMD_Lingue()
  {
  lock (LockClass)
  {
    DOMDProp MDP;
    DOMDColl MDC;
    DOMDLinkedDoc DOC;

    if (MDOLingue != null)
      return MDOLingue;
    else
      MDOLingue = new DOMDObj();
    MDOLingue.ObjTag = "Lingue";
    MDOLingue.ObjGUID = "4076055F-2DD6-4CEB-8B0E-E5348AEB5E43";
    MDOLingue.UIName = "Lingue";
    MDOLingue.Services = 0;
    MDOLingue.BaseProps = 0;
    MDOLingue.BaseColls = 0;
    MDOLingue.SetNumProp(2);
    MDP = new DOMDProp();
    MDOLingue.SetProp(1,MDP);
    MDP.Index = 1;
    MDP.ObjTag = "lang";
    MDP.Name = "Lingua";
    MDP.UIName = "Lingua";
    MDP.GUID = "9375DEB1-E2B0-47EA-A47F-2AFD2E6D3A6C";
    MDP.DataType = 1;
    MDP.MaxLength = 2;
    MDP.vScale = 0;
    MDP = new DOMDProp();
    MDOLingue.SetProp(2,MDP);
    MDP.Index = 2;
    MDP.ObjTag = "message";
    MDP.Name = "Message";
    MDP.UIName = "Message";
    MDP.GUID = "BBFDDE0C-FD8F-497C-BE15-3E194B581BF9";
    MDP.DataType = 5;
    MDP.MaxLength = 650;
    MDP.vScale = 0;
    MDOLingue.SetNumColl(0);
    return MDOLingue;
  }
  }

  public override DOMDObj GetMD()
  {
    return GetDOMD_Lingue();
  }

  // **********************************************
  // Get Meta Data By Name (tutte le classi...)
  // **********************************************
  public override DOMDObj GetMD(String ClassName)
  {
    try
    {
      return MyMDOInit.GetMetaData(ClassName);
    }
    catch (Exception e)
    {
      Console.Error.WriteLine(e.Message + "\n" + e.StackTrace); Console.Error.Flush();
      return null;
    }
  }

  // **********************************************
  // Get Meta Data By Name (tutte le classi...)
  // **********************************************
  public override IDDocument CreateDocument(String ClassName)
  {
    try
    {
      IDDocument d = MyMDOInit.CreateDocument(ClassName);
      d.SetMainFrm(MainFrm, IMDB);
      return d;
    }
    catch (Exception e)
    {
      Console.Error.WriteLine(e.Message + "\n" + e.StackTrace); Console.Error.Flush();
      return null;
    }
  }

  // **********************************************
  // Init Default Values
  // **********************************************
  public override void InitDefaults()
  {
    base.InitDefaults();
  }

  public override void Init()
  {
    InitDefaults();
    MDOInit.Init(this);
  }


  // **********************************************
  // Set Property By Index
  // **********************************************
  public override void SetPropByIndex(int Idx, IDVariant NewValue)
  {
    if (Idx==LINGUE_lang) { setlang(NewValue); goto fine; }
    if (Idx==LINGUE_message) { setmessage(NewValue); goto fine; }
    base.SetPropByIndex(Idx, NewValue);
    fine: ;
  }


  // **********************************************
  // Get Collection By Index
  // **********************************************
  public override IDCollection GetCollByIndex(int Idx)
  {
    return base.GetCollByIndex(Idx);
  }


  // **********************************************
  // Get Master Query used to load a document
  // **********************************************
  public override void GetMasterQuery(String[] SqlText, IDVariant MasterTableAlias, ArrayList ColAssignment)
  {
    StringBuilder SQL;

  }


  // **********************************************
  // Get Value Source Query used to load a collection
  // **********************************************
  public override void GetValueSource(IDVariant SQLStmt, ArrayList ColAssignment, IDCollection Coll, IDDocument DummyDoc)
  {
    StringBuilder SQL;
    String[] SqlText = new String[6];

    //
    if (SqlText[0]==null)
    {
    	// Ask to base class
    	base.GetValueSource(SQLStmt, ColAssignment, Coll, DummyDoc);
    	return;
    }
    //
    SQL = new StringBuilder();
    for (int i=0;i<6;i++)
   	{
   		if (SqlText[i]==null)
   			continue;
   		//
    	SQL.Append(SqlText[i]);
    	if (i == Glb.SQL_WHERE)
			{
				// Fire OnSQL Event...
				IDVariant AddWC = new IDVariant();
				DummyDoc.OnSQLQuery(new IDVariant(SQL.ToString()), new IDVariant(MDOInit.QRY_LOADCOLLECTION), AddWC);
				if (AddWC.stringValue().Length>0)
				{
					if (SqlText[i].Length == 0)
						SQL.Append(" where ");
					else
						SQL.Append(" and ");
					SQL.Append(AddWC);
				}
			}
    }
    SQLStmt.set(new IDVariant(SQL.ToString()));
  }


	// **********************************************
  // Document Validation
  // **********************************************
	public override void InternalValidate(int Reason, IDVariant bError)
	{
		MDOInit.InternalValidate(this, Reason, bError);
	}
	

  // **********************************************
  // Get DB Expression used to load a property
  // **********************************************
  public override String GetDBExpr(int PropIdx)
  {
    StringBuilder SQL;

    return "";
  }


	// **********************************************
  // Class factory
  // **********************************************
  public static Lingue CreateLingue()
 	{
 		return CreateLingue(null, null);
 	}
  
	public static Lingue CreateLingue(Object mainfrm, Object imdb)
	{
		Lingue newobj;
		//
		// Creating object
		lock(LockClass)
		{
			if (ClassName == null)
			  newobj = new Lingue(); // No class factory
			else
				newobj = (Lingue)System.Reflection.Assembly.GetCallingAssembly().CreateInstance(ClassName, true);
		}
		//
		// Setting Main Objects
		if (mainfrm!=null)
			newobj.SetMainFrm(mainfrm, imdb);
		//
		return newobj;
	}

	public static void SetClassName(String cn)
	{
		lock(LockClass)
		{
			ClassName = cn;
		}
	}

  // **********************************************
  // Definizione Concept di proprietà a run-time
  // **********************************************
  public static void SetPropertyConcept(IDVariant PropIdx, IDVariant Concept)
  {
    DOMDObj MD = GetDOMD_Lingue();
    DOMDProp MPR = MD.GetProp(PropIdx.intValue());
    lock (MPR)
    {
      MPR.Concept = Concept.stringValue();
    }
  }

  // **************************************************
  // Torna TRUE se l'oggetto passato è una mia istanza
  // **************************************************
  public static bool IsMyInstance(Object obj)
  {
    return (obj is Lingue);
  }

  // **********************************************
  // Restituisce il nome della classe
  // **********************************************
  public static String GetClassName(bool FullName)
  {
    return (FullName ? typeof(Lingue).FullName : typeof(Lingue).Name);
  }


  // **********************************************
  // Procedure Definition
  // **********************************************


}

}
