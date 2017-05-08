using Microsoft.Knowzy.Domain.Enums;

namespace Microsoft.Knowzy.Domain
{
    public class DevelopmentItem
    {
        public string ItemNumber { get; set; }
        public string Engineer { get; set; }
        public string NewProductName { get; set; }
        public string RawMaterial { get; set; }
        public DevelopmentStatus Status { get; set; }
    }
}
