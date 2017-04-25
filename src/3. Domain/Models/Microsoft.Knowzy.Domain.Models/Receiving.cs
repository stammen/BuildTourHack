namespace Microsoft.Knowzy.Domain.Models
{
    public class Receiving
    {
        public string ReceiptNumber { get; set; }
        public string From { get; set; }
        public string ShippingFrom { get; set; }
        public string Tracking { get; set; }
        public OrderStatus Status { get; set; }
    }
}
