using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HelpDeskLogin.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace HelpDeskLogin.Data
{
    public class ApplicationDbContext : IdentityDbContext<Pessoas, Perfil, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.

            builder.Entity<Pessoas>().ToTable("Pessoa");

            builder.Entity<Perfil>().ToTable("Perfil");

            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim");

            builder.Entity<IdentityUserRole<int>>().ToTable("UserRole");

            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin");

            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim");

            builder.Entity<IdentityUserToken<int>>().ToTable("UserToken");

            builder.Entity<Pessoas>(b =>
            {
                b.Property(au => au.Email)
                    .HasColumnName("EmailAddress");
            });

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
        public DbSet<Funcionario> Funcionario { get; set; }













    }
}
