using Microsoft.AspNetCore.Mvc;
using KinoSystemRezerwacji.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ApiFilmyController : ControllerBase
{
    private readonly CinemaContext _context;

    public ApiFilmyController(CinemaContext context)
    {
        _context = context;
    }

    // GET: api/Filmy
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Film>>> GetFilmy()
    {
        return await _context.Filmy.ToListAsync();
    }

    // GET: api/Filmy/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Film>> GetFilm(int id)
    {
        var film = await _context.Filmy.FindAsync(id);
        if (film == null)
        {
            return NotFound();
        }
        return film;
    }
    // GET: api/Filmy/{id}/Seanse
    [HttpGet("{id}/Seanse")]
    public async Task<ActionResult<IEnumerable<Seans>>> GetSeanseForFilm(int id)
    {
        // Sprawdź, czy film istnieje
        var filmExists = await _context.Filmy.AnyAsync(f => f.Id == id);
        if (!filmExists)
        {
            return NotFound("Film nie został znaleziony.");
        }

        // Pobierz seanse dla filmu
        var seanse = await _context.Seanse
                                   .Where(s => s.FilmId == id)
                                   .ToListAsync();

        return seanse;
    }

    // POST: api/Filmy
    [HttpPost]
    public async Task<ActionResult<Film>> PostFilm(Film film)
    {
        _context.Filmy.Add(film);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetFilm), new { id = film.Id }, film);
    }

    // PUT: api/Filmy/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFilm(int id, Film film)
    {
        if (id != film.Id)
        {
            return BadRequest();
        }
        _context.Entry(film).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FilmExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    // DELETE: api/Filmy/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFilm(int id)
    {
        var film = await _context.Filmy.FindAsync(id);
        if (film == null)
        {
            return NotFound();
        }
        _context.Filmy.Remove(film);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool FilmExists(int id)
    {
        return _context.Filmy.Any(e => e.Id == id);
    }
}

