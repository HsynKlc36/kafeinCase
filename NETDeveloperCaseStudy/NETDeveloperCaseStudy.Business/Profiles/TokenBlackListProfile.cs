using NETDeveloperCaseStudy.Dtos.TokenBlackList;

namespace NETDeveloperCaseStudy.Business.Profiles;
public class TokenBlackListProfile : Profile
{
    public TokenBlackListProfile()
    {
        CreateMap<TokenBlackListCreateDto, TokenBlackList>();
    }
}
