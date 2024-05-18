namespace NETDeveloperCaseStudy.Dtos.Account;
public record RefreshTokenDto
{
    public string Token { get; init; }
    public string RefreshToken { get; init; }
}
