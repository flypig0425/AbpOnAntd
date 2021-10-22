using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace AbpBlazorServerApp.Data
{
    /* This is used if database provider does't define
     * IAbpBlazorServerAppDbSchemaMigrator implementation.
     */
    public class NullAbpBlazorServerAppDbSchemaMigrator : IAbpBlazorServerAppDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}