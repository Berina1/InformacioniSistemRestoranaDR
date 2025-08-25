using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Restoran.BLL.Interfaces;
using Restoran.DAL.Data;
using Restoran.DAL.Interfaces;
using Restoran.DAL.Repositories;
using Restoran.DTO;
using Restoran.Models;

namespace Restoran.BLL.Services
{
    public class NarudzbaService : INarudzbaService
    {
        private readonly INarudzbaRepository _narudzbaRepository;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public NarudzbaService(INarudzbaRepository narudzbaRepository, IMapper mapper, ApplicationDbContext context)
        {
            _narudzbaRepository = narudzbaRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<NarudzbaDTO>> GetNarudzbaAsync()
        {
            var narudzba = await _narudzbaRepository.GetNarudzbaAsync();
            return _mapper.Map<List<NarudzbaDTO>>(narudzba);
        }
        //public async Task AddNarudzbaAsync(NarudzbaPostDTO narudzbaCreateDTO)
        //{
        //    //var narudzba = new Narudzba
        //    //{
        //    //    StoID = narudzbaCreateDTO.StoID,
        //    //    KorisnikID = narudzbaCreateDTO.KorisnikID,
        //    //    VrijemeNarudzbe = narudzbaCreateDTO.VrijemeNarudzbe,
        //    //    Status = narudzbaCreateDTO.Status,
        //    //    DetaljiNarudzbe = narudzbaCreateDTO.DetaljiNarudzbe 
        //    //        .Select(detaljDTO => new DetaljiNarudzbe
        //    //        {
        //    //            MeniID = detaljDTO.MeniID, 
        //    //            Kolicina = detaljDTO.Kolicina,
        //    //            UkupnaCijena = detaljDTO.UkupnaCijena
        //    //        })
        //    //        .ToList()
        //    //};
        //    var narudzba = _mapper.Map<Narudzba>(narudzbaCreateDTO);


        //    await _narudzbaRepository.AddNarudzbaAsync(narudzba);
        //}

        public async Task AddNarudzbaAsync(NarudzbaPostDTO narudzbaCreateDTO)
        {
            // Fetch the Meni items for each DetaljiNarudzbe to get the Naziv
            var meniItems = await _context.Meni
                .Where(m => narudzbaCreateDTO.DetaljiNarudzbe.Select(d => d.MeniID).Contains(m.MeniID))
                .ToListAsync();

            // Map DTO to Narudzba entity
            var narudzba = new Narudzba
            {
                StoID = narudzbaCreateDTO.StoID,
                KorisnikID = narudzbaCreateDTO.KorisnikID,
                VrijemeNarudzbe = narudzbaCreateDTO.VrijemeNarudzbe,
                Status = narudzbaCreateDTO.Status,
                // Use AutoMapper to map the rest of the properties
                DetaljiNarudzbe = narudzbaCreateDTO.DetaljiNarudzbe
                    .Select(detaljDTO =>
                    {
                        var meniItem = meniItems.FirstOrDefault(m => m.MeniID == detaljDTO.MeniID);
                        return new DetaljiNarudzbe
                        {
                            MeniID = detaljDTO.MeniID,
                            Kolicina = detaljDTO.Kolicina,
                            UkupnaCijena = detaljDTO.UkupnaCijena,
                            Cijena = meniItem?.Cijena ?? 0, // Use Cijena from Meni table or default to 0
                            NazivArtikla = meniItem?.Naziv // Get Naziv from Meni table
                        };
                    })
                    .ToList()
            };

            // Save the new Narudzba entity with its details
            await _narudzbaRepository.AddNarudzbaAsync(narudzba);
        }


        public async Task<NarudzbaDTO> UpdateNarudzbaAsync(int id, string status)
        {
            var existingNarudzba = await _narudzbaRepository.GetNarudzbaByIdAsync(id);

            if (existingNarudzba == null)
                return null;

            existingNarudzba.Status = status;

            await _narudzbaRepository.UpdateNarudzbaAsync(existingNarudzba);

            var updatedNarudzbaDto = new NarudzbaDTO
            {
                NarudzbaID = existingNarudzba.NarudzbaID,
                StoID = existingNarudzba.StoID,
                KorisnikID = existingNarudzba.KorisnikID,
                VrijemeNarudzbe = existingNarudzba.VrijemeNarudzbe,
                Status = existingNarudzba.Status
            };

            return updatedNarudzbaDto;
        }
        public async Task<bool> DeleteNarudzbaAsync(int id)
        {
            var narudzba = await _narudzbaRepository.GetNarudzbaByIdAsync(id);

            if (narudzba == null)
            {
                return false;
            }
            await _narudzbaRepository.DeleteNarudzbaAsync(narudzba);
            return true;
        }
        public async Task<NarudzbaDTO> GetNarudzbaByIdAsync(int id)
        {
            var narudzba = await _narudzbaRepository.GetNarudzbaByIdAsync(id);

            if (narudzba == null)
                return null;

            return new NarudzbaDTO
            {
                NarudzbaID = narudzba.NarudzbaID,
                StoID = narudzba.StoID,
                KorisnikID = narudzba.KorisnikID,
                VrijemeNarudzbe = narudzba.VrijemeNarudzbe,
                Status = narudzba.Status
            };
        }
    }
}