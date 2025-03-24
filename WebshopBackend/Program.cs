using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebshopBackend.ApiEndpoints;
using WebshopBackend.Data;
using WebshopBackend.Models;
using WebshopCore;

namespace WebshopBackend
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(IdentityConstants.ApplicationScheme)
                .AddCookie(IdentityConstants.ApplicationScheme);
            builder.Services.AddIdentityCore<WebshopUser>()
                .AddEntityFrameworkStores<WebshopDbContext>()
                .AddApiEndpoints();

            var connectionString = builder.Configuration.GetConnectionString("WebshopDb");

            builder.Services.AddDbContext<WebshopDbContext>(options => options.UseSqlServer(connectionString)
                .LogTo(message => Debug.WriteLine(message)));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            var bookEndpoints = new BookEndpoints();
            app.MapGet("/products", (WebshopDbContext context) => bookEndpoints.GetProductsAsync(context));
            app.MapGet("/products/{id}", (int id, WebshopDbContext context) => bookEndpoints.GetProductByIdAsync(id, context));
            app.MapPatch("/decreaseAvailableQty/{id}/{amount}",
                (int id, int amount, WebshopDbContext context) => bookEndpoints.DecreaseAvailableQtyAsync(id, amount, context));
            app.MapPatch("/increaseAvailableQty/{id}/{amount}",
                (int id, int amount, WebshopDbContext context) => bookEndpoints.IncreaseAvailableQtyAsync(id, amount, context));


            app.MapGroup("/account").MapIdentityApi<WebshopUser>();
            app.MapGroup("/account").MapGet("/AuthenticatedUser", async (ClaimsPrincipal userPrincipal, WebshopDbContext context) =>
            {
                string userId = userPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
                var user = await context.Users.FindAsync(userId); //get user from db
                return user;
            }).RequireAuthorization();


            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                //only needed if not using migrations for database
                using (var scope = app.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<WebshopDbContext>();
                    db.Database.EnsureDeleted();
                    db.Database.EnsureCreated();

                    //populate database with dummy data
                    var dummyData = new DummyDataForDb(db);
                    await dummyData.PopulateDatabaseAsync();
                }
            }

            app.Run();
        }
    }

}
