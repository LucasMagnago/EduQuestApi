using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCorrectionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "XpGanho",
                table: "AtividadeAlunos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PontuacaoObtida",
                table: "AtividadeAlunos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MoedasGanhas",
                table: "AtividadeAlunos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicio",
                table: "AtividadeAlunos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "AtividadeAlunos",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataUltimoAcessoStreak",
                value: new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataUltimoAcessoStreak",
                value: new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataUltimoAcessoStreak",
                value: new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AtividadeAlunos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataFim", "DataInicio", "MoedasGanhas", "PontuacaoObtida", "XpGanho" },
                values: new object[] { null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataResposta",
                value: new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataResposta",
                value: new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataResposta",
                value: new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataResposta",
                value: new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataResposta",
                value: new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "XpGanho",
                table: "AtividadeAlunos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PontuacaoObtida",
                table: "AtividadeAlunos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MoedasGanhas",
                table: "AtividadeAlunos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataInicio",
                table: "AtividadeAlunos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataFim",
                table: "AtividadeAlunos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataUltimoAcessoStreak",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 6,
                column: "DataUltimoAcessoStreak",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataUltimoAcessoStreak",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AtividadeAlunos",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DataFim", "DataInicio", "MoedasGanhas", "PontuacaoObtida", "XpGanho" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 0 });

            migrationBuilder.UpdateData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataResposta",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 3,
                column: "DataResposta",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 5,
                column: "DataResposta",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 7,
                column: "DataResposta",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 9,
                column: "DataResposta",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
