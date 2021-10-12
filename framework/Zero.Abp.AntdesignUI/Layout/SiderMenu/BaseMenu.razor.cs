using AntDesign;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AntdesignUI.Layout
{
    public partial class BaseMenu
    {
        readonly int maxTopMenuCount = 5;


        [Parameter] public string IconPrefixes { get; set; } = "icon-";

        [Parameter] public bool Collapsed { get; set; }
        //[Parameter] public bool IsMobile { get; set; }

        [Parameter] public MenuTheme Theme { get; set; }
        [Parameter] public MenuMode Mode { get; set; }//  //ToDo: 'vertical' | 'vertical-left' | 'vertical-right' | 'horizontal' | 'inline';
        [Parameter] public RenderFragment<ApplicationMenuItem> MenuItemRender { get; set; }
        [Parameter] public RenderFragment<ApplicationMenuItem> SubMenuItemRender { get; set; }
        [Parameter] public MenuSettings Menu { get; set; } = new MenuSettings();


        [Parameter] public ApplicationMenuItemList MenuData { get; set; }

        [Parameter] public string[] SelectedKeys { get; set; }
        [Parameter] public EventCallback<string[]> SelectedKeysChanged { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
    public class MenuSettings
    {
        /// <summary>
        /// 'sub' | 'group'
        /// </summary>
        public string Type { get; set; }
    }
}
