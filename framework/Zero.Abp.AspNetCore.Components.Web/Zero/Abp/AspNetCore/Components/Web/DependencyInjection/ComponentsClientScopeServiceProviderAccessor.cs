using System;
using Volo.Abp.DependencyInjection;

namespace Zero.Abp.AspNetCore.Components.Web.DependencyInjection
{
    public class ComponentsClientScopeServiceProviderAccessor :
        IClientScopeServiceProviderAccessor,
        ISingletonDependency
    {
        public IServiceProvider ServiceProvider { get; set; }
    }
}
