using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class BatalhaRepository : GenericRepository<Batalha>, IBatalhaRepository
    {
        public BatalhaRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
