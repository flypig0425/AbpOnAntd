using JetBrains.Annotations;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme.Themes.Basic
{
    public partial class LoginDisplay : IDisposable
    {
        [Inject]
        protected IMenuManager MenuManager { get; set; }

        //[CanBeNull]
        //protected AuthenticationStateProvider AuthenticationStateProvider;

        //[CanBeNull]
        //protected SignOutSessionStateManager SignOutManager;

        protected ApplicationMenu Menu { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Menu = await MenuManager.GetAsync(StandardMenus.User);

            Navigation.LocationChanged += OnLocationChanged;

            //LazyGetService(ref AuthenticationStateProvider);
            ////LazyGetService(ref SignOutManager);

            //if (AuthenticationStateProvider != null)
            //{
            //    AuthenticationStateProvider.AuthenticationStateChanged += async (task) =>
            //    {
            //        Menu = await MenuManager.GetAsync(StandardMenus.User);
            //        await InvokeAsync(StateHasChanged);
            //    };
            //}
        }

        protected virtual void OnLocationChanged(object sender, LocationChangedEventArgs e)
        {
            InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            Navigation.LocationChanged -= OnLocationChanged;
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

#pragma warning disable CS1998 // 此异步方法缺少 "await" 运算符，将以同步方式运行。请考虑使用 "await" 运算符等待非阻止的 API 调用，或者使用 "await Task.Run(...)" 在后台线程上执行占用大量 CPU 的工作。
        private async Task BeginSignOut()
#pragma warning restore CS1998 // 此异步方法缺少 "await" 运算符，将以同步方式运行。请考虑使用 "await" 运算符等待非阻止的 API 调用，或者使用 "await Task.Run(...)" 在后台线程上执行占用大量 CPU 的工作。
        {
            //if (SignOutManager != null)
            //{
            //    await SignOutManager.SetSignOutState();
            //    await NavigateToAsync("authentication/logout");
            //}
        }
    }
}
