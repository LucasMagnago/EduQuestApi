﻿using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AtividadeRepository : GenericRepository<Atividade>, IAtividadeRepository
    {
        public AtividadeRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<int> CountQuestionsByAtividadeId(int atividadeId)
        {
            return await _context.AtividadeQuestoes
                .Where(aq => aq.AtividadeId == atividadeId)
                .CountAsync();
        }

        public async Task<List<Atividade>> GetAllAtividadeByAlunoId(int alunoId)
        {
            return await _entity
            .Include(a => a.AtividadeTurmas)
            .Include(a => a.AtividadeAlunos)
            .Where(a => a.AtividadeAlunos.Any(aa => aa.AlunoId == alunoId))
            .ToListAsync();
        }

        public async Task<List<Atividade>> GetAllAtividadeByProfessorId(int professorId)
        {
            return await _entity
            .Include(a => a.AtividadeTurmas)
            .Include(a => a.Professor)
            .Where(a => a.ProfessorId == professorId)
            .ToListAsync();
        }

        public async Task<List<Atividade>> GetAllAtividadeByTurmaId(int turmaId)
        {
            return await _entity
            .Include(a => a.AtividadeTurmas)
            .Where(a => a.AtividadeTurmas.Any(at => at.TurmaId == turmaId))
            .ToListAsync();
        }

        public async Task<List<Atividade>> GetAllAvailableAtividadeByAlunoId(int alunoId)
        {
            return await _entity
            .Include(a => a.AtividadeTurmas)
            .Include(a => a.AtividadeAlunos)
            .Where(a => a.AtividadeAlunos.Any(aa => aa.AlunoId == alunoId) && a.AtividadeTurmas.Any(at => at.DataEntrega <= DateTime.Now))
            .ToListAsync();
        }

        public async Task<List<Atividade>> GetAllAvailableAtividadeByProfessorId(int professorId)
        {
            return await _entity
            .Include(a => a.AtividadeTurmas)
            .Include(a => a.Professor)
            .Where(a => a.ProfessorId == professorId && a.AtividadeTurmas.Any(at => at.DataEntrega <= DateTime.Now))
            .ToListAsync();
        }

        public async Task<List<Atividade>> GetAllAvailableAtividadeByTurmaId(int turmaId)
        {
            return await _entity
            .Include(a => a.AtividadeTurmas)
            .Where(a => a.AtividadeTurmas.Any(at => at.TurmaId == turmaId && at.DataEntrega <= DateTime.Now))
            .ToListAsync();
        }
    }
}
