using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Models
{
    public class chamados
    {
        [Key]
        [Display(Name = "Numero")]
        public int idChamado { get; set; }
        [Display(Name = "Data de Abertura")]
        public DateTime DH_Abertura { get; set; }
        [Display(Name = "Data de Fechamento:")]
        public DateTime DH_Fechamento { get; set; }
        [Display(Name = "Descrição")]
        public String descricao { get; set; }
        [NotMapped]
        [Display(Name = "Arquivo")]
        public string arquivo { get; set; }
        [NotMapped]
        public string  CaminhoArquivo { get ; set ; }
        [NotMapped]
        [Display(Name = "Arquivo")]
        public IFormFile Arquivo { get; set; }
        [Display(Name = "Log")]
        public String Log { get; set; }
        [Display(Name = "Comentario")]
        public String comentario { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }


        /*Fazendo a associação de categorias*/

        public int categoriasId { get; set; }
        [Display(Name = "Comentario")]
        public categorias categorias { get; set; }

        /*Fazendo a associação de comentarios*/

        public ICollection<comentarios> comentarios { get; set; }


        /*Fazendo a associação de grupos*/

        public int gruposId { get; set; }
        [Display(Name = "Grupo")]
        public grupos grupos { get; set; }


        /*Fazendo a associação de prioridades*/

        public int prioridadesId { get; set; }
        [Display(Name = "Prioridade")]
        public prioridades prioridades { get; set; }


        /*Fazendo a associação de arquivos*/

        public ICollection<Arquivos> arquivos { get; set; }

        /*Fazendo a associação de logs*/

        public ICollection<logs> logs { get; set; } // Foi alteração no chamdosController, foi feito a referencia de log


        //Listas utilizadas apenas na view
        [NotMapped]
        public IEnumerable<Arquivos> ListaArquivos { get; set; }
        [NotMapped]
        public IEnumerable<chamados> ListaChamados { get; set; }









    }
}
