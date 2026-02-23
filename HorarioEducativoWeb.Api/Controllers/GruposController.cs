using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HorarioEducativoWeb.API.Data;
using HorarioEducativoWeb.Shared.Models;

namespace HorarioEducativoWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GruposController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public GruposController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grupo>>> Get() => await _context.Grupos.ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Grupo>> Post(Grupo grupo)
        {
            _context.Grupos.Add(grupo);
            await _context.SaveChangesAsync();
            return Ok(grupo);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var h = await _context.Grupos.FindAsync(id);
            if (h == null) return NotFound();
            _context.Grupos.Remove(h);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}