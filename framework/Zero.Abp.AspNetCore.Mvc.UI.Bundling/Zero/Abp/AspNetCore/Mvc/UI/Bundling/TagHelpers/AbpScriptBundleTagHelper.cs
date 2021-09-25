using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Zero.Abp.AspNetCore.Mvc.UI.Bundling.TagHelpers
{
    [HtmlTargetElement("abp-script-bundle", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class AbpScriptBundleTagHelper : AbpBundleTagHelper<AbpScriptBundleTagHelper, AbpScriptBundleTagHelperService>, IBundleTagHelper
    {
        public AbpScriptBundleTagHelper(AbpScriptBundleTagHelperService service)
            : base(service)
        {

        }
    }
}