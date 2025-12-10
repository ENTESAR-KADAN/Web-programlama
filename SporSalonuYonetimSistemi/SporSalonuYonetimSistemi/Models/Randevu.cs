namespace SporSalonuYonetimSistemi.Models
{
    public class Randevu
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Service { get; set; }
        public decimal Price { get; set; }

        // İlişkiler
        public int UyeId { get; set; }
        public Uye Uye { get; set; }

        public int AntrenorId { get; set; }
        public Antrenor Antrenor { get; set; }
    }
}
