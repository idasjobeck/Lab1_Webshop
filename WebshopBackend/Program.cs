using System.Diagnostics;
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
            app.MapPatch("/decreaseAvailableQty/{id}",
                (int id, WebshopDbContext context) => bookEndpoints.DecreaseAvailableQtyAsync(id, context));
            app.MapPatch("/increaseAvailableQty/{id}",
                (int id, WebshopDbContext context) => bookEndpoints.IncreaseAvailableQtyAsync(id, context));


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
