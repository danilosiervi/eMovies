using Microsoft.AspNetCore.Mvc;

namespace eMovies.Controllers
{
    public class ActorsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
