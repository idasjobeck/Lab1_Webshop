using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebshopBackend.ApiEndpoints;
using WebshopBackend.Data;
using WebshopBackend.Models;
using WebshopCore;
using WebshopCore.Dtos;

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

            builder.Configuration.AddUserSecrets<Program>();

            var app = builder.Build();

            var webshopEndpoints = new WebshopEndpoints();
            app.MapGet("/products", (WebshopDbContext context) => webshopEndpoints.GetProductsAsync(context));
            app.MapGet("/products/{id}", (int id, WebshopDbContext context) => webshopEndpoints.GetProductByIdAsync(id, context));
            app.MapPatch("/decreaseAvailableQty/{id}/{amount}",
                (int id, int amount, WebshopDbContext context) => webshopEndpoints.DecreaseAvailableQtyAsync(id, amount, context));
            app.MapPatch("/increaseAvailableQty/{id}/{amount}",
                (int id, int amount, WebshopDbContext context) => webshopEndpoints.IncreaseAvailableQtyAsync(id, amount, context));
            app.MapPost("/checkout",
                (WebshopDbContext context, [FromBody] OrderDto orderDto) =>
                    webshopEndpoints.CheckoutAsync(context, orderDto));

            var exchangeRateEndpoints = new ExchangeRateEndpoints();
            app.MapGet("/ExchangeRate/{BaseCurrency}/{NewCurrency}", (string baseCurrency, string newCurrency, IConfiguration configuration) => 
                exchangeRateEndpoints.GetExchangeRateAsync(baseCurrency, newCurrency, configuration));

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

                using (var scope = app.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<WebshopDbContext>();

                    //populate database with dummy data
                    var dummyData = new DummyDataForDb(db);
                    await dummyData.PopulateDatabaseAsync();
                }
            }

            app.Run();
        }
    }

}
