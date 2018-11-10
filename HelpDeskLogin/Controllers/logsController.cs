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
    public class logsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public logsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: logs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Logs.ToListAsync());
        }

        // GET: logs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logs = await _context.Logs
                .SingleOrDefaultAsync(m => m.idLog == id);
            if (logs == null)
            {
                return NotFound();
            }

            return View(logs);
        }

        // GET: logs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: logs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idLog,Log")] logs logs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logs);
        }

        // GET: logs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logs = await _context.Logs.SingleOrDefaultAsync(m => m.idLog == id);
            if (logs == null)
            {
                return NotFound();
            }
            return View(logs);
        }

        // POST: logs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idLog,Log")] logs logs)
        {
            if (id != logs.idLog)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(logs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!logsExists(logs.idLog))
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
            return View(logs);
        }

        // GET: logs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logs = await _context.Logs
                .SingleOrDefaultAsync(m => m.idLog == id);
            if (logs == null)
            {
                return NotFound();
            }

            return View(logs);
        }

        // POST: logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logs = await _context.Logs.SingleOrDefaultAsync(m => m.idLog == id);
            _context.Logs.Remove(logs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool logsExists(int id)
        {
            return _context.Logs.Any(e => e.idLog == id);
        }
    }
}
