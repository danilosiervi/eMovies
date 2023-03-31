using eMovies.Models;
using eMovies.Services.DirectorsServices;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace eMovies.Controllers;

public class DirectorsController : Controller
{
    private readonly IDirectorsService _service;

    public DirectorsController(IDirectorsService service)
    {
        _service = service;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _service.GetAllAsync();
        return View(data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([Bind("Name,ProfilePictureURL,Bio")] Director director)
    {
        if (!ModelState.IsValid)
        {
            return View(director);
        }

        await _service.AddAsync(director);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var director = await _service.GetByIdAsync(id);

        if (director == null) return View("NotFound");
        return View(director);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var director = await _service.GetByIdAsync(id);

        if (director == null) return View("NotFound");
        return View(director);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Director director)
    {
        if (!ModelState.IsValid)
        {
            return View(director);
        }

        await _service.UpdateAsync(id, director);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var director = await _service.GetByIdAsync(id);

        if (director == null) return View("NotFound");
        return View(director);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var director = await _service.GetByIdAsync(id);
        if (director == null) return View("NotFound");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
