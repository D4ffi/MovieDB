using System.Text.Json;
using Microsoft.Extensions.Options;
using MovieDB.Models;

namespace MovieDB.Services;

public class MovieRequest : IMovieRequest
{

    private readonly HttpClient _httpClient;
    private readonly MovieDbApi _appSettings;
    
    
    public MovieRequest(HttpClient httpClient, IOptions<MovieDbApi> appsettings)
    {
        _httpClient = httpClient;
        _appSettings = appsettings.Value;
        
    }

    public async Task<HttpResponseMessage> GetTrendingMovies()
    {
        var response = await _httpClient.GetAsync("movie/popular?language=en-US&page=1");
        return response;
    }

    public async Task<HttpResponseMessage> GetMovieDetail(int id)
    {
        var response = await _httpClient.GetAsync($"movie/{id}");
        return response;
    }

    public async Task GetUpcomingMovies()
    {
        var response = await _httpClient.GetAsync("movie/upcoming?language=en-US&page=1");
    }
    
}
