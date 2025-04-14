using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface ICursoRepository
    {
        Task Add(Curso curso);
        Task Delete(Curso curso);
        void Update(Curso curso);
        Task<Curso> GetById(long id);
    }
}
