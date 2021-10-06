using Volo.Abp;

namespace Zero.Abp.AspNetCore.Components.Web
{
    public class AbpAspNetCoreApplicationCreationOptions
    {
        public AbpApplicationCreationOptions ApplicationCreationOptions { get; }

        public AbpAspNetCoreApplicationCreationOptions(
            AbpApplicationCreationOptions applicationCreationOptions)
        {
            ApplicationCreationOptions = applicationCreationOptions;
        }
    }
}
