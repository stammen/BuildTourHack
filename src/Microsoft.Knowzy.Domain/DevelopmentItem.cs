using System;
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
        public DateTime DevelopmentStartDate { get; set; }
        public DateTime ExpectedCompletionDate { get; set; }
        public string SupplyManagementContact { get; set; }
        public string Notes { get; set; }
        public string ImageSource { get; set; }
    }
}
