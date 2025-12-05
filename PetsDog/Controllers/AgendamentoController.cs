using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
                .Include(a => a.Animal)
                .Include(a => a.Servico)
                .Include(a => a.Profissional)
                .AsNoTracking()
                .OrderBy(a => a.DataHora)
                .ToListAsync();
            return View(agendamentos);
        }

        [HttpGet]
        public IActionResult Create()
        {
            PopularSeletores();
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
                PopularSeletores();
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

            PopularSeletores();
            return View(agendamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Agendamento agendamento)
        {
            if (!ModelState.IsValid)
            {
                PopularSeletores();
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
                .Include(a => a.Animal)
                .Include(a => a.Servico)
                .Include(a => a.Profissional)
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

        private void PopularSeletores()
        {
            var animais = _context.Animals
                .Include(a => a.Cliente)
                .Select(a => new
                {
                    a.id_animal,
                    Nome = a.Cliente == null ? a.Nome : $"{a.Nome} ({a.Cliente.Nome})"
                })
                .ToList();

            ViewBag.Animais = new SelectList(animais, "id_animal", "Nome");
            ViewBag.Servicos = new SelectList(_context.Servicos.AsNoTracking().ToList(), "Idservico", "nome");
            ViewBag.Profissionais = new SelectList(_context.Profissionais.AsNoTracking().ToList(), "id_profissional", "nome");
        }
    }
}
