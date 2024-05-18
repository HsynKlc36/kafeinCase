namespace NETDeveloperCaseStudy.Entities.DbSets;
public class OrderDetail : AuditableEntity//cross table(order ile product)
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Amount { get; set; }
    //navigation properties
    public Order Order { get; set; }
    public Product Product { get; set; }
}
