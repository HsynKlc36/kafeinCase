using NETDeveloperCaseStudy.Dtos.Order;

namespace NETDeveloperCaseStudy.Business.Profiles;
public class ShoppingProfile:Profile
{
    public ShoppingProfile()
    {
        CreateMap<CreateOrderDto,Order>().ReverseMap();
        CreateMap<CreateOrderDetailDto, OrderDetail>().ReverseMap();
    }
}
