using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Jenson.Models;

namespace Mission06_Jenson.Controllers;

public class HomeController : Controller
{
    private MovieFormContext _context;
    
    public HomeController(MovieFormContext temp)
    {
        _context = temp;
    }
// main page
    public IActionResult Index()
    {
        return View();
    }

    //get to know joel hilton
    public IActionResult Get2Know()
    {
        return View();
    }
    // getting the movie form page
    [HttpGet]
    public IActionResult MovieForm()
    {
       ViewBag.Categories = _context.Categories.ToList();
        
        return View();
    }
// posting the addition to the movie list
    [HttpPost]
    public IActionResult MovieForm(Movie response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();
        return View("Confirmation", response);
    }
// getting our list of movies
    public IActionResult MovieList()
    {
        var count = _context.Movies.Count();
        ViewBag.Count = count;
       var movies = _context.Movies
           .Include(x => x.Category) 
           .ToList();
        return View(movies);
    }
    // get the edit screen (making sure that all the information shows up
[HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies
            .Single(x => x.MovieId == id);
        
        ViewBag.Categories = _context.Categories.ToList();
        return View("MovieForm", recordToEdit);
    }
// post the edit
    [HttpPost]
    public IActionResult Edit(Movie recordToEdit)
    {
        _context.Update(recordToEdit);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
// getting the delete form
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies
            .Single(x => x.MovieId == id);
        
        return View(recordToDelete);
    }

    // post the delete
    [HttpPost]
    public IActionResult Delete(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
        return RedirectToAction("MovieList");
    }
}