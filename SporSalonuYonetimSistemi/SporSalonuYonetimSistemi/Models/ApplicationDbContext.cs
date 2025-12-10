using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SporSalonuYonetimSistemi.Models;

namespace SporSalonuYonetimSistemi.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // DbContext'e gelen seçenekleri base'e geçiyoruz
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        // Veritabanındaki tablolara karşılık gelen DbSet'ler
        public DbSet<Salon> Salons { get; set; }
        public DbSet<Antrenor> Antrenors { get; set; }
        public DbSet<Uye> Uyes { get; set; }
        public DbSet<Randevu> Randevus { get; set; }
    }
}
