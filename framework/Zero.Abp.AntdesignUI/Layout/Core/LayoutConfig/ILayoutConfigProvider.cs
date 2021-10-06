using System.Threading.Tasks;

namespace Zero.Abp.AntdesignUI.Layout
{
    public interface ILayoutConfigProvider
    {
        Task<LayoutSettings> GetAsync();
    }
}
