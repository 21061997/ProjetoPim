using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskLogin.Models.Enum;

namespace HelpDeskLogin.Models
{
    public class logs
    {
        [Key]
        public int idLog { get; set; }
        public String Log { get; set; }

        [NotMapped]
        public TipoLogEnum Tipo { get; set; }
        [NotMapped]
        public int IdUsuario { get; set; }




        public int chamdosId { get; set; }
        public chamados Chamados { get; set; }



    }
}
