namespace NETDeveloperCaseStudy.Entities.DbSets;
public class Client : BaseUser
{
    public Client()
    {
        Orders = new HashSet<Order>();
    }
    //Navigation Properties
    public ICollection<Order>? Orders { get; set; }

}
