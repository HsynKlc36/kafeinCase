using NETDeveloperCaseStudy.Entities.Enums;

namespace NETDeveloperCaseStudy.Dtos.Clients;
public record ClientDto
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Email { get; init; }
    public Gender Gender { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public string? IdentityId { get; init; }   
}


