namespace Restoran.Models
{
    public class Rezervacija
    {
        public int RezervacijaID { get; set; }
        public int? StoID { get; set; }
        public string RezervisanoOd { get; set; }
        public DateTime VrijemeRezervacije { get; set; }
        public string KontaktBroj { get; set; }
        public string Status { get; set; }

    }
}