using AutoMapper;
using Volo.Abp.AutoMapper;
using Volo.Abp.Identity;
using Zero.Abp.Account.Blazor.Pages.Account.Components.ProfileManagementGroup;

namespace Zero.Abp.Account.Blazor
{
    public class AbpAccountBlazorAutoMapperProfile : Profile
    {
        public AbpAccountBlazorAutoMapperProfile()
        {
            CreateMap<ProfileDto, PersonalInfoModel>();
                //.Ignore(x => x.PhoneNumberConfirmed)
                //.Ignore(x => x.EmailConfirmed);

            CreateMap<PersonalInfoModel, UpdateProfileDto>()
                .Ignore(x => x.ExtraProperties);
        }
    }
}