using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FitnessCenter.Models
{
    public class SporSalonu
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Salon Adı")]
        public string Ad { get; set; }

        [Display(Name = "Adres")]
        public string Adres { get; set; }

        [Display(Name = "Çalışma Saatleri")]
        public string CalismaSaatleri { get; set; }

        // İlişki: 1 salonda birçok hizmet olabilir
        public ICollection<Hizmet> Hizmetler { get; set; }
    }
}
