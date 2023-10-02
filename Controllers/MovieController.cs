using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;
using WebAPI.Data.Entities;
using WebAPI.Data.DTO.MovieDTO;
using WebAPI.Services.MovieService;
using AutoMapper;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly WebApiDbContext _context;
        private IMovieService movieService;
        private readonly IMapper _mapper;
        public MovieController(WebApiDbContext context, IMapper mapper)
        {
            _context = context;
            movieService = new MovieService(_context);
            _mapper = mapper;
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDTO>>> GetMovies()
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            return Ok(
                _mapper.Map<IEnumerable<MovieDTO>>(
                    await movieService.GetMovies()
                ));
        }

        /// <summary>
        /// Get single movie by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            return Ok(
                _mapper.Map<MovieDTO>(
                    await movieService.GetMovie(id)
                ));
            // if (movie == null)
            // {
            //     return NotFound();
            // }

            // return movie;
        }

        /// <summary>
        /// Update a single movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MoviePutDTO movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            
            return Ok(
                await movieService.UpdateMovie(_mapper.Map<Movie>(movie))
            );

            // try
            // {
            //     await _context.SaveChangesAsync();
            // }
            // catch (DbUpdateConcurrencyException)
            // {
            //     if (!MovieExists(id))
            //     {
            //         return NotFound();
            //     }
            //     else
            //     {
            //         throw;
            //     }
            // }

            // return NoContent();
        }

        /// <summary>
        /// Create a new movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(MoviePostDTO movie)
        {
            if (_context.Movies == null)
            {
                return Problem("Entity set 'WebApiDbContext.Movies'  is null.");
            }
            return Ok(
                await movieService.PostMovie(_mapper.Map<Movie>(movie))
            );
            // _context.Movies.Add(movie);
            // await _context.SaveChangesAsync();

            // return CreatedAtAction("GetMovie", new { id = movie.Id }, movie);
        }

        /// <summary>
        /// Delete a movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (_context.Movies == null)
            {
                return NotFound();
            }
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();

            return Ok(true);
        }

        private bool MovieExists(int id)
        {
            return (_context.Movies?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
