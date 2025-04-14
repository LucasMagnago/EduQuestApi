using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly EduQuestDbContext _context;

        public DisciplinaRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task IDisciplinaRepository.Add(Disciplina disciplina)
        {
            throw new NotImplementedException();
        }

        Task IDisciplinaRepository.Delete(Disciplina disciplina)
        {
            throw new NotImplementedException();
        }

        Task<Disciplina> IDisciplinaRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void IDisciplinaRepository.Update(Disciplina disciplina)
        {
            throw new NotImplementedException();
        }
    }
}
