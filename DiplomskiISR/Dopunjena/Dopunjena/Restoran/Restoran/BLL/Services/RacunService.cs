using Restoran.BLL.Interfaces;
using Restoran.DAL.Interfaces;
using Restoran.DAL.Repositories;
using Restoran.DTO;
using Restoran.Models;
using AutoMapper;

namespace Restoran.BLL.Services
{
    public class RacunService : IRacunService
    {
        private readonly IRacunRepository _racunRepository;
        private readonly IMapper _mapper;
        public RacunService(IRacunRepository racunRepository, IMapper mapper)
        {
            _racunRepository = racunRepository;
            _mapper = mapper;
        }
        public async Task<List<RacunDTO>> GetRacunAsync()
        {
            var racun = await _racunRepository.GetRacunAsync();
            return racun.Select(racun => new RacunDTO
            {
                RacunID = racun.RacunID,
                NarudzbaID = racun.NarudzbaID,
                Ukupno = racun.Ukupno,
                NacinPlacanja = racun.NacinPlacanja,
                VrijemePlacanja = racun.VrijemePlacanja,
            }).ToList();
        }
        public async Task AddRacunAsync(RacunDTO racunDTO)
        {
            var racun = new Racun
            {
                NarudzbaID = racunDTO.NarudzbaID,
                Ukupno = racunDTO.Ukupno,
                NacinPlacanja = racunDTO.NacinPlacanja,
                VrijemePlacanja = racunDTO.VrijemePlacanja,
            };

            await _racunRepository.AddRacunAsync(racun);
        }
        public async Task<RacunDTO> UpdateRacunAsync(int id, RacunDTO racunDto)
        {
            var existingRacun = await _racunRepository.GetRacunByIdAsync(id);

            if (existingRacun == null)
                return null;

            existingRacun.NarudzbaID = racunDto.NarudzbaID;
            existingRacun.Ukupno = racunDto.Ukupno;
            existingRacun.NacinPlacanja = racunDto.NacinPlacanja;
            existingRacun.VrijemePlacanja = racunDto.VrijemePlacanja;

            await _racunRepository.UpdateRacunAsync(existingRacun);

            var updatedRacunDto = new RacunDTO
            {
                RacunID = existingRacun.RacunID,
                NarudzbaID = existingRacun.NarudzbaID,
                Ukupno = existingRacun.Ukupno,
                NacinPlacanja = existingRacun.NacinPlacanja,
            };

            return updatedRacunDto;
        }
        public async Task<bool> DeleteRacunAsync(int id)
        {
            var racun = await _racunRepository.GetRacunByIdAsync(id);

            if (racun == null)
            {
                return false;
            }
            await _racunRepository.DeleteRacunAsync(racun);
            return true;
        }
        /*public async Task<RacunDTO> GetRacunByIdAsync(int id)
        {
            var racun = await _racunRepository.GetRacunByIdAsync(id);

            if (racun == null)
                return null;

            return new RacunDTO
            {
                RacunID = racun.RacunID,
                NarudzbaID = racun.NarudzbaID,
                Ukupno = racun.Ukupno,
                NacinPlacanja = racun.NacinPlacanja,
                VrijemePlacanja = racun.VrijemePlacanja
            };

        }*/
        //Berina dodala
        public async Task<RacunDTO> GetRacunByIdAsync(int id)
        {
            var racun = await _racunRepository.GetRacunByIdAsync(id);
            return _mapper.Map<RacunDTO>(racun);
        }
        public RacunDTO GetRacunById(int racunId)
        {
            var racun = _racunRepository.GetRacunById(racunId);

            if (racun == null) return null;

            // Use AutoMapper to map the Racun object to RacunDTO
            var racunDTO = _mapper.Map<RacunDTO>(racun);

            return racunDTO;
        }

        public RacunDTO GetRacunByNaruzbaId(int narudzbaId)
        {
            var racun = _racunRepository.GetRacunByNarudzbaId(narudzbaId);

            if (racun == null) return null;

            // Use AutoMapper to map the Racun object to RacunDTO
            var racunDTO = _mapper.Map<RacunDTO>(racun);

            return racunDTO;
        }
        public List<RacunDTO> GetAllRacuni()
        {
            var racuni = _racunRepository.GetAllRacuni();

            return racuni.Select(racun => new RacunDTO
            {
                RacunID = racun.RacunID,
                BrojRacuna = racun.BrojRacuna,
                Ukupno = racun.Ukupno,
                NacinPlacanja = racun.NacinPlacanja,
                VrijemePlacanja = racun.VrijemePlacanja,
                StatusNarudzbe = racun.Narudzba.Status,
                StavkeRacuna = racun.StavkeRacuna.Select(s => new StavkaRacunaDTO
                {
                    NazivArtikla = s.NazivArtikla,
                    Kolicina = s.Kolicina,
                    Cijena = s.Cijena,
                    Ukupno = s.Ukupno
                }).ToList()
            }).ToList();
        }

        public RacunDTO GenerisiRacun(int narudzbaId, string nacinPlacanja)
        {
            var racun = _racunRepository.GenerisiRacun(narudzbaId, nacinPlacanja);

            var racunDTO = _mapper.Map<RacunDTO>(racun);

            return racunDTO;
        }

        //public RacunDTO GenerisiRacun(int narudzbaId, string nacinPlacanja)
        //{
        //    var racun = _racunRepository.GenerisiRacun(narudzbaId, nacinPlacanja);

        //    var racunDTO = new RacunDTO
        //    {
        //        RacunID = racun.RacunID,
        //        BrojRacuna = racun.BrojRacuna,
        //        Ukupno = racun.Ukupno,
        //        NacinPlacanja = racun.NacinPlacanja,
        //        VrijemePlacanja = racun.VrijemePlacanja,
        //        Narudzba = racun.Narudzba,
        //        StatusNarudzbe = racun.Narudzba.Status,
        //        StavkeRacuna = racun.StavkeRacuna.Select(s => new StavkaRacunaDTO
        //        {
        //            NazivArtikla = s.NazivArtikla,
        //            Kolicina = s.Kolicina,
        //            Cijena = s.Cijena,
        //            Ukupno = s.Ukupno
        //        }).ToList()
        //    };

        //    return racunDTO;
        //}
    }
}
