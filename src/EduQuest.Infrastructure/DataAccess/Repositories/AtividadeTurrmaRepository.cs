using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AtividadeTurmaRepository : GenericRepository<AtividadeTurma>, IAtividadeTurmaRepository
    {
        public AtividadeTurmaRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
