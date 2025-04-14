using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AlternativaRepository : IAlternativaRepository
    {
        private readonly EduQuestDbContext _context;

        public AlternativaRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task IAlternativaRepository.Add(Alternativa alternativa)
        {
            throw new NotImplementedException();
        }

        Task IAlternativaRepository.Delete(Alternativa alternativa)
        {
            throw new NotImplementedException();
        }

        Task<Alternativa> IAlternativaRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void IAlternativaRepository.Update(Alternativa alternativa)
        {
            throw new NotImplementedException();
        }
    }
}
