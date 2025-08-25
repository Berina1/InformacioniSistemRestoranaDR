using Microsoft.EntityFrameworkCore;
using Restoran.Models;

namespace Restoran.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Meni> Meni { get; set; }
        public DbSet<Narudzba> Narudzbe { get; set; }
        public DbSet<DetaljiNarudzbe> DetaljiNarudzbe { get; set; }
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<Racun> Racuni { get; set; }
        public DbSet<Stolovi> Stolovi { get; set; }
        public DbSet<Korisnici> Korisnici { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetaljiNarudzbe>()
                .HasKey(d => d.DetaljID);  

            modelBuilder.Entity<DetaljiNarudzbe>()
                .Property(d => d.DetaljID)
                .ValueGeneratedOnAdd(); 

            base.OnModelCreating(modelBuilder);
        }
    }
}