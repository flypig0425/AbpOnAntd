using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Zero.Abp.AntdesignUI.Localization;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class SettingDrawerBase : AntDomComponentBase
    {
        [Inject] protected LayoutState LayoutState { get; set; }
        [Inject] protected IStringLocalizer<AbpAntdesignUIResource> L { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
