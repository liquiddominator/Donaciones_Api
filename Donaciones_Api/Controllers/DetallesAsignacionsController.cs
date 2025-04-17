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
    public class DetallesAsignacionsController : ControllerBase
    {
        private readonly DonacionesBeniContext _context;

        public DetallesAsignacionsController(DonacionesBeniContext context)
        {
            _context = context;
        }

        // GET: api/DetallesAsignacions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetallesAsignacion>>> GetDetallesAsignacions()
        {
            return await _context.DetallesAsignacions.ToListAsync();
        }

        // GET: api/DetallesAsignacions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetallesAsignacion>> GetDetallesAsignacion(int id)
        {
            var detallesAsignacion = await _context.DetallesAsignacions.FindAsync(id);

            if (detallesAsignacion == null)
            {
                return NotFound();
            }

            return detallesAsignacion;
        }

        // PUT: api/DetallesAsignacions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetallesAsignacion(int id, DetallesAsignacion detallesAsignacion)
        {
            if (id != detallesAsignacion.DetalleId)
            {
                return BadRequest();
            }

            _context.Entry(detallesAsignacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetallesAsignacionExists(id))
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

        // POST: api/DetallesAsignacions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetallesAsignacion>> PostDetallesAsignacion(DetallesAsignacion detallesAsignacion)
        {
            _context.DetallesAsignacions.Add(detallesAsignacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetallesAsignacion", new { id = detallesAsignacion.DetalleId }, detallesAsignacion);
        }

        // DELETE: api/DetallesAsignacions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetallesAsignacion(int id)
        {
            var detallesAsignacion = await _context.DetallesAsignacions.FindAsync(id);
            if (detallesAsignacion == null)
            {
                return NotFound();
            }

            _context.DetallesAsignacions.Remove(detallesAsignacion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetallesAsignacionExists(int id)
        {
            return _context.DetallesAsignacions.Any(e => e.DetalleId == id);
        }

        // GET: api/DetallesAsignacions/asignacion/5
        [HttpGet("asignacion/{asignacionId}")]
        public async Task<ActionResult<IEnumerable<DetallesAsignacion>>> GetByAsignacion(int asignacionId)
        {
            return await _context.DetallesAsignacions
                .Where(d => d.AsignacionId == asignacionId)
                .ToListAsync();
        }

    }
}
