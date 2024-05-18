namespace NETDeveloperCaseStudy.Entities.Configurations;
public class ClientConfiguration:BaseUserEntityTypeConfiguration<Client>
{
    public override void Configure(EntityTypeBuilder<Client> builder)
    {
        base.Configure(builder);
        
    }
}
