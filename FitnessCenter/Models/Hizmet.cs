using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Models
{
    public class Hizmet
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Hizmet Adı")]
        public string Ad { get; set; }

        [Display(Name = "Süre (dk)")]
        public int SureDakika { get; set; }

        [Display(Name = "Ücret (₺)")]
        public decimal Ucret { get; set; }

        // İlişki: Hizmeti veren antrenör
        [Display(Name = "Antrenör")]
        public int AntrenorId { get; set; }
        public Antrenor Antrenor { get; set; }

        // İlişki: Hizmet hangi salona ait
        [Display(Name = "Spor Salonu")]
        public int SporSalonuId { get; set; }
        public SporSalonu SporSalonu { get; set; }
    }
}
