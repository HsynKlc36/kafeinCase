using Microsoft.AspNetCore.Mvc;
using NETDeveloperCaseStudy.Business.Abstracts;
using NETDeveloperCaseStudy.Dtos.Shopping;

namespace NETDeveloperCaseStudy.WebApi.Areas.Client.Controllers.v1;

public class ShoppingCartController : ClientBaseController
{
    private readonly IShoppingService _shoppingService;

    public ShoppingCartController(IShoppingService shoppingService)
    {
        _shoppingService = shoppingService;
    }
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateShoppingCartListDto createShoppingCartListDto)
    {
        var result = await _shoppingService.CreateShoppingAsync(createShoppingCartListDto);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
