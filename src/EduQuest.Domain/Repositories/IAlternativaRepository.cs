using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAlternativaRepository
    {
        Task Add(Alternativa alternativa);
        Task Delete(Alternativa alternativa);
        void Update(Alternativa alternativa);
        Task<Alternativa> GetById(long id);
    }
}
