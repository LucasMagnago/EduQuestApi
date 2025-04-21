using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class PeriodoLetivoRepository : GenericRepository<PeriodoLetivo>, IPeriodoLetivoRepository
    {
        public PeriodoLetivoRepository(EduQuestDbContext context) : base(context)
        {
        }
    }
}
