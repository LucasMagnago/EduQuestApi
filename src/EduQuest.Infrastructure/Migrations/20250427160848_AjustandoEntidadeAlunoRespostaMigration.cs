using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoEntidadeAlunoRespostaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtividadeRespostas_Atividades_AtividadeId",
                table: "AtividadeRespostas");

            migrationBuilder.DropIndex(
                name: "IX_AtividadeRespostas_AtividadeId",
                table: "AtividadeRespostas");

            migrationBuilder.DropColumn(
                name: "AtividadeId",
                table: "AtividadeRespostas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtividadeId",
                table: "AtividadeRespostas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeRespostas_AtividadeId",
                table: "AtividadeRespostas",
                column: "AtividadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadeRespostas_Atividades_AtividadeId",
                table: "AtividadeRespostas",
                column: "AtividadeId",
                principalTable: "Atividades",
                principalColumn: "Id");
        }
    }
}
