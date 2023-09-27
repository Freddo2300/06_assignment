using System;
using Microsoft.EntityFrameworkCore;

using WebAPI.Models;

namespace WebAPI
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
        
    }
}