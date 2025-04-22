using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class PerfilRepository : GenericRepository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(EduQuestDbContext context) : base(context)
        {
        }
    }
}
