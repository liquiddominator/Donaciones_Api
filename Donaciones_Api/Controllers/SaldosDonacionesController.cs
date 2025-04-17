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
    public class SaldosDonacionesController : ControllerBase
    {
        private readonly DonacionesBeniContext _context;

        public SaldosDonacionesController(DonacionesBeniContext context)
        {
            _context = context;
        }

        // GET: api/SaldosDonaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaldosDonacione>>> GetSaldosDonaciones()
        {
            return await _context.SaldosDonaciones.ToListAsync();
        }

        // GET: api/SaldosDonaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaldosDonacione>> GetSaldosDonacione(int id)
        {
            var saldosDonacione = await _context.SaldosDonaciones.FindAsync(id);

            if (saldosDonacione == null)
            {
                return NotFound();
            }

            return saldosDonacione;
        }

        // PUT: api/SaldosDonaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaldosDonacione(int id, SaldosDonacione saldosDonacione)
        {
            if (id != saldosDonacione.SaldoId)
            {
                return BadRequest();
            }

            _context.Entry(saldosDonacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaldosDonacioneExists(id))
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

        // POST: api/SaldosDonaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaldosDonacione>> PostSaldosDonacione(SaldosDonacione saldosDonacione)
        {
            _context.SaldosDonaciones.Add(saldosDonacione);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaldosDonacione", new { id = saldosDonacione.SaldoId }, saldosDonacione);
        }

        // DELETE: api/SaldosDonaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaldosDonacione(int id)
        {
            var saldosDonacione = await _context.SaldosDonaciones.FindAsync(id);
            if (saldosDonacione == null)
            {
                return NotFound();
            }

            _context.SaldosDonaciones.Remove(saldosDonacione);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaldosDonacioneExists(int id)
        {
            return _context.SaldosDonaciones.Any(e => e.SaldoId == id);
        }

        // GET: api/SaldosDonaciones/donacion/5
        [HttpGet("donacion/{donacionId}")]
        public async Task<ActionResult<IEnumerable<SaldosDonacione>>> GetByDonacion(int donacionId)
        {
            return await _context.SaldosDonaciones
                .Where(s => s.DonacionId == donacionId)
                .ToListAsync();
        }

    }
}
