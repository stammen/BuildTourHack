namespace Microsoft.Knowzy.Domain
{
    public class OrderLine
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
