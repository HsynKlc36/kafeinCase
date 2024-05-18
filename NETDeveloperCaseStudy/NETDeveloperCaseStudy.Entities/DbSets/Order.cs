using System.ComponentModel.DataAnnotations.Schema;

namespace NETDeveloperCaseStudy.Entities.DbSets;
public class Order : AuditableEntity 
{
    public Order()
    {
        Products=new HashSet<OrderDetail>();
    }
    public Guid CustomerId { get; set; }
    public Guid MarketId { get; set; }
    //navigation Properties
    public Client Customer { get; set; }
    public Market Market { get; set; }
    public ICollection<OrderDetail> Products { get; set; }
}
