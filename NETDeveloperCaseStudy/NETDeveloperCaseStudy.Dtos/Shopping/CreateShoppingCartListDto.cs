namespace NETDeveloperCaseStudy.Dtos.Shopping;
public record CreateShoppingCartListDto
{
    public Guid CustomerId { get; init; }
    public List<CreateShoppingCartDto> ShoppingCartList { get; init; }
}