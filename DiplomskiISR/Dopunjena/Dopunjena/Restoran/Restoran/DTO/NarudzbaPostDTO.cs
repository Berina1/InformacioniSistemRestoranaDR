namespace Restoran.DTO
{
    public class NarudzbaPostDTO
    {
        public int StoID { get; set; }
        public int KorisnikID { get; set; }
        public DateTime VrijemeNarudzbe { get; set; }
        public string Status { get; set; }
        public List<DetaljiNarudzbePostDTO> DetaljiNarudzbe { get; set; }

    }
}