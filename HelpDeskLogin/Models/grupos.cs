using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Models
{
    public class grupos
    {
        [Key]
        public int idGrupo { get; set; }
        public String grupo { get; set; }
        public String descricao { get; set; }
        public bool ativo { get; set; }

        public ICollection<Funcionario> Funcionarios { get; set; }

    }
}
