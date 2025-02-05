using BlazorFilm.Components.Services;
using BlazorFilm.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BlazorMovieApp.Services
{
    public class MovieService : IMovieService
    {
        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<Movie>>("api/movies");
        }

        public async Task<Movie> GetMovieById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Movie>($"api/movies/{id}");
        }

        public async Task<Movie> AddMovie(Movie movie)
        {
            var response = await _httpClient.PostAsJsonAsync("api/movies", movie);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Movie>();
        }

        public async Task<Movie> UpdateMovie(int id, Movie updatedMovie)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/movies/{id}", updatedMovie);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Movie>();
        }

        public async Task DeleteMovie(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/movies/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
