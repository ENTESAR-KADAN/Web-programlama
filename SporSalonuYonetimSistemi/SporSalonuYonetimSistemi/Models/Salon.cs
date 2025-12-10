namespace SporSalonuYonetimSistemi.Models
{
    public class Salon
    {
        public int Id { get; set; }  // Veritabanı için anahtar (primary key)
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal Price { get; set; }
    }
}
