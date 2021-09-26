using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AspNetCore.Components.Web.BasicTheme.Themes.Basic
{
    public partial class MainLayout : IDisposable
    {
        [Inject] private NavigationManager NavigationManager { get; set; }
        [Inject] protected IMenuManager MenuManager { get; set; }

        //private bool IsCollapseShown { get; set; }

        //private MenuDataItem[] MenuData { get; set; } = Array.Empty<MenuDataItem>();

        protected override async Task OnInitializedAsync()
        {
            var Menu = await MenuManager.GetMainMenuAsync();

            //MenuData = await HttpClient.GetFromJsonAsync<MenuDataItem[]>("data/menu.json");

            NavigationManager.LocationChanged += OnLocationChanged;
        }

        //private void ToggleCollapse()
        //{
        //    IsCollapseShown = !IsCollapseShown;
        //}

        public void Dispose()
        {
            NavigationManager.LocationChanged -= OnLocationChanged;
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            //IsCollapseShown = false;
            InvokeAsync(StateHasChanged);
        }
    }
}
