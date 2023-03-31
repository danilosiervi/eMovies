using eMovies.Models;
using eMovies.Services.MoviesServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eMovies.Controllers;

public class MoviesController : Controller
{
    private readonly IMoviesService _services;

    public MoviesController(IMoviesService services)
    {
        _services = services;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _services.GetAllAsync(m => m.Cinema);
        return View(data);
    }

    public async Task<IActionResult> Create()
    {
        var movieDropdownsData = await _services.GetNewMovieDropdownsValues();

        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Directors = new SelectList(movieDropdownsData.Directors, "Id", "Name");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "Name");

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(NewMovieVM movie)
    {
        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await _services.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Directors = new SelectList(movieDropdownsData.Directors, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "Name");

            return View(movie);
        }

        await _services.AddNewMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(int id)
    {
        var movie = await _services.GetMovieByIdAsync(id);

        if (movie == null) return View("NotFound");
        return View(movie);
    }
}
