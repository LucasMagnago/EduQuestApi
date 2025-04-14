using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IEscolaRepository
    {
        Task Add(Escola escola);
        Task Delete(Escola escola);
        void Update(Escola escola);
        Task<Escola> GetById(long id);
    }
}
