using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAlunoRepository : IGenericRepository<Aluno>
    {
        Task<Aluno?> GetByUsuarioGuid(Guid usuarioGuid);
        Task<bool> ExistAlunoWithUsuarioGuid(Guid usuarioGuid);
    }
}
