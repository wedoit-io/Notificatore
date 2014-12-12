//-------------------------------------------------
// Ass 001210-2010
TabbedView.prototype.AdaptLayout = function()
{
  var n = this.Tabs.length;    // Numero di tab
	//	
	if (this.SendResize)
	{
		// Imposto il resize anche delle tabbed contenute
		for (var i=0; i<n; i++)
  	{
  		var t = this.Tabs[i];
  		if (t.Realized && t.Content)
  		{
  			t.Content.SendResize = true;
  			t.Content.DeltaW += this.DeltaW;
  			t.Content.DeltaH += this.DeltaH;
  		}
	  }
	  //
	  //---------------DIFF
	  this.DeltaW = 0;
	  this.DeltaH = 0;
	  //-------------------
	}
	//
	// Azzero la larghezza del filler perche' la riduzione dello spazio disponibile
	// potrebbe far andare a capo "temporaneamente" la toolbar, rubando troppo spazio
	// al contenuto della tabbed.
	this.TabFiller.style.width = "0px";
	//	
	// Chiamo la classe base
  WebFrame.prototype.AdaptLayout.call(this);
  //
  var thinpage = false;         // True se le linguette devono essere piccole per cercare di stare su una sola riga
  var availablew = 0;           // Spazio disponibile
  var usedw;                    // Spazio attualmente occupato
  //
  // Dimensiono il contenitore delle linguette perche' usi tutto lo spazio orizzontale di cui puo' disporre
  // Mostro il contenitore delle linguette, potrebbe essere stato nascosto ma devo mostrarlo perche' se non non da' i valori di dimensione giusti
  this.ToolbarBox.style.display = "";
  availablew = this.ToolbarBox.clientWidth;
  //
  // Adatto tutte le linguette
  var vistabs = 0;
  usedw = 0;
  for (var i=0; i<n; i++)
  {
    // La variabile thinpage mi dice quale dimensione minima usare come larghezza della linguetta
    var w = ((thinpage) ? RD3_ClientParams.TabWidthThin : RD3_ClientParams.TabWidth);
    //
    // Se il tab e' visibile allora dimensiono la sua linguetta
    var t = this.Tabs[i];
    if (t.Content.Visible)
    {
      vistabs++;
      //
      // Se devo usare la dimensione piu' piccola riazzero la larghezza di CaptionBox impostata da questo stesso ciclo
      t.HeaderCont.style.width = "";
      //
      // Se devo imposto la dimensione minima alla linguetta
      if (t.HeaderCont.offsetWidth <= w && t.HeaderCont.offsetWidth > 0)
        t.HeaderCont.style.width = w + "px";
      //
      // Calcolo lo spazio occupato fin'ora
      usedw += t.CaptionBox.offsetWidth;
      //
      // Se ho sforato quella a disposizione per le linguette
      if (usedw > availablew)
      {
        // Se non ho ancora usando la dimensione piccola per le linguette, faccio in modo 
        // che il ciclo riparta con alcune variabili modificate
        if (!thinpage)
        {
          // Resetto l'indice del ciclo per ripassare da tutte le linguette
          // e imposto thinpage per utilizzare la dimensione minima piu' piccola,
          // e azzero anche la dimensione utilizzata
          i = -1;
          thinpage = true;
          usedw = 0;
          continue;
        }
        else  // Ho appena cambiato riga, quindi lo spazio occupato e' solo quello di questa linguetta
        {
          usedw = t.CaptionBox.offsetWidth;
          continue;
        }
      }
    }
  }
  //
  // Ridimensiono il filler dell'ultima riga tenendo anche conto di eventuali errori di dimensionamento
  var w = (availablew - usedw);
  if (w<0) w=0;
  this.TabFiller.style.width = w + "px";
  if (this.TabFiller.offsetWidth > (availablew - usedw))
  {
    w = ((availablew - usedw) - (this.TabFiller.offsetWidth - (availablew - usedw)));
    if (w<0) w=0;
      this.TabFiller.style.width = w + "px";	
  }
  //
  // Firefox, a volte sbaglia... nonostante sia tutto preciso al pixel puo' mandare a capo il filler per 1px
  if (RD3_Glb.IsFirefox() && this.TabFiller.offsetLeft==0)
    this.TabFiller.style.width = (parseInt(this.TabFiller.style.width)-1) + "px";	
	//
	// Chiamo l'AdaptLayout dei miei figli
  var n = this.Tabs.length;
  for (var i=0; i<n; i++)
  {
    this.Tabs[i].AdaptLayout();
  }
  //
  // Nascondo o mostro il contenitore delle linguette se ce ne sono di visibili
  // (vistabs potrebbe essere superiore al numero di tab se sono stati fatti piu' giri di adattamento, ma a me interessa che sia maggiore di 0..)
  this.ToolbarBox.style.display = (vistabs>0 && !this.HiddenTabs) ? "" : "none";
  //
  /*
  // Imposto il Filler per riempire a partire dall'ultima o dalla prima Tab: se ci sono molte tab la toolbarbox va su due righe
  // ma il filler fa il riempimento corretto comunque
  var tabswidth = 0;
  if (this.Placement == RD3_Glb.TABOR_RIGHT || this.Placement == RD3_Glb.TABOR_BOTTOM)
  {
    tabswidth = this.Tabs[0].CaptionBox.offsetLeft;
    this.TabFiller.style.width = tabswidth + "px";   
  }
  if (this.Placement == RD3_Glb.TABOR_TOP || this.Placement == RD3_Glb.TABOR_LEFT)
  {
    tabswidth = this.Tabs[n-1].CaptionBox.offsetLeft + this.Tabs[n-1].CaptionBox.offsetWidth;
    RD3_Glb.AdaptToParent(this.TabFiller, tabswidth, -1);
  }
  */
}


WebFrame.prototype.SaveSize = function()
{ 
  this.SavedWidth = this.Width;
  this.SavedHeight = this.Height;
  //
  //---------------DIFF
  this.SavedDeltaW = this.DeltaW;
  this.SavedDeltaH = this.DeltaH;
  //--------------------
}

WebFrame.prototype.ResetDelta = function()
{ 
  if (this.ChildFrame1 && this.ChildFrame2)
  {
    this.ChildFrame1.ResetDelta();
    this.ChildFrame2.ResetDelta();
  }
  else
  {
    //---------------DIFF
    this.DeltaW = this.SavedDeltaW;
    this.DeltaH = this.SavedDeltaH;
    //-------------------
  }
}

// FINE Ass 001210-2010
//-------------------------------------------------