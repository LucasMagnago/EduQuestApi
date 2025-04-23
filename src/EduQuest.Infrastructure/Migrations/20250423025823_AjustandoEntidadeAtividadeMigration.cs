using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AjustandoEntidadeAtividadeMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Atividades_TiposAtividade_TipoAtividadeId",
                table: "Atividades");

            migrationBuilder.DropTable(
                name: "TiposAtividade");

            migrationBuilder.DropIndex(
                name: "IX_Atividades_TipoAtividadeId",
                table: "Atividades");

            migrationBuilder.RenameColumn(
                name: "TipoAtividadeId",
                table: "Atividades",
                newName: "XpRecompensa");

            migrationBuilder.AddColumn<int>(
                name: "MoedasRecompensa",
                table: "Atividades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MoedasRecompensa",
                table: "Atividades");

            migrationBuilder.RenameColumn(
                name: "XpRecompensa",
                table: "Atividades",
                newName: "TipoAtividadeId");

            migrationBuilder.CreateTable(
                name: "TiposAtividade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XpRecompensa = table.Column<int>(type: "int", nullable: false),
                    moedasRecompensa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAtividade", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_TipoAtividadeId",
                table: "Atividades",
                column: "TipoAtividadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Atividades_TiposAtividade_TipoAtividadeId",
                table: "Atividades",
                column: "TipoAtividadeId",
                principalTable: "TiposAtividade",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
