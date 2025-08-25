using Microsoft.EntityFrameworkCore;
using Restoran.DAL.Data;
using Restoran.DAL.Interfaces;
using Restoran.Models;

namespace Restoran.DAL.Repositories
{
    public class StoloviRepository : IStoloviRepository
    {
        private readonly ApplicationDbContext _context;
        public StoloviRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Stolovi>> GetStoloviAsync()
        {
            return await _context.Stolovi.ToListAsync();
        }
    }
}