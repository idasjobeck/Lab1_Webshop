using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebshopBackend.Data;
using WebshopBackend.DtoExtensions;
using WebshopBackend.Models;
using WebshopCore.Dtos;

namespace WebshopBackend.ApiEndpoints
{
    public class BookEndpoints
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
    }
}
