using AutoMapper;
using Microsoft.Knowzy.Domain;
using Microsoft.Knowzy.Models.ViewModels;

namespace Microsoft.Knowzy.Models.Profiles
{
    public class ReceivingProfile : Profile
    {
        public ReceivingProfile()
        {
            CreateMap<Receiving, ReceivingsViewModel>();

            CreateMap<Receiving, ReceivingViewModel>();
        }
    }
}
