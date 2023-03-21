using eMovies.Models;

namespace eMovies.Services.ActorsServices;

public interface IActorsService
{
    Task<IEnumerable<Actor>> GetAllAsync();
    Task<Actor> GetByIdAsync(int id);
    Task AddAsync(Actor actor);
    //Actor Update(int id, Actor newActor);
    //void Delete(int id);
}
