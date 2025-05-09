using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAlunoRepository : IGenericRepository<Aluno>
    {
        Task<Aluno?> GetByAlunoId(int alunoId);
        Task<Aluno?> GetByUsuarioGuid(Guid usuarioGuid);
        Task<List<Aluno>?> GetAllByTurmaId(int turmaId);
        Task<List<Aluno>?> GetAllByEscolaId(int escolaId);
        Task<bool> ExistAlunoWithUsuarioGuid(Guid usuarioGuid);
        Task<Turma?> GetTurmaByAlunoId(int alunoId);
        Task<Escola?> GetEscolaByAlunoId(int alunoId);
    }
}
