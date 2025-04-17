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
    public class AsignacionesController : ControllerBase
    {
        private readonly DonacionesBeniContext _context;

        public AsignacionesController(DonacionesBeniContext context)
        {
            _context = context;
        }

        // GET: api/Asignaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Asignacione>>> GetAsignaciones()
        {
            return await _context.Asignaciones.ToListAsync();
        }

        // GET: api/Asignaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Asignacione>> GetAsignacione(int id)
        {
            var asignacione = await _context.Asignaciones.FindAsync(id);

            if (asignacione == null)
            {
                return NotFound();
            }

            return asignacione;
        }

        // PUT: api/Asignaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignacione(int id, Asignacione asignacione)
        {
            if (id != asignacione.AsignacionId)
            {
                return BadRequest();
            }

            _context.Entry(asignacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignacioneExists(id))
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

        // POST: api/Asignaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Asignacione>> PostAsignacione(Asignacione asignacione)
        {
            _context.Asignaciones.Add(asignacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsignacione", new { id = asignacione.AsignacionId }, asignacione);
        }

        // DELETE: api/Asignaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsignacione(int id)
        {
            var asignacione = await _context.Asignaciones.FindAsync(id);
            if (asignacione == null)
            {
                return NotFound();
            }

            _context.Asignaciones.Remove(asignacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AsignacioneExists(int id)
        {
            return _context.Asignaciones.Any(e => e.AsignacionId == id);
        }

        // GET: api/Asignaciones/campania/5
        [HttpGet("campania/{campaniaId}")]
        public async Task<ActionResult<IEnumerable<Asignacione>>> GetAsignacionesByCampania(int campaniaId)
        {
            return await _context.Asignaciones
                .Where(a => a.CampaniaId == campaniaId)
                .ToListAsync();
        }

        // GET: api/Asignaciones/usuario/5
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<Asignacione>>> GetAsignacionesByUsuario(int usuarioId)
        {
            return await _context.Asignaciones
                .Where(a => a.UsuarioId == usuarioId)
                .ToListAsync();
        }

    }
}
