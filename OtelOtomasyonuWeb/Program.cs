using Microsoft.EntityFrameworkCore;
using OtelOtomasyonuWeb.Data;

var builder = WebApplication.CreateBuilder(args);
// HTTP portunu ayarla (localhost için yeterli)
builder.WebHost.UseUrls("http://localhost:5000");

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<OtelOtomasyonuWeb.Data.WebHotelContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// HTTPS redirection'ı kaldır - hem HTTP hem HTTPS destekle
// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
