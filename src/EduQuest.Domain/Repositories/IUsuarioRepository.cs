using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IUsuarioRepository
    {
        Task Add(Usuario usuario);
        Task Delete(Usuario usuario);
        void Update(Usuario usuario);
        Task<Usuario> GetById(long id);
        Task<bool> ExistActiveUserWithEmail(string email);
        Task<Usuario?> GetUserByEmail(string email);
    }
}
