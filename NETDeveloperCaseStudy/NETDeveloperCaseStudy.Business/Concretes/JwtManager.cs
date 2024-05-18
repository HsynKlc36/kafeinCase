using NETDeveloperCaseStudy.Core.Entities.BaseIdentities;
using System.Security.Cryptography;

namespace NETDeveloperCaseStudy.Business.Concretes;

public class JwtManager : IJwtService
{
    private readonly JwtOptions _jwtOptions;
    private readonly UserManager<ExtendedIdentityUser> _userManager;
    private readonly ILoggerService _logger;
    private readonly IStringLocalizer<Resource> _stringLocalizer;

    public JwtManager(IOptions<JwtOptions> options, UserManager<ExtendedIdentityUser> userManager, ILoggerService loggerService, IStringLocalizer<Resource> stringLocalizer)
    {
        _jwtOptions = options.Value;
        _userManager = userManager;
        _logger = loggerService;
        _stringLocalizer = stringLocalizer;
    }

    /// <summary>
    /// Bu metot ile Jwt'de bulunan SecurityKey encode edilip, dijital imzayı oluşturmak için şifreleme algoritması oluşturulur ve verilen bir kullanıcı için JWT token'ı oluşturulmaktadır.
    /// </summary>
    /// <param name="user">Token'ı oluşturulacak IdentityUser nesnesi</param>
    /// <returns>JwtSecurityTokenHandler().WriteToken(token)</returns>
    public async Task<string> GenerateTokenAsync(ExtendedIdentityUser user)
    {
        try
        {
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
            var identityRoles = (await _userManager.GetRolesAsync(user)).ToList();
            identityRoles.ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));

            var encodedKey = Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey); //Jwt'de bulunan SecurityKey'i encode ettik

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(encodedKey), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.Add(_jwtOptions.ExpiredTime),
                signingCredentials: signingCredentials
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
        catch (Exception)
        {
            _logger.LogError(_stringLocalizer[LogMessages.TokenCreationFailed]);
            throw;
        }

    }
    /// <summary>
    /// Refresh token oluşturan metottur
    /// </summary>
    /// <returns></returns>
    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[64];
        using var numberGenerator = RandomNumberGenerator.Create();
        numberGenerator.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
    /// <summary>
    /// token içerisindeki ClaimsPrincipal validasyonunu kontrol ederek claimsPrincipal geriye döndürür
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public ClaimsPrincipal? GetTokenPrincipal(string token)
    {
        try
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecurityKey));
            var validation = new TokenValidationParameters
            {
                // jwt ayarlarındaki(DataAccess.Extensions içerisindeki jwt validations'lar ile) validation'lar ile birebir aynı olmalıdır!
                ValidIssuer = _jwtOptions.Issuer,
                ValidAudience = _jwtOptions.Audience,
                IssuerSigningKey = securityKey,
                ValidateLifetime = false,//refresh token alabilmek için bu kontrolü kapattık
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                //LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.Now : false,//bu kontrol sağlansın ya da sağlanmasın jwt kütüphanesi default olarak bu kontrolü sağlayacak ve geçersiz olan jwt ler için 401 dönecektir!
                ClockSkew = TimeSpan.Zero
            };
            return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
        }
        catch (Exception)
        {
            _logger.LogError(_stringLocalizer[LogMessages.TokenValidateFailed]);
            return null;
        }

    }

}
