using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Restoran.DAL.Data;
using Restoran.DAL.Interfaces;
using Restoran.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Restoran.DAL.Repositories
{
    public class KorisniciRepository : IKorisniciRepository
    {
        private readonly ApplicationDbContext _context;
        public KorisniciRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
       
        public async Task<Korisnici> GetKorisniciByIdAsync(int id)
        {
            return await _context.Korisnici.FirstOrDefaultAsync(m => m.KorisnikID == id);
        }
        /*hej*/
        public async Task<Korisnici> GetKorisnikByEmailAndPasswordAsync(string email, string password)
        {
            return await _context.Korisnici.FirstOrDefaultAsync(k => k.Email == email && k.Lozinka == password);
        }
        public Korisnici GetByKorisnickoIme(string korisnickoIme)
        {
            return _context.Korisnici.FirstOrDefault(k => k.KorisnickoIme == korisnickoIme);
        }
        public void DodajKorisnika(Korisnici korisnici)
        {
            _context.Korisnici.Add(korisnici);
            _context.SaveChanges();
        }

    }
}
