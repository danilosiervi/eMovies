using System.ComponentModel.DataAnnotations;

namespace eMovies.Models;

public class Actor
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public string ProfilePictureURL { get; set; }
    public string Bio { get; set; }

    public ICollection<ActorMovie> Movies { get; set; }
}
