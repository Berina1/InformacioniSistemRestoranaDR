using System.ComponentModel.DataAnnotations;

namespace Restoran.Models
{
    public class Stolovi
    {
        [Key]  
        public int StoID { get; set; }
        public int BrojStola { get; set; }
        public int BrojMjesta { get; set; }
        public bool Dostupan { get; set; }

    }
}