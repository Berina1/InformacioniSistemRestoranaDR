using Restoran.BLL.Interfaces;
using Restoran.DAL.Interfaces;
using Restoran.DTO;
using Restoran.Models;

namespace Restoran.BLL.Services
{
    public class RezervacijaService : IRezervacijaService
    {
        private readonly IRezervacijaRepository _rezervacijaRepository;
        public RezervacijaService(IRezervacijaRepository rezervacijaRepository)
        {
            _rezervacijaRepository = rezervacijaRepository;
        }
        public async Task<List<RezervacijaDTO>> GetRezervacijaAsync()
        {
            var rezervacija = await _rezervacijaRepository.GetRezervacijaAsync();
            return rezervacija.Select(rezervacija => new RezervacijaDTO
            {
                RezervacijaID = rezervacija.RezervacijaID,
                StoID = rezervacija.StoID,
                RezervisanoOd = rezervacija.RezervisanoOd,
                VrijemeRezervacije = rezervacija.VrijemeRezervacije,
                KontaktBroj = rezervacija.KontaktBroj,
                Status = rezervacija.Status,
            }).ToList();
        }
        public async Task AddRezervacijaAsync(RezervacijaDTO rezervacijaDTO)
        {
            var rezervacija = new Rezervacija
            {
                StoID = rezervacijaDTO.StoID,
                RezervisanoOd = rezervacijaDTO.RezervisanoOd,
                VrijemeRezervacije = rezervacijaDTO.VrijemeRezervacije,
                KontaktBroj = rezervacijaDTO.KontaktBroj,
                Status = rezervacijaDTO.Status,

            };

            await _rezervacijaRepository.AddRezervacijaAsync(rezervacija);
        }
        public async Task<RezervacijaDTO> UpdateRezervacijaAsync(int id, RezervacijaDTO rezervacijaDto)
        {
            var existingRezervacija = await _rezervacijaRepository.GetRezervacijaByIdAsync(id);

            if (existingRezervacija == null)
                return null;

            existingRezervacija.StoID = rezervacijaDto.StoID;
            existingRezervacija.RezervisanoOd = rezervacijaDto.RezervisanoOd;
            existingRezervacija.VrijemeRezervacije = rezervacijaDto.VrijemeRezervacije;
            existingRezervacija.KontaktBroj = rezervacijaDto.KontaktBroj;
            existingRezervacija.Status = rezervacijaDto.Status;

            await _rezervacijaRepository.UpdateRezervacijaAsync(existingRezervacija);

            var updatedRezervacijaDto = new RezervacijaDTO
            {
                RezervacijaID = existingRezervacija.RezervacijaID,
                StoID = existingRezervacija.StoID,
                RezervisanoOd = existingRezervacija.RezervisanoOd,
                VrijemeRezervacije = existingRezervacija.VrijemeRezervacije,
                KontaktBroj=existingRezervacija.KontaktBroj,
                Status = existingRezervacija.Status
            };

            return updatedRezervacijaDto;
        }
        public async Task<bool> DeleteRezervacijaAsync(int id)
        {
            var rezervacija = await _rezervacijaRepository.GetRezervacijaByIdAsync(id);

            if (rezervacija == null)
            {
                return false;
            }
            await _rezervacijaRepository.DeleteRezervacijaAsync(rezervacija);
            return true;
        }
    }
}