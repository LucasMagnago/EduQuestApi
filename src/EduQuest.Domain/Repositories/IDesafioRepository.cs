using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IDesafioRepository
    {
        Task Add(Desafio desafio);
        Task Delete(Desafio desafio);
        void Update(Desafio desafio);
        Task<Desafio> GetById(long id);
    }
}
