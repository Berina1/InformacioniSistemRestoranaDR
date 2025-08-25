using Restoran.Models;

namespace Restoran.Models
{
    public class Narudzba
    {
        public int NarudzbaID { get; set; }
        public int StoID { get; set; }
        public int KorisnikID { get; set; }
        public DateTime VrijemeNarudzbe { get; set; }
        public string Status { get; set; }
        public List<DetaljiNarudzbe> DetaljiNarudzbe { get; set; }

    }
}