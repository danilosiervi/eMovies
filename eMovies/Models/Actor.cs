using System.ComponentModel.DataAnnotations;

namespace eMovies.Models;

public class Actor
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Full Name")]
    [Required(ErrorMessage = "Full Name is required")]
    public string Name { get; set; }

    [Display(Name = "Profile Picture")]
    [Required(ErrorMessage = "Profile Picture is required")]
    public string ProfilePictureURL { get; set; }

    [Display(Name = "Biography")]
    public string Bio { get; set; }

    public ICollection<ActorMovie> Movies { get; set; }
}
