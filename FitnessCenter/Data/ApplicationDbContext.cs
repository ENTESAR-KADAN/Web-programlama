using Microsoft.EntityFrameworkCore;
using FitnessCenter.Models;

namespace FitnessCenter.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Hizmet -> SporSalonu ilişkisinde Cascade Delete kapat
            modelBuilder.Entity<Hizmet>()
                .HasOne(h => h.SporSalonu)
                .WithMany(s => s.Hizmetler)
                .HasForeignKey(h => h.SporSalonuId)
                .OnDelete(DeleteBehavior.Restrict);

            // Hizmet -> Antrenor ilişkisinde Cascade Delete kapat
            modelBuilder.Entity<Hizmet>()
                .HasOne(h => h.Antrenor)
                .WithMany()
                .HasForeignKey(h => h.AntrenorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Antrenor -> SporSalonu ilişkisinde Cascade Delete kapat
            modelBuilder.Entity<Antrenor>()
                .HasOne(a => a.SporSalonu)
                .WithMany()
                .HasForeignKey(a => a.SporSalonuId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<SporSalonu> SporSalonlari { get; set; }
        public DbSet<Antrenor> Antrenorler { get; set; }
        public DbSet<Hizmet> Hizmetler { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
    }
}
