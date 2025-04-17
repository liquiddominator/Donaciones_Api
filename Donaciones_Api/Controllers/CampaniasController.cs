using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donaciones_Api.Models;

namespace Donaciones_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaniasController : ControllerBase
    {
        private readonly DonacionesBeniContext _context;

        public CampaniasController(DonacionesBeniContext context)
        {
            _context = context;
        }

        // GET: api/Campanias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Campania>>> GetCampanias()
        {
            return await _context.Campanias.ToListAsync();
        }

        // GET: api/Campanias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Campania>> GetCampania(int id)
        {
            var campania = await _context.Campanias.FindAsync(id);

            if (campania == null)
            {
                return NotFound();
            }

            return campania;
        }

        // PUT: api/Campanias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampania(int id, Campania campania)
        {
            if (id != campania.CampaniaId)
            {
                return BadRequest();
            }

            _context.Entry(campania).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaniaExists(id))
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

        // POST: api/Campanias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Campania>> PostCampania(Campania campania)
        {
            _context.Campanias.Add(campania);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampania", new { id = campania.CampaniaId }, campania);
        }

        // DELETE: api/Campanias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampania(int id)
        {
            var campania = await _context.Campanias.FindAsync(id);
            if (campania == null)
            {
                return NotFound();
            }

            _context.Campanias.Remove(campania);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CampaniaExists(int id)
        {
            return _context.Campanias.Any(e => e.CampaniaId == id);
        }
    }
}
