namespace NETDeveloperCaseStudy.Entities.DbSets;
public class ProductMarket : AuditableEntity //cross table(product ile market)
{
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public string CurrencyUnit { get; set; } = null!;
    public Guid ProductId { get; set; }
    public Guid MarketId { get; set; }
    //navigation properties
    public Product Product { get; set; }
    public Market Market { get; set; }
}
