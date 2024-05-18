namespace NETDeveloperCaseStudy.DataAccess.Interfaces.Repositories;
public interface IUnitOfWork
{
    IClientRepository ClientRepository { get; }
    ITokenBlackListRepository TokenBlackListRepository { get; }
    IOrderRepository OrderRepository { get; }
    IOrderDetailRepository OrderDetailRepository { get; }
    IProductMarketRepository ProductMarketRepository { get; }
    IProductRepository ProductRepository { get; }
    IMarketRepository MarketRepository { get; }
    ICategoryRepository CategoryRepository { get; }
}
