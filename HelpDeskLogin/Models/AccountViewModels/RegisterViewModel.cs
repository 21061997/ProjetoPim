using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HelpDeskLogin.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Telefone")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve conter ao menos {2} e no máximo {1} caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não correspondem, tente novamente!")]
        public string ConfirmPassword { get; set; }

        public int Perfil { get; set; }
        public IEnumerable<Perfil> ListaPerfil { get; set; }
        public int GrupoId { get; set; }
        public IEnumerable<grupos> ListaGrupos { get; set; }
        public int ClinicaId { get; set; }
        public IEnumerable<Clinicas> ListaClinicas { get; set; }
    }
}
