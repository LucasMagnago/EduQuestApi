using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class TurmaRepository : ITurmaRepository
    {
        private readonly EduQuestDbContext _context;

        public TurmaRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        Task ITurmaRepository.Add(Turma turma)
        {
            throw new NotImplementedException();
        }

        Task ITurmaRepository.Delete(Turma turma)
        {
            throw new NotImplementedException();
        }

        Task<Turma> ITurmaRepository.GetById(long id)
        {
            throw new NotImplementedException();
        }

        void ITurmaRepository.Update(Turma turma)
        {
            throw new NotImplementedException();
        }
    }
}
