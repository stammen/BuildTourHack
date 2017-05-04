using AutoMapper;
using Microsoft.Knowzy.Domain;
using Microsoft.Knowzy.Models.ViewModels;

namespace Microsoft.Knowzy.Models.Profiles
{
    public class OrderLineProfile : Profile
    {
        public OrderLineProfile()
        {
            CreateMap<OrderLine, OrderLineViewModel>()
                .ForMember(orderLineViewModel => orderLineViewModel.ItemNumber, 
                           options => options.ResolveUsing(orderLine => orderLine.Item.Number))
                .ForMember(orderLineViewModel => orderLineViewModel.ItemImage,
                           options => options.ResolveUsing(orderLine => orderLine.Item.Image));
        }
    }
}
