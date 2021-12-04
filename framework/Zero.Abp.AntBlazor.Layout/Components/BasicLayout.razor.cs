using AntDesign;
using AntDesign.JsInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Threading;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AntBlazor.Layout
{
    public partial class BasicLayout
    {
        #region [@bind-Collapsed,OnCollapse]
        [Parameter] public bool Collapsed { get; set; }
        [Parameter] public EventCallback<bool> CollapsedChanged { get; set; }
        [Parameter] public EventCallback<bool> OnCollapse { get; set; }
        private async Task HandleCollapse(bool collapsed)
        {
            Collapsed = collapsed;
            if (OnCollapse.HasDelegate) { await OnCollapse.InvokeAsync(collapsed); }
            if (CollapsedChanged.HasDelegate) { await CollapsedChanged.InvokeAsync(collapsed); }
        }
        #endregion

        #region 
        [Parameter] public RenderFragment HeaderContent { get; set; }
        [Parameter] public RenderFragment FooterContent { get; set; }
        [Parameter] public RenderFragment MenuContent { get; set; }

        [Parameter] public List<RenderFragment> HeaderRightItemRenders { get; set; }
        [Parameter] public RenderFragment HeaderRightContent { get; set; }
        [Parameter] public RenderFragment MenuExtraRender { get; set; }
        #endregion

        [Parameter] public bool Pure { get; set; }
        [Parameter] public bool Loading { get; set; }
        [Parameter] public bool DisableMobile { get; set; }
        [Parameter] public bool DisableContentMargin { get; set; }
        [Parameter] public string ContentStyle { get; set; }
        [Parameter] public ApplicationMenuItemList MenuData { get; set; }



        public bool IsMobile => (ScreenSize == BreakpointType.Sm || ScreenSize == BreakpointType.Xs) && !DisableMobile;

        private bool IsSplitMenus => Settings.SplitMenus && (/*OpenKeys != false ||*/ IsMixLayout) && !IsMobile;

        protected string[] TopSelectedKeys { get; set; }
        protected string[] SiderSelectedKeys { get; set; }


        [Inject] protected IDomEventListener DomEventListener { get; set; }
        #region [ScreenSize,OnResize,AddResizeListener]
        public event Action<Window> OnResize;
        public BreakpointType ScreenSize { get; internal set; } = BreakpointType.Lg;
        public async Task AddResizeListenerAsync()
        {
            DomEventListener.AddShared<Window>("window", "resize", WindowResize);
            var dimensions = await JsInvokeAsync<Window>(JSInteropConstants.GetWindow);
            OptimizeSize(dimensions.InnerWidth);
        }

        private static readonly BreakpointType[] _breakpoints = new[] {
            BreakpointType.Xs, BreakpointType.Sm,
            BreakpointType.Md, BreakpointType.Lg,
            BreakpointType.Xl, BreakpointType.Xxl
        };
        private void WindowResize(Window window)
        {
            OnResize?.Invoke(window);
            OptimizeSize(window.InnerWidth);
        }
        private void OptimizeSize(decimal windowWidth)
        {
            BreakpointType actualBreakpoint = _breakpoints[^1];
            for (int i = 0; i < _breakpoints.Length; i++)
            {
                var maxWidth = (int)_breakpoints[i];
                var minWidth = (i > 0 ? (int)_breakpoints[i - 1] : 0);
                if (windowWidth <= maxWidth && windowWidth >= minWidth)
                {
                    actualBreakpoint = _breakpoints[i];
                    break;
                }
            }
            ScreenSize = actualBreakpoint;
            InvokeStateHasChanged();
        }
        #endregion

        [Inject] protected NavigationManager NavigationManager { get; set; }
        [Inject] protected MessageService MessageService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            MatchMenuKeys();
            NavigationManager.LocationChanged += OnLocationChanged;
            LayoutConfigProvider.SettingsChanged += OnSettingsChanged;
            LayoutConfigProvider.ThemeChanged += OnThemeChanged;
            await LayoutConfigProvider?.UpdateThemeAsync();
        }
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender) {await AddResizeListenerAsync(); }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected override void Dispose(bool disposing)
        {
            if (NavigationManager != null)
            {
                NavigationManager.LocationChanged -= OnLocationChanged;
            }
            if (LayoutConfigProvider != null)
            {
                LayoutConfigProvider.SettingsChanged -= OnSettingsChanged;
                LayoutConfigProvider.ThemeChanged -= OnThemeChanged;
            }
            DomEventListener?.Dispose();
            base.Dispose(disposing);
        }

        protected string _themeUrl;
        protected ElementReference _themeRef;
        private void OnThemeChanged(string themeUrl)
        {
            _themeUrl = themeUrl;
            _ = JsInvokeAsync(JSInteropConstants.AddElementTo, _themeRef, "head");
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            MatchMenuKeys();
            InvokeStateHasChanged();
        }

        private void MatchMenuKeys()
        {
            if (IsSplitMenus)
            {
                var matchMenuKeys = NavigationManager.GetMatchMenuKeys(MenuData, true);
                TopSelectedKeys = matchMenuKeys;
                SiderSelectedKeys = matchMenuKeys;
            }
        }

        #region [StyleOrClass]
        bool HasSiderMenu => (!IsTopLayout || IsMixLayout && Settings.SplitMenus) && (SiderMenuDom != null);
        bool HasLeftPadding => HasSiderMenu && Settings.FixedSidebar && !IsMobile;
        int PaddingLeft => HasLeftPadding ? (Collapsed ? CollapsedWidth : Settings.SiderWidth) : 0;


        private readonly bool isChildrenLayout = false;
        private readonly string layoutCls = "ant-layout";
        private string WeakModeStyle => StyleValues(("filter: invert(80%)", Settings.ColorWeak));
        private string GenLayoutStyle => StyleValues("position: relative"
            , ("min-height:0px", isChildrenLayout || (ContentStyle?.Contains("min-height") ?? false))
            , ($"padding-left: {PaddingLeft}px", Settings.MenuRender)
            );


        private string BaseClassName => $"{PrefixCls}-basicLayout";
        private string LayoutClass => ClassNames("ant-design-pro", BaseClassName
            , ($"{BaseClassName}-top-menu", IsTopLayout)
            , ($"{BaseClassName}-is-children", isChildrenLayout)
            , ($"{BaseClassName}-fix-siderbar", Settings.FixedSidebar)
            , ($"{BaseClassName}-mobile", IsMobile)
            );
        private string ContentClass => ClassNames($"{BaseClassName}-content"
            , ($"{BaseClassName}-has-header", Settings.HeaderRender)
            , ($"{BaseClassName}-content-disable-margin", DisableContentMargin)
            );
        #endregion
    }
}
