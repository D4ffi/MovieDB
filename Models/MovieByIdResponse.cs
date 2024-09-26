using System.Text.Json.Serialization;

namespace MovieDB.Models;

public class MovieByIdResponse
{
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    [JsonPropertyName("overview")]
    public required string Overview { get; set; }
    [JsonPropertyName("release_date")]
    public required string ReleaseDate { get; set; }
    [JsonPropertyName("poster_path")]
    public required string PosterPath { get; set; }
    [JsonPropertyName("vote_average")]
    public required double VoteAverage { get; set; }
    [JsonPropertyName("vote_count")]
    public required int VoteCount { get; set; }
}