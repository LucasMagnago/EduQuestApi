using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewSeedCorrectionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NivelEscola",
                table: "Questoes",
                newName: "NivelEscolar");

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 3,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 4,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 5,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 6,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 7,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 9,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 10,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 11,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 12,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 13,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 14,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 15,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 16,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 17,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 18,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 19,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 20,
                column: "NivelEscolar",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 21,
                column: "NivelEscolar",
                value: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NivelEscolar",
                table: "Questoes",
                newName: "NivelEscola");

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 3,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 4,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 5,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 6,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 7,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 9,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 10,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 11,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 12,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 13,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 14,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 15,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 16,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 17,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 18,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 19,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 20,
                column: "NivelEscola",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 21,
                column: "NivelEscola",
                value: 0);
        }
    }
}
