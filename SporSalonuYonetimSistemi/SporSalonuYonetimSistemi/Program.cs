using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SporSalonuYonetimSistemi.Data;

var builder = WebApplication.CreateBuilder(args);

// Veritabaný baðlantýsýný ekleyin
builder.Services.AddDbContext<ApplicationDbContext>(options =>
<<<<<<< HEAD
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));  // Baðlantý dizesini kullanarak SQL Server'a baðlanýyoruz
=======
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));  // Baðlantý dizesi
>>>>>>> 2c6a6a27c00e28d78667db377d548b26bce52990

// Identity servisini ekleyin
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();  // Kullanýcý doðrulama için ekleme

builder.Services.AddControllersWithViews();

var app = builder.Build();

// middleware
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();  // Kimlik doðrulama
app.UseAuthorization();   // Yetkilendirme

app.MapDefaultControllerRoute();

app.Run();
