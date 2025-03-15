using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebshopCore
{
    public class OrderDTO
    {
        public List<ProductDTO> ProductsOrdered { get; set; }
        public string Currency { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal ShippingCost { get; set; }
        public UserWithAddressDTO User { get; set; }
    }
}
