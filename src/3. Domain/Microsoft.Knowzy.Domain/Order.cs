using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Knowzy.Domain
{
    public abstract class Order
    {
        public string OrderNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Tracking { get; set; }
        public int PostalCarrierId { get; set; }
        public virtual PostalCarrier PostalCarrier { get; set; }
        public OrderStatus Status { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
        public decimal Total => OrderLines.Sum(orderLine => orderLine.Price);
    }
}
