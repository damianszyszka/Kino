using Microsoft.EntityFrameworkCore;
using System;

namespace KinoSystemRezerwacji.Models
{
    public class CinemaContext : DbContext
    {
        public CinemaContext(DbContextOptions<CinemaContext> options) : base(options)
        {
        }

        public DbSet<Film> Filmy { get; set; }
        public DbSet<Seans> Seanse { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Przykładowe dane filmów
            modelBuilder.Entity<Film>().HasData(
                new Film { Id = 1, Tytul = "Niezłomny", Opis = "Dramat wojenny...", CzasTrwania = 137 },
                new Film { Id = 2, Tytul = "Gwiezdne Wojny: Ostatni Jedi", Opis = "Kolejna epicka część...", CzasTrwania = 152 },
                new Film { Id = 3, Tytul = "Incepcja", Opis = "Thriller science-fiction...", CzasTrwania = 148 },
                new Film { Id = 4, Tytul = "La La Land", Opis = "Muzyczny romans...", CzasTrwania = 128 },
                new Film { Id = 5, Tytul = "Interstellar", Opis = "Film science-fiction...", CzasTrwania = 169 },
                new Film { Id = 6, Tytul = "Gladiator", Opis = "Epicki film...", CzasTrwania = 155 }
            );

            // Tworzenie jednego seansu dla każdego filmu o godzinie 18:00
            var dataSeansu = DateTime.Today.AddHours(18);
            for (int filmId = 1; filmId <= 6; filmId++)
            {
                modelBuilder.Entity<Seans>().HasData(
                    new Seans { Id = filmId, FilmId = filmId, DataSeansu = dataSeansu }
                );
            }

        }

    }
}
