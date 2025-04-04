using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.DtoExtensions
{
    public static class CartDtoExtensions
    {
        public static Cart ToCart(this CartDto cartDto) => new Cart
        {
            Id = 0,
            UserId = cartDto.UserId,
            JsonCart = cartDto.JsonCart
        };

        public static CartDto ToCartDto(this Cart cart) => new CartDto
        {
            UserId = cart.UserId,
            JsonCart = cart.JsonCart
        };
    }
}
