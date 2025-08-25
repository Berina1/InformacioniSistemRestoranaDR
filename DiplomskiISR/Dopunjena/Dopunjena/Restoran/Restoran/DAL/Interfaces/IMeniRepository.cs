using Restoran.DTO;
using Restoran.Models;

namespace Restoran.DAL.Interfaces
{
    public interface IMeniRepository
    {
        Task AddMeniAsync(Meni meni);
        Task<List<Meni>> GetMeniAsync();
        Task<Meni> GetMeniByIdAsync(int id);
        Task UpdateMeniAsync(Meni meni);
        Task DeleteMeniAsync(Meni meni);

    }
}