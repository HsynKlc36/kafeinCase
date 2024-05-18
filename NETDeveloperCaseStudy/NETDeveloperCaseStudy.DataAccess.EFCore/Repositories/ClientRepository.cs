namespace NETDeveloperCaseStudy.DataAccess.EFCore.Repositories;
public class ClientRepository :EFBaseRepository<Client>, IClientRepository
{
    private readonly CaseStudyWebApiDbContext _caseStudyDbContext;

    public ClientRepository(CaseStudyWebApiDbContext context):base(context)
    {
        _caseStudyDbContext = context;
    }

    public Task<Client?> GetByIdentityId(string identityId)
    {
        return _table.FirstOrDefaultAsync(x => x.IdentityId == identityId);
    }
    public override int SaveChanges()
    {
        return _caseStudyDbContext.SaveChanges();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _caseStudyDbContext.SaveChangesAsync(cancellationToken);
    }
}
