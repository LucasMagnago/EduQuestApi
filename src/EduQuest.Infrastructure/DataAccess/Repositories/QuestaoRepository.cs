using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class QuestaoRepository : GenericRepository<Questao>, IQuestaoRepository
    {
        public QuestaoRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
