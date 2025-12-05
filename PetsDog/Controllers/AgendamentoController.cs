using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetsDog.Data;
using PetsDog.Models;
using PetsDog.Models.ViewModels;

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
            var viewModel = PopularSeletores(new Agendamento
            {
                DataHora = DateTime.Now
            });
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AgendamentoFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = PopularSeletores(viewModel.Agendamento);
                return View(viewModel);
            }

            _context.Agendamentos.Add(viewModel.Agendamento);
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

            var viewModel = PopularSeletores(agendamento);
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AgendamentoFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel = PopularSeletores(viewModel.Agendamento);
                return View(viewModel);
            }

            _context.Agendamentos.Update(viewModel.Agendamento);
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

        private AgendamentoFormViewModel PopularSeletores(Agendamento agendamento)
        {
            var animais = _context.Animals
                .Include(a => a.Cliente)
                .Select(a => new
                {
                    a.id_animal,
                    Nome = a.Cliente == null ? a.Nome : $"{a.Nome} ({a.Cliente.Nome})"
                })
                .ToList();

            return new AgendamentoFormViewModel
            {
                Agendamento = agendamento,
                Animais = new SelectList(animais, "id_animal", "Nome", agendamento.AnimalId),
                Servicos = new SelectList(_context.Servicos.AsNoTracking().ToList(), "Idservico", "nome", agendamento.ServicoId),
                Profissionais = new SelectList(_context.Profissionais.AsNoTracking().ToList(), "id_profissional", "nome", agendamento.ProfissionalId)
            };
        }
    }
}
