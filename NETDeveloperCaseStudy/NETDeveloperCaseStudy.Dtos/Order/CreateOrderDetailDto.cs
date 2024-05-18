namespace NETDeveloperCaseStudy.Dtos.Order;
public record CreateOrderDetailDto
{
    public Guid OrderId { get; set; }
    public Guid ProductId { get; set; }
    public int Amount { get; set; }
}
