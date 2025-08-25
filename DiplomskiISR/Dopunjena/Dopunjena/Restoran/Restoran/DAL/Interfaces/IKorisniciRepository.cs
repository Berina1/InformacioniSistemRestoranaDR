using Restoran.DTO;
using Restoran.Models;

namespace Restoran.DAL.Interfaces
{
    public interface IKorisniciRepository
    {

        Task<Korisnici> GetKorisniciByIdAsync(int id);
        Task<Korisnici> GetKorisnikByEmailAndPasswordAsync(string email, string password);
        Korisnici GetByKorisnickoIme(string korisnickoIme);
        void DodajKorisnika(Korisnici korisnik);
    }
}