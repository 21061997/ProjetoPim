using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Models
{
    public class Clinicas
    {
        [Key]
        public int idClinica { get; set; }
        public string telefone { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }




    }
}
