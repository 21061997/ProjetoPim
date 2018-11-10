using System;
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
    public class prioridadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public prioridadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: prioridades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prioridades.ToListAsync());
        }

        // GET: prioridades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridades = await _context.Prioridades
                .SingleOrDefaultAsync(m => m.idPrioridade == id);
            if (prioridades == null)
            {
                return NotFound();
            }

            return View(prioridades);
        }

        // GET: prioridades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: prioridades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idPrioridade,prioridade,descricao,ativo")] prioridades prioridades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prioridades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prioridades);
        }

        // GET: prioridades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridades = await _context.Prioridades.SingleOrDefaultAsync(m => m.idPrioridade == id);
            if (prioridades == null)
            {
                return NotFound();
            }
            return View(prioridades);
        }

        // POST: prioridades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idPrioridade,prioridade,descricao,ativo")] prioridades prioridades)
        {
            if (id != prioridades.idPrioridade)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prioridades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!prioridadesExists(prioridades.idPrioridade))
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
            return View(prioridades);
        }

        // GET: prioridades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prioridades = await _context.Prioridades
                .SingleOrDefaultAsync(m => m.idPrioridade == id);
            if (prioridades == null)
            {
                return NotFound();
            }

            return View(prioridades);
        }

        // POST: prioridades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prioridades = await _context.Prioridades.SingleOrDefaultAsync(m => m.idPrioridade == id);
            _context.Prioridades.Remove(prioridades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool prioridadesExists(int id)
        {
            return _context.Prioridades.Any(e => e.idPrioridade == id);
        }
    }
}
