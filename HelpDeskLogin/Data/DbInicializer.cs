using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskLogin.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDeskLogin.Data
{
    public class DbInicializer
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<Perfil> _roleManager;
        private readonly UserManager<Pessoas> _userManager;

        public DbInicializer(ApplicationDbContext context, UserManager<Pessoas> userManager, RoleManager<Perfil> roleManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;

        }


        public void Initializer(IApplicationBuilder  app)
        {

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }

            var qtdGrupos = _context.grupos.AsQueryable().Count();
            var qtdCategorias = _context.Categoria.AsQueryable().Count();
            var qtdPrioridades = _context.Prioridades.AsQueryable().Count();
            var qtdPerfil = _context.Roles.AsQueryable().Count();
            var usuarioAdm = _context.Users.Any(x => x.UserName == "admin@admin.com.br");


            if (qtdPerfil == 0)
            {
                //cria perfil padrão, admin
                var perfilAdmin = new Perfil { Name = PerfilDefault.PERFIL_DEFAULT, DH_Criacao = DateTime.Now, Ativo = true, NormalizedName = PerfilDefault.PERFIL_DEFAULT.Normalize() };
                _context.Add(perfilAdmin);
                _context.SaveChangesAsync();

                //cria perfil de usuarios do sistema
                var perfilUsuario = new Perfil { Name = PerfilDefault.PERFIL_USUARIO, DH_Criacao = DateTime.Now, Ativo = true, NormalizedName = PerfilDefault.PERFIL_USUARIO.Normalize() };
                _context.Add(perfilUsuario);
                _context.SaveChangesAsync();

                //cria perfil de funcionarios
                var perfilFuncionario = new Perfil { Name = PerfilDefault.PERFIL_FUNCIONARIO, DH_Criacao = DateTime.Now, Ativo = true, NormalizedName = PerfilDefault.PERFIL_FUNCIONARIO.Normalize() };
                _context.Add(perfilFuncionario);
                var resultado = _context.SaveChangesAsync().Result;
            }

            if (qtdGrupos == 0)
            {
                var listaGrupos = new List<grupos>();
                var grupoAdmin = new grupos(){
                    grupo = "Administradores",
                    descricao = "Grupo destinado a adiministradores do sistema",
                    ativo = true
                };
                listaGrupos.Add(grupoAdmin);

                var grupoPrimeiro = new grupos()
                {
                    grupo = "Atendentes de 1º nivel",
                    descricao = "Grupo destinado a atendentes de primeiro nivel",
                    ativo = true
                };
                listaGrupos.Add(grupoPrimeiro);

                var grupoSegundo = new grupos()
                {
                    grupo = "Atendentes de 2º nivel",
                    descricao = "Grupo destinado a atendentes de segundo nivel",
                    ativo = true
                };
                listaGrupos.Add(grupoSegundo);

                _context.grupos.AddRange(listaGrupos);
                _context.SaveChangesAsync();
            }

            if (qtdCategorias == 0)
            {
                var listaCategorias = new List<categorias>();

                var catSuporteH = new categorias()
                {
                    ativo = true,
                    categoria = "Suporte - Hardware",
                    descricao = "Suporte para hardwares diversos"
                };
                listaCategorias.Add(catSuporteH);


                var catSuporteS = new categorias()
                {
                    ativo = true,
                    categoria = "Suporte - Software",
                    descricao = "Suporte para softwares diversos"
                };
                listaCategorias.Add(catSuporteS);

                var catSuporteT = new categorias()
                {
                    ativo = true,
                    categoria = "Suporte - Telecom",
                    descricao = "Suporte para Telecom"
                };
                listaCategorias.Add(catSuporteT);

                _context.Categoria.AddRange(listaCategorias);
                _context.SaveChangesAsync();
            }

            if (qtdPrioridades == 0)
            {
                var listaPrioridades = new List<prioridades>();

                var prioridadeA = new prioridades()
                {
                    ativo = true,
                    descricao = "Prioridade alta",
                    prioridade = "Alta"
                };
                listaPrioridades.Add(prioridadeA);

                var prioridadeM = new prioridades()
                {
                    ativo = true,
                    descricao = "Prioridade Media",
                    prioridade = "Media"
                };
                listaPrioridades.Add(prioridadeM);


                var prioridadeB = new prioridades()
                {
                    ativo = true,
                    descricao = "Prioridade Baixa",
                    prioridade = "Baixa"
                };
                listaPrioridades.Add(prioridadeB);

                _context.Prioridades.AddRange(listaPrioridades);
                _context.SaveChangesAsync();
            }

            if (!usuarioAdm)
            {
                CreateUser();
            }
            
            
        }


        private void CreateUser()
        {
          
                var user = new Pessoas { UserName = "admin@admin.com.br", Email = "admin@admin.com.br" };
                var result =  _userManager.CreateAsync(user, "Admin@123").Result;
                if (result.Succeeded)
                {
                    //recupera id do perfil admin
                    var perfil = _context.Roles.Where(x => x.Name == PerfilDefault.PERFIL_DEFAULT).FirstOrDefault();

                    //criar vinculo de pessoa com o perfil e salvar na tabela UserRole vulgo UserPerfil
                    var userRole = new IdentityUserRole<int>();
                    userRole.UserId = user.Id;
                    userRole.RoleId = perfil.Id;
                    _context.UserRoles.Add(userRole);
                    var teste2 = _context.SaveChanges();

                    //recupera id do grupo administradores
                    var grupo = _context.grupos.Where(x => x.grupo == "Administradores").FirstOrDefault();

                    //Salvar grupo e id pessoa na tabela funcionario
                    var funcionario = new Funcionario();
                    funcionario.GrupoId = grupo.idGrupo;
                    funcionario.PessoaId = user.Id;
                     _context.Funcionario.Add(funcionario);
                    var teste =  _context.SaveChanges();
                }
        }
        
    }
}
