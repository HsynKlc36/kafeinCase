namespace NETDeveloperCaseStudy.DataAccess.EFCore.Repositories;
public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly CaseStudyWebApiDbContext _dbContext;

    private IClientRepository _clientRepository;
    private ITokenBlackListRepository _tokenBlackListRepository;
    private IMarketRepository _marketRepository;
    private IProductMarketRepository _productMarketRepository;
    private IProductRepository _productRepository;
    private IOrderDetailRepository _orderDetailRepository;
    private IOrderRepository _orderRepository;
    private ICategoryRepository _categoryRepository;

    public UnitOfWork(CaseStudyWebApiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IClientRepository ClientRepository => _clientRepository ?? (_clientRepository = new ClientRepository(_dbContext));
    public ITokenBlackListRepository TokenBlackListRepository => _tokenBlackListRepository ?? (_tokenBlackListRepository = new TokenBlackListRepository(_dbContext));
    public IMarketRepository MarketRepository => _marketRepository ?? (_marketRepository = new MarketRepository(_dbContext));
    public IProductRepository ProductRepository => _productRepository ?? (_productRepository = new ProductRepository(_dbContext));
    public IProductMarketRepository ProductMarketRepository => _productMarketRepository ?? (_productMarketRepository = new ProductMarketRepository(_dbContext));
    public IOrderDetailRepository OrderDetailRepository => _orderDetailRepository ?? (_orderDetailRepository = new OrderDetailRepository(_dbContext));
    public IOrderRepository OrderRepository => _orderRepository ?? (_orderRepository = new OrderRepository(_dbContext));
    public ICategoryRepository CategoryRepository => _categoryRepository ?? (_categoryRepository = new CategoryRepository(_dbContext));
 
    public void Dispose()
    {
        _dbContext.Dispose();
    }
}
