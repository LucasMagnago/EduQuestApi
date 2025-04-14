using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IQuestaoRepository
    {
        Task Add(Questao questao);
        Task Delete(Questao questao);
        void Update(Questao questao);
        Task<Questao> GetById(long id);
    }
}
