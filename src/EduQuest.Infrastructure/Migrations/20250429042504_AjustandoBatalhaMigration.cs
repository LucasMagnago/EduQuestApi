using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoBatalhaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicio",
                table: "Batalhas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "Batalhas",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "AlunoBId",
                table: "Batalhas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AlunoAId",
                table: "Batalhas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AlunoPerdedorId",
                table: "Batalhas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AlunoVencedorId",
                table: "Batalhas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Batalhas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "MoedasConcedidasPerdedor",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MoedasConcedidasVencedor",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XpConcedidoPerdedor",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "XpConcedidoVencedor",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "BatalhaRespostas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ordem",
                table: "BatalhaQuestoes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_AlunoPerdedorId",
                table: "Batalhas",
                column: "AlunoPerdedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_AlunoVencedorId",
                table: "Batalhas",
                column: "AlunoVencedorId");

            migrationBuilder.CreateIndex(
                name: "IX_BatalhaRespostas_AlunoId",
                table: "BatalhaRespostas",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_BatalhaRespostas_Alunos_AlunoId",
                table: "BatalhaRespostas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Alunos_AlunoPerdedorId",
                table: "Batalhas",
                column: "AlunoPerdedorId",
                principalTable: "Alunos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Alunos_AlunoVencedorId",
                table: "Batalhas",
                column: "AlunoVencedorId",
                principalTable: "Alunos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BatalhaRespostas_Alunos_AlunoId",
                table: "BatalhaRespostas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Alunos_AlunoPerdedorId",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Alunos_AlunoVencedorId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_AlunoPerdedorId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_AlunoVencedorId",
                table: "Batalhas");

            migrationBuilder.DropIndex(
                name: "IX_BatalhaRespostas_AlunoId",
                table: "BatalhaRespostas");

            migrationBuilder.DropColumn(
                name: "AlunoPerdedorId",
                table: "Batalhas");

            migrationBuilder.DropColumn(
                name: "AlunoVencedorId",
                table: "Batalhas");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Batalhas");

            migrationBuilder.DropColumn(
                name: "MoedasConcedidasPerdedor",
                table: "Batalhas");

            migrationBuilder.DropColumn(
                name: "MoedasConcedidasVencedor",
                table: "Batalhas");

            migrationBuilder.DropColumn(
                name: "XpConcedidoPerdedor",
                table: "Batalhas");

            migrationBuilder.DropColumn(
                name: "XpConcedidoVencedor",
                table: "Batalhas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "BatalhaRespostas");

            migrationBuilder.DropColumn(
                name: "Ordem",
                table: "BatalhaQuestoes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicio",
                table: "Batalhas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "Batalhas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlunoBId",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AlunoAId",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
