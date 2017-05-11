using System.Collections;
using System.Collections.Generic;

namespace Microsoft.Knowzy.Domain
{
    public class Item
    {
        public string Image { get; set; }
        public string Number { get; set; } 
        public decimal Price { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}