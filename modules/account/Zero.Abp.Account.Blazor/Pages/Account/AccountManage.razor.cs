using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zero.Abp.Account.Blazor.ProfileManagement;

namespace Zero.Abp.Account.Blazor.Pages.Account
{
    public partial class AccountManage
    {

        protected ProfileManagementPageOptions Options { get; }

        public AccountManage(IOptions<ProfileManagementPageOptions> options)
        {
            Options = options.Value;
        }


        [Inject] protected IServiceProvider ServiceProvider { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await SetItemRendersAsync();
        }


        #region [SetItemRendersAsync]
        public ProfileManagementPageCreationContext ProfileManagementPageCreationContext { get; private set; }

        protected string SelectedGroup;
        protected List<(string Key, string DisplayName, RenderFragment Component)> ItemRenders { get; set; } = new();

        protected virtual async Task SetItemRendersAsync()
        {
            ProfileManagementPageCreationContext = new ProfileManagementPageCreationContext(ServiceProvider);
            foreach (var contributor in Options.Contributors)
            {
                await contributor.ConfigureAsync(ProfileManagementPageCreationContext);
            }

            ItemRenders.Clear();
            foreach (var group in ProfileManagementPageCreationContext.Groups)
            {
                ItemRenders.Add((GetNormalizedString(group.Id), group.DisplayName, builder =>
                {
                    builder.OpenComponent(0, group.ComponentType);
                    builder.CloseComponent();
                }
                ));
            }
            SelectedGroup = GetNormalizedString(ProfileManagementPageCreationContext.Groups.First().Id);
        }

        protected virtual string GetNormalizedString(string value)
        {
            return value.Replace('.', '_');
        }
        #endregion
    }
}