using System;
using System.Collections.Generic;
using Volo.Abp.DependencyInjection;

namespace Zero.Abp.SettingManagement.Blazor
{
    public class SettingComponentCreationContext : IServiceProviderAccessor
    {
        public IServiceProvider ServiceProvider { get; }

        public List<SettingComponentGroup> Groups { get; }

        public SettingComponentCreationContext(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;

            Groups = new List<SettingComponentGroup>();
        }
    }
}