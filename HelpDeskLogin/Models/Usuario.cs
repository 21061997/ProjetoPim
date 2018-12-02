using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        /*Fazendo a associação de pessoas*/
        [Display(Name = "Pessoa")]
        public int PessoaId { get; set; }
        public Pessoas Pessoas { get; set; }
        [Display(Name = "Clinica")]
        public int ClinicaId { get; set; }
        public Clinicas Clinicas { get; set; }

    }
}
