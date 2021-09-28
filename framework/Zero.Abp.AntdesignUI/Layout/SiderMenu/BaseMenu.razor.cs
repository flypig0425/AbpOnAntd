using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Volo.Abp.UI.Navigation;

namespace Zero.Abp.AntdesignUI.Layout
{
    //internal interface IBaseMenu : IPureSettings
    //{
    //    bool Collapsed { get; }
    //    EventCallback<bool> HandleOpenChange { get; }
    //    bool IsMobile { get; }
    //    MenuMode Mode { get; }
    //    EventCallback<bool> OnCollapse { get; }
    //    string[] OpenKeys { get; }
    //}

    //public partial class BaseMenu : IBaseMenu
    //{
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