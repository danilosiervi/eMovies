using eMovies.Data;
using eMovies.Data.Base;
using eMovies.Models;

namespace eMovies.Services.DirectorsServices;

public class DirectorsService : EntityBaseRepository<Director>, IDirectorsService
{
    public DirectorsService(AppDbContext context)
        : base(context)
    {
    }
}
