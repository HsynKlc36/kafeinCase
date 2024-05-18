namespace NETDeveloperCaseStudy.Core.DataAccess.Interfaces;
public interface IAsyncRepository
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
