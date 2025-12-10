using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SporSalonuYonetimSistemi.Data;
using SporSalonuYonetimSistemi.Models;

namespace SporSalonuYonetimSistemi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        // Constructor: DbContext'e enjekte etme
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Index Metodu
        public async Task<IActionResult> Index()
        {
            // Veritabanýndan veri çekme (Salons tablosundan)
            var salons = await _context.Salons.ToListAsync();

            // Veri kontrolü
            if (salons != null && salons.Count > 0)
            {
                return View(salons); // Veriyi index sayfasýna gönderiyoruz
            }

            // Eðer veri yoksa bir mesaj döndür
            ViewData["Message"] = "No salons found in the database.";
            return View();
        }
    }
}
