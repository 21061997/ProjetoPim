using Microsoft.EntityFrameworkCore.Migrations;

namespace HelpDeskLogin.Migrations
{
    public partial class Update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Funcionario_FuncionarioId",
                table: "Chamados");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Chamados",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Funcionario_FuncionarioId",
                table: "Chamados",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chamados_Funcionario_FuncionarioId",
                table: "Chamados");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Chamados",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Chamados_Funcionario_FuncionarioId",
                table: "Chamados",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "IdFuncionario",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
