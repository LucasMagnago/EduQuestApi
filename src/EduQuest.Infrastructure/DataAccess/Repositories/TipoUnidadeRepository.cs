using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class TipoUnidadeRepository : ITipoUnidadeRepository
    {
        private readonly EduQuestDbContext _context;

        public TipoUnidadeRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task ITipoUnidadeRepository.Add(TipoUnidade tipoUnidade)
        {
            throw new NotImplementedException();
        }

        Task ITipoUnidadeRepository.Delete(TipoUnidade tipoUnidade)
        {
            throw new NotImplementedException();
        }

        Task<TipoUnidade> ITipoUnidadeRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void ITipoUnidadeRepository.Update(TipoUnidade tipoUnidade)
        {
            throw new NotImplementedException();
        }
    }
}
