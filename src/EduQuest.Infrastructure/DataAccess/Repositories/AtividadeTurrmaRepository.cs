using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AtividadeTurmaRepository : GenericRepository<AtividadeTurma>, IAtividadeTurmaRepository
    {
        public AtividadeTurmaRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<DateTime> GetDataEntregaAtividade(int atividadeTurmaId)
        {
            return await _entity.Where(at => at.Id == atividadeTurmaId)
                .Select(at => at.DataEntrega)
                .FirstOrDefaultAsync();
        }

        public async Task<DateTime> GetDataEntregaAtividade(int atividadeId, int turmaId)
        {
            return await _entity
                .Where(at => at.AtividadeId == atividadeId && at.TurmaId == turmaId)
                .Select(at => at.DataEntrega)
                .FirstOrDefaultAsync();
        }
    }
}
