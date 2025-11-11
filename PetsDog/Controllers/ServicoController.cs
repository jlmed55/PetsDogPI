using Microsoft.AspNetCore.Mvc;
using PetsDog.Models;
using System;

namespace PetsDog.Controllers
{
    public class ServicoController: Controller
    {
        private readonly AppDbContext _context;
        public ServicoController(AppDbcontext)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Fornecedores.ToList());
        }
        [HttpPost]
        public IActionResult Create(Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Fornecedores.Add(servico);
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
            var servico = _context.Fornecedores.Find(id);
            if (servico == null) return NotFound();
            return View(servico);
        }
        [HttpPost]
        public IActionResult Edit(Servico servico)
        {
            if (ModelState.IsValid)
            {
                _context.Fornecedores.Update(servico);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(servico);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var servico = _context.Fornecedores.Find(id);
            if (servico == null) return NotFound();
            return View(servico);
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var fornecedor = _context.Fornecedores.Find(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

