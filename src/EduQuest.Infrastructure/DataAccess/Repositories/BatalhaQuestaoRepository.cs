using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class BatalhaQuestaoRepository : GenericRepository<BatalhaQuestao>, IBatalhaQuestaoRepository
    {
        public BatalhaQuestaoRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
