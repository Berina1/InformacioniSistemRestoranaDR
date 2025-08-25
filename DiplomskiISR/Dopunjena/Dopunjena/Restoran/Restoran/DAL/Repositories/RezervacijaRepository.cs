using Restoran.DAL.Data;
using Restoran.DAL.Interfaces;
using Restoran.Models;
using Microsoft.EntityFrameworkCore;

namespace Restoran.DAL.Repositories
{
    public class RezervacijaRepository : IRezervacijaRepository
    {
        private readonly ApplicationDbContext _context;
        public RezervacijaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Rezervacija>> GetRezervacijaAsync()
        {
            return await _context.Rezervacije.ToListAsync();
        }
        public async Task AddRezervacijaAsync(Rezervacija rezervacija)
        {
            await _context.Rezervacije.AddAsync(rezervacija);
            await _context.SaveChangesAsync();
        }
        public async Task<Rezervacija> GetRezervacijaByIdAsync(int id)
        {
            var rezervacija = await _context.Rezervacije.FirstOrDefaultAsync(m => m.RezervacijaID == id);
            if (rezervacija == null)
            {
                return null;
            }
            return rezervacija;
        }
        public async Task UpdateRezervacijaAsync(Rezervacija rezervacija)
        {
            _context.Rezervacije.Update(rezervacija);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteRezervacijaAsync(Rezervacija rezervacija)
        {
            _context.Rezervacije.Remove(rezervacija);
            await _context.SaveChangesAsync();
        }
    }
}