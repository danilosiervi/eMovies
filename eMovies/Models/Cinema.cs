using eMovies.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace eMovies.Models;

public class Cinema : IEntityBase
{
    [Key]
    public int Id { get; set; }

    [Display(Name = "Cinema Name")]
    [Required(ErrorMessage = "Cinema name is required")]
    public string Name { get; set; }

    [Display(Name = "Cinema Logo")]
    [Required(ErrorMessage = "Logo is required")]
    public string Logo { get; set; }

    [Display(Name = "Cinema Description")]
    [Required(ErrorMessage = "Description is required")]
    public string Description { get; set; }

    public ICollection<Movie>? Movies { get; set; }
}
