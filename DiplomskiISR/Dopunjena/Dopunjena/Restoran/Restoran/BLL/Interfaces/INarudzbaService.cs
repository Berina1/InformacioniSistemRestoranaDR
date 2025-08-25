using Restoran.DTO;

namespace Restoran.BLL.Interfaces
{
    public interface INarudzbaService
    {
        Task<List<NarudzbaDTO>> GetNarudzbaAsync();
        Task AddNarudzbaAsync(NarudzbaPostDTO narudzbaCreateDTO);
        Task<NarudzbaDTO> UpdateNarudzbaAsync(int id, string status);
        Task<bool> DeleteNarudzbaAsync(int id);
        Task<NarudzbaDTO> GetNarudzbaByIdAsync(int id);
    }
}