using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace NETDeveloperCaseStudy.WebApi.ValidatorsFilter;

public class ApiParametersValidatorFilterAttribute : Attribute, IAsyncActionFilter
{
    private readonly List<(string Name, Type Type)> _parameters;

    public ApiParametersValidatorFilterAttribute(params string[] parameterNamesAndTypes)
    {
        if (parameterNamesAndTypes.Length % 2 != 0)
        {
            throw new ArgumentException("Parameters and types do not match.");
        }
        _parameters = new List<(string Name, Type Type)>();

        for (int i = 0; i < parameterNamesAndTypes.Length; i += 2)
        {
            string name = parameterNamesAndTypes[i];
            Type? type = Type.GetType(parameterNamesAndTypes[i + 1]);
            _parameters.Add((name, type!));
        }
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var invalidParameters = new List<string>();

        foreach (var (name, type) in _parameters)
        {
            if (context.ActionArguments.TryGetValue(name, out var value))
            {
                if ( value == null || (type == typeof(string) && string.IsNullOrWhiteSpace(value?.ToString()?.Trim())))
                {
                    invalidParameters.Add(name);
                }
                
                else if (type == typeof(Guid))
                {
                    if (!Guid.TryParse(value.ToString(), out var guid) || guid==Guid.Empty)
                    {
                        invalidParameters.Add(name);
                    }
                   
                }
                else if (type == typeof(int))
                {
                    if (!int.TryParse(value.ToString(), out _))
                    {
                        invalidParameters.Add(name);
                    }
                }
              
            }
            else
            {
                invalidParameters.Add(name);
            }
        }

        if (invalidParameters.Any())
        {
            var errorMessages = $"Parameters '{string.Join(", ", invalidParameters)}' are invalid.";
            var errors = new Dictionary<string, IEnumerable<string>> { { "Error", new List<string> { errorMessages } } };
            context.Result = new BadRequestObjectResult(errors);
            return;
        }

        await next();
    }
}
