using System.Threading.Tasks;

namespace Zero.Abp.AntBlazor.Layout
{
    public interface ILayoutConfigProvider
    {
        Task<LayoutSettings> GetSettingsAsync();
    }
}
