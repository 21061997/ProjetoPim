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
    public class gruposController : Controller
    {
        private readonly ApplicationDbContext _context;

        public gruposController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: grupos
        public async Task<IActionResult> Index()
        {
            return View(await _context.grupos.ToListAsync());
        }

        // GET: grupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupos = await _context.grupos
                .SingleOrDefaultAsync(m => m.idGrupo == id);
            if (grupos == null)
            {
                return NotFound();
            }

            return View(grupos);
        }

        // GET: grupos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: grupos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idGrupo,grupo,descricao,ativo")] grupos grupos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupos);
        }

        // GET: grupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupos = await _context.grupos.SingleOrDefaultAsync(m => m.idGrupo == id);
            if (grupos == null)
            {
                return NotFound();
            }
            return View(grupos);
        }

        // POST: grupos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idGrupo,grupo,descricao,ativo")] grupos grupos)
        {
            if (id != grupos.idGrupo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!gruposExists(grupos.idGrupo))
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
            return View(grupos);
        }

        // GET: grupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grupos = await _context.grupos
                .SingleOrDefaultAsync(m => m.idGrupo == id);
            if (grupos == null)
            {
                return NotFound();
            }

            return View(grupos);
        }

        // POST: grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grupos = await _context.grupos.SingleOrDefaultAsync(m => m.idGrupo == id);
            _context.grupos.Remove(grupos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool gruposExists(int id)
        {
            return _context.grupos.Any(e => e.idGrupo == id);
        }
    }
}
