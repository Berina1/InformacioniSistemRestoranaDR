using Restoran.Models;
using Restoran.DTO;
using Restoran.DAL.Interfaces;

namespace Restoran.DAL.Interfaces
{
    public interface IRezervacijaRepository
    {
        Task AddRezervacijaAsync(Rezervacija rezervacija);
        Task<List<Rezervacija>> GetRezervacijaAsync();
        Task<Rezervacija> GetRezervacijaByIdAsync(int id);
        Task UpdateRezervacijaAsync(Rezervacija rezervacija);
        Task DeleteRezervacijaAsync(Rezervacija rezervacija);
    }
}