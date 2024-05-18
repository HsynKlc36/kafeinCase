using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using NETDeveloperCaseStudy.Business.RabbitMQ;
using System.Globalization;
using System.Reflection;

namespace NETDeveloperCaseStudy.Business.Extensions;

public static class DependencyInjection
{
    private const string TurkishLanguageCode = "tr-TR";
    private const string EnglishLanguageCode = "en-US";

    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        // AutoMapper
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //Her gelen request için oluşturulacak instance oluşturuyor
        services.AddScoped<ILoggerService, LoggerManager>();
        services.AddScoped<IClientService, ClientManager>();
        services.AddScoped<IJwtService, JwtManager>();
        services.AddScoped<IEmailService, EmailManager>();
        services.AddScoped<IAccountService, AccountManager>();
        services.AddScoped<ITokenBlackListService, TokenBlackListManager>();
        services.AddScoped<IShoppingService, ShoppingManager>();
        services.AddSingleton<RabbitMQService>();
        services.AddHostedService<RabbitMQEmailWorker>();
        //Bu servisler error ve success messagge'lar için kullanılacak Localization extension'ının sisteme entegre edilmesini içerir.
        services.AddLocalization();
        services.Configure<RequestLocalizationOptions>(options =>
        {
            var supportedCultures = new[]
            {
                new CultureInfo(TurkishLanguageCode),
                new CultureInfo(EnglishLanguageCode),
            };
            options.SupportedCultures = supportedCultures;
            options.SupportedUICultures = supportedCultures;

            options.DefaultRequestCulture = new RequestCulture(EnglishLanguageCode);

            options.RequestCultureProviders.Insert(0, new CustomRequestCultureProvider(async context =>
            {
                string defaultLanguage = EnglishLanguageCode;
                var languages = context.Request.Headers["Accept-Language"].ToString().Split(',');
                if (languages.Any(a => a.Contains("tr")))
                    defaultLanguage = TurkishLanguageCode;

                return await Task.FromResult(new ProviderCultureResult(defaultLanguage, defaultLanguage));
            }));
        });


        return services;
    }
}
