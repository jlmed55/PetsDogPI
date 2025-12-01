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
            return View(_context.Servicos.ToList());
        }
        [HttpPost]
        public IActionResult Create(Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Servicos.Add(servico);
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
            var servico = _context.Servicos.Find(id);
            if (servico == null) return NotFound();
            return View(servico);
        }
        [HttpPost]
        public IActionResult Edit(Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Servicos.Update(servico);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servico);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var servico = _context.Servicos.Find(id);
            if (servico == null) return NotFound();
            return View(servico);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var servico = _context.Servicos.Find(id);
            if (servico != null)
            {
                _context.Servicos.Remove(servico);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

