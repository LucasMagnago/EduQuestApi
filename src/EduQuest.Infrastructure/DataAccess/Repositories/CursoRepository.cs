using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class CursoRepository : GenericRepository<Curso>, ICursoRepository
    {
        public CursoRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
