using HorarioEducativoWeb.Api.Data;
using HorarioEducativoWeb.Api.Models;
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
}