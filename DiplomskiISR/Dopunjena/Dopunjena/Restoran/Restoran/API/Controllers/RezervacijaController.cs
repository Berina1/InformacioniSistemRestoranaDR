using Microsoft.AspNetCore.Mvc;
using Restoran.BLL.Interfaces;
using Restoran.DTO;

namespace Restoran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RezervacijaController : ControllerBase
    {
        private readonly IRezervacijaService _rezervacijaService;
        private readonly EmailService _emailService;
        public RezervacijaController(IRezervacijaService rezervacijaService, EmailService emailService)
        {
            _rezervacijaService = rezervacijaService;
            _emailService = emailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRezervacija()
        {
            var rezervacija = await _rezervacijaService.GetRezervacijaAsync();
            return Ok(rezervacija);
        }

        [HttpPost]
        public async Task<IActionResult> AddRezervacija([FromBody] RezervacijaDTO rezervacija)
        {
            if (rezervacija == null)
                return BadRequest("Nepostojeci podatak.");

            await _rezervacijaService.AddRezervacijaAsync(rezervacija);

            await _emailService.SendEmailAsync(
           rezervacija.Email,
           "Potvrda rezervacije",
           $"Postovani/a {rezervacija.RezervacijaID}, vasa rezervacija za datum: {rezervacija.VrijemeRezervacije} je uspjesno potvrdjena."
       );

            return Ok(rezervacija);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRezervacija(int id, [FromBody] RezervacijaDTO rezervacija)
        {
            if (rezervacija == null)
                return BadRequest("Nepostojeci podatak.");

            var updatedRezervacija = await _rezervacijaService.UpdateRezervacijaAsync(id, rezervacija);

            if (updatedRezervacija == null)
                return NotFound($"Rezervacija with ID {id} not found.");

            return Ok(updatedRezervacija);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteRezervacija(int id)
        {
            var isDeleted = await _rezervacijaService.DeleteRezervacijaAsync(id);

            if (!isDeleted)
            {
                return NotFound($"Rezervacija with ID {id} not found.");
            }
            return Ok($"Rezervacija with ID {id} deleted successfully.");
        }
    }
}