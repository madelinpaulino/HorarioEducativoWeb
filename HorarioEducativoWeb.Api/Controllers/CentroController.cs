using HorarioEducativoWeb.API.Data;
using HorarioEducativoWeb.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CentroController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    public CentroController(ApplicationDbContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // Intentamos obtener el primer registro (o el único)
        var centro = await _context.InformacionCentro.FirstOrDefaultAsync();

        // Si no existe, devolvemos uno vacío para que el frontend no falle
        if (centro == null) return Ok(new CentroEducativo { Nombre = "Configurar Nombre", RNC = "000-00000-0" });

        return Ok(centro);
    }

    [HttpPost]
    public async Task<IActionResult> Update(CentroEducativo centro)
    {
        var existente = await _context.InformacionCentro.FirstOrDefaultAsync();

        if (existente == null)
        {
            _context.InformacionCentro.Add(centro);
        }
        else
        {
            existente.Nombre = centro.Nombre;
            existente.Direccion = centro.Direccion;
            existente.RNC = centro.RNC;
            _context.InformacionCentro.Update(existente);
        }

        await _context.SaveChangesAsync();
        return Ok(centro);
    }
}