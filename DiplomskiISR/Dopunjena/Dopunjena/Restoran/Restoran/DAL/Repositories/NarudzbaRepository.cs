using Restoran.DAL.Data;
using Restoran.DAL.Interfaces;
using Restoran.Models;
using Microsoft.EntityFrameworkCore;

namespace Restoran.DAL.Repositories
{
    public class NarudzbaRepository : INarudzbaRepository
    {
        private readonly ApplicationDbContext _context;
        public NarudzbaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Narudzba>> GetNarudzbaAsync()
        {
            var narudzbe = await _context.Narudzbe
                                           .Include(n => n.DetaljiNarudzbe)
                                           .ThenInclude(n => n.Meni)
                                           .ToListAsync();
            return narudzbe;
        }
        public async Task AddNarudzbaAsync(Narudzba narudzba)
        {
            await _context.Narudzbe.AddAsync(narudzba);
            await _context.SaveChangesAsync();
        }
        public async Task<Narudzba> GetNarudzbaByIdAsync(int id)
        {
            var narudzba = await _context.Narudzbe.FirstOrDefaultAsync(m => m.NarudzbaID == id);
            if (narudzba == null)
            {
                return null;
            }
            return narudzba;
        }
        public async Task UpdateNarudzbaAsync(Narudzba narudzba)
        {
            _context.Narudzbe.Update(narudzba);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteNarudzbaAsync(Narudzba narudzba)
        {
            _context.Narudzbe.Remove(narudzba);
            await _context.SaveChangesAsync();
        }
    }
}