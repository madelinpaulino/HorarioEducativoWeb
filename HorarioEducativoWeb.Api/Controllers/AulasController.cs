using HorarioEducativoWeb.Api.Data;
using HorarioEducativoWeb.Api.Models;
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
}