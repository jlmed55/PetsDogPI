using Microsoft.AspNetCore.Mvc;
using PetsDog.Data;
using PetsDog.Models;

namespace PetsDog.Controllers
{
    public class ProfissionalController : Controller
    {
        private readonly AppDbContext _context;
        public ProfissionalController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Profissionais.ToList());
        }
        [HttpPost]
        public IActionResult Create(Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                _context.Profissionais.Add(profissional);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profissional);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var profissional = _context.Profissionais.Find(id);
            if (profissional == null) return NotFound();
            return View(profissional);
        }
        [HttpPost]
        public IActionResult Edit(Profissional profissional)
        {
            if (ModelState.IsValid)
            {
                _context.Profissionais.Update(profissional);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profissional);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var profissional = _context.Profissionais.Find(id);
            if (profissional == null) return NotFound();
            return View(profissional);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
          var profissional = _context.Profissionais.Find(id);
            if (profissional != null)
            {
                _context.Profissionais.Remove(profissional);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

