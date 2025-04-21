using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AlternativaRepository : GenericRepository<Alternativa>, IAlternativaRepository
    {
        public AlternativaRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
