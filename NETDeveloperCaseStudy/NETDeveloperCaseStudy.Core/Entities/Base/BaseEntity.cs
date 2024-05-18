using NETDeveloperCaseStudy.Core.Entities.Interfaces;

namespace NETDeveloperCaseStudy.Core.Entities.Base;
public abstract class BaseEntity : IEntity, ICreateableEntity, IUpdateableEntity
{
    public Guid Id { get; set; }
    public Status Status { get; set; }
    public string? CreatedBy { get; set; } 
    public DateTime CreatedDate { get; set; }
    public string? ModifiedBy { get; set; } 
    public DateTime? ModifiedDate { get; set; }
}
