namespace Restoran.Models
{
    public class StavkaRacuna
    {
        public int StavkaRacunaID { get; set; }
        public int RacunID { get; set; }
        public string NazivArtikla { get; set; }
        public int Kolicina { get; set; }
        public decimal Cijena { get; set; }
        public decimal Ukupno => Kolicina * Cijena;

        public Racun Racun { get; set; }
    }
}
