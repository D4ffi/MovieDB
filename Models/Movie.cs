using System.Text.Json.Serialization;

namespace MovieDB.Services;

public class Movie
{
    [JsonPropertyName("adult")]
    public required bool Adult { get; set; }
    [JsonPropertyName("backdrop_path")]
    public required string BackdropPath { get; set; }
    [JsonPropertyName("id")]
    public required int Id { get; set; }
    [JsonPropertyName("original_language")]
    public required string OriginalLanguage { get; set; }
    [JsonPropertyName("original_title")]
    public required string OriginalTitle { get; set; }
    [JsonPropertyName("overview")]
    public required string Overview { get; set; }
    [JsonPropertyName("popularity")]
    public required double Popularity { get; set; }
    [JsonPropertyName("poster_path")]
    public required string PosterPath { get; set; }
    [JsonPropertyName("release_date")]
    public required string ReleaseDate { get; set; }
    [JsonPropertyName("title")]
    public required string Title { get; set; }
    [JsonPropertyName("video")]
    public required bool Video { get; set; }
    [JsonPropertyName("vote_average")]
    public required double VoteAverage { get; set; }
    [JsonPropertyName("vote_count")]
    public required int VoteCount { get; set; }
    
    [JsonPropertyName("genre_ids")]
    public required List<int> GenreIds { get; set; }
    
}