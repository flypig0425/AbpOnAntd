using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Zero.Abp.AntdesignUI.Layout
{
    public class DefaultLayoutConfigProvider : ILayoutConfigProvider, ITransientDependency
    {
        protected AbpLayoutConfigOptions Options { get; }

        public DefaultLayoutConfigProvider(IOptions<AbpLayoutConfigOptions> options)
        {
            Options = options.Value;
        }

        public Task<LayoutSettings> GetAsync()
        {
            return Task.FromResult(Options.Settings);
        }
    }
}
