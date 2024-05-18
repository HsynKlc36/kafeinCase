namespace NETDeveloperCaseStudy.Core.DataAccess.Interfaces;
public interface IAsyncIdentityRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdentityId(string identityId);
}

