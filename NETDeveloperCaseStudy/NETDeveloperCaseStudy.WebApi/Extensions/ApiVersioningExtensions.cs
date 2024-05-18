using Asp.Versioning;

namespace NETDeveloperCaseStudy.WebApi.Extensions;
public static class ApiVersioningExtensions
{
    public static IServiceCollection AddApiVersioningExt(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.AssumeDefaultVersionWhenUnspecified = true; //Eğer bir isteğin üzerinde belirtilen API versiyonu yoksa, varsayılan olarak belirtilen versiyonu kullan.
            options.DefaultApiVersion = new ApiVersion(1, 0);//Varsayılan API versiyonunu 1 olarak ayarla.
            options.ReportApiVersions = true;//API versiyonlarını rapor et. Bu, API'nın hangi versiyonları desteklediğini bildiren bilgileri içeren bir bilgi başlığı ekler.
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("x-api-version"),
                new MediaTypeApiVersionReader("x-api-version"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";//API grup adı biçimini belirtir. Bu, API versiyonlarını gruplamak için kullanılır.
            options.SubstituteApiVersionInUrl = true;//URL içindeki {version} şablonunu belirtilen versiyonla değiştirir.
        });
        return services;
    }
}
