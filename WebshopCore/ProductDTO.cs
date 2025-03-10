namespace WebshopCore
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        public ProductDTO(int id)
        {
            Id = id;
            ProductName = "Product Name";
            Author = "Author";
            Title = "Title";
            Description = "Description";
            ISBN = "ISBN";
            ImageUrl = "";
            Price = 0;
        }
    }

}
