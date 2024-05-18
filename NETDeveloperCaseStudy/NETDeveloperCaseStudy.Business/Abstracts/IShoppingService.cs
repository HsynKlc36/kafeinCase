using NETDeveloperCaseStudy.Dtos.Shopping;

namespace NETDeveloperCaseStudy.Business.Abstracts;
public interface IShoppingService
{
    Task<IResult> CreateShoppingAsync(CreateShoppingCartListDto shoppingList);
}
