using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NETDeveloperCaseStudy.Entities.Enums;

namespace NETDeveloperCaseStudy.Core.Entities.EntityTypeConfigurations;
public class BaseUserEntityTypeConfiguration<TEntity> : AuditableEntityTypeConfiguration<TEntity> where TEntity : BaseUser
{
    public override void Configure(EntityTypeBuilder<TEntity> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.FirstName).IsRequired().HasMaxLength(256);
        builder.Property(x => x.LastName).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Email).IsRequired().HasMaxLength(256);
        builder.Property(x => x.Address).IsRequired(false).HasMaxLength(256);
        builder.Property(x => x.Gender)
            .HasConversion(
            g=>g.ToString(),
            g=>(Gender)Enum.Parse(typeof(Gender),g))
            .IsRequired();
        builder.Property(x => x.DateOfBirth).HasColumnType("date").IsRequired(false);
        builder.Property(x => x.IdentityId).IsRequired(false);
    }
}
