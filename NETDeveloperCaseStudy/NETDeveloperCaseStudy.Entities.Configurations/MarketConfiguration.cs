using NETDeveloperCaseStudy.Core.Enums;

namespace NETDeveloperCaseStudy.Entities.Configurations;
public class MarketConfiguration : AuditableEntityTypeConfiguration<Market>
{
    public override void Configure(EntityTypeBuilder<Market> builder)
    {
        base.Configure(builder);
        builder.HasAlternateKey(m => m.Name);
        builder.HasAlternateKey(m => m.PhoneNumber);
        builder.Property(m => m.Name).HasMaxLength(64).IsRequired();
        builder.Property(m => m.Description).HasMaxLength(256).IsRequired(false);
        builder.Property(m => m.Address).HasMaxLength(256).IsRequired();
        builder.Property(m => m.PhoneNumber).HasMaxLength(11).IsRequired();
        #region HasData Markets
        builder.HasData(
            new Market { Id = Guid.Parse("266acab2-0fac-49e8-99e0-86da42d6cdc7"), Name = "A", Address = "İSTANBUL/Bostancı", PhoneNumber = "05555555555", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new Market { Id = Guid.Parse("d3c7760f-6166-4058-a343-9c6870ac391d"), Name = "B", Address = "İSTANBUL/Suadiye", PhoneNumber = "05555555554", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new Market { Id = Guid.Parse("de8bd1d1-3ea0-4b4f-9908-1e89419d88cc"), Name = "C", Address = "İSTANBUL/Etiler", PhoneNumber = "05555555553", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now }
            );
        #endregion
    }
}
