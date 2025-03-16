namespace WebshopCore
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string? Series { get; set; }
        public int? NumberInSeries { get; set; }
        public string Description { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public int PublishedYear { get; set; }
        public string Genre { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }

        public ProductDto(int id)
        {
            Id = id;
            ProductName = "Product Name";
            Author = "Author";
            Title = "Title";
            Series = "Series";
            NumberInSeries = 0;
            Description = "Description";
            ISBN = "ISBN";
            Publisher = "Publisher";
            PublishedYear = 1900;
            Genre = "Genre";
            ImageUrl = "";
            Price = 0;
        }
    }

}
