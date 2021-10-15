using Volo.Abp.Bundling;
using Zero.Abp.AspNetCore.Components.Web.AntdTheme;

namespace Zero.Abp.AspNetCore.Components.WebAssembly.AntdTheme
{
    public class AntdThemeBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {

        }

        public void AddStyles(BundleContext context)
        {
            context.Add(AbpAntdTheme.StylePath);
        }
    }
}
