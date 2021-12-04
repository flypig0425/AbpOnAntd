using AntDesign;
using Microsoft.AspNetCore.Components;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Volo.Abp.Identity;
using Volo.Abp.Identity.Settings;
using Volo.Abp.Settings;
using Volo.Abp.Validation;

namespace Zero.Abp.Account.Blazor.Pages.Account.Components.ProfileManagementGroup
{
    public partial class AccountProfilePersonalInfoManagementGroupViewComponent
    {
        protected bool isUserNameUpdateEnabled;
        protected bool isEmailUpdateEnabled;

        protected Form<PersonalInfoModel> PersonalInfoForm;
        protected PersonalInfoModel PersonalInfoModel;

        [Inject] protected IProfileAppService ProfileAppService { get; set; }

        [Inject] protected ISettingProvider SettingManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            var user = await ProfileAppService.GetAsync();
            PersonalInfoModel = ObjectMapper.Map<ProfileDto, PersonalInfoModel>(user);

            isUserNameUpdateEnabled = string.Equals(
                await SettingManager.GetOrNullAsync(IdentitySettingNames.User.IsUserNameUpdateEnabled), "true", StringComparison.OrdinalIgnoreCase);
            isEmailUpdateEnabled = string.Equals(
                await SettingManager.GetOrNullAsync(IdentitySettingNames.User.IsEmailUpdateEnabled), "true", StringComparison.OrdinalIgnoreCase);
        }
        protected bool UpdateInfoSubmiting { get; set; }
        protected async Task UpdatePersonalInfoAsync()
        {
            try
            {
                if (!(PersonalInfoForm?.Validate() ?? true)) { return; }

                UpdateInfoSubmiting = true;
                await ProfileAppService.UpdateAsync(
                    ObjectMapper.Map<PersonalInfoModel, UpdateProfileDto>(PersonalInfoModel)
                    );
                _ = Message.Success(L["PersonalSettingsSaved"]);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
            finally
            {
                UpdateInfoSubmiting = false;
                await InvokeAsync(StateHasChanged);
            }
        }
    }

    public class PersonalInfoModel //: IHasConcurrencyStamp
    {
        [Required]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxUserNameLength))]
        [Display(Name = "DisplayName:UserName")]
        public string UserName { get; set; }

        [Required]
        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxEmailLength))]
        [Display(Name = "DisplayName:Email")]
        public string Email { get; set; }

        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxNameLength))]
        [Display(Name = "DisplayName:Name")]
        public string Name { get; set; }

        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxSurnameLength))]
        [Display(Name = "DisplayName:Surname")]
        public string Surname { get; set; }

        [DynamicStringLength(typeof(IdentityUserConsts), nameof(IdentityUserConsts.MaxPhoneNumberLength))]
        [Display(Name = "DisplayName:PhoneNumber")]
        public string PhoneNumber { get; set; }

        //[HiddenInput]
        //public string ConcurrencyStamp { get; set; }
    }
}
