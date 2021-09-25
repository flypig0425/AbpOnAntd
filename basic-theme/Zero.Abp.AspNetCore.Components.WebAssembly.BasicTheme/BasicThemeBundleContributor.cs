using Volo.Abp.Bundling;

namespace Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme
{
    public class BasicThemeBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {

        }

        public void AddStyles(BundleContext context)
        {
            context.Add("_content/Zero.Abp.AspNetCore.Components.Web.BasicTheme/libs/abp/css/theme.css");
        }
    }
}
