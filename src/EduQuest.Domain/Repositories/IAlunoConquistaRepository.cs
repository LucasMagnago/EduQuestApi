using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAlunoConquistaRepository : IGenericRepository<AlunoConquista>
    {
        Task<List<AlunoConquista>?> GetAllByAlunoId(int alunoId);
    }
}
