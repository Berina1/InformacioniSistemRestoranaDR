using Restoran.BLL.Interfaces;
using Restoran.DAL.Interfaces;
using Restoran.DAL.Repositories;
using Restoran.DTO;
using Restoran.Models;

namespace Restoran.BLL.Services
{
    public class StoloviService : IStoloviService
    {
        private readonly IStoloviRepository _stoloviRepository;
        public StoloviService(IStoloviRepository stoloviRepository)
        {
            _stoloviRepository = stoloviRepository;
        }
        public async Task<List<StoloviDTO>> GetStoloviAsync()
        {
            var stolovi = await _stoloviRepository.GetStoloviAsync();
            return stolovi.Select(stolovi => new StoloviDTO
            {
                StoID = stolovi.StoID,
                BrojStola = stolovi.BrojStola,
                BrojMjesta = stolovi.BrojMjesta,
                Dostupan = stolovi.Dostupan

            }).ToList();
        }
    }
}