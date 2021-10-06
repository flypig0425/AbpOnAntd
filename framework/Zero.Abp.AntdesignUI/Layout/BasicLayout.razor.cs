using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AntdesignUI.Layout
{
    public partial class BasicLayout
    {
        [Parameter] public bool Pure { get; set; }
        [Parameter] public bool Loading { get; set; }
        [Parameter] public bool DisableMobile { get; set; }
        [Parameter] public bool DisableContentMargin { get; set; }
        [Parameter] public int SiderWidth { get; set; } = 208;
        [Parameter] public string ContentStyle { get; set; }
        [Parameter] public bool Collapsed { get; set; }
        [Parameter] public EventCallback<bool> OnCollapse { get; set; }


        protected string ColSize { get; set; } = "lg";//useAntdMediaQuery();
        protected bool IsMobile => (ColSize == "sm" || ColSize == "xs") && !DisableMobile;


        private bool IsSplitMenus => SplitMenus && (/*OpenKeys != false ||*/ Layout == Layout.Mix) && !IsMobile;
        public string[] TopSelectedKeys { get; set; }
        public string[] SiderSelectedKeys { get; set; }
        protected ApplicationMenuItemList MenuData { get; set; }

        [Inject] protected IMenuManager MenuManager { get; set; }
        [Inject] protected NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            MenuData = await MenuManager.GetMenuDataAsync();
            if (IsSplitMenus)
            {
                var matchMenuKeys = NavigationManager.GetMatchMenuKeys(MenuData, true);
                TopSelectedKeys = matchMenuKeys;
            }
        }

        private async Task HandleCollapse(bool collapsed)
        {
            Collapsed = collapsed;
            await OnCollapse.InvokeAsync(collapsed);
        }

        #region StyleOrClass
        private readonly bool isChildrenLayout = false;

        private readonly string layoutCls = "ant-layout";


        bool HasSiderMenu => Layout != Layout.Mix || !SplitMenus || SiderMenuDom != null;
        bool HasLeftPadding => HasSiderMenu && FixSiderbar && Layout != Layout.Top && !IsMobile;
        int PaddingLeft => HasLeftPadding ? (Collapsed ? 48 : SiderWidth) : 0;

        private string WeakModeStyle => StyleValues(("filter: invert(80%)", ColorWeak));
        private string GenLayoutStyle => StyleValues("position: relative"
            , ("min-height:0px", isChildrenLayout || (ContentStyle?.Contains("min-height") ?? false))
            , ($"padding-left: {PaddingLeft}px", MenuRender)
            );

        private string BaseClassName => $"{PrefixCls}-basicLayout";

        private string LayoutClass => ClassNames("ant-design-pro", BaseClassName, $"screen-{ColSize}"
            , ($"{BaseClassName}-top-menu", Layout == Layout.Top)
            , ($"{BaseClassName}-is-children", isChildrenLayout)
            , ($"{BaseClassName}-fix-siderbar", FixSiderbar)
            , ($"{BaseClassName}-mobile", IsMobile)
            );

        private string ContentClass => ClassNames($"{BaseClassName}-content"
            , ($"{BaseClassName}-has-header", HeaderRender)
            , ($"{BaseClassName}-content-disable-margin", DisableContentMargin)
            );
        #endregion
    }
}
