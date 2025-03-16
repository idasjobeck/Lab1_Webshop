using WebshopCore;

namespace WebshopBackend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            //app.MapGet("/", () => "Hello World!");
            app.MapGet("/products", () => DtoExtensions.GetProducts());
            app.MapGet("/products/{id}", (int id) => DtoExtensions.GetProductById(id));

            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }

            app.Run();
        }
    }

}
