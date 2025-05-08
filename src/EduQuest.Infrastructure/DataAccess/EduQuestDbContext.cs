using EduQuest.Domain.Entities;
using EduQuest.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess
{
    internal class EduQuestDbContext : DbContext
    {
        public EduQuestDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AlocacaoProfessor> AlocacaoProfessores { get; set; }
        public DbSet<Alternativa> Alternativas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<AlunoConquista> AlunoConquistas { get; set; }
        public DbSet<AlunoEstatistica> AlunoEstatisticas { get; set; }
        public DbSet<AlunoPossuiItem> AlunoPossuiItens { get; set; }
        public DbSet<AlunoProgressoCondicao> AlunoProgressoCondicoes { get; set; }
        public DbSet<AlunoProgressoDesafio> AlunoProgressoDesafios { get; set; }
        public DbSet<Atividade> Atividades { get; set; }
        public DbSet<AtividadeAluno> AtividadeAlunos { get; set; }
        public DbSet<AtividadeQuestao> AtividadeQuestoes { get; set; }
        public DbSet<AtividadeResposta> AtividadeRespostas { get; set; }
        public DbSet<AtividadeTurma> AtividadeTurmas { get; set; }
        public DbSet<Batalha> Batalhas { get; set; }
        public DbSet<BatalhaQuestao> BatalhaQuestoes { get; set; }
        public DbSet<BatalhaResposta> BatalhaRespostas { get; set; }
        public DbSet<Conquista> Conquistas { get; set; }
        //public DbSet<Curso> Cursos { get; set; }
        public DbSet<Desafio> Desafios { get; set; }
        public DbSet<DesafioCondicao> DesafioCondicoes { get; set; }
        public DbSet<DesafioEscola> DesafioEscolas { get; set; }
        public DbSet<DesafioTurma> DesafioTurmas { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Escola> Escolas { get; set; }
        public DbSet<EscolaEstatistica> EscolaEstatisticas { get; set; }
        public DbSet<Item> Itens { get; set; }
        //public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Mensagem> Mensagens { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        //public DbSet<PeriodoLetivo> PeriodosLetivos { get; set; }
        public DbSet<Questao> Questoes { get; set; }
        //public DbSet<TipoAtividade> TiposAtividade { get; set; }
        public DbSet<TipoCondicao> TiposCondicoes { get; set; }
        public DbSet<TipoUnidade> TiposUnidade { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<TurmaEstatistica> TurmaEstatisticas { get; set; }
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

            // 3. Batalha
            modelBuilder.Entity<Batalha>(entity =>
            {
                entity.HasOne(b => b.AlunoA)
                .WithMany(a => a.BatalhasAsAlunoA)
                .HasForeignKey(b => b.AlunoAId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(b => b.AlunoB)
                .WithMany(a => a.BatalhasAsAlunoB)
                .HasForeignKey(b => b.AlunoBId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 3. BatalhaQuestao
            modelBuilder.Entity<BatalhaQuestao>(entity =>
            {
                // Batalha ---> BatalhaQuestao
                entity.HasOne(bq => bq.Batalha)
                .WithMany(b => b.BatalhaQuestoes)
                .HasForeignKey(bq => bq.BatalhaId)
                .OnDelete(DeleteBehavior.Cascade);

                // Questao ---> BatalhaQuestao
                entity.HasOne(bq => bq.Questao)
                .WithMany(b => b.BatalhaQuestoes)
                .HasForeignKey(bq => bq.QuestaoId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 4. BatalhaResposta
            modelBuilder.Entity<BatalhaResposta>(entity =>
            {
                // BatalhaResposta ---> Batalha
                entity.HasOne(br => br.Batalha)
                .WithMany(b => b.BatalhaRespostas)
                .HasForeignKey(br => br.BatalhaId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(br => br.Questao)
                .WithMany(q => q.BatalhaRespostas)
                .HasForeignKey(br => br.QuestaoId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(br => br.Aluno)
                .WithMany(a => a.RespostasInBatalhas)
                .HasForeignKey(br => br.AlunoId)
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

            // 6. AtividadeTurma
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

            // 7. AtividadeAluno
            modelBuilder.Entity<AtividadeAluno>(entity =>
            {
                //modelBuilder.Entity<AtividadeAluno>()
                //.HasKey(a => new { a.AlunoId, a.AtividadeId });

                // Aluno ---> AtividadeAluno
                modelBuilder.Entity<AtividadeAluno>()
                .HasOne(arv => arv.Aluno)
                .WithMany(a => a.AtividadeAlunos)
                .HasForeignKey(arv => arv.AlunoId)
                .OnDelete(DeleteBehavior.Cascade);

                // Atividade ---> AtividadeAluno
                modelBuilder.Entity<AtividadeAluno>()
                .HasOne(arv => arv.Atividade)
                .WithMany(a => a.AtividadeAlunos)
                .HasForeignKey(arv => arv.AtividadeId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 7. AtividadeResposta
            modelBuilder.Entity<AtividadeResposta>(entity =>
            {
                //modelBuilder.Entity<AtividadeAluno>()
                //.HasKey(a => new { a.AlunoId, a.AtividadeId });

                // Aluno ---> AtividadeResposta
                entity.HasOne(ar => ar.AtividadeAluno)
                .WithMany(aa => aa.AtividadeRespostas)
                .HasForeignKey(ar => ar.AtividadeAlunoId)
                .OnDelete(DeleteBehavior.Restrict);

                // Questao ---> AtividadeResposta
                entity.HasOne(ar => ar.Questao)
                .WithMany(q => q.AtividadeRespostas)
                .HasForeignKey(br => br.QuestaoId)
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

            // 14. AlunoProgressoDesafio
            modelBuilder.Entity<AlunoProgressoDesafio>(entity =>
            {
                // Aluno ---> AlunoProgressoDesafio
                entity.HasOne(ap => ap.Aluno)
                .WithMany(a => a.AlunoProgressoDesafios)
                .HasForeignKey(ap => ap.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

                // Desafio ---> AlunoProgressoDesafio
                entity.HasOne(ap => ap.Desafio)
                .WithMany(d => d.AlunoProgressoDesafios)
                .HasForeignKey(ap => ap.DesafioId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 15. AlunoProgressoCondicao
            modelBuilder.Entity<AlunoProgressoCondicao>(entity =>
            {
                // Aluno ---> AlunoProgressoCondicao
                entity.HasOne(ap => ap.Aluno)
                .WithMany(a => a.AlunoProgressoCondicoes)
                .HasForeignKey(ap => ap.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

                // Desafio ---> AlunoProgressoCondicao
                entity.HasOne(ap => ap.DesafioCondicao)
                .WithMany(d => d.AlunoProgressoCondicoes)
                .HasForeignKey(ap => ap.DesafioConficaoId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            // 16. Mensagem ---> Usuario
            modelBuilder.Entity<Mensagem>(entity =>
            {
                entity.HasOne(m => m.Remetente)
                .WithMany(r => r.MensagensEnviadas)
                .HasForeignKey(m => m.RemetenteId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Mensagem>(entity =>
            {
                entity.HasOne(m => m.Destinatario)
                .WithMany(r => r.MensagensRecebidas)
                .HasForeignKey(m => m.DestinatarioId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            //// 17. Turma ---> PeriodoLetivo
            //modelBuilder.Entity<Turma>(entity =>
            //{
            //    entity.HasOne(t => t.PeriodoLetivo)
            //    .WithMany(p => p.Turmas)
            //    .HasForeignKey(t => t.PeriodoLetivoId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //});

            modelBuilder.Entity<AlunoEstatistica>()
                .HasKey(ae => ae.AlunoId); // PK

            modelBuilder.Entity<AlunoEstatistica>()
                .HasOne(ae => ae.Aluno)
                .WithOne() // ou .WithOne(a => a.AlunoEstatistica), se tiver navegação inversa
                .HasForeignKey<AlunoEstatistica>(ae => ae.AlunoId) // FK
                .OnDelete(DeleteBehavior.Cascade); // ou conforme necessário

            modelBuilder.Entity<TurmaEstatistica>()
                .HasKey(ae => ae.TurmaId); // PK

            modelBuilder.Entity<TurmaEstatistica>()
                .HasOne(ae => ae.Turma)
                .WithOne() // ou .WithOne(a => a.AlunoEstatistica), se tiver navegação inversa
                .HasForeignKey<TurmaEstatistica>(ae => ae.TurmaId) // FK
                .OnDelete(DeleteBehavior.Cascade); // ou conforme necessário

            modelBuilder.Entity<EscolaEstatistica>()
                .HasKey(ae => ae.EscolaId); // PK

            modelBuilder.Entity<EscolaEstatistica>()
                .HasOne(ae => ae.Escola)
                .WithOne() // ou .WithOne(a => a.AlunoEstatistica), se tiver navegação inversa
                .HasForeignKey<EscolaEstatistica>(ae => ae.EscolaId) // FK
                .OnDelete(DeleteBehavior.Cascade); // ou conforme necessário

            // SEED DATABASE
            modelBuilder.Entity<TipoUnidade>().HasData(
                new TipoUnidade { Id = 1, Nome = "Escola Municipal de Ensino Fundamental", Descricao = "Escola pública, administrada pela prefeitura de um município, que oferece o ensino fundamental (anos iniciais e finais). ", Sigla = "EMEF" }
            );

            modelBuilder.Entity<Escola>().HasData(
                new Escola { Id = 1, Nome = "Escola Exemplo", Sigla = "EE", Inep = "12016365", Telefone = "3251-2266", Ativo = true, TipoUnidadeId = 1 }
            );

            modelBuilder.Entity<Turma>().HasData(
                new Turma { Id = 1, Descricao = "6º Ano A", EscolaId = 1, Turno = 1, Ativo = true, NivelEscolar = 6, Ano = 2025 },
                new Turma { Id = 2, Descricao = "6º Ano B", EscolaId = 1, Turno = 1, Ativo = true, NivelEscolar = 6, Ano = 2025 }
            );

            modelBuilder.Entity<Disciplina>().HasData(
                new Disciplina { Id = 1, Descricao = "Matemática", Sigla = "MAT" },
                new Disciplina { Id = 2, Descricao = "Português", Sigla = "PORT" },
                new Disciplina { Id = 3, Descricao = "História", Sigla = "HIST" },
                new Disciplina { Id = 4, Descricao = "Geografia", Sigla = "GEO" },
                new Disciplina { Id = 5, Descricao = "Ciências", Sigla = "CIEN" },
                new Disciplina { Id = 6, Descricao = "Artes", Sigla = "ART" },
                new Disciplina { Id = 7, Descricao = "Educação Física", Sigla = "EDF" }
            );

            modelBuilder.Entity<Perfil>().HasData(
                new Perfil { Id = 1, Nome = "Admin", Descricao = "Responsável pela gestão geral da plataforma, com acesso total para configurar escolas, usuários e permissões." },
                new Perfil { Id = 2, Nome = "Gestor", Descricao = "Supervisiona as atividades de uma escola específica, podendo gerenciar professores, alunos e turmas." },
                new Perfil { Id = 3, Nome = "Professor", Descricao = "Responsável pelo acompanhamento pedagógico dos alunos, criação de atividades e lançamento de avaliações." }
            );

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nome = "João Admin", DataNascimento = DateOnly.FromDateTime(new DateTime(2025, 04, 12, 10, 20, 0).AddYears(-28)), Email = "joao@eduquest.com", SenhaHash = "$2a$11$l.1.XtCPblw2zZZS.UIu2eEOZiaQoypQka7N4rHAq0Qs6l/0dyvga", UsuarioIdentifier = Guid.Parse("3f3a2f14-56e1-4e1e-8d91-9f63d5f3d402"), DataUltimoLogin = new DateTime(2025, 04, 12, 10, 20, 0), DataCadastro = new DateTime(2025, 04, 12, 10, 20, 0), Ativo = true },
                new Usuario { Id = 2, Nome = "Maria Gestora", DataNascimento = DateOnly.FromDateTime(new DateTime(2025, 04, 12, 10, 20, 0).AddYears(-32)), Email = "maria@eduquest.com", SenhaHash = "$2a$11$/nTO8u7SXBROhis7RGn56OR0mWhxh7Tx.lf2P/F63R/TbHo/oWlZ.", UsuarioIdentifier = Guid.Parse("09d8a9cc-c23d-4b1f-8e14-ff12fd17c248"), DataUltimoLogin = new DateTime(2025, 04, 12, 10, 20, 0), DataCadastro = new DateTime(2025, 04, 12, 10, 20, 0), Ativo = true },
                new Usuario { Id = 3, Nome = "Alice Professora", DataNascimento = DateOnly.FromDateTime(new DateTime(2025, 04, 12, 10, 20, 0).AddYears(-26)), Email = "alice@eduquest.com", SenhaHash = "$2a$11$mNIy4y97smFq6Vzjj0o6TOxkJ/472tnI4Qv8FQ/3smJjH/Rp4CEZS", UsuarioIdentifier = Guid.Parse("f6f7b3b4-6e3e-4bc9-95f7-0d15f0e034c9"), DataUltimoLogin = new DateTime(2025, 04, 12, 10, 20, 0), DataCadastro = new DateTime(2025, 04, 12, 10, 20, 0), Ativo = true },
                new Usuario { Id = 4, Nome = "Diego Professor", DataNascimento = DateOnly.FromDateTime(new DateTime(2025, 04, 12, 10, 20, 0).AddYears(-23)), Email = "diego@eduquest.com", SenhaHash = "$2a$11$7aKDv6ML6d7whmHhJYUes.uBNAAcLM.dsIUOhCg1GxX5hXk/SCj62", UsuarioIdentifier = Guid.Parse("61a3b16d-1208-4ce4-b3c6-ccbe0ab0acdf"), DataUltimoLogin = new DateTime(2025, 04, 12, 10, 20, 0), DataCadastro = new DateTime(2025, 04, 12, 10, 20, 0), Ativo = true }
            );

            modelBuilder.Entity<UsuarioEscolaPerfil>().HasData(
                new UsuarioEscolaPerfil { UsuarioId = 1, EscolaId = 1, PerfilId = 1, Ativo = true },
                new UsuarioEscolaPerfil { UsuarioId = 2, EscolaId = 1, PerfilId = 2, Ativo = true },
                new UsuarioEscolaPerfil { UsuarioId = 3, EscolaId = 1, PerfilId = 3, Ativo = true },
                new UsuarioEscolaPerfil { UsuarioId = 4, EscolaId = 1, PerfilId = 3, Ativo = true }
            );

            modelBuilder.Entity<AlocacaoProfessor>().HasData(
                new AlocacaoProfessor { ProfessorId = 3, TurmaId = 1, DisciplinaId = 2 },
                new AlocacaoProfessor { ProfessorId = 3, TurmaId = 2, DisciplinaId = 2 },
                new AlocacaoProfessor { ProfessorId = 4, TurmaId = 1, DisciplinaId = 1 },
                new AlocacaoProfessor { ProfessorId = 4, TurmaId = 2, DisciplinaId = 1 }
            );

            // -- SENHAS -- 
            //"Admin@123"
            //"Gestora@123"
            //"Professora@123"
            //"Professor@123"
            //"Aluno@123"

            modelBuilder.Entity<Aluno>().HasData(
                new Aluno { Id = 5, Nome = "Lucas Aluno", DataNascimento = DateOnly.FromDateTime(new DateTime(2025, 04, 12, 10, 20, 0).AddYears(-10)), Email = "lucas@eduquest.com", SenhaHash = "$2a$11$zaRQt0VkVQkiPn/dMiKWuO6bpK/nAqyinCMuLk7tXSD3YPVbMAKtO", UsuarioIdentifier = Guid.Parse("a8dd0cd3-e0a1-4a2c-a18d-ec7f69c82872"), DataUltimoLogin = new DateTime(2025, 04, 12, 10, 20, 0), DataCadastro = new DateTime(2025, 04, 12, 10, 20, 0), Ativo = true, XpAtual = 1220, Nivel = 1, SaldoMoedas = 1000, StreakDiasConsecutivos = 6, DataUltimoAcessoStreak = new DateTime(2025, 04, 12, 10, 20, 0), TurmaId = 1 },
                new Aluno { Id = 6, Nome = "Israel Aluno", DataNascimento = DateOnly.FromDateTime(new DateTime(2025, 04, 12, 10, 20, 0).AddYears(-11)), Email = "israel@eduquest.com", SenhaHash = "$2a$11$zaRQt0VkVQkiPn/dMiKWuO6bpK/nAqyinCMuLk7tXSD3YPVbMAKtO", UsuarioIdentifier = Guid.Parse("772b5cbe-df26-4f16-90b5-4e0fd472e2c6"), DataUltimoLogin = new DateTime(2025, 04, 12, 10, 20, 0), DataCadastro = new DateTime(2025, 04, 12, 10, 20, 0), Ativo = true, XpAtual = 1180, Nivel = 1, SaldoMoedas = 1000, StreakDiasConsecutivos = 4, DataUltimoAcessoStreak = new DateTime(2025, 04, 12, 10, 20, 0), TurmaId = 1 },
                new Aluno { Id = 7, Nome = "Anker Aluno", DataNascimento = DateOnly.FromDateTime(new DateTime(2025, 04, 12, 10, 20, 0).AddYears(-12)), Email = "anker@eduquest.com", SenhaHash = "$2a$11$zaRQt0VkVQkiPn/dMiKWuO6bpK/nAqyinCMuLk7tXSD3YPVbMAKtO", UsuarioIdentifier = Guid.Parse("2eaf4c9b-6bc9-4463-8cf4-27911b34939e"), DataUltimoLogin = new DateTime(2025, 04, 12, 10, 20, 0), DataCadastro = new DateTime(2025, 04, 12, 10, 20, 0), Ativo = true, XpAtual = 2430, Nivel = 2, SaldoMoedas = 2000, StreakDiasConsecutivos = 7, DataUltimoAcessoStreak = new DateTime(2025, 04, 12, 10, 20, 0), TurmaId = 2 }
            );

            modelBuilder.Entity<Atividade>().HasData(
                new Atividade { Id = 1, Titulo = "Quiz de Frações", Descricao = "Quiz de Frações", Valor = 10, TempoLimiteSegundos = 600, XpRecompensa = 100, MoedasRecompensa = 100, DataCriacao = new DateTime(2025, 04, 12, 10, 20, 0), ProfessorId = 4 },
                new Atividade { Id = 2, Titulo = "Atividade de Português", Descricao = "Atividade de Português", Valor = 10, TempoLimiteSegundos = 600, XpRecompensa = 100, MoedasRecompensa = 100, DataCriacao = new DateTime(2025, 04, 12, 10, 20, 0), ProfessorId = 3 }
            );

            modelBuilder.Entity<Questao>().HasData(
                new Questao { Id = 2, Enunciado = "Quanto é 5 + 3?", DisciplinaId = 1, NivelEscolar = 6, UsuarioCriacaoId = 4 },
                new Questao { Id = 3, Enunciado = "Qual é a raiz quadrada de 16?", DisciplinaId = 1, NivelEscolar = 6, UsuarioCriacaoId = 4 },
                new Questao { Id = 4, Enunciado = "Quanto é 9 - 4?", DisciplinaId = 1, NivelEscolar = 6, UsuarioCriacaoId = 4 },
                new Questao { Id = 5, Enunciado = "Qual é o dobro de 7?", DisciplinaId = 1, NivelEscolar = 6, UsuarioCriacaoId = 4 },
                new Questao { Id = 6, Enunciado = "Quanto é 12 ÷ 3?", DisciplinaId = 1, NivelEscolar = 6, UsuarioCriacaoId = 4 },
                new Questao { Id = 7, Enunciado = "Quanto é 3²?", DisciplinaId = 1, NivelEscolar = 6, UsuarioCriacaoId = 4 },
                new Questao { Id = 8, Enunciado = "Qual é o valor de 10% de 100?", DisciplinaId = 1, NivelEscolar = 6, UsuarioCriacaoId = 4 },
                new Questao { Id = 9, Enunciado = "Quanto é 8 × 6?", DisciplinaId = 1, NivelEscolar = 6, UsuarioCriacaoId = 4 },
                new Questao { Id = 10, Enunciado = "Quanto é 14 + 5?", DisciplinaId = 1, NivelEscolar = 6, UsuarioCriacaoId = 4 },
                new Questao { Id = 11, Enunciado = "Qual é a metade de 30?", DisciplinaId = 1, NivelEscolar = 6, UsuarioCriacaoId = 4 },
                new Questao { Id = 12, Enunciado = "Qual é o sujeito da frase: 'O menino correu para casa'?", DisciplinaId = 2, NivelEscolar = 6, UsuarioCriacaoId = 3 },
                new Questao { Id = 13, Enunciado = "Qual a classe gramatical da palavra 'feliz'?", DisciplinaId = 2, NivelEscolar = 6, UsuarioCriacaoId = 3 },
                new Questao { Id = 14, Enunciado = "Identifique a figura de linguagem: 'O tempo voa.'", DisciplinaId = 2, NivelEscolar = 6, UsuarioCriacaoId = 3 },
                new Questao { Id = 15, Enunciado = "Qual a função do pronome na frase: 'Ela saiu cedo'?", DisciplinaId = 2, NivelEscolar = 6, UsuarioCriacaoId = 3 },
                new Questao { Id = 16, Enunciado = "Qual é o plural de 'cidadão'?", DisciplinaId = 2, NivelEscolar = 6, UsuarioCriacaoId = 3 },
                new Questao { Id = 17, Enunciado = "Qual a conjugação do verbo 'amar' na 1ª pessoa do singular no presente?", DisciplinaId = 2, NivelEscolar = 6, UsuarioCriacaoId = 3 },
                new Questao { Id = 18, Enunciado = "Qual é a forma correta: 'houveram problemas' ou 'houve problemas'?", DisciplinaId = 2, NivelEscolar = 6, UsuarioCriacaoId = 3 },
                new Questao { Id = 19, Enunciado = "Qual o antônimo de 'alegre'?", DisciplinaId = 2, NivelEscolar = 6, UsuarioCriacaoId = 3 },
                new Questao { Id = 20, Enunciado = "A palavra 'felicidade' é derivada de que outra palavra?", DisciplinaId = 2, NivelEscolar = 6, UsuarioCriacaoId = 3 },
                new Questao { Id = 21, Enunciado = "Qual a função da vírgula em: 'Maria, vá já dormir.'?", DisciplinaId = 2, NivelEscolar = 6, UsuarioCriacaoId = 3 }
            );

            modelBuilder.Entity<Alternativa>().HasData(
                new Alternativa { Id = 3, QuestaoId = 2, Descricao = "8", Ordem = 1 },
                new Alternativa { Id = 4, QuestaoId = 2, Descricao = "9", Ordem = 2 },
                new Alternativa { Id = 5, QuestaoId = 3, Descricao = "4", Ordem = 1 },
                new Alternativa { Id = 6, QuestaoId = 3, Descricao = "5", Ordem = 2 },
                new Alternativa { Id = 7, QuestaoId = 4, Descricao = "5", Ordem = 1 },
                new Alternativa { Id = 8, QuestaoId = 4, Descricao = "6", Ordem = 2 },
                new Alternativa { Id = 9, QuestaoId = 5, Descricao = "14", Ordem = 1 },
                new Alternativa { Id = 10, QuestaoId = 5, Descricao = "12", Ordem = 2 },
                new Alternativa { Id = 11, QuestaoId = 6, Descricao = "4", Ordem = 1 },
                new Alternativa { Id = 12, QuestaoId = 6, Descricao = "3", Ordem = 2 },
                new Alternativa { Id = 13, QuestaoId = 7, Descricao = "9", Ordem = 1 },
                new Alternativa { Id = 14, QuestaoId = 7, Descricao = "6", Ordem = 2 },
                new Alternativa { Id = 15, QuestaoId = 8, Descricao = "10", Ordem = 1 },
                new Alternativa { Id = 16, QuestaoId = 8, Descricao = "20", Ordem = 2 },
                new Alternativa { Id = 17, QuestaoId = 9, Descricao = "48", Ordem = 1 },
                new Alternativa { Id = 18, QuestaoId = 9, Descricao = "56", Ordem = 2 },
                new Alternativa { Id = 19, QuestaoId = 10, Descricao = "19", Ordem = 1 },
                new Alternativa { Id = 20, QuestaoId = 10, Descricao = "20", Ordem = 2 },
                new Alternativa { Id = 21, QuestaoId = 11, Descricao = "15", Ordem = 1 },
                new Alternativa { Id = 22, QuestaoId = 11, Descricao = "12", Ordem = 2 },
                new Alternativa { Id = 23, QuestaoId = 12, Descricao = "O menino", Ordem = 1 },
                new Alternativa { Id = 24, QuestaoId = 12, Descricao = "Para casa", Ordem = 2 },
                new Alternativa { Id = 25, QuestaoId = 13, Descricao = "Adjetivo", Ordem = 1 },
                new Alternativa { Id = 26, QuestaoId = 13, Descricao = "Substantivo", Ordem = 2 },
                new Alternativa { Id = 27, QuestaoId = 14, Descricao = "Metáfora", Ordem = 1 },
                new Alternativa { Id = 28, QuestaoId = 14, Descricao = "Comparação", Ordem = 2 },
                new Alternativa { Id = 29, QuestaoId = 15, Descricao = "Sujeito", Ordem = 2 },
                new Alternativa { Id = 30, QuestaoId = 15, Descricao = "Pronome pessoal do caso reto", Ordem = 1 },
                new Alternativa { Id = 31, QuestaoId = 16, Descricao = "Cidadãos", Ordem = 1 },
                new Alternativa { Id = 32, QuestaoId = 16, Descricao = "Cidadães", Ordem = 2 },
                new Alternativa { Id = 33, QuestaoId = 17, Descricao = "Amo", Ordem = 1 },
                new Alternativa { Id = 34, QuestaoId = 17, Descricao = "Amarei", Ordem = 2 },
                new Alternativa { Id = 35, QuestaoId = 18, Descricao = "'Houve problemas'", Ordem = 1 },
                new Alternativa { Id = 36, QuestaoId = 18, Descricao = "'Houveram problemas'", Ordem = 2 },
                new Alternativa { Id = 37, QuestaoId = 19, Descricao = "Triste", Ordem = 1 },
                new Alternativa { Id = 38, QuestaoId = 19, Descricao = "Feliz", Ordem = 2 },
                new Alternativa { Id = 39, QuestaoId = 20, Descricao = "Feliz", Ordem = 1 },
                new Alternativa { Id = 40, QuestaoId = 20, Descricao = "Felicitar", Ordem = 2 },
                new Alternativa { Id = 41, QuestaoId = 21, Descricao = "Vocativo", Ordem = 1 },
                new Alternativa { Id = 42, QuestaoId = 21, Descricao = "Enumeração", Ordem = 2 }
            );

            modelBuilder.Entity<AtividadeQuestao>().HasData(
                new AtividadeQuestao { Id = 1, AtividadeId = 1, QuestaoId = 2, Ordem = 1 },
                new AtividadeQuestao { Id = 2, AtividadeId = 1, QuestaoId = 3, Ordem = 2 },
                new AtividadeQuestao { Id = 3, AtividadeId = 1, QuestaoId = 4, Ordem = 3 },
                new AtividadeQuestao { Id = 4, AtividadeId = 1, QuestaoId = 5, Ordem = 4 },
                new AtividadeQuestao { Id = 5, AtividadeId = 1, QuestaoId = 6, Ordem = 5 },
                new AtividadeQuestao { Id = 6, AtividadeId = 1, QuestaoId = 7, Ordem = 6 },
                new AtividadeQuestao { Id = 7, AtividadeId = 1, QuestaoId = 8, Ordem = 7 },
                new AtividadeQuestao { Id = 8, AtividadeId = 1, QuestaoId = 9, Ordem = 8 },
                new AtividadeQuestao { Id = 9, AtividadeId = 1, QuestaoId = 10, Ordem = 9 },
                new AtividadeQuestao { Id = 10, AtividadeId = 1, QuestaoId = 11, Ordem = 10 },
                new AtividadeQuestao { Id = 11, AtividadeId = 2, QuestaoId = 12, Ordem = 1 },
                new AtividadeQuestao { Id = 12, AtividadeId = 2, QuestaoId = 13, Ordem = 2 },
                new AtividadeQuestao { Id = 13, AtividadeId = 2, QuestaoId = 14, Ordem = 3 },
                new AtividadeQuestao { Id = 14, AtividadeId = 2, QuestaoId = 15, Ordem = 4 },
                new AtividadeQuestao { Id = 15, AtividadeId = 2, QuestaoId = 16, Ordem = 5 },
                new AtividadeQuestao { Id = 16, AtividadeId = 2, QuestaoId = 17, Ordem = 6 },
                new AtividadeQuestao { Id = 17, AtividadeId = 2, QuestaoId = 18, Ordem = 7 },
                new AtividadeQuestao { Id = 18, AtividadeId = 2, QuestaoId = 19, Ordem = 8 },
                new AtividadeQuestao { Id = 19, AtividadeId = 2, QuestaoId = 2, Ordem = 9 },
                new AtividadeQuestao { Id = 20, AtividadeId = 2, QuestaoId = 2, Ordem = 10 }
            );

            modelBuilder.Entity<AtividadeTurma>().HasData(
                new AtividadeTurma { Id = 1, AtividadeId = 1, TurmaId = 1, DisciplinaId = 1, DataAtribuicao = new DateTime(2025, 04, 12, 10, 20, 0), DataEntrega = new DateTime(2025, 04, 12, 10, 20, 0).AddDays(6) },
                new AtividadeTurma { Id = 2, AtividadeId = 1, TurmaId = 2, DisciplinaId = 1, DataAtribuicao = new DateTime(2025, 04, 12, 10, 20, 0), DataEntrega = new DateTime(2025, 04, 12, 10, 20, 0).AddDays(5) },
                new AtividadeTurma { Id = 3, AtividadeId = 2, TurmaId = 1, DisciplinaId = 2, DataAtribuicao = new DateTime(2025, 04, 12, 10, 20, 0), DataEntrega = new DateTime(2025, 04, 12, 10, 20, 0).AddDays(6) },
                new AtividadeTurma { Id = 4, AtividadeId = 2, TurmaId = 2, DisciplinaId = 2, DataAtribuicao = new DateTime(2025, 04, 12, 10, 20, 0), DataEntrega = new DateTime(2025, 04, 12, 10, 20, 0).AddDays(5) }
            );

            modelBuilder.Entity<AtividadeAluno>().HasData(
                new AtividadeAluno { Id = 1, AlunoId = 5, AtividadeId = 1, Status = StatusAtividade.Concluida, DataInicio = new DateTime(2025, 04, 12, 10, 20, 0).AddMinutes(-1), DataFim = new DateTime(2025, 04, 12, 10, 20, 0), FeedbackProfessor = "Bom", MoedasGanhas = 100, XpGanho = 100, PontuacaoObtida = 10 },
                new AtividadeAluno { Id = 2, AlunoId = 5, AtividadeId = 2, Status = StatusAtividade.Pendente }
            );

            modelBuilder.Entity<AtividadeResposta>().HasData(
                new AtividadeResposta { Id = 1, AtividadeAlunoId = 1, QuestaoId = 2, AlternativaEscolhaId = 3, Acertou = true, DataResposta = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AtividadeResposta { Id = 2, AtividadeAlunoId = 1, QuestaoId = 3, AlternativaEscolhaId = 5, Acertou = true, DataResposta = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AtividadeResposta { Id = 3, AtividadeAlunoId = 1, QuestaoId = 4, AlternativaEscolhaId = 7, Acertou = true, DataResposta = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AtividadeResposta { Id = 4, AtividadeAlunoId = 1, QuestaoId = 5, AlternativaEscolhaId = 9, Acertou = true, DataResposta = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AtividadeResposta { Id = 5, AtividadeAlunoId = 1, QuestaoId = 6, AlternativaEscolhaId = 11, Acertou = true, DataResposta = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AtividadeResposta { Id = 6, AtividadeAlunoId = 1, QuestaoId = 7, AlternativaEscolhaId = 13, Acertou = true, DataResposta = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AtividadeResposta { Id = 7, AtividadeAlunoId = 1, QuestaoId = 8, AlternativaEscolhaId = 15, Acertou = true, DataResposta = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AtividadeResposta { Id = 8, AtividadeAlunoId = 1, QuestaoId = 9, AlternativaEscolhaId = 17, Acertou = true, DataResposta = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AtividadeResposta { Id = 9, AtividadeAlunoId = 1, QuestaoId = 10, AlternativaEscolhaId = 19, Acertou = true, DataResposta = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AtividadeResposta { Id = 10, AtividadeAlunoId = 1, QuestaoId = 11, AlternativaEscolhaId = 21, Acertou = true, DataResposta = new DateTime(2025, 04, 12, 10, 20, 0) }
            );


            modelBuilder.Entity<Batalha>().HasData(
                new Batalha { Id = 1, DataCriacao = new DateTime(2025, 04, 12, 10, 20, 0), DataInicio = new DateTime(2025, 04, 12, 10, 20, 0), TempoLimiteSegundos = 6000000, Status = StatusBatalha.AguardandoInicio, XpConcedidoVencedor = 100, XpConcedidoPerdedor = 50, MoedasConcedidasVencedor = 100, MoedasConcedidasPerdedor = 50, AlunoAId = 5, AlunoBId = 6 }
            );

            modelBuilder.Entity<BatalhaQuestao>().HasData(
                new BatalhaQuestao { Id = 1, BatalhaId = 1, QuestaoId = 2, Ordem = 1 },
                new BatalhaQuestao { Id = 2, BatalhaId = 1, QuestaoId = 3, Ordem = 2 },
                new BatalhaQuestao { Id = 3, BatalhaId = 1, QuestaoId = 4, Ordem = 3 },
                new BatalhaQuestao { Id = 4, BatalhaId = 1, QuestaoId = 15, Ordem = 4 },
                new BatalhaQuestao { Id = 5, BatalhaId = 1, QuestaoId = 16, Ordem = 5 }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1,
                    Nome = "Avatar Ninja Azul",
                    Descricao = "Avatar estilizado com roupa ninja azul.",
                    Tipo = TipoItem.Avatar,
                    Custo = 300,
                    XpDesbloqueio = 1000,
                    ImagemBase64 = string.Empty
                },
                new Item
                {
                    Id = 2,
                    Nome = "Avatar Robô Futurista",
                    Descricao = "Avatar com aparência metálica e olhos brilhantes.",
                    Tipo = TipoItem.Avatar,
                    Custo = 300,
                    XpDesbloqueio = 1000,
                    ImagemBase64 = string.Empty
                },
                new Item
                {
                    Id = 3,
                    Nome = "Borda Dourada para Perfil",
                    Descricao = "Moldura elegante dourada ao redor da imagem de perfil.",
                    Tipo = TipoItem.Moldura,
                    Custo = 300,
                    XpDesbloqueio = 1000,
                    ImagemBase64 = string.Empty
                },
                new Item
                {
                    Id = 4,
                    Nome = "Borda de Cristal Azul",
                    Descricao = "Moldura azulada com efeito de cristal.",
                    Tipo = TipoItem.Moldura,
                    Custo = 300,
                    XpDesbloqueio = 1000,
                    ImagemBase64 = string.Empty
                },
                new Item
                {
                    Id = 5,
                    Nome = "Tema Noturno",
                    Descricao = "Altera a interface da plataforma para tons escuros.",
                    Tipo = TipoItem.Tema,
                    Custo = 300,
                    XpDesbloqueio = 2000,
                    ImagemBase64 = string.Empty
                },
                new Item
                {
                    Id = 6,
                    Nome = "Tema Floresta Encantada",
                    Descricao = "Transforma o ambiente da plataforma em uma floresta mágica.",
                    Tipo = TipoItem.Tema,
                    Custo = 300,
                    XpDesbloqueio = 3000,
                    ImagemBase64 = string.Empty
                },
                new Item
                {
                    Id = 7,
                    Nome = "Tema Cibernético",
                    Descricao = "Interface com neon e circuitos inspirada no futuro.",
                    Tipo = TipoItem.Tema,
                    Custo = 300,
                    XpDesbloqueio = 4000,
                    ImagemBase64 = string.Empty
                },
                new Item
                {
                    Id = 8,
                    Nome = "Tema Oceano Profundo",
                    Descricao = "Visual marinho com tons de azul e bolhas.",
                    Tipo = TipoItem.Tema,
                    Custo = 300,
                    XpDesbloqueio = 5000,
                    ImagemBase64 = string.Empty
                }
            );

            modelBuilder.Entity<AlunoPossuiItem>().HasData(
                new AlunoPossuiItem { Id = 1, AlunoId = 5, ItemId = 1, DataAquisicao = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AlunoPossuiItem { Id = 2, AlunoId = 5, ItemId = 2, DataAquisicao = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AlunoPossuiItem { Id = 3, AlunoId = 5, ItemId = 3, DataAquisicao = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AlunoPossuiItem { Id = 4, AlunoId = 5, ItemId = 4, DataAquisicao = new DateTime(2025, 04, 12, 10, 20, 0) },
                new AlunoPossuiItem { Id = 5, AlunoId = 6, ItemId = 5, DataAquisicao = new DateTime(2025, 04, 12, 10, 20, 0) }
            );
        }
    }
}
