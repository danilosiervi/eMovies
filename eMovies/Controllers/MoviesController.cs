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

    public async Task<IActionResult> Filter(string searchString)
    {
        var allMovies = await _services.GetAllAsync(m => m.Cinema, m => m.Director, m => m.Actors);

        if (!string.IsNullOrEmpty(searchString))
        {
            var normalizedSearchString = searchString.ToLower();

            var filteredResult = allMovies
                .Where(m => m.Name.ToLower().Contains(normalizedSearchString) ||
                m.Description.ToLower().Contains(normalizedSearchString) ||
                m.Director.Name.ToLower().Contains(normalizedSearchString) ||
                m.Cinema.Name.ToLower().Contains(normalizedSearchString)
                ).ToList();

            return View("Index", filteredResult);
        }

        return View("Index", allMovies);
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

    public async Task<IActionResult> Edit(int id)
    {
        var movie = await _services.GetMovieByIdAsync(id);
        if (movie == null) return View("NotFound");

        var response = new NewMovieVM()
        {
            Id = movie.Id,
            Name = movie.Name,
            Description = movie.Description,
            Price = movie.Price,
            StartDate = movie.StartDate,
            EndDate = movie.EndDate,
            ImageURL = movie.ImageURL,
            Category = movie.Category,
            CinemaId = movie.CinemaId,
            DirectorId = movie.DirectorId,
            ActorsIds = movie.Actors.Select(a => a.ActorId).ToList()
        };

        var movieDropdownsData = await _services.GetNewMovieDropdownsValues();

        ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
        ViewBag.Directors = new SelectList(movieDropdownsData.Directors, "Id", "Name");
        ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "Name");

        return View(response);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, NewMovieVM movie)
    {
        if (id != movie.Id) return View("NotFound");

        if (!ModelState.IsValid)
        {
            var movieDropdownsData = await _services.GetNewMovieDropdownsValues();

            ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
            ViewBag.Directors = new SelectList(movieDropdownsData.Directors, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "Name");

            return View(movie);
        }

        await _services.UpdateMovieAsync(movie);
        return RedirectToAction(nameof(Index));
    }
}
