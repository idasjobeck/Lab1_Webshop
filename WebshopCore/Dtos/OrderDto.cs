using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopCore.Dtos
{
    public class OrderDto
    {
        public required Guid OrderNumber { get; set; }
        public required ShippingDetailsDto ShippingDetails { get; set; }
        public required DateTime OrderDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public required string OrderStatus { get; set; }
        public required decimal ShippingPrice { get; set; }
        public required decimal TotalPrice { get; set; }
        public required List<OrderItemDto> OrderItems { get; set; }
    }
}
