using AntDesign;
using AntDesign.JsInterop;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Volo.Abp;
using Zero.Abp.AntBlazor.Layout.Core.LayoutConfig;

namespace Zero.Abp.AntBlazor.Layout
{
    public partial class LayoutStateProvider
    {
        public LayoutSettings Settings { get; internal set; }

        #region 
        public int SiderWidth { get; internal set; } = 208;

        public bool HasHeader { get; internal set; }  

        public bool HasSiderMenu { get; internal set; }

        public bool HasPageContainer { get; internal set; }

        public bool HasPageFooterToolbar { get; internal set; } 
        #endregion


        public bool IsMobile => (ScreenSize == BreakpointType.Sm || ScreenSize == BreakpointType.Xs) && !DisableMobile;

        #region 
        protected BreakpointType ScreenSize { get; set; } = BreakpointType.Lg;//useAntdMediaQuery();

        private static readonly BreakpointType[] _breakpoints = new[] {
            BreakpointType.Xs, BreakpointType.Sm,
            BreakpointType.Md, BreakpointType.Lg,
            BreakpointType.Xl, BreakpointType.Xxl
        };

        private async Task InitOptimizeSize()
        {
            if (!DisableMobile)
            {
                var dimensions = await JsInvokeAsync<Window>(JSInteropConstants.GetWindow);
                DomEventListener.AddShared<Window>("window", "resize", OnResize);
                OptimizeSize(dimensions.InnerWidth);
            }
        }
        private void OnResize(Window window)
        {
            OptimizeSize(window.InnerWidth);
        }
        private void OptimizeSize(decimal windowWidth)
        {
            BreakpointType actualBreakpoint = _breakpoints[^1];
            for (int i = 0; i < _breakpoints.Length; i++)
            {
                if (windowWidth <= (int)_breakpoints[i] && (windowWidth >= (i > 0 ? (int)_breakpoints[i - 1] : 0)))
                {
                    actualBreakpoint = _breakpoints[i];
                }
            }
            ScreenSize = actualBreakpoint;

            InvokeStateHasChanged();
        }
        #endregion


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await InitOptimizeSize();
            }
            await base.OnAfterRenderAsync(firstRender);
        }


        [Inject] protected IDomEventListener DomEventListener { get; set; }

        protected override void Dispose(bool disposing)
        {
            DomEventListener?.Dispose();
            base.Dispose(disposing);
        }

        private bool isLoaded;

        [Inject] protected ILayoutConfigProvider LayoutConfigProvider { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            Settings = await LayoutConfigProvider.GetSettingsAsync();
            await UpdateThemeAsync();
            isLoaded = true;
        }


        public async Task UpdateSettingAsync<TValue>(Expression<Func<LayoutSettings, TValue>> propertySelector, TValue newValue, Func<TValue> currentValue = null)
        {
            if (currentValue?.Invoke()?.Equals(newValue) ?? false) { return; }
            ObjectHelper.TrySetProperty(Settings, propertySelector, () => newValue);

            NotifyStateChanged();

            var fieldName = (propertySelector.Body as MemberExpression)?.Member?.Name;
            if (fieldName == nameof(LayoutSettings.Layout))
            {
                if (Settings.Layout == Layout.Side.Name)
                {
                    Settings.HeaderTheme = "light";
                    Settings.SidebarTheme = "dark";
                    Settings.SplitMenus = false;
                }
                if (Settings.Layout == Layout.Top.Name)
                {
                    Settings.SplitMenus = false;
                    Settings.HeaderTheme = "dark";

                    //Settings.SidebarTheme = "light";//
                    //Settings.FixedSidebar = false;//
                    //Settings.MenuRender = false;
                    //Settings.MenuHeaderRender = false;
                }
                if (Settings.Layout == Layout.Mix.Name)
                {
                    Settings.FixedHeader = true;
                    Settings.HeaderTheme = "dark";
                    Settings.SidebarTheme = "light";
                }
            }
            var themeFieldNames = new List<string> { nameof(LayoutSettings.PrimaryColor), nameof(LayoutSettings.DarkTheme), nameof(LayoutSettings.CompactTheme) };
            if (themeFieldNames.Contains(fieldName)) { await UpdateThemeAsync(); }
            await Task.CompletedTask;
        }

        public async Task UpdateThemeAsync()
        {
            var primaryColor = Settings.PrimaryColor == "default" ? null : Settings.PrimaryColor;
            var fileNameArr = new List<string>();
            fileNameArr.AddIf(Settings.CompactTheme, "compact");
            fileNameArr.AddIf(Settings.DarkTheme, "dark");
            fileNameArr.AddIf(!primaryColor.IsNullOrWhiteSpace(), primaryColor);
            if (fileNameArr.IsNullOrEmpty()) { _themeUrl = "#"; }
            else
            {
                var fileName = string.Join("-", fileNameArr);
                _themeUrl = $"/_content/Zero.Abp.AntBlazor.Layout/theme/{fileName}.css";
            }
            await NotifyThemeChanged(_themeUrl);
        }


        protected string _themeUrl;
        protected ElementReference _themeRef;
        private async Task NotifyThemeChanged(string _themeUrl)
        {
            await JsInvokeAsync(JSInteropConstants.AddElementTo, _themeRef, "head");
        }
        private void NotifyStateChanged()
        {
            StateHasChanged();
        }
    }
}
