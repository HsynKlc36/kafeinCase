using Microsoft.AspNetCore.Identity;

namespace NETDeveloperCaseStudy.Entities.Configurations;
public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public  void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
        new IdentityRole
        {
            Name = "Admin",
            NormalizedName = "ADMIN"
        },
       new IdentityRole
       {
           Name = "Client",
           NormalizedName = "CLIENT"
       });
    }
}
