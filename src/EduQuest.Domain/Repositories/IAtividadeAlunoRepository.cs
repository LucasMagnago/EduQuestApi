using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAtividadeAlunoRepository : IGenericRepository<AtividadeAluno>
    {
        Task<AtividadeAluno?> GetByAlunoIdAndAtividadeId(int alunoId, int atividadeId);
        Task<AtividadeAluno?> GetWithRelationsByAlunoIdAndAtividadeId(int alunoId, int atividadeId);
        Task<int> CountCorrectAnswers(int atividadeAlunoId);
        Task<bool> CheckIfAlunoAlreadyStartedAtividade(int alunoId, int atividadeId);
    }
}
