namespace NETDeveloperCaseStudy.DataAccess.EFCore.Repositories;
public class CategoryRepository : EFBaseRepository<Category>, ICategoryRepository
{
    private readonly CaseStudyWebApiDbContext _caseStudyDbContext;

    public CategoryRepository(CaseStudyWebApiDbContext context) : base(context)
    {
        _caseStudyDbContext = context;
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
