namespace NETDeveloperCaseStudy.Core.Utilities.Results;
public class AuthResult
{
    public bool IsSuccess { get; set; }
    public string? Token { get; set; }
    public string? RefreshToken { get; set; }
    public string? Message { get; set; }
}
