using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HelpDeskLogin.Models;

namespace HelpDeskLogin.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.

        }

        /* Setando as Model's no banco de dados*/
        public DbSet<categorias> Categoria { get; set; }
        public DbSet<prioridades> Prioridades { get; set; }
        public DbSet<grupos> grupos { get; set; }
        public DbSet<logs> Logs { set; get; }
        public DbSet<comentarios> Comentarios { set; get; }
        public DbSet<chamados> Chamados { set; get; }
        public DbSet<Arquivos> Arquivos { set; get; }
        public DbSet<Clinicas> Clinicas { set; get; }













    }
}
