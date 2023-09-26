using System;
using Microsoft.EntityFrameworkCore;

namespace _06_assignment
{
	public class AppDbContext : DbContext
	{
        /// <summary>
        /// Initializes a new instance of the <see cref="AppDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        /// <remarks>
        /// The <paramref name="options"/> provides configuration settings for the database context. This includes details 
        /// such as the connection string and the database provider to use. By passing these options to the base 
        /// <see cref="DbContext"/> constructor using <c>base(options)</c>, we ensure that our context is properly 
        /// configured based on the provided settings. This design supports dependency injection in ASP.NET Core, 
        /// allowing the context to be configured at startup and then injected into other services as needed.
        /// </remarks>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Franchise> Franchises { get; set; }

        /// <summary>
        /// Provides further configuration for the models that were discovered by convention from the entity classes.
        /// </summary>
        /// <param name="modelBuilder">An API for configuring the discovered model.</param>
        /// <remarks>
        /// This method allows detailed configuration of the model, such as specifying relationships, 
        /// configuring properties, setting primary keys, indexes, and more. 
        /// Any configuration here will be applied on top of what was discovered by convention.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many-to-many relationship between Movie and Character
            m// Configuring the MovieCharacter table in the database
modelBuilder.Entity<MovieCharacter>()
    // Setting a composite primary key using both MovieId and CharacterId. 
    // This means that the combination of MovieId and CharacterId must be unique for each row.
    .HasKey(mc => new { mc.MovieId, mc.CharacterId }); // Composite Key

            // Setting up the relationship between the MovieCharacter and Movie tables/entities
            modelBuilder.Entity<MovieCharacter>()
                // Each MovieCharacter entry is associated with one Movie.
                .HasOne(mc => mc.Movie)
                // One Movie can be associated with multiple MovieCharacter entries, 
                // indicating that a movie can have multiple characters.
                .WithMany(m => m.Characters)
                // The foreign key for this relationship on the MovieCharacter table is MovieId. 
                // This means that the MovieId column in the MovieCharacter table points to the Id in the Movie table.
                .HasForeignKey(mc => mc.MovieId);

            // Setting up the relationship between the MovieCharacter and Character tables/entities
            modelBuilder.Entity<MovieCharacter>()
                // Each MovieCharacter entry is associated with one Character.
                .HasOne(mc => mc.Character)
                // One Character can be associated with multiple MovieCharacter entries, 
                // indicating that a character can appear in multiple movies.
                .WithMany(c => c.Movies)
                // The foreign key for this relationship on the MovieCharacter table is CharacterId. 
                // This means that the CharacterId column in the MovieCharacter table points to the Id in the Character table.
                .HasForeignKey(mc => mc.CharacterId);

        }

    }

public class MovieCharacter
    {
        public int MovieId { get; set; }
        public Model.Movie Movie { get; set; } // Navigation property to Movie

        public int CharacterId { get; set; }
        public Model.Character Character { get; set; } // Navigation property to Character

    }
}

