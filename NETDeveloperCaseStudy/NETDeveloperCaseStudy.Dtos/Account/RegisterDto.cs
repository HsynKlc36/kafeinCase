using NETDeveloperCaseStudy.Entities.Enums;

namespace NETDeveloperCaseStudy.Dtos.Account;
public record RegisterDto
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
    public string? Address { get; set; }
    public Gender Gender { get; init; }
    public DateTime? DateOfBirth { get; init; }


}
