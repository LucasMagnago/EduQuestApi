using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AtividadeRepository : GenericRepository<Atividade>, IAtividadeRepository
    {
        public AtividadeRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
