using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AtividadeRepository : GenericRepository<Atividade>, IAtividadeRepository
    {
        public AtividadeRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<List<Atividade>> GetAllAtividadeByAlunoId(int alunoId)
        {
            return await _context.Atividades
            .Include(a => a.AlunoRealizaAtividades)
            .Where(a => a.AlunoRealizaAtividades.Any(aa => aa.AlunoId == alunoId))
            .ToListAsync();
        }

        public async Task<List<Atividade>> GetAllAtividadeByProfessorId(int professorId)
        {
            return await _context.Atividades
            .Include(a => a.Professor)
            .Where(a => a.ProfessorId == professorId)
            .ToListAsync();
        }

        public async Task<List<Atividade>> GetAllAtividadeByTurmaId(int turmaId)
        {
            return await _context.Atividades
            .Include(a => a.AtividadeTurmas)
            .Where(a => a.AtividadeTurmas.Any(at => at.TurmaId == turmaId))
            .ToListAsync();
        }
    }
}
