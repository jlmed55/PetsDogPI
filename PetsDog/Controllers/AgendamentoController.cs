using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Agendamento.Add(agendamento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agendamento);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var agendamento = _context.Agendamento.Find(id);
            if (agendamento == null) return NotFound();
            return View(agendamento);
        }
        [HttpPost]
        public IActionResult Edit(Agendamento agendamento)
        {
            if (ModelState.IsValid)
            {
                _context.Agendamento.Update(agendamento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agendamento);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var agendamento = _context.Agendamento.Find(id);
            if (agendamento == null) return NotFound();
            return View(agendamento);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var agendamento = _context.Agendamento.Find(id);
            if (agendamento != null)
            {
                _context.Agendamento.Remove(agendamento);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

