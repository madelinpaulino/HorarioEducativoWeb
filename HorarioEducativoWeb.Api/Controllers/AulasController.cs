using HorarioEducativoWeb.API.Data;
using HorarioEducativoWeb.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AulasController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public AulasController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Aula>>> Get() => await _context.Aulas.ToListAsync();

    [HttpPost]
    public async Task<ActionResult<Asignatura>> Post(Aula aula)
    {
        _context.Aulas.Add(aula);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = aula.Id }, aula);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Aula aula)
    {
        if (id != aula.Id) return BadRequest();
        _context.Entry(aula).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _context.Aulas.FindAsync(id);
        if (item == null) return NotFound();
        _context.Aulas.Remove(item);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}