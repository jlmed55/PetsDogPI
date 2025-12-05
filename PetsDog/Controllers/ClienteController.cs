using Microsoft.AspNetCore.Mvc;
using PetsDog.Data;
using PetsDog.Models;

namespace PetsDog.Controllers
{
    public class ClienteController : Controller
    {
        
            private readonly AppDbContext _context;
            public ClienteController(AppDbContext context)
            {
                _context = context;
            }
            public IActionResult Index()
            {
                return View(_context.Clientes.ToList());
            }
            [HttpPost]
        public IActionResult Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Datacadastro == default)
                {
                    cliente.Datacadastro = DateTime.Now;
                }
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cliente);
            }
            [HttpGet]
            public IActionResult Create()
            {
                return View();
            }
            [HttpGet]
            public IActionResult Edit(int id)
            {
                var cliente = _context.Clientes.Find(id);
                if (cliente == null) return NotFound();
                return View(cliente);
            }
            [HttpPost]
            public IActionResult Edit(Cliente cliente)
            {
                if (ModelState.IsValid)
                {
                    _context.Clientes.Update(cliente);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(cliente);
            }
            [HttpGet]
        public IActionResult Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }
            [HttpPost]
            public IActionResult DeleteConfirmed(int id)
            {
                var cliente = _context.Clientes.Find(id);
                if (cliente != null)
                {
                    _context.Clientes.Remove(cliente);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
}
