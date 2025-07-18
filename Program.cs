using WebApplication7.Data.Repositories;
using WebApplication7.Services;
using WebApplication7.Services.Implementations;

namespace WebApplication7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ProductRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute("areas", "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
