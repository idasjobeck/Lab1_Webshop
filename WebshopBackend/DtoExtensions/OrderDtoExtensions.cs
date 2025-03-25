using Microsoft.EntityFrameworkCore;
using WebshopBackend.Data;
using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class OrderDtoExtensions
    {
        public static Order ToOrder(this OrderDto orderDto, WebshopDbContext context) => new Order
        {
            Id = 0,
            OrderNumber = orderDto.OrderNumber,
            User = context.Users.FirstOrDefault(u => u.Id == orderDto.User.Id)!,
            ShippingDetails = orderDto.ShippingDetails.ToShippingDetails(context),
            OrderDate = orderDto.OrderDate,
            ShippingDate = orderDto.ShippingDate,
            OrderStatus = orderDto.OrderStatus,
            ShippingPrice = orderDto.ShippingPrice,
            TotalPrice = orderDto.TotalPrice,
            OrderItems = orderDto.OrderItems.ToOrderItems()
        };
        
        public static OrderDto ToOrderDto(this Order order) => new OrderDto
        {
            OrderNumber = order.OrderNumber,
            ShippingDetails = order.ShippingDetails.ToShippingDetailsDto(),
            OrderDate = order.OrderDate,
            ShippingDate = order.ShippingDate,
            OrderStatus = order.OrderStatus,
            ShippingPrice = order.ShippingPrice,
            TotalPrice = order.TotalPrice,
            User = order.User.ToWebshopUserDto(),
            OrderItems = order.OrderItems.ToOrderItemsDto()
        };
    }
}
