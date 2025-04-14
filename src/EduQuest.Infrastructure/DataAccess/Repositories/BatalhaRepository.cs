using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class BatalhaRepository : IBatalhaRepository
    {
        private readonly EduQuestDbContext _context;

        public BatalhaRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task IBatalhaRepository.Add(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        Task IBatalhaRepository.Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        Task<Usuario> IBatalhaRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void IBatalhaRepository.Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
