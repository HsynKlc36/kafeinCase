namespace NETDeveloperCaseStudy.Dtos.Shopping;
public record CreateShoppingCartDto
{
    public Guid ProductId { get; init; }
    public Guid MarketId { get; init; }
    public int Amount { get; init; }
}
