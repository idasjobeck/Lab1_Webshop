namespace WebshopBackend.Models
{
    public class ShippingDetails
    {
        public int Id { get; set; }
        public required string ShipFirstName { get; set; }
        public required string ShipLastName { get; set; }
        public required string ShipAdd1 { get; set; }
        public string? ShipAdd2 { get; set; }
        public required string ShipCity { get; set; }
        public required string ShipZip { get; set; }
        public required string ShipCountry { get; set; }
        public required WebshopUser User { get; set; }
    }
}
