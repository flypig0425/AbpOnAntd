using System.Threading.Tasks;

namespace Zero.Abp.Account.Blazor.ProfileManagement
{
    public interface IProfileManagementPageContributor
    {
        Task ConfigureAsync(ProfileManagementPageCreationContext context);
    }
}
