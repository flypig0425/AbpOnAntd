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


        private readonly bool isChildrenLayout = false;
        protected string ColSize { get; set; } = "lg";//useAntdMediaQuery();
        protected bool IsMobile => (ColSize == "sm" || ColSize == "xs") && !DisableMobile;


        private bool IsSplitMenus => SplitMenus && (/*OpenKeys != false ||*/ Layout == Layout.Mix) && !IsMobile;
        public string[] TopSelectedKeys { get; set; }
        public string[] SiderSelectedKeys { get; set; }
        protected ApplicationMenuItemList MenuData { get; set; }

        [Inject] protected IRouteManager RouteManager { get; set; }
        protected override async Task OnInitializedAsync()
        {
            MenuData = await RouteManager.GetMenuDataAsync();
            if (IsSplitMenus) {
                var matchMenuKeys = await RouteManager.GetMatchMenuKeysAsync(true);
                TopSelectedKeys = matchMenuKeys;
            }

            //MenuState.UpdateMatchMenuKeys(matchMenuKeys);

            //MenuState.OnChange += StateHasChanged;
            //TopMenuKeys = await RouteManager.GetMatchMenuKeysAsync(true);
        }
       
        //protected override void Dispose(bool disposing)
        //{
        //    MenuState.OnChange -= StateHasChanged;
        //    base.Dispose(disposing);
        //}


        //string[] TopMenuKeys = Array.Empty<string>();
        //string[] SiderMenuKeys = Array.Empty<string>();
        //async Task HandleTopMenuSelectedKeysChanged(string[] keys)
        //{
        //    TopMenuKeys = await RouteManager.GetFirstLeafPathsNameAsync(keys.LastOrDefault());
        //    //SiderMenuKeys = TopMenuKeys;
        //}
        //async Task HandleSiderMenuSelectedKeysChanged(string[] keys)
        //{
        //    SiderMenuKeys = await RouteManager.GetFirstLeafPathsNameAsync(keys.FirstOrDefault());
        //    //TopMenuKeys = SiderMenuKeys;
        //}


        private async Task HandleCollapse(bool collapsed)
        {
            Collapsed = collapsed;
            await OnCollapse.InvokeAsync(collapsed);
        }



        #region StyleOrClass
        bool HasSiderMenu => Layout != Layout.Mix || !SplitMenus || SiderMenuDom != null;
        bool HasLeftPadding => HasSiderMenu && FixSiderbar && Layout != Layout.Top && !IsMobile;
        int PaddingLeft => HasLeftPadding ? (Collapsed ? 48 : SiderWidth) : 0;

        private string WeakModeStyle => StyleValues(("filter: invert(80%)", ColorWeak));
        private string GenLayoutStyle => StyleValues("position: relative"
            , ("min-height:0px", isChildrenLayout || (ContentStyle?.Contains("min-height") ?? false))
            , ($"padding-left: {PaddingLeft}px", MenuRender)
            );

        private string BaseClassName => $"{PrefixCls}-basicLayout";

        private readonly string layoutCls = "ant-layout";
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
