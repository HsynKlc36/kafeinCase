using NETDeveloperCaseStudy.Core.Entities.BaseIdentities;
using MimeKit;
using NETDeveloperCaseStudy.Dtos.Shopping;
namespace NETDeveloperCaseStudy.Business.Concretes;

public class EmailManager : IEmailService
{
   
    private readonly EmailOptions _emailSettings;
    private readonly OrderEmailOptions _orderEmailSettings;
    private readonly IWebHostEnvironment _IWebHostEnvironment;
    private readonly UserManager<ExtendedIdentityUser> _userManager;
    private readonly ILoggerService _logger;
    private readonly IStringLocalizer<Resource> _stringLocalizer;

    public EmailManager(IOptions<EmailOptions> emailSettings,IOptions<OrderEmailOptions> orderEmailSettings, IWebHostEnvironment iWebHostEnvironment, UserManager<ExtendedIdentityUser> userManager,ILoggerService loggerService, IStringLocalizer<Resource> stringLocalizer)
    {
        _emailSettings = emailSettings.Value;
        _orderEmailSettings = orderEmailSettings.Value;
        _IWebHostEnvironment = iWebHostEnvironment;
        _userManager = userManager;
        _logger = loggerService;
        _stringLocalizer = stringLocalizer;
    }

  //burası düzenlenecek kullanıcı sipariş oluşturduğunda sipariş başarılı ise buradaki metot ile mail gönderilecek!
    public async Task SendOrderEmailAsync(string toEmail, List<ShoppingCartDetailDto?> shoppingCartDetailList)
    {
        try
        {
          
            var PathToFile = Path.Combine(_IWebHostEnvironment.WebRootPath, "EmailTemplate", "orderEmail.html");

            var builder = new BodyBuilder();
            using (StreamReader sr = System.IO.File.OpenText(PathToFile))
            {
                builder.HtmlBody = sr.ReadToEnd();
            }
            

            var shoppingDetailsHtml = new StringBuilder();
            foreach (var detail in shoppingCartDetailList)
            {
                if (detail != null)
                {
                    shoppingDetailsHtml.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>",
                                                      detail.MarketName, detail.ProductName, detail.Amount, detail.Price);
                }
            }
            builder.HtmlBody = builder.HtmlBody.Replace("{1}", shoppingDetailsHtml.ToString());

            var client = new SmtpClient() { Host = _orderEmailSettings.SmtpHost, Port = _orderEmailSettings.SmtpPort };
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(_orderEmailSettings.FromEmail, _orderEmailSettings.SmtpPassword);
            MailMessage message = new MailMessage(_orderEmailSettings.FromEmail, toEmail, _orderEmailSettings.Subject, builder.HtmlBody);
            message.IsBodyHtml = true;
            await client.SendMailAsync(message);
            
        }
        catch (Exception)
        {

            _logger.LogError(_stringLocalizer[LogMessages.SendOrderEmailFailed]);
            throw;
        }
    }

    public async Task SendEmailAsync(string toEmail, string newPassword)
    {
        try
        {
            string subject = _emailSettings.Subject;
            string body = string.Format(_emailSettings.Body, newPassword);

            var client = new SmtpClient() { Host = _emailSettings.SmtpHost, Port = _emailSettings.SmtpPort };
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(_emailSettings.FromEmail, _emailSettings.SmtpPassword);

            MailMessage message = new MailMessage(_emailSettings.FromEmail, toEmail, subject, body);
            message.IsBodyHtml = true;

            await client.SendMailAsync(message);
        }
        catch (Exception)
        {
            _logger.LogError(_stringLocalizer[LogMessages.SendEmailFailed]);
            throw;
        }
       
    }

    


}

