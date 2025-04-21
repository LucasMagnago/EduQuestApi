using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class ConquistaRepository : GenericRepository<Conquista>, IConquistaRepository
    {
        public ConquistaRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
