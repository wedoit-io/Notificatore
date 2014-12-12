// ***************************************************************
// Implementazione Shell in Javascript
// (interfaccia verso la Shell di dispositivi mobile)
// ***************************************************************
function Shell()
{
}

// ********************************************************
// Invia un messaggio alla shell
// ********************************************************
Shell.prototype.SendCmd = function(cmd, params)
{
  var url = self._ShellURL + "?_CMD=" + cmd;
  if (params)
  {
    if (typeof(params) == "string") // Vedi Desktop::HandleShell
      url += "&" + params;
    else
    {
      // Passo i parametri in BASE64
      var keys = Object.keys(params);
      for (var i = 0; i < keys.length; i++)
      {
        var key = keys[i];
        var val = params[key];
        url += "&" + key + "=" + btoa(unescape(encodeURIComponent(val)));
      }
    }
  }
  var xhReq = new XMLHttpRequest();
  xhReq.open("GET", url, false);
  xhReq.send(null);
  //
  return xhReq.responseText;
}

// ***********************************************************************
// Invia al server lo stato dei servizi presenti nella shell
// ***********************************************************************
Shell.prototype.SendInfo = function()
{
  if (this.IsInsideShell())
  {
    return "&ISSHELL=1&VERSION=" + this.Version() + "&HASCAMERA=" + (this.HasCamera() ? "1" : "0") + "&DEVICEID=" + this.DeviceID() + 
           "&DEVICENAME=" + this.DeviceName() + "&SYNCHSRV=" + this.SynchServer();
  }
  else
    return "";
}

// ***********************************************************************
// Torna TRUE se l'applicazione e' in esecuzione all'interno di una shell sul dispositivo
// ***********************************************************************
Shell.prototype.IsInsideShell = function()
{
  return (self._ShellURL != undefined);
}

//***********************************************************************
//Torna 0 se l'applicazione e' eseguita da pacchetto
//   -1 se e' eseguita dentro Caravel
// NULL se e' eseguita fuori shell o non si sa se dentro Caravel
//***********************************************************************
Shell.prototype.IsInsideCaravel = function()
{
  if (this.iIsInsideCaravel === undefined)
  {
    if (this.IsInsideShell())
    {
      switch (parseInt(this.SendCmd("ISINSIDECARAVEL")))
      {
        case 0:  this.iIsInsideCaravel = 0; break;
        case 1:  this.iIsInsideCaravel = -1;  break;
        default: this.iIsInsideCaravel = null; break;
      }
    }
    else
      this.iIsInsideCaravel = null;
  }
  return this.iIsInsideCaravel;
}

// ***********************************************************************
// Torna la versione della shell nativa
// ***********************************************************************
Shell.prototype.Version = function()
{
  if (this.iVersion == undefined) 
    this.iVersion = (this.IsInsideShell() ? this.SendCmd("GETVER") : "");
  return this.iVersion;
}

// ***********************************************************************
// Torna TRUE se il dispositivo possiede una fotocamera
// ***********************************************************************
Shell.prototype.HasCamera = function()
{
  if (this.iHasCamera == undefined) 
    this.iHasCamera = (this.IsInsideShell() && this.SendCmd("HASCAMERA") == "OK");
  return this.iHasCamera;
}

// ***********************************************************************
// Restituisce un GUID che identifica univocamente l'installazione della Shell sul dispositivo
// ***********************************************************************
Shell.prototype.DeviceID = function()
{
  if (this.iDeviceID == undefined)
    this.iDeviceID = (this.IsInsideShell() ? this.SendCmd("GETSETTING", {KEY:"DEVICEID"}) : "");
  return this.iDeviceID;
}

// ***********************************************************************
// Restituisce il nome del dispositivo
// ***********************************************************************
Shell.prototype.DeviceName = function()
{
  if (this.iDeviceName == undefined)
    this.iDeviceName = (this.IsInsideShell() ? this.SendCmd("GETSETTING", {KEY:"DEVICENAME"}) : "");;
  return this.iDeviceName;
}

// ***********************************************************************
// Restituisce l'indirizzo IP utilizzato dal dispositivo
// ***********************************************************************
Shell.prototype.DeviceIP = function()
{
  return (this.IsInsideShell() ? this.SendCmd("GETSETTING", {KEY:"DEVICEIP"}) : "");
}

// ***********************************************************************
// Restituisce l'URL del server di sincronizzazione conosciuto dalla Shell
// ***********************************************************************
Shell.prototype.SynchServer = function()
{
  return (this.IsInsideShell() ? this.SendCmd("GETSETTING", {KEY:"SYNCSRV"}) : "");
}

// ***********************************************************************
// IDVoice
// ***********************************************************************
Shell.prototype.StartListen = function(lang, dettype, rectype)
{
  if (this.IsInsideShell())
		return this.SendCmd("STARTLISTEN", { LANG:lang, DETTYPE:dettype, RECTYPE:rectype });
}
Shell.prototype.StopListen = function()
{
  if (this.IsInsideShell())
		return this.SendCmd("STOPLISTEN");
}
Shell.prototype.Say = function(text, lang, rate)
{
  if (this.IsInsideShell())
		return this.SendCmd("SAY", {TEXT:text, LANG:lang, RATE:rate});
}
