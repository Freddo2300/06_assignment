using Microsoft.AspNetCore.Mvc;

using WebAPI.Data.Entities;

namespace WebAPI.Services.MovieService
{
    public interface IMovieService
    {
        // Create
        Task<Movie> CreateMovie(Movie movie);

        Task<Movie> PostMovie(Movie movie);

        Task<IEnumerable<Movie>> GetMovies();

        Task<Movie> PutMovie(int id, Movie movie);

        // Read
        // Task<ICollection<Movie>> GetMovie();
        Task<Movie> GetMovie(int id);

        Task<Movie> DeleteMovie(int id);

        // Update
        Task UpdateMovie(Movie movie);

        // Delete
    }
}