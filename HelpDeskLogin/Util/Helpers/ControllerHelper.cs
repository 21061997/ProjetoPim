using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskLogin.Data;
using HelpDeskLogin.Models;

namespace HelpDeskLogin.Util
{
    public class ControllerHelper
    {

        public static string RecuperaNomeCategoria(int idCategoria)
        {
            var context = new ApplicationDbContext();
            var categorias = context.Categoria.AsQueryable();

            var categoria = categorias.FirstOrDefault(x => x.idCategoria == idCategoria);

            if (categoria != null)
            {
                return categoria.categoria;
            }

            return "-";
        }

        public static string RecuperarNomeGrupo(int idGrupo)
        {
            var context = new ApplicationDbContext();
            var grupos = context.grupos.AsQueryable();

            var grupo = grupos.FirstOrDefault(x => x.idGrupo == idGrupo);

            if (grupo != null)
            {
                return grupo.grupo;
            }

            return " - ";
        }


        public static string RecuperarNomePrioridade(int idPrioridade)
        {
            var context = new ApplicationDbContext();
            var prioridades = context.Prioridades.AsQueryable();

            var prioridade = prioridades.FirstOrDefault(x => x.idPrioridade == idPrioridade);

            if (prioridade != null)
            {
                return prioridade.prioridade;
            }

            return " - ";
        }

        public static string RecuperarNomeUsuario(int idUsuario)
        {
            var context = new ApplicationDbContext();
            var usuario = context.Usuario.FirstOrDefault(x => x.IdUsuario == idUsuario);

            var pessoa = context.Users.FirstOrDefault(x => x.Id == usuario.PessoaId);

            if (pessoa != null)
            {
                return pessoa.Nome;
            }

            return " - ";
        }

        public static string RecuperarNomeFuncionario(int? idUsuario)
        {
            if (idUsuario == null)
            {
                return " - ";
            }
            var context = new ApplicationDbContext();
            var funcionario = context.Funcionario.FirstOrDefault(x => x.IdFuncionario == idUsuario);

            var pessoa = context.Users.FirstOrDefault(x => x.Id == funcionario.PessoaId);

            if (pessoa != null)
            {
                return pessoa.Nome;
            }

            return " - ";
        }


        public static string RecuperaNomeClinica(int? idUsuario)
        {

            if(idUsuario == null)
            {
                return "-";
            }
            var context = new ApplicationDbContext();
            //recuperar primeiro o usuario em si
            var usuario = context.Usuario.FirstOrDefault(x => x.IdUsuario == idUsuario);
            //recupera a clinica
            var clinica = context.Clinicas.FirstOrDefault(x => x.idClinica == usuario.ClinicaId );
            if (clinica != null)
            {
                return clinica.nome;
            }
            return "-";
        }


        public static string RecuperarNomePessoa(int? idUsuario)
        {
            var pessoa = new Pessoas();
            if (idUsuario == null)
            {
                return " - ";
            }
            var context = new ApplicationDbContext();
            //tenta recuperar primeiro na tabela funcionarios 
            var funcionario = context.Funcionario.FirstOrDefault(x => x.IdFuncionario == idUsuario);
            //se não encontrar procura na tabela de usuarios
            if (funcionario == null)
            {
               var usuario = context.Usuario.FirstOrDefault(x => x.IdUsuario == idUsuario);
               pessoa = context.Users.FirstOrDefault(x => x.Id == usuario.PessoaId);
            }
            else
            {
                pessoa = context.Users.FirstOrDefault(x => x.Id == funcionario.PessoaId);
            }
            
            if (pessoa != null)
            {
                return pessoa.Nome;
            }

            return " - ";
        }






    }
}
