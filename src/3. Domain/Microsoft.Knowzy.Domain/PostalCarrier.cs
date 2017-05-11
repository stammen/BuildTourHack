using System.Collections.Generic;

namespace Microsoft.Knowzy.Domain
{
    public class PostalCarrier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
