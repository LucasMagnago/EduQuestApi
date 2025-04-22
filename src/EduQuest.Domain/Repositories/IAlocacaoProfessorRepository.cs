using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAlocacaoProfessorRepository : IGenericRepository<AlocacaoProfessor>
    {
        Task<AlocacaoProfessor?> GetByProfessorIdAndDisciplinaIdAndTurmaId(int professorId, int disciplinaId, int turmaId);
        Task<List<AlocacaoProfessor>?> GetAllByProfessorId(int professorId);
        Task<List<AlocacaoProfessor>?> GetAllByProfessorIdAndTurmaId(int professorId, int turmaId);
        Task<List<AlocacaoProfessor>?> GetAllByTurmaId(int turmaId);
        Task<bool> DoesProfessorTeachDisciplinaInTurma(int professorId, int disciplinaId, int turmaId);
    }
}
