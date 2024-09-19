using System.Text.Json.Serialization;
using MovieDB.Services;

namespace MovieDB.Models;

public class MovieResponse
{
    [JsonPropertyName("page")]
    public required int Page { get; set; } // investigar anotaciones
    [JsonPropertyName("total_results")]
    public required int TotalResults { get; set; }
    [JsonPropertyName("total_pages")]
    public required int TotalPages { get; set; }
    
    [JsonPropertyName("results")]
    public required List<Movie> Results { get; set; }
}