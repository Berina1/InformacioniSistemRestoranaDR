using Restoran.Models;
using System.ComponentModel.DataAnnotations;

namespace Restoran.Models
{
    public class DetaljiNarudzbe
    {
        [Key]
        public int DetaljID { get; set; }
        public int NarudzbaID { get; set; }
        public int MeniID { get; set; }
        public int Kolicina { get; set; }
        public decimal UkupnaCijena { get; set; }
        public Meni Meni { get; set; }
        public string NazivArtikla { get; set; }
        public Narudzba Narudzba { get; set; }
        public decimal Cijena { get; set; }

        public decimal Ukupno => Kolicina * Cijena;
    }
}


