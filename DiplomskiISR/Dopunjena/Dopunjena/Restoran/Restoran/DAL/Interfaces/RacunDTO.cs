using Restoran.Models;

namespace Restoran.DTO
{
    public class RacunDTO
    {
        public int RacunID { get; set; }
        public int NarudzbaID { get; set; }
        public decimal Ukupno { get; set; }
        public string NacinPlacanja { get; set; }
        public DateTime VrijemePlacanja { get; set; }
        public Narudzba Narudzba { get; set; }
        public string BrojRacuna { get; set; }
        public string StatusNarudzbe { get; set; }
        public List<StavkaRacunaDTO> StavkeRacuna { get; set; }

    }
}