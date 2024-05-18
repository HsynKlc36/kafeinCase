namespace NETDeveloperCaseStudy.Business.Abstracts;

public interface IAccountService
{

    /// <summary>
    /// Bu metot Client nesnesinin, client tarafında register ile oluşturma işleminde kullanılmaktadır.Yani register ile oluşturulan kullanıcılar client rolüne sahip olacaktır.
    /// </summary>
    /// <param name="registerDto"></param>
    /// <returns>IResult</returns>
    Task<IResult> RegisterAsync(RegisterDto registerDto);

    /// <summary>
    /// Bu method gönderilen LoginDto nesnesin login işlemlerini kontrol eder.
    /// </summary>
    /// <param name="loginDto"> login için gerekli email ve şifre içeren dto</param>
    /// <returns>
    /// <see cref="AuthResult"/>
    /// </returns>
    Task<AuthResult> LoginAsync(LoginDto loginDto);

 
    /// <summary>
    /// token'ı biten kullanıcının refresh token'ını kontrol etmeye yarar eğer refresh token geçerli ise yeni bir token döner ve kullanıcı o token ile yoluna devam eder!
    /// </summary>
    /// <param name="refreshTokenDto"></param>
    /// <returns></returns>
    Task<AuthResult> RefreshTokenAsync(RefreshTokenDto refreshTokenDto);
}
