using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SimplificandoModeloDeDadosMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questoes_Cursos_CursoId",
                table: "Questoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Cursos_CursoId",
                table: "Turmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_PeriodosLetivos_PeriodoLetivoId",
                table: "Turmas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "PeriodosLetivos");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_CursoId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_PeriodoLetivoId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Questoes_CursoId",
                table: "Questoes");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Turmas");

            migrationBuilder.RenameColumn(
                name: "PeriodoLetivoId",
                table: "Turmas",
                newName: "NivelEscolar");

            migrationBuilder.RenameColumn(
                name: "Inep",
                table: "Turmas",
                newName: "Ano");

            migrationBuilder.RenameColumn(
                name: "CursoId",
                table: "Questoes",
                newName: "NivelEscola");

            migrationBuilder.AddColumn<int>(
                name: "TurmaId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos",
                column: "TurmaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Turmas_TurmaId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_TurmaId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "TurmaId",
                table: "Alunos");

            migrationBuilder.RenameColumn(
                name: "NivelEscolar",
                table: "Turmas",
                newName: "PeriodoLetivoId");

            migrationBuilder.RenameColumn(
                name: "Ano",
                table: "Turmas",
                newName: "Inep");

            migrationBuilder.RenameColumn(
                name: "NivelEscola",
                table: "Questoes",
                newName: "CursoId");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Turmas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Turmas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProximoCursoId = table.Column<int>(type: "int", nullable: true),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cursos_Cursos_ProximoCursoId",
                        column: x => x.ProximoCursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioExclusaoId = table.Column<int>(type: "int", nullable: true),
                    UsuarioSituacaoId = table.Column<int>(type: "int", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSituacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Situacao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matriculas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matriculas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matriculas_Usuarios_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matriculas_Usuarios_UsuarioExclusaoId",
                        column: x => x.UsuarioExclusaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matriculas_Usuarios_UsuarioSituacaoId",
                        column: x => x.UsuarioSituacaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PeriodosLetivos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EscolaId = table.Column<int>(type: "int", nullable: false),
                    Ano = table.Column<short>(type: "smallint", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "date", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodosLetivos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeriodosLetivos_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_CursoId",
                table: "Turmas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_PeriodoLetivoId",
                table: "Turmas",
                column: "PeriodoLetivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_CursoId",
                table: "Questoes",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_ProximoCursoId",
                table: "Cursos",
                column: "ProximoCursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_TurmaId",
                table: "Matriculas",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_UsuarioCriacaoId",
                table: "Matriculas",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_UsuarioExclusaoId",
                table: "Matriculas",
                column: "UsuarioExclusaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_UsuarioSituacaoId",
                table: "Matriculas",
                column: "UsuarioSituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodosLetivos_EscolaId",
                table: "PeriodosLetivos",
                column: "EscolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questoes_Cursos_CursoId",
                table: "Questoes",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Cursos_CursoId",
                table: "Turmas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_PeriodosLetivos_PeriodoLetivoId",
                table: "Turmas",
                column: "PeriodoLetivoId",
                principalTable: "PeriodosLetivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
