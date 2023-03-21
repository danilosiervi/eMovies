using eMovies.Models;

namespace eMovies.Services.ActorsServices;

public interface IActorsService
{
    Task<IEnumerable<Actor>> GetAllAsync();
    Task<Actor> GetByIdAsync(int id);
    Task AddAsync(Actor actor);
    Task<Actor> UpdateAsync(int id, Actor newActor);
    Task DeleteAsync(int id);
}
