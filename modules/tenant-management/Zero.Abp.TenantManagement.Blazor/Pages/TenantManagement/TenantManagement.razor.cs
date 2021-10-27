using AntDesign;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.ObjectExtending;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.Localization;
using Zero.Abp.AspNetCore.Components.Web.Extensibility.EntityActions;
using Zero.Abp.AspNetCore.Components.Web.Extensibility.TableColumns;
using Zero.Abp.AspNetCore.Components.Web.Extensibility.TableToolbar;
using Zero.Abp.AspNetCore.Components.Web.Theming.Extensibility;
using Zero.Abp.FeatureManagement.Blazor.Components;

namespace Zero.Abp.TenantManagement.Blazor.Pages.TenantManagement
{
    public partial class TenantManagement
    {

        protected FormValidateErrorMessages validateMessages = new FormValidateErrorMessages
        {
            Required = "'{0}' 是必选字段",
            // ...
        };



        protected const string FeatureProviderName = "T";

        protected bool HasManageFeaturesPermission;
        protected string ManageFeaturesPolicyName;

        protected FeatureManagementModal FeatureManagementModal;

        protected List<TableToolbarItem> TenantManagementTableToolbar => TableToolbar.Get<TenantManagement>();
        protected List<TableColumn> TenantManagementTableColumns => TableColumns.Get<TenantManagement>();

        public TenantManagement()
        {
            LocalizationResource = typeof(AbpTenantManagementResource);
            ObjectMapperContext = typeof(AbpTenantManagementBlazorModule);

            CreatePolicyName = TenantManagementPermissions.Tenants.Create;
            UpdatePolicyName = TenantManagementPermissions.Tenants.Update;
            DeletePolicyName = TenantManagementPermissions.Tenants.Delete;

            ManageFeaturesPolicyName = TenantManagementPermissions.Tenants.ManageFeatures;
        }

        protected override async Task SetPermissionsAsync()
        {
            await base.SetPermissionsAsync();
            HasManageFeaturesPermission = await AuthorizationService.IsGrantedAsync(ManageFeaturesPolicyName);
        }

        protected override string GetDeleteConfirmationMessage(TenantDto entity)
        {
            return string.Format(L["TenantDeletionConfirmationMessage"], entity.Name);
        }

        protected override ValueTask SetToolbarItemsAsync()
        {
            TenantManagementTableToolbar
                .AddButton(L["NewTenant"], OpenCreateModalAsync, "fa fa-plus", visible: () => HasCreatePermission);

            return base.SetToolbarItemsAsync();
        }

        protected override ValueTask SetEntityActionsAsync()
        {
            EntityActions
                .Get<TenantManagement>()
                .AddRange(new EntityAction[]
                {
                    new EntityAction
                    {
                        Text = L["Edit"],
                        Visible = (data) => HasUpdatePermission,
                        Clicked = async (data) => { await OpenEditModalAsync(data.As<TenantDto>()); }
                    },
                    new EntityAction
                    {
                        Text = L["Features"],
                        Visible = (data) => HasManageFeaturesPermission,
                        Clicked = async (data) =>
                        {
                            var tenant = data.As<TenantDto>();
                            await FeatureManagementModal.OpenAsync(FeatureProviderName, tenant.Id.ToString());
                        }
                    },
                    new EntityAction
                    {
                        Text = L["Delete"],
                        Visible = (data) => HasDeletePermission,
                        Clicked = async (data) => await DeleteEntityAsync(data.As<TenantDto>()),
                        ConfirmationMessage = (data) => GetDeleteConfirmationMessage(data.As<TenantDto>())
                    }
                });

            return base.SetEntityActionsAsync();
        }

        protected override ValueTask SetTableColumnsAsync()
        {
            TenantManagementTableColumns
                .AddRange(new TableColumn[]
                {
                    new TableColumn
                    {
                        Title = L["Actions"],
                        Actions = EntityActions.Get<TenantManagement>()
                    },
                    new TableColumn
                    {
                        Title = L["TenantName"],
                        Data = nameof(TenantDto.Name),
                    },
                });

            TenantManagementTableColumns.AddRange(GetExtensionTableColumns(
                TenantManagementModuleExtensionConsts.ModuleName,
                TenantManagementModuleExtensionConsts.EntityNames.Tenant));

            return base.SetTableColumnsAsync();
        }
    }
}