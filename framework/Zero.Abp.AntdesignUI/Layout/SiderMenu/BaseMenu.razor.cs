using AntDesign;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AntdesignUI.Layout
{
    public partial class BaseMenu
    {
        readonly int maxTopMenuCount = 5;

        [Parameter] public string IconPrefixes { get; set; } = "icon-";

        [Parameter] public bool Collapsed { get; set; }
        [Parameter] public bool IsMobile { get; set; }
        [Parameter] public MenuMode Mode { get; set; }//  //ToDo: 'vertical' | 'vertical-left' | 'vertical-right' | 'horizontal' | 'inline';
        [Parameter] public RenderFragment<ApplicationMenuItem> MenuItemRender { get; set; }
        [Parameter] public RenderFragment<ApplicationMenuItem> SubMenuItemRender { get; set; }

        //[CascadingParameter(Name = "MatchMenuKeys")]
        //public string[] MatchMenuKeys { get; set; } = { };


        [Parameter] public ApplicationMenuItemList MenuData { get; set; }

        //[Parameter] public string[] OpenKeys { get => openKeys; set => openKeys = value; }
        //{ get => (!Collapsed && new Layout[] { Layout.Side, Layout.Mix }.Contains(Layout)) ? openKeys : null; set => openKeys = value; }
  

        //[Parameter] public EventCallback<string[]> OnOpenChange { get; set; }

        [Parameter] public string[] SelectedKeys { get ; set; }
        [Parameter] public EventCallback<string[]> SelectedKeysChanged { get; set; }


        //[Inject] protected MenuState MenuState { get; set; }
        //public string[] MatchMenuKeys => MenuState.MatchMenuKeys;
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            //MenuState.OnChange += OnMenuStateChanged;
            //if (MatchMenuKeys?.Any() ?? false)
            //{
            //    SetOpenKeys(MatchMenuKeys);
            //    SetSelectedKeys(MatchMenuKeys);
            //}
        }
        //protected override void Dispose(bool disposing)
        //{
        //    MenuState.OnChange -= OnMenuStateChanged;
        //    base.Dispose(disposing);
        //}
        //protected virtual void OnMenuStateChanged()
        //{
        //    openKeys = MatchMenuKeys;
        //    selectedKeys = MatchMenuKeys;
        //    StateHasChanged();
        //}


        //string[] openKeys = Array.Empty<string>();
        //string[] selectedKeys = Array.Empty<string>();
        //async void SetOpenKeys(string[] keys)
        //{
        //    OpenKeys = keys;
        //    if (!IsMobile && OnOpenChange.HasDelegate)
        //    {
        //        await OnOpenChange.InvokeAsync(keys);
        //    }
        //}
        //async void SetSelectedKeys(string[] keys)
        //{
        //    SelectedKeys = keys;
        //    if (SelectedKeysChanged.HasDelegate)
        //    {
        //        await SelectedKeysChanged.InvokeAsync(keys);
        //    }
        //    StateHasChanged();
        //}

    }
}
