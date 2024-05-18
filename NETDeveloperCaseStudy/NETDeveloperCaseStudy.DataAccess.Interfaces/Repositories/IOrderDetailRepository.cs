namespace NETDeveloperCaseStudy.DataAccess.Interfaces.Repositories;
public interface IOrderDetailRepository : IAsyncFindableRepository<OrderDetail>, IAsyncInsertableRepository<OrderDetail>, IAsyncRepository, IAsyncDeleteableRepository<OrderDetail>, IAsyncUpdateableRepository<OrderDetail>
{
}
