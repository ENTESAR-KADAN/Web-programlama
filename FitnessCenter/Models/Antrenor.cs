using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Models
{
    public class Antrenor
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }

        [Display(Name = "Uzmanlık Alanı")]
        public string Uzmanlik { get; set; }

        [Display(Name = "Deneyim (Yıl)")]
        public int? DeneyimYili { get; set; }

        // Hangi salonda çalışıyor?
        [Display(Name = "Spor Salonu")]
        public int SporSalonuId { get; set; }
        public SporSalonu SporSalonu { get; set; }
    }
}
