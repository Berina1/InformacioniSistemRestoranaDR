using Microsoft.AspNetCore.Mvc;
using Restoran.BLL.Interfaces;
using Restoran.BLL.Services;
using Restoran.DTO;

namespace Restoran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NarudzbaController : ControllerBase
    {
        private readonly INarudzbaService _narudzbaService;
        public NarudzbaController(INarudzbaService narudzbaService)
        {
            _narudzbaService = narudzbaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNarudzba()
        {
            var narudzba = await _narudzbaService.GetNarudzbaAsync();
            return Ok(narudzba);
        }

        [HttpPost]
        public async Task<IActionResult> AddNarudzba([FromBody] NarudzbaPostDTO narudzba)
        {
            if (narudzba == null)
                return BadRequest("Nepostojeci podatak.");

            await _narudzbaService.AddNarudzbaAsync(narudzba);

            return Ok(narudzba); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateNarudzba(int id, string status)
        {
            if (status == null)
                return BadRequest("Nepostojeci podatak.");

            var updatedNarudzba = await _narudzbaService.UpdateNarudzbaAsync(id, status);

            if (updatedNarudzba == null)
                return NotFound($"Narudzba with ID {id} not found.");

            return Ok(updatedNarudzba);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNarudzba(int id)
        {
            var isDeleted = await _narudzbaService.DeleteNarudzbaAsync(id);

            if (!isDeleted)
            {
                return NotFound($"Narudzba with ID {id} not found.");
            }
            return Ok($"Narudzba with ID {id} deleted successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNarudzbaById(int id)
        {
            var narudzba = await _narudzbaService.GetNarudzbaByIdAsync(id);

            if (narudzba == null)
                return NotFound($"Narudzba with ID {id} not found.");

            return Ok(narudzba);
        }
    }
}