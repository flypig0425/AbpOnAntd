using System.Threading.Tasks;

namespace Zero.Abp.AntBlazor.Layout.Core.LayoutConfig
{
    public interface ILayoutConfigProvider
    {
        Task<LayoutSettings> GetSettingsAsync();
    }
}
