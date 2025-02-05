using BlazorFilm.Components.Services;
using BlazorFilm.Models;

namespace BlazorFilm.Components.Services
{

    public interface IMovieService
        {
            Task<IEnumerable<Movie>> GetAllMovies();
            Task<Movie> GetMovieById(int id);
            Task<Movie> AddMovie(Movie movie);
            Task<Movie> UpdateMovie(int id, Movie updatedMovie);
            Task DeleteMovie(int id);
        }
    
}
