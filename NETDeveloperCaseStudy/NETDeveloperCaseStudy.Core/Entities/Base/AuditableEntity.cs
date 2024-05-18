using NETDeveloperCaseStudy.Core.Entities.Interfaces;

namespace NETDeveloperCaseStudy.Core.Entities.Base;
public abstract class AuditableEntity : BaseEntity, ISoftDeletableEntity
{
    public string? DeletedBy { get; set; }
    public DateTime? DeletedDate { get; set; }
}
