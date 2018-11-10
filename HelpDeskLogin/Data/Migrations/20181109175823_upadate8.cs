using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HelpDeskLogin.Data.Migrations
{
    public partial class upadate8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Arquivos_arquivosId",
                table: "Chamados");

            migrationBuilder.DropIndex(
                name: "IX_Chamados_arquivosId",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "arquivosId",
                table: "Chamados");

            migrationBuilder.AddColumn<int>(
                name: "ChamadosidChamado",
                table: "Arquivos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "chamdosId",
                table: "Arquivos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_ChamadosidChamado",
                table: "Arquivos",
                column: "ChamadosidChamado");

            migrationBuilder.AddForeignKey(
                name: "FK_Arquivos_Chamados_ChamadosidChamado",
                table: "Arquivos",
                column: "ChamadosidChamado",
                principalTable: "Chamados",
                principalColumn: "idChamado",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquivos_Chamados_ChamadosidChamado",
                table: "Arquivos");

            migrationBuilder.DropIndex(
                name: "IX_Arquivos_ChamadosidChamado",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "ChamadosidChamado",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "chamdosId",
                table: "Arquivos");

            migrationBuilder.AddColumn<int>(
                name: "arquivosId",
                table: "Chamados",
                nullable: false,
                defaultValue: 0);

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
    }
}
