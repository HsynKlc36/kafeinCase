namespace NETDeveloperCaseStudy.DataAccess.EFCore.Repositories;
public class OrderRepository :EFBaseRepository<Order>,IOrderRepository
{
    private readonly CaseStudyWebApiDbContext _caseStudyDbContext;

    public OrderRepository(CaseStudyWebApiDbContext context) : base(context)
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
