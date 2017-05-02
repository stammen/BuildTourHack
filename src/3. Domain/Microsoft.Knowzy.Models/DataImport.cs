using System.Collections.Generic;
using Microsoft.Knowzy.Domain;

namespace Microsoft.Knowzy.Models
{
    public class DataImport
    {
        public IEnumerable<Receiving> Receivings { get; set; }
        public IEnumerable<Shipping> Shippings { get; set; }
    }
}
