using NETDeveloperCaseStudy.DataAccess.EFCore.Seeds;
using NETDeveloperCaseStudy.Authentication.Options;
using Microsoft.Extensions.Configuration;

namespace NETDeveloperCaseStudy.DataAccess.EFCore.Extensions;
public static class DependencyInjection
{
    public static IServiceCollection AddEFCoreServices(this IServiceCollection services, IConfiguration configuration)
    {
        //tüm repo IOC' leri en son burada services'lara eklenir!

        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<ITokenBlackListRepository, TokenBlackListRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
        services.AddScoped<IProductMarketRepository, ProductMarketRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IMarketRepository, MarketRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>(); 
        services.AddScoped<JwtOptions>();
        services.AddScoped<RefreshTokenOptions>();
        services.AddScoped<EmailOptions>();
        services.AddScoped<OrderEmailOptions>();

        ClientSeed.SeedAsync(configuration).GetAwaiter().GetResult();//seed datayı ekledik
        return services;

    }
}
