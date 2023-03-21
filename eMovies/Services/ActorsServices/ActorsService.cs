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
        var actor = await _context.Actors
            .FirstOrDefaultAsync(x => x.Id == id);

        return actor;
    }

    public async Task AddAsync(Actor actor)
    {
        await _context.Actors.AddAsync(actor);
        await _context.SaveChangesAsync();
    }

    public async Task<Actor> UpdateAsync(int id, Actor newActor)
    {
        _context.Update(newActor);
        await _context.SaveChangesAsync();

        return newActor;
    }

    public async Task DeleteAsync(int id)
    {
        var actor = await _context.Actors
            .FirstOrDefaultAsync(x => x.Id == id);

        _context.Actors.Remove(actor);
        await _context.SaveChangesAsync();
    }
}
