using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NETDeveloperCaseStudy.WebApi.ValidatorsFilter;
public class ApiValidatorFilter : IAsyncActionFilter
{
    /// <summary>
    /// her api isteği geldiğinde gönderilen modellerin doğru yapıda gönderilip gönderilmediğinin filtreleme işlemi burada yapılacak ve başarılı işlemler giriş işlemleri başarılı ise api' ye ait metod içerisine girecek ve geçerli işlemleri gerçekleştirecektir.İşlemi kontrol ederken her metot içerisine giripte modelState.Isvalid mi kontrolüne gerek kalmadan bu sayede kontrolu sağlamış olacak.Peki bunu nasıl algılayacak, bu işlem ise FluentValidationExtensions içerisindeki  options.Filters.Add(typeof(ApiValidatorFilter)) ile sağlanacaktır.
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ModelState.IsValid)
        {
            var errors = context.ModelState
                .Where(x => x.Value!.Errors.Any())
                .ToDictionary(e => e.Key, e => e.Value!.Errors.Select(e => e.ErrorMessage))
                .ToArray();
            context.Result = new BadRequestObjectResult(errors);
            return;

        }
        await next();
    }
}
