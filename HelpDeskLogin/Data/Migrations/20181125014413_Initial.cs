using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HelpDeskLogin.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    idCategoria = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ativo = table.Column<bool>(nullable: false),
                    categoria = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.idCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Clinicas",
                columns: table => new
                {
                    idClinica = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    bairro = table.Column<string>(nullable: true),
                    cep = table.Column<string>(nullable: true),
                    cidade = table.Column<string>(nullable: true),
                    logradouro = table.Column<string>(nullable: true),
                    nome = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true),
                    uf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clinicas", x => x.idClinica);
                });

            migrationBuilder.CreateTable(
                name: "grupos",
                columns: table => new
                {
                    idGrupo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ativo = table.Column<bool>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    grupo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupos", x => x.idGrupo);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Ativo = table.Column<bool>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    DH_Criacao = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prioridades",
                columns: table => new
                {
                    idPrioridade = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ativo = table.Column<bool>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    prioridade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridades", x => x.idPrioridade);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaim_Perfil_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    IdFuncionario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    GrupoId = table.Column<int>(nullable: false),
                    GruposidGrupo = table.Column<int>(nullable: true),
                    PessoaId = table.Column<int>(nullable: false),
                    PessoasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.IdFuncionario);
                    table.ForeignKey(
                        name: "FK_Funcionario_grupos_GruposidGrupo",
                        column: x => x.GruposidGrupo,
                        principalTable: "grupos",
                        principalColumn: "idGrupo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionario_Pessoa_PessoasId",
                        column: x => x.PessoasId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaim_Pessoa_UserId",
                        column: x => x.UserId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogin", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogin_Pessoa_UserId",
                        column: x => x.UserId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRole_Perfil_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Perfil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Pessoa_UserId",
                        column: x => x.UserId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserToken",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserToken", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserToken_Pessoa_UserId",
                        column: x => x.UserId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClinicaId = table.Column<int>(nullable: false),
                    ClinicasidClinica = table.Column<int>(nullable: true),
                    PessoaId = table.Column<int>(nullable: false),
                    PessoasId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Clinicas_ClinicasidClinica",
                        column: x => x.ClinicasidClinica,
                        principalTable: "Clinicas",
                        principalColumn: "idClinica",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuario_Pessoa_PessoasId",
                        column: x => x.PessoasId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chamados",
                columns: table => new
                {
                    idChamado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DH_Abertura = table.Column<DateTime>(nullable: false),
                    DH_Fechamento = table.Column<DateTime>(nullable: false),
                    FuncionarioId = table.Column<int>(nullable: false),
                    Log = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<int>(nullable: false),
                    categoriasId = table.Column<int>(nullable: false),
                    comentario = table.Column<string>(nullable: true),
                    descricao = table.Column<string>(nullable: true),
                    gruposId = table.Column<int>(nullable: false),
                    prioridadesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamados", x => x.idChamado);
                    table.ForeignKey(
                        name: "FK_Chamados_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "IdFuncionario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamados_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamados_Categoria_categoriasId",
                        column: x => x.categoriasId,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamados_grupos_gruposId",
                        column: x => x.gruposId,
                        principalTable: "grupos",
                        principalColumn: "idGrupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamados_Prioridades_prioridadesId",
                        column: x => x.prioridadesId,
                        principalTable: "Prioridades",
                        principalColumn: "idPrioridade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    idArquivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arquivo = table.Column<string>(nullable: true),
                    ChamadosidChamado = table.Column<int>(nullable: true),
                    DH_Cadastro = table.Column<DateTime>(nullable: false),
                    NomeArquivo = table.Column<string>(nullable: true),
                    chamdosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.idArquivo);
                    table.ForeignKey(
                        name: "FK_Arquivos_Chamados_ChamadosidChamado",
                        column: x => x.ChamadosidChamado,
                        principalTable: "Chamados",
                        principalColumn: "idChamado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    idComentario = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChamadosidChamado = table.Column<int>(nullable: true),
                    DHComentario = table.Column<DateTime>(nullable: false),
                    chamdosId = table.Column<int>(nullable: false),
                    comentario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.idComentario);
                    table.ForeignKey(
                        name: "FK_Comentarios_Chamados_ChamadosidChamado",
                        column: x => x.ChamadosidChamado,
                        principalTable: "Chamados",
                        principalColumn: "idChamado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    idLog = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ChamadosidChamado = table.Column<int>(nullable: true),
                    Log = table.Column<string>(nullable: true),
                    chamdosId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.idLog);
                    table.ForeignKey(
                        name: "FK_Logs_Chamados_ChamadosidChamado",
                        column: x => x.ChamadosidChamado,
                        principalTable: "Chamados",
                        principalColumn: "idChamado",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_ChamadosidChamado",
                table: "Arquivos",
                column: "ChamadosidChamado");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_FuncionarioId",
                table: "Chamados",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_UsuarioId",
                table: "Chamados",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_categoriasId",
                table: "Chamados",
                column: "categoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_gruposId",
                table: "Chamados",
                column: "gruposId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_prioridadesId",
                table: "Chamados",
                column: "prioridadesId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ChamadosidChamado",
                table: "Comentarios",
                column: "ChamadosidChamado");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_GruposidGrupo",
                table: "Funcionario",
                column: "GruposidGrupo");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_PessoasId",
                table: "Funcionario",
                column: "PessoasId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ChamadosidChamado",
                table: "Logs",
                column: "ChamadosidChamado");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "Perfil",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Pessoa",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Pessoa",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaim_RoleId",
                table: "RoleClaim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaim_UserId",
                table: "UserClaim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogin_UserId",
                table: "UserLogin",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ClinicasidClinica",
                table: "Usuario",
                column: "ClinicasidClinica");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PessoasId",
                table: "Usuario",
                column: "PessoasId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "RoleClaim");

            migrationBuilder.DropTable(
                name: "UserClaim");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "UserToken");

            migrationBuilder.DropTable(
                name: "Chamados");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Funcionario");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Prioridades");

            migrationBuilder.DropTable(
                name: "grupos");

            migrationBuilder.DropTable(
                name: "Clinicas");

            migrationBuilder.DropTable(
                name: "Pessoa");
        }
    }
}
