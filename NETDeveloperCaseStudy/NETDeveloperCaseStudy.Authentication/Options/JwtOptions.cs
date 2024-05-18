namespace NETDeveloperCaseStudy.Authentication.Options;
public class JwtOptions
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string SecurityKey { get; set; }
    public TimeSpan ExpiredTime { get; set; }
}
