using IdentityModel;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;
using Volo.Abp.Security.Claims;
using Zero.Abp.AspNetCore.Components.WebAssembly;

namespace Zero.Abp.Http.Client.IdentityModel.WebAssembly
{
    [DependsOn(
        typeof(AbpHttpClientIdentityModelModule),
        typeof(AbpAspNetCoreComponentsWebAssemblyModule)
    )]
    public class AbpHttpClientIdentityModelWebAssemblyModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            AbpClaimTypes.UserName = JwtClaimTypes.PreferredUserName;
            AbpClaimTypes.Name = JwtClaimTypes.GivenName;
            AbpClaimTypes.SurName = JwtClaimTypes.FamilyName;
            AbpClaimTypes.UserId = JwtClaimTypes.Subject;
            AbpClaimTypes.Role = JwtClaimTypes.Role;
            AbpClaimTypes.Email = JwtClaimTypes.Email;
        }
    }
}
