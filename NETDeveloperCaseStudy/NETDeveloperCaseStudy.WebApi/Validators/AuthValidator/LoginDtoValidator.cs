using NETDeveloperCaseStudy.Business;
using NETDeveloperCaseStudy.Business.Constants;
using NETDeveloperCaseStudy.Dtos.Account;
using FluentValidation;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace NETDeveloperCaseStudy.WebApi.Validators.AuthValidator;

public class LoginDtoValidator : AbstractValidator<LoginDto>
{
    private readonly IStringLocalizer<Resource> _stringLocalizer;
    public LoginDtoValidator(IStringLocalizer<Resource> stringLocalizer)
    {
        _stringLocalizer = stringLocalizer;

        //Bu kod ile önce Email alanı boş bırakıldığı durumda "Mail adresi girmelisiniz." mesajı dönmektedir, mail alanı doldurulduğu durumda ise girilen mail adresinin uygun formatta olup olmadığı kontrol edilip uygun değilse "Lütfen geçerli bir e-mail adresi giriniz." mesajı dönmektedir:
        RuleFor(x => x.Email)
            //.Cascade(CascadeMode.Stop) //NotEmpty hatasını alınca bir alt şarta geçmeyi engeller.
            //.Cascade(CascadeMode.StopOnFirstFailure) 
            .NotEmpty()
            .WithMessage($"{_stringLocalizer[ValidatorMessages.LoginEmailNotEmpty]}")
            .Must(IsValidEmail) //Email kontolu yapan yardımcı metot
            .WithMessage($"{_stringLocalizer[ValidatorMessages.LoginEmailControl]}");

        //Bu kod ile önce Password alanı boş bırakıldığı durumda "Şifre girmelisiniz." mesajı dönmektedir, Password alanı doldurulduğu durumda ise girilen şifrenin 8 haneli olup olmadığı kontrol edilip farklı girilmiş ise "Şifreniz 8 haneli olmalıdır." mesajı dönmektedir:
        RuleFor(x => x.Password)
            //.Cascade(CascadeMode.Stop) //NotEmpty hatasını alınca bir alt şarta geçmeyi engeller.
            .NotEmpty()
            .WithMessage($"{_stringLocalizer[ValidatorMessages.LoginPasswordNotEmpty]}")
            .Matches(new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$"))
       .WithMessage($"{_stringLocalizer[ValidatorMessages.LoginPasswordControl]}");
    }


    /// <summary>
    /// Bu metod hem loginDto'da yer alan mailin boş, email formatına uygunluğunu denetleyecek. Hem de mailin gmail.com, hotmail.com, kainatholding.com adreslerine uygunluğunu kontrol edecek. Önceden yazılmış olan metotta değişikliğe gidilmiştir. Eski metot kontrolleri korunmuş ve sadece üzerine gmail.com vs. gibi kontroller eklenmiştir.
    /// </summary>
    /// <param name="email">Metod içerisine gelen mail içeriğinin tutulduğu parameteredir.</param>
    /// <returns></returns>
    private bool IsValidEmail(string? email)
    {
        //Email şartına uygun olup olmadığını kontrol eden regex yapısı:
        //string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

        string pattern = @"^[a-zA-Z0-9_.+-]+@(gmail\.com|hotmail\.com|kainatholding\.com)$";

        //Regex yaratır:
        Regex rg = new Regex(pattern);

        email = email?.Trim();

        //Bu kontrol ile gelen email içeriğinin boş olma veya regex'e uymama durumu kontrol edilmiştir.
        if (!email.IsNullOrEmpty() && rg.IsMatch(email))
        {
            return true;
        }
        return false;
    }
}