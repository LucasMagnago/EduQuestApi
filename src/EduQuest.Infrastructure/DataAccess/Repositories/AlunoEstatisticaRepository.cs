using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AlunoEstatisticaRepository : GenericRepository<AlunoEstatistica>, IAlunoEstatisticaRepository
    {
        public AlunoEstatisticaRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
