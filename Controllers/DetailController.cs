using Microsoft.AspNetCore.Mvc;
using MovieDB.Models;
using MovieDB.Services;

namespace MovieDB.Controllers;

public class DetailController : Controller
{
    private readonly ILogger<DetailController> _logger;
    private readonly IMovieRequest _movieRequest;
    
    public DetailController(IMovieRequest movieRequest, ILogger<DetailController> logger)
    {
        _movieRequest = movieRequest;
        _logger = logger;
    }
    
    public async Task<IActionResult> Index(int id)
    {
        try
        {
            var response = await _movieRequest.GetMovieDetail(id);
            response.EnsureSuccessStatusCode();
            var movieDetail = await response.Content.ReadFromJsonAsync<MovieByIdResponse>();
            return View(movieDetail);
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error getting movie detail");
            return NotFound();
        }
        
    }
    
    public async Task<IActionResult> GetMovieDetail(int id)
    {
        try
        {
            var response = await _movieRequest.GetMovieDetail(id);
            response.EnsureSuccessStatusCode();
            var movieDetail = await response.Content.ReadFromJsonAsync<MovieByIdResponse>();
            return Json(movieDetail);
        }
        catch (HttpRequestException e)
        {
            _logger.LogError(e, "Error getting movie detail");
            return StatusCode(e.StatusCode!=null ? (int)e.StatusCode : 500, e.Message);
        }
    }
}