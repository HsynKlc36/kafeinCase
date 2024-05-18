namespace NETDeveloperCaseStudy.Entities.DbSets;
public class Product : AuditableEntity
{
    public Product()
    {
        Markets = new HashSet<ProductMarket>();
        Orders = new HashSet<OrderDetail>();
    }
    public string Barcode { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Size { get; set; } = null!;
    public string Color { get; set; } = null!;
    public string? Description { get; set; }
    public string Brand { get; set; } = null!;
    public Guid CategoryId { get; set; }
    //navigation properties
    public Category Category { get; set; }
    public IEnumerable<ProductMarket>? Markets { get; set; }
    public IEnumerable<OrderDetail>? Orders { get; set; }
}
