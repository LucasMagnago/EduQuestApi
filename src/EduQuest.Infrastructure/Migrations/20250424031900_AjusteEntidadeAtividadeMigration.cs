using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjusteEntidadeAtividadeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataAtribuicao",
                table: "AtivideTurmas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrega",
                table: "AtivideTurmas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DisciplinaId",
                table: "AtivideTurmas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AtivideTurmas_DisciplinaId",
                table: "AtivideTurmas",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtivideTurmas_Disciplinas_DisciplinaId",
                table: "AtivideTurmas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtivideTurmas_Disciplinas_DisciplinaId",
                table: "AtivideTurmas");

            migrationBuilder.DropIndex(
                name: "IX_AtivideTurmas_DisciplinaId",
                table: "AtivideTurmas");

            migrationBuilder.DropColumn(
                name: "DataAtribuicao",
                table: "AtivideTurmas");

            migrationBuilder.DropColumn(
                name: "DataEntrega",
                table: "AtivideTurmas");

            migrationBuilder.DropColumn(
                name: "DisciplinaId",
                table: "AtivideTurmas");
        }
    }
}
