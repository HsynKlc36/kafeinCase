using NETDeveloperCaseStudy.Business.RabbitMQ;
using NETDeveloperCaseStudy.Dtos.Order;
using NETDeveloperCaseStudy.Dtos.Shopping;

namespace NETDeveloperCaseStudy.Business.Concretes;
public class ShoppingManager : IShoppingService
{
    private readonly IEmailService _emailManager;
    private readonly IClientService _clientService;
    private readonly IStringLocalizer<Resource> _stringLocalizer;
    private readonly IUnitOfWork _unitOfWork;
    private readonly RabbitMQService _rabbitMQService;
    private readonly IMapper _mapper;
    private readonly ILoggerService _logger;

    public ShoppingManager(IEmailService emailManager, IClientService clientService, IStringLocalizer<Resource> stringLocalizer, IUnitOfWork unitOfWork, RabbitMQService rabbitMQService, IMapper mapper, ILoggerService logger)
    {
        _emailManager = emailManager;
        _clientService = clientService;
        _stringLocalizer = stringLocalizer;
        _unitOfWork = unitOfWork;
        _rabbitMQService = rabbitMQService;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<IResult> CreateShoppingAsync(CreateShoppingCartListDto shoppingList)
    {

        if (shoppingList.ShoppingCartList.IsNullOrEmpty())
        {
            _logger.LogError(_stringLocalizer[LogMessages.ShoppingCartNotFound]);
            return new ErrorResult(_stringLocalizer[Messages.ShoppingCartNotFound]);
        }
        var client = (DataResult<ClientDto>)await _clientService.GetByIdAsync(shoppingList.CustomerId);
        if (!client.IsSuccess)
        {
            _logger.LogError(_stringLocalizer[LogMessages.UserNotFound]);
            return new ErrorResult(_stringLocalizer[Messages.UserNotFound]);
        }
        var marketListDistinct = shoppingList.ShoppingCartList.DistinctBy(x => x.MarketId).Select(s => s.MarketId).ToList();
        List<ShoppingCartDetailDto?> shoppingCartDetailList = new();
        try
        {
            foreach (var marketId in marketListDistinct)
            {
                var market = await _unitOfWork.MarketRepository.GetByIdAsync(marketId);
                if (market is null)
                    continue;

                CreateOrderDto createOrderDto = new()
                {
                    CustomerId = shoppingList.CustomerId,
                    MarketId = marketId
                };

                var order = _mapper.Map<CreateOrderDto, Order>(createOrderDto);
                var createdOrder = await _unitOfWork.OrderRepository.AddAsync(order);
                await _unitOfWork.OrderRepository.SaveChangesAsync();

                var orderId = createdOrder.Id;
                var orderDetailsForMarket = shoppingList.ShoppingCartList.Where(x => x.MarketId == marketId);

                foreach (var orderDetailDto in orderDetailsForMarket)
                {
                    var product = await _unitOfWork.ProductRepository.GetByIdAsync(orderDetailDto.ProductId);
                    if (product is null)
                        continue;
                    var productMarket = await _unitOfWork.ProductMarketRepository.GetAsync(x => x.MarketId == orderDetailDto.MarketId && x.ProductId == orderDetailDto.ProductId);

                    if (productMarket is null && productMarket!.Stock < orderDetailDto.Amount)
                        continue;

                    CreateOrderDetailDto createOrderDetailDto = new()
                    {
                        OrderId = orderId,
                        ProductId = orderDetailDto.ProductId,
                        Amount = orderDetailDto.Amount
                    };

                    var orderDetail = _mapper.Map<CreateOrderDetailDto, OrderDetail>(createOrderDetailDto);
                    await _unitOfWork.OrderDetailRepository.AddAsync(orderDetail);
                    productMarket.Stock -= orderDetailDto.Amount;

                    var shoppingDetail = new ShoppingCartDetailDto
                    {
                        MarketName = market.Name,
                        ProductName = product.Name,
                        Amount = orderDetailDto.Amount,
                        Price = productMarket.Price,
                    };
                    shoppingCartDetailList.Add(shoppingDetail);
                }
            }
            await _unitOfWork.ProductMarketRepository.SaveChangesAsync();
            if (!shoppingCartDetailList.Any())
            {
                _logger.LogError(_stringLocalizer[LogMessages.ShoppingCartEmpty]);
                return new ErrorResult(_stringLocalizer[Messages.ShoppingCartEmpty]);
            }

            await _rabbitMQService.SendMessage("orderEmail_queue", new { ToEmail = client.Data!.Email, ShoppingCartDetailList = shoppingCartDetailList });
            //faturalandırma işlemlerin burada yapıldığı düşünülsün! 
            return new SuccessResult(_stringLocalizer[Messages.ShoppingCartSuccess]);

        }
        catch (Exception)
        {
            _logger.LogError(_stringLocalizer[LogMessages.ShoppingCartFailed]);
            return new ErrorResult(_stringLocalizer[Messages.ShoppingCartFailed]);
        }
    }

}
