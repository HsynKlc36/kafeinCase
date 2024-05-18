using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NETDeveloperCaseStudy.Core.Entities.EntityTypeConfigurations;
public class BaseEntityTypeConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Status).IsRequired();
        builder.Property(x => x.CreatedBy).HasMaxLength(128).IsRequired(false);
        builder.Property(x => x.CreatedDate).IsRequired();
        builder.Property(x => x.ModifiedBy).HasMaxLength(128).IsRequired(false);
        builder.Property(x => x.ModifiedDate).IsRequired(false);
    }
}
