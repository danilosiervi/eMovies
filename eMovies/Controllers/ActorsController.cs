using eMovies.Models;
using eMovies.Services.ActorsServices;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace eMovies.Controllers;

public class ActorsController : Controller
{
    private readonly IActorsService _service;

    public ActorsController(IActorsService service)
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
    public async Task<IActionResult> Create([Bind("Name,ProfilePictureURL,Bio")] Actor actor)
    {
        if (!ModelState.IsValid)
        {
            return View(actor);
        }

        await _service.AddAsync(actor);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var actor = await _service.GetByIdAsync(id);

        if (actor == null) return View("NotFound");
        return View(actor);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var actor = await _service.GetByIdAsync(id);

        if (actor == null) return View("NotFound");
        return View(actor);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Actor actor)
    {
        if (!ModelState.IsValid)
        {
            return View(actor);
        }

        await _service.UpdateAsync(id, actor);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var actor = await _service.GetByIdAsync(id);

        if (actor == null) return View("NotFound");
        return View(actor);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var actor = await _service.GetByIdAsync(id);
        if (actor == null) return View("NotFound");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
