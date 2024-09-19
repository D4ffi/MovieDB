using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieDB.Models;
using MovieDB.Services;

namespace MovieDB.Controllers;

public class HomeController : Controller
{
    private readonly MovieDbApi _appSettings;
    private readonly ILogger<HomeController> _logger;
    private readonly IMovieRequest _movieRequest;

    public HomeController(IOptions<MovieDbApi> appSettings, ILogger<HomeController> logger, IMovieRequest movieRequest)
    {
        _appSettings = appSettings.Value;
        _logger = logger;
        _movieRequest = movieRequest;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public async Task<IActionResult> GetTrendingMovies()
    {
        try
        {
            var response = await _movieRequest.GetTrendingMovies();
            response.EnsureSuccessStatusCode();
            var moviesResponse = await response.Content.ReadFromJsonAsync<MovieResponse>();
            return Json(moviesResponse);
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error getting trending movies");
            return StatusCode(e.StatusCode!=null ? (int)e.StatusCode : 500, e.Message);
        }
        
    }
}
