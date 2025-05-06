using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class TurmaEstatisticaRepository : GenericRepository<TurmaEstatistica>, ITurmaEstatisticaRepository
    {
        public TurmaEstatisticaRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
