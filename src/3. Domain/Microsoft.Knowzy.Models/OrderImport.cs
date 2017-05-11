using System.Collections.Generic;
using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Models
{
    public class OrderImport
    {
        public IEnumerable<Receiving> Receivings { get; set; }
        public IEnumerable<Shipping> Shippings { get; set; }
    }
}
