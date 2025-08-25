using Restoran.DTO;
using Restoran.Models;

namespace Restoran.BLL.Interfaces
{
    public interface IKorisniciService
    {
        Task<KorisniciDTO> GetKorisniciByIdAsync(int id);
        Task<KorisniciDTO> LoginAsync(string email, string password);
        string Autentifikuj(PrijavaDTO prijava);
        void RegistrujKorisnika(Korisnici korisnici);
        void OdjaviKorisnika(string token);

    }
}