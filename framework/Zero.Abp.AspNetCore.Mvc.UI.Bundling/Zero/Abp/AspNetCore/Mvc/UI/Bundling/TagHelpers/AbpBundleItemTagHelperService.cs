using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Mvc.UI.Bundling.TagHelpers
{
    public abstract class AbpBundleItemTagHelperService<TTagHelper, TService> : AbpTagHelperService<TTagHelper>
        where TTagHelper : AbpTagHelper<TTagHelper, TService>, IBundleItemTagHelper
        where TService : class, IAbpTagHelperService<TTagHelper>
    {
        protected AbpTagHelperResourceService ResourceService { get; }

        protected AbpBundleItemTagHelperService(AbpTagHelperResourceService resourceService)
        {
            ResourceService = resourceService;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var tagHelperItems = context.Items.GetOrDefault(AbpTagHelperConsts.ContextBundleItemListKey) as List<BundleTagHelperItem>;
            if (tagHelperItems != null)
            {
                output.SuppressOutput();
                tagHelperItems.Add(TagHelper.CreateBundleTagHelperItem());
            }
            else
            {
                await ResourceService.ProcessAsync(
                    TagHelper.ViewContext,
                    context,
                    output,
                    new List<BundleTagHelperItem>
                    {
                        TagHelper.CreateBundleTagHelperItem()
                    },
                    TagHelper.GetNameOrNull()
                );
            }
        }
    }
}
