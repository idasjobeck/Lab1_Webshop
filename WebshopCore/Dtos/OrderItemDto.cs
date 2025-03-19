using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopCore.Dtos
{
    public class OrderItemDto
    {
        public required string ProductName { get; set; }
        public required int Quantity { get; set; }
        public required decimal PriceAtPurchase { get; set; }
    }
}
