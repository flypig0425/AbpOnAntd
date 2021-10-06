using System.Threading.Tasks;

namespace Zero.Abp.AspNetCore.Components.Web.Configuration
{
    public interface ICurrentApplicationConfigurationCacheResetService
    {
        Task ResetAsync();
    }
}