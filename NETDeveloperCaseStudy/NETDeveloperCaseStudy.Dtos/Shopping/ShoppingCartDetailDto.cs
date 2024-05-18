namespace NETDeveloperCaseStudy.Dtos.Shopping;
public record ShoppingCartDetailDto
{
    public string MarketName { get; init; } 
    public string ProductName { get; init; } 
    public int Amount { get; init; } 
    public decimal Price { get; init; } 
}
