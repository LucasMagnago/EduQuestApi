using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface ITurmaRepository
    {
        Task Add(Turma turma);
        Task Delete(Turma turma);
        void Update(Turma turma);
        Task<Turma> GetById(long id);
    }
}
