using AutoMapper;
using Volo.Abp.SettingManagement;

namespace Zero.Abp.SettingManagement.Blazor
{
    public class SettingManagementBlazorAutoMapperProfile : Profile
    {
        public SettingManagementBlazorAutoMapperProfile()
        {
            CreateMap<EmailSettingsDto, UpdateEmailSettingsDto>();
        }
    }
}
