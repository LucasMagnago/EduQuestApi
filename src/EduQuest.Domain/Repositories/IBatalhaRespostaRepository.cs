using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IBatalhaRespostaRepository : IGenericRepository<BatalhaResposta>
    {
        Task<BatalhaResposta?> GetBatalhaRespostaByAlunoIdAndBatalhaIdAndQuestaoIdAsync(int alunoId, int batalhaId, int questaoId);
        Task<int> CountCorrectRespostasForAlunoInBatalhaAsync(int alunoId, int batalhaId);
    }
}


