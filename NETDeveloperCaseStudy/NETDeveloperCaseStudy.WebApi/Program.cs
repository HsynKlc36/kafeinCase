using NETDeveloperCaseStudy.Authentication.Options;
using NETDeveloperCaseStudy.Business.Extensions;
using NETDeveloperCaseStudy.DataAccess.EFCore.Extensions;
using NETDeveloperCaseStudy.DataAccess.Extensions;
using NETDeveloperCaseStudy.WebApi;
using NETDeveloperCaseStudy.WebApi.CustomMiddlewares;
using NETDeveloperCaseStudy.WebApi.Extensions;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDataAccessServices(builder.Configuration).AddEFCoreServices(builder.Configuration).AddBusinessServices();//extensionslarý ekledik
builder.Services.AddControllers();

#region NLog
//Loglama konfigürasyonunu yükler yani NLog.config XML tabanlý konfigurasyonu burada belirtiriz ve loglama yaparken config içeriisndeki bilgiler doðrultusunda loglama yapacaðýný söylemiþ oluruz!Bu loglama sadece developer' larýn geliþtirme sürecinde iþlerinin kolaylaþtýrýlmasý için oluþturuldu
LogManager.Setup().LoadConfigurationFromFile(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
#endregion

#region Swagger
// Printing Swagger Token.
builder.Services.AddSwaggerGen(setup =>
{
    // Include 'SecurityScheme' to use JWT Authentication
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
    setup.OperationFilter<CustomHeaderSwaggerAttribute>();
});
#endregion

builder.Services.AddEndpointsApiExplorer();
#region FluentValidationAndApiVersioningExtensions
builder.Services.AddFluentValidationWithAssemblies();//fluent validation ve filtreleme için yazýlan extensions
builder.Services.AddApiVersioningExt();//api versionlama için yazýlan extensions
#endregion

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

#region CustomTokenMiddleware
//custom olarak yazýlan token middleware eklendi.
app.UseMiddleware<TokenValidationMiddleware>();
#endregion

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
#region LocalizationOptions
var locOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(locOptions.Value);
#endregion
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
