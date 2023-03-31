using eMovies.Models;
using eMovies.Services.MoviesServices;
using Microsoft.AspNetCore.Mvc;

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

    public IActionResult Create()
    {
        return View();
    }

    public async Task<IActionResult> Details(int id)
    {
        var movie = await _services.GetMovieByIdAsync(id);

        if (movie == null) return View("NotFound");
        return View(movie);
    }
}
