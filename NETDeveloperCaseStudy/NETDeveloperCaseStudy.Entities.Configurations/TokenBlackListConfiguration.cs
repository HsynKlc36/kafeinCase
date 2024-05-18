namespace NETDeveloperCaseStudy.Entities.Configurations;
public class TokenBlackListConfiguration : AuditableEntityTypeConfiguration<TokenBlackList>
{
    public override void Configure(EntityTypeBuilder<TokenBlackList> builder)
    {
        base.Configure(builder);
        builder.Property(x => x.Token).IsRequired();
    }
}
