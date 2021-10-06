using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Security.Claims;
using Zero.Abp.AspNetCore.Components.Web.Security;

namespace Zero.Abp.AspNetCore.Components.WebAssembly
{
    public class WebAssemblyCurrentPrincipalAccessor : CurrentPrincipalAccessorBase, ITransientDependency
    {
        protected AbpComponentsClaimsCache ClaimsCache { get; }

        public WebAssemblyCurrentPrincipalAccessor(
            IClientScopeServiceProviderAccessor clientScopeServiceProviderAccessor)
        {
            ClaimsCache = clientScopeServiceProviderAccessor.ServiceProvider.GetRequiredService<AbpComponentsClaimsCache>();
        }

        protected override ClaimsPrincipal GetClaimsPrincipal()
        {
            return ClaimsCache.Principal;
        }
    }
}
