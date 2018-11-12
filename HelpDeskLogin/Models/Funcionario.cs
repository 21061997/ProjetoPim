using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Models
{
    public class Funcionario
    {

        [Key]
        public int IdFuncionario { get; set; }


        /*Fazendo a associação de grups*/
        public int GrupoId { get; set; }
        public grupos Grupos { get; set; }

        /*Fazendo a associação de pessoas*/
        public int PessoaId { get; set; }
        public Pessoas Pessoas { get; set; }
    }
}
