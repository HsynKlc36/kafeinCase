using NETDeveloperCaseStudy.Entities.Enums;

namespace NETDeveloperCaseStudy.Core.Entities.Base;
public abstract class BaseUser : AuditableEntity
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; } = null!;
    public string? Address { get; set; }
    public Gender Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? IdentityId { get; set; }


}
