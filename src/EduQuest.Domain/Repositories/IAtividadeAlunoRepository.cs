using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAtividadeAlunoRepository : IGenericRepository<AtividadeAluno>
    {
        Task<AtividadeAluno?> GetByAlunoIdAndAtividadeId(int alunoId, int atividadeId);
        Task<int> GetQuantidadeAcertos(int atividadeAlunoId);
        Task<bool> CheckIfAlunoAlreadyStartedAtividade(int alunoId, int atividadeId);
    }
}
