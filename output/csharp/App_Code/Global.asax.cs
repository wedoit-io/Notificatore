using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using com.progamma.ids;

public class Global : HttpApplication
{
	private IContainer components = null;

	public Global()
	{
		InitializeComponent();
	}

	protected void Application_Start(Object sender, EventArgs e)
	{
    // Creo il ServerSessionManager
    WebEntryPoint.SSManager = new ServerSessionManager();
    //
    // Se l'applicazione ha attivato l'opzione "Start Server Session"
    // faccio partire la Server Session di default
    if (true)
      WebEntryPoint.SSManager.StartSession(new MyWebEntryPoint(HttpContext.Current), "Notificatore", "§");
    //
    // Imposto la password per la comunicazione
    WebEntryPoint.set_ComPassword("56F7BA79-BFDE-466C-9ED7-6AB3DC3730D8");
  }

	protected void Session_Start(Object sender, EventArgs e)
	{
    lock (WebEntryPoint.Sessions)
    {
      // Se non c'è già
      if (!WebEntryPoint.Sessions.Contains(Session.SessionID))
        WebEntryPoint.Sessions.Add(Session.SessionID, Session);
    }
	}

	protected void Application_BeginRequest(Object sender, EventArgs e)
	{

  }

	protected void Application_EndRequest(Object sender, EventArgs e)
	{

  }

	protected void Application_AuthenticateRequest(Object sender, EventArgs e)
	{

	}

	protected void Application_Error(Object sender, EventArgs e)
	{

	}

	protected void Session_End(Object sender, EventArgs e)
	{
    TraceManager tm = null;
    lock (Application)
    {
      tm = (TraceManager)Application.Get("$TraceManager$");
    }
    if (tm != null)
      tm.EndSession(Session.SessionID);
    //
    try
    {
      MyWebEntryPoint wep = (MyWebEntryPoint)Session["WEP"];
      if (wep != null)
        wep._WebEntryPoint();
    }
    catch (Exception) { }
    //
    try
    {
      lock (WebEntryPoint.Sessions)
      {
        WebEntryPoint.Sessions.Remove(Session.SessionID);
      }
    }
    catch (Exception) { }
	}

	protected void Application_End(Object sender, EventArgs e)
	{
    // Termito "brutalmente" tutte le eventuali sessioni in corso
    WebEntryPoint.SSManager.Terminate();
    //
    // Informo tutte le sessioni che l'applicazione è morta
    lock (WebEntryPoint.Sessions)
    {
      try
      {
        IEnumerator pos = WebEntryPoint.Sessions.Keys.GetEnumerator();
        while (pos.MoveNext())
        {
          String sid = (String)pos.Current;
          HttpSessionState Sess = (HttpSessionState)WebEntryPoint.Sessions[sid];
          try
          {
            MyWebEntryPoint wep = (MyWebEntryPoint)Sess["WEP"];
            if (wep != null)
              wep._WebEntryPoint();
          }
          catch (Exception) {}
        }
      }
      catch (Exception) {}
    }
	}
		
	#region Web Form Designer generated code
	private void InitializeComponent()
	{    
		this.components = new Container();
	}
	#endregion
}
