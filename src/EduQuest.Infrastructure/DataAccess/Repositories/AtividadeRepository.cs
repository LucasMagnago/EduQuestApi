using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AtividadeRepository : IAtividadeRepository
    {
        private readonly EduQuestDbContext _context;

        public AtividadeRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task IAtividadeRepository.Add(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        Task IAtividadeRepository.Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        Task<Usuario> IAtividadeRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void IAtividadeRepository.Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
