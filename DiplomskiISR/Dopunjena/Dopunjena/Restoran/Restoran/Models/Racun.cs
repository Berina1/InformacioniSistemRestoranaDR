namespace Restoran.Models
{
    public class Racun
    {
        public int RacunID { get; set; }
        public int NarudzbaID { get; set; }
        public decimal Ukupno { get; set; }
        public string NacinPlacanja { get; set; }
        public DateTime VrijemePlacanja { get; set; }
        public Narudzba Narudzba { get; set; }
        public string BrojRacuna { get; set; }
        public List<StavkaRacuna> StavkeRacuna { get; set; }

    }
}