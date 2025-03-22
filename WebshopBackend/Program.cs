using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

            //mapping endpoints - make its own method?
            app.MapGet("/products", () => DtoExtensionsOld.GetProducts());
            app.MapGet("/products/{id}", (int id) => DtoExtensionsOld.GetProductById(id));

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
                    
                    var dummyData = new DummyDataForDb(db);
                    await dummyData.PopulateDatabaseAsync();
                }
            }

            app.Run();
        }
    }

}
