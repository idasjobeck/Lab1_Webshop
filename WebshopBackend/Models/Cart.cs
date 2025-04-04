namespace WebshopBackend.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public WebshopUser User { get; set; }
        public string JsonCart { get; set; }
    }
}
