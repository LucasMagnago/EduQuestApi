using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAtividadeRepository : IGenericRepository<Atividade>
    {
        Task<List<Atividade>> GetAllAtividadeByAlunoId(int alunoId);
        Task<List<Atividade>> GetAllAtividadeByProfessorId(int professorId);
        Task<List<Atividade>> GetAllAtividadeByTurmaId(int turmaId);
    }
}
