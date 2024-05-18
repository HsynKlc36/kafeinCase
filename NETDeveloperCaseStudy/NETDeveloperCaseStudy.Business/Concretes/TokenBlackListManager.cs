using NETDeveloperCaseStudy.Dtos.TokenBlackList;
namespace NETDeveloperCaseStudy.Business.Concretes;
public class TokenBlackListManager : ITokenBlackListService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IStringLocalizer<Resource> _stringLocalizer;
    private readonly ILoggerService _logger;

    public TokenBlackListManager(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer<Resource> stringLocalizer,ILoggerService loggerService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _stringLocalizer = stringLocalizer;
        _logger = loggerService;
    }

    /// <summary>
    /// Bu metot yeni bir TokenBlackList nesnesi oluşturmak için kullanılmaktadır.
    /// </summary>
    /// <param name="token"></param>
    /// <returns></returns>
    public async Task<bool> CreateAsync(string token)
    {
        try
        {
            TokenBlackListCreateDto tokenBlackListCreateDto = new() { Token=token };

            var toBeCreated = _mapper.Map<TokenBlackList>(tokenBlackListCreateDto);

            await _unitOfWork.TokenBlackListRepository.AddAsync(toBeCreated);
            var isAdded = await _unitOfWork.TokenBlackListRepository.SaveChangesAsync() > 0;

            return isAdded;
        }
        catch (Exception)
        {
            _logger.LogError(_stringLocalizer[LogMessages.TokenBlackListCreationFailed]);
            throw;
        }
        
    }

}
