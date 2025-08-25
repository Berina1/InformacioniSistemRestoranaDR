using Restoran.DTO;
using Restoran.Models;

namespace Restoran.BLL.Interfaces
{
    public interface IMeniService
    {
        Task<List<MeniDTO>> GetMeniAsync();
        Task AddMeniAsync(MeniDTO meniDTO);
        Task<MeniDTO> UpdateMeniAsync(int id, MeniDTO meniDto);
        Task<bool> DeleteMeniAsync(int id);
        Task<MeniDTO> GetMeniByIdAsync(int id);

    }
}