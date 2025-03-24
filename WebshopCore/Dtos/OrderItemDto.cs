using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopCore.Dtos
{
    public class OrderItemDto
    {
        public int BookId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; set; }
    }
}
