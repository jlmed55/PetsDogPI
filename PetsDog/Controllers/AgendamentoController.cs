using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetsDog.Data;
using PetsDog.Models;

namespace PetsDog.Controllers
{
    public class AgendamentoController : Controller
    {
        private readonly AppDbContext _context;

        public AgendamentoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var agendamentos = await _context.Agendamentos
                .AsNoTracking()
                .OrderBy(a => a.DataHora)
                .ToListAsync();
            return View(agendamentos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new Agendamento
            {
                DataHora = DateTime.Now
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Agendamento agendamento)
        {
            if (!ModelState.IsValid)
            {
                return View(agendamento);
            }

            _context.Agendamentos.Add(agendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Agendamento agendamento)
        {
            if (!ModelState.IsValid)
            {
                return View(agendamento);
            }

            _context.Agendamentos.Update(agendamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var agendamento = await _context.Agendamentos
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
            if (agendamento == null)
            {
                return NotFound();
            }

            return View(agendamento);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agendamento = await _context.Agendamentos.FindAsync(id);
            if (agendamento != null)
            {
                _context.Agendamentos.Remove(agendamento);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
