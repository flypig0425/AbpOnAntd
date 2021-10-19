using Volo.Abp.Bundling;
using Zero.Abp.AntBlazorUI;

namespace Zero.Abp.AspNetCore.Components.WebAssembly.Theming
{
    public class ComponentsComponentsBundleContributor : IBundleContributor
    {
        public void AddScripts(BundleContext context)
        {
            context.Add(AbpAntdesign.ScriptPath);
            //context.Add("_content/Microsoft.AspNetCore.Components.WebAssembly.Authentication/AuthenticationService.js");
            context.Add("_content/Zero.Abp.AspNetCore.Components.Web/libs/abp/js/abp.js"); 
        }

        public void AddStyles(BundleContext context)
        {
            context.Add(AbpAntdesign.StylePath);
        }
    }
}
