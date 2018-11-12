using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HelpDeskLogin.Data.Migrations
{
    public partial class update9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Logs_logsId",
                table: "Chamados");

            migrationBuilder.DropIndex(
                name: "IX_Chamados_logsId",
                table: "Chamados");

            migrationBuilder.DropColumn(
                name: "logsId",
                table: "Chamados");

            migrationBuilder.AddColumn<int>(
                name: "ChamadosidChamado",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "chamdosId",
                table: "Logs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Log",
                table: "Chamados",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ChamadosidChamado",
                table: "Logs",
                column: "ChamadosidChamado");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Chamados_ChamadosidChamado",
                table: "Logs",
                column: "ChamadosidChamado",
                principalTable: "Chamados",
                principalColumn: "idChamado",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Chamados_ChamadosidChamado",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_ChamadosidChamado",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ChamadosidChamado",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "chamdosId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Log",
                table: "Chamados");

            migrationBuilder.AddColumn<int>(
                name: "logsId",
                table: "Chamados",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Chamados_logsId",
                table: "Chamados",
                column: "logsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Logs_logsId",
                table: "Chamados",
                column: "logsId",
                principalTable: "Logs",
                principalColumn: "idLog",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
