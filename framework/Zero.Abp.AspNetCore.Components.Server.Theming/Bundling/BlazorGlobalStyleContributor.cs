using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Zero.Abp.AntBlazorUI;

namespace Zero.Abp.AspNetCore.Components.Server.Theming.Bundling
{
    public class BlazorGlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains(AntBlazorUiBundlePaths.Styles);
        }
    }
}