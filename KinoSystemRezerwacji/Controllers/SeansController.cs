using KinoSystemRezerwacji.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KinoSystemRezerwacji.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeansController : ControllerBase
    {
        private readonly CinemaContext _context;

        public SeansController(CinemaContext context)
        {
            _context = context;
        }

        // GET: api/Seans/{data} - Pobieranie seansów dla danego dnia
        [HttpGet("{data}")]
        public async Task<ActionResult<IEnumerable<Seans>>> GetSeanseNaDzien(DateTime data)
        {
            var seanseNaDzien = await _context.Seanse
                .Where(s => s.DataSeansu.Date == data.Date)
                .ToListAsync();

            return Ok(seanseNaDzien);
        }

        // POST: api/Seans - Tworzenie nowego seansu dla filmu
        [HttpPost]
        public async Task<ActionResult<Seans>> CreateSeans([FromBody] Seans seans)
        {
            // Na przykład, jeśli seans zawsze odbywa się o 18:00
            seans.DataSeansu = new DateTime(seans.DataSeansu.Year, seans.DataSeansu.Month, seans.DataSeansu.Day, 18, 0, 0);

            _context.Seanse.Add(seans);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSeanseNaDzien), new { data = seans.DataSeansu.Date }, seans);
        }

    }
}