using eMovies.Data;
using eMovies.Data.Base;
using eMovies.Models;

namespace eMovies.Services.ActorsServices;

public class ActorsService : EntityBaseRepository<Actor>, IActorsService
{
    public ActorsService(AppDbContext context)
        : base(context)
    {
    }
}
