// **********************************************
// Command Handler
// Instant WEB Application: www.progamma.com
// Project : Mobile Manager
// **********************************************
using System;
using System.Reflection;
using com.progamma;
using com.progamma.ids;

// **********************************************
// Command Handler
// **********************************************
[Serializable]
public sealed class MyCmdHandler : CmdHandler
{
  static int CMDS_OFFSET = 0;
  static int CMD_OFFSET = 0;
  static int CMDS_BASEIDX = 0;
  static int CMD_BASEIDX = 0;

  // **********************************************
  // Costruttore
  // **********************************************
  public MyCmdHandler(WebEntryPoint p)
    : base(p)
  {
    //
    CmdSets[MyGlb.CMDS_GENERALE] = new ACommand();
    CmdSets[MyGlb.CMDS_GENERALE].iGuid = "8FB85B23-3AE1-4C43-A67F-99176AF09C8A";
    CmdSets[MyGlb.CMDS_GENERALE].Index = MyGlb.CMDS_GENERALE;
    CmdSets[MyGlb.CMDS_GENERALE].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_GENERALE].SetNumCommands(8);
    CmdSets[MyGlb.CMDS_GENERALE].Caption = "Generale";
    CmdSets[MyGlb.CMDS_GENERALE].ToolTip = "";
    CmdSets[MyGlb.CMDS_GENERALE].Level = 1;
    CmdSets[MyGlb.CMDS_GENERALE].IsMenu = true;
    CmdSets[MyGlb.CMDS_GENERALE].IsToolbar = false;
    CmdSets[MyGlb.CMDS_GENERALE].ShowNames = false;
    CmdSets[MyGlb.CMDS_GENERALE].Code = "GENERALE";
    CmdLin[MyGlb.CMD_CONFIGURAZIO] = new ACommand();
    CmdSets[MyGlb.CMDS_GENERALE].AddCommand(CmdLin[MyGlb.CMD_CONFIGURAZIO]);
    CmdLin[MyGlb.CMD_CONFIGURAZIO].Parent = CmdSets[MyGlb.CMDS_GENERALE];
    CmdLin[MyGlb.CMD_CONFIGURAZIO].iGuid = "3A76E8BE-9A6B-4DA8-8D20-B61A6CBC1862";
    CmdLin[MyGlb.CMD_CONFIGURAZIO].Caption = "Configurazione";
    CmdLin[MyGlb.CMD_CONFIGURAZIO].ToolTip = "";
    CmdLin[MyGlb.CMD_CONFIGURAZIO].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_CONFIGURAZIO].IsMenu = true;
    CmdLin[MyGlb.CMD_CONFIGURAZIO].IsToolbar = false;
    CmdLin[MyGlb.CMD_CONFIGURAZIO].ShowNames = false;
    CmdLin[MyGlb.CMD_CONFIGURAZIO].ToolName = "Configur...";
    CmdLin[MyGlb.CMD_CONFIGURAZIO].UseHilight = false;
    CmdLin[MyGlb.CMD_CONFIGURAZIO].Code = "CONFIGURAZIO";
    CmdLin[MyGlb.CMD_CONFIGURAZIO].Index = MyGlb.CMD_CONFIGURAZIO;
    CmdLin[MyGlb.CMD_CONFIGURAZIO].Level = 2;
    CmdLin[MyGlb.CMD_CONFIGURAZIO].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_LOGS] = new ACommand();
    CmdSets[MyGlb.CMDS_GENERALE].AddCommand(CmdLin[MyGlb.CMD_LOGS]);
    CmdLin[MyGlb.CMD_LOGS].Parent = CmdSets[MyGlb.CMDS_GENERALE];
    CmdLin[MyGlb.CMD_LOGS].iGuid = "6CBD8382-ED37-40E9-876E-5DB745E0A6BE";
    CmdLin[MyGlb.CMD_LOGS].Caption = "Logs";
    CmdLin[MyGlb.CMD_LOGS].ToolTip = "";
    CmdLin[MyGlb.CMD_LOGS].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_LOGS].IsMenu = true;
    CmdLin[MyGlb.CMD_LOGS].IsToolbar = false;
    CmdLin[MyGlb.CMD_LOGS].ShowNames = false;
    CmdLin[MyGlb.CMD_LOGS].ToolName = "Logs";
    CmdLin[MyGlb.CMD_LOGS].UseHilight = false;
    CmdLin[MyGlb.CMD_LOGS].Code = "LOGS";
    CmdLin[MyGlb.CMD_LOGS].Index = MyGlb.CMD_LOGS;
    CmdLin[MyGlb.CMD_LOGS].Level = 2;
    CmdLin[MyGlb.CMD_LOGS].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_LINGUE] = new ACommand();
    CmdSets[MyGlb.CMDS_GENERALE].AddCommand(CmdLin[MyGlb.CMD_LINGUE]);
    CmdLin[MyGlb.CMD_LINGUE].Parent = CmdSets[MyGlb.CMDS_GENERALE];
    CmdLin[MyGlb.CMD_LINGUE].iGuid = "7BB5F861-A3E5-4908-A91D-A5DC9BA50E18";
    CmdLin[MyGlb.CMD_LINGUE].Caption = "Lingue";
    CmdLin[MyGlb.CMD_LINGUE].ToolTip = "";
    CmdLin[MyGlb.CMD_LINGUE].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_LINGUE].IsMenu = true;
    CmdLin[MyGlb.CMD_LINGUE].IsToolbar = false;
    CmdLin[MyGlb.CMD_LINGUE].ShowNames = false;
    CmdLin[MyGlb.CMD_LINGUE].ToolName = "Lingue";
    CmdLin[MyGlb.CMD_LINGUE].UseHilight = false;
    CmdLin[MyGlb.CMD_LINGUE].Code = "LINGUE";
    CmdLin[MyGlb.CMD_LINGUE].Index = MyGlb.CMD_LINGUE;
    CmdLin[MyGlb.CMD_LINGUE].Level = 2;
    CmdLin[MyGlb.CMD_LINGUE].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_SEP1] = new ACommand();
    CmdSets[MyGlb.CMDS_GENERALE].AddCommand(CmdLin[MyGlb.CMD_SEP1]);
    CmdLin[MyGlb.CMD_SEP1].Parent = CmdSets[MyGlb.CMDS_GENERALE];
    CmdLin[MyGlb.CMD_SEP1].iGuid = "B4917053-EFEA-4CAB-BA8A-CC179BA09FAF";
    CmdLin[MyGlb.CMD_SEP1].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_SEP1].IsMenu = true;
    CmdLin[MyGlb.CMD_SEP1].IsToolbar = false;
    CmdLin[MyGlb.CMD_SEP1].ShowNames = false;
    CmdLin[MyGlb.CMD_SEP1].ToolName = "Nuovo";
    CmdLin[MyGlb.CMD_SEP1].UseHilight = false;
    CmdLin[MyGlb.CMD_SEP1].Code = "SEP1";
    CmdLin[MyGlb.CMD_SEP1].Index = MyGlb.CMD_SEP1;
    CmdLin[MyGlb.CMD_SEP1].Level = 2;
    CmdLin[MyGlb.CMD_SEP1].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_APILOCATOR] = new ACommand();
    CmdSets[MyGlb.CMDS_GENERALE].AddCommand(CmdLin[MyGlb.CMD_APILOCATOR]);
    CmdLin[MyGlb.CMD_APILOCATOR].Parent = CmdSets[MyGlb.CMDS_GENERALE];
    CmdLin[MyGlb.CMD_APILOCATOR].iGuid = "3EADA715-7694-4FD9-87AA-7BB5B982781F";
    CmdLin[MyGlb.CMD_APILOCATOR].Caption = "API Locator";
    CmdLin[MyGlb.CMD_APILOCATOR].ToolTip = "";
    CmdLin[MyGlb.CMD_APILOCATOR].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_APILOCATOR].IsMenu = true;
    CmdLin[MyGlb.CMD_APILOCATOR].IsToolbar = false;
    CmdLin[MyGlb.CMD_APILOCATOR].ShowNames = false;
    CmdLin[MyGlb.CMD_APILOCATOR].ToolName = "API";
    CmdLin[MyGlb.CMD_APILOCATOR].UseHilight = false;
    CmdLin[MyGlb.CMD_APILOCATOR].Code = "APILOCATOR";
    CmdLin[MyGlb.CMD_APILOCATOR].Index = MyGlb.CMD_APILOCATOR;
    CmdLin[MyGlb.CMD_APILOCATOR].Level = 2;
    CmdLin[MyGlb.CMD_APILOCATOR].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_PRODOTTI] = new ACommand();
    CmdSets[MyGlb.CMDS_GENERALE].AddCommand(CmdLin[MyGlb.CMD_PRODOTTI]);
    CmdLin[MyGlb.CMD_PRODOTTI].Parent = CmdSets[MyGlb.CMDS_GENERALE];
    CmdLin[MyGlb.CMD_PRODOTTI].iGuid = "C7DC6830-5BC8-40DA-89A7-A6FE986CACBA";
    CmdLin[MyGlb.CMD_PRODOTTI].Caption = "Prodotti";
    CmdLin[MyGlb.CMD_PRODOTTI].ToolTip = "";
    CmdLin[MyGlb.CMD_PRODOTTI].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_PRODOTTI].IsMenu = true;
    CmdLin[MyGlb.CMD_PRODOTTI].IsToolbar = false;
    CmdLin[MyGlb.CMD_PRODOTTI].ShowNames = false;
    CmdLin[MyGlb.CMD_PRODOTTI].ToolName = "Prodotti";
    CmdLin[MyGlb.CMD_PRODOTTI].UseHilight = false;
    CmdLin[MyGlb.CMD_PRODOTTI].Code = "PRODOTTI";
    CmdLin[MyGlb.CMD_PRODOTTI].Index = MyGlb.CMD_PRODOTTI;
    CmdLin[MyGlb.CMD_PRODOTTI].Level = 2;
    CmdLin[MyGlb.CMD_PRODOTTI].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_APPLICAZIONI] = new ACommand();
    CmdSets[MyGlb.CMDS_GENERALE].AddCommand(CmdLin[MyGlb.CMD_APPLICAZIONI]);
    CmdLin[MyGlb.CMD_APPLICAZIONI].Parent = CmdSets[MyGlb.CMDS_GENERALE];
    CmdLin[MyGlb.CMD_APPLICAZIONI].iGuid = "0F17D5BF-36A6-429B-94A0-6DC61E7904ED";
    CmdLin[MyGlb.CMD_APPLICAZIONI].Caption = "Applicazioni";
    CmdLin[MyGlb.CMD_APPLICAZIONI].ToolTip = "";
    CmdLin[MyGlb.CMD_APPLICAZIONI].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_APPLICAZIONI].IsMenu = true;
    CmdLin[MyGlb.CMD_APPLICAZIONI].IsToolbar = false;
    CmdLin[MyGlb.CMD_APPLICAZIONI].ShowNames = false;
    CmdLin[MyGlb.CMD_APPLICAZIONI].ToolName = "Applicaz...";
    CmdLin[MyGlb.CMD_APPLICAZIONI].UseHilight = false;
    CmdLin[MyGlb.CMD_APPLICAZIONI].Code = "APPLICAZIONI";
    CmdLin[MyGlb.CMD_APPLICAZIONI].Index = MyGlb.CMD_APPLICAZIONI;
    CmdLin[MyGlb.CMD_APPLICAZIONI].Level = 2;
    CmdLin[MyGlb.CMD_APPLICAZIONI].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_DISPOSITNOTI] = new ACommand();
    CmdSets[MyGlb.CMDS_GENERALE].AddCommand(CmdLin[MyGlb.CMD_DISPOSITNOTI]);
    CmdLin[MyGlb.CMD_DISPOSITNOTI].Parent = CmdSets[MyGlb.CMDS_GENERALE];
    CmdLin[MyGlb.CMD_DISPOSITNOTI].iGuid = "9E3F7DE4-E8EC-423D-B8A9-840FC1984320";
    CmdLin[MyGlb.CMD_DISPOSITNOTI].Caption = "Dispositivi Noti";
    CmdLin[MyGlb.CMD_DISPOSITNOTI].ToolTip = "";
    CmdLin[MyGlb.CMD_DISPOSITNOTI].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_DISPOSITNOTI].IsMenu = true;
    CmdLin[MyGlb.CMD_DISPOSITNOTI].IsToolbar = false;
    CmdLin[MyGlb.CMD_DISPOSITNOTI].ShowNames = false;
    CmdLin[MyGlb.CMD_DISPOSITNOTI].ToolName = "Disposit...";
    CmdLin[MyGlb.CMD_DISPOSITNOTI].UseHilight = false;
    CmdLin[MyGlb.CMD_DISPOSITNOTI].Code = "DISPOSITNOTI";
    CmdLin[MyGlb.CMD_DISPOSITNOTI].Index = MyGlb.CMD_DISPOSITNOTI;
    CmdLin[MyGlb.CMD_DISPOSITNOTI].Level = 2;
    CmdLin[MyGlb.CMD_DISPOSITNOTI].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_IOS] = new ACommand();
    CmdSets[MyGlb.CMDS_IOS].iGuid = "91590DDD-D3B0-4DC0-AFD7-3B6D53CA3201";
    CmdSets[MyGlb.CMDS_IOS].Index = MyGlb.CMDS_IOS;
    CmdSets[MyGlb.CMDS_IOS].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_IOS].SetNumCommands(4);
    CmdSets[MyGlb.CMDS_IOS].Caption = "iOS";
    CmdSets[MyGlb.CMDS_IOS].ToolTip = "";
    CmdSets[MyGlb.CMDS_IOS].Level = 1;
    CmdSets[MyGlb.CMDS_IOS].IsMenu = true;
    CmdSets[MyGlb.CMDS_IOS].IsToolbar = false;
    CmdSets[MyGlb.CMDS_IOS].ShowNames = false;
    CmdSets[MyGlb.CMDS_IOS].Code = "IOS";
    CmdLin[MyGlb.CMD_IMPOSTAZION2] = new ACommand();
    CmdSets[MyGlb.CMDS_IOS].AddCommand(CmdLin[MyGlb.CMD_IMPOSTAZION2]);
    CmdLin[MyGlb.CMD_IMPOSTAZION2].Parent = CmdSets[MyGlb.CMDS_IOS];
    CmdLin[MyGlb.CMD_IMPOSTAZION2].iGuid = "D3566B1D-F4D7-4EFC-9BA0-5238E4B6911D";
    CmdLin[MyGlb.CMD_IMPOSTAZION2].Caption = "Impostazioni";
    CmdLin[MyGlb.CMD_IMPOSTAZION2].ToolTip = "";
    CmdLin[MyGlb.CMD_IMPOSTAZION2].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_IMPOSTAZION2].IsMenu = true;
    CmdLin[MyGlb.CMD_IMPOSTAZION2].IsToolbar = false;
    CmdLin[MyGlb.CMD_IMPOSTAZION2].ShowNames = false;
    CmdLin[MyGlb.CMD_IMPOSTAZION2].ToolName = "Impostaz...";
    CmdLin[MyGlb.CMD_IMPOSTAZION2].UseHilight = false;
    CmdLin[MyGlb.CMD_IMPOSTAZION2].Code = "IMPOSTAZION2";
    CmdLin[MyGlb.CMD_IMPOSTAZION2].Index = MyGlb.CMD_IMPOSTAZION2;
    CmdLin[MyGlb.CMD_IMPOSTAZION2].Level = 2;
    CmdLin[MyGlb.CMD_IMPOSTAZION2].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_DEVICETOKENS] = new ACommand();
    CmdSets[MyGlb.CMDS_IOS].AddCommand(CmdLin[MyGlb.CMD_DEVICETOKENS]);
    CmdLin[MyGlb.CMD_DEVICETOKENS].Parent = CmdSets[MyGlb.CMDS_IOS];
    CmdLin[MyGlb.CMD_DEVICETOKENS].iGuid = "296FC695-00B8-480E-939C-8C173478D877";
    CmdLin[MyGlb.CMD_DEVICETOKENS].Caption = "Device Tokens";
    CmdLin[MyGlb.CMD_DEVICETOKENS].ToolTip = "";
    CmdLin[MyGlb.CMD_DEVICETOKENS].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_DEVICETOKENS].IsMenu = true;
    CmdLin[MyGlb.CMD_DEVICETOKENS].IsToolbar = false;
    CmdLin[MyGlb.CMD_DEVICETOKENS].ShowNames = false;
    CmdLin[MyGlb.CMD_DEVICETOKENS].ToolName = "Device";
    CmdLin[MyGlb.CMD_DEVICETOKENS].UseHilight = false;
    CmdLin[MyGlb.CMD_DEVICETOKENS].Code = "DEVICETOKENS";
    CmdLin[MyGlb.CMD_DEVICETOKENS].Index = MyGlb.CMD_DEVICETOKENS;
    CmdLin[MyGlb.CMD_DEVICETOKENS].Level = 2;
    CmdLin[MyGlb.CMD_DEVICETOKENS].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_SPEDIZIONI1] = new ACommand();
    CmdSets[MyGlb.CMDS_IOS].AddCommand(CmdLin[MyGlb.CMD_SPEDIZIONI1]);
    CmdLin[MyGlb.CMD_SPEDIZIONI1].Parent = CmdSets[MyGlb.CMDS_IOS];
    CmdLin[MyGlb.CMD_SPEDIZIONI1].iGuid = "8F9475C4-8028-44BF-A539-63907CAF8E79";
    CmdLin[MyGlb.CMD_SPEDIZIONI1].Caption = "Spedizioni";
    CmdLin[MyGlb.CMD_SPEDIZIONI1].ToolTip = "";
    CmdLin[MyGlb.CMD_SPEDIZIONI1].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI1].IsMenu = true;
    CmdLin[MyGlb.CMD_SPEDIZIONI1].IsToolbar = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI1].ShowNames = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI1].ToolName = "Spedizioni";
    CmdLin[MyGlb.CMD_SPEDIZIONI1].UseHilight = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI1].Code = "SPEDIZIONI1";
    CmdLin[MyGlb.CMD_SPEDIZIONI1].Index = MyGlb.CMD_SPEDIZIONI1;
    CmdLin[MyGlb.CMD_SPEDIZIONI1].Level = 2;
    CmdLin[MyGlb.CMD_SPEDIZIONI1].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_SALESDATA1] = new ACommand();
    CmdLin[MyGlb.CMD_SALESDATA1].iGuid = "E9069E73-6699-4260-BA5A-51BD7D3FED20";
    CmdLin[MyGlb.CMD_SALESDATA1].Index = MyGlb.CMD_SALESDATA1;
    CmdLin[MyGlb.CMD_SALESDATA1].InitStatus(true, false, false);
    CmdLin[MyGlb.CMD_SALESDATA1].SetNumCommands(8);
    CmdSets[MyGlb.CMDS_IOS].AddCommand(CmdLin[MyGlb.CMD_SALESDATA1]);
    CmdLin[MyGlb.CMD_SALESDATA1].Parent = CmdSets[MyGlb.CMDS_IOS];
    CmdLin[MyGlb.CMD_SALESDATA1].Caption = "Sales Data";
    CmdLin[MyGlb.CMD_SALESDATA1].ToolTip = "";
    CmdLin[MyGlb.CMD_SALESDATA1].Level = 2;
    CmdLin[MyGlb.CMD_SALESDATA1].IsMenu = true;
    CmdLin[MyGlb.CMD_SALESDATA1].IsToolbar = false;
    CmdLin[MyGlb.CMD_SALESDATA1].ShowNames = false;
    CmdLin[MyGlb.CMD_SALESDATA1].Code = "SALESDATA1";
    CmdLin[MyGlb.CMD_CURRENCIES] = new ACommand();
    CmdLin[MyGlb.CMD_SALESDATA1].AddCommand(CmdLin[MyGlb.CMD_CURRENCIES]);
    CmdLin[MyGlb.CMD_CURRENCIES].Parent = CmdLin[MyGlb.CMD_SALESDATA1];
    CmdLin[MyGlb.CMD_CURRENCIES].iGuid = "1F1B5E65-8B09-400C-85EE-7AC2A80A7ABD";
    CmdLin[MyGlb.CMD_CURRENCIES].Caption = "Currencies";
    CmdLin[MyGlb.CMD_CURRENCIES].ToolTip = "";
    CmdLin[MyGlb.CMD_CURRENCIES].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_CURRENCIES].IsMenu = true;
    CmdLin[MyGlb.CMD_CURRENCIES].IsToolbar = false;
    CmdLin[MyGlb.CMD_CURRENCIES].ShowNames = false;
    CmdLin[MyGlb.CMD_CURRENCIES].ToolName = "Currencies";
    CmdLin[MyGlb.CMD_CURRENCIES].UseHilight = false;
    CmdLin[MyGlb.CMD_CURRENCIES].Code = "CURRENCIES";
    CmdLin[MyGlb.CMD_CURRENCIES].Index = MyGlb.CMD_CURRENCIES;
    CmdLin[MyGlb.CMD_CURRENCIES].Level = 3;
    CmdLin[MyGlb.CMD_CURRENCIES].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_PROMOCODES] = new ACommand();
    CmdLin[MyGlb.CMD_SALESDATA1].AddCommand(CmdLin[MyGlb.CMD_PROMOCODES]);
    CmdLin[MyGlb.CMD_PROMOCODES].Parent = CmdLin[MyGlb.CMD_SALESDATA1];
    CmdLin[MyGlb.CMD_PROMOCODES].iGuid = "6CD6904F-3A8A-4240-AC32-9D82814E4AE2";
    CmdLin[MyGlb.CMD_PROMOCODES].Caption = "Promo Codes";
    CmdLin[MyGlb.CMD_PROMOCODES].ToolTip = "";
    CmdLin[MyGlb.CMD_PROMOCODES].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_PROMOCODES].IsMenu = true;
    CmdLin[MyGlb.CMD_PROMOCODES].IsToolbar = false;
    CmdLin[MyGlb.CMD_PROMOCODES].ShowNames = false;
    CmdLin[MyGlb.CMD_PROMOCODES].ToolName = "Promo";
    CmdLin[MyGlb.CMD_PROMOCODES].UseHilight = false;
    CmdLin[MyGlb.CMD_PROMOCODES].Code = "PROMOCODES";
    CmdLin[MyGlb.CMD_PROMOCODES].Index = MyGlb.CMD_PROMOCODES;
    CmdLin[MyGlb.CMD_PROMOCODES].Level = 3;
    CmdLin[MyGlb.CMD_PROMOCODES].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_COUNTRYCODES] = new ACommand();
    CmdLin[MyGlb.CMD_SALESDATA1].AddCommand(CmdLin[MyGlb.CMD_COUNTRYCODES]);
    CmdLin[MyGlb.CMD_COUNTRYCODES].Parent = CmdLin[MyGlb.CMD_SALESDATA1];
    CmdLin[MyGlb.CMD_COUNTRYCODES].iGuid = "DFD10228-D322-4D4D-9E4D-4B7A2AC59861";
    CmdLin[MyGlb.CMD_COUNTRYCODES].Caption = "Country Codes";
    CmdLin[MyGlb.CMD_COUNTRYCODES].ToolTip = "";
    CmdLin[MyGlb.CMD_COUNTRYCODES].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_COUNTRYCODES].IsMenu = true;
    CmdLin[MyGlb.CMD_COUNTRYCODES].IsToolbar = false;
    CmdLin[MyGlb.CMD_COUNTRYCODES].ShowNames = false;
    CmdLin[MyGlb.CMD_COUNTRYCODES].ToolName = "Country";
    CmdLin[MyGlb.CMD_COUNTRYCODES].UseHilight = false;
    CmdLin[MyGlb.CMD_COUNTRYCODES].Code = "COUNTRYCODES";
    CmdLin[MyGlb.CMD_COUNTRYCODES].Index = MyGlb.CMD_COUNTRYCODES;
    CmdLin[MyGlb.CMD_COUNTRYCODES].Level = 3;
    CmdLin[MyGlb.CMD_COUNTRYCODES].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_PRODTYPEIDEN] = new ACommand();
    CmdLin[MyGlb.CMD_SALESDATA1].AddCommand(CmdLin[MyGlb.CMD_PRODTYPEIDEN]);
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].Parent = CmdLin[MyGlb.CMD_SALESDATA1];
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].iGuid = "28A6C008-21FE-48EC-BCA0-34824810FBD1";
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].Caption = "Product Type Identifiers";
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].ToolTip = "";
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].IsMenu = true;
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].IsToolbar = false;
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].ShowNames = false;
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].ToolName = "Product";
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].UseHilight = false;
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].Code = "PRODTYPEIDEN";
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].Index = MyGlb.CMD_PRODTYPEIDEN;
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].Level = 3;
    CmdLin[MyGlb.CMD_PRODTYPEIDEN].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_FISCALCALEND] = new ACommand();
    CmdLin[MyGlb.CMD_SALESDATA1].AddCommand(CmdLin[MyGlb.CMD_FISCALCALEND]);
    CmdLin[MyGlb.CMD_FISCALCALEND].Parent = CmdLin[MyGlb.CMD_SALESDATA1];
    CmdLin[MyGlb.CMD_FISCALCALEND].iGuid = "5E1F5312-000C-43C6-BECD-593AC570826F";
    CmdLin[MyGlb.CMD_FISCALCALEND].Caption = "Fiscal Calendar";
    CmdLin[MyGlb.CMD_FISCALCALEND].ToolTip = "";
    CmdLin[MyGlb.CMD_FISCALCALEND].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_FISCALCALEND].IsMenu = true;
    CmdLin[MyGlb.CMD_FISCALCALEND].IsToolbar = false;
    CmdLin[MyGlb.CMD_FISCALCALEND].ShowNames = false;
    CmdLin[MyGlb.CMD_FISCALCALEND].ToolName = "Fiscal";
    CmdLin[MyGlb.CMD_FISCALCALEND].UseHilight = false;
    CmdLin[MyGlb.CMD_FISCALCALEND].Code = "FISCALCALEND";
    CmdLin[MyGlb.CMD_FISCALCALEND].Index = MyGlb.CMD_FISCALCALEND;
    CmdLin[MyGlb.CMD_FISCALCALEND].Level = 3;
    CmdLin[MyGlb.CMD_FISCALCALEND].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_SEP2] = new ACommand();
    CmdLin[MyGlb.CMD_SALESDATA1].AddCommand(CmdLin[MyGlb.CMD_SEP2]);
    CmdLin[MyGlb.CMD_SEP2].Parent = CmdLin[MyGlb.CMD_SALESDATA1];
    CmdLin[MyGlb.CMD_SEP2].iGuid = "5E393B39-2FBC-47BA-BA89-56526831C3A0";
    CmdLin[MyGlb.CMD_SEP2].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_SEP2].IsMenu = true;
    CmdLin[MyGlb.CMD_SEP2].IsToolbar = false;
    CmdLin[MyGlb.CMD_SEP2].ShowNames = false;
    CmdLin[MyGlb.CMD_SEP2].ToolName = "Nuovo";
    CmdLin[MyGlb.CMD_SEP2].UseHilight = false;
    CmdLin[MyGlb.CMD_SEP2].Code = "SEP2";
    CmdLin[MyGlb.CMD_SEP2].Index = MyGlb.CMD_SEP2;
    CmdLin[MyGlb.CMD_SEP2].Level = 3;
    CmdLin[MyGlb.CMD_SEP2].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_SALESDATA] = new ACommand();
    CmdLin[MyGlb.CMD_SALESDATA1].AddCommand(CmdLin[MyGlb.CMD_SALESDATA]);
    CmdLin[MyGlb.CMD_SALESDATA].Parent = CmdLin[MyGlb.CMD_SALESDATA1];
    CmdLin[MyGlb.CMD_SALESDATA].iGuid = "7FFA7CE6-E6E9-4381-B99D-1EC8CCFCD3F9";
    CmdLin[MyGlb.CMD_SALESDATA].Caption = "Sales Data";
    CmdLin[MyGlb.CMD_SALESDATA].ToolTip = "";
    CmdLin[MyGlb.CMD_SALESDATA].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_SALESDATA].IsMenu = true;
    CmdLin[MyGlb.CMD_SALESDATA].IsToolbar = false;
    CmdLin[MyGlb.CMD_SALESDATA].ShowNames = false;
    CmdLin[MyGlb.CMD_SALESDATA].ToolName = "Sales Data";
    CmdLin[MyGlb.CMD_SALESDATA].UseHilight = false;
    CmdLin[MyGlb.CMD_SALESDATA].Code = "SALESDATA";
    CmdLin[MyGlb.CMD_SALESDATA].Index = MyGlb.CMD_SALESDATA;
    CmdLin[MyGlb.CMD_SALESDATA].Level = 3;
    CmdLin[MyGlb.CMD_SALESDATA].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_GRAFICANDAME] = new ACommand();
    CmdLin[MyGlb.CMD_SALESDATA1].AddCommand(CmdLin[MyGlb.CMD_GRAFICANDAME]);
    CmdLin[MyGlb.CMD_GRAFICANDAME].Parent = CmdLin[MyGlb.CMD_SALESDATA1];
    CmdLin[MyGlb.CMD_GRAFICANDAME].iGuid = "3F0D520D-CAA6-45D9-844D-C01599854ED5";
    CmdLin[MyGlb.CMD_GRAFICANDAME].Caption = "Grafico Andamento";
    CmdLin[MyGlb.CMD_GRAFICANDAME].ToolTip = "";
    CmdLin[MyGlb.CMD_GRAFICANDAME].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_GRAFICANDAME].IsMenu = true;
    CmdLin[MyGlb.CMD_GRAFICANDAME].IsToolbar = false;
    CmdLin[MyGlb.CMD_GRAFICANDAME].ShowNames = false;
    CmdLin[MyGlb.CMD_GRAFICANDAME].ToolName = "Grafico";
    CmdLin[MyGlb.CMD_GRAFICANDAME].UseHilight = false;
    CmdLin[MyGlb.CMD_GRAFICANDAME].Code = "GRAFICANDAME";
    CmdLin[MyGlb.CMD_GRAFICANDAME].Index = MyGlb.CMD_GRAFICANDAME;
    CmdLin[MyGlb.CMD_GRAFICANDAME].Level = 3;
    CmdLin[MyGlb.CMD_GRAFICANDAME].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_ANDROID] = new ACommand();
    CmdSets[MyGlb.CMDS_ANDROID].iGuid = "D3561A37-8DE6-4368-81BD-F0148F894BA9";
    CmdSets[MyGlb.CMDS_ANDROID].Index = MyGlb.CMDS_ANDROID;
    CmdSets[MyGlb.CMDS_ANDROID].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_ANDROID].SetNumCommands(3);
    CmdSets[MyGlb.CMDS_ANDROID].Caption = "Android";
    CmdSets[MyGlb.CMDS_ANDROID].ToolTip = "";
    CmdSets[MyGlb.CMDS_ANDROID].Level = 1;
    CmdSets[MyGlb.CMDS_ANDROID].IsMenu = true;
    CmdSets[MyGlb.CMDS_ANDROID].IsToolbar = false;
    CmdSets[MyGlb.CMDS_ANDROID].ShowNames = false;
    CmdSets[MyGlb.CMDS_ANDROID].Code = "ANDROID";
    CmdLin[MyGlb.CMD_IMPOSTAZION1] = new ACommand();
    CmdSets[MyGlb.CMDS_ANDROID].AddCommand(CmdLin[MyGlb.CMD_IMPOSTAZION1]);
    CmdLin[MyGlb.CMD_IMPOSTAZION1].Parent = CmdSets[MyGlb.CMDS_ANDROID];
    CmdLin[MyGlb.CMD_IMPOSTAZION1].iGuid = "C423FDB0-8BF0-4A22-9982-9E7FC0B57D27";
    CmdLin[MyGlb.CMD_IMPOSTAZION1].Caption = "Impostazioni";
    CmdLin[MyGlb.CMD_IMPOSTAZION1].ToolTip = "";
    CmdLin[MyGlb.CMD_IMPOSTAZION1].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_IMPOSTAZION1].IsMenu = true;
    CmdLin[MyGlb.CMD_IMPOSTAZION1].IsToolbar = false;
    CmdLin[MyGlb.CMD_IMPOSTAZION1].ShowNames = false;
    CmdLin[MyGlb.CMD_IMPOSTAZION1].ToolName = "Impostaz...";
    CmdLin[MyGlb.CMD_IMPOSTAZION1].UseHilight = false;
    CmdLin[MyGlb.CMD_IMPOSTAZION1].Code = "IMPOSTAZION1";
    CmdLin[MyGlb.CMD_IMPOSTAZION1].Index = MyGlb.CMD_IMPOSTAZION1;
    CmdLin[MyGlb.CMD_IMPOSTAZION1].Level = 2;
    CmdLin[MyGlb.CMD_IMPOSTAZION1].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_DEVICEID1] = new ACommand();
    CmdSets[MyGlb.CMDS_ANDROID].AddCommand(CmdLin[MyGlb.CMD_DEVICEID1]);
    CmdLin[MyGlb.CMD_DEVICEID1].Parent = CmdSets[MyGlb.CMDS_ANDROID];
    CmdLin[MyGlb.CMD_DEVICEID1].iGuid = "C6D43E8F-3B97-45EE-B355-4330F7EEEE17";
    CmdLin[MyGlb.CMD_DEVICEID1].Caption = "Device ID";
    CmdLin[MyGlb.CMD_DEVICEID1].ToolTip = "";
    CmdLin[MyGlb.CMD_DEVICEID1].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_DEVICEID1].IsMenu = true;
    CmdLin[MyGlb.CMD_DEVICEID1].IsToolbar = false;
    CmdLin[MyGlb.CMD_DEVICEID1].ShowNames = false;
    CmdLin[MyGlb.CMD_DEVICEID1].ToolName = "Device ID";
    CmdLin[MyGlb.CMD_DEVICEID1].UseHilight = false;
    CmdLin[MyGlb.CMD_DEVICEID1].Code = "DEVICEID1";
    CmdLin[MyGlb.CMD_DEVICEID1].Index = MyGlb.CMD_DEVICEID1;
    CmdLin[MyGlb.CMD_DEVICEID1].Level = 2;
    CmdLin[MyGlb.CMD_DEVICEID1].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_SPEDIZIONI2] = new ACommand();
    CmdSets[MyGlb.CMDS_ANDROID].AddCommand(CmdLin[MyGlb.CMD_SPEDIZIONI2]);
    CmdLin[MyGlb.CMD_SPEDIZIONI2].Parent = CmdSets[MyGlb.CMDS_ANDROID];
    CmdLin[MyGlb.CMD_SPEDIZIONI2].iGuid = "9B42356D-2D96-4D70-AE8C-3AA57424BD45";
    CmdLin[MyGlb.CMD_SPEDIZIONI2].Caption = "Spedizioni";
    CmdLin[MyGlb.CMD_SPEDIZIONI2].ToolTip = "";
    CmdLin[MyGlb.CMD_SPEDIZIONI2].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI2].IsMenu = true;
    CmdLin[MyGlb.CMD_SPEDIZIONI2].IsToolbar = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI2].ShowNames = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI2].ToolName = "Spedizioni";
    CmdLin[MyGlb.CMD_SPEDIZIONI2].UseHilight = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI2].Code = "SPEDIZIONI2";
    CmdLin[MyGlb.CMD_SPEDIZIONI2].Index = MyGlb.CMD_SPEDIZIONI2;
    CmdLin[MyGlb.CMD_SPEDIZIONI2].Level = 2;
    CmdLin[MyGlb.CMD_SPEDIZIONI2].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_WINPHONE] = new ACommand();
    CmdSets[MyGlb.CMDS_WINPHONE].iGuid = "22396A4F-70CE-42B4-A233-DCEA9BD2760E";
    CmdSets[MyGlb.CMDS_WINPHONE].Index = MyGlb.CMDS_WINPHONE;
    CmdSets[MyGlb.CMDS_WINPHONE].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_WINPHONE].SetNumCommands(3);
    CmdSets[MyGlb.CMDS_WINPHONE].Caption = "Win Phone";
    CmdSets[MyGlb.CMDS_WINPHONE].ToolTip = "";
    CmdSets[MyGlb.CMDS_WINPHONE].Level = 1;
    CmdSets[MyGlb.CMDS_WINPHONE].IsMenu = true;
    CmdSets[MyGlb.CMDS_WINPHONE].IsToolbar = false;
    CmdSets[MyGlb.CMDS_WINPHONE].ShowNames = false;
    CmdSets[MyGlb.CMDS_WINPHONE].Code = "WINPHONE";
    CmdLin[MyGlb.CMD_IMPOSTAZION3] = new ACommand();
    CmdSets[MyGlb.CMDS_WINPHONE].AddCommand(CmdLin[MyGlb.CMD_IMPOSTAZION3]);
    CmdLin[MyGlb.CMD_IMPOSTAZION3].Parent = CmdSets[MyGlb.CMDS_WINPHONE];
    CmdLin[MyGlb.CMD_IMPOSTAZION3].iGuid = "6F9EAD8B-1A81-4B37-A8C9-E3B2081F1686";
    CmdLin[MyGlb.CMD_IMPOSTAZION3].Caption = "Impostazioni";
    CmdLin[MyGlb.CMD_IMPOSTAZION3].ToolTip = "";
    CmdLin[MyGlb.CMD_IMPOSTAZION3].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_IMPOSTAZION3].IsMenu = true;
    CmdLin[MyGlb.CMD_IMPOSTAZION3].IsToolbar = false;
    CmdLin[MyGlb.CMD_IMPOSTAZION3].ShowNames = false;
    CmdLin[MyGlb.CMD_IMPOSTAZION3].ToolName = "Impostaz...";
    CmdLin[MyGlb.CMD_IMPOSTAZION3].UseHilight = false;
    CmdLin[MyGlb.CMD_IMPOSTAZION3].Code = "IMPOSTAZION3";
    CmdLin[MyGlb.CMD_IMPOSTAZION3].Index = MyGlb.CMD_IMPOSTAZION3;
    CmdLin[MyGlb.CMD_IMPOSTAZION3].Level = 2;
    CmdLin[MyGlb.CMD_IMPOSTAZION3].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_DEVICEID2] = new ACommand();
    CmdSets[MyGlb.CMDS_WINPHONE].AddCommand(CmdLin[MyGlb.CMD_DEVICEID2]);
    CmdLin[MyGlb.CMD_DEVICEID2].Parent = CmdSets[MyGlb.CMDS_WINPHONE];
    CmdLin[MyGlb.CMD_DEVICEID2].iGuid = "1E0CF8D3-8EBC-42A3-B102-B8F835562C4C";
    CmdLin[MyGlb.CMD_DEVICEID2].Caption = "Device ID";
    CmdLin[MyGlb.CMD_DEVICEID2].ToolTip = "";
    CmdLin[MyGlb.CMD_DEVICEID2].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_DEVICEID2].IsMenu = true;
    CmdLin[MyGlb.CMD_DEVICEID2].IsToolbar = false;
    CmdLin[MyGlb.CMD_DEVICEID2].ShowNames = false;
    CmdLin[MyGlb.CMD_DEVICEID2].ToolName = "Device ID";
    CmdLin[MyGlb.CMD_DEVICEID2].UseHilight = false;
    CmdLin[MyGlb.CMD_DEVICEID2].Code = "DEVICEID2";
    CmdLin[MyGlb.CMD_DEVICEID2].Index = MyGlb.CMD_DEVICEID2;
    CmdLin[MyGlb.CMD_DEVICEID2].Level = 2;
    CmdLin[MyGlb.CMD_DEVICEID2].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_SPEDIZIONI3] = new ACommand();
    CmdSets[MyGlb.CMDS_WINPHONE].AddCommand(CmdLin[MyGlb.CMD_SPEDIZIONI3]);
    CmdLin[MyGlb.CMD_SPEDIZIONI3].Parent = CmdSets[MyGlb.CMDS_WINPHONE];
    CmdLin[MyGlb.CMD_SPEDIZIONI3].iGuid = "669534CC-C21E-4ABF-BF76-A0E0E2D70FA6";
    CmdLin[MyGlb.CMD_SPEDIZIONI3].Caption = "Spedizioni";
    CmdLin[MyGlb.CMD_SPEDIZIONI3].ToolTip = "";
    CmdLin[MyGlb.CMD_SPEDIZIONI3].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI3].IsMenu = true;
    CmdLin[MyGlb.CMD_SPEDIZIONI3].IsToolbar = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI3].ShowNames = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI3].ToolName = "Spedizioni";
    CmdLin[MyGlb.CMD_SPEDIZIONI3].UseHilight = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI3].Code = "SPEDIZIONI3";
    CmdLin[MyGlb.CMD_SPEDIZIONI3].Index = MyGlb.CMD_SPEDIZIONI3;
    CmdLin[MyGlb.CMD_SPEDIZIONI3].Level = 2;
    CmdLin[MyGlb.CMD_SPEDIZIONI3].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_WINSTORE] = new ACommand();
    CmdSets[MyGlb.CMDS_WINSTORE].iGuid = "ACFE000F-BF0A-47A5-BF18-2AAE6782F714";
    CmdSets[MyGlb.CMDS_WINSTORE].Index = MyGlb.CMDS_WINSTORE;
    CmdSets[MyGlb.CMDS_WINSTORE].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_WINSTORE].SetNumCommands(3);
    CmdSets[MyGlb.CMDS_WINSTORE].Caption = "Win Store";
    CmdSets[MyGlb.CMDS_WINSTORE].ToolTip = "";
    CmdSets[MyGlb.CMDS_WINSTORE].Level = 1;
    CmdSets[MyGlb.CMDS_WINSTORE].IsMenu = true;
    CmdSets[MyGlb.CMDS_WINSTORE].IsToolbar = false;
    CmdSets[MyGlb.CMDS_WINSTORE].ShowNames = false;
    CmdSets[MyGlb.CMDS_WINSTORE].Code = "WINSTORE";
    CmdLin[MyGlb.CMD_IMPOSTAZIONI] = new ACommand();
    CmdSets[MyGlb.CMDS_WINSTORE].AddCommand(CmdLin[MyGlb.CMD_IMPOSTAZIONI]);
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].Parent = CmdSets[MyGlb.CMDS_WINSTORE];
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].iGuid = "70BC7D0B-72F2-47AC-90D6-9F7028776DEF";
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].Caption = "Impostazioni";
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].ToolTip = "";
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].IsMenu = true;
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].IsToolbar = false;
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].ShowNames = false;
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].ToolName = "Impostaz...";
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].UseHilight = false;
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].Code = "IMPOSTAZIONI";
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].Index = MyGlb.CMD_IMPOSTAZIONI;
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].Level = 2;
    CmdLin[MyGlb.CMD_IMPOSTAZIONI].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_DEVICEID] = new ACommand();
    CmdSets[MyGlb.CMDS_WINSTORE].AddCommand(CmdLin[MyGlb.CMD_DEVICEID]);
    CmdLin[MyGlb.CMD_DEVICEID].Parent = CmdSets[MyGlb.CMDS_WINSTORE];
    CmdLin[MyGlb.CMD_DEVICEID].iGuid = "367769DC-F90D-414F-B09B-6A3FE7C2BEED";
    CmdLin[MyGlb.CMD_DEVICEID].Caption = "Device ID";
    CmdLin[MyGlb.CMD_DEVICEID].ToolTip = "";
    CmdLin[MyGlb.CMD_DEVICEID].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_DEVICEID].IsMenu = true;
    CmdLin[MyGlb.CMD_DEVICEID].IsToolbar = false;
    CmdLin[MyGlb.CMD_DEVICEID].ShowNames = false;
    CmdLin[MyGlb.CMD_DEVICEID].ToolName = "Device ID";
    CmdLin[MyGlb.CMD_DEVICEID].UseHilight = false;
    CmdLin[MyGlb.CMD_DEVICEID].Code = "DEVICEID";
    CmdLin[MyGlb.CMD_DEVICEID].Index = MyGlb.CMD_DEVICEID;
    CmdLin[MyGlb.CMD_DEVICEID].Level = 2;
    CmdLin[MyGlb.CMD_DEVICEID].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_SPEDIZIONI] = new ACommand();
    CmdSets[MyGlb.CMDS_WINSTORE].AddCommand(CmdLin[MyGlb.CMD_SPEDIZIONI]);
    CmdLin[MyGlb.CMD_SPEDIZIONI].Parent = CmdSets[MyGlb.CMDS_WINSTORE];
    CmdLin[MyGlb.CMD_SPEDIZIONI].iGuid = "DD242B81-3024-4773-98ED-2836B5A87928";
    CmdLin[MyGlb.CMD_SPEDIZIONI].Caption = "Spedizioni";
    CmdLin[MyGlb.CMD_SPEDIZIONI].ToolTip = "";
    CmdLin[MyGlb.CMD_SPEDIZIONI].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI].IsMenu = true;
    CmdLin[MyGlb.CMD_SPEDIZIONI].IsToolbar = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI].ShowNames = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI].ToolName = "Spedizioni";
    CmdLin[MyGlb.CMD_SPEDIZIONI].UseHilight = false;
    CmdLin[MyGlb.CMD_SPEDIZIONI].Code = "SPEDIZIONI";
    CmdLin[MyGlb.CMD_SPEDIZIONI].Index = MyGlb.CMD_SPEDIZIONI;
    CmdLin[MyGlb.CMD_SPEDIZIONI].Level = 2;
    CmdLin[MyGlb.CMD_SPEDIZIONI].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_DEBUG1] = new ACommand();
    CmdSets[MyGlb.CMDS_DEBUG1].iGuid = "5B00FF58-DF81-4268-9EBB-0EA78F8B68F7";
    CmdSets[MyGlb.CMDS_DEBUG1].FormList = true;
    CmdSets[MyGlb.CMDS_DEBUG1].Index = MyGlb.CMDS_DEBUG1;
    CmdSets[MyGlb.CMDS_DEBUG1].InitStatus(true, false, false);
    CmdSets[MyGlb.CMDS_DEBUG1].SetNumCommands(1);
    CmdSets[MyGlb.CMDS_DEBUG1].Caption = "Debug";
    CmdSets[MyGlb.CMDS_DEBUG1].ToolTip = "";
    CmdSets[MyGlb.CMDS_DEBUG1].Level = 1;
    CmdSets[MyGlb.CMDS_DEBUG1].IsMenu = true;
    CmdSets[MyGlb.CMDS_DEBUG1].IsToolbar = false;
    CmdSets[MyGlb.CMDS_DEBUG1].ShowNames = false;
    CmdSets[MyGlb.CMDS_DEBUG1].Code = "DEBUG1";
    CmdLin[MyGlb.CMD_DEBUG] = new ACommand();
    CmdSets[MyGlb.CMDS_DEBUG1].AddCommand(CmdLin[MyGlb.CMD_DEBUG]);
    CmdLin[MyGlb.CMD_DEBUG].Parent = CmdSets[MyGlb.CMDS_DEBUG1];
    CmdLin[MyGlb.CMD_DEBUG].iGuid = "2A6B0D39-FDCB-41EE-B871-4F510D3F949D";
    CmdLin[MyGlb.CMD_DEBUG].Caption = "Debug";
    CmdLin[MyGlb.CMD_DEBUG].ToolTip = "";
    CmdLin[MyGlb.CMD_DEBUG].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_DEBUG].IsMenu = true;
    CmdLin[MyGlb.CMD_DEBUG].IsToolbar = false;
    CmdLin[MyGlb.CMD_DEBUG].ShowNames = false;
    CmdLin[MyGlb.CMD_DEBUG].ToolName = "Debug";
    CmdLin[MyGlb.CMD_DEBUG].UseHilight = false;
    CmdLin[MyGlb.CMD_DEBUG].Code = "DEBUG";
    CmdLin[MyGlb.CMD_DEBUG].Index = MyGlb.CMD_DEBUG;
    CmdLin[MyGlb.CMD_DEBUG].Level = 2;
    CmdLin[MyGlb.CMD_DEBUG].InitStatus(true, false, false);
    CmdSets[MyGlb.CMDS_TOOLBARLOG] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARLOG].iGuid = "8468C738-7D58-40D5-9194-BAC4E1E3DBB5";
    CmdSets[MyGlb.CMDS_TOOLBARLOG].IdxForm = MyGlb.FRM_LOGS;
    CmdSets[MyGlb.CMDS_TOOLBARLOG].ToolCont = -2;
    CmdSets[MyGlb.CMDS_TOOLBARLOG].ToolContCode = "PAN_LOGS";
    CmdSets[MyGlb.CMDS_TOOLBARLOG].Index = MyGlb.CMDS_TOOLBARLOG;
    CmdSets[MyGlb.CMDS_TOOLBARLOG].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_TOOLBARLOG].SetNumCommands(5);
    CmdSets[MyGlb.CMDS_TOOLBARLOG].Caption = "toolbar Log";
    CmdSets[MyGlb.CMDS_TOOLBARLOG].ToolTip = "Quali comandi saranno contenuti qui?";
    CmdSets[MyGlb.CMDS_TOOLBARLOG].Level = 1;
    CmdSets[MyGlb.CMDS_TOOLBARLOG].IsMenu = false;
    CmdSets[MyGlb.CMDS_TOOLBARLOG].IsToolbar = true;
    CmdSets[MyGlb.CMDS_TOOLBARLOG].ShowNames = false;
    CmdSets[MyGlb.CMDS_TOOLBARLOG].Code = "TOOLBARLOG";
    CmdLin[MyGlb.CMD_SVUOTALOG] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARLOG].AddCommand(CmdLin[MyGlb.CMD_SVUOTALOG]);
    CmdLin[MyGlb.CMD_SVUOTALOG].Parent = CmdSets[MyGlb.CMDS_TOOLBARLOG];
    CmdLin[MyGlb.CMD_SVUOTALOG].iGuid = "DD3E1021-7692-400B-BD12-D9824CF43922";
    CmdLin[MyGlb.CMD_SVUOTALOG].Caption = "Svuota log";
    CmdLin[MyGlb.CMD_SVUOTALOG].ToolTip = "";
    CmdLin[MyGlb.CMD_SVUOTALOG].RequireConfirmation = true;
    CmdLin[MyGlb.CMD_SVUOTALOG].IsMenu = false;
    CmdLin[MyGlb.CMD_SVUOTALOG].IsToolbar = true;
    CmdLin[MyGlb.CMD_SVUOTALOG].ShowNames = false;
    CmdLin[MyGlb.CMD_SVUOTALOG].ToolName = "Svuota log";
    CmdLin[MyGlb.CMD_SVUOTALOG].UseHilight = false;
    CmdLin[MyGlb.CMD_SVUOTALOG].Code = "SVUOTALOG";
    CmdLin[MyGlb.CMD_SVUOTALOG].Index = MyGlb.CMD_SVUOTALOG;
    CmdLin[MyGlb.CMD_SVUOTALOG].Level = 2;
    CmdLin[MyGlb.CMD_SVUOTALOG].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_SEP3] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARLOG].AddCommand(CmdLin[MyGlb.CMD_SEP3]);
    CmdLin[MyGlb.CMD_SEP3].Parent = CmdSets[MyGlb.CMDS_TOOLBARLOG];
    CmdLin[MyGlb.CMD_SEP3].iGuid = "CE31289D-CB7B-4C99-9EA1-1F6BA5D9029A";
    CmdLin[MyGlb.CMD_SEP3].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_SEP3].IsMenu = false;
    CmdLin[MyGlb.CMD_SEP3].IsToolbar = true;
    CmdLin[MyGlb.CMD_SEP3].ShowNames = false;
    CmdLin[MyGlb.CMD_SEP3].ToolName = "Nuovo";
    CmdLin[MyGlb.CMD_SEP3].UseHilight = false;
    CmdLin[MyGlb.CMD_SEP3].Code = "SEP3";
    CmdLin[MyGlb.CMD_SEP3].Index = MyGlb.CMD_SEP3;
    CmdLin[MyGlb.CMD_SEP3].Level = 2;
    CmdLin[MyGlb.CMD_SEP3].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_LOGSPEDIZION] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARLOG].AddCommand(CmdLin[MyGlb.CMD_LOGSPEDIZION]);
    CmdLin[MyGlb.CMD_LOGSPEDIZION].Parent = CmdSets[MyGlb.CMDS_TOOLBARLOG];
    CmdLin[MyGlb.CMD_LOGSPEDIZION].iGuid = "AEDDE685-3E20-4C30-B18C-4BAD009350BA";
    CmdLin[MyGlb.CMD_LOGSPEDIZION].Caption = "Log spedizioni";
    CmdLin[MyGlb.CMD_LOGSPEDIZION].ToolTip = "";
    CmdLin[MyGlb.CMD_LOGSPEDIZION].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_LOGSPEDIZION].IsMenu = false;
    CmdLin[MyGlb.CMD_LOGSPEDIZION].IsToolbar = true;
    CmdLin[MyGlb.CMD_LOGSPEDIZION].ShowNames = false;
    CmdLin[MyGlb.CMD_LOGSPEDIZION].ToolName = "Log";
    CmdLin[MyGlb.CMD_LOGSPEDIZION].UseHilight = false;
    CmdLin[MyGlb.CMD_LOGSPEDIZION].Code = "LOGSPEDIZION";
    CmdLin[MyGlb.CMD_LOGSPEDIZION].Index = MyGlb.CMD_LOGSPEDIZION;
    CmdLin[MyGlb.CMD_LOGSPEDIZION].Level = 2;
    CmdLin[MyGlb.CMD_LOGSPEDIZION].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_LOGFEEDBACK] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARLOG].AddCommand(CmdLin[MyGlb.CMD_LOGFEEDBACK]);
    CmdLin[MyGlb.CMD_LOGFEEDBACK].Parent = CmdSets[MyGlb.CMDS_TOOLBARLOG];
    CmdLin[MyGlb.CMD_LOGFEEDBACK].iGuid = "D28C5FA8-5B4C-4F9C-A457-F6A01E08909E";
    CmdLin[MyGlb.CMD_LOGFEEDBACK].Caption = "Log feedback";
    CmdLin[MyGlb.CMD_LOGFEEDBACK].ToolTip = "";
    CmdLin[MyGlb.CMD_LOGFEEDBACK].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_LOGFEEDBACK].IsMenu = false;
    CmdLin[MyGlb.CMD_LOGFEEDBACK].IsToolbar = true;
    CmdLin[MyGlb.CMD_LOGFEEDBACK].ShowNames = false;
    CmdLin[MyGlb.CMD_LOGFEEDBACK].ToolName = "Log";
    CmdLin[MyGlb.CMD_LOGFEEDBACK].UseHilight = false;
    CmdLin[MyGlb.CMD_LOGFEEDBACK].Code = "LOGFEEDBACK";
    CmdLin[MyGlb.CMD_LOGFEEDBACK].Index = MyGlb.CMD_LOGFEEDBACK;
    CmdLin[MyGlb.CMD_LOGFEEDBACK].Level = 2;
    CmdLin[MyGlb.CMD_LOGFEEDBACK].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_SVUOLOGSFILE] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARLOG].AddCommand(CmdLin[MyGlb.CMD_SVUOLOGSFILE]);
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].Parent = CmdSets[MyGlb.CMDS_TOOLBARLOG];
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].iGuid = "1411A5ED-E97C-4239-B4B2-4E7540B85A0D";
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].Caption = "Svuota Logs filesystem";
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].ToolTip = "";
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].RequireConfirmation = true;
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].IsMenu = false;
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].IsToolbar = true;
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].ShowNames = false;
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].ToolName = "Svuota";
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].UseHilight = false;
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].Code = "SVUOLOGSFILE";
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].Index = MyGlb.CMD_SVUOLOGSFILE;
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].Level = 2;
    CmdLin[MyGlb.CMD_SVUOLOGSFILE].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_TOOLBARFORM1] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].iGuid = "A5DC93F2-94BD-4E3C-913C-C894F487101F";
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].IdxForm = MyGlb.FRM_IMPOSTAZIIOS;
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].ToolCont = -2;
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].ToolContCode = "PAN_APPSPUSHSETT";
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].Index = MyGlb.CMDS_TOOLBARFORM1;
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].SetNumCommands(4);
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].Caption = "toolbar form";
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].ToolTip = "Quali comandi saranno contenuti qui?";
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].Level = 1;
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].IsMenu = false;
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].IsToolbar = true;
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].ShowNames = false;
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].Code = "TOOLBARFORM1";
    CmdLin[MyGlb.CMD_INVIADISPNOT] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].AddCommand(CmdLin[MyGlb.CMD_INVIADISPNOT]);
    CmdLin[MyGlb.CMD_INVIADISPNOT].Parent = CmdSets[MyGlb.CMDS_TOOLBARFORM1];
    CmdLin[MyGlb.CMD_INVIADISPNOT].iGuid = "F3A0563C-013B-49EB-ADAF-0AF041DB6F3D";
    CmdLin[MyGlb.CMD_INVIADISPNOT].Caption = "Invia a dispositivi noti";
    CmdLin[MyGlb.CMD_INVIADISPNOT].ToolTip = "Genera il file JSON per l'iphone";
    CmdLin[MyGlb.CMD_INVIADISPNOT].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_INVIADISPNOT].IsMenu = false;
    CmdLin[MyGlb.CMD_INVIADISPNOT].IsToolbar = true;
    CmdLin[MyGlb.CMD_INVIADISPNOT].ShowNames = false;
    CmdLin[MyGlb.CMD_INVIADISPNOT].ToolName = "Invia";
    CmdLin[MyGlb.CMD_INVIADISPNOT].UseHilight = false;
    CmdLin[MyGlb.CMD_INVIADISPNOT].Code = "INVIADISPNOT";
    CmdLin[MyGlb.CMD_INVIADISPNOT].Index = MyGlb.CMD_INVIADISPNOT;
    CmdLin[MyGlb.CMD_INVIADISPNOT].Level = 2;
    CmdLin[MyGlb.CMD_INVIADISPNOT].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_INVIAAUTENTI] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].AddCommand(CmdLin[MyGlb.CMD_INVIAAUTENTI]);
    CmdLin[MyGlb.CMD_INVIAAUTENTI].Parent = CmdSets[MyGlb.CMDS_TOOLBARFORM1];
    CmdLin[MyGlb.CMD_INVIAAUTENTI].iGuid = "F56F9E69-3E88-4839-828A-748F30EEB088";
    CmdLin[MyGlb.CMD_INVIAAUTENTI].Caption = "Invia a utenti";
    CmdLin[MyGlb.CMD_INVIAAUTENTI].ToolTip = "Genera il file JSON per l'iphone";
    CmdLin[MyGlb.CMD_INVIAAUTENTI].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_INVIAAUTENTI].IsMenu = false;
    CmdLin[MyGlb.CMD_INVIAAUTENTI].IsToolbar = true;
    CmdLin[MyGlb.CMD_INVIAAUTENTI].ShowNames = false;
    CmdLin[MyGlb.CMD_INVIAAUTENTI].ToolName = "Invia";
    CmdLin[MyGlb.CMD_INVIAAUTENTI].UseHilight = false;
    CmdLin[MyGlb.CMD_INVIAAUTENTI].Code = "INVIAAUTENTI";
    CmdLin[MyGlb.CMD_INVIAAUTENTI].Index = MyGlb.CMD_INVIAAUTENTI;
    CmdLin[MyGlb.CMD_INVIAAUTENTI].Level = 2;
    CmdLin[MyGlb.CMD_INVIAAUTENTI].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_CHECKFEEDBA1] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].AddCommand(CmdLin[MyGlb.CMD_CHECKFEEDBA1]);
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].Parent = CmdSets[MyGlb.CMDS_TOOLBARFORM1];
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].iGuid = "37615828-062C-464D-B707-584CB58CF651";
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].Caption = "Check Feedback";
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].ToolTip = "";
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].IsMenu = false;
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].IsToolbar = true;
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].ShowNames = false;
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].ToolName = "Check";
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].UseHilight = false;
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].Code = "CHECKFEEDBA1";
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].Index = MyGlb.CMD_CHECKFEEDBA1;
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].Level = 2;
    CmdLin[MyGlb.CMD_CHECKFEEDBA1].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_CHECKCERTS] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARFORM1].AddCommand(CmdLin[MyGlb.CMD_CHECKCERTS]);
    CmdLin[MyGlb.CMD_CHECKCERTS].Parent = CmdSets[MyGlb.CMDS_TOOLBARFORM1];
    CmdLin[MyGlb.CMD_CHECKCERTS].iGuid = "F79DF092-4150-4236-953D-E310C52DBA68";
    CmdLin[MyGlb.CMD_CHECKCERTS].Caption = "Check Certs";
    CmdLin[MyGlb.CMD_CHECKCERTS].ToolTip = "";
    CmdLin[MyGlb.CMD_CHECKCERTS].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_CHECKCERTS].IsMenu = false;
    CmdLin[MyGlb.CMD_CHECKCERTS].IsToolbar = true;
    CmdLin[MyGlb.CMD_CHECKCERTS].ShowNames = false;
    CmdLin[MyGlb.CMD_CHECKCERTS].ToolName = "Check";
    CmdLin[MyGlb.CMD_CHECKCERTS].UseHilight = false;
    CmdLin[MyGlb.CMD_CHECKCERTS].Code = "CHECKCERTS";
    CmdLin[MyGlb.CMD_CHECKCERTS].Index = MyGlb.CMD_CHECKCERTS;
    CmdLin[MyGlb.CMD_CHECKCERTS].Level = 2;
    CmdLin[MyGlb.CMD_CHECKCERTS].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].iGuid = "54932451-2AE5-4DE9-9E41-316F0C83A8D0";
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].IdxForm = MyGlb.FRM_DEVICTOKEIOS;
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].ToolCont = -2;
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].ToolContCode = "PAN_DEVICETOKEN";
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].Index = MyGlb.CMDS_TOOLBARNOTIF;
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].SetNumCommands(1);
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].Caption = "toolbarNotifiche";
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].ToolTip = "Quali comandi saranno contenuti qui?";
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].Level = 1;
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].IsMenu = false;
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].IsToolbar = true;
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].ShowNames = false;
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].Code = "TOOLBARNOTIF";
    CmdLin[MyGlb.CMD_INVIANOTIFIC] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARNOTIF].AddCommand(CmdLin[MyGlb.CMD_INVIANOTIFIC]);
    CmdLin[MyGlb.CMD_INVIANOTIFIC].Parent = CmdSets[MyGlb.CMDS_TOOLBARNOTIF];
    CmdLin[MyGlb.CMD_INVIANOTIFIC].iGuid = "64EA1AAD-49D7-4A4A-AFD1-91AD147C2E2E";
    CmdLin[MyGlb.CMD_INVIANOTIFIC].Caption = "Invia notifica";
    CmdLin[MyGlb.CMD_INVIANOTIFIC].ToolTip = "";
    CmdLin[MyGlb.CMD_INVIANOTIFIC].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_INVIANOTIFIC].IsMenu = false;
    CmdLin[MyGlb.CMD_INVIANOTIFIC].IsToolbar = true;
    CmdLin[MyGlb.CMD_INVIANOTIFIC].ShowNames = false;
    CmdLin[MyGlb.CMD_INVIANOTIFIC].ToolName = "Invia";
    CmdLin[MyGlb.CMD_INVIANOTIFIC].UseHilight = false;
    CmdLin[MyGlb.CMD_INVIANOTIFIC].Code = "INVIANOTIFIC";
    CmdLin[MyGlb.CMD_INVIANOTIFIC].Index = MyGlb.CMD_INVIANOTIFIC;
    CmdLin[MyGlb.CMD_INVIANOTIFIC].Level = 2;
    CmdLin[MyGlb.CMD_INVIANOTIFIC].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].iGuid = "E5C0F700-2931-4FE9-AAF6-7290D6533A23";
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].IdxForm = MyGlb.FRM_SPEDIZIONIOS;
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].ToolCont = -2;
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].ToolContCode = "PAN_SPEDIZIONI";
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].Index = MyGlb.CMDS_TOOLBASPEDIZ;
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].SetNumCommands(2);
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].Caption = "toolbar Spedizioni";
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].ToolTip = "Quali comandi saranno contenuti qui?";
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].Level = 1;
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].IsMenu = false;
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].IsToolbar = true;
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].ShowNames = false;
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].Code = "TOOLBASPEDIZ";
    CmdLin[MyGlb.CMD_ELIMININVIAT] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].AddCommand(CmdLin[MyGlb.CMD_ELIMININVIAT]);
    CmdLin[MyGlb.CMD_ELIMININVIAT].Parent = CmdSets[MyGlb.CMDS_TOOLBASPEDIZ];
    CmdLin[MyGlb.CMD_ELIMININVIAT].iGuid = "8D34D815-BF45-48CC-BFDF-1E5FD726AEF3";
    CmdLin[MyGlb.CMD_ELIMININVIAT].Caption = "Elimina inviati";
    CmdLin[MyGlb.CMD_ELIMININVIAT].ToolTip = "Elimina dalla coda di spedizioni tutti i messatti già inviati";
    CmdLin[MyGlb.CMD_ELIMININVIAT].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_ELIMININVIAT].IsMenu = false;
    CmdLin[MyGlb.CMD_ELIMININVIAT].IsToolbar = true;
    CmdLin[MyGlb.CMD_ELIMININVIAT].ShowNames = false;
    CmdLin[MyGlb.CMD_ELIMININVIAT].ToolName = "Elimina";
    CmdLin[MyGlb.CMD_ELIMININVIAT].UseHilight = false;
    CmdLin[MyGlb.CMD_ELIMININVIAT].Code = "ELIMININVIAT";
    CmdLin[MyGlb.CMD_ELIMININVIAT].Index = MyGlb.CMD_ELIMININVIAT;
    CmdLin[MyGlb.CMD_ELIMININVIAT].Level = 2;
    CmdLin[MyGlb.CMD_ELIMININVIAT].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_RIMETINATTES] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBASPEDIZ].AddCommand(CmdLin[MyGlb.CMD_RIMETINATTES]);
    CmdLin[MyGlb.CMD_RIMETINATTES].Parent = CmdSets[MyGlb.CMDS_TOOLBASPEDIZ];
    CmdLin[MyGlb.CMD_RIMETINATTES].iGuid = "53468235-A1E5-47CB-B31D-64A1792C824F";
    CmdLin[MyGlb.CMD_RIMETINATTES].Caption = "Rimetti in attesa";
    CmdLin[MyGlb.CMD_RIMETINATTES].ToolTip = "Rimette in attesa tutti i messaggi inviati (agisce solo sulla righe selezionate)";
    CmdLin[MyGlb.CMD_RIMETINATTES].RequireConfirmation = true;
    CmdLin[MyGlb.CMD_RIMETINATTES].IsMenu = false;
    CmdLin[MyGlb.CMD_RIMETINATTES].IsToolbar = true;
    CmdLin[MyGlb.CMD_RIMETINATTES].ShowNames = false;
    CmdLin[MyGlb.CMD_RIMETINATTES].ToolName = "Rimetti";
    CmdLin[MyGlb.CMD_RIMETINATTES].UseHilight = false;
    CmdLin[MyGlb.CMD_RIMETINATTES].Code = "RIMETINATTES";
    CmdLin[MyGlb.CMD_RIMETINATTES].Index = MyGlb.CMD_RIMETINATTES;
    CmdLin[MyGlb.CMD_RIMETINATTES].Level = 2;
    CmdLin[MyGlb.CMD_RIMETINATTES].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_TOOLBARFORM] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARFORM].iGuid = "DF65F2B4-3160-4301-9122-F1B63514693A";
    CmdSets[MyGlb.CMDS_TOOLBARFORM].IdxForm = MyGlb.FRM_IMPOSTANDROI;
    CmdSets[MyGlb.CMDS_TOOLBARFORM].ToolCont = -2;
    CmdSets[MyGlb.CMDS_TOOLBARFORM].ToolContCode = "PAN_APPSPUSHSETT";
    CmdSets[MyGlb.CMDS_TOOLBARFORM].Index = MyGlb.CMDS_TOOLBARFORM;
    CmdSets[MyGlb.CMDS_TOOLBARFORM].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_TOOLBARFORM].SetNumCommands(1);
    CmdSets[MyGlb.CMDS_TOOLBARFORM].Caption = "toolbar form";
    CmdSets[MyGlb.CMDS_TOOLBARFORM].ToolTip = "Quali comandi saranno contenuti qui?";
    CmdSets[MyGlb.CMDS_TOOLBARFORM].Level = 1;
    CmdSets[MyGlb.CMDS_TOOLBARFORM].IsMenu = false;
    CmdSets[MyGlb.CMDS_TOOLBARFORM].IsToolbar = true;
    CmdSets[MyGlb.CMDS_TOOLBARFORM].ShowNames = false;
    CmdSets[MyGlb.CMDS_TOOLBARFORM].Code = "TOOLBARFORM";
    CmdLin[MyGlb.CMD_INVIPUSHAUTE] = new ACommand();
    CmdSets[MyGlb.CMDS_TOOLBARFORM].AddCommand(CmdLin[MyGlb.CMD_INVIPUSHAUTE]);
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].Parent = CmdSets[MyGlb.CMDS_TOOLBARFORM];
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].iGuid = "FB63B2C6-931E-4CA7-8D87-27DADD950B8E";
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].Caption = "Invia Push a utenti";
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].ToolTip = "Genera il file JSON per l'iphone";
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].IsMenu = false;
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].IsToolbar = true;
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].ShowNames = false;
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].ToolName = "Invia";
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].UseHilight = false;
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].Code = "INVIPUSHAUTE";
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].Index = MyGlb.CMD_INVIPUSHAUTE;
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].Level = 2;
    CmdLin[MyGlb.CMD_INVIPUSHAUTE].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1] = new ACommand();
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].iGuid = "43D384F8-8F24-4798-94E9-CCE08D870CC4";
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].IdxForm = MyGlb.FRM_DEVICIDANDRO;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].ToolCont = -2;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].ToolContCode = "PAN_DEVICETOKEN";
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].Index = MyGlb.CMDS_NUOVOCOMMSE1;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].SetNumCommands(1);
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].Caption = "Nuovo Command Set";
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].ToolTip = "Quali comandi saranno contenuti qui?";
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].Level = 1;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].IsMenu = false;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].IsToolbar = true;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].ShowNames = false;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].Code = "NUOVOCOMMSE1";
    CmdLin[MyGlb.CMD_INVIOMANUAL4] = new ACommand();
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE1].AddCommand(CmdLin[MyGlb.CMD_INVIOMANUAL4]);
    CmdLin[MyGlb.CMD_INVIOMANUAL4].Parent = CmdSets[MyGlb.CMDS_NUOVOCOMMSE1];
    CmdLin[MyGlb.CMD_INVIOMANUAL4].iGuid = "2C3E9171-CE56-4276-BEB6-6364E8F67FF3";
    CmdLin[MyGlb.CMD_INVIOMANUAL4].Caption = "Invio Manuale";
    CmdLin[MyGlb.CMD_INVIOMANUAL4].ToolTip = "";
    CmdLin[MyGlb.CMD_INVIOMANUAL4].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_INVIOMANUAL4].IsMenu = false;
    CmdLin[MyGlb.CMD_INVIOMANUAL4].IsToolbar = true;
    CmdLin[MyGlb.CMD_INVIOMANUAL4].ShowNames = false;
    CmdLin[MyGlb.CMD_INVIOMANUAL4].ToolName = "Invio";
    CmdLin[MyGlb.CMD_INVIOMANUAL4].UseHilight = false;
    CmdLin[MyGlb.CMD_INVIOMANUAL4].Code = "INVIOMANUAL4";
    CmdLin[MyGlb.CMD_INVIOMANUAL4].Index = MyGlb.CMD_INVIOMANUAL4;
    CmdLin[MyGlb.CMD_INVIOMANUAL4].Level = 2;
    CmdLin[MyGlb.CMD_INVIOMANUAL4].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_INVIOMANUAL1] = new ACommand();
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].iGuid = "A8117149-BDCF-4F16-A3E1-FD1E75724AF8";
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].IdxForm = MyGlb.FRM_SPEDIZANDROI;
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].ToolCont = -2;
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].ToolContCode = "PAN_SPEDIZIONI";
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].Index = MyGlb.CMDS_INVIOMANUAL1;
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].SetNumCommands(2);
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].Caption = "Invio Manuale";
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].ToolTip = "Quali comandi saranno contenuti qui?";
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].Level = 1;
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].IsMenu = false;
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].IsToolbar = true;
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].ShowNames = false;
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].Code = "INVIOMANUAL1";
    CmdLin[MyGlb.CMD_INVIASUBITO1] = new ACommand();
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].AddCommand(CmdLin[MyGlb.CMD_INVIASUBITO1]);
    CmdLin[MyGlb.CMD_INVIASUBITO1].Parent = CmdSets[MyGlb.CMDS_INVIOMANUAL1];
    CmdLin[MyGlb.CMD_INVIASUBITO1].iGuid = "3D6C813D-299C-4AB7-A9F2-45AB5DA7EBCC";
    CmdLin[MyGlb.CMD_INVIASUBITO1].Caption = "Invia subito";
    CmdLin[MyGlb.CMD_INVIASUBITO1].ToolTip = "";
    CmdLin[MyGlb.CMD_INVIASUBITO1].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_INVIASUBITO1].IsMenu = false;
    CmdLin[MyGlb.CMD_INVIASUBITO1].IsToolbar = true;
    CmdLin[MyGlb.CMD_INVIASUBITO1].ShowNames = false;
    CmdLin[MyGlb.CMD_INVIASUBITO1].ToolName = "Invia";
    CmdLin[MyGlb.CMD_INVIASUBITO1].UseHilight = false;
    CmdLin[MyGlb.CMD_INVIASUBITO1].Code = "INVIASUBITO1";
    CmdLin[MyGlb.CMD_INVIASUBITO1].Index = MyGlb.CMD_INVIASUBITO1;
    CmdLin[MyGlb.CMD_INVIASUBITO1].Level = 2;
    CmdLin[MyGlb.CMD_INVIASUBITO1].InitStatus(true, true, false);
    CmdLin[MyGlb.CMD_TESTSPEDIZI1] = new ACommand();
    CmdSets[MyGlb.CMDS_INVIOMANUAL1].AddCommand(CmdLin[MyGlb.CMD_TESTSPEDIZI1]);
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].Parent = CmdSets[MyGlb.CMDS_INVIOMANUAL1];
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].iGuid = "0617D5A7-5B19-49B5-AF61-9341FD12D84E";
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].Caption = "Test spedizione";
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].ToolTip = "";
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].IsMenu = false;
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].IsToolbar = true;
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].ShowNames = false;
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].ToolName = "Test";
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].UseHilight = false;
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].Code = "TESTSPEDIZI1";
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].Index = MyGlb.CMD_TESTSPEDIZI1;
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].Level = 2;
    CmdLin[MyGlb.CMD_TESTSPEDIZI1].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET] = new ACommand();
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].iGuid = "D7D76643-BB5A-4309-A2DC-E0866699276F";
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].IdxForm = MyGlb.FRM_DEVIIDWINPHO;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].ToolCont = -2;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].ToolContCode = "PAN_DEVICETOKEN";
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].Index = MyGlb.CMDS_NUOVOCOMMSET;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].SetNumCommands(1);
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].Caption = "Nuovo Command Set";
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].ToolTip = "Quali comandi saranno contenuti qui?";
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].Level = 1;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].IsMenu = false;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].IsToolbar = true;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].ShowNames = false;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].Code = "NUOVOCOMMSET";
    CmdLin[MyGlb.CMD_INVIOMANUALE] = new ACommand();
    CmdSets[MyGlb.CMDS_NUOVOCOMMSET].AddCommand(CmdLin[MyGlb.CMD_INVIOMANUALE]);
    CmdLin[MyGlb.CMD_INVIOMANUALE].Parent = CmdSets[MyGlb.CMDS_NUOVOCOMMSET];
    CmdLin[MyGlb.CMD_INVIOMANUALE].iGuid = "7B14BCD1-C065-40DB-84F7-3821405B39DE";
    CmdLin[MyGlb.CMD_INVIOMANUALE].Caption = "Invio Manuale";
    CmdLin[MyGlb.CMD_INVIOMANUALE].ToolTip = "";
    CmdLin[MyGlb.CMD_INVIOMANUALE].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_INVIOMANUALE].IsMenu = false;
    CmdLin[MyGlb.CMD_INVIOMANUALE].IsToolbar = true;
    CmdLin[MyGlb.CMD_INVIOMANUALE].ShowNames = false;
    CmdLin[MyGlb.CMD_INVIOMANUALE].ToolName = "Invio";
    CmdLin[MyGlb.CMD_INVIOMANUALE].UseHilight = false;
    CmdLin[MyGlb.CMD_INVIOMANUALE].Code = "INVIOMANUALE";
    CmdLin[MyGlb.CMD_INVIOMANUALE].Index = MyGlb.CMD_INVIOMANUALE;
    CmdLin[MyGlb.CMD_INVIOMANUALE].Level = 2;
    CmdLin[MyGlb.CMD_INVIOMANUALE].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_INVIOMANUAL3] = new ACommand();
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].iGuid = "0E36A454-1797-4C48-93D5-3A3B065580F7";
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].IdxForm = MyGlb.FRM_SPEDIWINPHON;
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].ToolCont = -2;
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].ToolContCode = "PAN_SPEDIZIONI";
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].Index = MyGlb.CMDS_INVIOMANUAL3;
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].SetNumCommands(1);
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].Caption = "Invio Manuale";
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].ToolTip = "Quali comandi saranno contenuti qui?";
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].Level = 1;
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].IsMenu = false;
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].IsToolbar = true;
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].ShowNames = false;
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].Code = "INVIOMANUAL3";
    CmdLin[MyGlb.CMD_INVIASUBITO] = new ACommand();
    CmdSets[MyGlb.CMDS_INVIOMANUAL3].AddCommand(CmdLin[MyGlb.CMD_INVIASUBITO]);
    CmdLin[MyGlb.CMD_INVIASUBITO].Parent = CmdSets[MyGlb.CMDS_INVIOMANUAL3];
    CmdLin[MyGlb.CMD_INVIASUBITO].iGuid = "3A91A664-463B-4AA5-A250-88CCA8C072DF";
    CmdLin[MyGlb.CMD_INVIASUBITO].Caption = "Invia subito";
    CmdLin[MyGlb.CMD_INVIASUBITO].ToolTip = "";
    CmdLin[MyGlb.CMD_INVIASUBITO].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_INVIASUBITO].IsMenu = false;
    CmdLin[MyGlb.CMD_INVIASUBITO].IsToolbar = true;
    CmdLin[MyGlb.CMD_INVIASUBITO].ShowNames = false;
    CmdLin[MyGlb.CMD_INVIASUBITO].ToolName = "Invia";
    CmdLin[MyGlb.CMD_INVIASUBITO].UseHilight = false;
    CmdLin[MyGlb.CMD_INVIASUBITO].Code = "INVIASUBITO";
    CmdLin[MyGlb.CMD_INVIASUBITO].Index = MyGlb.CMD_INVIASUBITO;
    CmdLin[MyGlb.CMD_INVIASUBITO].Level = 2;
    CmdLin[MyGlb.CMD_INVIASUBITO].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2] = new ACommand();
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].iGuid = "EE343DEF-FA67-4C1E-AE2A-57A41E945782";
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].IdxForm = MyGlb.FRM_DEVIIDWINSTO;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].ToolCont = -2;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].ToolContCode = "PAN_DEVICETOKEN";
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].Index = MyGlb.CMDS_NUOVOCOMMSE2;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].SetNumCommands(1);
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].Caption = "Nuovo Command Set";
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].ToolTip = "Quali comandi saranno contenuti qui?";
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].Level = 1;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].IsMenu = false;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].IsToolbar = true;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].ShowNames = false;
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].Code = "NUOVOCOMMSE2";
    CmdLin[MyGlb.CMD_INVIOMANUAL5] = new ACommand();
    CmdSets[MyGlb.CMDS_NUOVOCOMMSE2].AddCommand(CmdLin[MyGlb.CMD_INVIOMANUAL5]);
    CmdLin[MyGlb.CMD_INVIOMANUAL5].Parent = CmdSets[MyGlb.CMDS_NUOVOCOMMSE2];
    CmdLin[MyGlb.CMD_INVIOMANUAL5].iGuid = "D376A28D-C110-4A33-8AAB-44CC27C9F817";
    CmdLin[MyGlb.CMD_INVIOMANUAL5].Caption = "Invio Manuale";
    CmdLin[MyGlb.CMD_INVIOMANUAL5].ToolTip = "";
    CmdLin[MyGlb.CMD_INVIOMANUAL5].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_INVIOMANUAL5].IsMenu = false;
    CmdLin[MyGlb.CMD_INVIOMANUAL5].IsToolbar = true;
    CmdLin[MyGlb.CMD_INVIOMANUAL5].ShowNames = false;
    CmdLin[MyGlb.CMD_INVIOMANUAL5].ToolName = "Invio";
    CmdLin[MyGlb.CMD_INVIOMANUAL5].UseHilight = false;
    CmdLin[MyGlb.CMD_INVIOMANUAL5].Code = "INVIOMANUAL5";
    CmdLin[MyGlb.CMD_INVIOMANUAL5].Index = MyGlb.CMD_INVIOMANUAL5;
    CmdLin[MyGlb.CMD_INVIOMANUAL5].Level = 2;
    CmdLin[MyGlb.CMD_INVIOMANUAL5].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_INVIOMANUAL2] = new ACommand();
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].iGuid = "C3671420-C616-49EE-945C-DF8EF3267914";
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].IdxForm = MyGlb.FRM_SPEDIWINSTOR;
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].ToolCont = -2;
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].ToolContCode = "PAN_SPEDIZIONI";
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].Index = MyGlb.CMDS_INVIOMANUAL2;
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].InitStatus(true, true, false);
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].SetNumCommands(1);
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].Caption = "Invio Manuale";
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].ToolTip = "Quali comandi saranno contenuti qui?";
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].Level = 1;
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].IsMenu = false;
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].IsToolbar = true;
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].ShowNames = false;
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].Code = "INVIOMANUAL2";
    CmdLin[MyGlb.CMD_INVIASUBITO2] = new ACommand();
    CmdSets[MyGlb.CMDS_INVIOMANUAL2].AddCommand(CmdLin[MyGlb.CMD_INVIASUBITO2]);
    CmdLin[MyGlb.CMD_INVIASUBITO2].Parent = CmdSets[MyGlb.CMDS_INVIOMANUAL2];
    CmdLin[MyGlb.CMD_INVIASUBITO2].iGuid = "D9F09F2F-3783-4ABA-A7ED-172B77A2F4AC";
    CmdLin[MyGlb.CMD_INVIASUBITO2].Caption = "Invia subito";
    CmdLin[MyGlb.CMD_INVIASUBITO2].ToolTip = "";
    CmdLin[MyGlb.CMD_INVIASUBITO2].RequireConfirmation = false;
    CmdLin[MyGlb.CMD_INVIASUBITO2].IsMenu = false;
    CmdLin[MyGlb.CMD_INVIASUBITO2].IsToolbar = true;
    CmdLin[MyGlb.CMD_INVIASUBITO2].ShowNames = false;
    CmdLin[MyGlb.CMD_INVIASUBITO2].ToolName = "Invia";
    CmdLin[MyGlb.CMD_INVIASUBITO2].UseHilight = false;
    CmdLin[MyGlb.CMD_INVIASUBITO2].Code = "INVIASUBITO2";
    CmdLin[MyGlb.CMD_INVIASUBITO2].Index = MyGlb.CMD_INVIASUBITO2;
    CmdLin[MyGlb.CMD_INVIASUBITO2].Level = 2;
    CmdLin[MyGlb.CMD_INVIASUBITO2].InitStatus(true, true, false);
    p.MenuType = 1;
    //
    ResetRoles(p);
  }

  // **********************************************
  // Appende gli oggetti al CmdHandler fornito
  // **********************************************
  public override int GetCmdSetBaseIndex()
  {
    return MyCmdHandler.CMDS_BASEIDX;
  }
  public override void SetCmdSetBaseIndex(int newIndex)
  {
    MyCmdHandler.CMDS_BASEIDX = newIndex;
  }
  public override int GetCmdBaseIndex()
  {
    return MyCmdHandler.CMD_BASEIDX;
  }
  public override void SetCmdBaseIndex(int newIndex)
  {
    MyCmdHandler.CMD_BASEIDX = newIndex;
  }
  public override void AppendTo(CmdHandler Dst)
  {
    // Se ho command set
    if (CmdSets.Length > 0)
    {
      // Se è la prima volta, appendo
      if (MyCmdHandler.CMDS_OFFSET == 0)
      {
        // Per cominciare appendo tutti i CmdSet contenuti in Dst dentro al mio array
        int idx = Dst.CmdSets.Length;
        if (idx == 0) idx = 1;    // L'array dei cmdset è 1-based
        //
        // Non ho mai caricato prima questo componente ma l'array che riceverà i miei oggetti
        // ha un baseidx diverso da 0 (questo può succedere se vengono caricati componenti dinamici
        // e vengono caricati in ordine diverso. Es: sessione 1 carica Comp1, sessione 2 carica Comp2
        // in questo caso la sessione 2 non ha mai caricato Comp1 ma se dovesse farlo deve esserci spazio
        // per i suoi oggetti nello stesso posto in cui erano prima!)
        // Quindi se il componente base ha delle zone che non possono essere occupate (causa componenti
        // già caricati in altre sessioni) sposto i miei oggetti in avanti di quell'offset così la
        // Append funziona correttamente
        int baseidx = Dst.GetCmdSetBaseIndex();
        if (baseidx != 0)
        {
          baseidx--;    // L'array dei cmdset è 1-based
          //
          // Baseidx è l'indice del primo slot libero. Shifto i miei oggetti in avanti di baseidx
          // (in altre parole inserisco baseidx nulli all'inizio dell'array)
          ACommand[] oldCmdSets = CmdSets;
          CmdSets = new ACommand[baseidx + oldCmdSets.Length];
          for (int i = baseidx; i < CmdSets.Length; i++)
            CmdSets[i] = oldCmdSets[i - baseidx];
          //
          // Questo è l'indice del mio primo oggetto
          MyCmdHandler.CMDS_OFFSET = baseidx;
          //
          idx = baseidx + 1;
          Array.Resize(ref Dst.CmdSets, CmdSets.Length);
        }
        else
          Array.Resize(ref Dst.CmdSets, idx + CmdSets.Length - 1);
        //
        for (int i = 1; i < CmdSets.Length; i++)
        {
          ACommand c = CmdSets[i];
          if (c == null)
            continue;
          //
          if (c.IdxForm > 0)
            c.IdxForm += MainFrm.CompOwner.iFrmOffs.intValue();   // Shifto le referenze alle form
          //
          c.Index = idx;
          Dst.CmdSets[idx++] = c;
        }
        //
        // Se non l'ho ancora fatto, il mio offset è il numero di commandset di tutti i miei padri...
        // Per calcolarlo guardo a dove è finito il mio primo commandset (l'elemento 0 è NULL)
        // Quello è l'offset dei miei commandset rispetto all'array che contiene tutti i commandset di tutti i componenti
        if (MyCmdHandler.CMDS_OFFSET == 0)
          MyCmdHandler.CMDS_OFFSET = CmdSets[1].Index - 1;
        //
        // Shifto tutte le costanti contenute in MyGlb
        String tn = (MainFrm.CompNameSpace != null ? MainFrm.CompNameSpace + "." : "");
        FieldInfo[] props = Assembly.GetExecutingAssembly().GetType(tn + "MyGlb").GetFields();
        for (int j = 0; j < props.Length; j++)
        {
          FieldInfo p = props[j];
          if (p.Name.StartsWith("CMDS_") || p.Name.Equals("MAX_COMMAND_SETS"))
            p.SetValue(null, ((int)p.GetValue(null)) + MyCmdHandler.CMDS_OFFSET);
        }
        //
        // Aggiorno l'indice di "riempimento" del DST. Se verrà caricato un nuovo componente 
        // i suoi oggetti dovranno finire dopo il mio ultimo oggetto
        Dst.SetCmdSetBaseIndex(Dst.CmdSets.Length);
      }
      else // Il componente è già stato inizializzato in precedenza... infilo i CmdSet dove li ho messi l'ultima volta
      {
        // L'array di mio padre potrebbe essere più grande del mio se i componenti sono "dinamici" e vengono caricati in un 
        // ordine diverso da quello precedente (es: app->cmp1->cmp2 e poi, in una sessione differente app->cmp2->cmp1)
        Array.Resize(ref Dst.CmdSets, Math.Max(CmdSets.Length, Dst.CmdSets.Length));
        Array.Copy(CmdSets, MyCmdHandler.CMDS_OFFSET + 1, Dst.CmdSets, MyCmdHandler.CMDS_OFFSET + 1, CmdSets.Length - (MyCmdHandler.CMDS_OFFSET + 1));
      }
    }
    //
    // Se ho comandi
    if (CmdLin.Length > 0)
    {
      // Poi proseguo con i comandi
      // Se è la prima volta, appendo
      if (MyCmdHandler.CMD_OFFSET == 0)
      {
        int idx = Dst.CmdLin.Length;
        if (idx == 0) idx = 1;    // L'array dei cmdset è 1-based
        //
        // Non ho mai caricato prima questo componente ma l'array che riceverà i miei oggetti
        // ha un baseidx diverso da 0 (questo può succedere se vengono caricati componenti dinamici
        // e vengono caricati in ordine diverso. Es: sessione 1 carica Comp1, sessione 2 carica Comp2
        // in questo caso la sessione 2 non ha mai caricato Comp1 ma se dovesse farlo deve esserci spazio
        // per i suoi oggetti nello stesso posto in cui erano prima!)
        // Quindi se il componente base ha delle zone che non possono essere occupate (causa componenti
        // già caricati in altre sessioni) sposto i miei oggetti in avanti di quell'offset così la
        // Append funziona correttamente
        int baseidx = Dst.GetCmdBaseIndex();
        if (baseidx != 0)
        {
          baseidx--;    // L'array dei cmdset è 1-based
          //
          // Baseidx è l'indice del primo slot libero. Shifto i miei oggetti in avanti di baseidx
          // (in altre parole inserisco baseidx nulli all'inizio dell'array)
          ACommand[] oldCmdLin = CmdLin;
          CmdLin = new ACommand[baseidx + oldCmdLin.Length];
          for (int i = baseidx; i < CmdLin.Length; i++)
            CmdLin[i] = oldCmdLin[i - baseidx];
          //
          // Questo è l'indice del mio primo oggetto
          MyCmdHandler.CMD_OFFSET = baseidx;
          //
          idx = baseidx + 1;
          Array.Resize(ref Dst.CmdLin, CmdLin.Length);
        }
        else
          Array.Resize(ref Dst.CmdLin, idx + CmdLin.Length - 1);
        //
        for (int i = 1; i < CmdLin.Length; i++)
        {
          ACommand c = CmdLin[i];
          if (c == null)
            continue;
          //
          if (c.IdxForm > 0)
            c.IdxForm += MainFrm.CompOwner.iFrmOffs.intValue();   // Shifto le referenze alle form
          //
          c.Index = idx;
          Dst.CmdLin[idx++] = c;
        }
        //
        // Se non l'ho ancora fatto, il mio offset è il numero di comandi di tutti i miei padri...
        // Per calcolarlo guardo a dove è finito il mio primo comando (l'elemento 0 è NULL)
        // Quello è l'offset dei miei comandi rispetto all'array che contiene tutti i comandi di tutti i componenti
        if (MyCmdHandler.CMD_OFFSET == 0)
          MyCmdHandler.CMD_OFFSET = CmdLin[1].Index - 1;
        //
        // Shifto tutte le costanti contenute in MyGlb
        String tn = (MainFrm.CompNameSpace != null ? MainFrm.CompNameSpace + "." : "");
        FieldInfo[] props = Assembly.GetExecutingAssembly().GetType(tn + "MyGlb").GetFields();
        for (int j = 0; j < props.Length; j++)
        {
          FieldInfo p = props[j];
          if (p.Name.StartsWith("CMD_") || p.Name.Equals("MAX_COMMANDS"))
            p.SetValue(null, ((int)p.GetValue(null)) + MyCmdHandler.CMD_OFFSET);
        }
        //
        // Aggiorno l'indice di "riempimento" del DST. Se verrà caricato un nuovo componente 
        // i suoi oggetti dovranno finire dopo il mio ultimo oggetto
        Dst.SetCmdBaseIndex(Dst.CmdLin.Length);
      }
      else  // Il componente è già stato inizializzato in precedenza... infilo i comandi dove li ho messi l'ultima volta
      {
        // L'array di mio padre potrebbe essere più grande del mio se i componenti sono "dinamici" e vengono caricati in un 
        // ordine diverso da quello precedente (es: app->cmp1->cmp2 e poi, in una sessione differente app->cmp2->cmp1)
        Array.Resize(ref Dst.CmdLin, Math.Max(CmdLin.Length, Dst.CmdLin.Length));
        Array.Copy(CmdLin, MyCmdHandler.CMD_OFFSET + 1, Dst.CmdLin, MyCmdHandler.CMD_OFFSET + 1, CmdLin.Length - (MyCmdHandler.CMD_OFFSET + 1));
      }
    }
  }
}
