using System.Collections.Generic;
using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Models.ViewModels
{
    public class OrderViewModel
    {
        public string OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Tracking { get; set; }
        public string PostalCarrier { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<OrderLineViewModel> OrderLines { get; set; }
    }
}
