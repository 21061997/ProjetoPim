using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDeskLogin.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquivos_Chamados_ChamadosidChamado",
                table: "Arquivos");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Chamados_ChamadosidChamado",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_grupos_GruposidGrupo",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Pessoa_PessoasId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Chamados_ChamadosidChamado",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Clinicas_ClinicasidClinica",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Pessoa_PessoasId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ClinicasidClinica",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PessoasId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Logs_ChamadosidChamado",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_GruposidGrupo",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_PessoasId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_ChamadosidChamado",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Arquivos_ChamadosidChamado",
                table: "Arquivos");

            migrationBuilder.DropColumn(
                name: "ClinicasidClinica",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PessoasId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "ChamadosidChamado",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "GruposidGrupo",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "PessoasId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "ChamadosidChamado",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "ChamadosidChamado",
                table: "Arquivos");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ClinicaId",
                table: "Usuario",
                column: "ClinicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PessoaId",
                table: "Usuario",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_chamdosId",
                table: "Logs",
                column: "chamdosId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_GrupoId",
                table: "Funcionario",
                column: "GrupoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_PessoaId",
                table: "Funcionario",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_chamdosId",
                table: "Comentarios",
                column: "chamdosId");

            migrationBuilder.CreateIndex(
                name: "IX_Arquivos_chamdosId",
                table: "Arquivos",
                column: "chamdosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arquivos_Chamados_chamdosId",
                table: "Arquivos",
                column: "chamdosId",
                principalTable: "Chamados",
                principalColumn: "idChamado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Chamados_chamdosId",
                table: "Comentarios",
                column: "chamdosId",
                principalTable: "Chamados",
                principalColumn: "idChamado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_grupos_GrupoId",
                table: "Funcionario",
                column: "GrupoId",
                principalTable: "grupos",
                principalColumn: "idGrupo",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Pessoa_PessoaId",
                table: "Funcionario",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Chamados_chamdosId",
                table: "Logs",
                column: "chamdosId",
                principalTable: "Chamados",
                principalColumn: "idChamado",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Clinicas_ClinicaId",
                table: "Usuario",
                column: "ClinicaId",
                principalTable: "Clinicas",
                principalColumn: "idClinica",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Pessoa_PessoaId",
                table: "Usuario",
                column: "PessoaId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arquivos_Chamados_chamdosId",
                table: "Arquivos");

            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Chamados_chamdosId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_grupos_GrupoId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Pessoa_PessoaId",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Chamados_chamdosId",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Clinicas_ClinicaId",
                table: "Usuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Pessoa_PessoaId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_ClinicaId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PessoaId",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Logs_chamdosId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_GrupoId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_PessoaId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_chamdosId",
                table: "Comentarios");

            migrationBuilder.DropIndex(
                name: "IX_Arquivos_chamdosId",
                table: "Arquivos");

            migrationBuilder.AddColumn<int>(
                name: "ClinicasidClinica",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoasId",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChamadosidChamado",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GruposidGrupo",
                table: "Funcionario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoasId",
                table: "Funcionario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChamadosidChamado",
                table: "Comentarios",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChamadosidChamado",
                table: "Arquivos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_ClinicasidClinica",
                table: "Usuario",
                column: "ClinicasidClinica");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PessoasId",
                table: "Usuario",
                column: "PessoasId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ChamadosidChamado",
                table: "Logs",
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
                name: "IX_Comentarios_ChamadosidChamado",
                table: "Comentarios",
                column: "ChamadosidChamado");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Chamados_ChamadosidChamado",
                table: "Comentarios",
                column: "ChamadosidChamado",
                principalTable: "Chamados",
                principalColumn: "idChamado",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_grupos_GruposidGrupo",
                table: "Funcionario",
                column: "GruposidGrupo",
                principalTable: "grupos",
                principalColumn: "idGrupo",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Pessoa_PessoasId",
                table: "Funcionario",
                column: "PessoasId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Chamados_ChamadosidChamado",
                table: "Logs",
                column: "ChamadosidChamado",
                principalTable: "Chamados",
                principalColumn: "idChamado",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Clinicas_ClinicasidClinica",
                table: "Usuario",
                column: "ClinicasidClinica",
                principalTable: "Clinicas",
                principalColumn: "idClinica",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Pessoa_PessoasId",
                table: "Usuario",
                column: "PessoasId",
                principalTable: "Pessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
