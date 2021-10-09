using AntDesign;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Volo.Abp.Threading;
using Zero.Abp.AntdesignUI.Localization;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class SettingDrawerBase : AntDomComponentBase
    {
      
        protected LayoutSettings Settings => AsyncHelper.RunSync(async () => await LayoutConfigProvider.GetSettingsAsync());

        [Inject] protected ILayoutConfigProvider LayoutConfigProvider { get; set; }

        [Inject] protected IStringLocalizer<AbpAntdesignUIResource> L { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
        }
    }
}
