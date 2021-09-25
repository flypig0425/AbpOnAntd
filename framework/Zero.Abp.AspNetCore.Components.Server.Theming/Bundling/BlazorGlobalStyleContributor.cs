﻿using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Zero.Abp.AspNetCore.Components.Server.Theming.Bundling
{
    public class BlazorGlobalStyleContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/_content/AntDesign/css/ant-design-blazor.css");
            context.Files.AddIfNotContains("/_content/Zero.Abp.AspNetCore.Components.Web/blazor-global-styles.css");
        }
    }
}