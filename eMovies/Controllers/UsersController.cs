using eMovies.Data;
using eMovies.Data.ViewModels;
using eMovies.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace eMovies.Controllers;

public class UsersController : Controller
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly AppDbContext _context;

    public UsersController(UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _context = context;
    }

    public IActionResult Login() => View(new LoginVM());

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM loginVM)
    {
        if (!ModelState.IsValid) return View(loginVM);

        var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
        if (user != null)
        {
            var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
            if (passwordCheck)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded) return RedirectToAction("Index", "Movies");
            }

            TempData["Error"] = "Wrong credentiasl. Please, try again";
            return View(loginVM);
        }

        TempData["Error"] = "Wrong credentiasl. Please, try again";
        return View(loginVM);
    }

    public IActionResult Signup() => View(new SignupVM());

    [HttpPost]
    public async Task<IActionResult> Signup(SignupVM signupVM)
    {
        if (!ModelState.IsValid) return View(signupVM);

        var user = await _userManager.FindByEmailAsync(signupVM.EmailAddress);
        if (user != null)
        {
            TempData["Error"] = "Email Address is already in use";
            return View(signupVM);
        }

        var newUser = new User()
        {
            FullName = signupVM.Name,
            Email = signupVM.EmailAddress,
            UserName = signupVM.EmailAddress
        };

        var newUserResponse = await _userManager.CreateAsync(newUser, signupVM.Password);
        if (newUserResponse.Succeeded) await _userManager.AddToRoleAsync(newUser, UserRoles.User);

        return View("RegisterCompleted");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Movies");
    }
}
