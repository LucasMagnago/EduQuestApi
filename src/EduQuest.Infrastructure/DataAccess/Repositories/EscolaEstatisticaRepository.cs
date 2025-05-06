using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class EscolaEstatisticaRepository : GenericRepository<EscolaEstatistica>, IEscolaEstatisticaRepository
    {
        public EscolaEstatisticaRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
