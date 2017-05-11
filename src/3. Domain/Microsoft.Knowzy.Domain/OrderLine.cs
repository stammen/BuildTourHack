namespace Microsoft.Knowzy.Domain
{
    public class OrderLine
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
