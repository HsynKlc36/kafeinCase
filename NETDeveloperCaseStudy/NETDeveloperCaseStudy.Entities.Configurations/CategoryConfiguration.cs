using NETDeveloperCaseStudy.Core.Enums;

namespace NETDeveloperCaseStudy.Entities.Configurations;
public class CategoryConfiguration : AuditableEntityTypeConfiguration<Category>
{
    public override void Configure(EntityTypeBuilder<Category> builder)
    {
        base.Configure(builder);
        builder.HasAlternateKey(c => c.Name);
        builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(256).IsRequired(false);
        #region HasData Categories
        builder.HasData(
            new Category { Id = Guid.Parse("972c7033-09ab-4dd7-97d7-4b1e892a77bb"), Name = "Üst Giyim", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new Category { Id = Guid.Parse("47f0cacd-7e44-4989-8eee-2ba09e470abd"), Name = "Dış Giyim", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now },
            new Category { Id = Guid.Parse("40e576f2-63c3-45eb-827f-389113dcdfd4"), Name = "Alt Giyim", Status = Status.Active, CreatedBy = "NotFound-User", CreatedDate = DateTime.Now }
             );
        #endregion

    }
}
