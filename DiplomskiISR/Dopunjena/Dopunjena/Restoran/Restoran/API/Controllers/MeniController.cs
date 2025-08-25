using Microsoft.AspNetCore.Mvc;
using Restoran.BLL.Interfaces;
using Restoran.DTO;

namespace Restoran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeniController : ControllerBase
    {
        private readonly IMeniService _meniService;
        public MeniController(IMeniService meniService)
        {
            _meniService = meniService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMeni()
        {
            var meni = await _meniService.GetMeniAsync();
            return Ok(meni);
        }

        [HttpPost]
        public async Task<IActionResult> AddMeni([FromBody] MeniDTO meni)
        {
            if (meni == null)
                return BadRequest("Nepostojeci podatak.");

            await _meniService.AddMeniAsync(meni);

            return Ok(meni); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMeni(int id, [FromBody] MeniDTO meni)
        {
            if (meni == null)
                return BadRequest("Nepostojeci podatak.");

            var updatedMeni = await _meniService.UpdateMeniAsync(id, meni);

            if (updatedMeni == null)
                return NotFound($"Meni with ID {id} not found.");

            return Ok(updatedMeni);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeni(int id)
        {
            var isDeleted = await _meniService.DeleteMeniAsync(id);

            if(!isDeleted)
            {
                return NotFound($"Meni with ID {id} not found.");
            }
            return Ok($"Meni with ID {id} deleted successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeniById(int id)
        {
            var meni = await _meniService.GetMeniByIdAsync(id);

            if (meni == null)
                return NotFound($"Meni with ID {id} not found.");

            return Ok(meni);
        }

    }
}