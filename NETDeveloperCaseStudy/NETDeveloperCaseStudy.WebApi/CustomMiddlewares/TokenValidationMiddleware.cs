using NETDeveloperCaseStudy.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace NETDeveloperCaseStudy.WebApi.CustomMiddlewares;
public class TokenValidationMiddleware
{
    private readonly RequestDelegate _next;

    public TokenValidationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpcontext)
    {
        var token = httpcontext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();// süresi geçmiş bir jwt burada token değişkenine null olarak atanacaktır. yani headers den null değerini alacaktir!
        if (!string.IsNullOrEmpty(token))
        {
            var dbContext = httpcontext.RequestServices.GetService<CaseStudyWebApiDbContext>();
            var isTokenBlacklisted = await dbContext!.TokenBlackLists.AnyAsync(t => t.Token == token);

            if (isTokenBlacklisted)
            {
                httpcontext.Response.StatusCode = 401; // Unauthorized
                return;
            }
        }

        await _next(httpcontext);
    }
}
