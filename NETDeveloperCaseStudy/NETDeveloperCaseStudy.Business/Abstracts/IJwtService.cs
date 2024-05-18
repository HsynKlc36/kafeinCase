using NETDeveloperCaseStudy.Core.Entities.BaseIdentities;

namespace NETDeveloperCaseStudy.Business.Abstracts;

public interface IJwtService
{
    /// <summary>
    /// Bu metot ile verilen bir BaseUser için JWT token'ı oluşturulmaktadır.
    /// </summary>
    /// <param name="user">Token'ı oluşturulacak BaseUser nesnesi</param>
    /// <returns>JwtSecurityTokenHandler().WriteToken(token)</returns>
    Task<string> GenerateTokenAsync(ExtendedIdentityUser user);

    /// <summary>
    /// Refresh token oluşturur!
    /// </summary>
    /// <returns></returns>
    string GenerateRefreshToken();

    ClaimsPrincipal? GetTokenPrincipal(string token);
}
