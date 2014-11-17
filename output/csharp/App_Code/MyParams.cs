// **********************************************
// Global parameters
// Instant WEB Application: www.progamma.com
// Project : Mobile Manager
// **********************************************
using System;
using com.progamma;
using com.progamma.ids;

// **********************************************
// Classe base della servlet
// **********************************************
[Serializable]
public class MyParams : Params
{
  // Compilation Predefined Constants
  public String Theme = "seattle";
  public String UseIDTag = "YES";
  public String UseRD = "YES";
  public String PanelNewInsertMode = "NO";
  public String UseDoubleClick = "YES";
  public String UseFK = "YES";
  public String PanelsUseTab = "YES";
  public String PanelsSortAlways = "NO";
  public String PanelsLikeSearch = "YES";
  public String EnablePanelMultiSelection = "YES";
  public String ActivePanelMultiSelection = "NO";
  public String ShowPanelMultiSelection = "NO";
  public String ShowDisabledFieldActivator = "YES";
  public String ConvertNullToValue = "YES";
  public String HtmlConstraints = "NONE";
  public String UseCollapsableFrames = "YES";
  public int ResponseBufferSize = 48;
  public String ShowRD = "NO";
  public String LANGUAGE = "ITA";
  public String IWCacheControl = "CACHE";
  public String CompressResponse = "YES";
  public String AutoSaveType = "NONE";
  public String ShowFieldImageInValue = "YES";
  public String UseDecimalDot = "NO";
  public String UseFastRowSelector = "YES";
  public String TruePopup = "YES";
  public String UseClientMask = "YES";
  public String NativeBlob = "NO";
  public String PanelQBEEmpty = "YES";
  public String InfoMessages = "YES";
  public String PanelConfirmDelete = "YES";
  public String PanelFreezeWhenHidden = "YES";
  public String PanelIsLockable = "NO";
  public int ChangeRowDelay = 300;
  public String SmartLookupIcon = "NO";
  public String ShowDisabledIcons = "NO";
  public String RightAlignedIcons = "NO";
  public String AllowMasterPanelNav = "YES";
  public String ToolbarPosition = "LEFT";
  public String UseRD3 = "YES";
  public String BorderType = "DEFAULT";
  public int TooltipErrorMode = 1;
  public String EnableGFX = "YES";
  public String EnableSound = "YES";
  public String EnableRichTooltip = "YES";
  public String MultiSelectionComboBox = "YES";
  public String UseCollapsableGroups = "NO";
  public String PanelHighlightDelete = "YES";
  public String SelectAllOnlyVisible = "NO";
  public String TooltipOnEachRow = "NO";
  public String EnableFrameResize = "NO";
  public String QBETrueLessThan = "YES";
  public String PanelEnableInsertWhenLocked = "YES";
  public String LKEDOAllProperties = "YES";
  public String LoadingPolicy = "AUTO";
  public String PullToRefresh = "YES";
  public String UseHTML5Upload = "NO";
  public String CompletePanelBorders = "NO";
  public String UseZones = "NO";
  public String EnableVoice = "NO";
  public String UseIDEditor = "NO";
  public bool UseRD4 = false;
  public bool UseDynVS = true;


  public MyParams()
  {
    base.MAX_FORMS = MyGlb.MAX_FORMS;
    base.MAX_INDICATORS = MyGlb.MAX_INDICATORS;
    base.MAX_COMMANDS = MyGlb.MAX_COMMANDS;
    base.MAX_COMMAND_SETS = MyGlb.MAX_COMMAND_SETS;
    base.MAX_TIMERS = MyGlb.MAX_TIMERS;
    base.ICDebug = this.ICDebug;
    base.DemoMode = this.DemoMode;
    base.UseFastRowSelector = this.UseFastRowSelector.Equals("YES");
    base.PanelIsLockable = this.PanelIsLockable.Equals("YES");
    base.InfoMessages = this.InfoMessages.Equals("YES");
    base.AutoDynRows = 0;
    base.ActImgWidth = 17;
    base.Theme = this.Theme;
    base.UseSmallIcon = (("NO").Equals("YES"));
    base.NativeBlob = this.NativeBlob.Equals("YES");
    base.UseClientMask = this.UseClientMask.Equals("YES");
    base.DefaultDateMask = "dd/mm/yyyy";
    base.DefaultTimeMask = "hh:nn";
    base.DefaultCurrencyMask = "#,###,###,##0.00";
    base.DefaultFloatMask = "#,###,###,###.####";
    base.UseDecimalDot = this.UseDecimalDot.Equals("YES");
    base.PanelConfirmDelete = this.PanelConfirmDelete.Equals("YES");
    base.PanelHighlightDelete = this.PanelHighlightDelete.Equals("YES");
    base.ShowFieldImageInValue = this.ShowFieldImageInValue.Equals("YES");
    base.ShowDisabledFieldActivator = this.ShowDisabledFieldActivator.Equals("YES");
    base.IWCacheControl = this.IWCacheControl;
    base.AutoSaveType = this.AutoSaveType;
    base.UseRD = this.UseRD.Equals("YES");
    base.TruePopup = this.TruePopup.Equals("YES");
    base.UseIDTag = this.UseIDTag.Equals("YES");
    base.ShowRD = this.ShowRD.Equals("YES");
    base.UseFK = this.UseFK.Equals("YES");
    base.UseDoubleClick = this.UseDoubleClick.Equals("YES");
    base.PanelsSortAlways = this.PanelsSortAlways.Equals("YES");
    base.EditUpdErrorMode = 1;
    base.EditInsErrorMode = 2;
    base.FinalUpdErrorMode = 0;
    base.FinalInsErrorMode = 0;
    base.PanelCommandMask = -1;
    base.EnablePanelMultiSelection = this.EnablePanelMultiSelection.Equals("YES");
    base.ShowPanelMultiSelection = this.ShowPanelMultiSelection.Equals("YES");
    base.ActivePanelMultiSelection = this.ActivePanelMultiSelection.Equals("YES");
    base.SelectAllOnlyVisible = this.SelectAllOnlyVisible.Equals("YES");
    base.PanelQBEEmpty = this.PanelQBEEmpty.Equals("YES");
    base.HelpFeatures = "";
    base.UseCollapsableFrames = this.UseCollapsableFrames.Equals("YES");
    base.HtmlConstraints = this.HtmlConstraints.Equals("NONE") ? MyGlb.WEBVALID_NONE : MyGlb.WEBVALID_STRICT;
    base.ChangeRowDelay = this.ChangeRowDelay;
    base.SmartLookupIcon = this.SmartLookupIcon;
		base.ShowDisabledIcons = this.ShowDisabledIcons.Equals("YES");
		base.RightAlignedIcons = this.RightAlignedIcons.Equals("YES");
		base.AllowMasterPanelNav = this.AllowMasterPanelNav.Equals("YES");
		base.PanelsLikeSearch = this.PanelsLikeSearch.Equals("YES");
		base.UseRD3 = this.UseRD3.Equals("YES");
		base.UseRD4 = this.UseRD4;
		base.PullToRefresh = this.PullToRefresh.Equals("YES");
    if (this.LoadingPolicy.Equals("MANUAL"))
      base.LoadingPolicy = 0;
    if (this.LoadingPolicy.Equals("AUTO"))
      base.LoadingPolicy = 1;
    if (this.LoadingPolicy.Equals("CONTINUOUS"))
      base.LoadingPolicy = 2;
    //
    if (this.ToolbarPosition.Equals("NONE"))
      base.ToolbarPosition = MyGlb.FORMTOOL_NONE;
    if (this.ToolbarPosition.Equals("LEFT"))
      base.ToolbarPosition = MyGlb.FORMTOOL_LEFT;
    if (this.ToolbarPosition.Equals("RIGHT"))
      base.ToolbarPosition = MyGlb.FORMTOOL_RIGHT;
    if (this.ToolbarPosition.Equals("DISTRIBUTED"))
      base.ToolbarPosition = MyGlb.FORMTOOL_DISTRUB;
		//
		base.BorderType = Theme.Equals("seattle") ? MyGlb.BORDER_THICK : MyGlb.BORDER_THIN;
		if (this.BorderType.Equals("NONE"))
			base.BorderType = MyGlb.BORDER_NONE;
		if (this.BorderType.Equals("THICK"))
			base.BorderType = MyGlb.BORDER_THICK;
		if (this.BorderType.Equals("THIN"))
			base.BorderType = MyGlb.BORDER_THIN;
    //
    base.TooltipErrorMode = this.TooltipErrorMode;
    base.MaxRequestSize = 102400;
    base.UseDynVS = this.UseDynVS;
    base.EnableGFX = this.EnableGFX.Equals("YES");
    base.EnableSound = this.EnableSound.Equals("YES");
    base.EnableRichTooltip = this.EnableRichTooltip.Equals("YES");
    base.MultiSelectionComboBox = this.MultiSelectionComboBox.Equals("YES");
    base.UseCollapsableGroups = this.UseCollapsableGroups.Equals("YES");
    base.TooltipOnEachRow = this.TooltipOnEachRow.Equals("YES");
    //
    base.EnableFrameResize = this.EnableFrameResize.Equals("YES");
    base.QBETrueLessThan = this.QBETrueLessThan.Equals("YES");
    base.PanelEnableInsertWhenLocked = this.PanelEnableInsertWhenLocked.Equals("YES");
    //
    base.LKEDOAllProperties = this.LKEDOAllProperties.Equals("YES");
    //
    base.UseHTML5Upload = this.UseHTML5Upload.Equals("YES");
    base.CompletePanelBorders = this.CompletePanelBorders.Equals("YES");
    base.UseZones = this.UseZones.Equals("YES");
    base.EnableVoice = this.EnableVoice.Equals("YES");
    base.UseIDEditor = this.UseIDEditor.Equals("YES");
    //
    // Se non sono in un componente (ma sono parte della App_Code.dll)
    if (this.GetType().Assembly.GetName().Name.IndexOf("App_Code") != -1)
    {
      IDVariant.ConvertNullToValue = this.ConvertNullToValue.Equals("YES");
      IDVariant.InitDefaultMasks(base.DefaultDateMask, base.DefaultTimeMask);
    }
  }
}
