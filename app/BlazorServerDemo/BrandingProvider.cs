using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BlazorServerDemo
{
    [Dependency(ReplaceServices = true)]
    public class BlazorServerDemoBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "BlazorServerDemo";
        public override string LogoUrl => "https://gw.alipayobjects.com/zos/rmsportal/KDpgvguMpGfqaHPjicRK.svg";
    }
}
 