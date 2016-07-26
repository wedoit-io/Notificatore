// **********************************************
// Document Orientation Meta Data Library
// **********************************************
namespace NotificatoreWS
{

using com.progamma;
using com.progamma.doc;

using System;
using System.Collections;
using System.Text;
using System.IO;

public class MyMDOInit : MDOInit
{
  // **********************************************
  // Create a new document
  // **********************************************
  public static IDDocument CreateDocument(String DOName)
  {
    if (DOName.Equals("Lingue")) return new Lingue();
    //
    return null;
  }


  // **********************************************
  // Get MD By Name
  // **********************************************
  public static DOMDObj GetMetaData(String DOName)
  {
    if (DOName.Equals("Lingue")) return Lingue.GetDOMD_Lingue();
    //
    throw new Exception("ERR " + DOERR_NOCLASS + ": [" + DOName + "] Classe Sconosciuta");
  }
}

}
