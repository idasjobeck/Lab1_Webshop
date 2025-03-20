using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class OrderDtoExtensions
    {
        /*
        public static Order ToOrder(this OrderDto orderDto) => new Order
        {
            Id = 0,
            OrderNumber = orderDto.OrderNumber,
            // need to get webshop user based on who is logged in
            ShippingDetails = orderDto.ShippingDetails.ToShippingDetails(), // this extension method also needs to get user based on who is logged in
            OrderDate = orderDto.OrderDate,
            ShippingDate = orderDto.ShippingDate,
            OrderStatus = orderDto.OrderStatus,
            ShippingPrice = orderDto.ShippingPrice,
            TotalPrice = orderDto.TotalPrice
        };
        */

        /*
        public static OrderDto ToOrderDto(this Order order) => new OrderDto
        {
            OrderNumber = order.OrderNumber,
            ShippingDetails = order.ShippingDetails.ToShippingDetailsDto(),
            OrderDate = order.OrderDate,
            ShippingDate = order.ShippingDate,
            OrderStatus = order.OrderStatus,
            ShippingPrice = order.ShippingPrice,
            TotalPrice = order.TotalPrice,
            // need to get order items from database based on order id and change them to order item dtos
        };
        */
    }
}
