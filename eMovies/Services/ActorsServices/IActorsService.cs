using eMovies.Models;

namespace eMovies.Services.ActorsServices;

public interface IActorsService
{
    Task<IEnumerable<Actor>> GetAll();
    Actor GetById(int id);
    void Add(Actor actor);
    Actor Update(int id, Actor newActor);
    void Delete(int id);
}
