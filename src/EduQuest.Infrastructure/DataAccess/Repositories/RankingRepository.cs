using EduQuest.Domain.DTOs;
using EduQuest.Domain.Enums;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class RankingRepository : IRankingRepository
    {
        private readonly EduQuestDbContext _context;

        public RankingRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        #region Ranking Atividades Concluídas

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosPorAtividadeConcluidaNaTurma(int turmaId)
        {
            var ranking = await _context.Alunos
                .Where(a => a.TurmaId == turmaId)
                .Select(a => new
                {
                    a.Id,
                    a.Nome,
                    Valor = (double)a.AtividadeAlunos.Count(aa => aa.Status == StatusAtividade.Concluida) // Cast para double
                })
                .OrderByDescending(r => r.Valor)
                .ThenBy(r => r.Nome) // Critério de desempate
                .ToListAsync(); // Execute a query

            // Adiciona a posição ao DTO
            return ranking.Select((r, index) => new AlunoRankingDTO
            {
                AlunoId = r.Id,
                NomeAluno = r.Nome,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosPorAtividadeConcluidaNaEscola(int escolaId)
        {
            var ranking = await _context.Alunos
               .Where(a => a.Turma != null && a.Turma.EscolaId == escolaId) // Garante que o aluno tem turma e é da escola
               .Select(a => new
               {
                   a.Id,
                   a.Nome,
                   Valor = (double)a.AtividadeAlunos.Count(aa => aa.Status == StatusAtividade.Concluida)
               })
               .OrderByDescending(r => r.Valor)
            .ThenBy(r => r.Nome)
            .ToListAsync();

            return ranking.Select((r, index) => new AlunoRankingDTO
            {
                AlunoId = r.Id,
                NomeAluno = r.Nome,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        public async Task<List<TurmaRankingDTO>> GetRankingTurmasPorMediaAtividadesConcluidasNaEscola(int escolaId)
        {
            var ranking = await _context.Turmas
                .Where(t => t.EscolaId == escolaId && t.Alunos.Any()) // Apenas turmas da escola com alunos
                .Select(t => new
                {
                    t.Id,
                    t.Descricao,
                    // Média de atividades concluídas por aluno na turma
                    Valor = t.Alunos.Average(a => (double?)a.AtividadeAlunos.Count(aa => aa.Status == StatusAtividade.Concluida)) ?? 0.0 // Trata turma sem atividades
                })
                .OrderByDescending(r => r.Valor)
                .ThenBy(r => r.Descricao)
                .ToListAsync();

            return ranking.Select((r, index) => new TurmaRankingDTO
            {
                TurmaId = r.Id,
                TurmaDescricao = r.Descricao,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        #endregion

        #region Ranking Média Nota em Atividades

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosPorMediaNotaNaTurma(int turmaId)
        {
            var ranking = await _context.Alunos
                .Where(a => a.TurmaId == turmaId && a.AtividadeAlunos.Any(aa => aa.Status == StatusAtividade.Concluida)) // Apenas alunos da turma com atividades concluídas
                .Select(a => new
                {
                    a.Id,
                    a.Nome,
                    Valor = a.AtividadeAlunos
                             .Where(aa => aa.Status == StatusAtividade.Concluida)
                             .Average(aa => (double?)aa.PontuacaoObtida) ?? 0.0 // Média, tratando null (caso não haja pontuação?)
                })
                .OrderByDescending(r => r.Valor)
                .ThenBy(r => r.Nome)
            .ToListAsync();

            return ranking.Select((r, index) => new AlunoRankingDTO
            {
                AlunoId = r.Id,
                NomeAluno = r.Nome,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosPorMediaNotaNaEscola(int escolaId)
        {
            var ranking = await _context.Alunos
               .Where(a => a.Turma != null && a.Turma.EscolaId == escolaId && a.AtividadeAlunos.Any(aa => aa.Status == StatusAtividade.Concluida))
               .Select(a => new
               {
                   a.Id,
                   a.Nome,
                   Valor = a.AtividadeAlunos
                            .Where(aa => aa.Status == StatusAtividade.Concluida)
                            .Average(aa => (double?)aa.PontuacaoObtida) ?? 0.0
               })
               .OrderByDescending(r => r.Valor)
               .ThenBy(r => r.Nome)
            .ToListAsync();

            return ranking.Select((r, index) => new AlunoRankingDTO
            {
                AlunoId = r.Id,
                NomeAluno = r.Nome,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        public async Task<List<TurmaRankingDTO>> GetRankingTurmasPorMediaGeralNotaNaEscola(int escolaId)
        {
            var ranking = await _context.Turmas
               .Where(t => t.EscolaId == escolaId && t.Alunos.Any(a => a.AtividadeAlunos.Any(aa => aa.Status == StatusAtividade.Concluida)))
               .Select(t => new
               {
                   t.Id,
                   t.Descricao,
                   // Média das médias dos alunos da turma
                   Valor = t.Alunos
                            .Where(a => a.AtividadeAlunos.Any(aa => aa.Status == StatusAtividade.Concluida))
                            .Average(a => a.AtividadeAlunos
                                           .Where(aa => aa.Status == StatusAtividade.Concluida)
                                           .Average(aa => (double?)aa.PontuacaoObtida) // Média do aluno
                                     ) ?? 0.0 // Média da turma
               })
               .OrderByDescending(r => r.Valor)
               .ThenBy(r => r.Descricao)
               .ToListAsync();

            return ranking.Select((r, index) => new TurmaRankingDTO
            {
                TurmaId = r.Id,
                TurmaDescricao = r.Descricao,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        #endregion

        //---------------------------------------------------------------------
        // Métricas de Batalhas e Questões (Alunos)
        //---------------------------------------------------------------------

        #region Ranking Batalhas Participadas

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosPorBatalhasParticipadasNaTurma(int turmaId)
        {
            var ranking = await _context.Alunos
                .Where(a => a.TurmaId == turmaId)
                .Select(a => new
                {
                    a.Id,
                    a.Nome,
                    // Conta batalhas como AlunoA ou AlunoB
                    Valor = (double)(a.BatalhasAsAlunoA.Count + a.BatalhasAsAlunoB.Count) // Ou use a.AllBatalhas.Count() se configurado corretamente
                })
                .OrderByDescending(r => r.Valor)
                .ThenBy(r => r.Nome)
            .ToListAsync();

            return ranking.Select((r, index) => new AlunoRankingDTO
            {
                AlunoId = r.Id,
                NomeAluno = r.Nome,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosPorBatalhasParticipadasNaEscola(int escolaId)
        {
            var ranking = await _context.Alunos
                .Where(a => a.Turma != null && a.Turma.EscolaId == escolaId)
                .Select(a => new
                {
                    a.Id,
                    a.Nome,
                    Valor = (double)(a.BatalhasAsAlunoA.Count + a.BatalhasAsAlunoB.Count)
                })
                .OrderByDescending(r => r.Valor)
                .ThenBy(r => r.Nome)
            .ToListAsync();

            return ranking.Select((r, index) => new AlunoRankingDTO
            {
                AlunoId = r.Id,
                NomeAluno = r.Nome,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        #endregion

        #region Ranking Batalhas Vencidas

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosPorBatalhasVencidasNaTurma(int turmaId)
        {
            var ranking = await _context.Alunos
               .Where(a => a.TurmaId == turmaId)
               .Select(a => new
               {
                   a.Id,
                   a.Nome,
                   Valor = (double)a.BatalhasWon.Count() // Usa a coleção BatalhasWon
               })
               .OrderByDescending(r => r.Valor)
               .ThenBy(r => r.Nome)
            .ToListAsync();

            return ranking.Select((r, index) => new AlunoRankingDTO
            {
                AlunoId = r.Id,
                NomeAluno = r.Nome,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosPorBatalhasVencidasNaEscola(int escolaId)
        {
            var ranking = await _context.Alunos
                .Where(a => a.Turma != null && a.Turma.EscolaId == escolaId)
                .Select(a => new
                {
                    a.Id,
                    a.Nome,
                    Valor = (double)a.BatalhasWon.Count()
                })
                .OrderByDescending(r => r.Valor)
                .ThenBy(r => r.Nome)
            .ToListAsync();

            return ranking.Select((r, index) => new AlunoRankingDTO
            {
                AlunoId = r.Id,
                NomeAluno = r.Nome,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        #endregion

        #region Ranking Questões Respondidas (Total)

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosPorQuestoesRespondidasNaTurma(int turmaId)
        {
            var ranking = await _context.Alunos
                .Where(a => a.TurmaId == turmaId)
                .Select(a => new
                {
                    a.Id,
                    a.Nome,
                    // Soma respostas em atividades E batalhas
                    Valor = (double)(a.AtividadeAlunos.SelectMany(aa => aa.AtividadeRespostas).Count() +
                                     a.RespostasInBatalhas.Count())
                })
                .OrderByDescending(r => r.Valor)
                .ThenBy(r => r.Nome)
            .ToListAsync();

            return ranking.Select((r, index) => new AlunoRankingDTO
            {
                AlunoId = r.Id,
                NomeAluno = r.Nome,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosPorQuestoesRespondidasNaEscola(int escolaId)
        {
            var ranking = await _context.Alunos
               .Where(a => a.Turma != null && a.Turma.EscolaId == escolaId)
               .Select(a => new
               {
                   a.Id,
                   a.Nome,
                   Valor = (double)(a.AtividadeAlunos.SelectMany(aa => aa.AtividadeRespostas).Count() +
                                    a.RespostasInBatalhas.Count())
               })
               .OrderByDescending(r => r.Valor)
               .ThenBy(r => r.Nome)
            .ToListAsync();

            return ranking.Select((r, index) => new AlunoRankingDTO
            {
                AlunoId = r.Id,
                NomeAluno = r.Nome,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        #endregion

        #region Ranking Questões Acertadas (Total)

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosPorQuestoesAcertadasNaTurma(int turmaId)
        {
            var ranking = await _context.Alunos
               .Where(a => a.TurmaId == turmaId)
               .Select(a => new
               {
                   a.Id,
                   a.Nome,
                   // Soma acertos em atividades E batalhas
                   Valor = (double)(a.AtividadeAlunos.SelectMany(aa => aa.AtividadeRespostas).Count(ar => ar.Acertou) +
                                    a.RespostasInBatalhas.Count(br => br.Acertou))
               })
               .OrderByDescending(r => r.Valor)
               .ThenBy(r => r.Nome)
            .ToListAsync();

            return ranking.Select((r, index) => new AlunoRankingDTO
            {
                AlunoId = r.Id,
                NomeAluno = r.Nome,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosPorQuestoesAcertadasNaEscola(int escolaId)
        {
            var ranking = await _context.Alunos
               .Where(a => a.Turma != null && a.Turma.EscolaId == escolaId)
               .Select(a => new
               {
                   a.Id,
                   a.Nome,
                   Valor = (double)(a.AtividadeAlunos.SelectMany(aa => aa.AtividadeRespostas).Count(ar => ar.Acertou) +
                                    a.RespostasInBatalhas.Count(br => br.Acertou))
               })
               .OrderByDescending(r => r.Valor)
               .ThenBy(r => r.Nome)
            .ToListAsync();

            return ranking.Select((r, index) => new AlunoRankingDTO
            {
                AlunoId = r.Id,
                NomeAluno = r.Nome,
                Valor = r.Valor,
                Posicao = index + 1
            }).ToList();
        }
        #endregion
    }
}
