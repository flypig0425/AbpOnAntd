using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Zero.Abp.AspNetCore.Mvc.UI.Bundling.TagHelpers
{
    [HtmlTargetElement("abp-script", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class AbpScriptTagHelper : AbpBundleItemTagHelper<AbpScriptTagHelper, AbpScriptTagHelperService>, IBundleItemTagHelper
    {
        public AbpScriptTagHelper(AbpScriptTagHelperService service)
            : base(service)
        {

        }

        protected override string GetFileExtension()
        {
            return "js";
        }
    }
}