using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAtividadeQuestaoRepository : IGenericRepository<AtividadeQuestao>
    {
        Task<bool> HasQuestionBeenAddedToActivity(int atividadeId, int questaoId);
        Task<List<Questao>> GetAllQuestaoByAtividadeId(int atividadeId);
    }
}
