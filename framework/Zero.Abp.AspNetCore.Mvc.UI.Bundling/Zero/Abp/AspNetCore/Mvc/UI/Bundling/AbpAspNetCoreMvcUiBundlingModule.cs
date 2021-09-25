using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.Minify;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Zero.Abp.AspNetCore.Mvc.UI.Bundling
{
    [DependsOn(
        typeof(AbpAspNetCoreMvcModule),
        typeof(AbpMinifyModule),
        typeof(AbpAspNetCoreMvcUiBundlingAbstractionsModule)
        )]
    public class AbpAspNetCoreMvcUiBundlingModule : AbpModule
    {
        internal static string AssemblyName => typeof(AbpAspNetCoreMvcUiBundlingModule).Assembly.GetName().Name;

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpVirtualFileSystemOptions>(options =>
            {
                options.FileSets.AddEmbedded<AbpAspNetCoreMvcUiBundlingModule>(AssemblyName);
            });
        }
    }
}
