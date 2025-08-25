using Restoran.BLL.Interfaces;
using Restoran.DAL.Interfaces;
using Restoran.DTO;
using Restoran.Models;

namespace Restoran.BLL.Services
{
    public class MeniService : IMeniService
    {
        private readonly IMeniRepository _meniRepository;
        public MeniService(IMeniRepository meniRepository)
        {
            _meniRepository = meniRepository;
        }
        public async Task<List<MeniDTO>> GetMeniAsync()
        {
            var meni = await _meniRepository.GetMeniAsync();
            return meni.Select(meni => new MeniDTO
            {
                MeniID = meni.MeniID,
                Naziv = meni.Naziv,
                Cijena = meni.Cijena,
                Opis = meni.Opis,
                slika = meni.slika,
                Kategorija = meni.Kategorija,
                Obrisano = meni.Obrisano
            }).ToList();
        }
        public async Task AddMeniAsync(MeniDTO meniDTO)
        {
            var meni = new Meni
            {
                Naziv = meniDTO.Naziv,
                Cijena = meniDTO.Cijena,
                Opis = meniDTO.Opis,
                slika = meniDTO.slika,
                Kategorija = meniDTO.Kategorija,
                Obrisano = meniDTO.Obrisano
            };

            await _meniRepository.AddMeniAsync(meni);
        }
        public async Task<MeniDTO> UpdateMeniAsync(int id, MeniDTO meniDto)
        {
            var existingMeni = await _meniRepository.GetMeniByIdAsync(id);

            if (existingMeni == null)
                return null;

            existingMeni.Naziv = meniDto.Naziv;
            existingMeni.Cijena = meniDto.Cijena;
            existingMeni.Opis = meniDto.Opis;
            existingMeni.slika = meniDto.slika;

            await _meniRepository.UpdateMeniAsync(existingMeni);

            return new MeniDTO
            {
                MeniID = existingMeni.MeniID,
                Naziv = existingMeni.Naziv,
                Cijena = existingMeni.Cijena,
                Opis = existingMeni.Opis,
                slika = existingMeni.slika,
                Kategorija = existingMeni.Kategorija,
                Obrisano = existingMeni.Obrisano
            };
        }
        public async Task<bool> DeleteMeniAsync(int id)
        {
            var meni = await _meniRepository.GetMeniByIdAsync(id);
            meni.Obrisano = true;

            if (meni == null)
                return false;

            await _meniRepository.UpdateMeniAsync(meni);
            return true;
        }
        public async Task<MeniDTO> GetMeniByIdAsync(int id)
        {
            var meni = await _meniRepository.GetMeniByIdAsync(id);

            if (meni == null)
                return null;

            return new MeniDTO
            {
                MeniID = meni.MeniID,
                Naziv = meni.Naziv,
                Cijena = meni.Cijena,
                Opis = meni.Opis,
                slika = meni.slika,
                Kategorija = meni.Kategorija,
                Obrisano = meni.Obrisano
            };
        }
    }
}