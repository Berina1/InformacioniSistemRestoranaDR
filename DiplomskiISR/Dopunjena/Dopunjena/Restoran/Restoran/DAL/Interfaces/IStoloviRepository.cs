using Restoran.DTO;
using Restoran.Models;

namespace Restoran.DAL.Interfaces
{
    public interface IStoloviRepository
    {
        Task<List<Stolovi>> GetStoloviAsync();

    }
}