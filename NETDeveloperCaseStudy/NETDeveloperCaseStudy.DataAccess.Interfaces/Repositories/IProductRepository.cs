namespace NETDeveloperCaseStudy.DataAccess.Interfaces.Repositories;
public interface IProductRepository  : IAsyncFindableRepository<Product>, IAsyncInsertableRepository<Product>, IAsyncRepository, IAsyncDeleteableRepository<Product>, IAsyncUpdateableRepository<Product>
{
}
