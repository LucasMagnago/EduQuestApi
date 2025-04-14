using EduQuest.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess
{
    internal class EduQuestDbContext : DbContext
    {
        public EduQuestDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AlocacaoProfessor> AlocacaoProfessores { get; set; }
        public DbSet<Alternativa> Alternativas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<Conquista> Conquistas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Desafio> Desafios { get; set; }
        public DbSet<DesafioCondicao> DesafioCondicoes { get; set; }
        public DbSet<DesafioEscola> DesafioEscolas { get; set; }
        public DbSet<DesafioTurma> DesafioTurmas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Item> Itens { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<PeriodoLetivo> PeriodosLetivos { get; set; }
        public DbSet<Questao> Questoes { get; set; }
        public DbSet<TipoAtividade> TiposAtividade { get; set; }
        public DbSet<TipoUnidade> TiposUnidade { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioPerfilEscola> UsuarioEscolaPerfis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações de mapeamento de entidades via Fluent API

            // Usuário
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            modelBuilder.Entity<Usuario>()
            .HasIndex(u => u.Email)
            .IsUnique();

            // Aluno
            modelBuilder.Entity<Aluno>().ToTable("Alunos");

            // 1. Aluno -> Matricula
            // 1. Configurar PK
            modelBuilder.Entity<Matricula>()
            .HasKey(m => new { m.AlunoId, m.TurmaId });

            // 1.1 Configurar a relação Aluno -> Matricula (Um-para-Muitos)
            modelBuilder.Entity<Matricula>()
            .HasOne(m => m.Aluno)
            .WithMany(a => a.Matriculas)
            .HasForeignKey(m => m.AlunoId)
            .OnDelete(DeleteBehavior.Restrict);

            // 1.2 Configurar a relação Turma-> Matricula (Um - para - Muitos)
            modelBuilder.Entity<Matricula>()
            .HasOne(m => m.Turma)
            .WithMany(t => t.Matriculas)
            .HasForeignKey(m => m.TurmaId)
            .OnDelete(DeleteBehavior.Restrict);

            // 1.3 Relação Usuario (Criador) -> Matricula (1:N)
            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.UsuarioCriacao)
                .WithMany(u => u.MatriculasCriadas)
                .HasForeignKey(m => m.UsuarioCriacaoId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            // 1.4 Relação Usuario (Mudou Situação) -> Matricula (1:N)
            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.UsuarioSituacao)
                .WithMany(u => u.MatriculasComSituacaoAlterada)
                .HasForeignKey(m => m.UsuarioSituacaoId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // 1.5 Relação Usuario (Excluiu) -> Matricula (1:N)
            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.UsuarioExclusao)
                .WithMany(u => u.MatriculasExcluidas)
                .HasForeignKey(m => m.UsuarioExclusaoId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            // 2. Aluno -> AlunoRealizaAtividade
            // 2. Configurar PK
            modelBuilder.Entity<AlunoRealizaAtividade>()
            .HasKey(a => new { a.AlunoId, a.AtividadeId });

            // 2.1 Configurar a relação Aluno -> AlunoRealizaAtividades (Um-para-Muitos)
            modelBuilder.Entity<AlunoRealizaAtividade>()
            .HasOne(m => m.Aluno)
            .WithMany(a => a.AlunoRealizaAtividades)
            .HasForeignKey(m => m.AlunoId)
            .OnDelete(DeleteBehavior.Restrict);

            // 2.2 Configurar a relação Turma -> AlunoRealizaAtividades (Um - para - Muitos)
            modelBuilder.Entity<AlunoRealizaAtividade>()
            .HasOne(m => m.Atividade)
            .WithMany(a => a.AlunoRealizaAtividades)
            .HasForeignKey(m => m.AtividadeId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
