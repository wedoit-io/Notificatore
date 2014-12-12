// **********************************************
// Wikipedia
// Project : Mobile Manager
// **********************************************
using System;
using System.Text;
using System.IO;
using System.Collections;
using System.Data;
using System.ComponentModel;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.Services.Description;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.CodeDom.Compiler;

using com.progamma.ws;
using com.progamma;

[GeneratedCodeAttribute("System.Web.Services", "2.0.50727.42")]
[DesignerCategoryAttribute("code")]
[WebServiceBindingAttribute(Name="ServiceSoap", Namespace="http://tempuri.org/")]
public class Wikipedia : IDWebService
{
  public Wikipedia()
  {
  	Url = "http://dev.wikipedia-lab.org/WikipediaOntologyAPIv3/Service.asmx";
  	NameSpace = "http://tempuri.org/";
  }

  [SoapDocumentMethodAttribute("http://tempuri.org/GetTopCandidateIDFromKeyword", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
  public int GetTopCandidateIDFromKeyword (String Keyword, String language)
  {
    Object[] Res = this.Invoke("GetTopCandidateIDFromKeyword", new Object[] {Keyword, language});
    return ((int)Res[0]);
  }

  public IDVariant GetTopCandidateIDFromKeyword_ws (IDVariant Keyword, IDVariant language)
  {
    return IDVariant.convertObject(GetTopCandidateIDFromKeyword(Keyword.stringValue(), language.stringValue()));
  }

}
