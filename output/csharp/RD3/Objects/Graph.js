// ************************************************
// Instant Developer RD3 Framework
// (c) 1999-2009 Pro Gamma Srl - All rights reserved
//
// Classe Panel: Rappresenta un frame di tipo
// Grafico
// ************************************************

function Graph(pform)
{
  // Chiamo il costruttore superiore
  WebFrame.call(this,pform); 
  //
	// Proprieta' di questo oggetto di modello
  this.Library = -1;          // Libreria relativa al grafico
  this.File = "";             // Nome del file immagine o xml del grafico
  this.Codice = "";           // Nome della mappa (attributo dell'immagine)
  this.Map = "";              // Mappa html per grafici JFreeChart attivi
  this.SwfFile = "";          // Nome del file swf da usare per il grafico FusionChart
  this.ImageWidth = 0;        // Dimensione dell'immagine
  this.ImageHeight = 0;       // Dimensione dell'immagine
  this.ErrText = "";          // Testo da presentare all'utente nel caso di errore nelle librerie J#
  //
  // Variabili accessorie di questo oggetto
  this.RefreshSWF = false;    // True se bisogna rinfrescare la stringa html del flash
	//
  // Struttura per la definizione degli eventi di questo pannello
  this.ClickEventDef = RD3_Glb.EVENT_ACTIVE; // Click su un punto del grafico
	//
	// Oggetti DOM di questo grafico
	this.Img = null;            // Immagine del grafico JFreeChart
	this.MapObj = null;         // Mappa per un grafico JFreeChart attivo
	this.ObjectSwf = null;      // Oggetto flash per FusionChart
}
//
// Definisco l'estensione della classe
Graph.prototype = new WebFrame();



// *******************************************************************
// Inizializza questo Tree leggendo i dati da un nodo XML
// *******************************************************************
Graph.prototype.LoadFromXml = function(node) 
{
	// Chiamo la classe base
	WebFrame.prototype.LoadFromXml.call(this,node);
}


// **************************************************************
// Inizializza le proprieta' di questo oggetto leggendole dal
// nodo xml arrivato.
// **************************************************************
Graph.prototype.LoadProperties = function(node)
{
	// Chiamo la classe base
	WebFrame.prototype.LoadProperties.call(this,node);
	//
  // Ciclo su tutti gli attributi del nodo
  var attrlist = node.attributes;
  var n = attrlist.length;
  for (var i=0; i<n; i++)
  {
    var attrnode = attrlist.item(i);
    var nome = attrnode.nodeName;
    var valore = attrnode.nodeValue;
    //
    switch(nome)
    {
    	case "lib": this.SetLibrary(valore); break;
    	case "fil": this.SetFileName(valore); break;
    	case "cod": this.SetCodice(valore); break;
    	case "map": this.SetMap(valore); break;
    	case "swf": this.SetFlashFileName(valore); break;
    	case "gwi": this.SetGraphWidth(parseInt(valore)); break;
    	case "ghe": this.SetGraphHeight(parseInt(valore)); break;
    	case "ger": this.SetGraphErrText(valore); break;
    	
    	case "clk": this.ClickEventDef = parseInt(valore); break;

    	case "sha": this.ShowAnimDef = valore; break;
    	
    	case "id": 
    		this.Identifier = valore;
    		RD3_DesktopManager.ObjectMap.add(valore, this);
    	break;
    }
  }
}


// **********************************************************************
// Esegue un evento di change che riguarda le proprieta' di questo oggetto
// **********************************************************************
Graph.prototype.ChangeProperties = function(node)
{
	// Eseguo il cambio di proprieta'
	this.LoadProperties(node);
}


// ******************************************************************
// Setter delle proprieta'
// ******************************************************************
Graph.prototype.SetLibrary= function(value) 
{
	if (value!=undefined)
		this.Library = value;
	//
	if (this.Realized)
	{
		if (this.Library == RD3_Glb.JFREECHART)
		{
		  // Mostro l'immagine e nascondo il flash
		  this.Img.style.display = "";
		  this.MapObj.style.display = "none";
		  this.ObjectSwf.style.display = "none";
		  //
		  // Se ero JQPlot allora devo rimettere a posto gli oggetti: per prima cosa distruggo JQPlot, poi rimetto a posto l'immagine..
		  if (this.Img.tagName=="DIV")
		  {
		    this.RemoveJQPlot();
		    //
        this.ContentBox.removeChild(this.Img);
		    //
		    this.Img = document.createElement("img");
      	this.Img.className = "graph-img";
      	this.ContentBox.appendChild(this.Img);
		  }
		}
		//
		if (this.Library == RD3_Glb.FUSIONCHART)
		{
		  // Mostro il flash e nascondo l'immagine
		  this.ObjectSwf.style.display = "";  
		  this.Img.style.display = "none";
		  this.MapObj.style.display = "none";
		}
		//
		if (this.Library == RD3_Glb.JQPLOT)
		{
		   // Nascondo il flash
		  this.MapObj.style.display = "none";
		  this.ObjectSwf.style.display = "none";  
		  //
		  // Sostituisco l'immagine con un DIV
      if (this.Img)
        this.ContentBox.removeChild(this.Img);
      //
      // Creo l'oggetto su cui verra' disegnato il grafico
  	  this.Img = document.createElement("div");
  	  this.Img.setAttribute("id", this.Identifier+":chartDiv");
  	  this.Img.style.overflow = "hidden"; 
    	this.ContentBox.appendChild(this.Img);
		}
	}
}

Graph.prototype.SetFileName= function(value) 
{
	if (value!=undefined)	
		this.File = value;
	//
	if (this.Realized)
	{
	  if (this.Library == RD3_Glb.JFREECHART)
	  {
	    // Nascondo il Flash
	    this.ObjectSwf.style.display = "none";
	    //
	    if (RD3_Glb.IsTouch())
	   	{
	   		// Nei dispositivi touch non uso animazione, per ora
	   		this.Img.src = this.File;
	   	}
	    else
	    {
		    // Animazione di cambio grafico
	    	var fx = new GFX("graph", this.File=="" ? false : true, this, false, null, this.ShowAnimDef);
      	RD3_GFXManager.AddEffect(fx);
      }
	  }
  	else if (this.Library == RD3_Glb.JQPLOT)
  	{
  	  // Se esiste gia' un grafico JQPLOT allora lo posso sostituire, se non c'e' verra' creato dall'AdaptLayout
  	  // (il Div deve essere dimensionato per poter disegnare un grafico)
  	  if (RD3_Glb.HasClass(this.Img, "jqplot-target"))
  	    this.EmbedJQPlot();
  	  else
  	    this.RecalcLayout = true;
  	}
    else
  	{
	    // Nascondo l'immagine
	    this.Img.style.display = "none";
	    //
  		this.ObjectSwf.style.visibility = (this.File=="")? "hidden":"";
  		//
  		// In IE il rinfrescamento alla fine non funziona, quindi lo faccio adesso, negli altri lo faccio come ultima cosa
  		if (RD3_Glb.IsIE())
  		  this.ObjectSwf.innerHTML = this.GetEmbedString();
  		else
  		  this.RefreshSWF = true;
	  }	  
	}
}

Graph.prototype.SetGraphErrText= function(value) 
{
  this.ErrText = value;
  //
  if (this.Realized)
  {
    // Sostituisco l'immagine con un DIV contenente il testo di errore ricevuto dal server
    if (this.Img)
      this.ContentBox.removeChild(this.Img);
    //
	  this.Img = document.createElement("div");
  	this.Img.className = "graph-img-err";
	  this.Img.innerHTML = value;
  	this.ContentBox.appendChild(this.Img);
  }
}

Graph.prototype.SetCodice= function(value) 
{
	if (value!=undefined)
		this.Codice = value;
	//
	if (this.Realized)
	{
		this.Img.useMap = "#" + this.Codice;
	}
}

Graph.prototype.SetMap= function(value) 
{
 	if (value!=undefined)
		this.Map = value;
	//
	if (this.Realized)
	{
		this.MapObj.innerHTML = this.Map;
		this.MapObj.style.visibility = "hidden";
	}
}

Graph.prototype.SetFlashFileName= function(value) 
{
	if (value!=undefined)
		this.SwfFile = value;
	//
	if (this.Realized)
	{
	  // In IE il rinfrescamento alla fine non funziona, quindi lo faccio adesso, negli altri lo faccio come ultima cosa
		if (RD3_Glb.IsIE())
		  this.ObjectSwf.innerHTML = this.GetEmbedString();
		else
		  this.RefreshSWF = true;
	}
}

Graph.prototype.SetGraphWidth= function(value) 
{
	if (value!=undefined)
		this.ImageWidth = value;
	//
	if (this.Realized)
	{
	  this.Img.style.width = this.ImageWidth + "px";
	  //
	  if (this.ObjectSwf.innerHTML == "")
    {
	    this.ObjectSwf.innerHTML = this.GetEmbedString();
	  }
	  else
	  {
	    var nw = (this.ImageWidth-2);
	    if (nw<0) nw=0;
	    this.ObjectSwf.childNodes[0].style.width = nw + "px";
	  }
	}
}

Graph.prototype.SetGraphHeight= function(value) 
{
	if (value!=undefined)
		this.ImageHeight = value;
	//
	if (this.Realized)
	{
	  // IE 8 farebbe a meno del -1 ma IE7 no...
	  this.Img.style.height = (this.ImageHeight>0 ? (this.ImageHeight-1) : 0 ) + "px";
		//
	  if (this.ObjectSwf.innerHTML == "")
    {
      this.ObjectSwf.innerHTML = this.GetEmbedString();
    }
    else
    {
	    var nh = (this.ImageHeight-2);
	    if (nh<0) nh=0;
      this.ObjectSwf.childNodes[0].style.height = nh + "px";
    }
	}
}


// ***************************************************************
// Crea gli oggetti DOM utili a questo oggetto
// L'oggetto parent indica all'oggetto dove devono essere contenuti
// i suoi oggetti figli nel DOM
// ***************************************************************
Graph.prototype.Realize = function(parent)
{
  // Chiamo la classe base
	if (!this.Realized)
		WebFrame.prototype.Realize.call(this,parent);
	//
	// Creo gli oggetti del DOM
	this.Img = document.createElement("img");
	this.MapObj = document.createElement("span");
	this.MapObj.style.visibility = "hidden";
	//
	this.ObjectSwf = document.createElement("span");
	//
	// Assegno le classi agli oggetti
	this.Img.className = "graph-img";
	this.MapObj.className = "graph-img";
	this.ObjectSwf.className = "graph-flash";
	//
	// Aggiungo gli elementi al DOM
	this.ContentBox.appendChild(this.Img);
	this.ContentBox.appendChild(this.MapObj);
	this.ContentBox.appendChild(this.ObjectSwf);
	//
	this.Realized = true;
	//
	// Inizializzazione
	this.SetLibrary();
	this.SetFileName();
	this.SetCodice();
	this.SetMap();
	this.SetWidth();
	this.SetHeight();
	this.SetFlashFileName();
}


// ********************************************************************************
// Calcola le dimensioni dei div in base alla dimensione del contenuto
// ********************************************************************************
Graph.prototype.AdaptLayout = function()
{ 
	// Chiamo la classe base
	WebFrame.prototype.AdaptLayout.call(this);
	//
	// Imposto le dimensioni dell'immagine in modo che ci stia...
	var oldWidth = this.ImageWidth;
	var oldHeight = this.ImageHeight;
	this.SetGraphWidth(this.ContentBox.clientWidth);
	this.SetGraphHeight(this.ContentBox.clientHeight);
	//
	// Lo devo fare ora perche' JQPlot ha bisogno che il DIV abbia le dimensioni gia' impostate
	// Se le dimensioni sono cambiate devo far riaggiornare JQPlot
	var UpdateJQPlot = oldWidth != this.ImageWidth || oldHeight != this.ImageHeight;
	//
	// Devo far aggiornare JQPlot se sono nella libreria giusta, ho un file ma non ho mai creato l'oggetto JQPlot
	UpdateJQPlot = UpdateJQPlot || (this.Library == RD3_Glb.JQPLOT && this.File!="" && !RD3_Glb.HasClass(this.Img, "jqplot-target"));
	//
	if (UpdateJQPlot)
	  this.EmbedJQPlot();
}


// ********************************************************************************
// Toglie gli elementi visuali dal DOM perche' questo oggetto sta per essere
// distrutto
// ********************************************************************************
Graph.prototype.Unrealize = function()
{ 
	// Chiamo la classe base
	WebFrame.prototype.Unrealize.call(this);
	//
	// Annullo i miei riferimenti
	this.Img = null;
	this.MapObj = null;
	this.ObjectSwf = null;  
	//
	if (this.Library == RD3_Glb.JQPLOT)
	{
	  if (this.OldPlot)
	    this.OldPlot.destroy();
	}
	//
	this.Realized = false;
}


// ********************************************************************************
// Gestore evento di click su un punto del grafico
// ********************************************************************************
Graph.prototype.OnGraphClick= function(evento, point)
{ 
	if (this.Visible && this.Enabled)
	{
		// Posso lanciare il click!
		var ev = new IDEvent("graclk", this.Identifier, evento, this.ClickEventDef, point);
	}
}


// ********************************************************************************
// Funzione che restituisce la stringa html da embeddare per creare il flash
// ********************************************************************************
Graph.prototype.GetEmbedString = function()
{ 
  if (this.Library != RD3_Glb.FUSIONCHART)
    return "";
  //
  var nw = (this.ImageWidth-2);
  var nh = (this.ImageHeight-2);
  if (nw<0) nw=0;
  if (nh<0) nh=0;
  //
	var embed = "<object type='application/x-shockwave-flash' data='" + this.SwfFile + "' style='width: "+nw+"px; height: "+nh+"px;' id='" + this.Identifier + "' >";
	embed += "<param name='movie' value='" + this.SwfFile + "' />";
	embed += "<param name='FlashVars' value='&dataURL=" + this.File + "' />";
	embed += "<param name='quality' value='high' />";
	embed += "<param name='wmode' value='transparent' /></object>";     // Deve stare sotto agli altri oggetti!
	//
	return embed;
}


// ********************************************************************************
// Il resize deve essere mandato immediatamente al server?
// ********************************************************************************
Graph.prototype.IsResizeImmediate = function()
{
	// Devo ottenere immediatamente la nuova immagine del grafico...
	return true; 
}


// ********************************************************************************
// Devo gestire le variazioni avvenute
// ********************************************************************************
Graph.prototype.AfterProcessResponse= function()
{ 
	// Chiamo la classe base
	WebFrame.prototype.AfterProcessResponse.call(this);
  //
  // Se devo rinfrescare il flash lo faccio adesso
	if (this.RefreshSWF)
	{
	  this.ObjectSwf.innerHTML = this.GetEmbedString();
	  //
	  this.RefreshSWF = false;
  }
}


// *********************************************************
// E' arrivato un click a livello di frame
// *********************************************************
Graph.prototype.OnFrameClick = function(evento, dbl, btn, x, y, xb, yb, tget)
{
	// cerco il punto nella mappa...
	var pointid = "";
	if (tget.tagName=="AREA")
	{
		var url = tget.href;
		var p1 = url.indexOf("'OnGraphClick', null,'");
		if (p1>0)
		{
			var p2 = url.indexOf("'",p1+22);
			if (p2>0)
			{
				pointid = url.substring(p1+22,p2);
			}
		}
	}
	//
	var ev = new IDEvent("rawclk", this.Identifier, evento, dbl?this.MouseDoubleClickEventDef:this.MouseClickEventDef, dbl, btn, Math.floor(xb)+"-"+Math.floor(yb), Math.floor(x)+"-"+Math.floor(y), pointid);
}


// *********************************************************
// Imposta il tooltip
// *********************************************************
Graph.prototype.GetTooltip = function(tip, obj)
{
  return WebFrame.prototype.GetTooltip.call(this, tip, obj);
}


// **********************************************************************
// Questa funzione chiama JQPlot e comunica il DIV in cui renderizzarsi
// **********************************************************************
Graph.prototype.EmbedJQPlot = function()
{
  if (this.Library == RD3_Glb.JQPLOT)
	{
	  this.RemoveJQPlot();
	  //
	  if (this.File != "")
	  {
  	  // I : sono un carattere riservato per JQuery: devo sostituirli con \:
  	  var divName = this.Identifier.replace(new RegExp(":","g"), "\\\\:");
  	  //
  	  eval("this.OldPlot = $.jqplot('" + divName + "\\\\:chartDiv" + "',"+ this.File + ");" );
  	  //
  	  // Se il grafico e' cliccabile aggancio la gestione dell'evento di click
  	  if (this.Enabled)
  	  {
  	    eval("$('#" + divName + "').bind('jqplotDataClick', function (ev, seriesIndex, pointIndex, data) {RD3_DesktopManager.CallEventHandler('"+this.Identifier+"', 'OnGraphClick', null,'S'+((seriesIndex + 1)<=9 ? '0' : '')+(seriesIndex+1)+'I'+(pointIndex+1));});");
        eval("$(document).unload(function() {$('*').unbind(); });");
  	  }	
  	}
	}
}

// **********************************************************************
// Questa funzione elimina JQPlot
// **********************************************************************
Graph.prototype.RemoveJQPlot = function()
{
  if (this.Img == null || this.Img.tagName != "DIV")
    return;
  //
  // Devo usare JQuery per rimuovere il vecchio JQPlot, altrimenti ci sono un casino di meory leak..
  var l = $('#'+this.Identifier.replace(new RegExp(":","g"), "\\:")+"\\:chartDiv *");
  if (l.length>0)
    l.unbind();
  //
  var l = $('#'+this.Identifier.replace(new RegExp(":","g"), "\\:")+"\\:chartDiv");
  if (l.length>0)
    l.empty();
  //
  if (this.OldPlot)
  {
    this.OldPlot.destroy();
    this.OldPlot = null;
  }
}