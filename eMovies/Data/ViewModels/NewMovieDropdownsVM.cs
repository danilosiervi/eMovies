using eMovies.Models;

namespace eMovies.Data.ViewModels;

public class NewMovieDropdownsVM
{
    public NewMovieDropdownsVM()
    {
        Directors = new List<Director>();
        Cinemas = new List<Cinema>();
        Actors = new List<Actor>();
    }

    public List<Director> Directors { get; set; }
    public List<Cinema> Cinemas { get; set; }
    public List<Actor> Actors { get; set; }
}
