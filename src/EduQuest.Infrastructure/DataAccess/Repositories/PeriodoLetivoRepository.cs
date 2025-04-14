using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class PeriodoLetivoRepository : IPeriodoLetivoRepository
    {
        private readonly EduQuestDbContext _context;

        public PeriodoLetivoRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task IPeriodoLetivoRepository.Add(PeriodoLetivo periodoLetivo)
        {
            throw new NotImplementedException();
        }

        Task IPeriodoLetivoRepository.Delete(PeriodoLetivo periodoLetivo)
        {
            throw new NotImplementedException();
        }

        Task<PeriodoLetivo> IPeriodoLetivoRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void IPeriodoLetivoRepository.Update(PeriodoLetivo periodoLetivo)
        {
            throw new NotImplementedException();
        }
    }
}
