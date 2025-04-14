using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class DesafioRepository : IDesafioRepository
    {
        private readonly EduQuestDbContext _context;

        public DesafioRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task IDesafioRepository.Add(Desafio desafio)
        {
            throw new NotImplementedException();
        }

        Task IDesafioRepository.Delete(Desafio desafio)
        {
            throw new NotImplementedException();
        }

        Task<Desafio> IDesafioRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void IDesafioRepository.Update(Desafio desafio)
        {
            throw new NotImplementedException();
        }
    }
}
