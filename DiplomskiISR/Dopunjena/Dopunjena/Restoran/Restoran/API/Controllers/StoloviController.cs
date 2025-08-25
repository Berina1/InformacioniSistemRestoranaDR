using Microsoft.AspNetCore.Mvc;
using Restoran.BLL.Interfaces;
using Restoran.DTO;

namespace Restoran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoloviController : ControllerBase
    {
        private readonly IStoloviService _stoloviService;
        public StoloviController(IStoloviService stoloviService)
        {
            _stoloviService = stoloviService;
        }

        [HttpGet]
        public async Task<IActionResult> GetStolovi()
        {
            var stolovi = await _stoloviService.GetStoloviAsync();
            return Ok(stolovi);
        }
    }
}