namespace MovieDB.Services;

public interface IMovieRequest
{
    // Interface for recovering the movie data
    Task<HttpResponseMessage> GetTrendingMovies();
    Task<List<Movie>> GetTrendingMoviesAsList();
    Task GetUpcomingMovies();
    
}