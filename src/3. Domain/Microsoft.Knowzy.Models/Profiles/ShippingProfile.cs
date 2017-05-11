using AutoMapper;
using Microsoft.Knowzy.Domain;
using Microsoft.Knowzy.Models.ViewModels;

namespace Microsoft.Knowzy.Models.Profiles
{
    public class ShippingProfile : Profile
    {
        public ShippingProfile()
        {
            CreateMap<Shipping, ShippingsViewModel>()
                .IncludeBase<Order, OrdersViewModel>();

            CreateMap<Shipping, ShippingViewModel>()
                .IncludeBase<Order, OrderViewModel>().ReverseMap();
        }
    }
}
