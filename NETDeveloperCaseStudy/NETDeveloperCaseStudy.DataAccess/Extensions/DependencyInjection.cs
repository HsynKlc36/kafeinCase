using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using NETDeveloperCaseStudy.Core.Entities.BaseIdentities;

namespace NETDeveloperCaseStudy.DataAccess.Extensions;
public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<CaseStudyWebApiDbContext>(options =>
        {
            
            string? getConnectionName = configuration.GetConnectionString(CaseStudyWebApiDbContext.ConnectionName);
            options.UseMySql(getConnectionName, ServerVersion.AutoDetect(getConnectionName),builder=>
              builder.EnableRetryOnFailure(
                maxRetryCount: 8,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: new[] { 4060 }))
            .LogTo(
                filter: (eventId, level) => eventId.Id == CoreEventId.ExecutionStrategyRetrying,
                logger: eventData =>
                {
                    Console.WriteLine($"Bağlantı tekrar kurulmaktadır!");
                });

        });
        //Identity kütphanesinin sisteme entegre edilmesi.
        services.AddIdentity<ExtendedIdentityUser, IdentityRole>(options =>
        {
            //Identity için kullanılacak özelliklerin kurallarının belirlenmesi.
            //options.Password.RequiredLength = 8;
            options.Lockout.MaxFailedAccessAttempts = 5; //maksimum arka arkaya kaç hatalı giriş yapılabileceğini belirler.
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15); //hesabı kilitlenen kişilerin hesabının ne kadar süre ile kilitli kalacağını belirler.
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.User.RequireUniqueEmail = true; //email alanının benzersiz olmasını sağlar

        }).AddEntityFrameworkStores<CaseStudyWebApiDbContext>().AddDefaultTokenProviders();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
           .AddJwtBearer(options =>
           {
               options.SaveToken = true;
               options.TokenValidationParameters = new TokenValidationParameters()
               {
                   ValidIssuer = configuration["Jwt:Issuer"],
                   ValidAudience = configuration["Jwt:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecurityKey"]!)),
                   ValidateIssuer = true,
                   ValidateAudience = true,//şu anlık hangi sitelerin bu jwt yi kullanacağı belli olmadığı için false aldık! eğerki belli bir client'ın kullanmasını istiyorsak true'ya alıp appsetting içerisinde belirtmeliyiz!
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,//bu kontrol sağlansın ya da sağlanmasın jwt kütüphanesi default olarak bu kontrolü sağlayacak ve geçersiz olan jwt ler için 401 dönecektir!
                   ClockSkew = TimeSpan.Zero
               };

           });

        services.Configure<JwtOptions>(configuration.GetSection("Jwt"));
        services.Configure<RefreshTokenOptions>(configuration.GetSection("RefreshToken"));
        services.Configure<EmailOptions>(configuration.GetSection("EmailSettings"));
        services.Configure<OrderEmailOptions>(configuration.GetSection("OrderEmailSettings"));

        return services;
    }
}
