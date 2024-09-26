namespace MovieDB.Services;

public interface IMovieRequest
{
    // Interface for recovering the movie data
    Task<HttpResponseMessage> GetTrendingMovies();
    Task<HttpResponseMessage> GetMovieDetail(int id);
    Task GetUpcomingMovies();
    
}