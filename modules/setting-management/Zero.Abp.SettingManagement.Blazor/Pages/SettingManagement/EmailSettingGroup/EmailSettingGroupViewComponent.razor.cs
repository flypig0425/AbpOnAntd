using Microsoft.AspNetCore.Components;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Localization;
using Zero.Abp.AspNetCore.Components.Messages;
using Zero.Abp.AspNetCore.Components.Web.Configuration;

namespace Zero.Abp.SettingManagement.Blazor.Pages.SettingManagement.EmailSettingGroup
{
    public partial class EmailSettingGroupViewComponent
    {
        [Inject]
        protected IEmailSettingsAppService EmailSettingsAppService { get; set; }

        [Inject]
        private ICurrentApplicationConfigurationCacheResetService CurrentApplicationConfigurationCacheResetService { get; set; }

        [Inject]
        protected IUiMessageService UiMessageService { get; set; }

        protected EmailSettingsDto EmailSettings = new EmailSettingsDto();

        //protected Validations IdentitySettingValidation;

        public EmailSettingGroupViewComponent()
        {
            ObjectMapperContext = typeof(AbpSettingManagementBlazorModule);
            LocalizationResource = typeof(AbpSettingManagementResource);
        }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                EmailSettings = await EmailSettingsAppService.GetAsync();
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }

        protected virtual async Task UpdateSettingsAsync()
        {
            try
            {
                await EmailSettingsAppService.UpdateAsync(ObjectMapper.Map<EmailSettingsDto, UpdateEmailSettingsDto>(EmailSettings));

                await CurrentApplicationConfigurationCacheResetService.ResetAsync();

                await UiMessageService.Success(L["SuccessfullySaved"]);
            }
            catch (Exception ex)
            {
                await HandleErrorAsync(ex);
            }
        }


        protected void OnFinishFailed()
        {
            Console.WriteLine($"Failed:{JsonSerializer.Serialize(EmailSettings)}");
        }
    }
}
