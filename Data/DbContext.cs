using Microsoft.EntityFrameworkCore;

using WebAPI.Data.Entities;

namespace WebAPI.Data
{
    public class WebApiDbContext : DbContext
    {
        public IConfiguration Config { get; set; }
        public WebApiDbContext(IConfiguration config)
        {
            Config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                Config["ConnectionString"]
            );
        }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(
                new Character() { Id = 1, FullName = "Frederik Strøm Friborg", Alias = "Freddono" },
                new Character() { Id = 2, FullName = "Marc Pedersen", Alias = "Marc P" },
                new Character() { Id = 3, FullName = "Mansour Hamidi", Alias = "Manzucker" },
                new Character() { Id = 4, FullName = "Mansour", Alias = "dinfar" }
            );

            modelBuilder.Entity<Franchise>().HasData(
                new Franchise() { Id = 1, Name = "Lord of the Rings", Description = "Movies about dwarfs and elfs" },
                new Franchise() { Id = 2, Name = "Star Wars", Description = "Movies about space chips and jedis" },
                new Franchise() { Id = 3, Name = "Monsters Inc", Description = "Movies about monsters" }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie() { Id = 1, Title = "Lord of the Rings: The Fellowship of the Ring", ReleaseYear = 2001, Director = "Peter Jackson" },
                new Movie() { Id = 2, Title = "Star Wars: A New Hope", ReleaseYear = 1977, Director = "George Lucas" }
            );

            modelBuilder.Entity<Movie>()
                .HasMany(std => std.Characters)
                .WithMany(sub => sub.Movies)
                .UsingEntity<Dictionary<string, object>>(
                    "CharacterMovie",
                    l => l.HasOne<Character>().WithMany().HasForeignKey("CharacterId"),
                    r => r.HasOne<Movie>().WithMany().HasForeignKey("MovieId"),
                    je =>
                    {
                        je.HasKey("CharacterId", "MovieId");
                        je.HasData(
                            new { CharacterId = 1, MovieId = 1 },
                            new { CharacterId = 1, MovieId = 2 },
                            new { CharacterId = 2, MovieId = 2 },
                            new { CharacterId = 2, MovieId = 1 },
                            new { CharacterId = 3, MovieId = 2 },
                            new { CharacterId = 3, MovieId = 1 },
                            new { CharacterId = 4, MovieId = 2 },
                            new { CharacterId = 4, MovieId = 1 }
                        );
                    }
                );
        }
    }
}