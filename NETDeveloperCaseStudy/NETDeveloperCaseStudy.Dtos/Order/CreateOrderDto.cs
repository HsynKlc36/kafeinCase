namespace NETDeveloperCaseStudy.Dtos.Order;
public class CreateOrderDto
{
    public Guid CustomerId { get; init; }
    public Guid MarketId { get; init; }
}
