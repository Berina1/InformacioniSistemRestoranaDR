using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Restoran.BLL.Interfaces;
using Restoran.BLL.Services;
using Restoran.DAL.Interfaces;
using Restoran.DTO;

namespace Restoran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RacunController : ControllerBase
    {
        private readonly IRacunService _racunService;
        private readonly IMapper _mapper;
        public RacunController(IRacunService racunService, IMapper mapper)
        {
            _racunService = racunService;
            _mapper = mapper;
        }

        /*[HttpGet]
        public async Task<IActionResult> GetRacun()
        {
            var racun = await _racunService.GetRacunAsync();
            return Ok(racun);
        }*/

        /*[HttpGet]
        public IActionResult GetAllRacuni()
        {
            var racuni = _racunService.GetAllRacuni();
            var racuniDTO = racuni.Select(racun => new RacunDTO
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

            return Ok(racuniDTO);
        }*/
        [HttpGet]
        public IActionResult GetAllRacuni()
        {
            var racuni = _racunService.GetAllRacuni();
            var racuniDTO = _mapper.Map<List<RacunDTO>>(racuni); // Automapper maps the objects

            return Ok(racuniDTO);
        }

        /*[HttpPost]
        public async Task<IActionResult> AddRacun([FromBody] RacunDTO racun)
        {
            if (racun == null)
                return BadRequest("Nepostojeci podatak.");

            await _racunService.AddRacunAsync(racun);

            return Ok(racun);
        }
        */
        [HttpPost("generisi")]
        public IActionResult GenerisiRacun([FromBody] GenerisiRacunDTO racunRequest)
        {
            try
            {
                var racun = _racunService.GenerisiRacun(racunRequest.NarudzbaID, racunRequest.NacinPlacanja);
                var racunDTO = new RacunDTO
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
                };
                return Ok(racunDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRacun(int id, [FromBody] RacunDTO racun)
        {
            if (racun == null)
                return BadRequest("Nepostojeci podatak.");

            var updatedRacun = await _racunService.UpdateRacunAsync(id, racun);

            if (updatedRacun == null)
                return NotFound($"Rezervacija with ID {id} not found.");

            return Ok(updatedRacun);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRacun(int id)
        {
            var isDeleted = await _racunService.DeleteRacunAsync(id);

            if (!isDeleted)
            {
                return NotFound($"Racun with ID {id} not found.");
            }
            return Ok($"Racun with ID {id} deleted successfully.");
        }
        /*[HttpGet("{id}")]
        public async Task<IActionResult> GetRacunById(int id)
        {
            var racun = await _racunService.GetRacunByIdAsync(id);

            if (racun == null)
                return NotFound($"Racun with ID {id} not found.");

            return Ok(racun);
        }*/
        /*[HttpGet("{racunId}")]
        public IActionResult GetRacun(int racunId)
        {
            var racun = _racunService.GetRacunById(racunId);
            if (racun == null) return NotFound();

            var racunDTO = new RacunDTO
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
            };

            return Ok(racunDTO);
        }*/
        [HttpGet("{racunId}")]
        public IActionResult GetRacun(int racunId)
        {
            var racun = _racunService.GetRacunById(racunId);
            if (racun == null) return NotFound();

            var racunDTO = _mapper.Map<RacunDTO>(racun);

            return Ok(racunDTO);
        }

        //[HttpGet("{racunIdprekoNarudzbe}")]
        [HttpGet("api/racun/{narudzbeId}")]
        public IActionResult GetRacunByNarudzbeId(int narudzbeId)
        {
            var racun = _racunService.GetRacunByNaruzbaId(narudzbeId);
            if (racun == null) return NotFound();

            var racunDTO = _mapper.Map<RacunDTO>(racun);

            return Ok(racunDTO);
        }
    }
}