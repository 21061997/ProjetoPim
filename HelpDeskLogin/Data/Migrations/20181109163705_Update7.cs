using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HelpDeskLogin.Data.Migrations
{
    public partial class Update7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "arquivosId",
                table: "Chamados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Arquivos",
                columns: table => new
                {
                    idArquivo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Arquivo = table.Column<string>(nullable: true),
                    DH_Cadastro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arquivos", x => x.idArquivo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_arquivosId",
                table: "Chamados",
                column: "arquivosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Arquivos_arquivosId",
                table: "Chamados",
                column: "arquivosId",
                principalTable: "Arquivos",
                principalColumn: "idArquivo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Arquivos_arquivosId",
                table: "Chamados");

            migrationBuilder.DropTable(
                name: "Arquivos");

            migrationBuilder.DropIndex(
                name: "IX_Chamados_arquivosId",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "arquivosId",
                table: "Chamados");
        }
    }
}
