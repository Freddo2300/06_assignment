using WebAPI.Data.Entities;

namespace WebAPI.Services.MovieService
{
    public interface IMovieService
    {
        // Create
        Task CreateMovie(Movie movie);

        // Read
        Task<ICollection<Movie>> GetMovie();

        Task<Movie> GetMovieById(int id);

        // Update
        Task UpdateMovie(Movie movie);

        // Delete
        Task DeleteMovie(int id);
    }
}