using Volo.Abp.AspNetCore.Mvc.UI.Bundling;

namespace Zero.Abp.AspNetCore.Mvc.UI.Bundling.TagHelpers
{
    public abstract class BundleTagHelperItem
    {
        public abstract void AddToConfiguration(BundleConfiguration configuration);
    }
}