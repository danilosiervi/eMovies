using System.ComponentModel.DataAnnotations;

namespace eMovies.Models;

public class Director
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Full Name")]
    public string Name { get; set; }
    [Display(Name = "Profile Picture")]
    public string ProfilePictureURL { get; set; }
    [Display(Name = "Biography")]
    public string Bio { get; set; }

    public ICollection<Movie> Movies { get; set; }
}
