using NETDeveloperCaseStudy.Core.Entities.BaseIdentities;

namespace NETDeveloperCaseStudy.Business.Profiles;
public class ClientProfile : Profile
{
    public ClientProfile()
    {
        CreateMap<Client, ClientDto>().ReverseMap();
        CreateMap<Client, ClientDetailsDto>();
        CreateMap<Client, ExtendedIdentityUser>().ForMember(x => x.Id, opt => opt.Ignore());

         

    }
}
