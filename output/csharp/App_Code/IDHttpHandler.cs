using System;
using System.IO;
using System.Web;
using System.Web.SessionState;
using com.progamma.ids;

public class IDHttpHandler : IHttpHandler, IRequiresSessionState
{
	public bool IsReusable
	{
		get
		{
			return true;
		}
	}

	public void ProcessRequest(HttpContext context)
	{
    // Gestione sessione
    // Prelevo l'oggetto WebEntryPoint legato alla sessione
    MyWebEntryPoint wep = (MyWebEntryPoint)context.Session["WEP"];
    if (wep == null)
    {
      // Se c'è un riavvio schedulato
      lock (WebEntryPoint.Sessions)
      {
        if (WebEntryPoint.ShutDownTime != DateTime.MinValue)
        {
          // Non accetto nuove sessioni e rispondo con una redirect sul file unavailable.htm
          context.Response.Redirect("unavailable.htm", false);
          context.Session.Abandon();
          return;
        }
      }
      //
      // Nuova sessione
      wep = new MyWebEntryPoint(context);
      context.Session["WEP"] = wep;
    }
    //
    TraceManager tm = null;
    lock (context.Application)
    {
      tm = (TraceManager)context.Application.Get("$TraceManager$");
    }
    if (tm != null)
      tm.BeginRequest(context.Session.SessionID, wep);
    //
    // Gestisco richiesta dal wep
    if (wep.Parent() == null) // Se parent = null, la sessione è stata appena attivata!
      wep.SetParent(context);
    wep.HandleRequest(context.Request, context.Response);
    //
    if (tm != null)
      tm.EndRequest(context.Session.SessionID);
  }

  public void log(String msg)
  {
    
  }
}


public class IDHttpHandlerDEL : IHttpHandler
{
	public IDHttpHandlerDEL()
  {
  }
  
  public bool IsReusable
  {
  	get
  	{
  		return true;
  	}
  }
  
  public void ProcessRequest(HttpContext context)
  {
	  // Se riguarda l'interruzione della DelayDlg lo gestisco qui
    HttpRequest req = context.Request;
    //
	  // Recupero il nome del file
    String fn = req.QueryString["FN"];
    if (fn != null && fn.Length > 0)
    {
	    // Vediamo se il nome è valido (solo lettere, numeri)
      bool flValid = true;
      for (int i=0; i<fn.Length; i++)
      {
        if (!((fn[i]>='A' && fn[i]<='Z') || (fn[i]>='0' && fn[i]<='9')))
        {
          flValid = false;
          break;
        }
      }
      //
      // Se è valido ed il file esiste
      fn = req.MapPath("temp/" + fn + ".xml");
      if (flValid && File.Exists(fn))
      {
        // Creo un file di lock... lo eliminerà WebEntryPoint alla prossima TRACKPHASE
        FileStream s = File.Create(fn + ".kill");
        s.Close();
        //
        // Già che ci sono rispondo OK al browser
        context.Response.Write("OK");
      }
    }
  }
}

public class IDHttpHandlerCOM : IHttpHandler
{
  public IDHttpHandlerCOM()
  {
  }

  public bool IsReusable
  {
    get
    {
      return true;
    }
  }

  public void ProcessRequest(HttpContext context)
  {
    WebEntryPoint.HandleComRequest(context);
    //
    // Invalido la sessione utilizzata per la comunicazione
//    context.Session.Abandon();
  }
}
