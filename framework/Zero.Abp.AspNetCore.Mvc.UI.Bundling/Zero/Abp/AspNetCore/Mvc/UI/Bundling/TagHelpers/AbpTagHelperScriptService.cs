﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;


namespace Zero.Abp.AspNetCore.Mvc.UI.Bundling.TagHelpers
{
    public class AbpTagHelperScriptService : AbpTagHelperResourceService
    {
        public AbpTagHelperScriptService(
            IBundleManager bundleManager,
            IOptions<AbpBundlingOptions> options,
            IWebHostEnvironment hostingEnvironment
            ) : base(
                bundleManager,
                options,
                hostingEnvironment)
        {
        }

        protected override void CreateBundle(string bundleName, List<BundleTagHelperItem> bundleItems)
        {
            Options.ScriptBundles.TryAdd(
                bundleName,
                configuration => bundleItems.ForEach(bi => bi.AddToConfiguration(configuration)),
                HostingEnvironment.IsDevelopment() && bundleItems.Any()
            );
        }

        protected override async Task<IReadOnlyList<string>> GetBundleFilesAsync(string bundleName)
        {
            return await BundleManager.GetScriptBundleFilesAsync(bundleName);
        }

        protected override void AddHtmlTag(ViewContext viewContext, TagHelperContext context, TagHelperOutput output, string file)
        {
            output.Content.AppendHtml($"<script src=\"{viewContext.GetUrlHelper().Content(file.EnsureStartsWith('~'))}\"></script>{Environment.NewLine}");
        }
    }
}
