using eMovies.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Controllers;

public class DirectorsController : Controller
{
    private readonly AppDbContext _context;

    public DirectorsController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var data = await _context.Directors.ToListAsync();
        return View(data);
    }
}
