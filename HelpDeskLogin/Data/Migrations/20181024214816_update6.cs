using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HelpDeskLogin.Data.Migrations
{
    public partial class update6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chamados",
                columns: table => new
                {
                    idChamado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DH_Abertura = table.Column<DateTime>(nullable: false),
                    DH_Fechamento = table.Column<DateTime>(nullable: false),
                    categoriasId = table.Column<int>(nullable: false),
                    comentariosId = table.Column<int>(nullable: false),
                    descricao = table.Column<string>(nullable: true),
                    gruposId = table.Column<int>(nullable: false),
                    logsId = table.Column<int>(nullable: false),
                    prioridadesId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chamados", x => x.idChamado);
                    table.ForeignKey(
                        name: "FK_Chamados_Categoria_categoriasId",
                        column: x => x.categoriasId,
                        principalTable: "Categoria",
                        principalColumn: "idCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamados_Comentarios_comentariosId",
                        column: x => x.comentariosId,
                        principalTable: "Comentarios",
                        principalColumn: "idComentario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamados_grupos_gruposId",
                        column: x => x.gruposId,
                        principalTable: "grupos",
                        principalColumn: "idGrupo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamados_Logs_logsId",
                        column: x => x.logsId,
                        principalTable: "Logs",
                        principalColumn: "idLog",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Chamados_Prioridades_prioridadesId",
                        column: x => x.prioridadesId,
                        principalTable: "Prioridades",
                        principalColumn: "idPrioridade",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_categoriasId",
                table: "Chamados",
                column: "categoriasId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_comentariosId",
                table: "Chamados",
                column: "comentariosId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_gruposId",
                table: "Chamados",
                column: "gruposId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_logsId",
                table: "Chamados",
                column: "logsId");

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_prioridadesId",
                table: "Chamados",
                column: "prioridadesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chamados");
        }
    }
}
