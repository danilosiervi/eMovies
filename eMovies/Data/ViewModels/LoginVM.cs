using System.ComponentModel.DataAnnotations;

namespace eMovies.Data.ViewModels;

public class LoginVM
{
    [Required(ErrorMessage = "Email Adress is required")]
    [Display(Name = "Email")]
    public string EmailAddress { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}
