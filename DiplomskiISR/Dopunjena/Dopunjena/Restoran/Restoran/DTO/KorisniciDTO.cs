using Restoran.Models;

namespace Restoran.DTO
{
    public class KorisniciDTO
    {
        
        public int KorisnikID { get; set; }
        public string ImePrezime { get; set; }
        public string Uloga { get; set; }
        public string Smjena { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public string Email { get; set; }
    }
}