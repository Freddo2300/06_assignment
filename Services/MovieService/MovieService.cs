using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;






namespace WebAPI.Services.MovieService
{
    public class MovieService : IMovieService
    {
        private readonly WebApiDbContext _context;


        public MovieService(WebApiDbContext context)
        {
            _context = context;
        }

        public async Task<bool> MovieExists(int id)
        {
            return await _context.Movies.AnyAsync(m => m.Id == id);
        }

        public async Task<Movie> CreateMovie(Movie movie)
        {
            await _context.Movies.AddAsync(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie> DeleteMovie(int id)
        {
            if (!await MovieExists(id))
                throw new Exception("Movie not found");

            Movie movie = await GetMovie(id);

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<Movie> PutMovie(int id, Movie movie)
        {
            if (id != movie.Id)
            {
                throw new Exception("No movie found");
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await MovieExists(id))
                {
                    throw new Exception("No movie found, in db");
                }
                else
                {
                    throw;
                }
            }

            return movie; // This represents a 204 No Content response.
        }

        // public async Task<Movie> GetMovieById(int id)
        // {
        //     if (!await MovieExists(id))
        //     {
        //         throw new Exception(message: "No movie by that id");
        //     }

        //     Movie movie = await _context.Movies
        //         .Where(m => m.Id == id)
        //         .SingleOrDefaultAsync() ?? throw new Exception("Could not find movie");

        //     return movie;
        // }

        public async Task<Movie> GetMovie(int id)
        {
            var movie = await _context.Movies
                .Where(m => m.Id == id)
                .Include(m => m.Characters)
                .Include(m => m.Franchise)
                .SingleOrDefaultAsync();

            if (movie == null)
            {
                throw new Exception("No movie found with that id"); // Return 404 if no movie is found by that ID
            }

            return movie;
        }

        public async Task<IEnumerable<Movie>> GetMovies()
        {
            if (_context.Movies == null)
            {
                return null;
            }
            return await _context.Movies
            .Include(m => m.Characters)
            .Include(m => m.Franchise)
            .ToListAsync();
        }


        //public async Task<ActionResult<IEnumerable<Movie>>> GetMovieById()
        //{
        //  var movies = await _context.Movies.ToListAsync();
        //if (movies == null || !movies.Any())
        //  return new NotFoundResult();

        //return new OkObjectResult(movies);
        //}


        // public async Task<Movie> CreateMovie(Movie movie) // Abundant?
        // {
        //     await _context.Movies.AddAsync(movie);
        //     await _context.SaveChangesAsync();

        //     return movie;
        // }

        


        public async Task<Movie> PostMovie(Movie movie) // Same as CreateMovie?
        {
            if (_context.Movies == null)
            {
                throw new Exception("Entity set 'WebApiDbContext.Movies'  is null.");
            }
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public async Task<bool> UpdateMovie(Movie movie)
        {
            _context.Entry(movie).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
