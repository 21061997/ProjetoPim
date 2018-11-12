using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HelpDeskLogin.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class Pessoas : IdentityUser<int>
    {
        public string Nome { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
        public ICollection<Funcionario> Funcionarios { get; set; }
    }
}
