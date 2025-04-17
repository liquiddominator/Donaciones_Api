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
    public class RespuestasMensajesController : ControllerBase
    {
        private readonly DonacionesBeniContext _context;

        public RespuestasMensajesController(DonacionesBeniContext context)
        {
            _context = context;
        }

        // GET: api/RespuestasMensajes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RespuestasMensaje>>> GetRespuestasMensajes()
        {
            return await _context.RespuestasMensajes.ToListAsync();
        }

        // GET: api/RespuestasMensajes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RespuestasMensaje>> GetRespuestasMensaje(int id)
        {
            var respuestasMensaje = await _context.RespuestasMensajes.FindAsync(id);

            if (respuestasMensaje == null)
            {
                return NotFound();
            }

            return respuestasMensaje;
        }

        // PUT: api/RespuestasMensajes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRespuestasMensaje(int id, RespuestasMensaje respuestasMensaje)
        {
            if (id != respuestasMensaje.RespuestaId)
            {
                return BadRequest();
            }

            _context.Entry(respuestasMensaje).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespuestasMensajeExists(id))
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

        // POST: api/RespuestasMensajes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RespuestasMensaje>> PostRespuestasMensaje(RespuestasMensaje respuestasMensaje)
        {
            _context.RespuestasMensajes.Add(respuestasMensaje);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRespuestasMensaje", new { id = respuestasMensaje.RespuestaId }, respuestasMensaje);
        }

        // DELETE: api/RespuestasMensajes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRespuestasMensaje(int id)
        {
            var respuestasMensaje = await _context.RespuestasMensajes.FindAsync(id);
            if (respuestasMensaje == null)
            {
                return NotFound();
            }

            _context.RespuestasMensajes.Remove(respuestasMensaje);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RespuestasMensajeExists(int id)
        {
            return _context.RespuestasMensajes.Any(e => e.RespuestaId == id);
        }

        // GET: api/RespuestasMensajes/mensaje/5
        [HttpGet("mensaje/{mensajeId}")]
        public async Task<ActionResult<IEnumerable<RespuestasMensaje>>> GetByMensaje(int mensajeId)
        {
            return await _context.RespuestasMensajes
                .Where(r => r.MensajeId == mensajeId)
                .ToListAsync();
        }

    }
}
