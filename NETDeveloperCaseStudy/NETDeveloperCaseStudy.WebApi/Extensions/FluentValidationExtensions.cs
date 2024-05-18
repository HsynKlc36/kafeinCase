using FluentValidation;
using FluentValidation.AspNetCore;
using NETDeveloperCaseStudy.WebApi.ValidatorsFilter;
using System.Reflection;

namespace NETDeveloperCaseStudy.WebApi.Extensions;

/// <summary>
/// bu extensions DbSet modellerine uygulanacak olan fluent validasyonlarının çalıştırılmasını sağlayacak ve istekler esnasında metotlarda validasyon uygulanmış parametreler varsa filters ile filtreleyecek. Böylece başarısız gönderilen modeller api isteğine girmeden doğrudan badRequest olarak geri dönüş yapılacaktır.
/// </summary>
public static class FluentValidationExtensions
{
    public static IServiceCollection AddFluentValidationWithAssemblies(this IServiceCollection services)
    {
        services
        .AddFluentValidationAutoValidation(config => config.DisableDataAnnotationsValidation = true) //"config => config.DisableDataAnnotationsValidation = true" yapılmasının sebebi validation mesajları gelirken DATA ANNOTATİON tarafından düşen default mesajları devre dışı bırakmak için yapılmıştır.
        .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.AddControllers(options =>
        {
            options.Filters.Add(typeof(ApiValidatorFilter));//apiye gelen isteklerde modellere filtreleme uygulayan class'ı burada filtreleme yaparken kullanırız.Global filtreleme olan bu filtrelemeyi vermemiz yeterli olacaktır.Diğer spesifik filtrelemeyi eklemeye gerek yoktur ve uygulanma sırası GlobalFilter -> controllerFilter -> actionFiler -> parameterFilter şeklindedir ve glabalFilter her istekte uygulanır çünkü bir attribute değildir.Diğerleri ise çağırıldıklarında uygulanır ve uygulanma sırası yukarıda belirttiğimiz şekildedir

        });

        return services;
    }
}
