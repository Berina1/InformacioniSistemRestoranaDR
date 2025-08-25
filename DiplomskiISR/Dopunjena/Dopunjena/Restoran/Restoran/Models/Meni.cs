namespace Restoran.Models
{
    public class Meni
    {
        public int MeniID { get; set; }
        public string Naziv { get; set; }
        public decimal Cijena { get; set; }
        public string Opis { get; set; }
        public string? slika { get; set; }
        public bool Kategorija { get; set; }
        public bool Obrisano { get; set; }

    }
}