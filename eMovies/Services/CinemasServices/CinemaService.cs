using eMovies.Data;
using eMovies.Data.Base;
using eMovies.Models;

namespace eMovies.Services.CinemasServices;

public class CinemaService : EntityBaseRepository<Cinema>, ICinemasService
{
    public CinemaService(AppDbContext context)
        : base(context)
    {
    }
}
