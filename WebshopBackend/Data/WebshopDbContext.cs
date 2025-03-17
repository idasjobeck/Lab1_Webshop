using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebshopBackend.Models;

namespace WebshopBackend.Data
{
    public class WebshopDbContext : IdentityDbContext<WebshopUser>
    {
        public WebshopDbContext(DbContextOptions<WebshopDbContext> options) : base(options)
        {
        }
    }
}
