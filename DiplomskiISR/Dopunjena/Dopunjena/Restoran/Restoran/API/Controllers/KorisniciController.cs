using Microsoft.AspNetCore.Mvc;
using Restoran.BLL.Interfaces;
using Restoran.DTO;
using Restoran.Models;

namespace Restoran.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class KorisniciController : ControllerBase
    {
        private readonly IKorisniciService _korisniciService;
        private readonly IConfiguration _configuration;

        public KorisniciController(IKorisniciService korisniciService, IConfiguration configuration)
        {
            _korisniciService = korisniciService;
            _configuration = configuration;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetKorisniciById(int id)
        {
            var korisnici = await _korisniciService.GetKorisniciByIdAsync(id);

            if (korisnici == null)
                return NotFound($"Korisnik with ID {id} not found.");

            return Ok(korisnici);
        }
        [HttpPost("prijava")]
        public IActionResult Prijava([FromBody] PrijavaDTO prijava)
        {
            var token = _korisniciService.Autentifikuj(prijava);
            if (token == null)
                return Unauthorized(new { message ="Pogresno korisnicko ime ili sifra" });

            return Ok(new { token });
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody] Korisnici korisnici)
        {
            _korisniciService.RegistrujKorisnika(korisnici);
            return Ok(new { message = "Korisnik je uspjesno registrovan" });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var korisnik = await _korisniciService.LoginAsync(loginDTO.Email, loginDTO.Lozinka);

            if (korisnik == null)
                return Unauthorized("Netačan email ili šifra3.");

            return Ok(korisnik);
        }

        [HttpPost("logout")]
        public IActionResult Odjava()
        {
            return Ok(new { message = "Korisnik je uspješno odjavljen" });
        }

        // DTO for login requests
        public class LoginDTO
        {
            public string Email { get; set; }
            public string Lozinka { get; set; }
        }

    }
}