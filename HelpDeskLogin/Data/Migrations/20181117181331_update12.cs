using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HelpDeskLogin.Data.Migrations
{
    public partial class update12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Comentarios_comentariosId",
                table: "Chamados");

            migrationBuilder.DropIndex(
                name: "IX_Chamados_comentariosId",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "comentariosId",
                table: "Chamados");

            migrationBuilder.AddColumn<int>(
                name: "ChamadosidChamado",
                table: "Comentarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "chamdosId",
                table: "Comentarios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "comentario",
                table: "Chamados",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ChamadosidChamado",
                table: "Comentarios",
                column: "ChamadosidChamado");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Chamados_ChamadosidChamado",
                table: "Comentarios",
                column: "ChamadosidChamado",
                principalTable: "Chamados",
                principalColumn: "idChamado",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Chamados_ChamadosidChamado",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_ChamadosidChamado",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "ChamadosidChamado",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "chamdosId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "comentario",
                table: "Chamados");

            migrationBuilder.AddColumn<int>(
                name: "comentariosId",
                table: "Chamados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_comentariosId",
                table: "Chamados",
                column: "comentariosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Comentarios_comentariosId",
                table: "Chamados",
                column: "comentariosId",
                principalTable: "Comentarios",
                principalColumn: "idComentario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
