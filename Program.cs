using BlazorApp.Data;
using BlazorApp.Components;
using Microsoft.EntityFrameworkCore;
using BlazorApp.Services;

namespace BlazorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

            builder.Services.AddDbContext<BookingAppContext>(options =>
                options.UseSqlServer("Server=HP-ANDRÉ;Database=booking-app;Trusted_Connection=True;TrustServerCertificate=True;"));

            builder.Services.AddScoped<AccommodationService>();
            builder.Services.AddScoped<CustomerService>();
            builder.Services.AddScoped<BookingService>();

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseAntiforgery();

            app.MapStaticAssets();
            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode();

            app.Run();
        }
    }
}
