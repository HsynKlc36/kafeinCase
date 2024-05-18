using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NETDeveloperCaseStudy.Business.Constants;

namespace NETDeveloperCaseStudy.WebApi.Areas.Client.Controllers.v1;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ClientRole)]
[Area("Client")]
[ApiController]
[Route("api/v{version:apiVersion}/[area]/[controller]")]
[ApiVersion("1.0")]// default version yinede ekledik

public class ClientBaseController : ControllerBase
{
}
