using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IUsuarioRepository : IGenericRepository<Usuario>
    {
        Task<Usuario?> GetByGuid(Guid guid);
        Task<Usuario?> GetByEmail(string email);
        Task<List<Usuario>?> GetAllByEscolaId(int escolaId);
        Task<List<Usuario>?> GetAllByPerfilId(int perfilId);
        Task<List<Usuario>?> GetAllByPerfilIdAndEscolaId(int perfilId, int escolaId);
        Task<List<Usuario>?> GetAllByListPerfilId(List<int> lstPerfilId);
        Task<List<Usuario>?> GetAllByListPerfilIdAndEscolaId(List<int> lstPerfilId, int escolaId);
        Task<bool> ExistsActiveUsuarioWithEmail(string email);

    }
}
