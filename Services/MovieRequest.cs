using Microsoft.Extensions.Options;
using MovieDB.Models;

namespace MovieDB.Services;

public class MovieRequest : IMovieRequest
{
    // Create the repository pattern here
    private readonly HttpClient _httpClient;
    private readonly MovieDbApi _appSettings;

    private string header;
    
    public MovieRequest(HttpClient httpClient, IOptions<MovieDbApi> appsettings)
    {
        _httpClient = httpClient;
        _appSettings = appsettings.Value;
        header = appsettings.Value.Token;
    }
    
    
}
