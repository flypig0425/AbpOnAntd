using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.Web.AntdTheme
{
    public interface ILayoutConfigProvider
    {
        Task<LayoutSettings> GetSettingsAsync();
    }
}
