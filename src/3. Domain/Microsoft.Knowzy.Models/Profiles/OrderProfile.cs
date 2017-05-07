using AutoMapper;
using Microsoft.Knowzy.Domain;
using Microsoft.Knowzy.Models.ViewModels;

namespace Microsoft.Knowzy.Models.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrdersViewModel>();

            CreateMap<Order, OrderViewModel>()
                .ForMember(orderViewModel => orderViewModel.PostalCarrierName,
                    options => options.ResolveUsing(order => order.PostalCarrier.Name));
        }
    }
}
