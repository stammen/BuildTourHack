using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Models.ViewModels
{
    public class OrdersViewModel
    {
        public string OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string Tracking { get; set; }
        public OrderStatus Status { get; set; }
    }
}
