using NETDeveloperCaseStudy.Core.Entities.BaseIdentities;

namespace NETDeveloperCaseStudy.Business.Concretes;
public class ClientManager:IClientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailManager;
    private readonly UserManager<ExtendedIdentityUser> _userManager;
    private readonly IStringLocalizer<Resource> _stringLocalizer;
    private readonly ILoggerService _logger;

    public ClientManager(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailManager,  UserManager<ExtendedIdentityUser> userManager, IStringLocalizer<Resource> stringLocalizer,ILoggerService loggerService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _emailManager = emailManager;
        _userManager = userManager;
        _stringLocalizer = stringLocalizer;
        _logger = loggerService;
    }


    

    /// <summary>
    /// Bu metot ile Client silme işlemi yapılmaktadır.Sadece Client rolüne sahipse kullanıcıyı tamamen siler. 
    /// </summary>
    /// <param name="id">Silinecek Client nesnesi için verilen id parametresi</param>
    /// <returns> <see cref="ErrorResult"/> ,<see cref="SuccessResult"/></returns>
    public async Task<Result> DeleteAsync(Guid id)
    {
        try
        {
            var ClientUser = await _unitOfWork.ClientRepository.GetByIdAsync(id);
            if (ClientUser == null)
            {
                _logger.LogError(_stringLocalizer[LogMessages.ClientNotFound]);
                return new ErrorResult(_stringLocalizer[Messages.ClientNotFound]);
            }
                
            var identityUser = await _userManager.FindByIdAsync(ClientUser.IdentityId);
            var userRoles = await _userManager.GetRolesAsync(identityUser);

            var hasDifferentRoleFromClient = userRoles.Any(role => role != "Client");
            var result = !hasDifferentRoleFromClient ? await DeleteUserAsync(identityUser, ClientUser) : new ErrorResult(_stringLocalizer[Messages.ClientDeleteFail]);//bu satır kontrol edilecek!
            return result;
        }
        catch (Exception)
        {
            _logger.LogError(_stringLocalizer[LogMessages.ClientDeleteFail]);
            return new ErrorResult(_stringLocalizer[Messages.ClientDeleteFail]);
        }

    }

   
    /// <summary>
    /// Sadece Client rolü olan kullanıcıyı AspNetUser ve Client tablosundan silen method.
    /// </summary>
    /// <param name="identityUser"></param>
    /// <param name="clientUser"></param>
    /// <returns><see cref="ErrorResult"/>,<see cref="SuccessResult"/></returns>
    private async Task<Result> DeleteUserAsync(ExtendedIdentityUser identityUser, Client clientUser)
    {
        Result result = new ErrorResult(_stringLocalizer[Messages.DeleteFail]);

        using var transactionScope = await _unitOfWork.ClientRepository.BeginTransactionAsync();
        try
        {
            var deleteClientTask = _unitOfWork.ClientRepository.DeleteAsync(clientUser);
            var deleteUserTask = _userManager.DeleteAsync(identityUser);
            var tasks = new List<Task> { deleteClientTask, deleteUserTask };
            await Task.WhenAll(tasks);
            await _unitOfWork.ClientRepository.SaveChangesAsync();
            await transactionScope.CommitAsync();
            result = new SuccessResult(_stringLocalizer[Messages.DeleteSuccess]);
        }
        catch (Exception)
        {
            await transactionScope.RollbackAsync();
        }
        return result;
    }


    /// <summary>
    /// GetByIdAsync() metodu database de kayıtlı olan ve id si verilen Client'i çeker ve ClientDto'ya Map'leyerek ClientDto nesnesine çevirir.Bu nesneyi ve işlemin durumuna göre verilmek istenen mesajı ile birlikte döner.
    /// </summary>
    /// <param name="id">Detayları getirilmek istenen Client nesnesinin Guid tipinde Id si</param>
    /// <returns>SuccessDataResult<ClientDto>, ErrorDataResult<ClientDto></returns> 
    public async Task<IResult> GetByIdAsync(Guid id)
    {
        try
        {
            var client = await _unitOfWork.ClientRepository.GetByIdAsync(id);
            if (client == null)
            {
                _logger.LogError(_stringLocalizer[LogMessages.ClientNotFound]);
                return new ErrorDataResult<ClientDto>(_stringLocalizer[Messages.ClientNotFound]);
            }

            var clientDto = _mapper.Map<ClientDto>(client);
            return new SuccessDataResult<ClientDto>(clientDto, _stringLocalizer[Messages.FoundSuccess]);
        }
        catch (Exception)
        {
            _logger.LogError(_stringLocalizer[LogMessages.ClientFoundFail]);
            return new ErrorDataResult<ClientDto>(_stringLocalizer[Messages.ClientFoundFail]);
        }
        
    }


  
    /// <summary>
    /// identityid ile Client bilgilerini getitir.
    /// </summary>
    /// <param name="identityId"></param>
    /// <returns></returns>
    public async Task<IResult> GetByIdentityId(string identityId)
    {
        try
        {
            var hasClient = await _unitOfWork.ClientRepository.GetByIdentityId(identityId);
            if (hasClient == null)
            {
                _logger.LogError(_stringLocalizer[LogMessages.ClientNotFound]);
                return new ErrorDataResult<ClientDto>(_stringLocalizer[Messages.ClientNotFound]);
            }
            var clientDto = _mapper.Map<ClientDto>(hasClient);
            return new SuccessDataResult<ClientDto>(clientDto, _stringLocalizer[Messages.FoundSuccess]);
        }
        catch (Exception)
        {
            _logger.LogError(_stringLocalizer[LogMessages.ClientFoundFail]);
            return new ErrorDataResult<ClientDto>(_stringLocalizer[Messages.ClientFoundFail]);
        }

    }
}
