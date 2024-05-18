namespace NETDeveloperCaseStudy.DataAccess.Interfaces.Repositories;
public interface IMarketRepository : IAsyncFindableRepository<Market>, IAsyncInsertableRepository<Market>, IAsyncRepository, IAsyncDeleteableRepository<Market>, IAsyncUpdateableRepository<Market>
{
}
