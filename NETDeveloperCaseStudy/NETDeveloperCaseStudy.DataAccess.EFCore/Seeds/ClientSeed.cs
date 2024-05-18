using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NETDeveloperCaseStudy.Core.Entities.BaseIdentities;
using NETDeveloperCaseStudy.Core.Enums;
using NETDeveloperCaseStudy.Entities.Enums;
using System.Globalization;

namespace NETDeveloperCaseStudy.DataAccess.EFCore.Seeds;
internal class ClientSeed
{
    private const string ClientEmail = "huseyin_kilic96@hotmailcom";
    private const string ClientPassword = "Wxyz1234";

    public static async Task SeedAsync(IConfiguration configuration)
    {

        var dbContextBuilder = new DbContextOptionsBuilder<CaseStudyWebApiDbContext>();
        string? _getConnStringName = configuration.GetConnectionString(CaseStudyWebApiDbContext.ConnectionName);

        dbContextBuilder.UseMySql(_getConnStringName, ServerVersion.AutoDetect(_getConnStringName));

        using CaseStudyWebApiDbContext context = new(dbContextBuilder.Options);

        if (!context.Roles.Any())
        {
            await AddRoles(context);
        }

        if (!context.Users.Any(user => user.Email == ClientEmail))
        {
            await AddClient(context);
        }

        await Task.CompletedTask;
    }
    private static async Task AddClient(CaseStudyWebApiDbContext context)
    {
        ExtendedIdentityUser user = new()
        {
            UserName = ClientEmail,
            NormalizedUserName = ClientEmail.ToUpper(CultureInfo.InvariantCulture),
            Email = ClientEmail,
            NormalizedEmail = ClientEmail.ToUpper(CultureInfo.InvariantCulture),
            EmailConfirmed = true,
            LockoutEnabled = false,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };
        user.PasswordHash = new PasswordHasher<ExtendedIdentityUser>().HashPassword(user, ClientPassword);
        await context.Users.AddAsync(user);

        var clientRoleId = context.Roles.FirstOrDefault(role => role.Name == Roles.Client.ToString())!.Id;

        await context.UserRoles.AddAsync(new IdentityUserRole<string> { UserId = user.Id, RoleId = clientRoleId });

        context.Clients.Add(new Client
        {
            Status = Status.Added,
            CreatedBy = "Super-Admin",
            CreatedDate = DateTime.Now,
            ModifiedBy = "Super-Admin",
            ModifiedDate = DateTime.Now,
            FirstName = "Hüseyin",
            LastName = "KILIÇ",
            Email = ClientEmail,
            Gender = Gender.Male,
            DateOfBirth = new DateTime(1996, 10, 10),
            IdentityId = user.Id,
        });

        await context.SaveChangesAsync();
    }
    private static async Task AddRoles(CaseStudyWebApiDbContext context)
    {
        string[] roles = Enum.GetNames(typeof(Roles));
        for (int i = 0; i < roles.Length; i++)
        {
            if (await context.Roles.AnyAsync(role => role.Name == roles[i]))
            {
                continue;
            }

            await context.Roles.AddAsync(new IdentityRole(roles[i]));
        }
    }
}
