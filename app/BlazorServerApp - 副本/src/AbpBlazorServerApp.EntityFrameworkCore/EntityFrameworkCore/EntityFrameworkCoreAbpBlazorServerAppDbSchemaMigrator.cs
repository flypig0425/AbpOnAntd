using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AbpBlazorServerApp.Data;
using Volo.Abp.DependencyInjection;

namespace AbpBlazorServerApp.EntityFrameworkCore
{
    public class EntityFrameworkCoreAbpBlazorServerAppDbSchemaMigrator
        : IAbpBlazorServerAppDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreAbpBlazorServerAppDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the AbpBlazorServerAppDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<AbpBlazorServerAppDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}
