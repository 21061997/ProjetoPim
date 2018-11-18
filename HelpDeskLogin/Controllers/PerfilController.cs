using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskLogin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HelpDeskLogin.Data;

namespace HelpDeskLogin.Controllers
{
    public class PerfilController : Controller
    {
        private readonly RoleManager<Perfil> _roleManager;
        private readonly ApplicationDbContext _context;

        public PerfilController(ApplicationDbContext context)
        {
            _context = context;
        }



        public IActionResult Index()
        {
            //var perfil = _roleManager.Roles;
            var retorno = _context.Roles;

            if (retorno == null)
            {
                return View();
            }

            //Converte do entity para a model Perfil
            //var listaRetorno = new List<Perfil>();
            //foreach (var item in retorno)
            //{
            //    var destino = new Perfil();
            //    destino.Name = item.Name;
            //    destino.Ativo = item.Ativo;
            //    destino.DH_Criacao = item.DH_Criacao;
            //    listaRetorno.Add(destino);
            //}


            return View(retorno);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Perfil model)
        {
            if (!ModelState.IsValid)
                return Index();

            var perfil = new Perfil { Name = model.Name, DH_Criacao = DateTime.Now, Ativo = model.Ativo, NormalizedName = model.Name.Normalize() };

            _context.Add(model);
            await _context.SaveChangesAsync();

            //var result = await _roleManager.CreateAsync(perfil);

            //if (!result.Succeeded)
            //{
            //    throw new Exception("Erro ao criar perfil");
            //}

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> GetPerfil(string Id)
        {
            var perfil = await _roleManager.FindByIdAsync(Id);

            if (perfil != null)
            {
                return View(perfil);
            }

            return null;
        }


    }
}