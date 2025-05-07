using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PreparandoRankingMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlunoEstatisticas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    TotalParticipacoesInBatalhas = table.Column<int>(type: "int", nullable: false),
                    TotalVitoriasInBatalhas = table.Column<int>(type: "int", nullable: false),
                    AtividadesConcluidas = table.Column<int>(type: "int", nullable: false),
                    MediaNotasNormalizadas = table.Column<double>(type: "float", nullable: false),
                    QuantidadeNotasValidas = table.Column<int>(type: "int", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoEstatisticas", x => x.AlunoId);
                    table.ForeignKey(
                        name: "FK_AlunoEstatisticas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EscolaEstatisticas",
                columns: table => new
                {
                    EscolaId = table.Column<int>(type: "int", nullable: false),
                    TotalParticipacoesInBatalhas = table.Column<int>(type: "int", nullable: false),
                    TotalVitoriasInBatalhas = table.Column<int>(type: "int", nullable: false),
                    AtividadesConcluidas = table.Column<int>(type: "int", nullable: false),
                    MediaNotasNormalizadas = table.Column<double>(type: "float", nullable: false),
                    QuantidadeNotasValidas = table.Column<int>(type: "int", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscolaEstatisticas", x => x.EscolaId);
                    table.ForeignKey(
                        name: "FK_EscolaEstatisticas_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TurmaEstatisticas",
                columns: table => new
                {
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    TotalParticipacoesInBatalhas = table.Column<int>(type: "int", nullable: false),
                    TotalVitoriasInBatalhas = table.Column<int>(type: "int", nullable: false),
                    AtividadesConcluidas = table.Column<int>(type: "int", nullable: false),
                    MediaNotasNormalizadas = table.Column<double>(type: "float", nullable: false),
                    QuantidadeNotasValidas = table.Column<int>(type: "int", nullable: false),
                    UltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TurmaEstatisticas", x => x.TurmaId);
                    table.ForeignKey(
                        name: "FK_TurmaEstatisticas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoEstatisticas");

            migrationBuilder.DropTable(
                name: "EscolaEstatisticas");

            migrationBuilder.DropTable(
                name: "TurmaEstatisticas");
        }
    }
}
