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
    public class DonacionesController : ControllerBase
    {
        private readonly DonacionesBeniContext _context;

        public DonacionesController(DonacionesBeniContext context)
        {
            _context = context;
        }

        // GET: api/Donaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Donacione>>> GetDonaciones()
        {
            return await _context.Donaciones.ToListAsync();
        }

        // GET: api/Donaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Donacione>> GetDonacione(int id)
        {
            var donacione = await _context.Donaciones.FindAsync(id);

            if (donacione == null)
            {
                return NotFound();
            }

            return donacione;
        }

        // PUT: api/Donaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonacione(int id, Donacione donacione)
        {
            if (id != donacione.DonacionId)
            {
                return BadRequest();
            }

            _context.Entry(donacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacioneExists(id))
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

        // POST: api/Donaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Donacione>> PostDonacione(Donacione donacione)
        {
            _context.Donaciones.Add(donacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonacione", new { id = donacione.DonacionId }, donacione);
        }

        // DELETE: api/Donaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonacione(int id)
        {
            var donacione = await _context.Donaciones.FindAsync(id);
            if (donacione == null)
            {
                return NotFound();
            }

            _context.Donaciones.Remove(donacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonacioneExists(int id)
        {
            return _context.Donaciones.Any(e => e.DonacionId == id);
        }

        // GET: api/Donaciones/usuario/5
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Donacione>>> GetDonacionesByUsuario(int usuarioId)
        {
            return await _context.Donaciones
                .Where(d => d.UsuarioId == usuarioId)
                .ToListAsync();
        }

        // GET: api/Donaciones/campania/5
        [HttpGet("campania/{campaniaId}")]
        public async Task<ActionResult<IEnumerable<Donacione>>> GetDonacionesByCampania(int campaniaId)
        {
            return await _context.Donaciones
                .Where(d => d.CampaniaId == campaniaId)
                .ToListAsync();
        }

    }
}
