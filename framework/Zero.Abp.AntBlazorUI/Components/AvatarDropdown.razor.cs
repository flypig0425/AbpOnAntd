using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AntBlazorUI.Components
{
    public partial class AvatarDropdown : IDisposable
    {
        [Inject] protected IMenuManager MenuManager { get; set; }

        protected ApplicationMenu Menu { get; set; }

        //[CanBeNull]
        //protected AuthenticationStateProvider AuthenticationStateProvider;

        //[CanBeNull]
        //protected SignOutSessionStateManager SignOutManager;

        protected override async Task OnInitializedAsync()
        {
            Menu = await MenuManager.GetAsync(StandardMenus.User);

            Navigation.LocationChanged += OnLocationChanged;
        }

        protected virtual void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            InvokeAsync(StateHasChanged);
        }
        private async Task NavigateToAsync(string uri, string target = null)
        {
            if (target == "_blank")
            {
                await JsRuntime.InvokeVoidAsync("open", uri, target);
            }
            else
            {
                Navigation.NavigateTo(uri);
            }
        }
        public void Dispose()
        {
            Navigation.LocationChanged -= OnLocationChanged;
        }
    }
}
