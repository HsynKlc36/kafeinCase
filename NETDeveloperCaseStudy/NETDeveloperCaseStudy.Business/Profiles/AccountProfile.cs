using NETDeveloperCaseStudy.Core.Entities.BaseIdentities;

namespace NETDeveloperCaseStudy.Business.Profiles;
public class AccountProfile : Profile
{
    public AccountProfile()
    { 
        CreateMap<RegisterDto, Client>().ReverseMap();
        CreateMap<RegisterDto, ExtendedIdentityUser>().ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

    }
}
