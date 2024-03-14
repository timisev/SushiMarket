using Microsoft.EntityFrameworkCore;
using SushiMarketApp.Models;

var builder = WebApplication.CreateBuilder(args);
{
    string connection = builder.Configuration.GetConnectionString("DefaultConnection");

    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

    builder.Services.AddTransient<IProductRepository, EFProductRepository>();
    builder.Services.AddTransient<IOrderRepository, EFOrderRepository>();
    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));

    builder.Services.AddMvc();
    builder.Services.AddDistributedMemoryCache();
    builder.Services.AddSession();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseStatusCodePages();
    app.UseSession(); 

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

app.Run();