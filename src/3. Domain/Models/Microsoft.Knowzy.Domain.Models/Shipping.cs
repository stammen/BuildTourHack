using System.Collections.Generic;

namespace Microsoft.Knowzy.Domain.Models
{
    public class Shipping
    {
        public string OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Tracking { get; set; }
        public OrderStatus Status { get; set; }
        public string ContactPerson { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCarrier { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
