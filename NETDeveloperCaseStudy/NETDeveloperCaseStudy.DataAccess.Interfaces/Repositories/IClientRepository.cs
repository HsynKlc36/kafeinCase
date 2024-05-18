namespace NETDeveloperCaseStudy.DataAccess.Interfaces.Repositories;
public interface IClientRepository : IAsyncRepository, IAsyncTransactionRepository, IAsyncInsertableRepository<Client>, IAsyncFindableRepository<Client>, IAsyncUpdateableRepository<Client>, IAsyncDeleteableRepository<Client>, IAsyncIdentityRepository<Client>
{
}
