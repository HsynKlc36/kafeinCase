using FluentValidation;
using Microsoft.Extensions.Localization;
using NETDeveloperCaseStudy.Business;
using NETDeveloperCaseStudy.Business.Constants;
using NETDeveloperCaseStudy.Dtos.Shopping;

namespace NETDeveloperCaseStudy.WebApi.Validators.ClientValidator;

public class CreateShoppingCartDtoValidator : AbstractValidator<CreateShoppingCartDto>
{
    private readonly IStringLocalizer<Resource> _stringLocalizer;
    public CreateShoppingCartDtoValidator(IStringLocalizer<Resource> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;

        RuleFor(x => x.ProductId)
            .NotEmpty().WithMessage(_stringLocalizer[ValidatorMessages.ProductIdNotNullOrEmpty])
            .Must(x => Guid.TryParse(x.ToString(), out _)).WithMessage(_stringLocalizer[ValidatorMessages.ProductIdControl]);
        RuleFor(x => x.MarketId)
            .NotEmpty().WithMessage(_stringLocalizer[ValidatorMessages.MarketIdNotNullOrEmpty])
            .Must(x => Guid.TryParse(x.ToString(), out _)).WithMessage(_stringLocalizer[ValidatorMessages.MarketIdControl]);
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage(_stringLocalizer[ValidatorMessages.AmountGreaterThan])
            .Must(BeValidInteger).WithMessage(_stringLocalizer[ValidatorMessages.AmountControl]);
    }

    private bool BeValidInteger(int value)
    {
        return value > 0;
    }
}
