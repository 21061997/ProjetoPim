using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace HelpDeskLogin.Data.Migrations
{
    public partial class Update16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_User_PessoasId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaim_User_UserId",
                table: "UserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_User_UserId",
                table: "UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToken_User_UserId",
                table: "UserToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_User_PessoasId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Pessoa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Pessoa_PessoasId",
                table: "Funcionario",
                column: "PessoasId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaim_Pessoa_UserId",
                table: "UserClaim",
                column: "UserId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_Pessoa_UserId",
                table: "UserLogin",
                column: "UserId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_Pessoa_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToken_Pessoa_UserId",
                table: "UserToken",
                column: "UserId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Pessoa_PessoasId",
                table: "Usuario",
                column: "PessoasId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Pessoa_PessoasId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_UserClaim_Pessoa_UserId",
                table: "UserClaim");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLogin_Pessoa_UserId",
                table: "UserLogin");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRole_Pessoa_UserId",
                table: "UserRole");

            migrationBuilder.DropForeignKey(
                name: "FK_UserToken_Pessoa_UserId",
                table: "UserToken");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Pessoa_PessoasId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoa",
                table: "Pessoa");

            migrationBuilder.RenameTable(
                name: "Pessoa",
                newName: "User");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_User_PessoasId",
                table: "Funcionario",
                column: "PessoasId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserClaim_User_UserId",
                table: "UserClaim",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogin_User_UserId",
                table: "UserLogin",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRole_User_UserId",
                table: "UserRole",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserToken_User_UserId",
                table: "UserToken",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_User_PessoasId",
                table: "Usuario",
                column: "PessoasId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
