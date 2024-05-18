namespace NETDeveloperCaseStudy.DataAccess.Interfaces.Repositories;
public interface IOrderRepository  : IAsyncFindableRepository<Order>, IAsyncInsertableRepository<Order>, IAsyncRepository, IAsyncDeleteableRepository<Order>, IAsyncUpdateableRepository<Order>
{
}
