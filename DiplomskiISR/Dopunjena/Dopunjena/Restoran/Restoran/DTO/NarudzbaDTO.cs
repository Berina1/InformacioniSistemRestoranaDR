using Restoran.Models;

namespace Restoran.DTO
{
    public class NarudzbaDTO
    {
        public int NarudzbaID { get; set; }
        public int StoID { get; set; }
        public int KorisnikID { get; set; }
        public DateTime VrijemeNarudzbe { get; set; }
        public string Status { get; set; }
        public List<DetaljiNarudzbeDTO> DetaljiNarudzbeDTO { get; set; }

    }
}