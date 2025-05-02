using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SecondNewSeedCorrectionMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 8,
                column: "NivelEscolar",
                value: 6);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 8,
                column: "NivelEscolar",
                value: 0);
        }
    }
}
