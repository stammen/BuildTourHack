using System.Collections.Generic;

namespace Microsoft.Knowzy.Domain.Models
{
    public class Order
    {
        public IEnumerable<Shipping> Shippings { get; set; }
        public IEnumerable<Receiving> Receivings { get; set; }
    }
}
