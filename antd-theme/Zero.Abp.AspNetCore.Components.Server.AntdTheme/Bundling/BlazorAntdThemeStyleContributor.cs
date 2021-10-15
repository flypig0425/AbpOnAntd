using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Zero.Abp.AspNetCore.Components.Web.AntdTheme;

namespace Zero.Abp.AspNetCore.Components.Server.AntdTheme.Bundling
{
    public class BlazorAntdThemeStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains(AbpAntdTheme.StylePath);
        }
    }
}