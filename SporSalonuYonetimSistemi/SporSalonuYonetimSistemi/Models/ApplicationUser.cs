using Microsoft.AspNetCore.Identity;

namespace SporSalonuYonetimSistemi.Data
{
    public class ApplicationUser : IdentityUser
    {
        // Ekstra kullanıcı bilgileri
        public string FullName { get; set; }
        public string Role { get; set; }  // Kullanıcı rolü
    }
}
