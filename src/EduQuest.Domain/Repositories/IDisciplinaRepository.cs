using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IDisciplinaRepository
    {
        Task Add(Disciplina disciplina);
        Task Delete(Disciplina disciplina);
        void Update(Disciplina disciplina);
        Task<Disciplina> GetById(long id);
    }
}
