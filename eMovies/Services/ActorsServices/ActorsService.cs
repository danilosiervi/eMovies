using eMovies.Data;
using eMovies.Models;
using Microsoft.EntityFrameworkCore;

namespace eMovies.Services.ActorsServices;

public class ActorsService : IActorsService
{
    private readonly AppDbContext _context;

    public ActorsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Actor>> GetAll()
    {
        return await _context.Actors.ToListAsync();
    }

    public Actor GetById(int id)
    {

    }

    public void Add(Actor actor)
    {

    }

    public Actor Update(int id, Actor newActor)
    {

    }

    public void Delete(int id)
    {

    }
}
