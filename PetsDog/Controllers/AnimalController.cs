using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetsDog.Data;
using PetsDog.Models;

namespace PetsDog.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AppDbContext _context;
        public AnimalController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var animais = _context.Animals
                .Include(a => a.Cliente)
                .ToList();
            return View(animais);
        }
        [HttpPost]
        public IActionResult Create(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Animals.Add(animal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            PopularClientes();
            return View(animal);
        }
        [HttpGet]
        public IActionResult Create()
        {
            PopularClientes();
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var animal = _context.Animals.Find(id);
            if (animal == null) return NotFound();
            PopularClientes();
            return View(animal);
        }
        [HttpPost]
        public IActionResult Edit(Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Animals.Update(animal);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            PopularClientes();
            return View(animal);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var animal = _context.Animals
                .Include(a => a.Cliente)
                .FirstOrDefault(a => a.id_animal == id);
            if (animal == null) return NotFound();
            return View(animal);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var animal = _context.Animals.Find(id);
            if (animal != null)
            {
                _context.Animals.Remove(animal);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        private void PopularClientes()
        {
            ViewBag.Clientes = new SelectList(_context.Clientes.ToList(), "Idcliente", "Nome");
        }
    }
}

