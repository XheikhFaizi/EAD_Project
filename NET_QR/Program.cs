using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NET_QR.Data;
using NET_QR.Models;
using NET_QR.Models.Repositry;
using NET_QR.Models.Interface;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<NET_QRContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NET_QRContext") ?? throw new InvalidOperationException("Connection string 'NET_QRContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<InterfaceUser, UserRepositry>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Null}/{id?}");

app.Run();
