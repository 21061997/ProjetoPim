using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HelpDeskLogin.Data;
using HelpDeskLogin.Models;
using System.IO;
using System.Collections;

namespace HelpDeskLogin.Controllers
{
    public class chamadosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public chamadosController(ApplicationDbContext context)
        {
            _context = context;
        }

        /*Salvando Arquivos*/

            public IActionResult SalvarArquivo(Arquivos model)
        {

            if (!ModelState.IsValid)
                return RedirectToAction("Index");// Fazendo a avalidação

            if (model == null)
                throw new Exception("Model null");

            //var arquivo = Arquivos.Convert(model);
    
            model.CaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\arquivos", model.arquivo.FileName);// Caminho para alocação do arquivo.

            using (var stream = new FileStream(model.CaminhoArquivo, FileMode.Create))
            {

                model.arquivo.CopyTo(stream);

            }


            _context.Add(model);
            //await
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));



        }



        // GET: chamados
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Chamados.Include(c => c.categorias).Include(c => c.comentarios).Include(c => c.grupos).Include(c => c.logs).Include(c => c.prioridades);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: chamados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var chamados = await _context.Chamados   
                .Include(c => c.categorias)
                .Include(c => c.comentarios)
                .Include(c => c.grupos)
                .Include(c => c.logs)
                .Include(c => c.prioridades)
                .Include(c=> c.arquivos)
                .SingleOrDefaultAsync(m => m.idChamado == id);
            if (chamados == null)
            {
                return NotFound();
            }

            return View(chamados);
        }

        // GET: chamados/Create
        public IActionResult Create()
        {


            ViewBag.categoriasId = new SelectList(_context.Categoria.ToList(), "idCategoria", "categoria");
            ViewBag.gruposId = new SelectList(_context.grupos.ToList(), "idGrupo", "grupo");
             //ViewData["categoriasId"] = new SelectList(_context.Categoria, "idCategoria", "idCategoria");
            ViewData["comentariosId"] = new SelectList(_context.Comentarios, "idComentario", "idComentario");
            //ViewData["gruposId"] = new SelectList(_context.grupos, "idGrupo", "idGrupo");
            ViewData["logsId"] = new SelectList(_context.Logs, "idLog", "idLog");
            ViewData["prioridadesId"] = new SelectList(_context.Prioridades, "idPrioridade", "idPrioridade");
            return View();
        }

        // POST: chamados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idChamado,DH_Abertura,DH_Fechamento,descricao,categoriasId,comentariosId,logsId,gruposId,prioridadesId,Arquivo")] chamados chamados)
        {
            if (ModelState.IsValid)
            {
                chamados.DH_Abertura = DateTime.Now;
                _context.Add(chamados);
                await _context.SaveChangesAsync();

                if (chamados.Arquivo != null)
                {
                    var arquivo = new Arquivos();
                    arquivo.arquivo = chamados.Arquivo;
                    arquivo.chamdosId = chamados.idChamado;
                    SalvarArquivo(arquivo);
                }

                


                return RedirectToAction(nameof(Index));
            }

          // ViewBag.categoriasId = new SelectList(_context.Categoria.ToList(), "idCategoria", "categoria", chamados.categoriasId);
            //ViewData["categoriasId"] = new SelectList(_context.Categoria, "idCategoria", "idCategoria", chamados.categoriasId);
            //ViewData["comentariosId"] = new SelectList(_context.Comentarios, "idComentario", "idComentario", chamados.comentariosId);
            //ViewBag.gruposId = new SelectList(_context.grupos.ToList(), "idGrupo", "grupo", chamados.gruposId);
           //ViewData["gruposId"] = new SelectList(_context.grupos, "idGrupo", "idGrupo", chamados.gruposId);
            //ViewData["logsId"] = new SelectList(_context.Logs, "idLog", "idLog", chamados.logsId);
            //ViewData["prioridadesId"] = new SelectList(_context.Prioridades, "idPrioridade", "idPrioridade", chamados.prioridadesId);
            return await Index();

            
            
        }

        // GET: chamados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamados = await _context.Chamados.SingleOrDefaultAsync(m => m.idChamado == id);
            if (chamados == null)
            {
                return NotFound();
            }
            ViewBag.categoriasId = new SelectList(_context.Categoria.ToList(), "idCategoria", "categoria", chamados.categoriasId);
            ViewBag.gruposId = new SelectList(_context.grupos.ToList(), "idGrupo", "grupo", chamados.gruposId);
            ViewData["comentariosId"] = new SelectList(_context.Comentarios, "idComentario", "idComentario", chamados.comentariosId);
            //ViewData["gruposId"] = new SelectList(_context.grupos.ToList(), "idGrupo", "grupos", chamados.gruposId);
            ViewData["logsId"] = new SelectList(_context.Logs, "idLog", "idLog", chamados.logs);
            ViewData["prioridadesId"] = new SelectList(_context.Prioridades, "idPrioridade", "idPrioridade", chamados.prioridadesId);
            return View(chamados);
        }

        // POST: chamados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idChamado,DH_Abertura,DH_Fechamento,descricao,categoriasId,comentariosId,logsId,gruposId,prioridadesId")] chamados chamados)
        {
            if (id != chamados.idChamado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chamados);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!chamadosExists(chamados.idChamado))
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
            ViewData["categoriasId"] = new SelectList(_context.Categoria, "idCategoria", "idCategoria", chamados.categoriasId);
            ViewData["comentariosId"] = new SelectList(_context.Comentarios, "idComentario", "idComentario", chamados.comentariosId);
            ViewData["gruposId"] = new SelectList(_context.grupos, "idGrupo", "idGrupo", chamados.gruposId);
            ViewData["logsId"] = new SelectList(_context.Logs, "idLog", "idLog", chamados.logs);
            ViewData["prioridadesId"] = new SelectList(_context.Prioridades, "idPrioridade", "idPrioridade", chamados.prioridadesId);
            return View(chamados);
        }

        // GET: chamados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chamados = await _context.Chamados
                .Include(c => c.categorias)
                .Include(c => c.comentarios)
                .Include(c => c.grupos)
                .Include(c => c.logs)
                .Include(c => c.prioridades)
                .SingleOrDefaultAsync(m => m.idChamado == id);
            if (chamados == null)
            {
                return NotFound();
            }

            return View(chamados);
        }

        // POST: chamados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chamados = await _context.Chamados.SingleOrDefaultAsync(m => m.idChamado == id);
            _context.Chamados.Remove(chamados);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool chamadosExists(int id)
        {
            return _context.Chamados.Any(e => e.idChamado == id);
        }
    }
}
