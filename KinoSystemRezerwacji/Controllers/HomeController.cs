using KinoSystemRezerwacji.Models;
using Microsoft.AspNetCore.Mvc;

namespace KinoSystemRezerwacji.Controllers
{
    public class HomeController : Controller
    {
        private readonly CinemaContext _context;

        public HomeController(CinemaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var filmy = _context.Filmy.ToList();

            return View(filmy);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}
