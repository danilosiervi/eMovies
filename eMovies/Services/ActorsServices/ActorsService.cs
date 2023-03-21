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

    public async Task<IEnumerable<Actor>> GetAllAsync()
    {
        return await _context.Actors.ToListAsync();
    }

    public async Task<Actor> GetByIdAsync(int id)
    {
        var result = await _context.Actors
            .FirstOrDefaultAsync(x => x.Id == id);

        return result;
    }

    public async Task AddAsync(Actor actor)
    {
        await _context.Actors.AddAsync(actor);
        await _context.SaveChangesAsync();
    }

    //public Actor Update(int id, Actor newActor)
    //{

    //}

    //public void Delete(int id)
    //{

    //}
}
