using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AtividadeRespostaRepository : GenericRepository<AtividadeResposta>, IAtividadeRespostaRepository
    {
        public AtividadeRespostaRepository(EduQuestDbContext context) : base(context)
        {

        }
    }
}
