using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Zero.Abp.AspNetCore.Mvc.UI.Bundling.TagHelpers
{
    [HtmlTargetElement("abp-style-bundle", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class AbpStyleBundleTagHelper : AbpBundleTagHelper<AbpStyleBundleTagHelper, AbpStyleBundleTagHelperService>, IBundleTagHelper
    {
        public AbpStyleBundleTagHelper(AbpStyleBundleTagHelperService service)
            : base(service)
        {
        }
    }
}
