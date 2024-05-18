namespace NETDeveloperCaseStudy.Entities.DbSets;
public class Category :AuditableEntity
{
    public Category()
    {
        Products = new HashSet<Product>();
    }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    //navigation properties
    public ICollection<Product>? Products { get; set; }
}
