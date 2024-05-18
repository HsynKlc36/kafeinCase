using FluentValidation;
using NETDeveloperCaseStudy.Business;
using NETDeveloperCaseStudy.Business.Constants;
using NETDeveloperCaseStudy.Dtos.Account;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace NETDeveloperCaseStudy.WebApi.Validators.AuthValidator;

public class RegisterDtoValidator : AbstractValidator<RegisterDto>
{
    private readonly IStringLocalizer<Resource> _stringLocalizer;

    public RegisterDtoValidator(IStringLocalizer<Resource> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;

        RuleFor(x => x.FirstName)
             .NotEmpty().WithMessage($"{_stringLocalizer[ValidatorMessages.FirstNameNotEmpty]}")
             .MaximumLength(50).WithMessage($"{_stringLocalizer[ValidatorMessages.FirstNameMaxLength]}")
             .MinimumLength(2).WithMessage($"{_stringLocalizer[ValidatorMessages.FirstNameMinLength]}")
             .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage($"{_stringLocalizer[ValidatorMessages.FirstNameMatches]}");

        RuleFor(x => x.LastName)
             .NotEmpty().WithMessage($"{_stringLocalizer[ValidatorMessages.LastNameNotEmpty]}")
             .MaximumLength(50).WithMessage($"{_stringLocalizer[ValidatorMessages.LastNameMaxLength]}")
             .MinimumLength(2).WithMessage($"{_stringLocalizer[ValidatorMessages.LastNameMinLength]}")
             .Matches("^[a-zA-ZğüşıöçĞÜŞİÖÇ\\s]+$").WithMessage($"{_stringLocalizer[ValidatorMessages.LastNameMatches]}");

        RuleFor(x => x.Email)
           //.Cascade(CascadeMode.Stop)
           .NotEmpty()
           .WithMessage($"{_stringLocalizer[ValidatorMessages.EmailNotEmpty]}")
           .Must(IsValidEmail)
           .WithMessage($"{_stringLocalizer[ValidatorMessages.EmailControl]}");

        RuleFor(x => x.Address)
           .NotEmpty().WithMessage($"{_stringLocalizer[ValidatorMessages.AddressNotNull]}")
           .NotNull().WithMessage($"{_stringLocalizer[ValidatorMessages.AddressNotNull]}")
           .MaximumLength(256).MinimumLength(2).WithMessage($"{_stringLocalizer[ValidatorMessages.AddressLength]}")
           .Must(address => address == null || !Regex.IsMatch(address, @"[*?)(*+@<>₺&%+^^'!#]")).WithMessage($"{_stringLocalizer[ValidatorMessages.ClientAddressNoSpecialChars]}");

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Now.AddYears(-18)).WithMessage($"{_stringLocalizer[ValidatorMessages.DateOfBirthControl]}")
            .GreaterThan(DateTime.Now.AddYears(-65)).WithMessage($"{_stringLocalizer[ValidatorMessages.DateOfBirthControl]}");

        RuleFor(x => x.Gender)
            .NotEmpty()
            .WithMessage($"{_stringLocalizer[ValidatorMessages.GenderNotEmpty]}");
    }

    /// <summary>
    /// Mail validasyonu ile ilgili yardımcı metot
    /// </summary>
    /// <param name="email"></param>
    /// <returns></returns>
    private bool IsValidEmail(string? email)
    {
        //string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        string pattern = @"^[a-zA-Z0-9_.+-]+@(gmail\.com|hotmail\.com)$";

        Regex rg = new Regex(pattern);

        email = email?.Trim();

        if (!email.IsNullOrEmpty() && rg.IsMatch(email))
        {
            return true;
        }
        return false;
    }

}
