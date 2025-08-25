namespace Restoran.DTO
{
    public class RezervacijaDTO
    {
        public int RezervacijaID { get; set; }
        public int? StoID { get; set; }
        public int BrojOsoba { get; set; }
        public string RezervisanoOd { get; set; }
        public DateTime VrijemeRezervacije { get; set; }
        public string KontaktBroj { get; set; }

        public string Email { get; set; }
        public string Status { get; set; }

    }
}