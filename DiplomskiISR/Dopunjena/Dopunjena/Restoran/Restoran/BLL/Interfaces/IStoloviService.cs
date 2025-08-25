using Restoran.DTO;
using Restoran.Models;

namespace Restoran.BLL.Interfaces
{
    public interface IStoloviService
    {
        Task<List<StoloviDTO>> GetStoloviAsync();
    }
}