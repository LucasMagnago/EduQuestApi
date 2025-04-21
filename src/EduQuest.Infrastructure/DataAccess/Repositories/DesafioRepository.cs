using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class DesafioRepository : GenericRepository<Desafio>, IDesafioRepository
    {
        public DesafioRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
