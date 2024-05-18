using NETDeveloperCaseStudy.Dtos.Shopping;

namespace NETDeveloperCaseStudy.Business.Abstracts;

public interface IEmailService
{
    /// <summary>
    /// Bu metot mail gönderme işlemini yapacaktır.
    /// </summary>
    /// <param name="toEmail"></param>
    /// <param name="newPassword"></param>
    Task SendEmailAsync(string toEmail, string newPassword);

    /// <summary>
    ///Bu metot kullanıcının verdiği sipariş bilgilerini mail olarak gönderme işlemi yapacaktır! 
    /// </summary>
    /// <param name="toEmail"></param>
    /// <param name="shoppingCartDetailList"></param>
    /// <returns></returns>
    Task SendOrderEmailAsync(string toEmail, List<ShoppingCartDetailDto?> shoppingCartDetailList);
}
