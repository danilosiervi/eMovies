using eMovies.Data.Base;
using eMovies.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace eMovies.Models;

public class NewMovieVM
{
    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Movie Name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [Display(Name = "Movie Description")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Price is required")]
    [Display(Name = "Price in R$")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Movie Poster URL is required")]
    [Display(Name = "Movie Poster URL")]
    public string ImageURL { get; set; }

    [Required(ErrorMessage = "Start is required")]
    [Display(Name = "Movie Start Date")]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessage = "End Date is required")]
    [Display(Name = "Movie End Date")]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessage = "Category is required")]
    [Display(Name = "Select a Category")]
    public MovieCategory Category { get; set; }

    [Required(ErrorMessage = "Movie actor(s) is required")]
    [Display(Name = "Select Actors")]
    public ICollection<int> ActorsIds { get; set; }

    [Required(ErrorMessage = "Movie cinema is required")]
    [Display(Name = "Select a Cinema")]
    public int CinemaId { get; set; }

    [Required(ErrorMessage = "Movie director is required")]
    [Display(Name = "Select a Director")]
    public int DirectorId { get; set; }
}
