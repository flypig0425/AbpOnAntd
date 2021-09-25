﻿using System.Collections.Generic;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Zero.Abp.AspNetCore.Components.Server.Theming.Bundling
{
    public class BlazorGlobalScriptContributor : BundleContributor
    {
        public override void ConfigureBundle(BundleConfigurationContext context)
        {
            context.Files.AddIfNotContains("/_framework/blazor.server.js");
            context.Files.AddIfNotContains("/_content/AntDesign/js/ant-design-blazor.js");
            context.Files.AddIfNotContains("/_content/Zero.Abp.AspNetCore.Components.Web/libs/abp/js/abp.js");
        }
    }
}