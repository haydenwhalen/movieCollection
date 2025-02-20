using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movieCollection.Models;

namespace movieCollection.Controllers;

public class HomeController : Controller
{
    private MovieContext _context;
    
    // Single constructor accepting both dependencies
    public HomeController(MovieContext context)
    {
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

    public IActionResult Collection()
    {
        // Get all movies from the database as a list without including a scalar property.
        var movies = _context.Movies.Include(x=>x.Category).ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int wallace)
    {
        var editedRecord = _context.Movies.Single(x => x.MovieId == wallace);
        return View("movieForm", editedRecord);
    }

    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Update(updatedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("Collection");
    }
}