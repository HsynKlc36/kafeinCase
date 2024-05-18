using Microsoft.AspNetCore.Mvc;
using NETDeveloperCaseStudy.Business.Abstracts;
using NETDeveloperCaseStudy.WebApi.ValidatorsFilter;

namespace NETDeveloperCaseStudy.WebApi.Areas.Client.Controllers.v1;

public class ClientController : ClientBaseController
{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }


    [HttpGet]
    [Route("[action]")]
    [ApiParametersValidatorFilter("identityId", "System.String")]
    public async Task<IActionResult> GetByIdentityId([FromQuery] string identityId)
    {
        var result = await _clientService.GetByIdentityId(identityId);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}
