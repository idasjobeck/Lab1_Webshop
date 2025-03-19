using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopCore.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Series { get; set; }
        public int? NumberInSeries { get; set; }
        public required string Authors { get; set; }
        public required string Genre { get; set; }
        public required string ISBN { get; set; }
        public DateTime PublishedYear { get; set; }
        public required string Publisher { get; set; }
        public required string Edition { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public decimal? SalePrice { get; set; }
        public int AvailableQty { get; set; }
    }
}
