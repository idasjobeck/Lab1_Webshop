using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class OrderItemDtoExtensions
    {
        /*
        public static OrderItem ToOrderItem(this OrderItemDto orderItemDto, int orderId, int bookId) => new OrderItem
        {
            Id = 0,
            //Book = new Book { Id = bookId }, //need to get the book by id
            //Order = new Order { Id = orderId }, //need to get the order by id
            Quantity = orderItemDto.Quantity,
            PriceAtPurchase = orderItemDto.PriceAtPurchase
        };
        */

        public static OrderItemDto ToOrderItemDto(this OrderItem orderItem) => new OrderItemDto
        {
            ProductName = orderItem.Book.GetProductName(),
            Quantity = orderItem.Quantity,
            PriceAtPurchase = orderItem.PriceAtPurchase
        };

        public static List<OrderItemDto> ToOrderItemsDto(this List<OrderItem> orderItems) => orderItems.Select(ToOrderItemDto).ToList();
    }
}
