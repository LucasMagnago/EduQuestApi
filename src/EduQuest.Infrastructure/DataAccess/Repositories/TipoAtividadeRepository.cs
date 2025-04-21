using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class TipoAtividadeRepository : GenericRepository<TipoAtividade>, ITipoAtividadeRepository
    {
        public TipoAtividadeRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
