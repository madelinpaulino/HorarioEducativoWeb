using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HorarioEducativoWeb.Api.Data;
using HorarioEducativoWeb.Api.Models;

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
    }
}