using Microsoft.AspNetCore.Identity;

namespace NETDeveloperCaseStudy.Core.Entities.BaseIdentities;
public class ExtendedIdentityUser : IdentityUser 
{
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiry { get; set; }
}
