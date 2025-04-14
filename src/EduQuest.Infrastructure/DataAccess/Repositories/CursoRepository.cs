using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class CursoRepository : ICursoRepository
    {
        private readonly EduQuestDbContext _context;

        public CursoRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task ICursoRepository.Add(Curso curso)
        {
            throw new NotImplementedException();
        }

        Task ICursoRepository.Delete(Curso curso)
        {
            throw new NotImplementedException();
        }

        Task<Curso> ICursoRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void ICursoRepository.Update(Curso curso)
        {
            throw new NotImplementedException();
        }
    }
}
