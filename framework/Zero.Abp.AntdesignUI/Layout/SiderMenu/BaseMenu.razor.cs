using AntDesign;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AntdesignUI.Layout
{
    public partial class BaseMenuProps : AntProComponentBase
    {
        //[Parameter] public MenuTheme Theme { get; set; }
        //[Parameter] public bool? SplitMenus { get; set; }


        [Parameter] public string IconPrefixes { get; set; } = "fa-";

        [Parameter] public bool DefaultCollapsed { get; set; }
        [Parameter] public bool Collapsed { get; set; }
        [Parameter] public bool IsMobile { get; set; }

        string[] openKeys = Array.Empty<string>();
        [Parameter]
        public string[] OpenKeys
        {
            get => (!Collapsed && new Layout[] { Layout.Side, Layout.Mix }.Contains(Layout)) ? openKeys : null;
            set => openKeys = value;
        }

        //ToDo: 'vertical' | 'vertical-left' | 'vertical-right' | 'horizontal' | 'inline';
        [Parameter] public MenuMode Mode { get; set; }

        [Parameter] public EventCallback<bool> OnCollapse { get; set; }
        [Parameter] public EventCallback<string[]> HandleOpenChange { get; set; }

        [Parameter] public RenderFragment<ApplicationMenuItem> MenuItemRender { get; set; }
        [Parameter] public RenderFragment<ApplicationMenuItem> SubMenuItemRender { get; set; }
    }




    //internal interface IBaseMenu : IPureSettings
    //{
    //    bool Collapsed { get; }
    //    EventCallback<bool> HandleOpenChange { get; }
    //    bool IsMobile { get; }
    //    MenuMode Mode { get; }
    //    EventCallback<bool> OnCollapse { get; }
    //    string[] OpenKeys { get; }
    //}

    public partial class BaseMenu
    {
        //    [Parameter] public bool OnlyTopMenu { get; set; }
        //    [Parameter] public bool IsMobile { get; set; }
        //    [Parameter] public bool Collapsed { get; set; }

        //    [Parameter] public string[] OpenKeys { get; set; } = { };
        //    [Parameter] public MenuMode Mode { get; set; }
        //    [Parameter] public EventCallback<bool> OnCollapse { get; set; }
        //    [Parameter] public EventCallback<string[]> HandleOpenChange { get; set; }

        //    [Inject] public ILogger<BaseMenu> Logger { get; set; }

        //    [Inject] protected IMenuManager MenuManager { get; set; }

        //    protected ApplicationMenuItemList Menus { get; set; }

        //    protected override async Task OnInitializedAsync()
        //    {
        //        Menus = (await MenuManager.GetMainMenuAsync()).Items;
        //        Logger.LogInformation("BaseMenu initialized.");
        //    }

        //    public void SetOpenKeys(string[] keys)
        //    {
        //    }
        //}
    }
}