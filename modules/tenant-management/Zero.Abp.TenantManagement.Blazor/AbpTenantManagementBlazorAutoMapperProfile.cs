using AutoMapper;
using Volo.Abp.TenantManagement;

namespace Zero.Abp.TenantManagement.Blazor
{
    public class AbpTenantManagementBlazorAutoMapperProfile : Profile
    {
        public AbpTenantManagementBlazorAutoMapperProfile()
        {
            CreateMap<TenantDto, TenantUpdateDto>()
                .MapExtraProperties();
        }
    }
}
