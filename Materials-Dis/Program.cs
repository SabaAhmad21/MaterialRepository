using Materials_Dis.DbModels;
using Materials_Dis.Infrastructure.Implementation;
using Materials_Dis.Infrastructure.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<RawMaterialDbContext>(x=>x.UseSqlServer("Server=DESKTOP-MPQVSOQ;Database=RawMaterialDB;Trusted_Connection=True;TrustServerCertificate=yes;"));
builder.Services.AddTransient<IMaterialRepository, MaterialRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
