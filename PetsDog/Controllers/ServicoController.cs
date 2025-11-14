using Microsoft.AspNetCore.Mvc;
using PetsDog.Data;
using PetsDog.Models;
using System;

namespace PetsDog.Controllers
{
    public class ServicoController: Controller
    {
        private readonly AppDbContext _context;
        public ServicoController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Servico.ToList());
        }
        [HttpPost]
        public IActionResult Create(Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Servico.Add(servico);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servico);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var servico = _context.Servico.Find(id);
            if (servico == null) return NotFound();
            return View(servico);
        }
        [HttpPost]
        public IActionResult Edit(Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Servico.Update(servico);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servico);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var servico = _context.Servico.Find(id);
            if (servico == null) return NotFound();
            return View(servico);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var servico = _context.Servico.Find(id);
            if (servico != null)
            {
                _context.Servico.Remove(servico);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

