using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class MensagemRepository : GenericRepository<Mensagem>, IMensagemRepository
    {
        public MensagemRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
