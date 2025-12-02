using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Models
{
    public class Randevu
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tarih ve Saat")]
        public DateTime TarihSaat { get; set; }

        [Display(Name = "Üye Adı (şimdilik basit)")]
        public string UyeAd { get; set; }

        [Display(Name = "Hizmet")]
        public int HizmetId { get; set; }
        public Hizmet Hizmet { get; set; }

        [Display(Name = "Onay Durumu")]
        public bool Onaylandi { get; set; }
    }
}
