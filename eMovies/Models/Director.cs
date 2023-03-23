using eMovies.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eMovies.Models;

public class Director : IEntityBase
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
    [Required(ErrorMessage = "Biography is required")]
    public string Bio { get; set; }

    public ICollection<Movie>? Movies { get; set; }
}
