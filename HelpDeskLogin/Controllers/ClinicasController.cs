﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDeskLogin.Data;
using HelpDeskLogin.Models;

namespace HelpDeskLogin.Controllers
{
    public class ClinicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClinicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Clinicas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clinicas.ToListAsync());
        }

        // GET: Clinicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicas = await _context.Clinicas
                .SingleOrDefaultAsync(m => m.idClinica == id);
            if (clinicas == null)
            {
                return NotFound();
            }

            return View(clinicas);
        }

        // GET: Clinicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idClinica,telefone,cep,logradouro,bairro,uf,cidade,nome")] Clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinicas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clinicas);
        }

        // GET: Clinicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicas = await _context.Clinicas.SingleOrDefaultAsync(m => m.idClinica == id);
            if (clinicas == null)
            {
                return NotFound();
            }
            return View(clinicas);
        }

        // POST: Clinicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idClinica,telefone,cep,logradouro,bairro,uf,cidade")] Clinicas clinicas)
        {
            if (id != clinicas.idClinica)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinicas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicasExists(clinicas.idClinica))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(clinicas);
        }

        // GET: Clinicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicas = await _context.Clinicas
                .SingleOrDefaultAsync(m => m.idClinica == id);
            if (clinicas == null)
            {
                return NotFound();
            }

            return View(clinicas);
        }

        // POST: Clinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clinicas = await _context.Clinicas.SingleOrDefaultAsync(m => m.idClinica == id);
            _context.Clinicas.Remove(clinicas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicasExists(int id)
        {
            return _context.Clinicas.Any(e => e.idClinica == id);
        }
    }
}
