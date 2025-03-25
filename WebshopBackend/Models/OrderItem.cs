namespace WebshopBackend.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public required Book Book { get; set; }
        public required int Quantity { get; set; }
        public required decimal PriceAtPurchase { get; set; }
    }
}
