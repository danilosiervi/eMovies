using eMovies.Data.Base;
using eMovies.Models;

namespace eMovies.Services.MoviesServices;

public interface IMoviesService : IEntityBaseRepository<Movie>
{
}
