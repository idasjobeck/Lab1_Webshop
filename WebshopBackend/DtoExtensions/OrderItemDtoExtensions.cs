using WebshopBackend.Data;
using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class OrderItemDtoExtensions
    {
        
        public static OrderItem ToOrderItem(this OrderItemDto orderItemDto) => new OrderItem
        {
            Book = orderItemDto.Book.ToBook(),
            Quantity = orderItemDto.Quantity,
            PriceAtPurchase = orderItemDto.PriceAtPurchase
        };

        public static List<OrderItem> ToOrderItems(this List<OrderItemDto> orderItemDtos) => orderItemDtos.Select(ToOrderItem).ToList();

        public static OrderItemDto ToOrderItemDto(this OrderItem orderItem) => new OrderItemDto
        {
            Book = orderItem.Book.ToBookDto(),
            Quantity = orderItem.Quantity,
            PriceAtPurchase = orderItem.PriceAtPurchase
        };

        public static List<OrderItemDto> ToOrderItemsDto(this List<OrderItem> orderItems) => orderItems.Select(ToOrderItemDto).ToList();
    }
}
