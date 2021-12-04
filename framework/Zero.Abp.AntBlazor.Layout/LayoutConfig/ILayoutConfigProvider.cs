using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Zero.Abp.AntBlazor.Layout.LayoutConfig
{
    public interface ILayoutConfigProvider : IScopedDependency
    {
        Task<LayoutSettings> GetSettingsAsync();

        Task UpdateSettingsAsync(LayoutSettings settings);

        Task UpdateThemeAsync();

        event Action<string> ThemeChanged;

        event Action SettingsChanged;
    }
}
