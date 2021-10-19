using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Zero.Abp.AntBlazor.Layout.Core.LayoutConfig
{
    public class DefaultLayoutConfigProvider : ILayoutConfigProvider, ITransientDependency
    {
        protected AbpLayoutConfigOptions Options { get; }

        public DefaultLayoutConfigProvider(IOptions<AbpLayoutConfigOptions> options)
        {
            Options = options.Value;

        }

        public Task<LayoutSettings> GetSettingsAsync()
        {
            return Task.FromResult(Options.Settings);
        }
    }
}
