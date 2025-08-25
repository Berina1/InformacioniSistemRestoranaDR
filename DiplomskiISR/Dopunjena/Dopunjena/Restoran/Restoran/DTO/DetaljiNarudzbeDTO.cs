namespace Restoran.DTO
{
    public class DetaljiNarudzbeDTO
    {
        public int NarudzbaID { get; set; }
        public int MeniID { get; set; }
        public int Kolicina { get; set; }
        public decimal UkupnaCijena { get; set; }
    //    public NarudzbaDTO Narudzba { get; set; }
        public MeniDTO Meni { get; set; }
        public string NazivArtikla { get; set; }
        public decimal Cijena { get; set; }
        public decimal Ukupno { get; set; }
    }
}