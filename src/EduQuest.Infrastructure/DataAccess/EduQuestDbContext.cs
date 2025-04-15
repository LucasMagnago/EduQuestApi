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
        public DbSet<UsuarioEscolaPerfil> UsuarioEscolaPerfis { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações de mapeamento de entidades via Fluent API

            // 1. Usuário
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");

                entity.HasIndex(u => u.Email)
                .IsUnique();
            });

            // 2. Aluno
            modelBuilder.Entity<Aluno>().ToTable("Alunos");

            // 3. Aluno ---> Matricula <--- Turma
            modelBuilder.Entity<Matricula>(entity =>
            {
                // Configurar PK
                //entity
                //.HasKey(m => new { m.AlunoId, m.TurmaId });

                // Aluno ---> Matricula
                entity.HasOne(m => m.Aluno)
                .WithMany(a => a.Matriculas)
                .HasForeignKey(m => m.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

                // Turma ---> Matricula 
                entity.HasOne(m => m.Turma)
                .WithMany(t => t.Matriculas)
                .HasForeignKey(m => m.TurmaId)
                .OnDelete(DeleteBehavior.Restrict);

                // Usuario (Criador) ---> Matricula 
                entity.HasOne(m => m.UsuarioCriacao)
                    .WithMany(u => u.MatriculasCriadas)
                    .HasForeignKey(m => m.UsuarioCriacaoId)
                    .IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                // Usuario (Mudou Situação) ---> Matricula
                entity.HasOne(m => m.UsuarioSituacao)
                    .WithMany(u => u.MatriculasComSituacaoAlterada)
                    .HasForeignKey(m => m.UsuarioSituacaoId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);

                // Usuario (Excluiu) ---> Matricula
                entity.HasOne(m => m.UsuarioExclusao)
                    .WithMany(u => u.MatriculasExcluidas)
                    .HasForeignKey(m => m.UsuarioExclusaoId)
                    .IsRequired(false)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.Property(m => m.Situacao)
                .HasConversion<string>()
                .HasMaxLength(20);
            });

            // 3. BatalhaParticipante
            modelBuilder.Entity<BatalhaParticipante>(entity =>
            {
                // Aluno ---> BatalhaParticipante
                entity.HasOne(bp => bp.Aluno)
                .WithMany(a => a.BatalhaParticipantes)
                .HasForeignKey(bp => bp.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

                // Batalha ---> BatalhaParticipante
                entity.HasOne(bp => bp.Batalha)
                .WithMany(b => b.BatalhaParticipantes)
                .HasForeignKey(bp => bp.BatalhaId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.Property(bp => bp.Status).HasConversion<string>().HasMaxLength(20);
            });

            // 4. BatalhaRespostaParticipante
            modelBuilder.Entity<BatalhaRespostaParticipante>(entity =>
            {
                // BatalhaRespostaParticipante ---> BatalhaParticipante
                entity.HasOne(brp => brp.BatalhaParticipante)
                .WithMany(bp => bp.BatalhaRespostaParticipantes)
                .HasForeignKey(brp => brp.BatalhaParticipanteId)
                .OnDelete(DeleteBehavior.Cascade);

                // BatalhaRespostaParticipante ---> Questao
                entity.HasOne(brp => brp.Questao)
                .WithMany(q => q.BatalhaRespostaParticipantes)
                .HasForeignKey(brp => brp.QuestaoId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 5. AtividadeQuestao
            modelBuilder.Entity<AtividadeQuestao>(entity =>
            {
                // AtividadeQuestao ---> Atividade
                entity.HasOne(aq => aq.Atividade)
                .WithMany(a => a.AtividadeQuestoes)
                .HasForeignKey(aq => aq.AtividadeId)
                .OnDelete(DeleteBehavior.Restrict);

                // AtividadeQuestao ---> Questao
                entity.HasOne(aq => aq.Questao)
                .WithMany(q => q.AtividadeQuestoes)
                .HasForeignKey(aq => aq.QuestaoId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 5. Questao ---> Alternativa
            modelBuilder.Entity<Questao>(entity =>
            {
                entity.HasMany(q => q.Alternativas)
                .WithOne(a => a.Questao)
                .HasForeignKey(q => q.QuestaoId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(q => q.AlternativaCorreta)
                .WithMany()
                .HasForeignKey(q => q.AlternativaCorretaId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 6. AlunoRealizaAtividade
            modelBuilder.Entity<AlunoRealizaAtividade>(entity =>
            {
                //modelBuilder.Entity<AlunoRealizaAtividade>()
                //.HasKey(a => new { a.AlunoId, a.AtividadeId });

                // Aluno ---> AlunoRealizaAtividades
                modelBuilder.Entity<AlunoRealizaAtividade>()
                .HasOne(arv => arv.Aluno)
                .WithMany(a => a.AlunoRealizaAtividades)
                .HasForeignKey(arv => arv.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

                // Atividade ---> AlunoRealizaAtividades
                modelBuilder.Entity<AlunoRealizaAtividade>()
                .HasOne(arv => arv.Atividade)
                .WithMany(a => a.AlunoRealizaAtividades)
                .HasForeignKey(arv => arv.AtividadeId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 7. AtividadeTurma
            modelBuilder.Entity<AtividadeTurma>(entity =>
            {
                // Atividade ---> AtividadeTurma
                entity.HasOne(at => at.Atividade)
                .WithMany(a => a.AtividadeTurmas)
                .HasForeignKey(at => at.AtividadeId)
                .OnDelete(DeleteBehavior.Restrict);

                // Turma ---> AtividadeTurma
                entity.HasOne(at => at.Turma)
                .WithMany(t => t.AtividadeTurmas)
                .HasForeignKey(at => at.TurmaId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 8. UsuarioEscolaPerfil
            modelBuilder.Entity<UsuarioEscolaPerfil>(entity =>
            {
                entity.HasKey(uep => new { uep.UsuarioId, uep.EscolaId, uep.PerfilId });

                // Usuario ---> UsuarioEscolaPerfil
                entity.HasOne(uep => uep.Usuario)
                .WithMany(u => u.UsuarioEscolaPerfis)
                .HasForeignKey(uep => uep.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

                // Escola ---> UsuarioEscolaPerfil 
                entity.HasOne(uep => uep.Escola)
                .WithMany(e => e.UsuarioEscolaPerfis)
                .HasForeignKey(uep => uep.EscolaId)
                .OnDelete(DeleteBehavior.Cascade);

                // Perfil ---> UsuarioEscolaPerfil 

                entity.HasOne(uep => uep.Perfil)
                .WithMany(p => p.UsuarioEscolaPerfis)
                .HasForeignKey(uep => uep.PerfilId)
                .OnDelete(DeleteBehavior.Cascade);
            });

            // 9. AlocacaoProfessor
            modelBuilder.Entity<AlocacaoProfessor>(entity =>
            {
                entity.HasKey(a => new { a.ProfessorId, a.TurmaId, a.DisciplinaId });

                // Professor ---> AlocacaoProfessores
                entity.HasOne(a => a.Professor)
                .WithMany(p => p.AlocacaoProfessores)
                .HasForeignKey(a => a.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);

                // Turma ---> AlocacaoProfessores
                entity.HasOne(a => a.Turma)
                .WithMany(p => p.AlocacaoProfessores)
                .HasForeignKey(a => a.TurmaId)
                .OnDelete(DeleteBehavior.Restrict);

                // Disciplina ---> AlocacaoProfessores
                entity.HasOne(a => a.Disciplina)
                .WithMany(p => p.AlocacaoProfessores)
                .HasForeignKey(a => a.DisciplinaId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 10. DesafioTurma
            modelBuilder.Entity<DesafioTurma>(entity =>
            {
                // Chave Primária Composta
                entity.HasKey(dt => new { dt.DesafioId, dt.TurmaId });

                entity.HasOne(dt => dt.Desafio)
                .WithMany(d => d.DesafioTurmas)
                .HasForeignKey(aq => aq.DesafioId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(dt => dt.Turma)
                .WithMany(t => t.DesafioTurmas)
                .HasForeignKey(dt => dt.TurmaId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 11. DesafioTurma
            modelBuilder.Entity<DesafioEscola>(entity =>
            {
                // Chave Primária Composta
                entity.HasKey(de => new { de.DesafioId, de.EscolaId });

                entity.HasOne(de => de.Desafio)
                .WithMany(d => d.DesafioEscolas)
                .HasForeignKey(de => de.DesafioId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(de => de.Escola)
                .WithMany(e => e.DesafiosEscolas)
                .HasForeignKey(de => de.EscolaId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 12. AlunoPossuiItem
            modelBuilder.Entity<AlunoPossuiItem>(entity =>
            {
                // Aluno ---> AlunoPossuiItem
                entity.HasOne(api => api.Aluno)
                .WithMany(a => a.AlunoPossuiItens)
                .HasForeignKey(api => api.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

                // Item ---> AlunoPossuiItem
                entity.HasOne(api => api.Item)
                .WithMany(i => i.AlunoPossuiItens)
                .HasForeignKey(api => api.ItemId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 13. AlunoConquista
            modelBuilder.Entity<AlunoConquista>(entity =>
            {
                // Aluno ---> AlunoConquista
                entity.HasOne(ac => ac.Aluno)
                .WithMany(a => a.AlunoConquistas)
                .HasForeignKey(api => api.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

                // Conquista ---> AlunoConquista
                entity.HasOne(ac => ac.Conquista)
                .WithMany(i => i.AlunoConquistas)
                .HasForeignKey(ac => ac.ConquistaId)
                .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
