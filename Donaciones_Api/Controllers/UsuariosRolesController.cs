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
    public class UsuariosRolesController : ControllerBase
    {
        private readonly DonacionesBeniContext _context;

        public UsuariosRolesController(DonacionesBeniContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosRoles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuariosRole>>> GetUsuariosRoles()
        {
            return await _context.UsuariosRoles.ToListAsync();
        }

        // GET: api/UsuariosRoles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuariosRole>> GetUsuariosRole(int id)
        {
            var usuariosRole = await _context.UsuariosRoles.FindAsync(id);

            if (usuariosRole == null)
            {
                return NotFound();
            }

            return usuariosRole;
        }

        // PUT: api/UsuariosRoles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuariosRole(int id, UsuariosRole usuariosRole)
        {
            if (id != usuariosRole.UsuarioRolId)
            {
                return BadRequest();
            }

            _context.Entry(usuariosRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosRoleExists(id))
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

        // POST: api/UsuariosRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuariosRole>> PostUsuariosRole(UsuariosRole usuariosRole)
        {
            _context.UsuariosRoles.Add(usuariosRole);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuariosRole", new { id = usuariosRole.UsuarioRolId }, usuariosRole);
        }

        // DELETE: api/UsuariosRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuariosRole(int id)
        {
            var usuariosRole = await _context.UsuariosRoles.FindAsync(id);
            if (usuariosRole == null)
            {
                return NotFound();
            }

            _context.UsuariosRoles.Remove(usuariosRole);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuariosRoleExists(int id)
        {
            return _context.UsuariosRoles.Any(e => e.UsuarioRolId == id);
        }

        // GET: api/UsuariosRoles/usuario/5
        [HttpGet("usuario/{usuarioId}")]
        public async Task<ActionResult<IEnumerable<UsuariosRole>>> GetRolesByUsuario(int usuarioId)
        {
            return await _context.UsuariosRoles
                .Where(ur => ur.UsuarioId == usuarioId)
                .ToListAsync();
        }

        // GET: api/UsuariosRoles/rol/5
        [HttpGet("rol/{rolId}")]
        public async Task<ActionResult<IEnumerable<UsuariosRole>>> GetUsuariosByRol(int rolId)
        {
            return await _context.UsuariosRoles
                .Where(ur => ur.RolId == rolId)
                .ToListAsync();
        }
    }
}
