using NETDeveloperCaseStudy.Core.Entities.BaseIdentities;

namespace NETDeveloperCaseStudy.Business.Concretes;
public class AccountManager : IAccountService
{
    private readonly IEmailService _emailManager;
    private readonly UserManager<ExtendedIdentityUser> _userManager;
    private readonly IStringLocalizer<Resource> _stringLocalizer;
    private readonly SignInManager<ExtendedIdentityUser> _signInManager;
    private readonly IJwtService _jwtManager;
    private readonly IUnitOfWork _unitOfWork;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IMapper _mapper;
    private readonly ILoggerService _logger;
    private readonly RefreshTokenOptions _refreshTokenOptions;

    public AccountManager(IEmailService emailManager, UserManager<ExtendedIdentityUser> userManager, IStringLocalizer<Resource> stringLocalizer, SignInManager<ExtendedIdentityUser> signInManager, IJwtService jwtManager, IUnitOfWork unitOfWork, RoleManager<IdentityRole> roleManager, IOptions<RefreshTokenOptions> options, IMapper mapper, ILoggerService logger)
    {
        _emailManager = emailManager;
        _userManager = userManager;
        _stringLocalizer = stringLocalizer;
        _signInManager = signInManager;
        _jwtManager = jwtManager;
        _unitOfWork = unitOfWork;
        _roleManager = roleManager;
        _refreshTokenOptions = options.Value;
        _mapper = mapper;
        _logger = logger;
    }


    public async Task<AuthResult> LoginAsync(LoginDto loginDto)
    {
        try
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                _logger.LogError(_stringLocalizer[LogMessages.UserNotFound]);
                return new AuthResult
                {
                    IsSuccess = false,
                    Token = null,
                    RefreshToken = null,
                    Message = _stringLocalizer[Messages.UserNotFound]
                };
            }

            var isValidPassword = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if (!isValidPassword.Succeeded)
            {
                _logger.LogError(_stringLocalizer[LogMessages.UsernameOrPasswordIsWrong]);
                return new AuthResult
                {
                    IsSuccess = false,
                    Token = null,
                    RefreshToken = null,
                    Message = _stringLocalizer[Messages.UsernameOrPasswordIsWrong]
                };
            }

            string token = await _jwtManager.GenerateTokenAsync(user);
            string refreshToken = _jwtManager.GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiry = DateTime.Now.Add(_refreshTokenOptions.RefreshTokenExpiry);
            await _userManager.UpdateAsync(user);

            return new AuthResult
            {
                IsSuccess = true,
                Token = token,
                RefreshToken = refreshToken,
                Message = _stringLocalizer[Messages.TokenCreatedSuccessfully]
            };
        }
        catch (Exception)
        {
            _logger.LogError(_stringLocalizer[LogMessages.TokenCreationFailed]);
            return new AuthResult
            {
                IsSuccess = false,
                Token = null,
                RefreshToken = null,
                Message = _stringLocalizer[Messages.TokenCreationFailed]
            };
        }

    }
    public async Task<IResult> RegisterAsync(RegisterDto registerDto)
    {
        try
        {
            var isExistingEmail = await _unitOfWork.ClientRepository.AnyAsync(x => x.Email == registerDto.Email);
            if (isExistingEmail)
            {
                _logger.LogError(_stringLocalizer[LogMessages.SameEmailAddressAlreadyUsed]);
                return new ErrorResult(_stringLocalizer[Messages.SameEmailAddressAlreadyUsed]);
            }

            var existingIdentityUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingIdentityUser is not null)
            {
                _logger.LogError(_stringLocalizer[LogMessages.SameEmailAddressAlreadyUsed]);
                return new ErrorResult(_stringLocalizer[Messages.SameEmailAddressAlreadyUsed]);
            }

            return await RegisterNewClientAsync(registerDto);
        }
        catch (Exception)
        {
            _logger.LogError(_stringLocalizer[LogMessages.RegisterFail]);
            return new ErrorResult(_stringLocalizer[Messages.RegisterFail]);
        }
    }

    /// <summary>
    /// bu metot ile refresh token ve token yenileriz.Eğerki veritabanındaki refreshTokenExpiry geçerli ise fakat token geçersiz ise 401 döndüğünde yeni bir token ve refresh token üretmesi için bu metoda yönlendirilecektir ve eğerki refresh token geçerliyse ve ömrü tamamlanmış token kullanıcıya ait bir token ise yeni bir token ve refresh token üretecektir ve kullanıcı işlemlerine o token ile devam edecektir.Aksi durumda refresh token da geçersiz ise başarısız olacaktır ve kullanıcı tekrardan login olmak zorundadır.
    /// </summary>
    /// <param name="refreshTokenDto"></param>
    /// <returns></returns>
    public async Task<AuthResult> RefreshTokenAsync(RefreshTokenDto refreshTokenDto)
    {
        var response = new AuthResult();
        try
        {
            var principal = _jwtManager.GetTokenPrincipal(refreshTokenDto.Token);

            if (principal?.Identity?.Name is null)
            {
                response.Message = _stringLocalizer[Messages.TokenCreationFailed];
                return response;
            }

            var identityUser = await _userManager.FindByNameAsync(principal.Identity.Name);

            if (identityUser is null || identityUser.RefreshToken != refreshTokenDto.RefreshToken || identityUser.RefreshTokenExpiry < DateTime.Now)
            {
                response.Message = _stringLocalizer[Messages.TokenCreationFailed];
                return response;
            }

            response.IsSuccess = true;
            response.Token = await _jwtManager.GenerateTokenAsync(identityUser);
            response.RefreshToken = _jwtManager.GenerateRefreshToken();
            response.Message = _stringLocalizer[Messages.TokenCreatedSuccessfully];

            identityUser.RefreshToken = response.RefreshToken;
            identityUser.RefreshTokenExpiry = DateTime.Now.Add(_refreshTokenOptions.RefreshTokenExpiry);
            await _userManager.UpdateAsync(identityUser);

            return response;
        }
        catch (Exception)
        {
            _logger.LogError(_stringLocalizer[LogMessages.TokenValidateFailed]);
            response.Message = _stringLocalizer[Messages.TokenCreationFailed];
            return response;
        }

    }


    /// <summary>
    /// Sistemde olmayan bir kullanıcıyı register arayüzü ile  Client olarak sisteme eklemek için kullanılan private method.
    /// </summary>
    /// <param name="registerDto">Kullanıcı tarafından gönderilen ClientCreateDto nesnesi.</param>
    /// <returns>ErrorDataResult<ClientDto>, SuccessDataResult<ClientDto></returns>
    private async Task<IResult> RegisterNewClientAsync(RegisterDto registerDto)
    {
        Result result = new ErrorResult(_stringLocalizer[Messages.RegisterFail]);
        var strategy = await _unitOfWork.ClientRepository.CreateExecutionStrategy();
        await strategy.ExecuteAsync(async () =>
        {
            using var transactionScope = await _unitOfWork.ClientRepository.BeginTransactionAsync();
            try
            {
                ExtendedIdentityUser identityClient = _mapper.Map<ExtendedIdentityUser>(registerDto);
                var randomPassword = AuthenticationHelper.GenerateRandomPassword();
                var createIdentityUserResult = await _userManager.CreateAsync(identityClient, randomPassword);
                if (!createIdentityUserResult.Succeeded)
                    return;

                var createdIdentityUser = await _userManager.FindByEmailAsync(identityClient.Email!);
                var addToRoleResult = await _userManager.AddToRoleAsync(createdIdentityUser, "Client");
                if (!addToRoleResult.Succeeded)
                {
                    await transactionScope.RollbackAsync();
                    return;
                }
                var toBeCreatedClient = _mapper.Map<Client>(registerDto);

                toBeCreatedClient.IdentityId = createdIdentityUser.Id;
                var createdClient = await _unitOfWork.ClientRepository.AddAsync(toBeCreatedClient);
                await _unitOfWork.ClientRepository.SaveChangesAsync();
                await _emailManager.SendEmailAsync(createdClient.Email, randomPassword);
                await transactionScope.CommitAsync();
                result = new SuccessResult(_stringLocalizer[Messages.RegisterSuccess]);
            }
            catch (Exception)
            {
                await transactionScope.RollbackAsync();
            }
        });
        return result;
    }




}