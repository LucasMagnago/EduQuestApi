using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RefatorandoAtividadeEBatalha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtivideTurmas_Atividades_AtividadeId",
                table: "AtivideTurmas");

            migrationBuilder.DropForeignKey(
                name: "FK_AtivideTurmas_Disciplinas_DisciplinaId",
                table: "AtivideTurmas");

            migrationBuilder.DropForeignKey(
                name: "FK_AtivideTurmas_Turmas_TurmaId",
                table: "AtivideTurmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Atividades_AtividadeId",
                table: "Batalhas");

            migrationBuilder.DropTable(
                name: "AlunoRealizaAtividades");

            migrationBuilder.DropTable(
                name: "BatalhaRespostaParticipantes");

            migrationBuilder.DropTable(
                name: "BatalhaParticipantes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtivideTurmas",
                table: "AtivideTurmas");

            migrationBuilder.RenameTable(
                name: "AtivideTurmas",
                newName: "AtividadeTurmas");

            migrationBuilder.RenameColumn(
                name: "AtividadeId",
                table: "Batalhas",
                newName: "AlunoBId");

            migrationBuilder.RenameIndex(
                name: "IX_Batalhas_AtividadeId",
                table: "Batalhas",
                newName: "IX_Batalhas_AlunoBId");

            migrationBuilder.RenameIndex(
                name: "IX_AtivideTurmas_TurmaId",
                table: "AtividadeTurmas",
                newName: "IX_AtividadeTurmas_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_AtivideTurmas_DisciplinaId",
                table: "AtividadeTurmas",
                newName: "IX_AtividadeTurmas_DisciplinaId");

            migrationBuilder.RenameIndex(
                name: "IX_AtivideTurmas_AtividadeId",
                table: "AtividadeTurmas",
                newName: "IX_AtividadeTurmas_AtividadeId");

            migrationBuilder.AddColumn<int>(
                name: "AlunoAId",
                table: "Batalhas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtividadeTurmas",
                table: "AtividadeTurmas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AtividadeAlunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PontuacaoObtida = table.Column<int>(type: "int", nullable: false),
                    XpGanho = table.Column<int>(type: "int", nullable: false),
                    MoedasGanhas = table.Column<int>(type: "int", nullable: false),
                    FeedbackProfessor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    AtividadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeAlunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadeAlunos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtividadeAlunos_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatalhaQuestoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatalhaId = table.Column<int>(type: "int", nullable: false),
                    QuestaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatalhaQuestoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatalhaQuestoes_Batalhas_BatalhaId",
                        column: x => x.BatalhaId,
                        principalTable: "Batalhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatalhaQuestoes_Questoes_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "Questoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatalhaRespostas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acertou = table.Column<bool>(type: "bit", nullable: false),
                    DataResposta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatalhaId = table.Column<int>(type: "int", nullable: false),
                    QuestaoId = table.Column<int>(type: "int", nullable: false),
                    AlternativaEscolhaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatalhaRespostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatalhaRespostas_Alternativas_AlternativaEscolhaId",
                        column: x => x.AlternativaEscolhaId,
                        principalTable: "Alternativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatalhaRespostas_Batalhas_BatalhaId",
                        column: x => x.BatalhaId,
                        principalTable: "Batalhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BatalhaRespostas_Questoes_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "Questoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtividadeRespostas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Acertou = table.Column<bool>(type: "bit", nullable: false),
                    DataResposta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AtividadeAlunoId = table.Column<int>(type: "int", nullable: false),
                    QuestaoId = table.Column<int>(type: "int", nullable: false),
                    AlternativaEscolhaId = table.Column<int>(type: "int", nullable: false),
                    AtividadeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeRespostas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadeRespostas_Alternativas_AlternativaEscolhaId",
                        column: x => x.AlternativaEscolhaId,
                        principalTable: "Alternativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AtividadeRespostas_AtividadeAlunos_AtividadeAlunoId",
                        column: x => x.AtividadeAlunoId,
                        principalTable: "AtividadeAlunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtividadeRespostas_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AtividadeRespostas_Questoes_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "Questoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_AlunoAId",
                table: "Batalhas",
                column: "AlunoAId");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeAlunos_AlunoId",
                table: "AtividadeAlunos",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeAlunos_AtividadeId",
                table: "AtividadeAlunos",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeRespostas_AlternativaEscolhaId",
                table: "AtividadeRespostas",
                column: "AlternativaEscolhaId");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeRespostas_AtividadeAlunoId",
                table: "AtividadeRespostas",
                column: "AtividadeAlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeRespostas_AtividadeId",
                table: "AtividadeRespostas",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeRespostas_QuestaoId",
                table: "AtividadeRespostas",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_BatalhaQuestoes_BatalhaId",
                table: "BatalhaQuestoes",
                column: "BatalhaId");

            migrationBuilder.CreateIndex(
                name: "IX_BatalhaQuestoes_QuestaoId",
                table: "BatalhaQuestoes",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_BatalhaRespostas_AlternativaEscolhaId",
                table: "BatalhaRespostas",
                column: "AlternativaEscolhaId");

            migrationBuilder.CreateIndex(
                name: "IX_BatalhaRespostas_BatalhaId",
                table: "BatalhaRespostas",
                column: "BatalhaId");

            migrationBuilder.CreateIndex(
                name: "IX_BatalhaRespostas_QuestaoId",
                table: "BatalhaRespostas",
                column: "QuestaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadeTurmas_Atividades_AtividadeId",
                table: "AtividadeTurmas",
                column: "AtividadeId",
                principalTable: "Atividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadeTurmas_Disciplinas_DisciplinaId",
                table: "AtividadeTurmas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtividadeTurmas_Turmas_TurmaId",
                table: "AtividadeTurmas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Alunos_AlunoAId",
                table: "Batalhas",
                column: "AlunoAId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Alunos_AlunoBId",
                table: "Batalhas",
                column: "AlunoBId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AtividadeTurmas_Atividades_AtividadeId",
                table: "AtividadeTurmas");

            migrationBuilder.DropForeignKey(
                name: "FK_AtividadeTurmas_Disciplinas_DisciplinaId",
                table: "AtividadeTurmas");

            migrationBuilder.DropForeignKey(
                name: "FK_AtividadeTurmas_Turmas_TurmaId",
                table: "AtividadeTurmas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Alunos_AlunoAId",
                table: "Batalhas");

            migrationBuilder.DropForeignKey(
                name: "FK_Batalhas_Alunos_AlunoBId",
                table: "Batalhas");

            migrationBuilder.DropTable(
                name: "AtividadeRespostas");

            migrationBuilder.DropTable(
                name: "BatalhaQuestoes");

            migrationBuilder.DropTable(
                name: "BatalhaRespostas");

            migrationBuilder.DropTable(
                name: "AtividadeAlunos");

            migrationBuilder.DropIndex(
                name: "IX_Batalhas_AlunoAId",
                table: "Batalhas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AtividadeTurmas",
                table: "AtividadeTurmas");

            migrationBuilder.DropColumn(
                name: "AlunoAId",
                table: "Batalhas");

            migrationBuilder.RenameTable(
                name: "AtividadeTurmas",
                newName: "AtivideTurmas");

            migrationBuilder.RenameColumn(
                name: "AlunoBId",
                table: "Batalhas",
                newName: "AtividadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Batalhas_AlunoBId",
                table: "Batalhas",
                newName: "IX_Batalhas_AtividadeId");

            migrationBuilder.RenameIndex(
                name: "IX_AtividadeTurmas_TurmaId",
                table: "AtivideTurmas",
                newName: "IX_AtivideTurmas_TurmaId");

            migrationBuilder.RenameIndex(
                name: "IX_AtividadeTurmas_DisciplinaId",
                table: "AtivideTurmas",
                newName: "IX_AtivideTurmas_DisciplinaId");

            migrationBuilder.RenameIndex(
                name: "IX_AtividadeTurmas_AtividadeId",
                table: "AtivideTurmas",
                newName: "IX_AtivideTurmas_AtividadeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AtivideTurmas",
                table: "AtivideTurmas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AlunoRealizaAtividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    AtividadeId = table.Column<int>(type: "int", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeedbackProfessor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoedasGanhas = table.Column<int>(type: "int", nullable: false),
                    PontuacaoObtida = table.Column<int>(type: "int", nullable: false),
                    XpGanho = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoRealizaAtividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoRealizaAtividades_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoRealizaAtividades_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatalhaParticipantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    BatalhaId = table.Column<int>(type: "int", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MoedaRecebidas = table.Column<int>(type: "int", nullable: false),
                    Pontuacao = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TempoTotalSegundos = table.Column<int>(type: "int", nullable: false),
                    XpRecebido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatalhaParticipantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatalhaParticipantes_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatalhaParticipantes_Batalhas_BatalhaId",
                        column: x => x.BatalhaId,
                        principalTable: "Batalhas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatalhaRespostaParticipantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BatalhaParticipanteId = table.Column<int>(type: "int", nullable: false),
                    QuestaoId = table.Column<int>(type: "int", nullable: false),
                    Acertou = table.Column<bool>(type: "bit", nullable: false),
                    DataResposta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RespostaDada = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BatalhaRespostaParticipantes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BatalhaRespostaParticipantes_BatalhaParticipantes_BatalhaParticipanteId",
                        column: x => x.BatalhaParticipanteId,
                        principalTable: "BatalhaParticipantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BatalhaRespostaParticipantes_Questoes_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "Questoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoRealizaAtividades_AlunoId",
                table: "AlunoRealizaAtividades",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoRealizaAtividades_AtividadeId",
                table: "AlunoRealizaAtividades",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_BatalhaParticipantes_AlunoId",
                table: "BatalhaParticipantes",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_BatalhaParticipantes_BatalhaId",
                table: "BatalhaParticipantes",
                column: "BatalhaId");

            migrationBuilder.CreateIndex(
                name: "IX_BatalhaRespostaParticipantes_BatalhaParticipanteId",
                table: "BatalhaRespostaParticipantes",
                column: "BatalhaParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_BatalhaRespostaParticipantes_QuestaoId",
                table: "BatalhaRespostaParticipantes",
                column: "QuestaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_AtivideTurmas_Atividades_AtividadeId",
                table: "AtivideTurmas",
                column: "AtividadeId",
                principalTable: "Atividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AtivideTurmas_Disciplinas_DisciplinaId",
                table: "AtivideTurmas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AtivideTurmas_Turmas_TurmaId",
                table: "AtivideTurmas",
                column: "TurmaId",
                principalTable: "Turmas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Batalhas_Atividades_AtividadeId",
                table: "Batalhas",
                column: "AtividadeId",
                principalTable: "Atividades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
