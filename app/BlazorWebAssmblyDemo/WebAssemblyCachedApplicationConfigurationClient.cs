using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc.ApplicationConfigurations;
using Volo.Abp.AspNetCore.Mvc.Client;
using Volo.Abp.DependencyInjection;
using Volo.Abp.MultiTenancy;
using Zero.Abp.AspNetCore.Components.WebAssembly;

namespace BlazorWebAssmblyDemo
{
    [Dependency(ReplaceServices = true)]
    public class MockCachedApplicationConfigurationClient : ICachedApplicationConfigurationClient, ITransientDependency
    {
        protected ApplicationConfigurationCache Cache { get; }

        protected ICurrentTenantAccessor CurrentTenantAccessor { get; }

        public MockCachedApplicationConfigurationClient(
            ApplicationConfigurationCache cache,
            ICurrentTenantAccessor currentTenantAccessor)
        {
            Cache = cache;
            CurrentTenantAccessor = currentTenantAccessor;
        }

        public virtual async Task InitializeAsync()
        {
            var configurationDto = await Task.FromResult(new ApplicationConfigurationDto());

            Cache.Set(configurationDto);

            CurrentTenantAccessor.Current = new BasicTenantInfo(
                configurationDto.CurrentTenant.Id,
                configurationDto.CurrentTenant.Name
            );
        }

        public virtual Task<ApplicationConfigurationDto> GetAsync()
        {
            return Task.FromResult(GetConfigurationByChecking());
        }

        public virtual ApplicationConfigurationDto Get()
        {
            return GetConfigurationByChecking();
        }

        private ApplicationConfigurationDto GetConfigurationByChecking()
        {
            var configuration = Cache.Get();
            if (configuration == null)
            {
                configuration = new ApplicationConfigurationDto();

                //throw new AbpException(
                //    $"{nameof(MockCachedApplicationConfigurationClient)} should be initialized before using it.");
            }

            return configuration;
        }
    }
}
