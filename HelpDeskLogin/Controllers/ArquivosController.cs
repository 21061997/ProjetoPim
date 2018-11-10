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
    public class ArquivosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArquivosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Arquivos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Arquivos.ToListAsync());
        }

        // GET: Arquivos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivos = await _context.Arquivos
                .SingleOrDefaultAsync(m => m.idArquivo == id);
            if (arquivos == null)
            {
                return NotFound();
            }

            return View(arquivos);
        }

        // GET: Arquivos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arquivos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idArquivo,DH_Cadastro")] Arquivos arquivos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arquivos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(arquivos);
        }

        // GET: Arquivos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivos = await _context.Arquivos.SingleOrDefaultAsync(m => m.idArquivo == id);
            if (arquivos == null)
            {
                return NotFound();
            }
            return View(arquivos);
        }

        // POST: Arquivos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idArquivo,DH_Cadastro")] Arquivos arquivos)
        {
            if (id != arquivos.idArquivo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arquivos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArquivosExists(arquivos.idArquivo))
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
            return View(arquivos);
        }

        // GET: Arquivos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arquivos = await _context.Arquivos
                .SingleOrDefaultAsync(m => m.idArquivo == id);
            if (arquivos == null)
            {
                return NotFound();
            }

            return View(arquivos);
        }

        // POST: Arquivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arquivos = await _context.Arquivos.SingleOrDefaultAsync(m => m.idArquivo == id);
            _context.Arquivos.Remove(arquivos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArquivosExists(int id)
        {
            return _context.Arquivos.Any(e => e.idArquivo == id);
        }
    }
}
