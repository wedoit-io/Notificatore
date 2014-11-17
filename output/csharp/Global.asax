<%@ Application Inherits="Global" Language="C#" %>
<%@ Import Namespace="System.Web.Configuration" %>
<script runat="server" language="C#">
  
  protected void Application_BeginRequest(object sender, EventArgs e)
  {
    /* Fix for the Flash Player Cookie bug in Non-IE browsers.
    * Since Flash Player always sends the IE cookies even in FireFox
    * we have to bypass the cookies by sending the values as part of the POST or GET
    * and overwrite the cookies with the passed in values.
    *
    * The theory is that at this point (BeginRequest) the cookies have not been read by
    * the Session and Authentication logic and if we update the cookies here we'll get our
    * Session and Authentication restored correctly
    */
    try
    {
      string session_cookie_name = "ASP.NET_SessionId";
      try
      {
        session_cookie_name = ((SessionStateSection)WebConfigurationManager.GetWebApplicationSection("system.web/sessionState")).CookieName;
      }
      catch (Exception)
      { }
      //
      string sessionID = HttpContext.Current.Request.QueryString["SESSIONID"];
      if (sessionID != null)
        UpdateCookie(session_cookie_name, sessionID);
    }
    catch (Exception)
    {
      Response.StatusCode = 500;
      Response.Write("Error Initializing Session");
    }

/*
    try
    {
      string auth_cookie_name = FormsAuthentication.FormsCookieName;
      string authID = HttpContext.Current.Request.QueryString["AUTHID"];
      //
      if (authID != null)
        UpdateCookie(auth_cookie_name, authID);
    }
    catch (Exception)
    {
      Response.StatusCode = 500;
      Response.Write("Error Initializing Forms Authentication");
    }
*/
  }

  void UpdateCookie(string cookie_name, string cookie_value)
  {
    HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookie_name);
    if (cookie == null)
    {
      cookie = new HttpCookie(cookie_name);
      HttpContext.Current.Request.Cookies.Add(cookie);
    }
    cookie.Value = cookie_value;
    HttpContext.Current.Request.Cookies.Set(cookie);
  }
</script>
