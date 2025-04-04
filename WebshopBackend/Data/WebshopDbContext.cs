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
        
        public DbSet<Book> Books { get; set; }
        public DbSet<Title> Titles { get; set; }
        public DbSet<Series> Series { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Edition> Editions { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<AuthorBook> AuthorBook { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasIndex(b => b.ISBN).IsUnique();
            modelBuilder.Entity<Order>().HasIndex(o => o.OrderNumber).IsUnique();
            modelBuilder.Entity<Author>()
                .HasMany(e => e.Books)
                .WithMany(e => e.Authors)
                .UsingEntity<AuthorBook>();
            modelBuilder.Entity<Book>().ToTable(b =>
                b.HasCheckConstraint("CK_Book_SalePercentage", "SalePercentage BETWEEN 0 AND 100"));
            modelBuilder.Entity<Book>().ToTable(b => b.HasCheckConstraint("CK_Book_AvailableQty", "AvailableQty >= 0"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
