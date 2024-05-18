namespace NETDeveloperCaseStudy.DataAccess.Interfaces.Repositories;
public interface IProductMarketRepository: IAsyncFindableRepository<ProductMarket>, IAsyncInsertableRepository<ProductMarket>, IAsyncRepository, IAsyncDeleteableRepository<ProductMarket>, IAsyncUpdateableRepository<ProductMarket>
{
}
