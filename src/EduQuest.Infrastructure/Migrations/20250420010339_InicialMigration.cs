using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduQuest.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InicialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Conquistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IconeUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriterioTipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriterioValor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conquistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProximoCursoId = table.Column<int>(type: "int", nullable: true)
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
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tipo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Perfis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposAtividade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    XpRecompensa = table.Column<int>(type: "int", nullable: false),
                    moedasRecompensa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAtividade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposCondicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposCondicoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposUnidade",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUnidade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsuarioIdentifier = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataUltimoLogin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Escolas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ativo = table.Column<bool>(type: "bit", nullable: false),
                    TipoUnidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escolas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Escolas_TiposUnidade_TipoUnidadeId",
                        column: x => x.TipoUnidadeId,
                        principalTable: "TiposUnidade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    XpAtual = table.Column<int>(type: "int", nullable: false),
                    Nivel = table.Column<int>(type: "int", nullable: false),
                    SaldoMoedas = table.Column<int>(type: "int", nullable: false),
                    StreakDiasConsecutivos = table.Column<int>(type: "int", nullable: false),
                    DataUltimoAcessoStreak = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alunos_Usuarios_Id",
                        column: x => x.Id,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    TempoLimiteSegundos = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoAtividadeId = table.Column<int>(type: "int", nullable: false),
                    ProfessorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividades_TiposAtividade_TipoAtividadeId",
                        column: x => x.TipoAtividadeId,
                        principalTable: "TiposAtividade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Atividades_Usuarios_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Desafios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dataInicioVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dataFimVigencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Escopo = table.Column<int>(type: "int", nullable: false),
                    XpRecompensa = table.Column<int>(type: "int", nullable: false),
                    MoedasRecompensa = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desafios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Desafios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mensagens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Conteudo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataEnvio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lida = table.Column<bool>(type: "bit", nullable: false),
                    RemetenteId = table.Column<int>(type: "int", nullable: false),
                    DestinatarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensagens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensagens_Usuarios_DestinatarioId",
                        column: x => x.DestinatarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensagens_Usuarios_RemetenteId",
                        column: x => x.RemetenteId,
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
                    Ano = table.Column<short>(type: "smallint", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    DataFim = table.Column<DateOnly>(type: "date", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    EscolaId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "UsuarioEscolaPerfis",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PerfilId = table.Column<int>(type: "int", nullable: false),
                    EscolaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioEscolaPerfis", x => new { x.UsuarioId, x.EscolaId, x.PerfilId });
                    table.ForeignKey(
                        name: "FK_UsuarioEscolaPerfis_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEscolaPerfis_Perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioEscolaPerfis_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoConquistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataObtencao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    ConquistaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoConquistas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoConquistas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlunoConquistas_Conquistas_ConquistaId",
                        column: x => x.ConquistaId,
                        principalTable: "Conquistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlunoPossuiItens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataAquisicao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoPossuiItens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoPossuiItens_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlunoPossuiItens_Itens_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Itens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlunoRealizaAtividades",
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
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    AtividadeId = table.Column<int>(type: "int", nullable: false)
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
                name: "Batalhas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TempoLimiteSegundos = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    AtividadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batalhas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Batalhas_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunoProgressoDesafios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataConclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DesafioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoProgressoDesafios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoProgressoDesafios_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlunoProgressoDesafios_Desafios_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "Desafios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DesafioCondicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoCondicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DescricaoCondicao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValorObjetivo = table.Column<int>(type: "int", nullable: false),
                    DataInicioContagem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFimContagem = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DesafioId = table.Column<int>(type: "int", nullable: false),
                    TipoCondicaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesafioCondicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DesafioCondicoes_Desafios_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "Desafios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DesafioCondicoes_TiposCondicoes_TipoCondicaoId",
                        column: x => x.TipoCondicaoId,
                        principalTable: "TiposCondicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DesafioEscolas",
                columns: table => new
                {
                    DesafioId = table.Column<int>(type: "int", nullable: false),
                    EscolaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesafioEscolas", x => new { x.DesafioId, x.EscolaId });
                    table.ForeignKey(
                        name: "FK_DesafioEscolas_Desafios_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "Desafios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DesafioEscolas_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Turno = table.Column<int>(type: "int", nullable: false),
                    Inep = table.Column<int>(type: "int", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    PeriodoLetivoId = table.Column<int>(type: "int", nullable: false),
                    EscolaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turmas_Escolas_EscolaId",
                        column: x => x.EscolaId,
                        principalTable: "Escolas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turmas_PeriodosLetivos_PeriodoLetivoId",
                        column: x => x.PeriodoLetivoId,
                        principalTable: "PeriodosLetivos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatalhaParticipantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pontuacao = table.Column<int>(type: "int", nullable: false),
                    TempoTotalSegundos = table.Column<int>(type: "int", nullable: false),
                    XpRecebido = table.Column<int>(type: "int", nullable: false),
                    MoedaRecebidas = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFim = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatalhaId = table.Column<int>(type: "int", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false)
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
                name: "AlunoProgressoCondicoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorAtual = table.Column<int>(type: "int", nullable: false),
                    DataUltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DesafioConficaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoProgressoCondicoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoProgressoCondicoes_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlunoProgressoCondicoes_DesafioCondicoes_DesafioConficaoId",
                        column: x => x.DesafioConficaoId,
                        principalTable: "DesafioCondicoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlocacaoProfessores",
                columns: table => new
                {
                    ProfessorId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlocacaoProfessores", x => new { x.ProfessorId, x.TurmaId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlocacaoProfessores_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlocacaoProfessores_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlocacaoProfessores_Usuarios_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtivideTurmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AtividadeId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtivideTurmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtivideTurmas_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtivideTurmas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DesafioTurmas",
                columns: table => new
                {
                    DesafioId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesafioTurmas", x => new { x.DesafioId, x.TurmaId });
                    table.ForeignKey(
                        name: "FK_DesafioTurmas_Desafios_DesafioId",
                        column: x => x.DesafioId,
                        principalTable: "Desafios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DesafioTurmas_Turmas_TurmaId",
                        column: x => x.TurmaId,
                        principalTable: "Turmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matriculas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Situacao = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DataMatricula = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataSituacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataExclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioSituacaoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioExclusaoId = table.Column<int>(type: "int", nullable: true)
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
                name: "Alternativas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    QuestaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternativas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enunciado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<int>(type: "int", nullable: false),
                    AlternativaCorretaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioCriacaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questoes_Alternativas_AlternativaCorretaId",
                        column: x => x.AlternativaCorretaId,
                        principalTable: "Alternativas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questoes_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questoes_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questoes_Usuarios_UsuarioCriacaoId",
                        column: x => x.UsuarioCriacaoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AtividadeQuestoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    AtividadeId = table.Column<int>(type: "int", nullable: false),
                    QuestaoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtividadeQuestoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtividadeQuestoes_Atividades_AtividadeId",
                        column: x => x.AtividadeId,
                        principalTable: "Atividades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AtividadeQuestoes_Questoes_QuestaoId",
                        column: x => x.QuestaoId,
                        principalTable: "Questoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BatalhaRespostaParticipantes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespostaDada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Acertou = table.Column<bool>(type: "bit", nullable: false),
                    DataResposta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatalhaParticipanteId = table.Column<int>(type: "int", nullable: false),
                    QuestaoId = table.Column<int>(type: "int", nullable: false)
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
                name: "IX_AlocacaoProfessores_DisciplinaId",
                table: "AlocacaoProfessores",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlocacaoProfessores_TurmaId",
                table: "AlocacaoProfessores",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Alternativas_QuestaoId",
                table: "Alternativas",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoConquistas_AlunoId",
                table: "AlunoConquistas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoConquistas_ConquistaId",
                table: "AlunoConquistas",
                column: "ConquistaId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoPossuiItens_AlunoId",
                table: "AlunoPossuiItens",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoPossuiItens_ItemId",
                table: "AlunoPossuiItens",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoProgressoCondicoes_AlunoId",
                table: "AlunoProgressoCondicoes",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoProgressoCondicoes_DesafioConficaoId",
                table: "AlunoProgressoCondicoes",
                column: "DesafioConficaoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoProgressoDesafios_AlunoId",
                table: "AlunoProgressoDesafios",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoProgressoDesafios_DesafioId",
                table: "AlunoProgressoDesafios",
                column: "DesafioId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoRealizaAtividades_AlunoId",
                table: "AlunoRealizaAtividades",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoRealizaAtividades_AtividadeId",
                table: "AlunoRealizaAtividades",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeQuestoes_AtividadeId",
                table: "AtividadeQuestoes",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtividadeQuestoes_QuestaoId",
                table: "AtividadeQuestoes",
                column: "QuestaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_ProfessorId",
                table: "Atividades",
                column: "ProfessorId");

            migrationBuilder.CreateIndex(
                name: "IX_Atividades_TipoAtividadeId",
                table: "Atividades",
                column: "TipoAtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtivideTurmas_AtividadeId",
                table: "AtivideTurmas",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_AtivideTurmas_TurmaId",
                table: "AtivideTurmas",
                column: "TurmaId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Batalhas_AtividadeId",
                table: "Batalhas",
                column: "AtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_ProximoCursoId",
                table: "Cursos",
                column: "ProximoCursoId");

            migrationBuilder.CreateIndex(
                name: "IX_DesafioCondicoes_DesafioId",
                table: "DesafioCondicoes",
                column: "DesafioId");

            migrationBuilder.CreateIndex(
                name: "IX_DesafioCondicoes_TipoCondicaoId",
                table: "DesafioCondicoes",
                column: "TipoCondicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_DesafioEscolas_EscolaId",
                table: "DesafioEscolas",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Desafios_UsuarioId",
                table: "Desafios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_DesafioTurmas_TurmaId",
                table: "DesafioTurmas",
                column: "TurmaId");

            migrationBuilder.CreateIndex(
                name: "IX_Escolas_TipoUnidadeId",
                table: "Escolas",
                column: "TipoUnidadeId");

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
                name: "IX_Mensagens_DestinatarioId",
                table: "Mensagens",
                column: "DestinatarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Mensagens_RemetenteId",
                table: "Mensagens",
                column: "RemetenteId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodosLetivos_EscolaId",
                table: "PeriodosLetivos",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_AlternativaCorretaId",
                table: "Questoes",
                column: "AlternativaCorretaId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_CursoId",
                table: "Questoes",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_DisciplinaId",
                table: "Questoes",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Questoes_UsuarioCriacaoId",
                table: "Questoes",
                column: "UsuarioCriacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_CursoId",
                table: "Turmas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_EscolaId",
                table: "Turmas",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_PeriodoLetivoId",
                table: "Turmas",
                column: "PeriodoLetivoId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEscolaPerfis_EscolaId",
                table: "UsuarioEscolaPerfis",
                column: "EscolaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioEscolaPerfis_PerfilId",
                table: "UsuarioEscolaPerfis",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Email",
                table: "Usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alternativas_Questoes_QuestaoId",
                table: "Alternativas",
                column: "QuestaoId",
                principalTable: "Questoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questoes_Disciplinas_DisciplinaId",
                table: "Questoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Questoes_Usuarios_UsuarioCriacaoId",
                table: "Questoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Alternativas_Questoes_QuestaoId",
                table: "Alternativas");

            migrationBuilder.DropTable(
                name: "AlocacaoProfessores");

            migrationBuilder.DropTable(
                name: "AlunoConquistas");

            migrationBuilder.DropTable(
                name: "AlunoPossuiItens");

            migrationBuilder.DropTable(
                name: "AlunoProgressoCondicoes");

            migrationBuilder.DropTable(
                name: "AlunoProgressoDesafios");

            migrationBuilder.DropTable(
                name: "AlunoRealizaAtividades");

            migrationBuilder.DropTable(
                name: "AtividadeQuestoes");

            migrationBuilder.DropTable(
                name: "AtivideTurmas");

            migrationBuilder.DropTable(
                name: "BatalhaRespostaParticipantes");

            migrationBuilder.DropTable(
                name: "DesafioEscolas");

            migrationBuilder.DropTable(
                name: "DesafioTurmas");

            migrationBuilder.DropTable(
                name: "Matriculas");

            migrationBuilder.DropTable(
                name: "Mensagens");

            migrationBuilder.DropTable(
                name: "UsuarioEscolaPerfis");

            migrationBuilder.DropTable(
                name: "Conquistas");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "DesafioCondicoes");

            migrationBuilder.DropTable(
                name: "BatalhaParticipantes");

            migrationBuilder.DropTable(
                name: "Turmas");

            migrationBuilder.DropTable(
                name: "Perfis");

            migrationBuilder.DropTable(
                name: "Desafios");

            migrationBuilder.DropTable(
                name: "TiposCondicoes");

            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Batalhas");

            migrationBuilder.DropTable(
                name: "PeriodosLetivos");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Escolas");

            migrationBuilder.DropTable(
                name: "TiposAtividade");

            migrationBuilder.DropTable(
                name: "TiposUnidade");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Questoes");

            migrationBuilder.DropTable(
                name: "Alternativas");

            migrationBuilder.DropTable(
                name: "Cursos");
        }
    }
}
