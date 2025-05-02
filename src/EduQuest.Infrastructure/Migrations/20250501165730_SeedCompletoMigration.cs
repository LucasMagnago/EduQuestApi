using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedCompletoMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ativo",
                table: "Escolas",
                newName: "Ativo");

            migrationBuilder.AlterColumn<int>(
                name: "AlternativaCorretaId",
                table: "Questoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "Descricao", "Sigla" },
                values: new object[,]
                {
                    { 1, "Matemática", "MAT" },
                    { 2, "Português", "PORT" },
                    { 3, "História", "HIST" },
                    { 4, "Geografia", "GEO" },
                    { 5, "Ciências", "CIEN" },
                    { 6, "Artes", "ART" },
                    { 7, "Educação Física", "EDF" }
                });

            migrationBuilder.InsertData(
                table: "Perfis",
                columns: new[] { "Id", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, "Responsável pela gestão geral da plataforma, com acesso total para configurar escolas, usuários e permissões.", "Admin" },
                    { 2, "Supervisiona as atividades de uma escola específica, podendo gerenciar professores, alunos e turmas.", "Gestor" },
                    { 3, "Responsável pelo acompanhamento pedagógico dos alunos, criação de atividades e lançamento de avaliações.", "Professor" }
                });

            migrationBuilder.InsertData(
                table: "TiposUnidade",
                columns: new[] { "Id", "Descricao", "Nome", "Sigla" },
                values: new object[] { 1, "Escola pública, administrada pela prefeitura de um município, que oferece o ensino fundamental (anos iniciais e finais). ", "Escola Municipal de Ensino Fundamental", "EMEF" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "Ativo", "DataCadastro", "DataNascimento", "DataUltimoLogin", "Email", "Nome", "SenhaHash", "UsuarioIdentifier" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateOnly(1997, 4, 12), new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), "joao@eduquest.com", "João Admin", "$2a$11$l.1.XtCPblw2zZZS.UIu2eEOZiaQoypQka7N4rHAq0Qs6l/0dyvga", new Guid("3f3a2f14-56e1-4e1e-8d91-9f63d5f3d402") },
                    { 2, true, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateOnly(1993, 4, 12), new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), "maria@eduquest.com", "Maria Gestora", "$2a$11$/nTO8u7SXBROhis7RGn56OR0mWhxh7Tx.lf2P/F63R/TbHo/oWlZ.", new Guid("09d8a9cc-c23d-4b1f-8e14-ff12fd17c248") },
                    { 3, true, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateOnly(1999, 4, 12), new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), "alice@eduquest.com", "Alice Professora", "$2a$11$mNIy4y97smFq6Vzjj0o6TOxkJ/472tnI4Qv8FQ/3smJjH/Rp4CEZS", new Guid("f6f7b3b4-6e3e-4bc9-95f7-0d15f0e034c9") },
                    { 4, true, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateOnly(2002, 4, 12), new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), "diego@eduquest.com", "Diego Professor", "$2a$11$7aKDv6ML6d7whmHhJYUes.uBNAAcLM.dsIUOhCg1GxX5hXk/SCj62", new Guid("61a3b16d-1208-4ce4-b3c6-ccbe0ab0acdf") },
                    { 5, true, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateOnly(2015, 4, 12), new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), "lucas@eduquest.com", "Lucas Aluno", "$2a$11$zaRQt0VkVQkiPn/dMiKWuO6bpK/nAqyinCMuLk7tXSD3YPVbMAKtO", new Guid("a8dd0cd3-e0a1-4a2c-a18d-ec7f69c82872") },
                    { 6, true, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateOnly(2014, 4, 12), new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), "israel@eduquest.com", "Israel Aluno", "$2a$11$zaRQt0VkVQkiPn/dMiKWuO6bpK/nAqyinCMuLk7tXSD3YPVbMAKtO", new Guid("772b5cbe-df26-4f16-90b5-4e0fd472e2c6") },
                    { 7, true, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateOnly(2013, 4, 12), new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), "anker@eduquest.com", "Anker Aluno", "$2a$11$zaRQt0VkVQkiPn/dMiKWuO6bpK/nAqyinCMuLk7tXSD3YPVbMAKtO", new Guid("2eaf4c9b-6bc9-4463-8cf4-27911b34939e") }
                });

            migrationBuilder.InsertData(
                table: "Atividades",
                columns: new[] { "Id", "DataCriacao", "Descricao", "MoedasRecompensa", "ProfessorId", "TempoLimiteSegundos", "Titulo", "Valor", "XpRecompensa" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), "Quiz de Frações", 100, 4, 600, "Quiz de Frações", 10, 100 },
                    { 2, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), "Atividade de Português", 100, 3, 600, "Atividade de Português", 10, 100 }
                });

            migrationBuilder.InsertData(
                table: "Escolas",
                columns: new[] { "Id", "Ativo", "Inep", "Nome", "Sigla", "Telefone", "TipoUnidadeId" },
                values: new object[] { 1, true, "12016365", "Escola Exemplo", "EE", "3251-2266", 1 });

            migrationBuilder.InsertData(
                table: "Questoes",
                columns: new[] { "Id", "AlternativaCorretaId", "DisciplinaId", "Enunciado", "NivelEscola", "Resposta", "UsuarioCriacaoId" },
                values: new object[,]
                {
                    { 2, null, 1, "Quanto é 5 + 3?", 0, "", 4 },
                    { 3, null, 1, "Qual é a raiz quadrada de 16?", 0, "", 4 },
                    { 4, null, 1, "Quanto é 9 - 4?", 0, "", 4 },
                    { 5, null, 1, "Qual é o dobro de 7?", 0, "", 4 },
                    { 6, null, 1, "Quanto é 12 ÷ 3?", 0, "", 4 },
                    { 7, null, 1, "Quanto é 3²?", 0, "", 4 },
                    { 8, null, 1, "Qual é o valor de 10% de 100?", 0, "", 4 },
                    { 9, null, 1, "Quanto é 8 × 6?", 0, "", 4 },
                    { 10, null, 1, "Quanto é 14 + 5?", 0, "", 4 },
                    { 11, null, 1, "Qual é a metade de 30?", 0, "", 4 },
                    { 12, null, 2, "Qual é o sujeito da frase: 'O menino correu para casa'?", 0, "", 3 },
                    { 13, null, 2, "Qual a classe gramatical da palavra 'feliz'?", 0, "", 3 },
                    { 14, null, 2, "Identifique a figura de linguagem: 'O tempo voa.'", 0, "", 3 },
                    { 15, null, 2, "Qual a função do pronome na frase: 'Ela saiu cedo'?", 0, "", 3 },
                    { 16, null, 2, "Qual é o plural de 'cidadão'?", 0, "", 3 },
                    { 17, null, 2, "Qual a conjugação do verbo 'amar' na 1ª pessoa do singular no presente?", 0, "", 3 },
                    { 18, null, 2, "Qual é a forma correta: 'houveram problemas' ou 'houve problemas'?", 0, "", 3 },
                    { 19, null, 2, "Qual o antônimo de 'alegre'?", 0, "", 3 },
                    { 20, null, 2, "A palavra 'felicidade' é derivada de que outra palavra?", 0, "", 3 },
                    { 21, null, 2, "Qual a função da vírgula em: 'Maria, vá já dormir.'?", 0, "", 3 }
                });

            migrationBuilder.InsertData(
                table: "Alternativas",
                columns: new[] { "Id", "Descricao", "Ordem", "QuestaoId" },
                values: new object[,]
                {
                    { 3, "8", 1, 2 },
                    { 4, "9", 2, 2 },
                    { 5, "4", 1, 3 },
                    { 6, "5", 2, 3 },
                    { 7, "5", 1, 4 },
                    { 8, "6", 2, 4 },
                    { 9, "14", 1, 5 },
                    { 10, "12", 2, 5 },
                    { 11, "4", 1, 6 },
                    { 12, "3", 2, 6 },
                    { 13, "9", 1, 7 },
                    { 14, "6", 2, 7 },
                    { 15, "10", 1, 8 },
                    { 16, "20", 2, 8 },
                    { 17, "48", 1, 9 },
                    { 18, "56", 2, 9 },
                    { 19, "19", 1, 10 },
                    { 20, "20", 2, 10 },
                    { 21, "15", 1, 11 },
                    { 22, "12", 2, 11 },
                    { 23, "O menino", 1, 12 },
                    { 24, "Para casa", 2, 12 },
                    { 25, "Adjetivo", 1, 13 },
                    { 26, "Substantivo", 2, 13 },
                    { 27, "Metáfora", 1, 14 },
                    { 28, "Comparação", 2, 14 },
                    { 29, "Sujeito", 2, 15 },
                    { 30, "Pronome pessoal do caso reto", 1, 15 },
                    { 31, "Cidadãos", 1, 16 },
                    { 32, "Cidadães", 2, 16 },
                    { 33, "Amo", 1, 17 },
                    { 34, "Amarei", 2, 17 },
                    { 35, "'Houve problemas'", 1, 18 },
                    { 36, "'Houveram problemas'", 2, 18 },
                    { 37, "Triste", 1, 19 },
                    { 38, "Feliz", 2, 19 },
                    { 39, "Feliz", 1, 20 },
                    { 40, "Felicitar", 2, 20 },
                    { 41, "Vocativo", 1, 21 },
                    { 42, "Enumeração", 2, 21 }
                });

            migrationBuilder.InsertData(
                table: "AtividadeQuestoes",
                columns: new[] { "Id", "AtividadeId", "Ordem", "QuestaoId" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 1, 2, 3 },
                    { 3, 1, 3, 4 },
                    { 4, 1, 4, 5 },
                    { 5, 1, 5, 6 },
                    { 6, 1, 6, 7 },
                    { 7, 1, 7, 8 },
                    { 8, 1, 8, 9 },
                    { 9, 1, 9, 10 },
                    { 10, 1, 10, 11 },
                    { 11, 2, 1, 12 },
                    { 12, 2, 2, 13 },
                    { 13, 2, 3, 14 },
                    { 14, 2, 4, 15 },
                    { 15, 2, 5, 16 },
                    { 16, 2, 6, 17 },
                    { 17, 2, 7, 18 },
                    { 18, 2, 8, 19 },
                    { 19, 2, 9, 2 },
                    { 20, 2, 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "Turmas",
                columns: new[] { "Id", "Ano", "Ativo", "Descricao", "EscolaId", "NivelEscolar", "Turno" },
                values: new object[,]
                {
                    { 1, 2025, true, "6º Ano A", 1, 6, 1 },
                    { 2, 2025, true, "6º Ano B", 1, 6, 1 }
                });

            migrationBuilder.InsertData(
                table: "UsuarioEscolaPerfis",
                columns: new[] { "EscolaId", "PerfilId", "UsuarioId", "Ativo" },
                values: new object[,]
                {
                    { 1, 1, 1, true },
                    { 1, 2, 2, true },
                    { 1, 3, 3, true },
                    { 1, 3, 4, true }
                });

            migrationBuilder.InsertData(
                table: "AlocacaoProfessores",
                columns: new[] { "DisciplinaId", "ProfessorId", "TurmaId" },
                values: new object[,]
                {
                    { 2, 3, 1 },
                    { 2, 3, 2 },
                    { 1, 4, 1 },
                    { 1, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "DataUltimoAcessoStreak", "Nivel", "SaldoMoedas", "StreakDiasConsecutivos", "TurmaId", "XpAtual" },
                values: new object[,]
                {
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1000, 6, 1, 1220 },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1000, 4, 1, 1180 },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2000, 7, 2, 2430 }
                });

            migrationBuilder.InsertData(
                table: "AtividadeTurmas",
                columns: new[] { "Id", "AtividadeId", "DataAtribuicao", "DataEntrega", "DisciplinaId", "TurmaId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 10, 20, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 1, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 17, 10, 20, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 3, 2, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 10, 20, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 4, 2, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 17, 10, 20, 0, 0, DateTimeKind.Unspecified), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "AtividadeAlunos",
                columns: new[] { "Id", "AlunoId", "AtividadeId", "DataFim", "DataInicio", "FeedbackProfessor", "MoedasGanhas", "PontuacaoObtida", "Status", "XpGanho" },
                values: new object[,]
                {
                    { 1, 5, 1, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 12, 10, 19, 0, 0, DateTimeKind.Unspecified), "Bom", 100, 10, 3, 100 },
                    { 2, 5, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", 0, 0, 1, 0 }
                });

            migrationBuilder.InsertData(
                table: "Batalhas",
                columns: new[] { "Id", "AlunoAId", "AlunoBId", "AlunoPerdedorId", "AlunoVencedorId", "DataCriacao", "DataFim", "DataInicio", "MoedasConcedidasPerdedor", "MoedasConcedidasVencedor", "Status", "TempoLimiteSegundos", "XpConcedidoPerdedor", "XpConcedidoVencedor" },
                values: new object[] { 1, 5, 6, null, null, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), null, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), 50, 100, 4, 6000000, 50, 100 });

            migrationBuilder.InsertData(
                table: "AtividadeRespostas",
                columns: new[] { "Id", "Acertou", "AlternativaEscolhaId", "AtividadeAlunoId", "DataResposta", "QuestaoId" },
                values: new object[,]
                {
                    { 1, true, 3, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, true, 5, 1, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 3, true, 7, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 4, true, 9, 1, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 5, true, 11, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 6, true, 13, 1, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 7, true, 15, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 8, true, 17, 1, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 9, true, 19, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 10, true, 21, 1, new DateTime(2025, 4, 12, 10, 20, 0, 0, DateTimeKind.Unspecified), 11 }
                });

            migrationBuilder.InsertData(
                table: "BatalhaQuestoes",
                columns: new[] { "Id", "BatalhaId", "Ordem", "QuestaoId" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 1, 2, 3 },
                    { 3, 1, 3, 4 },
                    { 4, 1, 4, 15 },
                    { 5, 1, 5, 16 }
                });

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 2,
                column: "AlternativaCorretaId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 3,
                column: "AlternativaCorretaId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 4,
                column: "AlternativaCorretaId",
                value: 7);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 5,
                column: "AlternativaCorretaId",
                value: 9);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 6,
                column: "AlternativaCorretaId",
                value: 11);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 7,
                column: "AlternativaCorretaId",
                value: 13);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 8,
                column: "AlternativaCorretaId",
                value: 15);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 9,
                column: "AlternativaCorretaId",
                value: 17);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 10,
                column: "AlternativaCorretaId",
                value: 19);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 11,
                column: "AlternativaCorretaId",
                value: 21);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 12,
                column: "AlternativaCorretaId",
                value: 23);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 13,
                column: "AlternativaCorretaId",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 14,
                column: "AlternativaCorretaId",
                value: 27);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 15,
                column: "AlternativaCorretaId",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 16,
                column: "AlternativaCorretaId",
                value: 31);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 17,
                column: "AlternativaCorretaId",
                value: 33);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 18,
                column: "AlternativaCorretaId",
                value: 35);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 19,
                column: "AlternativaCorretaId",
                value: 37);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 20,
                column: "AlternativaCorretaId",
                value: 39);

            migrationBuilder.UpdateData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 21,
                column: "AlternativaCorretaId",
                value: 41);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AlocacaoProfessores",
                keyColumns: new[] { "DisciplinaId", "ProfessorId", "TurmaId" },
                keyValues: new object[] { 2, 3, 1 });

            migrationBuilder.DeleteData(
                table: "AlocacaoProfessores",
                keyColumns: new[] { "DisciplinaId", "ProfessorId", "TurmaId" },
                keyValues: new object[] { 2, 3, 2 });

            migrationBuilder.DeleteData(
                table: "AlocacaoProfessores",
                keyColumns: new[] { "DisciplinaId", "ProfessorId", "TurmaId" },
                keyValues: new object[] { 1, 4, 1 });

            migrationBuilder.DeleteData(
                table: "AlocacaoProfessores",
                keyColumns: new[] { "DisciplinaId", "ProfessorId", "TurmaId" },
                keyValues: new object[] { 1, 4, 2 });

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AtividadeAlunos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AtividadeQuestoes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AtividadeRespostas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AtividadeTurmas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AtividadeTurmas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AtividadeTurmas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AtividadeTurmas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BatalhaQuestoes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BatalhaQuestoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BatalhaQuestoes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BatalhaQuestoes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BatalhaQuestoes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Disciplinas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Disciplinas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Disciplinas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Disciplinas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Disciplinas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "UsuarioEscolaPerfis",
                keyColumns: new[] { "EscolaId", "PerfilId", "UsuarioId" },
                keyValues: new object[] { 1, 1, 1 });

            migrationBuilder.DeleteData(
                table: "UsuarioEscolaPerfis",
                keyColumns: new[] { "EscolaId", "PerfilId", "UsuarioId" },
                keyValues: new object[] { 1, 2, 2 });

            migrationBuilder.DeleteData(
                table: "UsuarioEscolaPerfis",
                keyColumns: new[] { "EscolaId", "PerfilId", "UsuarioId" },
                keyValues: new object[] { 1, 3, 3 });

            migrationBuilder.DeleteData(
                table: "UsuarioEscolaPerfis",
                keyColumns: new[] { "EscolaId", "PerfilId", "UsuarioId" },
                keyValues: new object[] { 1, 3, 4 });

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Alternativas",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AtividadeAlunos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Atividades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Batalhas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Perfis",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Turmas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Alunos",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Atividades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Disciplinas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questoes",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Disciplinas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Turmas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Escolas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TiposUnidade",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameColumn(
                name: "Ativo",
                table: "Escolas",
                newName: "ativo");

            migrationBuilder.AlterColumn<int>(
                name: "AlternativaCorretaId",
                table: "Questoes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            for (int id = 2; id <= 21; id++)
            {
                migrationBuilder.UpdateData(
                    table: "Questoes",
                    keyColumn: "Id",
                    keyValue: id,
                    column: "AlternativaCorretaId",
                    value: null
                );
            }
        }
    }
}
