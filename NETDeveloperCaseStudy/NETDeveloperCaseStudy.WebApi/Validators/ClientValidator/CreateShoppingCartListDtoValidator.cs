using FluentValidation;
using Microsoft.Extensions.Localization;
using NETDeveloperCaseStudy.Business;
using NETDeveloperCaseStudy.Business.Constants;
using NETDeveloperCaseStudy.Dtos.Shopping;

namespace NETDeveloperCaseStudy.WebApi.Validators.ClientValidator;

public class CreateShoppingCartListDtoValidator : AbstractValidator<CreateShoppingCartListDto>
{
    private readonly IStringLocalizer<Resource> _stringLocalizer;
    public CreateShoppingCartListDtoValidator(IStringLocalizer<Resource> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;

        RuleFor(x => x.CustomerId)
            .NotEmpty().WithMessage(_stringLocalizer[ValidatorMessages.CustomerIdNotNullOrEmpty])
            .Must(x => Guid.TryParse(x.ToString(), out _)).WithMessage(_stringLocalizer[ValidatorMessages.CustomerIdControl]);

        RuleForEach(x => x.ShoppingCartList)
            .SetValidator(new CreateShoppingCartDtoValidator(_stringLocalizer));

    }

}
