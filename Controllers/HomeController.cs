using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MovieDB.Models;

namespace MovieDB.Controllers;

public class HomeController : Controller
{
    private readonly MovieDbApi _appSettings;
    private readonly ILogger<HomeController> _logger;

    public HomeController(IOptions<MovieDbApi> appSettings, ILogger<HomeController> logger)
    {
        _appSettings = appSettings.Value;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var apiKey = _appSettings.ApiKey;
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
}
