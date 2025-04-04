using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebshopBackend.Data;
using WebshopBackend.DtoExtensions;
using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.ApiEndpoints
{
    public class WebshopEndpoints
    {
        //GET /products
        public async Task<List<BookDto>> GetProductsAsync(WebshopDbContext context)
        {
            return await context.Books
                .Include(b => b.Title)
                .Include(b => b.Series)
                .Include(b => b.Genre)
                .Include(b => b.Publisher)
                .Include(b => b.Edition)
                .Include(b => b.Authors)
                .Select(b => b.ToBookDto())
                .ToListAsync();
        }

        //GET /products/{id}
        public async Task<BookDto> GetProductByIdAsync(int id, WebshopDbContext context)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
                return null!;

            book = await context.Books
                .Include(b => b.Title)
                .Include(b => b.Series)
                .Include(b => b.Genre)
                .Include(b => b.Publisher)
                .Include(b => b.Edition)
                .Include(b => b.Authors)
                .FirstOrDefaultAsync(b => b.Id == id);

            return book!.ToBookDto();
        }

        //PATCH /decreaseAvailableQty/{id}/{amount}
        public async Task DecreaseAvailableQtyAsync(int id, int amount, WebshopDbContext context)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
                return;

            if (book.AvailableQty > 0)
            {
                book.AvailableQty -= amount;
                await context.SaveChangesAsync();
            }
        }

        //PATCH /increaseAvailableQty/{id}/{amount}
        public async Task IncreaseAvailableQtyAsync(int id, int amount, WebshopDbContext context)
        {
            var book = await context.Books.FindAsync(id);

            if (book == null)
                return;
            
            book.AvailableQty += amount;
            await context.SaveChangesAsync();
        }

        //POST /checkout
        public async Task CheckoutAsync(WebshopDbContext context, [FromBody] OrderDto orderDto)
        {
            var order = orderDto.ToOrder(context);

            foreach (var orderItem in order.OrderItems)
            {
                context.Entry(orderItem.Book).State = EntityState.Unchanged;
            }

            context.Orders.Add(order);
            await context.SaveChangesAsync();
        }

        //GET /cart/{userId}
        public async Task<CartDto?> GetCartAsync(string userId, WebshopDbContext context)
        {
            var cart = await context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
                return null;

            return cart.ToCartDto();
        }

        //POST /cart
        public async Task AddCartAsync(WebshopDbContext context, [FromBody] CartDto cartDto)
        {
            var cart = cartDto.ToCart();
            context.Carts.Add(cart);
            await context.SaveChangesAsync();
        }

        //PATCH /cart/{userId}
        public async Task UpdateCartAsync(string userId, WebshopDbContext context, [FromBody] CartDto cartDto)
        {
            var cart = await context.Carts.FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
                return;

            cart.JsonCart = cartDto.JsonCart;
            await context.SaveChangesAsync();
        }

    }
}
