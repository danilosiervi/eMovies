using eMovies.Data;
using eMovies.Models;
using eMovies.Services.CinemasServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eMovies.Controllers;

[Authorize = UserRoles.Admin]
public class CinemasController : Controller
{
    private readonly ICinemasService _service;

    public CinemasController(ICinemasService service)
    {
        _service = service;
    }

    [AllowAnonymous]
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
    public async Task<IActionResult> Create([Bind("Name,Logo,Description")] Cinema cinema)
    {
        if (!ModelState.IsValid)
        {
            return View(cinema);
        }

        await _service.AddAsync(cinema);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> Details(int id)
    {
        var cinema = await _service.GetByIdAsync(id);

        if (cinema == null) return View("NotFound");
        return View(cinema);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var cinema = await _service.GetByIdAsync(id);

        if (cinema == null) return View("NotFound");
        return View(cinema);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Cinema cinema)
    {
        if (!ModelState.IsValid)
        {
            return View(cinema);
        }

        await _service.UpdateAsync(id, cinema);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var cinema = await _service.GetByIdAsync(id);

        if (cinema == null) return View("NotFound");
        return View(cinema);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var cinema = await _service.GetByIdAsync(id);
        if (cinema == null) return View("NotFound");

        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
