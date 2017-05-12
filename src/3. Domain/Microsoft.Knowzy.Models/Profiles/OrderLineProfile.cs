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
                .ForMember(orderLineViewModel => orderLineViewModel.ProductImage,
                    options => options.ResolveUsing(orderLine => orderLine.Product.Image))
                .ForMember(orderLineViewModel => orderLineViewModel.ProductPrice,
                    options => options.ResolveUsing(orderLine => orderLine.Product.Price)); ;

            CreateMap<OrderLineViewModel, OrderLine>()
                .ForMember(orderLine => orderLine.Price,
                    options => options.ResolveUsing(
                        orderLineViewModel => orderLineViewModel.Quantity * orderLineViewModel.ProductPrice));
        }
    }
}
