using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IDesafioCondicaoBatalhaRepository
    {
        Task Add(Usuario usuario);
        Task Delete(Usuario usuario);
        void Update(Usuario usuario);
        Task<Usuario> GetById(long id);
    }
}
