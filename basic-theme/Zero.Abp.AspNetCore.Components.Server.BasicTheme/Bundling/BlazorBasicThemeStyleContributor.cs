using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Zero.Abp.AspNetCore.Components.Server.BasicTheme.Bundling
{
    public class BlazorBasicThemeStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/_content/Zero.Abp.AspNetCore.Components.Web.BasicTheme/libs/abp/css/theme.css");
        }
    }
}