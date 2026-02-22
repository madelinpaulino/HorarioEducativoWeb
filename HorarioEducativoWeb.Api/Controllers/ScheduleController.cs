using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HorarioEducativoWeb.Api.Data;
using HorarioEducativoWeb.Api.Models;

namespace HorarioEducativoWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ScheduleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Schedule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horario>>> GetHorarios()
        {
            return await _context.Horarios
                .Include(h => h.Docente)
                .Include(h => h.Asignatura)
                .Include(h => h.Aula)
                .Include(h => h.Grupo)
                .ToListAsync();
        }

        // GET: api/Schedule/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Horario>> GetHorario(int id)
        {
            var horario = await _context.Horarios
                .Include(h => h.Docente)
                .Include(h => h.Asignatura)
                .Include(h => h.Aula)
                .Include(h => h.Grupo)
                .FirstOrDefaultAsync(h => h.Id == id);

            if (horario == null) return NotFound();
            return horario;
        }

        // POST: api/Schedule
        [HttpPost]
        public async Task<ActionResult<Horario>> PostHorario(Horario horario)
        {
            // Limpiamos navegación para evitar que EF intente crear duplicados de entidades existentes
            horario.Docente = null;
            horario.Asignatura = null;
            horario.Aula = null;
            horario.Grupo = null;

            _context.Horarios.Add(horario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHorario), new { id = horario.Id }, horario);
        }

        // PUT: api/Schedule/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHorario(int id, Horario horario)
        {
            if (id != horario.Id) return BadRequest();

            horario.Docente = null;
            horario.Asignatura = null;
            horario.Aula = null;
            horario.Grupo = null;

            _context.Entry(horario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HorarioExists(id)) return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/Schedule/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHorario(int id)
        {
            var horario = await _context.Horarios.FindAsync(id);
            if (horario == null) return NotFound();

            _context.Horarios.Remove(horario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HorarioExists(int id) => _context.Horarios.Any(e => e.Id == id);
    }
}