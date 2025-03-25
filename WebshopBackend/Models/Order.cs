namespace WebshopBackend.Models
{
    public class Order
    {
        public int Id { get; set; }
        public required Guid OrderNumber { get; set; }
        public required WebshopUser User { get; set; }
        public required ShippingDetails ShippingDetails { get; set; }
        public required DateTime OrderDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public required string OrderStatus { get; set; }
        public required decimal ShippingPrice { get; set; }
        public required decimal TotalPrice { get; set; }
        
        public List<OrderItem> OrderItems { get; set; }
    }
}
