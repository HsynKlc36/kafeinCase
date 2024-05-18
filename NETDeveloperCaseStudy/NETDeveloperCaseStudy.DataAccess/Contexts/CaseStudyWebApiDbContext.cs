using Microsoft.EntityFrameworkCore.Design;
using NETDeveloperCaseStudy.Core.Entities.BaseIdentities;


namespace NETDeveloperCaseStudy.DataAccess.Contexts;
public class CaseStudyWebApiDbContext : IdentityDbContext<ExtendedIdentityUser, IdentityRole, string>
{

    private readonly IHttpContextAccessor? _httpContextAccessor;
    public const string ConnectionName = "CaseStudyWebApi";

    public CaseStudyWebApiDbContext(DbContextOptions<CaseStudyWebApiDbContext> options, IHttpContextAccessor httpContextAccessor) : base(options)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public CaseStudyWebApiDbContext(DbContextOptions<CaseStudyWebApiDbContext> options) : base(options) { }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Market> Markets { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; } //(cross table) dbset olarak eklenmesine gerek yok fakat biz fiziksel olarak ekledik!
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductMarket> ProductMarkets { get; set; } //(cross table) dbset olarak eklenmesine gerek yok fakat biz fiziksel olarak ekledik!
    public DbSet<TokenBlackList> TokenBlackLists { get; set; }
    public DbSet<ExtendedIdentityUser> ExtendedIdentityUsers { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration).Assembly);//konfigurasyonları bu şekilde ekleriz

        base.OnModelCreating(modelBuilder);
    }
    public override int SaveChanges()
    {
        SetBaseProperties();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        SetBaseProperties();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void SetBaseProperties()
    {
        var entries = ChangeTracker.Entries<BaseEntity>();

        var user = _httpContextAccessor?.HttpContext!.User;
        var userId = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value ?? "NotFound-User";

        foreach (var entry in entries)
        {
            SetIfAdded(entry, userId);
            SetIfModified(entry, userId);
            SetIfDeleted(entry, userId);
        }
    }

    private void SetIfDeleted(EntityEntry<BaseEntity> entry, string? userId)
    {
        if (entry.State is not EntityState.Deleted)
        {
            return;
        }

        if (entry.Entity is not AuditableEntity entity)
        {
            return;
        }

        entry.State = EntityState.Modified;

        entity.Status = Status.Deleted;
        entity.DeletedDate = DateTime.Now;
        entity.DeletedBy = userId;
    }

    private void SetIfModified(EntityEntry<BaseEntity> entry, string? userId)
    {
        if (entry.State != EntityState.Modified)
        {
            return;
        }
        entry.Entity.Status = Status.Active;
        entry.Entity.ModifiedBy = userId;
        entry.Entity.ModifiedDate = DateTime.Now;
    }

    private void SetIfAdded(EntityEntry<BaseEntity> entry, string? userId)
    {
        if (entry.State != EntityState.Added)
        {
            return;
        }


        entry.Entity.Status = Status.Active;
        //entry.Entity.CreatedBy = userId;
        entry.Entity.CreatedBy = entry.Entity.CreatedBy ?? userId;
        entry.Entity.CreatedDate = DateTime.Now;
    }
}
/// <summary>
///  Tasarım zamanında kullanılacak olan DbContext burada belirtmek(örneğini oluşturmak) gerekir.EF core da add-migration ve update-database işlemlerinde yani tasarım zamanlı işlemlerde ihtiyaca binayen örnek bir context nesnesi bu şekilde oluşturulabilir.Çünkü seed Data oluşturmamız tasarım zamanlı add-migration esnasında  design-time hatası vermekteydi, bu sebepten ötürü dbContext örneği oluşturarak kullanılmasını sağlamış oluruz. 
/// </summary>
public class CaseStudyWebApiDbContextFactory : IDesignTimeDbContextFactory<CaseStudyWebApiDbContext>
{
    public CaseStudyWebApiDbContext CreateDbContext(string[] args)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true)
            .Build();

        var builder = new DbContextOptionsBuilder<CaseStudyWebApiDbContext>();
        var connectionString = configuration.GetConnectionString(CaseStudyWebApiDbContext.ConnectionName);
        builder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

        return new CaseStudyWebApiDbContext(builder.Options);
    }
}

