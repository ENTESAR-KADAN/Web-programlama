using Microsoft.AspNetCore.Identity;

namespace FitnessCenter.Models
{
    public class ApplicationUser : IdentityUser
    {
        // İstenilen ek alanlar
        public string FullName { get; set; }  // Tam ad
        public string Role { get; set; }  // Admin / Üye / Eğitmen

        // Ekstra alanlar (istediğiniz gibi genişletilebilir)
    }
}
