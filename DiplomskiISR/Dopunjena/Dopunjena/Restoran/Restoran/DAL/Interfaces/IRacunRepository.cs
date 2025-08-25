using Restoran.Models;

namespace Restoran.DAL.Interfaces
{
    public interface IRacunRepository
    {
        Task AddRacunAsync(Racun racun);
        Task<List<Racun>> GetRacunAsync();
        Task<Racun> GetRacunByIdAsync(int id);
        Task UpdateRacunAsync(Racun racun);
        Task DeleteRacunAsync(Racun racun);
        Racun GenerisiRacun(int narudzbaId, string nacinPlacanja);
        Racun GetRacunById(int racunId);
        Racun GetRacunByNarudzbaId(int narudzbaId);
        List<Racun> GetAllRacuni();
    }
}