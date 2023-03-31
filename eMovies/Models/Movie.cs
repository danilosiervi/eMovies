using eMovies.Data.Base;
using eMovies.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace eMovies.Models;

public class Movie : IEntityBase
{
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string ImageURL { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public MovieCategory Category { get; set; }

    public ICollection<ActorMovie> Actors { get; set; }

    public int CinemaId { get; set; }
    public Cinema Cinema { get; set; }

    public int DirectorId { get; set; }
    public Director Director { get; set; }
}
