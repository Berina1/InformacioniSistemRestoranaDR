using Restoran.Models;
using Restoran.DTO;
using Restoran.DAL.Interfaces;

namespace Restoran.DAL.Interfaces
{
    public interface INarudzbaRepository
    {
        Task AddNarudzbaAsync(Narudzba narudzba);
        Task<List<Narudzba>> GetNarudzbaAsync();
        Task<Narudzba> GetNarudzbaByIdAsync(int id);
        Task UpdateNarudzbaAsync(Narudzba narudzba);
        Task DeleteNarudzbaAsync(Narudzba narudzba);
    }
}