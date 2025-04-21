using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class EscolaRepository : GenericRepository<Escola>, IEscolaRepository
    {
        public EscolaRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
