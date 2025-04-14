using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class EscolaRepository : IEscolaRepository
    {
        private readonly EduQuestDbContext _context;

        public EscolaRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task IEscolaRepository.Add(Escola escola)
        {
            throw new NotImplementedException();
        }

        Task IEscolaRepository.Delete(Escola escola)
        {
            throw new NotImplementedException();
        }

        Task<Escola> IEscolaRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void IEscolaRepository.Update(Escola escola)
        {
            throw new NotImplementedException();
        }
    }
}
