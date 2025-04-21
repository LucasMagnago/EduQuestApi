using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class TipoUnidadeRepository : GenericRepository<TipoUnidade>, ITipoUnidadeRepository
    {
        public TipoUnidadeRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
