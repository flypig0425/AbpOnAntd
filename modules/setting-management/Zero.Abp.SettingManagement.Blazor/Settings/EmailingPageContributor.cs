﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;
using Volo.Abp.Features;
using Volo.Abp.MultiTenancy;
using Volo.Abp.SettingManagement;
using Volo.Abp.SettingManagement.Localization;
using Zero.Abp.SettingManagement.Blazor.Pages.SettingManagement.EmailSettingGroup;

namespace Zero.Abp.SettingManagement.Blazor.Settings
{
    public class EmailingPageContributor : ISettingComponentContributor
    {
        public async Task ConfigureAsync(SettingComponentCreationContext context)
        {
            if (!await CheckPermissionsInternalAsync(context))
            {
                return;
            }

            var l = context.ServiceProvider.GetRequiredService<IStringLocalizer<AbpSettingManagementResource>>();
            context.Groups.Add(
                new SettingComponentGroup(
                    "Volo.Abp.SettingManagement",
                    l["Menu:Emailing"],
                    typeof(EmailSettingGroupViewComponent)
                )
            );
        }

        public async Task<bool> CheckPermissionsAsync(SettingComponentCreationContext context)
        {
            return await CheckPermissionsInternalAsync(context);
        }

        private async Task<bool> CheckPermissionsInternalAsync(SettingComponentCreationContext context)
        {
            //if (!await CheckFeatureAsync(context))
            //{
            //    return false;
            //}

            var authorizationService = context.ServiceProvider.GetRequiredService<IAuthorizationService>();

            return await authorizationService.IsGrantedAsync(SettingManagementPermissions.Emailing);
        }

        //private async Task<bool> CheckFeatureAsync(SettingComponentCreationContext context)
        //{
        //    var currentTenant = context.ServiceProvider.GetRequiredService<ICurrentTenant>();

        //    if (!currentTenant.IsAvailable)
        //    {
        //        return true;
        //    }

        //    var featureCheck = context.ServiceProvider.GetRequiredService<IFeatureChecker>();

        //    return await featureCheck.IsEnabledAsync(SettingManagementFeatures.AllowTenantsToChangeEmailSettings);

        //}
    }
}
