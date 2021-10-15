using AntDesign;
using AntDesign.JsInterop;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AspNetCore.Components.Web.AntdTheme
{
    public partial class BasicLayout
    {
        #region MyRegion
        public bool HasHeader => HeaderDom != null;
        public bool HasFooterToolbar { get; set; }
        #endregion


        [Parameter] public bool Pure { get; set; }
        [Parameter] public bool Loading { get; set; }
        [Parameter] public bool DisableMobile { get; set; }
        [Parameter] public bool DisableContentMargin { get; set; }
        [Parameter] public int SiderWidth { get; set; } = 208;
        [Parameter] public string ContentStyle { get; set; }

        [Parameter] public bool Collapsed { get; set; }
        [Parameter] public EventCallback<bool> CollapsedChanged { get; set; }
        [Parameter] public EventCallback<bool> OnCollapse { get; set; }
        private async Task HandleCollapse(bool collapsed)
        {
            Collapsed = collapsed;
            if (OnCollapse.HasDelegate) { await OnCollapse.InvokeAsync(collapsed); }
            if (CollapsedChanged.HasDelegate) { await CollapsedChanged.InvokeAsync(collapsed); }
        }

        protected BreakpointType ScreenSize { get; set; } = BreakpointType.Lg;//useAntdMediaQuery();
        public bool IsMobile => (ScreenSize == BreakpointType.Sm || ScreenSize == BreakpointType.Xs) && !DisableMobile;


        private bool IsSplitMenus => Settings.SplitMenus && (/*OpenKeys != false ||*/ Settings.Layout == Layout.Mix.Name) && !IsMobile;
        public string[] TopSelectedKeys { get; set; }
        public string[] SiderSelectedKeys { get; set; }
        protected ApplicationMenuItemList MenuData { get; set; }

        [Inject] protected IMenuManager MenuManager { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }
        [Inject] protected IDomEventListener DomEventListener { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            MenuData = await MenuManager.GetMenuDataAsync();
            if (IsSplitMenus)
            {
                var matchMenuKeys = NavigationManager.GetMatchMenuKeys(MenuData, true);
                TopSelectedKeys = matchMenuKeys;
            }
            LayoutState.OnThemeChangedAsync += OnChangeThemeAsync;
            LayoutState.OnChange += OnSettingsChanged;
            await LayoutState.UpdateThemeAsync();
        }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                var dimensions = await JsInvokeAsync<Window>(JSInteropConstants.GetWindow);
                DomEventListener.AddShared<Window>("window", "resize", OnResize);
                OptimizeSize(dimensions.InnerWidth);
            }
            await base.OnAfterRenderAsync(firstRender);
        }

        protected override void Dispose(bool disposing)
        {
            DomEventListener?.Dispose();
            if (LayoutState != null)
            {
                LayoutState.OnThemeChangedAsync -= OnChangeThemeAsync;
                LayoutState.OnChange -= OnSettingsChanged;
            }
            base.Dispose(disposing);
        }

        private void OnResize(Window window)
        {
            OptimizeSize(window.InnerWidth);
        }

        private static readonly BreakpointType[] _breakpoints = new[] {
            BreakpointType.Xs, BreakpointType.Sm,
            BreakpointType.Md, BreakpointType.Lg,
            BreakpointType.Xl, BreakpointType.Xxl
        };
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
            StateHasChanged();
        }

        protected string _themeUrl;
        protected ElementReference _themeRef;
        protected virtual async Task OnChangeThemeAsync(string styleUrl)
        {
            _themeUrl = styleUrl;
            await JsInvokeAsync(JSInteropConstants.AddElementTo, _themeRef, "head");
        }

        #region StyleOrClass
        private readonly bool isChildrenLayout = false;

        private readonly string layoutCls = "ant-layout";


        public bool HasSiderMenu => (Settings.Layout != Layout.Top.Name || Settings.Layout == Layout.Mix.Name && Settings.SplitMenus) && (SiderMenuDom != null);
        bool HasLeftPadding => HasSiderMenu && Settings.FixedSidebar && !IsMobile;
        int PaddingLeft => HasLeftPadding ? (Collapsed ? 48 : SiderWidth) : 0;

        private string WeakModeStyle => StyleValues(("filter: invert(80%)", Settings.ColorWeak));
        private string GenLayoutStyle => StyleValues("position: relative"
            , ("min-height:0px", isChildrenLayout || (ContentStyle?.Contains("min-height") ?? false))
            , ($"padding-left: {PaddingLeft}px", Settings.MenuRender)
            );

        private string BaseClassName => $"{PrefixCls}-basicLayout";

        private string LayoutClass => ClassNames("ant-design-pro", BaseClassName, $"screen-{ScreenSize}"
            , ($"{BaseClassName}-top-menu", Settings.Layout == Layout.Top.Name)
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
