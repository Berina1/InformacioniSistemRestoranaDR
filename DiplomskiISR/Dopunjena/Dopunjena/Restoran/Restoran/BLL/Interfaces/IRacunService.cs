using Restoran.DTO;

namespace Restoran.BLL.Interfaces
{
    public interface IRacunService
    {
        Task<List<RacunDTO>> GetRacunAsync();
        Task AddRacunAsync(RacunDTO racunDTO);
        Task<RacunDTO> UpdateRacunAsync(int id, RacunDTO racunDTO);
        Task<bool> DeleteRacunAsync(int id);
        Task<RacunDTO> GetRacunByIdAsync(int id);
        RacunDTO GetRacunById(int racunId);
        RacunDTO GetRacunByNaruzbaId(int narudzbaId);
        RacunDTO GenerisiRacun(int narudzbaId, string nacinPlacanja);
        List<RacunDTO> GetAllRacuni();
    }
}