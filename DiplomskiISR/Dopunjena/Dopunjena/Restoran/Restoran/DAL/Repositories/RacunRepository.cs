using Restoran.DAL.Data;
using Restoran.DAL.Interfaces;
using Restoran.Models;
using Microsoft.EntityFrameworkCore;

namespace Restoran.DAL.Repositories
{
    public class RacunRepository : IRacunRepository
    {
        private readonly ApplicationDbContext _context;
        public RacunRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Racun>> GetRacunAsync()
        {
            return await _context.Racuni.ToListAsync();
        }
        public async Task AddRacunAsync(Racun racun)
        {
            await _context.Racuni.AddAsync(racun);
            await _context.SaveChangesAsync();
        }
        public async Task<Racun> GetRacunByIdAsync(int id)
        {
            var racun = await _context.Racuni
                .FirstOrDefaultAsync(m => m.RacunID == id);
            if (racun == null)
            {
                return null;
            }
            return racun;
        }
        public async Task UpdateRacunAsync(Racun racun)
        {
            _context.Racuni.Update(racun);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRacunAsync(Racun racun)
        {
            _context.Racuni.Remove(racun);
            await _context.SaveChangesAsync();
        }
        public Racun GenerisiRacun(int narudzbaId, string nacinPlacanja)
        {
            var narudzba = _context.Narudzbe
                .Where(n => n.NarudzbaID == narudzbaId)
                .Include(n => n.DetaljiNarudzbe)
                .FirstOrDefault();

            if (narudzba == null || narudzba.Status != "Završeno")
                throw new Exception("Narudžba ne postoji ili nije završena.");

            var racun = new Racun
            {
                NarudzbaID = narudzbaId,
                BrojRacuna = "R-" + DateTime.Now.Ticks,
                Ukupno = narudzba.DetaljiNarudzbe.Sum(d => d.Ukupno),
                NacinPlacanja = nacinPlacanja,
                VrijemePlacanja = DateTime.Now,
                Narudzba = narudzba,
                StavkeRacuna = narudzba.DetaljiNarudzbe.Select(d => new StavkaRacuna
                {
                    NazivArtikla = d.NazivArtikla,
                    Kolicina = d.Kolicina,
                    Cijena = d.Cijena
                }).ToList()
            };

            _context.Racuni.Add(racun);
            _context.SaveChanges();
            return racun;
        }

        public Racun GetRacunById(int racunId)
        {
            return _context.Racuni
                .Where(r => r.RacunID == racunId)
                .Include(r => r.StavkeRacuna)
                .Include(r => r.Narudzba)
                .OrderByDescending(r => r.RacunID)  // Order by RacunID, or another field
                .LastOrDefault();
        }
        public Racun GetRacunByNarudzbaId(int narudzbaId)
        {
            return _context.Racuni
                .Where(r => r.NarudzbaID == narudzbaId)
                .Include(r => r.StavkeRacuna)  // Make sure to include StavkeRacuna
                .Include(r => r.Narudzba)
                .OrderByDescending(r => r.RacunID)  // Sort by RacunID in descending order
                .FirstOrDefault();  // Get the first record, which will be the "last" due to the descending order
        }

        public List<Racun> GetAllRacuni()
        {
            return _context.Racuni
                .Include(r => r.StavkeRacuna)
                .Include(r => r.Narudzba)
                .ToList();
        }
    }
}
   