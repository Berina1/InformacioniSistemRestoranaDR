using Microsoft.EntityFrameworkCore;
using Restoran.DAL.Data;
using Restoran.DAL.Interfaces;
using Restoran.Models;

namespace Restoran.DAL.Repositories
{
    public class MeniRepository : IMeniRepository
    {
        private readonly ApplicationDbContext _context;
        public MeniRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Meni>> GetMeniAsync()
        {
            return await _context.Meni.ToListAsync();
        }
        public async Task AddMeniAsync(Meni meni)
        {
            await _context.Meni.AddAsync(meni);
            await _context.SaveChangesAsync();
        }
        public async Task<Meni> GetMeniByIdAsync(int id)
        {
            return await _context.Meni.FirstOrDefaultAsync(m => m.MeniID == id);
        }
        public async Task UpdateMeniAsync(Meni meni)
        {
            _context.Meni.Update(meni);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteMeniAsync(Meni meni)
        {
            try
            {
                _context.Meni.Remove(meni);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}