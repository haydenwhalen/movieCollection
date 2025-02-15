using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using movieCollection.Models;

namespace movieCollection.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly MovieContext _context;
    
    // Single constructor accepting both dependencies
    public HomeController(ILogger<HomeController> logger, MovieContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GTKJoel()
    {
        return View();
    }
    
    [HttpGet] 
    public IActionResult movieForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult movieForm(Movie response)
    {
        _context.Movies.Add(response); // adds record to a database
        _context.SaveChanges(); // saves to database
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}