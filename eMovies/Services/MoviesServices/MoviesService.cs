using eMovies.Data;
using eMovies.Data.Base;
using eMovies.Data.ViewModels;
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

    public async Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues()
    {
        var response = new NewMovieDropdownsVM()
        {
            Actors = await _context.Actors.OrderBy(a => a.Name).ToListAsync(),
            Cinemas = await _context.Cinemas.OrderBy(a => a.Name).ToListAsync(),
            Directors = await _context.Directors.OrderBy(a => a.Name).ToListAsync()
        };

        return response;
    }

    public async Task AddNewMovieAsync(NewMovieVM movie)
    {
        var newMovie = new Movie()
        {
            Name = movie.Name,
            Description = movie.Description,
            Price = movie.Price,
            ImageURL = movie.ImageURL,
            StartDate = movie.StartDate,
            EndDate = movie.EndDate,
            Category = movie.Category,
            CinemaId = movie.CinemaId,
            DirectorId = movie.DirectorId
        };

        await _context.Movies.AddAsync(newMovie);
        await _context.SaveChangesAsync();

        foreach(var actorId in movie.ActorsIds)
        {
            var newActorMovie = new ActorMovie()
            {
                MovieId = newMovie.Id,
                ActorId = actorId
            };

            await _context.Actors_Movies.AddAsync(newActorMovie);
            await _context.SaveChangesAsync();
        }
    }
}
