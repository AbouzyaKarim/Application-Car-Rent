using Microsoft.EntityFrameworkCore;
using Rent.Service.VoitureAPI.Models;

namespace Rent.Service.VoitureAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Voiture> Voitures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Voiture>().HasData(new Voiture
            {
                VoitureId = 1,
                marque = "Peugeot 208",
                PriceByDay = 540,
                CategoryName = "Citadine",
                ImageURL = "https://artisanaka.blob.core.windows.net/artisana/v3.png"
            });
            modelBuilder.Entity<Voiture>().HasData(new Voiture
            {
                VoitureId = 2,
                marque = "Dacia Sandero",
                PriceByDay = 400,
                CategoryName = "Citadine",
                ImageURL = "https://artisanaka.blob.core.windows.net/artisana/v2.png"
            });
            modelBuilder.Entity<Voiture>().HasData(new Voiture
            {
                VoitureId = 3,
                marque = "Renault Clio 4",
                PriceByDay = 650,
                CategoryName = "Citadine",
                ImageURL = "https://artisanaka.blob.core.windows.net/artisana/v1.png"
            });
            modelBuilder.Entity<Voiture>().HasData(new Voiture
            {
                VoitureId = 4,
                marque = "Citroën C3",
                PriceByDay = 450,
                CategoryName = "Citadine",
                ImageURL = "https://artisanaka.blob.core.windows.net/artisana/v4.png"
            });
        }
    }
}
