using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace AbpBlazorServerApp.Blazor
{
    [Dependency(ReplaceServices = true)]
    public class AbpBlazorServerAppBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "AbpBlazorServerApp";
    }
}
