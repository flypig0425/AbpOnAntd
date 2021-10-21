using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Volo.Abp.Data;
using Zero.Abp.AspNetCore.Components.Web;

namespace Zero.Abp.AntBlazorUI.Components.ObjectExtending
{
    public partial class ExtensionProperties<TEntityType, TResourceType> : ComponentBase
        where TEntityType : IHasExtraProperties
    {
        [Inject]
        public IStringLocalizerFactory StringLocalizerFactory { get; set; }

        [Parameter]
        public AbpBlazorMessageLocalizerHelper<TResourceType> LH { get; set; }

        [Parameter]
        public TEntityType Entity { get; set; }
    }
}
