using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario?> GetByGuid(Guid guid);
        Task<Usuario?> GetByEmail(string email);
        Task<bool> ExistsActiveUsuarioWithEmail(string email);

    }
}
