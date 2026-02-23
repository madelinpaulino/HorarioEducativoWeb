using HorarioEducativoWeb.API.Data;
using HorarioEducativoWeb.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HorarioEducativoWeb.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocentesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public DocentesController(ApplicationDbContext context) => _context = context;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Docente>>> Get() => await _context.Docentes.ToListAsync();

        [HttpGet("{id}")]
        public async Task<ActionResult<Docente>> Get(int id)
        {
            var item = await _context.Docentes.FindAsync(id);
            return item == null ? NotFound() : item;
        }

        [HttpPost]
        public async Task<ActionResult<Docente>> Post(Docente docente)
        {
            _context.Docentes.Add(docente);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = docente.Id }, docente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Docente docente)
        {
            if (id != docente.Id) return BadRequest();
            _context.Entry(docente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Docentes.FindAsync(id);
            if (item == null) return NotFound();
            _context.Docentes.Remove(item);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}