// **********************************************
// Document Orientation Meta Data Library
// **********************************************
using System;
using com.progamma;
using com.progamma.doc;

[Serializable]
public class MyMDOInit : MDOInit
{
  // **********************************************
  // Create a new document
  // **********************************************
  public static IDDocument CreateDocument(String DOName)
  {
    //
    return null;
  }


  // **********************************************
  // Get MD By Name
  // **********************************************
  public static DOMDObj GetMetaData(String DOName)
  {
    //
    throw new Exception("ERR " + DOERR_NOCLASS + ": [" + DOName + "] Classe Sconosciuta");
  }
}
