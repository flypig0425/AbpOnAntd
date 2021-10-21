using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;
using Zero.Abp.AntBlazor.Layout.Core;

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
        [Parameter] public bool DisableContentMargin { get; set; }
        [Parameter] public int SiderWidth { get; set; } = 208;
        [Parameter] public string ContentStyle { get; set; }

        [Parameter] public ApplicationMenuItemList MenuData { get; set; }

        private bool IsSplitMenus => Settings.SplitMenus && (/*OpenKeys != false ||*/ IsMixLayout) && !IsMobile;

        protected string[] TopSelectedKeys { get; set; }
        protected string[] SiderSelectedKeys { get; set; }

        [Inject] protected NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            MatchMenuKeys();
            SetLayoutState();
            NavigationManager.LocationChanged += OnLocationChanged;
        }

        protected override void Dispose(bool disposing)
        {
            if (NavigationManager != null)
            {
                NavigationManager.LocationChanged -= OnLocationChanged;
            }
            base.Dispose(disposing);
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            MatchMenuKeys();
            SetLayoutState();
            InvokeStateHasChanged();
        }

        private void SetLayoutState()
        {
            if (LayoutContextProvider != null)
            {
                LayoutContextProvider.HasHeader = HeaderDom != null;
                LayoutContextProvider.HasSiderMenu = HasSiderMenu;
                LayoutContextProvider.SiderWidth = SiderWidth;
            }
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
        int PaddingLeft => HasLeftPadding ? (Collapsed ? 48 : SiderWidth) : 0;


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
