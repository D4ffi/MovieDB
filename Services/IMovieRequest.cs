namespace MovieDB.Services;

public interface IMovieRequest
{
    // Interface for recovering the movie data
    
    Task<Movie> GetMovieAsync(int movieId);
    Task<HttpResponseMessage> GetTrendingMovies();
    Task GetUpcomingMovies();
    
}