using Asp.Versioning;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NETDeveloperCaseStudy.Authentication.Options;
using NETDeveloperCaseStudy.Business;
using NETDeveloperCaseStudy.Business.Abstracts;
using NETDeveloperCaseStudy.Business.Constants;
using NETDeveloperCaseStudy.Core.Entities.BaseIdentities;
using NETDeveloperCaseStudy.Core.Utilities.Results;
using NETDeveloperCaseStudy.Dtos.Account;

namespace NETDeveloperCaseStudy.WebApi.Controllers.v1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]// eğer başka bir versiyonlama çıkılan metotlar olursa bunun gibi eklenmeli
public class AccountController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly IAccountService _accountService;
    private readonly SignInManager<ExtendedIdentityUser> _signInManager;
    private readonly UserManager<ExtendedIdentityUser> _userManager;
    private readonly JwtOptions _jwtOptions;
    private readonly IEmailService _emailService;
    private readonly ITokenBlackListService _tokenBlackListService;
    private readonly IStringLocalizer<Resource> _stringLocalizer;

    public AccountController(IJwtService jwtService, IAccountService accountService, SignInManager<ExtendedIdentityUser> signInManager, UserManager<ExtendedIdentityUser> userManager, JwtOptions jwtOptions, IEmailService emailService, ITokenBlackListService tokenBlackListService, IStringLocalizer<Resource> stringLocalizer)
    {
        _jwtService = jwtService;
        _accountService = accountService;
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtOptions = jwtOptions;
        _emailService = emailService;
        _tokenBlackListService = tokenBlackListService;
        _stringLocalizer = stringLocalizer;
    }

    [HttpPost]
    [Route("[action]")]

    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {

        var user = await _userManager.FindByEmailAsync(loginDto.Email);
        if (user == null)
            return NotFound(_stringLocalizer[Messages.UserNotFound].Value);

        var loginResult = await _accountService.LoginAsync(loginDto);
        if (loginResult.IsSuccess)
            return Ok(loginResult);

        return BadRequest();

    }

    /// <summary>
    /// kullanıcı 401 alırsa token geçersiz olup refresh token'i kontrol etmek ve yeni bir token alabilmek için bu endpointe istek atılır.Geçerli değilse yine 401 döner ve client tarafında artık kullanıcının yeniden login olması gerektiği anlaşılarak tekrardan login ekranına yönlendirilir!
    /// </summary>
    /// <param name="refreshTokenDto"></param>
    /// <returns></returns>

    [HttpPost("[action]")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto refreshTokenDto)
    {
        var loginResult = await _accountService.RefreshTokenAsync(refreshTokenDto);
        if (loginResult.IsSuccess)
            return Ok(loginResult);

        return Unauthorized();
    }

    [HttpPost]
    [Route("[action]")]

    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var result = await _accountService.RegisterAsync(registerDto);
        return result.IsSuccess ? Ok(result) : BadRequest(result);

    }

    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = Roles.ClientRole)]
    [HttpPost]
    [Route("[action]")]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        //Token için verilen süreyi sıfırlar
        _jwtOptions.ExpiredTime = TimeSpan.Zero;
        //Mevcut token alınır
        var currentToken = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        //TokenBlackList e kaydedilir
        var result = await _tokenBlackListService.CreateAsync(currentToken);

        if (result)
        {
            return Ok(new AuthResult
            {
                IsSuccess = true,
                Token = null,
                Message = _stringLocalizer[Messages.LogoutSuccessfully]
            });
        }
        return BadRequest();
    }





}
