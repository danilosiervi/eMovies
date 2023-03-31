using eMovies.Data;
using eMovies.Data.Base;
using eMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Services.MoviesServices;

public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
{
    private readonly AppDbContext _context;
    public MoviesService(AppDbContext context)
        : base(context)
    {
        _context = context;
    }

    public async Task<Movie> GetMovieByIdAsync(int id)
    {
        var movie = await _context.Movies
            .Include(m => m.Cinema)
            .Include(m => m.Director)
            .Include(m => m.Actors).ThenInclude(am => am.Actor)
            .FirstOrDefaultAsync(m => m.Id == id);

        return movie;
    }
}
