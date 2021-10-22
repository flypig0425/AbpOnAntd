using Volo.Abp.Modularity;

namespace AbpBlazorServerApp
{
    [DependsOn(
        typeof(AbpBlazorServerAppApplicationModule),
        typeof(AbpBlazorServerAppDomainTestModule)
        )]
    public class AbpBlazorServerAppApplicationTestModule : AbpModule
    {

    }
}