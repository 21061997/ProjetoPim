using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Models
{
    public class categorias
    {

        [Key]
        public int idCategoria { get; set; }
        public String categoria { get; set; }
        public String descricao { get; set; }
        public bool ativo { get; set; }

        public ICollection<chamados> chamados { get; set; }

        




    }
}
