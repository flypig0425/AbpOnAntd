using AbpBlazorServerApp.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace AbpBlazorServerApp.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(AbpBlazorServerAppEntityFrameworkCoreModule),
        typeof(AbpBlazorServerAppApplicationContractsModule)
        )]
    public class AbpBlazorServerAppDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
