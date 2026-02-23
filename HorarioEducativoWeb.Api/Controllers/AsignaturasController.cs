using HorarioEducativoWeb.API.Data;
using HorarioEducativoWeb.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AsignaturasController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AsignaturasController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Asignatura>>> Get() => await _context.Asignaturas.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Asignatura>> Post(Asignatura asignatura)
    {
        _context.Asignaturas.Add(asignatura);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = asignatura.Id }, asignatura);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Asignatura asignatura)
    {
        if (id != asignatura.Id) return BadRequest();
        _context.Entry(asignatura).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Asignaturas.FindAsync(id);
        if (item == null) return NotFound();
        _context.Asignaturas.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}