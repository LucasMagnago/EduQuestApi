using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class TipoAtividadeRepository : ITipoAtividadeRepository
    {
        private readonly EduQuestDbContext _context;

        public TipoAtividadeRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task ITipoAtividadeRepository.Add(TipoAtividade tipoAtividade)
        {
            throw new NotImplementedException();
        }

        Task ITipoAtividadeRepository.Delete(TipoAtividade tipoAtividade)
        {
            throw new NotImplementedException();
        }

        Task<TipoAtividade> ITipoAtividadeRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void ITipoAtividadeRepository.Update(TipoAtividade tipoAtividade)
        {
            throw new NotImplementedException();
        }
    }
}
