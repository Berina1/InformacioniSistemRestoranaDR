using Restoran.DTO;

namespace Restoran.BLL.Interfaces
{
    public interface IRezervacijaService
    {
        Task<List<RezervacijaDTO>> GetRezervacijaAsync();
        Task AddRezervacijaAsync(RezervacijaDTO rezervacijaDTO);
        Task<RezervacijaDTO> UpdateRezervacijaAsync(int id, RezervacijaDTO rezervacijaDTO);
        Task<bool> DeleteRezervacijaAsync(int id);
    }
}