namespace NETDeveloperCaseStudy.Entities.DbSets;
public class Market : AuditableEntity 
{
    public Market()
    {
        Products=new HashSet<ProductMarket>();
        Orders=new HashSet<Order>();
    }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string Address { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    //navigation properties
    public ICollection<ProductMarket> Products { get; set; }
    public ICollection<Order>? Orders { get; set; }
}
