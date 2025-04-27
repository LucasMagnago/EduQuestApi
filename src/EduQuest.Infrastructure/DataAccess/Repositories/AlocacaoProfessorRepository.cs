using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AlocacaoProfessorRepository : GenericRepository<AlocacaoProfessor>, IAlocacaoProfessorRepository
    {
        public AlocacaoProfessorRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<List<AlocacaoProfessor>?> GetAllByProfessorId(int professorId)
        {
            return await _entity
                .Where(a => a.ProfessorId == professorId)
                .ToListAsync();
        }

        public async Task<List<AlocacaoProfessor>?> GetAllByProfessorIdAndTurmaId(int professorId, int turmaId)
        {
            return await _entity
                .Where(a => a.ProfessorId == professorId && a.TurmaId == turmaId)
                .ToListAsync();
        }

        public async Task<List<AlocacaoProfessor>?> GetAllByTurmaId(int turmaId)
        {
            return await _entity
                .Where(a => a.TurmaId == turmaId)
                .ToListAsync();
        }

        public async Task<bool> DoesProfessorTeachDisciplinaInTurma(int professorId, int disciplinaId, int turmaId)
        {
            return await _entity
                .Where(a => a.ProfessorId == professorId &&
                    a.DisciplinaId == disciplinaId &&
                    a.TurmaId == turmaId)
                .AnyAsync();
        }

        public async Task<AlocacaoProfessor?> GetByProfessorIdAndDisciplinaIdAndTurmaId(int professorId, int disciplinaId, int turmaId)
        {
            return await _entity
                .Where(a => a.ProfessorId == professorId &&
                    a.DisciplinaId == disciplinaId &&
                    a.TurmaId == turmaId)
                .FirstOrDefaultAsync();
        }
    }
}
