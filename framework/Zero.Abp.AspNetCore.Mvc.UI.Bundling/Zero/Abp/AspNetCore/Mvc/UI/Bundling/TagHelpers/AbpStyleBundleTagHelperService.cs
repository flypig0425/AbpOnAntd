namespace Zero.Abp.AspNetCore.Mvc.UI.Bundling.TagHelpers
{
    public class AbpStyleBundleTagHelperService : AbpBundleTagHelperService<AbpStyleBundleTagHelper, AbpStyleBundleTagHelperService>
    {
        public AbpStyleBundleTagHelperService(AbpTagHelperStyleService resourceHelper)
            : base(resourceHelper)
        {
        }
    }
}
