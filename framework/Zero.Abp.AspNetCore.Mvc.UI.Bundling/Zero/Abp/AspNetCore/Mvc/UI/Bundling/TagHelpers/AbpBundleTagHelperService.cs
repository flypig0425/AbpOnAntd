﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Mvc.UI.Bundling.TagHelpers
{
    public abstract class AbpBundleTagHelperService<TTagHelper, TService> : AbpTagHelperService<TTagHelper>
        where TTagHelper : AbpTagHelper<TTagHelper, TService>, IBundleTagHelper
        where TService : class, IAbpTagHelperService<TTagHelper>
    {
        protected AbpTagHelperResourceService ResourceService { get; }

        protected AbpBundleTagHelperService(AbpTagHelperResourceService resourceService)
        {
            ResourceService = resourceService;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            await ResourceService.ProcessAsync(
                TagHelper.ViewContext,
                context,
                output,
                await GetBundleItems(context, output),
                TagHelper.GetNameOrNull()
            );
        }

        protected virtual async Task<List<BundleTagHelperItem>> GetBundleItems(TagHelperContext context, TagHelperOutput output)
        {
            var bundleItems = new List<BundleTagHelperItem>();
            context.Items[AbpTagHelperConsts.ContextBundleItemListKey] = bundleItems;
            await output.GetChildContentAsync(); //TODO: Is there a way of executing children without getting content?
            return bundleItems;
        }
    }
}
