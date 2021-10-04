using Microsoft.AspNetCore.Components;
using Volo.Abp.DependencyInjection;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class RouteManager : IRouteManager, ITransientDependency
    {

        protected IMenuManager MenuManager { get; }
        protected NavigationManager NavigationManager { get; }

        public ApplicationMenuItemList MenuData { get; internal set; }

        public RouteManager(
            IMenuManager menuManager,
            NavigationManager navigationManager)
        {
            MenuManager = menuManager;
            NavigationManager = navigationManager;

            //MenuData = (await MenuManager.GetMainMenuAsync()).GetAdministration().Items;
        }
    }

    public interface IRouteManager
    {
        public ApplicationMenuItemList MenuData { get; }
    }
}
