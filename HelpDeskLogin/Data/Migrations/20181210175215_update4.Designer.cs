﻿// <auto-generated />
using System;
using HelpDeskLogin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelpDeskLogin.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181210175215_update4")]
    partial class update4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HelpDeskLogin.Models.Arquivos", b =>
                {
                    b.Property<int>("idArquivo")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Arquivo");

                    b.Property<DateTime>("DH_Cadastro");

                    b.Property<string>("NomeArquivo");

                    b.Property<int>("chamdosId");

                    b.HasKey("idArquivo");

                    b.HasIndex("chamdosId");

                    b.ToTable("Arquivos");
                });

            modelBuilder.Entity("HelpDeskLogin.Models.categorias", b =>
                {
                    b.Property<int>("idCategoria")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ativo");

                    b.Property<string>("categoria");

                    b.Property<string>("descricao");

                    b.HasKey("idCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("HelpDeskLogin.Models.chamados", b =>
                {
                    b.Property<int>("idChamado")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DH_Abertura");

                    b.Property<DateTime>("DH_Fechamento");

                    b.Property<int?>("FuncionarioId");

                    b.Property<string>("Log");

                    b.Property<int>("UsuarioId");

                    b.Property<int>("categoriasId");

                    b.Property<string>("comentario");

                    b.Property<string>("descricao");

                    b.Property<int>("gruposId");

                    b.Property<int>("prioridadesId");

                    b.Property<string>("status");

                    b.HasKey("idChamado");

                    b.HasIndex("FuncionarioId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("categoriasId");

                    b.HasIndex("gruposId");

                    b.HasIndex("prioridadesId");

                    b.ToTable("Chamados");
                });

            modelBuilder.Entity("HelpDeskLogin.Models.Clinicas", b =>
                {
                    b.Property<int>("idClinica")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("bairro");

                    b.Property<string>("cep");

                    b.Property<string>("cidade");

                    b.Property<string>("logradouro");

                    b.Property<string>("nome");

                    b.Property<string>("telefone");

                    b.Property<string>("uf");

                    b.HasKey("idClinica");

                    b.ToTable("Clinicas");
                });

            modelBuilder.Entity("HelpDeskLogin.Models.comentarios", b =>
                {
                    b.Property<int>("idComentario")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DHComentario");

                    b.Property<int>("chamdosId");

                    b.Property<string>("comentario");

                    b.HasKey("idComentario");

                    b.HasIndex("chamdosId");

                    b.ToTable("Comentarios");
                });

            modelBuilder.Entity("HelpDeskLogin.Models.Funcionario", b =>
                {
                    b.Property<int>("IdFuncionario")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("GrupoId");

                    b.Property<int>("PessoaId");

                    b.HasKey("IdFuncionario");

                    b.HasIndex("GrupoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("HelpDeskLogin.Models.grupos", b =>
                {
                    b.Property<int>("idGrupo")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ativo");

                    b.Property<string>("descricao");

                    b.Property<string>("grupo");

                    b.HasKey("idGrupo");

                    b.ToTable("grupos");
                });

            modelBuilder.Entity("HelpDeskLogin.Models.logs", b =>
                {
                    b.Property<int>("idLog")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Log");

                    b.Property<int>("chamdosId");

                    b.HasKey("idLog");

                    b.HasIndex("chamdosId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("HelpDeskLogin.Models.Perfil", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Ativo");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime>("DH_Criacao");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Perfil");
                });

            modelBuilder.Entity("HelpDeskLogin.Models.Pessoas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasColumnName("EmailAddress")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nome");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Pessoa");
                });

            modelBuilder.Entity("HelpDeskLogin.Models.prioridades", b =>
                {
                    b.Property<int>("idPrioridade")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("ativo");

                    b.Property<string>("descricao");

                    b.Property<string>("prioridade");

                    b.HasKey("idPrioridade");

                    b.ToTable("Prioridades");
                });

            modelBuilder.Entity("HelpDeskLogin.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClinicaId");

                    b.Property<int>("PessoaId");

                    b.HasKey("IdUsuario");

                    b.HasIndex("ClinicaId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserToken");
                });

            modelBuilder.Entity("HelpDeskLogin.Models.Arquivos", b =>
                {
                    b.HasOne("HelpDeskLogin.Models.chamados", "Chamados")
                        .WithMany("arquivos")
                        .HasForeignKey("chamdosId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HelpDeskLogin.Models.chamados", b =>
                {
                    b.HasOne("HelpDeskLogin.Models.Funcionario", "Funcionario")
                        .WithMany()
                        .HasForeignKey("FuncionarioId");

                    b.HasOne("HelpDeskLogin.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpDeskLogin.Models.categorias", "categorias")
                        .WithMany("chamados")
                        .HasForeignKey("categoriasId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpDeskLogin.Models.grupos", "grupos")
                        .WithMany()
                        .HasForeignKey("gruposId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpDeskLogin.Models.prioridades", "prioridades")
                        .WithMany("chamados")
                        .HasForeignKey("prioridadesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HelpDeskLogin.Models.comentarios", b =>
                {
                    b.HasOne("HelpDeskLogin.Models.chamados", "Chamados")
                        .WithMany("comentarios")
                        .HasForeignKey("chamdosId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HelpDeskLogin.Models.Funcionario", b =>
                {
                    b.HasOne("HelpDeskLogin.Models.grupos", "Grupos")
                        .WithMany("Funcionarios")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpDeskLogin.Models.Pessoas", "Pessoas")
                        .WithMany("Funcionarios")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HelpDeskLogin.Models.logs", b =>
                {
                    b.HasOne("HelpDeskLogin.Models.chamados", "Chamados")
                        .WithMany("logs")
                        .HasForeignKey("chamdosId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HelpDeskLogin.Models.Usuario", b =>
                {
                    b.HasOne("HelpDeskLogin.Models.Clinicas", "Clinicas")
                        .WithMany("Usuarios")
                        .HasForeignKey("ClinicaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpDeskLogin.Models.Pessoas", "Pessoas")
                        .WithMany("Usuarios")
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("HelpDeskLogin.Models.Perfil")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("HelpDeskLogin.Models.Pessoas")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("HelpDeskLogin.Models.Pessoas")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("HelpDeskLogin.Models.Perfil")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpDeskLogin.Models.Pessoas")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("HelpDeskLogin.Models.Pessoas")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
