// **********************************************
// Notificatore
// Project : Mobile Manager
// **********************************************
namespace NotificatoreWS
{
  
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
[WebServiceBindingAttribute(Name="ServiceSoap", Namespace="http://www.progamma.com")]
public class Notificatore : IDWebService
{
  public Notificatore()
  {
  	Url = "http://www.progamma.com";
  	NameSpace = "http://www.progamma.com";
  }

  [SoapRpcMethodAttribute("http://www.progamma.com/SendNotification", RequestNamespace = "http://www.progamma.com", ResponseNamespace = "http://www.progamma.com")]
  public String SendNotification (String pAuthKey, String pApplicationKey, String pMessage, String pUserName, String pSound, int pBadge)
  {
    Object[] Res = this.Invoke("SendNotification", new Object[] {pAuthKey, pApplicationKey, pMessage, pUserName, pSound, pBadge});
    return ((String)Res[0]);
  }

  public IDVariant SendNotification_ws (IDVariant AuthKey, IDVariant ApplicationKey, IDVariant Message, IDVariant UserName, IDVariant Sound, IDVariant Badge)
  {
    return IDVariant.convertObject(SendNotification(AuthKey.stringValue(), ApplicationKey.stringValue(), Message.stringValue(), UserName.stringValue(), Sound.stringValue(), Badge.intValue()));
  }

  [SoapRpcMethodAttribute("http://www.progamma.com/SendNotificationWithLang", RequestNamespace = "http://www.progamma.com", ResponseNamespace = "http://www.progamma.com")]
  public String SendNotificationWithLang (String pAuthKey, String pApplicationKey, String pMessage, String pUserName, String pSound, int pBadge)
  {
    Object[] Res = this.Invoke("SendNotificationWithLang", new Object[] {pAuthKey, pApplicationKey, pMessage, pUserName, pSound, pBadge});
    return ((String)Res[0]);
  }

  public IDVariant SendNotificationWithLang_ws (IDVariant AuthKey, IDVariant ApplicationKey, IDVariant Message, IDVariant UserName, IDVariant Sound, IDVariant Badge)
  {
    return IDVariant.convertObject(SendNotificationWithLang(AuthKey.stringValue(), ApplicationKey.stringValue(), Message.stringValue(), UserName.stringValue(), Sound.stringValue(), Badge.intValue()));
  }

}

}
