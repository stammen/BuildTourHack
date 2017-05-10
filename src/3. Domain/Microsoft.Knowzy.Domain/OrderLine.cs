namespace Microsoft.Knowzy.Domain
{
    public class OrderLine
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public virtual Order Order { get; set; }
        public string ItemNumber { get; set; }
        public virtual Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
