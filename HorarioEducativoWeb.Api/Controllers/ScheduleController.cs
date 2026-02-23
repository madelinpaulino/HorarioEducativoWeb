using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HorarioEducativoWeb.API.Data;
using HorarioEducativoWeb.Shared.Models;

namespace HorarioEducativoWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ScheduleController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Horario>>> Get() =>
            await _context.Horarios.Include(h => h.Docente).Include(h => h.Asignatura)
                                   .Include(h => h.Aula).Include(h => h.Grupo).ToListAsync();

        [HttpPost]
        public async Task<ActionResult<Horario>> Post(Horario horario)
        {
            // 1. Validar conflictos antes de insertar
            var mensajeError = await ValidarConflicto(horario);
            if (mensajeError != null) return BadRequest(mensajeError);

            // Limpiamos objetos de navegación para evitar que EF intente re-insertarlos
            horario.Docente = null; horario.Asignatura = null;
            horario.Aula = null; horario.Grupo = null;

            _context.Horarios.Add(horario);
            await _context.SaveChangesAsync();
            return Ok(horario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Horario horario)
        {
            if (id != horario.Id) return BadRequest();

            // 1. Validar conflictos (excluyendo el registro actual)
            var mensajeError = await ValidarConflicto(horario);
            if (mensajeError != null) return BadRequest(mensajeError);

            horario.Docente = null; horario.Asignatura = null;
            horario.Aula = null; horario.Grupo = null;

            _context.Entry(horario).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var h = await _context.Horarios.FindAsync(id);
            if (h == null) return NotFound();
            _context.Horarios.Remove(h);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // --- MÉTODO DE VALIDACIÓN CENTRALIZADO ---
        private async Task<string?> ValidarConflicto(Horario nuevo)
        {
            // Buscamos cualquier horario en el mismo día que se cruce en el tiempo
            // Regla: (InicioA < FinB) && (FinA > InicioB)
            var conflicto = await _context.Horarios
                .Include(h => h.Docente)
                .Include(h => h.Aula)
                .Include(h => h.Grupo)
                .Where(h => h.Id != nuevo.Id) // Importante para el PUT: ignorar el registro que estamos editando
                .Where(h => h.DiaSemana == nuevo.DiaSemana)
                .Where(h => nuevo.HoraInicio < h.HoraFin && nuevo.HoraFin > h.HoraInicio)
                .FirstOrDefaultAsync(h =>
                    h.AulaId == nuevo.AulaId ||
                    h.DocenteId == nuevo.DocenteId ||
                    h.GrupoId == nuevo.GrupoId);

            if (conflicto != null)
            {
                if (conflicto.AulaId == nuevo.AulaId)
                    return $"Conflicto: El aula ya está ocupada por el grupo '{conflicto.Grupo?.Nombre}'.";

                if (conflicto.DocenteId == nuevo.DocenteId)
                    return $"Conflicto: El docente '{conflicto.Docente?.Nombre}' ya tiene clase en este horario.";

                if (conflicto.GrupoId == nuevo.GrupoId)
                    return $"Conflicto: El grupo '{conflicto.Grupo?.Nombre}' ya tiene otra asignatura asignada.";
            }

            return null; // No hay conflictos
        }
    }
}