using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Restoran.BLL.Interfaces;
using Restoran.DAL.Interfaces;
using Restoran.DAL.Repositories;
using Restoran.DTO;
using Restoran.Models;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Concurrent;

namespace Restoran.BLL.Services
{
    public class KorisniciService : IKorisniciService
    {
        private readonly IKorisniciRepository _korisniciRepository;
        private readonly IConfiguration _configuration;
        private static readonly ConcurrentDictionary<string, bool> BlacklistedTokens = new();

        public KorisniciService(IKorisniciRepository korisniciRepository, IConfiguration configuration)
        {
            _korisniciRepository = korisniciRepository;
            _configuration = configuration;
        }
        public string Autentifikuj(PrijavaDTO prijava)
        {
            var korisnik = _korisniciRepository.GetByKorisnickoIme(prijava.KorisnickoIme);
            //dodati u if ako lozinka nije dobra
            if (korisnik==null)
            {
                return null;
            }
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, korisnik.KorisnickoIme),
                new Claim(ClaimTypes.Role, korisnik.Uloga)
            };
            var kljuc = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecretKey"]));
            var credentials = new SigningCredentials(kljuc, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["JwtSettings:Issuer"],
                _configuration["JwtSettings:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JwtSettings:ExpiryMinutes"])),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public void RegistrujKorisnika(Korisnici korisnici)
        {
            korisnici.Lozinka = (korisnici.Lozinka);
            _korisniciRepository.DodajKorisnika(korisnici);
        }

        public void OdjaviKorisnika(string token)
        {
            BlacklistedTokens.TryAdd(token, true);
        }

        public async Task<KorisniciDTO> GetKorisniciByIdAsync(int id)
        {
            var korisnici = await _korisniciRepository.GetKorisniciByIdAsync(id);

            if (korisnici == null)
                return null;

            return new KorisniciDTO
            {
                KorisnikID = korisnici.KorisnikID,
                ImePrezime = korisnici.ImePrezime,
                Uloga = korisnici.Uloga,
                Smjena = korisnici.Smjena,
                KorisnickoIme = korisnici.KorisnickoIme,
                Lozinka = korisnici.Lozinka,
                Email = korisnici.Email
            };
        }
        public async Task<KorisniciDTO> LoginAsync(string email, string password)
        {
            var korisnik = await _korisniciRepository.GetKorisnikByEmailAndPasswordAsync(email, password);

            if (korisnik == null)
                return null;

            return new KorisniciDTO
            {
                KorisnikID = korisnik.KorisnikID,
                ImePrezime = korisnik.ImePrezime,
                Uloga = korisnik.Uloga,
                Smjena = korisnik.Smjena,
                KorisnickoIme = korisnik.KorisnickoIme,
                Email = korisnik.Email,
                Lozinka = korisnik.Lozinka // Avoid sending passwords in the DTO
            };
        }
    }
}

