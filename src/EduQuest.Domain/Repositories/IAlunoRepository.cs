using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAlunoRepository
    {
        Task Add(Aluno aluno);
        Task Delete(Aluno aluno);
        void Update(Aluno aluno);
        Task<Aluno> GetById(int id);
        Task<bool> Matricular(int turmaId);
        Task<bool> Remanejar(int turmaDestinoId);
    }
}
