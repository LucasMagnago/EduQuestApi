using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class QuestaoRepository : GenericRepository<Questao>, IQuestaoRepository
    {
        public QuestaoRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<List<Questao>> GetAllByDisciplinaId(int disciplinaId)
        {
            return await _entity
                .Include(q => q.Alternativas)
                .Include(q => q.AlternativaCorreta)
                .Where(q => q.DisciplinaId == disciplinaId)
                .ToListAsync();
        }

        public async Task<List<Questao>> GetAllByDisciplinaIdAndNivel(int disciplinaId, int nivel)
        {
            return await _entity
                .Include(q => q.Alternativas)
                .Include(q => q.AlternativaCorreta)
                .Where(q => q.DisciplinaId == disciplinaId && q.NivelEscolar == nivel)
                .ToListAsync();
        }

        public async Task<List<Questao>> GetAllByProfessorId(int professorId)
        {
            return await _entity
                .Include(q => q.Alternativas)
                .Include(q => q.AlternativaCorreta)
                .Where(q => q.UsuarioCriacaoId == professorId)
                .ToListAsync();
        }

        public async Task<List<Questao>> GetRandomQuestoesAsync(int count)
        {
            return await _context.Questoes
                             .Include(q => q.Alternativas)
                             .Take(count)
                             .ToListAsync();
        }
    }
}
