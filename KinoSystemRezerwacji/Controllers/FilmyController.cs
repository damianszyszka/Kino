using KinoSystemRezerwacji.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace KinoSystemRezerwacji.Controllers
{

    public class QueryParameters
    {
        public string Search { get; set; } = "";
    }

    public class FilmyController : Controller
    {
        private readonly CinemaContext _context;

        public FilmyController(CinemaContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var filmy = _context.Filmy.ToList();

            return View(filmy);
        }

        public IActionResult Show(int id)
        {
            var film = _context.Filmy.Find(id);

            return View(film);
        }

        public IActionResult Search([FromQuery] QueryParameters queryParameters)
        {
            var films = _context.Filmy.Where(f => EF.Functions.Like(f.Tytul, $"%{queryParameters.Search}%")).ToList();

            return View(films);
        }
    }
}