using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Models
{
    public class prioridades
    {
        [Key]
        public int idPrioridade { get; set; }
        public string prioridade { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }

        public ICollection<chamados> chamados { get; set; }










    }
}
