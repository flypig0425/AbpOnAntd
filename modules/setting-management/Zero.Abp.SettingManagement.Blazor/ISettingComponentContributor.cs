using System.Threading.Tasks;

namespace Zero.Abp.SettingManagement.Blazor
{
    public interface ISettingComponentContributor
    {
        Task ConfigureAsync(SettingComponentCreationContext context);

        Task<bool> CheckPermissionsAsync(SettingComponentCreationContext context);
    }
}