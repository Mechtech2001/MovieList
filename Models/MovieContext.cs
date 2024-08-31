using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;

namespace MovieList.Models
{
    public class MovieContext : DbContext
    {
        //sets db options
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }
        //creates movie dbset
        public DbSet<Movie> Movies { get; set; } = null;
        public DbSet<Genre> Genres { get; set; } = null;

        

        //method to create data set on creation on the table
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Genre>().HasData(
               new Genre { GenreId = "A", Name = "Action" },
               new Genre { GenreId = "C", Name = "Comedy" },
               new Genre { GenreId = "D", Name = "Drama" },
               new Genre { GenreId = "H", Name = "Horro" },
               new Genre { GenreId = "M", Name = "Muscial" },
               new Genre { GenreId = "R", Name = "RomCom" },
               new Genre { GenreId = "S", Name = "SciFi" }
               );

            modelBuilder.Entity<Movie>().HasData(
                new Movie
                {
                    MovieId = 1,
                    Name = "Casablanca",
                    Year = 1942,
                    Rating = 5,
                    GenreId = "D"
                },
                new Movie
                {
                    MovieId = 2,
                    Name = "Wonder Woman",
                    Year = 2017,
                    Rating = 3,
                    GenreId = "A"
                },
                new Movie
                {
                    MovieId = 3,
                    Name = "Moonstruck",
                    Year = 1988,
                    Rating = 4,
                    GenreId = "R"
                }

                );
           
        }
    }
}
