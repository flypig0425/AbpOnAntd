using System.Collections.Generic;

namespace Zero.Abp.Account.Blazor.ProfileManagement
{
    public class ProfileManagementPageOptions
    {
        public List<IProfileManagementPageContributor> Contributors { get; }

        public ProfileManagementPageOptions()
        {
            Contributors = new List<IProfileManagementPageContributor>();
        }
    }
}
