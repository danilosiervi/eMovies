using eMovies.Data;
using eMovies.Data.Base;
using eMovies.Models;

namespace eMovies.Services.MoviesServices;

public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
{
    public MoviesService(AppDbContext context)
        : base(context)
    {
    }
}
