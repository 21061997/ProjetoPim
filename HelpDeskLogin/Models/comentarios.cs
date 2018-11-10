using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Models
{
    public class comentarios
    {

        [Key]
        public int idComentario { get; set; }
        public String comentario { get; set; }
        public DateTime DHComentario { get; set; }

        public ICollection<chamados> chamados { get; set; }


    }
}
