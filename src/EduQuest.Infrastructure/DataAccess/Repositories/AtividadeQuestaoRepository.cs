using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AtividadeQuestaoRepository : GenericRepository<AtividadeQuestao>, IAtividadeQuestaoRepository
    {
        public AtividadeQuestaoRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<bool> HasQuestionBeenAddedToActivity(int atividadeId, int questaoId)
        {
            return await _entity
                .Where(aq => aq.AtividadeId == atividadeId && aq.QuestaoId == questaoId)
                .AnyAsync();
        }

        public async Task<List<Questao>> GetAllQuestaoByAtividadeId(int atividadeId)
        {
            return await _entity
                .Include(aq => aq.Questao)
                    .ThenInclude(q => q.Alternativas)
                .Where(aq => aq.AtividadeId == atividadeId)
                .OrderBy(aq => aq.Ordem)
                .Select(aq => aq.Questao)
                .ToListAsync();
        }
    }
}
