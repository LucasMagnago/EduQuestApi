using EduQuest.Domain.DTOs;
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

        //---------------------------------------------------------------------
        // RANKING DE ALUNOS
        //---------------------------------------------------------------------

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosByAtividadesConcluidasInTurma(int turmaId)
        {
            return await _context.AlunoEstatisticas
                .Where(a => a.Aluno.Turma != null && a.Aluno.TurmaId == turmaId)
                .OrderByDescending(a => a.AtividadesConcluidas)
                .Select((a, index) => new AlunoRankingDTO
                {
                    AlunoId = a.AlunoId,
                    NomeAluno = a.Aluno.Nome,
                    Descricao = "Ranking de alunos na turma por atividades concluídas",
                    Posicao = index + 1,
                    Valor = a.AtividadesConcluidas
                })
                .ToListAsync();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosByAtividadesConcluidasInEscola(int escolaId)
        {
            return await _context.AlunoEstatisticas
                .Where(a => a.Aluno.Turma != null && a.Aluno.Turma.EscolaId == escolaId)
                .OrderByDescending(a => a.AtividadesConcluidas)
                .Select((a, index) => new AlunoRankingDTO
                {
                    AlunoId = a.AlunoId,
                    NomeAluno = a.Aluno.Nome,
                    Descricao = "Ranking de alunos na escola por atividades concluídas",
                    Posicao = index + 1,
                    Valor = a.AtividadesConcluidas
                })
                .ToListAsync();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosByMediaNotasInTurma(int turmaId)
        {
            return await _context.AlunoEstatisticas
                .Where(a => a.Aluno.Turma != null && a.Aluno.TurmaId == turmaId && a.QuantidadeNotasValidas > 0)
                .OrderByDescending(a => a.MediaNotasNormalizadas)
                .Select((a, index) => new AlunoRankingDTO
                {
                    AlunoId = a.AlunoId,
                    NomeAluno = a.Aluno.Nome,
                    Descricao = "Ranking de alunos na turma por média nas atividades",
                    Posicao = index + 1,
                    Valor = a.MediaNotasNormalizadas
                })
                .ToListAsync();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosByMediaNotasInEscola(int escolaId)
        {
            return await _context.AlunoEstatisticas
                .Where(a => a.Aluno.Turma != null && a.Aluno.Turma.EscolaId == escolaId && a.QuantidadeNotasValidas > 0)
                .OrderByDescending(a => a.MediaNotasNormalizadas)
                .Select((a, index) => new AlunoRankingDTO
                {
                    AlunoId = a.AlunoId,
                    NomeAluno = a.Aluno.Nome,
                    Descricao = "Ranking de alunos na escola por média nas atividades",
                    Posicao = index + 1,
                    Valor = a.MediaNotasNormalizadas
                })
                .ToListAsync();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosByBatalhasParticipadasInTurma(int turmaId)
        {
            return await _context.AlunoEstatisticas
                .Where(a => a.Aluno.Turma != null && a.Aluno.TurmaId == turmaId)
                .OrderByDescending(a => a.TotalParticipacoesInBatalhas)
                .Select((a, index) => new AlunoRankingDTO
                {
                    AlunoId = a.AlunoId,
                    NomeAluno = a.Aluno.Nome,
                    Descricao = "Ranking de alunos na turma por participações em batalhas",
                    Posicao = index + 1,
                    Valor = a.TotalParticipacoesInBatalhas
                })
                .ToListAsync();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosByBatalhasParticipadasInEscola(int escolaId)
        {
            return await _context.AlunoEstatisticas
                .Where(a => a.Aluno.Turma != null && a.Aluno.Turma.EscolaId == escolaId)
                .OrderByDescending(a => a.TotalParticipacoesInBatalhas)
                .Select((a, index) => new AlunoRankingDTO
                {
                    AlunoId = a.AlunoId,
                    NomeAluno = a.Aluno.Nome,
                    Descricao = "Ranking de alunos na escola por participações em batalhas",
                    Posicao = index + 1,
                    Valor = a.TotalParticipacoesInBatalhas
                })
                .ToListAsync();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosByBatalhasVencidasInTurma(int turmaId)
        {
            return await _context.AlunoEstatisticas
                .Where(a => a.Aluno.Turma != null && a.Aluno.TurmaId == turmaId)
                .OrderByDescending(a => a.TotalVitoriasInBatalhas)
                .Select((a, index) => new AlunoRankingDTO
                {
                    AlunoId = a.AlunoId,
                    NomeAluno = a.Aluno.Nome,
                    Descricao = "Ranking de alunos na turma por vitórias em batalhas",
                    Posicao = index + 1,
                    Valor = a.TotalVitoriasInBatalhas
                })
                .ToListAsync();
        }

        public async Task<List<AlunoRankingDTO>> GetRankingAlunosByBatalhasVencidasInEscola(int escolaId)
        {
            return await _context.AlunoEstatisticas
                .Where(a => a.Aluno.Turma != null && a.Aluno.Turma.EscolaId == escolaId)
                .OrderByDescending(a => a.TotalVitoriasInBatalhas)
                .Select((a, index) => new AlunoRankingDTO
                {
                    AlunoId = a.AlunoId,
                    NomeAluno = a.Aluno.Nome,
                    Descricao = "Ranking de alunos na escola por vitórias em batalhas",
                    Posicao = index + 1,
                    Valor = a.TotalVitoriasInBatalhas
                })
                .ToListAsync();
        }

        //---------------------------------------------------------------------
        // RANKING DE TURMAS
        //---------------------------------------------------------------------

        public async Task<List<TurmaRankingDTO>> GetRankingTurmasByAtividadesConcluidasInEscola(int escolaId)
        {
            return await _context.TurmaEstatisticas
                .Where(t => t.Turma.EscolaId == escolaId)
                .OrderByDescending(t => t.AtividadesConcluidas)
                .Select((t, index) => new TurmaRankingDTO
                {
                    TurmaId = t.TurmaId,
                    TurmaDescricao = t.Turma.Descricao,
                    Descricao = "Ranking de turmas na escola por atividades concluídas",
                    Posicao = index + 1,
                    Valor = t.AtividadesConcluidas
                })
                .ToListAsync();
        }

        public async Task<List<TurmaRankingDTO>> GetRankingTurmasByMediaNotasInEscola(int escolaId)
        {
            return await _context.TurmaEstatisticas
                .Where(t => t.Turma.EscolaId == escolaId && t.QuantidadeNotasValidas > 0)
                .OrderByDescending(t => t.MediaNotasNormalizadas)
                .Select((t, index) => new TurmaRankingDTO
                {
                    TurmaId = t.TurmaId,
                    TurmaDescricao = t.Turma.Descricao,
                    Descricao = "Ranking de turmas na escola por média nas atividades",
                    Posicao = index + 1,
                    Valor = t.MediaNotasNormalizadas
                })
                .ToListAsync();
        }

        public async Task<List<TurmaRankingDTO>> GetRankingTurmasByBatalhasParticipadasInEscola(int escolaId)
        {
            return await _context.TurmaEstatisticas
                .Where(t => t.Turma.EscolaId == escolaId)
                .OrderByDescending(t => t.TotalParticipacoesInBatalhas)
                .Select((t, index) => new TurmaRankingDTO
                {
                    TurmaId = t.TurmaId,
                    TurmaDescricao = t.Turma.Descricao,
                    Descricao = "Ranking de turmas na escola por participações em batalhas",
                    Posicao = index + 1,
                    Valor = t.TotalParticipacoesInBatalhas
                })
                .ToListAsync();
        }

        public async Task<List<TurmaRankingDTO>> GetRankingTurmasByBatalhasVencidasInEscola(int escolaId)
        {
            return await _context.TurmaEstatisticas
                .Where(t => t.Turma.EscolaId == escolaId)
                .OrderByDescending(t => t.TotalVitoriasInBatalhas)
                .Select((t, index) => new TurmaRankingDTO
                {
                    TurmaId = t.TurmaId,
                    TurmaDescricao = t.Turma.Descricao,
                    Descricao = "Ranking de turmas na escola por vitórias em batalhas",
                    Posicao = index + 1,
                    Valor = t.TotalVitoriasInBatalhas
                })
                .ToListAsync();
        }

        //---------------------------------------------------------------------
        // RANKING DE ESCOLAS 
        //---------------------------------------------------------------------

        public async Task<List<EscolaRankingDTO>> GetRankingEscolasByAtividadesConcluidas()
        {
            return await _context.EscolaEstatisticas
                .OrderByDescending(e => e.AtividadesConcluidas)
                .Select((e, index) => new EscolaRankingDTO
                {
                    EscolaId = e.EscolaId,
                    EscolaNome = e.Escola.Nome,
                    Descricao = "Ranking de escolas por atividades concluídas",
                    Posicao = index + 1,
                    Valor = e.AtividadesConcluidas
                })
                .ToListAsync();
        }

        public async Task<List<EscolaRankingDTO>> GetRankingEscolasByMediaNotas()
        {
            return await _context.EscolaEstatisticas
                .Where(e => e.QuantidadeNotasValidas > 0)
                .OrderByDescending(e => e.MediaNotasNormalizadas)
                .Select((e, index) => new EscolaRankingDTO
                {
                    EscolaId = e.EscolaId,
                    EscolaNome = e.Escola.Nome,
                    Descricao = "Ranking de escolas por média nas atividades",
                    Posicao = index + 1,
                    Valor = e.MediaNotasNormalizadas
                })
                .ToListAsync();
        }

        public async Task<List<EscolaRankingDTO>> GetRankingEscolasByBatalhasParticipadas()
        {
            return await _context.EscolaEstatisticas
                .OrderByDescending(e => e.TotalParticipacoesInBatalhas)
                .Select((e, index) => new EscolaRankingDTO
                {
                    EscolaId = e.EscolaId,
                    EscolaNome = e.Escola.Nome,
                    Descricao = "Ranking de escolas por participações em batalhas",
                    Posicao = index + 1,
                    Valor = e.TotalParticipacoesInBatalhas
                })
                .ToListAsync();
        }

        public async Task<List<EscolaRankingDTO>> GetRankingEscolasByBatalhasVencidas()
        {
            return await _context.EscolaEstatisticas
                .OrderByDescending(e => e.TotalVitoriasInBatalhas)
                .Select((e, index) => new EscolaRankingDTO
                {
                    EscolaId = e.EscolaId,
                    EscolaNome = e.Escola.Nome,
                    Descricao = "Ranking de escolas por vitórias em batalhas",
                    Posicao = index + 1,
                    Valor = e.TotalVitoriasInBatalhas
                })
                .ToListAsync();
        }
    }
}
