namespace NETDeveloperCaseStudy.DataAccess.EFCore.Repositories;
public class OrderDetailRepository :EFBaseRepository<OrderDetail>,IOrderDetailRepository
{
    private readonly CaseStudyWebApiDbContext _caseStudyDbContext;

    public OrderDetailRepository(CaseStudyWebApiDbContext context) : base(context)
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
