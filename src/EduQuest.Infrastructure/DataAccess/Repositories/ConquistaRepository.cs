using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class ConquistaRepository : IConquistaRepository
    {
        private readonly EduQuestDbContext _context;

        public ConquistaRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task IConquistaRepository.Add(Conquista conquista)
        {
            throw new NotImplementedException();
        }

        Task IConquistaRepository.Delete(Conquista conquista)
        {
            throw new NotImplementedException();
        }

        Task<Conquista> IConquistaRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void IConquistaRepository.Update(Conquista conquista)
        {
            throw new NotImplementedException();
        }
    }
}
