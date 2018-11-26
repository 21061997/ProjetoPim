using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HelpDeskLogin.Models
{
    public class Perfil : IdentityRole<int>
    {
        [Required]
        [StringLength(256, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Perfil")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Data de criação")]
        public DateTime DH_Criacao { get; set; }

        [Required]
        [Display(Name = "Status")]
        public Boolean Ativo { get; set; }
    }

    public static class PerfilDefault
    {
        public const string PERFIL_DEFAULT = "Admin";
        public const string PERFIL_USUARIO = "Usuarios";
        public const string PERFIL_FUNCIONARIO = "Funcionarios";
    }
}
