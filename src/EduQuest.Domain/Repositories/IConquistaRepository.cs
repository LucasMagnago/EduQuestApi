using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IConquistaRepository
    {
        Task Add(Conquista conquista);
        Task Delete(Conquista conquista);
        void Update(Conquista conquista);
        Task<Conquista> GetById(long id);
    }
}
