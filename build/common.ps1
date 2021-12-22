$full = $args[0]

# COMMON PATHS 

$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = (Get-Item -Path "./" -Verbose).FullName

# List of solutions used only in development mode
$solutionPaths = @(
	"../"
)
	
$projects = @(
	"../antd-theme/Zero.Abp.AspNetCore.Components.Server.AntdTheme",
	"../antd-theme/Zero.Abp.AspNetCore.Components.Web.AntdTheme",
	"../antd-theme/Zero.Abp.AspNetCore.Components.WebAssembly.AntdTheme",

	"../basic-theme/Zero.Abp.AspNetCore.Components.Server.BasicTheme",
	"../basic-theme/Zero.Abp.AspNetCore.Components.Web.BasicTheme",
	"../basic-theme/Zero.Abp.AspNetCore.Components.WebAssembly.BasicTheme",

	"../framework/Zero.Abp.AntBlazor.Field",
	"../framework/Zero.Abp.AntBlazor.Layout",
	"../framework/Zero.Abp.AntBlazorUI",
	"../framework/Zero.Abp.AspNetCore.Components",
	"../framework/Zero.Abp.AspNetCore.Components.Server",
	"../framework/Zero.Abp.AspNetCore.Components.Server.Theming",
	"../framework/Zero.Abp.AspNetCore.Components.Web",
	"../framework/Zero.Abp.AspNetCore.Components.Web.Theming",
	"../framework/Zero.Abp.AspNetCore.Components.WebAssembly",
	"../framework/Zero.Abp.AspNetCore.Components.WebAssembly.Theming",
	"../framework/Zero.Abp.AspNetCore.Mvc.UI.Bundling",
	"../framework/Zero.Abp.Http.Client.IdentityModel.WebAssembly",

	"../modules/account/Zero.Abp.Account.Blazor",
	"../modules/account/Zero.Abp.Account.Blazor.Server",
	"../modules/account/Zero.Abp.Account.Blazor.WebAssembly",

	"../modules/feature-management/Zero.Abp.FeatureManagement.Blazor",
	"../modules/feature-management/Zero.Abp.FeatureManagement.Blazor.Server",
	"../modules/feature-management/Zero.Abp.FeatureManagement.Blazor.WebAssembly",

	"../modules/identity/Zero.Abp.Identity.Blazor",
	"../modules/identity/Zero.Abp.Identity.Blazor.Server",
	"../modules/identity/Zero.Abp.Identity.Blazor.WebAssembly",

	"../modules/permission-management/Zero.Abp.PermissionManagement.Blazor",
	"../modules/permission-management/Zero.Abp.PermissionManagement.Blazor.Server",
	"../modules/permission-management/Zero.Abp.PermissionManagement.Blazor.WebAssembly",

	"../modules/setting-management/Zero.Abp.SettingManagement.Blazor",
	"../modules/setting-management/Zero.Abp.SettingManagement.Blazor.Server",
	"../modules/setting-management/Zero.Abp.SettingManagement.Blazor.WebAssembly",

	"../modules/tenant-management/Zero.Abp.TenantManagement.Blazor",
	"../modules/tenant-management/Zero.Abp.TenantManagement.Blazor.Server",
	"../modules/tenant-management/Zero.Abp.TenantManagement.Blazor.WebAssembly"

)	

if ($full -eq "-f") {
	# List of additional solutions required for full build
	#	$solutionPaths += (
	#		"../modules/client-simulation",
	#		"../modules/virtual-file-explorer",
	#	) 
}
else { 
	Write-Host ""
	Write-Host ":::::::::::::: !!! You are in development mode !!! ::::::::::::::" -ForegroundColor red -BackgroundColor  yellow
	Write-Host "" 
} 