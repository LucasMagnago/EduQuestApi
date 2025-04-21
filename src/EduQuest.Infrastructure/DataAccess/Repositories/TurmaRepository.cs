using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class TurmaRepository : GenericRepository<Turma>, ITurmaRepository
    {
        public TurmaRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
