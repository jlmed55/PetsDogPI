using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetsDog.Data;
using PetsDog.Models;

namespace PetsDog.Controllers
{
    [ApiController]
    [Route("agendamentos")]
    [EnableCors("AgendamentoCors")]
    public class AgendamentosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AgendamentosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agendamento>>> Get()
        {
            var agendamentos = await _context.Agendamentos.AsNoTracking().ToListAsync();
            return Ok(agendamentos);
        }

        [HttpPost]
        public async Task<ActionResult<Agendamento>> Post([FromBody] Agendamento agendamento)
        {
            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();

            return Created($"/agendamentos/{agendamento.Id}", agendamento);
        }
    }
}
