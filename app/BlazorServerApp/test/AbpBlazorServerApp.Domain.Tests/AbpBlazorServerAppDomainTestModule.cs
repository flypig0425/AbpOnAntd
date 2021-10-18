using AbpBlazorServerApp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AbpBlazorServerApp
{
    [DependsOn(
        typeof(AbpBlazorServerAppEntityFrameworkCoreTestModule)
        )]
    public class AbpBlazorServerAppDomainTestModule : AbpModule
    {

    }
}