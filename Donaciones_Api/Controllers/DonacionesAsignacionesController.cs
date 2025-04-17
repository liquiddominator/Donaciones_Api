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
    public class DonacionesAsignacionesController : ControllerBase
    {
        private readonly DonacionesBeniContext _context;

        public DonacionesAsignacionesController(DonacionesBeniContext context)
        {
            _context = context;
        }

        // GET: api/DonacionesAsignaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DonacionesAsignacione>>> GetDonacionesAsignaciones()
        {
            return await _context.DonacionesAsignaciones.ToListAsync();
        }

        // GET: api/DonacionesAsignaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DonacionesAsignacione>> GetDonacionesAsignacione(int id)
        {
            var donacionesAsignacione = await _context.DonacionesAsignaciones.FindAsync(id);

            if (donacionesAsignacione == null)
            {
                return NotFound();
            }

            return donacionesAsignacione;
        }

        // PUT: api/DonacionesAsignaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDonacionesAsignacione(int id, DonacionesAsignacione donacionesAsignacione)
        {
            if (id != donacionesAsignacione.DonacionAsignacionId)
            {
                return BadRequest();
            }

            _context.Entry(donacionesAsignacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonacionesAsignacioneExists(id))
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

        // POST: api/DonacionesAsignaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DonacionesAsignacione>> PostDonacionesAsignacione(DonacionesAsignacione donacionesAsignacione)
        {
            _context.DonacionesAsignaciones.Add(donacionesAsignacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDonacionesAsignacione", new { id = donacionesAsignacione.DonacionAsignacionId }, donacionesAsignacione);
        }

        // DELETE: api/DonacionesAsignaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDonacionesAsignacione(int id)
        {
            var donacionesAsignacione = await _context.DonacionesAsignaciones.FindAsync(id);
            if (donacionesAsignacione == null)
            {
                return NotFound();
            }

            _context.DonacionesAsignaciones.Remove(donacionesAsignacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonacionesAsignacioneExists(int id)
        {
            return _context.DonacionesAsignaciones.Any(e => e.DonacionAsignacionId == id);
        }

        // GET: api/DonacionesAsignaciones/donacion/5
        [HttpGet("donacion/{donacionId}")]
        public async Task<ActionResult<IEnumerable<DonacionesAsignacione>>> GetByDonacion(int donacionId)
        {
            return await _context.DonacionesAsignaciones
                .Where(da => da.DonacionId == donacionId)
                .ToListAsync();
        }

        // GET: api/DonacionesAsignaciones/asignacion/5
        [HttpGet("asignacion/{asignacionId}")]
        public async Task<ActionResult<IEnumerable<DonacionesAsignacione>>> GetByAsignacion(int asignacionId)
        {
            return await _context.DonacionesAsignaciones
                .Where(da => da.AsignacionId == asignacionId)
                .ToListAsync();
        }
    }
}
