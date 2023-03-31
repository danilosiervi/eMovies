using eMovies.Data.Base;
using eMovies.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace eMovies.Models;

public class NewMovieVM
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Description = "Movie Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Description is required")]
    [Display(Description = "Movie Description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Display(Description = "Price in R$")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Movie Poster URL is required")]
    [Display(Description = "Movie Poster URL")]
    public string ImageURL { get; set; }

    [Required(ErrorMessage = "Start is required")]
    [Display(Description = "Movie Start Date")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End Date is required")]
    [Display(Description = "Movie End Date")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Category is required")]
    [Display(Description = "Select a Category")]
    public MovieCategory Category { get; set; }

    [Required(ErrorMessage = "Movie actor(s) is required")]
    [Display(Description = "Select Actors")]
    public ICollection<int> ActorsIds { get; set; }

    [Required(ErrorMessage = "Movie cinema is required")]
    [Display(Description = "Select a Cinema")]
    public int CinemaId { get; set; }

    [Required(ErrorMessage = "Movie director is required")]
    [Display(Description = "Select a Director")]
    public int DirectorId { get; set; }
}
