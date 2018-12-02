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
using HelpDeskLogin.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace HelpDeskLogin.Controllers
{
    public class chamadosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Pessoas> _userManager;

        public chamadosController(ApplicationDbContext context, UserManager<Pessoas> usermanager)
        {
            _context = context;
            _userManager = usermanager;
        }

        // GET: chamados
        public async Task<IActionResult> Index()
        {
            var chamadosAbertos = _context.Chamados.Where(x => x.DH_Fechamento == DateTime.MinValue);
            var model = new chamados();

            model.ListaChamados = chamadosAbertos;

            return View(model);
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

            var listaArquivos = await _context.Arquivos.Where(m => m.chamdosId == id).ToListAsync();
            chamados.ListaArquivos = listaArquivos;

            if (chamados == null)
            {
                return NotFound();
            }

            return View(chamados);
        }

        // GET: chamados/Create
        [Authorize]
        public IActionResult Create()
        {


            ViewBag.categoriasId = new SelectList(_context.Categoria.ToList(), "idCategoria", "categoria");
            ViewBag.gruposId = new SelectList(_context.grupos.ToList(), "idGrupo", "grupo");
            ViewBag.prioridadesId = new SelectList(_context.Prioridades.ToList(), "idPrioridade", "prioridade");

            //ViewData["categoriasId"] = new SelectList(_context.Categoria, "idCategoria", "idCategoria");
            ViewData["comentariosId"] = new SelectList(_context.Comentarios, "idComentario", "idComentario");
            //ViewData["gruposId"] = new SelectList(_context.grupos, "idGrupo", "idGrupo");
            ViewData["logsId"] = new SelectList(_context.Logs, "idLog", "idLog");
            //ViewData["prioridadesId"] = new SelectList(_context.Prioridades, "idPrioridade", "idPrioridade");
            return View();
        }

        // POST: chamados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Abre chamado somente de usuarios
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("idChamado,DH_Abertura,DH_Fechamento,descricao,categoriasId,comentariosId,logsId,gruposId,prioridadesId,Arquivo")] chamados chamados)
        {
            if (ModelState.IsValid)
            {

                //Se o chamdo for aberto pelo proprio usuario pega o id pelo usuario logado
                if (chamados.UsuarioId == 0)
                {
                    //recupera usuario logado e busca no banco de dados
                    var userName = User.Identity.Name;
                    var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
                    var usuario = await _context.Usuario.FirstOrDefaultAsync(x => x.PessoaId == user.Id);
                    chamados.UsuarioId = usuario.IdUsuario;
                }
                


                chamados.DH_Abertura = DateTime.Now;
                _context.Add(chamados);
                await _context.SaveChangesAsync();

                if (chamados.Arquivo != null)
                {
                    var retorno = Upload(chamados.Arquivo);
                    var arquivo = new Arquivos();
                    arquivo.Arquivo = string.Format(@"{0}\{1}{2}", retorno.CaminhoDBArquivo, retorno.NomeArquivo, retorno.ExtensaoArquivo);
                    arquivo.NomeArquivo = chamados.Arquivo.FileName;
                    arquivo.DH_Cadastro = DateTime.Now;
                    arquivo.chamdosId = chamados.idChamado;

                    //salva
                    _context.Arquivos.Add(arquivo);
                    await _context.SaveChangesAsync();
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
            ViewBag.prioridadesId = new SelectList(_context.Prioridades.ToList(), "idPrioridade", "prioridade", chamados.prioridadesId);

            ViewData["comentariosId"] = new SelectList(_context.Comentarios, "idComentario", "idComentario", chamados.comentarios);
            //ViewData["gruposId"] = new SelectList(_context.grupos.ToList(), "idGrupo", "grupos", chamados.gruposId);
            ViewData["logsId"] = new SelectList(_context.Logs, "idLog", "idLog", chamados.logs);
            //ViewData["prioridadesId"] = new SelectList(_context.Prioridades, "idPrioridade", "idPrioridade", chamados.prioridadesId);
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
            ViewData["comentariosId"] = new SelectList(_context.Comentarios, "idComentario", "idComentario", chamados.comentarios);
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

        public async Task<IActionResult> AssinarChamado(int id)
        {
            //recupera usuario logado e busca no banco de dados
            var userName = User.Identity.Name;
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            var usuario = await _context.Funcionario.FirstOrDefaultAsync(x => x.PessoaId == user.Id);

            var chamado = await _context.Chamados.FirstOrDefaultAsync(x => x.idChamado == id);
            chamado.FuncionarioId = usuario.IdFuncionario;
            _context.Chamados.Update(chamado);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> MeusChamadosTecnico()
        {
            var userId = _userManager.GetUserId(User);
            var funcionario = _context.Funcionario.FirstOrDefault(x => x.PessoaId == Int32.Parse(userId));

            var chamados = _context.Chamados.Where(x => x.FuncionarioId == funcionario.IdFuncionario).AsQueryable();

            var model = new chamados();
            model.ListaChamados = chamados;


            return View(model);
        }

        public async Task<IActionResult> ChamadosFechados()
        {

            var chamados = _context.Chamados.Where(x => x.DH_Fechamento != DateTime.MinValue).AsQueryable();

            var model = new chamados();
            model.ListaChamados = chamados;


            return View(model);
        }


        private bool chamadosExists(int id)
        {
            return _context.Chamados.Any(e => e.idChamado == id);
        }

        public IActionResult BaixarAnexo(int id)
        {
            var arquivos = _context.Arquivos.FirstOrDefault(m => m.idArquivo == id);

            if (arquivos == null)
                throw new Exception("Arquivo não localizado");

            return BaixarArquivo(arquivos.Arquivo);
        }

        //metodo responsavel por fazer todo o tratamento do arquivo, copiar e retornoar o nome e caminho
        public Arquivo Upload(IFormFile arquivo)
        {
            try
            {
                String ext = Path.GetExtension(arquivo.FileName);
                string pathArquivo = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\arquivos");

                pathArquivo = Path.Combine(pathArquivo, DateTime.Now.ToString("MMyyyy"));
                if (!Directory.Exists(pathArquivo))
                    Directory.CreateDirectory(pathArquivo);

                var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "_");

                pathArquivo = string.Format(@"{0}\{1}{2}", pathArquivo, nomeArquivo, ext);

                using (var stream = new FileStream(pathArquivo, FileMode.Create))
                {
                    arquivo.CopyTo(stream);
                }

                return new Arquivo()
                {
                    CaminhoCompletoArquivo = pathArquivo,
                    CaminhoDBArquivo = DateTime.Now.ToString("MMyyyy"),
                    NomeArquivo = nomeArquivo,
                    ExtensaoArquivo = ext,
                    FoiSalvoEmDisco = true
                };
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Erro ao tentar realizar o upload do arquivo {0}", arquivo.FileName), e);
            }
        }


        public IActionResult BaixarArquivo(string caminhoArquivo)
        {
            if (string.IsNullOrWhiteSpace(caminhoArquivo))
            {
                throw new Exception("Caminho do arquivo nulo!");
            }

            try
            {
                String pathArquivo = Path.Combine("wwwroot\\arquivos");
                pathArquivo = Path.Combine(pathArquivo, caminhoArquivo);

                byte[] stream = System.IO.File.ReadAllBytes(pathArquivo);
                string mimeType = Arquivo.GetMimeType(pathArquivo);
                string ext = Path.GetExtension(pathArquivo).ToLower();

                var nomeArquivo = string.Format("Anexo_{0}{1}", DateTime.Now.ToString("dd_MM_yyyy"), ext);

                return File(stream, mimeType, nomeArquivo);
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Erro ao tentar baixar o arquivo"), e);
            }
        }
    }
}
