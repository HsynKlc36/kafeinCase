using NETDeveloperCaseStudy.Dtos.Shopping;

namespace NETDeveloperCaseStudy.Dtos.RabbitMQMessage;
public record RabbitMessageDto
{
    public string ToEmail { get; init; }
    public List<ShoppingCartDetailDto> ShoppingCartDetailList { get; init; }
}
